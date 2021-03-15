namespace EtwTools
{
    public sealed record EtwSimplePropertyDescriptor : EtwPropertyDescriptor
    {
        public EtwInputType InputType { get; set; }
        public EtwOutputType OutputType { get; set; }
        public string MapName { get; internal set; }
    }
}
