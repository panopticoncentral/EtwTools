using System;

namespace EtwTools.Providers.Microsoft.Windows.Kernel
{
    /// <summary>
    /// Provider for Microsoft-Windows-Kernel-Process (22fb2cd6-0e7b-422b-a0c7-2fad1fd0e716)
    /// </summary>
    public sealed class ProcessProvider
    {
        /// <summary>
        /// Provider ID.
        /// </summary>
        public static readonly Guid Id = new("22fb2cd6-0e7b-422b-a0c7-2fad1fd0e716");

        /// <summary>
        /// Provider name.
        /// </summary>
        public const string Name = "Microsoft-Windows-Kernel-Process";
    }
}
