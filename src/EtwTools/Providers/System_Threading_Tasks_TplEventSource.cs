using System;

namespace EtwTools.Providers.System.Threading.Tasks
{
    /// <summary>
    /// Provider for System.Threading.Tasks.TplEventSource (2e5dba47-a3d2-4d16-8ee0-6671ffdcd7b5)
    /// </summary>
    public sealed class TplEventSourceProvider
    {
        /// <summary>
        /// Provider ID.
        /// </summary>
        public static readonly Guid Id = new("2e5dba47-a3d2-4d16-8ee0-6671ffdcd7b5");

        /// <summary>
        /// Provider name.
        /// </summary>
        public const string Name = "System.Threading.Tasks.TplEventSource";
    }
}
