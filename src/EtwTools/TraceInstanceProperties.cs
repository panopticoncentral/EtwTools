using System;

namespace EtwTools
{
    /// <summary>
    /// Properties of an instance of a trace provider.
    /// </summary>
    [Flags]
    public enum TraceInstanceProperties : uint
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0x0,

        /// <summary>
        /// This provider was registered using <c>RegisterTraceGuids</c> instead of <c>EventRegister</c>.
        /// </summary>
        Legacy = 0x1,

        /// <summary>
        /// This provider was enabled without being registered.
        /// </summary>
        PreEnabled = 0x2
    }
}
