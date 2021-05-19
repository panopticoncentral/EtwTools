using System;

#pragma warning disable IDE0004 // Remove Unnecessary Cast
#pragma warning disable CA1707 // Identifiers should not contain underscores
#pragma warning disable CA1720 // Identifier contains type name

namespace EtwTools
{
    /// <summary>
    /// Provider for System.Threading.Tasks.TplEventSource (2e5dba47-a3d2-4d16-8ee0-6671ffdcd7b5)
    /// </summary>
    public sealed class TplEventSourceProvider
    {
        /// <summary>s
        /// Provider ID.
        /// </summary>
        public static readonly Guid Id = new("2e5dba47-a3d2-4d16-8ee0-6671ffdcd7b5");

        /// <summary>
        /// Provider name.
        /// </summary>
        public const string Name = "System.Threading.Tasks.TplEventSource";

        /// <summary>
        /// Tasks supported by System.Threading.Tasks.TplEventSource.
        /// </summary>
        public enum Tasks : ushort
        {
            /// <summary>
            /// 'Loop' task.
            /// </summary>
            Loop = 1,
            /// <summary>
            /// 'Invoke' task.
            /// </summary>
            Invoke = 2,
            /// <summary>
            /// 'TaskExecute' task.
            /// </summary>
            TaskExecute = 3,
            /// <summary>
            /// 'TaskWait' task.
            /// </summary>
            TaskWait = 4,
            /// <summary>
            /// 'ForkJoin' task.
            /// </summary>
            ForkJoin = 5,
            /// <summary>
            /// 'TaskScheduled' task.
            /// </summary>
            TaskScheduled = 6,
            /// <summary>
            /// 'AwaitTaskContinuationScheduled' task.
            /// </summary>
            AwaitTaskContinuationScheduled = 7,
            /// <summary>
            /// 'TraceOperation' task.
            /// </summary>
            TraceOperation = 8,
            /// <summary>
            /// 'TraceSynchronousWork' task.
            /// </summary>
            TraceSynchronousWork = 9,
            /// <summary>
            /// 'NewID' task.
            /// </summary>
            NewID = 65508,
            /// <summary>
            /// 'SetActivityId' task.
            /// </summary>
            SetActivityId = 65509,
            /// <summary>
            /// 'DebugFacilityMessage1' task.
            /// </summary>
            DebugFacilityMessage1 = 65510,
            /// <summary>
            /// 'DebugFacilityMessage' task.
            /// </summary>
            DebugFacilityMessage = 65511,
            /// <summary>
            /// 'DebugMessage' task.
            /// </summary>
            DebugMessage = 65512,
            /// <summary>
            /// 'RunningContinuationList' task.
            /// </summary>
            RunningContinuationList = 65513,
            /// <summary>
            /// 'RunningContinuation' task.
            /// </summary>
            RunningContinuation = 65514,
            /// <summary>
            /// 'TaskWaitContinuationStarted' task.
            /// </summary>
            TaskWaitContinuationStarted = 65515,
            /// <summary>
            /// 'TraceSynchronousWorkEnd' task.
            /// </summary>
            TraceSynchronousWorkEnd = 65516,
            /// <summary>
            /// 'TraceSynchronousWorkBegin' task.
            /// </summary>
            TraceSynchronousWorkBegin = 65517,
            /// <summary>
            /// 'TraceOperationRelation' task.
            /// </summary>
            TraceOperationRelation = 65518,
            /// <summary>
            /// 'TraceOperationEnd' task.
            /// </summary>
            TraceOperationEnd = 65519,
            /// <summary>
            /// 'TraceOperationBegin' task.
            /// </summary>
            TraceOperationBegin = 65520,
            /// <summary>
            /// 'TaskWaitContinuationComplete' task.
            /// </summary>
            TaskWaitContinuationComplete = 65521,
            /// <summary>
            /// 'TaskWaitEnd' task.
            /// </summary>
            TaskWaitEnd = 65523,
            /// <summary>
            /// 'TaskCompleted' task.
            /// </summary>
            TaskCompleted = 65525,
            /// <summary>
            /// 'TaskStarted' task.
            /// </summary>
            TaskStarted = 65526,
            /// <summary>
            /// 'EventSourceMessage' task.
            /// </summary>
            EventSourceMessage = 65534,
        }

        /// <summary>
        /// Keywords supported by TplEventSource.
        /// </summary>
        [Flags]
        public enum Keywords : ulong
        {
            /// <summary>
            /// 'TaskTransfer' keyword.
            /// </summary>
            TaskTransfer = 0x0000000000000001,
            /// <summary>
            /// 'Tasks' keyword.
            /// </summary>
            Tasks = 0x0000000000000002,
            /// <summary>
            /// 'Parallel' keyword.
            /// </summary>
            Parallel = 0x0000000000000004,
            /// <summary>
            /// 'AsyncCausalityOperation' keyword.
            /// </summary>
            AsyncCausalityOperation = 0x0000000000000008,
            /// <summary>
            /// 'AsyncCausalityRelation' keyword.
            /// </summary>
            AsyncCausalityRelation = 0x0000000000000010,
            /// <summary>
            /// 'AsyncCausalitySynchronousWork' keyword.
            /// </summary>
            AsyncCausalitySynchronousWork = 0x0000000000000020,
            /// <summary>
            /// 'TaskStops' keyword.
            /// </summary>
            TaskStops = 0x0000000000000040,
            /// <summary>
            /// 'TasksFlowActivityIds' keyword.
            /// </summary>
            TasksFlowActivityIds = 0x0000000000000080,
            /// <summary>
            /// 'TasksSetActivityIds' keyword.
            /// </summary>
            TasksSetActivityIds = 0x0000000000010000,
            /// <summary>
            /// 'Debug' keyword.
            /// </summary>
            Debug = 0x0000000000020000,
            /// <summary>
            /// 'DebugActivityId' keyword.
            /// </summary>
            DebugActivityId = 0x0000000000040000,
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
                public string Message => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Message..]);

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
        /// An event wrapper for a ParallelLoopBegin event.
        /// </summary>
        public readonly ref struct ParallelLoopBeginEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ParallelLoopBegin";

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
                Opcode = EtwEventOpcode.Start,
                Task = (ushort)Tasks.Loop,
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
            public ParallelLoopBeginData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ParallelLoopBeginEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ParallelLoopBeginEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ParallelLoopBegin event.
            /// </summary>
            public ref struct ParallelLoopBeginData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_OriginatingTaskSchedulerID;
                private int _offset_OriginatingTaskID;
                private int _offset_ForkJoinContextID;
                private int _offset_OperationType;
                private int _offset_InclusiveFrom;
                private int _offset_ExclusiveTo;

                private int Offset_OriginatingTaskSchedulerID
                {
                    get
                    {
                        if (_offset_OriginatingTaskSchedulerID == -1)
                        {
                            _offset_OriginatingTaskSchedulerID = 0;
                        }

                        return _offset_OriginatingTaskSchedulerID;
                    }
                }

                private int Offset_OriginatingTaskID
                {
                    get
                    {
                        if (_offset_OriginatingTaskID == -1)
                        {
                            _offset_OriginatingTaskID = Offset_OriginatingTaskSchedulerID + 4;
                        }

                        return _offset_OriginatingTaskID;
                    }
                }

                private int Offset_ForkJoinContextID
                {
                    get
                    {
                        if (_offset_ForkJoinContextID == -1)
                        {
                            _offset_ForkJoinContextID = Offset_OriginatingTaskID + 4;
                        }

                        return _offset_ForkJoinContextID;
                    }
                }

                private int Offset_OperationType
                {
                    get
                    {
                        if (_offset_OperationType == -1)
                        {
                            _offset_OperationType = Offset_ForkJoinContextID + 4;
                        }

                        return _offset_OperationType;
                    }
                }

                private int Offset_InclusiveFrom
                {
                    get
                    {
                        if (_offset_InclusiveFrom == -1)
                        {
                            _offset_InclusiveFrom = Offset_OperationType + 4;
                        }

                        return _offset_InclusiveFrom;
                    }
                }

                private int Offset_ExclusiveTo
                {
                    get
                    {
                        if (_offset_ExclusiveTo == -1)
                        {
                            _offset_ExclusiveTo = Offset_InclusiveFrom + 8;
                        }

                        return _offset_ExclusiveTo;
                    }
                }

                /// <summary>
                /// Retrieves the OriginatingTaskSchedulerID field.
                /// </summary>
                public int OriginatingTaskSchedulerID => BitConverter.ToInt32(_etwEvent.Data[Offset_OriginatingTaskSchedulerID..]);

                /// <summary>
                /// Retrieves the OriginatingTaskID field.
                /// </summary>
                public int OriginatingTaskID => BitConverter.ToInt32(_etwEvent.Data[Offset_OriginatingTaskID..]);

                /// <summary>
                /// Retrieves the ForkJoinContextID field.
                /// </summary>
                public int ForkJoinContextID => BitConverter.ToInt32(_etwEvent.Data[Offset_ForkJoinContextID..]);

                /// <summary>
                /// Retrieves the OperationType field.
                /// </summary>
                public ForkJoinOperationType OperationType => (ForkJoinOperationType)BitConverter.ToUInt32(_etwEvent.Data[Offset_OperationType..]);

                /// <summary>
                /// Retrieves the InclusiveFrom field.
                /// </summary>
                public long InclusiveFrom => BitConverter.ToInt64(_etwEvent.Data[Offset_InclusiveFrom..]);

                /// <summary>
                /// Retrieves the ExclusiveTo field.
                /// </summary>
                public long ExclusiveTo => BitConverter.ToInt64(_etwEvent.Data[Offset_ExclusiveTo..]);

                /// <summary>
                /// Creates a new ParallelLoopBeginData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ParallelLoopBeginData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_OriginatingTaskSchedulerID = -1;
                    _offset_OriginatingTaskID = -1;
                    _offset_ForkJoinContextID = -1;
                    _offset_OperationType = -1;
                    _offset_InclusiveFrom = -1;
                    _offset_ExclusiveTo = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ParallelLoopEnd event.
        /// </summary>
        public readonly ref struct ParallelLoopEndEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ParallelLoopEnd";

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
                Opcode = EtwEventOpcode.End,
                Task = (ushort)Tasks.Loop,
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
            public ParallelLoopEndData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ParallelLoopEndEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ParallelLoopEndEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ParallelLoopEnd event.
            /// </summary>
            public ref struct ParallelLoopEndData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_OriginatingTaskSchedulerID;
                private int _offset_OriginatingTaskID;
                private int _offset_ForkJoinContextID;
                private int _offset_TotalIterations;

                private int Offset_OriginatingTaskSchedulerID
                {
                    get
                    {
                        if (_offset_OriginatingTaskSchedulerID == -1)
                        {
                            _offset_OriginatingTaskSchedulerID = 0;
                        }

                        return _offset_OriginatingTaskSchedulerID;
                    }
                }

                private int Offset_OriginatingTaskID
                {
                    get
                    {
                        if (_offset_OriginatingTaskID == -1)
                        {
                            _offset_OriginatingTaskID = Offset_OriginatingTaskSchedulerID + 4;
                        }

                        return _offset_OriginatingTaskID;
                    }
                }

                private int Offset_ForkJoinContextID
                {
                    get
                    {
                        if (_offset_ForkJoinContextID == -1)
                        {
                            _offset_ForkJoinContextID = Offset_OriginatingTaskID + 4;
                        }

                        return _offset_ForkJoinContextID;
                    }
                }

                private int Offset_TotalIterations
                {
                    get
                    {
                        if (_offset_TotalIterations == -1)
                        {
                            _offset_TotalIterations = Offset_ForkJoinContextID + 4;
                        }

                        return _offset_TotalIterations;
                    }
                }

                /// <summary>
                /// Retrieves the OriginatingTaskSchedulerID field.
                /// </summary>
                public int OriginatingTaskSchedulerID => BitConverter.ToInt32(_etwEvent.Data[Offset_OriginatingTaskSchedulerID..]);

                /// <summary>
                /// Retrieves the OriginatingTaskID field.
                /// </summary>
                public int OriginatingTaskID => BitConverter.ToInt32(_etwEvent.Data[Offset_OriginatingTaskID..]);

                /// <summary>
                /// Retrieves the ForkJoinContextID field.
                /// </summary>
                public int ForkJoinContextID => BitConverter.ToInt32(_etwEvent.Data[Offset_ForkJoinContextID..]);

                /// <summary>
                /// Retrieves the TotalIterations field.
                /// </summary>
                public long TotalIterations => BitConverter.ToInt64(_etwEvent.Data[Offset_TotalIterations..]);

                /// <summary>
                /// Creates a new ParallelLoopEndData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ParallelLoopEndData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_OriginatingTaskSchedulerID = -1;
                    _offset_OriginatingTaskID = -1;
                    _offset_ForkJoinContextID = -1;
                    _offset_TotalIterations = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ParallelInvokeBegin event.
        /// </summary>
        public readonly ref struct ParallelInvokeBeginEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ParallelInvokeBegin";

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
                Opcode = EtwEventOpcode.Start,
                Task = (ushort)Tasks.Invoke,
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
            public ParallelInvokeBeginData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ParallelInvokeBeginEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ParallelInvokeBeginEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ParallelInvokeBegin event.
            /// </summary>
            public ref struct ParallelInvokeBeginData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_OriginatingTaskSchedulerID;
                private int _offset_OriginatingTaskID;
                private int _offset_ForkJoinContextID;
                private int _offset_OperationType;
                private int _offset_ActionCount;

                private int Offset_OriginatingTaskSchedulerID
                {
                    get
                    {
                        if (_offset_OriginatingTaskSchedulerID == -1)
                        {
                            _offset_OriginatingTaskSchedulerID = 0;
                        }

                        return _offset_OriginatingTaskSchedulerID;
                    }
                }

                private int Offset_OriginatingTaskID
                {
                    get
                    {
                        if (_offset_OriginatingTaskID == -1)
                        {
                            _offset_OriginatingTaskID = Offset_OriginatingTaskSchedulerID + 4;
                        }

                        return _offset_OriginatingTaskID;
                    }
                }

                private int Offset_ForkJoinContextID
                {
                    get
                    {
                        if (_offset_ForkJoinContextID == -1)
                        {
                            _offset_ForkJoinContextID = Offset_OriginatingTaskID + 4;
                        }

                        return _offset_ForkJoinContextID;
                    }
                }

                private int Offset_OperationType
                {
                    get
                    {
                        if (_offset_OperationType == -1)
                        {
                            _offset_OperationType = Offset_ForkJoinContextID + 4;
                        }

                        return _offset_OperationType;
                    }
                }

                private int Offset_ActionCount
                {
                    get
                    {
                        if (_offset_ActionCount == -1)
                        {
                            _offset_ActionCount = Offset_OperationType + 4;
                        }

                        return _offset_ActionCount;
                    }
                }

                /// <summary>
                /// Retrieves the OriginatingTaskSchedulerID field.
                /// </summary>
                public int OriginatingTaskSchedulerID => BitConverter.ToInt32(_etwEvent.Data[Offset_OriginatingTaskSchedulerID..]);

                /// <summary>
                /// Retrieves the OriginatingTaskID field.
                /// </summary>
                public int OriginatingTaskID => BitConverter.ToInt32(_etwEvent.Data[Offset_OriginatingTaskID..]);

                /// <summary>
                /// Retrieves the ForkJoinContextID field.
                /// </summary>
                public int ForkJoinContextID => BitConverter.ToInt32(_etwEvent.Data[Offset_ForkJoinContextID..]);

                /// <summary>
                /// Retrieves the OperationType field.
                /// </summary>
                public ForkJoinOperationType OperationType => (ForkJoinOperationType)BitConverter.ToUInt32(_etwEvent.Data[Offset_OperationType..]);

                /// <summary>
                /// Retrieves the ActionCount field.
                /// </summary>
                public int ActionCount => BitConverter.ToInt32(_etwEvent.Data[Offset_ActionCount..]);

                /// <summary>
                /// Creates a new ParallelInvokeBeginData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ParallelInvokeBeginData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_OriginatingTaskSchedulerID = -1;
                    _offset_OriginatingTaskID = -1;
                    _offset_ForkJoinContextID = -1;
                    _offset_OperationType = -1;
                    _offset_ActionCount = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ParallelInvokeEnd event.
        /// </summary>
        public readonly ref struct ParallelInvokeEndEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ParallelInvokeEnd";

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
                Opcode = EtwEventOpcode.End,
                Task = (ushort)Tasks.Invoke,
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
            public ParallelInvokeEndData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ParallelInvokeEndEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ParallelInvokeEndEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ParallelInvokeEnd event.
            /// </summary>
            public ref struct ParallelInvokeEndData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_OriginatingTaskSchedulerID;
                private int _offset_OriginatingTaskID;
                private int _offset_ForkJoinContextID;

                private int Offset_OriginatingTaskSchedulerID
                {
                    get
                    {
                        if (_offset_OriginatingTaskSchedulerID == -1)
                        {
                            _offset_OriginatingTaskSchedulerID = 0;
                        }

                        return _offset_OriginatingTaskSchedulerID;
                    }
                }

                private int Offset_OriginatingTaskID
                {
                    get
                    {
                        if (_offset_OriginatingTaskID == -1)
                        {
                            _offset_OriginatingTaskID = Offset_OriginatingTaskSchedulerID + 4;
                        }

                        return _offset_OriginatingTaskID;
                    }
                }

                private int Offset_ForkJoinContextID
                {
                    get
                    {
                        if (_offset_ForkJoinContextID == -1)
                        {
                            _offset_ForkJoinContextID = Offset_OriginatingTaskID + 4;
                        }

                        return _offset_ForkJoinContextID;
                    }
                }

                /// <summary>
                /// Retrieves the OriginatingTaskSchedulerID field.
                /// </summary>
                public int OriginatingTaskSchedulerID => BitConverter.ToInt32(_etwEvent.Data[Offset_OriginatingTaskSchedulerID..]);

                /// <summary>
                /// Retrieves the OriginatingTaskID field.
                /// </summary>
                public int OriginatingTaskID => BitConverter.ToInt32(_etwEvent.Data[Offset_OriginatingTaskID..]);

                /// <summary>
                /// Retrieves the ForkJoinContextID field.
                /// </summary>
                public int ForkJoinContextID => BitConverter.ToInt32(_etwEvent.Data[Offset_ForkJoinContextID..]);

                /// <summary>
                /// Creates a new ParallelInvokeEndData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ParallelInvokeEndData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_OriginatingTaskSchedulerID = -1;
                    _offset_OriginatingTaskID = -1;
                    _offset_ForkJoinContextID = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ParallelFork event.
        /// </summary>
        public readonly ref struct ParallelForkEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ParallelFork";

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
                Level = EtwTraceLevel.Verbose,
                Opcode = EtwEventOpcode.Start,
                Task = (ushort)Tasks.ForkJoin,
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
            public ParallelForkData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ParallelForkEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ParallelForkEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ParallelFork event.
            /// </summary>
            public ref struct ParallelForkData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_OriginatingTaskSchedulerID;
                private int _offset_OriginatingTaskID;
                private int _offset_ForkJoinContextID;

                private int Offset_OriginatingTaskSchedulerID
                {
                    get
                    {
                        if (_offset_OriginatingTaskSchedulerID == -1)
                        {
                            _offset_OriginatingTaskSchedulerID = 0;
                        }

                        return _offset_OriginatingTaskSchedulerID;
                    }
                }

                private int Offset_OriginatingTaskID
                {
                    get
                    {
                        if (_offset_OriginatingTaskID == -1)
                        {
                            _offset_OriginatingTaskID = Offset_OriginatingTaskSchedulerID + 4;
                        }

                        return _offset_OriginatingTaskID;
                    }
                }

                private int Offset_ForkJoinContextID
                {
                    get
                    {
                        if (_offset_ForkJoinContextID == -1)
                        {
                            _offset_ForkJoinContextID = Offset_OriginatingTaskID + 4;
                        }

                        return _offset_ForkJoinContextID;
                    }
                }

                /// <summary>
                /// Retrieves the OriginatingTaskSchedulerID field.
                /// </summary>
                public int OriginatingTaskSchedulerID => BitConverter.ToInt32(_etwEvent.Data[Offset_OriginatingTaskSchedulerID..]);

                /// <summary>
                /// Retrieves the OriginatingTaskID field.
                /// </summary>
                public int OriginatingTaskID => BitConverter.ToInt32(_etwEvent.Data[Offset_OriginatingTaskID..]);

                /// <summary>
                /// Retrieves the ForkJoinContextID field.
                /// </summary>
                public int ForkJoinContextID => BitConverter.ToInt32(_etwEvent.Data[Offset_ForkJoinContextID..]);

                /// <summary>
                /// Creates a new ParallelForkData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ParallelForkData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_OriginatingTaskSchedulerID = -1;
                    _offset_OriginatingTaskID = -1;
                    _offset_ForkJoinContextID = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ParallelJoin event.
        /// </summary>
        public readonly ref struct ParallelJoinEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ParallelJoin";

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
                Level = EtwTraceLevel.Verbose,
                Opcode = EtwEventOpcode.End,
                Task = (ushort)Tasks.ForkJoin,
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
            public ParallelJoinData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ParallelJoinEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ParallelJoinEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ParallelJoin event.
            /// </summary>
            public ref struct ParallelJoinData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_OriginatingTaskSchedulerID;
                private int _offset_OriginatingTaskID;
                private int _offset_ForkJoinContextID;

                private int Offset_OriginatingTaskSchedulerID
                {
                    get
                    {
                        if (_offset_OriginatingTaskSchedulerID == -1)
                        {
                            _offset_OriginatingTaskSchedulerID = 0;
                        }

                        return _offset_OriginatingTaskSchedulerID;
                    }
                }

                private int Offset_OriginatingTaskID
                {
                    get
                    {
                        if (_offset_OriginatingTaskID == -1)
                        {
                            _offset_OriginatingTaskID = Offset_OriginatingTaskSchedulerID + 4;
                        }

                        return _offset_OriginatingTaskID;
                    }
                }

                private int Offset_ForkJoinContextID
                {
                    get
                    {
                        if (_offset_ForkJoinContextID == -1)
                        {
                            _offset_ForkJoinContextID = Offset_OriginatingTaskID + 4;
                        }

                        return _offset_ForkJoinContextID;
                    }
                }

                /// <summary>
                /// Retrieves the OriginatingTaskSchedulerID field.
                /// </summary>
                public int OriginatingTaskSchedulerID => BitConverter.ToInt32(_etwEvent.Data[Offset_OriginatingTaskSchedulerID..]);

                /// <summary>
                /// Retrieves the OriginatingTaskID field.
                /// </summary>
                public int OriginatingTaskID => BitConverter.ToInt32(_etwEvent.Data[Offset_OriginatingTaskID..]);

                /// <summary>
                /// Retrieves the ForkJoinContextID field.
                /// </summary>
                public int ForkJoinContextID => BitConverter.ToInt32(_etwEvent.Data[Offset_ForkJoinContextID..]);

                /// <summary>
                /// Creates a new ParallelJoinData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ParallelJoinData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_OriginatingTaskSchedulerID = -1;
                    _offset_OriginatingTaskID = -1;
                    _offset_ForkJoinContextID = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a TaskScheduled event.
        /// </summary>
        public readonly ref struct TaskScheduledEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "TaskScheduled";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 7,
                Version = 1,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Send,
                Task = (ushort)Tasks.TaskScheduled,
                Keyword = (ulong)Keywords.TaskTransfer | (ulong)Keywords.Tasks
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
            public TaskScheduledData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new TaskScheduledEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public TaskScheduledEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a TaskScheduled event.
            /// </summary>
            public ref struct TaskScheduledData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_OriginatingTaskSchedulerID;
                private int _offset_OriginatingTaskID;
                private int _offset_TaskID;
                private int _offset_CreatingTaskID;
                private int _offset_TaskCreationOptions;
                private int _offset_AppDomain;

                private int Offset_OriginatingTaskSchedulerID
                {
                    get
                    {
                        if (_offset_OriginatingTaskSchedulerID == -1)
                        {
                            _offset_OriginatingTaskSchedulerID = 0;
                        }

                        return _offset_OriginatingTaskSchedulerID;
                    }
                }

                private int Offset_OriginatingTaskID
                {
                    get
                    {
                        if (_offset_OriginatingTaskID == -1)
                        {
                            _offset_OriginatingTaskID = Offset_OriginatingTaskSchedulerID + 4;
                        }

                        return _offset_OriginatingTaskID;
                    }
                }

                private int Offset_TaskID
                {
                    get
                    {
                        if (_offset_TaskID == -1)
                        {
                            _offset_TaskID = Offset_OriginatingTaskID + 4;
                        }

                        return _offset_TaskID;
                    }
                }

                private int Offset_CreatingTaskID
                {
                    get
                    {
                        if (_offset_CreatingTaskID == -1)
                        {
                            _offset_CreatingTaskID = Offset_TaskID + 4;
                        }

                        return _offset_CreatingTaskID;
                    }
                }

                private int Offset_TaskCreationOptions
                {
                    get
                    {
                        if (_offset_TaskCreationOptions == -1)
                        {
                            _offset_TaskCreationOptions = Offset_CreatingTaskID + 4;
                        }

                        return _offset_TaskCreationOptions;
                    }
                }

                private int Offset_AppDomain
                {
                    get
                    {
                        if (_offset_AppDomain == -1)
                        {
                            _offset_AppDomain = Offset_TaskCreationOptions + 4;
                        }

                        return _offset_AppDomain;
                    }
                }

                /// <summary>
                /// Retrieves the OriginatingTaskSchedulerID field.
                /// </summary>
                public int OriginatingTaskSchedulerID => BitConverter.ToInt32(_etwEvent.Data[Offset_OriginatingTaskSchedulerID..]);

                /// <summary>
                /// Retrieves the OriginatingTaskID field.
                /// </summary>
                public int OriginatingTaskID => BitConverter.ToInt32(_etwEvent.Data[Offset_OriginatingTaskID..]);

                /// <summary>
                /// Retrieves the TaskID field.
                /// </summary>
                public int TaskID => BitConverter.ToInt32(_etwEvent.Data[Offset_TaskID..]);

                /// <summary>
                /// Retrieves the CreatingTaskID field.
                /// </summary>
                public int CreatingTaskID => BitConverter.ToInt32(_etwEvent.Data[Offset_CreatingTaskID..]);

                /// <summary>
                /// Retrieves the TaskCreationOptions field.
                /// </summary>
                public int TaskCreationOptions => BitConverter.ToInt32(_etwEvent.Data[Offset_TaskCreationOptions..]);

                /// <summary>
                /// Retrieves the AppDomain field.
                /// </summary>
                public int AppDomain => BitConverter.ToInt32(_etwEvent.Data[Offset_AppDomain..]);

                /// <summary>
                /// Creates a new TaskScheduledData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public TaskScheduledData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_OriginatingTaskSchedulerID = -1;
                    _offset_OriginatingTaskID = -1;
                    _offset_TaskID = -1;
                    _offset_CreatingTaskID = -1;
                    _offset_TaskCreationOptions = -1;
                    _offset_AppDomain = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a TaskStarted event.
        /// </summary>
        public readonly ref struct TaskStartedEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "TaskStarted";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 8,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.TaskStarted,
                Keyword = (ulong)Keywords.Tasks
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
            public TaskStartedData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new TaskStartedEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public TaskStartedEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a TaskStarted event.
            /// </summary>
            public ref struct TaskStartedData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_OriginatingTaskSchedulerID;
                private int _offset_OriginatingTaskID;
                private int _offset_TaskID;

                private int Offset_OriginatingTaskSchedulerID
                {
                    get
                    {
                        if (_offset_OriginatingTaskSchedulerID == -1)
                        {
                            _offset_OriginatingTaskSchedulerID = 0;
                        }

                        return _offset_OriginatingTaskSchedulerID;
                    }
                }

                private int Offset_OriginatingTaskID
                {
                    get
                    {
                        if (_offset_OriginatingTaskID == -1)
                        {
                            _offset_OriginatingTaskID = Offset_OriginatingTaskSchedulerID + 4;
                        }

                        return _offset_OriginatingTaskID;
                    }
                }

                private int Offset_TaskID
                {
                    get
                    {
                        if (_offset_TaskID == -1)
                        {
                            _offset_TaskID = Offset_OriginatingTaskID + 4;
                        }

                        return _offset_TaskID;
                    }
                }

                /// <summary>
                /// Retrieves the OriginatingTaskSchedulerID field.
                /// </summary>
                public int OriginatingTaskSchedulerID => BitConverter.ToInt32(_etwEvent.Data[Offset_OriginatingTaskSchedulerID..]);

                /// <summary>
                /// Retrieves the OriginatingTaskID field.
                /// </summary>
                public int OriginatingTaskID => BitConverter.ToInt32(_etwEvent.Data[Offset_OriginatingTaskID..]);

                /// <summary>
                /// Retrieves the TaskID field.
                /// </summary>
                public int TaskID => BitConverter.ToInt32(_etwEvent.Data[Offset_TaskID..]);

                /// <summary>
                /// Creates a new TaskStartedData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public TaskStartedData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_OriginatingTaskSchedulerID = -1;
                    _offset_OriginatingTaskID = -1;
                    _offset_TaskID = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a TaskCompleted event.
        /// </summary>
        public readonly ref struct TaskCompletedEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "TaskCompleted";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 9,
                Version = 1,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.TaskCompleted,
                Keyword = (ulong)Keywords.TaskStops
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
            public TaskCompletedData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new TaskCompletedEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public TaskCompletedEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a TaskCompleted event.
            /// </summary>
            public ref struct TaskCompletedData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_OriginatingTaskSchedulerID;
                private int _offset_OriginatingTaskID;
                private int _offset_TaskID;
                private int _offset_IsExceptional;

                private int Offset_OriginatingTaskSchedulerID
                {
                    get
                    {
                        if (_offset_OriginatingTaskSchedulerID == -1)
                        {
                            _offset_OriginatingTaskSchedulerID = 0;
                        }

                        return _offset_OriginatingTaskSchedulerID;
                    }
                }

                private int Offset_OriginatingTaskID
                {
                    get
                    {
                        if (_offset_OriginatingTaskID == -1)
                        {
                            _offset_OriginatingTaskID = Offset_OriginatingTaskSchedulerID + 4;
                        }

                        return _offset_OriginatingTaskID;
                    }
                }

                private int Offset_TaskID
                {
                    get
                    {
                        if (_offset_TaskID == -1)
                        {
                            _offset_TaskID = Offset_OriginatingTaskID + 4;
                        }

                        return _offset_TaskID;
                    }
                }

                private int Offset_IsExceptional
                {
                    get
                    {
                        if (_offset_IsExceptional == -1)
                        {
                            _offset_IsExceptional = Offset_TaskID + 4;
                        }

                        return _offset_IsExceptional;
                    }
                }

                /// <summary>
                /// Retrieves the OriginatingTaskSchedulerID field.
                /// </summary>
                public int OriginatingTaskSchedulerID => BitConverter.ToInt32(_etwEvent.Data[Offset_OriginatingTaskSchedulerID..]);

                /// <summary>
                /// Retrieves the OriginatingTaskID field.
                /// </summary>
                public int OriginatingTaskID => BitConverter.ToInt32(_etwEvent.Data[Offset_OriginatingTaskID..]);

                /// <summary>
                /// Retrieves the TaskID field.
                /// </summary>
                public int TaskID => BitConverter.ToInt32(_etwEvent.Data[Offset_TaskID..]);

                /// <summary>
                /// Retrieves the IsExceptional field.
                /// </summary>
                public bool IsExceptional => _etwEvent.Data[Offset_IsExceptional] != 0;

                /// <summary>
                /// Creates a new TaskCompletedData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public TaskCompletedData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_OriginatingTaskSchedulerID = -1;
                    _offset_OriginatingTaskID = -1;
                    _offset_TaskID = -1;
                    _offset_IsExceptional = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a TaskWaitBegin event.
        /// </summary>
        public readonly ref struct TaskWaitBeginEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "TaskWaitBegin";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 10,
                Version = 3,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Send,
                Task = (ushort)Tasks.TaskWait,
                Keyword = (ulong)Keywords.TaskTransfer | (ulong)Keywords.Tasks
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
            public TaskWaitBeginData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new TaskWaitBeginEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public TaskWaitBeginEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a TaskWaitBegin event.
            /// </summary>
            public ref struct TaskWaitBeginData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_OriginatingTaskSchedulerID;
                private int _offset_OriginatingTaskID;
                private int _offset_TaskID;
                private int _offset_Behavior;
                private int _offset_ContinueWithTaskID;
                private int _offset_AppDomain;

                private int Offset_OriginatingTaskSchedulerID
                {
                    get
                    {
                        if (_offset_OriginatingTaskSchedulerID == -1)
                        {
                            _offset_OriginatingTaskSchedulerID = 0;
                        }

                        return _offset_OriginatingTaskSchedulerID;
                    }
                }

                private int Offset_OriginatingTaskID
                {
                    get
                    {
                        if (_offset_OriginatingTaskID == -1)
                        {
                            _offset_OriginatingTaskID = Offset_OriginatingTaskSchedulerID + 4;
                        }

                        return _offset_OriginatingTaskID;
                    }
                }

                private int Offset_TaskID
                {
                    get
                    {
                        if (_offset_TaskID == -1)
                        {
                            _offset_TaskID = Offset_OriginatingTaskID + 4;
                        }

                        return _offset_TaskID;
                    }
                }

                private int Offset_Behavior
                {
                    get
                    {
                        if (_offset_Behavior == -1)
                        {
                            _offset_Behavior = Offset_TaskID + 4;
                        }

                        return _offset_Behavior;
                    }
                }

                private int Offset_ContinueWithTaskID
                {
                    get
                    {
                        if (_offset_ContinueWithTaskID == -1)
                        {
                            _offset_ContinueWithTaskID = Offset_Behavior + 4;
                        }

                        return _offset_ContinueWithTaskID;
                    }
                }

                private int Offset_AppDomain
                {
                    get
                    {
                        if (_offset_AppDomain == -1)
                        {
                            _offset_AppDomain = Offset_ContinueWithTaskID + 4;
                        }

                        return _offset_AppDomain;
                    }
                }

                /// <summary>
                /// Retrieves the OriginatingTaskSchedulerID field.
                /// </summary>
                public int OriginatingTaskSchedulerID => BitConverter.ToInt32(_etwEvent.Data[Offset_OriginatingTaskSchedulerID..]);

                /// <summary>
                /// Retrieves the OriginatingTaskID field.
                /// </summary>
                public int OriginatingTaskID => BitConverter.ToInt32(_etwEvent.Data[Offset_OriginatingTaskID..]);

                /// <summary>
                /// Retrieves the TaskID field.
                /// </summary>
                public int TaskID => BitConverter.ToInt32(_etwEvent.Data[Offset_TaskID..]);

                /// <summary>
                /// Retrieves the Behavior field.
                /// </summary>
                public TaskWaitBehavior Behavior => (TaskWaitBehavior)BitConverter.ToUInt32(_etwEvent.Data[Offset_Behavior..]);

                /// <summary>
                /// Retrieves the ContinueWithTaskID field.
                /// </summary>
                public int ContinueWithTaskID => BitConverter.ToInt32(_etwEvent.Data[Offset_ContinueWithTaskID..]);

                /// <summary>
                /// Retrieves the AppDomain field.
                /// </summary>
                public int AppDomain => BitConverter.ToInt32(_etwEvent.Data[Offset_AppDomain..]);

                /// <summary>
                /// Creates a new TaskWaitBeginData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public TaskWaitBeginData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_OriginatingTaskSchedulerID = -1;
                    _offset_OriginatingTaskID = -1;
                    _offset_TaskID = -1;
                    _offset_Behavior = -1;
                    _offset_ContinueWithTaskID = -1;
                    _offset_AppDomain = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a TaskWaitEnd event.
        /// </summary>
        public readonly ref struct TaskWaitEndEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "TaskWaitEnd";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 11,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Verbose,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.TaskWaitEnd,
                Keyword = (ulong)Keywords.Tasks
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
            public TaskWaitEndData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new TaskWaitEndEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public TaskWaitEndEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a TaskWaitEnd event.
            /// </summary>
            public ref struct TaskWaitEndData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_OriginatingTaskSchedulerID;
                private int _offset_OriginatingTaskID;
                private int _offset_TaskID;

                private int Offset_OriginatingTaskSchedulerID
                {
                    get
                    {
                        if (_offset_OriginatingTaskSchedulerID == -1)
                        {
                            _offset_OriginatingTaskSchedulerID = 0;
                        }

                        return _offset_OriginatingTaskSchedulerID;
                    }
                }

                private int Offset_OriginatingTaskID
                {
                    get
                    {
                        if (_offset_OriginatingTaskID == -1)
                        {
                            _offset_OriginatingTaskID = Offset_OriginatingTaskSchedulerID + 4;
                        }

                        return _offset_OriginatingTaskID;
                    }
                }

                private int Offset_TaskID
                {
                    get
                    {
                        if (_offset_TaskID == -1)
                        {
                            _offset_TaskID = Offset_OriginatingTaskID + 4;
                        }

                        return _offset_TaskID;
                    }
                }

                /// <summary>
                /// Retrieves the OriginatingTaskSchedulerID field.
                /// </summary>
                public int OriginatingTaskSchedulerID => BitConverter.ToInt32(_etwEvent.Data[Offset_OriginatingTaskSchedulerID..]);

                /// <summary>
                /// Retrieves the OriginatingTaskID field.
                /// </summary>
                public int OriginatingTaskID => BitConverter.ToInt32(_etwEvent.Data[Offset_OriginatingTaskID..]);

                /// <summary>
                /// Retrieves the TaskID field.
                /// </summary>
                public int TaskID => BitConverter.ToInt32(_etwEvent.Data[Offset_TaskID..]);

                /// <summary>
                /// Creates a new TaskWaitEndData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public TaskWaitEndData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_OriginatingTaskSchedulerID = -1;
                    _offset_OriginatingTaskID = -1;
                    _offset_TaskID = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a TaskWaitContinuationComplete event.
        /// </summary>
        public readonly ref struct TaskWaitContinuationCompleteEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "TaskWaitContinuationComplete";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 13,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Verbose,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.TaskWaitContinuationComplete,
                Keyword = (ulong)Keywords.TaskStops
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
            public TaskWaitContinuationCompleteData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new TaskWaitContinuationCompleteEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public TaskWaitContinuationCompleteEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a TaskWaitContinuationComplete event.
            /// </summary>
            public ref struct TaskWaitContinuationCompleteData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_TaskID;

                private int Offset_TaskID
                {
                    get
                    {
                        if (_offset_TaskID == -1)
                        {
                            _offset_TaskID = 0;
                        }

                        return _offset_TaskID;
                    }
                }

                /// <summary>
                /// Retrieves the TaskID field.
                /// </summary>
                public int TaskID => BitConverter.ToInt32(_etwEvent.Data[Offset_TaskID..]);

                /// <summary>
                /// Creates a new TaskWaitContinuationCompleteData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public TaskWaitContinuationCompleteData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_TaskID = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a TaskWaitContinuationStarted event.
        /// </summary>
        public readonly ref struct TaskWaitContinuationStartedEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "TaskWaitContinuationStarted";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 19,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Verbose,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.TaskWaitContinuationStarted,
                Keyword = (ulong)Keywords.TaskStops
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
            public TaskWaitContinuationStartedData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new TaskWaitContinuationStartedEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public TaskWaitContinuationStartedEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a TaskWaitContinuationStarted event.
            /// </summary>
            public ref struct TaskWaitContinuationStartedData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_TaskID;

                private int Offset_TaskID
                {
                    get
                    {
                        if (_offset_TaskID == -1)
                        {
                            _offset_TaskID = 0;
                        }

                        return _offset_TaskID;
                    }
                }

                /// <summary>
                /// Retrieves the TaskID field.
                /// </summary>
                public int TaskID => BitConverter.ToInt32(_etwEvent.Data[Offset_TaskID..]);

                /// <summary>
                /// Creates a new TaskWaitContinuationStartedData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public TaskWaitContinuationStartedData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_TaskID = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a AwaitTaskContinuationScheduled event.
        /// </summary>
        public readonly ref struct AwaitTaskContinuationScheduledEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "AwaitTaskContinuationScheduled";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 12,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Send,
                Task = (ushort)Tasks.AwaitTaskContinuationScheduled,
                Keyword = (ulong)Keywords.TaskTransfer | (ulong)Keywords.Tasks
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
            public AwaitTaskContinuationScheduledData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new AwaitTaskContinuationScheduledEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public AwaitTaskContinuationScheduledEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a AwaitTaskContinuationScheduled event.
            /// </summary>
            public ref struct AwaitTaskContinuationScheduledData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_OriginatingTaskSchedulerID;
                private int _offset_OriginatingTaskID;
                private int _offset_ContinuwWithTaskId;

                private int Offset_OriginatingTaskSchedulerID
                {
                    get
                    {
                        if (_offset_OriginatingTaskSchedulerID == -1)
                        {
                            _offset_OriginatingTaskSchedulerID = 0;
                        }

                        return _offset_OriginatingTaskSchedulerID;
                    }
                }

                private int Offset_OriginatingTaskID
                {
                    get
                    {
                        if (_offset_OriginatingTaskID == -1)
                        {
                            _offset_OriginatingTaskID = Offset_OriginatingTaskSchedulerID + 4;
                        }

                        return _offset_OriginatingTaskID;
                    }
                }

                private int Offset_ContinuwWithTaskId
                {
                    get
                    {
                        if (_offset_ContinuwWithTaskId == -1)
                        {
                            _offset_ContinuwWithTaskId = Offset_OriginatingTaskID + 4;
                        }

                        return _offset_ContinuwWithTaskId;
                    }
                }

                /// <summary>
                /// Retrieves the OriginatingTaskSchedulerID field.
                /// </summary>
                public int OriginatingTaskSchedulerID => BitConverter.ToInt32(_etwEvent.Data[Offset_OriginatingTaskSchedulerID..]);

                /// <summary>
                /// Retrieves the OriginatingTaskID field.
                /// </summary>
                public int OriginatingTaskID => BitConverter.ToInt32(_etwEvent.Data[Offset_OriginatingTaskID..]);

                /// <summary>
                /// Retrieves the ContinuwWithTaskId field.
                /// </summary>
                public int ContinuwWithTaskId => BitConverter.ToInt32(_etwEvent.Data[Offset_ContinuwWithTaskId..]);

                /// <summary>
                /// Creates a new AwaitTaskContinuationScheduledData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public AwaitTaskContinuationScheduledData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_OriginatingTaskSchedulerID = -1;
                    _offset_OriginatingTaskID = -1;
                    _offset_ContinuwWithTaskId = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a TraceOperationBegin event.
        /// </summary>
        public readonly ref struct TraceOperationBeginEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "TraceOperationBegin";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 14,
                Version = 1,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.TraceOperationBegin,
                Keyword = (ulong)Keywords.AsyncCausalityOperation
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
            public TraceOperationBeginData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new TraceOperationBeginEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public TraceOperationBeginEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a TraceOperationBegin event.
            /// </summary>
            public ref struct TraceOperationBeginData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_TaskID;
                private int _offset_OperationName;
                private int _offset_RelatedContext;

                private int Offset_TaskID
                {
                    get
                    {
                        if (_offset_TaskID == -1)
                        {
                            _offset_TaskID = 0;
                        }

                        return _offset_TaskID;
                    }
                }

                private int Offset_OperationName
                {
                    get
                    {
                        if (_offset_OperationName == -1)
                        {
                            _offset_OperationName = Offset_TaskID + 4;
                        }

                        return _offset_OperationName;
                    }
                }

                private int Offset_RelatedContext
                {
                    get
                    {
                        if (_offset_RelatedContext == -1)
                        {
                            _offset_RelatedContext = Offset_OperationName + EtwEvent.UnicodeStringEnumerable.UnicodeStringEnumerator.StringLength(_etwEvent.Data, Offset_OperationName);
                        }

                        return _offset_RelatedContext;
                    }
                }

                /// <summary>
                /// Retrieves the TaskID field.
                /// </summary>
                public int TaskID => BitConverter.ToInt32(_etwEvent.Data[Offset_TaskID..]);

                /// <summary>
                /// Retrieves the OperationName field.
                /// </summary>
                public string OperationName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_OperationName..]);

                /// <summary>
                /// Retrieves the RelatedContext field.
                /// </summary>
                public long RelatedContext => BitConverter.ToInt64(_etwEvent.Data[Offset_RelatedContext..]);

                /// <summary>
                /// Creates a new TraceOperationBeginData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public TraceOperationBeginData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_TaskID = -1;
                    _offset_OperationName = -1;
                    _offset_RelatedContext = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a TraceOperationRelation event.
        /// </summary>
        public readonly ref struct TraceOperationRelationEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "TraceOperationRelation";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 16,
                Version = 1,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.TraceOperationRelation,
                Keyword = (ulong)Keywords.AsyncCausalityRelation
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
            public TraceOperationRelationData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new TraceOperationRelationEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public TraceOperationRelationEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a TraceOperationRelation event.
            /// </summary>
            public ref struct TraceOperationRelationData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_TaskID;
                private int _offset_Relation;

                private int Offset_TaskID
                {
                    get
                    {
                        if (_offset_TaskID == -1)
                        {
                            _offset_TaskID = 0;
                        }

                        return _offset_TaskID;
                    }
                }

                private int Offset_Relation
                {
                    get
                    {
                        if (_offset_Relation == -1)
                        {
                            _offset_Relation = Offset_TaskID + 4;
                        }

                        return _offset_Relation;
                    }
                }

                /// <summary>
                /// Retrieves the TaskID field.
                /// </summary>
                public int TaskID => BitConverter.ToInt32(_etwEvent.Data[Offset_TaskID..]);

                /// <summary>
                /// Retrieves the Relation field.
                /// </summary>
                public CausalityRelation Relation => (CausalityRelation)BitConverter.ToUInt32(_etwEvent.Data[Offset_Relation..]);

                /// <summary>
                /// Creates a new TraceOperationRelationData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public TraceOperationRelationData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_TaskID = -1;
                    _offset_Relation = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a TraceOperationEnd event.
        /// </summary>
        public readonly ref struct TraceOperationEndEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "TraceOperationEnd";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 15,
                Version = 1,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.TraceOperationEnd,
                Keyword = (ulong)Keywords.AsyncCausalityOperation
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
            public TraceOperationEndData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new TraceOperationEndEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public TraceOperationEndEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a TraceOperationEnd event.
            /// </summary>
            public ref struct TraceOperationEndData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_TaskID;
                private int _offset_Status;

                private int Offset_TaskID
                {
                    get
                    {
                        if (_offset_TaskID == -1)
                        {
                            _offset_TaskID = 0;
                        }

                        return _offset_TaskID;
                    }
                }

                private int Offset_Status
                {
                    get
                    {
                        if (_offset_Status == -1)
                        {
                            _offset_Status = Offset_TaskID + 4;
                        }

                        return _offset_Status;
                    }
                }

                /// <summary>
                /// Retrieves the TaskID field.
                /// </summary>
                public int TaskID => BitConverter.ToInt32(_etwEvent.Data[Offset_TaskID..]);

                /// <summary>
                /// Retrieves the Status field.
                /// </summary>
                public AsyncCausalityStatus Status => (AsyncCausalityStatus)BitConverter.ToUInt32(_etwEvent.Data[Offset_Status..]);

                /// <summary>
                /// Creates a new TraceOperationEndData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public TraceOperationEndData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_TaskID = -1;
                    _offset_Status = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a TraceSynchronousWorkBegin event.
        /// </summary>
        public readonly ref struct TraceSynchronousWorkBeginEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "TraceSynchronousWorkBegin";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 17,
                Version = 1,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.TraceSynchronousWorkBegin,
                Keyword = (ulong)Keywords.AsyncCausalitySynchronousWork
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
            public TraceSynchronousWorkBeginData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new TraceSynchronousWorkBeginEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public TraceSynchronousWorkBeginEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a TraceSynchronousWorkBegin event.
            /// </summary>
            public ref struct TraceSynchronousWorkBeginData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_TaskID;
                private int _offset_Work;

                private int Offset_TaskID
                {
                    get
                    {
                        if (_offset_TaskID == -1)
                        {
                            _offset_TaskID = 0;
                        }

                        return _offset_TaskID;
                    }
                }

                private int Offset_Work
                {
                    get
                    {
                        if (_offset_Work == -1)
                        {
                            _offset_Work = Offset_TaskID + 4;
                        }

                        return _offset_Work;
                    }
                }

                /// <summary>
                /// Retrieves the TaskID field.
                /// </summary>
                public int TaskID => BitConverter.ToInt32(_etwEvent.Data[Offset_TaskID..]);

                /// <summary>
                /// Retrieves the Work field.
                /// </summary>
                public CausalitySynchronousWork Work => (CausalitySynchronousWork)BitConverter.ToUInt32(_etwEvent.Data[Offset_Work..]);

                /// <summary>
                /// Creates a new TraceSynchronousWorkBeginData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public TraceSynchronousWorkBeginData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_TaskID = -1;
                    _offset_Work = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a TraceSynchronousWorkEnd event.
        /// </summary>
        public readonly ref struct TraceSynchronousWorkEndEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "TraceSynchronousWorkEnd";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 18,
                Version = 1,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.TraceSynchronousWorkEnd,
                Keyword = (ulong)Keywords.AsyncCausalitySynchronousWork
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
            public TraceSynchronousWorkEndData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new TraceSynchronousWorkEndEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public TraceSynchronousWorkEndEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a TraceSynchronousWorkEnd event.
            /// </summary>
            public ref struct TraceSynchronousWorkEndData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Work;

                private int Offset_Work
                {
                    get
                    {
                        if (_offset_Work == -1)
                        {
                            _offset_Work = 0;
                        }

                        return _offset_Work;
                    }
                }

                /// <summary>
                /// Retrieves the Work field.
                /// </summary>
                public CausalitySynchronousWork Work => (CausalitySynchronousWork)BitConverter.ToUInt32(_etwEvent.Data[Offset_Work..]);

                /// <summary>
                /// Creates a new TraceSynchronousWorkEndData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public TraceSynchronousWorkEndData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Work = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a RunningContinuation event.
        /// </summary>
        public readonly ref struct RunningContinuationEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "RunningContinuation";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 20,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.RunningContinuation,
                Keyword = (ulong)Keywords.Debug
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
            public RunningContinuationData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new RunningContinuationEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public RunningContinuationEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a RunningContinuation event.
            /// </summary>
            public ref struct RunningContinuationData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_TaskID;
                private int _offset_Object;

                private int Offset_TaskID
                {
                    get
                    {
                        if (_offset_TaskID == -1)
                        {
                            _offset_TaskID = 0;
                        }

                        return _offset_TaskID;
                    }
                }

                private int Offset_Object
                {
                    get
                    {
                        if (_offset_Object == -1)
                        {
                            _offset_Object = Offset_TaskID + 4;
                        }

                        return _offset_Object;
                    }
                }

                /// <summary>
                /// Retrieves the TaskID field.
                /// </summary>
                public int TaskID => BitConverter.ToInt32(_etwEvent.Data[Offset_TaskID..]);

                /// <summary>
                /// Retrieves the Object field.
                /// </summary>
                public long Object => BitConverter.ToInt64(_etwEvent.Data[Offset_Object..]);

                /// <summary>
                /// Creates a new RunningContinuationData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public RunningContinuationData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_TaskID = -1;
                    _offset_Object = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a RunningContinuationList event.
        /// </summary>
        public readonly ref struct RunningContinuationListEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "RunningContinuationList";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 21,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.RunningContinuationList,
                Keyword = (ulong)Keywords.Debug
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
            public RunningContinuationListData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new RunningContinuationListEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public RunningContinuationListEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a RunningContinuationList event.
            /// </summary>
            public ref struct RunningContinuationListData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_TaskID;
                private int _offset_Index;
                private int _offset_Object;

                private int Offset_TaskID
                {
                    get
                    {
                        if (_offset_TaskID == -1)
                        {
                            _offset_TaskID = 0;
                        }

                        return _offset_TaskID;
                    }
                }

                private int Offset_Index
                {
                    get
                    {
                        if (_offset_Index == -1)
                        {
                            _offset_Index = Offset_TaskID + 4;
                        }

                        return _offset_Index;
                    }
                }

                private int Offset_Object
                {
                    get
                    {
                        if (_offset_Object == -1)
                        {
                            _offset_Object = Offset_Index + 4;
                        }

                        return _offset_Object;
                    }
                }

                /// <summary>
                /// Retrieves the TaskID field.
                /// </summary>
                public int TaskID => BitConverter.ToInt32(_etwEvent.Data[Offset_TaskID..]);

                /// <summary>
                /// Retrieves the Index field.
                /// </summary>
                public int Index => BitConverter.ToInt32(_etwEvent.Data[Offset_Index..]);

                /// <summary>
                /// Retrieves the Object field.
                /// </summary>
                public long Object => BitConverter.ToInt64(_etwEvent.Data[Offset_Object..]);

                /// <summary>
                /// Creates a new RunningContinuationListData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public RunningContinuationListData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_TaskID = -1;
                    _offset_Index = -1;
                    _offset_Object = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DebugMessage event.
        /// </summary>
        public readonly ref struct DebugMessageEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DebugMessage";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 22,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.DebugMessage,
                Keyword = (ulong)Keywords.Debug
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
            public DebugMessageData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DebugMessageEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DebugMessageEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a DebugMessage event.
            /// </summary>
            public ref struct DebugMessageData
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
                public string Message => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Message..]);

                /// <summary>
                /// Creates a new DebugMessageData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DebugMessageData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Message = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DebugFacilityMessage event.
        /// </summary>
        public readonly ref struct DebugFacilityMessageEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DebugFacilityMessage";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 23,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.DebugFacilityMessage,
                Keyword = (ulong)Keywords.Debug
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
            public DebugFacilityMessageData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DebugFacilityMessageEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DebugFacilityMessageEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a DebugFacilityMessage event.
            /// </summary>
            public ref struct DebugFacilityMessageData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Facility;
                private int _offset_Message;

                private int Offset_Facility
                {
                    get
                    {
                        if (_offset_Facility == -1)
                        {
                            _offset_Facility = 0;
                        }

                        return _offset_Facility;
                    }
                }

                private int Offset_Message
                {
                    get
                    {
                        if (_offset_Message == -1)
                        {
                            _offset_Message = Offset_Facility + EtwEvent.UnicodeStringEnumerable.UnicodeStringEnumerator.StringLength(_etwEvent.Data, Offset_Facility);
                        }

                        return _offset_Message;
                    }
                }

                /// <summary>
                /// Retrieves the Facility field.
                /// </summary>
                public string Facility => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Facility..]);

                /// <summary>
                /// Retrieves the Message field.
                /// </summary>
                public string Message => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Message..]);

                /// <summary>
                /// Creates a new DebugFacilityMessageData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DebugFacilityMessageData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Facility = -1;
                    _offset_Message = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DebugFacilityMessage1 event.
        /// </summary>
        public readonly ref struct DebugFacilityMessage1Event
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DebugFacilityMessage1";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 24,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.DebugFacilityMessage1,
                Keyword = (ulong)Keywords.Debug
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
            public DebugFacilityMessage1Data Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DebugFacilityMessage1Event.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DebugFacilityMessage1Event(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a DebugFacilityMessage1 event.
            /// </summary>
            public ref struct DebugFacilityMessage1Data
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Facility;
                private int _offset_Message;
                private int _offset_Value1;

                private int Offset_Facility
                {
                    get
                    {
                        if (_offset_Facility == -1)
                        {
                            _offset_Facility = 0;
                        }

                        return _offset_Facility;
                    }
                }

                private int Offset_Message
                {
                    get
                    {
                        if (_offset_Message == -1)
                        {
                            _offset_Message = Offset_Facility + EtwEvent.UnicodeStringEnumerable.UnicodeStringEnumerator.StringLength(_etwEvent.Data, Offset_Facility);
                        }

                        return _offset_Message;
                    }
                }

                private int Offset_Value1
                {
                    get
                    {
                        if (_offset_Value1 == -1)
                        {
                            _offset_Value1 = Offset_Message + EtwEvent.UnicodeStringEnumerable.UnicodeStringEnumerator.StringLength(_etwEvent.Data, Offset_Message);
                        }

                        return _offset_Value1;
                    }
                }

                /// <summary>
                /// Retrieves the Facility field.
                /// </summary>
                public string Facility => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Facility..]);

                /// <summary>
                /// Retrieves the Message field.
                /// </summary>
                public string Message => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Message..]);

                /// <summary>
                /// Retrieves the Value1 field.
                /// </summary>
                public string Value1 => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Value1..]);

                /// <summary>
                /// Creates a new DebugFacilityMessage1Data.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DebugFacilityMessage1Data(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Facility = -1;
                    _offset_Message = -1;
                    _offset_Value1 = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a SetActivityId event.
        /// </summary>
        public readonly ref struct SetActivityIdEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SetActivityId";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 25,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.SetActivityId,
                Keyword = (ulong)Keywords.DebugActivityId
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
            public SetActivityIdData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new SetActivityIdEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SetActivityIdEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a SetActivityId event.
            /// </summary>
            public ref struct SetActivityIdData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_NewId;

                private int Offset_NewId
                {
                    get
                    {
                        if (_offset_NewId == -1)
                        {
                            _offset_NewId = 0;
                        }

                        return _offset_NewId;
                    }
                }

                /// <summary>
                /// Retrieves the NewId field.
                /// </summary>
                public Guid NewId => new(_etwEvent.Data[Offset_NewId..]);

                /// <summary>
                /// Creates a new SetActivityIdData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public SetActivityIdData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_NewId = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a NewID event.
        /// </summary>
        public readonly ref struct NewIDEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "NewID";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 26,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.NewID,
                Keyword = (ulong)Keywords.Debug
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
            public NewIDData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new NewIDEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public NewIDEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a NewID event.
            /// </summary>
            public ref struct NewIDData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_TaskID;

                private int Offset_TaskID
                {
                    get
                    {
                        if (_offset_TaskID == -1)
                        {
                            _offset_TaskID = 0;
                        }

                        return _offset_TaskID;
                    }
                }

                /// <summary>
                /// Retrieves the TaskID field.
                /// </summary>
                public int TaskID => BitConverter.ToInt32(_etwEvent.Data[Offset_TaskID..]);

                /// <summary>
                /// Creates a new NewIDData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public NewIDData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_TaskID = -1;
                }
            }

        }

        /// <summary>
        /// ForkJoinOperationType.
        /// </summary>
        public enum ForkJoinOperationType : ulong
        {
            /// <summary>
            /// ParallelInvoke.
            /// </summary>
            ParallelInvoke = 1,
            /// <summary>
            /// ParallelFor.
            /// </summary>
            ParallelFor = 2,
            /// <summary>
            /// ParallelForEach.
            /// </summary>
            ParallelForEach = 3,
        }

        /// <summary>
        /// TaskWaitBehavior.
        /// </summary>
        public enum TaskWaitBehavior : ulong
        {
            /// <summary>
            /// Synchronous.
            /// </summary>
            Synchronous = 1,
            /// <summary>
            /// Asynchronous.
            /// </summary>
            Asynchronous = 2,
        }

        /// <summary>
        /// CausalityRelation.
        /// </summary>
        public enum CausalityRelation : ulong
        {
            /// <summary>
            /// AssignDelegate.
            /// </summary>
            AssignDelegate = 0,
            /// <summary>
            /// Join.
            /// </summary>
            Join = 1,
            /// <summary>
            /// Choice.
            /// </summary>
            Choice = 2,
            /// <summary>
            /// Cancel.
            /// </summary>
            Cancel = 3,
            /// <summary>
            /// Error.
            /// </summary>
            Error = 4,
        }

        /// <summary>
        /// AsyncCausalityStatus.
        /// </summary>
        public enum AsyncCausalityStatus : ulong
        {
            /// <summary>
            /// Canceled.
            /// </summary>
            Canceled = 2,
            /// <summary>
            /// Completed.
            /// </summary>
            Completed = 1,
            /// <summary>
            /// Error.
            /// </summary>
            Error = 3,
            /// <summary>
            /// Started.
            /// </summary>
            Started = 0,
        }

        /// <summary>
        /// CausalitySynchronousWork.
        /// </summary>
        public enum CausalitySynchronousWork : ulong
        {
            /// <summary>
            /// CompletionNotification.
            /// </summary>
            CompletionNotification = 0,
            /// <summary>
            /// ProgressNotification.
            /// </summary>
            ProgressNotification = 1,
            /// <summary>
            /// Execution.
            /// </summary>
            Execution = 2,
        }
    }
}
