using System.Runtime.InteropServices;

namespace EtwTools
{
    /// <summary>
    /// Description of an ETW event.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public record EtwEventDescriptor
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
    }
}
