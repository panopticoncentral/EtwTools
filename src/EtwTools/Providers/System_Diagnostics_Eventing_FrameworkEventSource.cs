using System;

namespace EtwTools.Providers.System.Diagnostics.Eventing
{
    /// <summary>
    /// Provider for System.Diagnostics.Eventing.FrameworkEventSource (8e9f5090-2d75-4d03-8a81-e5afbf85daf1)
    /// </summary>
    public sealed class FrameworkEventSourceProvider
    {
        /// <summary>
        /// Provider ID.
        /// </summary>
        public static readonly Guid Id = new("8e9f5090-2d75-4d03-8a81-e5afbf85daf1");

        /// <summary>
        /// Provider name.
        /// </summary>
        public const string Name = "System.Diagnostics.Eventing.FrameworkEventSource";
    }
}
