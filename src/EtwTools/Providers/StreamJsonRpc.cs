using System;

namespace EtwTools.Providers
{
    /// <summary>
    /// Provider for StreamJsonRpc (f0cffe53-bcc5-53f5-8873-995568808a3b)
    /// </summary>
    public sealed class StreamJsonRpcProvider
    {
        /// <summary>
        /// Provider ID.
        /// </summary>
        public static readonly Guid Id = new("f0cffe53-bcc5-53f5-8873-995568808a3b");

        /// <summary>
        /// Provider name.
        /// </summary>
        public const string Name = "StreamJsonRpc";
    }
}
