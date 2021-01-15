using System;
using System.Collections.Generic;

namespace EventTracing
{
    /// <summary>
    /// Represents an ETW session.
    /// </summary>
    public sealed unsafe class EtwSession
    {
        private const int MaxNameSize = 1024;

        private readonly ulong _handle;

        private static int SizeOfProperties => sizeof(Native.EventTraceProperties) + (sizeof(char) * MaxNameSize) + (sizeof(char) * MaxNameSize);

        /// <summary>
        /// The GUID of the session.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// The name of the session.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The clock resolution used by the session.
        /// </summary>
        public ClockResolution ClockResolution { get; }

        private EtwSession(Guid id, string name, ulong handle, ClockResolution clockResolution)
        {
            Id = id;
            Name = name;
            ClockResolution = clockResolution;
            _handle = handle;
        }

        /// <summary>
        /// Gets properties of the session.
        /// </summary>
        /// <returns>Properties of the session.</returns>
        public Properties GetProperties()
        {
            var buffer = stackalloc byte[SizeOfProperties];
            var nativeProperties = (Native.EventTraceProperties*)buffer;
            nativeProperties->Wnode.BufferSize = (uint)SizeOfProperties;
            nativeProperties->LoggerNameOffset = (uint)sizeof(Native.EventTraceProperties);
            nativeProperties->LogFileNameOffset = (uint)sizeof(Native.EventTraceProperties) + (sizeof(char) * MaxNameSize);

            ((Native.Hresult)Native.ControlTrace(_handle, null, nativeProperties, Native.TraceControl.Query)).ThrowException();
            return new Properties(
                nativeProperties->BufferSize,
                nativeProperties->MinimumBuffers,
                nativeProperties->MaximumBuffers,
                nativeProperties->MaximumFileSize,
                nativeProperties->LogFileMode,
                nativeProperties->FlushTimer,
                nativeProperties->EnableFlags,
                new string((char*)&((byte*)nativeProperties)[nativeProperties->LogFileNameOffset]));
        }

        /// <summary>
        /// Gets statistics of the session.
        /// </summary>
        /// <returns>Statistics of the session.</returns>
        public Statistics GetStatistics()
        {
            var buffer = stackalloc byte[SizeOfProperties];
            var nativeProperties = (Native.EventTraceProperties*)buffer;
            nativeProperties->Wnode.BufferSize = (uint)SizeOfProperties;
            nativeProperties->LoggerNameOffset = (uint)sizeof(Native.EventTraceProperties);
            nativeProperties->LogFileNameOffset = (uint)sizeof(Native.EventTraceProperties) + (sizeof(char) * MaxNameSize);

            ((Native.Hresult)Native.ControlTrace(_handle, null, nativeProperties, Native.TraceControl.Query)).ThrowException();
            return new Statistics(
                nativeProperties->NumberOfBuffers,
                nativeProperties->FreeBuffers,
                nativeProperties->EventsLost,
                nativeProperties->BuffersWritten,
                nativeProperties->LogBuffersLost,
                nativeProperties->RealTimeBuffersLost);
        }

        /// <summary>
        /// Gets all ETW sessions the user has access to.
        /// </summary>
        /// <returns>A list of sessions.</returns>
        public static IReadOnlyList<EtwSession> GetAllSessions()
        {
            var hr = (Native.Hresult)Native.QueryAllTraces(null, 0, out var sessionCount);
            if (hr != Native.Hresult.ErrorMoreData)
            {
                hr.ThrowException();
            }

            var sessionsArray = stackalloc byte[sessionCount * SizeOfProperties];
            var propertiesArray = stackalloc Native.EventTraceProperties*[sessionCount];

            for (var i = 0; i < sessionCount; i++)
            {
                var properties = (Native.EventTraceProperties*)&sessionsArray[SizeOfProperties * i];
                properties->Wnode.BufferSize = (uint)SizeOfProperties;
                properties->LoggerNameOffset = (uint)sizeof(Native.EventTraceProperties);
                properties->LogFileNameOffset = (uint)sizeof(Native.EventTraceProperties) + (sizeof(char) * MaxNameSize);
                propertiesArray[i] = properties;
            }

            ((Native.Hresult)Native.QueryAllTraces(propertiesArray, sessionCount, out sessionCount)).ThrowException();

            var list = new List<EtwSession>();
            for (var i = 0; i < sessionCount; i++)
            {
                list.Add(new EtwSession(
                    propertiesArray[i]->Wnode.Guid,
                    new string((char*)&((byte*)propertiesArray[i])[propertiesArray[i]->LoggerNameOffset]),
                    propertiesArray[i]->Wnode.HistoricalContext,
                    propertiesArray[i]->Wnode.ClientContext));
            }

            return list;
        }

        /// <summary>
        /// Finds the session with the given name.
        /// </summary>
        /// <param name="name">The name to look for.</param>
        /// <returns>The session, if found, null otherwise.</returns>
        public static EtwSession GetSession(string name)
        {
            var buffer = stackalloc byte[SizeOfProperties];
            var nativeProperties = (Native.EventTraceProperties*)buffer;
            nativeProperties->Wnode.BufferSize = (uint)SizeOfProperties;
            nativeProperties->LoggerNameOffset = (uint)sizeof(Native.EventTraceProperties);
            nativeProperties->LogFileNameOffset = (uint)sizeof(Native.EventTraceProperties) + (sizeof(char) * MaxNameSize);

            var hr = (Native.Hresult)Native.ControlTrace(0, name, nativeProperties, Native.TraceControl.Query);

            if (hr == Native.Hresult.ErrorWmiInstanceNotFound)
            {
                return null;
            }

            hr.ThrowException();

            return new EtwSession(
                    nativeProperties->Wnode.Guid,
                    new string((char*)&((byte*)nativeProperties)[nativeProperties->LoggerNameOffset]),
                    nativeProperties->Wnode.HistoricalContext,
                    nativeProperties->Wnode.ClientContext);
        }

        /// <summary>
        /// Properties of the session.
        /// </summary>
        public readonly struct Properties
        {
            internal Properties(uint bufferSize, uint minimumBuffers, uint maximumBuffers, uint maximumFileSize, LogFileMode logFileMode, uint flushTimer, SystemTraceProvider systemTraceProvidersEnabled, string logFileName)
            {
                BufferSize = bufferSize;
                MinimumBuffers = minimumBuffers;
                MaximumBuffers = maximumBuffers;
                MaximumFileSize = maximumFileSize;
                LogFileMode = logFileMode;
                FlushTimer = flushTimer;
                SystemTraceProvidersEnabled = systemTraceProvidersEnabled;
                LogFileName = logFileName;
            }

            /// <summary>
            /// Amount of memory allocated for each event tracing session buffer, in kilobytes.
            /// </summary>
            public uint BufferSize { get; }

            /// <summary>
            /// Minimum number of buffers allocated for the event tracing session's buffer pool.
            /// </summary>
            public uint MinimumBuffers { get; }

            /// <summary>
            /// Maximum number of buffers allocated for the event tracing session's buffer pool.
            /// </summary>
            public uint MaximumBuffers { get; }

            /// <summary>
            /// Maximum size of the file used to log events, in megabytes.
            /// </summary>
            public uint MaximumFileSize { get; }

            /// <summary>
            /// Logging modes for the event tracing session.
            /// </summary>
            public LogFileMode LogFileMode { get; }

            /// <summary>
            /// How often, in seconds, the trace buffers are forcibly flushed.
            /// </summary>
            public uint FlushTimer { get; }

            /// <summary>
            /// Which kernel events should be included in the trace.
            /// </summary>
            public SystemTraceProvider SystemTraceProvidersEnabled { get; }

            /// <summary>
            /// The name of the log file.
            /// </summary>
            public string LogFileName { get; }
        }

        /// <summary>
        /// Statistics about the session.
        /// </summary>
        public struct Statistics
        {
            /// <summary>
            /// The number of buffers allocated for the event tracing session's buffer pool.
            /// </summary>
            public uint NumberOfBuffers { get; }

            /// <summary>
            /// The number of buffers that are allocated but unused in the event tracing session's buffer pool.
            /// </summary>
            public uint FreeBuffers { get; }

            /// <summary>
            /// The number of events that were not recorded.
            /// </summary>
            public uint EventsLost { get; }

            /// <summary>
            /// The number of buffers written.
            /// </summary>
            public uint BuffersWritten { get; }

            /// <summary>
            /// The number of buffers that could not be written to the log file.
            /// </summary>
            public uint LogBuffersLost { get; }

            /// <summary>
            /// The number of buffers that could not be delivered in real-time to the consumer.
            /// </summary>
            public uint RealTimeBuffersLost { get; }

            internal Statistics(uint numberOfBuffers, uint freeBuffers, uint eventsLost, uint buffersWritten, uint logBuffersLost, uint realTimeBuffersLost)
            {
                NumberOfBuffers = numberOfBuffers;
                FreeBuffers = freeBuffers;
                EventsLost = eventsLost;
                BuffersWritten = buffersWritten;
                LogBuffersLost = logBuffersLost;
                RealTimeBuffersLost = realTimeBuffersLost;
            }
        }
    }
}
