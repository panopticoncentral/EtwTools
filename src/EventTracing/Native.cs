using System;
using System.Runtime.InteropServices;

namespace EventTracing
{
    internal static unsafe class Native
    {
        public struct Hresult : IEquatable<Hresult>
        {
            public const uint FacilityWin32 = 0x80070000;

            public static readonly Hresult ErrorMoreData = new(0x800700EA);

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

        public struct ErrorCode
        {
            public int Value { get; }
        }

        public enum ClockResolution : uint
        {
            QueryPerformanceCounter = 1,
            SystemTime = 2,
            CpuCycleCounter = 3
        }

        [Flags]
        public enum LogFileMode : uint
        {
            FileModeNone = 0x00000000,
            FileModeSequential = 0x00000001,
            FileModeCircular = 0x00000002,
            FileModeAppend = 0x00000004,
            FileModeNewFile = 0x00000008,
            FileModePreAllocate = 0x00000020,
            NonStoppableMode = 0x00000040,
            SecureMode = 0x00000080,
            RealTimeMode = 0x00000100,
            DelayOpenFileMode = 0x00000200,
            BufferingMode = 0x00000400,
            PrivateLoggerMode = 0x00000800,
            AddHeaderMode = 0x00001000,
            UseKbytesForSize = 0x00002000,
            UseGlobalSequence = 0x00004000,
            UseLocalSequence = 0x00008000,
            RelogMode = 0x00010000,
            PrivateInProc = 0x00020000,
            ModeReserved = 0x00100000,
            StopOnHybridShutdown = 0x00400000,
            PersistOnHybridShutdown = 0x0080000,
            UsePagedMemory = 0x01000000,
            SystemLoggerMode = 0x02000000,
            IndependentSessionMode = 0x08000000,
            NoPerProcessorBuffering = 0x10000000,
            AddToTriageDump = 0x80000000
        }

#pragma warning disable IDE1006
        [StructLayout(LayoutKind.Sequential)]
        public struct WnodeHeader
        {
            public uint BufferSize;
            public uint ProviderId;
            public long HistoricalContext;
            public long TimeStamp;
            public Guid Guid;
            public ClockResolution ClientContext;
            public uint Flags;
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
            public uint EnableFlags;
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
#pragma warning restore IDE1006

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode)]
        public static extern ErrorCode QueryAllTraces(EventTraceProperties** propertyArray, int propertyArrayCount, out int sessionCount);
    }
}
