using System;

namespace EtwTools
{
    /// <summary>
    /// An ETW trace.
    /// </summary>
    public sealed unsafe class EtwTrace : IDisposable
    {
        private Native.TraceHandle _traceHandle = Native.TraceHandle.Invalid;

        /// <summary>
        /// The path of the trace.
        /// </summary>
        public string Path { get; }

        /// <summary>
        /// Constructs a trace from a log file.
        /// </summary>
        /// <param name="path">The path of the log file.</param>
        public EtwTrace(string path)
        {
            Path = path;
        }

        /// <summary>
        /// Open the ETW trace.
        /// </summary>
        /// <returns></returns>
        public Statistics Open()
        {
            fixed (char* pathPointer = Path)
            {
                Native.EventTraceLogFile logFile = new(pathPointer, null, Native.ProcessTraceMode.EventRecord, null, null, 0);
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
                        ClockResolution = logFile.LogFileHeader.ReservedFlags
                    };
            }
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
        }

        /// <summary>
        /// Statistics about the trace;
        /// </summary>
        public record Statistics
        {
            /// <summary>
            /// The version of the OS the trace was captured on.
            /// </summary>
            public Version OsVersion { get; init; }

            /// <summary>
            /// Pointer size, in bytes.
            /// </summary>
            public uint PointerSize { get; internal set; }

            /// <summary>
            /// The processor count on the machine.
            /// </summary>
            public uint ProcessorCount { get; internal set; }

            /// <summary>
            /// The CPU speed.
            /// </summary>
            public uint CpuSpeed { get; internal set; }

            /// <summary>
            /// Time when the machine was booted.
            /// </summary>
            public DateTime BootTime { get; internal set; }

            /// <summary>
            /// Start time of the trace.
            /// </summary>
            public DateTime StartTime { get; internal set; }

            /// <summary>
            /// End time of the trace, if any.
            /// </summary>
            public DateTime EndTime { get; internal set; }

            /// <summary>
            /// Maximum size of the log file.
            /// </summary>
            public uint MaximumFileSize { get; internal set; }

            /// <summary>
            /// The log file mode.
            /// </summary>
            public LogFileMode LogFileMode { get; internal set; }

            /// <summary>
            /// The size of the trace's buffers;
            /// </summary>
            public uint BufferSize { get; init; }

            /// <summary>
            /// The number of buffers written.
            /// </summary>
            public uint BuffersWritten { get; internal set; }

            /// <summary>
            /// The number of events lost.
            /// </summary>
            public uint EventsLost { get; internal set; }

            /// <summary>
            /// The number of buffers lost.
            /// </summary>
            public uint BuffersLost { get; internal set; }

            /// <summary>
            /// The timer resolution of the hardware timer, in 100 nanoseconds.
            /// </summary>
            public uint TimerResolution { get; internal set; }

            /// <summary>
            /// The frequency of the high-performance counter, if any.
            /// </summary>
            public long PerfFrequency { get; internal set; }

            /// <summary>
            /// The clock resolution.
            /// </summary>
            public ClockResolution ClockResolution { get; internal set; }
        }
    }
}
