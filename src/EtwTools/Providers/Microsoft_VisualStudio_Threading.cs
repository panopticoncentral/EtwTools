using System;

namespace EtwTools.Providers.Microsoft.VisualStudio
{
    /// <summary>
    /// Provider for Microsoft-VisualStudio-Threading (589491ba-4f15-53fe-c376-db7f020f5204)
    /// </summary>
    public sealed class ThreadingProvider
    {
        /// <summary>
        /// Provider ID.
        /// </summary>
        public static readonly Guid Id = new("589491ba-4f15-53fe-c376-db7f020f5204");

        /// <summary>
        /// Provider name.
        /// </summary>
        public const string Name = "Microsoft-VisualStudio-Threading";
    }
}
