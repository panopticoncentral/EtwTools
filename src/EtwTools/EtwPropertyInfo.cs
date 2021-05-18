using System.Collections.Generic;

namespace EtwTools
{
    /// <summary>
    /// Description of an ETW event's property.
    /// </summary>
    public sealed record EtwPropertyInfo
    {
        /// <summary>
        /// The name of the property.
        /// </summary>
        public string Name { get; init; }

        /// <summary>
        /// The input type of the property.
        /// </summary>
        public EtwInputType InputType { get; init; }

        /// <summary>
        /// The desired output type of the property.
        /// </summary>
        public EtwOutputType OutputType { get; init; }

        /// <summary>
        /// The name of the map type of the property, if any.
        /// </summary>
        public string MapName { get; init; }

        /// <summary>
        /// The structure properties, if any.
        /// </summary>
        public IReadOnlyList<EtwPropertyInfo> Properties { get; init; }

        /// <summary>
        /// The length of the property.
        /// </summary>
        public object Length { get; init; }

        /// <summary>
        /// The count of the property.
        /// </summary>
        public object Count { get; init; }

        /// <summary>
        /// Property tags.
        /// </summary>
        public uint Tags { get; init; }
    }
}
