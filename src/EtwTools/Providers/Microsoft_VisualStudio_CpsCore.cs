using System;

namespace EtwTools.Providers.Microsoft.VisualStudio
{
    /// <summary>
    /// Provider for Microsoft-VisualStudio-CpsCore (fdc862e2-43a9-5181-288a-7fade55cc9cc)
    /// </summary>
    public sealed class CpsCoreProvider
    {
        /// <summary>
        /// Provider ID.
        /// </summary>
        public static readonly Guid Id = new("fdc862e2-43a9-5181-288a-7fade55cc9cc");

        /// <summary>
        /// Provider name.
        /// </summary>
        public const string Name = "Microsoft-VisualStudio-CpsCore";
    }
}
