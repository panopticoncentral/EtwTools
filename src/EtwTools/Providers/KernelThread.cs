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
    /// Provider for Kernel-Thread (3d6fa8d1-fe05-11d0-9dda-00c04fd7ba7c)
    /// </summary>
    public sealed class KernelThreadProvider
    {
        /// <summary>s
        /// Provider ID.
        /// </summary>
        public static readonly Guid Id = new("3d6fa8d1-fe05-11d0-9dda-00c04fd7ba7c");

        /// <summary>
        /// Provider name.
        /// </summary>
        public const string Name = "Kernel-Thread";

        /// <summary>
        /// Opcodes supported by KernelThread.
        /// </summary>
        public enum Opcodes
        {
            /// <summary>
            /// 'CSwitch' opcode.
            /// </summary>
            CSwitch = 36,
            /// <summary>
            /// 'CompCS' opcode.
            /// </summary>
            CompCS = 37,
            /// <summary>
            /// 'SpinLock' opcode.
            /// </summary>
            SpinLock = 41,
            /// <summary>
            /// 'SetPriority' opcode.
            /// </summary>
            SetPriority = 48,
            /// <summary>
            /// 'SetBasePriority' opcode.
            /// </summary>
            SetBasePriority = 49,
            /// <summary>
            /// 'ReadyThread' opcode.
            /// </summary>
            ReadyThread = 50,
            /// <summary>
            /// 'SetPagePriority' opcode.
            /// </summary>
            SetPagePriority = 51,
            /// <summary>
            /// 'SetIoPriority' opcode.
            /// </summary>
            SetIoPriority = 52,
            /// <summary>
            /// 'ThreadAffinity' opcode.
            /// </summary>
            ThreadAffinity = 53,
            /// <summary>
            /// 'WorkerThread' opcode.
            /// </summary>
            WorkerThread = 57,
            /// <summary>
            /// 'AntiStarvationBoost' opcode.
            /// </summary>
            AntiStarvationBoost = 60,
            /// <summary>
            /// 'ThreadMigration' opcode.
            /// </summary>
            ThreadMigration = 61,
            /// <summary>
            /// 'KernelQueueEnqueue' opcode.
            /// </summary>
            KernelQueueEnqueue = 62,
            /// <summary>
            /// 'KernelQueueDequeue' opcode.
            /// </summary>
            KernelQueueDequeue = 63,
            /// <summary>
            /// 'WorkerThreadStart' opcode.
            /// </summary>
            WorkerThreadStart = 64,
            /// <summary>
            /// 'WorkerThreadEnd' opcode.
            /// </summary>
            WorkerThreadEnd = 65,
            /// <summary>
            /// 'AutoBoostSetFloor' opcode.
            /// </summary>
            AutoBoostSetFloor = 66,
            /// <summary>
            /// 'AutoBoostClearFloor' opcode.
            /// </summary>
            AutoBoostClearFloor = 67,
            /// <summary>
            /// 'AutoBoostEntryExhaustion' opcode.
            /// </summary>
            AutoBoostEntryExhaustion = 68,
            /// <summary>
            /// 'SubProcessTagChanged' opcode.
            /// </summary>
            SubProcessTagChanged = 69,
            /// <summary>
            /// 'SetName' opcode.
            /// </summary>
            SetName = 72,
        }

        /// <summary>
        /// An event wrapper for a Start event.
        /// </summary>
        public readonly ref struct StartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Start";

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
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = EtwEventOpcode.Start,
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
            public StartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new StartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public StartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a Start event.
            /// </summary>
            public ref struct StartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_TThreadId;
                private int _offset_ProcessId;

                private int Offset_TThreadId
                {
                    get
                    {
                        if (_offset_TThreadId == -1)
                        {
                            _offset_TThreadId = 0;
                        }

                        return _offset_TThreadId;
                    }
                }

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = Offset_TThreadId + 4;
                        }

                        return _offset_ProcessId;
                    }
                }

                /// <summary>
                /// Retrieves the TThreadId field.
                /// </summary>
                public uint TThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_TThreadId..]);

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..]);

                /// <summary>
                /// Creates a new StartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public StartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_TThreadId = -1;
                    _offset_ProcessId = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a End event.
        /// </summary>
        public readonly ref struct EndEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "End";

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
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = EtwEventOpcode.End,
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
            public EndData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new EndEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public EndEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a End event.
            /// </summary>
            public ref struct EndData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_TThreadId;
                private int _offset_ProcessId;

                private int Offset_TThreadId
                {
                    get
                    {
                        if (_offset_TThreadId == -1)
                        {
                            _offset_TThreadId = 0;
                        }

                        return _offset_TThreadId;
                    }
                }

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = Offset_TThreadId + 4;
                        }

                        return _offset_ProcessId;
                    }
                }

                /// <summary>
                /// Retrieves the TThreadId field.
                /// </summary>
                public uint TThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_TThreadId..]);

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..]);

                /// <summary>
                /// Creates a new EndData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public EndData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_TThreadId = -1;
                    _offset_ProcessId = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DCStart event.
        /// </summary>
        public readonly ref struct DCStartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DCStart";

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
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = EtwEventOpcode.DataCollectionStart,
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
            public DCStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DCStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DCStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a DCStart event.
            /// </summary>
            public ref struct DCStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_TThreadId;
                private int _offset_ProcessId;

                private int Offset_TThreadId
                {
                    get
                    {
                        if (_offset_TThreadId == -1)
                        {
                            _offset_TThreadId = 0;
                        }

                        return _offset_TThreadId;
                    }
                }

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = Offset_TThreadId + 4;
                        }

                        return _offset_ProcessId;
                    }
                }

                /// <summary>
                /// Retrieves the TThreadId field.
                /// </summary>
                public uint TThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_TThreadId..]);

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..]);

                /// <summary>
                /// Creates a new DCStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DCStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_TThreadId = -1;
                    _offset_ProcessId = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DCEnd event.
        /// </summary>
        public readonly ref struct DCEndEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DCEnd";

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
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = EtwEventOpcode.DataCollectionEnd,
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
            public DCEndData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DCEndEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DCEndEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a DCEnd event.
            /// </summary>
            public ref struct DCEndData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_TThreadId;
                private int _offset_ProcessId;

                private int Offset_TThreadId
                {
                    get
                    {
                        if (_offset_TThreadId == -1)
                        {
                            _offset_TThreadId = 0;
                        }

                        return _offset_TThreadId;
                    }
                }

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = Offset_TThreadId + 4;
                        }

                        return _offset_ProcessId;
                    }
                }

                /// <summary>
                /// Retrieves the TThreadId field.
                /// </summary>
                public uint TThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_TThreadId..]);

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..]);

                /// <summary>
                /// Creates a new DCEndData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DCEndData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_TThreadId = -1;
                    _offset_ProcessId = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Start event.
        /// </summary>
        public readonly ref struct StartEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Start";

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
                Version = 1,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = EtwEventOpcode.Start,
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
            public StartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new StartEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public StartEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a Start event.
            /// </summary>
            public ref struct StartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProcessId;
                private int _offset_TThreadId;
                private int _offset_StackBase;
                private int _offset_StackLimit;
                private int _offset_UserStackBase;
                private int _offset_UserStackLimit;
                private int _offset_StartAddr;
                private int _offset_Win32StartAddr;
                private int _offset_WaitMode;

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = 0;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_TThreadId
                {
                    get
                    {
                        if (_offset_TThreadId == -1)
                        {
                            _offset_TThreadId = Offset_ProcessId + 4;
                        }

                        return _offset_TThreadId;
                    }
                }

                private int Offset_StackBase
                {
                    get
                    {
                        if (_offset_StackBase == -1)
                        {
                            _offset_StackBase = Offset_TThreadId + 4;
                        }

                        return _offset_StackBase;
                    }
                }

                private int Offset_StackLimit
                {
                    get
                    {
                        if (_offset_StackLimit == -1)
                        {
                            _offset_StackLimit = Offset_StackBase + _etwEvent.AddressSize;
                        }

                        return _offset_StackLimit;
                    }
                }

                private int Offset_UserStackBase
                {
                    get
                    {
                        if (_offset_UserStackBase == -1)
                        {
                            _offset_UserStackBase = Offset_StackLimit + _etwEvent.AddressSize;
                        }

                        return _offset_UserStackBase;
                    }
                }

                private int Offset_UserStackLimit
                {
                    get
                    {
                        if (_offset_UserStackLimit == -1)
                        {
                            _offset_UserStackLimit = Offset_UserStackBase + _etwEvent.AddressSize;
                        }

                        return _offset_UserStackLimit;
                    }
                }

                private int Offset_StartAddr
                {
                    get
                    {
                        if (_offset_StartAddr == -1)
                        {
                            _offset_StartAddr = Offset_UserStackLimit + _etwEvent.AddressSize;
                        }

                        return _offset_StartAddr;
                    }
                }

                private int Offset_Win32StartAddr
                {
                    get
                    {
                        if (_offset_Win32StartAddr == -1)
                        {
                            _offset_Win32StartAddr = Offset_StartAddr + _etwEvent.AddressSize;
                        }

                        return _offset_Win32StartAddr;
                    }
                }

                private int Offset_WaitMode
                {
                    get
                    {
                        if (_offset_WaitMode == -1)
                        {
                            _offset_WaitMode = Offset_Win32StartAddr + _etwEvent.AddressSize;
                        }

                        return _offset_WaitMode;
                    }
                }

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..]);

                /// <summary>
                /// Retrieves the TThreadId field.
                /// </summary>
                public uint TThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_TThreadId..]);

                /// <summary>
                /// Retrieves the StackBase field.
                /// </summary>
                public ulong StackBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_StackBase..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_StackBase..]);

                /// <summary>
                /// Retrieves the StackLimit field.
                /// </summary>
                public ulong StackLimit => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_StackLimit..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_StackLimit..]);

                /// <summary>
                /// Retrieves the UserStackBase field.
                /// </summary>
                public ulong UserStackBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_UserStackBase..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_UserStackBase..]);

                /// <summary>
                /// Retrieves the UserStackLimit field.
                /// </summary>
                public ulong UserStackLimit => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_UserStackLimit..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_UserStackLimit..]);

                /// <summary>
                /// Retrieves the StartAddr field.
                /// </summary>
                public ulong StartAddr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_StartAddr..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_StartAddr..]);

                /// <summary>
                /// Retrieves the Win32StartAddr field.
                /// </summary>
                public ulong Win32StartAddr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Win32StartAddr..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Win32StartAddr..]);

                /// <summary>
                /// Retrieves the WaitMode field.
                /// </summary>
                public sbyte WaitMode => (sbyte)_etwEvent.Data[Offset_WaitMode];

                /// <summary>
                /// Creates a new StartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public StartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProcessId = -1;
                    _offset_TThreadId = -1;
                    _offset_StackBase = -1;
                    _offset_StackLimit = -1;
                    _offset_UserStackBase = -1;
                    _offset_UserStackLimit = -1;
                    _offset_StartAddr = -1;
                    _offset_Win32StartAddr = -1;
                    _offset_WaitMode = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DCStart event.
        /// </summary>
        public readonly ref struct DCStartEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DCStart";

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
                Version = 1,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = EtwEventOpcode.DataCollectionStart,
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
            public DCStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DCStartEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DCStartEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a DCStart event.
            /// </summary>
            public ref struct DCStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProcessId;
                private int _offset_TThreadId;
                private int _offset_StackBase;
                private int _offset_StackLimit;
                private int _offset_UserStackBase;
                private int _offset_UserStackLimit;
                private int _offset_StartAddr;
                private int _offset_Win32StartAddr;
                private int _offset_WaitMode;

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = 0;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_TThreadId
                {
                    get
                    {
                        if (_offset_TThreadId == -1)
                        {
                            _offset_TThreadId = Offset_ProcessId + 4;
                        }

                        return _offset_TThreadId;
                    }
                }

                private int Offset_StackBase
                {
                    get
                    {
                        if (_offset_StackBase == -1)
                        {
                            _offset_StackBase = Offset_TThreadId + 4;
                        }

                        return _offset_StackBase;
                    }
                }

                private int Offset_StackLimit
                {
                    get
                    {
                        if (_offset_StackLimit == -1)
                        {
                            _offset_StackLimit = Offset_StackBase + _etwEvent.AddressSize;
                        }

                        return _offset_StackLimit;
                    }
                }

                private int Offset_UserStackBase
                {
                    get
                    {
                        if (_offset_UserStackBase == -1)
                        {
                            _offset_UserStackBase = Offset_StackLimit + _etwEvent.AddressSize;
                        }

                        return _offset_UserStackBase;
                    }
                }

                private int Offset_UserStackLimit
                {
                    get
                    {
                        if (_offset_UserStackLimit == -1)
                        {
                            _offset_UserStackLimit = Offset_UserStackBase + _etwEvent.AddressSize;
                        }

                        return _offset_UserStackLimit;
                    }
                }

                private int Offset_StartAddr
                {
                    get
                    {
                        if (_offset_StartAddr == -1)
                        {
                            _offset_StartAddr = Offset_UserStackLimit + _etwEvent.AddressSize;
                        }

                        return _offset_StartAddr;
                    }
                }

                private int Offset_Win32StartAddr
                {
                    get
                    {
                        if (_offset_Win32StartAddr == -1)
                        {
                            _offset_Win32StartAddr = Offset_StartAddr + _etwEvent.AddressSize;
                        }

                        return _offset_Win32StartAddr;
                    }
                }

                private int Offset_WaitMode
                {
                    get
                    {
                        if (_offset_WaitMode == -1)
                        {
                            _offset_WaitMode = Offset_Win32StartAddr + _etwEvent.AddressSize;
                        }

                        return _offset_WaitMode;
                    }
                }

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..]);

                /// <summary>
                /// Retrieves the TThreadId field.
                /// </summary>
                public uint TThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_TThreadId..]);

                /// <summary>
                /// Retrieves the StackBase field.
                /// </summary>
                public ulong StackBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_StackBase..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_StackBase..]);

                /// <summary>
                /// Retrieves the StackLimit field.
                /// </summary>
                public ulong StackLimit => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_StackLimit..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_StackLimit..]);

                /// <summary>
                /// Retrieves the UserStackBase field.
                /// </summary>
                public ulong UserStackBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_UserStackBase..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_UserStackBase..]);

                /// <summary>
                /// Retrieves the UserStackLimit field.
                /// </summary>
                public ulong UserStackLimit => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_UserStackLimit..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_UserStackLimit..]);

                /// <summary>
                /// Retrieves the StartAddr field.
                /// </summary>
                public ulong StartAddr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_StartAddr..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_StartAddr..]);

                /// <summary>
                /// Retrieves the Win32StartAddr field.
                /// </summary>
                public ulong Win32StartAddr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Win32StartAddr..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Win32StartAddr..]);

                /// <summary>
                /// Retrieves the WaitMode field.
                /// </summary>
                public sbyte WaitMode => (sbyte)_etwEvent.Data[Offset_WaitMode];

                /// <summary>
                /// Creates a new DCStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DCStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProcessId = -1;
                    _offset_TThreadId = -1;
                    _offset_StackBase = -1;
                    _offset_StackLimit = -1;
                    _offset_UserStackBase = -1;
                    _offset_UserStackLimit = -1;
                    _offset_StartAddr = -1;
                    _offset_Win32StartAddr = -1;
                    _offset_WaitMode = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DCEnd event.
        /// </summary>
        public readonly ref struct DCEndEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DCEnd";

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
                Version = 1,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = EtwEventOpcode.DataCollectionEnd,
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
            public DCEndData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DCEndEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DCEndEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a DCEnd event.
            /// </summary>
            public ref struct DCEndData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProcessId;
                private int _offset_TThreadId;
                private int _offset_StackBase;
                private int _offset_StackLimit;
                private int _offset_UserStackBase;
                private int _offset_UserStackLimit;
                private int _offset_StartAddr;
                private int _offset_Win32StartAddr;
                private int _offset_WaitMode;

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = 0;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_TThreadId
                {
                    get
                    {
                        if (_offset_TThreadId == -1)
                        {
                            _offset_TThreadId = Offset_ProcessId + 4;
                        }

                        return _offset_TThreadId;
                    }
                }

                private int Offset_StackBase
                {
                    get
                    {
                        if (_offset_StackBase == -1)
                        {
                            _offset_StackBase = Offset_TThreadId + 4;
                        }

                        return _offset_StackBase;
                    }
                }

                private int Offset_StackLimit
                {
                    get
                    {
                        if (_offset_StackLimit == -1)
                        {
                            _offset_StackLimit = Offset_StackBase + _etwEvent.AddressSize;
                        }

                        return _offset_StackLimit;
                    }
                }

                private int Offset_UserStackBase
                {
                    get
                    {
                        if (_offset_UserStackBase == -1)
                        {
                            _offset_UserStackBase = Offset_StackLimit + _etwEvent.AddressSize;
                        }

                        return _offset_UserStackBase;
                    }
                }

                private int Offset_UserStackLimit
                {
                    get
                    {
                        if (_offset_UserStackLimit == -1)
                        {
                            _offset_UserStackLimit = Offset_UserStackBase + _etwEvent.AddressSize;
                        }

                        return _offset_UserStackLimit;
                    }
                }

                private int Offset_StartAddr
                {
                    get
                    {
                        if (_offset_StartAddr == -1)
                        {
                            _offset_StartAddr = Offset_UserStackLimit + _etwEvent.AddressSize;
                        }

                        return _offset_StartAddr;
                    }
                }

                private int Offset_Win32StartAddr
                {
                    get
                    {
                        if (_offset_Win32StartAddr == -1)
                        {
                            _offset_Win32StartAddr = Offset_StartAddr + _etwEvent.AddressSize;
                        }

                        return _offset_Win32StartAddr;
                    }
                }

                private int Offset_WaitMode
                {
                    get
                    {
                        if (_offset_WaitMode == -1)
                        {
                            _offset_WaitMode = Offset_Win32StartAddr + _etwEvent.AddressSize;
                        }

                        return _offset_WaitMode;
                    }
                }

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..]);

                /// <summary>
                /// Retrieves the TThreadId field.
                /// </summary>
                public uint TThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_TThreadId..]);

                /// <summary>
                /// Retrieves the StackBase field.
                /// </summary>
                public ulong StackBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_StackBase..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_StackBase..]);

                /// <summary>
                /// Retrieves the StackLimit field.
                /// </summary>
                public ulong StackLimit => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_StackLimit..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_StackLimit..]);

                /// <summary>
                /// Retrieves the UserStackBase field.
                /// </summary>
                public ulong UserStackBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_UserStackBase..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_UserStackBase..]);

                /// <summary>
                /// Retrieves the UserStackLimit field.
                /// </summary>
                public ulong UserStackLimit => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_UserStackLimit..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_UserStackLimit..]);

                /// <summary>
                /// Retrieves the StartAddr field.
                /// </summary>
                public ulong StartAddr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_StartAddr..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_StartAddr..]);

                /// <summary>
                /// Retrieves the Win32StartAddr field.
                /// </summary>
                public ulong Win32StartAddr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Win32StartAddr..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Win32StartAddr..]);

                /// <summary>
                /// Retrieves the WaitMode field.
                /// </summary>
                public sbyte WaitMode => (sbyte)_etwEvent.Data[Offset_WaitMode];

                /// <summary>
                /// Creates a new DCEndData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DCEndData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProcessId = -1;
                    _offset_TThreadId = -1;
                    _offset_StackBase = -1;
                    _offset_StackLimit = -1;
                    _offset_UserStackBase = -1;
                    _offset_UserStackLimit = -1;
                    _offset_StartAddr = -1;
                    _offset_Win32StartAddr = -1;
                    _offset_WaitMode = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a End event.
        /// </summary>
        public readonly ref struct EndEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "End";

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
                Version = 1,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = EtwEventOpcode.End,
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
            public EndData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new EndEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public EndEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a End event.
            /// </summary>
            public ref struct EndData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProcessId;
                private int _offset_TThreadId;

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = 0;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_TThreadId
                {
                    get
                    {
                        if (_offset_TThreadId == -1)
                        {
                            _offset_TThreadId = Offset_ProcessId + 4;
                        }

                        return _offset_TThreadId;
                    }
                }

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..]);

                /// <summary>
                /// Retrieves the TThreadId field.
                /// </summary>
                public uint TThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_TThreadId..]);

                /// <summary>
                /// Creates a new EndData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public EndData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProcessId = -1;
                    _offset_TThreadId = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a CSwitch event.
        /// </summary>
        public readonly ref struct CSwitchEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "CSwitch";

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
                Version = 1,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.CSwitch,
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
            public CSwitchData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new CSwitchEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public CSwitchEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a CSwitch event.
            /// </summary>
            public ref struct CSwitchData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_NewThreadId;
                private int _offset_OldThreadId;
                private int _offset_NewThreadPriority;
                private int _offset_OldThreadPriority;
                private int _offset_NewThreadQuantum;
                private int _offset_OldThreadQuantum;
                private int _offset_OldThreadWaitReason;
                private int _offset_OldThreadWaitMode;
                private int _offset_OldThreadState;
                private int _offset_OldThreadWaitIdealProcessor;

                private int Offset_NewThreadId
                {
                    get
                    {
                        if (_offset_NewThreadId == -1)
                        {
                            _offset_NewThreadId = 0;
                        }

                        return _offset_NewThreadId;
                    }
                }

                private int Offset_OldThreadId
                {
                    get
                    {
                        if (_offset_OldThreadId == -1)
                        {
                            _offset_OldThreadId = Offset_NewThreadId + 4;
                        }

                        return _offset_OldThreadId;
                    }
                }

                private int Offset_NewThreadPriority
                {
                    get
                    {
                        if (_offset_NewThreadPriority == -1)
                        {
                            _offset_NewThreadPriority = Offset_OldThreadId + 4;
                        }

                        return _offset_NewThreadPriority;
                    }
                }

                private int Offset_OldThreadPriority
                {
                    get
                    {
                        if (_offset_OldThreadPriority == -1)
                        {
                            _offset_OldThreadPriority = Offset_NewThreadPriority + 1;
                        }

                        return _offset_OldThreadPriority;
                    }
                }

                private int Offset_NewThreadQuantum
                {
                    get
                    {
                        if (_offset_NewThreadQuantum == -1)
                        {
                            _offset_NewThreadQuantum = Offset_OldThreadPriority + 1;
                        }

                        return _offset_NewThreadQuantum;
                    }
                }

                private int Offset_OldThreadQuantum
                {
                    get
                    {
                        if (_offset_OldThreadQuantum == -1)
                        {
                            _offset_OldThreadQuantum = Offset_NewThreadQuantum + 1;
                        }

                        return _offset_OldThreadQuantum;
                    }
                }

                private int Offset_OldThreadWaitReason
                {
                    get
                    {
                        if (_offset_OldThreadWaitReason == -1)
                        {
                            _offset_OldThreadWaitReason = Offset_OldThreadQuantum + 1;
                        }

                        return _offset_OldThreadWaitReason;
                    }
                }

                private int Offset_OldThreadWaitMode
                {
                    get
                    {
                        if (_offset_OldThreadWaitMode == -1)
                        {
                            _offset_OldThreadWaitMode = Offset_OldThreadWaitReason + 1;
                        }

                        return _offset_OldThreadWaitMode;
                    }
                }

                private int Offset_OldThreadState
                {
                    get
                    {
                        if (_offset_OldThreadState == -1)
                        {
                            _offset_OldThreadState = Offset_OldThreadWaitMode + 1;
                        }

                        return _offset_OldThreadState;
                    }
                }

                private int Offset_OldThreadWaitIdealProcessor
                {
                    get
                    {
                        if (_offset_OldThreadWaitIdealProcessor == -1)
                        {
                            _offset_OldThreadWaitIdealProcessor = Offset_OldThreadState + 1;
                        }

                        return _offset_OldThreadWaitIdealProcessor;
                    }
                }

                /// <summary>
                /// Retrieves the NewThreadId field.
                /// </summary>
                public uint NewThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_NewThreadId..]);

                /// <summary>
                /// Retrieves the OldThreadId field.
                /// </summary>
                public uint OldThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_OldThreadId..]);

                /// <summary>
                /// Retrieves the NewThreadPriority field.
                /// </summary>
                public sbyte NewThreadPriority => (sbyte)_etwEvent.Data[Offset_NewThreadPriority];

                /// <summary>
                /// Retrieves the OldThreadPriority field.
                /// </summary>
                public sbyte OldThreadPriority => (sbyte)_etwEvent.Data[Offset_OldThreadPriority];

                /// <summary>
                /// Retrieves the NewThreadQuantum field.
                /// </summary>
                public sbyte NewThreadQuantum => (sbyte)_etwEvent.Data[Offset_NewThreadQuantum];

                /// <summary>
                /// Retrieves the OldThreadQuantum field.
                /// </summary>
                public sbyte OldThreadQuantum => (sbyte)_etwEvent.Data[Offset_OldThreadQuantum];

                /// <summary>
                /// Retrieves the OldThreadWaitReason field.
                /// </summary>
                public sbyte OldThreadWaitReason => (sbyte)_etwEvent.Data[Offset_OldThreadWaitReason];

                /// <summary>
                /// Retrieves the OldThreadWaitMode field.
                /// </summary>
                public sbyte OldThreadWaitMode => (sbyte)_etwEvent.Data[Offset_OldThreadWaitMode];

                /// <summary>
                /// Retrieves the OldThreadState field.
                /// </summary>
                public sbyte OldThreadState => (sbyte)_etwEvent.Data[Offset_OldThreadState];

                /// <summary>
                /// Retrieves the OldThreadWaitIdealProcessor field.
                /// </summary>
                public sbyte OldThreadWaitIdealProcessor => (sbyte)_etwEvent.Data[Offset_OldThreadWaitIdealProcessor];

                /// <summary>
                /// Creates a new CSwitchData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public CSwitchData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_NewThreadId = -1;
                    _offset_OldThreadId = -1;
                    _offset_NewThreadPriority = -1;
                    _offset_OldThreadPriority = -1;
                    _offset_NewThreadQuantum = -1;
                    _offset_OldThreadQuantum = -1;
                    _offset_OldThreadWaitReason = -1;
                    _offset_OldThreadWaitMode = -1;
                    _offset_OldThreadState = -1;
                    _offset_OldThreadWaitIdealProcessor = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a WorkerThread event.
        /// </summary>
        public readonly ref struct WorkerThreadEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "WorkerThread";

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
                Version = 1,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.WorkerThread,
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
            public WorkerThreadData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new WorkerThreadEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public WorkerThreadEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a WorkerThread event.
            /// </summary>
            public ref struct WorkerThreadData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_TThreadId;
                private int _offset_StartTime;
                private int _offset_ThreadRoutine;

                private int Offset_TThreadId
                {
                    get
                    {
                        if (_offset_TThreadId == -1)
                        {
                            _offset_TThreadId = 0;
                        }

                        return _offset_TThreadId;
                    }
                }

                private int Offset_StartTime
                {
                    get
                    {
                        if (_offset_StartTime == -1)
                        {
                            _offset_StartTime = Offset_TThreadId + 4;
                        }

                        return _offset_StartTime;
                    }
                }

                private int Offset_ThreadRoutine
                {
                    get
                    {
                        if (_offset_ThreadRoutine == -1)
                        {
                            _offset_ThreadRoutine = Offset_StartTime + 8;
                        }

                        return _offset_ThreadRoutine;
                    }
                }

                /// <summary>
                /// Retrieves the TThreadId field.
                /// </summary>
                public uint TThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_TThreadId..]);

                /// <summary>
                /// Retrieves the StartTime field.
                /// </summary>
                public ulong StartTime => BitConverter.ToUInt64(_etwEvent.Data[Offset_StartTime..]);

                /// <summary>
                /// Retrieves the ThreadRoutine field.
                /// </summary>
                public ulong ThreadRoutine => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ThreadRoutine..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ThreadRoutine..]);

                /// <summary>
                /// Creates a new WorkerThreadData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public WorkerThreadData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_TThreadId = -1;
                    _offset_StartTime = -1;
                    _offset_ThreadRoutine = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Start event.
        /// </summary>
        public readonly ref struct StartEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Start";

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
                Opcode = EtwEventOpcode.Start,
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
            public StartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new StartEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public StartEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a Start event.
            /// </summary>
            public ref struct StartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProcessId;
                private int _offset_TThreadId;
                private int _offset_StackBase;
                private int _offset_StackLimit;
                private int _offset_UserStackBase;
                private int _offset_UserStackLimit;
                private int _offset_StartAddr;
                private int _offset_Win32StartAddr;
                private int _offset_TebBase;
                private int _offset_SubProcessTag;

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = 0;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_TThreadId
                {
                    get
                    {
                        if (_offset_TThreadId == -1)
                        {
                            _offset_TThreadId = Offset_ProcessId + 4;
                        }

                        return _offset_TThreadId;
                    }
                }

                private int Offset_StackBase
                {
                    get
                    {
                        if (_offset_StackBase == -1)
                        {
                            _offset_StackBase = Offset_TThreadId + 4;
                        }

                        return _offset_StackBase;
                    }
                }

                private int Offset_StackLimit
                {
                    get
                    {
                        if (_offset_StackLimit == -1)
                        {
                            _offset_StackLimit = Offset_StackBase + _etwEvent.AddressSize;
                        }

                        return _offset_StackLimit;
                    }
                }

                private int Offset_UserStackBase
                {
                    get
                    {
                        if (_offset_UserStackBase == -1)
                        {
                            _offset_UserStackBase = Offset_StackLimit + _etwEvent.AddressSize;
                        }

                        return _offset_UserStackBase;
                    }
                }

                private int Offset_UserStackLimit
                {
                    get
                    {
                        if (_offset_UserStackLimit == -1)
                        {
                            _offset_UserStackLimit = Offset_UserStackBase + _etwEvent.AddressSize;
                        }

                        return _offset_UserStackLimit;
                    }
                }

                private int Offset_StartAddr
                {
                    get
                    {
                        if (_offset_StartAddr == -1)
                        {
                            _offset_StartAddr = Offset_UserStackLimit + _etwEvent.AddressSize;
                        }

                        return _offset_StartAddr;
                    }
                }

                private int Offset_Win32StartAddr
                {
                    get
                    {
                        if (_offset_Win32StartAddr == -1)
                        {
                            _offset_Win32StartAddr = Offset_StartAddr + _etwEvent.AddressSize;
                        }

                        return _offset_Win32StartAddr;
                    }
                }

                private int Offset_TebBase
                {
                    get
                    {
                        if (_offset_TebBase == -1)
                        {
                            _offset_TebBase = Offset_Win32StartAddr + _etwEvent.AddressSize;
                        }

                        return _offset_TebBase;
                    }
                }

                private int Offset_SubProcessTag
                {
                    get
                    {
                        if (_offset_SubProcessTag == -1)
                        {
                            _offset_SubProcessTag = Offset_TebBase + _etwEvent.AddressSize;
                        }

                        return _offset_SubProcessTag;
                    }
                }

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..]);

                /// <summary>
                /// Retrieves the TThreadId field.
                /// </summary>
                public uint TThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_TThreadId..]);

                /// <summary>
                /// Retrieves the StackBase field.
                /// </summary>
                public ulong StackBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_StackBase..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_StackBase..]);

                /// <summary>
                /// Retrieves the StackLimit field.
                /// </summary>
                public ulong StackLimit => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_StackLimit..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_StackLimit..]);

                /// <summary>
                /// Retrieves the UserStackBase field.
                /// </summary>
                public ulong UserStackBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_UserStackBase..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_UserStackBase..]);

                /// <summary>
                /// Retrieves the UserStackLimit field.
                /// </summary>
                public ulong UserStackLimit => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_UserStackLimit..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_UserStackLimit..]);

                /// <summary>
                /// Retrieves the StartAddr field.
                /// </summary>
                public ulong StartAddr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_StartAddr..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_StartAddr..]);

                /// <summary>
                /// Retrieves the Win32StartAddr field.
                /// </summary>
                public ulong Win32StartAddr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Win32StartAddr..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Win32StartAddr..]);

                /// <summary>
                /// Retrieves the TebBase field.
                /// </summary>
                public ulong TebBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_TebBase..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_TebBase..]);

                /// <summary>
                /// Retrieves the SubProcessTag field.
                /// </summary>
                public uint SubProcessTag => BitConverter.ToUInt32(_etwEvent.Data[Offset_SubProcessTag..]);

                /// <summary>
                /// Creates a new StartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public StartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProcessId = -1;
                    _offset_TThreadId = -1;
                    _offset_StackBase = -1;
                    _offset_StackLimit = -1;
                    _offset_UserStackBase = -1;
                    _offset_UserStackLimit = -1;
                    _offset_StartAddr = -1;
                    _offset_Win32StartAddr = -1;
                    _offset_TebBase = -1;
                    _offset_SubProcessTag = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a End event.
        /// </summary>
        public readonly ref struct EndEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "End";

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
                Opcode = EtwEventOpcode.End,
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
            public EndData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new EndEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public EndEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a End event.
            /// </summary>
            public ref struct EndData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProcessId;
                private int _offset_TThreadId;
                private int _offset_StackBase;
                private int _offset_StackLimit;
                private int _offset_UserStackBase;
                private int _offset_UserStackLimit;
                private int _offset_StartAddr;
                private int _offset_Win32StartAddr;
                private int _offset_TebBase;
                private int _offset_SubProcessTag;

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = 0;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_TThreadId
                {
                    get
                    {
                        if (_offset_TThreadId == -1)
                        {
                            _offset_TThreadId = Offset_ProcessId + 4;
                        }

                        return _offset_TThreadId;
                    }
                }

                private int Offset_StackBase
                {
                    get
                    {
                        if (_offset_StackBase == -1)
                        {
                            _offset_StackBase = Offset_TThreadId + 4;
                        }

                        return _offset_StackBase;
                    }
                }

                private int Offset_StackLimit
                {
                    get
                    {
                        if (_offset_StackLimit == -1)
                        {
                            _offset_StackLimit = Offset_StackBase + _etwEvent.AddressSize;
                        }

                        return _offset_StackLimit;
                    }
                }

                private int Offset_UserStackBase
                {
                    get
                    {
                        if (_offset_UserStackBase == -1)
                        {
                            _offset_UserStackBase = Offset_StackLimit + _etwEvent.AddressSize;
                        }

                        return _offset_UserStackBase;
                    }
                }

                private int Offset_UserStackLimit
                {
                    get
                    {
                        if (_offset_UserStackLimit == -1)
                        {
                            _offset_UserStackLimit = Offset_UserStackBase + _etwEvent.AddressSize;
                        }

                        return _offset_UserStackLimit;
                    }
                }

                private int Offset_StartAddr
                {
                    get
                    {
                        if (_offset_StartAddr == -1)
                        {
                            _offset_StartAddr = Offset_UserStackLimit + _etwEvent.AddressSize;
                        }

                        return _offset_StartAddr;
                    }
                }

                private int Offset_Win32StartAddr
                {
                    get
                    {
                        if (_offset_Win32StartAddr == -1)
                        {
                            _offset_Win32StartAddr = Offset_StartAddr + _etwEvent.AddressSize;
                        }

                        return _offset_Win32StartAddr;
                    }
                }

                private int Offset_TebBase
                {
                    get
                    {
                        if (_offset_TebBase == -1)
                        {
                            _offset_TebBase = Offset_Win32StartAddr + _etwEvent.AddressSize;
                        }

                        return _offset_TebBase;
                    }
                }

                private int Offset_SubProcessTag
                {
                    get
                    {
                        if (_offset_SubProcessTag == -1)
                        {
                            _offset_SubProcessTag = Offset_TebBase + _etwEvent.AddressSize;
                        }

                        return _offset_SubProcessTag;
                    }
                }

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..]);

                /// <summary>
                /// Retrieves the TThreadId field.
                /// </summary>
                public uint TThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_TThreadId..]);

                /// <summary>
                /// Retrieves the StackBase field.
                /// </summary>
                public ulong StackBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_StackBase..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_StackBase..]);

                /// <summary>
                /// Retrieves the StackLimit field.
                /// </summary>
                public ulong StackLimit => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_StackLimit..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_StackLimit..]);

                /// <summary>
                /// Retrieves the UserStackBase field.
                /// </summary>
                public ulong UserStackBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_UserStackBase..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_UserStackBase..]);

                /// <summary>
                /// Retrieves the UserStackLimit field.
                /// </summary>
                public ulong UserStackLimit => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_UserStackLimit..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_UserStackLimit..]);

                /// <summary>
                /// Retrieves the StartAddr field.
                /// </summary>
                public ulong StartAddr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_StartAddr..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_StartAddr..]);

                /// <summary>
                /// Retrieves the Win32StartAddr field.
                /// </summary>
                public ulong Win32StartAddr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Win32StartAddr..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Win32StartAddr..]);

                /// <summary>
                /// Retrieves the TebBase field.
                /// </summary>
                public ulong TebBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_TebBase..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_TebBase..]);

                /// <summary>
                /// Retrieves the SubProcessTag field.
                /// </summary>
                public uint SubProcessTag => BitConverter.ToUInt32(_etwEvent.Data[Offset_SubProcessTag..]);

                /// <summary>
                /// Creates a new EndData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public EndData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProcessId = -1;
                    _offset_TThreadId = -1;
                    _offset_StackBase = -1;
                    _offset_StackLimit = -1;
                    _offset_UserStackBase = -1;
                    _offset_UserStackLimit = -1;
                    _offset_StartAddr = -1;
                    _offset_Win32StartAddr = -1;
                    _offset_TebBase = -1;
                    _offset_SubProcessTag = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DCStart event.
        /// </summary>
        public readonly ref struct DCStartEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DCStart";

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
                Opcode = EtwEventOpcode.DataCollectionStart,
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
            public DCStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DCStartEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DCStartEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a DCStart event.
            /// </summary>
            public ref struct DCStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProcessId;
                private int _offset_TThreadId;
                private int _offset_StackBase;
                private int _offset_StackLimit;
                private int _offset_UserStackBase;
                private int _offset_UserStackLimit;
                private int _offset_StartAddr;
                private int _offset_Win32StartAddr;
                private int _offset_TebBase;
                private int _offset_SubProcessTag;

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = 0;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_TThreadId
                {
                    get
                    {
                        if (_offset_TThreadId == -1)
                        {
                            _offset_TThreadId = Offset_ProcessId + 4;
                        }

                        return _offset_TThreadId;
                    }
                }

                private int Offset_StackBase
                {
                    get
                    {
                        if (_offset_StackBase == -1)
                        {
                            _offset_StackBase = Offset_TThreadId + 4;
                        }

                        return _offset_StackBase;
                    }
                }

                private int Offset_StackLimit
                {
                    get
                    {
                        if (_offset_StackLimit == -1)
                        {
                            _offset_StackLimit = Offset_StackBase + _etwEvent.AddressSize;
                        }

                        return _offset_StackLimit;
                    }
                }

                private int Offset_UserStackBase
                {
                    get
                    {
                        if (_offset_UserStackBase == -1)
                        {
                            _offset_UserStackBase = Offset_StackLimit + _etwEvent.AddressSize;
                        }

                        return _offset_UserStackBase;
                    }
                }

                private int Offset_UserStackLimit
                {
                    get
                    {
                        if (_offset_UserStackLimit == -1)
                        {
                            _offset_UserStackLimit = Offset_UserStackBase + _etwEvent.AddressSize;
                        }

                        return _offset_UserStackLimit;
                    }
                }

                private int Offset_StartAddr
                {
                    get
                    {
                        if (_offset_StartAddr == -1)
                        {
                            _offset_StartAddr = Offset_UserStackLimit + _etwEvent.AddressSize;
                        }

                        return _offset_StartAddr;
                    }
                }

                private int Offset_Win32StartAddr
                {
                    get
                    {
                        if (_offset_Win32StartAddr == -1)
                        {
                            _offset_Win32StartAddr = Offset_StartAddr + _etwEvent.AddressSize;
                        }

                        return _offset_Win32StartAddr;
                    }
                }

                private int Offset_TebBase
                {
                    get
                    {
                        if (_offset_TebBase == -1)
                        {
                            _offset_TebBase = Offset_Win32StartAddr + _etwEvent.AddressSize;
                        }

                        return _offset_TebBase;
                    }
                }

                private int Offset_SubProcessTag
                {
                    get
                    {
                        if (_offset_SubProcessTag == -1)
                        {
                            _offset_SubProcessTag = Offset_TebBase + _etwEvent.AddressSize;
                        }

                        return _offset_SubProcessTag;
                    }
                }

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..]);

                /// <summary>
                /// Retrieves the TThreadId field.
                /// </summary>
                public uint TThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_TThreadId..]);

                /// <summary>
                /// Retrieves the StackBase field.
                /// </summary>
                public ulong StackBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_StackBase..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_StackBase..]);

                /// <summary>
                /// Retrieves the StackLimit field.
                /// </summary>
                public ulong StackLimit => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_StackLimit..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_StackLimit..]);

                /// <summary>
                /// Retrieves the UserStackBase field.
                /// </summary>
                public ulong UserStackBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_UserStackBase..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_UserStackBase..]);

                /// <summary>
                /// Retrieves the UserStackLimit field.
                /// </summary>
                public ulong UserStackLimit => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_UserStackLimit..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_UserStackLimit..]);

                /// <summary>
                /// Retrieves the StartAddr field.
                /// </summary>
                public ulong StartAddr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_StartAddr..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_StartAddr..]);

                /// <summary>
                /// Retrieves the Win32StartAddr field.
                /// </summary>
                public ulong Win32StartAddr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Win32StartAddr..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Win32StartAddr..]);

                /// <summary>
                /// Retrieves the TebBase field.
                /// </summary>
                public ulong TebBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_TebBase..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_TebBase..]);

                /// <summary>
                /// Retrieves the SubProcessTag field.
                /// </summary>
                public uint SubProcessTag => BitConverter.ToUInt32(_etwEvent.Data[Offset_SubProcessTag..]);

                /// <summary>
                /// Creates a new DCStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DCStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProcessId = -1;
                    _offset_TThreadId = -1;
                    _offset_StackBase = -1;
                    _offset_StackLimit = -1;
                    _offset_UserStackBase = -1;
                    _offset_UserStackLimit = -1;
                    _offset_StartAddr = -1;
                    _offset_Win32StartAddr = -1;
                    _offset_TebBase = -1;
                    _offset_SubProcessTag = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DCEnd event.
        /// </summary>
        public readonly ref struct DCEndEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DCEnd";

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
                Opcode = EtwEventOpcode.DataCollectionEnd,
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
            public DCEndData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DCEndEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DCEndEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a DCEnd event.
            /// </summary>
            public ref struct DCEndData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProcessId;
                private int _offset_TThreadId;
                private int _offset_StackBase;
                private int _offset_StackLimit;
                private int _offset_UserStackBase;
                private int _offset_UserStackLimit;
                private int _offset_StartAddr;
                private int _offset_Win32StartAddr;
                private int _offset_TebBase;
                private int _offset_SubProcessTag;

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = 0;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_TThreadId
                {
                    get
                    {
                        if (_offset_TThreadId == -1)
                        {
                            _offset_TThreadId = Offset_ProcessId + 4;
                        }

                        return _offset_TThreadId;
                    }
                }

                private int Offset_StackBase
                {
                    get
                    {
                        if (_offset_StackBase == -1)
                        {
                            _offset_StackBase = Offset_TThreadId + 4;
                        }

                        return _offset_StackBase;
                    }
                }

                private int Offset_StackLimit
                {
                    get
                    {
                        if (_offset_StackLimit == -1)
                        {
                            _offset_StackLimit = Offset_StackBase + _etwEvent.AddressSize;
                        }

                        return _offset_StackLimit;
                    }
                }

                private int Offset_UserStackBase
                {
                    get
                    {
                        if (_offset_UserStackBase == -1)
                        {
                            _offset_UserStackBase = Offset_StackLimit + _etwEvent.AddressSize;
                        }

                        return _offset_UserStackBase;
                    }
                }

                private int Offset_UserStackLimit
                {
                    get
                    {
                        if (_offset_UserStackLimit == -1)
                        {
                            _offset_UserStackLimit = Offset_UserStackBase + _etwEvent.AddressSize;
                        }

                        return _offset_UserStackLimit;
                    }
                }

                private int Offset_StartAddr
                {
                    get
                    {
                        if (_offset_StartAddr == -1)
                        {
                            _offset_StartAddr = Offset_UserStackLimit + _etwEvent.AddressSize;
                        }

                        return _offset_StartAddr;
                    }
                }

                private int Offset_Win32StartAddr
                {
                    get
                    {
                        if (_offset_Win32StartAddr == -1)
                        {
                            _offset_Win32StartAddr = Offset_StartAddr + _etwEvent.AddressSize;
                        }

                        return _offset_Win32StartAddr;
                    }
                }

                private int Offset_TebBase
                {
                    get
                    {
                        if (_offset_TebBase == -1)
                        {
                            _offset_TebBase = Offset_Win32StartAddr + _etwEvent.AddressSize;
                        }

                        return _offset_TebBase;
                    }
                }

                private int Offset_SubProcessTag
                {
                    get
                    {
                        if (_offset_SubProcessTag == -1)
                        {
                            _offset_SubProcessTag = Offset_TebBase + _etwEvent.AddressSize;
                        }

                        return _offset_SubProcessTag;
                    }
                }

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..]);

                /// <summary>
                /// Retrieves the TThreadId field.
                /// </summary>
                public uint TThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_TThreadId..]);

                /// <summary>
                /// Retrieves the StackBase field.
                /// </summary>
                public ulong StackBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_StackBase..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_StackBase..]);

                /// <summary>
                /// Retrieves the StackLimit field.
                /// </summary>
                public ulong StackLimit => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_StackLimit..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_StackLimit..]);

                /// <summary>
                /// Retrieves the UserStackBase field.
                /// </summary>
                public ulong UserStackBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_UserStackBase..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_UserStackBase..]);

                /// <summary>
                /// Retrieves the UserStackLimit field.
                /// </summary>
                public ulong UserStackLimit => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_UserStackLimit..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_UserStackLimit..]);

                /// <summary>
                /// Retrieves the StartAddr field.
                /// </summary>
                public ulong StartAddr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_StartAddr..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_StartAddr..]);

                /// <summary>
                /// Retrieves the Win32StartAddr field.
                /// </summary>
                public ulong Win32StartAddr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Win32StartAddr..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Win32StartAddr..]);

                /// <summary>
                /// Retrieves the TebBase field.
                /// </summary>
                public ulong TebBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_TebBase..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_TebBase..]);

                /// <summary>
                /// Retrieves the SubProcessTag field.
                /// </summary>
                public uint SubProcessTag => BitConverter.ToUInt32(_etwEvent.Data[Offset_SubProcessTag..]);

                /// <summary>
                /// Creates a new DCEndData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DCEndData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProcessId = -1;
                    _offset_TThreadId = -1;
                    _offset_StackBase = -1;
                    _offset_StackLimit = -1;
                    _offset_UserStackBase = -1;
                    _offset_UserStackLimit = -1;
                    _offset_StartAddr = -1;
                    _offset_Win32StartAddr = -1;
                    _offset_TebBase = -1;
                    _offset_SubProcessTag = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a SetName event.
        /// </summary>
        public readonly ref struct SetNameEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SetName";

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
                Opcode = (EtwEventOpcode)Opcodes.SetName,
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
            public SetNameData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new SetNameEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SetNameEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a SetName event.
            /// </summary>
            public ref struct SetNameData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProcessId;
                private int _offset_ThreadId;
                private int _offset_ThreadName;

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = 0;
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

                private int Offset_ThreadName
                {
                    get
                    {
                        if (_offset_ThreadName == -1)
                        {
                            _offset_ThreadName = Offset_ThreadId + 4;
                        }

                        return _offset_ThreadName;
                    }
                }

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..]);

                /// <summary>
                /// Retrieves the ThreadId field.
                /// </summary>
                public uint ThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ThreadId..]);

                /// <summary>
                /// Retrieves the ThreadName field.
                /// </summary>
                public string ThreadName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ThreadName..]);

                /// <summary>
                /// Creates a new SetNameData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public SetNameData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProcessId = -1;
                    _offset_ThreadId = -1;
                    _offset_ThreadName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a CSwitch event.
        /// </summary>
        public readonly ref struct CSwitchEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "CSwitch";

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
                Opcode = (EtwEventOpcode)Opcodes.CSwitch,
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
            public CSwitchData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new CSwitchEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public CSwitchEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a CSwitch event.
            /// </summary>
            public ref struct CSwitchData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_NewThreadId;
                private int _offset_OldThreadId;
                private int _offset_NewThreadPriority;
                private int _offset_OldThreadPriority;
                private int _offset_PreviousCState;
                private int _offset_SpareByte;
                private int _offset_OldThreadWaitReason;
                private int _offset_OldThreadWaitMode;
                private int _offset_OldThreadState;
                private int _offset_OldThreadWaitIdealProcessor;
                private int _offset_NewThreadWaitTime;
                private int _offset_Reserved;

                private int Offset_NewThreadId
                {
                    get
                    {
                        if (_offset_NewThreadId == -1)
                        {
                            _offset_NewThreadId = 0;
                        }

                        return _offset_NewThreadId;
                    }
                }

                private int Offset_OldThreadId
                {
                    get
                    {
                        if (_offset_OldThreadId == -1)
                        {
                            _offset_OldThreadId = Offset_NewThreadId + 4;
                        }

                        return _offset_OldThreadId;
                    }
                }

                private int Offset_NewThreadPriority
                {
                    get
                    {
                        if (_offset_NewThreadPriority == -1)
                        {
                            _offset_NewThreadPriority = Offset_OldThreadId + 4;
                        }

                        return _offset_NewThreadPriority;
                    }
                }

                private int Offset_OldThreadPriority
                {
                    get
                    {
                        if (_offset_OldThreadPriority == -1)
                        {
                            _offset_OldThreadPriority = Offset_NewThreadPriority + 1;
                        }

                        return _offset_OldThreadPriority;
                    }
                }

                private int Offset_PreviousCState
                {
                    get
                    {
                        if (_offset_PreviousCState == -1)
                        {
                            _offset_PreviousCState = Offset_OldThreadPriority + 1;
                        }

                        return _offset_PreviousCState;
                    }
                }

                private int Offset_SpareByte
                {
                    get
                    {
                        if (_offset_SpareByte == -1)
                        {
                            _offset_SpareByte = Offset_PreviousCState + 1;
                        }

                        return _offset_SpareByte;
                    }
                }

                private int Offset_OldThreadWaitReason
                {
                    get
                    {
                        if (_offset_OldThreadWaitReason == -1)
                        {
                            _offset_OldThreadWaitReason = Offset_SpareByte + 1;
                        }

                        return _offset_OldThreadWaitReason;
                    }
                }

                private int Offset_OldThreadWaitMode
                {
                    get
                    {
                        if (_offset_OldThreadWaitMode == -1)
                        {
                            _offset_OldThreadWaitMode = Offset_OldThreadWaitReason + 1;
                        }

                        return _offset_OldThreadWaitMode;
                    }
                }

                private int Offset_OldThreadState
                {
                    get
                    {
                        if (_offset_OldThreadState == -1)
                        {
                            _offset_OldThreadState = Offset_OldThreadWaitMode + 1;
                        }

                        return _offset_OldThreadState;
                    }
                }

                private int Offset_OldThreadWaitIdealProcessor
                {
                    get
                    {
                        if (_offset_OldThreadWaitIdealProcessor == -1)
                        {
                            _offset_OldThreadWaitIdealProcessor = Offset_OldThreadState + 1;
                        }

                        return _offset_OldThreadWaitIdealProcessor;
                    }
                }

                private int Offset_NewThreadWaitTime
                {
                    get
                    {
                        if (_offset_NewThreadWaitTime == -1)
                        {
                            _offset_NewThreadWaitTime = Offset_OldThreadWaitIdealProcessor + 1;
                        }

                        return _offset_NewThreadWaitTime;
                    }
                }

                private int Offset_Reserved
                {
                    get
                    {
                        if (_offset_Reserved == -1)
                        {
                            _offset_Reserved = Offset_NewThreadWaitTime + 4;
                        }

                        return _offset_Reserved;
                    }
                }

                /// <summary>
                /// Retrieves the NewThreadId field.
                /// </summary>
                public uint NewThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_NewThreadId..]);

                /// <summary>
                /// Retrieves the OldThreadId field.
                /// </summary>
                public uint OldThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_OldThreadId..]);

                /// <summary>
                /// Retrieves the NewThreadPriority field.
                /// </summary>
                public sbyte NewThreadPriority => (sbyte)_etwEvent.Data[Offset_NewThreadPriority];

                /// <summary>
                /// Retrieves the OldThreadPriority field.
                /// </summary>
                public sbyte OldThreadPriority => (sbyte)_etwEvent.Data[Offset_OldThreadPriority];

                /// <summary>
                /// Retrieves the PreviousCState field.
                /// </summary>
                public byte PreviousCState => _etwEvent.Data[Offset_PreviousCState];

                /// <summary>
                /// Retrieves the SpareByte field.
                /// </summary>
                public sbyte SpareByte => (sbyte)_etwEvent.Data[Offset_SpareByte];

                /// <summary>
                /// Retrieves the OldThreadWaitReason field.
                /// </summary>
                public sbyte OldThreadWaitReason => (sbyte)_etwEvent.Data[Offset_OldThreadWaitReason];

                /// <summary>
                /// Retrieves the OldThreadWaitMode field.
                /// </summary>
                public sbyte OldThreadWaitMode => (sbyte)_etwEvent.Data[Offset_OldThreadWaitMode];

                /// <summary>
                /// Retrieves the OldThreadState field.
                /// </summary>
                public sbyte OldThreadState => (sbyte)_etwEvent.Data[Offset_OldThreadState];

                /// <summary>
                /// Retrieves the OldThreadWaitIdealProcessor field.
                /// </summary>
                public sbyte OldThreadWaitIdealProcessor => (sbyte)_etwEvent.Data[Offset_OldThreadWaitIdealProcessor];

                /// <summary>
                /// Retrieves the NewThreadWaitTime field.
                /// </summary>
                public uint NewThreadWaitTime => BitConverter.ToUInt32(_etwEvent.Data[Offset_NewThreadWaitTime..]);

                /// <summary>
                /// Retrieves the Reserved field.
                /// </summary>
                public uint Reserved => BitConverter.ToUInt32(_etwEvent.Data[Offset_Reserved..]);

                /// <summary>
                /// Creates a new CSwitchData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public CSwitchData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_NewThreadId = -1;
                    _offset_OldThreadId = -1;
                    _offset_NewThreadPriority = -1;
                    _offset_OldThreadPriority = -1;
                    _offset_PreviousCState = -1;
                    _offset_SpareByte = -1;
                    _offset_OldThreadWaitReason = -1;
                    _offset_OldThreadWaitMode = -1;
                    _offset_OldThreadState = -1;
                    _offset_OldThreadWaitIdealProcessor = -1;
                    _offset_NewThreadWaitTime = -1;
                    _offset_Reserved = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a CompCS event.
        /// </summary>
        public readonly ref struct CompCSEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "CompCS";

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
                Opcode = (EtwEventOpcode)Opcodes.CompCS,
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
            /// Creates a new CompCSEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public CompCSEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a SpinLock event.
        /// </summary>
        public readonly ref struct SpinLockEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SpinLock";

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
                Opcode = (EtwEventOpcode)Opcodes.SpinLock,
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
            public SpinLockData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new SpinLockEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SpinLockEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a SpinLock event.
            /// </summary>
            public ref struct SpinLockData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_SpinLockAddress;
                private int _offset_CallerAddress;
                private int _offset_AcquireTime;
                private int _offset_ReleaseTime;
                private int _offset_WaitTimeInCycles;
                private int _offset_SpinCount;
                private int _offset_ThreadId;
                private int _offset_InterruptCount;
                private int _offset_Irql;
                private int _offset_AcquireDepth;
                private int _offset_Flag;
                private int _offset_Reserved;

                private int Offset_SpinLockAddress
                {
                    get
                    {
                        if (_offset_SpinLockAddress == -1)
                        {
                            _offset_SpinLockAddress = 0;
                        }

                        return _offset_SpinLockAddress;
                    }
                }

                private int Offset_CallerAddress
                {
                    get
                    {
                        if (_offset_CallerAddress == -1)
                        {
                            _offset_CallerAddress = Offset_SpinLockAddress + _etwEvent.AddressSize;
                        }

                        return _offset_CallerAddress;
                    }
                }

                private int Offset_AcquireTime
                {
                    get
                    {
                        if (_offset_AcquireTime == -1)
                        {
                            _offset_AcquireTime = Offset_CallerAddress + _etwEvent.AddressSize;
                        }

                        return _offset_AcquireTime;
                    }
                }

                private int Offset_ReleaseTime
                {
                    get
                    {
                        if (_offset_ReleaseTime == -1)
                        {
                            _offset_ReleaseTime = Offset_AcquireTime + 8;
                        }

                        return _offset_ReleaseTime;
                    }
                }

                private int Offset_WaitTimeInCycles
                {
                    get
                    {
                        if (_offset_WaitTimeInCycles == -1)
                        {
                            _offset_WaitTimeInCycles = Offset_ReleaseTime + 8;
                        }

                        return _offset_WaitTimeInCycles;
                    }
                }

                private int Offset_SpinCount
                {
                    get
                    {
                        if (_offset_SpinCount == -1)
                        {
                            _offset_SpinCount = Offset_WaitTimeInCycles + 4;
                        }

                        return _offset_SpinCount;
                    }
                }

                private int Offset_ThreadId
                {
                    get
                    {
                        if (_offset_ThreadId == -1)
                        {
                            _offset_ThreadId = Offset_SpinCount + 4;
                        }

                        return _offset_ThreadId;
                    }
                }

                private int Offset_InterruptCount
                {
                    get
                    {
                        if (_offset_InterruptCount == -1)
                        {
                            _offset_InterruptCount = Offset_ThreadId + 4;
                        }

                        return _offset_InterruptCount;
                    }
                }

                private int Offset_Irql
                {
                    get
                    {
                        if (_offset_Irql == -1)
                        {
                            _offset_Irql = Offset_InterruptCount + 4;
                        }

                        return _offset_Irql;
                    }
                }

                private int Offset_AcquireDepth
                {
                    get
                    {
                        if (_offset_AcquireDepth == -1)
                        {
                            _offset_AcquireDepth = Offset_Irql + 1;
                        }

                        return _offset_AcquireDepth;
                    }
                }

                private int Offset_Flag
                {
                    get
                    {
                        if (_offset_Flag == -1)
                        {
                            _offset_Flag = Offset_AcquireDepth + 1;
                        }

                        return _offset_Flag;
                    }
                }

                private int Offset_Reserved
                {
                    get
                    {
                        if (_offset_Reserved == -1)
                        {
                            _offset_Reserved = Offset_Flag + 1;
                        }

                        return _offset_Reserved;
                    }
                }

                /// <summary>
                /// Retrieves the SpinLockAddress field.
                /// </summary>
                public ulong SpinLockAddress => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_SpinLockAddress..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_SpinLockAddress..]);

                /// <summary>
                /// Retrieves the CallerAddress field.
                /// </summary>
                public ulong CallerAddress => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_CallerAddress..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_CallerAddress..]);

                /// <summary>
                /// Retrieves the AcquireTime field.
                /// </summary>
                public ulong AcquireTime => BitConverter.ToUInt64(_etwEvent.Data[Offset_AcquireTime..]);

                /// <summary>
                /// Retrieves the ReleaseTime field.
                /// </summary>
                public ulong ReleaseTime => BitConverter.ToUInt64(_etwEvent.Data[Offset_ReleaseTime..]);

                /// <summary>
                /// Retrieves the WaitTimeInCycles field.
                /// </summary>
                public uint WaitTimeInCycles => BitConverter.ToUInt32(_etwEvent.Data[Offset_WaitTimeInCycles..]);

                /// <summary>
                /// Retrieves the SpinCount field.
                /// </summary>
                public uint SpinCount => BitConverter.ToUInt32(_etwEvent.Data[Offset_SpinCount..]);

                /// <summary>
                /// Retrieves the ThreadId field.
                /// </summary>
                public uint ThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ThreadId..]);

                /// <summary>
                /// Retrieves the InterruptCount field.
                /// </summary>
                public uint InterruptCount => BitConverter.ToUInt32(_etwEvent.Data[Offset_InterruptCount..]);

                /// <summary>
                /// Retrieves the Irql field.
                /// </summary>
                public byte Irql => _etwEvent.Data[Offset_Irql];

                /// <summary>
                /// Retrieves the AcquireDepth field.
                /// </summary>
                public byte AcquireDepth => _etwEvent.Data[Offset_AcquireDepth];

                /// <summary>
                /// Retrieves the Flag field.
                /// </summary>
                public byte Flag => _etwEvent.Data[Offset_Flag];

                /// <summary>
                /// Retrieves the Reserved field.
                /// </summary>
                public byte Reserved => _etwEvent.Data[Offset_Reserved];

                /// <summary>
                /// Creates a new SpinLockData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public SpinLockData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_SpinLockAddress = -1;
                    _offset_CallerAddress = -1;
                    _offset_AcquireTime = -1;
                    _offset_ReleaseTime = -1;
                    _offset_WaitTimeInCycles = -1;
                    _offset_SpinCount = -1;
                    _offset_ThreadId = -1;
                    _offset_InterruptCount = -1;
                    _offset_Irql = -1;
                    _offset_AcquireDepth = -1;
                    _offset_Flag = -1;
                    _offset_Reserved = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ReadyThread event.
        /// </summary>
        public readonly ref struct ReadyThreadEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ReadyThread";

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
                Opcode = (EtwEventOpcode)Opcodes.ReadyThread,
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
            public ReadyThreadData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ReadyThreadEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ReadyThreadEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ReadyThread event.
            /// </summary>
            public ref struct ReadyThreadData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_TThreadId;
                private int _offset_AdjustReason;
                private int _offset_AdjustIncrement;
                private int _offset_Flag;
                private int _offset_Reserved;

                private int Offset_TThreadId
                {
                    get
                    {
                        if (_offset_TThreadId == -1)
                        {
                            _offset_TThreadId = 0;
                        }

                        return _offset_TThreadId;
                    }
                }

                private int Offset_AdjustReason
                {
                    get
                    {
                        if (_offset_AdjustReason == -1)
                        {
                            _offset_AdjustReason = Offset_TThreadId + 4;
                        }

                        return _offset_AdjustReason;
                    }
                }

                private int Offset_AdjustIncrement
                {
                    get
                    {
                        if (_offset_AdjustIncrement == -1)
                        {
                            _offset_AdjustIncrement = Offset_AdjustReason + 1;
                        }

                        return _offset_AdjustIncrement;
                    }
                }

                private int Offset_Flag
                {
                    get
                    {
                        if (_offset_Flag == -1)
                        {
                            _offset_Flag = Offset_AdjustIncrement + 1;
                        }

                        return _offset_Flag;
                    }
                }

                private int Offset_Reserved
                {
                    get
                    {
                        if (_offset_Reserved == -1)
                        {
                            _offset_Reserved = Offset_Flag + 1;
                        }

                        return _offset_Reserved;
                    }
                }

                /// <summary>
                /// Retrieves the TThreadId field.
                /// </summary>
                public uint TThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_TThreadId..]);

                /// <summary>
                /// Retrieves the AdjustReason field.
                /// </summary>
                public sbyte AdjustReason => (sbyte)_etwEvent.Data[Offset_AdjustReason];

                /// <summary>
                /// Retrieves the AdjustIncrement field.
                /// </summary>
                public sbyte AdjustIncrement => (sbyte)_etwEvent.Data[Offset_AdjustIncrement];

                /// <summary>
                /// Retrieves the Flag field.
                /// </summary>
                public sbyte Flag => (sbyte)_etwEvent.Data[Offset_Flag];

                /// <summary>
                /// Retrieves the Reserved field.
                /// </summary>
                public sbyte Reserved => (sbyte)_etwEvent.Data[Offset_Reserved];

                /// <summary>
                /// Creates a new ReadyThreadData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ReadyThreadData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_TThreadId = -1;
                    _offset_AdjustReason = -1;
                    _offset_AdjustIncrement = -1;
                    _offset_Flag = -1;
                    _offset_Reserved = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ThreadAffinity event.
        /// </summary>
        public readonly ref struct ThreadAffinityEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ThreadAffinity";

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
                Opcode = (EtwEventOpcode)Opcodes.ThreadAffinity,
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
            public ThreadAffinityData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ThreadAffinityEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ThreadAffinityEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ThreadAffinity event.
            /// </summary>
            public ref struct ThreadAffinityData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Affinity;
                private int _offset_ThreadId;
                private int _offset_Group;
                private int _offset_Reserved;

                private int Offset_Affinity
                {
                    get
                    {
                        if (_offset_Affinity == -1)
                        {
                            _offset_Affinity = 0;
                        }

                        return _offset_Affinity;
                    }
                }

                private int Offset_ThreadId
                {
                    get
                    {
                        if (_offset_ThreadId == -1)
                        {
                            _offset_ThreadId = Offset_Affinity + _etwEvent.AddressSize;
                        }

                        return _offset_ThreadId;
                    }
                }

                private int Offset_Group
                {
                    get
                    {
                        if (_offset_Group == -1)
                        {
                            _offset_Group = Offset_ThreadId + 4;
                        }

                        return _offset_Group;
                    }
                }

                private int Offset_Reserved
                {
                    get
                    {
                        if (_offset_Reserved == -1)
                        {
                            _offset_Reserved = Offset_Group + 2;
                        }

                        return _offset_Reserved;
                    }
                }

                /// <summary>
                /// Retrieves the Affinity field.
                /// </summary>
                public ulong Affinity => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Affinity..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Affinity..]);

                /// <summary>
                /// Retrieves the ThreadId field.
                /// </summary>
                public uint ThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ThreadId..]);

                /// <summary>
                /// Retrieves the Group field.
                /// </summary>
                public ushort Group => BitConverter.ToUInt16(_etwEvent.Data[Offset_Group..]);

                /// <summary>
                /// Retrieves the Reserved field.
                /// </summary>
                public ushort Reserved => BitConverter.ToUInt16(_etwEvent.Data[Offset_Reserved..]);

                /// <summary>
                /// Creates a new ThreadAffinityData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ThreadAffinityData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Affinity = -1;
                    _offset_ThreadId = -1;
                    _offset_Group = -1;
                    _offset_Reserved = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a WorkerThread event.
        /// </summary>
        public readonly ref struct WorkerThreadEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "WorkerThread";

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
                Opcode = (EtwEventOpcode)Opcodes.WorkerThread,
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
            public WorkerThreadData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new WorkerThreadEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public WorkerThreadEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a WorkerThread event.
            /// </summary>
            public ref struct WorkerThreadData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_TThreadId;
                private int _offset_StartTime;
                private int _offset_ThreadRoutine;

                private int Offset_TThreadId
                {
                    get
                    {
                        if (_offset_TThreadId == -1)
                        {
                            _offset_TThreadId = 0;
                        }

                        return _offset_TThreadId;
                    }
                }

                private int Offset_StartTime
                {
                    get
                    {
                        if (_offset_StartTime == -1)
                        {
                            _offset_StartTime = Offset_TThreadId + 4;
                        }

                        return _offset_StartTime;
                    }
                }

                private int Offset_ThreadRoutine
                {
                    get
                    {
                        if (_offset_ThreadRoutine == -1)
                        {
                            _offset_ThreadRoutine = Offset_StartTime + 8;
                        }

                        return _offset_ThreadRoutine;
                    }
                }

                /// <summary>
                /// Retrieves the TThreadId field.
                /// </summary>
                public uint TThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_TThreadId..]);

                /// <summary>
                /// Retrieves the StartTime field.
                /// </summary>
                public ulong StartTime => BitConverter.ToUInt64(_etwEvent.Data[Offset_StartTime..]);

                /// <summary>
                /// Retrieves the ThreadRoutine field.
                /// </summary>
                public ulong ThreadRoutine => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ThreadRoutine..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ThreadRoutine..]);

                /// <summary>
                /// Creates a new WorkerThreadData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public WorkerThreadData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_TThreadId = -1;
                    _offset_StartTime = -1;
                    _offset_ThreadRoutine = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a AntiStarvationBoost event.
        /// </summary>
        public readonly ref struct AntiStarvationBoostEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "AntiStarvationBoost";

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
                Opcode = (EtwEventOpcode)Opcodes.AntiStarvationBoost,
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
            public AntiStarvationBoostData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new AntiStarvationBoostEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public AntiStarvationBoostEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a AntiStarvationBoost event.
            /// </summary>
            public ref struct AntiStarvationBoostData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ThreadId;
                private int _offset_ProcessorIndex;
                private int _offset_Priority;
                private int _offset_Reserved;

                private int Offset_ThreadId
                {
                    get
                    {
                        if (_offset_ThreadId == -1)
                        {
                            _offset_ThreadId = 0;
                        }

                        return _offset_ThreadId;
                    }
                }

                private int Offset_ProcessorIndex
                {
                    get
                    {
                        if (_offset_ProcessorIndex == -1)
                        {
                            _offset_ProcessorIndex = Offset_ThreadId + 4;
                        }

                        return _offset_ProcessorIndex;
                    }
                }

                private int Offset_Priority
                {
                    get
                    {
                        if (_offset_Priority == -1)
                        {
                            _offset_Priority = Offset_ProcessorIndex + 2;
                        }

                        return _offset_Priority;
                    }
                }

                private int Offset_Reserved
                {
                    get
                    {
                        if (_offset_Reserved == -1)
                        {
                            _offset_Reserved = Offset_Priority + 1;
                        }

                        return _offset_Reserved;
                    }
                }

                /// <summary>
                /// Retrieves the ThreadId field.
                /// </summary>
                public uint ThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ThreadId..]);

                /// <summary>
                /// Retrieves the ProcessorIndex field.
                /// </summary>
                public ushort ProcessorIndex => BitConverter.ToUInt16(_etwEvent.Data[Offset_ProcessorIndex..]);

                /// <summary>
                /// Retrieves the Priority field.
                /// </summary>
                public byte Priority => _etwEvent.Data[Offset_Priority];

                /// <summary>
                /// Retrieves the Reserved field.
                /// </summary>
                public byte Reserved => _etwEvent.Data[Offset_Reserved];

                /// <summary>
                /// Creates a new AntiStarvationBoostData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public AntiStarvationBoostData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ThreadId = -1;
                    _offset_ProcessorIndex = -1;
                    _offset_Priority = -1;
                    _offset_Reserved = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ThreadMigration event.
        /// </summary>
        public readonly ref struct ThreadMigrationEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ThreadMigration";

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
                Opcode = (EtwEventOpcode)Opcodes.ThreadMigration,
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
            public ThreadMigrationData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ThreadMigrationEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ThreadMigrationEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ThreadMigration event.
            /// </summary>
            public ref struct ThreadMigrationData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ThreadId;
                private int _offset_SourceProcessorIndex;
                private int _offset_TargetProcessorIndex;
                private int _offset_Priority;
                private int _offset_IdealProcessorAdjust;
                private int _offset_OldIdealProcessorIndex;

                private int Offset_ThreadId
                {
                    get
                    {
                        if (_offset_ThreadId == -1)
                        {
                            _offset_ThreadId = 0;
                        }

                        return _offset_ThreadId;
                    }
                }

                private int Offset_SourceProcessorIndex
                {
                    get
                    {
                        if (_offset_SourceProcessorIndex == -1)
                        {
                            _offset_SourceProcessorIndex = Offset_ThreadId + 4;
                        }

                        return _offset_SourceProcessorIndex;
                    }
                }

                private int Offset_TargetProcessorIndex
                {
                    get
                    {
                        if (_offset_TargetProcessorIndex == -1)
                        {
                            _offset_TargetProcessorIndex = Offset_SourceProcessorIndex + 2;
                        }

                        return _offset_TargetProcessorIndex;
                    }
                }

                private int Offset_Priority
                {
                    get
                    {
                        if (_offset_Priority == -1)
                        {
                            _offset_Priority = Offset_TargetProcessorIndex + 2;
                        }

                        return _offset_Priority;
                    }
                }

                private int Offset_IdealProcessorAdjust
                {
                    get
                    {
                        if (_offset_IdealProcessorAdjust == -1)
                        {
                            _offset_IdealProcessorAdjust = Offset_Priority + 1;
                        }

                        return _offset_IdealProcessorAdjust;
                    }
                }

                private int Offset_OldIdealProcessorIndex
                {
                    get
                    {
                        if (_offset_OldIdealProcessorIndex == -1)
                        {
                            _offset_OldIdealProcessorIndex = Offset_IdealProcessorAdjust + 1;
                        }

                        return _offset_OldIdealProcessorIndex;
                    }
                }

                /// <summary>
                /// Retrieves the ThreadId field.
                /// </summary>
                public uint ThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ThreadId..]);

                /// <summary>
                /// Retrieves the SourceProcessorIndex field.
                /// </summary>
                public ushort SourceProcessorIndex => BitConverter.ToUInt16(_etwEvent.Data[Offset_SourceProcessorIndex..]);

                /// <summary>
                /// Retrieves the TargetProcessorIndex field.
                /// </summary>
                public ushort TargetProcessorIndex => BitConverter.ToUInt16(_etwEvent.Data[Offset_TargetProcessorIndex..]);

                /// <summary>
                /// Retrieves the Priority field.
                /// </summary>
                public byte Priority => _etwEvent.Data[Offset_Priority];

                /// <summary>
                /// Retrieves the IdealProcessorAdjust field.
                /// </summary>
                public bool IdealProcessorAdjust => _etwEvent.Data[Offset_IdealProcessorAdjust] != 0;

                /// <summary>
                /// Retrieves the OldIdealProcessorIndex field.
                /// </summary>
                public ushort OldIdealProcessorIndex => BitConverter.ToUInt16(_etwEvent.Data[Offset_OldIdealProcessorIndex..]);

                /// <summary>
                /// Creates a new ThreadMigrationData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ThreadMigrationData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ThreadId = -1;
                    _offset_SourceProcessorIndex = -1;
                    _offset_TargetProcessorIndex = -1;
                    _offset_Priority = -1;
                    _offset_IdealProcessorAdjust = -1;
                    _offset_OldIdealProcessorIndex = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a KernelQueueEnqueue event.
        /// </summary>
        public readonly ref struct KernelQueueEnqueueEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "KernelQueueEnqueue";

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
                Opcode = (EtwEventOpcode)Opcodes.KernelQueueEnqueue,
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
            public KernelQueueEnqueueData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new KernelQueueEnqueueEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public KernelQueueEnqueueEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a KernelQueueEnqueue event.
            /// </summary>
            public ref struct KernelQueueEnqueueData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Entry;
                private int _offset_ThreadId;

                private int Offset_Entry
                {
                    get
                    {
                        if (_offset_Entry == -1)
                        {
                            _offset_Entry = 0;
                        }

                        return _offset_Entry;
                    }
                }

                private int Offset_ThreadId
                {
                    get
                    {
                        if (_offset_ThreadId == -1)
                        {
                            _offset_ThreadId = Offset_Entry + _etwEvent.AddressSize;
                        }

                        return _offset_ThreadId;
                    }
                }

                /// <summary>
                /// Retrieves the Entry field.
                /// </summary>
                public ulong Entry => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Entry..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Entry..]);

                /// <summary>
                /// Retrieves the ThreadId field.
                /// </summary>
                public uint ThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ThreadId..]);

                /// <summary>
                /// Creates a new KernelQueueEnqueueData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public KernelQueueEnqueueData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Entry = -1;
                    _offset_ThreadId = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a KernelQueueDequeue event.
        /// </summary>
        public readonly ref struct KernelQueueDequeueEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "KernelQueueDequeue";

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
                Opcode = (EtwEventOpcode)Opcodes.KernelQueueDequeue,
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
            public KernelQueueDequeueData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new KernelQueueDequeueEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public KernelQueueDequeueEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a KernelQueueDequeue event.
            /// </summary>
            public ref struct KernelQueueDequeueData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ThreadId;
                private int _offset_EntryCount;
                private int _offset_Entries;

                private int Offset_ThreadId
                {
                    get
                    {
                        if (_offset_ThreadId == -1)
                        {
                            _offset_ThreadId = 0;
                        }

                        return _offset_ThreadId;
                    }
                }

                private int Offset_EntryCount
                {
                    get
                    {
                        if (_offset_EntryCount == -1)
                        {
                            _offset_EntryCount = Offset_ThreadId + 4;
                        }

                        return _offset_EntryCount;
                    }
                }

                private int Offset_Entries
                {
                    get
                    {
                        if (_offset_Entries == -1)
                        {
                            _offset_Entries = Offset_EntryCount + 4;
                        }

                        return _offset_Entries;
                    }
                }

                /// <summary>
                /// Retrieves the ThreadId field.
                /// </summary>
                public uint ThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ThreadId..]);

                /// <summary>
                /// Retrieves the EntryCount field.
                /// </summary>
                public uint EntryCount => BitConverter.ToUInt32(_etwEvent.Data[Offset_EntryCount..]);

                /// <summary>
                /// Retrieves the Entries field.
                /// </summary>
                public EtwEvent.AddressEnumerable Entries => new(_etwEvent, Offset_Entries, EntryCount);

                /// <summary>
                /// Creates a new KernelQueueDequeueData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public KernelQueueDequeueData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ThreadId = -1;
                    _offset_EntryCount = -1;
                    _offset_Entries = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a WorkerThreadStart event.
        /// </summary>
        public readonly ref struct WorkerThreadStartEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "WorkerThreadStart";

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
                Opcode = (EtwEventOpcode)Opcodes.WorkerThreadStart,
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
            public WorkerThreadStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new WorkerThreadStartEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public WorkerThreadStartEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a WorkerThreadStart event.
            /// </summary>
            public ref struct WorkerThreadStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_CallbackRoutine;

                private int Offset_CallbackRoutine
                {
                    get
                    {
                        if (_offset_CallbackRoutine == -1)
                        {
                            _offset_CallbackRoutine = 0;
                        }

                        return _offset_CallbackRoutine;
                    }
                }

                /// <summary>
                /// Retrieves the CallbackRoutine field.
                /// </summary>
                public ulong CallbackRoutine => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_CallbackRoutine..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_CallbackRoutine..]);

                /// <summary>
                /// Creates a new WorkerThreadStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public WorkerThreadStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_CallbackRoutine = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a WorkerThreadEnd event.
        /// </summary>
        public readonly ref struct WorkerThreadEndEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "WorkerThreadEnd";

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
                Opcode = (EtwEventOpcode)Opcodes.WorkerThreadEnd,
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
            public WorkerThreadEndData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new WorkerThreadEndEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public WorkerThreadEndEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a WorkerThreadEnd event.
            /// </summary>
            public ref struct WorkerThreadEndData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_CallbackRoutine;

                private int Offset_CallbackRoutine
                {
                    get
                    {
                        if (_offset_CallbackRoutine == -1)
                        {
                            _offset_CallbackRoutine = 0;
                        }

                        return _offset_CallbackRoutine;
                    }
                }

                /// <summary>
                /// Retrieves the CallbackRoutine field.
                /// </summary>
                public ulong CallbackRoutine => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_CallbackRoutine..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_CallbackRoutine..]);

                /// <summary>
                /// Creates a new WorkerThreadEndData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public WorkerThreadEndData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_CallbackRoutine = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a AutoBoostSetFloor event.
        /// </summary>
        public readonly ref struct AutoBoostSetFloorEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "AutoBoostSetFloor";

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
                Opcode = (EtwEventOpcode)Opcodes.AutoBoostSetFloor,
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
            public AutoBoostSetFloorData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new AutoBoostSetFloorEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public AutoBoostSetFloorEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a AutoBoostSetFloor event.
            /// </summary>
            public ref struct AutoBoostSetFloorData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Lock;
                private int _offset_ThreadId;
                private int _offset_NewCpuPriorityFloor;
                private int _offset_OldCpuPriority;
                private int _offset_IoPriorities;
                private int _offset_BoostFlags;

                private int Offset_Lock
                {
                    get
                    {
                        if (_offset_Lock == -1)
                        {
                            _offset_Lock = 0;
                        }

                        return _offset_Lock;
                    }
                }

                private int Offset_ThreadId
                {
                    get
                    {
                        if (_offset_ThreadId == -1)
                        {
                            _offset_ThreadId = Offset_Lock + _etwEvent.AddressSize;
                        }

                        return _offset_ThreadId;
                    }
                }

                private int Offset_NewCpuPriorityFloor
                {
                    get
                    {
                        if (_offset_NewCpuPriorityFloor == -1)
                        {
                            _offset_NewCpuPriorityFloor = Offset_ThreadId + 4;
                        }

                        return _offset_NewCpuPriorityFloor;
                    }
                }

                private int Offset_OldCpuPriority
                {
                    get
                    {
                        if (_offset_OldCpuPriority == -1)
                        {
                            _offset_OldCpuPriority = Offset_NewCpuPriorityFloor + 1;
                        }

                        return _offset_OldCpuPriority;
                    }
                }

                private int Offset_IoPriorities
                {
                    get
                    {
                        if (_offset_IoPriorities == -1)
                        {
                            _offset_IoPriorities = Offset_OldCpuPriority + 1;
                        }

                        return _offset_IoPriorities;
                    }
                }

                private int Offset_BoostFlags
                {
                    get
                    {
                        if (_offset_BoostFlags == -1)
                        {
                            _offset_BoostFlags = Offset_IoPriorities + 1;
                        }

                        return _offset_BoostFlags;
                    }
                }

                /// <summary>
                /// Retrieves the Lock field.
                /// </summary>
                public ulong Lock => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Lock..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Lock..]);

                /// <summary>
                /// Retrieves the ThreadId field.
                /// </summary>
                public uint ThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ThreadId..]);

                /// <summary>
                /// Retrieves the NewCpuPriorityFloor field.
                /// </summary>
                public byte NewCpuPriorityFloor => _etwEvent.Data[Offset_NewCpuPriorityFloor];

                /// <summary>
                /// Retrieves the OldCpuPriority field.
                /// </summary>
                public byte OldCpuPriority => _etwEvent.Data[Offset_OldCpuPriority];

                /// <summary>
                /// Retrieves the IoPriorities field.
                /// </summary>
                public byte IoPriorities => _etwEvent.Data[Offset_IoPriorities];

                /// <summary>
                /// Retrieves the BoostFlags field.
                /// </summary>
                public byte BoostFlags => _etwEvent.Data[Offset_BoostFlags];

                /// <summary>
                /// Creates a new AutoBoostSetFloorData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public AutoBoostSetFloorData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Lock = -1;
                    _offset_ThreadId = -1;
                    _offset_NewCpuPriorityFloor = -1;
                    _offset_OldCpuPriority = -1;
                    _offset_IoPriorities = -1;
                    _offset_BoostFlags = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a AutoBoostClearFloor event.
        /// </summary>
        public readonly ref struct AutoBoostClearFloorEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "AutoBoostClearFloor";

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
                Opcode = (EtwEventOpcode)Opcodes.AutoBoostClearFloor,
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
            public AutoBoostClearFloorData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new AutoBoostClearFloorEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public AutoBoostClearFloorEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a AutoBoostClearFloor event.
            /// </summary>
            public ref struct AutoBoostClearFloorData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_LockAddress;
                private int _offset_ThreadId;
                private int _offset_BoostBitmap;

                private int Offset_LockAddress
                {
                    get
                    {
                        if (_offset_LockAddress == -1)
                        {
                            _offset_LockAddress = 0;
                        }

                        return _offset_LockAddress;
                    }
                }

                private int Offset_ThreadId
                {
                    get
                    {
                        if (_offset_ThreadId == -1)
                        {
                            _offset_ThreadId = Offset_LockAddress + _etwEvent.AddressSize;
                        }

                        return _offset_ThreadId;
                    }
                }

                private int Offset_BoostBitmap
                {
                    get
                    {
                        if (_offset_BoostBitmap == -1)
                        {
                            _offset_BoostBitmap = Offset_ThreadId + 4;
                        }

                        return _offset_BoostBitmap;
                    }
                }

                /// <summary>
                /// Retrieves the LockAddress field.
                /// </summary>
                public ulong LockAddress => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_LockAddress..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_LockAddress..]);

                /// <summary>
                /// Retrieves the ThreadId field.
                /// </summary>
                public uint ThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ThreadId..]);

                /// <summary>
                /// Retrieves the BoostBitmap field.
                /// </summary>
                public uint BoostBitmap => BitConverter.ToUInt32(_etwEvent.Data[Offset_BoostBitmap..]);

                /// <summary>
                /// Creates a new AutoBoostClearFloorData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public AutoBoostClearFloorData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_LockAddress = -1;
                    _offset_ThreadId = -1;
                    _offset_BoostBitmap = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a AutoBoostEntryExhaustion event.
        /// </summary>
        public readonly ref struct AutoBoostEntryExhaustionEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "AutoBoostEntryExhaustion";

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
                Opcode = (EtwEventOpcode)Opcodes.AutoBoostEntryExhaustion,
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
            public AutoBoostEntryExhaustionData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new AutoBoostEntryExhaustionEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public AutoBoostEntryExhaustionEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a AutoBoostEntryExhaustion event.
            /// </summary>
            public ref struct AutoBoostEntryExhaustionData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_LockAddress;
                private int _offset_ThreadId;

                private int Offset_LockAddress
                {
                    get
                    {
                        if (_offset_LockAddress == -1)
                        {
                            _offset_LockAddress = 0;
                        }

                        return _offset_LockAddress;
                    }
                }

                private int Offset_ThreadId
                {
                    get
                    {
                        if (_offset_ThreadId == -1)
                        {
                            _offset_ThreadId = Offset_LockAddress + _etwEvent.AddressSize;
                        }

                        return _offset_ThreadId;
                    }
                }

                /// <summary>
                /// Retrieves the LockAddress field.
                /// </summary>
                public ulong LockAddress => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_LockAddress..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_LockAddress..]);

                /// <summary>
                /// Retrieves the ThreadId field.
                /// </summary>
                public uint ThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ThreadId..]);

                /// <summary>
                /// Creates a new AutoBoostEntryExhaustionData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public AutoBoostEntryExhaustionData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_LockAddress = -1;
                    _offset_ThreadId = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a SubProcessTagChanged event.
        /// </summary>
        public readonly ref struct SubProcessTagChangedEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SubProcessTagChanged";

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
                Opcode = (EtwEventOpcode)Opcodes.SubProcessTagChanged,
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
            public SubProcessTagChangedData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new SubProcessTagChangedEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SubProcessTagChangedEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a SubProcessTagChanged event.
            /// </summary>
            public ref struct SubProcessTagChangedData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_OldTag;
                private int _offset_NewTag;

                private int Offset_OldTag
                {
                    get
                    {
                        if (_offset_OldTag == -1)
                        {
                            _offset_OldTag = 0;
                        }

                        return _offset_OldTag;
                    }
                }

                private int Offset_NewTag
                {
                    get
                    {
                        if (_offset_NewTag == -1)
                        {
                            _offset_NewTag = Offset_OldTag + 4;
                        }

                        return _offset_NewTag;
                    }
                }

                /// <summary>
                /// Retrieves the OldTag field.
                /// </summary>
                public uint OldTag => BitConverter.ToUInt32(_etwEvent.Data[Offset_OldTag..]);

                /// <summary>
                /// Retrieves the NewTag field.
                /// </summary>
                public uint NewTag => BitConverter.ToUInt32(_etwEvent.Data[Offset_NewTag..]);

                /// <summary>
                /// Creates a new SubProcessTagChangedData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public SubProcessTagChangedData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_OldTag = -1;
                    _offset_NewTag = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Start event.
        /// </summary>
        public readonly ref struct StartEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Start";

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
                Version = 3,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = EtwEventOpcode.Start,
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
            public StartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new StartEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public StartEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a Start event.
            /// </summary>
            public ref struct StartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProcessId;
                private int _offset_TThreadId;
                private int _offset_StackBase;
                private int _offset_StackLimit;
                private int _offset_UserStackBase;
                private int _offset_UserStackLimit;
                private int _offset_Affinity;
                private int _offset_Win32StartAddr;
                private int _offset_TebBase;
                private int _offset_SubProcessTag;
                private int _offset_BasePriority;
                private int _offset_PagePriority;
                private int _offset_IoPriority;
                private int _offset_ThreadFlags;

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = 0;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_TThreadId
                {
                    get
                    {
                        if (_offset_TThreadId == -1)
                        {
                            _offset_TThreadId = Offset_ProcessId + 4;
                        }

                        return _offset_TThreadId;
                    }
                }

                private int Offset_StackBase
                {
                    get
                    {
                        if (_offset_StackBase == -1)
                        {
                            _offset_StackBase = Offset_TThreadId + 4;
                        }

                        return _offset_StackBase;
                    }
                }

                private int Offset_StackLimit
                {
                    get
                    {
                        if (_offset_StackLimit == -1)
                        {
                            _offset_StackLimit = Offset_StackBase + _etwEvent.AddressSize;
                        }

                        return _offset_StackLimit;
                    }
                }

                private int Offset_UserStackBase
                {
                    get
                    {
                        if (_offset_UserStackBase == -1)
                        {
                            _offset_UserStackBase = Offset_StackLimit + _etwEvent.AddressSize;
                        }

                        return _offset_UserStackBase;
                    }
                }

                private int Offset_UserStackLimit
                {
                    get
                    {
                        if (_offset_UserStackLimit == -1)
                        {
                            _offset_UserStackLimit = Offset_UserStackBase + _etwEvent.AddressSize;
                        }

                        return _offset_UserStackLimit;
                    }
                }

                private int Offset_Affinity
                {
                    get
                    {
                        if (_offset_Affinity == -1)
                        {
                            _offset_Affinity = Offset_UserStackLimit + _etwEvent.AddressSize;
                        }

                        return _offset_Affinity;
                    }
                }

                private int Offset_Win32StartAddr
                {
                    get
                    {
                        if (_offset_Win32StartAddr == -1)
                        {
                            _offset_Win32StartAddr = Offset_Affinity + _etwEvent.AddressSize;
                        }

                        return _offset_Win32StartAddr;
                    }
                }

                private int Offset_TebBase
                {
                    get
                    {
                        if (_offset_TebBase == -1)
                        {
                            _offset_TebBase = Offset_Win32StartAddr + _etwEvent.AddressSize;
                        }

                        return _offset_TebBase;
                    }
                }

                private int Offset_SubProcessTag
                {
                    get
                    {
                        if (_offset_SubProcessTag == -1)
                        {
                            _offset_SubProcessTag = Offset_TebBase + _etwEvent.AddressSize;
                        }

                        return _offset_SubProcessTag;
                    }
                }

                private int Offset_BasePriority
                {
                    get
                    {
                        if (_offset_BasePriority == -1)
                        {
                            _offset_BasePriority = Offset_SubProcessTag + 4;
                        }

                        return _offset_BasePriority;
                    }
                }

                private int Offset_PagePriority
                {
                    get
                    {
                        if (_offset_PagePriority == -1)
                        {
                            _offset_PagePriority = Offset_BasePriority + 1;
                        }

                        return _offset_PagePriority;
                    }
                }

                private int Offset_IoPriority
                {
                    get
                    {
                        if (_offset_IoPriority == -1)
                        {
                            _offset_IoPriority = Offset_PagePriority + 1;
                        }

                        return _offset_IoPriority;
                    }
                }

                private int Offset_ThreadFlags
                {
                    get
                    {
                        if (_offset_ThreadFlags == -1)
                        {
                            _offset_ThreadFlags = Offset_IoPriority + 1;
                        }

                        return _offset_ThreadFlags;
                    }
                }

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..]);

                /// <summary>
                /// Retrieves the TThreadId field.
                /// </summary>
                public uint TThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_TThreadId..]);

                /// <summary>
                /// Retrieves the StackBase field.
                /// </summary>
                public ulong StackBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_StackBase..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_StackBase..]);

                /// <summary>
                /// Retrieves the StackLimit field.
                /// </summary>
                public ulong StackLimit => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_StackLimit..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_StackLimit..]);

                /// <summary>
                /// Retrieves the UserStackBase field.
                /// </summary>
                public ulong UserStackBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_UserStackBase..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_UserStackBase..]);

                /// <summary>
                /// Retrieves the UserStackLimit field.
                /// </summary>
                public ulong UserStackLimit => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_UserStackLimit..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_UserStackLimit..]);

                /// <summary>
                /// Retrieves the Affinity field.
                /// </summary>
                public ulong Affinity => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Affinity..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Affinity..]);

                /// <summary>
                /// Retrieves the Win32StartAddr field.
                /// </summary>
                public ulong Win32StartAddr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Win32StartAddr..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Win32StartAddr..]);

                /// <summary>
                /// Retrieves the TebBase field.
                /// </summary>
                public ulong TebBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_TebBase..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_TebBase..]);

                /// <summary>
                /// Retrieves the SubProcessTag field.
                /// </summary>
                public uint SubProcessTag => BitConverter.ToUInt32(_etwEvent.Data[Offset_SubProcessTag..]);

                /// <summary>
                /// Retrieves the BasePriority field.
                /// </summary>
                public byte BasePriority => _etwEvent.Data[Offset_BasePriority];

                /// <summary>
                /// Retrieves the PagePriority field.
                /// </summary>
                public byte PagePriority => _etwEvent.Data[Offset_PagePriority];

                /// <summary>
                /// Retrieves the IoPriority field.
                /// </summary>
                public byte IoPriority => _etwEvent.Data[Offset_IoPriority];

                /// <summary>
                /// Retrieves the ThreadFlags field.
                /// </summary>
                public byte ThreadFlags => _etwEvent.Data[Offset_ThreadFlags];

                /// <summary>
                /// Creates a new StartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public StartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProcessId = -1;
                    _offset_TThreadId = -1;
                    _offset_StackBase = -1;
                    _offset_StackLimit = -1;
                    _offset_UserStackBase = -1;
                    _offset_UserStackLimit = -1;
                    _offset_Affinity = -1;
                    _offset_Win32StartAddr = -1;
                    _offset_TebBase = -1;
                    _offset_SubProcessTag = -1;
                    _offset_BasePriority = -1;
                    _offset_PagePriority = -1;
                    _offset_IoPriority = -1;
                    _offset_ThreadFlags = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a End event.
        /// </summary>
        public readonly ref struct EndEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "End";

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
                Version = 3,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = EtwEventOpcode.End,
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
            public EndData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new EndEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public EndEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a End event.
            /// </summary>
            public ref struct EndData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProcessId;
                private int _offset_TThreadId;
                private int _offset_StackBase;
                private int _offset_StackLimit;
                private int _offset_UserStackBase;
                private int _offset_UserStackLimit;
                private int _offset_Affinity;
                private int _offset_Win32StartAddr;
                private int _offset_TebBase;
                private int _offset_SubProcessTag;
                private int _offset_BasePriority;
                private int _offset_PagePriority;
                private int _offset_IoPriority;
                private int _offset_ThreadFlags;

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = 0;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_TThreadId
                {
                    get
                    {
                        if (_offset_TThreadId == -1)
                        {
                            _offset_TThreadId = Offset_ProcessId + 4;
                        }

                        return _offset_TThreadId;
                    }
                }

                private int Offset_StackBase
                {
                    get
                    {
                        if (_offset_StackBase == -1)
                        {
                            _offset_StackBase = Offset_TThreadId + 4;
                        }

                        return _offset_StackBase;
                    }
                }

                private int Offset_StackLimit
                {
                    get
                    {
                        if (_offset_StackLimit == -1)
                        {
                            _offset_StackLimit = Offset_StackBase + _etwEvent.AddressSize;
                        }

                        return _offset_StackLimit;
                    }
                }

                private int Offset_UserStackBase
                {
                    get
                    {
                        if (_offset_UserStackBase == -1)
                        {
                            _offset_UserStackBase = Offset_StackLimit + _etwEvent.AddressSize;
                        }

                        return _offset_UserStackBase;
                    }
                }

                private int Offset_UserStackLimit
                {
                    get
                    {
                        if (_offset_UserStackLimit == -1)
                        {
                            _offset_UserStackLimit = Offset_UserStackBase + _etwEvent.AddressSize;
                        }

                        return _offset_UserStackLimit;
                    }
                }

                private int Offset_Affinity
                {
                    get
                    {
                        if (_offset_Affinity == -1)
                        {
                            _offset_Affinity = Offset_UserStackLimit + _etwEvent.AddressSize;
                        }

                        return _offset_Affinity;
                    }
                }

                private int Offset_Win32StartAddr
                {
                    get
                    {
                        if (_offset_Win32StartAddr == -1)
                        {
                            _offset_Win32StartAddr = Offset_Affinity + _etwEvent.AddressSize;
                        }

                        return _offset_Win32StartAddr;
                    }
                }

                private int Offset_TebBase
                {
                    get
                    {
                        if (_offset_TebBase == -1)
                        {
                            _offset_TebBase = Offset_Win32StartAddr + _etwEvent.AddressSize;
                        }

                        return _offset_TebBase;
                    }
                }

                private int Offset_SubProcessTag
                {
                    get
                    {
                        if (_offset_SubProcessTag == -1)
                        {
                            _offset_SubProcessTag = Offset_TebBase + _etwEvent.AddressSize;
                        }

                        return _offset_SubProcessTag;
                    }
                }

                private int Offset_BasePriority
                {
                    get
                    {
                        if (_offset_BasePriority == -1)
                        {
                            _offset_BasePriority = Offset_SubProcessTag + 4;
                        }

                        return _offset_BasePriority;
                    }
                }

                private int Offset_PagePriority
                {
                    get
                    {
                        if (_offset_PagePriority == -1)
                        {
                            _offset_PagePriority = Offset_BasePriority + 1;
                        }

                        return _offset_PagePriority;
                    }
                }

                private int Offset_IoPriority
                {
                    get
                    {
                        if (_offset_IoPriority == -1)
                        {
                            _offset_IoPriority = Offset_PagePriority + 1;
                        }

                        return _offset_IoPriority;
                    }
                }

                private int Offset_ThreadFlags
                {
                    get
                    {
                        if (_offset_ThreadFlags == -1)
                        {
                            _offset_ThreadFlags = Offset_IoPriority + 1;
                        }

                        return _offset_ThreadFlags;
                    }
                }

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..]);

                /// <summary>
                /// Retrieves the TThreadId field.
                /// </summary>
                public uint TThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_TThreadId..]);

                /// <summary>
                /// Retrieves the StackBase field.
                /// </summary>
                public ulong StackBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_StackBase..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_StackBase..]);

                /// <summary>
                /// Retrieves the StackLimit field.
                /// </summary>
                public ulong StackLimit => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_StackLimit..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_StackLimit..]);

                /// <summary>
                /// Retrieves the UserStackBase field.
                /// </summary>
                public ulong UserStackBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_UserStackBase..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_UserStackBase..]);

                /// <summary>
                /// Retrieves the UserStackLimit field.
                /// </summary>
                public ulong UserStackLimit => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_UserStackLimit..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_UserStackLimit..]);

                /// <summary>
                /// Retrieves the Affinity field.
                /// </summary>
                public ulong Affinity => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Affinity..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Affinity..]);

                /// <summary>
                /// Retrieves the Win32StartAddr field.
                /// </summary>
                public ulong Win32StartAddr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Win32StartAddr..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Win32StartAddr..]);

                /// <summary>
                /// Retrieves the TebBase field.
                /// </summary>
                public ulong TebBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_TebBase..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_TebBase..]);

                /// <summary>
                /// Retrieves the SubProcessTag field.
                /// </summary>
                public uint SubProcessTag => BitConverter.ToUInt32(_etwEvent.Data[Offset_SubProcessTag..]);

                /// <summary>
                /// Retrieves the BasePriority field.
                /// </summary>
                public byte BasePriority => _etwEvent.Data[Offset_BasePriority];

                /// <summary>
                /// Retrieves the PagePriority field.
                /// </summary>
                public byte PagePriority => _etwEvent.Data[Offset_PagePriority];

                /// <summary>
                /// Retrieves the IoPriority field.
                /// </summary>
                public byte IoPriority => _etwEvent.Data[Offset_IoPriority];

                /// <summary>
                /// Retrieves the ThreadFlags field.
                /// </summary>
                public byte ThreadFlags => _etwEvent.Data[Offset_ThreadFlags];

                /// <summary>
                /// Creates a new EndData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public EndData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProcessId = -1;
                    _offset_TThreadId = -1;
                    _offset_StackBase = -1;
                    _offset_StackLimit = -1;
                    _offset_UserStackBase = -1;
                    _offset_UserStackLimit = -1;
                    _offset_Affinity = -1;
                    _offset_Win32StartAddr = -1;
                    _offset_TebBase = -1;
                    _offset_SubProcessTag = -1;
                    _offset_BasePriority = -1;
                    _offset_PagePriority = -1;
                    _offset_IoPriority = -1;
                    _offset_ThreadFlags = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DCStart event.
        /// </summary>
        public readonly ref struct DCStartEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DCStart";

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
                Version = 3,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = EtwEventOpcode.DataCollectionStart,
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
            public DCStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DCStartEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DCStartEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a DCStart event.
            /// </summary>
            public ref struct DCStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProcessId;
                private int _offset_TThreadId;
                private int _offset_StackBase;
                private int _offset_StackLimit;
                private int _offset_UserStackBase;
                private int _offset_UserStackLimit;
                private int _offset_Affinity;
                private int _offset_Win32StartAddr;
                private int _offset_TebBase;
                private int _offset_SubProcessTag;
                private int _offset_BasePriority;
                private int _offset_PagePriority;
                private int _offset_IoPriority;
                private int _offset_ThreadFlags;

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = 0;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_TThreadId
                {
                    get
                    {
                        if (_offset_TThreadId == -1)
                        {
                            _offset_TThreadId = Offset_ProcessId + 4;
                        }

                        return _offset_TThreadId;
                    }
                }

                private int Offset_StackBase
                {
                    get
                    {
                        if (_offset_StackBase == -1)
                        {
                            _offset_StackBase = Offset_TThreadId + 4;
                        }

                        return _offset_StackBase;
                    }
                }

                private int Offset_StackLimit
                {
                    get
                    {
                        if (_offset_StackLimit == -1)
                        {
                            _offset_StackLimit = Offset_StackBase + _etwEvent.AddressSize;
                        }

                        return _offset_StackLimit;
                    }
                }

                private int Offset_UserStackBase
                {
                    get
                    {
                        if (_offset_UserStackBase == -1)
                        {
                            _offset_UserStackBase = Offset_StackLimit + _etwEvent.AddressSize;
                        }

                        return _offset_UserStackBase;
                    }
                }

                private int Offset_UserStackLimit
                {
                    get
                    {
                        if (_offset_UserStackLimit == -1)
                        {
                            _offset_UserStackLimit = Offset_UserStackBase + _etwEvent.AddressSize;
                        }

                        return _offset_UserStackLimit;
                    }
                }

                private int Offset_Affinity
                {
                    get
                    {
                        if (_offset_Affinity == -1)
                        {
                            _offset_Affinity = Offset_UserStackLimit + _etwEvent.AddressSize;
                        }

                        return _offset_Affinity;
                    }
                }

                private int Offset_Win32StartAddr
                {
                    get
                    {
                        if (_offset_Win32StartAddr == -1)
                        {
                            _offset_Win32StartAddr = Offset_Affinity + _etwEvent.AddressSize;
                        }

                        return _offset_Win32StartAddr;
                    }
                }

                private int Offset_TebBase
                {
                    get
                    {
                        if (_offset_TebBase == -1)
                        {
                            _offset_TebBase = Offset_Win32StartAddr + _etwEvent.AddressSize;
                        }

                        return _offset_TebBase;
                    }
                }

                private int Offset_SubProcessTag
                {
                    get
                    {
                        if (_offset_SubProcessTag == -1)
                        {
                            _offset_SubProcessTag = Offset_TebBase + _etwEvent.AddressSize;
                        }

                        return _offset_SubProcessTag;
                    }
                }

                private int Offset_BasePriority
                {
                    get
                    {
                        if (_offset_BasePriority == -1)
                        {
                            _offset_BasePriority = Offset_SubProcessTag + 4;
                        }

                        return _offset_BasePriority;
                    }
                }

                private int Offset_PagePriority
                {
                    get
                    {
                        if (_offset_PagePriority == -1)
                        {
                            _offset_PagePriority = Offset_BasePriority + 1;
                        }

                        return _offset_PagePriority;
                    }
                }

                private int Offset_IoPriority
                {
                    get
                    {
                        if (_offset_IoPriority == -1)
                        {
                            _offset_IoPriority = Offset_PagePriority + 1;
                        }

                        return _offset_IoPriority;
                    }
                }

                private int Offset_ThreadFlags
                {
                    get
                    {
                        if (_offset_ThreadFlags == -1)
                        {
                            _offset_ThreadFlags = Offset_IoPriority + 1;
                        }

                        return _offset_ThreadFlags;
                    }
                }

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..]);

                /// <summary>
                /// Retrieves the TThreadId field.
                /// </summary>
                public uint TThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_TThreadId..]);

                /// <summary>
                /// Retrieves the StackBase field.
                /// </summary>
                public ulong StackBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_StackBase..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_StackBase..]);

                /// <summary>
                /// Retrieves the StackLimit field.
                /// </summary>
                public ulong StackLimit => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_StackLimit..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_StackLimit..]);

                /// <summary>
                /// Retrieves the UserStackBase field.
                /// </summary>
                public ulong UserStackBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_UserStackBase..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_UserStackBase..]);

                /// <summary>
                /// Retrieves the UserStackLimit field.
                /// </summary>
                public ulong UserStackLimit => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_UserStackLimit..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_UserStackLimit..]);

                /// <summary>
                /// Retrieves the Affinity field.
                /// </summary>
                public ulong Affinity => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Affinity..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Affinity..]);

                /// <summary>
                /// Retrieves the Win32StartAddr field.
                /// </summary>
                public ulong Win32StartAddr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Win32StartAddr..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Win32StartAddr..]);

                /// <summary>
                /// Retrieves the TebBase field.
                /// </summary>
                public ulong TebBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_TebBase..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_TebBase..]);

                /// <summary>
                /// Retrieves the SubProcessTag field.
                /// </summary>
                public uint SubProcessTag => BitConverter.ToUInt32(_etwEvent.Data[Offset_SubProcessTag..]);

                /// <summary>
                /// Retrieves the BasePriority field.
                /// </summary>
                public byte BasePriority => _etwEvent.Data[Offset_BasePriority];

                /// <summary>
                /// Retrieves the PagePriority field.
                /// </summary>
                public byte PagePriority => _etwEvent.Data[Offset_PagePriority];

                /// <summary>
                /// Retrieves the IoPriority field.
                /// </summary>
                public byte IoPriority => _etwEvent.Data[Offset_IoPriority];

                /// <summary>
                /// Retrieves the ThreadFlags field.
                /// </summary>
                public byte ThreadFlags => _etwEvent.Data[Offset_ThreadFlags];

                /// <summary>
                /// Creates a new DCStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DCStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProcessId = -1;
                    _offset_TThreadId = -1;
                    _offset_StackBase = -1;
                    _offset_StackLimit = -1;
                    _offset_UserStackBase = -1;
                    _offset_UserStackLimit = -1;
                    _offset_Affinity = -1;
                    _offset_Win32StartAddr = -1;
                    _offset_TebBase = -1;
                    _offset_SubProcessTag = -1;
                    _offset_BasePriority = -1;
                    _offset_PagePriority = -1;
                    _offset_IoPriority = -1;
                    _offset_ThreadFlags = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DCEnd event.
        /// </summary>
        public readonly ref struct DCEndEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DCEnd";

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
                Version = 3,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = EtwEventOpcode.DataCollectionEnd,
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
            public DCEndData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DCEndEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DCEndEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a DCEnd event.
            /// </summary>
            public ref struct DCEndData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProcessId;
                private int _offset_TThreadId;
                private int _offset_StackBase;
                private int _offset_StackLimit;
                private int _offset_UserStackBase;
                private int _offset_UserStackLimit;
                private int _offset_Affinity;
                private int _offset_Win32StartAddr;
                private int _offset_TebBase;
                private int _offset_SubProcessTag;
                private int _offset_BasePriority;
                private int _offset_PagePriority;
                private int _offset_IoPriority;
                private int _offset_ThreadFlags;

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = 0;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_TThreadId
                {
                    get
                    {
                        if (_offset_TThreadId == -1)
                        {
                            _offset_TThreadId = Offset_ProcessId + 4;
                        }

                        return _offset_TThreadId;
                    }
                }

                private int Offset_StackBase
                {
                    get
                    {
                        if (_offset_StackBase == -1)
                        {
                            _offset_StackBase = Offset_TThreadId + 4;
                        }

                        return _offset_StackBase;
                    }
                }

                private int Offset_StackLimit
                {
                    get
                    {
                        if (_offset_StackLimit == -1)
                        {
                            _offset_StackLimit = Offset_StackBase + _etwEvent.AddressSize;
                        }

                        return _offset_StackLimit;
                    }
                }

                private int Offset_UserStackBase
                {
                    get
                    {
                        if (_offset_UserStackBase == -1)
                        {
                            _offset_UserStackBase = Offset_StackLimit + _etwEvent.AddressSize;
                        }

                        return _offset_UserStackBase;
                    }
                }

                private int Offset_UserStackLimit
                {
                    get
                    {
                        if (_offset_UserStackLimit == -1)
                        {
                            _offset_UserStackLimit = Offset_UserStackBase + _etwEvent.AddressSize;
                        }

                        return _offset_UserStackLimit;
                    }
                }

                private int Offset_Affinity
                {
                    get
                    {
                        if (_offset_Affinity == -1)
                        {
                            _offset_Affinity = Offset_UserStackLimit + _etwEvent.AddressSize;
                        }

                        return _offset_Affinity;
                    }
                }

                private int Offset_Win32StartAddr
                {
                    get
                    {
                        if (_offset_Win32StartAddr == -1)
                        {
                            _offset_Win32StartAddr = Offset_Affinity + _etwEvent.AddressSize;
                        }

                        return _offset_Win32StartAddr;
                    }
                }

                private int Offset_TebBase
                {
                    get
                    {
                        if (_offset_TebBase == -1)
                        {
                            _offset_TebBase = Offset_Win32StartAddr + _etwEvent.AddressSize;
                        }

                        return _offset_TebBase;
                    }
                }

                private int Offset_SubProcessTag
                {
                    get
                    {
                        if (_offset_SubProcessTag == -1)
                        {
                            _offset_SubProcessTag = Offset_TebBase + _etwEvent.AddressSize;
                        }

                        return _offset_SubProcessTag;
                    }
                }

                private int Offset_BasePriority
                {
                    get
                    {
                        if (_offset_BasePriority == -1)
                        {
                            _offset_BasePriority = Offset_SubProcessTag + 4;
                        }

                        return _offset_BasePriority;
                    }
                }

                private int Offset_PagePriority
                {
                    get
                    {
                        if (_offset_PagePriority == -1)
                        {
                            _offset_PagePriority = Offset_BasePriority + 1;
                        }

                        return _offset_PagePriority;
                    }
                }

                private int Offset_IoPriority
                {
                    get
                    {
                        if (_offset_IoPriority == -1)
                        {
                            _offset_IoPriority = Offset_PagePriority + 1;
                        }

                        return _offset_IoPriority;
                    }
                }

                private int Offset_ThreadFlags
                {
                    get
                    {
                        if (_offset_ThreadFlags == -1)
                        {
                            _offset_ThreadFlags = Offset_IoPriority + 1;
                        }

                        return _offset_ThreadFlags;
                    }
                }

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..]);

                /// <summary>
                /// Retrieves the TThreadId field.
                /// </summary>
                public uint TThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_TThreadId..]);

                /// <summary>
                /// Retrieves the StackBase field.
                /// </summary>
                public ulong StackBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_StackBase..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_StackBase..]);

                /// <summary>
                /// Retrieves the StackLimit field.
                /// </summary>
                public ulong StackLimit => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_StackLimit..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_StackLimit..]);

                /// <summary>
                /// Retrieves the UserStackBase field.
                /// </summary>
                public ulong UserStackBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_UserStackBase..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_UserStackBase..]);

                /// <summary>
                /// Retrieves the UserStackLimit field.
                /// </summary>
                public ulong UserStackLimit => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_UserStackLimit..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_UserStackLimit..]);

                /// <summary>
                /// Retrieves the Affinity field.
                /// </summary>
                public ulong Affinity => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Affinity..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Affinity..]);

                /// <summary>
                /// Retrieves the Win32StartAddr field.
                /// </summary>
                public ulong Win32StartAddr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Win32StartAddr..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Win32StartAddr..]);

                /// <summary>
                /// Retrieves the TebBase field.
                /// </summary>
                public ulong TebBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_TebBase..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_TebBase..]);

                /// <summary>
                /// Retrieves the SubProcessTag field.
                /// </summary>
                public uint SubProcessTag => BitConverter.ToUInt32(_etwEvent.Data[Offset_SubProcessTag..]);

                /// <summary>
                /// Retrieves the BasePriority field.
                /// </summary>
                public byte BasePriority => _etwEvent.Data[Offset_BasePriority];

                /// <summary>
                /// Retrieves the PagePriority field.
                /// </summary>
                public byte PagePriority => _etwEvent.Data[Offset_PagePriority];

                /// <summary>
                /// Retrieves the IoPriority field.
                /// </summary>
                public byte IoPriority => _etwEvent.Data[Offset_IoPriority];

                /// <summary>
                /// Retrieves the ThreadFlags field.
                /// </summary>
                public byte ThreadFlags => _etwEvent.Data[Offset_ThreadFlags];

                /// <summary>
                /// Creates a new DCEndData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DCEndData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProcessId = -1;
                    _offset_TThreadId = -1;
                    _offset_StackBase = -1;
                    _offset_StackLimit = -1;
                    _offset_UserStackBase = -1;
                    _offset_UserStackLimit = -1;
                    _offset_Affinity = -1;
                    _offset_Win32StartAddr = -1;
                    _offset_TebBase = -1;
                    _offset_SubProcessTag = -1;
                    _offset_BasePriority = -1;
                    _offset_PagePriority = -1;
                    _offset_IoPriority = -1;
                    _offset_ThreadFlags = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a SetPriority event.
        /// </summary>
        public readonly ref struct SetPriorityEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SetPriority";

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
                Version = 3,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.SetPriority,
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
            public SetPriorityData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new SetPriorityEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SetPriorityEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a SetPriority event.
            /// </summary>
            public ref struct SetPriorityData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ThreadId;
                private int _offset_OldPriority;
                private int _offset_NewPriority;
                private int _offset_Reserved;

                private int Offset_ThreadId
                {
                    get
                    {
                        if (_offset_ThreadId == -1)
                        {
                            _offset_ThreadId = 0;
                        }

                        return _offset_ThreadId;
                    }
                }

                private int Offset_OldPriority
                {
                    get
                    {
                        if (_offset_OldPriority == -1)
                        {
                            _offset_OldPriority = Offset_ThreadId + 4;
                        }

                        return _offset_OldPriority;
                    }
                }

                private int Offset_NewPriority
                {
                    get
                    {
                        if (_offset_NewPriority == -1)
                        {
                            _offset_NewPriority = Offset_OldPriority + 1;
                        }

                        return _offset_NewPriority;
                    }
                }

                private int Offset_Reserved
                {
                    get
                    {
                        if (_offset_Reserved == -1)
                        {
                            _offset_Reserved = Offset_NewPriority + 1;
                        }

                        return _offset_Reserved;
                    }
                }

                /// <summary>
                /// Retrieves the ThreadId field.
                /// </summary>
                public uint ThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ThreadId..]);

                /// <summary>
                /// Retrieves the OldPriority field.
                /// </summary>
                public byte OldPriority => _etwEvent.Data[Offset_OldPriority];

                /// <summary>
                /// Retrieves the NewPriority field.
                /// </summary>
                public byte NewPriority => _etwEvent.Data[Offset_NewPriority];

                /// <summary>
                /// Retrieves the Reserved field.
                /// </summary>
                public ushort Reserved => BitConverter.ToUInt16(_etwEvent.Data[Offset_Reserved..]);

                /// <summary>
                /// Creates a new SetPriorityData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public SetPriorityData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ThreadId = -1;
                    _offset_OldPriority = -1;
                    _offset_NewPriority = -1;
                    _offset_Reserved = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a SetBasePriority event.
        /// </summary>
        public readonly ref struct SetBasePriorityEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SetBasePriority";

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
                Version = 3,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.SetBasePriority,
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
            public SetBasePriorityData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new SetBasePriorityEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SetBasePriorityEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a SetBasePriority event.
            /// </summary>
            public ref struct SetBasePriorityData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ThreadId;
                private int _offset_OldPriority;
                private int _offset_NewPriority;
                private int _offset_Reserved;

                private int Offset_ThreadId
                {
                    get
                    {
                        if (_offset_ThreadId == -1)
                        {
                            _offset_ThreadId = 0;
                        }

                        return _offset_ThreadId;
                    }
                }

                private int Offset_OldPriority
                {
                    get
                    {
                        if (_offset_OldPriority == -1)
                        {
                            _offset_OldPriority = Offset_ThreadId + 4;
                        }

                        return _offset_OldPriority;
                    }
                }

                private int Offset_NewPriority
                {
                    get
                    {
                        if (_offset_NewPriority == -1)
                        {
                            _offset_NewPriority = Offset_OldPriority + 1;
                        }

                        return _offset_NewPriority;
                    }
                }

                private int Offset_Reserved
                {
                    get
                    {
                        if (_offset_Reserved == -1)
                        {
                            _offset_Reserved = Offset_NewPriority + 1;
                        }

                        return _offset_Reserved;
                    }
                }

                /// <summary>
                /// Retrieves the ThreadId field.
                /// </summary>
                public uint ThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ThreadId..]);

                /// <summary>
                /// Retrieves the OldPriority field.
                /// </summary>
                public byte OldPriority => _etwEvent.Data[Offset_OldPriority];

                /// <summary>
                /// Retrieves the NewPriority field.
                /// </summary>
                public byte NewPriority => _etwEvent.Data[Offset_NewPriority];

                /// <summary>
                /// Retrieves the Reserved field.
                /// </summary>
                public ushort Reserved => BitConverter.ToUInt16(_etwEvent.Data[Offset_Reserved..]);

                /// <summary>
                /// Creates a new SetBasePriorityData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public SetBasePriorityData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ThreadId = -1;
                    _offset_OldPriority = -1;
                    _offset_NewPriority = -1;
                    _offset_Reserved = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a SetPagePriority event.
        /// </summary>
        public readonly ref struct SetPagePriorityEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SetPagePriority";

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
                Version = 3,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.SetPagePriority,
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
            public SetPagePriorityData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new SetPagePriorityEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SetPagePriorityEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a SetPagePriority event.
            /// </summary>
            public ref struct SetPagePriorityData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ThreadId;
                private int _offset_OldPriority;
                private int _offset_NewPriority;
                private int _offset_Reserved;

                private int Offset_ThreadId
                {
                    get
                    {
                        if (_offset_ThreadId == -1)
                        {
                            _offset_ThreadId = 0;
                        }

                        return _offset_ThreadId;
                    }
                }

                private int Offset_OldPriority
                {
                    get
                    {
                        if (_offset_OldPriority == -1)
                        {
                            _offset_OldPriority = Offset_ThreadId + 4;
                        }

                        return _offset_OldPriority;
                    }
                }

                private int Offset_NewPriority
                {
                    get
                    {
                        if (_offset_NewPriority == -1)
                        {
                            _offset_NewPriority = Offset_OldPriority + 1;
                        }

                        return _offset_NewPriority;
                    }
                }

                private int Offset_Reserved
                {
                    get
                    {
                        if (_offset_Reserved == -1)
                        {
                            _offset_Reserved = Offset_NewPriority + 1;
                        }

                        return _offset_Reserved;
                    }
                }

                /// <summary>
                /// Retrieves the ThreadId field.
                /// </summary>
                public uint ThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ThreadId..]);

                /// <summary>
                /// Retrieves the OldPriority field.
                /// </summary>
                public byte OldPriority => _etwEvent.Data[Offset_OldPriority];

                /// <summary>
                /// Retrieves the NewPriority field.
                /// </summary>
                public byte NewPriority => _etwEvent.Data[Offset_NewPriority];

                /// <summary>
                /// Retrieves the Reserved field.
                /// </summary>
                public ushort Reserved => BitConverter.ToUInt16(_etwEvent.Data[Offset_Reserved..]);

                /// <summary>
                /// Creates a new SetPagePriorityData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public SetPagePriorityData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ThreadId = -1;
                    _offset_OldPriority = -1;
                    _offset_NewPriority = -1;
                    _offset_Reserved = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a SetIoPriority event.
        /// </summary>
        public readonly ref struct SetIoPriorityEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SetIoPriority";

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
                Version = 3,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.SetIoPriority,
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
            public SetIoPriorityData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new SetIoPriorityEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SetIoPriorityEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a SetIoPriority event.
            /// </summary>
            public ref struct SetIoPriorityData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ThreadId;
                private int _offset_OldPriority;
                private int _offset_NewPriority;
                private int _offset_Reserved;

                private int Offset_ThreadId
                {
                    get
                    {
                        if (_offset_ThreadId == -1)
                        {
                            _offset_ThreadId = 0;
                        }

                        return _offset_ThreadId;
                    }
                }

                private int Offset_OldPriority
                {
                    get
                    {
                        if (_offset_OldPriority == -1)
                        {
                            _offset_OldPriority = Offset_ThreadId + 4;
                        }

                        return _offset_OldPriority;
                    }
                }

                private int Offset_NewPriority
                {
                    get
                    {
                        if (_offset_NewPriority == -1)
                        {
                            _offset_NewPriority = Offset_OldPriority + 1;
                        }

                        return _offset_NewPriority;
                    }
                }

                private int Offset_Reserved
                {
                    get
                    {
                        if (_offset_Reserved == -1)
                        {
                            _offset_Reserved = Offset_NewPriority + 1;
                        }

                        return _offset_Reserved;
                    }
                }

                /// <summary>
                /// Retrieves the ThreadId field.
                /// </summary>
                public uint ThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ThreadId..]);

                /// <summary>
                /// Retrieves the OldPriority field.
                /// </summary>
                public byte OldPriority => _etwEvent.Data[Offset_OldPriority];

                /// <summary>
                /// Retrieves the NewPriority field.
                /// </summary>
                public byte NewPriority => _etwEvent.Data[Offset_NewPriority];

                /// <summary>
                /// Retrieves the Reserved field.
                /// </summary>
                public ushort Reserved => BitConverter.ToUInt16(_etwEvent.Data[Offset_Reserved..]);

                /// <summary>
                /// Creates a new SetIoPriorityData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public SetIoPriorityData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ThreadId = -1;
                    _offset_OldPriority = -1;
                    _offset_NewPriority = -1;
                    _offset_Reserved = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a CSwitch event.
        /// </summary>
        public readonly ref struct CSwitchEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "CSwitch";

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
                Version = 3,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.CSwitch,
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
            public CSwitchData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new CSwitchEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public CSwitchEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a CSwitch event.
            /// </summary>
            public ref struct CSwitchData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_NewThreadId;
                private int _offset_OldThreadId;
                private int _offset_NewThreadPriority;
                private int _offset_OldThreadPriority;
                private int _offset_PreviousCState;
                private int _offset_SpareByte;
                private int _offset_OldThreadWaitReason;
                private int _offset_ThreadFlags;
                private int _offset_OldThreadState;
                private int _offset_OldThreadWaitIdealProcessor;
                private int _offset_NewThreadWaitTime;
                private int _offset_Reserved;

                private int Offset_NewThreadId
                {
                    get
                    {
                        if (_offset_NewThreadId == -1)
                        {
                            _offset_NewThreadId = 0;
                        }

                        return _offset_NewThreadId;
                    }
                }

                private int Offset_OldThreadId
                {
                    get
                    {
                        if (_offset_OldThreadId == -1)
                        {
                            _offset_OldThreadId = Offset_NewThreadId + 4;
                        }

                        return _offset_OldThreadId;
                    }
                }

                private int Offset_NewThreadPriority
                {
                    get
                    {
                        if (_offset_NewThreadPriority == -1)
                        {
                            _offset_NewThreadPriority = Offset_OldThreadId + 4;
                        }

                        return _offset_NewThreadPriority;
                    }
                }

                private int Offset_OldThreadPriority
                {
                    get
                    {
                        if (_offset_OldThreadPriority == -1)
                        {
                            _offset_OldThreadPriority = Offset_NewThreadPriority + 1;
                        }

                        return _offset_OldThreadPriority;
                    }
                }

                private int Offset_PreviousCState
                {
                    get
                    {
                        if (_offset_PreviousCState == -1)
                        {
                            _offset_PreviousCState = Offset_OldThreadPriority + 1;
                        }

                        return _offset_PreviousCState;
                    }
                }

                private int Offset_SpareByte
                {
                    get
                    {
                        if (_offset_SpareByte == -1)
                        {
                            _offset_SpareByte = Offset_PreviousCState + 1;
                        }

                        return _offset_SpareByte;
                    }
                }

                private int Offset_OldThreadWaitReason
                {
                    get
                    {
                        if (_offset_OldThreadWaitReason == -1)
                        {
                            _offset_OldThreadWaitReason = Offset_SpareByte + 1;
                        }

                        return _offset_OldThreadWaitReason;
                    }
                }

                private int Offset_ThreadFlags
                {
                    get
                    {
                        if (_offset_ThreadFlags == -1)
                        {
                            _offset_ThreadFlags = Offset_OldThreadWaitReason + 1;
                        }

                        return _offset_ThreadFlags;
                    }
                }

                private int Offset_OldThreadState
                {
                    get
                    {
                        if (_offset_OldThreadState == -1)
                        {
                            _offset_OldThreadState = Offset_ThreadFlags + 1;
                        }

                        return _offset_OldThreadState;
                    }
                }

                private int Offset_OldThreadWaitIdealProcessor
                {
                    get
                    {
                        if (_offset_OldThreadWaitIdealProcessor == -1)
                        {
                            _offset_OldThreadWaitIdealProcessor = Offset_OldThreadState + 1;
                        }

                        return _offset_OldThreadWaitIdealProcessor;
                    }
                }

                private int Offset_NewThreadWaitTime
                {
                    get
                    {
                        if (_offset_NewThreadWaitTime == -1)
                        {
                            _offset_NewThreadWaitTime = Offset_OldThreadWaitIdealProcessor + 1;
                        }

                        return _offset_NewThreadWaitTime;
                    }
                }

                private int Offset_Reserved
                {
                    get
                    {
                        if (_offset_Reserved == -1)
                        {
                            _offset_Reserved = Offset_NewThreadWaitTime + 4;
                        }

                        return _offset_Reserved;
                    }
                }

                /// <summary>
                /// Retrieves the NewThreadId field.
                /// </summary>
                public uint NewThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_NewThreadId..]);

                /// <summary>
                /// Retrieves the OldThreadId field.
                /// </summary>
                public uint OldThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_OldThreadId..]);

                /// <summary>
                /// Retrieves the NewThreadPriority field.
                /// </summary>
                public sbyte NewThreadPriority => (sbyte)_etwEvent.Data[Offset_NewThreadPriority];

                /// <summary>
                /// Retrieves the OldThreadPriority field.
                /// </summary>
                public sbyte OldThreadPriority => (sbyte)_etwEvent.Data[Offset_OldThreadPriority];

                /// <summary>
                /// Retrieves the PreviousCState field.
                /// </summary>
                public byte PreviousCState => _etwEvent.Data[Offset_PreviousCState];

                /// <summary>
                /// Retrieves the SpareByte field.
                /// </summary>
                public sbyte SpareByte => (sbyte)_etwEvent.Data[Offset_SpareByte];

                /// <summary>
                /// Retrieves the OldThreadWaitReason field.
                /// </summary>
                public sbyte OldThreadWaitReason => (sbyte)_etwEvent.Data[Offset_OldThreadWaitReason];

                /// <summary>
                /// Retrieves the ThreadFlags field.
                /// </summary>
                public sbyte ThreadFlags => (sbyte)_etwEvent.Data[Offset_ThreadFlags];

                /// <summary>
                /// Retrieves the OldThreadState field.
                /// </summary>
                public sbyte OldThreadState => (sbyte)_etwEvent.Data[Offset_OldThreadState];

                /// <summary>
                /// Retrieves the OldThreadWaitIdealProcessor field.
                /// </summary>
                public sbyte OldThreadWaitIdealProcessor => (sbyte)_etwEvent.Data[Offset_OldThreadWaitIdealProcessor];

                /// <summary>
                /// Retrieves the NewThreadWaitTime field.
                /// </summary>
                public uint NewThreadWaitTime => BitConverter.ToUInt32(_etwEvent.Data[Offset_NewThreadWaitTime..]);

                /// <summary>
                /// Retrieves the Reserved field.
                /// </summary>
                public uint Reserved => BitConverter.ToUInt32(_etwEvent.Data[Offset_Reserved..]);

                /// <summary>
                /// Creates a new CSwitchData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public CSwitchData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_NewThreadId = -1;
                    _offset_OldThreadId = -1;
                    _offset_NewThreadPriority = -1;
                    _offset_OldThreadPriority = -1;
                    _offset_PreviousCState = -1;
                    _offset_SpareByte = -1;
                    _offset_OldThreadWaitReason = -1;
                    _offset_ThreadFlags = -1;
                    _offset_OldThreadState = -1;
                    _offset_OldThreadWaitIdealProcessor = -1;
                    _offset_NewThreadWaitTime = -1;
                    _offset_Reserved = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Start event.
        /// </summary>
        public readonly ref struct StartEventV4
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Start";

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
                Version = 4,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = EtwEventOpcode.Start,
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
            public StartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new StartEventV4.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public StartEventV4(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a Start event.
            /// </summary>
            public ref struct StartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProcessId;
                private int _offset_TThreadId;
                private int _offset_StackBase;
                private int _offset_StackLimit;
                private int _offset_UserStackBase;
                private int _offset_UserStackLimit;
                private int _offset_Affinity;
                private int _offset_Win32StartAddr;
                private int _offset_TebBase;
                private int _offset_SubProcessTag;
                private int _offset_BasePriority;
                private int _offset_PagePriority;
                private int _offset_IoPriority;
                private int _offset_ThreadFlags;
                private int _offset_ThreadName;

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = 0;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_TThreadId
                {
                    get
                    {
                        if (_offset_TThreadId == -1)
                        {
                            _offset_TThreadId = Offset_ProcessId + 4;
                        }

                        return _offset_TThreadId;
                    }
                }

                private int Offset_StackBase
                {
                    get
                    {
                        if (_offset_StackBase == -1)
                        {
                            _offset_StackBase = Offset_TThreadId + 4;
                        }

                        return _offset_StackBase;
                    }
                }

                private int Offset_StackLimit
                {
                    get
                    {
                        if (_offset_StackLimit == -1)
                        {
                            _offset_StackLimit = Offset_StackBase + _etwEvent.AddressSize;
                        }

                        return _offset_StackLimit;
                    }
                }

                private int Offset_UserStackBase
                {
                    get
                    {
                        if (_offset_UserStackBase == -1)
                        {
                            _offset_UserStackBase = Offset_StackLimit + _etwEvent.AddressSize;
                        }

                        return _offset_UserStackBase;
                    }
                }

                private int Offset_UserStackLimit
                {
                    get
                    {
                        if (_offset_UserStackLimit == -1)
                        {
                            _offset_UserStackLimit = Offset_UserStackBase + _etwEvent.AddressSize;
                        }

                        return _offset_UserStackLimit;
                    }
                }

                private int Offset_Affinity
                {
                    get
                    {
                        if (_offset_Affinity == -1)
                        {
                            _offset_Affinity = Offset_UserStackLimit + _etwEvent.AddressSize;
                        }

                        return _offset_Affinity;
                    }
                }

                private int Offset_Win32StartAddr
                {
                    get
                    {
                        if (_offset_Win32StartAddr == -1)
                        {
                            _offset_Win32StartAddr = Offset_Affinity + _etwEvent.AddressSize;
                        }

                        return _offset_Win32StartAddr;
                    }
                }

                private int Offset_TebBase
                {
                    get
                    {
                        if (_offset_TebBase == -1)
                        {
                            _offset_TebBase = Offset_Win32StartAddr + _etwEvent.AddressSize;
                        }

                        return _offset_TebBase;
                    }
                }

                private int Offset_SubProcessTag
                {
                    get
                    {
                        if (_offset_SubProcessTag == -1)
                        {
                            _offset_SubProcessTag = Offset_TebBase + _etwEvent.AddressSize;
                        }

                        return _offset_SubProcessTag;
                    }
                }

                private int Offset_BasePriority
                {
                    get
                    {
                        if (_offset_BasePriority == -1)
                        {
                            _offset_BasePriority = Offset_SubProcessTag + 4;
                        }

                        return _offset_BasePriority;
                    }
                }

                private int Offset_PagePriority
                {
                    get
                    {
                        if (_offset_PagePriority == -1)
                        {
                            _offset_PagePriority = Offset_BasePriority + 1;
                        }

                        return _offset_PagePriority;
                    }
                }

                private int Offset_IoPriority
                {
                    get
                    {
                        if (_offset_IoPriority == -1)
                        {
                            _offset_IoPriority = Offset_PagePriority + 1;
                        }

                        return _offset_IoPriority;
                    }
                }

                private int Offset_ThreadFlags
                {
                    get
                    {
                        if (_offset_ThreadFlags == -1)
                        {
                            _offset_ThreadFlags = Offset_IoPriority + 1;
                        }

                        return _offset_ThreadFlags;
                    }
                }

                private int Offset_ThreadName
                {
                    get
                    {
                        if (_offset_ThreadName == -1)
                        {
                            _offset_ThreadName = Offset_ThreadFlags + 1;
                        }

                        return _offset_ThreadName;
                    }
                }

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..]);

                /// <summary>
                /// Retrieves the TThreadId field.
                /// </summary>
                public uint TThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_TThreadId..]);

                /// <summary>
                /// Retrieves the StackBase field.
                /// </summary>
                public ulong StackBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_StackBase..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_StackBase..]);

                /// <summary>
                /// Retrieves the StackLimit field.
                /// </summary>
                public ulong StackLimit => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_StackLimit..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_StackLimit..]);

                /// <summary>
                /// Retrieves the UserStackBase field.
                /// </summary>
                public ulong UserStackBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_UserStackBase..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_UserStackBase..]);

                /// <summary>
                /// Retrieves the UserStackLimit field.
                /// </summary>
                public ulong UserStackLimit => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_UserStackLimit..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_UserStackLimit..]);

                /// <summary>
                /// Retrieves the Affinity field.
                /// </summary>
                public ulong Affinity => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Affinity..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Affinity..]);

                /// <summary>
                /// Retrieves the Win32StartAddr field.
                /// </summary>
                public ulong Win32StartAddr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Win32StartAddr..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Win32StartAddr..]);

                /// <summary>
                /// Retrieves the TebBase field.
                /// </summary>
                public ulong TebBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_TebBase..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_TebBase..]);

                /// <summary>
                /// Retrieves the SubProcessTag field.
                /// </summary>
                public uint SubProcessTag => BitConverter.ToUInt32(_etwEvent.Data[Offset_SubProcessTag..]);

                /// <summary>
                /// Retrieves the BasePriority field.
                /// </summary>
                public byte BasePriority => _etwEvent.Data[Offset_BasePriority];

                /// <summary>
                /// Retrieves the PagePriority field.
                /// </summary>
                public byte PagePriority => _etwEvent.Data[Offset_PagePriority];

                /// <summary>
                /// Retrieves the IoPriority field.
                /// </summary>
                public byte IoPriority => _etwEvent.Data[Offset_IoPriority];

                /// <summary>
                /// Retrieves the ThreadFlags field.
                /// </summary>
                public byte ThreadFlags => _etwEvent.Data[Offset_ThreadFlags];

                /// <summary>
                /// Retrieves the ThreadName field.
                /// </summary>
                public string ThreadName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ThreadName..]);

                /// <summary>
                /// Creates a new StartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public StartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProcessId = -1;
                    _offset_TThreadId = -1;
                    _offset_StackBase = -1;
                    _offset_StackLimit = -1;
                    _offset_UserStackBase = -1;
                    _offset_UserStackLimit = -1;
                    _offset_Affinity = -1;
                    _offset_Win32StartAddr = -1;
                    _offset_TebBase = -1;
                    _offset_SubProcessTag = -1;
                    _offset_BasePriority = -1;
                    _offset_PagePriority = -1;
                    _offset_IoPriority = -1;
                    _offset_ThreadFlags = -1;
                    _offset_ThreadName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a End event.
        /// </summary>
        public readonly ref struct EndEventV4
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "End";

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
                Version = 4,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = EtwEventOpcode.End,
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
            public EndData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new EndEventV4.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public EndEventV4(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a End event.
            /// </summary>
            public ref struct EndData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProcessId;
                private int _offset_TThreadId;
                private int _offset_StackBase;
                private int _offset_StackLimit;
                private int _offset_UserStackBase;
                private int _offset_UserStackLimit;
                private int _offset_Affinity;
                private int _offset_Win32StartAddr;
                private int _offset_TebBase;
                private int _offset_SubProcessTag;
                private int _offset_BasePriority;
                private int _offset_PagePriority;
                private int _offset_IoPriority;
                private int _offset_ThreadFlags;
                private int _offset_ThreadName;

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = 0;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_TThreadId
                {
                    get
                    {
                        if (_offset_TThreadId == -1)
                        {
                            _offset_TThreadId = Offset_ProcessId + 4;
                        }

                        return _offset_TThreadId;
                    }
                }

                private int Offset_StackBase
                {
                    get
                    {
                        if (_offset_StackBase == -1)
                        {
                            _offset_StackBase = Offset_TThreadId + 4;
                        }

                        return _offset_StackBase;
                    }
                }

                private int Offset_StackLimit
                {
                    get
                    {
                        if (_offset_StackLimit == -1)
                        {
                            _offset_StackLimit = Offset_StackBase + _etwEvent.AddressSize;
                        }

                        return _offset_StackLimit;
                    }
                }

                private int Offset_UserStackBase
                {
                    get
                    {
                        if (_offset_UserStackBase == -1)
                        {
                            _offset_UserStackBase = Offset_StackLimit + _etwEvent.AddressSize;
                        }

                        return _offset_UserStackBase;
                    }
                }

                private int Offset_UserStackLimit
                {
                    get
                    {
                        if (_offset_UserStackLimit == -1)
                        {
                            _offset_UserStackLimit = Offset_UserStackBase + _etwEvent.AddressSize;
                        }

                        return _offset_UserStackLimit;
                    }
                }

                private int Offset_Affinity
                {
                    get
                    {
                        if (_offset_Affinity == -1)
                        {
                            _offset_Affinity = Offset_UserStackLimit + _etwEvent.AddressSize;
                        }

                        return _offset_Affinity;
                    }
                }

                private int Offset_Win32StartAddr
                {
                    get
                    {
                        if (_offset_Win32StartAddr == -1)
                        {
                            _offset_Win32StartAddr = Offset_Affinity + _etwEvent.AddressSize;
                        }

                        return _offset_Win32StartAddr;
                    }
                }

                private int Offset_TebBase
                {
                    get
                    {
                        if (_offset_TebBase == -1)
                        {
                            _offset_TebBase = Offset_Win32StartAddr + _etwEvent.AddressSize;
                        }

                        return _offset_TebBase;
                    }
                }

                private int Offset_SubProcessTag
                {
                    get
                    {
                        if (_offset_SubProcessTag == -1)
                        {
                            _offset_SubProcessTag = Offset_TebBase + _etwEvent.AddressSize;
                        }

                        return _offset_SubProcessTag;
                    }
                }

                private int Offset_BasePriority
                {
                    get
                    {
                        if (_offset_BasePriority == -1)
                        {
                            _offset_BasePriority = Offset_SubProcessTag + 4;
                        }

                        return _offset_BasePriority;
                    }
                }

                private int Offset_PagePriority
                {
                    get
                    {
                        if (_offset_PagePriority == -1)
                        {
                            _offset_PagePriority = Offset_BasePriority + 1;
                        }

                        return _offset_PagePriority;
                    }
                }

                private int Offset_IoPriority
                {
                    get
                    {
                        if (_offset_IoPriority == -1)
                        {
                            _offset_IoPriority = Offset_PagePriority + 1;
                        }

                        return _offset_IoPriority;
                    }
                }

                private int Offset_ThreadFlags
                {
                    get
                    {
                        if (_offset_ThreadFlags == -1)
                        {
                            _offset_ThreadFlags = Offset_IoPriority + 1;
                        }

                        return _offset_ThreadFlags;
                    }
                }

                private int Offset_ThreadName
                {
                    get
                    {
                        if (_offset_ThreadName == -1)
                        {
                            _offset_ThreadName = Offset_ThreadFlags + 1;
                        }

                        return _offset_ThreadName;
                    }
                }

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..]);

                /// <summary>
                /// Retrieves the TThreadId field.
                /// </summary>
                public uint TThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_TThreadId..]);

                /// <summary>
                /// Retrieves the StackBase field.
                /// </summary>
                public ulong StackBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_StackBase..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_StackBase..]);

                /// <summary>
                /// Retrieves the StackLimit field.
                /// </summary>
                public ulong StackLimit => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_StackLimit..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_StackLimit..]);

                /// <summary>
                /// Retrieves the UserStackBase field.
                /// </summary>
                public ulong UserStackBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_UserStackBase..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_UserStackBase..]);

                /// <summary>
                /// Retrieves the UserStackLimit field.
                /// </summary>
                public ulong UserStackLimit => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_UserStackLimit..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_UserStackLimit..]);

                /// <summary>
                /// Retrieves the Affinity field.
                /// </summary>
                public ulong Affinity => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Affinity..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Affinity..]);

                /// <summary>
                /// Retrieves the Win32StartAddr field.
                /// </summary>
                public ulong Win32StartAddr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Win32StartAddr..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Win32StartAddr..]);

                /// <summary>
                /// Retrieves the TebBase field.
                /// </summary>
                public ulong TebBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_TebBase..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_TebBase..]);

                /// <summary>
                /// Retrieves the SubProcessTag field.
                /// </summary>
                public uint SubProcessTag => BitConverter.ToUInt32(_etwEvent.Data[Offset_SubProcessTag..]);

                /// <summary>
                /// Retrieves the BasePriority field.
                /// </summary>
                public byte BasePriority => _etwEvent.Data[Offset_BasePriority];

                /// <summary>
                /// Retrieves the PagePriority field.
                /// </summary>
                public byte PagePriority => _etwEvent.Data[Offset_PagePriority];

                /// <summary>
                /// Retrieves the IoPriority field.
                /// </summary>
                public byte IoPriority => _etwEvent.Data[Offset_IoPriority];

                /// <summary>
                /// Retrieves the ThreadFlags field.
                /// </summary>
                public byte ThreadFlags => _etwEvent.Data[Offset_ThreadFlags];

                /// <summary>
                /// Retrieves the ThreadName field.
                /// </summary>
                public string ThreadName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ThreadName..]);

                /// <summary>
                /// Creates a new EndData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public EndData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProcessId = -1;
                    _offset_TThreadId = -1;
                    _offset_StackBase = -1;
                    _offset_StackLimit = -1;
                    _offset_UserStackBase = -1;
                    _offset_UserStackLimit = -1;
                    _offset_Affinity = -1;
                    _offset_Win32StartAddr = -1;
                    _offset_TebBase = -1;
                    _offset_SubProcessTag = -1;
                    _offset_BasePriority = -1;
                    _offset_PagePriority = -1;
                    _offset_IoPriority = -1;
                    _offset_ThreadFlags = -1;
                    _offset_ThreadName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DCStart event.
        /// </summary>
        public readonly ref struct DCStartEventV4
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DCStart";

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
                Version = 4,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = EtwEventOpcode.DataCollectionStart,
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
            public DCStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DCStartEventV4.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DCStartEventV4(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a DCStart event.
            /// </summary>
            public ref struct DCStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProcessId;
                private int _offset_TThreadId;
                private int _offset_StackBase;
                private int _offset_StackLimit;
                private int _offset_UserStackBase;
                private int _offset_UserStackLimit;
                private int _offset_Affinity;
                private int _offset_Win32StartAddr;
                private int _offset_TebBase;
                private int _offset_SubProcessTag;
                private int _offset_BasePriority;
                private int _offset_PagePriority;
                private int _offset_IoPriority;
                private int _offset_ThreadFlags;
                private int _offset_ThreadName;

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = 0;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_TThreadId
                {
                    get
                    {
                        if (_offset_TThreadId == -1)
                        {
                            _offset_TThreadId = Offset_ProcessId + 4;
                        }

                        return _offset_TThreadId;
                    }
                }

                private int Offset_StackBase
                {
                    get
                    {
                        if (_offset_StackBase == -1)
                        {
                            _offset_StackBase = Offset_TThreadId + 4;
                        }

                        return _offset_StackBase;
                    }
                }

                private int Offset_StackLimit
                {
                    get
                    {
                        if (_offset_StackLimit == -1)
                        {
                            _offset_StackLimit = Offset_StackBase + _etwEvent.AddressSize;
                        }

                        return _offset_StackLimit;
                    }
                }

                private int Offset_UserStackBase
                {
                    get
                    {
                        if (_offset_UserStackBase == -1)
                        {
                            _offset_UserStackBase = Offset_StackLimit + _etwEvent.AddressSize;
                        }

                        return _offset_UserStackBase;
                    }
                }

                private int Offset_UserStackLimit
                {
                    get
                    {
                        if (_offset_UserStackLimit == -1)
                        {
                            _offset_UserStackLimit = Offset_UserStackBase + _etwEvent.AddressSize;
                        }

                        return _offset_UserStackLimit;
                    }
                }

                private int Offset_Affinity
                {
                    get
                    {
                        if (_offset_Affinity == -1)
                        {
                            _offset_Affinity = Offset_UserStackLimit + _etwEvent.AddressSize;
                        }

                        return _offset_Affinity;
                    }
                }

                private int Offset_Win32StartAddr
                {
                    get
                    {
                        if (_offset_Win32StartAddr == -1)
                        {
                            _offset_Win32StartAddr = Offset_Affinity + _etwEvent.AddressSize;
                        }

                        return _offset_Win32StartAddr;
                    }
                }

                private int Offset_TebBase
                {
                    get
                    {
                        if (_offset_TebBase == -1)
                        {
                            _offset_TebBase = Offset_Win32StartAddr + _etwEvent.AddressSize;
                        }

                        return _offset_TebBase;
                    }
                }

                private int Offset_SubProcessTag
                {
                    get
                    {
                        if (_offset_SubProcessTag == -1)
                        {
                            _offset_SubProcessTag = Offset_TebBase + _etwEvent.AddressSize;
                        }

                        return _offset_SubProcessTag;
                    }
                }

                private int Offset_BasePriority
                {
                    get
                    {
                        if (_offset_BasePriority == -1)
                        {
                            _offset_BasePriority = Offset_SubProcessTag + 4;
                        }

                        return _offset_BasePriority;
                    }
                }

                private int Offset_PagePriority
                {
                    get
                    {
                        if (_offset_PagePriority == -1)
                        {
                            _offset_PagePriority = Offset_BasePriority + 1;
                        }

                        return _offset_PagePriority;
                    }
                }

                private int Offset_IoPriority
                {
                    get
                    {
                        if (_offset_IoPriority == -1)
                        {
                            _offset_IoPriority = Offset_PagePriority + 1;
                        }

                        return _offset_IoPriority;
                    }
                }

                private int Offset_ThreadFlags
                {
                    get
                    {
                        if (_offset_ThreadFlags == -1)
                        {
                            _offset_ThreadFlags = Offset_IoPriority + 1;
                        }

                        return _offset_ThreadFlags;
                    }
                }

                private int Offset_ThreadName
                {
                    get
                    {
                        if (_offset_ThreadName == -1)
                        {
                            _offset_ThreadName = Offset_ThreadFlags + 1;
                        }

                        return _offset_ThreadName;
                    }
                }

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..]);

                /// <summary>
                /// Retrieves the TThreadId field.
                /// </summary>
                public uint TThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_TThreadId..]);

                /// <summary>
                /// Retrieves the StackBase field.
                /// </summary>
                public ulong StackBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_StackBase..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_StackBase..]);

                /// <summary>
                /// Retrieves the StackLimit field.
                /// </summary>
                public ulong StackLimit => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_StackLimit..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_StackLimit..]);

                /// <summary>
                /// Retrieves the UserStackBase field.
                /// </summary>
                public ulong UserStackBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_UserStackBase..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_UserStackBase..]);

                /// <summary>
                /// Retrieves the UserStackLimit field.
                /// </summary>
                public ulong UserStackLimit => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_UserStackLimit..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_UserStackLimit..]);

                /// <summary>
                /// Retrieves the Affinity field.
                /// </summary>
                public ulong Affinity => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Affinity..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Affinity..]);

                /// <summary>
                /// Retrieves the Win32StartAddr field.
                /// </summary>
                public ulong Win32StartAddr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Win32StartAddr..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Win32StartAddr..]);

                /// <summary>
                /// Retrieves the TebBase field.
                /// </summary>
                public ulong TebBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_TebBase..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_TebBase..]);

                /// <summary>
                /// Retrieves the SubProcessTag field.
                /// </summary>
                public uint SubProcessTag => BitConverter.ToUInt32(_etwEvent.Data[Offset_SubProcessTag..]);

                /// <summary>
                /// Retrieves the BasePriority field.
                /// </summary>
                public byte BasePriority => _etwEvent.Data[Offset_BasePriority];

                /// <summary>
                /// Retrieves the PagePriority field.
                /// </summary>
                public byte PagePriority => _etwEvent.Data[Offset_PagePriority];

                /// <summary>
                /// Retrieves the IoPriority field.
                /// </summary>
                public byte IoPriority => _etwEvent.Data[Offset_IoPriority];

                /// <summary>
                /// Retrieves the ThreadFlags field.
                /// </summary>
                public byte ThreadFlags => _etwEvent.Data[Offset_ThreadFlags];

                /// <summary>
                /// Retrieves the ThreadName field.
                /// </summary>
                public string ThreadName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ThreadName..]);

                /// <summary>
                /// Creates a new DCStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DCStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProcessId = -1;
                    _offset_TThreadId = -1;
                    _offset_StackBase = -1;
                    _offset_StackLimit = -1;
                    _offset_UserStackBase = -1;
                    _offset_UserStackLimit = -1;
                    _offset_Affinity = -1;
                    _offset_Win32StartAddr = -1;
                    _offset_TebBase = -1;
                    _offset_SubProcessTag = -1;
                    _offset_BasePriority = -1;
                    _offset_PagePriority = -1;
                    _offset_IoPriority = -1;
                    _offset_ThreadFlags = -1;
                    _offset_ThreadName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DCEnd event.
        /// </summary>
        public readonly ref struct DCEndEventV4
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DCEnd";

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
                Version = 4,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = EtwEventOpcode.DataCollectionEnd,
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
            public DCEndData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DCEndEventV4.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DCEndEventV4(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a DCEnd event.
            /// </summary>
            public ref struct DCEndData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProcessId;
                private int _offset_TThreadId;
                private int _offset_StackBase;
                private int _offset_StackLimit;
                private int _offset_UserStackBase;
                private int _offset_UserStackLimit;
                private int _offset_Affinity;
                private int _offset_Win32StartAddr;
                private int _offset_TebBase;
                private int _offset_SubProcessTag;
                private int _offset_BasePriority;
                private int _offset_PagePriority;
                private int _offset_IoPriority;
                private int _offset_ThreadFlags;
                private int _offset_ThreadName;

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = 0;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_TThreadId
                {
                    get
                    {
                        if (_offset_TThreadId == -1)
                        {
                            _offset_TThreadId = Offset_ProcessId + 4;
                        }

                        return _offset_TThreadId;
                    }
                }

                private int Offset_StackBase
                {
                    get
                    {
                        if (_offset_StackBase == -1)
                        {
                            _offset_StackBase = Offset_TThreadId + 4;
                        }

                        return _offset_StackBase;
                    }
                }

                private int Offset_StackLimit
                {
                    get
                    {
                        if (_offset_StackLimit == -1)
                        {
                            _offset_StackLimit = Offset_StackBase + _etwEvent.AddressSize;
                        }

                        return _offset_StackLimit;
                    }
                }

                private int Offset_UserStackBase
                {
                    get
                    {
                        if (_offset_UserStackBase == -1)
                        {
                            _offset_UserStackBase = Offset_StackLimit + _etwEvent.AddressSize;
                        }

                        return _offset_UserStackBase;
                    }
                }

                private int Offset_UserStackLimit
                {
                    get
                    {
                        if (_offset_UserStackLimit == -1)
                        {
                            _offset_UserStackLimit = Offset_UserStackBase + _etwEvent.AddressSize;
                        }

                        return _offset_UserStackLimit;
                    }
                }

                private int Offset_Affinity
                {
                    get
                    {
                        if (_offset_Affinity == -1)
                        {
                            _offset_Affinity = Offset_UserStackLimit + _etwEvent.AddressSize;
                        }

                        return _offset_Affinity;
                    }
                }

                private int Offset_Win32StartAddr
                {
                    get
                    {
                        if (_offset_Win32StartAddr == -1)
                        {
                            _offset_Win32StartAddr = Offset_Affinity + _etwEvent.AddressSize;
                        }

                        return _offset_Win32StartAddr;
                    }
                }

                private int Offset_TebBase
                {
                    get
                    {
                        if (_offset_TebBase == -1)
                        {
                            _offset_TebBase = Offset_Win32StartAddr + _etwEvent.AddressSize;
                        }

                        return _offset_TebBase;
                    }
                }

                private int Offset_SubProcessTag
                {
                    get
                    {
                        if (_offset_SubProcessTag == -1)
                        {
                            _offset_SubProcessTag = Offset_TebBase + _etwEvent.AddressSize;
                        }

                        return _offset_SubProcessTag;
                    }
                }

                private int Offset_BasePriority
                {
                    get
                    {
                        if (_offset_BasePriority == -1)
                        {
                            _offset_BasePriority = Offset_SubProcessTag + 4;
                        }

                        return _offset_BasePriority;
                    }
                }

                private int Offset_PagePriority
                {
                    get
                    {
                        if (_offset_PagePriority == -1)
                        {
                            _offset_PagePriority = Offset_BasePriority + 1;
                        }

                        return _offset_PagePriority;
                    }
                }

                private int Offset_IoPriority
                {
                    get
                    {
                        if (_offset_IoPriority == -1)
                        {
                            _offset_IoPriority = Offset_PagePriority + 1;
                        }

                        return _offset_IoPriority;
                    }
                }

                private int Offset_ThreadFlags
                {
                    get
                    {
                        if (_offset_ThreadFlags == -1)
                        {
                            _offset_ThreadFlags = Offset_IoPriority + 1;
                        }

                        return _offset_ThreadFlags;
                    }
                }

                private int Offset_ThreadName
                {
                    get
                    {
                        if (_offset_ThreadName == -1)
                        {
                            _offset_ThreadName = Offset_ThreadFlags + 1;
                        }

                        return _offset_ThreadName;
                    }
                }

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..]);

                /// <summary>
                /// Retrieves the TThreadId field.
                /// </summary>
                public uint TThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_TThreadId..]);

                /// <summary>
                /// Retrieves the StackBase field.
                /// </summary>
                public ulong StackBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_StackBase..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_StackBase..]);

                /// <summary>
                /// Retrieves the StackLimit field.
                /// </summary>
                public ulong StackLimit => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_StackLimit..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_StackLimit..]);

                /// <summary>
                /// Retrieves the UserStackBase field.
                /// </summary>
                public ulong UserStackBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_UserStackBase..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_UserStackBase..]);

                /// <summary>
                /// Retrieves the UserStackLimit field.
                /// </summary>
                public ulong UserStackLimit => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_UserStackLimit..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_UserStackLimit..]);

                /// <summary>
                /// Retrieves the Affinity field.
                /// </summary>
                public ulong Affinity => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Affinity..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Affinity..]);

                /// <summary>
                /// Retrieves the Win32StartAddr field.
                /// </summary>
                public ulong Win32StartAddr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Win32StartAddr..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Win32StartAddr..]);

                /// <summary>
                /// Retrieves the TebBase field.
                /// </summary>
                public ulong TebBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_TebBase..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_TebBase..]);

                /// <summary>
                /// Retrieves the SubProcessTag field.
                /// </summary>
                public uint SubProcessTag => BitConverter.ToUInt32(_etwEvent.Data[Offset_SubProcessTag..]);

                /// <summary>
                /// Retrieves the BasePriority field.
                /// </summary>
                public byte BasePriority => _etwEvent.Data[Offset_BasePriority];

                /// <summary>
                /// Retrieves the PagePriority field.
                /// </summary>
                public byte PagePriority => _etwEvent.Data[Offset_PagePriority];

                /// <summary>
                /// Retrieves the IoPriority field.
                /// </summary>
                public byte IoPriority => _etwEvent.Data[Offset_IoPriority];

                /// <summary>
                /// Retrieves the ThreadFlags field.
                /// </summary>
                public byte ThreadFlags => _etwEvent.Data[Offset_ThreadFlags];

                /// <summary>
                /// Retrieves the ThreadName field.
                /// </summary>
                public string ThreadName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ThreadName..]);

                /// <summary>
                /// Creates a new DCEndData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DCEndData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProcessId = -1;
                    _offset_TThreadId = -1;
                    _offset_StackBase = -1;
                    _offset_StackLimit = -1;
                    _offset_UserStackBase = -1;
                    _offset_UserStackLimit = -1;
                    _offset_Affinity = -1;
                    _offset_Win32StartAddr = -1;
                    _offset_TebBase = -1;
                    _offset_SubProcessTag = -1;
                    _offset_BasePriority = -1;
                    _offset_PagePriority = -1;
                    _offset_IoPriority = -1;
                    _offset_ThreadFlags = -1;
                    _offset_ThreadName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a CSwitch event.
        /// </summary>
        public readonly ref struct CSwitchEventV4
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "CSwitch";

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
                Version = 4,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.CSwitch,
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
            public CSwitchData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new CSwitchEventV4.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public CSwitchEventV4(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a CSwitch event.
            /// </summary>
            public ref struct CSwitchData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_NewThreadId;
                private int _offset_OldThreadId;
                private int _offset_NewThreadPriority;
                private int _offset_OldThreadPriority;
                private int _offset_PreviousCState;
                private int _offset_SpareByte;
                private int _offset_OldThreadWaitReason;
                private int _offset_ThreadFlags;
                private int _offset_OldThreadState;
                private int _offset_OldThreadWaitIdealProcessor;
                private int _offset_NewThreadWaitTime;
                private int _offset_Reserved;

                private int Offset_NewThreadId
                {
                    get
                    {
                        if (_offset_NewThreadId == -1)
                        {
                            _offset_NewThreadId = 0;
                        }

                        return _offset_NewThreadId;
                    }
                }

                private int Offset_OldThreadId
                {
                    get
                    {
                        if (_offset_OldThreadId == -1)
                        {
                            _offset_OldThreadId = Offset_NewThreadId + 4;
                        }

                        return _offset_OldThreadId;
                    }
                }

                private int Offset_NewThreadPriority
                {
                    get
                    {
                        if (_offset_NewThreadPriority == -1)
                        {
                            _offset_NewThreadPriority = Offset_OldThreadId + 4;
                        }

                        return _offset_NewThreadPriority;
                    }
                }

                private int Offset_OldThreadPriority
                {
                    get
                    {
                        if (_offset_OldThreadPriority == -1)
                        {
                            _offset_OldThreadPriority = Offset_NewThreadPriority + 1;
                        }

                        return _offset_OldThreadPriority;
                    }
                }

                private int Offset_PreviousCState
                {
                    get
                    {
                        if (_offset_PreviousCState == -1)
                        {
                            _offset_PreviousCState = Offset_OldThreadPriority + 1;
                        }

                        return _offset_PreviousCState;
                    }
                }

                private int Offset_SpareByte
                {
                    get
                    {
                        if (_offset_SpareByte == -1)
                        {
                            _offset_SpareByte = Offset_PreviousCState + 1;
                        }

                        return _offset_SpareByte;
                    }
                }

                private int Offset_OldThreadWaitReason
                {
                    get
                    {
                        if (_offset_OldThreadWaitReason == -1)
                        {
                            _offset_OldThreadWaitReason = Offset_SpareByte + 1;
                        }

                        return _offset_OldThreadWaitReason;
                    }
                }

                private int Offset_ThreadFlags
                {
                    get
                    {
                        if (_offset_ThreadFlags == -1)
                        {
                            _offset_ThreadFlags = Offset_OldThreadWaitReason + 1;
                        }

                        return _offset_ThreadFlags;
                    }
                }

                private int Offset_OldThreadState
                {
                    get
                    {
                        if (_offset_OldThreadState == -1)
                        {
                            _offset_OldThreadState = Offset_ThreadFlags + 1;
                        }

                        return _offset_OldThreadState;
                    }
                }

                private int Offset_OldThreadWaitIdealProcessor
                {
                    get
                    {
                        if (_offset_OldThreadWaitIdealProcessor == -1)
                        {
                            _offset_OldThreadWaitIdealProcessor = Offset_OldThreadState + 1;
                        }

                        return _offset_OldThreadWaitIdealProcessor;
                    }
                }

                private int Offset_NewThreadWaitTime
                {
                    get
                    {
                        if (_offset_NewThreadWaitTime == -1)
                        {
                            _offset_NewThreadWaitTime = Offset_OldThreadWaitIdealProcessor + 1;
                        }

                        return _offset_NewThreadWaitTime;
                    }
                }

                private int Offset_Reserved
                {
                    get
                    {
                        if (_offset_Reserved == -1)
                        {
                            _offset_Reserved = Offset_NewThreadWaitTime + 4;
                        }

                        return _offset_Reserved;
                    }
                }

                /// <summary>
                /// Retrieves the NewThreadId field.
                /// </summary>
                public uint NewThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_NewThreadId..]);

                /// <summary>
                /// Retrieves the OldThreadId field.
                /// </summary>
                public uint OldThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_OldThreadId..]);

                /// <summary>
                /// Retrieves the NewThreadPriority field.
                /// </summary>
                public sbyte NewThreadPriority => (sbyte)_etwEvent.Data[Offset_NewThreadPriority];

                /// <summary>
                /// Retrieves the OldThreadPriority field.
                /// </summary>
                public sbyte OldThreadPriority => (sbyte)_etwEvent.Data[Offset_OldThreadPriority];

                /// <summary>
                /// Retrieves the PreviousCState field.
                /// </summary>
                public byte PreviousCState => _etwEvent.Data[Offset_PreviousCState];

                /// <summary>
                /// Retrieves the SpareByte field.
                /// </summary>
                public sbyte SpareByte => (sbyte)_etwEvent.Data[Offset_SpareByte];

                /// <summary>
                /// Retrieves the OldThreadWaitReason field.
                /// </summary>
                public sbyte OldThreadWaitReason => (sbyte)_etwEvent.Data[Offset_OldThreadWaitReason];

                /// <summary>
                /// Retrieves the ThreadFlags field.
                /// </summary>
                public sbyte ThreadFlags => (sbyte)_etwEvent.Data[Offset_ThreadFlags];

                /// <summary>
                /// Retrieves the OldThreadState field.
                /// </summary>
                public sbyte OldThreadState => (sbyte)_etwEvent.Data[Offset_OldThreadState];

                /// <summary>
                /// Retrieves the OldThreadWaitIdealProcessor field.
                /// </summary>
                public sbyte OldThreadWaitIdealProcessor => (sbyte)_etwEvent.Data[Offset_OldThreadWaitIdealProcessor];

                /// <summary>
                /// Retrieves the NewThreadWaitTime field.
                /// </summary>
                public uint NewThreadWaitTime => BitConverter.ToUInt32(_etwEvent.Data[Offset_NewThreadWaitTime..]);

                /// <summary>
                /// Retrieves the Reserved field.
                /// </summary>
                public uint Reserved => BitConverter.ToUInt32(_etwEvent.Data[Offset_Reserved..]);

                /// <summary>
                /// Creates a new CSwitchData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public CSwitchData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_NewThreadId = -1;
                    _offset_OldThreadId = -1;
                    _offset_NewThreadPriority = -1;
                    _offset_OldThreadPriority = -1;
                    _offset_PreviousCState = -1;
                    _offset_SpareByte = -1;
                    _offset_OldThreadWaitReason = -1;
                    _offset_ThreadFlags = -1;
                    _offset_OldThreadState = -1;
                    _offset_OldThreadWaitIdealProcessor = -1;
                    _offset_NewThreadWaitTime = -1;
                    _offset_Reserved = -1;
                }
            }

        }
    }
}
