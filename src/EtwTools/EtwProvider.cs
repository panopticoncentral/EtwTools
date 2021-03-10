using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace EtwTools
{
    /// <summary>
    /// Represents an ETW event provider.
    /// </summary>
    public sealed unsafe class EtwProvider
    {
        /// <summary>
        /// The name of the provider (may be null).
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The ID of the provider.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Creates a provider with a specified name and ID.
        /// </summary>
        /// <param name="name">The name of the provider.</param>
        /// <param name="id">The ID of the provider.</param>
        public EtwProvider(string name, Guid id)
        {
            Name = name;
            Id = id;
        }

        /// <summary>
        /// Gets the provider that corresponds to an EventSource.
        /// </summary>
        /// <param name="eventSource">The name of the event source.</param>
        /// <returns>The provider.</returns>
        public static EtwProvider GetProviderForEventSource(string eventSource)
        {
            // Follow the convention for turning an EventSource name into a GUID.

            if (eventSource[0] == '*')
            {
                eventSource = eventSource[1..];
            }

            eventSource = eventSource.ToUpperInvariant();

            var bytes = new byte[(eventSource.Length * 2) + 16];

            var namespace1 = 0x482C2DB2u;
            var namespace2 = 0xC39047C8u;
            var namespace3 = 0x87F81A15u;
            var namespace4 = 0xBFC130FBu;

            for (var index = 3; 0 <= index; --index)
            {
                bytes[index] = (byte)namespace1;
                namespace1 >>= 8;
                bytes[index + 4] = (byte)namespace2;
                namespace2 >>= 8;
                bytes[index + 8] = (byte)namespace3;
                namespace3 >>= 8;
                bytes[index + 12] = (byte)namespace4;
                namespace4 >>= 8;
            }

            for (var index = 0; index < eventSource.Length; index++)
            {
                bytes[(2 * index) + 16 + 1] = (byte)eventSource[index];
                bytes[(2 * index) + 16] = (byte)(eventSource[index] >> 8);
            }

#pragma warning disable CA5350 // Do Not Use Weak Cryptographic Algorithms
            var sha1 = SHA1.Create();
#pragma warning restore CA5350 // Do Not Use Weak Cryptographic Algorithms
            var hash = sha1.ComputeHash(bytes);

            var a = (((((hash[3] << 8) + hash[2]) << 8) + hash[1]) << 8) + hash[0];
            var b = (short)((hash[5] << 8) + hash[4]);
            var c = (short)((hash[7] << 8) + hash[6]);

            c = (short)((c & 0x0FFF) | 0x5000);
            var guid = new Guid(a, b, c, hash[8], hash[9], hash[10], hash[11], hash[12], hash[13], hash[14], hash[15]);

            return new EtwProvider(eventSource, guid);
        }

        /// <summary>
        /// Returns information about instance of the provider.
        /// </summary>
        /// <returns></returns>
        public IReadOnlyList<InstanceInfo> GetInstanceInfos()
        {
            var providerGuid = Id;
            var hr = (Native.Hresult)Native.EnumerateTraceGuidsEx(Native.TraceQueryInfoClass.TraceGuidQueryInfo, &providerGuid, sizeof(Guid), null, 0, out var bufferSize);
            if (hr != Native.Hresult.ErrorInsufficientBuffer)
            {
                hr.ThrowException();
            }

            var buffer = stackalloc byte[bufferSize];
            ((Native.Hresult)Native.EnumerateTraceGuidsEx(Native.TraceQueryInfoClass.TraceGuidQueryInfo, &providerGuid, sizeof(Guid), buffer, bufferSize, out bufferSize)).ThrowException();

            var current = buffer;
            var providerInfoCount = *(uint*)current;
            current += sizeof(uint) * 2;

            var result = new List<InstanceInfo>();
            for (var infoIndex = 0; infoIndex < providerInfoCount; infoIndex++)
            {
                var currentProviderInfo = (Native.TraceProviderInstanceInfo*)current;
                current += sizeof(Native.TraceProviderInstanceInfo);

                if (currentProviderInfo->EnableCount > 0)
                {
                    var enableInfos = new List<EnableInfo>();
                    for (var enableIndex = 0; enableIndex < currentProviderInfo->EnableCount; enableIndex++)
                    {
                        var enableInfo = (Native.TraceEnableInfo*)current;
                        current += sizeof(Native.TraceEnableInfo);
                        enableInfos.Add(new(enableInfo->Level, enableInfo->EnableProperty, enableInfo->MatchAnyKeyword, enableInfo->MatchAllKeyword));
                    }

                    result.Add(new(currentProviderInfo->Pid, currentProviderInfo->Flags, enableInfos));
                }

                if (currentProviderInfo->NextOffset == 0)
                {
                    break;
                }

                current = (byte*)currentProviderInfo + currentProviderInfo->NextOffset;
            }

            return result;
        }

        /// <summary>
        /// Returns a list of all published providers on the system.
        /// </summary>
        /// <returns>The published providers on the system.</returns>
        public static IReadOnlyList<EtwProvider> GetPublishedProviders()
        {
            var hr = (Native.Hresult)Native.TdhEnumerateProviders(null, out var bufferSize);

            if (hr != Native.Hresult.ErrorInsufficientBuffer)
            {
                hr.ThrowException();
            }

            var buffer = stackalloc byte[bufferSize];

            ((Native.Hresult)Native.TdhEnumerateProviders(buffer, out bufferSize)).ThrowException();

            var providerCount = *(uint*)buffer;
            var providers = (Native.TraceProviderInfo*)(buffer + (sizeof(uint) * 2));
            var result = new List<EtwProvider>((int)providerCount);

            for (var index = 0; index < providerCount; index++)
            {
                var name = new string((char*)&buffer[providers[index].ProviderNameOffset]);
                result.Add(new(name, providers[index].ProviderGuid));
            }

            return result;
        }

        /// <summary>
        /// Returns a list of all providers registered on the system.
        /// </summary>
        /// <returns>The registered providers on the system.</returns>
        public static IReadOnlyList<EtwProvider> GetRegisteredProviders()
        {
            var hr = (Native.Hresult)Native.EnumerateTraceGuidsEx(Native.TraceQueryInfoClass.TraceGuidQueryList, null, 0, null, 0, out var bufferSizeNeeded);
            if (hr != Native.Hresult.ErrorInsufficientBuffer)
            {
                hr.ThrowException();
            }

            var buffer = stackalloc byte[bufferSizeNeeded];
            ((Native.Hresult)Native.EnumerateTraceGuidsEx(Native.TraceQueryInfoClass.TraceGuidQueryList, null, 0, buffer, bufferSizeNeeded, out bufferSizeNeeded)).ThrowException();

            var registeredProviders = GetPublishedProviders();
            Dictionary<Guid, string> providerIdMap = new();

            // There may be duplicates, but this is just a best guess...
            foreach (var registeredProvider in registeredProviders.Where(p => !string.IsNullOrEmpty(p.Name)))
            {
                providerIdMap[registeredProvider.Id] = registeredProvider.Name;
            }

            var guids = (Guid*)buffer;
            var count = bufferSizeNeeded / sizeof(Guid);
            var result = new List<EtwProvider>(count);
            for (var index = 0; index < count; index++)
            {
                _ = providerIdMap.TryGetValue(guids[index], out var name);
                result.Add(new EtwProvider(name, guids[index]));
            }

            return result;
        }

        /// <summary>
        /// Gets descriptions of events supported by this provider.
        /// </summary>
        /// <returns>A list of event descriptors.</returns>
        public IReadOnlyList<EtwEventDescriptor> GetEventDescriptors()
        {
            var providerGuid = Id;
            var hr = (Native.Hresult)Native.TdhEnumerateManifestProviderEvents(&providerGuid, null, out var bufferSize);
            if (hr != Native.Hresult.ErrorInsufficientBuffer)
            {
                // There are lots of error codes possible here, so just fail.
                return null;
            }

            var buffer = stackalloc byte[(int)bufferSize];
            var providerEventInfo = (Native.ProviderEventInfo*)buffer;
            ((Native.Hresult)Native.TdhEnumerateManifestProviderEvents(&providerGuid, providerEventInfo, out bufferSize)).ThrowException();

            var infos = new EtwEventDescriptor[providerEventInfo->NumberOfEvents];
            for (var i = 0; i < providerEventInfo->NumberOfEvents; i++)
            {
                var eventDescriptor = (Native.EventDescriptor*)(buffer + sizeof(Native.ProviderEventInfo) + (i * sizeof(Native.EventDescriptor)));

                uint eventBufferSize = 0;
                hr = (Native.Hresult)Native.TdhGetManifestEventInformation(&providerGuid, eventDescriptor, null, &eventBufferSize);
                if (hr == Native.Hresult.ErrorInsufficientBuffer)
                {
                    fixed (byte* eventBuffer = new byte[(int)eventBufferSize])
                    {
                        var eventInfo = (Native.TraceEventInfo*)eventBuffer;
                        ((Native.Hresult)Native.TdhGetManifestEventInformation(&providerGuid, eventDescriptor, eventInfo, &eventBufferSize)).ThrowException();

                        infos[i] = new EtwEventDescriptor
                        {
                            Name = eventInfo->DecodingSource switch
                            {
                                Native.DecodingSource.XmlFile or Native.DecodingSource.Tlg => eventInfo->EventNameOffset != 0 ? new string((char*)(eventBuffer + eventInfo->EventNameOffset)) : string.Empty,
                                Native.DecodingSource.Wbem => eventInfo->TaskNameOffset != 0 ? new string((char*)(eventBuffer + eventInfo->TaskNameOffset)) : string.Empty,
                                _ => string.Empty
                            },
                            Id = eventDescriptor->Id,
                            Version = eventDescriptor->Version,
                            Channel = eventDescriptor->Channel,
                            ChannelName = eventInfo->ChannelNameOffset != 0 ? new string((char*)(eventBuffer + eventInfo->ChannelNameOffset)) : string.Empty,
                            Level = eventDescriptor->Level,
                            LevelName = eventInfo->LevelNameOffset != 0 ? new string((char*)(eventBuffer + eventInfo->LevelNameOffset)) : string.Empty,
                            Opcode = eventDescriptor->Opcode,
                            OpcodeName = eventInfo->OpcodeNameOffset != 0 ? new string((char*)(eventBuffer + eventInfo->OpcodeNameOffset)) : string.Empty,
                            Task = eventDescriptor->Task,
                            TaskName = eventInfo->DecodingSource switch
                            {
                                Native.DecodingSource.XmlFile => eventInfo->TaskNameOffset != 0  ? new string((char*)(eventBuffer + eventInfo->TaskNameOffset)) : string.Empty,
                                _ => string.Empty
                            },
                            Keyword = eventDescriptor->Keyword,
                            KeywordName = eventInfo->KeywordsNameOffset != 0 ? new string((char*)(eventBuffer + eventInfo->KeywordsNameOffset)) : string.Empty,
                            Message = eventInfo->EventMessageOffset != 0 ? new string((char*)(eventBuffer + eventInfo->EventMessageOffset)) : string.Empty,
                            ActivityIdName = eventInfo->DecodingSource switch
                            {
                                Native.DecodingSource.Wbem => eventInfo->EventNameOffset != 0 ? new string((char*)(eventBuffer + eventInfo->EventNameOffset)) : string.Empty,
                                _ => string.Empty
                            },
                            EventAttributes = eventInfo->DecodingSource switch
                            {
                                Native.DecodingSource.XmlFile => eventInfo->EventAttributesOffset != 0 ? new string((char*)(eventBuffer + eventInfo->EventAttributesOffset)) : string.Empty,
                                _ => string.Empty
                            },
                            RelatedActivityIdName = eventInfo->DecodingSource switch
                            {
                                Native.DecodingSource.Wbem => eventInfo->EventAttributesOffset != 0 ? new string((char*)(eventBuffer + eventInfo->EventAttributesOffset)) : string.Empty,
                                _ => string.Empty
                            },
                        };
                    }
                }
                else
                {
                    infos[i] = new EtwEventDescriptor
                    {
                        Id = eventDescriptor->Id,
                        Version = eventDescriptor->Version,
                        Channel = eventDescriptor->Channel,
                        Level = eventDescriptor->Level,
                        Opcode = eventDescriptor->Opcode,
                        Task = eventDescriptor->Task,
                        Keyword = eventDescriptor->Keyword
                    };
                }
            }

            return infos;
        }

        /// <summary>
        /// Information about an instance of this provider.
        /// </summary>
        public readonly struct InstanceInfo
        {
            /// <summary>
            /// The process ID of the instance.
            /// </summary>
            public uint ProcessId { get; }

            /// <summary>
            /// Properties of the instance.
            /// </summary>
            public TraceInstanceProperties Properties { get; }

            /// <summary>
            /// Information about each way the provider was enabled.
            /// </summary>
            public IReadOnlyList<EnableInfo> EnableInfos { get; }

            internal InstanceInfo(uint processId, TraceInstanceProperties properties, IReadOnlyList<EnableInfo> enableInfos)
            {
                ProcessId = processId;
                Properties = properties;
                EnableInfos = enableInfos;
            }
        }

        /// <summary>
        /// Information about an instance of a provider being enabled.
        /// </summary>
        public readonly struct EnableInfo
        {
            /// <summary>
            /// The information level enabled.
            /// </summary>
            public TraceLevel Level { get; }

            /// <summary>
            /// Optional properties that are enabled.
            /// </summary>
            public TraceProperties EnableProperty { get; }

            /// <summary>
            /// Bitmask of keywords that determine the category of events the provider should write.
            /// </summary>
            public ulong MatchAnyKeyword { get; }

            /// <summary>
            /// Restricts the category of events that the provider should write.
            /// </summary>
            public ulong MatchAllKeyword { get; }

            internal EnableInfo(TraceLevel level, TraceProperties enableProperty, ulong matchAnyKeyword, ulong matchAllKeyword)
            {
                Level = level;
                EnableProperty = enableProperty;
                MatchAnyKeyword = matchAnyKeyword;
                MatchAllKeyword = matchAllKeyword;
            }
        }
    }
}
