using System;

namespace EtwTools.Providers.Microsoft.Windows.Kernel
{
    /// <summary>
    /// Provider for Microsoft-Windows-Kernel-EventTracing (b675ec37-bdb6-4648-bc92-f3fdc74d3ca2)
    /// </summary>
    public sealed class EventTracingProvider
    {
        /// <summary>
        /// Provider ID.
        /// </summary>
        public static readonly Guid Id = new("b675ec37-bdb6-4648-bc92-f3fdc74d3ca2");

        /// <summary>
        /// Provider name.
        /// </summary>
        public const string Name = "Microsoft-Windows-Kernel-EventTracing";
    }
}
