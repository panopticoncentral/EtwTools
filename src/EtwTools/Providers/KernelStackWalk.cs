using System;

#pragma warning disable IDE0004 // Remove Unnecessary Cast
#pragma warning disable CA1707 // Identifiers should not contain underscores
#pragma warning disable CA1720 // Identifier contains type name

namespace EtwTools
{
    /// <summary>
    /// Provider for Kernel-StackWalk (def2fe46-7bd6-4b80-bd94-f57fe20d0ce3)
    /// </summary>
    public sealed class KernelStackWalkProvider
    {
        /// <summary>s
        /// Provider ID.
        /// </summary>
        public static readonly Guid Id = new("def2fe46-7bd6-4b80-bd94-f57fe20d0ce3");

        /// <summary>
        /// Provider name.
        /// </summary>
        public const string Name = "Kernel-StackWalk";

        /// <summary>
        /// Opcodes supported by KernelStackWalk.
        /// </summary>
        public enum Opcodes
        {
            /// <summary>
            /// 'Stack' opcode.
            /// </summary>
            Stack = 32,
            /// <summary>
            /// 'StackKeyCreate' opcode.
            /// </summary>
            StackKeyCreate = 34,
            /// <summary>
            /// 'StackKeyDelete' opcode.
            /// </summary>
            StackKeyDelete = 35,
            /// <summary>
            /// 'StackKeyRundown' opcode.
            /// </summary>
            StackKeyRundown = 36,
            /// <summary>
            /// 'StackKeyKernel' opcode.
            /// </summary>
            StackKeyKernel = 37,
            /// <summary>
            /// 'StackKeyUser' opcode.
            /// </summary>
            StackKeyUser = 38,
        }

        /// <summary>
        /// An event wrapper for a Stack event.
        /// </summary>
        public readonly ref struct StackEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Stack";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 0,
                Version = 2,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.Stack,
                Task = 0,
                Keyword = 0
            };

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
            /// Data for the event.
            /// </summary>
            public StackData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new StackEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public StackEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a Stack event.
            /// </summary>
            public ref struct StackData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Timestamp;
                private int _offset_ProcessId;
                private int _offset_ThreadId;
                private int _offset_Stack;

                private int Offset_Timestamp
                {
                    get
                    {
                        if (_offset_Timestamp == -1)
                        {
                            _offset_Timestamp = 0;
                        }

                        return _offset_Timestamp;
                    }
                }

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = Offset_Timestamp + 8;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_ThreadId
                {
                    get
                    {
                        if (_offset_ThreadId == -1)
                        {
                            _offset_ThreadId = Offset_ProcessId + 4;
                        }

                        return _offset_ThreadId;
                    }
                }

                private int Offset_Stack
                {
                    get
                    {
                        if (_offset_Stack == -1)
                        {
                            _offset_Stack = Offset_ThreadId + 4;
                        }

                        return _offset_Stack;
                    }
                }

                /// <summary>
                /// Retrieves the Timestamp field.
                /// </summary>
                public ulong Timestamp => BitConverter.ToUInt64(_etwEvent.Data[Offset_Timestamp..]);

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..]);

                /// <summary>
                /// Retrieves the ThreadId field.
                /// </summary>
                public uint ThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ThreadId..]);

                /// <summary>
                /// Retrieves the Stack field.
                /// </summary>
                public EtwEvent.AddressEnumerable Stack => new(_etwEvent, Offset_Stack);

                /// <summary>
                /// Creates a new StackData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public StackData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Timestamp = -1;
                    _offset_ProcessId = -1;
                    _offset_ThreadId = -1;
                    _offset_Stack = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a StackKeyCreate event.
        /// </summary>
        public readonly ref struct StackKeyCreateEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "StackKeyCreate";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 0,
                Version = 2,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.StackKeyCreate,
                Task = 0,
                Keyword = 0
            };

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
            /// Data for the event.
            /// </summary>
            public StackKeyCreateData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new StackKeyCreateEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public StackKeyCreateEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a StackKeyCreate event.
            /// </summary>
            public ref struct StackKeyCreateData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_StackKey;
                private int _offset_StackFrames;

                private int Offset_StackKey
                {
                    get
                    {
                        if (_offset_StackKey == -1)
                        {
                            _offset_StackKey = 0;
                        }

                        return _offset_StackKey;
                    }
                }

                private int Offset_StackFrames
                {
                    get
                    {
                        if (_offset_StackFrames == -1)
                        {
                            _offset_StackFrames = Offset_StackKey + _etwEvent.AddressSize;
                        }

                        return _offset_StackFrames;
                    }
                }

                /// <summary>
                /// Retrieves the StackKey field.
                /// </summary>
                public ulong StackKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_StackKey..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_StackKey..]);

                /// <summary>
                /// Retrieves the StackFrames field.
                /// </summary>
                public EtwEvent.AddressEnumerable StackFrames => new(_etwEvent, Offset_StackFrames);

                /// <summary>
                /// Creates a new StackKeyCreateData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public StackKeyCreateData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_StackKey = -1;
                    _offset_StackFrames = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a StackKeyDelete event.
        /// </summary>
        public readonly ref struct StackKeyDeleteEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "StackKeyDelete";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 0,
                Version = 2,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.StackKeyDelete,
                Task = 0,
                Keyword = 0
            };

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
            /// Data for the event.
            /// </summary>
            public StackKeyDeleteData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new StackKeyDeleteEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public StackKeyDeleteEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a StackKeyDelete event.
            /// </summary>
            public ref struct StackKeyDeleteData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_StackKey;
                private int _offset_StackFrames;

                private int Offset_StackKey
                {
                    get
                    {
                        if (_offset_StackKey == -1)
                        {
                            _offset_StackKey = 0;
                        }

                        return _offset_StackKey;
                    }
                }

                private int Offset_StackFrames
                {
                    get
                    {
                        if (_offset_StackFrames == -1)
                        {
                            _offset_StackFrames = Offset_StackKey + _etwEvent.AddressSize;
                        }

                        return _offset_StackFrames;
                    }
                }

                /// <summary>
                /// Retrieves the StackKey field.
                /// </summary>
                public ulong StackKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_StackKey..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_StackKey..]);

                /// <summary>
                /// Retrieves the StackFrames field.
                /// </summary>
                public EtwEvent.AddressEnumerable StackFrames => new(_etwEvent, Offset_StackFrames);

                /// <summary>
                /// Creates a new StackKeyDeleteData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public StackKeyDeleteData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_StackKey = -1;
                    _offset_StackFrames = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a StackKeyRundown event.
        /// </summary>
        public readonly ref struct StackKeyRundownEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "StackKeyRundown";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 0,
                Version = 2,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.StackKeyRundown,
                Task = 0,
                Keyword = 0
            };

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
            /// Data for the event.
            /// </summary>
            public StackKeyRundownData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new StackKeyRundownEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public StackKeyRundownEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a StackKeyRundown event.
            /// </summary>
            public ref struct StackKeyRundownData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_StackKey;
                private int _offset_StackFrames;

                private int Offset_StackKey
                {
                    get
                    {
                        if (_offset_StackKey == -1)
                        {
                            _offset_StackKey = 0;
                        }

                        return _offset_StackKey;
                    }
                }

                private int Offset_StackFrames
                {
                    get
                    {
                        if (_offset_StackFrames == -1)
                        {
                            _offset_StackFrames = Offset_StackKey + _etwEvent.AddressSize;
                        }

                        return _offset_StackFrames;
                    }
                }

                /// <summary>
                /// Retrieves the StackKey field.
                /// </summary>
                public ulong StackKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_StackKey..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_StackKey..]);

                /// <summary>
                /// Retrieves the StackFrames field.
                /// </summary>
                public EtwEvent.AddressEnumerable StackFrames => new(_etwEvent, Offset_StackFrames);

                /// <summary>
                /// Creates a new StackKeyRundownData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public StackKeyRundownData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_StackKey = -1;
                    _offset_StackFrames = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a StackKeyKernel event.
        /// </summary>
        public readonly ref struct StackKeyKernelEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "StackKeyKernel";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 0,
                Version = 2,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.StackKeyKernel,
                Task = 0,
                Keyword = 0
            };

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
            /// Data for the event.
            /// </summary>
            public StackKeyKernelData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new StackKeyKernelEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public StackKeyKernelEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a StackKeyKernel event.
            /// </summary>
            public ref struct StackKeyKernelData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Timestamp;
                private int _offset_ProcessId;
                private int _offset_ThreadId;
                private int _offset_StackKey;

                private int Offset_Timestamp
                {
                    get
                    {
                        if (_offset_Timestamp == -1)
                        {
                            _offset_Timestamp = 0;
                        }

                        return _offset_Timestamp;
                    }
                }

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = Offset_Timestamp + 8;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_ThreadId
                {
                    get
                    {
                        if (_offset_ThreadId == -1)
                        {
                            _offset_ThreadId = Offset_ProcessId + 4;
                        }

                        return _offset_ThreadId;
                    }
                }

                private int Offset_StackKey
                {
                    get
                    {
                        if (_offset_StackKey == -1)
                        {
                            _offset_StackKey = Offset_ThreadId + 4;
                        }

                        return _offset_StackKey;
                    }
                }

                /// <summary>
                /// Retrieves the Timestamp field.
                /// </summary>
                public ulong Timestamp => BitConverter.ToUInt64(_etwEvent.Data[Offset_Timestamp..]);

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..]);

                /// <summary>
                /// Retrieves the ThreadId field.
                /// </summary>
                public uint ThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ThreadId..]);

                /// <summary>
                /// Retrieves the StackKey field.
                /// </summary>
                public ulong StackKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_StackKey..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_StackKey..]);

                /// <summary>
                /// Creates a new StackKeyKernelData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public StackKeyKernelData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Timestamp = -1;
                    _offset_ProcessId = -1;
                    _offset_ThreadId = -1;
                    _offset_StackKey = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a StackKeyUser event.
        /// </summary>
        public readonly ref struct StackKeyUserEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "StackKeyUser";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 0,
                Version = 2,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.StackKeyUser,
                Task = 0,
                Keyword = 0
            };

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
            /// Data for the event.
            /// </summary>
            public StackKeyUserData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new StackKeyUserEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public StackKeyUserEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a StackKeyUser event.
            /// </summary>
            public ref struct StackKeyUserData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Timestamp;
                private int _offset_ProcessId;
                private int _offset_ThreadId;
                private int _offset_StackKey;

                private int Offset_Timestamp
                {
                    get
                    {
                        if (_offset_Timestamp == -1)
                        {
                            _offset_Timestamp = 0;
                        }

                        return _offset_Timestamp;
                    }
                }

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = Offset_Timestamp + 8;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_ThreadId
                {
                    get
                    {
                        if (_offset_ThreadId == -1)
                        {
                            _offset_ThreadId = Offset_ProcessId + 4;
                        }

                        return _offset_ThreadId;
                    }
                }

                private int Offset_StackKey
                {
                    get
                    {
                        if (_offset_StackKey == -1)
                        {
                            _offset_StackKey = Offset_ThreadId + 4;
                        }

                        return _offset_StackKey;
                    }
                }

                /// <summary>
                /// Retrieves the Timestamp field.
                /// </summary>
                public ulong Timestamp => BitConverter.ToUInt64(_etwEvent.Data[Offset_Timestamp..]);

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..]);

                /// <summary>
                /// Retrieves the ThreadId field.
                /// </summary>
                public uint ThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ThreadId..]);

                /// <summary>
                /// Retrieves the StackKey field.
                /// </summary>
                public ulong StackKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_StackKey..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_StackKey..]);

                /// <summary>
                /// Creates a new StackKeyUserData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public StackKeyUserData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Timestamp = -1;
                    _offset_ProcessId = -1;
                    _offset_ThreadId = -1;
                    _offset_StackKey = -1;
                }
            }

        }
    }
}
