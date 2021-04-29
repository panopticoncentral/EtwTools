namespace EtwTools
{
    /// <summary>
    /// Information about a field value.
    /// </summary>
    public sealed record EtwProviderFieldInfo
    {
        /// <summary>
        /// The name of the value.
        /// </summary>
        public string Name { get; init; }

        /// <summary>
        /// The description of the value, if any.
        /// </summary>
        public string Description { get; init; }

        /// <summary>
        /// The value.
        /// </summary>
        public ulong Value { get; init; }
    }
}
