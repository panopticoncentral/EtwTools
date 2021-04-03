using System;

namespace EtwTools.Providers.Microsoft.VisualStudio
{
    /// <summary>
    /// Provider for Microsoft-VisualStudio-Common (25c93eda-40a3-596d-950d-998ab963f367)
    /// </summary>
    public sealed class CommonProvider
    {
        /// <summary>
        /// Provider ID.
        /// </summary>
        public static readonly Guid Id = new("25c93eda-40a3-596d-950d-998ab963f367");

        /// <summary>
        /// Provider name.
        /// </summary>
        public const string Name = "Microsoft-VisualStudio-Common";
    }
}
