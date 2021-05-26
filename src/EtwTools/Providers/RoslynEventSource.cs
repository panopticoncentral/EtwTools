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
    /// Provider for RoslynEventSource (bf965e67-c7fb-5c5b-d98f-cdf68f8154c2)
    /// </summary>
    public sealed class RoslynEventSourceProvider
    {
        /// <summary>s
        /// Provider ID.
        /// </summary>
        public static readonly Guid Id = new("bf965e67-c7fb-5c5b-d98f-cdf68f8154c2");

        /// <summary>
        /// Provider name.
        /// </summary>
        public const string Name = "RoslynEventSource";

        /// <summary>
        /// Tasks supported by RoslynEventSource.
        /// </summary>
        public enum Tasks : ushort
        {
            /// <summary>
            /// 'OnEventCommand' task.
            /// </summary>
            OnEventCommand = 65528,
            /// <summary>
            /// 'BlockCanceled' task.
            /// </summary>
            BlockCanceled = 65529,
            /// <summary>
            /// 'SendFunctionDefinitions' task.
            /// </summary>
            SendFunctionDefinitions = 65530,
            /// <summary>
            /// 'Block' task.
            /// </summary>
            Block = 65532,
            /// <summary>
            /// 'Log' task.
            /// </summary>
            Log = 65533,
            /// <summary>
            /// 'EventSourceMessage' task.
            /// </summary>
            EventSourceMessage = 65534,
        }

        /// <summary>
        /// Keywords supported by RoslynEventSource.
        /// </summary>
        [Flags]
        public enum Keywords : ulong
        {
            /// <summary>
            /// 'Session3' keyword.
            /// </summary>
            Session3 = 0x0000100000000000,
            /// <summary>
            /// 'Session2' keyword.
            /// </summary>
            Session2 = 0x0000200000000000,
            /// <summary>
            /// 'Session1' keyword.
            /// </summary>
            Session1 = 0x0000400000000000,
            /// <summary>
            /// 'Session0' keyword.
            /// </summary>
            Session0 = 0x0000800000000000,
        }

        /// <summary>
        /// An event wrapper for a EventSourceMessage event.
        /// </summary>
        public readonly ref struct EventSourceMessageEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "EventSourceMessage";

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
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.EventSourceMessage,
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
            public EventSourceMessageData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new EventSourceMessageEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public EventSourceMessageEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a EventSourceMessageEvent.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator EventSourceMessageEvent(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a EventSourceMessage event.
            /// </summary>
            public ref struct EventSourceMessageData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Message;

                private int Offset_Message
                {
                    get
                    {
                        if (_offset_Message == -1)
                        {
                            _offset_Message = 0;
                        }

                        return _offset_Message;
                    }
                }

                /// <summary>
                /// Retrieves the Message field.
                /// </summary>
                public string Message => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Message..^1]);

                /// <summary>
                /// Creates a new EventSourceMessageData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public EventSourceMessageData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Message = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Log event.
        /// </summary>
        public readonly ref struct LogEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Log";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 1,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.Log,
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
            public LogData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new LogEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public LogEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a LogEvent.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator LogEvent(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Log event.
            /// </summary>
            public ref struct LogData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Message;
                private int _offset_FunctionId;

                private int Offset_Message
                {
                    get
                    {
                        if (_offset_Message == -1)
                        {
                            _offset_Message = 0;
                        }

                        return _offset_Message;
                    }
                }

                private int Offset_FunctionId
                {
                    get
                    {
                        if (_offset_FunctionId == -1)
                        {
                            _offset_FunctionId = Offset_Message + _etwEvent.UnicodeStringLength(Offset_Message);
                        }

                        return _offset_FunctionId;
                    }
                }

                /// <summary>
                /// Retrieves the Message field.
                /// </summary>
                public string Message => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Message..(Offset_FunctionId - 1)]);

                /// <summary>
                /// Retrieves the FunctionId field.
                /// </summary>
                public FunctionId FunctionId => (FunctionId)BitConverter.ToUInt32(_etwEvent.Data[Offset_FunctionId..]);

                /// <summary>
                /// Creates a new LogData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public LogData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Message = -1;
                    _offset_FunctionId = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a BlockStart event.
        /// </summary>
        public readonly ref struct BlockStartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "BlockStart";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 2,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Start,
                Task = (ushort)Tasks.Block,
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
            public BlockStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new BlockStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public BlockStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a BlockStartEvent.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator BlockStartEvent(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a BlockStart event.
            /// </summary>
            public ref struct BlockStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Message;
                private int _offset_FunctionId;
                private int _offset_BlockId;

                private int Offset_Message
                {
                    get
                    {
                        if (_offset_Message == -1)
                        {
                            _offset_Message = 0;
                        }

                        return _offset_Message;
                    }
                }

                private int Offset_FunctionId
                {
                    get
                    {
                        if (_offset_FunctionId == -1)
                        {
                            _offset_FunctionId = Offset_Message + _etwEvent.UnicodeStringLength(Offset_Message);
                        }

                        return _offset_FunctionId;
                    }
                }

                private int Offset_BlockId
                {
                    get
                    {
                        if (_offset_BlockId == -1)
                        {
                            _offset_BlockId = Offset_FunctionId + 4;
                        }

                        return _offset_BlockId;
                    }
                }

                /// <summary>
                /// Retrieves the Message field.
                /// </summary>
                public string Message => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Message..(Offset_FunctionId - 1)]);

                /// <summary>
                /// Retrieves the FunctionId field.
                /// </summary>
                public FunctionId FunctionId => (FunctionId)BitConverter.ToUInt32(_etwEvent.Data[Offset_FunctionId..Offset_BlockId]);

                /// <summary>
                /// Retrieves the BlockId field.
                /// </summary>
                public int BlockId => BitConverter.ToInt32(_etwEvent.Data[Offset_BlockId..]);

                /// <summary>
                /// Creates a new BlockStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public BlockStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Message = -1;
                    _offset_FunctionId = -1;
                    _offset_BlockId = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a BlockStop event.
        /// </summary>
        public readonly ref struct BlockStopEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "BlockStop";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 3,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.End,
                Task = (ushort)Tasks.Block,
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
            public BlockStopData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new BlockStopEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public BlockStopEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a BlockStopEvent.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator BlockStopEvent(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a BlockStop event.
            /// </summary>
            public ref struct BlockStopData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_FunctionId;
                private int _offset_Tick;
                private int _offset_BlockId;

                private int Offset_FunctionId
                {
                    get
                    {
                        if (_offset_FunctionId == -1)
                        {
                            _offset_FunctionId = 0;
                        }

                        return _offset_FunctionId;
                    }
                }

                private int Offset_Tick
                {
                    get
                    {
                        if (_offset_Tick == -1)
                        {
                            _offset_Tick = Offset_FunctionId + 4;
                        }

                        return _offset_Tick;
                    }
                }

                private int Offset_BlockId
                {
                    get
                    {
                        if (_offset_BlockId == -1)
                        {
                            _offset_BlockId = Offset_Tick + 4;
                        }

                        return _offset_BlockId;
                    }
                }

                /// <summary>
                /// Retrieves the FunctionId field.
                /// </summary>
                public FunctionId FunctionId => (FunctionId)BitConverter.ToUInt32(_etwEvent.Data[Offset_FunctionId..Offset_Tick]);

                /// <summary>
                /// Retrieves the Tick field.
                /// </summary>
                public int Tick => BitConverter.ToInt32(_etwEvent.Data[Offset_Tick..Offset_BlockId]);

                /// <summary>
                /// Retrieves the BlockId field.
                /// </summary>
                public int BlockId => BitConverter.ToInt32(_etwEvent.Data[Offset_BlockId..]);

                /// <summary>
                /// Creates a new BlockStopData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public BlockStopData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_FunctionId = -1;
                    _offset_Tick = -1;
                    _offset_BlockId = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a SendFunctionDefinitions event.
        /// </summary>
        public readonly ref struct SendFunctionDefinitionsEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SendFunctionDefinitions";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 4,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.SendFunctionDefinitions,
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
            public SendFunctionDefinitionsData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new SendFunctionDefinitionsEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SendFunctionDefinitionsEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a SendFunctionDefinitionsEvent.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator SendFunctionDefinitionsEvent(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a SendFunctionDefinitions event.
            /// </summary>
            public ref struct SendFunctionDefinitionsData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Definitions;

                private int Offset_Definitions
                {
                    get
                    {
                        if (_offset_Definitions == -1)
                        {
                            _offset_Definitions = 0;
                        }

                        return _offset_Definitions;
                    }
                }

                /// <summary>
                /// Retrieves the Definitions field.
                /// </summary>
                public string Definitions => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Definitions..^1]);

                /// <summary>
                /// Creates a new SendFunctionDefinitionsData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public SendFunctionDefinitionsData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Definitions = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a BlockCanceled event.
        /// </summary>
        public readonly ref struct BlockCanceledEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "BlockCanceled";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 5,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.BlockCanceled,
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
            public BlockCanceledData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new BlockCanceledEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public BlockCanceledEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a BlockCanceledEvent.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator BlockCanceledEvent(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a BlockCanceled event.
            /// </summary>
            public ref struct BlockCanceledData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_FunctionId;
                private int _offset_Tick;
                private int _offset_BlockId;

                private int Offset_FunctionId
                {
                    get
                    {
                        if (_offset_FunctionId == -1)
                        {
                            _offset_FunctionId = 0;
                        }

                        return _offset_FunctionId;
                    }
                }

                private int Offset_Tick
                {
                    get
                    {
                        if (_offset_Tick == -1)
                        {
                            _offset_Tick = Offset_FunctionId + 4;
                        }

                        return _offset_Tick;
                    }
                }

                private int Offset_BlockId
                {
                    get
                    {
                        if (_offset_BlockId == -1)
                        {
                            _offset_BlockId = Offset_Tick + 4;
                        }

                        return _offset_BlockId;
                    }
                }

                /// <summary>
                /// Retrieves the FunctionId field.
                /// </summary>
                public FunctionId FunctionId => (FunctionId)BitConverter.ToUInt32(_etwEvent.Data[Offset_FunctionId..Offset_Tick]);

                /// <summary>
                /// Retrieves the Tick field.
                /// </summary>
                public int Tick => BitConverter.ToInt32(_etwEvent.Data[Offset_Tick..Offset_BlockId]);

                /// <summary>
                /// Retrieves the BlockId field.
                /// </summary>
                public int BlockId => BitConverter.ToInt32(_etwEvent.Data[Offset_BlockId..]);

                /// <summary>
                /// Creates a new BlockCanceledData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public BlockCanceledData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_FunctionId = -1;
                    _offset_Tick = -1;
                    _offset_BlockId = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a OnEventCommand event.
        /// </summary>
        public readonly ref struct OnEventCommandEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "OnEventCommand";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 6,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.OnEventCommand,
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
            /// Creates a new OnEventCommandEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public OnEventCommandEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a OnEventCommandEvent.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator OnEventCommandEvent(EtwEvent etwEvent) => new(etwEvent);
        }

        /// <summary>
        /// FunctionId.
        /// </summary>
        public enum FunctionId : ulong
        {
            /// <summary>
            /// TestEvent_NotUsed.
            /// </summary>
            TestEvent_NotUsed = 1,
            /// <summary>
            /// WorkCoordinator_DocumentWorker_Enqueue.
            /// </summary>
            WorkCoordinator_DocumentWorker_Enqueue = 2,
            /// <summary>
            /// WorkCoordinator_ProcessProjectAsync.
            /// </summary>
            WorkCoordinator_ProcessProjectAsync = 3,
            /// <summary>
            /// WorkCoordinator_ProcessDocumentAsync.
            /// </summary>
            WorkCoordinator_ProcessDocumentAsync = 4,
            /// <summary>
            /// WorkCoordinator_SemanticChange_Enqueue.
            /// </summary>
            WorkCoordinator_SemanticChange_Enqueue = 5,
            /// <summary>
            /// WorkCoordinator_SemanticChange_EnqueueFromMember.
            /// </summary>
            WorkCoordinator_SemanticChange_EnqueueFromMember = 6,
            /// <summary>
            /// WorkCoordinator_SemanticChange_EnqueueFromType.
            /// </summary>
            WorkCoordinator_SemanticChange_EnqueueFromType = 7,
            /// <summary>
            /// WorkCoordinator_SemanticChange_FullProjects.
            /// </summary>
            WorkCoordinator_SemanticChange_FullProjects = 8,
            /// <summary>
            /// WorkCoordinator_Project_Enqueue.
            /// </summary>
            WorkCoordinator_Project_Enqueue = 9,
            /// <summary>
            /// WorkCoordinator_AsyncWorkItemQueue_LastItem.
            /// </summary>
            WorkCoordinator_AsyncWorkItemQueue_LastItem = 10,
            /// <summary>
            /// WorkCoordinator_AsyncWorkItemQueue_FirstItem.
            /// </summary>
            WorkCoordinator_AsyncWorkItemQueue_FirstItem = 11,
            /// <summary>
            /// Diagnostics_SyntaxDiagnostic.
            /// </summary>
            Diagnostics_SyntaxDiagnostic = 12,
            /// <summary>
            /// Diagnostics_SemanticDiagnostic.
            /// </summary>
            Diagnostics_SemanticDiagnostic = 13,
            /// <summary>
            /// Diagnostics_ProjectDiagnostic.
            /// </summary>
            Diagnostics_ProjectDiagnostic = 14,
            /// <summary>
            /// Diagnostics_DocumentReset.
            /// </summary>
            Diagnostics_DocumentReset = 15,
            /// <summary>
            /// Diagnostics_DocumentOpen.
            /// </summary>
            Diagnostics_DocumentOpen = 16,
            /// <summary>
            /// Diagnostics_RemoveDocument.
            /// </summary>
            Diagnostics_RemoveDocument = 17,
            /// <summary>
            /// Diagnostics_RemoveProject.
            /// </summary>
            Diagnostics_RemoveProject = 18,
            /// <summary>
            /// Diagnostics_DocumentClose.
            /// </summary>
            Diagnostics_DocumentClose = 19,
            /// <summary>
            /// Run_Environment.
            /// </summary>
            Run_Environment = 20,
            /// <summary>
            /// Run_Environment_Options.
            /// </summary>
            Run_Environment_Options = 21,
            /// <summary>
            /// Tagger_AdornmentManager_OnLayoutChanged.
            /// </summary>
            Tagger_AdornmentManager_OnLayoutChanged = 22,
            /// <summary>
            /// Tagger_AdornmentManager_UpdateInvalidSpans.
            /// </summary>
            Tagger_AdornmentManager_UpdateInvalidSpans = 23,
            /// <summary>
            /// Tagger_BatchChangeNotifier_NotifyEditorNow.
            /// </summary>
            Tagger_BatchChangeNotifier_NotifyEditorNow = 24,
            /// <summary>
            /// Tagger_BatchChangeNotifier_NotifyEditor.
            /// </summary>
            Tagger_BatchChangeNotifier_NotifyEditor = 25,
            /// <summary>
            /// Tagger_TagSource_RecomputeTags.
            /// </summary>
            Tagger_TagSource_RecomputeTags = 26,
            /// <summary>
            /// Tagger_TagSource_ProcessNewTags.
            /// </summary>
            Tagger_TagSource_ProcessNewTags = 27,
            /// <summary>
            /// Tagger_SyntacticClassification_TagComputer_GetTags.
            /// </summary>
            Tagger_SyntacticClassification_TagComputer_GetTags = 28,
            /// <summary>
            /// Tagger_SemanticClassification_TagProducer_ProduceTags.
            /// </summary>
            Tagger_SemanticClassification_TagProducer_ProduceTags = 29,
            /// <summary>
            /// Tagger_BraceHighlighting_TagProducer_ProduceTags.
            /// </summary>
            Tagger_BraceHighlighting_TagProducer_ProduceTags = 30,
            /// <summary>
            /// Tagger_LineSeparator_TagProducer_ProduceTags.
            /// </summary>
            Tagger_LineSeparator_TagProducer_ProduceTags = 31,
            /// <summary>
            /// Tagger_Outlining_TagProducer_ProduceTags.
            /// </summary>
            Tagger_Outlining_TagProducer_ProduceTags = 32,
            /// <summary>
            /// Tagger_Highlighter_TagProducer_ProduceTags.
            /// </summary>
            Tagger_Highlighter_TagProducer_ProduceTags = 33,
            /// <summary>
            /// Tagger_ReferenceHighlighting_TagProducer_ProduceTags.
            /// </summary>
            Tagger_ReferenceHighlighting_TagProducer_ProduceTags = 34,
            /// <summary>
            /// CaseCorrection_CaseCorrect.
            /// </summary>
            CaseCorrection_CaseCorrect = 35,
            /// <summary>
            /// CaseCorrection_ReplaceTokens.
            /// </summary>
            CaseCorrection_ReplaceTokens = 36,
            /// <summary>
            /// CaseCorrection_AddReplacements.
            /// </summary>
            CaseCorrection_AddReplacements = 37,
            /// <summary>
            /// CodeCleanup_CleanupAsync.
            /// </summary>
            CodeCleanup_CleanupAsync = 38,
            /// <summary>
            /// CodeCleanup_Cleanup.
            /// </summary>
            CodeCleanup_Cleanup = 39,
            /// <summary>
            /// CodeCleanup_IterateAllCodeCleanupProviders.
            /// </summary>
            CodeCleanup_IterateAllCodeCleanupProviders = 40,
            /// <summary>
            /// CodeCleanup_IterateOneCodeCleanup.
            /// </summary>
            CodeCleanup_IterateOneCodeCleanup = 41,
            /// <summary>
            /// CommandHandler_GetCommandState.
            /// </summary>
            CommandHandler_GetCommandState = 42,
            /// <summary>
            /// CommandHandler_ExecuteHandlers.
            /// </summary>
            CommandHandler_ExecuteHandlers = 43,
            /// <summary>
            /// CommandHandler_FormatCommand.
            /// </summary>
            CommandHandler_FormatCommand = 44,
            /// <summary>
            /// CommandHandler_CompleteStatement.
            /// </summary>
            CommandHandler_CompleteStatement = 45,
            /// <summary>
            /// CommandHandler_ToggleBlockComment.
            /// </summary>
            CommandHandler_ToggleBlockComment = 46,
            /// <summary>
            /// CommandHandler_ToggleLineComment.
            /// </summary>
            CommandHandler_ToggleLineComment = 47,
            /// <summary>
            /// Workspace_SourceText_GetChangeRanges.
            /// </summary>
            Workspace_SourceText_GetChangeRanges = 48,
            /// <summary>
            /// Workspace_Recoverable_RecoverRootAsync.
            /// </summary>
            Workspace_Recoverable_RecoverRootAsync = 49,
            /// <summary>
            /// Workspace_Recoverable_RecoverRoot.
            /// </summary>
            Workspace_Recoverable_RecoverRoot = 50,
            /// <summary>
            /// Workspace_Recoverable_RecoverTextAsync.
            /// </summary>
            Workspace_Recoverable_RecoverTextAsync = 51,
            /// <summary>
            /// Workspace_Recoverable_RecoverText.
            /// </summary>
            Workspace_Recoverable_RecoverText = 52,
            /// <summary>
            /// Workspace_SkeletonAssembly_GetMetadataOnlyImage.
            /// </summary>
            Workspace_SkeletonAssembly_GetMetadataOnlyImage = 53,
            /// <summary>
            /// Workspace_SkeletonAssembly_EmitMetadataOnlyImage.
            /// </summary>
            Workspace_SkeletonAssembly_EmitMetadataOnlyImage = 54,
            /// <summary>
            /// Workspace_Document_State_FullyParseSyntaxTree.
            /// </summary>
            Workspace_Document_State_FullyParseSyntaxTree = 55,
            /// <summary>
            /// Workspace_Document_State_IncrementallyParseSyntaxTree.
            /// </summary>
            Workspace_Document_State_IncrementallyParseSyntaxTree = 56,
            /// <summary>
            /// Workspace_Document_GetSemanticModel.
            /// </summary>
            Workspace_Document_GetSemanticModel = 57,
            /// <summary>
            /// Workspace_Document_GetSyntaxTree.
            /// </summary>
            Workspace_Document_GetSyntaxTree = 58,
            /// <summary>
            /// Workspace_Document_GetTextChanges.
            /// </summary>
            Workspace_Document_GetTextChanges = 59,
            /// <summary>
            /// Workspace_Project_GetCompilation.
            /// </summary>
            Workspace_Project_GetCompilation = 60,
            /// <summary>
            /// Workspace_Project_CompilationTracker_BuildCompilationAsync.
            /// </summary>
            Workspace_Project_CompilationTracker_BuildCompilationAsync = 61,
            /// <summary>
            /// Workspace_ApplyChanges.
            /// </summary>
            Workspace_ApplyChanges = 62,
            /// <summary>
            /// Workspace_TryGetDocument.
            /// </summary>
            Workspace_TryGetDocument = 63,
            /// <summary>
            /// Workspace_TryGetDocumentFromInProgressSolution.
            /// </summary>
            Workspace_TryGetDocumentFromInProgressSolution = 64,
            /// <summary>
            /// Workspace_Solution_LinkedFileDiffMergingSession.
            /// </summary>
            Workspace_Solution_LinkedFileDiffMergingSession = 65,
            /// <summary>
            /// Workspace_Solution_LinkedFileDiffMergingSession_LinkedFileGroup.
            /// </summary>
            Workspace_Solution_LinkedFileDiffMergingSession_LinkedFileGroup = 66,
            /// <summary>
            /// Workspace_Solution_Info.
            /// </summary>
            Workspace_Solution_Info = 67,
            /// <summary>
            /// EndConstruct_DoStatement.
            /// </summary>
            EndConstruct_DoStatement = 68,
            /// <summary>
            /// EndConstruct_XmlCData.
            /// </summary>
            EndConstruct_XmlCData = 69,
            /// <summary>
            /// EndConstruct_XmlComment.
            /// </summary>
            EndConstruct_XmlComment = 70,
            /// <summary>
            /// EndConstruct_XmlElement.
            /// </summary>
            EndConstruct_XmlElement = 71,
            /// <summary>
            /// EndConstruct_XmlEmbeddedExpression.
            /// </summary>
            EndConstruct_XmlEmbeddedExpression = 72,
            /// <summary>
            /// EndConstruct_XmlProcessingInstruction.
            /// </summary>
            EndConstruct_XmlProcessingInstruction = 73,
            /// <summary>
            /// FindReference_Rename.
            /// </summary>
            FindReference_Rename = 74,
            /// <summary>
            /// FindReference_ChangeSignature.
            /// </summary>
            FindReference_ChangeSignature = 75,
            /// <summary>
            /// FindReference.
            /// </summary>
            FindReference = 76,
            /// <summary>
            /// FindReference_DetermineAllSymbolsAsync.
            /// </summary>
            FindReference_DetermineAllSymbolsAsync = 77,
            /// <summary>
            /// FindReference_CreateProjectMapAsync.
            /// </summary>
            FindReference_CreateProjectMapAsync = 78,
            /// <summary>
            /// FindReference_CreateDocumentMapAsync.
            /// </summary>
            FindReference_CreateDocumentMapAsync = 79,
            /// <summary>
            /// FindReference_ProcessAsync.
            /// </summary>
            FindReference_ProcessAsync = 80,
            /// <summary>
            /// FindReference_ProcessProjectAsync.
            /// </summary>
            FindReference_ProcessProjectAsync = 81,
            /// <summary>
            /// FindReference_ProcessDocumentAsync.
            /// </summary>
            FindReference_ProcessDocumentAsync = 82,
            /// <summary>
            /// LineCommit_CommitRegion.
            /// </summary>
            LineCommit_CommitRegion = 83,
            /// <summary>
            /// Formatting_TokenStreamConstruction.
            /// </summary>
            Formatting_TokenStreamConstruction = 84,
            /// <summary>
            /// Formatting_ContextInitialization.
            /// </summary>
            Formatting_ContextInitialization = 85,
            /// <summary>
            /// Formatting_Format.
            /// </summary>
            Formatting_Format = 86,
            /// <summary>
            /// Formatting_ApplyResultToBuffer.
            /// </summary>
            Formatting_ApplyResultToBuffer = 87,
            /// <summary>
            /// Formatting_IterateNodes.
            /// </summary>
            Formatting_IterateNodes = 88,
            /// <summary>
            /// Formatting_CollectIndentBlock.
            /// </summary>
            Formatting_CollectIndentBlock = 89,
            /// <summary>
            /// Formatting_CollectSuppressOperation.
            /// </summary>
            Formatting_CollectSuppressOperation = 90,
            /// <summary>
            /// Formatting_CollectAlignOperation.
            /// </summary>
            Formatting_CollectAlignOperation = 91,
            /// <summary>
            /// Formatting_CollectAnchorOperation.
            /// </summary>
            Formatting_CollectAnchorOperation = 92,
            /// <summary>
            /// Formatting_CollectTokenOperation.
            /// </summary>
            Formatting_CollectTokenOperation = 93,
            /// <summary>
            /// Formatting_BuildContext.
            /// </summary>
            Formatting_BuildContext = 94,
            /// <summary>
            /// Formatting_ApplySpaceAndLine.
            /// </summary>
            Formatting_ApplySpaceAndLine = 95,
            /// <summary>
            /// Formatting_ApplyAnchorOperation.
            /// </summary>
            Formatting_ApplyAnchorOperation = 96,
            /// <summary>
            /// Formatting_ApplyAlignOperation.
            /// </summary>
            Formatting_ApplyAlignOperation = 97,
            /// <summary>
            /// Formatting_AggregateCreateTextChanges.
            /// </summary>
            Formatting_AggregateCreateTextChanges = 98,
            /// <summary>
            /// Formatting_AggregateCreateFormattedRoot.
            /// </summary>
            Formatting_AggregateCreateFormattedRoot = 99,
            /// <summary>
            /// Formatting_CreateTextChanges.
            /// </summary>
            Formatting_CreateTextChanges = 100,
            /// <summary>
            /// Formatting_CreateFormattedRoot.
            /// </summary>
            Formatting_CreateFormattedRoot = 101,
            /// <summary>
            /// Formatting_Partitions.
            /// </summary>
            Formatting_Partitions = 102,
            /// <summary>
            /// SmartIndentation_Start.
            /// </summary>
            SmartIndentation_Start = 103,
            /// <summary>
            /// SmartIndentation_OpenCurly.
            /// </summary>
            SmartIndentation_OpenCurly = 104,
            /// <summary>
            /// SmartIndentation_CloseCurly.
            /// </summary>
            SmartIndentation_CloseCurly = 105,
            /// <summary>
            /// Rename_InlineSession.
            /// </summary>
            Rename_InlineSession = 106,
            /// <summary>
            /// Rename_InlineSession_Session.
            /// </summary>
            Rename_InlineSession_Session = 107,
            /// <summary>
            /// Rename_FindLinkedSpans.
            /// </summary>
            Rename_FindLinkedSpans = 108,
            /// <summary>
            /// Rename_GetSymbolRenameInfo.
            /// </summary>
            Rename_GetSymbolRenameInfo = 109,
            /// <summary>
            /// Rename_OnTextBufferChanged.
            /// </summary>
            Rename_OnTextBufferChanged = 110,
            /// <summary>
            /// Rename_ApplyReplacementText.
            /// </summary>
            Rename_ApplyReplacementText = 111,
            /// <summary>
            /// Rename_CommitCore.
            /// </summary>
            Rename_CommitCore = 112,
            /// <summary>
            /// Rename_CommitCoreWithPreview.
            /// </summary>
            Rename_CommitCoreWithPreview = 113,
            /// <summary>
            /// Rename_GetAsynchronousLocationsSource.
            /// </summary>
            Rename_GetAsynchronousLocationsSource = 114,
            /// <summary>
            /// Rename_AllRenameLocations.
            /// </summary>
            Rename_AllRenameLocations = 115,
            /// <summary>
            /// Rename_StartSearchingForSpansInAllOpenDocuments.
            /// </summary>
            Rename_StartSearchingForSpansInAllOpenDocuments = 116,
            /// <summary>
            /// Rename_StartSearchingForSpansInOpenDocument.
            /// </summary>
            Rename_StartSearchingForSpansInOpenDocument = 117,
            /// <summary>
            /// Rename_CreateOpenTextBufferManagerForAllOpenDocs.
            /// </summary>
            Rename_CreateOpenTextBufferManagerForAllOpenDocs = 118,
            /// <summary>
            /// Rename_CreateOpenTextBufferManagerForAllOpenDocument.
            /// </summary>
            Rename_CreateOpenTextBufferManagerForAllOpenDocument = 119,
            /// <summary>
            /// Rename_ReportSpan.
            /// </summary>
            Rename_ReportSpan = 120,
            /// <summary>
            /// Rename_GetNoChangeConflictResolution.
            /// </summary>
            Rename_GetNoChangeConflictResolution = 121,
            /// <summary>
            /// Rename_Tracking_BufferChanged.
            /// </summary>
            Rename_Tracking_BufferChanged = 122,
            /// <summary>
            /// TPLTask_TaskScheduled.
            /// </summary>
            TPLTask_TaskScheduled = 123,
            /// <summary>
            /// TPLTask_TaskStarted.
            /// </summary>
            TPLTask_TaskStarted = 124,
            /// <summary>
            /// TPLTask_TaskCompleted.
            /// </summary>
            TPLTask_TaskCompleted = 125,
            /// <summary>
            /// Get_QuickInfo_Async.
            /// </summary>
            Get_QuickInfo_Async = 126,
            /// <summary>
            /// Completion_ModelComputer_DoInBackground.
            /// </summary>
            Completion_ModelComputer_DoInBackground = 127,
            /// <summary>
            /// Completion_ModelComputation_FilterModelInBackground.
            /// </summary>
            Completion_ModelComputation_FilterModelInBackground = 128,
            /// <summary>
            /// Completion_ModelComputation_WaitForModel.
            /// </summary>
            Completion_ModelComputation_WaitForModel = 129,
            /// <summary>
            /// Completion_SymbolCompletionProvider_GetItemsWorker.
            /// </summary>
            Completion_SymbolCompletionProvider_GetItemsWorker = 130,
            /// <summary>
            /// Completion_KeywordCompletionProvider_GetItemsWorker.
            /// </summary>
            Completion_KeywordCompletionProvider_GetItemsWorker = 131,
            /// <summary>
            /// Completion_SnippetCompletionProvider_GetItemsWorker_CSharp.
            /// </summary>
            Completion_SnippetCompletionProvider_GetItemsWorker_CSharp = 132,
            /// <summary>
            /// Completion_TypeImportCompletionProvider_GetCompletionItemsAsync.
            /// </summary>
            Completion_TypeImportCompletionProvider_GetCompletionItemsAsync = 133,
            /// <summary>
            /// Completion_ExtensionMethodImportCompletionProvider_GetCompletionItemsAsync.
            /// </summary>
            Completion_ExtensionMethodImportCompletionProvider_GetCompletionItemsAsync = 134,
            /// <summary>
            /// SignatureHelp_ModelComputation_ComputeModelInBackground.
            /// </summary>
            SignatureHelp_ModelComputation_ComputeModelInBackground = 135,
            /// <summary>
            /// SignatureHelp_ModelComputation_UpdateModelInBackground.
            /// </summary>
            SignatureHelp_ModelComputation_UpdateModelInBackground = 136,
            /// <summary>
            /// Refactoring_CodeRefactoringService_GetRefactoringsAsync.
            /// </summary>
            Refactoring_CodeRefactoringService_GetRefactoringsAsync = 137,
            /// <summary>
            /// Refactoring_AddImport.
            /// </summary>
            Refactoring_AddImport = 138,
            /// <summary>
            /// Refactoring_FullyQualify.
            /// </summary>
            Refactoring_FullyQualify = 139,
            /// <summary>
            /// Refactoring_GenerateFromMembers_AddConstructorParametersFromMembers.
            /// </summary>
            Refactoring_GenerateFromMembers_AddConstructorParametersFromMembers = 140,
            /// <summary>
            /// Refactoring_GenerateFromMembers_GenerateConstructorFromMembers.
            /// </summary>
            Refactoring_GenerateFromMembers_GenerateConstructorFromMembers = 141,
            /// <summary>
            /// Refactoring_GenerateFromMembers_GenerateEqualsAndGetHashCode.
            /// </summary>
            Refactoring_GenerateFromMembers_GenerateEqualsAndGetHashCode = 142,
            /// <summary>
            /// Refactoring_GenerateMember_GenerateConstructor.
            /// </summary>
            Refactoring_GenerateMember_GenerateConstructor = 143,
            /// <summary>
            /// Refactoring_GenerateMember_GenerateDefaultConstructors.
            /// </summary>
            Refactoring_GenerateMember_GenerateDefaultConstructors = 144,
            /// <summary>
            /// Refactoring_GenerateMember_GenerateEnumMember.
            /// </summary>
            Refactoring_GenerateMember_GenerateEnumMember = 145,
            /// <summary>
            /// Refactoring_GenerateMember_GenerateMethod.
            /// </summary>
            Refactoring_GenerateMember_GenerateMethod = 146,
            /// <summary>
            /// Refactoring_GenerateMember_GenerateVariable.
            /// </summary>
            Refactoring_GenerateMember_GenerateVariable = 147,
            /// <summary>
            /// Refactoring_ImplementAbstractClass.
            /// </summary>
            Refactoring_ImplementAbstractClass = 148,
            /// <summary>
            /// Refactoring_ImplementInterface.
            /// </summary>
            Refactoring_ImplementInterface = 149,
            /// <summary>
            /// Refactoring_IntroduceVariable.
            /// </summary>
            Refactoring_IntroduceVariable = 150,
            /// <summary>
            /// Refactoring_GenerateType.
            /// </summary>
            Refactoring_GenerateType = 151,
            /// <summary>
            /// Refactoring_RemoveUnnecessaryImports_CSharp.
            /// </summary>
            Refactoring_RemoveUnnecessaryImports_CSharp = 152,
            /// <summary>
            /// Refactoring_RemoveUnnecessaryImports_VisualBasic.
            /// </summary>
            Refactoring_RemoveUnnecessaryImports_VisualBasic = 153,
            /// <summary>
            /// Snippet_OnBeforeInsertion.
            /// </summary>
            Snippet_OnBeforeInsertion = 154,
            /// <summary>
            /// Snippet_OnAfterInsertion.
            /// </summary>
            Snippet_OnAfterInsertion = 155,
            /// <summary>
            /// Misc_NonReentrantLock_BlockingWait.
            /// </summary>
            Misc_NonReentrantLock_BlockingWait = 156,
            /// <summary>
            /// Misc_VisualStudioWaitIndicator_Wait.
            /// </summary>
            Misc_VisualStudioWaitIndicator_Wait = 157,
            /// <summary>
            /// Misc_SaveEventsSink_OnBeforeSave.
            /// </summary>
            Misc_SaveEventsSink_OnBeforeSave = 158,
            /// <summary>
            /// TaskList_Refresh.
            /// </summary>
            TaskList_Refresh = 159,
            /// <summary>
            /// TaskList_NavigateTo.
            /// </summary>
            TaskList_NavigateTo = 160,
            /// <summary>
            /// WinformDesigner_GenerateXML.
            /// </summary>
            WinformDesigner_GenerateXML = 161,
            /// <summary>
            /// NavigateTo_Search.
            /// </summary>
            NavigateTo_Search = 162,
            /// <summary>
            /// NavigationService_VSDocumentNavigationService_NavigateTo.
            /// </summary>
            NavigationService_VSDocumentNavigationService_NavigateTo = 163,
            /// <summary>
            /// NavigationBar_ComputeModelAsync.
            /// </summary>
            NavigationBar_ComputeModelAsync = 164,
            /// <summary>
            /// NavigationBar_ItemService_GetMembersInTypes_CSharp.
            /// </summary>
            NavigationBar_ItemService_GetMembersInTypes_CSharp = 165,
            /// <summary>
            /// NavigationBar_ItemService_GetTypesInFile_CSharp.
            /// </summary>
            NavigationBar_ItemService_GetTypesInFile_CSharp = 166,
            /// <summary>
            /// NavigationBar_UpdateDropDownsSynchronously_WaitForModel.
            /// </summary>
            NavigationBar_UpdateDropDownsSynchronously_WaitForModel = 167,
            /// <summary>
            /// NavigationBar_UpdateDropDownsSynchronously_WaitForSelectedItemInfo.
            /// </summary>
            NavigationBar_UpdateDropDownsSynchronously_WaitForSelectedItemInfo = 168,
            /// <summary>
            /// EventHookup_Determine_If_Event_Hookup.
            /// </summary>
            EventHookup_Determine_If_Event_Hookup = 169,
            /// <summary>
            /// EventHookup_Generate_Handler.
            /// </summary>
            EventHookup_Generate_Handler = 170,
            /// <summary>
            /// EventHookup_Type_Char.
            /// </summary>
            EventHookup_Type_Char = 171,
            /// <summary>
            /// Cache_Created.
            /// </summary>
            Cache_Created = 172,
            /// <summary>
            /// Cache_AddOrAccess.
            /// </summary>
            Cache_AddOrAccess = 173,
            /// <summary>
            /// Cache_Remove.
            /// </summary>
            Cache_Remove = 174,
            /// <summary>
            /// Cache_Evict.
            /// </summary>
            Cache_Evict = 175,
            /// <summary>
            /// Cache_EvictAll.
            /// </summary>
            Cache_EvictAll = 176,
            /// <summary>
            /// Cache_ItemRank.
            /// </summary>
            Cache_ItemRank = 177,
            /// <summary>
            /// TextStructureNavigator_GetExtentOfWord.
            /// </summary>
            TextStructureNavigator_GetExtentOfWord = 178,
            /// <summary>
            /// TextStructureNavigator_GetSpanOfEnclosing.
            /// </summary>
            TextStructureNavigator_GetSpanOfEnclosing = 179,
            /// <summary>
            /// TextStructureNavigator_GetSpanOfFirstChild.
            /// </summary>
            TextStructureNavigator_GetSpanOfFirstChild = 180,
            /// <summary>
            /// TextStructureNavigator_GetSpanOfNextSibling.
            /// </summary>
            TextStructureNavigator_GetSpanOfNextSibling = 181,
            /// <summary>
            /// TextStructureNavigator_GetSpanOfPreviousSibling.
            /// </summary>
            TextStructureNavigator_GetSpanOfPreviousSibling = 182,
            /// <summary>
            /// Debugging_LanguageDebugInfoService_GetDataTipSpanAndText.
            /// </summary>
            Debugging_LanguageDebugInfoService_GetDataTipSpanAndText = 183,
            /// <summary>
            /// Debugging_VsLanguageDebugInfo_ValidateBreakpointLocation.
            /// </summary>
            Debugging_VsLanguageDebugInfo_ValidateBreakpointLocation = 184,
            /// <summary>
            /// Debugging_VsLanguageDebugInfo_GetProximityExpressions.
            /// </summary>
            Debugging_VsLanguageDebugInfo_GetProximityExpressions = 185,
            /// <summary>
            /// Debugging_VsLanguageDebugInfo_ResolveName.
            /// </summary>
            Debugging_VsLanguageDebugInfo_ResolveName = 186,
            /// <summary>
            /// Debugging_VsLanguageDebugInfo_GetNameOfLocation.
            /// </summary>
            Debugging_VsLanguageDebugInfo_GetNameOfLocation = 187,
            /// <summary>
            /// Debugging_VsLanguageDebugInfo_GetDataTipText.
            /// </summary>
            Debugging_VsLanguageDebugInfo_GetDataTipText = 188,
            /// <summary>
            /// Debugging_EncSession.
            /// </summary>
            Debugging_EncSession = 189,
            /// <summary>
            /// Debugging_EncSession_EditSession.
            /// </summary>
            Debugging_EncSession_EditSession = 190,
            /// <summary>
            /// Debugging_EncSession_EditSession_EmitDeltaErrorId.
            /// </summary>
            Debugging_EncSession_EditSession_EmitDeltaErrorId = 191,
            /// <summary>
            /// Debugging_EncSession_EditSession_RudeEdit.
            /// </summary>
            Debugging_EncSession_EditSession_RudeEdit = 192,
            /// <summary>
            /// Simplifier_ReduceAsync.
            /// </summary>
            Simplifier_ReduceAsync = 193,
            /// <summary>
            /// Simplifier_ExpandNode.
            /// </summary>
            Simplifier_ExpandNode = 194,
            /// <summary>
            /// Simplifier_ExpandToken.
            /// </summary>
            Simplifier_ExpandToken = 195,
            /// <summary>
            /// ForegroundNotificationService_Processed.
            /// </summary>
            ForegroundNotificationService_Processed = 196,
            /// <summary>
            /// ForegroundNotificationService_NotifyOnForeground.
            /// </summary>
            ForegroundNotificationService_NotifyOnForeground = 197,
            /// <summary>
            /// BackgroundCompiler_BuildCompilationsAsync.
            /// </summary>
            BackgroundCompiler_BuildCompilationsAsync = 198,
            /// <summary>
            /// PersistenceService_ReadAsync.
            /// </summary>
            PersistenceService_ReadAsync = 199,
            /// <summary>
            /// PersistenceService_WriteAsync.
            /// </summary>
            PersistenceService_WriteAsync = 200,
            /// <summary>
            /// PersistenceService_ReadAsyncFailed.
            /// </summary>
            PersistenceService_ReadAsyncFailed = 201,
            /// <summary>
            /// PersistenceService_WriteAsyncFailed.
            /// </summary>
            PersistenceService_WriteAsyncFailed = 202,
            /// <summary>
            /// PersistenceService_Initialization.
            /// </summary>
            PersistenceService_Initialization = 203,
            /// <summary>
            /// TemporaryStorageServiceFactory_ReadText.
            /// </summary>
            TemporaryStorageServiceFactory_ReadText = 204,
            /// <summary>
            /// TemporaryStorageServiceFactory_WriteText.
            /// </summary>
            TemporaryStorageServiceFactory_WriteText = 205,
            /// <summary>
            /// TemporaryStorageServiceFactory_ReadStream.
            /// </summary>
            TemporaryStorageServiceFactory_ReadStream = 206,
            /// <summary>
            /// TemporaryStorageServiceFactory_WriteStream.
            /// </summary>
            TemporaryStorageServiceFactory_WriteStream = 207,
            /// <summary>
            /// PullMembersUpWarning_ChangeTargetToAbstract.
            /// </summary>
            PullMembersUpWarning_ChangeTargetToAbstract = 208,
            /// <summary>
            /// PullMembersUpWarning_ChangeOriginToPublic.
            /// </summary>
            PullMembersUpWarning_ChangeOriginToPublic = 209,
            /// <summary>
            /// PullMembersUpWarning_ChangeOriginToNonStatic.
            /// </summary>
            PullMembersUpWarning_ChangeOriginToNonStatic = 210,
            /// <summary>
            /// PullMembersUpWarning_UserProceedToFinish.
            /// </summary>
            PullMembersUpWarning_UserProceedToFinish = 211,
            /// <summary>
            /// PullMembersUpWarning_UserGoBack.
            /// </summary>
            PullMembersUpWarning_UserGoBack = 212,
            /// <summary>
            /// SmartTags_RefreshSession.
            /// </summary>
            SmartTags_RefreshSession = 213,
            /// <summary>
            /// SmartTags_SmartTagInitializeFixes.
            /// </summary>
            SmartTags_SmartTagInitializeFixes = 214,
            /// <summary>
            /// SmartTags_ApplyQuickFix.
            /// </summary>
            SmartTags_ApplyQuickFix = 215,
            /// <summary>
            /// EditorTestApp_RefreshTask.
            /// </summary>
            EditorTestApp_RefreshTask = 216,
            /// <summary>
            /// EditorTestApp_UpdateDiagnostics.
            /// </summary>
            EditorTestApp_UpdateDiagnostics = 217,
            /// <summary>
            /// IncrementalAnalyzerProcessor_Analyzers.
            /// </summary>
            IncrementalAnalyzerProcessor_Analyzers = 218,
            /// <summary>
            /// IncrementalAnalyzerProcessor_Analyzer.
            /// </summary>
            IncrementalAnalyzerProcessor_Analyzer = 219,
            /// <summary>
            /// IncrementalAnalyzerProcessor_ActiveFileAnalyzers.
            /// </summary>
            IncrementalAnalyzerProcessor_ActiveFileAnalyzers = 220,
            /// <summary>
            /// IncrementalAnalyzerProcessor_ActiveFileAnalyzer.
            /// </summary>
            IncrementalAnalyzerProcessor_ActiveFileAnalyzer = 221,
            /// <summary>
            /// IncrementalAnalyzerProcessor_Shutdown.
            /// </summary>
            IncrementalAnalyzerProcessor_Shutdown = 222,
            /// <summary>
            /// WorkCoordinatorRegistrationService_Register.
            /// </summary>
            WorkCoordinatorRegistrationService_Register = 223,
            /// <summary>
            /// WorkCoordinatorRegistrationService_Unregister.
            /// </summary>
            WorkCoordinatorRegistrationService_Unregister = 224,
            /// <summary>
            /// WorkCoordinatorRegistrationService_Reanalyze.
            /// </summary>
            WorkCoordinatorRegistrationService_Reanalyze = 225,
            /// <summary>
            /// WorkCoordinator_SolutionCrawlerOption.
            /// </summary>
            WorkCoordinator_SolutionCrawlerOption = 226,
            /// <summary>
            /// WorkCoordinator_PersistentStorageAdded.
            /// </summary>
            WorkCoordinator_PersistentStorageAdded = 227,
            /// <summary>
            /// WorkCoordinator_PersistentStorageRemoved.
            /// </summary>
            WorkCoordinator_PersistentStorageRemoved = 228,
            /// <summary>
            /// WorkCoordinator_Shutdown.
            /// </summary>
            WorkCoordinator_Shutdown = 229,
            /// <summary>
            /// DiagnosticAnalyzerService_Analyzers.
            /// </summary>
            DiagnosticAnalyzerService_Analyzers = 230,
            /// <summary>
            /// DiagnosticAnalyzerDriver_AnalyzerCrash.
            /// </summary>
            DiagnosticAnalyzerDriver_AnalyzerCrash = 231,
            /// <summary>
            /// DiagnosticAnalyzerDriver_AnalyzerTypeCount.
            /// </summary>
            DiagnosticAnalyzerDriver_AnalyzerTypeCount = 232,
            /// <summary>
            /// PersistedSemanticVersion_Info.
            /// </summary>
            PersistedSemanticVersion_Info = 233,
            /// <summary>
            /// StorageDatabase_Exceptions.
            /// </summary>
            StorageDatabase_Exceptions = 234,
            /// <summary>
            /// WorkCoordinator_ShutdownTimeout.
            /// </summary>
            WorkCoordinator_ShutdownTimeout = 235,
            /// <summary>
            /// Diagnostics_HyperLink.
            /// </summary>
            Diagnostics_HyperLink = 236,
            /// <summary>
            /// CodeFixes_FixAllOccurrencesSession.
            /// </summary>
            CodeFixes_FixAllOccurrencesSession = 237,
            /// <summary>
            /// CodeFixes_FixAllOccurrencesContext.
            /// </summary>
            CodeFixes_FixAllOccurrencesContext = 238,
            /// <summary>
            /// CodeFixes_FixAllOccurrencesComputation.
            /// </summary>
            CodeFixes_FixAllOccurrencesComputation = 239,
            /// <summary>
            /// CodeFixes_FixAllOccurrencesComputation_Document_Diagnostics.
            /// </summary>
            CodeFixes_FixAllOccurrencesComputation_Document_Diagnostics = 240,
            /// <summary>
            /// CodeFixes_FixAllOccurrencesComputation_Project_Diagnostics.
            /// </summary>
            CodeFixes_FixAllOccurrencesComputation_Project_Diagnostics = 241,
            /// <summary>
            /// CodeFixes_FixAllOccurrencesComputation_Document_Fixes.
            /// </summary>
            CodeFixes_FixAllOccurrencesComputation_Document_Fixes = 242,
            /// <summary>
            /// CodeFixes_FixAllOccurrencesComputation_Project_Fixes.
            /// </summary>
            CodeFixes_FixAllOccurrencesComputation_Project_Fixes = 243,
            /// <summary>
            /// CodeFixes_FixAllOccurrencesComputation_Document_Merge.
            /// </summary>
            CodeFixes_FixAllOccurrencesComputation_Document_Merge = 244,
            /// <summary>
            /// CodeFixes_FixAllOccurrencesComputation_Project_Merge.
            /// </summary>
            CodeFixes_FixAllOccurrencesComputation_Project_Merge = 245,
            /// <summary>
            /// CodeFixes_FixAllOccurrencesPreviewChanges.
            /// </summary>
            CodeFixes_FixAllOccurrencesPreviewChanges = 246,
            /// <summary>
            /// CodeFixes_ApplyChanges.
            /// </summary>
            CodeFixes_ApplyChanges = 247,
            /// <summary>
            /// SolutionExplorer_AnalyzerItemSource_GetItems.
            /// </summary>
            SolutionExplorer_AnalyzerItemSource_GetItems = 248,
            /// <summary>
            /// SolutionExplorer_DiagnosticItemSource_GetItems.
            /// </summary>
            SolutionExplorer_DiagnosticItemSource_GetItems = 249,
            /// <summary>
            /// WorkCoordinator_ActiveFileEnqueue.
            /// </summary>
            WorkCoordinator_ActiveFileEnqueue = 250,
            /// <summary>
            /// SymbolFinder_FindDeclarationsAsync.
            /// </summary>
            SymbolFinder_FindDeclarationsAsync = 251,
            /// <summary>
            /// SymbolFinder_Project_AddDeclarationsAsync.
            /// </summary>
            SymbolFinder_Project_AddDeclarationsAsync = 252,
            /// <summary>
            /// SymbolFinder_Assembly_AddDeclarationsAsync.
            /// </summary>
            SymbolFinder_Assembly_AddDeclarationsAsync = 253,
            /// <summary>
            /// SymbolFinder_Solution_Name_FindSourceDeclarationsAsync.
            /// </summary>
            SymbolFinder_Solution_Name_FindSourceDeclarationsAsync = 254,
            /// <summary>
            /// SymbolFinder_Project_Name_FindSourceDeclarationsAsync.
            /// </summary>
            SymbolFinder_Project_Name_FindSourceDeclarationsAsync = 255,
            /// <summary>
            /// SymbolFinder_Solution_Predicate_FindSourceDeclarationsAsync.
            /// </summary>
            SymbolFinder_Solution_Predicate_FindSourceDeclarationsAsync = 256,
            /// <summary>
            /// SymbolFinder_Project_Predicate_FindSourceDeclarationsAsync.
            /// </summary>
            SymbolFinder_Project_Predicate_FindSourceDeclarationsAsync = 257,
            /// <summary>
            /// Tagger_Diagnostics_RecomputeTags.
            /// </summary>
            Tagger_Diagnostics_RecomputeTags = 258,
            /// <summary>
            /// Tagger_Diagnostics_Updated.
            /// </summary>
            Tagger_Diagnostics_Updated = 259,
            /// <summary>
            /// SuggestedActions_HasSuggestedActionsAsync.
            /// </summary>
            SuggestedActions_HasSuggestedActionsAsync = 260,
            /// <summary>
            /// SuggestedActions_GetSuggestedActions.
            /// </summary>
            SuggestedActions_GetSuggestedActions = 261,
            /// <summary>
            /// AnalyzerDependencyCheckingService_LogConflict.
            /// </summary>
            AnalyzerDependencyCheckingService_LogConflict = 262,
            /// <summary>
            /// AnalyzerDependencyCheckingService_LogMissingDependency.
            /// </summary>
            AnalyzerDependencyCheckingService_LogMissingDependency = 263,
            /// <summary>
            /// VirtualMemory_MemoryLow.
            /// </summary>
            VirtualMemory_MemoryLow = 264,
            /// <summary>
            /// Extension_Exception.
            /// </summary>
            Extension_Exception = 265,
            /// <summary>
            /// WorkCoordinator_WaitForHigherPriorityOperationsAsync.
            /// </summary>
            WorkCoordinator_WaitForHigherPriorityOperationsAsync = 266,
            /// <summary>
            /// CSharp_Interactive_Window.
            /// </summary>
            CSharp_Interactive_Window = 267,
            /// <summary>
            /// VisualBasic_Interactive_Window.
            /// </summary>
            VisualBasic_Interactive_Window = 268,
            /// <summary>
            /// NonFatalWatson.
            /// </summary>
            NonFatalWatson = 269,
            /// <summary>
            /// GlobalOperationRegistration.
            /// </summary>
            GlobalOperationRegistration = 270,
            /// <summary>
            /// CommandHandler_FindAllReference.
            /// </summary>
            CommandHandler_FindAllReference = 271,
            /// <summary>
            /// CodefixInfobar_Enable.
            /// </summary>
            CodefixInfobar_Enable = 272,
            /// <summary>
            /// CodefixInfobar_EnableAndIgnoreFutureErrors.
            /// </summary>
            CodefixInfobar_EnableAndIgnoreFutureErrors = 273,
            /// <summary>
            /// CodefixInfobar_LeaveDisabled.
            /// </summary>
            CodefixInfobar_LeaveDisabled = 274,
            /// <summary>
            /// CodefixInfobar_ErrorIgnored.
            /// </summary>
            CodefixInfobar_ErrorIgnored = 275,
            /// <summary>
            /// Refactoring_NamingStyle.
            /// </summary>
            Refactoring_NamingStyle = 276,
            /// <summary>
            /// SymbolTreeInfo_ExceptionInCacheRead.
            /// </summary>
            SymbolTreeInfo_ExceptionInCacheRead = 277,
            /// <summary>
            /// SpellChecker_ExceptionInCacheRead.
            /// </summary>
            SpellChecker_ExceptionInCacheRead = 278,
            /// <summary>
            /// BKTree_ExceptionInCacheRead.
            /// </summary>
            BKTree_ExceptionInCacheRead = 279,
            /// <summary>
            /// IntellisenseBuild_Failed.
            /// </summary>
            IntellisenseBuild_Failed = 280,
            /// <summary>
            /// FileTextLoader_FileLengthThresholdExceeded.
            /// </summary>
            FileTextLoader_FileLengthThresholdExceeded = 281,
            /// <summary>
            /// MeasurePerformance_StartAction.
            /// </summary>
            MeasurePerformance_StartAction = 282,
            /// <summary>
            /// MeasurePerformance_StopAction.
            /// </summary>
            MeasurePerformance_StopAction = 283,
            /// <summary>
            /// Serializer_CreateChecksum.
            /// </summary>
            Serializer_CreateChecksum = 284,
            /// <summary>
            /// Serializer_Serialize.
            /// </summary>
            Serializer_Serialize = 285,
            /// <summary>
            /// Serializer_Deserialize.
            /// </summary>
            Serializer_Deserialize = 286,
            /// <summary>
            /// CodeAnalysisService_CalculateDiagnosticsAsync.
            /// </summary>
            CodeAnalysisService_CalculateDiagnosticsAsync = 287,
            /// <summary>
            /// CodeAnalysisService_SerializeDiagnosticResultAsync.
            /// </summary>
            CodeAnalysisService_SerializeDiagnosticResultAsync = 288,
            /// <summary>
            /// CodeAnalysisService_GetReferenceCountAsync.
            /// </summary>
            CodeAnalysisService_GetReferenceCountAsync = 289,
            /// <summary>
            /// CodeAnalysisService_FindReferenceLocationsAsync.
            /// </summary>
            CodeAnalysisService_FindReferenceLocationsAsync = 290,
            /// <summary>
            /// CodeAnalysisService_FindReferenceMethodsAsync.
            /// </summary>
            CodeAnalysisService_FindReferenceMethodsAsync = 291,
            /// <summary>
            /// CodeAnalysisService_GetFullyQualifiedName.
            /// </summary>
            CodeAnalysisService_GetFullyQualifiedName = 292,
            /// <summary>
            /// CodeAnalysisService_GetTodoCommentsAsync.
            /// </summary>
            CodeAnalysisService_GetTodoCommentsAsync = 293,
            /// <summary>
            /// CodeAnalysisService_GetDesignerAttributesAsync.
            /// </summary>
            CodeAnalysisService_GetDesignerAttributesAsync = 294,
            /// <summary>
            /// ServiceHubRemoteHostClient_CreateAsync.
            /// </summary>
            ServiceHubRemoteHostClient_CreateAsync = 295,
            /// <summary>
            /// RemoteHost_Connect.
            /// </summary>
            RemoteHost_Connect = 297,
            /// <summary>
            /// RemoteHost_Disconnect.
            /// </summary>
            RemoteHost_Disconnect = 298,
            /// <summary>
            /// RemoteHostService_SynchronizePrimaryWorkspaceAsync.
            /// </summary>
            RemoteHostService_SynchronizePrimaryWorkspaceAsync = 303,
            /// <summary>
            /// AssetStorage_CleanAssets.
            /// </summary>
            AssetStorage_CleanAssets = 305,
            /// <summary>
            /// AssetStorage_TryGetAsset.
            /// </summary>
            AssetStorage_TryGetAsset = 306,
            /// <summary>
            /// AssetService_GetAssetAsync.
            /// </summary>
            AssetService_GetAssetAsync = 307,
            /// <summary>
            /// AssetService_SynchronizeAssetsAsync.
            /// </summary>
            AssetService_SynchronizeAssetsAsync = 308,
            /// <summary>
            /// AssetService_SynchronizeSolutionAssetsAsync.
            /// </summary>
            AssetService_SynchronizeSolutionAssetsAsync = 309,
            /// <summary>
            /// AssetService_SynchronizeProjectAssetsAsync.
            /// </summary>
            AssetService_SynchronizeProjectAssetsAsync = 310,
            /// <summary>
            /// CodeLens_GetReferenceCountAsync.
            /// </summary>
            CodeLens_GetReferenceCountAsync = 311,
            /// <summary>
            /// CodeLens_FindReferenceLocationsAsync.
            /// </summary>
            CodeLens_FindReferenceLocationsAsync = 312,
            /// <summary>
            /// CodeLens_FindReferenceMethodsAsync.
            /// </summary>
            CodeLens_FindReferenceMethodsAsync = 313,
            /// <summary>
            /// CodeLens_GetFullyQualifiedName.
            /// </summary>
            CodeLens_GetFullyQualifiedName = 314,
            /// <summary>
            /// SolutionState_ComputeChecksumsAsync.
            /// </summary>
            SolutionState_ComputeChecksumsAsync = 315,
            /// <summary>
            /// ProjectState_ComputeChecksumsAsync.
            /// </summary>
            ProjectState_ComputeChecksumsAsync = 316,
            /// <summary>
            /// DocumentState_ComputeChecksumsAsync.
            /// </summary>
            DocumentState_ComputeChecksumsAsync = 317,
            /// <summary>
            /// SolutionChecksumUpdater_SynchronizePrimaryWorkspace.
            /// </summary>
            SolutionChecksumUpdater_SynchronizePrimaryWorkspace = 320,
            /// <summary>
            /// JsonRpcSession_RequestAssetAsync.
            /// </summary>
            JsonRpcSession_RequestAssetAsync = 321,
            /// <summary>
            /// SolutionService_GetSolutionAsync.
            /// </summary>
            SolutionService_GetSolutionAsync = 322,
            /// <summary>
            /// SolutionService_UpdatePrimaryWorkspaceAsync.
            /// </summary>
            SolutionService_UpdatePrimaryWorkspaceAsync = 323,
            /// <summary>
            /// RemoteHostService_GetAssetsAsync.
            /// </summary>
            RemoteHostService_GetAssetsAsync = 324,
            /// <summary>
            /// SolutionCreator_AssetDifferences.
            /// </summary>
            SolutionCreator_AssetDifferences = 326,
            /// <summary>
            /// Extension_InfoBar.
            /// </summary>
            Extension_InfoBar = 327,
            /// <summary>
            /// FxCopAnalyzersInstall.
            /// </summary>
            FxCopAnalyzersInstall = 328,
            /// <summary>
            /// AssetStorage_ForceGC.
            /// </summary>
            AssetStorage_ForceGC = 329,
            /// <summary>
            /// RemoteHost_Bitness.
            /// </summary>
            RemoteHost_Bitness = 330,
            /// <summary>
            /// Intellisense_Completion.
            /// </summary>
            Intellisense_Completion = 331,
            /// <summary>
            /// MetadataOnlyImage_EmitFailure.
            /// </summary>
            MetadataOnlyImage_EmitFailure = 332,
            /// <summary>
            /// LiveTableDataSource_OnDiagnosticsUpdated.
            /// </summary>
            LiveTableDataSource_OnDiagnosticsUpdated = 333,
            /// <summary>
            /// Experiment_KeybindingsReset.
            /// </summary>
            Experiment_KeybindingsReset = 334,
            /// <summary>
            /// Diagnostics_GeneratePerformaceReport.
            /// </summary>
            Diagnostics_GeneratePerformaceReport = 335,
            /// <summary>
            /// Diagnostics_BadAnalyzer.
            /// </summary>
            Diagnostics_BadAnalyzer = 336,
            /// <summary>
            /// CodeAnalysisService_ReportAnalyzerPerformance.
            /// </summary>
            CodeAnalysisService_ReportAnalyzerPerformance = 337,
            /// <summary>
            /// PerformanceTrackerService_AddSnapshot.
            /// </summary>
            PerformanceTrackerService_AddSnapshot = 338,
            /// <summary>
            /// AbstractProject_SetIntelliSenseBuild.
            /// </summary>
            AbstractProject_SetIntelliSenseBuild = 339,
            /// <summary>
            /// AbstractProject_Created.
            /// </summary>
            AbstractProject_Created = 340,
            /// <summary>
            /// AbstractProject_PushedToWorkspace.
            /// </summary>
            AbstractProject_PushedToWorkspace = 341,
            /// <summary>
            /// ExternalErrorDiagnosticUpdateSource_AddError.
            /// </summary>
            ExternalErrorDiagnosticUpdateSource_AddError = 342,
            /// <summary>
            /// DiagnosticIncrementalAnalyzer_SynchronizeWithBuildAsync.
            /// </summary>
            DiagnosticIncrementalAnalyzer_SynchronizeWithBuildAsync = 343,
            /// <summary>
            /// Completion_ExecuteCommand_TypeChar.
            /// </summary>
            Completion_ExecuteCommand_TypeChar = 344,
            /// <summary>
            /// RemoteHostService_SynchronizeTextAsync.
            /// </summary>
            RemoteHostService_SynchronizeTextAsync = 345,
            /// <summary>
            /// SymbolFinder_Solution_Pattern_FindSourceDeclarationsAsync.
            /// </summary>
            SymbolFinder_Solution_Pattern_FindSourceDeclarationsAsync = 346,
            /// <summary>
            /// SymbolFinder_Project_Pattern_FindSourceDeclarationsAsync.
            /// </summary>
            SymbolFinder_Project_Pattern_FindSourceDeclarationsAsync = 347,
            /// <summary>
            /// Intellisense_Completion_Commit.
            /// </summary>
            Intellisense_Completion_Commit = 348,
            /// <summary>
            /// CodeCleanupInfobar_BarDisplayed.
            /// </summary>
            CodeCleanupInfobar_BarDisplayed = 349,
            /// <summary>
            /// CodeCleanupInfobar_ConfigureNow.
            /// </summary>
            CodeCleanupInfobar_ConfigureNow = 350,
            /// <summary>
            /// CodeCleanupInfobar_NeverShowCodeCleanupInfoBarAgain.
            /// </summary>
            CodeCleanupInfobar_NeverShowCodeCleanupInfoBarAgain = 351,
            /// <summary>
            /// FormatDocument.
            /// </summary>
            FormatDocument = 352,
            /// <summary>
            /// CodeCleanup_ApplyCodeFixesAsync.
            /// </summary>
            CodeCleanup_ApplyCodeFixesAsync = 353,
            /// <summary>
            /// CodeCleanup_RemoveUnusedImports.
            /// </summary>
            CodeCleanup_RemoveUnusedImports = 354,
            /// <summary>
            /// CodeCleanup_SortImports.
            /// </summary>
            CodeCleanup_SortImports = 355,
            /// <summary>
            /// CodeCleanup_Format.
            /// </summary>
            CodeCleanup_Format = 356,
            /// <summary>
            /// CodeCleanupABTest_AssignedToOnByDefault.
            /// </summary>
            CodeCleanupABTest_AssignedToOnByDefault = 357,
            /// <summary>
            /// CodeCleanupABTest_AssignedToOffByDefault.
            /// </summary>
            CodeCleanupABTest_AssignedToOffByDefault = 358,
            /// <summary>
            /// Workspace_Events.
            /// </summary>
            Workspace_Events = 359,
            /// <summary>
            /// Refactoring_ExtractMethod_UnknownMatrixItem.
            /// </summary>
            Refactoring_ExtractMethod_UnknownMatrixItem = 360,
            /// <summary>
            /// SyntaxTreeIndex_Precalculate.
            /// </summary>
            SyntaxTreeIndex_Precalculate = 361,
            /// <summary>
            /// SyntaxTreeIndex_Precalculate_Create.
            /// </summary>
            SyntaxTreeIndex_Precalculate_Create = 362,
            /// <summary>
            /// SymbolTreeInfo_Create.
            /// </summary>
            SymbolTreeInfo_Create = 363,
            /// <summary>
            /// SymbolTreeInfo_TryLoadOrCreate.
            /// </summary>
            SymbolTreeInfo_TryLoadOrCreate = 364,
            /// <summary>
            /// CommandHandler_GoToImplementation.
            /// </summary>
            CommandHandler_GoToImplementation = 365,
            /// <summary>
            /// GraphQuery_ImplementedBy.
            /// </summary>
            GraphQuery_ImplementedBy = 366,
            /// <summary>
            /// GraphQuery_Implements.
            /// </summary>
            GraphQuery_Implements = 367,
            /// <summary>
            /// GraphQuery_IsCalledBy.
            /// </summary>
            GraphQuery_IsCalledBy = 368,
            /// <summary>
            /// GraphQuery_IsUsedBy.
            /// </summary>
            GraphQuery_IsUsedBy = 369,
            /// <summary>
            /// GraphQuery_Overrides.
            /// </summary>
            GraphQuery_Overrides = 370,
            /// <summary>
            /// Intellisense_AsyncCompletion_Data.
            /// </summary>
            Intellisense_AsyncCompletion_Data = 371,
            /// <summary>
            /// Intellisense_CompletionProviders_Data.
            /// </summary>
            Intellisense_CompletionProviders_Data = 372,
            /// <summary>
            /// RemoteHostService_IsExperimentEnabledAsync.
            /// </summary>
            RemoteHostService_IsExperimentEnabledAsync = 373,
            /// <summary>
            /// PartialLoad_FullyLoaded.
            /// </summary>
            PartialLoad_FullyLoaded = 374,
            /// <summary>
            /// Liveshare_UnknownCodeAction.
            /// </summary>
            Liveshare_UnknownCodeAction = 375,
            /// <summary>
            /// Liveshare_LexicalClassifications.
            /// </summary>
            Liveshare_LexicalClassifications = 376,
            /// <summary>
            /// Liveshare_SyntacticClassifications.
            /// </summary>
            Liveshare_SyntacticClassifications = 377,
            /// <summary>
            /// Liveshare_SyntacticTagger.
            /// </summary>
            Liveshare_SyntacticTagger = 378,
            /// <summary>
            /// CommandHandler_GoToBase.
            /// </summary>
            CommandHandler_GoToBase = 379,
            /// <summary>
            /// DiagnosticAnalyzerService_GetDiagnosticsForSpanAsync.
            /// </summary>
            DiagnosticAnalyzerService_GetDiagnosticsForSpanAsync = 380,
            /// <summary>
            /// CodeFixes_GetCodeFixesAsync.
            /// </summary>
            CodeFixes_GetCodeFixesAsync = 381,
            /// <summary>
            /// LanguageServer_ActivateFailed.
            /// </summary>
            LanguageServer_ActivateFailed = 382,
            /// <summary>
            /// LanguageServer_OnLoadedFailed.
            /// </summary>
            LanguageServer_OnLoadedFailed = 383,
            /// <summary>
            /// CodeFixes_AddExplicitCast.
            /// </summary>
            CodeFixes_AddExplicitCast = 384,
            /// <summary>
            /// ToolsOptions_GenerateEditorconfig.
            /// </summary>
            ToolsOptions_GenerateEditorconfig = 385,
            /// <summary>
            /// Renamer_RenameSymbolAsync.
            /// </summary>
            Renamer_RenameSymbolAsync = 386,
            /// <summary>
            /// Renamer_FindRenameLocationsAsync.
            /// </summary>
            Renamer_FindRenameLocationsAsync = 387,
            /// <summary>
            /// Renamer_ResolveConflictsAsync.
            /// </summary>
            Renamer_ResolveConflictsAsync = 388,
            /// <summary>
            /// ChangeSignature_Data.
            /// </summary>
            ChangeSignature_Data = 400,
            /// <summary>
            /// AbstractEncapsulateFieldService_EncapsulateFieldsAsync.
            /// </summary>
            AbstractEncapsulateFieldService_EncapsulateFieldsAsync = 410,
            /// <summary>
            /// AbstractConvertTupleToStructCodeRefactoringProvider_ConvertToStructAsync.
            /// </summary>
            AbstractConvertTupleToStructCodeRefactoringProvider_ConvertToStructAsync = 420,
            /// <summary>
            /// DependentTypeFinder_FindAndCacheDerivedClassesAsync.
            /// </summary>
            DependentTypeFinder_FindAndCacheDerivedClassesAsync = 430,
            /// <summary>
            /// DependentTypeFinder_FindAndCacheDerivedInterfacesAsync.
            /// </summary>
            DependentTypeFinder_FindAndCacheDerivedInterfacesAsync = 431,
            /// <summary>
            /// DependentTypeFinder_FindAndCacheImplementingTypesAsync.
            /// </summary>
            DependentTypeFinder_FindAndCacheImplementingTypesAsync = 432,
            /// <summary>
            /// RemoteSemanticClassificationCacheService_ExceptionInCacheRead.
            /// </summary>
            RemoteSemanticClassificationCacheService_ExceptionInCacheRead = 440,
            /// <summary>
            /// FeatureNotAvailable.
            /// </summary>
            FeatureNotAvailable = 441,
            /// <summary>
            /// LSPCompletion_MissingLSPCompletionTriggerKind.
            /// </summary>
            LSPCompletion_MissingLSPCompletionTriggerKind = 450,
            /// <summary>
            /// LSPCompletion_MissingLSPCompletionInvokeKind.
            /// </summary>
            LSPCompletion_MissingLSPCompletionInvokeKind = 451,
            /// <summary>
            /// Workspace_Project_CompilationThrownAway.
            /// </summary>
            Workspace_Project_CompilationThrownAway = 460,
            /// <summary>
            /// CommandHandler_Paste_ImportsOnPaste.
            /// </summary>
            CommandHandler_Paste_ImportsOnPaste = 470,
            /// <summary>
            /// FindDocumentInWorkspace.
            /// </summary>
            FindDocumentInWorkspace = 480,
            /// <summary>
            /// RegisterWorkspace.
            /// </summary>
            RegisterWorkspace = 481,
            /// <summary>
            /// LSP_RequestCounter.
            /// </summary>
            LSP_RequestCounter = 482,
            /// <summary>
            /// LSP_RequestDuration.
            /// </summary>
            LSP_RequestDuration = 483,
            /// <summary>
            /// LSP_TimeInQueue.
            /// </summary>
            LSP_TimeInQueue = 484,
        }
    }
}
