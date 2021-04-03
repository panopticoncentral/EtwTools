using System;

namespace EtwTools.Providers.Kernel
{
    /// <summary>
    /// Provider for Kernel-UdpIp (bf3a50c5-a9c9-4988-a005-2df0b7c80f80)
    /// </summary>
    public sealed class UdpIpProvider
    {
        /// <summary>
        /// Provider ID.
        /// </summary>
        public static readonly Guid Id = new("bf3a50c5-a9c9-4988-a005-2df0b7c80f80");

        /// <summary>
        /// Provider name.
        /// </summary>
        public const string Name = "Kernel-UdpIp";
    }
}
