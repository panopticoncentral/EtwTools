using System;

namespace EtwTools.Providers.Microsoft.Windows
{
    /// <summary>
    /// Provider for Microsoft-Windows-TCPIP (2f07e2ee-15db-40f1-90ef-9d7ba282188a)
    /// </summary>
    public sealed class TCPIPProvider
    {
        /// <summary>
        /// Provider ID.
        /// </summary>
        public static readonly Guid Id = new("2f07e2ee-15db-40f1-90ef-9d7ba282188a");

        /// <summary>
        /// Provider name.
        /// </summary>
        public const string Name = "Microsoft-Windows-TCPIP";
    }
}
