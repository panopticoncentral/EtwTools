using System.Runtime.InteropServices;

namespace EtwTools
{
    /// <summary>
    /// An identifier for an event.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct EtwEventDescriptor
    {
        /// <summary>
        /// The ID of the event.
        /// </summary>
        public ushort Id { get; init; }

        /// <summary>
        /// The version of the event.
        /// </summary>
        public byte Version { get; init; }

        /// <summary>
        /// The channel of the event.
        /// </summary>
        public byte Channel { get; init; }

        /// <summary>
        /// The level of the event.
        /// </summary>
        public EtwTraceLevel Level { get; init; }

        /// <summary>
        /// The opcode of the event.
        /// </summary>
        public EtwEventType Opcode { get; init; }

        /// <summary>
        /// The task of the event.
        /// </summary>
        public ushort Task { get; init; }

        /// <summary>
        /// The keyword of the event.
        /// </summary>
        public ulong Keyword { get; init; }
    }
}
