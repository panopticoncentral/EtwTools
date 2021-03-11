using System;

namespace EtwTools
{
    /// <summary>
    /// Flags for how events are logged.
    /// </summary>
    [Flags]
    public enum EtwLogFileMode : uint
    {
        /// <summary>
        /// No flags.
        /// </summary>
        None = 0x00000000,
        /// <summary>
        /// Writes events to a log file sequentially; stops when the file reaches its maximum size.
        /// </summary>
        Sequential = 0x00000001,
        /// <summary>
        /// Writes events to a log file. After the file reaches the maximum size, the oldest events are replaced with incoming events.
        /// </summary>
        Circular = 0x00000002,
        /// <summary>
        /// Appends events to an existing sequential log file. If the file does not exist, it is created.
        /// </summary>
        Append = 0x00000004,
        /// <summary>
        /// Automatically switches to a new log file when the file reaches the maximum size.
        /// </summary>
        NewFile = 0x00000008,
        /// <summary>
        /// Reserves the maximum file size of disk space for the log file in advance.
        /// </summary>
        PreAllocate = 0x00000020,
        /// <summary>
        /// The logging session cannot be stopped.
        /// </summary>
        NonStoppable = 0x00000040,
        /// <summary>
        /// Restricts who can log events to the session.
        /// </summary>
        Secure = 0x00000080,
        /// <summary>
        /// Delivers the events to consumers in real-time. Events are delivered when the buffers are flushed, not at the time the provider writes the event.
        /// </summary>
        RealTime = 0x00000100,
        /// <summary>
        /// Delay opening the log file until an event occurs.
        /// </summary>
        DelayOpenFile = 0x00000200,
        /// <summary>
        /// This mode writes events to a circular memory buffer. Events written beyond the total size of the buffer evict the oldest events still remaining in the buffer.
        /// </summary>
        Buffering = 0x00000400,
        /// <summary>
        /// Creates a user-mode event tracing session that runs in the same process as its event trace provider.
        /// </summary>
        PrivateLogger = 0x00000800,
        /// <summary>
        /// Adds a header to the log file.
        /// </summary>
        AddHeader = 0x00001000,
        /// <summary>
        /// Use kilobytes as the unit of measure for specifying the size of a file. The default unit of measure is megabytes.
        /// </summary>
        UseKbytesForSize = 0x00002000,
        /// <summary>
        /// Uses sequence numbers that are unique across event tracing sessions.
        /// </summary>
        UseGlobalSequence = 0x00004000,
        /// <summary>
        /// Uses sequence numbers that are unique only for an individual event tracing session.
        /// </summary>
        UseLocalSequence = 0x00008000,
        /// <summary>
        /// Enforces that only the process that registered the provider GUID can start the logger session with that GUID.
        /// </summary>
        PrivateInProc = 0x00020000,
        /// <summary>
        /// Stops logging on hybrid shutdown.
        /// </summary>
        StopOnHybridShutdown = 0x00400000,
        /// <summary>
        /// Continues logging on hybrid shutdown.
        /// </summary>
        PersistOnHybridShutdown = 0x00800000,
        /// <summary>
        /// Uses paged memory.
        /// </summary>
        UsePagedMemory = 0x01000000,
        /// <summary>
        /// Receive events from SystemTraceProvider.
        /// </summary>
        SystemLogger = 0x02000000,
        /// <summary>
        /// A logging session should not be affected by EventWrite failures in other sessions.
        /// </summary>
        IndependentSession = 0x08000000,
        /// <summary>
        /// Writes events that were logged on different processors to a common buffer.
        /// </summary>
        NoPerProcessorBuffering = 0x10000000,
        /// <summary>
        /// Adds ETW buffers to triage dumps.
        /// </summary>
        AddToTriageDump = 0x80000000,
        /// <summary>
        /// All known values
        /// </summary>
        All = None
            | Sequential
            | Circular
            | Append
            | NewFile
            | PreAllocate
            | NonStoppable
            | Secure
            | RealTime
            | DelayOpenFile
            | Buffering
            | PrivateLogger
            | AddHeader
            | UseKbytesForSize
            | UseGlobalSequence
            | UseLocalSequence
            | PrivateInProc
            | StopOnHybridShutdown
            | PersistOnHybridShutdown
            | UsePagedMemory
            | SystemLogger
            | IndependentSession
            | NoPerProcessorBuffering
            | AddToTriageDump
    }

}
