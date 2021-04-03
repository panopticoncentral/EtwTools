using System;

namespace EtwTools.Providers.Microsoft.Windows.Kernel
{
    /// <summary>
    /// Provider for Microsoft-Windows-Kernel-File (edd08927-9cc4-4e65-b970-c2560fb5c289)
    /// </summary>
    public sealed class FileProvider
    {
        /// <summary>
        /// Provider ID.
        /// </summary>
        public static readonly Guid Id = new("edd08927-9cc4-4e65-b970-c2560fb5c289");

        /// <summary>
        /// Provider name.
        /// </summary>
        public const string Name = "Microsoft-Windows-Kernel-File";
    }
}
