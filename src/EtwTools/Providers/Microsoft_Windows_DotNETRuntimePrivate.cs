using System;

namespace EtwTools.Providers.Microsoft.Windows
{
    /// <summary>
    /// Provider for Microsoft-Windows-DotNETRuntimePrivate (763fd754-7086-4dfe-95eb-c01a46faf4ca)
    /// </summary>
    public sealed class DotNETRuntimePrivateProvider
    {
        /// <summary>
        /// Provider ID.
        /// </summary>
        public static readonly Guid Id = new("763fd754-7086-4dfe-95eb-c01a46faf4ca");

        /// <summary>
        /// Provider name.
        /// </summary>
        public const string Name = "Microsoft-Windows-DotNETRuntimePrivate";
    }
}
