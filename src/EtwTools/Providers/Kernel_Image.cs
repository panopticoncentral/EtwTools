using System;

namespace EtwTools.Providers.Kernel
{
    /// <summary>
    /// Provider for Kernel-Image (2cb15d1d-5fc1-11d2-abe1-00a0c911f518)
    /// </summary>
    public sealed class ImageProvider
    {
        /// <summary>
        /// Provider ID.
        /// </summary>
        public static readonly Guid Id = new("2cb15d1d-5fc1-11d2-abe1-00a0c911f518");

        /// <summary>
        /// Provider name.
        /// </summary>
        public const string Name = "Kernel-Image";
    }
}
