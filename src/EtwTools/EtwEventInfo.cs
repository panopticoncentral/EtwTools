using System;
using System.Collections.Generic;

namespace EtwTools
{
    /// <summary>
    /// Description of an ETW event.
    /// </summary>
    public sealed record EtwEventInfo
    {
        /// <summary>
        /// The event's provider ID.
        /// </summary>
        public Guid ProviderId { get; init; }

        /// <summary>
        /// The event's provider's name.
        /// </summary>
        public string ProviderName { get; init; }

        /// <summary>
        /// The event's ID.
        /// </summary>
        public Guid EventId { get; init; }

        /// <summary>
        /// The event descriptor.
        /// </summary>
        public EtwEventDescriptor Descriptor { get; init; }

        /// <summary>
        /// The name of the event, if any.
        /// </summary>
        public string Name { get; init; }

        /// <summary>
        /// The channel of the event.
        /// </summary>
        public string ChannelName { get; init; }

        /// <summary>
        /// The level of the event.
        /// </summary>
        public string LevelName { get; init; }

        /// <summary>
        /// The opcode of the event.
        /// </summary>
        public string OpcodeName { get; init; }

        /// <summary>
        /// The task of the event.
        /// </summary>
        public string TaskName { get; init; }

        /// <summary>
        /// The keyword of the event.
        /// </summary>
        public string KeywordName { get; init; }

        /// <summary>
        /// Event message, if any.
        /// </summary>
        public string Message { get; init; }

        /// <summary>
        /// Event attributes, if any.
        /// </summary>
        public string EventAttributes { get; init; }

        /// <summary>
        /// Activity ID name, if any.
        /// </summary>
        public string ActivityIdName { get; init; }

        /// <summary>
        /// Related activity ID name, if any.
        /// </summary>
        public string RelatedActivityIdName { get; init; }

        /// <summary>
        /// Event flags.
        /// </summary>
        public uint? Flags { get; init; }

        /// <summary>
        /// The properties of the event.
        /// </summary>
        public IReadOnlyList<EtwPropertyInfo> Properties { get; init; }

        /// <summary>
        /// Creates a new event info.
        /// </summary>
        public EtwEventInfo()
        {
        }

        internal unsafe EtwEventInfo(Native.TraceEventInfo* eventInfo)
        {
            var eventBuffer = (byte*)eventInfo;

            Descriptor = eventInfo->EventDescriptor;

            if (eventInfo == null)
            {
                return;
            }

            ProviderId = eventInfo->ProviderGuid;
            ProviderName = eventInfo->ProviderNameOffset != 0 ? new string((char*)(eventBuffer + eventInfo->ProviderNameOffset)).Trim() : null;
            EventId = eventInfo->EventGuid;

            ChannelName = eventInfo->ChannelNameOffset != 0 ? new string((char*)(eventBuffer + eventInfo->ChannelNameOffset)).Trim() : null;
            LevelName = eventInfo->LevelNameOffset != 0 ? new string((char*)(eventBuffer + eventInfo->LevelNameOffset)).Trim() : null;
            OpcodeName = eventInfo->OpcodeNameOffset != 0 ? new string((char*)(eventBuffer + eventInfo->OpcodeNameOffset)).Trim() : null;
            TaskName = eventInfo->DecodingSource switch
            {
                Native.DecodingSource.XmlFile => eventInfo->TaskNameOffset != 0 ? new string((char*)(eventBuffer + eventInfo->TaskNameOffset)).Trim() : null,
                _ => null
            };
            KeywordName = eventInfo->KeywordsNameOffset != 0 ? new string((char*)(eventBuffer + eventInfo->KeywordsNameOffset)).Trim() : null;

            Name = eventInfo->DecodingSource switch
            {
                Native.DecodingSource.XmlFile or Native.DecodingSource.Tlg => eventInfo->EventNameOffset != 0 ? new string((char*)(eventBuffer + eventInfo->EventNameOffset)).Trim() : null,
                Native.DecodingSource.Wbem => eventInfo->TaskNameOffset != 0 ? new string((char*)(eventBuffer + eventInfo->TaskNameOffset)).Trim() : null,
                _ => null
            };
            Message = eventInfo->EventMessageOffset != 0 ? new string((char*)(eventBuffer + eventInfo->EventMessageOffset)).Trim() : null;
            ActivityIdName = eventInfo->DecodingSource switch
            {
                Native.DecodingSource.Wbem => eventInfo->EventNameOffset != 0 ? new string((char*)(eventBuffer + eventInfo->EventNameOffset)).Trim() : null,
                _ => null
            };
            EventAttributes = eventInfo->DecodingSource switch
            {
                Native.DecodingSource.XmlFile => eventInfo->EventAttributesOffset != 0 ? new string((char*)(eventBuffer + eventInfo->EventAttributesOffset)).Trim() : null,
                _ => null
            };
            RelatedActivityIdName = eventInfo->DecodingSource switch
            {
                Native.DecodingSource.Wbem => eventInfo->EventAttributesOffset != 0 ? new string((char*)(eventBuffer + eventInfo->EventAttributesOffset)).Trim() : null,
                _ => null
            };
            Flags = eventInfo->Flags;

            if (eventInfo->PropertyCount == 0)
            {
                Properties = Array.Empty<EtwPropertyInfo>();
                return;
            }

            var properties = new EtwPropertyInfo[eventInfo->TopLevelPropertyCount];
            for (var i = 0; i < eventInfo->TopLevelPropertyCount; i++)
            {
                properties[i] = Create(eventInfo, i);
            }
            Properties = properties;
        }

        internal static unsafe EtwPropertyInfo Create(Native.TraceEventInfo* eventInfo, int index)
        {
            var eventBuffer = (byte*)eventInfo;

            string GetString(uint offset) => new((char*)(eventBuffer + offset));
            Native.EventPropertyInfo* GetProperty(int index) => (Native.EventPropertyInfo*)(eventBuffer + sizeof(Native.TraceEventInfo) + (sizeof(Native.EventPropertyInfo) * index));

            var propertyInfo = GetProperty(index);
            if ((propertyInfo->PropertyFlags & Native.PropertyFlags.HasCustomSchema) != 0)
            {
                throw new InvalidOperationException();
            }

            var name = GetString(propertyInfo->NameOffset);
            object length = ((propertyInfo->PropertyFlags & Native.PropertyFlags.ParamLength) != 0)
                ? GetString(GetProperty(propertyInfo->Length)->NameOffset)
                : propertyInfo->Length;
            object count = ((propertyInfo->PropertyFlags & Native.PropertyFlags.ParamCount) != 0)
                ? GetString(GetProperty(propertyInfo->Count)->NameOffset)
                : propertyInfo->Count;

            if ((propertyInfo->PropertyFlags & Native.PropertyFlags.Struct) != 0)
            {
                var properties = new EtwPropertyInfo[propertyInfo->Union2];
                for (var i = 0; i < propertyInfo->Union2; i++)
                {
                    properties[i] = Create(eventInfo, i + propertyInfo->Union1);
                }

                return new EtwPropertyInfo
                {
                    Name = name,
                    Length = length,
                    Count = count,
                    Properties = properties,
                    Tags = propertyInfo->Tags
                };
            }
            else
            {
                return new EtwPropertyInfo
                {
                    Name = name,
                    InputType = (EtwInputType)propertyInfo->Union1,
                    OutputType = (EtwOutputType)propertyInfo->Union2,
                    MapName = propertyInfo->Union3 == 0 ? null : new string((char*)(((byte*)eventInfo) + propertyInfo->Union3)),
                    Length = length,
                    Count = count,
                    Tags = propertyInfo->Tags
                };
            }
        }
    }
}
