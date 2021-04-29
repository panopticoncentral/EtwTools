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

            public static readonly Hresult OK = new(0x0);
            public static readonly Hresult ErrorFileNotFound = new(0x80070002);
            public static readonly Hresult ErrorInvalidData = new(0x8007000D);
            public static readonly Hresult ErrorInsufficientBuffer = new(0x8007007A);
            public static readonly Hresult ErrorMoreData = new(0x800700EA);
            public static readonly Hresult ErrorNotFound = new(0x80070490);
            public static readonly Hresult ErrorResourceTypeNotFound = new(0x80070715);
            public static readonly Hresult ErrorWmiInstanceNotFound = new(0x80071069);
            public static readonly Hresult ErrorEmpty = new(0x800710D2);
            public static readonly Hresult ErrorResourceNotPresent = new(0x800710DC);

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

            public static explicit operator Hresult(int errorCode) => new((uint)errorCode);
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

        public enum EventHeaderExtendedType : ushort
        {
            None,
            RelatedActivityId,
            Sid,
            TsId,
            InstanceInfo,
            StackTrace32,
            StackTrace64,
            PebsIndex,
            PmcCounters,
            PsmKey,
            EventKey,
            EventSchemaTl,
            ProvTraits,
            ProcessStartKey,
            ControlGuid,
            QpcDelta,
            ContainerId,
            StackKey32,
            StackKey64,
            Max
        }

        public enum DecodingSource
        {
            XmlFile,
            Wbem,
            Wpp,
            Tlg,
            Max
        }

        [Flags]
        public enum PropertyFlags
        {
            Struct = 0x1,
            ParamLength = 0x2,
            ParamCount = 0x4,
            WbemXmlFragment = 0x8,
            ParamFixedLength = 0x10,
            ParamFixedCount = 0x20,
            HasTags = 0x40,
            HasCustomSchema = 0x80
        }

        [Flags]
        public enum MapFlags
        {
            ManifestValuemap = 0x1,
            ManifestBitmap = 0x2,
            ManifestPatternmap = 0x4,
            WbemValuemap = 0x8,
            WbemBitmap = 0x10,
            WbemFlags = 0x20,
            WbemNoMap = 0x30
        };

        public enum MapValueType
        {
            UnsignedLong,
            String
        }

        public enum EventFieldType
        {
            KeywordInformation,
            LevelInformation,
            ChannelInformation,
            TaskInformation,
            OpcodeInformation,
            InformationMax,
        };

#pragma warning disable IDE1006
        [StructLayout(LayoutKind.Sequential)]
        public readonly struct WnodeHeader
        {
            public uint BufferSize { get; init; }
            public uint ProviderId { get; init; }
            public ulong HistoricalContext { get; init; }
            public long TimeStamp { get; init; }
            public Guid Guid { get; init; }
            public EtwClockResolution ClientContext { get; init; }
            public WnodeFlags Flags { get; init; }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct EventTraceProperties
        {
            public WnodeHeader Wnode { get; set; }
            public uint BufferSize { get; set; }
            public uint MinimumBuffers { get; set; }
            public uint MaximumBuffers { get; set; }
            public uint MaximumFileSize { get; set; }
            public EtwLogFileMode LogFileMode { get; set; }
            public uint FlushTimer { get; set; }
            public EtwSystemTraceProvider EnableFlags { get; set; }
            public int AgeLimit { get; set; }
            public uint NumberOfBuffers { get; set; }
            public uint FreeBuffers { get; set; }
            public uint EventsLost { get; set; }
            public uint BuffersWritten { get; set; }
            public uint LogBuffersLost { get; set; }
            public uint RealTimeBuffersLost { get; set; }
            public nint LoggerThreadId { get; set; }
            public uint LogFileNameOffset { get; set; }
            public uint LoggerNameOffset { get; set; }
        }

        [StructLayout(LayoutKind.Sequential)]
        public readonly struct EventMapEntry
        {
            public uint OutputOffset { get; }
            public uint Value { get; }
        }

        [StructLayout(LayoutKind.Sequential)]
        public readonly struct EventMapInfo
        {
            public uint NameOffset { get; }
            public MapFlags Flag { get; }
            public uint EntryCount { get; }
            public MapValueType MapEntryValueType { get; }
        }

        [StructLayout(LayoutKind.Sequential)]
        public readonly struct TraceEventInfo
        {
            public Guid ProviderGuid { get; }
            public Guid EventGuid { get; }
            public EtwEventDescriptor EventDescriptor { get; }
            public DecodingSource DecodingSource { get; }
            public uint ProviderNameOffset { get; }
            public uint LevelNameOffset { get; }
            public uint ChannelNameOffset { get; }
            public uint KeywordsNameOffset { get; }
            public uint TaskNameOffset { get; }
            public uint OpcodeNameOffset { get; }
            public uint EventMessageOffset { get; }
            public uint ProviderMessageOffset { get; }
            private readonly uint _binaryXmlOffset;
            private readonly uint _binaryXmlSize;
            public uint EventNameOffset { get; }
            public uint EventAttributesOffset { get; }
            public uint PropertyCount { get; }
            public uint TopLevelPropertyCount { get; }
            public uint Flags { get; }
        };

        [StructLayout(LayoutKind.Sequential)]
        public readonly struct TraceProviderInfo
        {
            public Guid ProviderGuid { get; }
            public int SchemaSource { get; }
            public int ProviderNameOffset { get; }
        }

        [StructLayout(LayoutKind.Sequential)]
        public readonly struct TraceEnableInfo
        {
            [field: MarshalAs(UnmanagedType.Bool)]
            public bool IsEnabled { get; }
            public EtwTraceLevel Level { get; }
            private readonly byte _reserved1;
            public ushort LoggerId { get; }
            public EtwTraceProperties EnableProperty { get; }
            private readonly uint _reserved2;
            public ulong MatchAnyKeyword { get; }
            public ulong MatchAllKeyword { get; }
        };

        [StructLayout(LayoutKind.Sequential)]
        public readonly struct TraceProviderInstanceInfo
        {
            public uint NextOffset { get; }
            public uint EnableCount { get; }
            public uint Pid { get; }
            public EtwTraceInstanceProperties Flags { get; }
        };

        [StructLayout(LayoutKind.Sequential)]
        public readonly struct EtwBufferContext
        {
            public byte ProcessorNumber { get; }
            public byte Alignment { get; }
            public ushort LoggerId { get; }
        }

        [StructLayout(LayoutKind.Sequential)]
        public readonly struct EventTraceHeader
        {
            public ushort Size { get; }
            public ushort FieldTypeFlags { get; }
            public EtwEventOpcode Type { get; }
            public EtwTraceLevel Level { get; }
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
        public readonly struct EventHeader
        {
            public ushort Size { get; init; }
            private readonly ushort _headerType;
            public EventHeaderFlags Flags { get; init; }
            public EventPropertySource EventProperty { get; init; }
            public uint ThreadId { get; init; }
            public uint ProcessId { get; init; }
            public long TimeStamp { get; init; }
            public Guid ProviderId { get; init; }
            public EtwEventDescriptor EventDescriptor { get; init; }
            public uint KernelTime { get; init; }
            public uint UserTime { get; init; }
            public Guid ActivityId { get; init; }
        }

        [StructLayout(LayoutKind.Sequential)]
        public readonly struct EventHeaderExtendedDataItem
        {
            private readonly ushort _reserved1;
            public readonly EventHeaderExtendedType ExtType;
            private readonly ushort _reserved2;
            public readonly ushort DataSize;
            public readonly ulong DataPtr;
        };

        [StructLayout(LayoutKind.Sequential)]
        public readonly struct EventPropertyInfo
        {
            public PropertyFlags PropertyFlags { get; }
            public uint NameOffset { get; }
            public ushort Union1 { get; }
            public ushort Union2 { get; }
            public uint Union3 { get; }
            public ushort Count { get; }
            public ushort Length { get; }
            public uint Tags { get; }
        }

        [StructLayout(LayoutKind.Sequential)]
        public readonly struct EventRecord
        {
            public EventHeader EventHeader { get; init; }
            public EtwBufferContext BufferContext { get; init; }
            private readonly ushort _extendedDataCount;
            private readonly ushort _userDataLength;
            private readonly EventHeaderExtendedDataItem* _extendedData;
            private readonly byte* _userData;
            public nint UserContext { get; init; }

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
            public EtwLogFileMode LogFileMode { get; }
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
            public EtwClockResolution ReservedFlags { get; }
            public uint BuffersLost { get; }
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public readonly struct EventTraceLogFile
        {
            private readonly char* _logFileName;
            public string LogFileName => _logFileName == null ? null : new(_logFileName);
            private readonly char* _loggerName;
            public string LoggerName => _loggerName == null ? null : new(_loggerName);
            public readonly long _currentTime { get; }
            public DateTime CurrentTime => DateTime.FromFileTime(_currentTime);
            public uint BuffersRead { get; }
            public ProcessTraceMode ProcessTraceMode { get; }
            public EventTrace CurrentEvent { get; }
            public TraceLogFileHeader LogFileHeader { get; }
            private readonly delegate* unmanaged<EventTraceLogFile*, uint> _bufferCallback;
            public uint BufferSize { get; }
            public uint Filled { get; }
            private readonly uint _eventsLost;
            private readonly delegate* unmanaged<EventRecord*, void> _eventRecordCallback;
            private readonly uint _isKernelTrace;
            public bool IsKernelTrace => _isKernelTrace != 0;
            public nint Context { get; }

            public EventTraceLogFile(char* logFileName, char* loggerName, ProcessTraceMode processTraceMode, delegate* unmanaged<EventTraceLogFile*, uint> bufferCallback, delegate* unmanaged<EventRecord*, void> eventRecordCallback, nint context)
            {
                _logFileName = logFileName;
                _loggerName = loggerName;
                _currentTime = default;
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

        [StructLayout(LayoutKind.Sequential)]
        public readonly struct ProviderEventInfo
        {
            public uint NumberOfEvents { get; }
            private readonly uint _reserved;
        }

        [StructLayout(LayoutKind.Sequential)]
        public readonly struct ProviderFieldInfoArray
        {
            public uint NumberOfElements { get; }
            public EventFieldType FieldType { get; }
        }

        [StructLayout(LayoutKind.Sequential)]
        public readonly struct ProviderFieldInfo
        {
            public uint NameOffset { get; }
            public uint DescriptionOffset { get; }
            public ulong Value { get; }
        };


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
        public static extern ErrorCode ProcessTrace(TraceHandle* handleArray, uint handleCount, long* startTime, long* endTime);

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode)]
        public static extern ErrorCode QueryAllTraces(EventTraceProperties** propertyArray, int propertyArrayCount, out int sessionCount);

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode)]
        public static extern ErrorCode StartTrace(out ulong sessionHandle, string sessionName, EventTraceProperties* properties);

        [DllImport("tdh.dll")]
        public static extern ErrorCode TdhEnumerateManifestProviderEvents(Guid* providerGuid, ProviderEventInfo* buffer, uint* bufferSize);

        [DllImport("tdh.dll")]
        public static extern ErrorCode TdhEnumerateProviderFieldInformation(Guid* providerGuid, EventFieldType fieldType, ProviderFieldInfoArray* buffer, uint* bufferSize);

        [DllImport("tdh.dll")]
        public static extern ErrorCode TdhEnumerateProviders(byte* buffer, out int bufferSize);

        [DllImport("tdh.dll", CharSet = CharSet.Unicode)]
        public static extern ErrorCode TdhGetAllEventsInformation(EventRecord* pEvent, IWbemServices wbemServices, uint* index, uint* count, TraceEventInfo** buffer, uint* bufferSize);

        [DllImport("tdh.dll", CharSet = CharSet.Unicode)]
        public static extern ErrorCode TdhGetEventInformation(EventRecord* eventRecord, uint contextCount, void* context, TraceEventInfo* buffer, uint* bufferSize);

        [DllImport("tdh.dll", CharSet = CharSet.Unicode)]
        public static extern ErrorCode TdhGetEventMapInformation(EventRecord* eventRecord, string mapName, EventMapInfo* buffer, uint* bufferSize);

        [DllImport("tdh.dll")]
        public static extern ErrorCode TdhGetManifestEventInformation(Guid* providerGuid, EtwEventDescriptor* eventDescriptor, TraceEventInfo* buffer, uint* bufferSize);

        [Guid("4590F811-1D3A-11D0-891F-00AA004B2E24")]
        [ComImport]
        public class WbemLocator
        {
        }

        [Guid("DC12A687-737F-11CF-884D-00AA004B2E24")]
        [ComImport]
        public interface IWbemLocator
        {
            [PreserveSig] int ConnectServer_([In][MarshalAs(UnmanagedType.BStr)] string strNetworkResource, [In][MarshalAs(UnmanagedType.BStr)] string strUser, [In][MarshalAs(UnmanagedType.BStr)] string strPassword, [In][MarshalAs(UnmanagedType.BStr)] string strLocale, [In] int lSecurityFlags, [In][MarshalAs(UnmanagedType.BStr)] string strAuthority, [In][MarshalAs(UnmanagedType.Interface)] IWbemContext pCtx, [Out][MarshalAs(UnmanagedType.Interface)] out IWbemServices ppNamespace);
        }

        [Guid("44ACA674-E8FC-11D0-A07C-00C04FB68820")]
        [ComImport]
        public interface IWbemContext
        {
        }

        [Guid("9556DC99-828C-11CF-A37E-00AA003240C7")]
        [ComImport]
        public interface IWbemServices
        {
        }
    }
}
