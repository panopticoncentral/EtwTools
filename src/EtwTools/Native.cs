using System;
using System.Runtime.InteropServices;

namespace EtwTools
{
    internal static unsafe class Native
    {
        // Simple wrappers

        public readonly struct Hresult : IEquatable<Hresult>
        {
            public const uint FacilityWin32 = 0x80070000;

            public static readonly Hresult ErrorInsufficientBuffer = new(0x8007007A);
            public static readonly Hresult ErrorMoreData = new(0x800700EA);
            public static readonly Hresult ErrorWmiInstanceNotFound = new(0x80071069);

            public uint Value { get; }

            public Hresult(uint value)
            {
                Value = value;
            }

            public Hresult(ErrorCode errorCode)
            {
                Value = (errorCode.Value != 0) ? (FacilityWin32 | ((uint)errorCode.Value & 0xffff)) : 0;
            }

            public void ThrowException() => Marshal.ThrowExceptionForHR(unchecked((int)Value));

            public bool Equals(Hresult other) => Value == other.Value;

            public override bool Equals(object obj) => obj is Hresult hresult && Equals(hresult);

            public override int GetHashCode() => unchecked((int)Value);

            public static bool operator ==(Hresult left, Hresult right) => left.Equals(right);

            public static bool operator !=(Hresult left, Hresult right) => !left.Equals(right);

            public static explicit operator Hresult(ErrorCode errorCode) => new(errorCode);
        }

        public readonly struct ErrorCode
        {
            public int Value { get; }
        }

        public readonly struct TraceHandle
        {
            public ulong Handle { get; }

            public bool IsInvalid => Handle == ulong.MaxValue;

            public TraceHandle(ulong handle)
            {
                Handle = handle;
            }

            public static TraceHandle Invalid = new(ulong.MaxValue);
        }

        // Basic structures

        [StructLayout(LayoutKind.Sequential)]
        public readonly struct SystemTime
        {
            public short Year { get; }
            public short Month { get; }
            public short DayOfWeek { get; }
            public short Day { get; }
            public short Hour { get; }
            public short Minute { get; }
            public short Second { get; }
            public short Milliseconds { get; }
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct TimeZoneInformation
        {
            public int Bias { get; }
            private fixed char _standardName[32];
            public string StandardName
            {
                get
                {
                    fixed (char* standardNamePointer = _standardName)
                    {
                        return new string(standardNamePointer);
                    }
                }
            }
            public SystemTime StandardDate { get; }
            public int StandardBias { get; }
            private fixed char _daylightName[32];
            public string DaylightName
            {
                get
                {
                    fixed (char* daylightNamePointer = _daylightName)
                    {
                        return new string(daylightNamePointer);
                    }
                }
            }
            public SystemTime DaylightDate { get; }
            public int DaylightBias { get; }
        }

        // Enums

        public enum TraceControl
        {
            Query,
            Stop,
            Update,
            Flush
        };

        public enum TraceQueryInfoClass
        {
            TraceGuidQueryList,
            TraceGuidQueryInfo,
            TraceGuidQueryProcess,
            TraceStackTracingInfo,
            TraceSystemTraceEnableFlagsInfo,
            TraceSampledProfileIntervalInfo,
            TraceProfileSourceConfigInfo,
            TraceProfileSourceListInfo,
            TracePmcEventListInfo,
            TracePmcCounterListInfo,
            TraceSetDisallowList,
            TraceVersionInfo,
            TraceGroupQueryList,
            TraceGroupQueryInfo,
            TraceDisallowListQuery,
            TraceInfoReserved15,
            TracePeriodicCaptureStateListInfo,
            TracePeriodicCaptureStateInfo,
            TraceProviderBinaryTracking,
            TraceMaxLoggersQuery,
            TraceLbrConfigurationInfo,
            TraceLbrEventListInfo,
            TraceMaxPmcCounterQuery,
            MaxTraceSetInfoClass
        };

        [Flags]
        public enum ProcessTraceMode : uint
        {
            RealTime = 0x00000100,
            RawTimestamp = 0x00001000,
            EventRecord = 0x10000000,
        }

        public enum EventType : byte
        {
            Info,
            Start,
            End,
            Stop = End,
            DataCollectionStart,
            DataCollectionEnd,
            Extension,
            Reply,
            Dequeue,
            Resume = Dequeue,
            Checkpoint,
            Suspend = Checkpoint,
            Send,
            Recieve = 0xF0
        }

        [Flags]
        public enum EventHeaderFlags : ushort
        {
            ExtendedInfo = 0x1,
            PrivateSession = 0x2,
            StringOnly = 0x4,
            TraceMessage = 0x8,
            NoCpuTime = 0x10,
            x86Header = 0x20,
            x64Header = 0x40,
            ClassicHeader = 0x100
        }

        public enum EventPropertySource : ushort
        {
            Xml = 0x1,
            ForwardedXml = 0x2,
            LegacyEventLog = 0x4
        }

        [Flags]
        public enum WnodeFlags : uint
        {
            TracedGuid = 0x00020000
        }

#pragma warning disable IDE1006
        [StructLayout(LayoutKind.Sequential)]
        public struct WnodeHeader
        {
            public uint BufferSize;
            public uint ProviderId;
            public ulong HistoricalContext;
            public long TimeStamp;
            public Guid Guid;
            public ClockResolution ClientContext;
            public WnodeFlags Flags;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct EventTraceProperties
        {
            public WnodeHeader Wnode;
            public uint BufferSize;
            public uint MinimumBuffers;
            public uint MaximumBuffers;
            public uint MaximumFileSize;
            public LogFileMode LogFileMode;
            public uint FlushTimer;
            public SystemTraceProvider EnableFlags;
            public int AgeLimit;
            public uint NumberOfBuffers;
            public uint FreeBuffers;
            public uint EventsLost;
            public uint BuffersWritten;
            public uint LogBuffersLost;
            public uint RealTimeBuffersLost;
            public nint LoggerThreadId;
            public uint LogFileNameOffset;
            public uint LoggerNameOffset;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct TraceProviderInfo
        {
            public Guid ProviderGuid;
            public int SchemaSource;
            public int ProviderNameOffset;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct TraceEnableInfo
        {
            [MarshalAs(UnmanagedType.Bool)]
            public bool IsEnabled;
            public TraceLevel Level;
            public byte Reserved1;
            public ushort LoggerId;
            public TraceProperties EnableProperty;
            public uint Reserved2;
            public ulong MatchAnyKeyword;
            public ulong MatchAllKeyword;
        };

        [StructLayout(LayoutKind.Sequential)]
        public struct TraceProviderInstanceInfo
        {
            public uint NextOffset;
            public uint EnableCount;
            public uint Pid;
            public TraceInstanceProperties Flags;
        };

        [StructLayout(LayoutKind.Sequential)]
        public readonly struct EtwBufferContext
        {
            public readonly byte ProcessorNumber;
            public readonly byte Alignment;
            public readonly ushort LoggerId;
        }

        [StructLayout(LayoutKind.Sequential)]
        public readonly struct EventTraceHeader
        {
            public ushort Size { get; }
            public ushort FieldTypeFlags { get; }
            public EventType Type { get; }
            public TraceLevel Level { get; }
            public ushort Version { get; }
            public uint ThreadId { get; }
            public uint ProcessId { get; }
            public long TimeStamp { get; }
            public Guid Guid { get; }
            public int KernelTime { get; }
            public int UserTime { get; }
        }

        [StructLayout(LayoutKind.Sequential)]
        public readonly struct EventTrace
        {
            public EventTraceHeader Header { get; }
            public uint InstanceId { get; }
            public uint ParentInstanceId { get; }
            public Guid ParentGuid { get; }
            private readonly byte* _mofData;
            private readonly uint _mofLength;
            public Span<byte> MofData => new(_mofData, (int)_mofLength);
            public EtwBufferContext BufferContext { get; }
        }

        [StructLayout(LayoutKind.Sequential)]
        public readonly struct EventDescriptor
        {
            public ushort Id { get; }
            public byte Version { get; }
            public byte Channel { get; }
            public TraceLevel Level { get; }
            public EventType Opcode { get; }
            public ushort Task { get; }
            public ulong Keyword { get; }
        }

        [StructLayout(LayoutKind.Sequential)]
        public readonly struct EventHeader
        {
            public ushort Size { get; }
            private readonly ushort _headerType;
            public EventHeaderFlags Flags { get; }
            public EventPropertySource EventProperty { get; }
            public int ThreadId { get; }
            public int ProcessId { get; }
            public long TimeStamp { get; }
            public Guid ProviderId { get; }
            public EventDescriptor EventDescriptor { get; }
            public int KernelTime { get; }
            public int UserTime { get; }
            public Guid ActivityId { get; }
        }

        [StructLayout(LayoutKind.Sequential)]
        public readonly struct EventHeaderExtendedDataItem
        {
            private readonly ushort _reserved1;
            public readonly ushort ExtType;
            private readonly ushort _reserved2;
            public readonly ushort DataSize;
            public readonly ulong DataPtr;
        };

        [StructLayout(LayoutKind.Sequential)]
        public readonly struct EventRecord
        {
            public EventHeader EventHeader { get; }
            public EtwBufferContext BufferContext { get; }
            private readonly ushort _extendedDataCount;
            private readonly ushort _userDataLength;
            private readonly EventHeaderExtendedDataItem* _extendedData;
            private readonly byte* _userData;
            public nint UserContext { get; }

            public Span<EventHeaderExtendedDataItem> ExtendedData => new(_extendedData, _extendedDataCount);
            public Span<byte> UserData => new(_userData, _userDataLength);
        }

        [StructLayout(LayoutKind.Sequential)]
        public readonly struct TraceLogFileHeader
        {
            public uint BufferSize { get; }
            private readonly byte _major;
            private readonly byte _minor;
            private readonly byte _subVersion;
            private readonly byte _subMinorVersion;
            public Version Version => new(_major, _minor, _subVersion, _subMinorVersion);
            public uint ProviderVersion { get; }
            public uint NumberOfProcessors { get; }
            private readonly long _endTime;
            public DateTime EndTime => DateTime.FromFileTime(_endTime);
            public uint TimerResolution { get; }
            public uint MaximumFileSize { get; }
            public LogFileMode LogFileMode { get; }
            public uint BuffersWritten { get; }
            private readonly uint _startBuffers;
            public uint PointerSize { get; }
            public uint EventsLost { get; }
            public uint CpuSpeedInMHz { get; }
            private readonly nint _loggerName;
            private readonly nint _logFileName;
            public TimeZoneInformation TimeZone { get; }
            private readonly long _bootTime;
            public DateTime BootTime => DateTime.FromFileTime(_bootTime);
            public long PerfFreq { get; }
            private readonly long _startTime;
            public DateTime StartTime => DateTime.FromFileTime(_startTime);
            public ClockResolution ReservedFlags { get; }
            public uint BuffersLost { get; }
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public readonly struct EventTraceLogFile
        {
            private readonly char* _logFileName;
            public string LogFileName => _logFileName == null ? null : new(_logFileName);
            private readonly char* _loggerName;
            public string LoggerName => _loggerName == null ? null : new(_loggerName);
            public long CurrentTime { get; }
            public uint BuffersRead { get; }
            public ProcessTraceMode ProcessTraceMode { get; }
            public EventTrace CurrentEvent { get; }
            public TraceLogFileHeader LogFileHeader { get; }
            private readonly delegate* unmanaged<EventTraceLogFile*> _bufferCallback;
            public uint BufferSize { get; }
            public uint Filled { get; }
            private readonly uint _eventsLost;
            private readonly delegate* unmanaged<EventRecord*> _eventRecordCallback;
            private readonly uint _isKernelTrace;
            public bool IsKernelTrace => _isKernelTrace != 0;
            public nint Context { get; }

            public EventTraceLogFile(char* logFileName, char* loggerName, ProcessTraceMode processTraceMode, delegate* unmanaged<EventTraceLogFile*> bufferCallback, delegate* unmanaged<EventRecord*> eventRecordCallback, nint context)
            {
                _logFileName = logFileName;
                _loggerName = loggerName;
                CurrentTime = default;
                BuffersRead = default;
                ProcessTraceMode = processTraceMode | ProcessTraceMode.EventRecord;
                CurrentEvent = default;
                LogFileHeader = default;
                _bufferCallback = bufferCallback;
                BufferSize = default;
                Filled = default;
                _eventsLost = default;
                _eventRecordCallback = eventRecordCallback;
                _isKernelTrace = default;
                Context = context;
            }
        }

#pragma warning restore IDE1006

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode)]
        internal static extern ErrorCode CloseTrace(TraceHandle traceHandle);

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode)]
        public static extern ErrorCode ControlTrace(ulong sessionHandle, string sessionName, EventTraceProperties* properties, TraceControl controlCode);

        [DllImport("advapi32.dll")]
        public static extern ErrorCode EnumerateTraceGuidsEx(TraceQueryInfoClass infoClass, void* inBuffer, int inBufferSize, void* outBuffer, int outBufferSize, out int returnLength);

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern TraceHandle OpenTrace(EventTraceLogFile* logfile);

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode)]
        public static extern ErrorCode QueryAllTraces(EventTraceProperties** propertyArray, int propertyArrayCount, out int sessionCount);

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode)]
        public static extern ErrorCode StartTrace(out ulong sessionHandle, string sessionName, EventTraceProperties* properties);

        [DllImport("tdh.dll")]
        public static extern ErrorCode TdhEnumerateProviders(byte* buffer, ref int bufferSize);
    }
}
