namespace EtwTools
{
    /// <summary>
    /// Common ETW event types.
    /// </summary>
    public enum EtwEventOpcode : byte
    {
        /// <summary>
        /// Informational event.
        /// </summary>
        Info,

        /// <summary>
        /// Start operation.
        /// </summary>
        Start,

        /// <summary>
        /// End operation.
        /// </summary>
        End,

        /// <summary>
        /// Stop operation.
        /// </summary>
        Stop = End,

        /// <summary>
        /// Data collection start.
        /// </summary>
        DataCollectionStart,

        /// <summary>
        /// Data collection end.
        /// </summary>
        DataCollectionEnd,

        /// <summary>
        /// Extension event.
        /// </summary>
        Extension,

        /// <summary>
        /// Reply event.
        /// </summary>
        Reply,

        /// <summary>
        /// Dequeue event.
        /// </summary>
        Dequeue,

        /// <summary>
        /// Resume event.
        /// </summary>
        Resume = Dequeue,

        /// <summary>
        /// Checkpoint event.
        /// </summary>
        Checkpoint,

        /// <summary>
        /// Suspend event.
        /// </summary>
        Suspend = Checkpoint,

        /// <summary>
        /// Send event.
        /// </summary>
        Send,

        /// <summary>
        /// Receieve event.
        /// </summary>
        Recieve = 0xF0
    }
}
