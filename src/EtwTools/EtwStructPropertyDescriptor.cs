using System.Collections.Generic;

namespace EtwTools
{
    /// <summary>
    /// Property descriptor for a structure property.
    /// </summary>
    public sealed record EtwStructPropertyDescriptor : EtwPropertyDescriptor
    {
        /// <summary>
        /// The kind of the property.
        /// </summary>
        public override PropertyKind Kind => PropertyKind.Struct;

        /// <summary>
        /// The structure properties.
        /// </summary>
        public IReadOnlyList<EtwPropertyDescriptor> Properties { get; init; }
    }
}
