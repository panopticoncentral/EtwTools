using System;

namespace EtwTools
{
    /// <summary>
    /// An ETW event.
    /// </summary>
    public readonly ref struct EtwEvent
    {
        /// <summary>
        /// The process the event was recorded in.
        /// </summary>
        public uint ProcessId { get; init; }

        /// <summary>
        /// The thread the event was recorded on.
        /// </summary>
        public uint ThreadId { get; init; }

        /// <summary>
        /// The timestamp of the event.
        /// </summary>
        public long Timestamp { get; init; }

        /// <summary>
        /// The event provider.
        /// </summary>
        public Guid Provider { get; init; }

        /// <summary>
        /// The event ID;
        /// </summary>
        public ushort Id { get; init; }

        /// <summary>
        /// The event version.
        /// </summary>
        public byte Version { get; init; }

        /// <summary>
        /// The event channel.
        /// </summary>
        public byte Channel { get; init; }

        /// <summary>
        /// The trace level of the event.
        /// </summary>
        public TraceLevel Level { get; init; }

        /// <summary>
        /// The event opcode.
        /// </summary>
        public EventType Opcode { get; init; }

        /// <summary>
        /// The event task.
        /// </summary>
        public ushort Task { get; init; }

        /// <summary>
        /// The event's keywords.
        /// </summary>
        public ulong Keyword { get; init; }

        /// <summary>
        /// Timing information for the event.
        /// </summary>
        public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time { get; init; }
    }
}
