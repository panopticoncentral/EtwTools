using System;

namespace EtwTools
{
    /// <summary>
    /// System event providers.
    /// </summary>
    [Flags]
    public enum EtwSystemTraceProvider : uint
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0x00000000,
        /// <summary>
        /// Process start and end.
        /// </summary>
        Process = 0x00000001,
        /// <summary>
        /// Thread start and end.
        /// </summary>
        Thread = 0x00000002,
        /// <summary>
        /// Image load.
        /// </summary>
        ImageLoad = 0x00000004,
        /// <summary>
        /// Process performance counters.
        /// </summary>
        ProcessCounters = 0x00000008,
        /// <summary>
        /// Context switches.
        /// </summary>
        Cswitch = 0x00000010,
        /// <summary>
        /// Deferred procedure calls.
        /// </summary>
        Dpc = 0x00000020,
        /// <summary>
        /// Interrupts.
        /// </summary>
        Interrupt = 0x00000040,
        /// <summary>
        /// System calls.
        /// </summary>
        SystemCall = 0x00000080,
        /// <summary>
        /// Physical disk I/O.
        /// </summary>
        DiskIo = 0x00000100,
        /// <summary>
        /// File disk I/O.
        /// </summary>
        DiskFileIo = 0x00000200,
        /// <summary>
        /// Physical disk I/O initialization.
        /// </summary>
        DiskIoInit = 0x00000400,
        /// <summary>
        /// Scheduler/ReadyThread events.
        /// </summary>
        Dispatcher = 0x00000800,
        /// <summary>
        /// All page faults.
        /// </summary>
        MemoryPageFaults = 0x00001000,
        /// <summary>
        /// Hard faults only.
        /// </summary>
        MemoryHardFaults = 0x00002000,
        /// <summary>
        /// Virtual memory operations.
        /// </summary>
        VirtualAlloc = 0x00004000,
        /// <summary>
        /// Map/unmap (excluding images).
        /// </summary>
        Vamap = 0x00008000,
        /// <summary>
        /// TCP/IP send and receieve.
        /// </summary>
        NetworkTcpip = 0x00010000,
        /// <summary>
        /// Registry calls.
        /// </summary>
        Registry = 0x00020000,
        /// <summary>
        /// DbgPrint calls.
        /// </summary>
        DbgPrint = 0x00040000,
        /// <summary>
        /// Job start and end.
        /// </summary>
        Job = 0x00080000,
        /// <summary>
        /// ALPC traces.
        /// </summary>
        Alpc = 0x00100000,
        /// <summary>
        /// Split I/O traces.
        /// </summary>
        SplitIo = 0x00200000,
        /// <summary>
        /// Debugger events.
        /// </summary>
        DebugEvents = 0x00400000,
        /// <summary>
        /// Driver delays.
        /// </summary>
        Driver = 0x00800000,
        /// <summary>
        /// Sample-based profiling.
        /// </summary>
        Profile = 0x01000000,
        /// <summary>
        /// File I/O.
        /// </summary>
        FileIo = 0x02000000,
        /// <summary>
        /// File I/O initialization.
        /// </summary>
        FileIoInit = 0x04000000,
        /// <summary>
        /// Do not do system configuration rundown.
        /// </summary>
        NoSysConfig = 0x10000000,
        /// <summary>
        /// Can forward to WMI.
        /// </summary>
        ForwardWmi = 0x40000000,
        /// <summary>
        /// Indicates more flags.
        /// </summary>
        Extension = 0x80000000
    }
}
