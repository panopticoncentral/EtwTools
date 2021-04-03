using System;

namespace EtwTools.Providers.Microsoft.VisualStudio
{
    /// <summary>
    /// Provider for Microsoft-VisualStudio-CpsVs (2bf0e3de-e8a7-5821-ee81-ad9385d138a4)
    /// </summary>
    public sealed class CpsVsProvider
    {
        /// <summary>
        /// Provider ID.
        /// </summary>
        public static readonly Guid Id = new("2bf0e3de-e8a7-5821-ee81-ad9385d138a4");

        /// <summary>
        /// Provider name.
        /// </summary>
        public const string Name = "Microsoft-VisualStudio-CpsVs";
    }
}
