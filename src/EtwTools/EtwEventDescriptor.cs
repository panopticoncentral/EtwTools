using System;
using System.Runtime.InteropServices;

namespace EtwTools
{
    /// <summary>
    /// An identifier for an event.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct EtwEventDescriptor : IEquatable<EtwEventDescriptor>
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

        /// <summary>
        /// Converts descriptor to a string.
        /// </summary>
        /// <returns>The string.</returns>
        public override string ToString() => $"({Id},{Version},{Channel},{Level},{Opcode},{Task},0x{Keyword:X16})";

        /// <summary>
        /// Compares two descriptors.
        /// </summary>
        /// <param name="other">The other descriptor.</param>
        /// <returns>Whether they are equal.</returns>
        public bool Equals(EtwEventDescriptor other) =>
            Id == other.Id
            && Version == other.Version
            && Channel == other.Channel
            && Level == other.Level
            && Opcode == other.Opcode
            && Task == other.Task;

        /// <summary>
        /// Determines if a descriptor is equal to anoher object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>Whether they are equal.</returns>
        public override bool Equals(object obj) => obj is EtwEventDescriptor other && this == other;

        /// <summary>
        /// Calculates a hash code for the descriptor.
        /// </summary>
        /// <returns>The hash value.</returns>
        public override int GetHashCode() =>
            HashCode.Combine(Id, Version, Channel, Level, Opcode, Task);

        /// <summary>
        /// Determines if two descriptors are equal.
        /// </summary>
        /// <param name="left">The left descriptor.</param>
        /// <param name="right">The right descriptor.</param>
        /// <returns>Whether they are equal.</returns>
        public static bool operator ==(EtwEventDescriptor left, EtwEventDescriptor right) => left.Equals(right);

        /// <summary>
        /// Determines if two descriptors are not equal.
        /// </summary>
        /// <param name="left">The left descriptor.</param>
        /// <param name="right">The right descriptor.</param>
        /// <returns>Whether they are not equal.</returns>
        public static bool operator !=(EtwEventDescriptor left, EtwEventDescriptor right) => !(left == right);
    }
}
