using System;

namespace EtwTools.Providers.Microsoft.Windows.NDIS
{
    /// <summary>
    /// Provider for Microsoft-Windows-NDIS-PacketCapture (2ed6006e-4729-4609-b423-3ee7bcd678ef)
    /// </summary>
    public sealed class PacketCaptureProvider
    {
        /// <summary>
        /// Provider ID.
        /// </summary>
        public static readonly Guid Id = new("2ed6006e-4729-4609-b423-3ee7bcd678ef");

        /// <summary>
        /// Provider name.
        /// </summary>
        public const string Name = "Microsoft-Windows-NDIS-PacketCapture";
    }
}
