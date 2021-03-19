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

        internal unsafe EtwEventInfo(EtwEventDescriptor eventDescriptor, Native.TraceEventInfo* eventInfo)
        {
            var eventBuffer = (byte*)eventInfo;

            Descriptor = eventDescriptor;

            if (eventInfo == null)
            {
                return;
            }

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

            var properties = new EtwPropertyInfo[eventInfo->PropertyCount];
            for (var i = 0; i < eventInfo->PropertyCount; i++)
            {
                var currentProperty = (Native.EventPropertyInfo*)(eventBuffer + sizeof(Native.TraceEventInfo) + (sizeof(Native.EventPropertyInfo) * i));
                properties[i] = EtwPropertyInfo.Create(eventInfo, currentProperty);
            }
            Properties = properties;
        }
    }
}
