namespace EtwTools
{
    public sealed record EtwSimplePropertyDescriptor : EtwPropertyDescriptor
    {
        public override PropertyKind Kind => PropertyKind.Simple;
        public EtwInputType InputType { get; init; }
        public EtwOutputType OutputType { get; init; }
        public string MapName { get; init; }
    }
}
