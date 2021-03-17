namespace EtwTools
{
    /// <summary>
    /// Descriptor for a simple property.
    /// </summary>
    public sealed record EtwSimplePropertyDescriptor : EtwPropertyDescriptor
    {
        /// <summary>
        /// The property kind.
        /// </summary>
        public override PropertyKind Kind => PropertyKind.Simple;

        /// <summary>
        /// The input type of the property.
        /// </summary>
        public EtwInputType InputType { get; init; }

        /// <summary>
        /// The desired output type of the property.
        /// </summary>
        public EtwOutputType OutputType { get; init; }

        /// <summary>
        /// The name of the map type of the property.
        /// </summary>
        public string MapName { get; init; }
    }
}
