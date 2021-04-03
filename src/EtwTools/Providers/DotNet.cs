using System;

namespace EtwTools.Providers
{
    /// <summary>
    /// Provider for DotNet (319dc449-ada5-50f7-428e-957db6791668)
    /// </summary>
    public sealed class DotNetProvider
    {
        /// <summary>
        /// Provider ID.
        /// </summary>
        public static readonly Guid Id = new("319dc449-ada5-50f7-428e-957db6791668");

        /// <summary>
        /// Provider name.
        /// </summary>
        public const string Name = "DotNet";
    }
}
