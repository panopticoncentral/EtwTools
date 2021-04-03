using System;

namespace EtwTools.Providers.Kernel
{
    /// <summary>
    /// Provider for Kernel-FileSystem (9b79ee91-b5fd-41c0-a243-4248e266e9d0)
    /// </summary>
    public sealed class FileSystemProvider
    {
        /// <summary>
        /// Provider ID.
        /// </summary>
        public static readonly Guid Id = new("9b79ee91-b5fd-41c0-a243-4248e266e9d0");

        /// <summary>
        /// Provider name.
        /// </summary>
        public const string Name = "Kernel-FileSystem";
    }
}
