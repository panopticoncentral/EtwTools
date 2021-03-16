namespace EtwTools
{
    public sealed record EtwCustomSchemaPropertyDescriptor : EtwPropertyDescriptor
    {
        public override PropertyKind Kind => PropertyKind.CustomSchema;
    }
}
