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
    /// Provider for System.Diagnostics.Eventing.FrameworkEventSource (8e9f5090-2d75-4d03-8a81-e5afbf85daf1)
    /// </summary>
    public sealed class SystemDiagnosticsEventingFrameworkEventSourceProvider
    {
        /// <summary>s
        /// Provider ID.
        /// </summary>
        public static readonly Guid Id = new("8e9f5090-2d75-4d03-8a81-e5afbf85daf1");

        /// <summary>
        /// Provider name.
        /// </summary>
        public const string Name = "System.Diagnostics.Eventing.FrameworkEventSource";

        /// <summary>
        /// Tasks supported by System.Diagnostics.Eventing.FrameworkEventSource.
        /// </summary>
        public enum Tasks : ushort
        {
            /// <summary>
            /// 'GetResponse' task.
            /// </summary>
            GetResponse = 1,
            /// <summary>
            /// 'GetRequestStream' task.
            /// </summary>
            GetRequestStream = 2,
            /// <summary>
            /// 'ThreadTransfer' task.
            /// </summary>
            ThreadTransfer = 3,
            /// <summary>
            /// 'ThreadPoolDequeueWork' task.
            /// </summary>
            ThreadPoolDequeueWork = 65503,
            /// <summary>
            /// 'ThreadPoolEnqueueWork' task.
            /// </summary>
            ThreadPoolEnqueueWork = 65504,
            /// <summary>
            /// 'ResourceManagerCultureFoundInConfigFile' task.
            /// </summary>
            ResourceManagerCultureFoundInConfigFile = 65512,
            /// <summary>
            /// 'ResourceManagerCultureNotFoundInConfigFile' task.
            /// </summary>
            ResourceManagerCultureNotFoundInConfigFile = 65513,
            /// <summary>
            /// 'ResourceManagerAddingCultureFromConfigFile' task.
            /// </summary>
            ResourceManagerAddingCultureFromConfigFile = 65514,
            /// <summary>
            /// 'ResourceManagerNeutralResourcesFound' task.
            /// </summary>
            ResourceManagerNeutralResourcesFound = 65515,
            /// <summary>
            /// 'ResourceManagerNeutralResourcesNotFound' task.
            /// </summary>
            ResourceManagerNeutralResourcesNotFound = 65516,
            /// <summary>
            /// 'ResourceManagerReleasingResources' task.
            /// </summary>
            ResourceManagerReleasingResources = 65517,
            /// <summary>
            /// 'ResourceManagerLookupFailed' task.
            /// </summary>
            ResourceManagerLookupFailed = 65518,
            /// <summary>
            /// 'ResourceManagerNotCreatingResourceSet' task.
            /// </summary>
            ResourceManagerNotCreatingResourceSet = 65519,
            /// <summary>
            /// 'ResourceManagerCreatingResourceSet' task.
            /// </summary>
            ResourceManagerCreatingResourceSet = 65520,
            /// <summary>
            /// 'ResourceManagerNeutralResourceAttributeMissing' task.
            /// </summary>
            ResourceManagerNeutralResourceAttributeMissing = 65521,
            /// <summary>
            /// 'ResourceManagerNeutralResourcesSufficient' task.
            /// </summary>
            ResourceManagerNeutralResourcesSufficient = 65522,
            /// <summary>
            /// 'ResourceManagerManifestResourceAccessDenied' task.
            /// </summary>
            ResourceManagerManifestResourceAccessDenied = 65523,
            /// <summary>
            /// 'ResourceManagerCaseInsensitiveResourceStreamLookupFailed' task.
            /// </summary>
            ResourceManagerCaseInsensitiveResourceStreamLookupFailed = 65524,
            /// <summary>
            /// 'ResourceManagerCaseInsensitiveResourceStreamLookupSucceeded' task.
            /// </summary>
            ResourceManagerCaseInsensitiveResourceStreamLookupSucceeded = 65525,
            /// <summary>
            /// 'ResourceManagerGetSatelliteAssemblyFailed' task.
            /// </summary>
            ResourceManagerGetSatelliteAssemblyFailed = 65526,
            /// <summary>
            /// 'ResourceManagerGetSatelliteAssemblySucceeded' task.
            /// </summary>
            ResourceManagerGetSatelliteAssemblySucceeded = 65527,
            /// <summary>
            /// 'ResourceManagerStreamNotFound' task.
            /// </summary>
            ResourceManagerStreamNotFound = 65528,
            /// <summary>
            /// 'ResourceManagerStreamFound' task.
            /// </summary>
            ResourceManagerStreamFound = 65529,
            /// <summary>
            /// 'ResourceManagerFoundResourceSetInCacheUnexpected' task.
            /// </summary>
            ResourceManagerFoundResourceSetInCacheUnexpected = 65530,
            /// <summary>
            /// 'ResourceManagerFoundResourceSetInCache' task.
            /// </summary>
            ResourceManagerFoundResourceSetInCache = 65531,
            /// <summary>
            /// 'ResourceManagerLookingForResourceSet' task.
            /// </summary>
            ResourceManagerLookingForResourceSet = 65532,
            /// <summary>
            /// 'ResourceManagerLookupStarted' task.
            /// </summary>
            ResourceManagerLookupStarted = 65533,
            /// <summary>
            /// 'EventSourceMessage' task.
            /// </summary>
            EventSourceMessage = 65534,
        }

        /// <summary>
        /// Opcodes supported by SystemDiagnosticsEventingFrameworkEventSource.
        /// </summary>
        public enum Opcodes
        {
            /// <summary>
            /// 'ReceiveHandled' opcode.
            /// </summary>
            ReceiveHandled = 11,
        }

        /// <summary>
        /// Keywords supported by SystemDiagnosticsEventingFrameworkEventSource.
        /// </summary>
        [Flags]
        public enum Keywords : ulong
        {
            /// <summary>
            /// 'Loader' keyword.
            /// </summary>
            Loader = 0x0000000000000001,
            /// <summary>
            /// 'ThreadPool' keyword.
            /// </summary>
            ThreadPool = 0x0000000000000002,
            /// <summary>
            /// 'NetClient' keyword.
            /// </summary>
            NetClient = 0x0000000000000004,
            /// <summary>
            /// 'DynamicTypeUsage' keyword.
            /// </summary>
            DynamicTypeUsage = 0x0000000000000008,
            /// <summary>
            /// 'ThreadTransfer' keyword.
            /// </summary>
            ThreadTransfer = 0x0000000000000010,
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
        /// An event wrapper for a ResourceManagerLookupStarted event.
        /// </summary>
        public readonly ref struct ResourceManagerLookupStartedEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ResourceManagerLookupStarted";

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
                Task = (ushort)Tasks.ResourceManagerLookupStarted,
                Keyword = (ulong)Keywords.Loader
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
            public ResourceManagerLookupStartedData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ResourceManagerLookupStartedEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ResourceManagerLookupStartedEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ResourceManagerLookupStarted event.
            /// </summary>
            public ref struct ResourceManagerLookupStartedData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_BaseName;
                private int _offset_MainAssemblyName;
                private int _offset_CultureName;

                private int Offset_BaseName
                {
                    get
                    {
                        if (_offset_BaseName == -1)
                        {
                            _offset_BaseName = 0;
                        }

                        return _offset_BaseName;
                    }
                }

                private int Offset_MainAssemblyName
                {
                    get
                    {
                        if (_offset_MainAssemblyName == -1)
                        {
                            _offset_MainAssemblyName = Offset_BaseName + _etwEvent.UnicodeStringLength(Offset_BaseName);
                        }

                        return _offset_MainAssemblyName;
                    }
                }

                private int Offset_CultureName
                {
                    get
                    {
                        if (_offset_CultureName == -1)
                        {
                            _offset_CultureName = Offset_MainAssemblyName + _etwEvent.UnicodeStringLength(Offset_MainAssemblyName);
                        }

                        return _offset_CultureName;
                    }
                }

                /// <summary>
                /// Retrieves the BaseName field.
                /// </summary>
                public string BaseName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_BaseName..]);

                /// <summary>
                /// Retrieves the MainAssemblyName field.
                /// </summary>
                public string MainAssemblyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_MainAssemblyName..]);

                /// <summary>
                /// Retrieves the CultureName field.
                /// </summary>
                public string CultureName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_CultureName..]);

                /// <summary>
                /// Creates a new ResourceManagerLookupStartedData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ResourceManagerLookupStartedData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_BaseName = -1;
                    _offset_MainAssemblyName = -1;
                    _offset_CultureName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ResourceManagerLookingForResourceSet event.
        /// </summary>
        public readonly ref struct ResourceManagerLookingForResourceSetEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ResourceManagerLookingForResourceSet";

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
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.ResourceManagerLookingForResourceSet,
                Keyword = (ulong)Keywords.Loader
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
            public ResourceManagerLookingForResourceSetData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ResourceManagerLookingForResourceSetEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ResourceManagerLookingForResourceSetEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ResourceManagerLookingForResourceSet event.
            /// </summary>
            public ref struct ResourceManagerLookingForResourceSetData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_BaseName;
                private int _offset_MainAssemblyName;
                private int _offset_CultureName;

                private int Offset_BaseName
                {
                    get
                    {
                        if (_offset_BaseName == -1)
                        {
                            _offset_BaseName = 0;
                        }

                        return _offset_BaseName;
                    }
                }

                private int Offset_MainAssemblyName
                {
                    get
                    {
                        if (_offset_MainAssemblyName == -1)
                        {
                            _offset_MainAssemblyName = Offset_BaseName + _etwEvent.UnicodeStringLength(Offset_BaseName);
                        }

                        return _offset_MainAssemblyName;
                    }
                }

                private int Offset_CultureName
                {
                    get
                    {
                        if (_offset_CultureName == -1)
                        {
                            _offset_CultureName = Offset_MainAssemblyName + _etwEvent.UnicodeStringLength(Offset_MainAssemblyName);
                        }

                        return _offset_CultureName;
                    }
                }

                /// <summary>
                /// Retrieves the BaseName field.
                /// </summary>
                public string BaseName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_BaseName..]);

                /// <summary>
                /// Retrieves the MainAssemblyName field.
                /// </summary>
                public string MainAssemblyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_MainAssemblyName..]);

                /// <summary>
                /// Retrieves the CultureName field.
                /// </summary>
                public string CultureName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_CultureName..]);

                /// <summary>
                /// Creates a new ResourceManagerLookingForResourceSetData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ResourceManagerLookingForResourceSetData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_BaseName = -1;
                    _offset_MainAssemblyName = -1;
                    _offset_CultureName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ResourceManagerFoundResourceSetInCache event.
        /// </summary>
        public readonly ref struct ResourceManagerFoundResourceSetInCacheEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ResourceManagerFoundResourceSetInCache";

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
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.ResourceManagerFoundResourceSetInCache,
                Keyword = (ulong)Keywords.Loader
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
            public ResourceManagerFoundResourceSetInCacheData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ResourceManagerFoundResourceSetInCacheEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ResourceManagerFoundResourceSetInCacheEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ResourceManagerFoundResourceSetInCache event.
            /// </summary>
            public ref struct ResourceManagerFoundResourceSetInCacheData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_BaseName;
                private int _offset_MainAssemblyName;
                private int _offset_CultureName;

                private int Offset_BaseName
                {
                    get
                    {
                        if (_offset_BaseName == -1)
                        {
                            _offset_BaseName = 0;
                        }

                        return _offset_BaseName;
                    }
                }

                private int Offset_MainAssemblyName
                {
                    get
                    {
                        if (_offset_MainAssemblyName == -1)
                        {
                            _offset_MainAssemblyName = Offset_BaseName + _etwEvent.UnicodeStringLength(Offset_BaseName);
                        }

                        return _offset_MainAssemblyName;
                    }
                }

                private int Offset_CultureName
                {
                    get
                    {
                        if (_offset_CultureName == -1)
                        {
                            _offset_CultureName = Offset_MainAssemblyName + _etwEvent.UnicodeStringLength(Offset_MainAssemblyName);
                        }

                        return _offset_CultureName;
                    }
                }

                /// <summary>
                /// Retrieves the BaseName field.
                /// </summary>
                public string BaseName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_BaseName..]);

                /// <summary>
                /// Retrieves the MainAssemblyName field.
                /// </summary>
                public string MainAssemblyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_MainAssemblyName..]);

                /// <summary>
                /// Retrieves the CultureName field.
                /// </summary>
                public string CultureName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_CultureName..]);

                /// <summary>
                /// Creates a new ResourceManagerFoundResourceSetInCacheData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ResourceManagerFoundResourceSetInCacheData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_BaseName = -1;
                    _offset_MainAssemblyName = -1;
                    _offset_CultureName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ResourceManagerFoundResourceSetInCacheUnexpected event.
        /// </summary>
        public readonly ref struct ResourceManagerFoundResourceSetInCacheUnexpectedEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ResourceManagerFoundResourceSetInCacheUnexpected";

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
                Level = EtwTraceLevel.Warning,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.ResourceManagerFoundResourceSetInCacheUnexpected,
                Keyword = (ulong)Keywords.Loader
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
            public ResourceManagerFoundResourceSetInCacheUnexpectedData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ResourceManagerFoundResourceSetInCacheUnexpectedEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ResourceManagerFoundResourceSetInCacheUnexpectedEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ResourceManagerFoundResourceSetInCacheUnexpected event.
            /// </summary>
            public ref struct ResourceManagerFoundResourceSetInCacheUnexpectedData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_BaseName;
                private int _offset_MainAssemblyName;
                private int _offset_CultureName;

                private int Offset_BaseName
                {
                    get
                    {
                        if (_offset_BaseName == -1)
                        {
                            _offset_BaseName = 0;
                        }

                        return _offset_BaseName;
                    }
                }

                private int Offset_MainAssemblyName
                {
                    get
                    {
                        if (_offset_MainAssemblyName == -1)
                        {
                            _offset_MainAssemblyName = Offset_BaseName + _etwEvent.UnicodeStringLength(Offset_BaseName);
                        }

                        return _offset_MainAssemblyName;
                    }
                }

                private int Offset_CultureName
                {
                    get
                    {
                        if (_offset_CultureName == -1)
                        {
                            _offset_CultureName = Offset_MainAssemblyName + _etwEvent.UnicodeStringLength(Offset_MainAssemblyName);
                        }

                        return _offset_CultureName;
                    }
                }

                /// <summary>
                /// Retrieves the BaseName field.
                /// </summary>
                public string BaseName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_BaseName..]);

                /// <summary>
                /// Retrieves the MainAssemblyName field.
                /// </summary>
                public string MainAssemblyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_MainAssemblyName..]);

                /// <summary>
                /// Retrieves the CultureName field.
                /// </summary>
                public string CultureName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_CultureName..]);

                /// <summary>
                /// Creates a new ResourceManagerFoundResourceSetInCacheUnexpectedData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ResourceManagerFoundResourceSetInCacheUnexpectedData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_BaseName = -1;
                    _offset_MainAssemblyName = -1;
                    _offset_CultureName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ResourceManagerStreamFound event.
        /// </summary>
        public readonly ref struct ResourceManagerStreamFoundEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ResourceManagerStreamFound";

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
                Task = (ushort)Tasks.ResourceManagerStreamFound,
                Keyword = (ulong)Keywords.Loader
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
            public ResourceManagerStreamFoundData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ResourceManagerStreamFoundEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ResourceManagerStreamFoundEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ResourceManagerStreamFound event.
            /// </summary>
            public ref struct ResourceManagerStreamFoundData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_BaseName;
                private int _offset_MainAssemblyName;
                private int _offset_CultureName;
                private int _offset_LoadedAssemblyName;
                private int _offset_ResourceFileName;

                private int Offset_BaseName
                {
                    get
                    {
                        if (_offset_BaseName == -1)
                        {
                            _offset_BaseName = 0;
                        }

                        return _offset_BaseName;
                    }
                }

                private int Offset_MainAssemblyName
                {
                    get
                    {
                        if (_offset_MainAssemblyName == -1)
                        {
                            _offset_MainAssemblyName = Offset_BaseName + _etwEvent.UnicodeStringLength(Offset_BaseName);
                        }

                        return _offset_MainAssemblyName;
                    }
                }

                private int Offset_CultureName
                {
                    get
                    {
                        if (_offset_CultureName == -1)
                        {
                            _offset_CultureName = Offset_MainAssemblyName + _etwEvent.UnicodeStringLength(Offset_MainAssemblyName);
                        }

                        return _offset_CultureName;
                    }
                }

                private int Offset_LoadedAssemblyName
                {
                    get
                    {
                        if (_offset_LoadedAssemblyName == -1)
                        {
                            _offset_LoadedAssemblyName = Offset_CultureName + _etwEvent.UnicodeStringLength(Offset_CultureName);
                        }

                        return _offset_LoadedAssemblyName;
                    }
                }

                private int Offset_ResourceFileName
                {
                    get
                    {
                        if (_offset_ResourceFileName == -1)
                        {
                            _offset_ResourceFileName = Offset_LoadedAssemblyName + _etwEvent.UnicodeStringLength(Offset_LoadedAssemblyName);
                        }

                        return _offset_ResourceFileName;
                    }
                }

                /// <summary>
                /// Retrieves the BaseName field.
                /// </summary>
                public string BaseName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_BaseName..]);

                /// <summary>
                /// Retrieves the MainAssemblyName field.
                /// </summary>
                public string MainAssemblyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_MainAssemblyName..]);

                /// <summary>
                /// Retrieves the CultureName field.
                /// </summary>
                public string CultureName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_CultureName..]);

                /// <summary>
                /// Retrieves the LoadedAssemblyName field.
                /// </summary>
                public string LoadedAssemblyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_LoadedAssemblyName..]);

                /// <summary>
                /// Retrieves the ResourceFileName field.
                /// </summary>
                public string ResourceFileName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ResourceFileName..]);

                /// <summary>
                /// Creates a new ResourceManagerStreamFoundData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ResourceManagerStreamFoundData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_BaseName = -1;
                    _offset_MainAssemblyName = -1;
                    _offset_CultureName = -1;
                    _offset_LoadedAssemblyName = -1;
                    _offset_ResourceFileName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ResourceManagerStreamNotFound event.
        /// </summary>
        public readonly ref struct ResourceManagerStreamNotFoundEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ResourceManagerStreamNotFound";

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
                Level = EtwTraceLevel.Warning,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.ResourceManagerStreamNotFound,
                Keyword = (ulong)Keywords.Loader
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
            public ResourceManagerStreamNotFoundData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ResourceManagerStreamNotFoundEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ResourceManagerStreamNotFoundEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ResourceManagerStreamNotFound event.
            /// </summary>
            public ref struct ResourceManagerStreamNotFoundData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_BaseName;
                private int _offset_MainAssemblyName;
                private int _offset_CultureName;
                private int _offset_LoadedAssemblyName;
                private int _offset_ResourceFileName;

                private int Offset_BaseName
                {
                    get
                    {
                        if (_offset_BaseName == -1)
                        {
                            _offset_BaseName = 0;
                        }

                        return _offset_BaseName;
                    }
                }

                private int Offset_MainAssemblyName
                {
                    get
                    {
                        if (_offset_MainAssemblyName == -1)
                        {
                            _offset_MainAssemblyName = Offset_BaseName + _etwEvent.UnicodeStringLength(Offset_BaseName);
                        }

                        return _offset_MainAssemblyName;
                    }
                }

                private int Offset_CultureName
                {
                    get
                    {
                        if (_offset_CultureName == -1)
                        {
                            _offset_CultureName = Offset_MainAssemblyName + _etwEvent.UnicodeStringLength(Offset_MainAssemblyName);
                        }

                        return _offset_CultureName;
                    }
                }

                private int Offset_LoadedAssemblyName
                {
                    get
                    {
                        if (_offset_LoadedAssemblyName == -1)
                        {
                            _offset_LoadedAssemblyName = Offset_CultureName + _etwEvent.UnicodeStringLength(Offset_CultureName);
                        }

                        return _offset_LoadedAssemblyName;
                    }
                }

                private int Offset_ResourceFileName
                {
                    get
                    {
                        if (_offset_ResourceFileName == -1)
                        {
                            _offset_ResourceFileName = Offset_LoadedAssemblyName + _etwEvent.UnicodeStringLength(Offset_LoadedAssemblyName);
                        }

                        return _offset_ResourceFileName;
                    }
                }

                /// <summary>
                /// Retrieves the BaseName field.
                /// </summary>
                public string BaseName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_BaseName..]);

                /// <summary>
                /// Retrieves the MainAssemblyName field.
                /// </summary>
                public string MainAssemblyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_MainAssemblyName..]);

                /// <summary>
                /// Retrieves the CultureName field.
                /// </summary>
                public string CultureName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_CultureName..]);

                /// <summary>
                /// Retrieves the LoadedAssemblyName field.
                /// </summary>
                public string LoadedAssemblyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_LoadedAssemblyName..]);

                /// <summary>
                /// Retrieves the ResourceFileName field.
                /// </summary>
                public string ResourceFileName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ResourceFileName..]);

                /// <summary>
                /// Creates a new ResourceManagerStreamNotFoundData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ResourceManagerStreamNotFoundData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_BaseName = -1;
                    _offset_MainAssemblyName = -1;
                    _offset_CultureName = -1;
                    _offset_LoadedAssemblyName = -1;
                    _offset_ResourceFileName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ResourceManagerGetSatelliteAssemblySucceeded event.
        /// </summary>
        public readonly ref struct ResourceManagerGetSatelliteAssemblySucceededEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ResourceManagerGetSatelliteAssemblySucceeded";

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
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.ResourceManagerGetSatelliteAssemblySucceeded,
                Keyword = (ulong)Keywords.Loader
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
            public ResourceManagerGetSatelliteAssemblySucceededData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ResourceManagerGetSatelliteAssemblySucceededEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ResourceManagerGetSatelliteAssemblySucceededEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ResourceManagerGetSatelliteAssemblySucceeded event.
            /// </summary>
            public ref struct ResourceManagerGetSatelliteAssemblySucceededData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_BaseName;
                private int _offset_MainAssemblyName;
                private int _offset_CultureName;
                private int _offset_AssemblyName;

                private int Offset_BaseName
                {
                    get
                    {
                        if (_offset_BaseName == -1)
                        {
                            _offset_BaseName = 0;
                        }

                        return _offset_BaseName;
                    }
                }

                private int Offset_MainAssemblyName
                {
                    get
                    {
                        if (_offset_MainAssemblyName == -1)
                        {
                            _offset_MainAssemblyName = Offset_BaseName + _etwEvent.UnicodeStringLength(Offset_BaseName);
                        }

                        return _offset_MainAssemblyName;
                    }
                }

                private int Offset_CultureName
                {
                    get
                    {
                        if (_offset_CultureName == -1)
                        {
                            _offset_CultureName = Offset_MainAssemblyName + _etwEvent.UnicodeStringLength(Offset_MainAssemblyName);
                        }

                        return _offset_CultureName;
                    }
                }

                private int Offset_AssemblyName
                {
                    get
                    {
                        if (_offset_AssemblyName == -1)
                        {
                            _offset_AssemblyName = Offset_CultureName + _etwEvent.UnicodeStringLength(Offset_CultureName);
                        }

                        return _offset_AssemblyName;
                    }
                }

                /// <summary>
                /// Retrieves the BaseName field.
                /// </summary>
                public string BaseName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_BaseName..]);

                /// <summary>
                /// Retrieves the MainAssemblyName field.
                /// </summary>
                public string MainAssemblyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_MainAssemblyName..]);

                /// <summary>
                /// Retrieves the CultureName field.
                /// </summary>
                public string CultureName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_CultureName..]);

                /// <summary>
                /// Retrieves the AssemblyName field.
                /// </summary>
                public string AssemblyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_AssemblyName..]);

                /// <summary>
                /// Creates a new ResourceManagerGetSatelliteAssemblySucceededData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ResourceManagerGetSatelliteAssemblySucceededData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_BaseName = -1;
                    _offset_MainAssemblyName = -1;
                    _offset_CultureName = -1;
                    _offset_AssemblyName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ResourceManagerGetSatelliteAssemblyFailed event.
        /// </summary>
        public readonly ref struct ResourceManagerGetSatelliteAssemblyFailedEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ResourceManagerGetSatelliteAssemblyFailed";

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
                Level = EtwTraceLevel.Warning,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.ResourceManagerGetSatelliteAssemblyFailed,
                Keyword = (ulong)Keywords.Loader
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
            public ResourceManagerGetSatelliteAssemblyFailedData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ResourceManagerGetSatelliteAssemblyFailedEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ResourceManagerGetSatelliteAssemblyFailedEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ResourceManagerGetSatelliteAssemblyFailed event.
            /// </summary>
            public ref struct ResourceManagerGetSatelliteAssemblyFailedData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_BaseName;
                private int _offset_MainAssemblyName;
                private int _offset_CultureName;
                private int _offset_AssemblyName;

                private int Offset_BaseName
                {
                    get
                    {
                        if (_offset_BaseName == -1)
                        {
                            _offset_BaseName = 0;
                        }

                        return _offset_BaseName;
                    }
                }

                private int Offset_MainAssemblyName
                {
                    get
                    {
                        if (_offset_MainAssemblyName == -1)
                        {
                            _offset_MainAssemblyName = Offset_BaseName + _etwEvent.UnicodeStringLength(Offset_BaseName);
                        }

                        return _offset_MainAssemblyName;
                    }
                }

                private int Offset_CultureName
                {
                    get
                    {
                        if (_offset_CultureName == -1)
                        {
                            _offset_CultureName = Offset_MainAssemblyName + _etwEvent.UnicodeStringLength(Offset_MainAssemblyName);
                        }

                        return _offset_CultureName;
                    }
                }

                private int Offset_AssemblyName
                {
                    get
                    {
                        if (_offset_AssemblyName == -1)
                        {
                            _offset_AssemblyName = Offset_CultureName + _etwEvent.UnicodeStringLength(Offset_CultureName);
                        }

                        return _offset_AssemblyName;
                    }
                }

                /// <summary>
                /// Retrieves the BaseName field.
                /// </summary>
                public string BaseName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_BaseName..]);

                /// <summary>
                /// Retrieves the MainAssemblyName field.
                /// </summary>
                public string MainAssemblyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_MainAssemblyName..]);

                /// <summary>
                /// Retrieves the CultureName field.
                /// </summary>
                public string CultureName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_CultureName..]);

                /// <summary>
                /// Retrieves the AssemblyName field.
                /// </summary>
                public string AssemblyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_AssemblyName..]);

                /// <summary>
                /// Creates a new ResourceManagerGetSatelliteAssemblyFailedData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ResourceManagerGetSatelliteAssemblyFailedData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_BaseName = -1;
                    _offset_MainAssemblyName = -1;
                    _offset_CultureName = -1;
                    _offset_AssemblyName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ResourceManagerCaseInsensitiveResourceStreamLookupSucceeded event.
        /// </summary>
        public readonly ref struct ResourceManagerCaseInsensitiveResourceStreamLookupSucceededEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ResourceManagerCaseInsensitiveResourceStreamLookupSucceeded";

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
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.ResourceManagerCaseInsensitiveResourceStreamLookupSucceeded,
                Keyword = (ulong)Keywords.Loader
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
            public ResourceManagerCaseInsensitiveResourceStreamLookupSucceededData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ResourceManagerCaseInsensitiveResourceStreamLookupSucceededEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ResourceManagerCaseInsensitiveResourceStreamLookupSucceededEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ResourceManagerCaseInsensitiveResourceStreamLookupSucceeded event.
            /// </summary>
            public ref struct ResourceManagerCaseInsensitiveResourceStreamLookupSucceededData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_BaseName;
                private int _offset_MainAssemblyName;
                private int _offset_AssemblyName;
                private int _offset_ResourceFileName;

                private int Offset_BaseName
                {
                    get
                    {
                        if (_offset_BaseName == -1)
                        {
                            _offset_BaseName = 0;
                        }

                        return _offset_BaseName;
                    }
                }

                private int Offset_MainAssemblyName
                {
                    get
                    {
                        if (_offset_MainAssemblyName == -1)
                        {
                            _offset_MainAssemblyName = Offset_BaseName + _etwEvent.UnicodeStringLength(Offset_BaseName);
                        }

                        return _offset_MainAssemblyName;
                    }
                }

                private int Offset_AssemblyName
                {
                    get
                    {
                        if (_offset_AssemblyName == -1)
                        {
                            _offset_AssemblyName = Offset_MainAssemblyName + _etwEvent.UnicodeStringLength(Offset_MainAssemblyName);
                        }

                        return _offset_AssemblyName;
                    }
                }

                private int Offset_ResourceFileName
                {
                    get
                    {
                        if (_offset_ResourceFileName == -1)
                        {
                            _offset_ResourceFileName = Offset_AssemblyName + _etwEvent.UnicodeStringLength(Offset_AssemblyName);
                        }

                        return _offset_ResourceFileName;
                    }
                }

                /// <summary>
                /// Retrieves the BaseName field.
                /// </summary>
                public string BaseName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_BaseName..]);

                /// <summary>
                /// Retrieves the MainAssemblyName field.
                /// </summary>
                public string MainAssemblyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_MainAssemblyName..]);

                /// <summary>
                /// Retrieves the AssemblyName field.
                /// </summary>
                public string AssemblyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_AssemblyName..]);

                /// <summary>
                /// Retrieves the ResourceFileName field.
                /// </summary>
                public string ResourceFileName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ResourceFileName..]);

                /// <summary>
                /// Creates a new ResourceManagerCaseInsensitiveResourceStreamLookupSucceededData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ResourceManagerCaseInsensitiveResourceStreamLookupSucceededData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_BaseName = -1;
                    _offset_MainAssemblyName = -1;
                    _offset_AssemblyName = -1;
                    _offset_ResourceFileName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ResourceManagerCaseInsensitiveResourceStreamLookupFailed event.
        /// </summary>
        public readonly ref struct ResourceManagerCaseInsensitiveResourceStreamLookupFailedEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ResourceManagerCaseInsensitiveResourceStreamLookupFailed";

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
                Level = EtwTraceLevel.Warning,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.ResourceManagerCaseInsensitiveResourceStreamLookupFailed,
                Keyword = (ulong)Keywords.Loader
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
            public ResourceManagerCaseInsensitiveResourceStreamLookupFailedData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ResourceManagerCaseInsensitiveResourceStreamLookupFailedEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ResourceManagerCaseInsensitiveResourceStreamLookupFailedEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ResourceManagerCaseInsensitiveResourceStreamLookupFailed event.
            /// </summary>
            public ref struct ResourceManagerCaseInsensitiveResourceStreamLookupFailedData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_BaseName;
                private int _offset_MainAssemblyName;
                private int _offset_AssemblyName;
                private int _offset_ResourceFileName;

                private int Offset_BaseName
                {
                    get
                    {
                        if (_offset_BaseName == -1)
                        {
                            _offset_BaseName = 0;
                        }

                        return _offset_BaseName;
                    }
                }

                private int Offset_MainAssemblyName
                {
                    get
                    {
                        if (_offset_MainAssemblyName == -1)
                        {
                            _offset_MainAssemblyName = Offset_BaseName + _etwEvent.UnicodeStringLength(Offset_BaseName);
                        }

                        return _offset_MainAssemblyName;
                    }
                }

                private int Offset_AssemblyName
                {
                    get
                    {
                        if (_offset_AssemblyName == -1)
                        {
                            _offset_AssemblyName = Offset_MainAssemblyName + _etwEvent.UnicodeStringLength(Offset_MainAssemblyName);
                        }

                        return _offset_AssemblyName;
                    }
                }

                private int Offset_ResourceFileName
                {
                    get
                    {
                        if (_offset_ResourceFileName == -1)
                        {
                            _offset_ResourceFileName = Offset_AssemblyName + _etwEvent.UnicodeStringLength(Offset_AssemblyName);
                        }

                        return _offset_ResourceFileName;
                    }
                }

                /// <summary>
                /// Retrieves the BaseName field.
                /// </summary>
                public string BaseName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_BaseName..]);

                /// <summary>
                /// Retrieves the MainAssemblyName field.
                /// </summary>
                public string MainAssemblyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_MainAssemblyName..]);

                /// <summary>
                /// Retrieves the AssemblyName field.
                /// </summary>
                public string AssemblyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_AssemblyName..]);

                /// <summary>
                /// Retrieves the ResourceFileName field.
                /// </summary>
                public string ResourceFileName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ResourceFileName..]);

                /// <summary>
                /// Creates a new ResourceManagerCaseInsensitiveResourceStreamLookupFailedData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ResourceManagerCaseInsensitiveResourceStreamLookupFailedData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_BaseName = -1;
                    _offset_MainAssemblyName = -1;
                    _offset_AssemblyName = -1;
                    _offset_ResourceFileName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ResourceManagerManifestResourceAccessDenied event.
        /// </summary>
        public readonly ref struct ResourceManagerManifestResourceAccessDeniedEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ResourceManagerManifestResourceAccessDenied";

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
                Level = EtwTraceLevel.Error,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.ResourceManagerManifestResourceAccessDenied,
                Keyword = (ulong)Keywords.Loader
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
            public ResourceManagerManifestResourceAccessDeniedData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ResourceManagerManifestResourceAccessDeniedEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ResourceManagerManifestResourceAccessDeniedEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ResourceManagerManifestResourceAccessDenied event.
            /// </summary>
            public ref struct ResourceManagerManifestResourceAccessDeniedData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_BaseName;
                private int _offset_MainAssemblyName;
                private int _offset_AssemblyName;
                private int _offset_CanonicalName;

                private int Offset_BaseName
                {
                    get
                    {
                        if (_offset_BaseName == -1)
                        {
                            _offset_BaseName = 0;
                        }

                        return _offset_BaseName;
                    }
                }

                private int Offset_MainAssemblyName
                {
                    get
                    {
                        if (_offset_MainAssemblyName == -1)
                        {
                            _offset_MainAssemblyName = Offset_BaseName + _etwEvent.UnicodeStringLength(Offset_BaseName);
                        }

                        return _offset_MainAssemblyName;
                    }
                }

                private int Offset_AssemblyName
                {
                    get
                    {
                        if (_offset_AssemblyName == -1)
                        {
                            _offset_AssemblyName = Offset_MainAssemblyName + _etwEvent.UnicodeStringLength(Offset_MainAssemblyName);
                        }

                        return _offset_AssemblyName;
                    }
                }

                private int Offset_CanonicalName
                {
                    get
                    {
                        if (_offset_CanonicalName == -1)
                        {
                            _offset_CanonicalName = Offset_AssemblyName + _etwEvent.UnicodeStringLength(Offset_AssemblyName);
                        }

                        return _offset_CanonicalName;
                    }
                }

                /// <summary>
                /// Retrieves the BaseName field.
                /// </summary>
                public string BaseName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_BaseName..]);

                /// <summary>
                /// Retrieves the MainAssemblyName field.
                /// </summary>
                public string MainAssemblyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_MainAssemblyName..]);

                /// <summary>
                /// Retrieves the AssemblyName field.
                /// </summary>
                public string AssemblyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_AssemblyName..]);

                /// <summary>
                /// Retrieves the CanonicalName field.
                /// </summary>
                public string CanonicalName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_CanonicalName..]);

                /// <summary>
                /// Creates a new ResourceManagerManifestResourceAccessDeniedData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ResourceManagerManifestResourceAccessDeniedData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_BaseName = -1;
                    _offset_MainAssemblyName = -1;
                    _offset_AssemblyName = -1;
                    _offset_CanonicalName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ResourceManagerNeutralResourcesSufficient event.
        /// </summary>
        public readonly ref struct ResourceManagerNeutralResourcesSufficientEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ResourceManagerNeutralResourcesSufficient";

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
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.ResourceManagerNeutralResourcesSufficient,
                Keyword = (ulong)Keywords.Loader
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
            public ResourceManagerNeutralResourcesSufficientData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ResourceManagerNeutralResourcesSufficientEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ResourceManagerNeutralResourcesSufficientEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ResourceManagerNeutralResourcesSufficient event.
            /// </summary>
            public ref struct ResourceManagerNeutralResourcesSufficientData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_BaseName;
                private int _offset_MainAssemblyName;
                private int _offset_CultureName;

                private int Offset_BaseName
                {
                    get
                    {
                        if (_offset_BaseName == -1)
                        {
                            _offset_BaseName = 0;
                        }

                        return _offset_BaseName;
                    }
                }

                private int Offset_MainAssemblyName
                {
                    get
                    {
                        if (_offset_MainAssemblyName == -1)
                        {
                            _offset_MainAssemblyName = Offset_BaseName + _etwEvent.UnicodeStringLength(Offset_BaseName);
                        }

                        return _offset_MainAssemblyName;
                    }
                }

                private int Offset_CultureName
                {
                    get
                    {
                        if (_offset_CultureName == -1)
                        {
                            _offset_CultureName = Offset_MainAssemblyName + _etwEvent.UnicodeStringLength(Offset_MainAssemblyName);
                        }

                        return _offset_CultureName;
                    }
                }

                /// <summary>
                /// Retrieves the BaseName field.
                /// </summary>
                public string BaseName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_BaseName..]);

                /// <summary>
                /// Retrieves the MainAssemblyName field.
                /// </summary>
                public string MainAssemblyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_MainAssemblyName..]);

                /// <summary>
                /// Retrieves the CultureName field.
                /// </summary>
                public string CultureName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_CultureName..]);

                /// <summary>
                /// Creates a new ResourceManagerNeutralResourcesSufficientData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ResourceManagerNeutralResourcesSufficientData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_BaseName = -1;
                    _offset_MainAssemblyName = -1;
                    _offset_CultureName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ResourceManagerNeutralResourceAttributeMissing event.
        /// </summary>
        public readonly ref struct ResourceManagerNeutralResourceAttributeMissingEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ResourceManagerNeutralResourceAttributeMissing";

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
                Level = EtwTraceLevel.Warning,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.ResourceManagerNeutralResourceAttributeMissing,
                Keyword = (ulong)Keywords.Loader
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
            public ResourceManagerNeutralResourceAttributeMissingData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ResourceManagerNeutralResourceAttributeMissingEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ResourceManagerNeutralResourceAttributeMissingEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ResourceManagerNeutralResourceAttributeMissing event.
            /// </summary>
            public ref struct ResourceManagerNeutralResourceAttributeMissingData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_MainAssemblyName;

                private int Offset_MainAssemblyName
                {
                    get
                    {
                        if (_offset_MainAssemblyName == -1)
                        {
                            _offset_MainAssemblyName = 0;
                        }

                        return _offset_MainAssemblyName;
                    }
                }

                /// <summary>
                /// Retrieves the MainAssemblyName field.
                /// </summary>
                public string MainAssemblyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_MainAssemblyName..]);

                /// <summary>
                /// Creates a new ResourceManagerNeutralResourceAttributeMissingData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ResourceManagerNeutralResourceAttributeMissingData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_MainAssemblyName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ResourceManagerCreatingResourceSet event.
        /// </summary>
        public readonly ref struct ResourceManagerCreatingResourceSetEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ResourceManagerCreatingResourceSet";

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
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.ResourceManagerCreatingResourceSet,
                Keyword = (ulong)Keywords.Loader
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
            public ResourceManagerCreatingResourceSetData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ResourceManagerCreatingResourceSetEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ResourceManagerCreatingResourceSetEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ResourceManagerCreatingResourceSet event.
            /// </summary>
            public ref struct ResourceManagerCreatingResourceSetData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_BaseName;
                private int _offset_MainAssemblyName;
                private int _offset_CultureName;
                private int _offset_FileName;

                private int Offset_BaseName
                {
                    get
                    {
                        if (_offset_BaseName == -1)
                        {
                            _offset_BaseName = 0;
                        }

                        return _offset_BaseName;
                    }
                }

                private int Offset_MainAssemblyName
                {
                    get
                    {
                        if (_offset_MainAssemblyName == -1)
                        {
                            _offset_MainAssemblyName = Offset_BaseName + _etwEvent.UnicodeStringLength(Offset_BaseName);
                        }

                        return _offset_MainAssemblyName;
                    }
                }

                private int Offset_CultureName
                {
                    get
                    {
                        if (_offset_CultureName == -1)
                        {
                            _offset_CultureName = Offset_MainAssemblyName + _etwEvent.UnicodeStringLength(Offset_MainAssemblyName);
                        }

                        return _offset_CultureName;
                    }
                }

                private int Offset_FileName
                {
                    get
                    {
                        if (_offset_FileName == -1)
                        {
                            _offset_FileName = Offset_CultureName + _etwEvent.UnicodeStringLength(Offset_CultureName);
                        }

                        return _offset_FileName;
                    }
                }

                /// <summary>
                /// Retrieves the BaseName field.
                /// </summary>
                public string BaseName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_BaseName..]);

                /// <summary>
                /// Retrieves the MainAssemblyName field.
                /// </summary>
                public string MainAssemblyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_MainAssemblyName..]);

                /// <summary>
                /// Retrieves the CultureName field.
                /// </summary>
                public string CultureName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_CultureName..]);

                /// <summary>
                /// Retrieves the FileName field.
                /// </summary>
                public string FileName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FileName..]);

                /// <summary>
                /// Creates a new ResourceManagerCreatingResourceSetData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ResourceManagerCreatingResourceSetData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_BaseName = -1;
                    _offset_MainAssemblyName = -1;
                    _offset_CultureName = -1;
                    _offset_FileName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ResourceManagerNotCreatingResourceSet event.
        /// </summary>
        public readonly ref struct ResourceManagerNotCreatingResourceSetEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ResourceManagerNotCreatingResourceSet";

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
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.ResourceManagerNotCreatingResourceSet,
                Keyword = (ulong)Keywords.Loader
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
            public ResourceManagerNotCreatingResourceSetData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ResourceManagerNotCreatingResourceSetEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ResourceManagerNotCreatingResourceSetEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ResourceManagerNotCreatingResourceSet event.
            /// </summary>
            public ref struct ResourceManagerNotCreatingResourceSetData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_BaseName;
                private int _offset_MainAssemblyName;
                private int _offset_CultureName;

                private int Offset_BaseName
                {
                    get
                    {
                        if (_offset_BaseName == -1)
                        {
                            _offset_BaseName = 0;
                        }

                        return _offset_BaseName;
                    }
                }

                private int Offset_MainAssemblyName
                {
                    get
                    {
                        if (_offset_MainAssemblyName == -1)
                        {
                            _offset_MainAssemblyName = Offset_BaseName + _etwEvent.UnicodeStringLength(Offset_BaseName);
                        }

                        return _offset_MainAssemblyName;
                    }
                }

                private int Offset_CultureName
                {
                    get
                    {
                        if (_offset_CultureName == -1)
                        {
                            _offset_CultureName = Offset_MainAssemblyName + _etwEvent.UnicodeStringLength(Offset_MainAssemblyName);
                        }

                        return _offset_CultureName;
                    }
                }

                /// <summary>
                /// Retrieves the BaseName field.
                /// </summary>
                public string BaseName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_BaseName..]);

                /// <summary>
                /// Retrieves the MainAssemblyName field.
                /// </summary>
                public string MainAssemblyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_MainAssemblyName..]);

                /// <summary>
                /// Retrieves the CultureName field.
                /// </summary>
                public string CultureName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_CultureName..]);

                /// <summary>
                /// Creates a new ResourceManagerNotCreatingResourceSetData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ResourceManagerNotCreatingResourceSetData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_BaseName = -1;
                    _offset_MainAssemblyName = -1;
                    _offset_CultureName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ResourceManagerLookupFailed event.
        /// </summary>
        public readonly ref struct ResourceManagerLookupFailedEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ResourceManagerLookupFailed";

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
                Level = EtwTraceLevel.Warning,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.ResourceManagerLookupFailed,
                Keyword = (ulong)Keywords.Loader
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
            public ResourceManagerLookupFailedData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ResourceManagerLookupFailedEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ResourceManagerLookupFailedEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ResourceManagerLookupFailed event.
            /// </summary>
            public ref struct ResourceManagerLookupFailedData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_BaseName;
                private int _offset_MainAssemblyName;
                private int _offset_CultureName;

                private int Offset_BaseName
                {
                    get
                    {
                        if (_offset_BaseName == -1)
                        {
                            _offset_BaseName = 0;
                        }

                        return _offset_BaseName;
                    }
                }

                private int Offset_MainAssemblyName
                {
                    get
                    {
                        if (_offset_MainAssemblyName == -1)
                        {
                            _offset_MainAssemblyName = Offset_BaseName + _etwEvent.UnicodeStringLength(Offset_BaseName);
                        }

                        return _offset_MainAssemblyName;
                    }
                }

                private int Offset_CultureName
                {
                    get
                    {
                        if (_offset_CultureName == -1)
                        {
                            _offset_CultureName = Offset_MainAssemblyName + _etwEvent.UnicodeStringLength(Offset_MainAssemblyName);
                        }

                        return _offset_CultureName;
                    }
                }

                /// <summary>
                /// Retrieves the BaseName field.
                /// </summary>
                public string BaseName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_BaseName..]);

                /// <summary>
                /// Retrieves the MainAssemblyName field.
                /// </summary>
                public string MainAssemblyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_MainAssemblyName..]);

                /// <summary>
                /// Retrieves the CultureName field.
                /// </summary>
                public string CultureName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_CultureName..]);

                /// <summary>
                /// Creates a new ResourceManagerLookupFailedData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ResourceManagerLookupFailedData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_BaseName = -1;
                    _offset_MainAssemblyName = -1;
                    _offset_CultureName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ResourceManagerReleasingResources event.
        /// </summary>
        public readonly ref struct ResourceManagerReleasingResourcesEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ResourceManagerReleasingResources";

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
                Task = (ushort)Tasks.ResourceManagerReleasingResources,
                Keyword = (ulong)Keywords.Loader
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
            public ResourceManagerReleasingResourcesData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ResourceManagerReleasingResourcesEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ResourceManagerReleasingResourcesEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ResourceManagerReleasingResources event.
            /// </summary>
            public ref struct ResourceManagerReleasingResourcesData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_BaseName;
                private int _offset_MainAssemblyName;

                private int Offset_BaseName
                {
                    get
                    {
                        if (_offset_BaseName == -1)
                        {
                            _offset_BaseName = 0;
                        }

                        return _offset_BaseName;
                    }
                }

                private int Offset_MainAssemblyName
                {
                    get
                    {
                        if (_offset_MainAssemblyName == -1)
                        {
                            _offset_MainAssemblyName = Offset_BaseName + _etwEvent.UnicodeStringLength(Offset_BaseName);
                        }

                        return _offset_MainAssemblyName;
                    }
                }

                /// <summary>
                /// Retrieves the BaseName field.
                /// </summary>
                public string BaseName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_BaseName..]);

                /// <summary>
                /// Retrieves the MainAssemblyName field.
                /// </summary>
                public string MainAssemblyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_MainAssemblyName..]);

                /// <summary>
                /// Creates a new ResourceManagerReleasingResourcesData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ResourceManagerReleasingResourcesData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_BaseName = -1;
                    _offset_MainAssemblyName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ResourceManagerNeutralResourcesNotFound event.
        /// </summary>
        public readonly ref struct ResourceManagerNeutralResourcesNotFoundEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ResourceManagerNeutralResourcesNotFound";

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
                Level = EtwTraceLevel.Warning,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.ResourceManagerNeutralResourcesNotFound,
                Keyword = (ulong)Keywords.Loader
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
            public ResourceManagerNeutralResourcesNotFoundData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ResourceManagerNeutralResourcesNotFoundEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ResourceManagerNeutralResourcesNotFoundEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ResourceManagerNeutralResourcesNotFound event.
            /// </summary>
            public ref struct ResourceManagerNeutralResourcesNotFoundData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_BaseName;
                private int _offset_MainAssemblyName;
                private int _offset_ResName;

                private int Offset_BaseName
                {
                    get
                    {
                        if (_offset_BaseName == -1)
                        {
                            _offset_BaseName = 0;
                        }

                        return _offset_BaseName;
                    }
                }

                private int Offset_MainAssemblyName
                {
                    get
                    {
                        if (_offset_MainAssemblyName == -1)
                        {
                            _offset_MainAssemblyName = Offset_BaseName + _etwEvent.UnicodeStringLength(Offset_BaseName);
                        }

                        return _offset_MainAssemblyName;
                    }
                }

                private int Offset_ResName
                {
                    get
                    {
                        if (_offset_ResName == -1)
                        {
                            _offset_ResName = Offset_MainAssemblyName + _etwEvent.UnicodeStringLength(Offset_MainAssemblyName);
                        }

                        return _offset_ResName;
                    }
                }

                /// <summary>
                /// Retrieves the BaseName field.
                /// </summary>
                public string BaseName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_BaseName..]);

                /// <summary>
                /// Retrieves the MainAssemblyName field.
                /// </summary>
                public string MainAssemblyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_MainAssemblyName..]);

                /// <summary>
                /// Retrieves the ResName field.
                /// </summary>
                public string ResName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ResName..]);

                /// <summary>
                /// Creates a new ResourceManagerNeutralResourcesNotFoundData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ResourceManagerNeutralResourcesNotFoundData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_BaseName = -1;
                    _offset_MainAssemblyName = -1;
                    _offset_ResName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ResourceManagerNeutralResourcesFound event.
        /// </summary>
        public readonly ref struct ResourceManagerNeutralResourcesFoundEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ResourceManagerNeutralResourcesFound";

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
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.ResourceManagerNeutralResourcesFound,
                Keyword = (ulong)Keywords.Loader
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
            public ResourceManagerNeutralResourcesFoundData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ResourceManagerNeutralResourcesFoundEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ResourceManagerNeutralResourcesFoundEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ResourceManagerNeutralResourcesFound event.
            /// </summary>
            public ref struct ResourceManagerNeutralResourcesFoundData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_BaseName;
                private int _offset_MainAssemblyName;
                private int _offset_ResName;

                private int Offset_BaseName
                {
                    get
                    {
                        if (_offset_BaseName == -1)
                        {
                            _offset_BaseName = 0;
                        }

                        return _offset_BaseName;
                    }
                }

                private int Offset_MainAssemblyName
                {
                    get
                    {
                        if (_offset_MainAssemblyName == -1)
                        {
                            _offset_MainAssemblyName = Offset_BaseName + _etwEvent.UnicodeStringLength(Offset_BaseName);
                        }

                        return _offset_MainAssemblyName;
                    }
                }

                private int Offset_ResName
                {
                    get
                    {
                        if (_offset_ResName == -1)
                        {
                            _offset_ResName = Offset_MainAssemblyName + _etwEvent.UnicodeStringLength(Offset_MainAssemblyName);
                        }

                        return _offset_ResName;
                    }
                }

                /// <summary>
                /// Retrieves the BaseName field.
                /// </summary>
                public string BaseName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_BaseName..]);

                /// <summary>
                /// Retrieves the MainAssemblyName field.
                /// </summary>
                public string MainAssemblyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_MainAssemblyName..]);

                /// <summary>
                /// Retrieves the ResName field.
                /// </summary>
                public string ResName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ResName..]);

                /// <summary>
                /// Creates a new ResourceManagerNeutralResourcesFoundData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ResourceManagerNeutralResourcesFoundData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_BaseName = -1;
                    _offset_MainAssemblyName = -1;
                    _offset_ResName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ResourceManagerAddingCultureFromConfigFile event.
        /// </summary>
        public readonly ref struct ResourceManagerAddingCultureFromConfigFileEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ResourceManagerAddingCultureFromConfigFile";

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
                Task = (ushort)Tasks.ResourceManagerAddingCultureFromConfigFile,
                Keyword = (ulong)Keywords.Loader
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
            public ResourceManagerAddingCultureFromConfigFileData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ResourceManagerAddingCultureFromConfigFileEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ResourceManagerAddingCultureFromConfigFileEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ResourceManagerAddingCultureFromConfigFile event.
            /// </summary>
            public ref struct ResourceManagerAddingCultureFromConfigFileData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_BaseName;
                private int _offset_MainAssemblyName;
                private int _offset_CultureName;

                private int Offset_BaseName
                {
                    get
                    {
                        if (_offset_BaseName == -1)
                        {
                            _offset_BaseName = 0;
                        }

                        return _offset_BaseName;
                    }
                }

                private int Offset_MainAssemblyName
                {
                    get
                    {
                        if (_offset_MainAssemblyName == -1)
                        {
                            _offset_MainAssemblyName = Offset_BaseName + _etwEvent.UnicodeStringLength(Offset_BaseName);
                        }

                        return _offset_MainAssemblyName;
                    }
                }

                private int Offset_CultureName
                {
                    get
                    {
                        if (_offset_CultureName == -1)
                        {
                            _offset_CultureName = Offset_MainAssemblyName + _etwEvent.UnicodeStringLength(Offset_MainAssemblyName);
                        }

                        return _offset_CultureName;
                    }
                }

                /// <summary>
                /// Retrieves the BaseName field.
                /// </summary>
                public string BaseName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_BaseName..]);

                /// <summary>
                /// Retrieves the MainAssemblyName field.
                /// </summary>
                public string MainAssemblyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_MainAssemblyName..]);

                /// <summary>
                /// Retrieves the CultureName field.
                /// </summary>
                public string CultureName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_CultureName..]);

                /// <summary>
                /// Creates a new ResourceManagerAddingCultureFromConfigFileData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ResourceManagerAddingCultureFromConfigFileData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_BaseName = -1;
                    _offset_MainAssemblyName = -1;
                    _offset_CultureName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ResourceManagerCultureNotFoundInConfigFile event.
        /// </summary>
        public readonly ref struct ResourceManagerCultureNotFoundInConfigFileEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ResourceManagerCultureNotFoundInConfigFile";

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
                Task = (ushort)Tasks.ResourceManagerCultureNotFoundInConfigFile,
                Keyword = (ulong)Keywords.Loader
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
            public ResourceManagerCultureNotFoundInConfigFileData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ResourceManagerCultureNotFoundInConfigFileEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ResourceManagerCultureNotFoundInConfigFileEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ResourceManagerCultureNotFoundInConfigFile event.
            /// </summary>
            public ref struct ResourceManagerCultureNotFoundInConfigFileData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_BaseName;
                private int _offset_MainAssemblyName;
                private int _offset_CultureName;

                private int Offset_BaseName
                {
                    get
                    {
                        if (_offset_BaseName == -1)
                        {
                            _offset_BaseName = 0;
                        }

                        return _offset_BaseName;
                    }
                }

                private int Offset_MainAssemblyName
                {
                    get
                    {
                        if (_offset_MainAssemblyName == -1)
                        {
                            _offset_MainAssemblyName = Offset_BaseName + _etwEvent.UnicodeStringLength(Offset_BaseName);
                        }

                        return _offset_MainAssemblyName;
                    }
                }

                private int Offset_CultureName
                {
                    get
                    {
                        if (_offset_CultureName == -1)
                        {
                            _offset_CultureName = Offset_MainAssemblyName + _etwEvent.UnicodeStringLength(Offset_MainAssemblyName);
                        }

                        return _offset_CultureName;
                    }
                }

                /// <summary>
                /// Retrieves the BaseName field.
                /// </summary>
                public string BaseName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_BaseName..]);

                /// <summary>
                /// Retrieves the MainAssemblyName field.
                /// </summary>
                public string MainAssemblyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_MainAssemblyName..]);

                /// <summary>
                /// Retrieves the CultureName field.
                /// </summary>
                public string CultureName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_CultureName..]);

                /// <summary>
                /// Creates a new ResourceManagerCultureNotFoundInConfigFileData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ResourceManagerCultureNotFoundInConfigFileData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_BaseName = -1;
                    _offset_MainAssemblyName = -1;
                    _offset_CultureName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ResourceManagerCultureFoundInConfigFile event.
        /// </summary>
        public readonly ref struct ResourceManagerCultureFoundInConfigFileEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ResourceManagerCultureFoundInConfigFile";

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
                Task = (ushort)Tasks.ResourceManagerCultureFoundInConfigFile,
                Keyword = (ulong)Keywords.Loader
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
            public ResourceManagerCultureFoundInConfigFileData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ResourceManagerCultureFoundInConfigFileEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ResourceManagerCultureFoundInConfigFileEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ResourceManagerCultureFoundInConfigFile event.
            /// </summary>
            public ref struct ResourceManagerCultureFoundInConfigFileData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_BaseName;
                private int _offset_MainAssemblyName;
                private int _offset_CultureName;

                private int Offset_BaseName
                {
                    get
                    {
                        if (_offset_BaseName == -1)
                        {
                            _offset_BaseName = 0;
                        }

                        return _offset_BaseName;
                    }
                }

                private int Offset_MainAssemblyName
                {
                    get
                    {
                        if (_offset_MainAssemblyName == -1)
                        {
                            _offset_MainAssemblyName = Offset_BaseName + _etwEvent.UnicodeStringLength(Offset_BaseName);
                        }

                        return _offset_MainAssemblyName;
                    }
                }

                private int Offset_CultureName
                {
                    get
                    {
                        if (_offset_CultureName == -1)
                        {
                            _offset_CultureName = Offset_MainAssemblyName + _etwEvent.UnicodeStringLength(Offset_MainAssemblyName);
                        }

                        return _offset_CultureName;
                    }
                }

                /// <summary>
                /// Retrieves the BaseName field.
                /// </summary>
                public string BaseName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_BaseName..]);

                /// <summary>
                /// Retrieves the MainAssemblyName field.
                /// </summary>
                public string MainAssemblyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_MainAssemblyName..]);

                /// <summary>
                /// Retrieves the CultureName field.
                /// </summary>
                public string CultureName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_CultureName..]);

                /// <summary>
                /// Creates a new ResourceManagerCultureFoundInConfigFileData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ResourceManagerCultureFoundInConfigFileData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_BaseName = -1;
                    _offset_MainAssemblyName = -1;
                    _offset_CultureName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ThreadPoolEnqueueWork event.
        /// </summary>
        public readonly ref struct ThreadPoolEnqueueWorkEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ThreadPoolEnqueueWork";

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
                Level = EtwTraceLevel.Verbose,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.ThreadPoolEnqueueWork,
                Keyword = (ulong)Keywords.ThreadPool | (ulong)Keywords.ThreadTransfer
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
            public ThreadPoolEnqueueWorkData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ThreadPoolEnqueueWorkEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ThreadPoolEnqueueWorkEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ThreadPoolEnqueueWork event.
            /// </summary>
            public ref struct ThreadPoolEnqueueWorkData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_WorkID;

                private int Offset_WorkID
                {
                    get
                    {
                        if (_offset_WorkID == -1)
                        {
                            _offset_WorkID = 0;
                        }

                        return _offset_WorkID;
                    }
                }

                /// <summary>
                /// Retrieves the WorkID field.
                /// </summary>
                public long WorkID => BitConverter.ToInt64(_etwEvent.Data[Offset_WorkID..]);

                /// <summary>
                /// Creates a new ThreadPoolEnqueueWorkData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ThreadPoolEnqueueWorkData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_WorkID = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ThreadPoolDequeueWork event.
        /// </summary>
        public readonly ref struct ThreadPoolDequeueWorkEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ThreadPoolDequeueWork";

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
                Level = EtwTraceLevel.Verbose,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.ThreadPoolDequeueWork,
                Keyword = (ulong)Keywords.ThreadPool | (ulong)Keywords.ThreadTransfer
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
            public ThreadPoolDequeueWorkData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ThreadPoolDequeueWorkEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ThreadPoolDequeueWorkEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ThreadPoolDequeueWork event.
            /// </summary>
            public ref struct ThreadPoolDequeueWorkData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_WorkID;

                private int Offset_WorkID
                {
                    get
                    {
                        if (_offset_WorkID == -1)
                        {
                            _offset_WorkID = 0;
                        }

                        return _offset_WorkID;
                    }
                }

                /// <summary>
                /// Retrieves the WorkID field.
                /// </summary>
                public long WorkID => BitConverter.ToInt64(_etwEvent.Data[Offset_WorkID..]);

                /// <summary>
                /// Creates a new ThreadPoolDequeueWorkData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ThreadPoolDequeueWorkData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_WorkID = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a GetResponseStart event.
        /// </summary>
        public readonly ref struct GetResponseStartEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "GetResponseStart";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 140,
                Version = 1,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Start,
                Task = (ushort)Tasks.GetResponse,
                Keyword = (ulong)Keywords.NetClient
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
            public GetResponseStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new GetResponseStartEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public GetResponseStartEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a GetResponseStart event.
            /// </summary>
            public ref struct GetResponseStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Id;
                private int _offset_Uri;
                private int _offset_Success;
                private int _offset_Synchronous;

                private int Offset_Id
                {
                    get
                    {
                        if (_offset_Id == -1)
                        {
                            _offset_Id = 0;
                        }

                        return _offset_Id;
                    }
                }

                private int Offset_Uri
                {
                    get
                    {
                        if (_offset_Uri == -1)
                        {
                            _offset_Uri = Offset_Id + 8;
                        }

                        return _offset_Uri;
                    }
                }

                private int Offset_Success
                {
                    get
                    {
                        if (_offset_Success == -1)
                        {
                            _offset_Success = Offset_Uri + _etwEvent.UnicodeStringLength(Offset_Uri);
                        }

                        return _offset_Success;
                    }
                }

                private int Offset_Synchronous
                {
                    get
                    {
                        if (_offset_Synchronous == -1)
                        {
                            _offset_Synchronous = Offset_Success + 1;
                        }

                        return _offset_Synchronous;
                    }
                }

                /// <summary>
                /// Retrieves the Id field.
                /// </summary>
                public long Id => BitConverter.ToInt64(_etwEvent.Data[Offset_Id..]);

                /// <summary>
                /// Retrieves the Uri field.
                /// </summary>
                public string Uri => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Uri..]);

                /// <summary>
                /// Retrieves the Success field.
                /// </summary>
                public bool Success => _etwEvent.Data[Offset_Success] != 0;

                /// <summary>
                /// Retrieves the Synchronous field.
                /// </summary>
                public bool Synchronous => _etwEvent.Data[Offset_Synchronous] != 0;

                /// <summary>
                /// Creates a new GetResponseStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public GetResponseStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Id = -1;
                    _offset_Uri = -1;
                    _offset_Success = -1;
                    _offset_Synchronous = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a GetResponseStop event.
        /// </summary>
        public readonly ref struct GetResponseStopEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "GetResponseStop";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 141,
                Version = 1,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.End,
                Task = (ushort)Tasks.GetResponse,
                Keyword = (ulong)Keywords.NetClient
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
            public GetResponseStopData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new GetResponseStopEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public GetResponseStopEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a GetResponseStop event.
            /// </summary>
            public ref struct GetResponseStopData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Id;
                private int _offset_Success;
                private int _offset_Synchronous;
                private int _offset_StatusCode;

                private int Offset_Id
                {
                    get
                    {
                        if (_offset_Id == -1)
                        {
                            _offset_Id = 0;
                        }

                        return _offset_Id;
                    }
                }

                private int Offset_Success
                {
                    get
                    {
                        if (_offset_Success == -1)
                        {
                            _offset_Success = Offset_Id + 8;
                        }

                        return _offset_Success;
                    }
                }

                private int Offset_Synchronous
                {
                    get
                    {
                        if (_offset_Synchronous == -1)
                        {
                            _offset_Synchronous = Offset_Success + 1;
                        }

                        return _offset_Synchronous;
                    }
                }

                private int Offset_StatusCode
                {
                    get
                    {
                        if (_offset_StatusCode == -1)
                        {
                            _offset_StatusCode = Offset_Synchronous + 1;
                        }

                        return _offset_StatusCode;
                    }
                }

                /// <summary>
                /// Retrieves the Id field.
                /// </summary>
                public long Id => BitConverter.ToInt64(_etwEvent.Data[Offset_Id..]);

                /// <summary>
                /// Retrieves the Success field.
                /// </summary>
                public bool Success => _etwEvent.Data[Offset_Success] != 0;

                /// <summary>
                /// Retrieves the Synchronous field.
                /// </summary>
                public bool Synchronous => _etwEvent.Data[Offset_Synchronous] != 0;

                /// <summary>
                /// Retrieves the StatusCode field.
                /// </summary>
                public int StatusCode => BitConverter.ToInt32(_etwEvent.Data[Offset_StatusCode..]);

                /// <summary>
                /// Creates a new GetResponseStopData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public GetResponseStopData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Id = -1;
                    _offset_Success = -1;
                    _offset_Synchronous = -1;
                    _offset_StatusCode = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a GetRequestStreamStart event.
        /// </summary>
        public readonly ref struct GetRequestStreamStartEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "GetRequestStreamStart";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 142,
                Version = 1,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Start,
                Task = (ushort)Tasks.GetRequestStream,
                Keyword = (ulong)Keywords.NetClient
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
            public GetRequestStreamStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new GetRequestStreamStartEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public GetRequestStreamStartEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a GetRequestStreamStart event.
            /// </summary>
            public ref struct GetRequestStreamStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Id;
                private int _offset_Uri;
                private int _offset_Success;
                private int _offset_Synchronous;

                private int Offset_Id
                {
                    get
                    {
                        if (_offset_Id == -1)
                        {
                            _offset_Id = 0;
                        }

                        return _offset_Id;
                    }
                }

                private int Offset_Uri
                {
                    get
                    {
                        if (_offset_Uri == -1)
                        {
                            _offset_Uri = Offset_Id + 8;
                        }

                        return _offset_Uri;
                    }
                }

                private int Offset_Success
                {
                    get
                    {
                        if (_offset_Success == -1)
                        {
                            _offset_Success = Offset_Uri + _etwEvent.UnicodeStringLength(Offset_Uri);
                        }

                        return _offset_Success;
                    }
                }

                private int Offset_Synchronous
                {
                    get
                    {
                        if (_offset_Synchronous == -1)
                        {
                            _offset_Synchronous = Offset_Success + 1;
                        }

                        return _offset_Synchronous;
                    }
                }

                /// <summary>
                /// Retrieves the Id field.
                /// </summary>
                public long Id => BitConverter.ToInt64(_etwEvent.Data[Offset_Id..]);

                /// <summary>
                /// Retrieves the Uri field.
                /// </summary>
                public string Uri => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Uri..]);

                /// <summary>
                /// Retrieves the Success field.
                /// </summary>
                public bool Success => _etwEvent.Data[Offset_Success] != 0;

                /// <summary>
                /// Retrieves the Synchronous field.
                /// </summary>
                public bool Synchronous => _etwEvent.Data[Offset_Synchronous] != 0;

                /// <summary>
                /// Creates a new GetRequestStreamStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public GetRequestStreamStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Id = -1;
                    _offset_Uri = -1;
                    _offset_Success = -1;
                    _offset_Synchronous = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a GetRequestStreamStop event.
        /// </summary>
        public readonly ref struct GetRequestStreamStopEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "GetRequestStreamStop";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 143,
                Version = 1,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.End,
                Task = (ushort)Tasks.GetRequestStream,
                Keyword = (ulong)Keywords.NetClient
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
            public GetRequestStreamStopData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new GetRequestStreamStopEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public GetRequestStreamStopEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a GetRequestStreamStop event.
            /// </summary>
            public ref struct GetRequestStreamStopData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Id;
                private int _offset_Success;
                private int _offset_Synchronous;

                private int Offset_Id
                {
                    get
                    {
                        if (_offset_Id == -1)
                        {
                            _offset_Id = 0;
                        }

                        return _offset_Id;
                    }
                }

                private int Offset_Success
                {
                    get
                    {
                        if (_offset_Success == -1)
                        {
                            _offset_Success = Offset_Id + 8;
                        }

                        return _offset_Success;
                    }
                }

                private int Offset_Synchronous
                {
                    get
                    {
                        if (_offset_Synchronous == -1)
                        {
                            _offset_Synchronous = Offset_Success + 1;
                        }

                        return _offset_Synchronous;
                    }
                }

                /// <summary>
                /// Retrieves the Id field.
                /// </summary>
                public long Id => BitConverter.ToInt64(_etwEvent.Data[Offset_Id..]);

                /// <summary>
                /// Retrieves the Success field.
                /// </summary>
                public bool Success => _etwEvent.Data[Offset_Success] != 0;

                /// <summary>
                /// Retrieves the Synchronous field.
                /// </summary>
                public bool Synchronous => _etwEvent.Data[Offset_Synchronous] != 0;

                /// <summary>
                /// Creates a new GetRequestStreamStopData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public GetRequestStreamStopData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Id = -1;
                    _offset_Success = -1;
                    _offset_Synchronous = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ThreadTransferSend event.
        /// </summary>
        public readonly ref struct ThreadTransferSendEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ThreadTransferSend";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 150,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Send,
                Task = (ushort)Tasks.ThreadTransfer,
                Keyword = (ulong)Keywords.ThreadTransfer
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
            public ThreadTransferSendData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ThreadTransferSendEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ThreadTransferSendEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ThreadTransferSend event.
            /// </summary>
            public ref struct ThreadTransferSendData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Id;
                private int _offset_Kind;
                private int _offset_Info;
                private int _offset_MultiDequeues;

                private int Offset_Id
                {
                    get
                    {
                        if (_offset_Id == -1)
                        {
                            _offset_Id = 0;
                        }

                        return _offset_Id;
                    }
                }

                private int Offset_Kind
                {
                    get
                    {
                        if (_offset_Kind == -1)
                        {
                            _offset_Kind = Offset_Id + 8;
                        }

                        return _offset_Kind;
                    }
                }

                private int Offset_Info
                {
                    get
                    {
                        if (_offset_Info == -1)
                        {
                            _offset_Info = Offset_Kind + 4;
                        }

                        return _offset_Info;
                    }
                }

                private int Offset_MultiDequeues
                {
                    get
                    {
                        if (_offset_MultiDequeues == -1)
                        {
                            _offset_MultiDequeues = Offset_Info + _etwEvent.UnicodeStringLength(Offset_Info);
                        }

                        return _offset_MultiDequeues;
                    }
                }

                /// <summary>
                /// Retrieves the Id field.
                /// </summary>
                public long Id => BitConverter.ToInt64(_etwEvent.Data[Offset_Id..]);

                /// <summary>
                /// Retrieves the Kind field.
                /// </summary>
                public int Kind => BitConverter.ToInt32(_etwEvent.Data[Offset_Kind..]);

                /// <summary>
                /// Retrieves the Info field.
                /// </summary>
                public string Info => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Info..]);

                /// <summary>
                /// Retrieves the MultiDequeues field.
                /// </summary>
                public bool MultiDequeues => _etwEvent.Data[Offset_MultiDequeues] != 0;

                /// <summary>
                /// Creates a new ThreadTransferSendData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ThreadTransferSendData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Id = -1;
                    _offset_Kind = -1;
                    _offset_Info = -1;
                    _offset_MultiDequeues = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ThreadTransferReceive event.
        /// </summary>
        public readonly ref struct ThreadTransferReceiveEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ThreadTransferReceive";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 151,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Recieve,
                Task = (ushort)Tasks.ThreadTransfer,
                Keyword = (ulong)Keywords.ThreadTransfer
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
            public ThreadTransferReceiveData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ThreadTransferReceiveEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ThreadTransferReceiveEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ThreadTransferReceive event.
            /// </summary>
            public ref struct ThreadTransferReceiveData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Id;
                private int _offset_Kind;
                private int _offset_Info;

                private int Offset_Id
                {
                    get
                    {
                        if (_offset_Id == -1)
                        {
                            _offset_Id = 0;
                        }

                        return _offset_Id;
                    }
                }

                private int Offset_Kind
                {
                    get
                    {
                        if (_offset_Kind == -1)
                        {
                            _offset_Kind = Offset_Id + 8;
                        }

                        return _offset_Kind;
                    }
                }

                private int Offset_Info
                {
                    get
                    {
                        if (_offset_Info == -1)
                        {
                            _offset_Info = Offset_Kind + 4;
                        }

                        return _offset_Info;
                    }
                }

                /// <summary>
                /// Retrieves the Id field.
                /// </summary>
                public long Id => BitConverter.ToInt64(_etwEvent.Data[Offset_Id..]);

                /// <summary>
                /// Retrieves the Kind field.
                /// </summary>
                public int Kind => BitConverter.ToInt32(_etwEvent.Data[Offset_Kind..]);

                /// <summary>
                /// Retrieves the Info field.
                /// </summary>
                public string Info => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Info..]);

                /// <summary>
                /// Creates a new ThreadTransferReceiveData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ThreadTransferReceiveData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Id = -1;
                    _offset_Kind = -1;
                    _offset_Info = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ThreadTransferReceiveHandled event.
        /// </summary>
        public readonly ref struct ThreadTransferReceiveHandledEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ThreadTransferReceiveHandled";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 152,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = (EtwEventOpcode)Opcodes.ReceiveHandled,
                Task = (ushort)Tasks.ThreadTransfer,
                Keyword = (ulong)Keywords.ThreadTransfer
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
            public ThreadTransferReceiveHandledData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ThreadTransferReceiveHandledEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ThreadTransferReceiveHandledEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ThreadTransferReceiveHandled event.
            /// </summary>
            public ref struct ThreadTransferReceiveHandledData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Id;
                private int _offset_Kind;
                private int _offset_Info;

                private int Offset_Id
                {
                    get
                    {
                        if (_offset_Id == -1)
                        {
                            _offset_Id = 0;
                        }

                        return _offset_Id;
                    }
                }

                private int Offset_Kind
                {
                    get
                    {
                        if (_offset_Kind == -1)
                        {
                            _offset_Kind = Offset_Id + 8;
                        }

                        return _offset_Kind;
                    }
                }

                private int Offset_Info
                {
                    get
                    {
                        if (_offset_Info == -1)
                        {
                            _offset_Info = Offset_Kind + 4;
                        }

                        return _offset_Info;
                    }
                }

                /// <summary>
                /// Retrieves the Id field.
                /// </summary>
                public long Id => BitConverter.ToInt64(_etwEvent.Data[Offset_Id..]);

                /// <summary>
                /// Retrieves the Kind field.
                /// </summary>
                public int Kind => BitConverter.ToInt32(_etwEvent.Data[Offset_Kind..]);

                /// <summary>
                /// Retrieves the Info field.
                /// </summary>
                public string Info => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Info..]);

                /// <summary>
                /// Creates a new ThreadTransferReceiveHandledData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ThreadTransferReceiveHandledData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Id = -1;
                    _offset_Kind = -1;
                    _offset_Info = -1;
                }
            }

        }
    }
}
