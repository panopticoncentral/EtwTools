using System.Collections.Generic;

namespace EtwTools
{
    /// <summary>
    /// Describes a property map.
    /// </summary>
    public sealed record EtwPropertyMapInfo
    {
        /// <summary>
        /// The name of the map.
        /// </summary>
        public string Name { get; init; }

        /// <summary>
        /// The values are bitflags.
        /// </summary>
        public bool Flags { get; init; }

        /// <summary>
        /// The values.
        /// </summary>
        public IReadOnlyDictionary<ulong, string> Values { get; init; }
    }
}
