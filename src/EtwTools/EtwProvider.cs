using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace EtwTools
{
    /// <summary>
    /// Represents an ETW event provider.
    /// </summary>
    public sealed unsafe class EtwProvider
    {
        /// <summary>
        /// The ID of the provider.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Creates a provider.
        /// </summary>
        /// <param name="id">The ID of the provider.</param>
        public EtwProvider(Guid id)
        {
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

            return new EtwProvider(guid);
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
                return Array.Empty<InstanceInfo>();
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
        public static IReadOnlyList<(string Name, EtwProvider Provider)> GetPublishedProviders()
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
            var result = new List<(string Name, EtwProvider Provider)>((int)providerCount);

            for (var index = 0; index < providerCount; index++)
            {
                var name = new string((char*)&buffer[providers[index].ProviderNameOffset]);
                result.Add((name, new EtwProvider(providers[index].ProviderGuid)));
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

            var guids = (Guid*)buffer;
            var count = bufferSizeNeeded / sizeof(Guid);
            var result = new List<EtwProvider>(count);
            for (var index = 0; index < count; index++)
            {
                result.Add(new EtwProvider(guids[index]));
            }

            return result;
        }

        /// <summary>
        /// Gets descriptions of events supported by this provider.
        /// </summary>
        /// <returns>A list of event descriptors.</returns>
        public IReadOnlyList<EtwEventInfo> GetEventDescriptors()
        {
            var providerGuid = Id;
            uint bufferSize = 0;
            var hr = (Native.Hresult)Native.TdhEnumerateManifestProviderEvents(&providerGuid, null, &bufferSize);
            if (hr != Native.Hresult.ErrorInsufficientBuffer)
            {
                // There are lots of error codes possible here, so just fail.
                return null;
            }

            var buffer = stackalloc byte[(int)bufferSize];
            var providerEventInfo = (Native.ProviderEventInfo*)buffer;
            ((Native.Hresult)Native.TdhEnumerateManifestProviderEvents(&providerGuid, providerEventInfo, &bufferSize)).ThrowException();

            var infos = new EtwEventInfo[providerEventInfo->NumberOfEvents];
            for (var i = 0; i < providerEventInfo->NumberOfEvents; i++)
            {
                var eventDescriptor = (EtwEventDescriptor*)(buffer + sizeof(Native.ProviderEventInfo) + (i * sizeof(EtwEventDescriptor)));

                uint eventBufferSize = 0;
                hr = (Native.Hresult)Native.TdhGetManifestEventInformation(&providerGuid, eventDescriptor, null, &eventBufferSize);
                if (hr != Native.Hresult.ErrorInsufficientBuffer)
                {
                    infos[i] = new EtwEventInfo(*eventDescriptor, null);
                    continue;
                }

                fixed (byte* eventBuffer = new byte[(int)eventBufferSize])
                {
                    var eventInfo = (Native.TraceEventInfo*)eventBuffer;
                    ((Native.Hresult)Native.TdhGetManifestEventInformation(&providerGuid, eventDescriptor, eventInfo, &eventBufferSize)).ThrowException();
                    infos[i] = new EtwEventInfo(*eventDescriptor, eventInfo);
                }
            }

            return infos;
        }

        /// <summary>
        /// Returns a map for an event property.
        /// </summary>
        /// <param name="name">The name of the map.</param>
        /// <param name="version">The version of the map to retrieve.</param>
        /// <returns>The map.</returns>
        public EtwPropertyMapInfo GetPropertyMap(string name, byte version)
        {
            Dictionary<uint, string> map = new();

            Native.EventRecord eventRecord = new() { EventHeader = new() { ProviderId = Id, EventDescriptor = new() { Version = version } } };
            uint bufferSize = 0;
            var hr = (Native.Hresult)Native.TdhGetEventMapInformation(&eventRecord, name, null, &bufferSize);

            if (hr != Native.Hresult.ErrorInsufficientBuffer)
            {
                return null;
            }

            var buffer = stackalloc byte[(int)bufferSize];
            var eventMapInfo = (Native.EventMapInfo*)buffer;
            ((Native.Hresult)Native.TdhGetEventMapInformation(&eventRecord, name, eventMapInfo, &bufferSize)).ThrowException();

            if (((eventMapInfo->Flag & (Native.MapFlags.ManifestValuemap | Native.MapFlags.ManifestBitmap)) == 0) ||
                eventMapInfo->MapEntryValueType != Native.MapValueType.UnsignedLong)
            {
                // Unsupported map type
                return null;
            }

            for (var i = 0; i < eventMapInfo->EntryCount; i++)
            {
                var mapEntry = (Native.EventMapEntry*)(buffer + sizeof(Native.EventMapInfo) + (i * sizeof(Native.EventMapEntry)));
                map[mapEntry->Value] = new string((char*)&buffer[mapEntry->OutputOffset]).Trim();
            }

            return new EtwPropertyMapInfo { Flags = (eventMapInfo->Flag & Native.MapFlags.ManifestBitmap) != 0, Values = map };
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
            public EtwTraceInstanceProperties Properties { get; }

            /// <summary>
            /// Information about each way the provider was enabled.
            /// </summary>
            public IReadOnlyList<EnableInfo> EnableInfos { get; }

            internal InstanceInfo(uint processId, EtwTraceInstanceProperties properties, IReadOnlyList<EnableInfo> enableInfos)
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
            public EtwTraceLevel Level { get; }

            /// <summary>
            /// Optional properties that are enabled.
            /// </summary>
            public EtwTraceProperties EnableProperty { get; }

            /// <summary>
            /// Bitmask of keywords that determine the category of events the provider should write.
            /// </summary>
            public ulong MatchAnyKeyword { get; }

            /// <summary>
            /// Restricts the category of events that the provider should write.
            /// </summary>
            public ulong MatchAllKeyword { get; }

            internal EnableInfo(EtwTraceLevel level, EtwTraceProperties enableProperty, ulong matchAnyKeyword, ulong matchAllKeyword)
            {
                Level = level;
                EnableProperty = enableProperty;
                MatchAnyKeyword = matchAnyKeyword;
                MatchAllKeyword = matchAllKeyword;
            }
        }
    }
}
