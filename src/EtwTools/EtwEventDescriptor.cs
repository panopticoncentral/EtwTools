using System.Runtime.InteropServices;

namespace EtwTools
{
    /// <summary>
    /// Description of an ETW event.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct EtwEventDescriptor
    {
        /// <summary>
        /// The ID of the event.
        /// </summary>
        public ushort Id { get; }

        /// <summary>
        /// The version of the event.
        /// </summary>
        public byte Version { get; }

        /// <summary>
        /// The channel of the event.
        /// </summary>
        public byte Channel { get; }

        /// <summary>
        /// The level of the event.
        /// </summary>
        public TraceLevel Level { get; }

        /// <summary>
        /// The opcode of the event.
        /// </summary>
        public EtwEventType Opcode { get; }

        /// <summary>
        /// The task of the event.
        /// </summary>
        public ushort Task { get; }

        /// <summary>
        /// The keyword of the event.
        /// </summary>
        public ulong Keyword { get; }
    }
}
