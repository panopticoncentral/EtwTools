using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using System.Threading;

namespace EtwTools
{
    /// <summary>
    /// An ETW trace.
    /// </summary>
    public sealed unsafe class EtwTrace : IDisposable
    {
        private static int s_nextId;
        private static readonly ConcurrentDictionary<int, WeakReference<EtwTrace>> s_instances = new();

        private readonly int _id;
        private Native.TraceHandle _traceHandle = Native.TraceHandle.Invalid;
        private BufferCallback _bufferCallback;
        private EventCallback _eventCallback;

        /// <summary>
        /// A callback for event processing.
        /// </summary>
        /// <param name="e">The event to process.</param>
        public delegate void EventCallback(EtwEvent e);

        /// <summary>
        /// A callback for buffer processing.
        /// </summary>
        /// <param name="statistics">Information about the buffer processed.</param>
        /// <returns>Whether to continue processing buffers.</returns>
        public delegate bool BufferCallback(BufferStatistics statistics);

        /// <summary>
        /// The name of the trace (file name or real-time session name).
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Whether the trace is of a real-time session.
        /// </summary>
        public bool IsRealTime { get; }

        /// <summary>
        /// Constructs a trace.
        /// </summary>
        /// <param name="name">The name of the log file or real-time session.</param>
        /// <param name="isRealTime">Whether the name is of a lof file or real-time session.</param>
        public EtwTrace(string name, bool isRealTime)
        {
            _id = Interlocked.Increment(ref s_nextId);
            _ = s_instances.TryAdd(_id, new(this));
            Name = name;
            IsRealTime = isRealTime;
        }

        /// <summary>
        /// Finalizes the trace.
        /// </summary>
        ~EtwTrace()
        {
            Dispose();
        }

        [UnmanagedCallersOnly]
        private static uint NativeBufferCallback(Native.EventTraceLogFile* logFile)
        {
            var shouldContinue = true;
            if (s_instances.TryGetValue((int)logFile->Context, out var weakReference) &&
                weakReference.TryGetTarget(out var instance))
            {
                shouldContinue = instance._bufferCallback?.Invoke(new BufferStatistics
                {
                    ProcessedTime = logFile->CurrentTime,
                    BuffersRead = logFile->BuffersRead,
                    BufferSize = logFile->BufferSize,
                    BufferUsed = logFile->Filled
                }) ?? true;
            }
            return shouldContinue ? 1u : 0u;
        }

        [UnmanagedCallersOnly]
        private static void NativeEventCallback(Native.EventRecord* record)
        {
            if (s_instances.TryGetValue((int)record->UserContext, out var weakReference) &&
                weakReference.TryGetTarget(out var instance))
            {
                instance._eventCallback?.Invoke(new EtwEvent(record));
            }
        }

        /// <summary>
        /// Opens the trace.
        /// </summary>
        /// <param name="bufferCallback">A callback when buffers are processed.</param>
        /// <param name="eventCallback">A callback when events are processed.</param>
        /// <returns>Information about the trace.</returns>
        public Statistics Open(BufferCallback bufferCallback, EventCallback eventCallback)
        {
            if (!_traceHandle.IsInvalid)
            {
                throw new InvalidOperationException();
            }

            _bufferCallback = bufferCallback;
            _eventCallback = eventCallback;
            fixed (char* namePointer = Name)
            {
                Native.EventTraceLogFile logFile = !IsRealTime
                    ? new(namePointer, null, Native.ProcessTraceMode.EventRecord, &NativeBufferCallback, &NativeEventCallback, _id)
                    : new(null, namePointer, Native.ProcessTraceMode.RealTime | Native.ProcessTraceMode.EventRecord, &NativeBufferCallback, &NativeEventCallback, _id);
                _traceHandle = Native.OpenTrace(&logFile);
                return _traceHandle.IsInvalid
                    ? throw new InvalidOperationException()
                    : new Statistics
                    {
                        BufferSize = logFile.LogFileHeader.BufferSize,
                        OsVersion = logFile.LogFileHeader.Version,
                        PointerSize = logFile.LogFileHeader.PointerSize,
                        ProcessorCount = logFile.LogFileHeader.NumberOfProcessors,
                        CpuSpeed = logFile.LogFileHeader.CpuSpeedInMHz,
                        BootTime = logFile.LogFileHeader.BootTime,
                        StartTime = logFile.LogFileHeader.StartTime,
                        EndTime = logFile.LogFileHeader.EndTime,
                        TimerResolution = logFile.LogFileHeader.TimerResolution,
                        MaximumFileSize = logFile.LogFileHeader.MaximumFileSize,
                        LogFileMode = logFile.LogFileHeader.LogFileMode,
                        BuffersWritten = logFile.LogFileHeader.BuffersWritten,
                        EventsLost = logFile.LogFileHeader.EventsLost,
                        BuffersLost = logFile.LogFileHeader.BuffersLost,
                        PerfFrequency = logFile.LogFileHeader.PerfFreq,
                        ClockResolution = logFile.LogFileHeader.ReservedFlags,
                        IsKernelTrace = logFile.IsKernelTrace
                    };
            }
        }

        /// <summary>
        /// Processes the trace.
        /// </summary>
        public void Process()
        {
            var handle = _traceHandle;
            ((Native.Hresult)Native.ProcessTrace(&handle, 1, null, null)).ThrowException();
        }

        /// <summary>
        /// Disposes the trace.
        /// </summary>
        public void Dispose()
        {
            if (!_traceHandle.IsInvalid)
            {
                ((Native.Hresult)Native.CloseTrace(_traceHandle)).ThrowException();
                _traceHandle = Native.TraceHandle.Invalid;
            }

            _ = s_instances.TryRemove(_id, out var _);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Statistics about the trace.
        /// </summary>
        public sealed record Statistics
        {
            /// <summary>
            /// The version of the OS the trace was captured on.
            /// </summary>
            public Version OsVersion { get; init; }

            /// <summary>
            /// Pointer size, in bytes.
            /// </summary>
            public uint PointerSize { get; init; }

            /// <summary>
            /// The processor count on the machine.
            /// </summary>
            public uint ProcessorCount { get; init; }

            /// <summary>
            /// The CPU speed.
            /// </summary>
            public uint CpuSpeed { get; init; }

            /// <summary>
            /// Time when the machine was booted.
            /// </summary>
            public DateTime BootTime { get; init; }

            /// <summary>
            /// Start time of the trace.
            /// </summary>
            public DateTime StartTime { get; init; }

            /// <summary>
            /// End time of the trace, if any.
            /// </summary>
            public DateTime EndTime { get; init; }

            /// <summary>
            /// Maximum size of the log file.
            /// </summary>
            public uint MaximumFileSize { get; init; }

            /// <summary>
            /// The log file mode.
            /// </summary>
            public EtwLogFileMode LogFileMode { get; init; }

            /// <summary>
            /// The size of the trace's buffers;
            /// </summary>
            public uint BufferSize { get; init; }

            /// <summary>
            /// The number of buffers written.
            /// </summary>
            public uint BuffersWritten { get; init; }

            /// <summary>
            /// The number of events lost.
            /// </summary>
            public uint EventsLost { get; init; }

            /// <summary>
            /// The number of buffers lost.
            /// </summary>
            public uint BuffersLost { get; init; }

            /// <summary>
            /// The timer resolution of the hardware timer, in 100 nanoseconds.
            /// </summary>
            public uint TimerResolution { get; init; }

            /// <summary>
            /// The frequency of the high-performance counter, if any.
            /// </summary>
            public long PerfFrequency { get; init; }

            /// <summary>
            /// The clock resolution.
            /// </summary>
            public EtwClockResolution ClockResolution { get; init; }

            /// <summary>
            /// Whether the trace is from the NT Kernel Logger.
            /// </summary>
            public bool IsKernelTrace { get; init; }
        }

        /// <summary>
        /// Statistics about a buffer that was processed.
        /// </summary>
        public sealed record BufferStatistics
        {
            /// <summary>
            /// The time the buffer was processed.
            /// </summary>
            public DateTime ProcessedTime { get; init; }

            /// <summary>
            /// The number of buffers read so far.
            /// </summary>
            public uint BuffersRead { get; init; }

            /// <summary>
            /// The overall size of the buffer.
            /// </summary>
            public uint BufferSize { get; init; }

            /// <summary>
            /// The number of bytes used in the buffer.
            /// </summary>
            public uint BufferUsed { get; init; }
        }
    }
}
