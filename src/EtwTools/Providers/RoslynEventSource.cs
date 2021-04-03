using System;

namespace EtwTools.Providers
{
    /// <summary>
    /// Provider for RoslynEventSource (bf965e67-c7fb-5c5b-d98f-cdf68f8154c2)
    /// </summary>
    public sealed class RoslynEventSourceProvider
    {
        /// <summary>
        /// Provider ID.
        /// </summary>
        public static readonly Guid Id = new("bf965e67-c7fb-5c5b-d98f-cdf68f8154c2");

        /// <summary>
        /// Provider name.
        /// </summary>
        public const string Name = "RoslynEventSource";
    }
}
