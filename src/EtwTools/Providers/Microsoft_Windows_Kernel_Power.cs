using System;

namespace EtwTools.Providers.Microsoft.Windows.Kernel
{
    /// <summary>
    /// Provider for Microsoft-Windows-Kernel-Power (331c3b3a-2005-44c2-ac5e-77220c37d6b4)
    /// </summary>
    public sealed class PowerProvider
    {
        /// <summary>
        /// Provider ID.
        /// </summary>
        public static readonly Guid Id = new("331c3b3a-2005-44c2-ac5e-77220c37d6b4");

        /// <summary>
        /// Provider name.
        /// </summary>
        public const string Name = "Microsoft-Windows-Kernel-Power";
    }
}
