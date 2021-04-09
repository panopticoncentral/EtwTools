using System;

namespace EtwTools.Providers.Kernel
{
    /// <summary>
    /// Provider for Kernel-StackWalk (def2fe46-7bd6-4b80-bd94-f57fe20d0ce3)
    /// </summary>
    public sealed class StackWalkProvider
    {
        /// <summary>
        /// Provider ID.
        /// </summary>
        public static readonly Guid Id = new("def2fe46-7bd6-4b80-bd94-f57fe20d0ce3");

        /// <summary>
        /// Provider name.
        /// </summary>
        public const string Name = "Kernel-StackWalk";

        /// <summary>
        /// An event wrapper for a Stack event.
        /// </summary>
        public readonly ref struct StackEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_Timestamp = 0;
            private const int Offset_ProcessId = 8;
            private const int Offset_ThreadId = 12;
            private const int Offset_Stack = 16;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 33;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Stack";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = StackWalkProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)32, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the Timestamp field.
            /// </summary>
            public ulong Timestamp => BitConverter.ToUInt64(_etwEvent.Data[Offset_Timestamp..Offset_ProcessId]);

            /// <summary>
            /// Retrieves the ProcessId field.
            /// </summary>
            public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..Offset_ThreadId]);

            /// <summary>
            /// Retrieves the ThreadId field.
            /// </summary>
            public uint ThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ThreadId..Offset_Stack]);

            /// <summary>
            /// Retrieves the Stack field.
            /// </summary>
            public EtwEvent.AddressEnumerable Stack => new(_etwEvent.Data[Offset_Stack..], _etwEvent.AddressSize);

            /// <summary>
            /// Creates a new StackEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public StackEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a StackKeyCreate event.
        /// </summary>
        public readonly ref struct StackKeyCreateEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_StackKey = 0;
            private readonly int _offset_StackFrames;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 34;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "StackKeyCreate";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = StackWalkProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)34, Task = 0, Keyword = 0x0000000000000000 };

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
            /// Retrieves the StackKey field.
            /// </summary>
            public ulong StackKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_StackKey.._offset_StackFrames]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_StackKey.._offset_StackFrames]);

            /// <summary>
            /// Retrieves the StackFrames field.
            /// </summary>
            public EtwEvent.AddressEnumerable StackFrames => new(_etwEvent.Data[_offset_StackFrames..], _etwEvent.AddressSize);

            /// <summary>
            /// Creates a new StackKeyCreateEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public StackKeyCreateEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
                _offset_StackFrames = Offset_StackKey + etwEvent.AddressSize;
            }
        }

        /// <summary>
        /// An event wrapper for a StackKeyDelete event.
        /// </summary>
        public readonly ref struct StackKeyDeleteEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_StackKey = 0;
            private readonly int _offset_StackFrames;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 35;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "StackKeyDelete";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = StackWalkProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)35, Task = 0, Keyword = 0x0000000000000000 };

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
            /// Retrieves the StackKey field.
            /// </summary>
            public ulong StackKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_StackKey.._offset_StackFrames]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_StackKey.._offset_StackFrames]);

            /// <summary>
            /// Retrieves the StackFrames field.
            /// </summary>
            public EtwEvent.AddressEnumerable StackFrames => new(_etwEvent.Data[_offset_StackFrames..], _etwEvent.AddressSize);

            /// <summary>
            /// Creates a new StackKeyDeleteEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public StackKeyDeleteEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
                _offset_StackFrames = Offset_StackKey + etwEvent.AddressSize;
            }
        }

        /// <summary>
        /// An event wrapper for a StackKeyRundown event.
        /// </summary>
        public readonly ref struct StackKeyRundownEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_StackKey = 0;
            private readonly int _offset_StackFrames;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 36;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "StackKeyRundown";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = StackWalkProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)36, Task = 0, Keyword = 0x0000000000000000 };

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
            /// Retrieves the StackKey field.
            /// </summary>
            public ulong StackKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_StackKey.._offset_StackFrames]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_StackKey.._offset_StackFrames]);

            /// <summary>
            /// Retrieves the StackFrames field.
            /// </summary>
            public EtwEvent.AddressEnumerable StackFrames => new(_etwEvent.Data[_offset_StackFrames..], _etwEvent.AddressSize);

            /// <summary>
            /// Creates a new StackKeyRundownEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public StackKeyRundownEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
                _offset_StackFrames = Offset_StackKey + etwEvent.AddressSize;
            }
        }

        /// <summary>
        /// An event wrapper for a StackKeyKernel event.
        /// </summary>
        public readonly ref struct StackKeyKernelEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_Timestamp = 0;
            private const int Offset_ProcessId = 8;
            private const int Offset_ThreadId = 12;
            private const int Offset_StackKey = 16;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 37;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "StackKeyKernel";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = StackWalkProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)37, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the Timestamp field.
            /// </summary>
            public ulong Timestamp => BitConverter.ToUInt64(_etwEvent.Data[Offset_Timestamp..Offset_ProcessId]);

            /// <summary>
            /// Retrieves the ProcessId field.
            /// </summary>
            public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..Offset_ThreadId]);

            /// <summary>
            /// Retrieves the ThreadId field.
            /// </summary>
            public uint ThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ThreadId..Offset_StackKey]);

            /// <summary>
            /// Retrieves the StackKey field.
            /// </summary>
            public ulong StackKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_StackKey..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_StackKey..]);

            /// <summary>
            /// Creates a new StackKeyKernelEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public StackKeyKernelEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a StackKeyUser event.
        /// </summary>
        public readonly ref struct StackKeyUserEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_Timestamp = 0;
            private const int Offset_ProcessId = 8;
            private const int Offset_ThreadId = 12;
            private const int Offset_StackKey = 16;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 38;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "StackKeyUser";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = StackWalkProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)38, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the Timestamp field.
            /// </summary>
            public ulong Timestamp => BitConverter.ToUInt64(_etwEvent.Data[Offset_Timestamp..Offset_ProcessId]);

            /// <summary>
            /// Retrieves the ProcessId field.
            /// </summary>
            public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..Offset_ThreadId]);

            /// <summary>
            /// Retrieves the ThreadId field.
            /// </summary>
            public uint ThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ThreadId..Offset_StackKey]);

            /// <summary>
            /// Retrieves the StackKey field.
            /// </summary>
            public ulong StackKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_StackKey..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_StackKey..]);

            /// <summary>
            /// Creates a new StackKeyUserEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public StackKeyUserEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }
    }
}
