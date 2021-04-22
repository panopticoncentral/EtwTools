using System;

#pragma warning disable CA1707 // Identifiers should not contain underscores

namespace EtwTools
{
    /// <summary>
    /// Provider for Microsoft-VisualStudio-CpsVs ({2bf0e3de-e8a7-5821-ee81-ad9385d138a4})
    /// </summary>
    public sealed class MicrosoftVisualStudioCpsVsProvider
    {
        /// <summary>
        /// Provider ID.
        /// </summary>
        public static readonly Guid Id = new("{2bf0e3de-e8a7-5821-ee81-ad9385d138a4}");

        /// <summary>
        /// Provider name.
        /// </summary>
        public const string Name = "Microsoft-VisualStudio-CpsVs";

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
                Opcode = EtwEventType.Info,
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
            public readonly ref struct EventSourceMessageData
            {
                private readonly EtwEvent _etwEvent;

                private const int Offset_Message = 0;

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
                }
            }

        }

        /// <summary>
        /// An event wrapper for a CreateProjectStart event.
        /// </summary>
        public readonly ref struct CreateProjectStartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "CreateProjectStart";

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
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventType.Start,
                Task = (ushort)Tasks.CreateProject,
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
            public CreateProjectStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new CreateProjectStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public CreateProjectStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a CreateProjectStart event.
            /// </summary>
            public readonly ref struct CreateProjectStartData
            {
                private readonly EtwEvent _etwEvent;

                private const int Offset_ProjectFileName = 0;
                private readonly int _offset_Location;
                private readonly int _offset_IsNew;

                /// <summary>
                /// Retrieves the ProjectFileName field.
                /// </summary>
                public string ProjectFileName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectFileName.._offset_Location]);

                /// <summary>
                /// Retrieves the Location field.
                /// </summary>
                public string Location => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_Location.._offset_IsNew]);

                /// <summary>
                /// Retrieves the IsNew field.
                /// </summary>
                public bool IsNew => _etwEvent.Data[_offset_IsNew] != 0;

                /// <summary>
                /// Creates a new CreateProjectStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public CreateProjectStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Location = Offset_ProjectFileName + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, Offset_ProjectFileName);
                    _offset_IsNew = _offset_Location + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, _offset_Location);
                }
            }

        }

        /// <summary>
        /// An event wrapper for a SetInitialProjectConfigurationStop event.
        /// </summary>
        public readonly ref struct SetInitialProjectConfigurationStopEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SetInitialProjectConfigurationStop";

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
                Opcode = EtwEventType.Stop,
                Task = (ushort)Tasks.SetInitialProjectConfigurationStop,
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
            public SetInitialProjectConfigurationStopData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new SetInitialProjectConfigurationStopEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SetInitialProjectConfigurationStopEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a SetInitialProjectConfigurationStop event.
            /// </summary>
            public readonly ref struct SetInitialProjectConfigurationStopData
            {
                private readonly EtwEvent _etwEvent;

                private const int Offset_ProjectPath = 0;

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectPath..]);

                /// <summary>
                /// Creates a new SetInitialProjectConfigurationStopData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public SetInitialProjectConfigurationStopData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a InitializeProjectNodeStart event.
        /// </summary>
        public readonly ref struct InitializeProjectNodeStartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "InitializeProjectNodeStart";

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
                Opcode = EtwEventType.Start,
                Task = (ushort)Tasks.InitializeProjectNode,
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
            public InitializeProjectNodeStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new InitializeProjectNodeStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public InitializeProjectNodeStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a InitializeProjectNodeStart event.
            /// </summary>
            public readonly ref struct InitializeProjectNodeStartData
            {
                private readonly EtwEvent _etwEvent;

                private const int Offset_ProjectPath = 0;

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectPath..]);

                /// <summary>
                /// Creates a new InitializeProjectNodeStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public InitializeProjectNodeStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a InitializeProjectNodeStop event.
        /// </summary>
        public readonly ref struct InitializeProjectNodeStopEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "InitializeProjectNodeStop";

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
                Opcode = EtwEventType.Stop,
                Task = (ushort)Tasks.InitializeProjectNode,
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
            public InitializeProjectNodeStopData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new InitializeProjectNodeStopEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public InitializeProjectNodeStopEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a InitializeProjectNodeStop event.
            /// </summary>
            public readonly ref struct InitializeProjectNodeStopData
            {
                private readonly EtwEvent _etwEvent;

                private const int Offset_ProjectPath = 0;

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectPath..]);

                /// <summary>
                /// Creates a new InitializeProjectNodeStopData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public InitializeProjectNodeStopData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a CreateProjectStop event.
        /// </summary>
        public readonly ref struct CreateProjectStopEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "CreateProjectStop";

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
                Opcode = EtwEventType.Stop,
                Task = (ushort)Tasks.CreateProject,
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
            public CreateProjectStopData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new CreateProjectStopEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public CreateProjectStopEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a CreateProjectStop event.
            /// </summary>
            public readonly ref struct CreateProjectStopData
            {
                private readonly EtwEvent _etwEvent;

                private const int Offset_ProjectFileName = 0;
                private readonly int _offset_Location;
                private readonly int _offset_Configuration;

                /// <summary>
                /// Retrieves the ProjectFileName field.
                /// </summary>
                public string ProjectFileName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectFileName.._offset_Location]);

                /// <summary>
                /// Retrieves the Location field.
                /// </summary>
                public string Location => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_Location.._offset_Configuration]);

                /// <summary>
                /// Retrieves the Configuration field.
                /// </summary>
                public string Configuration => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_Configuration..]);

                /// <summary>
                /// Creates a new CreateProjectStopData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public CreateProjectStopData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Location = Offset_ProjectFileName + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, Offset_ProjectFileName);
                    _offset_Configuration = _offset_Location + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, _offset_Location);
                }
            }

        }

        /// <summary>
        /// An event wrapper for a WaitingProjectTreeLoadingStop event.
        /// </summary>
        public readonly ref struct WaitingProjectTreeLoadingStopEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "WaitingProjectTreeLoadingStop";

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
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventType.Stop,
                Task = (ushort)Tasks.WaitingProjectTreeLoadingStop,
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
            public WaitingProjectTreeLoadingStopData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new WaitingProjectTreeLoadingStopEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public WaitingProjectTreeLoadingStopEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a WaitingProjectTreeLoadingStop event.
            /// </summary>
            public readonly ref struct WaitingProjectTreeLoadingStopData
            {
                private readonly EtwEvent _etwEvent;

                private const int Offset_ProjectPath = 0;

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectPath..]);

                /// <summary>
                /// Creates a new WaitingProjectTreeLoadingStopData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public WaitingProjectTreeLoadingStopData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a CpsNotifyTaskStart event.
        /// </summary>
        public readonly ref struct CpsNotifyTaskStartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "CpsNotifyTaskStart";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 41,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventType.Start,
                Task = (ushort)Tasks.CpsNotifyTask,
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
            public CpsNotifyTaskStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new CpsNotifyTaskStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public CpsNotifyTaskStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a CpsNotifyTaskStart event.
            /// </summary>
            public readonly ref struct CpsNotifyTaskStartData
            {
                private readonly EtwEvent _etwEvent;

                private const int Offset_StageId = 0;
                private readonly int _offset_ProjectPath;
                private readonly int _offset_Name;

                /// <summary>
                /// Retrieves the StageId field.
                /// </summary>
                public string StageId => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_StageId.._offset_ProjectPath]);

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_ProjectPath.._offset_Name]);

                /// <summary>
                /// Retrieves the Name field.
                /// </summary>
                public string Name => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_Name..]);

                /// <summary>
                /// Creates a new CpsNotifyTaskStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public CpsNotifyTaskStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProjectPath = Offset_StageId + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, Offset_StageId);
                    _offset_Name = _offset_ProjectPath + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, _offset_ProjectPath);
                }
            }

        }

        /// <summary>
        /// An event wrapper for a CreateUnconfiguredProjectStart event.
        /// </summary>
        public readonly ref struct CreateUnconfiguredProjectStartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "CreateUnconfiguredProjectStart";

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
                Opcode = EtwEventType.Start,
                Task = (ushort)Tasks.CreateUnconfiguredProject,
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
            public CreateUnconfiguredProjectStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new CreateUnconfiguredProjectStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public CreateUnconfiguredProjectStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a CreateUnconfiguredProjectStart event.
            /// </summary>
            public readonly ref struct CreateUnconfiguredProjectStartData
            {
                private readonly EtwEvent _etwEvent;

                private const int Offset_ProjectFileName = 0;
                private readonly int _offset_Location;

                /// <summary>
                /// Retrieves the ProjectFileName field.
                /// </summary>
                public string ProjectFileName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectFileName.._offset_Location]);

                /// <summary>
                /// Retrieves the Location field.
                /// </summary>
                public string Location => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_Location..]);

                /// <summary>
                /// Creates a new CreateUnconfiguredProjectStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public CreateUnconfiguredProjectStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Location = Offset_ProjectFileName + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, Offset_ProjectFileName);
                }
            }

        }

        /// <summary>
        /// An event wrapper for a CreateUnconfiguredProjectStop event.
        /// </summary>
        public readonly ref struct CreateUnconfiguredProjectStopEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "CreateUnconfiguredProjectStop";

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
                Opcode = EtwEventType.Stop,
                Task = (ushort)Tasks.CreateUnconfiguredProject,
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
            public CreateUnconfiguredProjectStopData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new CreateUnconfiguredProjectStopEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public CreateUnconfiguredProjectStopEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a CreateUnconfiguredProjectStop event.
            /// </summary>
            public readonly ref struct CreateUnconfiguredProjectStopData
            {
                private readonly EtwEvent _etwEvent;

                private const int Offset_ProjectFileName = 0;
                private readonly int _offset_Location;
                private readonly int _offset_Capabilities;

                /// <summary>
                /// Retrieves the ProjectFileName field.
                /// </summary>
                public string ProjectFileName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectFileName.._offset_Location]);

                /// <summary>
                /// Retrieves the Location field.
                /// </summary>
                public string Location => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_Location.._offset_Capabilities]);

                /// <summary>
                /// Retrieves the Capabilities field.
                /// </summary>
                public string Capabilities => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_Capabilities..]);

                /// <summary>
                /// Creates a new CreateUnconfiguredProjectStopData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public CreateUnconfiguredProjectStopData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Location = Offset_ProjectFileName + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, Offset_ProjectFileName);
                    _offset_Capabilities = _offset_Location + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, _offset_Location);
                }
            }

        }

        /// <summary>
        /// An event wrapper for a SetInitialProjectConfigurationStart event.
        /// </summary>
        public readonly ref struct SetInitialProjectConfigurationStartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SetInitialProjectConfigurationStart";

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
                Opcode = EtwEventType.Start,
                Task = (ushort)Tasks.SetInitialProjectConfiguration,
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
            public SetInitialProjectConfigurationStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new SetInitialProjectConfigurationStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SetInitialProjectConfigurationStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a SetInitialProjectConfigurationStart event.
            /// </summary>
            public readonly ref struct SetInitialProjectConfigurationStartData
            {
                private readonly EtwEvent _etwEvent;

                private const int Offset_ProjectPath = 0;
                private readonly int _offset_ConfigurationName;

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectPath.._offset_ConfigurationName]);

                /// <summary>
                /// Retrieves the ConfigurationName field.
                /// </summary>
                public string ConfigurationName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_ConfigurationName..]);

                /// <summary>
                /// Creates a new SetInitialProjectConfigurationStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public SetInitialProjectConfigurationStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ConfigurationName = Offset_ProjectPath + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, Offset_ProjectPath);
                }
            }

        }

        /// <summary>
        /// An event wrapper for a WaitingProjectTreePublishingStart event.
        /// </summary>
        public readonly ref struct WaitingProjectTreePublishingStartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "WaitingProjectTreePublishingStart";

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
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventType.Start,
                Task = (ushort)Tasks.WaitingProjectTreePublishing,
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
            public WaitingProjectTreePublishingStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new WaitingProjectTreePublishingStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public WaitingProjectTreePublishingStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a WaitingProjectTreePublishingStart event.
            /// </summary>
            public readonly ref struct WaitingProjectTreePublishingStartData
            {
                private readonly EtwEvent _etwEvent;

                private const int Offset_ProjectPath = 0;

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectPath..]);

                /// <summary>
                /// Creates a new WaitingProjectTreePublishingStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public WaitingProjectTreePublishingStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a WaitingProjectTreePublishingStop event.
        /// </summary>
        public readonly ref struct WaitingProjectTreePublishingStopEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "WaitingProjectTreePublishingStop";

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
                Opcode = EtwEventType.Stop,
                Task = (ushort)Tasks.WaitingProjectTreePublishing,
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
            public WaitingProjectTreePublishingStopData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new WaitingProjectTreePublishingStopEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public WaitingProjectTreePublishingStopEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a WaitingProjectTreePublishingStop event.
            /// </summary>
            public readonly ref struct WaitingProjectTreePublishingStopData
            {
                private readonly EtwEvent _etwEvent;

                private const int Offset_ProjectPath = 0;

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectPath..]);

                /// <summary>
                /// Creates a new WaitingProjectTreePublishingStopData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public WaitingProjectTreePublishingStopData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a WaitingLatestReferencesStart event.
        /// </summary>
        public readonly ref struct WaitingLatestReferencesStartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "WaitingLatestReferencesStart";

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
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventType.Start,
                Task = (ushort)Tasks.WaitingLatestReferences,
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
            public WaitingLatestReferencesStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new WaitingLatestReferencesStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public WaitingLatestReferencesStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a WaitingLatestReferencesStart event.
            /// </summary>
            public readonly ref struct WaitingLatestReferencesStartData
            {
                private readonly EtwEvent _etwEvent;

                private const int Offset_ProjectPath = 0;

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectPath..]);

                /// <summary>
                /// Creates a new WaitingLatestReferencesStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public WaitingLatestReferencesStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a WaitingLatestReferencesStop event.
        /// </summary>
        public readonly ref struct WaitingLatestReferencesStopEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "WaitingLatestReferencesStop";

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
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventType.Stop,
                Task = (ushort)Tasks.WaitingLatestReferences,
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
            public WaitingLatestReferencesStopData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new WaitingLatestReferencesStopEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public WaitingLatestReferencesStopEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a WaitingLatestReferencesStop event.
            /// </summary>
            public readonly ref struct WaitingLatestReferencesStopData
            {
                private readonly EtwEvent _etwEvent;

                private const int Offset_ProjectPath = 0;

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectPath..]);

                /// <summary>
                /// Creates a new WaitingLatestReferencesStopData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public WaitingLatestReferencesStopData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a CreateProjectAsyncStart event.
        /// </summary>
        public readonly ref struct CreateProjectAsyncStartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "CreateProjectAsyncStart";

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
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventType.Start,
                Task = (ushort)Tasks.CreateProjectAsync,
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
            public CreateProjectAsyncStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new CreateProjectAsyncStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public CreateProjectAsyncStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a CreateProjectAsyncStart event.
            /// </summary>
            public readonly ref struct CreateProjectAsyncStartData
            {
                private readonly EtwEvent _etwEvent;

                private const int Offset_ProjectFileName = 0;
                private readonly int _offset_Location;
                private readonly int _offset_IsNew;

                /// <summary>
                /// Retrieves the ProjectFileName field.
                /// </summary>
                public string ProjectFileName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectFileName.._offset_Location]);

                /// <summary>
                /// Retrieves the Location field.
                /// </summary>
                public string Location => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_Location.._offset_IsNew]);

                /// <summary>
                /// Retrieves the IsNew field.
                /// </summary>
                public bool IsNew => _etwEvent.Data[_offset_IsNew] != 0;

                /// <summary>
                /// Creates a new CreateProjectAsyncStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public CreateProjectAsyncStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Location = Offset_ProjectFileName + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, Offset_ProjectFileName);
                    _offset_IsNew = _offset_Location + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, _offset_Location);
                }
            }

        }

        /// <summary>
        /// An event wrapper for a LoadInitialProjectTreeStart event.
        /// </summary>
        public readonly ref struct LoadInitialProjectTreeStartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "LoadInitialProjectTreeStart";

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
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventType.Start,
                Task = (ushort)Tasks.LoadInitialProjectTree,
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
            public LoadInitialProjectTreeStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new LoadInitialProjectTreeStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public LoadInitialProjectTreeStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a LoadInitialProjectTreeStart event.
            /// </summary>
            public readonly ref struct LoadInitialProjectTreeStartData
            {
                private readonly EtwEvent _etwEvent;

                private const int Offset_ProjectPath = 0;

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectPath..]);

                /// <summary>
                /// Creates a new LoadInitialProjectTreeStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public LoadInitialProjectTreeStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a LoadInitialProjectTreeStop event.
        /// </summary>
        public readonly ref struct LoadInitialProjectTreeStopEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "LoadInitialProjectTreeStop";

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
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventType.Stop,
                Task = (ushort)Tasks.LoadInitialProjectTree,
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
            public LoadInitialProjectTreeStopData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new LoadInitialProjectTreeStopEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public LoadInitialProjectTreeStopEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a LoadInitialProjectTreeStop event.
            /// </summary>
            public readonly ref struct LoadInitialProjectTreeStopData
            {
                private readonly EtwEvent _etwEvent;

                private const int Offset_ProjectPath = 0;
                private readonly int _offset_Size;

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectPath.._offset_Size]);

                /// <summary>
                /// Retrieves the Size field.
                /// </summary>
                public int Size => BitConverter.ToInt32(_etwEvent.Data[_offset_Size..]);

                /// <summary>
                /// Creates a new LoadInitialProjectTreeStopData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public LoadInitialProjectTreeStopData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Size = Offset_ProjectPath + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, Offset_ProjectPath);
                }
            }

        }

        /// <summary>
        /// An event wrapper for a CreateDynamicTypeFromRuleStart event.
        /// </summary>
        public readonly ref struct CreateDynamicTypeFromRuleStartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "CreateDynamicTypeFromRuleStart";

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
                Opcode = EtwEventType.Start,
                Task = (ushort)Tasks.CreateDynamicTypeFromRule,
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
            public CreateDynamicTypeFromRuleStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new CreateDynamicTypeFromRuleStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public CreateDynamicTypeFromRuleStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a CreateDynamicTypeFromRuleStart event.
            /// </summary>
            public readonly ref struct CreateDynamicTypeFromRuleStartData
            {
                private readonly EtwEvent _etwEvent;

                private const int Offset_ProjectFileName = 0;
                private readonly int _offset_Rule;
                private readonly int _offset_CategoryName;
                private readonly int _offset_CreateBrowserObject;

                /// <summary>
                /// Retrieves the ProjectFileName field.
                /// </summary>
                public string ProjectFileName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectFileName.._offset_Rule]);

                /// <summary>
                /// Retrieves the Rule field.
                /// </summary>
                public string Rule => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_Rule.._offset_CategoryName]);

                /// <summary>
                /// Retrieves the CategoryName field.
                /// </summary>
                public string CategoryName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_CategoryName.._offset_CreateBrowserObject]);

                /// <summary>
                /// Retrieves the CreateBrowserObject field.
                /// </summary>
                public bool CreateBrowserObject => _etwEvent.Data[_offset_CreateBrowserObject] != 0;

                /// <summary>
                /// Creates a new CreateDynamicTypeFromRuleStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public CreateDynamicTypeFromRuleStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Rule = Offset_ProjectFileName + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, Offset_ProjectFileName);
                    _offset_CategoryName = _offset_Rule + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, _offset_Rule);
                    _offset_CreateBrowserObject = _offset_CategoryName + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, _offset_CategoryName);
                }
            }

        }

        /// <summary>
        /// An event wrapper for a CreateDynamicTypeFromRuleStop event.
        /// </summary>
        public readonly ref struct CreateDynamicTypeFromRuleStopEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "CreateDynamicTypeFromRuleStop";

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
                Opcode = EtwEventType.Stop,
                Task = (ushort)Tasks.CreateDynamicTypeFromRule,
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
            public CreateDynamicTypeFromRuleStopData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new CreateDynamicTypeFromRuleStopEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public CreateDynamicTypeFromRuleStopEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a CreateDynamicTypeFromRuleStop event.
            /// </summary>
            public readonly ref struct CreateDynamicTypeFromRuleStopData
            {
                private readonly EtwEvent _etwEvent;

                private const int Offset_ProjectFileName = 0;

                /// <summary>
                /// Retrieves the ProjectFileName field.
                /// </summary>
                public string ProjectFileName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectFileName..]);

                /// <summary>
                /// Creates a new CreateDynamicTypeFromRuleStopData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public CreateDynamicTypeFromRuleStopData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a PublishProjectTreeCoreStart event.
        /// </summary>
        public readonly ref struct PublishProjectTreeCoreStartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "PublishProjectTreeCoreStart";

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
                Opcode = EtwEventType.Start,
                Task = (ushort)Tasks.PublishProjectTreeCore,
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
            public PublishProjectTreeCoreStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new PublishProjectTreeCoreStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public PublishProjectTreeCoreStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a PublishProjectTreeCoreStart event.
            /// </summary>
            public readonly ref struct PublishProjectTreeCoreStartData
            {
                private readonly EtwEvent _etwEvent;

                private const int Offset_ProjectFileName = 0;
                private readonly int _offset_ConfiguredVersion;

                /// <summary>
                /// Retrieves the ProjectFileName field.
                /// </summary>
                public string ProjectFileName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectFileName.._offset_ConfiguredVersion]);

                /// <summary>
                /// Retrieves the ConfiguredVersion field.
                /// </summary>
                public string ConfiguredVersion => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_ConfiguredVersion..]);

                /// <summary>
                /// Creates a new PublishProjectTreeCoreStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public PublishProjectTreeCoreStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ConfiguredVersion = Offset_ProjectFileName + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, Offset_ProjectFileName);
                }
            }

        }

        /// <summary>
        /// An event wrapper for a PublishProjectTreeCoreStop event.
        /// </summary>
        public readonly ref struct PublishProjectTreeCoreStopEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "PublishProjectTreeCoreStop";

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
                Opcode = EtwEventType.Stop,
                Task = (ushort)Tasks.PublishProjectTreeCore,
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
            public PublishProjectTreeCoreStopData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new PublishProjectTreeCoreStopEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public PublishProjectTreeCoreStopEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a PublishProjectTreeCoreStop event.
            /// </summary>
            public readonly ref struct PublishProjectTreeCoreStopData
            {
                private readonly EtwEvent _etwEvent;

                private const int Offset_ProjectFileName = 0;
                private readonly int _offset_ConfiguredVersion;

                /// <summary>
                /// Retrieves the ProjectFileName field.
                /// </summary>
                public string ProjectFileName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectFileName.._offset_ConfiguredVersion]);

                /// <summary>
                /// Retrieves the ConfiguredVersion field.
                /// </summary>
                public string ConfiguredVersion => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_ConfiguredVersion..]);

                /// <summary>
                /// Creates a new PublishProjectTreeCoreStopData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public PublishProjectTreeCoreStopData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ConfiguredVersion = Offset_ProjectFileName + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, Offset_ProjectFileName);
                }
            }

        }

        /// <summary>
        /// An event wrapper for a PublishProjectTreeAcquiringLockStart event.
        /// </summary>
        public readonly ref struct PublishProjectTreeAcquiringLockStartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "PublishProjectTreeAcquiringLockStart";

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
                Opcode = EtwEventType.Start,
                Task = (ushort)Tasks.PublishProjectTreeAcquiringLock,
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
            /// Creates a new PublishProjectTreeAcquiringLockStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public PublishProjectTreeAcquiringLockStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a PublishProjectTreeAcquiringLockStop event.
        /// </summary>
        public readonly ref struct PublishProjectTreeAcquiringLockStopEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "PublishProjectTreeAcquiringLockStop";

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
                Opcode = EtwEventType.Stop,
                Task = (ushort)Tasks.PublishProjectTreeAcquiringLock,
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
            public PublishProjectTreeAcquiringLockStopData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new PublishProjectTreeAcquiringLockStopEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public PublishProjectTreeAcquiringLockStopEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a PublishProjectTreeAcquiringLockStop event.
            /// </summary>
            public readonly ref struct PublishProjectTreeAcquiringLockStopData
            {
                private readonly EtwEvent _etwEvent;

                private const int Offset_AbandonedLockCount = 0;
                private const int Offset_AbandonedAcquiringLockCount = 4;
                private const int Offset_ThreadSwitchingTime = 8;

                /// <summary>
                /// Retrieves the AbandonedLockCount field.
                /// </summary>
                public int AbandonedLockCount => BitConverter.ToInt32(_etwEvent.Data[Offset_AbandonedLockCount..Offset_AbandonedAcquiringLockCount]);

                /// <summary>
                /// Retrieves the AbandonedAcquiringLockCount field.
                /// </summary>
                public int AbandonedAcquiringLockCount => BitConverter.ToInt32(_etwEvent.Data[Offset_AbandonedAcquiringLockCount..Offset_ThreadSwitchingTime]);

                /// <summary>
                /// Retrieves the ThreadSwitchingTime field.
                /// </summary>
                public long ThreadSwitchingTime => BitConverter.ToInt64(_etwEvent.Data[Offset_ThreadSwitchingTime..]);

                /// <summary>
                /// Creates a new PublishProjectTreeAcquiringLockStopData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public PublishProjectTreeAcquiringLockStopData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a TransferToBestProjectOwnerStart event.
        /// </summary>
        public readonly ref struct TransferToBestProjectOwnerStartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "TransferToBestProjectOwnerStart";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 501,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventType.Start,
                Task = (ushort)Tasks.TransferToBestProjectOwner,
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
            public TransferToBestProjectOwnerStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new TransferToBestProjectOwnerStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public TransferToBestProjectOwnerStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a TransferToBestProjectOwnerStart event.
            /// </summary>
            public readonly ref struct TransferToBestProjectOwnerStartData
            {
                private readonly EtwEvent _etwEvent;

                private const int Offset_FilePath = 0;

                /// <summary>
                /// Retrieves the FilePath field.
                /// </summary>
                public string FilePath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FilePath..]);

                /// <summary>
                /// Creates a new TransferToBestProjectOwnerStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public TransferToBestProjectOwnerStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a TransferToBestProjectOwnerStop event.
        /// </summary>
        public readonly ref struct TransferToBestProjectOwnerStopEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "TransferToBestProjectOwnerStop";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 502,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventType.Stop,
                Task = (ushort)Tasks.TransferToBestProjectOwner,
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
            public TransferToBestProjectOwnerStopData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new TransferToBestProjectOwnerStopEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public TransferToBestProjectOwnerStopEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a TransferToBestProjectOwnerStop event.
            /// </summary>
            public readonly ref struct TransferToBestProjectOwnerStopData
            {
                private readonly EtwEvent _etwEvent;

                private const int Offset_FilePath = 0;

                /// <summary>
                /// Retrieves the FilePath field.
                /// </summary>
                public string FilePath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FilePath..]);

                /// <summary>
                /// Creates a new TransferToBestProjectOwnerStopData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public TransferToBestProjectOwnerStopData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a SwitchToMainThreadToPublishTreeFailed event.
        /// </summary>
        public readonly ref struct SwitchToMainThreadToPublishTreeFailedEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SwitchToMainThreadToPublishTreeFailed";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 100,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventType.Info,
                Task = (ushort)Tasks.SwitchToMainThreadToPublishTreeFailed,
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
            public SwitchToMainThreadToPublishTreeFailedData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new SwitchToMainThreadToPublishTreeFailedEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SwitchToMainThreadToPublishTreeFailedEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a SwitchToMainThreadToPublishTreeFailed event.
            /// </summary>
            public readonly ref struct SwitchToMainThreadToPublishTreeFailedData
            {
                private readonly EtwEvent _etwEvent;

                private const int Offset_Count = 0;

                /// <summary>
                /// Retrieves the Count field.
                /// </summary>
                public int Count => BitConverter.ToInt32(_etwEvent.Data[Offset_Count..]);

                /// <summary>
                /// Creates a new SwitchToMainThreadToPublishTreeFailedData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public SwitchToMainThreadToPublishTreeFailedData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a NotifyBeforeSolutionClosing event.
        /// </summary>
        public readonly ref struct NotifyBeforeSolutionClosingEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "NotifyBeforeSolutionClosing";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 101,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventType.Info,
                Task = (ushort)Tasks.NotifyBeforeSolutionClosing,
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
            /// Creates a new NotifyBeforeSolutionClosingEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public NotifyBeforeSolutionClosingEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a NotifyQueryStatusDelay event.
        /// </summary>
        public readonly ref struct NotifyQueryStatusDelayEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "NotifyQueryStatusDelay";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 102,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventType.Info,
                Task = (ushort)Tasks.NotifyQueryStatusDelay,
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
            public NotifyQueryStatusDelayData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new NotifyQueryStatusDelayEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public NotifyQueryStatusDelayEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a NotifyQueryStatusDelay event.
            /// </summary>
            public readonly ref struct NotifyQueryStatusDelayData
            {
                private readonly EtwEvent _etwEvent;

                private const int Offset_CommandGroup = 0;
                private readonly int _offset_CommandId;
                private readonly int _offset_Handler;
                private readonly int _offset_DelayTicket;

                /// <summary>
                /// Retrieves the CommandGroup field.
                /// </summary>
                public string CommandGroup => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_CommandGroup.._offset_CommandId]);

                /// <summary>
                /// Retrieves the CommandId field.
                /// </summary>
                public uint CommandId => BitConverter.ToUInt32(_etwEvent.Data[_offset_CommandId.._offset_Handler]);

                /// <summary>
                /// Retrieves the Handler field.
                /// </summary>
                public string Handler => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_Handler.._offset_DelayTicket]);

                /// <summary>
                /// Retrieves the DelayTicket field.
                /// </summary>
                public int DelayTicket => BitConverter.ToInt32(_etwEvent.Data[_offset_DelayTicket..]);

                /// <summary>
                /// Creates a new NotifyQueryStatusDelayData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public NotifyQueryStatusDelayData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_CommandId = Offset_CommandGroup + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, Offset_CommandGroup);
                    _offset_Handler = _offset_CommandId + 4;
                    _offset_DelayTicket = _offset_Handler + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, _offset_Handler);
                }
            }

        }

        /// <summary>
        /// An event wrapper for a WaitingProjectTreeLoadingStart event.
        /// </summary>
        public readonly ref struct WaitingProjectTreeLoadingStartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "WaitingProjectTreeLoadingStart";

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
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventType.Start,
                Task = (ushort)Tasks.WaitingProjectTreeLoading,
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
            public WaitingProjectTreeLoadingStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new WaitingProjectTreeLoadingStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public WaitingProjectTreeLoadingStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a WaitingProjectTreeLoadingStart event.
            /// </summary>
            public readonly ref struct WaitingProjectTreeLoadingStartData
            {
                private readonly EtwEvent _etwEvent;

                private const int Offset_ProjectPath = 0;

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectPath..]);

                /// <summary>
                /// Creates a new WaitingProjectTreeLoadingStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public WaitingProjectTreeLoadingStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a LoadAllUnconfiguredProjectsStart event.
        /// </summary>
        public readonly ref struct LoadAllUnconfiguredProjectsStartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "LoadAllUnconfiguredProjectsStart";

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
                Opcode = EtwEventType.Start,
                Task = (ushort)Tasks.LoadAllUnconfiguredProjects,
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
            /// Creates a new LoadAllUnconfiguredProjectsStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public LoadAllUnconfiguredProjectsStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a LoadAllUnconfiguredProjectsStop event.
        /// </summary>
        public readonly ref struct LoadAllUnconfiguredProjectsStopEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "LoadAllUnconfiguredProjectsStop";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 31,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventType.Stop,
                Task = (ushort)Tasks.LoadAllUnconfiguredProjects,
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
            /// Creates a new LoadAllUnconfiguredProjectsStopEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public LoadAllUnconfiguredProjectsStopEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a LoadAllConfiguredProjectsStart event.
        /// </summary>
        public readonly ref struct LoadAllConfiguredProjectsStartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "LoadAllConfiguredProjectsStart";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 32,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventType.Start,
                Task = (ushort)Tasks.LoadAllConfiguredProjects,
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
            /// Creates a new LoadAllConfiguredProjectsStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public LoadAllConfiguredProjectsStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a LoadAllConfiguredProjectsStop event.
        /// </summary>
        public readonly ref struct LoadAllConfiguredProjectsStopEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "LoadAllConfiguredProjectsStop";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 33,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventType.Stop,
                Task = (ushort)Tasks.LoadAllConfiguredProjects,
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
            /// Creates a new LoadAllConfiguredProjectsStopEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public LoadAllConfiguredProjectsStopEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a LoadAllProjectNodesStart event.
        /// </summary>
        public readonly ref struct LoadAllProjectNodesStartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "LoadAllProjectNodesStart";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 34,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventType.Start,
                Task = (ushort)Tasks.LoadAllProjectNodes,
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
            /// Creates a new LoadAllProjectNodesStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public LoadAllProjectNodesStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a LoadAllProjectNodesStop event.
        /// </summary>
        public readonly ref struct LoadAllProjectNodesStopEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "LoadAllProjectNodesStop";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 35,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventType.Stop,
                Task = (ushort)Tasks.LoadAllProjectNodes,
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
            /// Creates a new LoadAllProjectNodesStopEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public LoadAllProjectNodesStopEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a LoadProjectsAndTreesStart event.
        /// </summary>
        public readonly ref struct LoadProjectsAndTreesStartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "LoadProjectsAndTreesStart";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 36,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventType.Start,
                Task = (ushort)Tasks.LoadProjectsAndTrees,
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
            /// Creates a new LoadProjectsAndTreesStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public LoadProjectsAndTreesStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a LoadProjectsAndTreesStop event.
        /// </summary>
        public readonly ref struct LoadProjectsAndTreesStopEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "LoadProjectsAndTreesStop";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 37,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventType.Stop,
                Task = (ushort)Tasks.LoadProjectsAndTrees,
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
            /// Creates a new LoadProjectsAndTreesStopEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public LoadProjectsAndTreesStopEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a ResetDesignTimeBuilder event.
        /// </summary>
        public readonly ref struct ResetDesignTimeBuilderEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ResetDesignTimeBuilder";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 38,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventType.Info,
                Task = (ushort)Tasks.ResetDesignTimeBuilder,
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
            public ResetDesignTimeBuilderData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ResetDesignTimeBuilderEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ResetDesignTimeBuilderEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ResetDesignTimeBuilder event.
            /// </summary>
            public readonly ref struct ResetDesignTimeBuilderData
            {
                private readonly EtwEvent _etwEvent;

                private const int Offset_Project = 0;
                private readonly int _offset_Configuration;
                private readonly int _offset_ResetId;

                /// <summary>
                /// Retrieves the Project field.
                /// </summary>
                public string Project => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Project.._offset_Configuration]);

                /// <summary>
                /// Retrieves the Configuration field.
                /// </summary>
                public string Configuration => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_Configuration.._offset_ResetId]);

                /// <summary>
                /// Retrieves the ResetId field.
                /// </summary>
                public int ResetId => BitConverter.ToInt32(_etwEvent.Data[_offset_ResetId..]);

                /// <summary>
                /// Creates a new ResetDesignTimeBuilderData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ResetDesignTimeBuilderData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Configuration = Offset_Project + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, Offset_Project);
                    _offset_ResetId = _offset_Configuration + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, _offset_Configuration);
                }
            }

        }

        /// <summary>
        /// An event wrapper for a CpsHandlersBeforeCloseSolutionStart event.
        /// </summary>
        public readonly ref struct CpsHandlersBeforeCloseSolutionStartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "CpsHandlersBeforeCloseSolutionStart";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 39,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventType.Start,
                Task = (ushort)Tasks.CpsHandlersBeforeCloseSolution,
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
            /// Creates a new CpsHandlersBeforeCloseSolutionStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public CpsHandlersBeforeCloseSolutionStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a CpsHandlersBeforeCloseSolutionStop event.
        /// </summary>
        public readonly ref struct CpsHandlersBeforeCloseSolutionStopEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "CpsHandlersBeforeCloseSolutionStop";

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
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventType.Stop,
                Task = (ushort)Tasks.CpsHandlersBeforeCloseSolution,
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
            /// Creates a new CpsHandlersBeforeCloseSolutionStopEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public CpsHandlersBeforeCloseSolutionStopEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a CpsNotifyTaskStop event.
        /// </summary>
        public readonly ref struct CpsNotifyTaskStopEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "CpsNotifyTaskStop";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 42,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventType.Stop,
                Task = (ushort)Tasks.CpsNotifyTask,
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
            public CpsNotifyTaskStopData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new CpsNotifyTaskStopEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public CpsNotifyTaskStopEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a CpsNotifyTaskStop event.
            /// </summary>
            public readonly ref struct CpsNotifyTaskStopData
            {
                private readonly EtwEvent _etwEvent;

                private const int Offset_StageId = 0;
                private readonly int _offset_ProjectPath;
                private readonly int _offset_Name;

                /// <summary>
                /// Retrieves the StageId field.
                /// </summary>
                public string StageId => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_StageId.._offset_ProjectPath]);

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_ProjectPath.._offset_Name]);

                /// <summary>
                /// Retrieves the Name field.
                /// </summary>
                public string Name => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_Name..]);

                /// <summary>
                /// Creates a new CpsNotifyTaskStopData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public CpsNotifyTaskStopData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProjectPath = Offset_StageId + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, Offset_StageId);
                    _offset_Name = _offset_ProjectPath + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, _offset_ProjectPath);
                }
            }

        }

        /// <summary>
        /// An event wrapper for a CpsUpdateSubTypeStart event.
        /// </summary>
        public readonly ref struct CpsUpdateSubTypeStartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "CpsUpdateSubTypeStart";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 43,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventType.Start,
                Task = (ushort)Tasks.CpsUpdateSubType,
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
            public CpsUpdateSubTypeStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new CpsUpdateSubTypeStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public CpsUpdateSubTypeStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a CpsUpdateSubTypeStart event.
            /// </summary>
            public readonly ref struct CpsUpdateSubTypeStartData
            {
                private readonly EtwEvent _etwEvent;

                private const int Offset_ProjectPath = 0;

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectPath..]);

                /// <summary>
                /// Creates a new CpsUpdateSubTypeStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public CpsUpdateSubTypeStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a CpsUpdateSubTypeEnd event.
        /// </summary>
        public readonly ref struct CpsUpdateSubTypeEndEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "CpsUpdateSubTypeEnd";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 44,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventType.Info,
                Task = (ushort)Tasks.CpsUpdateSubTypeEnd,
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
            public CpsUpdateSubTypeEndData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new CpsUpdateSubTypeEndEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public CpsUpdateSubTypeEndEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a CpsUpdateSubTypeEnd event.
            /// </summary>
            public readonly ref struct CpsUpdateSubTypeEndData
            {
                private readonly EtwEvent _etwEvent;

                private const int Offset_ProjectPath = 0;
                private readonly int _offset_Count;
                private readonly int _offset_Changed;
                private readonly int _offset_Reevaluated;

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectPath.._offset_Count]);

                /// <summary>
                /// Retrieves the Count field.
                /// </summary>
                public int Count => BitConverter.ToInt32(_etwEvent.Data[_offset_Count.._offset_Changed]);

                /// <summary>
                /// Retrieves the Changed field.
                /// </summary>
                public bool Changed => _etwEvent.Data[_offset_Changed] != 0;

                /// <summary>
                /// Retrieves the Reevaluated field.
                /// </summary>
                public bool Reevaluated => _etwEvent.Data[_offset_Reevaluated] != 0;

                /// <summary>
                /// Creates a new CpsUpdateSubTypeEndData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public CpsUpdateSubTypeEndData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Count = Offset_ProjectPath + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, Offset_ProjectPath);
                    _offset_Changed = _offset_Count + 4;
                    _offset_Reevaluated = _offset_Changed + 1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ProjectReloadedInBackground event.
        /// </summary>
        public readonly ref struct ProjectReloadedInBackgroundEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ProjectReloadedInBackground";

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
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventType.Info,
                Task = (ushort)Tasks.ProjectReloadedInBackground,
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
            public ProjectReloadedInBackgroundData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ProjectReloadedInBackgroundEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ProjectReloadedInBackgroundEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ProjectReloadedInBackground event.
            /// </summary>
            public readonly ref struct ProjectReloadedInBackgroundData
            {
                private readonly EtwEvent _etwEvent;

                private const int Offset_Project = 0;
                private readonly int _offset_ConfiguredVersion;

                /// <summary>
                /// Retrieves the Project field.
                /// </summary>
                public string Project => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Project.._offset_ConfiguredVersion]);

                /// <summary>
                /// Retrieves the ConfiguredVersion field.
                /// </summary>
                public string ConfiguredVersion => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_ConfiguredVersion..]);

                /// <summary>
                /// Creates a new ProjectReloadedInBackgroundData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ProjectReloadedInBackgroundData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ConfiguredVersion = Offset_Project + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, Offset_Project);
                }
            }

        }

        /// <summary>
        /// Tasks supported by Microsoft-VisualStudio-CpsVs.
        /// </summary>
        public enum Tasks : ushort
        {
            /// <summary>
            /// 'TransferToBestProjectOwner' task.
            /// </summary>
            TransferToBestProjectOwner = 65033,
            /// <summary>
            /// 'NotifyQueryStatusDelay' task.
            /// </summary>
            NotifyQueryStatusDelay = 65432,
            /// <summary>
            /// 'NotifyBeforeSolutionClosing' task.
            /// </summary>
            NotifyBeforeSolutionClosing = 65433,
            /// <summary>
            /// 'SwitchToMainThreadToPublishTreeFailed' task.
            /// </summary>
            SwitchToMainThreadToPublishTreeFailed = 65434,
            /// <summary>
            /// 'ProjectReloadedInBackground' task.
            /// </summary>
            ProjectReloadedInBackground = 65484,
            /// <summary>
            /// 'CpsUpdateSubTypeEnd' task.
            /// </summary>
            CpsUpdateSubTypeEnd = 65490,
            /// <summary>
            /// 'CpsUpdateSubType' task.
            /// </summary>
            CpsUpdateSubType = 65491,
            /// <summary>
            /// 'CpsNotifyTask' task.
            /// </summary>
            CpsNotifyTask = 65493,
            /// <summary>
            /// 'CpsHandlersBeforeCloseSolution' task.
            /// </summary>
            CpsHandlersBeforeCloseSolution = 65495,
            /// <summary>
            /// 'ResetDesignTimeBuilder' task.
            /// </summary>
            ResetDesignTimeBuilder = 65496,
            /// <summary>
            /// 'LoadProjectsAndTrees' task.
            /// </summary>
            LoadProjectsAndTrees = 65498,
            /// <summary>
            /// 'LoadAllProjectNodes' task.
            /// </summary>
            LoadAllProjectNodes = 65500,
            /// <summary>
            /// 'LoadAllConfiguredProjects' task.
            /// </summary>
            LoadAllConfiguredProjects = 65502,
            /// <summary>
            /// 'LoadAllUnconfiguredProjects' task.
            /// </summary>
            LoadAllUnconfiguredProjects = 65504,
            /// <summary>
            /// 'PublishProjectTreeAcquiringLock' task.
            /// </summary>
            PublishProjectTreeAcquiringLock = 65509,
            /// <summary>
            /// 'PublishProjectTreeCore' task.
            /// </summary>
            PublishProjectTreeCore = 65511,
            /// <summary>
            /// 'CreateDynamicTypeFromRule' task.
            /// </summary>
            CreateDynamicTypeFromRule = 65513,
            /// <summary>
            /// 'WaitingProjectTreeLoadingStop' task.
            /// </summary>
            WaitingProjectTreeLoadingStop = 65516,
            /// <summary>
            /// 'WaitingProjectTreeLoading' task.
            /// </summary>
            WaitingProjectTreeLoading = 65517,
            /// <summary>
            /// 'LoadInitialProjectTree' task.
            /// </summary>
            LoadInitialProjectTree = 65519,
            /// <summary>
            /// 'CreateProjectAsync' task.
            /// </summary>
            CreateProjectAsync = 65521,
            /// <summary>
            /// 'CreateProject' task.
            /// </summary>
            CreateProject = 65523,
            /// <summary>
            /// 'WaitingLatestReferences' task.
            /// </summary>
            WaitingLatestReferences = 65525,
            /// <summary>
            /// 'WaitingProjectTreePublishing' task.
            /// </summary>
            WaitingProjectTreePublishing = 65527,
            /// <summary>
            /// 'InitializeProjectNode' task.
            /// </summary>
            InitializeProjectNode = 65529,
            /// <summary>
            /// 'SetInitialProjectConfigurationStop' task.
            /// </summary>
            SetInitialProjectConfigurationStop = 65530,
            /// <summary>
            /// 'SetInitialProjectConfiguration' task.
            /// </summary>
            SetInitialProjectConfiguration = 65531,
            /// <summary>
            /// 'CreateUnconfiguredProject' task.
            /// </summary>
            CreateUnconfiguredProject = 65533,
            /// <summary>
            /// 'EventSourceMessage' task.
            /// </summary>
            EventSourceMessage = 65534,
        }

        /// <summary>
        /// Keywords supported by Microsoft-VisualStudio-CpsVs.
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
    }
}
