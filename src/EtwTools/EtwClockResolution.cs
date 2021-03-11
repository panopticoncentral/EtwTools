namespace EtwTools
{
    /// <summary>
    /// The clock resolution used during tracing.
    /// </summary>
    public enum EtwClockResolution : uint
    {
        /// <summary>
        /// Query performance counter (QPC). The QPC counter provides a high-resolution time stamp that 
        /// is not affected by adjustments to the system clock.
        /// </summary>
        QueryPerformanceCounter = 1,

        /// <summary>
        /// System time. The system time provides a time stamp that tracks changes to the system’s clock.
        /// </summary>
        SystemTime = 2,

        /// <summary>
        /// CPU cycle counter. The CPU counter provides the highest resolution time stamp and is the least 
        /// resource-intensive to retrieve. However, the CPU counter is unreliable and should not be used in 
        /// production.
        /// </summary>
        CpuCycleCounter = 3
    }
}
