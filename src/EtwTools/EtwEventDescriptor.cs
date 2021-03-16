using System;
using System.Collections.Generic;

namespace EtwTools
{
    /// <summary>
    /// Description of an ETW event.
    /// </summary>
    public sealed record EtwEventDescriptor
    {
        /// <summary>
        /// The ID of the event.
        /// </summary>
        public ushort Id { get; init; }

        /// <summary>
        /// The name of the event, if any.
        /// </summary>
        public string Name { get; init; }

        /// <summary>
        /// The version of the event.
        /// </summary>
        public byte Version { get; init; }

        /// <summary>
        /// The channel of the event.
        /// </summary>
        public byte Channel { get; init; }

        /// <summary>
        /// The name of the channel, if any.
        /// </summary>
        public string ChannelName { get; init; }

        /// <summary>
        /// The level of the event.
        /// </summary>
        public EtwTraceLevel Level { get; init; }

        /// <summary>
        /// The name of the level, if any.
        /// </summary>
        public string LevelName { get; init; }

        /// <summary>
        /// The opcode of the event.
        /// </summary>
        public EtwEventType Opcode { get; init; }

        /// <summary>
        /// The name of the opcode, if any.
        /// </summary>
        public string OpcodeName { get; init; }

        /// <summary>
        /// The task of the event.
        /// </summary>
        public ushort Task { get; init; }

        /// <summary>
        /// The name of the task, if any.
        /// </summary>
        public string TaskName { get; init; }

        /// <summary>
        /// The keyword of the event.
        /// </summary>
        public ulong Keyword { get; init; }

        /// <summary>
        /// The keyword name of the task, if any.
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

        public IReadOnlyList<EtwPropertyDescriptor> Properties { get; init; }

        internal unsafe EtwEventDescriptor(Native.EventDescriptor* eventDescriptor, Native.TraceEventInfo* eventInfo)
        {
            Id = eventDescriptor->Id;
            Version = eventDescriptor->Version;
            Channel = eventDescriptor->Channel;
            Level = eventDescriptor->Level;
            Opcode = eventDescriptor->Opcode;
            Task = eventDescriptor->Task;
            Keyword = eventDescriptor->Keyword;

            if (eventInfo == null)
            {
                return;
            }

            var eventBuffer = (byte*)eventInfo;
            Name = eventInfo->DecodingSource switch
            {
                Native.DecodingSource.XmlFile or Native.DecodingSource.Tlg => eventInfo->EventNameOffset != 0 ? new string((char*)(eventBuffer + eventInfo->EventNameOffset)).Trim() : null,
                Native.DecodingSource.Wbem => eventInfo->TaskNameOffset != 0 ? new string((char*)(eventBuffer + eventInfo->TaskNameOffset)).Trim() : null,
                _ => null
            };
            ChannelName = eventInfo->ChannelNameOffset != 0 ? new string((char*)(eventBuffer + eventInfo->ChannelNameOffset)).Trim() : null;
            LevelName = eventInfo->LevelNameOffset != 0 ? new string((char*)(eventBuffer + eventInfo->LevelNameOffset)).Trim() : null;
            OpcodeName = eventInfo->OpcodeNameOffset != 0 ? new string((char*)(eventBuffer + eventInfo->OpcodeNameOffset)).Trim() : null;
            TaskName = eventInfo->DecodingSource switch
            {
                Native.DecodingSource.XmlFile => eventInfo->TaskNameOffset != 0 ? new string((char*)(eventBuffer + eventInfo->TaskNameOffset)).Trim() : null,
                _ => null
            };
            KeywordName = eventInfo->KeywordsNameOffset != 0 ? new string((char*)(eventBuffer + eventInfo->KeywordsNameOffset)).Trim() : null;
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
                Properties = Array.Empty<EtwPropertyDescriptor>();
                return;
            }

            var properties = new EtwPropertyDescriptor[eventInfo->PropertyCount];
            for (var i = 0; i < eventInfo->PropertyCount; i++)
            {
                var currentProperty = (Native.EventPropertyInfo*)(eventBuffer + sizeof(Native.TraceEventInfo) + (sizeof(Native.EventPropertyInfo) * i));
                properties[i] = EtwPropertyDescriptor.Create(eventInfo, currentProperty);
            }
            Properties = properties;
        }
    }
}
