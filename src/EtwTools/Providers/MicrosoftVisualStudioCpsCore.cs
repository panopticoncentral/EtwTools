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
    /// Provider for Microsoft-VisualStudio-CpsCore (fdc862e2-43a9-5181-288a-7fade55cc9cc)
    /// </summary>
    public sealed class MicrosoftVisualStudioCpsCoreProvider
    {
        /// <summary>s
        /// Provider ID.
        /// </summary>
        public static readonly Guid Id = new("fdc862e2-43a9-5181-288a-7fade55cc9cc");

        /// <summary>
        /// Provider name.
        /// </summary>
        public const string Name = "Microsoft-VisualStudio-CpsCore";

        /// <summary>
        /// Tasks supported by Microsoft-VisualStudio-CpsCore.
        /// </summary>
        public enum Tasks : ushort
        {
            /// <summary>
            /// 'ReportCoreDirectoryTreeHintFileChanged' task.
            /// </summary>
            ReportCoreDirectoryTreeHintFileChanged = 65442,
            /// <summary>
            /// 'ReportOutputDataSource' task.
            /// </summary>
            ReportOutputDataSource = 65444,
            /// <summary>
            /// 'ReportProjectDataSourceVersionChanged' task.
            /// </summary>
            ReportProjectDataSourceVersionChanged = 65445,
            /// <summary>
            /// 'ReportPrioritySchedulerGap' task.
            /// </summary>
            ReportPrioritySchedulerGap = 65446,
            /// <summary>
            /// 'GlobbingWatchingTriggerReevaluationWriterLockRequestResult' task.
            /// </summary>
            GlobbingWatchingTriggerReevaluationWriterLockRequestResult = 65447,
            /// <summary>
            /// 'GlobbingWatchingTriggerReevaluationUpgradeableLockRequestEnd' task.
            /// </summary>
            GlobbingWatchingTriggerReevaluationUpgradeableLockRequestEnd = 65448,
            /// <summary>
            /// 'GlobbingWatchingTriggerReevaluationUpgradeableLockRequest' task.
            /// </summary>
            GlobbingWatchingTriggerReevaluationUpgradeableLockRequest = 65449,
            /// <summary>
            /// 'UpToDateCheckCalculateHash' task.
            /// </summary>
            UpToDateCheckCalculateHash = 65451,
            /// <summary>
            /// 'DesignTimeBuildFallbackToLegacy' task.
            /// </summary>
            DesignTimeBuildFallbackToLegacy = 65452,
            /// <summary>
            /// 'DesignTimeBuild' task.
            /// </summary>
            DesignTimeBuild = 65454,
            /// <summary>
            /// 'ProjectMarkDirtied' task.
            /// </summary>
            ProjectMarkDirtied = 65455,
            /// <summary>
            /// 'ProjectEvaluation' task.
            /// </summary>
            ProjectEvaluation = 65457,
            /// <summary>
            /// 'GetEvaluatedPropertyValue' task.
            /// </summary>
            GetEvaluatedPropertyValue = 65459,
            /// <summary>
            /// 'ProjectDirectoryTreeReleaseSubscription' task.
            /// </summary>
            ProjectDirectoryTreeReleaseSubscription = 65460,
            /// <summary>
            /// 'ProjectDirectoryTreeAddSubscription' task.
            /// </summary>
            ProjectDirectoryTreeAddSubscription = 65461,
            /// <summary>
            /// 'ProjectDirectoryTreeDisposed' task.
            /// </summary>
            ProjectDirectoryTreeDisposed = 65462,
            /// <summary>
            /// 'GlobbingWatchingTriggerReevaluation' task.
            /// </summary>
            GlobbingWatchingTriggerReevaluation = 65464,
            /// <summary>
            /// 'GlobbingWatchingConsistentCheck' task.
            /// </summary>
            GlobbingWatchingConsistentCheck = 65466,
            /// <summary>
            /// 'ConfiguredProjectVersionChanged' task.
            /// </summary>
            ConfiguredProjectVersionChanged = 65467,
            /// <summary>
            /// 'ProjectGlobbingWatchingServiceInitialized' task.
            /// </summary>
            ProjectGlobbingWatchingServiceInitialized = 65468,
            /// <summary>
            /// 'UnloadDynamicLoadComponents' task.
            /// </summary>
            UnloadDynamicLoadComponents = 65470,
            /// <summary>
            /// 'LoadDynamicLoadComponents' task.
            /// </summary>
            LoadDynamicLoadComponents = 65472,
            /// <summary>
            /// 'PublishingProjectCapabilities' task.
            /// </summary>
            PublishingProjectCapabilities = 65473,
            /// <summary>
            /// 'CapabilitiesTriggersProjectReload' task.
            /// </summary>
            CapabilitiesTriggersProjectReload = 65474,
            /// <summary>
            /// 'InitializeActiveTreeProvider' task.
            /// </summary>
            InitializeActiveTreeProvider = 65483,
            /// <summary>
            /// 'SetActiveTreeProvider' task.
            /// </summary>
            SetActiveTreeProvider = 65485,
            /// <summary>
            /// 'WaitAutoLoadMethodsToFinish' task.
            /// </summary>
            WaitAutoLoadMethodsToFinish = 65487,
            /// <summary>
            /// 'DirectoryTreeLoading' task.
            /// </summary>
            DirectoryTreeLoading = 65489,
            /// <summary>
            /// 'PhysicalTreeLoadingStop' task.
            /// </summary>
            PhysicalTreeLoadingStop = 65490,
            /// <summary>
            /// 'PhysicalTreeLoading' task.
            /// </summary>
            PhysicalTreeLoading = 65491,
            /// <summary>
            /// 'LoadConfiguredProject' task.
            /// </summary>
            LoadConfiguredProject = 65493,
            /// <summary>
            /// 'RemoveSourceItems' task.
            /// </summary>
            RemoveSourceItems = 65501,
            /// <summary>
            /// 'AddSourceItems' task.
            /// </summary>
            AddSourceItems = 65503,
            /// <summary>
            /// 'HintProcess' task.
            /// </summary>
            HintProcess = 65505,
            /// <summary>
            /// 'HintSubmission' task.
            /// </summary>
            HintSubmission = 65507,
            /// <summary>
            /// 'CreateItemSchema' task.
            /// </summary>
            CreateItemSchema = 65509,
            /// <summary>
            /// 'CreatePropertyCatalogs' task.
            /// </summary>
            CreatePropertyCatalogs = 65511,
            /// <summary>
            /// 'LoadSchemaFileStop' task.
            /// </summary>
            LoadSchemaFileStop = 65512,
            /// <summary>
            /// 'LoadSchemaFile' task.
            /// </summary>
            LoadSchemaFile = 65513,
            /// <summary>
            /// 'ProjectTreeProviderInitialization' task.
            /// </summary>
            ProjectTreeProviderInitialization = 65515,
            /// <summary>
            /// 'ProjectConfigurationDeactivated' task.
            /// </summary>
            ProjectConfigurationDeactivated = 65516,
            /// <summary>
            /// 'ProjectConfigurationActivated' task.
            /// </summary>
            ProjectConfigurationActivated = 65517,
            /// <summary>
            /// 'UpdateProjectRuleSnapshot' task.
            /// </summary>
            UpdateProjectRuleSnapshot = 65519,
            /// <summary>
            /// 'SubscribeRule' task.
            /// </summary>
            SubscribeRule = 65521,
            /// <summary>
            /// 'ProjectBuildRuleSnapshot' task.
            /// </summary>
            ProjectBuildRuleSnapshot = 65523,
            /// <summary>
            /// 'ProjectEvaluationRuleSnapshot' task.
            /// </summary>
            ProjectEvaluationRuleSnapshot = 65525,
            /// <summary>
            /// 'ProjectSnapshot' task.
            /// </summary>
            ProjectSnapshot = 65527,
            /// <summary>
            /// 'ProjectBuildSnapshot' task.
            /// </summary>
            ProjectBuildSnapshot = 65529,
            /// <summary>
            /// 'ProjectBuildStop' task.
            /// </summary>
            ProjectBuildStop = 65530,
            /// <summary>
            /// 'ProjectBuild' task.
            /// </summary>
            ProjectBuild = 65531,
            /// <summary>
            /// 'BatchBuild' task.
            /// </summary>
            BatchBuild = 65533,
            /// <summary>
            /// 'EventSourceMessage' task.
            /// </summary>
            EventSourceMessage = 65534,
        }

        /// <summary>
        /// Keywords supported by MicrosoftVisualStudioCpsCore.
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
        /// An event wrapper for a ProjectBuildStop event.
        /// </summary>
        public readonly ref struct ProjectBuildStopEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ProjectBuildStop";

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
                Task = (ushort)Tasks.ProjectBuildStop,
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
            public ProjectBuildStopData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ProjectBuildStopEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ProjectBuildStopEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ProjectBuildStop event.
            /// </summary>
            public ref struct ProjectBuildStopData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProjectPath;
                private int _offset_Configuration;
                private int _offset_RequestId;
                private int _offset_IsSuccessful;

                private int Offset_ProjectPath
                {
                    get
                    {
                        if (_offset_ProjectPath == -1)
                        {
                            _offset_ProjectPath = 0;
                        }

                        return _offset_ProjectPath;
                    }
                }

                private int Offset_Configuration
                {
                    get
                    {
                        if (_offset_Configuration == -1)
                        {
                            _offset_Configuration = Offset_ProjectPath + _etwEvent.UnicodeStringLength(Offset_ProjectPath);
                        }

                        return _offset_Configuration;
                    }
                }

                private int Offset_RequestId
                {
                    get
                    {
                        if (_offset_RequestId == -1)
                        {
                            _offset_RequestId = Offset_Configuration + _etwEvent.UnicodeStringLength(Offset_Configuration);
                        }

                        return _offset_RequestId;
                    }
                }

                private int Offset_IsSuccessful
                {
                    get
                    {
                        if (_offset_IsSuccessful == -1)
                        {
                            _offset_IsSuccessful = Offset_RequestId + 4;
                        }

                        return _offset_IsSuccessful;
                    }
                }

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectPath..]);

                /// <summary>
                /// Retrieves the Configuration field.
                /// </summary>
                public string Configuration => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Configuration..]);

                /// <summary>
                /// Retrieves the RequestId field.
                /// </summary>
                public int RequestId => BitConverter.ToInt32(_etwEvent.Data[Offset_RequestId..]);

                /// <summary>
                /// Retrieves the IsSuccessful field.
                /// </summary>
                public bool IsSuccessful => _etwEvent.Data[Offset_IsSuccessful] != 0;

                /// <summary>
                /// Creates a new ProjectBuildStopData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ProjectBuildStopData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProjectPath = -1;
                    _offset_Configuration = -1;
                    _offset_RequestId = -1;
                    _offset_IsSuccessful = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a CreateItemSchemaStart event.
        /// </summary>
        public readonly ref struct CreateItemSchemaStartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "CreateItemSchemaStart";

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
                Opcode = EtwEventOpcode.Start,
                Task = (ushort)Tasks.CreateItemSchema,
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
            public CreateItemSchemaStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new CreateItemSchemaStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public CreateItemSchemaStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a CreateItemSchemaStart event.
            /// </summary>
            public ref struct CreateItemSchemaStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProjectPath;
                private int _offset_Configuration;
                private int _offset_SnapshotId;

                private int Offset_ProjectPath
                {
                    get
                    {
                        if (_offset_ProjectPath == -1)
                        {
                            _offset_ProjectPath = 0;
                        }

                        return _offset_ProjectPath;
                    }
                }

                private int Offset_Configuration
                {
                    get
                    {
                        if (_offset_Configuration == -1)
                        {
                            _offset_Configuration = Offset_ProjectPath + _etwEvent.UnicodeStringLength(Offset_ProjectPath);
                        }

                        return _offset_Configuration;
                    }
                }

                private int Offset_SnapshotId
                {
                    get
                    {
                        if (_offset_SnapshotId == -1)
                        {
                            _offset_SnapshotId = Offset_Configuration + _etwEvent.UnicodeStringLength(Offset_Configuration);
                        }

                        return _offset_SnapshotId;
                    }
                }

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectPath..]);

                /// <summary>
                /// Retrieves the Configuration field.
                /// </summary>
                public string Configuration => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Configuration..]);

                /// <summary>
                /// Retrieves the SnapshotId field.
                /// </summary>
                public int SnapshotId => BitConverter.ToInt32(_etwEvent.Data[Offset_SnapshotId..]);

                /// <summary>
                /// Creates a new CreateItemSchemaStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public CreateItemSchemaStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProjectPath = -1;
                    _offset_Configuration = -1;
                    _offset_SnapshotId = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a CreateItemSchemaStop event.
        /// </summary>
        public readonly ref struct CreateItemSchemaStopEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "CreateItemSchemaStop";

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
                Opcode = EtwEventOpcode.End,
                Task = (ushort)Tasks.CreateItemSchema,
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
            public CreateItemSchemaStopData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new CreateItemSchemaStopEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public CreateItemSchemaStopEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a CreateItemSchemaStop event.
            /// </summary>
            public ref struct CreateItemSchemaStopData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProjectPath;
                private int _offset_Configuration;
                private int _offset_SnapshotId;

                private int Offset_ProjectPath
                {
                    get
                    {
                        if (_offset_ProjectPath == -1)
                        {
                            _offset_ProjectPath = 0;
                        }

                        return _offset_ProjectPath;
                    }
                }

                private int Offset_Configuration
                {
                    get
                    {
                        if (_offset_Configuration == -1)
                        {
                            _offset_Configuration = Offset_ProjectPath + _etwEvent.UnicodeStringLength(Offset_ProjectPath);
                        }

                        return _offset_Configuration;
                    }
                }

                private int Offset_SnapshotId
                {
                    get
                    {
                        if (_offset_SnapshotId == -1)
                        {
                            _offset_SnapshotId = Offset_Configuration + _etwEvent.UnicodeStringLength(Offset_Configuration);
                        }

                        return _offset_SnapshotId;
                    }
                }

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectPath..]);

                /// <summary>
                /// Retrieves the Configuration field.
                /// </summary>
                public string Configuration => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Configuration..]);

                /// <summary>
                /// Retrieves the SnapshotId field.
                /// </summary>
                public int SnapshotId => BitConverter.ToInt32(_etwEvent.Data[Offset_SnapshotId..]);

                /// <summary>
                /// Creates a new CreateItemSchemaStopData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public CreateItemSchemaStopData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProjectPath = -1;
                    _offset_Configuration = -1;
                    _offset_SnapshotId = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a PublishingProjectCapabilities event.
        /// </summary>
        public readonly ref struct PublishingProjectCapabilitiesEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "PublishingProjectCapabilities";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 61,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.PublishingProjectCapabilities,
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
            public PublishingProjectCapabilitiesData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new PublishingProjectCapabilitiesEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public PublishingProjectCapabilitiesEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a PublishingProjectCapabilities event.
            /// </summary>
            public ref struct PublishingProjectCapabilitiesData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProjectPath;
                private int _offset_Scope;
                private int _offset_ValueVersionNumber;
                private int _offset_ValueChanged;

                private int Offset_ProjectPath
                {
                    get
                    {
                        if (_offset_ProjectPath == -1)
                        {
                            _offset_ProjectPath = 0;
                        }

                        return _offset_ProjectPath;
                    }
                }

                private int Offset_Scope
                {
                    get
                    {
                        if (_offset_Scope == -1)
                        {
                            _offset_Scope = Offset_ProjectPath + _etwEvent.UnicodeStringLength(Offset_ProjectPath);
                        }

                        return _offset_Scope;
                    }
                }

                private int Offset_ValueVersionNumber
                {
                    get
                    {
                        if (_offset_ValueVersionNumber == -1)
                        {
                            _offset_ValueVersionNumber = Offset_Scope + _etwEvent.UnicodeStringLength(Offset_Scope);
                        }

                        return _offset_ValueVersionNumber;
                    }
                }

                private int Offset_ValueChanged
                {
                    get
                    {
                        if (_offset_ValueChanged == -1)
                        {
                            _offset_ValueChanged = Offset_ValueVersionNumber + 8;
                        }

                        return _offset_ValueChanged;
                    }
                }

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectPath..]);

                /// <summary>
                /// Retrieves the Scope field.
                /// </summary>
                public string Scope => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Scope..]);

                /// <summary>
                /// Retrieves the ValueVersionNumber field.
                /// </summary>
                public long ValueVersionNumber => BitConverter.ToInt64(_etwEvent.Data[Offset_ValueVersionNumber..]);

                /// <summary>
                /// Retrieves the ValueChanged field.
                /// </summary>
                public bool ValueChanged => _etwEvent.Data[Offset_ValueChanged] != 0;

                /// <summary>
                /// Creates a new PublishingProjectCapabilitiesData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public PublishingProjectCapabilitiesData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProjectPath = -1;
                    _offset_Scope = -1;
                    _offset_ValueVersionNumber = -1;
                    _offset_ValueChanged = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a LoadDynamicLoadComponentsStart event.
        /// </summary>
        public readonly ref struct LoadDynamicLoadComponentsStartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "LoadDynamicLoadComponentsStart";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 62,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Start,
                Task = (ushort)Tasks.LoadDynamicLoadComponents,
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
            public LoadDynamicLoadComponentsStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new LoadDynamicLoadComponentsStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public LoadDynamicLoadComponentsStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a LoadDynamicLoadComponentsStart event.
            /// </summary>
            public ref struct LoadDynamicLoadComponentsStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProjectPath;
                private int _offset_Scope;
                private int _offset_ValueVersionNumber;

                private int Offset_ProjectPath
                {
                    get
                    {
                        if (_offset_ProjectPath == -1)
                        {
                            _offset_ProjectPath = 0;
                        }

                        return _offset_ProjectPath;
                    }
                }

                private int Offset_Scope
                {
                    get
                    {
                        if (_offset_Scope == -1)
                        {
                            _offset_Scope = Offset_ProjectPath + _etwEvent.UnicodeStringLength(Offset_ProjectPath);
                        }

                        return _offset_Scope;
                    }
                }

                private int Offset_ValueVersionNumber
                {
                    get
                    {
                        if (_offset_ValueVersionNumber == -1)
                        {
                            _offset_ValueVersionNumber = Offset_Scope + _etwEvent.UnicodeStringLength(Offset_Scope);
                        }

                        return _offset_ValueVersionNumber;
                    }
                }

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectPath..]);

                /// <summary>
                /// Retrieves the Scope field.
                /// </summary>
                public string Scope => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Scope..]);

                /// <summary>
                /// Retrieves the ValueVersionNumber field.
                /// </summary>
                public long ValueVersionNumber => BitConverter.ToInt64(_etwEvent.Data[Offset_ValueVersionNumber..]);

                /// <summary>
                /// Creates a new LoadDynamicLoadComponentsStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public LoadDynamicLoadComponentsStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProjectPath = -1;
                    _offset_Scope = -1;
                    _offset_ValueVersionNumber = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ConfiguredProjectVersionChanged event.
        /// </summary>
        public readonly ref struct ConfiguredProjectVersionChangedEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ConfiguredProjectVersionChanged";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 67,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.ConfiguredProjectVersionChanged,
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
            public ConfiguredProjectVersionChangedData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ConfiguredProjectVersionChangedEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ConfiguredProjectVersionChangedEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ConfiguredProjectVersionChanged event.
            /// </summary>
            public ref struct ConfiguredProjectVersionChangedData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProjectPath;
                private int _offset_ConfigurationName;
                private int _offset_Version;

                private int Offset_ProjectPath
                {
                    get
                    {
                        if (_offset_ProjectPath == -1)
                        {
                            _offset_ProjectPath = 0;
                        }

                        return _offset_ProjectPath;
                    }
                }

                private int Offset_ConfigurationName
                {
                    get
                    {
                        if (_offset_ConfigurationName == -1)
                        {
                            _offset_ConfigurationName = Offset_ProjectPath + _etwEvent.UnicodeStringLength(Offset_ProjectPath);
                        }

                        return _offset_ConfigurationName;
                    }
                }

                private int Offset_Version
                {
                    get
                    {
                        if (_offset_Version == -1)
                        {
                            _offset_Version = Offset_ConfigurationName + _etwEvent.UnicodeStringLength(Offset_ConfigurationName);
                        }

                        return _offset_Version;
                    }
                }

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectPath..]);

                /// <summary>
                /// Retrieves the ConfigurationName field.
                /// </summary>
                public string ConfigurationName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ConfigurationName..]);

                /// <summary>
                /// Retrieves the Version field.
                /// </summary>
                public long Version => BitConverter.ToInt64(_etwEvent.Data[Offset_Version..]);

                /// <summary>
                /// Creates a new ConfiguredProjectVersionChangedData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ConfiguredProjectVersionChangedData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProjectPath = -1;
                    _offset_ConfigurationName = -1;
                    _offset_Version = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ReportPrioritySchedulerGap event.
        /// </summary>
        public readonly ref struct ReportPrioritySchedulerGapEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ReportPrioritySchedulerGap";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 88,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.ReportPrioritySchedulerGap,
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
            public ReportPrioritySchedulerGapData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ReportPrioritySchedulerGapEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ReportPrioritySchedulerGapEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ReportPrioritySchedulerGap event.
            /// </summary>
            public ref struct ReportPrioritySchedulerGapData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Time;
                private int _offset_IsPostCallback;

                private int Offset_Time
                {
                    get
                    {
                        if (_offset_Time == -1)
                        {
                            _offset_Time = 0;
                        }

                        return _offset_Time;
                    }
                }

                private int Offset_IsPostCallback
                {
                    get
                    {
                        if (_offset_IsPostCallback == -1)
                        {
                            _offset_IsPostCallback = Offset_Time + 4;
                        }

                        return _offset_IsPostCallback;
                    }
                }

                /// <summary>
                /// Retrieves the Time field.
                /// </summary>
                public int Time => BitConverter.ToInt32(_etwEvent.Data[Offset_Time..]);

                /// <summary>
                /// Retrieves the IsPostCallback field.
                /// </summary>
                public bool IsPostCallback => _etwEvent.Data[Offset_IsPostCallback] != 0;

                /// <summary>
                /// Creates a new ReportPrioritySchedulerGapData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ReportPrioritySchedulerGapData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Time = -1;
                    _offset_IsPostCallback = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ReportProjectDataSourceVersionChanged event.
        /// </summary>
        public readonly ref struct ReportProjectDataSourceVersionChangedEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ReportProjectDataSourceVersionChanged";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 89,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.ReportProjectDataSourceVersionChanged,
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
            public ReportProjectDataSourceVersionChangedData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ReportProjectDataSourceVersionChangedEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ReportProjectDataSourceVersionChangedEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ReportProjectDataSourceVersionChanged event.
            /// </summary>
            public ref struct ReportProjectDataSourceVersionChangedData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Project;
                private int _offset_DataSourceId;
                private int _offset_DataSourceName;

                private int Offset_Project
                {
                    get
                    {
                        if (_offset_Project == -1)
                        {
                            _offset_Project = 0;
                        }

                        return _offset_Project;
                    }
                }

                private int Offset_DataSourceId
                {
                    get
                    {
                        if (_offset_DataSourceId == -1)
                        {
                            _offset_DataSourceId = Offset_Project + _etwEvent.UnicodeStringLength(Offset_Project);
                        }

                        return _offset_DataSourceId;
                    }
                }

                private int Offset_DataSourceName
                {
                    get
                    {
                        if (_offset_DataSourceName == -1)
                        {
                            _offset_DataSourceName = Offset_DataSourceId + 4;
                        }

                        return _offset_DataSourceName;
                    }
                }

                /// <summary>
                /// Retrieves the Project field.
                /// </summary>
                public string Project => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Project..]);

                /// <summary>
                /// Retrieves the DataSourceId field.
                /// </summary>
                public int DataSourceId => BitConverter.ToInt32(_etwEvent.Data[Offset_DataSourceId..]);

                /// <summary>
                /// Retrieves the DataSourceName field.
                /// </summary>
                public string DataSourceName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_DataSourceName..]);

                /// <summary>
                /// Creates a new ReportProjectDataSourceVersionChangedData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ReportProjectDataSourceVersionChangedData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Project = -1;
                    _offset_DataSourceId = -1;
                    _offset_DataSourceName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ProjectEvaluationRuleSnapshotStart event.
        /// </summary>
        public readonly ref struct ProjectEvaluationRuleSnapshotStartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ProjectEvaluationRuleSnapshotStart";

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
                Level = EtwTraceLevel.Verbose,
                Opcode = EtwEventOpcode.Start,
                Task = (ushort)Tasks.ProjectEvaluationRuleSnapshot,
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
            public ProjectEvaluationRuleSnapshotStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ProjectEvaluationRuleSnapshotStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ProjectEvaluationRuleSnapshotStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ProjectEvaluationRuleSnapshotStart event.
            /// </summary>
            public ref struct ProjectEvaluationRuleSnapshotStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProjectPath;
                private int _offset_ConfigurationName;
                private int _offset_RuleName;

                private int Offset_ProjectPath
                {
                    get
                    {
                        if (_offset_ProjectPath == -1)
                        {
                            _offset_ProjectPath = 0;
                        }

                        return _offset_ProjectPath;
                    }
                }

                private int Offset_ConfigurationName
                {
                    get
                    {
                        if (_offset_ConfigurationName == -1)
                        {
                            _offset_ConfigurationName = Offset_ProjectPath + _etwEvent.UnicodeStringLength(Offset_ProjectPath);
                        }

                        return _offset_ConfigurationName;
                    }
                }

                private int Offset_RuleName
                {
                    get
                    {
                        if (_offset_RuleName == -1)
                        {
                            _offset_RuleName = Offset_ConfigurationName + _etwEvent.UnicodeStringLength(Offset_ConfigurationName);
                        }

                        return _offset_RuleName;
                    }
                }

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectPath..]);

                /// <summary>
                /// Retrieves the ConfigurationName field.
                /// </summary>
                public string ConfigurationName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ConfigurationName..]);

                /// <summary>
                /// Retrieves the RuleName field.
                /// </summary>
                public string RuleName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_RuleName..]);

                /// <summary>
                /// Creates a new ProjectEvaluationRuleSnapshotStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ProjectEvaluationRuleSnapshotStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProjectPath = -1;
                    _offset_ConfigurationName = -1;
                    _offset_RuleName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ProjectEvaluationRuleSnapshotStop event.
        /// </summary>
        public readonly ref struct ProjectEvaluationRuleSnapshotStopEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ProjectEvaluationRuleSnapshotStop";

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
                Opcode = EtwEventOpcode.End,
                Task = (ushort)Tasks.ProjectEvaluationRuleSnapshot,
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
            public ProjectEvaluationRuleSnapshotStopData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ProjectEvaluationRuleSnapshotStopEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ProjectEvaluationRuleSnapshotStopEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ProjectEvaluationRuleSnapshotStop event.
            /// </summary>
            public ref struct ProjectEvaluationRuleSnapshotStopData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProjectPath;
                private int _offset_ConfigurationName;
                private int _offset_RuleName;

                private int Offset_ProjectPath
                {
                    get
                    {
                        if (_offset_ProjectPath == -1)
                        {
                            _offset_ProjectPath = 0;
                        }

                        return _offset_ProjectPath;
                    }
                }

                private int Offset_ConfigurationName
                {
                    get
                    {
                        if (_offset_ConfigurationName == -1)
                        {
                            _offset_ConfigurationName = Offset_ProjectPath + _etwEvent.UnicodeStringLength(Offset_ProjectPath);
                        }

                        return _offset_ConfigurationName;
                    }
                }

                private int Offset_RuleName
                {
                    get
                    {
                        if (_offset_RuleName == -1)
                        {
                            _offset_RuleName = Offset_ConfigurationName + _etwEvent.UnicodeStringLength(Offset_ConfigurationName);
                        }

                        return _offset_RuleName;
                    }
                }

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectPath..]);

                /// <summary>
                /// Retrieves the ConfigurationName field.
                /// </summary>
                public string ConfigurationName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ConfigurationName..]);

                /// <summary>
                /// Retrieves the RuleName field.
                /// </summary>
                public string RuleName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_RuleName..]);

                /// <summary>
                /// Creates a new ProjectEvaluationRuleSnapshotStopData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ProjectEvaluationRuleSnapshotStopData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProjectPath = -1;
                    _offset_ConfigurationName = -1;
                    _offset_RuleName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a LoadSchemaFileStop event.
        /// </summary>
        public readonly ref struct LoadSchemaFileStopEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "LoadSchemaFileStop";

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
                Opcode = EtwEventOpcode.End,
                Task = (ushort)Tasks.LoadSchemaFileStop,
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
            public LoadSchemaFileStopData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new LoadSchemaFileStopEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public LoadSchemaFileStopEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a LoadSchemaFileStop event.
            /// </summary>
            public ref struct LoadSchemaFileStopData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_FilePath;

                private int Offset_FilePath
                {
                    get
                    {
                        if (_offset_FilePath == -1)
                        {
                            _offset_FilePath = 0;
                        }

                        return _offset_FilePath;
                    }
                }

                /// <summary>
                /// Retrieves the FilePath field.
                /// </summary>
                public string FilePath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FilePath..]);

                /// <summary>
                /// Creates a new LoadSchemaFileStopData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public LoadSchemaFileStopData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_FilePath = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a PhysicalTreeLoadingStop event.
        /// </summary>
        public readonly ref struct PhysicalTreeLoadingStopEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "PhysicalTreeLoadingStop";

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
                Opcode = EtwEventOpcode.End,
                Task = (ushort)Tasks.PhysicalTreeLoadingStop,
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
            public PhysicalTreeLoadingStopData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new PhysicalTreeLoadingStopEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public PhysicalTreeLoadingStopEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a PhysicalTreeLoadingStop event.
            /// </summary>
            public ref struct PhysicalTreeLoadingStopData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProjectPath;

                private int Offset_ProjectPath
                {
                    get
                    {
                        if (_offset_ProjectPath == -1)
                        {
                            _offset_ProjectPath = 0;
                        }

                        return _offset_ProjectPath;
                    }
                }

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectPath..]);

                /// <summary>
                /// Creates a new PhysicalTreeLoadingStopData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public PhysicalTreeLoadingStopData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProjectPath = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a LoadDynamicLoadComponentsStop event.
        /// </summary>
        public readonly ref struct LoadDynamicLoadComponentsStopEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "LoadDynamicLoadComponentsStop";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 63,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.End,
                Task = (ushort)Tasks.LoadDynamicLoadComponents,
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
            public LoadDynamicLoadComponentsStopData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new LoadDynamicLoadComponentsStopEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public LoadDynamicLoadComponentsStopEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a LoadDynamicLoadComponentsStop event.
            /// </summary>
            public ref struct LoadDynamicLoadComponentsStopData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProjectPath;
                private int _offset_Scope;

                private int Offset_ProjectPath
                {
                    get
                    {
                        if (_offset_ProjectPath == -1)
                        {
                            _offset_ProjectPath = 0;
                        }

                        return _offset_ProjectPath;
                    }
                }

                private int Offset_Scope
                {
                    get
                    {
                        if (_offset_Scope == -1)
                        {
                            _offset_Scope = Offset_ProjectPath + _etwEvent.UnicodeStringLength(Offset_ProjectPath);
                        }

                        return _offset_Scope;
                    }
                }

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectPath..]);

                /// <summary>
                /// Retrieves the Scope field.
                /// </summary>
                public string Scope => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Scope..]);

                /// <summary>
                /// Creates a new LoadDynamicLoadComponentsStopData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public LoadDynamicLoadComponentsStopData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProjectPath = -1;
                    _offset_Scope = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a BatchBuildStart event.
        /// </summary>
        public readonly ref struct BatchBuildStartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "BatchBuildStart";

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
                Task = (ushort)Tasks.BatchBuild,
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
            public BatchBuildStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new BatchBuildStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public BatchBuildStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a BatchBuildStart event.
            /// </summary>
            public ref struct BatchBuildStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Host;
                private int _offset_RequestCount;
                private int _offset_Requests;

                private int Offset_Host
                {
                    get
                    {
                        if (_offset_Host == -1)
                        {
                            _offset_Host = 0;
                        }

                        return _offset_Host;
                    }
                }

                private int Offset_RequestCount
                {
                    get
                    {
                        if (_offset_RequestCount == -1)
                        {
                            _offset_RequestCount = Offset_Host + _etwEvent.UnicodeStringLength(Offset_Host);
                        }

                        return _offset_RequestCount;
                    }
                }

                private int Offset_Requests
                {
                    get
                    {
                        if (_offset_Requests == -1)
                        {
                            _offset_Requests = Offset_RequestCount + 4;
                        }

                        return _offset_Requests;
                    }
                }

                /// <summary>
                /// Retrieves the Host field.
                /// </summary>
                public string Host => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Host..]);

                /// <summary>
                /// Retrieves the RequestCount field.
                /// </summary>
                public int RequestCount => BitConverter.ToInt32(_etwEvent.Data[Offset_RequestCount..]);

                /// <summary>
                /// Retrieves the Requests field.
                /// </summary>
                public string Requests => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Requests..]);

                /// <summary>
                /// Creates a new BatchBuildStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public BatchBuildStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Host = -1;
                    _offset_RequestCount = -1;
                    _offset_Requests = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a BatchBuildStop event.
        /// </summary>
        public readonly ref struct BatchBuildStopEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "BatchBuildStop";

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
                Task = (ushort)Tasks.BatchBuild,
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
            public BatchBuildStopData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new BatchBuildStopEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public BatchBuildStopEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a BatchBuildStop event.
            /// </summary>
            public ref struct BatchBuildStopData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Host;
                private int _offset_RequestCount;
                private int _offset__;

                private int Offset_Host
                {
                    get
                    {
                        if (_offset_Host == -1)
                        {
                            _offset_Host = 0;
                        }

                        return _offset_Host;
                    }
                }

                private int Offset_RequestCount
                {
                    get
                    {
                        if (_offset_RequestCount == -1)
                        {
                            _offset_RequestCount = Offset_Host + _etwEvent.UnicodeStringLength(Offset_Host);
                        }

                        return _offset_RequestCount;
                    }
                }

                private int Offset__
                {
                    get
                    {
                        if (_offset__ == -1)
                        {
                            _offset__ = Offset_RequestCount + 4;
                        }

                        return _offset__;
                    }
                }

                /// <summary>
                /// Retrieves the Host field.
                /// </summary>
                public string Host => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Host..]);

                /// <summary>
                /// Retrieves the RequestCount field.
                /// </summary>
                public int RequestCount => BitConverter.ToInt32(_etwEvent.Data[Offset_RequestCount..]);

                /// <summary>
                /// Creates a new BatchBuildStopData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public BatchBuildStopData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Host = -1;
                    _offset_RequestCount = -1;
                    _offset__ = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ProjectBuildStart event.
        /// </summary>
        public readonly ref struct ProjectBuildStartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ProjectBuildStart";

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
                Task = (ushort)Tasks.ProjectBuild,
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
            public ProjectBuildStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ProjectBuildStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ProjectBuildStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ProjectBuildStart event.
            /// </summary>
            public ref struct ProjectBuildStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProjectPath;
                private int _offset_Configuration;
                private int _offset_RequestId;
                private int _offset_Targets;
                private int _offset_IsUsingProjectInstance;

                private int Offset_ProjectPath
                {
                    get
                    {
                        if (_offset_ProjectPath == -1)
                        {
                            _offset_ProjectPath = 0;
                        }

                        return _offset_ProjectPath;
                    }
                }

                private int Offset_Configuration
                {
                    get
                    {
                        if (_offset_Configuration == -1)
                        {
                            _offset_Configuration = Offset_ProjectPath + _etwEvent.UnicodeStringLength(Offset_ProjectPath);
                        }

                        return _offset_Configuration;
                    }
                }

                private int Offset_RequestId
                {
                    get
                    {
                        if (_offset_RequestId == -1)
                        {
                            _offset_RequestId = Offset_Configuration + _etwEvent.UnicodeStringLength(Offset_Configuration);
                        }

                        return _offset_RequestId;
                    }
                }

                private int Offset_Targets
                {
                    get
                    {
                        if (_offset_Targets == -1)
                        {
                            _offset_Targets = Offset_RequestId + 4;
                        }

                        return _offset_Targets;
                    }
                }

                private int Offset_IsUsingProjectInstance
                {
                    get
                    {
                        if (_offset_IsUsingProjectInstance == -1)
                        {
                            _offset_IsUsingProjectInstance = Offset_Targets + _etwEvent.UnicodeStringLength(Offset_Targets);
                        }

                        return _offset_IsUsingProjectInstance;
                    }
                }

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectPath..]);

                /// <summary>
                /// Retrieves the Configuration field.
                /// </summary>
                public string Configuration => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Configuration..]);

                /// <summary>
                /// Retrieves the RequestId field.
                /// </summary>
                public int RequestId => BitConverter.ToInt32(_etwEvent.Data[Offset_RequestId..]);

                /// <summary>
                /// Retrieves the Targets field.
                /// </summary>
                public string Targets => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Targets..]);

                /// <summary>
                /// Retrieves the IsUsingProjectInstance field.
                /// </summary>
                public bool IsUsingProjectInstance => _etwEvent.Data[Offset_IsUsingProjectInstance] != 0;

                /// <summary>
                /// Creates a new ProjectBuildStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ProjectBuildStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProjectPath = -1;
                    _offset_Configuration = -1;
                    _offset_RequestId = -1;
                    _offset_Targets = -1;
                    _offset_IsUsingProjectInstance = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ProjectBuildSnapshotStart event.
        /// </summary>
        public readonly ref struct ProjectBuildSnapshotStartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ProjectBuildSnapshotStart";

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
                Opcode = EtwEventOpcode.Start,
                Task = (ushort)Tasks.ProjectBuildSnapshot,
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
            public ProjectBuildSnapshotStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ProjectBuildSnapshotStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ProjectBuildSnapshotStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ProjectBuildSnapshotStart event.
            /// </summary>
            public ref struct ProjectBuildSnapshotStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProjectPath;
                private int _offset_InstanceId;
                private int _offset_Targets;

                private int Offset_ProjectPath
                {
                    get
                    {
                        if (_offset_ProjectPath == -1)
                        {
                            _offset_ProjectPath = 0;
                        }

                        return _offset_ProjectPath;
                    }
                }

                private int Offset_InstanceId
                {
                    get
                    {
                        if (_offset_InstanceId == -1)
                        {
                            _offset_InstanceId = Offset_ProjectPath + _etwEvent.UnicodeStringLength(Offset_ProjectPath);
                        }

                        return _offset_InstanceId;
                    }
                }

                private int Offset_Targets
                {
                    get
                    {
                        if (_offset_Targets == -1)
                        {
                            _offset_Targets = Offset_InstanceId + 4;
                        }

                        return _offset_Targets;
                    }
                }

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectPath..]);

                /// <summary>
                /// Retrieves the InstanceId field.
                /// </summary>
                public int InstanceId => BitConverter.ToInt32(_etwEvent.Data[Offset_InstanceId..]);

                /// <summary>
                /// Retrieves the Targets field.
                /// </summary>
                public string Targets => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Targets..]);

                /// <summary>
                /// Creates a new ProjectBuildSnapshotStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ProjectBuildSnapshotStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProjectPath = -1;
                    _offset_InstanceId = -1;
                    _offset_Targets = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ProjectBuildSnapshotStop event.
        /// </summary>
        public readonly ref struct ProjectBuildSnapshotStopEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ProjectBuildSnapshotStop";

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
                Opcode = EtwEventOpcode.End,
                Task = (ushort)Tasks.ProjectBuildSnapshot,
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
            public ProjectBuildSnapshotStopData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ProjectBuildSnapshotStopEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ProjectBuildSnapshotStopEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ProjectBuildSnapshotStop event.
            /// </summary>
            public ref struct ProjectBuildSnapshotStopData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProjectPath;
                private int _offset_InstanceId;

                private int Offset_ProjectPath
                {
                    get
                    {
                        if (_offset_ProjectPath == -1)
                        {
                            _offset_ProjectPath = 0;
                        }

                        return _offset_ProjectPath;
                    }
                }

                private int Offset_InstanceId
                {
                    get
                    {
                        if (_offset_InstanceId == -1)
                        {
                            _offset_InstanceId = Offset_ProjectPath + _etwEvent.UnicodeStringLength(Offset_ProjectPath);
                        }

                        return _offset_InstanceId;
                    }
                }

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectPath..]);

                /// <summary>
                /// Retrieves the InstanceId field.
                /// </summary>
                public int InstanceId => BitConverter.ToInt32(_etwEvent.Data[Offset_InstanceId..]);

                /// <summary>
                /// Creates a new ProjectBuildSnapshotStopData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ProjectBuildSnapshotStopData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProjectPath = -1;
                    _offset_InstanceId = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ProjectSnapshotStart event.
        /// </summary>
        public readonly ref struct ProjectSnapshotStartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ProjectSnapshotStart";

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
                Opcode = EtwEventOpcode.Start,
                Task = (ushort)Tasks.ProjectSnapshot,
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
            public ProjectSnapshotStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ProjectSnapshotStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ProjectSnapshotStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ProjectSnapshotStart event.
            /// </summary>
            public ref struct ProjectSnapshotStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProjectPath;
                private int _offset_ConfigurationName;
                private int _offset_Version;

                private int Offset_ProjectPath
                {
                    get
                    {
                        if (_offset_ProjectPath == -1)
                        {
                            _offset_ProjectPath = 0;
                        }

                        return _offset_ProjectPath;
                    }
                }

                private int Offset_ConfigurationName
                {
                    get
                    {
                        if (_offset_ConfigurationName == -1)
                        {
                            _offset_ConfigurationName = Offset_ProjectPath + _etwEvent.UnicodeStringLength(Offset_ProjectPath);
                        }

                        return _offset_ConfigurationName;
                    }
                }

                private int Offset_Version
                {
                    get
                    {
                        if (_offset_Version == -1)
                        {
                            _offset_Version = Offset_ConfigurationName + _etwEvent.UnicodeStringLength(Offset_ConfigurationName);
                        }

                        return _offset_Version;
                    }
                }

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectPath..]);

                /// <summary>
                /// Retrieves the ConfigurationName field.
                /// </summary>
                public string ConfigurationName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ConfigurationName..]);

                /// <summary>
                /// Retrieves the Version field.
                /// </summary>
                public long Version => BitConverter.ToInt64(_etwEvent.Data[Offset_Version..]);

                /// <summary>
                /// Creates a new ProjectSnapshotStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ProjectSnapshotStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProjectPath = -1;
                    _offset_ConfigurationName = -1;
                    _offset_Version = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ProjectSnapshotStop event.
        /// </summary>
        public readonly ref struct ProjectSnapshotStopEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ProjectSnapshotStop";

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
                Opcode = EtwEventOpcode.End,
                Task = (ushort)Tasks.ProjectSnapshot,
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
            public ProjectSnapshotStopData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ProjectSnapshotStopEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ProjectSnapshotStopEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ProjectSnapshotStop event.
            /// </summary>
            public ref struct ProjectSnapshotStopData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProjectPath;
                private int _offset_ConfigurationName;
                private int _offset_Version;
                private int _offset_InstanceId;

                private int Offset_ProjectPath
                {
                    get
                    {
                        if (_offset_ProjectPath == -1)
                        {
                            _offset_ProjectPath = 0;
                        }

                        return _offset_ProjectPath;
                    }
                }

                private int Offset_ConfigurationName
                {
                    get
                    {
                        if (_offset_ConfigurationName == -1)
                        {
                            _offset_ConfigurationName = Offset_ProjectPath + _etwEvent.UnicodeStringLength(Offset_ProjectPath);
                        }

                        return _offset_ConfigurationName;
                    }
                }

                private int Offset_Version
                {
                    get
                    {
                        if (_offset_Version == -1)
                        {
                            _offset_Version = Offset_ConfigurationName + _etwEvent.UnicodeStringLength(Offset_ConfigurationName);
                        }

                        return _offset_Version;
                    }
                }

                private int Offset_InstanceId
                {
                    get
                    {
                        if (_offset_InstanceId == -1)
                        {
                            _offset_InstanceId = Offset_Version + 8;
                        }

                        return _offset_InstanceId;
                    }
                }

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectPath..]);

                /// <summary>
                /// Retrieves the ConfigurationName field.
                /// </summary>
                public string ConfigurationName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ConfigurationName..]);

                /// <summary>
                /// Retrieves the Version field.
                /// </summary>
                public long Version => BitConverter.ToInt64(_etwEvent.Data[Offset_Version..]);

                /// <summary>
                /// Retrieves the InstanceId field.
                /// </summary>
                public int InstanceId => BitConverter.ToInt32(_etwEvent.Data[Offset_InstanceId..]);

                /// <summary>
                /// Creates a new ProjectSnapshotStopData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ProjectSnapshotStopData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProjectPath = -1;
                    _offset_ConfigurationName = -1;
                    _offset_Version = -1;
                    _offset_InstanceId = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ProjectBuildRuleSnapshotStart event.
        /// </summary>
        public readonly ref struct ProjectBuildRuleSnapshotStartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ProjectBuildRuleSnapshotStart";

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
                Opcode = EtwEventOpcode.Start,
                Task = (ushort)Tasks.ProjectBuildRuleSnapshot,
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
            public ProjectBuildRuleSnapshotStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ProjectBuildRuleSnapshotStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ProjectBuildRuleSnapshotStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ProjectBuildRuleSnapshotStart event.
            /// </summary>
            public ref struct ProjectBuildRuleSnapshotStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProjectPath;
                private int _offset_ConfigurationName;
                private int _offset_RuleName;

                private int Offset_ProjectPath
                {
                    get
                    {
                        if (_offset_ProjectPath == -1)
                        {
                            _offset_ProjectPath = 0;
                        }

                        return _offset_ProjectPath;
                    }
                }

                private int Offset_ConfigurationName
                {
                    get
                    {
                        if (_offset_ConfigurationName == -1)
                        {
                            _offset_ConfigurationName = Offset_ProjectPath + _etwEvent.UnicodeStringLength(Offset_ProjectPath);
                        }

                        return _offset_ConfigurationName;
                    }
                }

                private int Offset_RuleName
                {
                    get
                    {
                        if (_offset_RuleName == -1)
                        {
                            _offset_RuleName = Offset_ConfigurationName + _etwEvent.UnicodeStringLength(Offset_ConfigurationName);
                        }

                        return _offset_RuleName;
                    }
                }

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectPath..]);

                /// <summary>
                /// Retrieves the ConfigurationName field.
                /// </summary>
                public string ConfigurationName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ConfigurationName..]);

                /// <summary>
                /// Retrieves the RuleName field.
                /// </summary>
                public string RuleName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_RuleName..]);

                /// <summary>
                /// Creates a new ProjectBuildRuleSnapshotStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ProjectBuildRuleSnapshotStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProjectPath = -1;
                    _offset_ConfigurationName = -1;
                    _offset_RuleName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ProjectBuildRuleSnapshotStop event.
        /// </summary>
        public readonly ref struct ProjectBuildRuleSnapshotStopEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ProjectBuildRuleSnapshotStop";

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
                Level = EtwTraceLevel.Verbose,
                Opcode = EtwEventOpcode.End,
                Task = (ushort)Tasks.ProjectBuildRuleSnapshot,
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
            public ProjectBuildRuleSnapshotStopData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ProjectBuildRuleSnapshotStopEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ProjectBuildRuleSnapshotStopEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ProjectBuildRuleSnapshotStop event.
            /// </summary>
            public ref struct ProjectBuildRuleSnapshotStopData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProjectPath;
                private int _offset_ConfigurationName;
                private int _offset_RuleName;

                private int Offset_ProjectPath
                {
                    get
                    {
                        if (_offset_ProjectPath == -1)
                        {
                            _offset_ProjectPath = 0;
                        }

                        return _offset_ProjectPath;
                    }
                }

                private int Offset_ConfigurationName
                {
                    get
                    {
                        if (_offset_ConfigurationName == -1)
                        {
                            _offset_ConfigurationName = Offset_ProjectPath + _etwEvent.UnicodeStringLength(Offset_ProjectPath);
                        }

                        return _offset_ConfigurationName;
                    }
                }

                private int Offset_RuleName
                {
                    get
                    {
                        if (_offset_RuleName == -1)
                        {
                            _offset_RuleName = Offset_ConfigurationName + _etwEvent.UnicodeStringLength(Offset_ConfigurationName);
                        }

                        return _offset_RuleName;
                    }
                }

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectPath..]);

                /// <summary>
                /// Retrieves the ConfigurationName field.
                /// </summary>
                public string ConfigurationName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ConfigurationName..]);

                /// <summary>
                /// Retrieves the RuleName field.
                /// </summary>
                public string RuleName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_RuleName..]);

                /// <summary>
                /// Creates a new ProjectBuildRuleSnapshotStopData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ProjectBuildRuleSnapshotStopData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProjectPath = -1;
                    _offset_ConfigurationName = -1;
                    _offset_RuleName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a SubscribeRuleStart event.
        /// </summary>
        public readonly ref struct SubscribeRuleStartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SubscribeRuleStart";

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
                Opcode = EtwEventOpcode.Start,
                Task = (ushort)Tasks.SubscribeRule,
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
            public SubscribeRuleStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new SubscribeRuleStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SubscribeRuleStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a SubscribeRuleStart event.
            /// </summary>
            public ref struct SubscribeRuleStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProjectPath;
                private int _offset_ConfigurationName;
                private int _offset_Rules;

                private int Offset_ProjectPath
                {
                    get
                    {
                        if (_offset_ProjectPath == -1)
                        {
                            _offset_ProjectPath = 0;
                        }

                        return _offset_ProjectPath;
                    }
                }

                private int Offset_ConfigurationName
                {
                    get
                    {
                        if (_offset_ConfigurationName == -1)
                        {
                            _offset_ConfigurationName = Offset_ProjectPath + _etwEvent.UnicodeStringLength(Offset_ProjectPath);
                        }

                        return _offset_ConfigurationName;
                    }
                }

                private int Offset_Rules
                {
                    get
                    {
                        if (_offset_Rules == -1)
                        {
                            _offset_Rules = Offset_ConfigurationName + _etwEvent.UnicodeStringLength(Offset_ConfigurationName);
                        }

                        return _offset_Rules;
                    }
                }

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectPath..]);

                /// <summary>
                /// Retrieves the ConfigurationName field.
                /// </summary>
                public string ConfigurationName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ConfigurationName..]);

                /// <summary>
                /// Retrieves the Rules field.
                /// </summary>
                public string Rules => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Rules..]);

                /// <summary>
                /// Creates a new SubscribeRuleStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public SubscribeRuleStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProjectPath = -1;
                    _offset_ConfigurationName = -1;
                    _offset_Rules = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a SubscribeRuleStop event.
        /// </summary>
        public readonly ref struct SubscribeRuleStopEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SubscribeRuleStop";

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
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.End,
                Task = (ushort)Tasks.SubscribeRule,
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
            public SubscribeRuleStopData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new SubscribeRuleStopEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SubscribeRuleStopEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a SubscribeRuleStop event.
            /// </summary>
            public ref struct SubscribeRuleStopData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProjectPath;
                private int _offset_ConfigurationName;
                private int _offset_Rules;

                private int Offset_ProjectPath
                {
                    get
                    {
                        if (_offset_ProjectPath == -1)
                        {
                            _offset_ProjectPath = 0;
                        }

                        return _offset_ProjectPath;
                    }
                }

                private int Offset_ConfigurationName
                {
                    get
                    {
                        if (_offset_ConfigurationName == -1)
                        {
                            _offset_ConfigurationName = Offset_ProjectPath + _etwEvent.UnicodeStringLength(Offset_ProjectPath);
                        }

                        return _offset_ConfigurationName;
                    }
                }

                private int Offset_Rules
                {
                    get
                    {
                        if (_offset_Rules == -1)
                        {
                            _offset_Rules = Offset_ConfigurationName + _etwEvent.UnicodeStringLength(Offset_ConfigurationName);
                        }

                        return _offset_Rules;
                    }
                }

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectPath..]);

                /// <summary>
                /// Retrieves the ConfigurationName field.
                /// </summary>
                public string ConfigurationName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ConfigurationName..]);

                /// <summary>
                /// Retrieves the Rules field.
                /// </summary>
                public string Rules => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Rules..]);

                /// <summary>
                /// Creates a new SubscribeRuleStopData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public SubscribeRuleStopData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProjectPath = -1;
                    _offset_ConfigurationName = -1;
                    _offset_Rules = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a UpdateProjectRuleSnapshotStart event.
        /// </summary>
        public readonly ref struct UpdateProjectRuleSnapshotStartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "UpdateProjectRuleSnapshotStart";

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
                Opcode = EtwEventOpcode.Start,
                Task = (ushort)Tasks.UpdateProjectRuleSnapshot,
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
            public UpdateProjectRuleSnapshotStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new UpdateProjectRuleSnapshotStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public UpdateProjectRuleSnapshotStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a UpdateProjectRuleSnapshotStart event.
            /// </summary>
            public ref struct UpdateProjectRuleSnapshotStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProjectPath;
                private int _offset_ConfigurationName;
                private int _offset_SubscriptionType;

                private int Offset_ProjectPath
                {
                    get
                    {
                        if (_offset_ProjectPath == -1)
                        {
                            _offset_ProjectPath = 0;
                        }

                        return _offset_ProjectPath;
                    }
                }

                private int Offset_ConfigurationName
                {
                    get
                    {
                        if (_offset_ConfigurationName == -1)
                        {
                            _offset_ConfigurationName = Offset_ProjectPath + _etwEvent.UnicodeStringLength(Offset_ProjectPath);
                        }

                        return _offset_ConfigurationName;
                    }
                }

                private int Offset_SubscriptionType
                {
                    get
                    {
                        if (_offset_SubscriptionType == -1)
                        {
                            _offset_SubscriptionType = Offset_ConfigurationName + _etwEvent.UnicodeStringLength(Offset_ConfigurationName);
                        }

                        return _offset_SubscriptionType;
                    }
                }

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectPath..]);

                /// <summary>
                /// Retrieves the ConfigurationName field.
                /// </summary>
                public string ConfigurationName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ConfigurationName..]);

                /// <summary>
                /// Retrieves the SubscriptionType field.
                /// </summary>
                public string SubscriptionType => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_SubscriptionType..]);

                /// <summary>
                /// Creates a new UpdateProjectRuleSnapshotStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public UpdateProjectRuleSnapshotStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProjectPath = -1;
                    _offset_ConfigurationName = -1;
                    _offset_SubscriptionType = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a UpdateProjectRuleSnapshotStop event.
        /// </summary>
        public readonly ref struct UpdateProjectRuleSnapshotStopEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "UpdateProjectRuleSnapshotStop";

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
                Opcode = EtwEventOpcode.End,
                Task = (ushort)Tasks.UpdateProjectRuleSnapshot,
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
            public UpdateProjectRuleSnapshotStopData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new UpdateProjectRuleSnapshotStopEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public UpdateProjectRuleSnapshotStopEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a UpdateProjectRuleSnapshotStop event.
            /// </summary>
            public ref struct UpdateProjectRuleSnapshotStopData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProjectPath;
                private int _offset_ConfigurationName;
                private int _offset_SubscriptionType;

                private int Offset_ProjectPath
                {
                    get
                    {
                        if (_offset_ProjectPath == -1)
                        {
                            _offset_ProjectPath = 0;
                        }

                        return _offset_ProjectPath;
                    }
                }

                private int Offset_ConfigurationName
                {
                    get
                    {
                        if (_offset_ConfigurationName == -1)
                        {
                            _offset_ConfigurationName = Offset_ProjectPath + _etwEvent.UnicodeStringLength(Offset_ProjectPath);
                        }

                        return _offset_ConfigurationName;
                    }
                }

                private int Offset_SubscriptionType
                {
                    get
                    {
                        if (_offset_SubscriptionType == -1)
                        {
                            _offset_SubscriptionType = Offset_ConfigurationName + _etwEvent.UnicodeStringLength(Offset_ConfigurationName);
                        }

                        return _offset_SubscriptionType;
                    }
                }

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectPath..]);

                /// <summary>
                /// Retrieves the ConfigurationName field.
                /// </summary>
                public string ConfigurationName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ConfigurationName..]);

                /// <summary>
                /// Retrieves the SubscriptionType field.
                /// </summary>
                public string SubscriptionType => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_SubscriptionType..]);

                /// <summary>
                /// Creates a new UpdateProjectRuleSnapshotStopData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public UpdateProjectRuleSnapshotStopData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProjectPath = -1;
                    _offset_ConfigurationName = -1;
                    _offset_SubscriptionType = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ProjectConfigurationActivated event.
        /// </summary>
        public readonly ref struct ProjectConfigurationActivatedEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ProjectConfigurationActivated";

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
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.ProjectConfigurationActivated,
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
            public ProjectConfigurationActivatedData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ProjectConfigurationActivatedEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ProjectConfigurationActivatedEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ProjectConfigurationActivated event.
            /// </summary>
            public ref struct ProjectConfigurationActivatedData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProjectPath;
                private int _offset_ConfigurationName;

                private int Offset_ProjectPath
                {
                    get
                    {
                        if (_offset_ProjectPath == -1)
                        {
                            _offset_ProjectPath = 0;
                        }

                        return _offset_ProjectPath;
                    }
                }

                private int Offset_ConfigurationName
                {
                    get
                    {
                        if (_offset_ConfigurationName == -1)
                        {
                            _offset_ConfigurationName = Offset_ProjectPath + _etwEvent.UnicodeStringLength(Offset_ProjectPath);
                        }

                        return _offset_ConfigurationName;
                    }
                }

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectPath..]);

                /// <summary>
                /// Retrieves the ConfigurationName field.
                /// </summary>
                public string ConfigurationName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ConfigurationName..]);

                /// <summary>
                /// Creates a new ProjectConfigurationActivatedData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ProjectConfigurationActivatedData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProjectPath = -1;
                    _offset_ConfigurationName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ProjectConfigurationDeactivated event.
        /// </summary>
        public readonly ref struct ProjectConfigurationDeactivatedEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ProjectConfigurationDeactivated";

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
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.ProjectConfigurationDeactivated,
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
            public ProjectConfigurationDeactivatedData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ProjectConfigurationDeactivatedEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ProjectConfigurationDeactivatedEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ProjectConfigurationDeactivated event.
            /// </summary>
            public ref struct ProjectConfigurationDeactivatedData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProjectPath;
                private int _offset_ConfigurationName;

                private int Offset_ProjectPath
                {
                    get
                    {
                        if (_offset_ProjectPath == -1)
                        {
                            _offset_ProjectPath = 0;
                        }

                        return _offset_ProjectPath;
                    }
                }

                private int Offset_ConfigurationName
                {
                    get
                    {
                        if (_offset_ConfigurationName == -1)
                        {
                            _offset_ConfigurationName = Offset_ProjectPath + _etwEvent.UnicodeStringLength(Offset_ProjectPath);
                        }

                        return _offset_ConfigurationName;
                    }
                }

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectPath..]);

                /// <summary>
                /// Retrieves the ConfigurationName field.
                /// </summary>
                public string ConfigurationName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ConfigurationName..]);

                /// <summary>
                /// Creates a new ProjectConfigurationDeactivatedData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ProjectConfigurationDeactivatedData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProjectPath = -1;
                    _offset_ConfigurationName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ProjectTreeProviderInitializationStart event.
        /// </summary>
        public readonly ref struct ProjectTreeProviderInitializationStartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ProjectTreeProviderInitializationStart";

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
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Start,
                Task = (ushort)Tasks.ProjectTreeProviderInitialization,
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
            public ProjectTreeProviderInitializationStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ProjectTreeProviderInitializationStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ProjectTreeProviderInitializationStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ProjectTreeProviderInitializationStart event.
            /// </summary>
            public ref struct ProjectTreeProviderInitializationStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProjectPath;
                private int _offset_ProviderName;

                private int Offset_ProjectPath
                {
                    get
                    {
                        if (_offset_ProjectPath == -1)
                        {
                            _offset_ProjectPath = 0;
                        }

                        return _offset_ProjectPath;
                    }
                }

                private int Offset_ProviderName
                {
                    get
                    {
                        if (_offset_ProviderName == -1)
                        {
                            _offset_ProviderName = Offset_ProjectPath + _etwEvent.UnicodeStringLength(Offset_ProjectPath);
                        }

                        return _offset_ProviderName;
                    }
                }

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectPath..]);

                /// <summary>
                /// Retrieves the ProviderName field.
                /// </summary>
                public string ProviderName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProviderName..]);

                /// <summary>
                /// Creates a new ProjectTreeProviderInitializationStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ProjectTreeProviderInitializationStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProjectPath = -1;
                    _offset_ProviderName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ProjectTreeProviderInitializationStop event.
        /// </summary>
        public readonly ref struct ProjectTreeProviderInitializationStopEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ProjectTreeProviderInitializationStop";

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
                Opcode = EtwEventOpcode.End,
                Task = (ushort)Tasks.ProjectTreeProviderInitialization,
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
            public ProjectTreeProviderInitializationStopData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ProjectTreeProviderInitializationStopEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ProjectTreeProviderInitializationStopEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ProjectTreeProviderInitializationStop event.
            /// </summary>
            public ref struct ProjectTreeProviderInitializationStopData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProjectPath;
                private int _offset_ProviderName;

                private int Offset_ProjectPath
                {
                    get
                    {
                        if (_offset_ProjectPath == -1)
                        {
                            _offset_ProjectPath = 0;
                        }

                        return _offset_ProjectPath;
                    }
                }

                private int Offset_ProviderName
                {
                    get
                    {
                        if (_offset_ProviderName == -1)
                        {
                            _offset_ProviderName = Offset_ProjectPath + _etwEvent.UnicodeStringLength(Offset_ProjectPath);
                        }

                        return _offset_ProviderName;
                    }
                }

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectPath..]);

                /// <summary>
                /// Retrieves the ProviderName field.
                /// </summary>
                public string ProviderName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProviderName..]);

                /// <summary>
                /// Creates a new ProjectTreeProviderInitializationStopData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ProjectTreeProviderInitializationStopData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProjectPath = -1;
                    _offset_ProviderName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a LoadSchemaFileStart event.
        /// </summary>
        public readonly ref struct LoadSchemaFileStartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "LoadSchemaFileStart";

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
                Opcode = EtwEventOpcode.Start,
                Task = (ushort)Tasks.LoadSchemaFile,
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
            public LoadSchemaFileStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new LoadSchemaFileStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public LoadSchemaFileStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a LoadSchemaFileStart event.
            /// </summary>
            public ref struct LoadSchemaFileStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_FilePath;

                private int Offset_FilePath
                {
                    get
                    {
                        if (_offset_FilePath == -1)
                        {
                            _offset_FilePath = 0;
                        }

                        return _offset_FilePath;
                    }
                }

                /// <summary>
                /// Retrieves the FilePath field.
                /// </summary>
                public string FilePath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FilePath..]);

                /// <summary>
                /// Creates a new LoadSchemaFileStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public LoadSchemaFileStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_FilePath = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a CreatePropertyCatalogsStart event.
        /// </summary>
        public readonly ref struct CreatePropertyCatalogsStartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "CreatePropertyCatalogsStart";

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
                Opcode = EtwEventOpcode.Start,
                Task = (ushort)Tasks.CreatePropertyCatalogs,
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
            public CreatePropertyCatalogsStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new CreatePropertyCatalogsStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public CreatePropertyCatalogsStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a CreatePropertyCatalogsStart event.
            /// </summary>
            public ref struct CreatePropertyCatalogsStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProjectPath;
                private int _offset_SnapshotId;

                private int Offset_ProjectPath
                {
                    get
                    {
                        if (_offset_ProjectPath == -1)
                        {
                            _offset_ProjectPath = 0;
                        }

                        return _offset_ProjectPath;
                    }
                }

                private int Offset_SnapshotId
                {
                    get
                    {
                        if (_offset_SnapshotId == -1)
                        {
                            _offset_SnapshotId = Offset_ProjectPath + _etwEvent.UnicodeStringLength(Offset_ProjectPath);
                        }

                        return _offset_SnapshotId;
                    }
                }

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectPath..]);

                /// <summary>
                /// Retrieves the SnapshotId field.
                /// </summary>
                public int SnapshotId => BitConverter.ToInt32(_etwEvent.Data[Offset_SnapshotId..]);

                /// <summary>
                /// Creates a new CreatePropertyCatalogsStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public CreatePropertyCatalogsStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProjectPath = -1;
                    _offset_SnapshotId = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a CreatePropertyCatalogsStop event.
        /// </summary>
        public readonly ref struct CreatePropertyCatalogsStopEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "CreatePropertyCatalogsStop";

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
                Opcode = EtwEventOpcode.End,
                Task = (ushort)Tasks.CreatePropertyCatalogs,
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
            public CreatePropertyCatalogsStopData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new CreatePropertyCatalogsStopEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public CreatePropertyCatalogsStopEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a CreatePropertyCatalogsStop event.
            /// </summary>
            public ref struct CreatePropertyCatalogsStopData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProjectPath;
                private int _offset_SnapshotId;

                private int Offset_ProjectPath
                {
                    get
                    {
                        if (_offset_ProjectPath == -1)
                        {
                            _offset_ProjectPath = 0;
                        }

                        return _offset_ProjectPath;
                    }
                }

                private int Offset_SnapshotId
                {
                    get
                    {
                        if (_offset_SnapshotId == -1)
                        {
                            _offset_SnapshotId = Offset_ProjectPath + _etwEvent.UnicodeStringLength(Offset_ProjectPath);
                        }

                        return _offset_SnapshotId;
                    }
                }

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectPath..]);

                /// <summary>
                /// Retrieves the SnapshotId field.
                /// </summary>
                public int SnapshotId => BitConverter.ToInt32(_etwEvent.Data[Offset_SnapshotId..]);

                /// <summary>
                /// Creates a new CreatePropertyCatalogsStopData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public CreatePropertyCatalogsStopData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProjectPath = -1;
                    _offset_SnapshotId = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a HintSubmissionStart event.
        /// </summary>
        public readonly ref struct HintSubmissionStartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "HintSubmissionStart";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 27,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Verbose,
                Opcode = EtwEventOpcode.Start,
                Task = (ushort)Tasks.HintSubmission,
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
            public HintSubmissionStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new HintSubmissionStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public HintSubmissionStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a HintSubmissionStart event.
            /// </summary>
            public ref struct HintSubmissionStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Kind;
                private int _offset_AccumulatedCount;

                private int Offset_Kind
                {
                    get
                    {
                        if (_offset_Kind == -1)
                        {
                            _offset_Kind = 0;
                        }

                        return _offset_Kind;
                    }
                }

                private int Offset_AccumulatedCount
                {
                    get
                    {
                        if (_offset_AccumulatedCount == -1)
                        {
                            _offset_AccumulatedCount = Offset_Kind + _etwEvent.UnicodeStringLength(Offset_Kind);
                        }

                        return _offset_AccumulatedCount;
                    }
                }

                /// <summary>
                /// Retrieves the Kind field.
                /// </summary>
                public string Kind => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Kind..]);

                /// <summary>
                /// Retrieves the AccumulatedCount field.
                /// </summary>
                public int AccumulatedCount => BitConverter.ToInt32(_etwEvent.Data[Offset_AccumulatedCount..]);

                /// <summary>
                /// Creates a new HintSubmissionStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public HintSubmissionStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Kind = -1;
                    _offset_AccumulatedCount = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a HintSubmissionStop event.
        /// </summary>
        public readonly ref struct HintSubmissionStopEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "HintSubmissionStop";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 28,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Verbose,
                Opcode = EtwEventOpcode.End,
                Task = (ushort)Tasks.HintSubmission,
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
            /// Creates a new HintSubmissionStopEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public HintSubmissionStopEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a HintProcessStart event.
        /// </summary>
        public readonly ref struct HintProcessStartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "HintProcessStart";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 29,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Start,
                Task = (ushort)Tasks.HintProcess,
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
            public HintProcessStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new HintProcessStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public HintProcessStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a HintProcessStart event.
            /// </summary>
            public ref struct HintProcessStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_TotalEventCount;

                private int Offset_TotalEventCount
                {
                    get
                    {
                        if (_offset_TotalEventCount == -1)
                        {
                            _offset_TotalEventCount = 0;
                        }

                        return _offset_TotalEventCount;
                    }
                }

                /// <summary>
                /// Retrieves the TotalEventCount field.
                /// </summary>
                public int TotalEventCount => BitConverter.ToInt32(_etwEvent.Data[Offset_TotalEventCount..]);

                /// <summary>
                /// Creates a new HintProcessStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public HintProcessStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_TotalEventCount = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a HintProcessStop event.
        /// </summary>
        public readonly ref struct HintProcessStopEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "HintProcessStop";

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
                Opcode = EtwEventOpcode.End,
                Task = (ushort)Tasks.HintProcess,
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
            /// Creates a new HintProcessStopEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public HintProcessStopEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a AddSourceItemsStart event.
        /// </summary>
        public readonly ref struct AddSourceItemsStartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "AddSourceItemsStart";

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
                Opcode = EtwEventOpcode.Start,
                Task = (ushort)Tasks.AddSourceItems,
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
            public AddSourceItemsStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new AddSourceItemsStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public AddSourceItemsStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a AddSourceItemsStart event.
            /// </summary>
            public ref struct AddSourceItemsStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProjectPath;
                private int _offset_ItemCount;

                private int Offset_ProjectPath
                {
                    get
                    {
                        if (_offset_ProjectPath == -1)
                        {
                            _offset_ProjectPath = 0;
                        }

                        return _offset_ProjectPath;
                    }
                }

                private int Offset_ItemCount
                {
                    get
                    {
                        if (_offset_ItemCount == -1)
                        {
                            _offset_ItemCount = Offset_ProjectPath + _etwEvent.UnicodeStringLength(Offset_ProjectPath);
                        }

                        return _offset_ItemCount;
                    }
                }

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectPath..]);

                /// <summary>
                /// Retrieves the ItemCount field.
                /// </summary>
                public int ItemCount => BitConverter.ToInt32(_etwEvent.Data[Offset_ItemCount..]);

                /// <summary>
                /// Creates a new AddSourceItemsStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public AddSourceItemsStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProjectPath = -1;
                    _offset_ItemCount = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a AddSourceItemsStop event.
        /// </summary>
        public readonly ref struct AddSourceItemsStopEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "AddSourceItemsStop";

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
                Opcode = EtwEventOpcode.End,
                Task = (ushort)Tasks.AddSourceItems,
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
            /// Creates a new AddSourceItemsStopEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public AddSourceItemsStopEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a RemoveSourceItemsStart event.
        /// </summary>
        public readonly ref struct RemoveSourceItemsStartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "RemoveSourceItemsStart";

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
                Opcode = EtwEventOpcode.Start,
                Task = (ushort)Tasks.RemoveSourceItems,
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
            public RemoveSourceItemsStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new RemoveSourceItemsStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public RemoveSourceItemsStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a RemoveSourceItemsStart event.
            /// </summary>
            public ref struct RemoveSourceItemsStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProjectPath;
                private int _offset_ItemCount;

                private int Offset_ProjectPath
                {
                    get
                    {
                        if (_offset_ProjectPath == -1)
                        {
                            _offset_ProjectPath = 0;
                        }

                        return _offset_ProjectPath;
                    }
                }

                private int Offset_ItemCount
                {
                    get
                    {
                        if (_offset_ItemCount == -1)
                        {
                            _offset_ItemCount = Offset_ProjectPath + _etwEvent.UnicodeStringLength(Offset_ProjectPath);
                        }

                        return _offset_ItemCount;
                    }
                }

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectPath..]);

                /// <summary>
                /// Retrieves the ItemCount field.
                /// </summary>
                public int ItemCount => BitConverter.ToInt32(_etwEvent.Data[Offset_ItemCount..]);

                /// <summary>
                /// Creates a new RemoveSourceItemsStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public RemoveSourceItemsStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProjectPath = -1;
                    _offset_ItemCount = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a RemoveSourceItemsStop event.
        /// </summary>
        public readonly ref struct RemoveSourceItemsStopEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "RemoveSourceItemsStop";

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
                Opcode = EtwEventOpcode.End,
                Task = (ushort)Tasks.RemoveSourceItems,
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
            /// Creates a new RemoveSourceItemsStopEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public RemoveSourceItemsStopEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a LoadConfiguredProjectStart event.
        /// </summary>
        public readonly ref struct LoadConfiguredProjectStartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "LoadConfiguredProjectStart";

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
                Opcode = EtwEventOpcode.Start,
                Task = (ushort)Tasks.LoadConfiguredProject,
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
            public LoadConfiguredProjectStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new LoadConfiguredProjectStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public LoadConfiguredProjectStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a LoadConfiguredProjectStart event.
            /// </summary>
            public ref struct LoadConfiguredProjectStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProjectPath;
                private int _offset_Configuration;

                private int Offset_ProjectPath
                {
                    get
                    {
                        if (_offset_ProjectPath == -1)
                        {
                            _offset_ProjectPath = 0;
                        }

                        return _offset_ProjectPath;
                    }
                }

                private int Offset_Configuration
                {
                    get
                    {
                        if (_offset_Configuration == -1)
                        {
                            _offset_Configuration = Offset_ProjectPath + _etwEvent.UnicodeStringLength(Offset_ProjectPath);
                        }

                        return _offset_Configuration;
                    }
                }

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectPath..]);

                /// <summary>
                /// Retrieves the Configuration field.
                /// </summary>
                public string Configuration => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Configuration..]);

                /// <summary>
                /// Creates a new LoadConfiguredProjectStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public LoadConfiguredProjectStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProjectPath = -1;
                    _offset_Configuration = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a LoadConfiguredProjectStop event.
        /// </summary>
        public readonly ref struct LoadConfiguredProjectStopEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "LoadConfiguredProjectStop";

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
                Opcode = EtwEventOpcode.End,
                Task = (ushort)Tasks.LoadConfiguredProject,
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
            public LoadConfiguredProjectStopData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new LoadConfiguredProjectStopEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public LoadConfiguredProjectStopEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a LoadConfiguredProjectStop event.
            /// </summary>
            public ref struct LoadConfiguredProjectStopData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProjectPath;
                private int _offset_Configuration;
                private int _offset_Capabilities;

                private int Offset_ProjectPath
                {
                    get
                    {
                        if (_offset_ProjectPath == -1)
                        {
                            _offset_ProjectPath = 0;
                        }

                        return _offset_ProjectPath;
                    }
                }

                private int Offset_Configuration
                {
                    get
                    {
                        if (_offset_Configuration == -1)
                        {
                            _offset_Configuration = Offset_ProjectPath + _etwEvent.UnicodeStringLength(Offset_ProjectPath);
                        }

                        return _offset_Configuration;
                    }
                }

                private int Offset_Capabilities
                {
                    get
                    {
                        if (_offset_Capabilities == -1)
                        {
                            _offset_Capabilities = Offset_Configuration + _etwEvent.UnicodeStringLength(Offset_Configuration);
                        }

                        return _offset_Capabilities;
                    }
                }

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectPath..]);

                /// <summary>
                /// Retrieves the Configuration field.
                /// </summary>
                public string Configuration => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Configuration..]);

                /// <summary>
                /// Retrieves the Capabilities field.
                /// </summary>
                public string Capabilities => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Capabilities..]);

                /// <summary>
                /// Creates a new LoadConfiguredProjectStopData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public LoadConfiguredProjectStopData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProjectPath = -1;
                    _offset_Configuration = -1;
                    _offset_Capabilities = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a PhysicalTreeLoadingStart event.
        /// </summary>
        public readonly ref struct PhysicalTreeLoadingStartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "PhysicalTreeLoadingStart";

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
                Opcode = EtwEventOpcode.Start,
                Task = (ushort)Tasks.PhysicalTreeLoading,
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
            public PhysicalTreeLoadingStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new PhysicalTreeLoadingStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public PhysicalTreeLoadingStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a PhysicalTreeLoadingStart event.
            /// </summary>
            public ref struct PhysicalTreeLoadingStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProjectPath;

                private int Offset_ProjectPath
                {
                    get
                    {
                        if (_offset_ProjectPath == -1)
                        {
                            _offset_ProjectPath = 0;
                        }

                        return _offset_ProjectPath;
                    }
                }

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectPath..]);

                /// <summary>
                /// Creates a new PhysicalTreeLoadingStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public PhysicalTreeLoadingStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProjectPath = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DirectoryTreeLoadingStart event.
        /// </summary>
        public readonly ref struct DirectoryTreeLoadingStartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DirectoryTreeLoadingStart";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 45,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Start,
                Task = (ushort)Tasks.DirectoryTreeLoading,
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
            public DirectoryTreeLoadingStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DirectoryTreeLoadingStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DirectoryTreeLoadingStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a DirectoryTreeLoadingStart event.
            /// </summary>
            public ref struct DirectoryTreeLoadingStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProjectPath;

                private int Offset_ProjectPath
                {
                    get
                    {
                        if (_offset_ProjectPath == -1)
                        {
                            _offset_ProjectPath = 0;
                        }

                        return _offset_ProjectPath;
                    }
                }

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectPath..]);

                /// <summary>
                /// Creates a new DirectoryTreeLoadingStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DirectoryTreeLoadingStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProjectPath = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DirectoryTreeLoadingStop event.
        /// </summary>
        public readonly ref struct DirectoryTreeLoadingStopEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DirectoryTreeLoadingStop";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 46,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.End,
                Task = (ushort)Tasks.DirectoryTreeLoading,
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
            public DirectoryTreeLoadingStopData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DirectoryTreeLoadingStopEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DirectoryTreeLoadingStopEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a DirectoryTreeLoadingStop event.
            /// </summary>
            public ref struct DirectoryTreeLoadingStopData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProjectPath;

                private int Offset_ProjectPath
                {
                    get
                    {
                        if (_offset_ProjectPath == -1)
                        {
                            _offset_ProjectPath = 0;
                        }

                        return _offset_ProjectPath;
                    }
                }

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectPath..]);

                /// <summary>
                /// Creates a new DirectoryTreeLoadingStopData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DirectoryTreeLoadingStopData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProjectPath = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a WaitAutoLoadMethodsToFinishStart event.
        /// </summary>
        public readonly ref struct WaitAutoLoadMethodsToFinishStartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "WaitAutoLoadMethodsToFinishStart";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 47,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Start,
                Task = (ushort)Tasks.WaitAutoLoadMethodsToFinish,
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
            public WaitAutoLoadMethodsToFinishStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new WaitAutoLoadMethodsToFinishStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public WaitAutoLoadMethodsToFinishStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a WaitAutoLoadMethodsToFinishStart event.
            /// </summary>
            public ref struct WaitAutoLoadMethodsToFinishStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProjectPath;

                private int Offset_ProjectPath
                {
                    get
                    {
                        if (_offset_ProjectPath == -1)
                        {
                            _offset_ProjectPath = 0;
                        }

                        return _offset_ProjectPath;
                    }
                }

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectPath..]);

                /// <summary>
                /// Creates a new WaitAutoLoadMethodsToFinishStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public WaitAutoLoadMethodsToFinishStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProjectPath = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a WaitAutoLoadMethodsToFinishStop event.
        /// </summary>
        public readonly ref struct WaitAutoLoadMethodsToFinishStopEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "WaitAutoLoadMethodsToFinishStop";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 48,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.End,
                Task = (ushort)Tasks.WaitAutoLoadMethodsToFinish,
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
            public WaitAutoLoadMethodsToFinishStopData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new WaitAutoLoadMethodsToFinishStopEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public WaitAutoLoadMethodsToFinishStopEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a WaitAutoLoadMethodsToFinishStop event.
            /// </summary>
            public ref struct WaitAutoLoadMethodsToFinishStopData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProjectPath;

                private int Offset_ProjectPath
                {
                    get
                    {
                        if (_offset_ProjectPath == -1)
                        {
                            _offset_ProjectPath = 0;
                        }

                        return _offset_ProjectPath;
                    }
                }

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectPath..]);

                /// <summary>
                /// Creates a new WaitAutoLoadMethodsToFinishStopData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public WaitAutoLoadMethodsToFinishStopData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProjectPath = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a SetActiveTreeProviderStart event.
        /// </summary>
        public readonly ref struct SetActiveTreeProviderStartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SetActiveTreeProviderStart";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 49,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Start,
                Task = (ushort)Tasks.SetActiveTreeProvider,
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
            public SetActiveTreeProviderStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new SetActiveTreeProviderStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SetActiveTreeProviderStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a SetActiveTreeProviderStart event.
            /// </summary>
            public ref struct SetActiveTreeProviderStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProjectPath;

                private int Offset_ProjectPath
                {
                    get
                    {
                        if (_offset_ProjectPath == -1)
                        {
                            _offset_ProjectPath = 0;
                        }

                        return _offset_ProjectPath;
                    }
                }

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectPath..]);

                /// <summary>
                /// Creates a new SetActiveTreeProviderStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public SetActiveTreeProviderStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProjectPath = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a SetActiveTreeProviderStop event.
        /// </summary>
        public readonly ref struct SetActiveTreeProviderStopEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SetActiveTreeProviderStop";

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
                Opcode = EtwEventOpcode.End,
                Task = (ushort)Tasks.SetActiveTreeProvider,
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
            public SetActiveTreeProviderStopData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new SetActiveTreeProviderStopEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SetActiveTreeProviderStopEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a SetActiveTreeProviderStop event.
            /// </summary>
            public ref struct SetActiveTreeProviderStopData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProjectPath;

                private int Offset_ProjectPath
                {
                    get
                    {
                        if (_offset_ProjectPath == -1)
                        {
                            _offset_ProjectPath = 0;
                        }

                        return _offset_ProjectPath;
                    }
                }

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectPath..]);

                /// <summary>
                /// Creates a new SetActiveTreeProviderStopData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public SetActiveTreeProviderStopData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProjectPath = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a InitializeActiveTreeProviderStart event.
        /// </summary>
        public readonly ref struct InitializeActiveTreeProviderStartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "InitializeActiveTreeProviderStart";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 51,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Start,
                Task = (ushort)Tasks.InitializeActiveTreeProvider,
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
            public InitializeActiveTreeProviderStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new InitializeActiveTreeProviderStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public InitializeActiveTreeProviderStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a InitializeActiveTreeProviderStart event.
            /// </summary>
            public ref struct InitializeActiveTreeProviderStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProjectPath;

                private int Offset_ProjectPath
                {
                    get
                    {
                        if (_offset_ProjectPath == -1)
                        {
                            _offset_ProjectPath = 0;
                        }

                        return _offset_ProjectPath;
                    }
                }

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectPath..]);

                /// <summary>
                /// Creates a new InitializeActiveTreeProviderStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public InitializeActiveTreeProviderStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProjectPath = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a InitializeActiveTreeProviderStop event.
        /// </summary>
        public readonly ref struct InitializeActiveTreeProviderStopEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "InitializeActiveTreeProviderStop";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 52,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.End,
                Task = (ushort)Tasks.InitializeActiveTreeProvider,
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
            public InitializeActiveTreeProviderStopData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new InitializeActiveTreeProviderStopEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public InitializeActiveTreeProviderStopEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a InitializeActiveTreeProviderStop event.
            /// </summary>
            public ref struct InitializeActiveTreeProviderStopData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProjectPath;

                private int Offset_ProjectPath
                {
                    get
                    {
                        if (_offset_ProjectPath == -1)
                        {
                            _offset_ProjectPath = 0;
                        }

                        return _offset_ProjectPath;
                    }
                }

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectPath..]);

                /// <summary>
                /// Creates a new InitializeActiveTreeProviderStopData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public InitializeActiveTreeProviderStopData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProjectPath = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a CapabilitiesTriggersProjectReload event.
        /// </summary>
        public readonly ref struct CapabilitiesTriggersProjectReloadEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "CapabilitiesTriggersProjectReload";

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
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.CapabilitiesTriggersProjectReload,
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
            public CapabilitiesTriggersProjectReloadData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new CapabilitiesTriggersProjectReloadEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public CapabilitiesTriggersProjectReloadEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a CapabilitiesTriggersProjectReload event.
            /// </summary>
            public ref struct CapabilitiesTriggersProjectReloadData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProjectPath;
                private int _offset_Scope;

                private int Offset_ProjectPath
                {
                    get
                    {
                        if (_offset_ProjectPath == -1)
                        {
                            _offset_ProjectPath = 0;
                        }

                        return _offset_ProjectPath;
                    }
                }

                private int Offset_Scope
                {
                    get
                    {
                        if (_offset_Scope == -1)
                        {
                            _offset_Scope = Offset_ProjectPath + _etwEvent.UnicodeStringLength(Offset_ProjectPath);
                        }

                        return _offset_Scope;
                    }
                }

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectPath..]);

                /// <summary>
                /// Retrieves the Scope field.
                /// </summary>
                public string Scope => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Scope..]);

                /// <summary>
                /// Creates a new CapabilitiesTriggersProjectReloadData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public CapabilitiesTriggersProjectReloadData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProjectPath = -1;
                    _offset_Scope = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a UnloadDynamicLoadComponentsStart event.
        /// </summary>
        public readonly ref struct UnloadDynamicLoadComponentsStartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "UnloadDynamicLoadComponentsStart";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 64,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Start,
                Task = (ushort)Tasks.UnloadDynamicLoadComponents,
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
            public UnloadDynamicLoadComponentsStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new UnloadDynamicLoadComponentsStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public UnloadDynamicLoadComponentsStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a UnloadDynamicLoadComponentsStart event.
            /// </summary>
            public ref struct UnloadDynamicLoadComponentsStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProjectPath;
                private int _offset_Scope;
                private int _offset_ValueVersionNumber;

                private int Offset_ProjectPath
                {
                    get
                    {
                        if (_offset_ProjectPath == -1)
                        {
                            _offset_ProjectPath = 0;
                        }

                        return _offset_ProjectPath;
                    }
                }

                private int Offset_Scope
                {
                    get
                    {
                        if (_offset_Scope == -1)
                        {
                            _offset_Scope = Offset_ProjectPath + _etwEvent.UnicodeStringLength(Offset_ProjectPath);
                        }

                        return _offset_Scope;
                    }
                }

                private int Offset_ValueVersionNumber
                {
                    get
                    {
                        if (_offset_ValueVersionNumber == -1)
                        {
                            _offset_ValueVersionNumber = Offset_Scope + _etwEvent.UnicodeStringLength(Offset_Scope);
                        }

                        return _offset_ValueVersionNumber;
                    }
                }

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectPath..]);

                /// <summary>
                /// Retrieves the Scope field.
                /// </summary>
                public string Scope => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Scope..]);

                /// <summary>
                /// Retrieves the ValueVersionNumber field.
                /// </summary>
                public long ValueVersionNumber => BitConverter.ToInt64(_etwEvent.Data[Offset_ValueVersionNumber..]);

                /// <summary>
                /// Creates a new UnloadDynamicLoadComponentsStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public UnloadDynamicLoadComponentsStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProjectPath = -1;
                    _offset_Scope = -1;
                    _offset_ValueVersionNumber = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a UnloadDynamicLoadComponentsStop event.
        /// </summary>
        public readonly ref struct UnloadDynamicLoadComponentsStopEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "UnloadDynamicLoadComponentsStop";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 65,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.End,
                Task = (ushort)Tasks.UnloadDynamicLoadComponents,
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
            public UnloadDynamicLoadComponentsStopData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new UnloadDynamicLoadComponentsStopEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public UnloadDynamicLoadComponentsStopEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a UnloadDynamicLoadComponentsStop event.
            /// </summary>
            public ref struct UnloadDynamicLoadComponentsStopData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProjectPath;
                private int _offset_Scope;

                private int Offset_ProjectPath
                {
                    get
                    {
                        if (_offset_ProjectPath == -1)
                        {
                            _offset_ProjectPath = 0;
                        }

                        return _offset_ProjectPath;
                    }
                }

                private int Offset_Scope
                {
                    get
                    {
                        if (_offset_Scope == -1)
                        {
                            _offset_Scope = Offset_ProjectPath + _etwEvent.UnicodeStringLength(Offset_ProjectPath);
                        }

                        return _offset_Scope;
                    }
                }

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectPath..]);

                /// <summary>
                /// Retrieves the Scope field.
                /// </summary>
                public string Scope => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Scope..]);

                /// <summary>
                /// Creates a new UnloadDynamicLoadComponentsStopData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public UnloadDynamicLoadComponentsStopData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProjectPath = -1;
                    _offset_Scope = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ProjectGlobbingWatchingServiceInitialized event.
        /// </summary>
        public readonly ref struct ProjectGlobbingWatchingServiceInitializedEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ProjectGlobbingWatchingServiceInitialized";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 66,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.ProjectGlobbingWatchingServiceInitialized,
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
            public ProjectGlobbingWatchingServiceInitializedData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ProjectGlobbingWatchingServiceInitializedEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ProjectGlobbingWatchingServiceInitializedEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ProjectGlobbingWatchingServiceInitialized event.
            /// </summary>
            public ref struct ProjectGlobbingWatchingServiceInitializedData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProjectPath;
                private int _offset_ConfigurationName;

                private int Offset_ProjectPath
                {
                    get
                    {
                        if (_offset_ProjectPath == -1)
                        {
                            _offset_ProjectPath = 0;
                        }

                        return _offset_ProjectPath;
                    }
                }

                private int Offset_ConfigurationName
                {
                    get
                    {
                        if (_offset_ConfigurationName == -1)
                        {
                            _offset_ConfigurationName = Offset_ProjectPath + _etwEvent.UnicodeStringLength(Offset_ProjectPath);
                        }

                        return _offset_ConfigurationName;
                    }
                }

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectPath..]);

                /// <summary>
                /// Retrieves the ConfigurationName field.
                /// </summary>
                public string ConfigurationName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ConfigurationName..]);

                /// <summary>
                /// Creates a new ProjectGlobbingWatchingServiceInitializedData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ProjectGlobbingWatchingServiceInitializedData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProjectPath = -1;
                    _offset_ConfigurationName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a GlobbingWatchingConsistentCheckStart event.
        /// </summary>
        public readonly ref struct GlobbingWatchingConsistentCheckStartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "GlobbingWatchingConsistentCheckStart";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 68,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Start,
                Task = (ushort)Tasks.GlobbingWatchingConsistentCheck,
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
            public GlobbingWatchingConsistentCheckStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new GlobbingWatchingConsistentCheckStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public GlobbingWatchingConsistentCheckStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a GlobbingWatchingConsistentCheckStart event.
            /// </summary>
            public ref struct GlobbingWatchingConsistentCheckStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProjectPath;
                private int _offset_ConfigurationName;

                private int Offset_ProjectPath
                {
                    get
                    {
                        if (_offset_ProjectPath == -1)
                        {
                            _offset_ProjectPath = 0;
                        }

                        return _offset_ProjectPath;
                    }
                }

                private int Offset_ConfigurationName
                {
                    get
                    {
                        if (_offset_ConfigurationName == -1)
                        {
                            _offset_ConfigurationName = Offset_ProjectPath + _etwEvent.UnicodeStringLength(Offset_ProjectPath);
                        }

                        return _offset_ConfigurationName;
                    }
                }

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectPath..]);

                /// <summary>
                /// Retrieves the ConfigurationName field.
                /// </summary>
                public string ConfigurationName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ConfigurationName..]);

                /// <summary>
                /// Creates a new GlobbingWatchingConsistentCheckStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public GlobbingWatchingConsistentCheckStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProjectPath = -1;
                    _offset_ConfigurationName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a GlobbingWatchingConsistentCheckStop event.
        /// </summary>
        public readonly ref struct GlobbingWatchingConsistentCheckStopEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "GlobbingWatchingConsistentCheckStop";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 69,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.End,
                Task = (ushort)Tasks.GlobbingWatchingConsistentCheck,
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
            public GlobbingWatchingConsistentCheckStopData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new GlobbingWatchingConsistentCheckStopEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public GlobbingWatchingConsistentCheckStopEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a GlobbingWatchingConsistentCheckStop event.
            /// </summary>
            public ref struct GlobbingWatchingConsistentCheckStopData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProjectPath;
                private int _offset_ConfigurationName;

                private int Offset_ProjectPath
                {
                    get
                    {
                        if (_offset_ProjectPath == -1)
                        {
                            _offset_ProjectPath = 0;
                        }

                        return _offset_ProjectPath;
                    }
                }

                private int Offset_ConfigurationName
                {
                    get
                    {
                        if (_offset_ConfigurationName == -1)
                        {
                            _offset_ConfigurationName = Offset_ProjectPath + _etwEvent.UnicodeStringLength(Offset_ProjectPath);
                        }

                        return _offset_ConfigurationName;
                    }
                }

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectPath..]);

                /// <summary>
                /// Retrieves the ConfigurationName field.
                /// </summary>
                public string ConfigurationName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ConfigurationName..]);

                /// <summary>
                /// Creates a new GlobbingWatchingConsistentCheckStopData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public GlobbingWatchingConsistentCheckStopData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProjectPath = -1;
                    _offset_ConfigurationName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a GlobbingWatchingTriggerReevaluationStart event.
        /// </summary>
        public readonly ref struct GlobbingWatchingTriggerReevaluationStartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "GlobbingWatchingTriggerReevaluationStart";

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
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Start,
                Task = (ushort)Tasks.GlobbingWatchingTriggerReevaluation,
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
            public GlobbingWatchingTriggerReevaluationStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new GlobbingWatchingTriggerReevaluationStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public GlobbingWatchingTriggerReevaluationStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a GlobbingWatchingTriggerReevaluationStart event.
            /// </summary>
            public ref struct GlobbingWatchingTriggerReevaluationStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProjectPath;
                private int _offset_ConfigurationName;

                private int Offset_ProjectPath
                {
                    get
                    {
                        if (_offset_ProjectPath == -1)
                        {
                            _offset_ProjectPath = 0;
                        }

                        return _offset_ProjectPath;
                    }
                }

                private int Offset_ConfigurationName
                {
                    get
                    {
                        if (_offset_ConfigurationName == -1)
                        {
                            _offset_ConfigurationName = Offset_ProjectPath + _etwEvent.UnicodeStringLength(Offset_ProjectPath);
                        }

                        return _offset_ConfigurationName;
                    }
                }

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectPath..]);

                /// <summary>
                /// Retrieves the ConfigurationName field.
                /// </summary>
                public string ConfigurationName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ConfigurationName..]);

                /// <summary>
                /// Creates a new GlobbingWatchingTriggerReevaluationStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public GlobbingWatchingTriggerReevaluationStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProjectPath = -1;
                    _offset_ConfigurationName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a GlobbingWatchingTriggerReevaluationStop event.
        /// </summary>
        public readonly ref struct GlobbingWatchingTriggerReevaluationStopEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "GlobbingWatchingTriggerReevaluationStop";

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
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.End,
                Task = (ushort)Tasks.GlobbingWatchingTriggerReevaluation,
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
            public GlobbingWatchingTriggerReevaluationStopData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new GlobbingWatchingTriggerReevaluationStopEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public GlobbingWatchingTriggerReevaluationStopEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a GlobbingWatchingTriggerReevaluationStop event.
            /// </summary>
            public ref struct GlobbingWatchingTriggerReevaluationStopData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProjectPath;
                private int _offset_ConfigurationName;

                private int Offset_ProjectPath
                {
                    get
                    {
                        if (_offset_ProjectPath == -1)
                        {
                            _offset_ProjectPath = 0;
                        }

                        return _offset_ProjectPath;
                    }
                }

                private int Offset_ConfigurationName
                {
                    get
                    {
                        if (_offset_ConfigurationName == -1)
                        {
                            _offset_ConfigurationName = Offset_ProjectPath + _etwEvent.UnicodeStringLength(Offset_ProjectPath);
                        }

                        return _offset_ConfigurationName;
                    }
                }

                /// <summary>
                /// Retrieves the ProjectPath field.
                /// </summary>
                public string ProjectPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProjectPath..]);

                /// <summary>
                /// Retrieves the ConfigurationName field.
                /// </summary>
                public string ConfigurationName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ConfigurationName..]);

                /// <summary>
                /// Creates a new GlobbingWatchingTriggerReevaluationStopData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public GlobbingWatchingTriggerReevaluationStopData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProjectPath = -1;
                    _offset_ConfigurationName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ProjectDirectoryTreeDisposed event.
        /// </summary>
        public readonly ref struct ProjectDirectoryTreeDisposedEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ProjectDirectoryTreeDisposed";

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
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.ProjectDirectoryTreeDisposed,
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
            public ProjectDirectoryTreeDisposedData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ProjectDirectoryTreeDisposedEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ProjectDirectoryTreeDisposedEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ProjectDirectoryTreeDisposed event.
            /// </summary>
            public ref struct ProjectDirectoryTreeDisposedData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_FolderPath;

                private int Offset_FolderPath
                {
                    get
                    {
                        if (_offset_FolderPath == -1)
                        {
                            _offset_FolderPath = 0;
                        }

                        return _offset_FolderPath;
                    }
                }

                /// <summary>
                /// Retrieves the FolderPath field.
                /// </summary>
                public string FolderPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FolderPath..]);

                /// <summary>
                /// Creates a new ProjectDirectoryTreeDisposedData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ProjectDirectoryTreeDisposedData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_FolderPath = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ProjectDirectoryTreeAddSubscription event.
        /// </summary>
        public readonly ref struct ProjectDirectoryTreeAddSubscriptionEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ProjectDirectoryTreeAddSubscription";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 73,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.ProjectDirectoryTreeAddSubscription,
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
            public ProjectDirectoryTreeAddSubscriptionData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ProjectDirectoryTreeAddSubscriptionEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ProjectDirectoryTreeAddSubscriptionEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ProjectDirectoryTreeAddSubscription event.
            /// </summary>
            public ref struct ProjectDirectoryTreeAddSubscriptionData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_FolderPath;

                private int Offset_FolderPath
                {
                    get
                    {
                        if (_offset_FolderPath == -1)
                        {
                            _offset_FolderPath = 0;
                        }

                        return _offset_FolderPath;
                    }
                }

                /// <summary>
                /// Retrieves the FolderPath field.
                /// </summary>
                public string FolderPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FolderPath..]);

                /// <summary>
                /// Creates a new ProjectDirectoryTreeAddSubscriptionData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ProjectDirectoryTreeAddSubscriptionData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_FolderPath = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ProjectDirectoryTreeReleaseSubscription event.
        /// </summary>
        public readonly ref struct ProjectDirectoryTreeReleaseSubscriptionEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ProjectDirectoryTreeReleaseSubscription";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 74,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.ProjectDirectoryTreeReleaseSubscription,
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
            public ProjectDirectoryTreeReleaseSubscriptionData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ProjectDirectoryTreeReleaseSubscriptionEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ProjectDirectoryTreeReleaseSubscriptionEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ProjectDirectoryTreeReleaseSubscription event.
            /// </summary>
            public ref struct ProjectDirectoryTreeReleaseSubscriptionData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_FolderPath;

                private int Offset_FolderPath
                {
                    get
                    {
                        if (_offset_FolderPath == -1)
                        {
                            _offset_FolderPath = 0;
                        }

                        return _offset_FolderPath;
                    }
                }

                /// <summary>
                /// Retrieves the FolderPath field.
                /// </summary>
                public string FolderPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FolderPath..]);

                /// <summary>
                /// Creates a new ProjectDirectoryTreeReleaseSubscriptionData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ProjectDirectoryTreeReleaseSubscriptionData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_FolderPath = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a GetEvaluatedPropertyValueStart event.
        /// </summary>
        public readonly ref struct GetEvaluatedPropertyValueStartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "GetEvaluatedPropertyValueStart";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 75,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Verbose,
                Opcode = EtwEventOpcode.Start,
                Task = (ushort)Tasks.GetEvaluatedPropertyValue,
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
            public GetEvaluatedPropertyValueStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new GetEvaluatedPropertyValueStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public GetEvaluatedPropertyValueStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a GetEvaluatedPropertyValueStart event.
            /// </summary>
            public ref struct GetEvaluatedPropertyValueStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_PropertyName;

                private int Offset_PropertyName
                {
                    get
                    {
                        if (_offset_PropertyName == -1)
                        {
                            _offset_PropertyName = 0;
                        }

                        return _offset_PropertyName;
                    }
                }

                /// <summary>
                /// Retrieves the PropertyName field.
                /// </summary>
                public string PropertyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_PropertyName..]);

                /// <summary>
                /// Creates a new GetEvaluatedPropertyValueStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public GetEvaluatedPropertyValueStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_PropertyName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a GetEvaluatedPropertyValueStop event.
        /// </summary>
        public readonly ref struct GetEvaluatedPropertyValueStopEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "GetEvaluatedPropertyValueStop";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 76,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Verbose,
                Opcode = EtwEventOpcode.End,
                Task = (ushort)Tasks.GetEvaluatedPropertyValue,
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
            public GetEvaluatedPropertyValueStopData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new GetEvaluatedPropertyValueStopEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public GetEvaluatedPropertyValueStopEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a GetEvaluatedPropertyValueStop event.
            /// </summary>
            public ref struct GetEvaluatedPropertyValueStopData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_PropertyName;
                private int _offset_Value;

                private int Offset_PropertyName
                {
                    get
                    {
                        if (_offset_PropertyName == -1)
                        {
                            _offset_PropertyName = 0;
                        }

                        return _offset_PropertyName;
                    }
                }

                private int Offset_Value
                {
                    get
                    {
                        if (_offset_Value == -1)
                        {
                            _offset_Value = Offset_PropertyName + _etwEvent.UnicodeStringLength(Offset_PropertyName);
                        }

                        return _offset_Value;
                    }
                }

                /// <summary>
                /// Retrieves the PropertyName field.
                /// </summary>
                public string PropertyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_PropertyName..]);

                /// <summary>
                /// Retrieves the Value field.
                /// </summary>
                public string Value => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Value..]);

                /// <summary>
                /// Creates a new GetEvaluatedPropertyValueStopData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public GetEvaluatedPropertyValueStopData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_PropertyName = -1;
                    _offset_Value = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ProjectEvaluationStart event.
        /// </summary>
        public readonly ref struct ProjectEvaluationStartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ProjectEvaluationStart";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 77,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Start,
                Task = (ushort)Tasks.ProjectEvaluation,
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
            public ProjectEvaluationStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ProjectEvaluationStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ProjectEvaluationStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ProjectEvaluationStart event.
            /// </summary>
            public ref struct ProjectEvaluationStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Project;
                private int _offset_EvaluationId;

                private int Offset_Project
                {
                    get
                    {
                        if (_offset_Project == -1)
                        {
                            _offset_Project = 0;
                        }

                        return _offset_Project;
                    }
                }

                private int Offset_EvaluationId
                {
                    get
                    {
                        if (_offset_EvaluationId == -1)
                        {
                            _offset_EvaluationId = Offset_Project + _etwEvent.UnicodeStringLength(Offset_Project);
                        }

                        return _offset_EvaluationId;
                    }
                }

                /// <summary>
                /// Retrieves the Project field.
                /// </summary>
                public string Project => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Project..]);

                /// <summary>
                /// Retrieves the EvaluationId field.
                /// </summary>
                public int EvaluationId => BitConverter.ToInt32(_etwEvent.Data[Offset_EvaluationId..]);

                /// <summary>
                /// Creates a new ProjectEvaluationStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ProjectEvaluationStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Project = -1;
                    _offset_EvaluationId = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ProjectEvaluationStop event.
        /// </summary>
        public readonly ref struct ProjectEvaluationStopEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ProjectEvaluationStop";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 78,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.End,
                Task = (ushort)Tasks.ProjectEvaluation,
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
            public ProjectEvaluationStopData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ProjectEvaluationStopEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ProjectEvaluationStopEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ProjectEvaluationStop event.
            /// </summary>
            public ref struct ProjectEvaluationStopData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Project;
                private int _offset_EvaluationId;

                private int Offset_Project
                {
                    get
                    {
                        if (_offset_Project == -1)
                        {
                            _offset_Project = 0;
                        }

                        return _offset_Project;
                    }
                }

                private int Offset_EvaluationId
                {
                    get
                    {
                        if (_offset_EvaluationId == -1)
                        {
                            _offset_EvaluationId = Offset_Project + _etwEvent.UnicodeStringLength(Offset_Project);
                        }

                        return _offset_EvaluationId;
                    }
                }

                /// <summary>
                /// Retrieves the Project field.
                /// </summary>
                public string Project => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Project..]);

                /// <summary>
                /// Retrieves the EvaluationId field.
                /// </summary>
                public int EvaluationId => BitConverter.ToInt32(_etwEvent.Data[Offset_EvaluationId..]);

                /// <summary>
                /// Creates a new ProjectEvaluationStopData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ProjectEvaluationStopData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Project = -1;
                    _offset_EvaluationId = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ProjectMarkDirtied event.
        /// </summary>
        public readonly ref struct ProjectMarkDirtiedEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ProjectMarkDirtied";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 79,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.ProjectMarkDirtied,
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
            public ProjectMarkDirtiedData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ProjectMarkDirtiedEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ProjectMarkDirtiedEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ProjectMarkDirtied event.
            /// </summary>
            public ref struct ProjectMarkDirtiedData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Project;

                private int Offset_Project
                {
                    get
                    {
                        if (_offset_Project == -1)
                        {
                            _offset_Project = 0;
                        }

                        return _offset_Project;
                    }
                }

                /// <summary>
                /// Retrieves the Project field.
                /// </summary>
                public string Project => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Project..]);

                /// <summary>
                /// Creates a new ProjectMarkDirtiedData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ProjectMarkDirtiedData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Project = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DesignTimeBuildStart event.
        /// </summary>
        public readonly ref struct DesignTimeBuildStartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DesignTimeBuildStart";

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
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Start,
                Task = (ushort)Tasks.DesignTimeBuild,
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
            public DesignTimeBuildStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DesignTimeBuildStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DesignTimeBuildStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a DesignTimeBuildStart event.
            /// </summary>
            public ref struct DesignTimeBuildStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Project;
                private int _offset_Configuration;
                private int _offset_UseCache;
                private int _offset_Targets;

                private int Offset_Project
                {
                    get
                    {
                        if (_offset_Project == -1)
                        {
                            _offset_Project = 0;
                        }

                        return _offset_Project;
                    }
                }

                private int Offset_Configuration
                {
                    get
                    {
                        if (_offset_Configuration == -1)
                        {
                            _offset_Configuration = Offset_Project + _etwEvent.UnicodeStringLength(Offset_Project);
                        }

                        return _offset_Configuration;
                    }
                }

                private int Offset_UseCache
                {
                    get
                    {
                        if (_offset_UseCache == -1)
                        {
                            _offset_UseCache = Offset_Configuration + _etwEvent.UnicodeStringLength(Offset_Configuration);
                        }

                        return _offset_UseCache;
                    }
                }

                private int Offset_Targets
                {
                    get
                    {
                        if (_offset_Targets == -1)
                        {
                            _offset_Targets = Offset_UseCache + 1;
                        }

                        return _offset_Targets;
                    }
                }

                /// <summary>
                /// Retrieves the Project field.
                /// </summary>
                public string Project => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Project..]);

                /// <summary>
                /// Retrieves the Configuration field.
                /// </summary>
                public string Configuration => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Configuration..]);

                /// <summary>
                /// Retrieves the UseCache field.
                /// </summary>
                public bool UseCache => _etwEvent.Data[Offset_UseCache] != 0;

                /// <summary>
                /// Retrieves the Targets field.
                /// </summary>
                public string Targets => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Targets..]);

                /// <summary>
                /// Creates a new DesignTimeBuildStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DesignTimeBuildStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Project = -1;
                    _offset_Configuration = -1;
                    _offset_UseCache = -1;
                    _offset_Targets = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DesignTimeBuildStop event.
        /// </summary>
        public readonly ref struct DesignTimeBuildStopEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DesignTimeBuildStop";

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
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.End,
                Task = (ushort)Tasks.DesignTimeBuild,
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
            public DesignTimeBuildStopData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DesignTimeBuildStopEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DesignTimeBuildStopEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a DesignTimeBuildStop event.
            /// </summary>
            public ref struct DesignTimeBuildStopData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Project;
                private int _offset_Configuration;
                private int _offset_ResetId;
                private int _offset_IsSuccessful;
                private int _offset_FromCache;

                private int Offset_Project
                {
                    get
                    {
                        if (_offset_Project == -1)
                        {
                            _offset_Project = 0;
                        }

                        return _offset_Project;
                    }
                }

                private int Offset_Configuration
                {
                    get
                    {
                        if (_offset_Configuration == -1)
                        {
                            _offset_Configuration = Offset_Project + _etwEvent.UnicodeStringLength(Offset_Project);
                        }

                        return _offset_Configuration;
                    }
                }

                private int Offset_ResetId
                {
                    get
                    {
                        if (_offset_ResetId == -1)
                        {
                            _offset_ResetId = Offset_Configuration + _etwEvent.UnicodeStringLength(Offset_Configuration);
                        }

                        return _offset_ResetId;
                    }
                }

                private int Offset_IsSuccessful
                {
                    get
                    {
                        if (_offset_IsSuccessful == -1)
                        {
                            _offset_IsSuccessful = Offset_ResetId + 4;
                        }

                        return _offset_IsSuccessful;
                    }
                }

                private int Offset_FromCache
                {
                    get
                    {
                        if (_offset_FromCache == -1)
                        {
                            _offset_FromCache = Offset_IsSuccessful + 1;
                        }

                        return _offset_FromCache;
                    }
                }

                /// <summary>
                /// Retrieves the Project field.
                /// </summary>
                public string Project => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Project..]);

                /// <summary>
                /// Retrieves the Configuration field.
                /// </summary>
                public string Configuration => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Configuration..]);

                /// <summary>
                /// Retrieves the ResetId field.
                /// </summary>
                public int ResetId => BitConverter.ToInt32(_etwEvent.Data[Offset_ResetId..]);

                /// <summary>
                /// Retrieves the IsSuccessful field.
                /// </summary>
                public bool IsSuccessful => _etwEvent.Data[Offset_IsSuccessful] != 0;

                /// <summary>
                /// Retrieves the FromCache field.
                /// </summary>
                public bool FromCache => _etwEvent.Data[Offset_FromCache] != 0;

                /// <summary>
                /// Creates a new DesignTimeBuildStopData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DesignTimeBuildStopData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Project = -1;
                    _offset_Configuration = -1;
                    _offset_ResetId = -1;
                    _offset_IsSuccessful = -1;
                    _offset_FromCache = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DesignTimeBuildFallbackToLegacy event.
        /// </summary>
        public readonly ref struct DesignTimeBuildFallbackToLegacyEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DesignTimeBuildFallbackToLegacy";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 82,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.DesignTimeBuildFallbackToLegacy,
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
            public DesignTimeBuildFallbackToLegacyData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DesignTimeBuildFallbackToLegacyEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DesignTimeBuildFallbackToLegacyEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a DesignTimeBuildFallbackToLegacy event.
            /// </summary>
            public ref struct DesignTimeBuildFallbackToLegacyData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Project;
                private int _offset_Configuration;

                private int Offset_Project
                {
                    get
                    {
                        if (_offset_Project == -1)
                        {
                            _offset_Project = 0;
                        }

                        return _offset_Project;
                    }
                }

                private int Offset_Configuration
                {
                    get
                    {
                        if (_offset_Configuration == -1)
                        {
                            _offset_Configuration = Offset_Project + _etwEvent.UnicodeStringLength(Offset_Project);
                        }

                        return _offset_Configuration;
                    }
                }

                /// <summary>
                /// Retrieves the Project field.
                /// </summary>
                public string Project => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Project..]);

                /// <summary>
                /// Retrieves the Configuration field.
                /// </summary>
                public string Configuration => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Configuration..]);

                /// <summary>
                /// Creates a new DesignTimeBuildFallbackToLegacyData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DesignTimeBuildFallbackToLegacyData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Project = -1;
                    _offset_Configuration = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a UpToDateCheckCalculateHashStart event.
        /// </summary>
        public readonly ref struct UpToDateCheckCalculateHashStartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "UpToDateCheckCalculateHashStart";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 83,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Start,
                Task = (ushort)Tasks.UpToDateCheckCalculateHash,
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
            public UpToDateCheckCalculateHashStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new UpToDateCheckCalculateHashStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public UpToDateCheckCalculateHashStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a UpToDateCheckCalculateHashStart event.
            /// </summary>
            public ref struct UpToDateCheckCalculateHashStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Project;
                private int _offset_Configuration;

                private int Offset_Project
                {
                    get
                    {
                        if (_offset_Project == -1)
                        {
                            _offset_Project = 0;
                        }

                        return _offset_Project;
                    }
                }

                private int Offset_Configuration
                {
                    get
                    {
                        if (_offset_Configuration == -1)
                        {
                            _offset_Configuration = Offset_Project + _etwEvent.UnicodeStringLength(Offset_Project);
                        }

                        return _offset_Configuration;
                    }
                }

                /// <summary>
                /// Retrieves the Project field.
                /// </summary>
                public string Project => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Project..]);

                /// <summary>
                /// Retrieves the Configuration field.
                /// </summary>
                public string Configuration => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Configuration..]);

                /// <summary>
                /// Creates a new UpToDateCheckCalculateHashStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public UpToDateCheckCalculateHashStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Project = -1;
                    _offset_Configuration = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a UpToDateCheckCalculateHashStop event.
        /// </summary>
        public readonly ref struct UpToDateCheckCalculateHashStopEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "UpToDateCheckCalculateHashStop";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 84,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.End,
                Task = (ushort)Tasks.UpToDateCheckCalculateHash,
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
            public UpToDateCheckCalculateHashStopData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new UpToDateCheckCalculateHashStopEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public UpToDateCheckCalculateHashStopEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a UpToDateCheckCalculateHashStop event.
            /// </summary>
            public ref struct UpToDateCheckCalculateHashStopData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Project;
                private int _offset_Configuration;

                private int Offset_Project
                {
                    get
                    {
                        if (_offset_Project == -1)
                        {
                            _offset_Project = 0;
                        }

                        return _offset_Project;
                    }
                }

                private int Offset_Configuration
                {
                    get
                    {
                        if (_offset_Configuration == -1)
                        {
                            _offset_Configuration = Offset_Project + _etwEvent.UnicodeStringLength(Offset_Project);
                        }

                        return _offset_Configuration;
                    }
                }

                /// <summary>
                /// Retrieves the Project field.
                /// </summary>
                public string Project => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Project..]);

                /// <summary>
                /// Retrieves the Configuration field.
                /// </summary>
                public string Configuration => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Configuration..]);

                /// <summary>
                /// Creates a new UpToDateCheckCalculateHashStopData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public UpToDateCheckCalculateHashStopData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Project = -1;
                    _offset_Configuration = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a GlobbingWatchingTriggerReevaluationUpgradeableLockRequestStart event.
        /// </summary>
        public readonly ref struct GlobbingWatchingTriggerReevaluationUpgradeableLockRequestStartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "GlobbingWatchingTriggerReevaluationUpgradeableLockRequestStart";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 85,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Start,
                Task = (ushort)Tasks.GlobbingWatchingTriggerReevaluationUpgradeableLockRequest,
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
            /// Creates a new GlobbingWatchingTriggerReevaluationUpgradeableLockRequestStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public GlobbingWatchingTriggerReevaluationUpgradeableLockRequestStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a GlobbingWatchingTriggerReevaluationUpgradeableLockRequestEnd event.
        /// </summary>
        public readonly ref struct GlobbingWatchingTriggerReevaluationUpgradeableLockRequestEndEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "GlobbingWatchingTriggerReevaluationUpgradeableLockRequestEnd";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 86,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.GlobbingWatchingTriggerReevaluationUpgradeableLockRequestEnd,
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
            /// Creates a new GlobbingWatchingTriggerReevaluationUpgradeableLockRequestEndEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public GlobbingWatchingTriggerReevaluationUpgradeableLockRequestEndEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a GlobbingWatchingTriggerReevaluationWriterLockRequestResult event.
        /// </summary>
        public readonly ref struct GlobbingWatchingTriggerReevaluationWriterLockRequestResultEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "GlobbingWatchingTriggerReevaluationWriterLockRequestResult";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 87,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.GlobbingWatchingTriggerReevaluationWriterLockRequestResult,
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
            public GlobbingWatchingTriggerReevaluationWriterLockRequestResultData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new GlobbingWatchingTriggerReevaluationWriterLockRequestResultEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public GlobbingWatchingTriggerReevaluationWriterLockRequestResultEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a GlobbingWatchingTriggerReevaluationWriterLockRequestResult event.
            /// </summary>
            public ref struct GlobbingWatchingTriggerReevaluationWriterLockRequestResultData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Cancelled;

                private int Offset_Cancelled
                {
                    get
                    {
                        if (_offset_Cancelled == -1)
                        {
                            _offset_Cancelled = 0;
                        }

                        return _offset_Cancelled;
                    }
                }

                /// <summary>
                /// Retrieves the Cancelled field.
                /// </summary>
                public bool Cancelled => _etwEvent.Data[Offset_Cancelled] != 0;

                /// <summary>
                /// Creates a new GlobbingWatchingTriggerReevaluationWriterLockRequestResultData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public GlobbingWatchingTriggerReevaluationWriterLockRequestResultData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Cancelled = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ReportOutputDataSourceStart event.
        /// </summary>
        public readonly ref struct ReportOutputDataSourceStartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ReportOutputDataSourceStart";

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
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Start,
                Task = (ushort)Tasks.ReportOutputDataSource,
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
            public ReportOutputDataSourceStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ReportOutputDataSourceStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ReportOutputDataSourceStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ReportOutputDataSourceStart event.
            /// </summary>
            public ref struct ReportOutputDataSourceStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Project;
                private int _offset_DataSourceName;

                private int Offset_Project
                {
                    get
                    {
                        if (_offset_Project == -1)
                        {
                            _offset_Project = 0;
                        }

                        return _offset_Project;
                    }
                }

                private int Offset_DataSourceName
                {
                    get
                    {
                        if (_offset_DataSourceName == -1)
                        {
                            _offset_DataSourceName = Offset_Project + _etwEvent.UnicodeStringLength(Offset_Project);
                        }

                        return _offset_DataSourceName;
                    }
                }

                /// <summary>
                /// Retrieves the Project field.
                /// </summary>
                public string Project => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Project..]);

                /// <summary>
                /// Retrieves the DataSourceName field.
                /// </summary>
                public string DataSourceName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_DataSourceName..]);

                /// <summary>
                /// Creates a new ReportOutputDataSourceStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ReportOutputDataSourceStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Project = -1;
                    _offset_DataSourceName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ReportOutputDataSourceStop event.
        /// </summary>
        public readonly ref struct ReportOutputDataSourceStopEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ReportOutputDataSourceStop";

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
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.End,
                Task = (ushort)Tasks.ReportOutputDataSource,
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
            public ReportOutputDataSourceStopData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ReportOutputDataSourceStopEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ReportOutputDataSourceStopEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ReportOutputDataSourceStop event.
            /// </summary>
            public ref struct ReportOutputDataSourceStopData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Project;
                private int _offset_DataSourceName;

                private int Offset_Project
                {
                    get
                    {
                        if (_offset_Project == -1)
                        {
                            _offset_Project = 0;
                        }

                        return _offset_Project;
                    }
                }

                private int Offset_DataSourceName
                {
                    get
                    {
                        if (_offset_DataSourceName == -1)
                        {
                            _offset_DataSourceName = Offset_Project + _etwEvent.UnicodeStringLength(Offset_Project);
                        }

                        return _offset_DataSourceName;
                    }
                }

                /// <summary>
                /// Retrieves the Project field.
                /// </summary>
                public string Project => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Project..]);

                /// <summary>
                /// Retrieves the DataSourceName field.
                /// </summary>
                public string DataSourceName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_DataSourceName..]);

                /// <summary>
                /// Creates a new ReportOutputDataSourceStopData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ReportOutputDataSourceStopData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Project = -1;
                    _offset_DataSourceName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ReportCoreDirectoryTreeHintFileChanged event.
        /// </summary>
        public readonly ref struct ReportCoreDirectoryTreeHintFileChangedEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ReportCoreDirectoryTreeHintFileChanged";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 92,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.ReportCoreDirectoryTreeHintFileChanged,
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
            public ReportCoreDirectoryTreeHintFileChangedData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ReportCoreDirectoryTreeHintFileChangedEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ReportCoreDirectoryTreeHintFileChangedEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ReportCoreDirectoryTreeHintFileChanged event.
            /// </summary>
            public ref struct ReportCoreDirectoryTreeHintFileChangedData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_RootPath;
                private int _offset_FilePath;
                private int _offset_ChangeType;

                private int Offset_RootPath
                {
                    get
                    {
                        if (_offset_RootPath == -1)
                        {
                            _offset_RootPath = 0;
                        }

                        return _offset_RootPath;
                    }
                }

                private int Offset_FilePath
                {
                    get
                    {
                        if (_offset_FilePath == -1)
                        {
                            _offset_FilePath = Offset_RootPath + _etwEvent.UnicodeStringLength(Offset_RootPath);
                        }

                        return _offset_FilePath;
                    }
                }

                private int Offset_ChangeType
                {
                    get
                    {
                        if (_offset_ChangeType == -1)
                        {
                            _offset_ChangeType = Offset_FilePath + _etwEvent.UnicodeStringLength(Offset_FilePath);
                        }

                        return _offset_ChangeType;
                    }
                }

                /// <summary>
                /// Retrieves the RootPath field.
                /// </summary>
                public string RootPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_RootPath..]);

                /// <summary>
                /// Retrieves the FilePath field.
                /// </summary>
                public string FilePath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FilePath..]);

                /// <summary>
                /// Retrieves the ChangeType field.
                /// </summary>
                public WatcherChangeTypes ChangeType => (WatcherChangeTypes)BitConverter.ToUInt32(_etwEvent.Data[Offset_ChangeType..]);

                /// <summary>
                /// Creates a new ReportCoreDirectoryTreeHintFileChangedData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ReportCoreDirectoryTreeHintFileChangedData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_RootPath = -1;
                    _offset_FilePath = -1;
                    _offset_ChangeType = -1;
                }
            }

        }

        /// <summary>
        /// WatcherChangeTypes.
        /// </summary>
        [Flags]
        public enum WatcherChangeTypes : ulong
        {
            /// <summary>
            /// Created.
            /// </summary>
            Created = 0x0000000000000001,
            /// <summary>
            /// Deleted.
            /// </summary>
            Deleted = 0x0000000000000002,
            /// <summary>
            /// Changed.
            /// </summary>
            Changed = 0x0000000000000004,
            /// <summary>
            /// Renamed.
            /// </summary>
            Renamed = 0x0000000000000008,
        }
    }
}
