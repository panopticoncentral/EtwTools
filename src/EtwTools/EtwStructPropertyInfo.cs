using System.Collections.Generic;

namespace EtwTools
{
    /// <summary>
    /// Property descriptor for a structure property.
    /// </summary>
    public sealed record EtwStructPropertyInfo : EtwPropertyInfo
    {
        /// <summary>
        /// The kind of the property.
        /// </summary>
        public override PropertyKind Kind => PropertyKind.Struct;

        /// <summary>
        /// The structure properties.
        /// </summary>
        public IReadOnlyList<EtwPropertyInfo> Properties { get; init; }
    }
}
