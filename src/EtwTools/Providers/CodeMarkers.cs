using System;

namespace EtwTools.Providers
{
    /// <summary>
    /// Provider for CodeMarkers (641d7f6c-481c-42e8-ab7e-d18dc5e5cb9e)
    /// </summary>
    public sealed class CodeMarkersProvider
    {
        /// <summary>
        /// Provider ID.
        /// </summary>
        public static readonly Guid Id = new("641d7f6c-481c-42e8-ab7e-d18dc5e5cb9e");

        /// <summary>
        /// Provider name.
        /// </summary>
        public const string Name = "CodeMarkers";
    }
}
