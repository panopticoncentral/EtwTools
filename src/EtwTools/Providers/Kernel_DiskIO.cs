using System;

namespace EtwTools.Providers.Kernel
{
    /// <summary>
    /// Provider for Kernel-DiskIO (3d6fa8d4-fe05-11d0-9dda-00c04fd7ba7c)
    /// </summary>
    public sealed class DiskIOProvider
    {
        /// <summary>
        /// Provider ID.
        /// </summary>
        public static readonly Guid Id = new("3d6fa8d4-fe05-11d0-9dda-00c04fd7ba7c");

        /// <summary>
        /// Provider name.
        /// </summary>
        public const string Name = "Kernel-DiskIO";
    }
}
