using System.Collections.Generic;

namespace EtwTools
{
    /// <summary>
    /// Describes a property map.
    /// </summary>
    public sealed record EtwPropertyMapInfo
    {
        /// <summary>
        /// The values are bitflags.
        /// </summary>
        public bool Flags { get; init; }

        /// <summary>
        /// The values.
        /// </summary>
        public IReadOnlyDictionary<uint, string> Values { get; init; }
    }
}
