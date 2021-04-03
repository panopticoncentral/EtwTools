using System;

namespace EtwTools.Providers.Microsoft.ApplicationInsights
{
    /// <summary>
    /// Provider for Microsoft-ApplicationInsights-Core (74af9f20-af6a-5582-9382-f21f674fb271)
    /// </summary>
    public sealed class CoreProvider
    {
        /// <summary>
        /// Provider ID.
        /// </summary>
        public static readonly Guid Id = new("74af9f20-af6a-5582-9382-f21f674fb271");

        /// <summary>
        /// Provider name.
        /// </summary>
        public const string Name = "Microsoft-ApplicationInsights-Core";
    }
}
