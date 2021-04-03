using System;

namespace EtwTools.Providers.Kernel
{
    /// <summary>
    /// Provider for Kernel-Tcpip (9a280ac0-c8e0-11d1-84e2-00c04fb998a2)
    /// </summary>
    public sealed class TcpipProvider
    {
        /// <summary>
        /// Provider ID.
        /// </summary>
        public static readonly Guid Id = new("9a280ac0-c8e0-11d1-84e2-00c04fb998a2");

        /// <summary>
        /// Provider name.
        /// </summary>
        public const string Name = "Kernel-Tcpip";
    }
}
