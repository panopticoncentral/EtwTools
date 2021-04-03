using System;

namespace EtwTools.Providers.Kernel
{
    /// <summary>
    /// Provider for Kernel-EventMetadata (bbccf6c1-6cd1-48c4-80ff-839482e37671)
    /// </summary>
    public sealed class EventMetadataProvider
    {
        /// <summary>
        /// Provider ID.
        /// </summary>
        public static readonly Guid Id = new("bbccf6c1-6cd1-48c4-80ff-839482e37671");

        /// <summary>
        /// Provider name.
        /// </summary>
        public const string Name = "Kernel-EventMetadata";
    }
}
