namespace EtwTools
{
    /// <summary>
    /// The level of detail provided by an event provider.
    /// </summary>
    public enum TraceLevel : byte
    {
        /// <summary>
        /// No trace level.
        /// </summary>
        None = 0,

        /// <summary>
        /// Abnormal exit or termination events.
        /// </summary>
        Critical = 1,

        /// <summary>
        /// Severe error events.
        /// </summary>
        Error = 2,

        /// <summary>
        /// Warning events such as allocation failures.
        /// </summary>
        Warning = 3,

        /// <summary>
        /// Non-error events such as entry or exit events.
        /// </summary>
        Information = 4,

        /// <summary>
        /// Detailed trace events.
        /// </summary>
        Verbose = 5
    }
}
