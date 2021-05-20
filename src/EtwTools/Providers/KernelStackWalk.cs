using System;

#pragma warning disable IDE0079 // Remove unnecessary suppression
#pragma warning disable IDE0004 // Remove Unnecessary Cast
#pragma warning disable IDE1006 // Naming Styles
#pragma warning disable CA1416 // Validate platform compatibility
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
        public readonly ref struct StackEventV2
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
            /// Creates a new StackEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public StackEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a StackEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator StackEventV2(EtwEvent etwEvent) => new(etwEvent);

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
        public readonly ref struct StackKeyCreateEventV2
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
            /// Creates a new StackKeyCreateEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public StackKeyCreateEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a StackKeyCreateEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator StackKeyCreateEventV2(EtwEvent etwEvent) => new(etwEvent);

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
                public ulong StackKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_StackKey..Offset_StackFrames]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_StackKey..Offset_StackFrames]);

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
        public readonly ref struct StackKeyDeleteEventV2
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
            /// Creates a new StackKeyDeleteEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public StackKeyDeleteEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a StackKeyDeleteEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator StackKeyDeleteEventV2(EtwEvent etwEvent) => new(etwEvent);

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
                public ulong StackKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_StackKey..Offset_StackFrames]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_StackKey..Offset_StackFrames]);

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
        public readonly ref struct StackKeyRundownEventV2
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
            /// Creates a new StackKeyRundownEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public StackKeyRundownEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a StackKeyRundownEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator StackKeyRundownEventV2(EtwEvent etwEvent) => new(etwEvent);

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
                public ulong StackKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_StackKey..Offset_StackFrames]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_StackKey..Offset_StackFrames]);

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
        public readonly ref struct StackKeyKernelEventV2
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
            /// Creates a new StackKeyKernelEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public StackKeyKernelEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a StackKeyKernelEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator StackKeyKernelEventV2(EtwEvent etwEvent) => new(etwEvent);

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
        public readonly ref struct StackKeyUserEventV2
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
            /// Creates a new StackKeyUserEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public StackKeyUserEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a StackKeyUserEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator StackKeyUserEventV2(EtwEvent etwEvent) => new(etwEvent);

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
