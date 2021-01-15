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

        public struct ErrorCode
        {
            public int Value { get; }
        }

        public enum TraceControl
        {
            Query,
            Stop,
            Update,
            Flush
        };

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
#pragma warning restore IDE1006

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode)]
        public static extern ErrorCode QueryAllTraces(EventTraceProperties** propertyArray, int propertyArrayCount, out int sessionCount);

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode)]
        public static extern ErrorCode ControlTrace(ulong sessionHandle, string sessionName, EventTraceProperties* properties, TraceControl controlCode);
    }
}
