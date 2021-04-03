using System;

namespace EtwTools.Providers.Kernel
{
    /// <summary>
    /// Provider for Kernel-ImageID (b3e675d7-2554-4f18-830b-2762732560de)
    /// </summary>
    public sealed class ImageIDProvider
    {
        /// <summary>
        /// Provider ID.
        /// </summary>
        public static readonly Guid Id = new("b3e675d7-2554-4f18-830b-2762732560de");

        /// <summary>
        /// Provider name.
        /// </summary>
        public const string Name = "Kernel-ImageID";
    }
}
