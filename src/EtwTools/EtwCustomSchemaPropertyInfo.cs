namespace EtwTools
{
    /// <summary>
    /// A property with a custom schema.
    /// </summary>
    public sealed record EtwCustomSchemaPropertyInfo : EtwPropertyInfo
    {
        /// <summary>
        /// The kind of the property.
        /// </summary>
        public override PropertyKind Kind => PropertyKind.CustomSchema;
    }
}
