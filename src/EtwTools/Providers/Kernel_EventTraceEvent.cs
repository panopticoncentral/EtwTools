using System;

namespace EtwTools.Providers.Kernel
{
    /// <summary>
    /// Provider for Kernel-EventTraceEvent (68fdd900-4a3e-11d1-84f4-0000f80464e3)
    /// </summary>
    public sealed class EventTraceEventProvider
    {
        /// <summary>
        /// Provider ID.
        /// </summary>
        public static readonly Guid Id = new("68fdd900-4a3e-11d1-84f4-0000f80464e3");

        /// <summary>
        /// Provider name.
        /// </summary>
        public const string Name = "Kernel-EventTraceEvent";
    }
}
