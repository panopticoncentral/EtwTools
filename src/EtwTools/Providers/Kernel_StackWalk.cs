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

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 8;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Stack";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = new("def2fe46-7bd6-4b80-bd94-f57fe20d0ce3");

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)32, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Retrieves the Timestamp field.
            /// </summary>
            public ulong Timestamp() => BitConverter.ToUInt64(_etwEvent.Data);

            /// <summary>
            /// Retrieves the ProcessId field.
            /// </summary>
            public uint ProcessId() => BitConverter.ToUInt32(_etwEvent.Data[8..]);

            /// <summary>
            /// Retrieves the ThreadId field.
            /// </summary>
            public uint ThreadId() => BitConverter.ToUInt32(_etwEvent.Data[12..]);

            /// <summary>
            /// Retrieves the Stack field.
            /// </summary>
            public uint GetStack(int index) => BitConverter.ToUInt32(_etwEvent.Data[(16 + (index * sizeof(uint)))..]);

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

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 9;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "StackKeyCreate";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = new("def2fe46-7bd6-4b80-bd94-f57fe20d0ce3");

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
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Retrieves the StackKey field.
            /// </summary>
            public uint StackKey() => BitConverter.ToUInt32(_etwEvent.Data);

            /// <summary>
            /// Retrieves the StackFrames field.
            /// </summary>
            public uint GetStackFrames(int index) => BitConverter.ToUInt32(_etwEvent.Data[(4 + (index * sizeof(uint)))..]);

            /// <summary>
            /// Creates a new StackKeyCreateEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public StackKeyCreateEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a StackKeyDelete event.
        /// </summary>
        public readonly ref struct StackKeyDeleteEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 10;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "StackKeyDelete";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = new("def2fe46-7bd6-4b80-bd94-f57fe20d0ce3");

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
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Retrieves the StackKey field.
            /// </summary>
            public uint StackKey() => BitConverter.ToUInt32(_etwEvent.Data);

            /// <summary>
            /// Retrieves the StackFrames field.
            /// </summary>
            public uint GetStackFrames(int index) => BitConverter.ToUInt32(_etwEvent.Data[(4 + (index * sizeof(uint)))..]);

            /// <summary>
            /// Creates a new StackKeyDeleteEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public StackKeyDeleteEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a StackKeyRundown event.
        /// </summary>
        public readonly ref struct StackKeyRundownEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 11;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "StackKeyRundown";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = new("def2fe46-7bd6-4b80-bd94-f57fe20d0ce3");

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
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Retrieves the StackKey field.
            /// </summary>
            public uint StackKey() => BitConverter.ToUInt32(_etwEvent.Data);

            /// <summary>
            /// Retrieves the StackFrames field.
            /// </summary>
            public uint GetStackFrames(int index) => BitConverter.ToUInt32(_etwEvent.Data[(4 + (index * sizeof(uint)))..]);

            /// <summary>
            /// Creates a new StackKeyRundownEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public StackKeyRundownEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a StackKeyKernel event.
        /// </summary>
        public readonly ref struct StackKeyKernelEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 12;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "StackKeyKernel";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = new("def2fe46-7bd6-4b80-bd94-f57fe20d0ce3");

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)37, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Retrieves the Timestamp field.
            /// </summary>
            public ulong Timestamp() => BitConverter.ToUInt64(_etwEvent.Data);

            /// <summary>
            /// Retrieves the ProcessId field.
            /// </summary>
            public uint ProcessId() => BitConverter.ToUInt32(_etwEvent.Data[8..]);

            /// <summary>
            /// Retrieves the ThreadId field.
            /// </summary>
            public uint ThreadId() => BitConverter.ToUInt32(_etwEvent.Data[12..]);

            /// <summary>
            /// Retrieves the StackKey field.
            /// </summary>
            public uint StackKey() => BitConverter.ToUInt32(_etwEvent.Data[16..]);

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

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 13;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "StackKeyUser";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = new("def2fe46-7bd6-4b80-bd94-f57fe20d0ce3");

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)38, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Retrieves the Timestamp field.
            /// </summary>
            public ulong Timestamp() => BitConverter.ToUInt64(_etwEvent.Data);

            /// <summary>
            /// Retrieves the ProcessId field.
            /// </summary>
            public uint ProcessId() => BitConverter.ToUInt32(_etwEvent.Data[8..]);

            /// <summary>
            /// Retrieves the ThreadId field.
            /// </summary>
            public uint ThreadId() => BitConverter.ToUInt32(_etwEvent.Data[12..]);

            /// <summary>
            /// Retrieves the StackKey field.
            /// </summary>
            public uint StackKey() => BitConverter.ToUInt32(_etwEvent.Data[16..]);

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
