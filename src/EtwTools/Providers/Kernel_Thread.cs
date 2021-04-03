using System;

namespace EtwTools.Providers.Kernel
{
    /// <summary>
    /// Provider for Kernel-Thread (3d6fa8d1-fe05-11d0-9dda-00c04fd7ba7c)
    /// </summary>
    public sealed class ThreadProvider
    {
        /// <summary>
        /// Provider ID.
        /// </summary>
        public static readonly Guid Id = new("3d6fa8d1-fe05-11d0-9dda-00c04fd7ba7c");

        /// <summary>
        /// Provider name.
        /// </summary>
        public const string Name = "Kernel-Thread";

        /// <summary>
        /// An event wrapper for a Start event.
        /// </summary>
        public readonly ref struct StartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 14;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Start";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = new("3d6fa8d1-fe05-11d0-9dda-00c04fd7ba7c");

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 4, Channel = 0, Level = 0, Opcode = (EtwEventType)1, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Retrieves the ProcessId field.
            /// </summary>
            public uint ProcessId() => BitConverter.ToUInt32(_etwEvent.Data);

            /// <summary>
            /// Retrieves the ThreadId field.
            /// </summary>
            public uint ThreadId() => BitConverter.ToUInt32(_etwEvent.Data[4..]);

            /// <summary>
            /// Retrieves the StackBase field.
            /// </summary>
            public uint StackBase() => BitConverter.ToUInt32(_etwEvent.Data[8..]);

            /// <summary>
            /// Retrieves the StackLimit field.
            /// </summary>
            public uint StackLimit() => BitConverter.ToUInt32(_etwEvent.Data[12..]);

            /// <summary>
            /// Retrieves the UserStackBase field.
            /// </summary>
            public uint UserStackBase() => BitConverter.ToUInt32(_etwEvent.Data[16..]);

            /// <summary>
            /// Retrieves the UserStackLimit field.
            /// </summary>
            public uint UserStackLimit() => BitConverter.ToUInt32(_etwEvent.Data[20..]);

            /// <summary>
            /// Retrieves the Affinity field.
            /// </summary>
            public uint Affinity() => BitConverter.ToUInt32(_etwEvent.Data[24..]);

            /// <summary>
            /// Retrieves the Win32StartAddr field.
            /// </summary>
            public uint Win32StartAddr() => BitConverter.ToUInt32(_etwEvent.Data[28..]);

            /// <summary>
            /// Retrieves the TebBase field.
            /// </summary>
            public uint TebBase() => BitConverter.ToUInt32(_etwEvent.Data[32..]);

            /// <summary>
            /// Retrieves the SubProcessTag field.
            /// </summary>
            public uint SubProcessTag() => BitConverter.ToUInt32(_etwEvent.Data[36..]);

            /// <summary>
            /// Retrieves the BasePriority field.
            /// </summary>
            public byte BasePriority() => _etwEvent.Data[40];

            /// <summary>
            /// Retrieves the PagePriority field.
            /// </summary>
            public byte PagePriority() => _etwEvent.Data[41];

            /// <summary>
            /// Retrieves the IoPriority field.
            /// </summary>
            public byte IoPriority() => _etwEvent.Data[42];

            /// <summary>
            /// Retrieves the ThreadFlags field.
            /// </summary>
            public byte ThreadFlags() => _etwEvent.Data[43];

            /// <summary>
            /// Retrieves the ThreadName field.
            /// </summary>
            public string ThreadName() => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[44..]);

            /// <summary>
            /// Creates a new StartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public StartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a End event.
        /// </summary>
        public readonly ref struct EndEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 15;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "End";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = new("3d6fa8d1-fe05-11d0-9dda-00c04fd7ba7c");

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 4, Channel = 0, Level = 0, Opcode = (EtwEventType)2, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Retrieves the ProcessId field.
            /// </summary>
            public uint ProcessId() => BitConverter.ToUInt32(_etwEvent.Data);

            /// <summary>
            /// Retrieves the ThreadId field.
            /// </summary>
            public uint ThreadId() => BitConverter.ToUInt32(_etwEvent.Data[4..]);

            /// <summary>
            /// Retrieves the StackBase field.
            /// </summary>
            public uint StackBase() => BitConverter.ToUInt32(_etwEvent.Data[8..]);

            /// <summary>
            /// Retrieves the StackLimit field.
            /// </summary>
            public uint StackLimit() => BitConverter.ToUInt32(_etwEvent.Data[12..]);

            /// <summary>
            /// Retrieves the UserStackBase field.
            /// </summary>
            public uint UserStackBase() => BitConverter.ToUInt32(_etwEvent.Data[16..]);

            /// <summary>
            /// Retrieves the UserStackLimit field.
            /// </summary>
            public uint UserStackLimit() => BitConverter.ToUInt32(_etwEvent.Data[20..]);

            /// <summary>
            /// Retrieves the Affinity field.
            /// </summary>
            public uint Affinity() => BitConverter.ToUInt32(_etwEvent.Data[24..]);

            /// <summary>
            /// Retrieves the Win32StartAddr field.
            /// </summary>
            public uint Win32StartAddr() => BitConverter.ToUInt32(_etwEvent.Data[28..]);

            /// <summary>
            /// Retrieves the TebBase field.
            /// </summary>
            public uint TebBase() => BitConverter.ToUInt32(_etwEvent.Data[32..]);

            /// <summary>
            /// Retrieves the SubProcessTag field.
            /// </summary>
            public uint SubProcessTag() => BitConverter.ToUInt32(_etwEvent.Data[36..]);

            /// <summary>
            /// Retrieves the BasePriority field.
            /// </summary>
            public byte BasePriority() => _etwEvent.Data[40];

            /// <summary>
            /// Retrieves the PagePriority field.
            /// </summary>
            public byte PagePriority() => _etwEvent.Data[41];

            /// <summary>
            /// Retrieves the IoPriority field.
            /// </summary>
            public byte IoPriority() => _etwEvent.Data[42];

            /// <summary>
            /// Retrieves the ThreadFlags field.
            /// </summary>
            public byte ThreadFlags() => _etwEvent.Data[43];

            /// <summary>
            /// Retrieves the ThreadName field.
            /// </summary>
            public string ThreadName() => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[44..]);

            /// <summary>
            /// Creates a new EndEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public EndEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a DCStart event.
        /// </summary>
        public readonly ref struct DCStartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 16;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DCStart";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = new("3d6fa8d1-fe05-11d0-9dda-00c04fd7ba7c");

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 4, Channel = 0, Level = 0, Opcode = (EtwEventType)3, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Retrieves the ProcessId field.
            /// </summary>
            public uint ProcessId() => BitConverter.ToUInt32(_etwEvent.Data);

            /// <summary>
            /// Retrieves the ThreadId field.
            /// </summary>
            public uint ThreadId() => BitConverter.ToUInt32(_etwEvent.Data[4..]);

            /// <summary>
            /// Retrieves the StackBase field.
            /// </summary>
            public uint StackBase() => BitConverter.ToUInt32(_etwEvent.Data[8..]);

            /// <summary>
            /// Retrieves the StackLimit field.
            /// </summary>
            public uint StackLimit() => BitConverter.ToUInt32(_etwEvent.Data[12..]);

            /// <summary>
            /// Retrieves the UserStackBase field.
            /// </summary>
            public uint UserStackBase() => BitConverter.ToUInt32(_etwEvent.Data[16..]);

            /// <summary>
            /// Retrieves the UserStackLimit field.
            /// </summary>
            public uint UserStackLimit() => BitConverter.ToUInt32(_etwEvent.Data[20..]);

            /// <summary>
            /// Retrieves the Affinity field.
            /// </summary>
            public uint Affinity() => BitConverter.ToUInt32(_etwEvent.Data[24..]);

            /// <summary>
            /// Retrieves the Win32StartAddr field.
            /// </summary>
            public uint Win32StartAddr() => BitConverter.ToUInt32(_etwEvent.Data[28..]);

            /// <summary>
            /// Retrieves the TebBase field.
            /// </summary>
            public uint TebBase() => BitConverter.ToUInt32(_etwEvent.Data[32..]);

            /// <summary>
            /// Retrieves the SubProcessTag field.
            /// </summary>
            public uint SubProcessTag() => BitConverter.ToUInt32(_etwEvent.Data[36..]);

            /// <summary>
            /// Retrieves the BasePriority field.
            /// </summary>
            public byte BasePriority() => _etwEvent.Data[40];

            /// <summary>
            /// Retrieves the PagePriority field.
            /// </summary>
            public byte PagePriority() => _etwEvent.Data[41];

            /// <summary>
            /// Retrieves the IoPriority field.
            /// </summary>
            public byte IoPriority() => _etwEvent.Data[42];

            /// <summary>
            /// Retrieves the ThreadFlags field.
            /// </summary>
            public byte ThreadFlags() => _etwEvent.Data[43];

            /// <summary>
            /// Retrieves the ThreadName field.
            /// </summary>
            public string ThreadName() => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[44..]);

            /// <summary>
            /// Creates a new DCStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DCStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a DCEnd event.
        /// </summary>
        public readonly ref struct DCEndEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 17;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DCEnd";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = new("3d6fa8d1-fe05-11d0-9dda-00c04fd7ba7c");

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 4, Channel = 0, Level = 0, Opcode = (EtwEventType)4, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Retrieves the ProcessId field.
            /// </summary>
            public uint ProcessId() => BitConverter.ToUInt32(_etwEvent.Data);

            /// <summary>
            /// Retrieves the ThreadId field.
            /// </summary>
            public uint ThreadId() => BitConverter.ToUInt32(_etwEvent.Data[4..]);

            /// <summary>
            /// Retrieves the StackBase field.
            /// </summary>
            public uint StackBase() => BitConverter.ToUInt32(_etwEvent.Data[8..]);

            /// <summary>
            /// Retrieves the StackLimit field.
            /// </summary>
            public uint StackLimit() => BitConverter.ToUInt32(_etwEvent.Data[12..]);

            /// <summary>
            /// Retrieves the UserStackBase field.
            /// </summary>
            public uint UserStackBase() => BitConverter.ToUInt32(_etwEvent.Data[16..]);

            /// <summary>
            /// Retrieves the UserStackLimit field.
            /// </summary>
            public uint UserStackLimit() => BitConverter.ToUInt32(_etwEvent.Data[20..]);

            /// <summary>
            /// Retrieves the Affinity field.
            /// </summary>
            public uint Affinity() => BitConverter.ToUInt32(_etwEvent.Data[24..]);

            /// <summary>
            /// Retrieves the Win32StartAddr field.
            /// </summary>
            public uint Win32StartAddr() => BitConverter.ToUInt32(_etwEvent.Data[28..]);

            /// <summary>
            /// Retrieves the TebBase field.
            /// </summary>
            public uint TebBase() => BitConverter.ToUInt32(_etwEvent.Data[32..]);

            /// <summary>
            /// Retrieves the SubProcessTag field.
            /// </summary>
            public uint SubProcessTag() => BitConverter.ToUInt32(_etwEvent.Data[36..]);

            /// <summary>
            /// Retrieves the BasePriority field.
            /// </summary>
            public byte BasePriority() => _etwEvent.Data[40];

            /// <summary>
            /// Retrieves the PagePriority field.
            /// </summary>
            public byte PagePriority() => _etwEvent.Data[41];

            /// <summary>
            /// Retrieves the IoPriority field.
            /// </summary>
            public byte IoPriority() => _etwEvent.Data[42];

            /// <summary>
            /// Retrieves the ThreadFlags field.
            /// </summary>
            public byte ThreadFlags() => _etwEvent.Data[43];

            /// <summary>
            /// Retrieves the ThreadName field.
            /// </summary>
            public string ThreadName() => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[44..]);

            /// <summary>
            /// Creates a new DCEndEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DCEndEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a CSwitch event.
        /// </summary>
        public readonly ref struct CSwitchEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 18;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "CSwitch";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = new("3d6fa8d1-fe05-11d0-9dda-00c04fd7ba7c");

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 4, Channel = 0, Level = 0, Opcode = (EtwEventType)36, Task = 0, Keyword = 0x0000000000000000 };

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
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Retrieves the NewThreadId field.
            /// </summary>
            public uint NewThreadId() => BitConverter.ToUInt32(_etwEvent.Data);

            /// <summary>
            /// Retrieves the OldThreadId field.
            /// </summary>
            public uint OldThreadId() => BitConverter.ToUInt32(_etwEvent.Data[4..]);

            /// <summary>
            /// Retrieves the NewThreadPriority field.
            /// </summary>
            public sbyte NewThreadPriority() => (sbyte)_etwEvent.Data[8];

            /// <summary>
            /// Retrieves the OldThreadPriority field.
            /// </summary>
            public sbyte OldThreadPriority() => (sbyte)_etwEvent.Data[9];

            /// <summary>
            /// Retrieves the PreviousCState field.
            /// </summary>
            public byte PreviousCState() => _etwEvent.Data[10];

            /// <summary>
            /// Retrieves the OldThreadWaitReason field.
            /// </summary>
            public sbyte OldThreadWaitReason() => (sbyte)_etwEvent.Data[12];

            /// <summary>
            /// Retrieves the ThreadFlags field.
            /// </summary>
            public sbyte ThreadFlags() => (sbyte)_etwEvent.Data[13];

            /// <summary>
            /// Retrieves the OldThreadState field.
            /// </summary>
            public sbyte OldThreadState() => (sbyte)_etwEvent.Data[14];

            /// <summary>
            /// Retrieves the OldThreadWaitIdealProcessor field.
            /// </summary>
            public sbyte OldThreadWaitIdealProcessor() => (sbyte)_etwEvent.Data[15];

            /// <summary>
            /// Retrieves the NewThreadWaitTime field.
            /// </summary>
            public uint NewThreadWaitTime() => BitConverter.ToUInt32(_etwEvent.Data[16..]);

            /// <summary>
            /// Creates a new CSwitchEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public CSwitchEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a CompCS event.
        /// </summary>
        public readonly ref struct CompCSEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 19;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "CompCS";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = new("3d6fa8d1-fe05-11d0-9dda-00c04fd7ba7c");

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)37, Task = 0, Keyword = 0x0000000000000000 };

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
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Creates a new CompCSEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public CompCSEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a SpinLock event.
        /// </summary>
        public readonly ref struct SpinLockEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 20;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SpinLock";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = new("3d6fa8d1-fe05-11d0-9dda-00c04fd7ba7c");

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)41, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Retrieves the SpinLockAddress field.
            /// </summary>
            public uint SpinLockAddress() => BitConverter.ToUInt32(_etwEvent.Data);

            /// <summary>
            /// Retrieves the CallerAddress field.
            /// </summary>
            public uint CallerAddress() => BitConverter.ToUInt32(_etwEvent.Data[4..]);

            /// <summary>
            /// Retrieves the AcquireTime field.
            /// </summary>
            public ulong AcquireTime() => BitConverter.ToUInt64(_etwEvent.Data[8..]);

            /// <summary>
            /// Retrieves the ReleaseTime field.
            /// </summary>
            public ulong ReleaseTime() => BitConverter.ToUInt64(_etwEvent.Data[16..]);

            /// <summary>
            /// Retrieves the WaitTimeInCycles field.
            /// </summary>
            public uint WaitTimeInCycles() => BitConverter.ToUInt32(_etwEvent.Data[24..]);

            /// <summary>
            /// Retrieves the SpinCount field.
            /// </summary>
            public uint SpinCount() => BitConverter.ToUInt32(_etwEvent.Data[28..]);

            /// <summary>
            /// Retrieves the ThreadId field.
            /// </summary>
            public uint ThreadId() => BitConverter.ToUInt32(_etwEvent.Data[32..]);

            /// <summary>
            /// Retrieves the InterruptCount field.
            /// </summary>
            public uint InterruptCount() => BitConverter.ToUInt32(_etwEvent.Data[36..]);

            /// <summary>
            /// Retrieves the Irql field.
            /// </summary>
            public byte Irql() => _etwEvent.Data[40];

            /// <summary>
            /// Retrieves the AcquireDepth field.
            /// </summary>
            public byte AcquireDepth() => _etwEvent.Data[41];

            /// <summary>
            /// Retrieves the Flag field.
            /// </summary>
            public byte Flag() => _etwEvent.Data[42];

            /// <summary>
            /// Creates a new SpinLockEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SpinLockEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a SetPriority event.
        /// </summary>
        public readonly ref struct SetPriorityEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 21;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SetPriority";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = new("3d6fa8d1-fe05-11d0-9dda-00c04fd7ba7c");

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 3, Channel = 0, Level = 0, Opcode = (EtwEventType)48, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Retrieves the ThreadId field.
            /// </summary>
            public uint ThreadId() => BitConverter.ToUInt32(_etwEvent.Data);

            /// <summary>
            /// Retrieves the OldPriority field.
            /// </summary>
            public byte OldPriority() => _etwEvent.Data[4];

            /// <summary>
            /// Retrieves the NewPriority field.
            /// </summary>
            public byte NewPriority() => _etwEvent.Data[5];

            /// <summary>
            /// Creates a new SetPriorityEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SetPriorityEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a SetBasePriority event.
        /// </summary>
        public readonly ref struct SetBasePriorityEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 22;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SetBasePriority";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = new("3d6fa8d1-fe05-11d0-9dda-00c04fd7ba7c");

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 3, Channel = 0, Level = 0, Opcode = (EtwEventType)49, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Retrieves the ThreadId field.
            /// </summary>
            public uint ThreadId() => BitConverter.ToUInt32(_etwEvent.Data);

            /// <summary>
            /// Retrieves the OldPriority field.
            /// </summary>
            public byte OldPriority() => _etwEvent.Data[4];

            /// <summary>
            /// Retrieves the NewPriority field.
            /// </summary>
            public byte NewPriority() => _etwEvent.Data[5];

            /// <summary>
            /// Creates a new SetBasePriorityEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SetBasePriorityEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a ReadyThread event.
        /// </summary>
        public readonly ref struct ReadyThreadEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 23;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ReadyThread";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = new("3d6fa8d1-fe05-11d0-9dda-00c04fd7ba7c");

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)50, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Retrieves the ThreadId field.
            /// </summary>
            public uint ThreadId() => BitConverter.ToUInt32(_etwEvent.Data);

            /// <summary>
            /// Retrieves the AdjustReason field.
            /// </summary>
            public sbyte AdjustReason() => (sbyte)_etwEvent.Data[4];

            /// <summary>
            /// Retrieves the AdjustIncrement field.
            /// </summary>
            public sbyte AdjustIncrement() => (sbyte)_etwEvent.Data[5];

            /// <summary>
            /// Retrieves the Flags field.
            /// </summary>
            public sbyte Flags() => (sbyte)_etwEvent.Data[6];

            /// <summary>
            /// Creates a new ReadyThreadEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ReadyThreadEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a SetPagePriority event.
        /// </summary>
        public readonly ref struct SetPagePriorityEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 24;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SetPagePriority";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = new("3d6fa8d1-fe05-11d0-9dda-00c04fd7ba7c");

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 3, Channel = 0, Level = 0, Opcode = (EtwEventType)51, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Retrieves the ThreadId field.
            /// </summary>
            public uint ThreadId() => BitConverter.ToUInt32(_etwEvent.Data);

            /// <summary>
            /// Retrieves the OldPriority field.
            /// </summary>
            public byte OldPriority() => _etwEvent.Data[4];

            /// <summary>
            /// Retrieves the NewPriority field.
            /// </summary>
            public byte NewPriority() => _etwEvent.Data[5];

            /// <summary>
            /// Creates a new SetPagePriorityEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SetPagePriorityEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a SetIoPriority event.
        /// </summary>
        public readonly ref struct SetIoPriorityEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 25;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SetIoPriority";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = new("3d6fa8d1-fe05-11d0-9dda-00c04fd7ba7c");

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 3, Channel = 0, Level = 0, Opcode = (EtwEventType)52, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Retrieves the ThreadId field.
            /// </summary>
            public uint ThreadId() => BitConverter.ToUInt32(_etwEvent.Data);

            /// <summary>
            /// Retrieves the OldPriority field.
            /// </summary>
            public byte OldPriority() => _etwEvent.Data[4];

            /// <summary>
            /// Retrieves the NewPriority field.
            /// </summary>
            public byte NewPriority() => _etwEvent.Data[5];

            /// <summary>
            /// Creates a new SetIoPriorityEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SetIoPriorityEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a ThreadAffinity event.
        /// </summary>
        public readonly ref struct ThreadAffinityEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 26;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ThreadAffinity";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = new("3d6fa8d1-fe05-11d0-9dda-00c04fd7ba7c");

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)53, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Retrieves the Affinity field.
            /// </summary>
            public uint Affinity() => BitConverter.ToUInt32(_etwEvent.Data);

            /// <summary>
            /// Retrieves the ThreadId field.
            /// </summary>
            public uint ThreadId() => BitConverter.ToUInt32(_etwEvent.Data[4..]);

            /// <summary>
            /// Retrieves the Group field.
            /// </summary>
            public ushort Group() => BitConverter.ToUInt16(_etwEvent.Data[8..]);

            /// <summary>
            /// Creates a new ThreadAffinityEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ThreadAffinityEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a WorkerThread event.
        /// </summary>
        public readonly ref struct WorkerThreadEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 27;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "WorkerThread";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = new("3d6fa8d1-fe05-11d0-9dda-00c04fd7ba7c");

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)57, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Retrieves the ThreadId field.
            /// </summary>
            public uint ThreadId() => BitConverter.ToUInt32(_etwEvent.Data);

            /// <summary>
            /// Retrieves the StartTime field.
            /// </summary>
            public ulong StartTime() => BitConverter.ToUInt64(_etwEvent.Data[4..]);

            /// <summary>
            /// Retrieves the ThreadRoutine field.
            /// </summary>
            public uint ThreadRoutine() => BitConverter.ToUInt32(_etwEvent.Data[12..]);

            /// <summary>
            /// Creates a new WorkerThreadEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public WorkerThreadEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a AntiStarvationBoost event.
        /// </summary>
        public readonly ref struct AntiStarvationBoostEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 28;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "AntiStarvationBoost";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = new("3d6fa8d1-fe05-11d0-9dda-00c04fd7ba7c");

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)60, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Retrieves the ThreadId field.
            /// </summary>
            public uint ThreadId() => BitConverter.ToUInt32(_etwEvent.Data);

            /// <summary>
            /// Retrieves the ProcessorIndex field.
            /// </summary>
            public ushort ProcessorIndex() => BitConverter.ToUInt16(_etwEvent.Data[4..]);

            /// <summary>
            /// Retrieves the Priority field.
            /// </summary>
            public byte Priority() => _etwEvent.Data[6];

            /// <summary>
            /// Creates a new AntiStarvationBoostEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public AntiStarvationBoostEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a ThreadMigration event.
        /// </summary>
        public readonly ref struct ThreadMigrationEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 29;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ThreadMigration";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = new("3d6fa8d1-fe05-11d0-9dda-00c04fd7ba7c");

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)61, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Retrieves the ThreadId field.
            /// </summary>
            public uint ThreadId() => BitConverter.ToUInt32(_etwEvent.Data);

            /// <summary>
            /// Retrieves the SourceProcessorIndex field.
            /// </summary>
            public ushort SourceProcessorIndex() => BitConverter.ToUInt16(_etwEvent.Data[4..]);

            /// <summary>
            /// Retrieves the TargetProcessorIndex field.
            /// </summary>
            public ushort TargetProcessorIndex() => BitConverter.ToUInt16(_etwEvent.Data[6..]);

            /// <summary>
            /// Retrieves the Priority field.
            /// </summary>
            public byte Priority() => _etwEvent.Data[8];

            /// <summary>
            /// Retrieves the IdealProcessorAdjust field.
            /// </summary>
            public bool IdealProcessorAdjust() => _etwEvent.Data[9] != 0;

            /// <summary>
            /// Retrieves the OldIdealProcessorIndex field.
            /// </summary>
            public ushort OldIdealProcessorIndex() => BitConverter.ToUInt16(_etwEvent.Data[10..]);

            /// <summary>
            /// Creates a new ThreadMigrationEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ThreadMigrationEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a KernelQueueEnqueue event.
        /// </summary>
        public readonly ref struct KernelQueueEnqueueEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 30;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "KernelQueueEnqueue";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = new("3d6fa8d1-fe05-11d0-9dda-00c04fd7ba7c");

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)62, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Retrieves the Entry field.
            /// </summary>
            public uint Entry() => BitConverter.ToUInt32(_etwEvent.Data);

            /// <summary>
            /// Retrieves the ThreadId field.
            /// </summary>
            public uint ThreadId() => BitConverter.ToUInt32(_etwEvent.Data[4..]);

            /// <summary>
            /// Creates a new KernelQueueEnqueueEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public KernelQueueEnqueueEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a KernelQueueDequeue event.
        /// </summary>
        public readonly ref struct KernelQueueDequeueEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 31;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "KernelQueueDequeue";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = new("3d6fa8d1-fe05-11d0-9dda-00c04fd7ba7c");

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)63, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Retrieves the ThreadId field.
            /// </summary>
            public uint ThreadId() => BitConverter.ToUInt32(_etwEvent.Data);

            /// <summary>
            /// Retrieves the EntryCount field.
            /// </summary>
            public uint EntryCount() => BitConverter.ToUInt32(_etwEvent.Data[4..]);

            /// <summary>
            /// Retrieves the Entries field.
            /// </summary>
            public uint GetEntries(int index) => BitConverter.ToUInt32(_etwEvent.Data[(8 + (index * sizeof(uint)))..]);

            /// <summary>
            /// Creates a new KernelQueueDequeueEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public KernelQueueDequeueEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a WorkerThreadStart event.
        /// </summary>
        public readonly ref struct WorkerThreadStartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 32;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "WorkerThreadStart";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = new("3d6fa8d1-fe05-11d0-9dda-00c04fd7ba7c");

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)64, Task = 0, Keyword = 0x0000000000000000 };

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
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Retrieves the CallbackRoutine field.
            /// </summary>
            public uint CallbackRoutine() => BitConverter.ToUInt32(_etwEvent.Data);

            /// <summary>
            /// Creates a new WorkerThreadStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public WorkerThreadStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a WorkerThreadStop event.
        /// </summary>
        public readonly ref struct WorkerThreadStopEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 33;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "WorkerThreadStop";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = new("3d6fa8d1-fe05-11d0-9dda-00c04fd7ba7c");

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)65, Task = 0, Keyword = 0x0000000000000000 };

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
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Retrieves the CallbackRoutine field.
            /// </summary>
            public uint CallbackRoutine() => BitConverter.ToUInt32(_etwEvent.Data);

            /// <summary>
            /// Creates a new WorkerThreadStopEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public WorkerThreadStopEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a AutoBoostSetFloor event.
        /// </summary>
        public readonly ref struct AutoBoostSetFloorEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 34;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "AutoBoostSetFloor";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = new("3d6fa8d1-fe05-11d0-9dda-00c04fd7ba7c");

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)66, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Retrieves the Lock field.
            /// </summary>
            public uint Lock() => BitConverter.ToUInt32(_etwEvent.Data);

            /// <summary>
            /// Retrieves the ThreadId field.
            /// </summary>
            public uint ThreadId() => BitConverter.ToUInt32(_etwEvent.Data[4..]);

            /// <summary>
            /// Retrieves the NewCpuPriorityFloor field.
            /// </summary>
            public byte NewCpuPriorityFloor() => _etwEvent.Data[8];

            /// <summary>
            /// Retrieves the OldCpuPriority field.
            /// </summary>
            public byte OldCpuPriority() => _etwEvent.Data[9];

            /// <summary>
            /// Retrieves the IoPriorities field.
            /// </summary>
            public byte IoPriorities() => _etwEvent.Data[10];

            /// <summary>
            /// Retrieves the BoostFlags field.
            /// </summary>
            public byte BoostFlags() => _etwEvent.Data[11];

            /// <summary>
            /// Creates a new AutoBoostSetFloorEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public AutoBoostSetFloorEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a AutoBoostClearFloor event.
        /// </summary>
        public readonly ref struct AutoBoostClearFloorEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 35;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "AutoBoostClearFloor";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = new("3d6fa8d1-fe05-11d0-9dda-00c04fd7ba7c");

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)67, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Retrieves the LockAddress field.
            /// </summary>
            public uint LockAddress() => BitConverter.ToUInt32(_etwEvent.Data);

            /// <summary>
            /// Retrieves the ThreadId field.
            /// </summary>
            public uint ThreadId() => BitConverter.ToUInt32(_etwEvent.Data[4..]);

            /// <summary>
            /// Retrieves the BoostBitmap field.
            /// </summary>
            public uint BoostBitmap() => BitConverter.ToUInt32(_etwEvent.Data[8..]);

            /// <summary>
            /// Creates a new AutoBoostClearFloorEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public AutoBoostClearFloorEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a AutoBoostEntryExhaustion event.
        /// </summary>
        public readonly ref struct AutoBoostEntryExhaustionEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 36;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "AutoBoostEntryExhaustion";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = new("3d6fa8d1-fe05-11d0-9dda-00c04fd7ba7c");

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)68, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Retrieves the LockAddress field.
            /// </summary>
            public uint LockAddress() => BitConverter.ToUInt32(_etwEvent.Data);

            /// <summary>
            /// Retrieves the ThreadId field.
            /// </summary>
            public uint ThreadId() => BitConverter.ToUInt32(_etwEvent.Data[4..]);

            /// <summary>
            /// Creates a new AutoBoostEntryExhaustionEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public AutoBoostEntryExhaustionEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a SubProcessTagChanged event.
        /// </summary>
        public readonly ref struct SubProcessTagChangedEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 37;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SubProcessTagChanged";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = new("3d6fa8d1-fe05-11d0-9dda-00c04fd7ba7c");

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
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Retrieves the OldTag field.
            /// </summary>
            public uint OldTag() => BitConverter.ToUInt32(_etwEvent.Data);

            /// <summary>
            /// Retrieves the NewTag field.
            /// </summary>
            public uint NewTag() => BitConverter.ToUInt32(_etwEvent.Data[4..]);

            /// <summary>
            /// Creates a new SubProcessTagChangedEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SubProcessTagChangedEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a SetName event.
        /// </summary>
        public readonly ref struct SetNameEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 38;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SetName";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = new("3d6fa8d1-fe05-11d0-9dda-00c04fd7ba7c");

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)72, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Retrieves the ProcessId field.
            /// </summary>
            public uint ProcessId() => BitConverter.ToUInt32(_etwEvent.Data);

            /// <summary>
            /// Retrieves the ThreadId field.
            /// </summary>
            public uint ThreadId() => BitConverter.ToUInt32(_etwEvent.Data[4..]);

            /// <summary>
            /// Retrieves the ThreadName field.
            /// </summary>
            public string ThreadName() => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[8..]);

            /// <summary>
            /// Creates a new SetNameEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SetNameEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }
    }
}
