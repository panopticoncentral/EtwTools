using System;

namespace EtwTools.Providers.Microsoft.Windows
{
    /// <summary>
    /// Provider for Microsoft-Windows-DotNETRuntime (e13c0d23-ccbc-4e12-931b-d9cc2eee27e4)
    /// </summary>
    public sealed class DotNETRuntimeProvider
    {
        /// <summary>
        /// Provider ID.
        /// </summary>
        public static readonly Guid Id = new("e13c0d23-ccbc-4e12-931b-d9cc2eee27e4");

        /// <summary>
        /// Provider name.
        /// </summary>
        public const string Name = "Microsoft-Windows-DotNETRuntime";
    }
}
