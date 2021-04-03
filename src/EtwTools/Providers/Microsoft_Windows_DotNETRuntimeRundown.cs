using System;

namespace EtwTools.Providers.Microsoft.Windows
{
    /// <summary>
    /// Provider for Microsoft-Windows-DotNETRuntimeRundown (a669021c-c450-4609-a035-5af59af4df18)
    /// </summary>
    public sealed class DotNETRuntimeRundownProvider
    {
        /// <summary>
        /// Provider ID.
        /// </summary>
        public static readonly Guid Id = new("a669021c-c450-4609-a035-5af59af4df18");

        /// <summary>
        /// Provider name.
        /// </summary>
        public const string Name = "Microsoft-Windows-DotNETRuntimeRundown";
    }
}
