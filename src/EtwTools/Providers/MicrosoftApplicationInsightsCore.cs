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
    /// Provider for Microsoft-ApplicationInsights-Core (74af9f20-af6a-5582-9382-f21f674fb271)
    /// </summary>
    public sealed class MicrosoftApplicationInsightsCoreProvider
    {
        /// <summary>s
        /// Provider ID.
        /// </summary>
        public static readonly Guid Id = new("74af9f20-af6a-5582-9382-f21f674fb271");

        /// <summary>
        /// Provider name.
        /// </summary>
        public const string Name = "Microsoft-ApplicationInsights-Core";

        /// <summary>
        /// Tasks supported by Microsoft-ApplicationInsights-Core.
        /// </summary>
        public enum Tasks : ushort
        {
            /// <summary>
            /// 'BuildInfoConfigBrokenXmlError' task.
            /// </summary>
            BuildInfoConfigBrokenXmlError = 65443,
            /// <summary>
            /// 'LogError' task.
            /// </summary>
            LogError = 65444,
            /// <summary>
            /// 'TrackingWasEnabled' task.
            /// </summary>
            TrackingWasEnabled = 65453,
            /// <summary>
            /// 'TrackingWasDisabled' task.
            /// </summary>
            TrackingWasDisabled = 65454,
            /// <summary>
            /// 'RequestTelemetryIncorrectDuration' task.
            /// </summary>
            RequestTelemetryIncorrectDuration = 65462,
            /// <summary>
            /// 'PopulateRequiredStringWithValue' task.
            /// </summary>
            PopulateRequiredStringWithValue = 65463,
            /// <summary>
            /// 'TelemetryClientConstructorWithNoTelemetryConfiguration' task.
            /// </summary>
            TelemetryClientConstructorWithNoTelemetryConfiguration = 65464,
            /// <summary>
            /// 'DiagnoisticsEventThrottlingSchedulerTimerWasRemoved' task.
            /// </summary>
            DiagnoisticsEventThrottlingSchedulerTimerWasRemoved = 65474,
            /// <summary>
            /// 'DiagnoisticsEventThrottlingSchedulerTimerWasCreated' task.
            /// </summary>
            DiagnoisticsEventThrottlingSchedulerTimerWasCreated = 65484,
            /// <summary>
            /// 'DiagnoisticsEventThrottlingSchedulerDisposeTimerFailure' task.
            /// </summary>
            DiagnoisticsEventThrottlingSchedulerDisposeTimerFailure = 65494,
            /// <summary>
            /// 'DiagnosticsEventThrottlingHasBeenResetForTheEvent' task.
            /// </summary>
            DiagnosticsEventThrottlingHasBeenResetForTheEvent = 65504,
            /// <summary>
            /// 'DiagnosticsEventThrottlingHasBeenStartedForTheEvent' task.
            /// </summary>
            DiagnosticsEventThrottlingHasBeenStartedForTheEvent = 65514,
            /// <summary>
            /// 'LogVerbose' task.
            /// </summary>
            LogVerbose = 65524,
            /// <summary>
            /// 'EventSourceMessage' task.
            /// </summary>
            EventSourceMessage = 65534,
        }

        /// <summary>
        /// Keywords supported by MicrosoftApplicationInsightsCore.
        /// </summary>
        [Flags]
        public enum Keywords : ulong
        {
            /// <summary>
            /// 'UserActionable' keyword.
            /// </summary>
            UserActionable = 0x0000000000000001,
            /// <summary>
            /// 'Diagnostics' keyword.
            /// </summary>
            Diagnostics = 0x0000000000000002,
            /// <summary>
            /// 'VerboseFailure' keyword.
            /// </summary>
            VerboseFailure = 0x0000000000000004,
            /// <summary>
            /// 'ErrorFailure' keyword.
            /// </summary>
            ErrorFailure = 0x0000000000000008,
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
        /// An event wrapper for a LogVerbose event.
        /// </summary>
        public readonly ref struct LogVerboseEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "LogVerbose";

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
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Verbose,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.LogVerbose,
                Keyword = (ulong)Keywords.VerboseFailure
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
            public LogVerboseData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new LogVerboseEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public LogVerboseEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a LogVerboseEvent.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator LogVerboseEvent(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a LogVerbose event.
            /// </summary>
            public ref struct LogVerboseData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Msg;
                private int _offset_AppDomainName;

                private int Offset_Msg
                {
                    get
                    {
                        if (_offset_Msg == -1)
                        {
                            _offset_Msg = 0;
                        }

                        return _offset_Msg;
                    }
                }

                private int Offset_AppDomainName
                {
                    get
                    {
                        if (_offset_AppDomainName == -1)
                        {
                            _offset_AppDomainName = Offset_Msg + _etwEvent.UnicodeStringLength(Offset_Msg);
                        }

                        return _offset_AppDomainName;
                    }
                }

                /// <summary>
                /// Retrieves the Msg field.
                /// </summary>
                public string Msg => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Msg..Offset_AppDomainName]);

                /// <summary>
                /// Retrieves the AppDomainName field.
                /// </summary>
                public string AppDomainName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_AppDomainName..]);

                /// <summary>
                /// Creates a new LogVerboseData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public LogVerboseData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Msg = -1;
                    _offset_AppDomainName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DiagnosticsEventThrottlingHasBeenStartedForTheEvent event.
        /// </summary>
        public readonly ref struct DiagnosticsEventThrottlingHasBeenStartedForTheEventEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DiagnosticsEventThrottlingHasBeenStartedForTheEvent";

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
                Task = (ushort)Tasks.DiagnosticsEventThrottlingHasBeenStartedForTheEvent,
                Keyword = (ulong)Keywords.UserActionable | (ulong)Keywords.Diagnostics
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
            public DiagnosticsEventThrottlingHasBeenStartedForTheEventData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DiagnosticsEventThrottlingHasBeenStartedForTheEventEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DiagnosticsEventThrottlingHasBeenStartedForTheEventEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a DiagnosticsEventThrottlingHasBeenStartedForTheEventEvent.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator DiagnosticsEventThrottlingHasBeenStartedForTheEventEvent(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a DiagnosticsEventThrottlingHasBeenStartedForTheEvent event.
            /// </summary>
            public ref struct DiagnosticsEventThrottlingHasBeenStartedForTheEventData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_EventId;
                private int _offset_AppDomainName;

                private int Offset_EventId
                {
                    get
                    {
                        if (_offset_EventId == -1)
                        {
                            _offset_EventId = 0;
                        }

                        return _offset_EventId;
                    }
                }

                private int Offset_AppDomainName
                {
                    get
                    {
                        if (_offset_AppDomainName == -1)
                        {
                            _offset_AppDomainName = Offset_EventId + 4;
                        }

                        return _offset_AppDomainName;
                    }
                }

                /// <summary>
                /// Retrieves the EventId field.
                /// </summary>
                public int EventId => BitConverter.ToInt32(_etwEvent.Data[Offset_EventId..Offset_AppDomainName]);

                /// <summary>
                /// Retrieves the AppDomainName field.
                /// </summary>
                public string AppDomainName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_AppDomainName..]);

                /// <summary>
                /// Creates a new DiagnosticsEventThrottlingHasBeenStartedForTheEventData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DiagnosticsEventThrottlingHasBeenStartedForTheEventData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_EventId = -1;
                    _offset_AppDomainName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DiagnosticsEventThrottlingHasBeenResetForTheEvent event.
        /// </summary>
        public readonly ref struct DiagnosticsEventThrottlingHasBeenResetForTheEventEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DiagnosticsEventThrottlingHasBeenResetForTheEvent";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 30,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.DiagnosticsEventThrottlingHasBeenResetForTheEvent,
                Keyword = (ulong)Keywords.UserActionable | (ulong)Keywords.Diagnostics
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
            public DiagnosticsEventThrottlingHasBeenResetForTheEventData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DiagnosticsEventThrottlingHasBeenResetForTheEventEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DiagnosticsEventThrottlingHasBeenResetForTheEventEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a DiagnosticsEventThrottlingHasBeenResetForTheEventEvent.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator DiagnosticsEventThrottlingHasBeenResetForTheEventEvent(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a DiagnosticsEventThrottlingHasBeenResetForTheEvent event.
            /// </summary>
            public ref struct DiagnosticsEventThrottlingHasBeenResetForTheEventData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_EventId;
                private int _offset_ExecutionCount;
                private int _offset_AppDomainName;

                private int Offset_EventId
                {
                    get
                    {
                        if (_offset_EventId == -1)
                        {
                            _offset_EventId = 0;
                        }

                        return _offset_EventId;
                    }
                }

                private int Offset_ExecutionCount
                {
                    get
                    {
                        if (_offset_ExecutionCount == -1)
                        {
                            _offset_ExecutionCount = Offset_EventId + 4;
                        }

                        return _offset_ExecutionCount;
                    }
                }

                private int Offset_AppDomainName
                {
                    get
                    {
                        if (_offset_AppDomainName == -1)
                        {
                            _offset_AppDomainName = Offset_ExecutionCount + 4;
                        }

                        return _offset_AppDomainName;
                    }
                }

                /// <summary>
                /// Retrieves the EventId field.
                /// </summary>
                public int EventId => BitConverter.ToInt32(_etwEvent.Data[Offset_EventId..Offset_ExecutionCount]);

                /// <summary>
                /// Retrieves the ExecutionCount field.
                /// </summary>
                public int ExecutionCount => BitConverter.ToInt32(_etwEvent.Data[Offset_ExecutionCount..Offset_AppDomainName]);

                /// <summary>
                /// Retrieves the AppDomainName field.
                /// </summary>
                public string AppDomainName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_AppDomainName..]);

                /// <summary>
                /// Creates a new DiagnosticsEventThrottlingHasBeenResetForTheEventData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DiagnosticsEventThrottlingHasBeenResetForTheEventData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_EventId = -1;
                    _offset_ExecutionCount = -1;
                    _offset_AppDomainName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DiagnoisticsEventThrottlingSchedulerDisposeTimerFailure event.
        /// </summary>
        public readonly ref struct DiagnoisticsEventThrottlingSchedulerDisposeTimerFailureEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DiagnoisticsEventThrottlingSchedulerDisposeTimerFailure";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 40,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Warning,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.DiagnoisticsEventThrottlingSchedulerDisposeTimerFailure,
                Keyword = (ulong)Keywords.Diagnostics
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
            public DiagnoisticsEventThrottlingSchedulerDisposeTimerFailureData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DiagnoisticsEventThrottlingSchedulerDisposeTimerFailureEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DiagnoisticsEventThrottlingSchedulerDisposeTimerFailureEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a DiagnoisticsEventThrottlingSchedulerDisposeTimerFailureEvent.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator DiagnoisticsEventThrottlingSchedulerDisposeTimerFailureEvent(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a DiagnoisticsEventThrottlingSchedulerDisposeTimerFailure event.
            /// </summary>
            public ref struct DiagnoisticsEventThrottlingSchedulerDisposeTimerFailureData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Exception;
                private int _offset_AppDomainName;

                private int Offset_Exception
                {
                    get
                    {
                        if (_offset_Exception == -1)
                        {
                            _offset_Exception = 0;
                        }

                        return _offset_Exception;
                    }
                }

                private int Offset_AppDomainName
                {
                    get
                    {
                        if (_offset_AppDomainName == -1)
                        {
                            _offset_AppDomainName = Offset_Exception + _etwEvent.UnicodeStringLength(Offset_Exception);
                        }

                        return _offset_AppDomainName;
                    }
                }

                /// <summary>
                /// Retrieves the Exception field.
                /// </summary>
                public string Exception => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Exception..Offset_AppDomainName]);

                /// <summary>
                /// Retrieves the AppDomainName field.
                /// </summary>
                public string AppDomainName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_AppDomainName..]);

                /// <summary>
                /// Creates a new DiagnoisticsEventThrottlingSchedulerDisposeTimerFailureData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DiagnoisticsEventThrottlingSchedulerDisposeTimerFailureData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Exception = -1;
                    _offset_AppDomainName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DiagnoisticsEventThrottlingSchedulerTimerWasCreated event.
        /// </summary>
        public readonly ref struct DiagnoisticsEventThrottlingSchedulerTimerWasCreatedEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DiagnoisticsEventThrottlingSchedulerTimerWasCreated";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 50,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Verbose,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.DiagnoisticsEventThrottlingSchedulerTimerWasCreated,
                Keyword = (ulong)Keywords.Diagnostics
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
            public DiagnoisticsEventThrottlingSchedulerTimerWasCreatedData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DiagnoisticsEventThrottlingSchedulerTimerWasCreatedEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DiagnoisticsEventThrottlingSchedulerTimerWasCreatedEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a DiagnoisticsEventThrottlingSchedulerTimerWasCreatedEvent.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator DiagnoisticsEventThrottlingSchedulerTimerWasCreatedEvent(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a DiagnoisticsEventThrottlingSchedulerTimerWasCreated event.
            /// </summary>
            public ref struct DiagnoisticsEventThrottlingSchedulerTimerWasCreatedData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_IntervalInMilliseconds;
                private int _offset_AppDomainName;

                private int Offset_IntervalInMilliseconds
                {
                    get
                    {
                        if (_offset_IntervalInMilliseconds == -1)
                        {
                            _offset_IntervalInMilliseconds = 0;
                        }

                        return _offset_IntervalInMilliseconds;
                    }
                }

                private int Offset_AppDomainName
                {
                    get
                    {
                        if (_offset_AppDomainName == -1)
                        {
                            _offset_AppDomainName = Offset_IntervalInMilliseconds + 4;
                        }

                        return _offset_AppDomainName;
                    }
                }

                /// <summary>
                /// Retrieves the IntervalInMilliseconds field.
                /// </summary>
                public int IntervalInMilliseconds => BitConverter.ToInt32(_etwEvent.Data[Offset_IntervalInMilliseconds..Offset_AppDomainName]);

                /// <summary>
                /// Retrieves the AppDomainName field.
                /// </summary>
                public string AppDomainName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_AppDomainName..]);

                /// <summary>
                /// Creates a new DiagnoisticsEventThrottlingSchedulerTimerWasCreatedData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DiagnoisticsEventThrottlingSchedulerTimerWasCreatedData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_IntervalInMilliseconds = -1;
                    _offset_AppDomainName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DiagnoisticsEventThrottlingSchedulerTimerWasRemoved event.
        /// </summary>
        public readonly ref struct DiagnoisticsEventThrottlingSchedulerTimerWasRemovedEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DiagnoisticsEventThrottlingSchedulerTimerWasRemoved";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 60,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Verbose,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.DiagnoisticsEventThrottlingSchedulerTimerWasRemoved,
                Keyword = (ulong)Keywords.Diagnostics
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
            public DiagnoisticsEventThrottlingSchedulerTimerWasRemovedData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DiagnoisticsEventThrottlingSchedulerTimerWasRemovedEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DiagnoisticsEventThrottlingSchedulerTimerWasRemovedEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a DiagnoisticsEventThrottlingSchedulerTimerWasRemovedEvent.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator DiagnoisticsEventThrottlingSchedulerTimerWasRemovedEvent(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a DiagnoisticsEventThrottlingSchedulerTimerWasRemoved event.
            /// </summary>
            public ref struct DiagnoisticsEventThrottlingSchedulerTimerWasRemovedData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_AppDomainName;

                private int Offset_AppDomainName
                {
                    get
                    {
                        if (_offset_AppDomainName == -1)
                        {
                            _offset_AppDomainName = 0;
                        }

                        return _offset_AppDomainName;
                    }
                }

                /// <summary>
                /// Retrieves the AppDomainName field.
                /// </summary>
                public string AppDomainName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_AppDomainName..]);

                /// <summary>
                /// Creates a new DiagnoisticsEventThrottlingSchedulerTimerWasRemovedData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DiagnoisticsEventThrottlingSchedulerTimerWasRemovedData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_AppDomainName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a TelemetryClientConstructorWithNoTelemetryConfiguration event.
        /// </summary>
        public readonly ref struct TelemetryClientConstructorWithNoTelemetryConfigurationEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "TelemetryClientConstructorWithNoTelemetryConfiguration";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 70,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Warning,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.TelemetryClientConstructorWithNoTelemetryConfiguration,
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
            public TelemetryClientConstructorWithNoTelemetryConfigurationData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new TelemetryClientConstructorWithNoTelemetryConfigurationEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public TelemetryClientConstructorWithNoTelemetryConfigurationEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a TelemetryClientConstructorWithNoTelemetryConfigurationEvent.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator TelemetryClientConstructorWithNoTelemetryConfigurationEvent(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a TelemetryClientConstructorWithNoTelemetryConfiguration event.
            /// </summary>
            public ref struct TelemetryClientConstructorWithNoTelemetryConfigurationData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_AppDomainName;

                private int Offset_AppDomainName
                {
                    get
                    {
                        if (_offset_AppDomainName == -1)
                        {
                            _offset_AppDomainName = 0;
                        }

                        return _offset_AppDomainName;
                    }
                }

                /// <summary>
                /// Retrieves the AppDomainName field.
                /// </summary>
                public string AppDomainName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_AppDomainName..]);

                /// <summary>
                /// Creates a new TelemetryClientConstructorWithNoTelemetryConfigurationData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public TelemetryClientConstructorWithNoTelemetryConfigurationData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_AppDomainName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a PopulateRequiredStringWithValue event.
        /// </summary>
        public readonly ref struct PopulateRequiredStringWithValueEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "PopulateRequiredStringWithValue";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 71,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Verbose,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.PopulateRequiredStringWithValue,
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
            public PopulateRequiredStringWithValueData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new PopulateRequiredStringWithValueEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public PopulateRequiredStringWithValueEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a PopulateRequiredStringWithValueEvent.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator PopulateRequiredStringWithValueEvent(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a PopulateRequiredStringWithValue event.
            /// </summary>
            public ref struct PopulateRequiredStringWithValueData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ParameterName;
                private int _offset_TelemetryType;
                private int _offset_AppDomainName;

                private int Offset_ParameterName
                {
                    get
                    {
                        if (_offset_ParameterName == -1)
                        {
                            _offset_ParameterName = 0;
                        }

                        return _offset_ParameterName;
                    }
                }

                private int Offset_TelemetryType
                {
                    get
                    {
                        if (_offset_TelemetryType == -1)
                        {
                            _offset_TelemetryType = Offset_ParameterName + _etwEvent.UnicodeStringLength(Offset_ParameterName);
                        }

                        return _offset_TelemetryType;
                    }
                }

                private int Offset_AppDomainName
                {
                    get
                    {
                        if (_offset_AppDomainName == -1)
                        {
                            _offset_AppDomainName = Offset_TelemetryType + _etwEvent.UnicodeStringLength(Offset_TelemetryType);
                        }

                        return _offset_AppDomainName;
                    }
                }

                /// <summary>
                /// Retrieves the ParameterName field.
                /// </summary>
                public string ParameterName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ParameterName..Offset_TelemetryType]);

                /// <summary>
                /// Retrieves the TelemetryType field.
                /// </summary>
                public string TelemetryType => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_TelemetryType..Offset_AppDomainName]);

                /// <summary>
                /// Retrieves the AppDomainName field.
                /// </summary>
                public string AppDomainName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_AppDomainName..]);

                /// <summary>
                /// Creates a new PopulateRequiredStringWithValueData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public PopulateRequiredStringWithValueData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ParameterName = -1;
                    _offset_TelemetryType = -1;
                    _offset_AppDomainName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a RequestTelemetryIncorrectDuration event.
        /// </summary>
        public readonly ref struct RequestTelemetryIncorrectDurationEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "RequestTelemetryIncorrectDuration";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 72,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Warning,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.RequestTelemetryIncorrectDuration,
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
            public RequestTelemetryIncorrectDurationData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new RequestTelemetryIncorrectDurationEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public RequestTelemetryIncorrectDurationEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a RequestTelemetryIncorrectDurationEvent.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator RequestTelemetryIncorrectDurationEvent(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a RequestTelemetryIncorrectDuration event.
            /// </summary>
            public ref struct RequestTelemetryIncorrectDurationData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_AppDomainName;

                private int Offset_AppDomainName
                {
                    get
                    {
                        if (_offset_AppDomainName == -1)
                        {
                            _offset_AppDomainName = 0;
                        }

                        return _offset_AppDomainName;
                    }
                }

                /// <summary>
                /// Retrieves the AppDomainName field.
                /// </summary>
                public string AppDomainName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_AppDomainName..]);

                /// <summary>
                /// Creates a new RequestTelemetryIncorrectDurationData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public RequestTelemetryIncorrectDurationData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_AppDomainName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a TrackingWasDisabled event.
        /// </summary>
        public readonly ref struct TrackingWasDisabledEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "TrackingWasDisabled";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 80,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Verbose,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.TrackingWasDisabled,
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
            public TrackingWasDisabledData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new TrackingWasDisabledEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public TrackingWasDisabledEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a TrackingWasDisabledEvent.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator TrackingWasDisabledEvent(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a TrackingWasDisabled event.
            /// </summary>
            public ref struct TrackingWasDisabledData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_AppDomainName;

                private int Offset_AppDomainName
                {
                    get
                    {
                        if (_offset_AppDomainName == -1)
                        {
                            _offset_AppDomainName = 0;
                        }

                        return _offset_AppDomainName;
                    }
                }

                /// <summary>
                /// Retrieves the AppDomainName field.
                /// </summary>
                public string AppDomainName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_AppDomainName..]);

                /// <summary>
                /// Creates a new TrackingWasDisabledData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public TrackingWasDisabledData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_AppDomainName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a TrackingWasEnabled event.
        /// </summary>
        public readonly ref struct TrackingWasEnabledEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "TrackingWasEnabled";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 81,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Verbose,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.TrackingWasEnabled,
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
            public TrackingWasEnabledData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new TrackingWasEnabledEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public TrackingWasEnabledEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a TrackingWasEnabledEvent.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator TrackingWasEnabledEvent(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a TrackingWasEnabled event.
            /// </summary>
            public ref struct TrackingWasEnabledData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_AppDomainName;

                private int Offset_AppDomainName
                {
                    get
                    {
                        if (_offset_AppDomainName == -1)
                        {
                            _offset_AppDomainName = 0;
                        }

                        return _offset_AppDomainName;
                    }
                }

                /// <summary>
                /// Retrieves the AppDomainName field.
                /// </summary>
                public string AppDomainName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_AppDomainName..]);

                /// <summary>
                /// Creates a new TrackingWasEnabledData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public TrackingWasEnabledData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_AppDomainName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a LogError event.
        /// </summary>
        public readonly ref struct LogErrorEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "LogError";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 90,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Error,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.LogError,
                Keyword = (ulong)Keywords.ErrorFailure
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
            public LogErrorData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new LogErrorEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public LogErrorEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a LogErrorEvent.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator LogErrorEvent(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a LogError event.
            /// </summary>
            public ref struct LogErrorData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Msg;
                private int _offset_AppDomainName;

                private int Offset_Msg
                {
                    get
                    {
                        if (_offset_Msg == -1)
                        {
                            _offset_Msg = 0;
                        }

                        return _offset_Msg;
                    }
                }

                private int Offset_AppDomainName
                {
                    get
                    {
                        if (_offset_AppDomainName == -1)
                        {
                            _offset_AppDomainName = Offset_Msg + _etwEvent.UnicodeStringLength(Offset_Msg);
                        }

                        return _offset_AppDomainName;
                    }
                }

                /// <summary>
                /// Retrieves the Msg field.
                /// </summary>
                public string Msg => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Msg..Offset_AppDomainName]);

                /// <summary>
                /// Retrieves the AppDomainName field.
                /// </summary>
                public string AppDomainName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_AppDomainName..]);

                /// <summary>
                /// Creates a new LogErrorData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public LogErrorData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Msg = -1;
                    _offset_AppDomainName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a BuildInfoConfigBrokenXmlError event.
        /// </summary>
        public readonly ref struct BuildInfoConfigBrokenXmlErrorEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "BuildInfoConfigBrokenXmlError";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 91,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Error,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.BuildInfoConfigBrokenXmlError,
                Keyword = (ulong)Keywords.UserActionable | (ulong)Keywords.ErrorFailure
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
            public BuildInfoConfigBrokenXmlErrorData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new BuildInfoConfigBrokenXmlErrorEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public BuildInfoConfigBrokenXmlErrorEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a BuildInfoConfigBrokenXmlErrorEvent.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator BuildInfoConfigBrokenXmlErrorEvent(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a BuildInfoConfigBrokenXmlError event.
            /// </summary>
            public ref struct BuildInfoConfigBrokenXmlErrorData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Msg;
                private int _offset_AppDomainName;

                private int Offset_Msg
                {
                    get
                    {
                        if (_offset_Msg == -1)
                        {
                            _offset_Msg = 0;
                        }

                        return _offset_Msg;
                    }
                }

                private int Offset_AppDomainName
                {
                    get
                    {
                        if (_offset_AppDomainName == -1)
                        {
                            _offset_AppDomainName = Offset_Msg + _etwEvent.UnicodeStringLength(Offset_Msg);
                        }

                        return _offset_AppDomainName;
                    }
                }

                /// <summary>
                /// Retrieves the Msg field.
                /// </summary>
                public string Msg => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Msg..Offset_AppDomainName]);

                /// <summary>
                /// Retrieves the AppDomainName field.
                /// </summary>
                public string AppDomainName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_AppDomainName..]);

                /// <summary>
                /// Creates a new BuildInfoConfigBrokenXmlErrorData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public BuildInfoConfigBrokenXmlErrorData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Msg = -1;
                    _offset_AppDomainName = -1;
                }
            }

        }
    }
}
