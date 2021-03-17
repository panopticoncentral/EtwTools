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
        public NamedValue<byte> Channel { get; init; }

        /// <summary>
        /// The level of the event.
        /// </summary>
        public NamedValue<EtwTraceLevel> Level { get; init; }

        /// <summary>
        /// The opcode of the event.
        /// </summary>
        public NamedValue<EtwEventType> Opcode { get; init; }

        /// <summary>
        /// The task of the event.
        /// </summary>
        public NamedValue<ushort> Task { get; init; }

        /// <summary>
        /// The keyword of the event.
        /// </summary>
        public NamedValue<ulong> Keyword { get; init; }

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
        public IReadOnlyList<EtwPropertyDescriptor> Properties { get; init; }

        internal unsafe EtwEventDescriptor(Native.EventDescriptor* eventDescriptor, Native.TraceEventInfo* eventInfo)
        {
            var eventBuffer = (byte*)eventInfo;

            Id = eventDescriptor->Id;
            Version = eventDescriptor->Version;
            Channel = new NamedValue<byte> { Value = eventDescriptor->Channel, Name = eventInfo == null ? null : eventInfo->ChannelNameOffset != 0 ? new string((char*)(eventBuffer + eventInfo->ChannelNameOffset)).Trim() : null };
            Level = new NamedValue<EtwTraceLevel> { Value = eventDescriptor->Level, Name = eventInfo == null ? null : eventInfo->LevelNameOffset != 0 ? new string((char*)(eventBuffer + eventInfo->LevelNameOffset)).Trim() : null };
            Opcode = new NamedValue<EtwEventType> { Value = eventDescriptor->Opcode, Name = eventInfo == null ? null : eventInfo->OpcodeNameOffset != 0 ? new string((char*)(eventBuffer + eventInfo->OpcodeNameOffset)).Trim() : null };
            Task = new NamedValue<ushort>
            {
                Value = eventDescriptor->Task,
                Name = eventInfo == null ? null : eventInfo->DecodingSource switch
                {
                    Native.DecodingSource.XmlFile => eventInfo->TaskNameOffset != 0 ? new string((char*)(eventBuffer + eventInfo->TaskNameOffset)).Trim() : null,
                    _ => null
                }
            };
            Keyword = new NamedValue<ulong> { Value = eventDescriptor->Keyword, Name = eventInfo == null ? null : eventInfo->KeywordsNameOffset != 0 ? new string((char*)(eventBuffer + eventInfo->KeywordsNameOffset)).Trim() : null };

            Name = eventInfo == null ? null : eventInfo->DecodingSource switch
            {
                Native.DecodingSource.XmlFile or Native.DecodingSource.Tlg => eventInfo->EventNameOffset != 0 ? new string((char*)(eventBuffer + eventInfo->EventNameOffset)).Trim() : null,
                Native.DecodingSource.Wbem => eventInfo->TaskNameOffset != 0 ? new string((char*)(eventBuffer + eventInfo->TaskNameOffset)).Trim() : null,
                _ => null
            };
            Message = eventInfo == null ? null : eventInfo->EventMessageOffset != 0 ? new string((char*)(eventBuffer + eventInfo->EventMessageOffset)).Trim() : null;
            ActivityIdName = eventInfo == null ? null : eventInfo->DecodingSource switch
            {
                Native.DecodingSource.Wbem => eventInfo->EventNameOffset != 0 ? new string((char*)(eventBuffer + eventInfo->EventNameOffset)).Trim() : null,
                _ => null
            };
            EventAttributes = eventInfo == null ? null : eventInfo->DecodingSource switch
            {
                Native.DecodingSource.XmlFile => eventInfo->EventAttributesOffset != 0 ? new string((char*)(eventBuffer + eventInfo->EventAttributesOffset)).Trim() : null,
                _ => null
            };
            RelatedActivityIdName = eventInfo == null ? null : eventInfo->DecodingSource switch
            {
                Native.DecodingSource.Wbem => eventInfo->EventAttributesOffset != 0 ? new string((char*)(eventBuffer + eventInfo->EventAttributesOffset)).Trim() : null,
                _ => null
            };
            Flags = eventInfo == null ? 0 : eventInfo->Flags;

            if (eventInfo == null || eventInfo->PropertyCount == 0)
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

        /// <summary>
        /// A value that has an optional name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public struct NamedValue<T>
        {
            /// <summary>
            /// The value.
            /// </summary>
            public T Value { get; init; }

            /// <summary>
            /// The optional name.
            /// </summary>
            public string Name { get; init; }
        }
    }
}
