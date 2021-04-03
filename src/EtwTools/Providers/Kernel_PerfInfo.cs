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
        /// An event wrapper for a SampleProfile event.
        /// </summary>
        public readonly ref struct SampleProfileEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 1;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SampleProfile";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = new("ce1dbfb4-137e-4da6-87b0-3f59aa102cbc");

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
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Retrieves the InstructionPointer field.
            /// </summary>
            public uint InstructionPointer() => BitConverter.ToUInt32(_etwEvent.Data);

            /// <summary>
            /// Retrieves the ThreadId field.
            /// </summary>
            public uint ThreadId() => BitConverter.ToUInt32(_etwEvent.Data[4..]);

            /// <summary>
            /// Retrieves the Count field.
            /// </summary>
            public ushort Count() => BitConverter.ToUInt16(_etwEvent.Data[8..]);

            /// <summary>
            /// Creates a new SampleProfileEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SampleProfileEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a PmcCounterProfile event.
        /// </summary>
        public readonly ref struct PmcCounterProfileEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 2;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "PmcCounterProfile";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = new("ce1dbfb4-137e-4da6-87b0-3f59aa102cbc");

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
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Retrieves the InstructionPointer field.
            /// </summary>
            public uint InstructionPointer() => BitConverter.ToUInt32(_etwEvent.Data);

            /// <summary>
            /// Retrieves the ThreadId field.
            /// </summary>
            public uint ThreadId() => BitConverter.ToUInt32(_etwEvent.Data[4..]);

            /// <summary>
            /// Retrieves the ProfileSource field.
            /// </summary>
            public ushort ProfileSource() => BitConverter.ToUInt16(_etwEvent.Data[8..]);

            /// <summary>
            /// Creates a new PmcCounterProfileEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public PmcCounterProfileEvent(EtwEvent etwEvent)
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

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 3;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SampledProfileSetInterval";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = new("ce1dbfb4-137e-4da6-87b0-3f59aa102cbc");

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
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Retrieves the Source field.
            /// </summary>
            public uint Source() => BitConverter.ToUInt32(_etwEvent.Data);

            /// <summary>
            /// Retrieves the NewInterval field.
            /// </summary>
            public uint NewInterval() => BitConverter.ToUInt32(_etwEvent.Data[4..]);

            /// <summary>
            /// Retrieves the OldInterval field.
            /// </summary>
            public uint OldInterval() => BitConverter.ToUInt32(_etwEvent.Data[8..]);

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

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 4;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SampledProfileIntervalStart";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = new("ce1dbfb4-137e-4da6-87b0-3f59aa102cbc");

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
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Retrieves the Source field.
            /// </summary>
            public uint Source() => BitConverter.ToUInt32(_etwEvent.Data);

            /// <summary>
            /// Retrieves the NewInterval field.
            /// </summary>
            public uint NewInterval() => BitConverter.ToUInt32(_etwEvent.Data[4..]);

            /// <summary>
            /// Retrieves the OldInterval field.
            /// </summary>
            public uint OldInterval() => BitConverter.ToUInt32(_etwEvent.Data[8..]);

            /// <summary>
            /// Retrieves the SourceName field.
            /// </summary>
            public string SourceName() => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[12..]);

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

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 5;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SampledProfileIntervalEnd";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = new("ce1dbfb4-137e-4da6-87b0-3f59aa102cbc");

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
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Retrieves the Source field.
            /// </summary>
            public uint Source() => BitConverter.ToUInt32(_etwEvent.Data);

            /// <summary>
            /// Retrieves the NewInterval field.
            /// </summary>
            public uint NewInterval() => BitConverter.ToUInt32(_etwEvent.Data[4..]);

            /// <summary>
            /// Retrieves the OldInterval field.
            /// </summary>
            public uint OldInterval() => BitConverter.ToUInt32(_etwEvent.Data[8..]);

            /// <summary>
            /// Retrieves the SourceName field.
            /// </summary>
            public string SourceName() => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[12..]);

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

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 6;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SpinlockConfigureStart";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = new("ce1dbfb4-137e-4da6-87b0-3f59aa102cbc");

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
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Retrieves the SpinLockSpinThreshold field.
            /// </summary>
            public uint SpinLockSpinThreshold() => BitConverter.ToUInt32(_etwEvent.Data);

            /// <summary>
            /// Retrieves the SpinLockContentionSampleRate field.
            /// </summary>
            public uint SpinLockContentionSampleRate() => BitConverter.ToUInt32(_etwEvent.Data[4..]);

            /// <summary>
            /// Retrieves the SpinLockAcquireSampleRate field.
            /// </summary>
            public uint SpinLockAcquireSampleRate() => BitConverter.ToUInt32(_etwEvent.Data[8..]);

            /// <summary>
            /// Retrieves the SpinLockHoldThreshold field.
            /// </summary>
            public uint SpinLockHoldThreshold() => BitConverter.ToUInt32(_etwEvent.Data[12..]);

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

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 7;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SpinlockConfigureEnd";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = new("ce1dbfb4-137e-4da6-87b0-3f59aa102cbc");

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
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Retrieves the SpinLockSpinThreshold field.
            /// </summary>
            public uint SpinLockSpinThreshold() => BitConverter.ToUInt32(_etwEvent.Data);

            /// <summary>
            /// Retrieves the SpinLockContentionSampleRate field.
            /// </summary>
            public uint SpinLockContentionSampleRate() => BitConverter.ToUInt32(_etwEvent.Data[4..]);

            /// <summary>
            /// Retrieves the SpinLockAcquireSampleRate field.
            /// </summary>
            public uint SpinLockAcquireSampleRate() => BitConverter.ToUInt32(_etwEvent.Data[8..]);

            /// <summary>
            /// Retrieves the SpinLockHoldThreshold field.
            /// </summary>
            public uint SpinLockHoldThreshold() => BitConverter.ToUInt32(_etwEvent.Data[12..]);

            /// <summary>
            /// Creates a new SpinlockConfigureEndEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SpinlockConfigureEndEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }
    }
}
