using System;

namespace EtwTools.Providers.Kernel
{
    /// <summary>
    /// Provider for Kernel-PerfInfo (ce1dbfb4-137e-4da6-87b0-3f59aa102cbc)
    /// </summary>
    public sealed class PerfInfoProvider
    {
        /// <summary>
        /// Provider ID.
        /// </summary>
        public static readonly Guid Id = new("ce1dbfb4-137e-4da6-87b0-3f59aa102cbc");

        /// <summary>
        /// Provider name.
        /// </summary>
        public const string Name = "Kernel-PerfInfo";

        /// <summary>
        /// An event wrapper for a Mark event.
        /// </summary>
        public readonly ref struct MarkEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_Message = 0;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 1;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Mark";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = PerfInfoProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 0, Channel = 0, Level = 0, Opcode = (EtwEventType)34, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the Message field.
            /// </summary>
            public string Message => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Message..]);

            /// <summary>
            /// Creates a new MarkEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public MarkEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a SampleProfile event.
        /// </summary>
        public readonly ref struct SampleProfileEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_InstructionPointer = 0;
            private readonly int _offset_ThreadId;
            private readonly int _offset_Count;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 2;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SampleProfile";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = PerfInfoProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)46, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the InstructionPointer field.
            /// </summary>
            public ulong InstructionPointer => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_InstructionPointer.._offset_ThreadId]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_InstructionPointer.._offset_ThreadId]);

            /// <summary>
            /// Retrieves the ThreadId field.
            /// </summary>
            public uint ThreadId => BitConverter.ToUInt32(_etwEvent.Data[_offset_ThreadId.._offset_Count]);

            /// <summary>
            /// Retrieves the Count field.
            /// </summary>
            public ushort Count => BitConverter.ToUInt16(_etwEvent.Data[_offset_Count..]);

            /// <summary>
            /// Creates a new SampleProfileEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SampleProfileEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
                _offset_ThreadId = Offset_InstructionPointer + etwEvent.AddressSize;
                _offset_Count = _offset_ThreadId + 4;
            }
        }

        /// <summary>
        /// An event wrapper for a PmcCounterProfile event.
        /// </summary>
        public readonly ref struct PmcCounterProfileEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_InstructionPointer = 0;
            private readonly int _offset_ThreadId;
            private readonly int _offset_ProfileSource;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 3;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "PmcCounterProfile";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = PerfInfoProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)47, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the InstructionPointer field.
            /// </summary>
            public ulong InstructionPointer => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_InstructionPointer.._offset_ThreadId]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_InstructionPointer.._offset_ThreadId]);

            /// <summary>
            /// Retrieves the ThreadId field.
            /// </summary>
            public uint ThreadId => BitConverter.ToUInt32(_etwEvent.Data[_offset_ThreadId.._offset_ProfileSource]);

            /// <summary>
            /// Retrieves the ProfileSource field.
            /// </summary>
            public ushort ProfileSource => BitConverter.ToUInt16(_etwEvent.Data[_offset_ProfileSource..]);

            /// <summary>
            /// Creates a new PmcCounterProfileEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public PmcCounterProfileEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
                _offset_ThreadId = Offset_InstructionPointer + etwEvent.AddressSize;
                _offset_ProfileSource = _offset_ThreadId + 4;
            }
        }

        /// <summary>
        /// An event wrapper for a PmcCounterConfig event.
        /// </summary>
        public readonly ref struct PmcCounterConfigEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_CounterCount = 0;
            private const int Offset_CounterName = 4;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 4;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "PmcCounterConfig";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = PerfInfoProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)48, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the CounterCount field.
            /// </summary>
            public uint CounterCount => BitConverter.ToUInt32(_etwEvent.Data[Offset_CounterCount..Offset_CounterName]);

            /// <summary>
            /// Retrieves the CounterName field.
            /// </summary>
            public EtwEvent.StringEnumerable CounterName => new(_etwEvent.Data[Offset_CounterName..], CounterCount);

            /// <summary>
            /// Creates a new PmcCounterConfigEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public PmcCounterConfigEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a PmcCounterCorruption event.
        /// </summary>
        public readonly ref struct PmcCounterCorruptionEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_ProcessorNumber = 0;
            private const int Offset_CounterCount = 4;
            private const int Offset_CounterStatus = 8;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 5;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "PmcCounterCorruption";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = PerfInfoProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)49, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the ProcessorNumber field.
            /// </summary>
            public uint ProcessorNumber => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessorNumber..Offset_CounterCount]);

            /// <summary>
            /// Retrieves the CounterCount field.
            /// </summary>
            public uint CounterCount => BitConverter.ToUInt32(_etwEvent.Data[Offset_CounterCount..Offset_CounterStatus]);

            /// <summary>
            /// Retrieves the CounterStatus field.
            /// </summary>
            public EtwEvent.StructEnumerable<CounterCorruptionStatus> CounterStatus => new(_etwEvent.Data[Offset_CounterStatus..], CounterCount);

            /// <summary>
            /// Creates a new PmcCounterCorruptionEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public PmcCounterCorruptionEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a ISRMsi event.
        /// </summary>
        public readonly ref struct ISRMsiEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_InitialTime = 0;
            private const int Offset_Routine = 8;
            private readonly int _offset_ReturnValue;
            private readonly int _offset_InterruptVector;
            private readonly int _offset__reserved;
            private readonly int _offset_MessageNumber;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 6;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ISRMsi";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = PerfInfoProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)50, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the InitialTime field.
            /// </summary>
            public ulong InitialTime => BitConverter.ToUInt64(_etwEvent.Data[Offset_InitialTime..Offset_Routine]);

            /// <summary>
            /// Retrieves the Routine field.
            /// </summary>
            public ulong Routine => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Routine.._offset_ReturnValue]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Routine.._offset_ReturnValue]);

            /// <summary>
            /// Retrieves the ReturnValue field.
            /// </summary>
            public byte ReturnValue => _etwEvent.Data[_offset_ReturnValue];

            /// <summary>
            /// Retrieves the InterruptVector field.
            /// </summary>
            public ushort InterruptVector => BitConverter.ToUInt16(_etwEvent.Data[_offset_InterruptVector.._offset__reserved]);

            /// <summary>
            /// Retrieves the MessageNumber field.
            /// </summary>
            public uint MessageNumber => BitConverter.ToUInt32(_etwEvent.Data[_offset_MessageNumber..]);

            /// <summary>
            /// Creates a new ISRMsiEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ISRMsiEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
                _offset_ReturnValue = Offset_Routine + etwEvent.AddressSize;
                _offset_InterruptVector = _offset_ReturnValue + 1;
                _offset__reserved = _offset_InterruptVector + 2;
                _offset_MessageNumber = _offset__reserved + 1;
            }
        }

        /// <summary>
        /// An event wrapper for a SystemCallEnter event.
        /// </summary>
        public readonly ref struct SystemCallEnterEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_SysCallAddress = 0;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 7;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SystemCallEnter";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = PerfInfoProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)51, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the SysCallAddress field.
            /// </summary>
            public ulong SysCallAddress => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_SysCallAddress..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_SysCallAddress..]);

            /// <summary>
            /// Creates a new SystemCallEnterEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SystemCallEnterEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a SystemCallExit event.
        /// </summary>
        public readonly ref struct SystemCallExitEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_SysCallNTStatus = 0;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 8;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SystemCallExit";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = PerfInfoProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)52, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the SysCallNTStatus field.
            /// </summary>
            public uint SysCallNTStatus => BitConverter.ToUInt32(_etwEvent.Data[Offset_SysCallNTStatus..]);

            /// <summary>
            /// Creates a new SystemCallExitEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SystemCallExitEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a DebuggerEnabled event.
        /// </summary>
        public readonly ref struct DebuggerEnabledEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 9;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DebuggerEnabled";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = PerfInfoProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)58, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Creates a new DebuggerEnabledEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DebuggerEnabledEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a ThreadedDPC event.
        /// </summary>
        public readonly ref struct ThreadedDPCEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_InitialTime = 0;
            private const int Offset_Routine = 8;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 10;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ThreadedDPC";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = PerfInfoProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)66, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the InitialTime field.
            /// </summary>
            public ulong InitialTime => BitConverter.ToUInt64(_etwEvent.Data[Offset_InitialTime..Offset_Routine]);

            /// <summary>
            /// Retrieves the Routine field.
            /// </summary>
            public ulong Routine => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Routine..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Routine..]);

            /// <summary>
            /// Creates a new ThreadedDPCEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ThreadedDPCEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a ISR event.
        /// </summary>
        public readonly ref struct ISREvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_InitialTime = 0;
            private const int Offset_Routine = 8;
            private readonly int _offset_ReturnValue;
            private readonly int _offset_InterruptVector;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 11;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ISR";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = PerfInfoProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)67, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the InitialTime field.
            /// </summary>
            public ulong InitialTime => BitConverter.ToUInt64(_etwEvent.Data[Offset_InitialTime..Offset_Routine]);

            /// <summary>
            /// Retrieves the Routine field.
            /// </summary>
            public ulong Routine => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Routine.._offset_ReturnValue]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Routine.._offset_ReturnValue]);

            /// <summary>
            /// Retrieves the ReturnValue field.
            /// </summary>
            public byte ReturnValue => _etwEvent.Data[_offset_ReturnValue];

            /// <summary>
            /// Retrieves the InterruptVector field.
            /// </summary>
            public ushort InterruptVector => BitConverter.ToUInt16(_etwEvent.Data[_offset_InterruptVector..]);

            /// <summary>
            /// Creates a new ISREvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ISREvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
                _offset_ReturnValue = Offset_Routine + etwEvent.AddressSize;
                _offset_InterruptVector = _offset_ReturnValue + 1;
            }
        }

        /// <summary>
        /// An event wrapper for a DPC event.
        /// </summary>
        public readonly ref struct DPCEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_InitialTime = 0;
            private const int Offset_Routine = 8;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 12;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DPC";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = PerfInfoProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)68, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the InitialTime field.
            /// </summary>
            public ulong InitialTime => BitConverter.ToUInt64(_etwEvent.Data[Offset_InitialTime..Offset_Routine]);

            /// <summary>
            /// Retrieves the Routine field.
            /// </summary>
            public ulong Routine => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Routine..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Routine..]);

            /// <summary>
            /// Creates a new DPCEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DPCEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a TimerDPC event.
        /// </summary>
        public readonly ref struct TimerDPCEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_InitialTime = 0;
            private const int Offset_Routine = 8;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 13;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "TimerDPC";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = PerfInfoProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)69, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the InitialTime field.
            /// </summary>
            public ulong InitialTime => BitConverter.ToUInt64(_etwEvent.Data[Offset_InitialTime..Offset_Routine]);

            /// <summary>
            /// Retrieves the Routine field.
            /// </summary>
            public ulong Routine => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Routine..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Routine..]);

            /// <summary>
            /// Creates a new TimerDPCEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public TimerDPCEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a IOTimer event.
        /// </summary>
        public readonly ref struct IOTimerEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_InitialTime = 0;
            private const int Offset_Routine = 8;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 14;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "IOTimer";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = PerfInfoProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)70, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the InitialTime field.
            /// </summary>
            public ulong InitialTime => BitConverter.ToUInt64(_etwEvent.Data[Offset_InitialTime..Offset_Routine]);

            /// <summary>
            /// Retrieves the Routine field.
            /// </summary>
            public ulong Routine => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Routine..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Routine..]);

            /// <summary>
            /// Creates a new IOTimerEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public IOTimerEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a SampledProfileSetInterval event.
        /// </summary>
        public readonly ref struct SampledProfileSetIntervalEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_Source = 0;
            private const int Offset_NewInterval = 4;
            private const int Offset_OldInterval = 8;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 15;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SampledProfileSetInterval";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = PerfInfoProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)72, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the Source field.
            /// </summary>
            public uint Source => BitConverter.ToUInt32(_etwEvent.Data[Offset_Source..Offset_NewInterval]);

            /// <summary>
            /// Retrieves the NewInterval field.
            /// </summary>
            public uint NewInterval => BitConverter.ToUInt32(_etwEvent.Data[Offset_NewInterval..Offset_OldInterval]);

            /// <summary>
            /// Retrieves the OldInterval field.
            /// </summary>
            public uint OldInterval => BitConverter.ToUInt32(_etwEvent.Data[Offset_OldInterval..]);

            /// <summary>
            /// Creates a new SampledProfileSetIntervalEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SampledProfileSetIntervalEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a SampledProfileIntervalStart event.
        /// </summary>
        public readonly ref struct SampledProfileIntervalStartEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_Source = 0;
            private const int Offset_NewInterval = 4;
            private const int Offset_OldInterval = 8;
            private const int Offset_SourceName = 12;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 16;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SampledProfileIntervalStart";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = PerfInfoProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 3, Channel = 0, Level = 0, Opcode = (EtwEventType)73, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the Source field.
            /// </summary>
            public uint Source => BitConverter.ToUInt32(_etwEvent.Data[Offset_Source..Offset_NewInterval]);

            /// <summary>
            /// Retrieves the NewInterval field.
            /// </summary>
            public uint NewInterval => BitConverter.ToUInt32(_etwEvent.Data[Offset_NewInterval..Offset_OldInterval]);

            /// <summary>
            /// Retrieves the OldInterval field.
            /// </summary>
            public uint OldInterval => BitConverter.ToUInt32(_etwEvent.Data[Offset_OldInterval..Offset_SourceName]);

            /// <summary>
            /// Retrieves the SourceName field.
            /// </summary>
            public string SourceName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_SourceName..]);

            /// <summary>
            /// Creates a new SampledProfileIntervalStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SampledProfileIntervalStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a SampledProfileIntervalEnd event.
        /// </summary>
        public readonly ref struct SampledProfileIntervalEndEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_Source = 0;
            private const int Offset_NewInterval = 4;
            private const int Offset_OldInterval = 8;
            private const int Offset_SourceName = 12;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 17;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SampledProfileIntervalEnd";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = PerfInfoProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 3, Channel = 0, Level = 0, Opcode = (EtwEventType)74, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the Source field.
            /// </summary>
            public uint Source => BitConverter.ToUInt32(_etwEvent.Data[Offset_Source..Offset_NewInterval]);

            /// <summary>
            /// Retrieves the NewInterval field.
            /// </summary>
            public uint NewInterval => BitConverter.ToUInt32(_etwEvent.Data[Offset_NewInterval..Offset_OldInterval]);

            /// <summary>
            /// Retrieves the OldInterval field.
            /// </summary>
            public uint OldInterval => BitConverter.ToUInt32(_etwEvent.Data[Offset_OldInterval..Offset_SourceName]);

            /// <summary>
            /// Retrieves the SourceName field.
            /// </summary>
            public string SourceName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_SourceName..]);

            /// <summary>
            /// Creates a new SampledProfileIntervalEndEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SampledProfileIntervalEndEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a SpinlockConfigureStart event.
        /// </summary>
        public readonly ref struct SpinlockConfigureStartEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_SpinLockSpinThreshold = 0;
            private const int Offset_SpinLockContentionSampleRate = 4;
            private const int Offset_SpinLockAcquireSampleRate = 8;
            private const int Offset_SpinLockHoldThreshold = 12;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 18;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SpinlockConfigureStart";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = PerfInfoProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 3, Channel = 0, Level = 0, Opcode = (EtwEventType)75, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the SpinLockSpinThreshold field.
            /// </summary>
            public uint SpinLockSpinThreshold => BitConverter.ToUInt32(_etwEvent.Data[Offset_SpinLockSpinThreshold..Offset_SpinLockContentionSampleRate]);

            /// <summary>
            /// Retrieves the SpinLockContentionSampleRate field.
            /// </summary>
            public uint SpinLockContentionSampleRate => BitConverter.ToUInt32(_etwEvent.Data[Offset_SpinLockContentionSampleRate..Offset_SpinLockAcquireSampleRate]);

            /// <summary>
            /// Retrieves the SpinLockAcquireSampleRate field.
            /// </summary>
            public uint SpinLockAcquireSampleRate => BitConverter.ToUInt32(_etwEvent.Data[Offset_SpinLockAcquireSampleRate..Offset_SpinLockHoldThreshold]);

            /// <summary>
            /// Retrieves the SpinLockHoldThreshold field.
            /// </summary>
            public uint SpinLockHoldThreshold => BitConverter.ToUInt32(_etwEvent.Data[Offset_SpinLockHoldThreshold..]);

            /// <summary>
            /// Creates a new SpinlockConfigureStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SpinlockConfigureStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a SpinlockConfigureEnd event.
        /// </summary>
        public readonly ref struct SpinlockConfigureEndEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_SpinLockSpinThreshold = 0;
            private const int Offset_SpinLockContentionSampleRate = 4;
            private const int Offset_SpinLockAcquireSampleRate = 8;
            private const int Offset_SpinLockHoldThreshold = 12;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 19;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SpinlockConfigureEnd";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = PerfInfoProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 3, Channel = 0, Level = 0, Opcode = (EtwEventType)76, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the SpinLockSpinThreshold field.
            /// </summary>
            public uint SpinLockSpinThreshold => BitConverter.ToUInt32(_etwEvent.Data[Offset_SpinLockSpinThreshold..Offset_SpinLockContentionSampleRate]);

            /// <summary>
            /// Retrieves the SpinLockContentionSampleRate field.
            /// </summary>
            public uint SpinLockContentionSampleRate => BitConverter.ToUInt32(_etwEvent.Data[Offset_SpinLockContentionSampleRate..Offset_SpinLockAcquireSampleRate]);

            /// <summary>
            /// Retrieves the SpinLockAcquireSampleRate field.
            /// </summary>
            public uint SpinLockAcquireSampleRate => BitConverter.ToUInt32(_etwEvent.Data[Offset_SpinLockAcquireSampleRate..Offset_SpinLockHoldThreshold]);

            /// <summary>
            /// Retrieves the SpinLockHoldThreshold field.
            /// </summary>
            public uint SpinLockHoldThreshold => BitConverter.ToUInt32(_etwEvent.Data[Offset_SpinLockHoldThreshold..]);

            /// <summary>
            /// Creates a new SpinlockConfigureEndEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SpinlockConfigureEndEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a ISRUnexpected event.
        /// </summary>
        public readonly ref struct ISRUnexpectedEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_Vector = 0;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 20;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ISRUnexpected";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = PerfInfoProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)92, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the Vector field.
            /// </summary>
            public ushort Vector => BitConverter.ToUInt16(_etwEvent.Data[Offset_Vector..]);

            /// <summary>
            /// Creates a new ISRUnexpectedEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ISRUnexpectedEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a IoStartTimer event.
        /// </summary>
        public readonly ref struct IoStartTimerEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_DeviceObject = 0;
            private readonly int _offset_TimerRoutine;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 21;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "IoStartTimer";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = PerfInfoProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)93, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the DeviceObject field.
            /// </summary>
            public ulong DeviceObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_DeviceObject.._offset_TimerRoutine]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_DeviceObject.._offset_TimerRoutine]);

            /// <summary>
            /// Retrieves the TimerRoutine field.
            /// </summary>
            public ulong TimerRoutine => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[_offset_TimerRoutine..]) : BitConverter.ToUInt64(_etwEvent.Data[_offset_TimerRoutine..]);

            /// <summary>
            /// Creates a new IoStartTimerEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public IoStartTimerEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
                _offset_TimerRoutine = Offset_DeviceObject + etwEvent.AddressSize;
            }
        }

        /// <summary>
        /// An event wrapper for a IoStopTimer event.
        /// </summary>
        public readonly ref struct IoStopTimerEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_DeviceObject = 0;
            private readonly int _offset_TimerRoutine;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 22;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "IoStopTimer";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = PerfInfoProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)94, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the DeviceObject field.
            /// </summary>
            public ulong DeviceObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_DeviceObject.._offset_TimerRoutine]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_DeviceObject.._offset_TimerRoutine]);

            /// <summary>
            /// Retrieves the TimerRoutine field.
            /// </summary>
            public ulong TimerRoutine => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[_offset_TimerRoutine..]) : BitConverter.ToUInt64(_etwEvent.Data[_offset_TimerRoutine..]);

            /// <summary>
            /// Creates a new IoStopTimerEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public IoStopTimerEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
                _offset_TimerRoutine = Offset_DeviceObject + etwEvent.AddressSize;
            }
        }

        /// <summary>
        /// An event wrapper for a ISRPass event.
        /// </summary>
        public readonly ref struct ISRPassEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_InitialTime = 0;
            private const int Offset_Routine = 8;
            private readonly int _offset_ReturnValue;
            private readonly int _offset_InterruptVector;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 23;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ISRPass";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = PerfInfoProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)95, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the InitialTime field.
            /// </summary>
            public ulong InitialTime => BitConverter.ToUInt64(_etwEvent.Data[Offset_InitialTime..Offset_Routine]);

            /// <summary>
            /// Retrieves the Routine field.
            /// </summary>
            public ulong Routine => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Routine.._offset_ReturnValue]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Routine.._offset_ReturnValue]);

            /// <summary>
            /// Retrieves the ReturnValue field.
            /// </summary>
            public byte ReturnValue => _etwEvent.Data[_offset_ReturnValue];

            /// <summary>
            /// Retrieves the InterruptVector field.
            /// </summary>
            public ushort InterruptVector => BitConverter.ToUInt16(_etwEvent.Data[_offset_InterruptVector..]);

            /// <summary>
            /// Creates a new ISRPassEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ISRPassEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
                _offset_ReturnValue = Offset_Routine + etwEvent.AddressSize;
                _offset_InterruptVector = _offset_ReturnValue + 1;
            }
        }

        /// <summary>
        /// An event wrapper for a WdfISR event.
        /// </summary>
        public readonly ref struct WdfISREvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_Routine = 0;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 24;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "WdfISR";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = PerfInfoProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)96, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the Routine field.
            /// </summary>
            public ulong Routine => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Routine..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Routine..]);

            /// <summary>
            /// Creates a new WdfISREvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public WdfISREvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a WdfPassiveISR event.
        /// </summary>
        public readonly ref struct WdfPassiveISREvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_Routine = 0;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 25;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "WdfPassiveISR";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = PerfInfoProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)97, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the Routine field.
            /// </summary>
            public ulong Routine => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Routine..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Routine..]);

            /// <summary>
            /// Creates a new WdfPassiveISREvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public WdfPassiveISREvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a WdfDPC event.
        /// </summary>
        public readonly ref struct WdfDPCEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_Routine = 0;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 26;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "WdfDPC";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = PerfInfoProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)98, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the Routine field.
            /// </summary>
            public ulong Routine => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Routine..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Routine..]);

            /// <summary>
            /// Creates a new WdfDPCEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public WdfDPCEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a WdfWorkItem event.
        /// </summary>
        public readonly ref struct WdfWorkItemEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_Routine = 0;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 27;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "WdfWorkItem";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = PerfInfoProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)103, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the Routine field.
            /// </summary>
            public ulong Routine => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Routine..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Routine..]);

            /// <summary>
            /// Creates a new WdfWorkItemEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public WdfWorkItemEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a SetKTimer2 event.
        /// </summary>
        public readonly ref struct SetKTimer2Event
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_DueTime = 0;
            private const int Offset_MaximumDueTime = 8;
            private const int Offset_Period = 16;
            private const int Offset_Timer = 24;
            private readonly int _offset_Callback;
            private readonly int _offset_CallbackContext;
            private readonly int _offset_TimerFlags;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 28;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SetKTimer2";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = PerfInfoProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)104, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the DueTime field.
            /// </summary>
            public ulong DueTime => BitConverter.ToUInt64(_etwEvent.Data[Offset_DueTime..Offset_MaximumDueTime]);

            /// <summary>
            /// Retrieves the MaximumDueTime field.
            /// </summary>
            public ulong MaximumDueTime => BitConverter.ToUInt64(_etwEvent.Data[Offset_MaximumDueTime..Offset_Period]);

            /// <summary>
            /// Retrieves the Period field.
            /// </summary>
            public ulong Period => BitConverter.ToUInt64(_etwEvent.Data[Offset_Period..Offset_Timer]);

            /// <summary>
            /// Retrieves the Timer field.
            /// </summary>
            public ulong Timer => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Timer.._offset_Callback]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Timer.._offset_Callback]);

            /// <summary>
            /// Retrieves the Callback field.
            /// </summary>
            public ulong Callback => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[_offset_Callback.._offset_CallbackContext]) : BitConverter.ToUInt64(_etwEvent.Data[_offset_Callback.._offset_CallbackContext]);

            /// <summary>
            /// Retrieves the CallbackContext field.
            /// </summary>
            public ulong CallbackContext => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[_offset_CallbackContext.._offset_TimerFlags]) : BitConverter.ToUInt64(_etwEvent.Data[_offset_CallbackContext.._offset_TimerFlags]);

            /// <summary>
            /// Retrieves the TimerFlags field.
            /// </summary>
            public byte TimerFlags => _etwEvent.Data[_offset_TimerFlags];

            /// <summary>
            /// Creates a new SetKTimer2Event.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SetKTimer2Event(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
                _offset_Callback = Offset_Timer + etwEvent.AddressSize;
                _offset_CallbackContext = _offset_Callback + etwEvent.AddressSize;
                _offset_TimerFlags = _offset_CallbackContext + etwEvent.AddressSize;
            }
        }

        /// <summary>
        /// An event wrapper for a ExpireKTimer2 event.
        /// </summary>
        public readonly ref struct ExpireKTimer2Event
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_DueTime = 0;
            private const int Offset_MaximumDueTime = 8;
            private const int Offset_Period = 16;
            private const int Offset_Timer = 24;
            private readonly int _offset_Callback;
            private readonly int _offset_CallbackContext;
            private readonly int _offset_TimerFlags;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 29;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ExpireKTimer2";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = PerfInfoProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)105, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the DueTime field.
            /// </summary>
            public ulong DueTime => BitConverter.ToUInt64(_etwEvent.Data[Offset_DueTime..Offset_MaximumDueTime]);

            /// <summary>
            /// Retrieves the MaximumDueTime field.
            /// </summary>
            public ulong MaximumDueTime => BitConverter.ToUInt64(_etwEvent.Data[Offset_MaximumDueTime..Offset_Period]);

            /// <summary>
            /// Retrieves the Period field.
            /// </summary>
            public ulong Period => BitConverter.ToUInt64(_etwEvent.Data[Offset_Period..Offset_Timer]);

            /// <summary>
            /// Retrieves the Timer field.
            /// </summary>
            public ulong Timer => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Timer.._offset_Callback]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Timer.._offset_Callback]);

            /// <summary>
            /// Retrieves the Callback field.
            /// </summary>
            public ulong Callback => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[_offset_Callback.._offset_CallbackContext]) : BitConverter.ToUInt64(_etwEvent.Data[_offset_Callback.._offset_CallbackContext]);

            /// <summary>
            /// Retrieves the CallbackContext field.
            /// </summary>
            public ulong CallbackContext => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[_offset_CallbackContext.._offset_TimerFlags]) : BitConverter.ToUInt64(_etwEvent.Data[_offset_CallbackContext.._offset_TimerFlags]);

            /// <summary>
            /// Retrieves the TimerFlags field.
            /// </summary>
            public byte TimerFlags => _etwEvent.Data[_offset_TimerFlags];

            /// <summary>
            /// Creates a new ExpireKTimer2Event.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ExpireKTimer2Event(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
                _offset_Callback = Offset_Timer + etwEvent.AddressSize;
                _offset_CallbackContext = _offset_Callback + etwEvent.AddressSize;
                _offset_TimerFlags = _offset_CallbackContext + etwEvent.AddressSize;
            }
        }

        /// <summary>
        /// An event wrapper for a CancelKTimer2 event.
        /// </summary>
        public readonly ref struct CancelKTimer2Event
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_Timer = 0;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 30;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "CancelKTimer2";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = PerfInfoProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)106, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the Timer field.
            /// </summary>
            public ulong Timer => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Timer..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Timer..]);

            /// <summary>
            /// Creates a new CancelKTimer2Event.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public CancelKTimer2Event(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a DisableKTimer2 event.
        /// </summary>
        public readonly ref struct DisableKTimer2Event
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_Timer = 0;
            private readonly int _offset_DisableCallback;
            private readonly int _offset_DisableContext;
            private readonly int _offset_TimerFlags;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 31;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DisableKTimer2";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = PerfInfoProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)107, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the Timer field.
            /// </summary>
            public ulong Timer => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Timer.._offset_DisableCallback]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Timer.._offset_DisableCallback]);

            /// <summary>
            /// Retrieves the DisableCallback field.
            /// </summary>
            public ulong DisableCallback => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[_offset_DisableCallback.._offset_DisableContext]) : BitConverter.ToUInt64(_etwEvent.Data[_offset_DisableCallback.._offset_DisableContext]);

            /// <summary>
            /// Retrieves the DisableContext field.
            /// </summary>
            public ulong DisableContext => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[_offset_DisableContext.._offset_TimerFlags]) : BitConverter.ToUInt64(_etwEvent.Data[_offset_DisableContext.._offset_TimerFlags]);

            /// <summary>
            /// Retrieves the TimerFlags field.
            /// </summary>
            public byte TimerFlags => _etwEvent.Data[_offset_TimerFlags];

            /// <summary>
            /// Creates a new DisableKTimer2Event.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DisableKTimer2Event(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
                _offset_DisableCallback = Offset_Timer + etwEvent.AddressSize;
                _offset_DisableContext = _offset_DisableCallback + etwEvent.AddressSize;
                _offset_TimerFlags = _offset_DisableContext + etwEvent.AddressSize;
            }
        }

        /// <summary>
        /// An event wrapper for a FinalizeKTimer2 event.
        /// </summary>
        public readonly ref struct FinalizeKTimer2Event
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_Timer = 0;
            private readonly int _offset_DisableCallback;
            private readonly int _offset_DisableContext;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 32;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "FinalizeKTimer2";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = PerfInfoProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)108, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the Timer field.
            /// </summary>
            public ulong Timer => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Timer.._offset_DisableCallback]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Timer.._offset_DisableCallback]);

            /// <summary>
            /// Retrieves the DisableCallback field.
            /// </summary>
            public ulong DisableCallback => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[_offset_DisableCallback.._offset_DisableContext]) : BitConverter.ToUInt64(_etwEvent.Data[_offset_DisableCallback.._offset_DisableContext]);

            /// <summary>
            /// Retrieves the DisableContext field.
            /// </summary>
            public ulong DisableContext => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[_offset_DisableContext..]) : BitConverter.ToUInt64(_etwEvent.Data[_offset_DisableContext..]);

            /// <summary>
            /// Creates a new FinalizeKTimer2Event.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public FinalizeKTimer2Event(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
                _offset_DisableCallback = Offset_Timer + etwEvent.AddressSize;
                _offset_DisableContext = _offset_DisableCallback + etwEvent.AddressSize;
            }
        }

        /// <summary>
        /// A CounterCorruptionStatus structure.
        /// </summary>
        public readonly struct CounterCorruptionStatus
        {

            /// <summary>
            /// Retrieves the ProfileSource field.
            /// </summary>
            public uint ProfileSource { get; init; }

            /// <summary>
            /// Retrieves the LastKnownGoodTimestamp field.
            /// </summary>
            public ulong LastKnownGoodTimestamp { get; init; }
        }
    }
}
