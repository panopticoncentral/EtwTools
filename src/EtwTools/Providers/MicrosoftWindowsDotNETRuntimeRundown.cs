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
    /// Provider for Microsoft-Windows-DotNETRuntimeRundown (a669021c-c450-4609-a035-5af59af4df18)
    /// </summary>
    public sealed class MicrosoftWindowsDotNETRuntimeRundownProvider
    {
        /// <summary>s
        /// Provider ID.
        /// </summary>
        public static readonly Guid Id = new("a669021c-c450-4609-a035-5af59af4df18");

        /// <summary>
        /// Provider name.
        /// </summary>
        public const string Name = "Microsoft-Windows-DotNETRuntimeRundown";

        /// <summary>
        /// Tasks supported by Microsoft-Windows-DotNETRuntimeRundown.
        /// </summary>
        public enum Tasks : ushort
        {
            /// <summary>
            /// 'Method' task.
            /// </summary>
            Method = 1,
            /// <summary>
            /// 'Loader' task.
            /// </summary>
            Loader = 2,
            /// <summary>
            /// 'ClrStack' task.
            /// </summary>
            ClrStack = 11,
            /// <summary>
            /// 'Runtime' task.
            /// </summary>
            Runtime = 19,
            /// <summary>
            /// 'ClrPerfTrack' task.
            /// </summary>
            ClrPerfTrack = 20,
        }

        /// <summary>
        /// Opcodes supported by MicrosoftWindowsDotNETRuntimeRundown.
        /// </summary>
        public enum Opcodes
        {
            /// <summary>
            /// 'ModuleRangeDCStart' opcode.
            /// </summary>
            ModuleRangeDCStart = 10,
            /// <summary>
            /// 'ModuleRangeDCEnd' opcode.
            /// </summary>
            ModuleRangeDCEnd = 11,
            /// <summary>
            /// 'DCStartComplete' opcode.
            /// </summary>
            DCStartComplete = 14,
            /// <summary>
            /// 'DCStopComplete' opcode.
            /// </summary>
            DCStopComplete = 15,
            /// <summary>
            /// 'DCStartInit' opcode.
            /// </summary>
            DCStartInit = 16,
            /// <summary>
            /// 'DCStopInit' opcode.
            /// </summary>
            DCStopInit = 17,
            /// <summary>
            /// 'DCStart' opcode.
            /// </summary>
            DCStart = 35,
            /// <summary>
            /// 'DCStop' opcode.
            /// </summary>
            DCStop = 36,
            /// <summary>
            /// 'DCStartVerbose' opcode.
            /// </summary>
            DCStartVerbose = 39,
            /// <summary>
            /// 'DCStopVerbose' opcode.
            /// </summary>
            DCStopVerbose = 40,
            /// <summary>
            /// 'MethodDCStartILToNativeMap' opcode.
            /// </summary>
            MethodDCStartILToNativeMap = 41,
            /// <summary>
            /// 'MethodDCEndILToNativeMap' opcode.
            /// </summary>
            MethodDCEndILToNativeMap = 42,
            /// <summary>
            /// 'AppDomainDCStart' opcode.
            /// </summary>
            AppDomainDCStart = 43,
            /// <summary>
            /// 'AppDomainDCStop' opcode.
            /// </summary>
            AppDomainDCStop = 44,
            /// <summary>
            /// 'DomainModuleDCStart' opcode.
            /// </summary>
            DomainModuleDCStart = 46,
            /// <summary>
            /// 'DomainModuleDCStop' opcode.
            /// </summary>
            DomainModuleDCStop = 47,
            /// <summary>
            /// 'ThreadDCStop' opcode.
            /// </summary>
            ThreadDCStop = 48,
            /// <summary>
            /// 'Walk' opcode.
            /// </summary>
            Walk = 82,
        }

        /// <summary>
        /// Keywords supported by MicrosoftWindowsDotNETRuntimeRundown.
        /// </summary>
        [Flags]
        public enum Keywords : ulong
        {
            /// <summary>
            /// 'LoaderRundownKeyword' keyword.
            /// </summary>
            LoaderRundownKeyword = 0x0000000000000008,
            /// <summary>
            /// 'JitRundownKeyword' keyword.
            /// </summary>
            JitRundownKeyword = 0x0000000000000010,
            /// <summary>
            /// 'NGenRundownKeyword' keyword.
            /// </summary>
            NGenRundownKeyword = 0x0000000000000020,
            /// <summary>
            /// 'StartRundownKeyword' keyword.
            /// </summary>
            StartRundownKeyword = 0x0000000000000040,
            /// <summary>
            /// 'EndRundownKeyword' keyword.
            /// </summary>
            EndRundownKeyword = 0x0000000000000100,
            /// <summary>
            /// 'AppDomainResourceManagementRundownKeyword' keyword.
            /// </summary>
            AppDomainResourceManagementRundownKeyword = 0x0000000000000800,
            /// <summary>
            /// 'ThreadingKeyword' keyword.
            /// </summary>
            ThreadingKeyword = 0x0000000000010000,
            /// <summary>
            /// 'JittedMethodILToNativeMapRundownKeyword' keyword.
            /// </summary>
            JittedMethodILToNativeMapRundownKeyword = 0x0000000000020000,
            /// <summary>
            /// 'OverrideAndSuppressNGenEventsRundownKeyword' keyword.
            /// </summary>
            OverrideAndSuppressNGenEventsRundownKeyword = 0x0000000000040000,
            /// <summary>
            /// 'PerfTrackRundownKeyword' keyword.
            /// </summary>
            PerfTrackRundownKeyword = 0x0000000020000000,
            /// <summary>
            /// 'StackKeyword' keyword.
            /// </summary>
            StackKeyword = 0x0000000040000000,
        }

        /// <summary>
        /// An event wrapper for a ClrStackWalk event.
        /// </summary>
        public readonly ref struct ClrStackWalkEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ClrStackWalk";

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
                Opcode = (EtwEventOpcode)Opcodes.Walk,
                Task = (ushort)Tasks.ClrStack,
                Keyword = (ulong)Keywords.StackKeyword
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

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
            public ClrStackWalkData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ClrStackWalkEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ClrStackWalkEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ClrStackWalk event.
            /// </summary>
            public ref struct ClrStackWalkData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ClrInstanceID;
                private int _offset_Reserved1;
                private int _offset_Reserved2;
                private int _offset_FrameCount;
                private int _offset_Stack;

                private int Offset_ClrInstanceID
                {
                    get
                    {
                        if (_offset_ClrInstanceID == -1)
                        {
                            _offset_ClrInstanceID = 0;
                        }

                        return _offset_ClrInstanceID;
                    }
                }

                private int Offset_Reserved1
                {
                    get
                    {
                        if (_offset_Reserved1 == -1)
                        {
                            _offset_Reserved1 = Offset_ClrInstanceID + 2;
                        }

                        return _offset_Reserved1;
                    }
                }

                private int Offset_Reserved2
                {
                    get
                    {
                        if (_offset_Reserved2 == -1)
                        {
                            _offset_Reserved2 = Offset_Reserved1 + 1;
                        }

                        return _offset_Reserved2;
                    }
                }

                private int Offset_FrameCount
                {
                    get
                    {
                        if (_offset_FrameCount == -1)
                        {
                            _offset_FrameCount = Offset_Reserved2 + 1;
                        }

                        return _offset_FrameCount;
                    }
                }

                private int Offset_Stack
                {
                    get
                    {
                        if (_offset_Stack == -1)
                        {
                            _offset_Stack = Offset_FrameCount + 4;
                        }

                        return _offset_Stack;
                    }
                }

                /// <summary>
                /// Retrieves the ClrInstanceID field.
                /// </summary>
                public ushort ClrInstanceID => BitConverter.ToUInt16(_etwEvent.Data[Offset_ClrInstanceID..]);

                /// <summary>
                /// Retrieves the Reserved1 field.
                /// </summary>
                public byte Reserved1 => _etwEvent.Data[Offset_Reserved1];

                /// <summary>
                /// Retrieves the Reserved2 field.
                /// </summary>
                public byte Reserved2 => _etwEvent.Data[Offset_Reserved2];

                /// <summary>
                /// Retrieves the FrameCount field.
                /// </summary>
                public uint FrameCount => BitConverter.ToUInt32(_etwEvent.Data[Offset_FrameCount..]);

                /// <summary>
                /// Retrieves the Stack field.
                /// </summary>
                public ulong Stack => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Stack..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Stack..]);

                /// <summary>
                /// Creates a new ClrStackWalkData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ClrStackWalkData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ClrInstanceID = -1;
                    _offset_Reserved1 = -1;
                    _offset_Reserved2 = -1;
                    _offset_FrameCount = -1;
                    _offset_Stack = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a MethodDCStart event.
        /// </summary>
        public readonly ref struct MethodDCStartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "MethodDCStart";

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
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = (EtwEventOpcode)Opcodes.DCStart,
                Task = (ushort)Tasks.Method,
                Keyword = (ulong)Keywords.JitRundownKeyword | (ulong)Keywords.NGenRundownKeyword
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

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
            public MethodDCStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new MethodDCStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public MethodDCStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a MethodDCStart event.
            /// </summary>
            public ref struct MethodDCStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_MethodID;
                private int _offset_ModuleID;
                private int _offset_MethodStartAddress;
                private int _offset_MethodSize;
                private int _offset_MethodToken;
                private int _offset_MethodFlags;

                private int Offset_MethodID
                {
                    get
                    {
                        if (_offset_MethodID == -1)
                        {
                            _offset_MethodID = 0;
                        }

                        return _offset_MethodID;
                    }
                }

                private int Offset_ModuleID
                {
                    get
                    {
                        if (_offset_ModuleID == -1)
                        {
                            _offset_ModuleID = Offset_MethodID + 8;
                        }

                        return _offset_ModuleID;
                    }
                }

                private int Offset_MethodStartAddress
                {
                    get
                    {
                        if (_offset_MethodStartAddress == -1)
                        {
                            _offset_MethodStartAddress = Offset_ModuleID + 8;
                        }

                        return _offset_MethodStartAddress;
                    }
                }

                private int Offset_MethodSize
                {
                    get
                    {
                        if (_offset_MethodSize == -1)
                        {
                            _offset_MethodSize = Offset_MethodStartAddress + 8;
                        }

                        return _offset_MethodSize;
                    }
                }

                private int Offset_MethodToken
                {
                    get
                    {
                        if (_offset_MethodToken == -1)
                        {
                            _offset_MethodToken = Offset_MethodSize + 4;
                        }

                        return _offset_MethodToken;
                    }
                }

                private int Offset_MethodFlags
                {
                    get
                    {
                        if (_offset_MethodFlags == -1)
                        {
                            _offset_MethodFlags = Offset_MethodToken + 4;
                        }

                        return _offset_MethodFlags;
                    }
                }

                /// <summary>
                /// Retrieves the MethodID field.
                /// </summary>
                public ulong MethodID => BitConverter.ToUInt64(_etwEvent.Data[Offset_MethodID..]);

                /// <summary>
                /// Retrieves the ModuleID field.
                /// </summary>
                public ulong ModuleID => BitConverter.ToUInt64(_etwEvent.Data[Offset_ModuleID..]);

                /// <summary>
                /// Retrieves the MethodStartAddress field.
                /// </summary>
                public ulong MethodStartAddress => BitConverter.ToUInt64(_etwEvent.Data[Offset_MethodStartAddress..]);

                /// <summary>
                /// Retrieves the MethodSize field.
                /// </summary>
                public uint MethodSize => BitConverter.ToUInt32(_etwEvent.Data[Offset_MethodSize..]);

                /// <summary>
                /// Retrieves the MethodToken field.
                /// </summary>
                public uint MethodToken => BitConverter.ToUInt32(_etwEvent.Data[Offset_MethodToken..]);

                /// <summary>
                /// Retrieves the MethodFlags field.
                /// </summary>
                public MethodFlagsMap MethodFlags => (MethodFlagsMap)BitConverter.ToUInt32(_etwEvent.Data[Offset_MethodFlags..]);

                /// <summary>
                /// Creates a new MethodDCStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public MethodDCStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_MethodID = -1;
                    _offset_ModuleID = -1;
                    _offset_MethodStartAddress = -1;
                    _offset_MethodSize = -1;
                    _offset_MethodToken = -1;
                    _offset_MethodFlags = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a MethodDCStop event.
        /// </summary>
        public readonly ref struct MethodDCStopEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "MethodDCStop";

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
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = (EtwEventOpcode)Opcodes.DCStop,
                Task = (ushort)Tasks.Method,
                Keyword = (ulong)Keywords.JitRundownKeyword | (ulong)Keywords.NGenRundownKeyword
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

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
            public MethodDCStopData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new MethodDCStopEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public MethodDCStopEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a MethodDCStop event.
            /// </summary>
            public ref struct MethodDCStopData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_MethodID;
                private int _offset_ModuleID;
                private int _offset_MethodStartAddress;
                private int _offset_MethodSize;
                private int _offset_MethodToken;
                private int _offset_MethodFlags;

                private int Offset_MethodID
                {
                    get
                    {
                        if (_offset_MethodID == -1)
                        {
                            _offset_MethodID = 0;
                        }

                        return _offset_MethodID;
                    }
                }

                private int Offset_ModuleID
                {
                    get
                    {
                        if (_offset_ModuleID == -1)
                        {
                            _offset_ModuleID = Offset_MethodID + 8;
                        }

                        return _offset_ModuleID;
                    }
                }

                private int Offset_MethodStartAddress
                {
                    get
                    {
                        if (_offset_MethodStartAddress == -1)
                        {
                            _offset_MethodStartAddress = Offset_ModuleID + 8;
                        }

                        return _offset_MethodStartAddress;
                    }
                }

                private int Offset_MethodSize
                {
                    get
                    {
                        if (_offset_MethodSize == -1)
                        {
                            _offset_MethodSize = Offset_MethodStartAddress + 8;
                        }

                        return _offset_MethodSize;
                    }
                }

                private int Offset_MethodToken
                {
                    get
                    {
                        if (_offset_MethodToken == -1)
                        {
                            _offset_MethodToken = Offset_MethodSize + 4;
                        }

                        return _offset_MethodToken;
                    }
                }

                private int Offset_MethodFlags
                {
                    get
                    {
                        if (_offset_MethodFlags == -1)
                        {
                            _offset_MethodFlags = Offset_MethodToken + 4;
                        }

                        return _offset_MethodFlags;
                    }
                }

                /// <summary>
                /// Retrieves the MethodID field.
                /// </summary>
                public ulong MethodID => BitConverter.ToUInt64(_etwEvent.Data[Offset_MethodID..]);

                /// <summary>
                /// Retrieves the ModuleID field.
                /// </summary>
                public ulong ModuleID => BitConverter.ToUInt64(_etwEvent.Data[Offset_ModuleID..]);

                /// <summary>
                /// Retrieves the MethodStartAddress field.
                /// </summary>
                public ulong MethodStartAddress => BitConverter.ToUInt64(_etwEvent.Data[Offset_MethodStartAddress..]);

                /// <summary>
                /// Retrieves the MethodSize field.
                /// </summary>
                public uint MethodSize => BitConverter.ToUInt32(_etwEvent.Data[Offset_MethodSize..]);

                /// <summary>
                /// Retrieves the MethodToken field.
                /// </summary>
                public uint MethodToken => BitConverter.ToUInt32(_etwEvent.Data[Offset_MethodToken..]);

                /// <summary>
                /// Retrieves the MethodFlags field.
                /// </summary>
                public MethodFlagsMap MethodFlags => (MethodFlagsMap)BitConverter.ToUInt32(_etwEvent.Data[Offset_MethodFlags..]);

                /// <summary>
                /// Creates a new MethodDCStopData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public MethodDCStopData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_MethodID = -1;
                    _offset_ModuleID = -1;
                    _offset_MethodStartAddress = -1;
                    _offset_MethodSize = -1;
                    _offset_MethodToken = -1;
                    _offset_MethodFlags = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a MethodDCStartVerbose event.
        /// </summary>
        public readonly ref struct MethodDCStartVerboseEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "MethodDCStartVerbose";

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
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = (EtwEventOpcode)Opcodes.DCStartVerbose,
                Task = (ushort)Tasks.Method,
                Keyword = (ulong)Keywords.JitRundownKeyword | (ulong)Keywords.NGenRundownKeyword
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

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
            public MethodDCStartVerboseData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new MethodDCStartVerboseEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public MethodDCStartVerboseEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a MethodDCStartVerbose event.
            /// </summary>
            public ref struct MethodDCStartVerboseData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_MethodID;
                private int _offset_ModuleID;
                private int _offset_MethodStartAddress;
                private int _offset_MethodSize;
                private int _offset_MethodToken;
                private int _offset_MethodFlags;
                private int _offset_MethodNamespace;
                private int _offset_MethodName;
                private int _offset_MethodSignature;

                private int Offset_MethodID
                {
                    get
                    {
                        if (_offset_MethodID == -1)
                        {
                            _offset_MethodID = 0;
                        }

                        return _offset_MethodID;
                    }
                }

                private int Offset_ModuleID
                {
                    get
                    {
                        if (_offset_ModuleID == -1)
                        {
                            _offset_ModuleID = Offset_MethodID + 8;
                        }

                        return _offset_ModuleID;
                    }
                }

                private int Offset_MethodStartAddress
                {
                    get
                    {
                        if (_offset_MethodStartAddress == -1)
                        {
                            _offset_MethodStartAddress = Offset_ModuleID + 8;
                        }

                        return _offset_MethodStartAddress;
                    }
                }

                private int Offset_MethodSize
                {
                    get
                    {
                        if (_offset_MethodSize == -1)
                        {
                            _offset_MethodSize = Offset_MethodStartAddress + 8;
                        }

                        return _offset_MethodSize;
                    }
                }

                private int Offset_MethodToken
                {
                    get
                    {
                        if (_offset_MethodToken == -1)
                        {
                            _offset_MethodToken = Offset_MethodSize + 4;
                        }

                        return _offset_MethodToken;
                    }
                }

                private int Offset_MethodFlags
                {
                    get
                    {
                        if (_offset_MethodFlags == -1)
                        {
                            _offset_MethodFlags = Offset_MethodToken + 4;
                        }

                        return _offset_MethodFlags;
                    }
                }

                private int Offset_MethodNamespace
                {
                    get
                    {
                        if (_offset_MethodNamespace == -1)
                        {
                            _offset_MethodNamespace = Offset_MethodFlags + 4;
                        }

                        return _offset_MethodNamespace;
                    }
                }

                private int Offset_MethodName
                {
                    get
                    {
                        if (_offset_MethodName == -1)
                        {
                            _offset_MethodName = Offset_MethodNamespace + _etwEvent.UnicodeStringLength(Offset_MethodNamespace);
                        }

                        return _offset_MethodName;
                    }
                }

                private int Offset_MethodSignature
                {
                    get
                    {
                        if (_offset_MethodSignature == -1)
                        {
                            _offset_MethodSignature = Offset_MethodName + _etwEvent.UnicodeStringLength(Offset_MethodName);
                        }

                        return _offset_MethodSignature;
                    }
                }

                /// <summary>
                /// Retrieves the MethodID field.
                /// </summary>
                public ulong MethodID => BitConverter.ToUInt64(_etwEvent.Data[Offset_MethodID..]);

                /// <summary>
                /// Retrieves the ModuleID field.
                /// </summary>
                public ulong ModuleID => BitConverter.ToUInt64(_etwEvent.Data[Offset_ModuleID..]);

                /// <summary>
                /// Retrieves the MethodStartAddress field.
                /// </summary>
                public ulong MethodStartAddress => BitConverter.ToUInt64(_etwEvent.Data[Offset_MethodStartAddress..]);

                /// <summary>
                /// Retrieves the MethodSize field.
                /// </summary>
                public uint MethodSize => BitConverter.ToUInt32(_etwEvent.Data[Offset_MethodSize..]);

                /// <summary>
                /// Retrieves the MethodToken field.
                /// </summary>
                public uint MethodToken => BitConverter.ToUInt32(_etwEvent.Data[Offset_MethodToken..]);

                /// <summary>
                /// Retrieves the MethodFlags field.
                /// </summary>
                public MethodFlagsMap MethodFlags => (MethodFlagsMap)BitConverter.ToUInt32(_etwEvent.Data[Offset_MethodFlags..]);

                /// <summary>
                /// Retrieves the MethodNamespace field.
                /// </summary>
                public string MethodNamespace => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_MethodNamespace..]);

                /// <summary>
                /// Retrieves the MethodName field.
                /// </summary>
                public string MethodName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_MethodName..]);

                /// <summary>
                /// Retrieves the MethodSignature field.
                /// </summary>
                public string MethodSignature => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_MethodSignature..]);

                /// <summary>
                /// Creates a new MethodDCStartVerboseData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public MethodDCStartVerboseData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_MethodID = -1;
                    _offset_ModuleID = -1;
                    _offset_MethodStartAddress = -1;
                    _offset_MethodSize = -1;
                    _offset_MethodToken = -1;
                    _offset_MethodFlags = -1;
                    _offset_MethodNamespace = -1;
                    _offset_MethodName = -1;
                    _offset_MethodSignature = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a MethodDCStopVerbose event.
        /// </summary>
        public readonly ref struct MethodDCStopVerboseEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "MethodDCStopVerbose";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 144,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = (EtwEventOpcode)Opcodes.DCStopVerbose,
                Task = (ushort)Tasks.Method,
                Keyword = (ulong)Keywords.JitRundownKeyword | (ulong)Keywords.NGenRundownKeyword
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

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
            public MethodDCStopVerboseData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new MethodDCStopVerboseEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public MethodDCStopVerboseEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a MethodDCStopVerbose event.
            /// </summary>
            public ref struct MethodDCStopVerboseData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_MethodID;
                private int _offset_ModuleID;
                private int _offset_MethodStartAddress;
                private int _offset_MethodSize;
                private int _offset_MethodToken;
                private int _offset_MethodFlags;
                private int _offset_MethodNamespace;
                private int _offset_MethodName;
                private int _offset_MethodSignature;

                private int Offset_MethodID
                {
                    get
                    {
                        if (_offset_MethodID == -1)
                        {
                            _offset_MethodID = 0;
                        }

                        return _offset_MethodID;
                    }
                }

                private int Offset_ModuleID
                {
                    get
                    {
                        if (_offset_ModuleID == -1)
                        {
                            _offset_ModuleID = Offset_MethodID + 8;
                        }

                        return _offset_ModuleID;
                    }
                }

                private int Offset_MethodStartAddress
                {
                    get
                    {
                        if (_offset_MethodStartAddress == -1)
                        {
                            _offset_MethodStartAddress = Offset_ModuleID + 8;
                        }

                        return _offset_MethodStartAddress;
                    }
                }

                private int Offset_MethodSize
                {
                    get
                    {
                        if (_offset_MethodSize == -1)
                        {
                            _offset_MethodSize = Offset_MethodStartAddress + 8;
                        }

                        return _offset_MethodSize;
                    }
                }

                private int Offset_MethodToken
                {
                    get
                    {
                        if (_offset_MethodToken == -1)
                        {
                            _offset_MethodToken = Offset_MethodSize + 4;
                        }

                        return _offset_MethodToken;
                    }
                }

                private int Offset_MethodFlags
                {
                    get
                    {
                        if (_offset_MethodFlags == -1)
                        {
                            _offset_MethodFlags = Offset_MethodToken + 4;
                        }

                        return _offset_MethodFlags;
                    }
                }

                private int Offset_MethodNamespace
                {
                    get
                    {
                        if (_offset_MethodNamespace == -1)
                        {
                            _offset_MethodNamespace = Offset_MethodFlags + 4;
                        }

                        return _offset_MethodNamespace;
                    }
                }

                private int Offset_MethodName
                {
                    get
                    {
                        if (_offset_MethodName == -1)
                        {
                            _offset_MethodName = Offset_MethodNamespace + _etwEvent.UnicodeStringLength(Offset_MethodNamespace);
                        }

                        return _offset_MethodName;
                    }
                }

                private int Offset_MethodSignature
                {
                    get
                    {
                        if (_offset_MethodSignature == -1)
                        {
                            _offset_MethodSignature = Offset_MethodName + _etwEvent.UnicodeStringLength(Offset_MethodName);
                        }

                        return _offset_MethodSignature;
                    }
                }

                /// <summary>
                /// Retrieves the MethodID field.
                /// </summary>
                public ulong MethodID => BitConverter.ToUInt64(_etwEvent.Data[Offset_MethodID..]);

                /// <summary>
                /// Retrieves the ModuleID field.
                /// </summary>
                public ulong ModuleID => BitConverter.ToUInt64(_etwEvent.Data[Offset_ModuleID..]);

                /// <summary>
                /// Retrieves the MethodStartAddress field.
                /// </summary>
                public ulong MethodStartAddress => BitConverter.ToUInt64(_etwEvent.Data[Offset_MethodStartAddress..]);

                /// <summary>
                /// Retrieves the MethodSize field.
                /// </summary>
                public uint MethodSize => BitConverter.ToUInt32(_etwEvent.Data[Offset_MethodSize..]);

                /// <summary>
                /// Retrieves the MethodToken field.
                /// </summary>
                public uint MethodToken => BitConverter.ToUInt32(_etwEvent.Data[Offset_MethodToken..]);

                /// <summary>
                /// Retrieves the MethodFlags field.
                /// </summary>
                public MethodFlagsMap MethodFlags => (MethodFlagsMap)BitConverter.ToUInt32(_etwEvent.Data[Offset_MethodFlags..]);

                /// <summary>
                /// Retrieves the MethodNamespace field.
                /// </summary>
                public string MethodNamespace => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_MethodNamespace..]);

                /// <summary>
                /// Retrieves the MethodName field.
                /// </summary>
                public string MethodName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_MethodName..]);

                /// <summary>
                /// Retrieves the MethodSignature field.
                /// </summary>
                public string MethodSignature => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_MethodSignature..]);

                /// <summary>
                /// Creates a new MethodDCStopVerboseData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public MethodDCStopVerboseData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_MethodID = -1;
                    _offset_ModuleID = -1;
                    _offset_MethodStartAddress = -1;
                    _offset_MethodSize = -1;
                    _offset_MethodToken = -1;
                    _offset_MethodFlags = -1;
                    _offset_MethodNamespace = -1;
                    _offset_MethodName = -1;
                    _offset_MethodSignature = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a MethodDCStartComplete event.
        /// </summary>
        public readonly ref struct MethodDCStartCompleteEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "MethodDCStartComplete";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 145,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = (EtwEventOpcode)Opcodes.DCStartComplete,
                Task = (ushort)Tasks.Method,
                Keyword = (ulong)Keywords.LoaderRundownKeyword | (ulong)Keywords.JitRundownKeyword | (ulong)Keywords.NGenRundownKeyword | (ulong)Keywords.JittedMethodILToNativeMapRundownKeyword
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Creates a new MethodDCStartCompleteEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public MethodDCStartCompleteEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a MethodDCStopComplete event.
        /// </summary>
        public readonly ref struct MethodDCStopCompleteEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "MethodDCStopComplete";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 146,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = (EtwEventOpcode)Opcodes.DCStopComplete,
                Task = (ushort)Tasks.Method,
                Keyword = (ulong)Keywords.LoaderRundownKeyword | (ulong)Keywords.JitRundownKeyword | (ulong)Keywords.NGenRundownKeyword | (ulong)Keywords.JittedMethodILToNativeMapRundownKeyword
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Creates a new MethodDCStopCompleteEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public MethodDCStopCompleteEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a MethodDCStartInit event.
        /// </summary>
        public readonly ref struct MethodDCStartInitEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "MethodDCStartInit";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 147,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = (EtwEventOpcode)Opcodes.DCStartInit,
                Task = (ushort)Tasks.Method,
                Keyword = (ulong)Keywords.LoaderRundownKeyword | (ulong)Keywords.JitRundownKeyword | (ulong)Keywords.NGenRundownKeyword | (ulong)Keywords.JittedMethodILToNativeMapRundownKeyword
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Creates a new MethodDCStartInitEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public MethodDCStartInitEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a MethodDCStopInit event.
        /// </summary>
        public readonly ref struct MethodDCStopInitEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "MethodDCStopInit";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 148,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = (EtwEventOpcode)Opcodes.DCStopInit,
                Task = (ushort)Tasks.Method,
                Keyword = (ulong)Keywords.LoaderRundownKeyword | (ulong)Keywords.JitRundownKeyword | (ulong)Keywords.NGenRundownKeyword | (ulong)Keywords.JittedMethodILToNativeMapRundownKeyword
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Creates a new MethodDCStopInitEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public MethodDCStopInitEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a MethodMethodDCStartILToNativeMap event.
        /// </summary>
        public readonly ref struct MethodMethodDCStartILToNativeMapEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "MethodMethodDCStartILToNativeMap";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 149,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Verbose,
                Opcode = (EtwEventOpcode)Opcodes.MethodDCStartILToNativeMap,
                Task = (ushort)Tasks.Method,
                Keyword = (ulong)Keywords.JittedMethodILToNativeMapRundownKeyword
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

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
            public MethodMethodDCStartILToNativeMapData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new MethodMethodDCStartILToNativeMapEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public MethodMethodDCStartILToNativeMapEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a MethodMethodDCStartILToNativeMap event.
            /// </summary>
            public ref struct MethodMethodDCStartILToNativeMapData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_MethodID;
                private int _offset_ReJITID;
                private int _offset_MethodExtent;
                private int _offset_CountOfMapEntries;
                private int _offset_ILOffsets;
                private int _offset_NativeOffsets;
                private int _offset_ClrInstanceID;

                private int Offset_MethodID
                {
                    get
                    {
                        if (_offset_MethodID == -1)
                        {
                            _offset_MethodID = 0;
                        }

                        return _offset_MethodID;
                    }
                }

                private int Offset_ReJITID
                {
                    get
                    {
                        if (_offset_ReJITID == -1)
                        {
                            _offset_ReJITID = Offset_MethodID + 8;
                        }

                        return _offset_ReJITID;
                    }
                }

                private int Offset_MethodExtent
                {
                    get
                    {
                        if (_offset_MethodExtent == -1)
                        {
                            _offset_MethodExtent = Offset_ReJITID + 8;
                        }

                        return _offset_MethodExtent;
                    }
                }

                private int Offset_CountOfMapEntries
                {
                    get
                    {
                        if (_offset_CountOfMapEntries == -1)
                        {
                            _offset_CountOfMapEntries = Offset_MethodExtent + 1;
                        }

                        return _offset_CountOfMapEntries;
                    }
                }

                private int Offset_ILOffsets
                {
                    get
                    {
                        if (_offset_ILOffsets == -1)
                        {
                            _offset_ILOffsets = Offset_CountOfMapEntries + 2;
                        }

                        return _offset_ILOffsets;
                    }
                }

                private int Offset_NativeOffsets
                {
                    get
                    {
                        if (_offset_NativeOffsets == -1)
                        {
                            _offset_NativeOffsets = Offset_ILOffsets + (4 * (int)CountOfMapEntries);
                        }

                        return _offset_NativeOffsets;
                    }
                }

                private int Offset_ClrInstanceID
                {
                    get
                    {
                        if (_offset_ClrInstanceID == -1)
                        {
                            _offset_ClrInstanceID = Offset_NativeOffsets + (4 * (int)CountOfMapEntries);
                        }

                        return _offset_ClrInstanceID;
                    }
                }

                /// <summary>
                /// Retrieves the MethodID field.
                /// </summary>
                public ulong MethodID => BitConverter.ToUInt64(_etwEvent.Data[Offset_MethodID..]);

                /// <summary>
                /// Retrieves the ReJITID field.
                /// </summary>
                public ulong ReJITID => BitConverter.ToUInt64(_etwEvent.Data[Offset_ReJITID..]);

                /// <summary>
                /// Retrieves the MethodExtent field.
                /// </summary>
                public byte MethodExtent => _etwEvent.Data[Offset_MethodExtent];

                /// <summary>
                /// Retrieves the CountOfMapEntries field.
                /// </summary>
                public ushort CountOfMapEntries => BitConverter.ToUInt16(_etwEvent.Data[Offset_CountOfMapEntries..]);

                /// <summary>
                /// Retrieves the ILOffsets field.
                /// </summary>
                public EtwEvent.StructEnumerable<uint> ILOffsets => new(_etwEvent, Offset_ILOffsets, CountOfMapEntries);

                /// <summary>
                /// Retrieves the NativeOffsets field.
                /// </summary>
                public EtwEvent.StructEnumerable<uint> NativeOffsets => new(_etwEvent, Offset_NativeOffsets, CountOfMapEntries);

                /// <summary>
                /// Retrieves the ClrInstanceID field.
                /// </summary>
                public ushort ClrInstanceID => BitConverter.ToUInt16(_etwEvent.Data[Offset_ClrInstanceID..]);

                /// <summary>
                /// Creates a new MethodMethodDCStartILToNativeMapData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public MethodMethodDCStartILToNativeMapData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_MethodID = -1;
                    _offset_ReJITID = -1;
                    _offset_MethodExtent = -1;
                    _offset_CountOfMapEntries = -1;
                    _offset_ILOffsets = -1;
                    _offset_NativeOffsets = -1;
                    _offset_ClrInstanceID = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a MethodMethodDCEndILToNativeMap event.
        /// </summary>
        public readonly ref struct MethodMethodDCEndILToNativeMapEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "MethodMethodDCEndILToNativeMap";

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
                Level = EtwTraceLevel.Verbose,
                Opcode = (EtwEventOpcode)Opcodes.MethodDCEndILToNativeMap,
                Task = (ushort)Tasks.Method,
                Keyword = (ulong)Keywords.JittedMethodILToNativeMapRundownKeyword
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

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
            public MethodMethodDCEndILToNativeMapData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new MethodMethodDCEndILToNativeMapEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public MethodMethodDCEndILToNativeMapEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a MethodMethodDCEndILToNativeMap event.
            /// </summary>
            public ref struct MethodMethodDCEndILToNativeMapData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_MethodID;
                private int _offset_ReJITID;
                private int _offset_MethodExtent;
                private int _offset_CountOfMapEntries;
                private int _offset_ILOffsets;
                private int _offset_NativeOffsets;
                private int _offset_ClrInstanceID;

                private int Offset_MethodID
                {
                    get
                    {
                        if (_offset_MethodID == -1)
                        {
                            _offset_MethodID = 0;
                        }

                        return _offset_MethodID;
                    }
                }

                private int Offset_ReJITID
                {
                    get
                    {
                        if (_offset_ReJITID == -1)
                        {
                            _offset_ReJITID = Offset_MethodID + 8;
                        }

                        return _offset_ReJITID;
                    }
                }

                private int Offset_MethodExtent
                {
                    get
                    {
                        if (_offset_MethodExtent == -1)
                        {
                            _offset_MethodExtent = Offset_ReJITID + 8;
                        }

                        return _offset_MethodExtent;
                    }
                }

                private int Offset_CountOfMapEntries
                {
                    get
                    {
                        if (_offset_CountOfMapEntries == -1)
                        {
                            _offset_CountOfMapEntries = Offset_MethodExtent + 1;
                        }

                        return _offset_CountOfMapEntries;
                    }
                }

                private int Offset_ILOffsets
                {
                    get
                    {
                        if (_offset_ILOffsets == -1)
                        {
                            _offset_ILOffsets = Offset_CountOfMapEntries + 2;
                        }

                        return _offset_ILOffsets;
                    }
                }

                private int Offset_NativeOffsets
                {
                    get
                    {
                        if (_offset_NativeOffsets == -1)
                        {
                            _offset_NativeOffsets = Offset_ILOffsets + (4 * (int)CountOfMapEntries);
                        }

                        return _offset_NativeOffsets;
                    }
                }

                private int Offset_ClrInstanceID
                {
                    get
                    {
                        if (_offset_ClrInstanceID == -1)
                        {
                            _offset_ClrInstanceID = Offset_NativeOffsets + (4 * (int)CountOfMapEntries);
                        }

                        return _offset_ClrInstanceID;
                    }
                }

                /// <summary>
                /// Retrieves the MethodID field.
                /// </summary>
                public ulong MethodID => BitConverter.ToUInt64(_etwEvent.Data[Offset_MethodID..]);

                /// <summary>
                /// Retrieves the ReJITID field.
                /// </summary>
                public ulong ReJITID => BitConverter.ToUInt64(_etwEvent.Data[Offset_ReJITID..]);

                /// <summary>
                /// Retrieves the MethodExtent field.
                /// </summary>
                public byte MethodExtent => _etwEvent.Data[Offset_MethodExtent];

                /// <summary>
                /// Retrieves the CountOfMapEntries field.
                /// </summary>
                public ushort CountOfMapEntries => BitConverter.ToUInt16(_etwEvent.Data[Offset_CountOfMapEntries..]);

                /// <summary>
                /// Retrieves the ILOffsets field.
                /// </summary>
                public EtwEvent.StructEnumerable<uint> ILOffsets => new(_etwEvent, Offset_ILOffsets, CountOfMapEntries);

                /// <summary>
                /// Retrieves the NativeOffsets field.
                /// </summary>
                public EtwEvent.StructEnumerable<uint> NativeOffsets => new(_etwEvent, Offset_NativeOffsets, CountOfMapEntries);

                /// <summary>
                /// Retrieves the ClrInstanceID field.
                /// </summary>
                public ushort ClrInstanceID => BitConverter.ToUInt16(_etwEvent.Data[Offset_ClrInstanceID..]);

                /// <summary>
                /// Creates a new MethodMethodDCEndILToNativeMapData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public MethodMethodDCEndILToNativeMapData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_MethodID = -1;
                    _offset_ReJITID = -1;
                    _offset_MethodExtent = -1;
                    _offset_CountOfMapEntries = -1;
                    _offset_ILOffsets = -1;
                    _offset_NativeOffsets = -1;
                    _offset_ClrInstanceID = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a LoaderDomainModuleDCStart event.
        /// </summary>
        public readonly ref struct LoaderDomainModuleDCStartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "LoaderDomainModuleDCStart";

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
                Opcode = (EtwEventOpcode)Opcodes.DomainModuleDCStart,
                Task = (ushort)Tasks.Loader,
                Keyword = (ulong)Keywords.LoaderRundownKeyword
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

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
            public LoaderDomainModuleDCStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new LoaderDomainModuleDCStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public LoaderDomainModuleDCStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a LoaderDomainModuleDCStart event.
            /// </summary>
            public ref struct LoaderDomainModuleDCStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ModuleID;
                private int _offset_AssemblyID;
                private int _offset_AppDomainID;
                private int _offset_ModuleFlags;
                private int _offset_Reserved1;
                private int _offset_ModuleILPath;
                private int _offset_ModuleNativePath;

                private int Offset_ModuleID
                {
                    get
                    {
                        if (_offset_ModuleID == -1)
                        {
                            _offset_ModuleID = 0;
                        }

                        return _offset_ModuleID;
                    }
                }

                private int Offset_AssemblyID
                {
                    get
                    {
                        if (_offset_AssemblyID == -1)
                        {
                            _offset_AssemblyID = Offset_ModuleID + 8;
                        }

                        return _offset_AssemblyID;
                    }
                }

                private int Offset_AppDomainID
                {
                    get
                    {
                        if (_offset_AppDomainID == -1)
                        {
                            _offset_AppDomainID = Offset_AssemblyID + 8;
                        }

                        return _offset_AppDomainID;
                    }
                }

                private int Offset_ModuleFlags
                {
                    get
                    {
                        if (_offset_ModuleFlags == -1)
                        {
                            _offset_ModuleFlags = Offset_AppDomainID + 8;
                        }

                        return _offset_ModuleFlags;
                    }
                }

                private int Offset_Reserved1
                {
                    get
                    {
                        if (_offset_Reserved1 == -1)
                        {
                            _offset_Reserved1 = Offset_ModuleFlags + 4;
                        }

                        return _offset_Reserved1;
                    }
                }

                private int Offset_ModuleILPath
                {
                    get
                    {
                        if (_offset_ModuleILPath == -1)
                        {
                            _offset_ModuleILPath = Offset_Reserved1 + 4;
                        }

                        return _offset_ModuleILPath;
                    }
                }

                private int Offset_ModuleNativePath
                {
                    get
                    {
                        if (_offset_ModuleNativePath == -1)
                        {
                            _offset_ModuleNativePath = Offset_ModuleILPath + _etwEvent.UnicodeStringLength(Offset_ModuleILPath);
                        }

                        return _offset_ModuleNativePath;
                    }
                }

                /// <summary>
                /// Retrieves the ModuleID field.
                /// </summary>
                public ulong ModuleID => BitConverter.ToUInt64(_etwEvent.Data[Offset_ModuleID..]);

                /// <summary>
                /// Retrieves the AssemblyID field.
                /// </summary>
                public ulong AssemblyID => BitConverter.ToUInt64(_etwEvent.Data[Offset_AssemblyID..]);

                /// <summary>
                /// Retrieves the AppDomainID field.
                /// </summary>
                public ulong AppDomainID => BitConverter.ToUInt64(_etwEvent.Data[Offset_AppDomainID..]);

                /// <summary>
                /// Retrieves the ModuleFlags field.
                /// </summary>
                public ModuleFlagsMap ModuleFlags => (ModuleFlagsMap)BitConverter.ToUInt32(_etwEvent.Data[Offset_ModuleFlags..]);

                /// <summary>
                /// Retrieves the Reserved1 field.
                /// </summary>
                public uint Reserved1 => BitConverter.ToUInt32(_etwEvent.Data[Offset_Reserved1..]);

                /// <summary>
                /// Retrieves the ModuleILPath field.
                /// </summary>
                public string ModuleILPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ModuleILPath..]);

                /// <summary>
                /// Retrieves the ModuleNativePath field.
                /// </summary>
                public string ModuleNativePath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ModuleNativePath..]);

                /// <summary>
                /// Creates a new LoaderDomainModuleDCStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public LoaderDomainModuleDCStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ModuleID = -1;
                    _offset_AssemblyID = -1;
                    _offset_AppDomainID = -1;
                    _offset_ModuleFlags = -1;
                    _offset_Reserved1 = -1;
                    _offset_ModuleILPath = -1;
                    _offset_ModuleNativePath = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a LoaderDomainModuleDCStop event.
        /// </summary>
        public readonly ref struct LoaderDomainModuleDCStopEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "LoaderDomainModuleDCStop";

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
                Opcode = (EtwEventOpcode)Opcodes.DomainModuleDCStop,
                Task = (ushort)Tasks.Loader,
                Keyword = (ulong)Keywords.LoaderRundownKeyword
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

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
            public LoaderDomainModuleDCStopData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new LoaderDomainModuleDCStopEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public LoaderDomainModuleDCStopEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a LoaderDomainModuleDCStop event.
            /// </summary>
            public ref struct LoaderDomainModuleDCStopData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ModuleID;
                private int _offset_AssemblyID;
                private int _offset_AppDomainID;
                private int _offset_ModuleFlags;
                private int _offset_Reserved1;
                private int _offset_ModuleILPath;
                private int _offset_ModuleNativePath;

                private int Offset_ModuleID
                {
                    get
                    {
                        if (_offset_ModuleID == -1)
                        {
                            _offset_ModuleID = 0;
                        }

                        return _offset_ModuleID;
                    }
                }

                private int Offset_AssemblyID
                {
                    get
                    {
                        if (_offset_AssemblyID == -1)
                        {
                            _offset_AssemblyID = Offset_ModuleID + 8;
                        }

                        return _offset_AssemblyID;
                    }
                }

                private int Offset_AppDomainID
                {
                    get
                    {
                        if (_offset_AppDomainID == -1)
                        {
                            _offset_AppDomainID = Offset_AssemblyID + 8;
                        }

                        return _offset_AppDomainID;
                    }
                }

                private int Offset_ModuleFlags
                {
                    get
                    {
                        if (_offset_ModuleFlags == -1)
                        {
                            _offset_ModuleFlags = Offset_AppDomainID + 8;
                        }

                        return _offset_ModuleFlags;
                    }
                }

                private int Offset_Reserved1
                {
                    get
                    {
                        if (_offset_Reserved1 == -1)
                        {
                            _offset_Reserved1 = Offset_ModuleFlags + 4;
                        }

                        return _offset_Reserved1;
                    }
                }

                private int Offset_ModuleILPath
                {
                    get
                    {
                        if (_offset_ModuleILPath == -1)
                        {
                            _offset_ModuleILPath = Offset_Reserved1 + 4;
                        }

                        return _offset_ModuleILPath;
                    }
                }

                private int Offset_ModuleNativePath
                {
                    get
                    {
                        if (_offset_ModuleNativePath == -1)
                        {
                            _offset_ModuleNativePath = Offset_ModuleILPath + _etwEvent.UnicodeStringLength(Offset_ModuleILPath);
                        }

                        return _offset_ModuleNativePath;
                    }
                }

                /// <summary>
                /// Retrieves the ModuleID field.
                /// </summary>
                public ulong ModuleID => BitConverter.ToUInt64(_etwEvent.Data[Offset_ModuleID..]);

                /// <summary>
                /// Retrieves the AssemblyID field.
                /// </summary>
                public ulong AssemblyID => BitConverter.ToUInt64(_etwEvent.Data[Offset_AssemblyID..]);

                /// <summary>
                /// Retrieves the AppDomainID field.
                /// </summary>
                public ulong AppDomainID => BitConverter.ToUInt64(_etwEvent.Data[Offset_AppDomainID..]);

                /// <summary>
                /// Retrieves the ModuleFlags field.
                /// </summary>
                public ModuleFlagsMap ModuleFlags => (ModuleFlagsMap)BitConverter.ToUInt32(_etwEvent.Data[Offset_ModuleFlags..]);

                /// <summary>
                /// Retrieves the Reserved1 field.
                /// </summary>
                public uint Reserved1 => BitConverter.ToUInt32(_etwEvent.Data[Offset_Reserved1..]);

                /// <summary>
                /// Retrieves the ModuleILPath field.
                /// </summary>
                public string ModuleILPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ModuleILPath..]);

                /// <summary>
                /// Retrieves the ModuleNativePath field.
                /// </summary>
                public string ModuleNativePath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ModuleNativePath..]);

                /// <summary>
                /// Creates a new LoaderDomainModuleDCStopData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public LoaderDomainModuleDCStopData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ModuleID = -1;
                    _offset_AssemblyID = -1;
                    _offset_AppDomainID = -1;
                    _offset_ModuleFlags = -1;
                    _offset_Reserved1 = -1;
                    _offset_ModuleILPath = -1;
                    _offset_ModuleNativePath = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a LoaderModuleDCStart event.
        /// </summary>
        public readonly ref struct LoaderModuleDCStartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "LoaderModuleDCStart";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 153,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = (EtwEventOpcode)Opcodes.DCStart,
                Task = (ushort)Tasks.Loader,
                Keyword = (ulong)Keywords.LoaderRundownKeyword
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

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
            public LoaderModuleDCStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new LoaderModuleDCStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public LoaderModuleDCStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a LoaderModuleDCStart event.
            /// </summary>
            public ref struct LoaderModuleDCStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ModuleID;
                private int _offset_AssemblyID;
                private int _offset_ModuleFlags;
                private int _offset_Reserved1;
                private int _offset_ModuleILPath;
                private int _offset_ModuleNativePath;

                private int Offset_ModuleID
                {
                    get
                    {
                        if (_offset_ModuleID == -1)
                        {
                            _offset_ModuleID = 0;
                        }

                        return _offset_ModuleID;
                    }
                }

                private int Offset_AssemblyID
                {
                    get
                    {
                        if (_offset_AssemblyID == -1)
                        {
                            _offset_AssemblyID = Offset_ModuleID + 8;
                        }

                        return _offset_AssemblyID;
                    }
                }

                private int Offset_ModuleFlags
                {
                    get
                    {
                        if (_offset_ModuleFlags == -1)
                        {
                            _offset_ModuleFlags = Offset_AssemblyID + 8;
                        }

                        return _offset_ModuleFlags;
                    }
                }

                private int Offset_Reserved1
                {
                    get
                    {
                        if (_offset_Reserved1 == -1)
                        {
                            _offset_Reserved1 = Offset_ModuleFlags + 4;
                        }

                        return _offset_Reserved1;
                    }
                }

                private int Offset_ModuleILPath
                {
                    get
                    {
                        if (_offset_ModuleILPath == -1)
                        {
                            _offset_ModuleILPath = Offset_Reserved1 + 4;
                        }

                        return _offset_ModuleILPath;
                    }
                }

                private int Offset_ModuleNativePath
                {
                    get
                    {
                        if (_offset_ModuleNativePath == -1)
                        {
                            _offset_ModuleNativePath = Offset_ModuleILPath + _etwEvent.UnicodeStringLength(Offset_ModuleILPath);
                        }

                        return _offset_ModuleNativePath;
                    }
                }

                /// <summary>
                /// Retrieves the ModuleID field.
                /// </summary>
                public ulong ModuleID => BitConverter.ToUInt64(_etwEvent.Data[Offset_ModuleID..]);

                /// <summary>
                /// Retrieves the AssemblyID field.
                /// </summary>
                public ulong AssemblyID => BitConverter.ToUInt64(_etwEvent.Data[Offset_AssemblyID..]);

                /// <summary>
                /// Retrieves the ModuleFlags field.
                /// </summary>
                public ModuleFlagsMap ModuleFlags => (ModuleFlagsMap)BitConverter.ToUInt32(_etwEvent.Data[Offset_ModuleFlags..]);

                /// <summary>
                /// Retrieves the Reserved1 field.
                /// </summary>
                public uint Reserved1 => BitConverter.ToUInt32(_etwEvent.Data[Offset_Reserved1..]);

                /// <summary>
                /// Retrieves the ModuleILPath field.
                /// </summary>
                public string ModuleILPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ModuleILPath..]);

                /// <summary>
                /// Retrieves the ModuleNativePath field.
                /// </summary>
                public string ModuleNativePath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ModuleNativePath..]);

                /// <summary>
                /// Creates a new LoaderModuleDCStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public LoaderModuleDCStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ModuleID = -1;
                    _offset_AssemblyID = -1;
                    _offset_ModuleFlags = -1;
                    _offset_Reserved1 = -1;
                    _offset_ModuleILPath = -1;
                    _offset_ModuleNativePath = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a LoaderModuleDCStop event.
        /// </summary>
        public readonly ref struct LoaderModuleDCStopEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "LoaderModuleDCStop";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 154,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = (EtwEventOpcode)Opcodes.DCStop,
                Task = (ushort)Tasks.Loader,
                Keyword = (ulong)Keywords.LoaderRundownKeyword
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

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
            public LoaderModuleDCStopData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new LoaderModuleDCStopEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public LoaderModuleDCStopEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a LoaderModuleDCStop event.
            /// </summary>
            public ref struct LoaderModuleDCStopData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ModuleID;
                private int _offset_AssemblyID;
                private int _offset_ModuleFlags;
                private int _offset_Reserved1;
                private int _offset_ModuleILPath;
                private int _offset_ModuleNativePath;

                private int Offset_ModuleID
                {
                    get
                    {
                        if (_offset_ModuleID == -1)
                        {
                            _offset_ModuleID = 0;
                        }

                        return _offset_ModuleID;
                    }
                }

                private int Offset_AssemblyID
                {
                    get
                    {
                        if (_offset_AssemblyID == -1)
                        {
                            _offset_AssemblyID = Offset_ModuleID + 8;
                        }

                        return _offset_AssemblyID;
                    }
                }

                private int Offset_ModuleFlags
                {
                    get
                    {
                        if (_offset_ModuleFlags == -1)
                        {
                            _offset_ModuleFlags = Offset_AssemblyID + 8;
                        }

                        return _offset_ModuleFlags;
                    }
                }

                private int Offset_Reserved1
                {
                    get
                    {
                        if (_offset_Reserved1 == -1)
                        {
                            _offset_Reserved1 = Offset_ModuleFlags + 4;
                        }

                        return _offset_Reserved1;
                    }
                }

                private int Offset_ModuleILPath
                {
                    get
                    {
                        if (_offset_ModuleILPath == -1)
                        {
                            _offset_ModuleILPath = Offset_Reserved1 + 4;
                        }

                        return _offset_ModuleILPath;
                    }
                }

                private int Offset_ModuleNativePath
                {
                    get
                    {
                        if (_offset_ModuleNativePath == -1)
                        {
                            _offset_ModuleNativePath = Offset_ModuleILPath + _etwEvent.UnicodeStringLength(Offset_ModuleILPath);
                        }

                        return _offset_ModuleNativePath;
                    }
                }

                /// <summary>
                /// Retrieves the ModuleID field.
                /// </summary>
                public ulong ModuleID => BitConverter.ToUInt64(_etwEvent.Data[Offset_ModuleID..]);

                /// <summary>
                /// Retrieves the AssemblyID field.
                /// </summary>
                public ulong AssemblyID => BitConverter.ToUInt64(_etwEvent.Data[Offset_AssemblyID..]);

                /// <summary>
                /// Retrieves the ModuleFlags field.
                /// </summary>
                public ModuleFlagsMap ModuleFlags => (ModuleFlagsMap)BitConverter.ToUInt32(_etwEvent.Data[Offset_ModuleFlags..]);

                /// <summary>
                /// Retrieves the Reserved1 field.
                /// </summary>
                public uint Reserved1 => BitConverter.ToUInt32(_etwEvent.Data[Offset_Reserved1..]);

                /// <summary>
                /// Retrieves the ModuleILPath field.
                /// </summary>
                public string ModuleILPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ModuleILPath..]);

                /// <summary>
                /// Retrieves the ModuleNativePath field.
                /// </summary>
                public string ModuleNativePath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ModuleNativePath..]);

                /// <summary>
                /// Creates a new LoaderModuleDCStopData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public LoaderModuleDCStopData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ModuleID = -1;
                    _offset_AssemblyID = -1;
                    _offset_ModuleFlags = -1;
                    _offset_Reserved1 = -1;
                    _offset_ModuleILPath = -1;
                    _offset_ModuleNativePath = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a LoaderAssemblyDCStart event.
        /// </summary>
        public readonly ref struct LoaderAssemblyDCStartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "LoaderAssemblyDCStart";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 155,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = (EtwEventOpcode)Opcodes.DCStartVerbose,
                Task = (ushort)Tasks.Loader,
                Keyword = (ulong)Keywords.LoaderRundownKeyword
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

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
            public LoaderAssemblyDCStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new LoaderAssemblyDCStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public LoaderAssemblyDCStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a LoaderAssemblyDCStart event.
            /// </summary>
            public ref struct LoaderAssemblyDCStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_AssemblyID;
                private int _offset_AppDomainID;
                private int _offset_AssemblyFlags;
                private int _offset_FullyQualifiedAssemblyName;

                private int Offset_AssemblyID
                {
                    get
                    {
                        if (_offset_AssemblyID == -1)
                        {
                            _offset_AssemblyID = 0;
                        }

                        return _offset_AssemblyID;
                    }
                }

                private int Offset_AppDomainID
                {
                    get
                    {
                        if (_offset_AppDomainID == -1)
                        {
                            _offset_AppDomainID = Offset_AssemblyID + 8;
                        }

                        return _offset_AppDomainID;
                    }
                }

                private int Offset_AssemblyFlags
                {
                    get
                    {
                        if (_offset_AssemblyFlags == -1)
                        {
                            _offset_AssemblyFlags = Offset_AppDomainID + 8;
                        }

                        return _offset_AssemblyFlags;
                    }
                }

                private int Offset_FullyQualifiedAssemblyName
                {
                    get
                    {
                        if (_offset_FullyQualifiedAssemblyName == -1)
                        {
                            _offset_FullyQualifiedAssemblyName = Offset_AssemblyFlags + 4;
                        }

                        return _offset_FullyQualifiedAssemblyName;
                    }
                }

                /// <summary>
                /// Retrieves the AssemblyID field.
                /// </summary>
                public ulong AssemblyID => BitConverter.ToUInt64(_etwEvent.Data[Offset_AssemblyID..]);

                /// <summary>
                /// Retrieves the AppDomainID field.
                /// </summary>
                public ulong AppDomainID => BitConverter.ToUInt64(_etwEvent.Data[Offset_AppDomainID..]);

                /// <summary>
                /// Retrieves the AssemblyFlags field.
                /// </summary>
                public AssemblyFlagsMap AssemblyFlags => (AssemblyFlagsMap)BitConverter.ToUInt32(_etwEvent.Data[Offset_AssemblyFlags..]);

                /// <summary>
                /// Retrieves the FullyQualifiedAssemblyName field.
                /// </summary>
                public string FullyQualifiedAssemblyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FullyQualifiedAssemblyName..]);

                /// <summary>
                /// Creates a new LoaderAssemblyDCStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public LoaderAssemblyDCStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_AssemblyID = -1;
                    _offset_AppDomainID = -1;
                    _offset_AssemblyFlags = -1;
                    _offset_FullyQualifiedAssemblyName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a LoaderAssemblyDCStop event.
        /// </summary>
        public readonly ref struct LoaderAssemblyDCStopEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "LoaderAssemblyDCStop";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 156,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = (EtwEventOpcode)Opcodes.DCStopVerbose,
                Task = (ushort)Tasks.Loader,
                Keyword = (ulong)Keywords.LoaderRundownKeyword
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

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
            public LoaderAssemblyDCStopData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new LoaderAssemblyDCStopEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public LoaderAssemblyDCStopEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a LoaderAssemblyDCStop event.
            /// </summary>
            public ref struct LoaderAssemblyDCStopData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_AssemblyID;
                private int _offset_AppDomainID;
                private int _offset_AssemblyFlags;
                private int _offset_FullyQualifiedAssemblyName;

                private int Offset_AssemblyID
                {
                    get
                    {
                        if (_offset_AssemblyID == -1)
                        {
                            _offset_AssemblyID = 0;
                        }

                        return _offset_AssemblyID;
                    }
                }

                private int Offset_AppDomainID
                {
                    get
                    {
                        if (_offset_AppDomainID == -1)
                        {
                            _offset_AppDomainID = Offset_AssemblyID + 8;
                        }

                        return _offset_AppDomainID;
                    }
                }

                private int Offset_AssemblyFlags
                {
                    get
                    {
                        if (_offset_AssemblyFlags == -1)
                        {
                            _offset_AssemblyFlags = Offset_AppDomainID + 8;
                        }

                        return _offset_AssemblyFlags;
                    }
                }

                private int Offset_FullyQualifiedAssemblyName
                {
                    get
                    {
                        if (_offset_FullyQualifiedAssemblyName == -1)
                        {
                            _offset_FullyQualifiedAssemblyName = Offset_AssemblyFlags + 4;
                        }

                        return _offset_FullyQualifiedAssemblyName;
                    }
                }

                /// <summary>
                /// Retrieves the AssemblyID field.
                /// </summary>
                public ulong AssemblyID => BitConverter.ToUInt64(_etwEvent.Data[Offset_AssemblyID..]);

                /// <summary>
                /// Retrieves the AppDomainID field.
                /// </summary>
                public ulong AppDomainID => BitConverter.ToUInt64(_etwEvent.Data[Offset_AppDomainID..]);

                /// <summary>
                /// Retrieves the AssemblyFlags field.
                /// </summary>
                public AssemblyFlagsMap AssemblyFlags => (AssemblyFlagsMap)BitConverter.ToUInt32(_etwEvent.Data[Offset_AssemblyFlags..]);

                /// <summary>
                /// Retrieves the FullyQualifiedAssemblyName field.
                /// </summary>
                public string FullyQualifiedAssemblyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FullyQualifiedAssemblyName..]);

                /// <summary>
                /// Creates a new LoaderAssemblyDCStopData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public LoaderAssemblyDCStopData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_AssemblyID = -1;
                    _offset_AppDomainID = -1;
                    _offset_AssemblyFlags = -1;
                    _offset_FullyQualifiedAssemblyName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a LoaderAppDomainDCStart event.
        /// </summary>
        public readonly ref struct LoaderAppDomainDCStartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "LoaderAppDomainDCStart";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 157,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = (EtwEventOpcode)Opcodes.AppDomainDCStart,
                Task = (ushort)Tasks.Loader,
                Keyword = (ulong)Keywords.LoaderRundownKeyword
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

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
            public LoaderAppDomainDCStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new LoaderAppDomainDCStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public LoaderAppDomainDCStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a LoaderAppDomainDCStart event.
            /// </summary>
            public ref struct LoaderAppDomainDCStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_AppDomainID;
                private int _offset_AppDomainFlags;
                private int _offset_AppDomainName;

                private int Offset_AppDomainID
                {
                    get
                    {
                        if (_offset_AppDomainID == -1)
                        {
                            _offset_AppDomainID = 0;
                        }

                        return _offset_AppDomainID;
                    }
                }

                private int Offset_AppDomainFlags
                {
                    get
                    {
                        if (_offset_AppDomainFlags == -1)
                        {
                            _offset_AppDomainFlags = Offset_AppDomainID + 8;
                        }

                        return _offset_AppDomainFlags;
                    }
                }

                private int Offset_AppDomainName
                {
                    get
                    {
                        if (_offset_AppDomainName == -1)
                        {
                            _offset_AppDomainName = Offset_AppDomainFlags + 4;
                        }

                        return _offset_AppDomainName;
                    }
                }

                /// <summary>
                /// Retrieves the AppDomainID field.
                /// </summary>
                public ulong AppDomainID => BitConverter.ToUInt64(_etwEvent.Data[Offset_AppDomainID..]);

                /// <summary>
                /// Retrieves the AppDomainFlags field.
                /// </summary>
                public AppDomainFlagsMap AppDomainFlags => (AppDomainFlagsMap)BitConverter.ToUInt32(_etwEvent.Data[Offset_AppDomainFlags..]);

                /// <summary>
                /// Retrieves the AppDomainName field.
                /// </summary>
                public string AppDomainName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_AppDomainName..]);

                /// <summary>
                /// Creates a new LoaderAppDomainDCStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public LoaderAppDomainDCStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_AppDomainID = -1;
                    _offset_AppDomainFlags = -1;
                    _offset_AppDomainName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a LoaderAppDomainDCStop event.
        /// </summary>
        public readonly ref struct LoaderAppDomainDCStopEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "LoaderAppDomainDCStop";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 158,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = (EtwEventOpcode)Opcodes.AppDomainDCStop,
                Task = (ushort)Tasks.Loader,
                Keyword = (ulong)Keywords.LoaderRundownKeyword
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

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
            public LoaderAppDomainDCStopData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new LoaderAppDomainDCStopEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public LoaderAppDomainDCStopEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a LoaderAppDomainDCStop event.
            /// </summary>
            public ref struct LoaderAppDomainDCStopData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_AppDomainID;
                private int _offset_AppDomainFlags;
                private int _offset_AppDomainName;

                private int Offset_AppDomainID
                {
                    get
                    {
                        if (_offset_AppDomainID == -1)
                        {
                            _offset_AppDomainID = 0;
                        }

                        return _offset_AppDomainID;
                    }
                }

                private int Offset_AppDomainFlags
                {
                    get
                    {
                        if (_offset_AppDomainFlags == -1)
                        {
                            _offset_AppDomainFlags = Offset_AppDomainID + 8;
                        }

                        return _offset_AppDomainFlags;
                    }
                }

                private int Offset_AppDomainName
                {
                    get
                    {
                        if (_offset_AppDomainName == -1)
                        {
                            _offset_AppDomainName = Offset_AppDomainFlags + 4;
                        }

                        return _offset_AppDomainName;
                    }
                }

                /// <summary>
                /// Retrieves the AppDomainID field.
                /// </summary>
                public ulong AppDomainID => BitConverter.ToUInt64(_etwEvent.Data[Offset_AppDomainID..]);

                /// <summary>
                /// Retrieves the AppDomainFlags field.
                /// </summary>
                public AppDomainFlagsMap AppDomainFlags => (AppDomainFlagsMap)BitConverter.ToUInt32(_etwEvent.Data[Offset_AppDomainFlags..]);

                /// <summary>
                /// Retrieves the AppDomainName field.
                /// </summary>
                public string AppDomainName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_AppDomainName..]);

                /// <summary>
                /// Creates a new LoaderAppDomainDCStopData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public LoaderAppDomainDCStopData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_AppDomainID = -1;
                    _offset_AppDomainFlags = -1;
                    _offset_AppDomainName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a LoaderThreadDCStop event.
        /// </summary>
        public readonly ref struct LoaderThreadDCStopEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "LoaderThreadDCStop";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 159,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = (EtwEventOpcode)Opcodes.ThreadDCStop,
                Task = (ushort)Tasks.Loader,
                Keyword = (ulong)Keywords.AppDomainResourceManagementRundownKeyword | (ulong)Keywords.ThreadingKeyword
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

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
            public LoaderThreadDCStopData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new LoaderThreadDCStopEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public LoaderThreadDCStopEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a LoaderThreadDCStop event.
            /// </summary>
            public ref struct LoaderThreadDCStopData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ManagedThreadID;
                private int _offset_AppDomainID;
                private int _offset_Flags;
                private int _offset_ManagedThreadIndex;
                private int _offset_OSThreadID;
                private int _offset_ClrInstanceID;

                private int Offset_ManagedThreadID
                {
                    get
                    {
                        if (_offset_ManagedThreadID == -1)
                        {
                            _offset_ManagedThreadID = 0;
                        }

                        return _offset_ManagedThreadID;
                    }
                }

                private int Offset_AppDomainID
                {
                    get
                    {
                        if (_offset_AppDomainID == -1)
                        {
                            _offset_AppDomainID = Offset_ManagedThreadID + 8;
                        }

                        return _offset_AppDomainID;
                    }
                }

                private int Offset_Flags
                {
                    get
                    {
                        if (_offset_Flags == -1)
                        {
                            _offset_Flags = Offset_AppDomainID + 8;
                        }

                        return _offset_Flags;
                    }
                }

                private int Offset_ManagedThreadIndex
                {
                    get
                    {
                        if (_offset_ManagedThreadIndex == -1)
                        {
                            _offset_ManagedThreadIndex = Offset_Flags + 4;
                        }

                        return _offset_ManagedThreadIndex;
                    }
                }

                private int Offset_OSThreadID
                {
                    get
                    {
                        if (_offset_OSThreadID == -1)
                        {
                            _offset_OSThreadID = Offset_ManagedThreadIndex + 4;
                        }

                        return _offset_OSThreadID;
                    }
                }

                private int Offset_ClrInstanceID
                {
                    get
                    {
                        if (_offset_ClrInstanceID == -1)
                        {
                            _offset_ClrInstanceID = Offset_OSThreadID + 4;
                        }

                        return _offset_ClrInstanceID;
                    }
                }

                /// <summary>
                /// Retrieves the ManagedThreadID field.
                /// </summary>
                public ulong ManagedThreadID => BitConverter.ToUInt64(_etwEvent.Data[Offset_ManagedThreadID..]);

                /// <summary>
                /// Retrieves the AppDomainID field.
                /// </summary>
                public ulong AppDomainID => BitConverter.ToUInt64(_etwEvent.Data[Offset_AppDomainID..]);

                /// <summary>
                /// Retrieves the Flags field.
                /// </summary>
                public ThreadFlagsMap Flags => (ThreadFlagsMap)BitConverter.ToUInt32(_etwEvent.Data[Offset_Flags..]);

                /// <summary>
                /// Retrieves the ManagedThreadIndex field.
                /// </summary>
                public uint ManagedThreadIndex => BitConverter.ToUInt32(_etwEvent.Data[Offset_ManagedThreadIndex..]);

                /// <summary>
                /// Retrieves the OSThreadID field.
                /// </summary>
                public uint OSThreadID => BitConverter.ToUInt32(_etwEvent.Data[Offset_OSThreadID..]);

                /// <summary>
                /// Retrieves the ClrInstanceID field.
                /// </summary>
                public ushort ClrInstanceID => BitConverter.ToUInt16(_etwEvent.Data[Offset_ClrInstanceID..]);

                /// <summary>
                /// Creates a new LoaderThreadDCStopData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public LoaderThreadDCStopData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ManagedThreadID = -1;
                    _offset_AppDomainID = -1;
                    _offset_Flags = -1;
                    _offset_ManagedThreadIndex = -1;
                    _offset_OSThreadID = -1;
                    _offset_ClrInstanceID = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ClrPerfTrackModuleRangeDCStart event.
        /// </summary>
        public readonly ref struct ClrPerfTrackModuleRangeDCStartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ClrPerfTrackModuleRangeDCStart";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 160,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = (EtwEventOpcode)Opcodes.ModuleRangeDCStart,
                Task = (ushort)Tasks.ClrPerfTrack,
                Keyword = (ulong)Keywords.PerfTrackRundownKeyword
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

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
            public ClrPerfTrackModuleRangeDCStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ClrPerfTrackModuleRangeDCStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ClrPerfTrackModuleRangeDCStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ClrPerfTrackModuleRangeDCStart event.
            /// </summary>
            public ref struct ClrPerfTrackModuleRangeDCStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ClrInstanceID;
                private int _offset_ModuleID;
                private int _offset_RangeBegin;
                private int _offset_RangeSize;
                private int _offset_RangeType;

                private int Offset_ClrInstanceID
                {
                    get
                    {
                        if (_offset_ClrInstanceID == -1)
                        {
                            _offset_ClrInstanceID = 0;
                        }

                        return _offset_ClrInstanceID;
                    }
                }

                private int Offset_ModuleID
                {
                    get
                    {
                        if (_offset_ModuleID == -1)
                        {
                            _offset_ModuleID = Offset_ClrInstanceID + 2;
                        }

                        return _offset_ModuleID;
                    }
                }

                private int Offset_RangeBegin
                {
                    get
                    {
                        if (_offset_RangeBegin == -1)
                        {
                            _offset_RangeBegin = Offset_ModuleID + 8;
                        }

                        return _offset_RangeBegin;
                    }
                }

                private int Offset_RangeSize
                {
                    get
                    {
                        if (_offset_RangeSize == -1)
                        {
                            _offset_RangeSize = Offset_RangeBegin + 4;
                        }

                        return _offset_RangeSize;
                    }
                }

                private int Offset_RangeType
                {
                    get
                    {
                        if (_offset_RangeType == -1)
                        {
                            _offset_RangeType = Offset_RangeSize + 4;
                        }

                        return _offset_RangeType;
                    }
                }

                /// <summary>
                /// Retrieves the ClrInstanceID field.
                /// </summary>
                public ushort ClrInstanceID => BitConverter.ToUInt16(_etwEvent.Data[Offset_ClrInstanceID..]);

                /// <summary>
                /// Retrieves the ModuleID field.
                /// </summary>
                public ulong ModuleID => BitConverter.ToUInt64(_etwEvent.Data[Offset_ModuleID..]);

                /// <summary>
                /// Retrieves the RangeBegin field.
                /// </summary>
                public uint RangeBegin => BitConverter.ToUInt32(_etwEvent.Data[Offset_RangeBegin..]);

                /// <summary>
                /// Retrieves the RangeSize field.
                /// </summary>
                public uint RangeSize => BitConverter.ToUInt32(_etwEvent.Data[Offset_RangeSize..]);

                /// <summary>
                /// Retrieves the RangeType field.
                /// </summary>
                public ModuleRangeTypeMap RangeType => (ModuleRangeTypeMap)_etwEvent.Data[Offset_RangeType];

                /// <summary>
                /// Creates a new ClrPerfTrackModuleRangeDCStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ClrPerfTrackModuleRangeDCStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ClrInstanceID = -1;
                    _offset_ModuleID = -1;
                    _offset_RangeBegin = -1;
                    _offset_RangeSize = -1;
                    _offset_RangeType = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ClrPerfTrackModuleRangeDCEnd event.
        /// </summary>
        public readonly ref struct ClrPerfTrackModuleRangeDCEndEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ClrPerfTrackModuleRangeDCEnd";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 161,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = (EtwEventOpcode)Opcodes.ModuleRangeDCEnd,
                Task = (ushort)Tasks.ClrPerfTrack,
                Keyword = (ulong)Keywords.PerfTrackRundownKeyword
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

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
            public ClrPerfTrackModuleRangeDCEndData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ClrPerfTrackModuleRangeDCEndEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ClrPerfTrackModuleRangeDCEndEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ClrPerfTrackModuleRangeDCEnd event.
            /// </summary>
            public ref struct ClrPerfTrackModuleRangeDCEndData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ClrInstanceID;
                private int _offset_ModuleID;
                private int _offset_RangeBegin;
                private int _offset_RangeSize;
                private int _offset_RangeType;

                private int Offset_ClrInstanceID
                {
                    get
                    {
                        if (_offset_ClrInstanceID == -1)
                        {
                            _offset_ClrInstanceID = 0;
                        }

                        return _offset_ClrInstanceID;
                    }
                }

                private int Offset_ModuleID
                {
                    get
                    {
                        if (_offset_ModuleID == -1)
                        {
                            _offset_ModuleID = Offset_ClrInstanceID + 2;
                        }

                        return _offset_ModuleID;
                    }
                }

                private int Offset_RangeBegin
                {
                    get
                    {
                        if (_offset_RangeBegin == -1)
                        {
                            _offset_RangeBegin = Offset_ModuleID + 8;
                        }

                        return _offset_RangeBegin;
                    }
                }

                private int Offset_RangeSize
                {
                    get
                    {
                        if (_offset_RangeSize == -1)
                        {
                            _offset_RangeSize = Offset_RangeBegin + 4;
                        }

                        return _offset_RangeSize;
                    }
                }

                private int Offset_RangeType
                {
                    get
                    {
                        if (_offset_RangeType == -1)
                        {
                            _offset_RangeType = Offset_RangeSize + 4;
                        }

                        return _offset_RangeType;
                    }
                }

                /// <summary>
                /// Retrieves the ClrInstanceID field.
                /// </summary>
                public ushort ClrInstanceID => BitConverter.ToUInt16(_etwEvent.Data[Offset_ClrInstanceID..]);

                /// <summary>
                /// Retrieves the ModuleID field.
                /// </summary>
                public ulong ModuleID => BitConverter.ToUInt64(_etwEvent.Data[Offset_ModuleID..]);

                /// <summary>
                /// Retrieves the RangeBegin field.
                /// </summary>
                public uint RangeBegin => BitConverter.ToUInt32(_etwEvent.Data[Offset_RangeBegin..]);

                /// <summary>
                /// Retrieves the RangeSize field.
                /// </summary>
                public uint RangeSize => BitConverter.ToUInt32(_etwEvent.Data[Offset_RangeSize..]);

                /// <summary>
                /// Retrieves the RangeType field.
                /// </summary>
                public ModuleRangeTypeMap RangeType => (ModuleRangeTypeMap)_etwEvent.Data[Offset_RangeType];

                /// <summary>
                /// Creates a new ClrPerfTrackModuleRangeDCEndData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ClrPerfTrackModuleRangeDCEndData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ClrInstanceID = -1;
                    _offset_ModuleID = -1;
                    _offset_RangeBegin = -1;
                    _offset_RangeSize = -1;
                    _offset_RangeType = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a RuntimeStart event.
        /// </summary>
        public readonly ref struct RuntimeStartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "RuntimeStart";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 187,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Start,
                Task = (ushort)Tasks.Runtime,
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
            public RuntimeStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new RuntimeStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public RuntimeStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a RuntimeStart event.
            /// </summary>
            public ref struct RuntimeStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ClrInstanceID;
                private int _offset_Sku;
                private int _offset_BclMajorVersion;
                private int _offset_BclMinorVersion;
                private int _offset_BclBuildNumber;
                private int _offset_BclQfeNumber;
                private int _offset_VMMajorVersion;
                private int _offset_VMMinorVersion;
                private int _offset_VMBuildNumber;
                private int _offset_VMQfeNumber;
                private int _offset_StartupFlags;
                private int _offset_StartupMode;
                private int _offset_CommandLine;
                private int _offset_ComObjectGuid;
                private int _offset_RuntimeDllPath;

                private int Offset_ClrInstanceID
                {
                    get
                    {
                        if (_offset_ClrInstanceID == -1)
                        {
                            _offset_ClrInstanceID = 0;
                        }

                        return _offset_ClrInstanceID;
                    }
                }

                private int Offset_Sku
                {
                    get
                    {
                        if (_offset_Sku == -1)
                        {
                            _offset_Sku = Offset_ClrInstanceID + 2;
                        }

                        return _offset_Sku;
                    }
                }

                private int Offset_BclMajorVersion
                {
                    get
                    {
                        if (_offset_BclMajorVersion == -1)
                        {
                            _offset_BclMajorVersion = Offset_Sku + 2;
                        }

                        return _offset_BclMajorVersion;
                    }
                }

                private int Offset_BclMinorVersion
                {
                    get
                    {
                        if (_offset_BclMinorVersion == -1)
                        {
                            _offset_BclMinorVersion = Offset_BclMajorVersion + 2;
                        }

                        return _offset_BclMinorVersion;
                    }
                }

                private int Offset_BclBuildNumber
                {
                    get
                    {
                        if (_offset_BclBuildNumber == -1)
                        {
                            _offset_BclBuildNumber = Offset_BclMinorVersion + 2;
                        }

                        return _offset_BclBuildNumber;
                    }
                }

                private int Offset_BclQfeNumber
                {
                    get
                    {
                        if (_offset_BclQfeNumber == -1)
                        {
                            _offset_BclQfeNumber = Offset_BclBuildNumber + 2;
                        }

                        return _offset_BclQfeNumber;
                    }
                }

                private int Offset_VMMajorVersion
                {
                    get
                    {
                        if (_offset_VMMajorVersion == -1)
                        {
                            _offset_VMMajorVersion = Offset_BclQfeNumber + 2;
                        }

                        return _offset_VMMajorVersion;
                    }
                }

                private int Offset_VMMinorVersion
                {
                    get
                    {
                        if (_offset_VMMinorVersion == -1)
                        {
                            _offset_VMMinorVersion = Offset_VMMajorVersion + 2;
                        }

                        return _offset_VMMinorVersion;
                    }
                }

                private int Offset_VMBuildNumber
                {
                    get
                    {
                        if (_offset_VMBuildNumber == -1)
                        {
                            _offset_VMBuildNumber = Offset_VMMinorVersion + 2;
                        }

                        return _offset_VMBuildNumber;
                    }
                }

                private int Offset_VMQfeNumber
                {
                    get
                    {
                        if (_offset_VMQfeNumber == -1)
                        {
                            _offset_VMQfeNumber = Offset_VMBuildNumber + 2;
                        }

                        return _offset_VMQfeNumber;
                    }
                }

                private int Offset_StartupFlags
                {
                    get
                    {
                        if (_offset_StartupFlags == -1)
                        {
                            _offset_StartupFlags = Offset_VMQfeNumber + 2;
                        }

                        return _offset_StartupFlags;
                    }
                }

                private int Offset_StartupMode
                {
                    get
                    {
                        if (_offset_StartupMode == -1)
                        {
                            _offset_StartupMode = Offset_StartupFlags + 4;
                        }

                        return _offset_StartupMode;
                    }
                }

                private int Offset_CommandLine
                {
                    get
                    {
                        if (_offset_CommandLine == -1)
                        {
                            _offset_CommandLine = Offset_StartupMode + 1;
                        }

                        return _offset_CommandLine;
                    }
                }

                private int Offset_ComObjectGuid
                {
                    get
                    {
                        if (_offset_ComObjectGuid == -1)
                        {
                            _offset_ComObjectGuid = Offset_CommandLine + _etwEvent.UnicodeStringLength(Offset_CommandLine);
                        }

                        return _offset_ComObjectGuid;
                    }
                }

                private int Offset_RuntimeDllPath
                {
                    get
                    {
                        if (_offset_RuntimeDllPath == -1)
                        {
                            _offset_RuntimeDllPath = Offset_ComObjectGuid + 16;
                        }

                        return _offset_RuntimeDllPath;
                    }
                }

                /// <summary>
                /// Retrieves the ClrInstanceID field.
                /// </summary>
                public ushort ClrInstanceID => BitConverter.ToUInt16(_etwEvent.Data[Offset_ClrInstanceID..]);

                /// <summary>
                /// Retrieves the Sku field.
                /// </summary>
                public RuntimeSkuMap Sku => (RuntimeSkuMap)BitConverter.ToUInt16(_etwEvent.Data[Offset_Sku..]);

                /// <summary>
                /// Retrieves the BclMajorVersion field.
                /// </summary>
                public ushort BclMajorVersion => BitConverter.ToUInt16(_etwEvent.Data[Offset_BclMajorVersion..]);

                /// <summary>
                /// Retrieves the BclMinorVersion field.
                /// </summary>
                public ushort BclMinorVersion => BitConverter.ToUInt16(_etwEvent.Data[Offset_BclMinorVersion..]);

                /// <summary>
                /// Retrieves the BclBuildNumber field.
                /// </summary>
                public ushort BclBuildNumber => BitConverter.ToUInt16(_etwEvent.Data[Offset_BclBuildNumber..]);

                /// <summary>
                /// Retrieves the BclQfeNumber field.
                /// </summary>
                public ushort BclQfeNumber => BitConverter.ToUInt16(_etwEvent.Data[Offset_BclQfeNumber..]);

                /// <summary>
                /// Retrieves the VMMajorVersion field.
                /// </summary>
                public ushort VMMajorVersion => BitConverter.ToUInt16(_etwEvent.Data[Offset_VMMajorVersion..]);

                /// <summary>
                /// Retrieves the VMMinorVersion field.
                /// </summary>
                public ushort VMMinorVersion => BitConverter.ToUInt16(_etwEvent.Data[Offset_VMMinorVersion..]);

                /// <summary>
                /// Retrieves the VMBuildNumber field.
                /// </summary>
                public ushort VMBuildNumber => BitConverter.ToUInt16(_etwEvent.Data[Offset_VMBuildNumber..]);

                /// <summary>
                /// Retrieves the VMQfeNumber field.
                /// </summary>
                public ushort VMQfeNumber => BitConverter.ToUInt16(_etwEvent.Data[Offset_VMQfeNumber..]);

                /// <summary>
                /// Retrieves the StartupFlags field.
                /// </summary>
                public StartupFlagsMap StartupFlags => (StartupFlagsMap)BitConverter.ToUInt32(_etwEvent.Data[Offset_StartupFlags..]);

                /// <summary>
                /// Retrieves the StartupMode field.
                /// </summary>
                public StartupModeMap StartupMode => (StartupModeMap)_etwEvent.Data[Offset_StartupMode];

                /// <summary>
                /// Retrieves the CommandLine field.
                /// </summary>
                public string CommandLine => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_CommandLine..]);

                /// <summary>
                /// Retrieves the ComObjectGuid field.
                /// </summary>
                public Guid ComObjectGuid => new(_etwEvent.Data[Offset_ComObjectGuid..]);

                /// <summary>
                /// Retrieves the RuntimeDllPath field.
                /// </summary>
                public string RuntimeDllPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_RuntimeDllPath..]);

                /// <summary>
                /// Creates a new RuntimeStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public RuntimeStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ClrInstanceID = -1;
                    _offset_Sku = -1;
                    _offset_BclMajorVersion = -1;
                    _offset_BclMinorVersion = -1;
                    _offset_BclBuildNumber = -1;
                    _offset_BclQfeNumber = -1;
                    _offset_VMMajorVersion = -1;
                    _offset_VMMinorVersion = -1;
                    _offset_VMBuildNumber = -1;
                    _offset_VMQfeNumber = -1;
                    _offset_StartupFlags = -1;
                    _offset_StartupMode = -1;
                    _offset_CommandLine = -1;
                    _offset_ComObjectGuid = -1;
                    _offset_RuntimeDllPath = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a MethodDCStart event.
        /// </summary>
        public readonly ref struct MethodDCStartEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "MethodDCStart";

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
                Opcode = (EtwEventOpcode)Opcodes.DCStart,
                Task = (ushort)Tasks.Method,
                Keyword = (ulong)Keywords.JitRundownKeyword | (ulong)Keywords.NGenRundownKeyword
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

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
            public MethodDCStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new MethodDCStartEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public MethodDCStartEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a MethodDCStart event.
            /// </summary>
            public ref struct MethodDCStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_MethodID;
                private int _offset_ModuleID;
                private int _offset_MethodStartAddress;
                private int _offset_MethodSize;
                private int _offset_MethodToken;
                private int _offset_MethodFlags;
                private int _offset_ClrInstanceID;

                private int Offset_MethodID
                {
                    get
                    {
                        if (_offset_MethodID == -1)
                        {
                            _offset_MethodID = 0;
                        }

                        return _offset_MethodID;
                    }
                }

                private int Offset_ModuleID
                {
                    get
                    {
                        if (_offset_ModuleID == -1)
                        {
                            _offset_ModuleID = Offset_MethodID + 8;
                        }

                        return _offset_ModuleID;
                    }
                }

                private int Offset_MethodStartAddress
                {
                    get
                    {
                        if (_offset_MethodStartAddress == -1)
                        {
                            _offset_MethodStartAddress = Offset_ModuleID + 8;
                        }

                        return _offset_MethodStartAddress;
                    }
                }

                private int Offset_MethodSize
                {
                    get
                    {
                        if (_offset_MethodSize == -1)
                        {
                            _offset_MethodSize = Offset_MethodStartAddress + 8;
                        }

                        return _offset_MethodSize;
                    }
                }

                private int Offset_MethodToken
                {
                    get
                    {
                        if (_offset_MethodToken == -1)
                        {
                            _offset_MethodToken = Offset_MethodSize + 4;
                        }

                        return _offset_MethodToken;
                    }
                }

                private int Offset_MethodFlags
                {
                    get
                    {
                        if (_offset_MethodFlags == -1)
                        {
                            _offset_MethodFlags = Offset_MethodToken + 4;
                        }

                        return _offset_MethodFlags;
                    }
                }

                private int Offset_ClrInstanceID
                {
                    get
                    {
                        if (_offset_ClrInstanceID == -1)
                        {
                            _offset_ClrInstanceID = Offset_MethodFlags + 4;
                        }

                        return _offset_ClrInstanceID;
                    }
                }

                /// <summary>
                /// Retrieves the MethodID field.
                /// </summary>
                public ulong MethodID => BitConverter.ToUInt64(_etwEvent.Data[Offset_MethodID..]);

                /// <summary>
                /// Retrieves the ModuleID field.
                /// </summary>
                public ulong ModuleID => BitConverter.ToUInt64(_etwEvent.Data[Offset_ModuleID..]);

                /// <summary>
                /// Retrieves the MethodStartAddress field.
                /// </summary>
                public ulong MethodStartAddress => BitConverter.ToUInt64(_etwEvent.Data[Offset_MethodStartAddress..]);

                /// <summary>
                /// Retrieves the MethodSize field.
                /// </summary>
                public uint MethodSize => BitConverter.ToUInt32(_etwEvent.Data[Offset_MethodSize..]);

                /// <summary>
                /// Retrieves the MethodToken field.
                /// </summary>
                public uint MethodToken => BitConverter.ToUInt32(_etwEvent.Data[Offset_MethodToken..]);

                /// <summary>
                /// Retrieves the MethodFlags field.
                /// </summary>
                public MethodFlagsMap MethodFlags => (MethodFlagsMap)BitConverter.ToUInt32(_etwEvent.Data[Offset_MethodFlags..]);

                /// <summary>
                /// Retrieves the ClrInstanceID field.
                /// </summary>
                public ushort ClrInstanceID => BitConverter.ToUInt16(_etwEvent.Data[Offset_ClrInstanceID..]);

                /// <summary>
                /// Creates a new MethodDCStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public MethodDCStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_MethodID = -1;
                    _offset_ModuleID = -1;
                    _offset_MethodStartAddress = -1;
                    _offset_MethodSize = -1;
                    _offset_MethodToken = -1;
                    _offset_MethodFlags = -1;
                    _offset_ClrInstanceID = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a MethodDCStop event.
        /// </summary>
        public readonly ref struct MethodDCStopEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "MethodDCStop";

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
                Opcode = (EtwEventOpcode)Opcodes.DCStop,
                Task = (ushort)Tasks.Method,
                Keyword = (ulong)Keywords.JitRundownKeyword | (ulong)Keywords.NGenRundownKeyword
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

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
            public MethodDCStopData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new MethodDCStopEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public MethodDCStopEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a MethodDCStop event.
            /// </summary>
            public ref struct MethodDCStopData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_MethodID;
                private int _offset_ModuleID;
                private int _offset_MethodStartAddress;
                private int _offset_MethodSize;
                private int _offset_MethodToken;
                private int _offset_MethodFlags;
                private int _offset_ClrInstanceID;

                private int Offset_MethodID
                {
                    get
                    {
                        if (_offset_MethodID == -1)
                        {
                            _offset_MethodID = 0;
                        }

                        return _offset_MethodID;
                    }
                }

                private int Offset_ModuleID
                {
                    get
                    {
                        if (_offset_ModuleID == -1)
                        {
                            _offset_ModuleID = Offset_MethodID + 8;
                        }

                        return _offset_ModuleID;
                    }
                }

                private int Offset_MethodStartAddress
                {
                    get
                    {
                        if (_offset_MethodStartAddress == -1)
                        {
                            _offset_MethodStartAddress = Offset_ModuleID + 8;
                        }

                        return _offset_MethodStartAddress;
                    }
                }

                private int Offset_MethodSize
                {
                    get
                    {
                        if (_offset_MethodSize == -1)
                        {
                            _offset_MethodSize = Offset_MethodStartAddress + 8;
                        }

                        return _offset_MethodSize;
                    }
                }

                private int Offset_MethodToken
                {
                    get
                    {
                        if (_offset_MethodToken == -1)
                        {
                            _offset_MethodToken = Offset_MethodSize + 4;
                        }

                        return _offset_MethodToken;
                    }
                }

                private int Offset_MethodFlags
                {
                    get
                    {
                        if (_offset_MethodFlags == -1)
                        {
                            _offset_MethodFlags = Offset_MethodToken + 4;
                        }

                        return _offset_MethodFlags;
                    }
                }

                private int Offset_ClrInstanceID
                {
                    get
                    {
                        if (_offset_ClrInstanceID == -1)
                        {
                            _offset_ClrInstanceID = Offset_MethodFlags + 4;
                        }

                        return _offset_ClrInstanceID;
                    }
                }

                /// <summary>
                /// Retrieves the MethodID field.
                /// </summary>
                public ulong MethodID => BitConverter.ToUInt64(_etwEvent.Data[Offset_MethodID..]);

                /// <summary>
                /// Retrieves the ModuleID field.
                /// </summary>
                public ulong ModuleID => BitConverter.ToUInt64(_etwEvent.Data[Offset_ModuleID..]);

                /// <summary>
                /// Retrieves the MethodStartAddress field.
                /// </summary>
                public ulong MethodStartAddress => BitConverter.ToUInt64(_etwEvent.Data[Offset_MethodStartAddress..]);

                /// <summary>
                /// Retrieves the MethodSize field.
                /// </summary>
                public uint MethodSize => BitConverter.ToUInt32(_etwEvent.Data[Offset_MethodSize..]);

                /// <summary>
                /// Retrieves the MethodToken field.
                /// </summary>
                public uint MethodToken => BitConverter.ToUInt32(_etwEvent.Data[Offset_MethodToken..]);

                /// <summary>
                /// Retrieves the MethodFlags field.
                /// </summary>
                public MethodFlagsMap MethodFlags => (MethodFlagsMap)BitConverter.ToUInt32(_etwEvent.Data[Offset_MethodFlags..]);

                /// <summary>
                /// Retrieves the ClrInstanceID field.
                /// </summary>
                public ushort ClrInstanceID => BitConverter.ToUInt16(_etwEvent.Data[Offset_ClrInstanceID..]);

                /// <summary>
                /// Creates a new MethodDCStopData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public MethodDCStopData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_MethodID = -1;
                    _offset_ModuleID = -1;
                    _offset_MethodStartAddress = -1;
                    _offset_MethodSize = -1;
                    _offset_MethodToken = -1;
                    _offset_MethodFlags = -1;
                    _offset_ClrInstanceID = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a MethodDCStartVerbose event.
        /// </summary>
        public readonly ref struct MethodDCStartVerboseEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "MethodDCStartVerbose";

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
                Opcode = (EtwEventOpcode)Opcodes.DCStartVerbose,
                Task = (ushort)Tasks.Method,
                Keyword = (ulong)Keywords.JitRundownKeyword | (ulong)Keywords.NGenRundownKeyword
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

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
            public MethodDCStartVerboseData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new MethodDCStartVerboseEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public MethodDCStartVerboseEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a MethodDCStartVerbose event.
            /// </summary>
            public ref struct MethodDCStartVerboseData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_MethodID;
                private int _offset_ModuleID;
                private int _offset_MethodStartAddress;
                private int _offset_MethodSize;
                private int _offset_MethodToken;
                private int _offset_MethodFlags;
                private int _offset_MethodNamespace;
                private int _offset_MethodName;
                private int _offset_MethodSignature;
                private int _offset_ClrInstanceID;

                private int Offset_MethodID
                {
                    get
                    {
                        if (_offset_MethodID == -1)
                        {
                            _offset_MethodID = 0;
                        }

                        return _offset_MethodID;
                    }
                }

                private int Offset_ModuleID
                {
                    get
                    {
                        if (_offset_ModuleID == -1)
                        {
                            _offset_ModuleID = Offset_MethodID + 8;
                        }

                        return _offset_ModuleID;
                    }
                }

                private int Offset_MethodStartAddress
                {
                    get
                    {
                        if (_offset_MethodStartAddress == -1)
                        {
                            _offset_MethodStartAddress = Offset_ModuleID + 8;
                        }

                        return _offset_MethodStartAddress;
                    }
                }

                private int Offset_MethodSize
                {
                    get
                    {
                        if (_offset_MethodSize == -1)
                        {
                            _offset_MethodSize = Offset_MethodStartAddress + 8;
                        }

                        return _offset_MethodSize;
                    }
                }

                private int Offset_MethodToken
                {
                    get
                    {
                        if (_offset_MethodToken == -1)
                        {
                            _offset_MethodToken = Offset_MethodSize + 4;
                        }

                        return _offset_MethodToken;
                    }
                }

                private int Offset_MethodFlags
                {
                    get
                    {
                        if (_offset_MethodFlags == -1)
                        {
                            _offset_MethodFlags = Offset_MethodToken + 4;
                        }

                        return _offset_MethodFlags;
                    }
                }

                private int Offset_MethodNamespace
                {
                    get
                    {
                        if (_offset_MethodNamespace == -1)
                        {
                            _offset_MethodNamespace = Offset_MethodFlags + 4;
                        }

                        return _offset_MethodNamespace;
                    }
                }

                private int Offset_MethodName
                {
                    get
                    {
                        if (_offset_MethodName == -1)
                        {
                            _offset_MethodName = Offset_MethodNamespace + _etwEvent.UnicodeStringLength(Offset_MethodNamespace);
                        }

                        return _offset_MethodName;
                    }
                }

                private int Offset_MethodSignature
                {
                    get
                    {
                        if (_offset_MethodSignature == -1)
                        {
                            _offset_MethodSignature = Offset_MethodName + _etwEvent.UnicodeStringLength(Offset_MethodName);
                        }

                        return _offset_MethodSignature;
                    }
                }

                private int Offset_ClrInstanceID
                {
                    get
                    {
                        if (_offset_ClrInstanceID == -1)
                        {
                            _offset_ClrInstanceID = Offset_MethodSignature + _etwEvent.UnicodeStringLength(Offset_MethodSignature);
                        }

                        return _offset_ClrInstanceID;
                    }
                }

                /// <summary>
                /// Retrieves the MethodID field.
                /// </summary>
                public ulong MethodID => BitConverter.ToUInt64(_etwEvent.Data[Offset_MethodID..]);

                /// <summary>
                /// Retrieves the ModuleID field.
                /// </summary>
                public ulong ModuleID => BitConverter.ToUInt64(_etwEvent.Data[Offset_ModuleID..]);

                /// <summary>
                /// Retrieves the MethodStartAddress field.
                /// </summary>
                public ulong MethodStartAddress => BitConverter.ToUInt64(_etwEvent.Data[Offset_MethodStartAddress..]);

                /// <summary>
                /// Retrieves the MethodSize field.
                /// </summary>
                public uint MethodSize => BitConverter.ToUInt32(_etwEvent.Data[Offset_MethodSize..]);

                /// <summary>
                /// Retrieves the MethodToken field.
                /// </summary>
                public uint MethodToken => BitConverter.ToUInt32(_etwEvent.Data[Offset_MethodToken..]);

                /// <summary>
                /// Retrieves the MethodFlags field.
                /// </summary>
                public MethodFlagsMap MethodFlags => (MethodFlagsMap)BitConverter.ToUInt32(_etwEvent.Data[Offset_MethodFlags..]);

                /// <summary>
                /// Retrieves the MethodNamespace field.
                /// </summary>
                public string MethodNamespace => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_MethodNamespace..]);

                /// <summary>
                /// Retrieves the MethodName field.
                /// </summary>
                public string MethodName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_MethodName..]);

                /// <summary>
                /// Retrieves the MethodSignature field.
                /// </summary>
                public string MethodSignature => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_MethodSignature..]);

                /// <summary>
                /// Retrieves the ClrInstanceID field.
                /// </summary>
                public ushort ClrInstanceID => BitConverter.ToUInt16(_etwEvent.Data[Offset_ClrInstanceID..]);

                /// <summary>
                /// Creates a new MethodDCStartVerboseData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public MethodDCStartVerboseData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_MethodID = -1;
                    _offset_ModuleID = -1;
                    _offset_MethodStartAddress = -1;
                    _offset_MethodSize = -1;
                    _offset_MethodToken = -1;
                    _offset_MethodFlags = -1;
                    _offset_MethodNamespace = -1;
                    _offset_MethodName = -1;
                    _offset_MethodSignature = -1;
                    _offset_ClrInstanceID = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a MethodDCStopVerbose event.
        /// </summary>
        public readonly ref struct MethodDCStopVerboseEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "MethodDCStopVerbose";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 144,
                Version = 1,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = (EtwEventOpcode)Opcodes.DCStopVerbose,
                Task = (ushort)Tasks.Method,
                Keyword = (ulong)Keywords.JitRundownKeyword | (ulong)Keywords.NGenRundownKeyword
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

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
            public MethodDCStopVerboseData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new MethodDCStopVerboseEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public MethodDCStopVerboseEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a MethodDCStopVerbose event.
            /// </summary>
            public ref struct MethodDCStopVerboseData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_MethodID;
                private int _offset_ModuleID;
                private int _offset_MethodStartAddress;
                private int _offset_MethodSize;
                private int _offset_MethodToken;
                private int _offset_MethodFlags;
                private int _offset_MethodNamespace;
                private int _offset_MethodName;
                private int _offset_MethodSignature;
                private int _offset_ClrInstanceID;

                private int Offset_MethodID
                {
                    get
                    {
                        if (_offset_MethodID == -1)
                        {
                            _offset_MethodID = 0;
                        }

                        return _offset_MethodID;
                    }
                }

                private int Offset_ModuleID
                {
                    get
                    {
                        if (_offset_ModuleID == -1)
                        {
                            _offset_ModuleID = Offset_MethodID + 8;
                        }

                        return _offset_ModuleID;
                    }
                }

                private int Offset_MethodStartAddress
                {
                    get
                    {
                        if (_offset_MethodStartAddress == -1)
                        {
                            _offset_MethodStartAddress = Offset_ModuleID + 8;
                        }

                        return _offset_MethodStartAddress;
                    }
                }

                private int Offset_MethodSize
                {
                    get
                    {
                        if (_offset_MethodSize == -1)
                        {
                            _offset_MethodSize = Offset_MethodStartAddress + 8;
                        }

                        return _offset_MethodSize;
                    }
                }

                private int Offset_MethodToken
                {
                    get
                    {
                        if (_offset_MethodToken == -1)
                        {
                            _offset_MethodToken = Offset_MethodSize + 4;
                        }

                        return _offset_MethodToken;
                    }
                }

                private int Offset_MethodFlags
                {
                    get
                    {
                        if (_offset_MethodFlags == -1)
                        {
                            _offset_MethodFlags = Offset_MethodToken + 4;
                        }

                        return _offset_MethodFlags;
                    }
                }

                private int Offset_MethodNamespace
                {
                    get
                    {
                        if (_offset_MethodNamespace == -1)
                        {
                            _offset_MethodNamespace = Offset_MethodFlags + 4;
                        }

                        return _offset_MethodNamespace;
                    }
                }

                private int Offset_MethodName
                {
                    get
                    {
                        if (_offset_MethodName == -1)
                        {
                            _offset_MethodName = Offset_MethodNamespace + _etwEvent.UnicodeStringLength(Offset_MethodNamespace);
                        }

                        return _offset_MethodName;
                    }
                }

                private int Offset_MethodSignature
                {
                    get
                    {
                        if (_offset_MethodSignature == -1)
                        {
                            _offset_MethodSignature = Offset_MethodName + _etwEvent.UnicodeStringLength(Offset_MethodName);
                        }

                        return _offset_MethodSignature;
                    }
                }

                private int Offset_ClrInstanceID
                {
                    get
                    {
                        if (_offset_ClrInstanceID == -1)
                        {
                            _offset_ClrInstanceID = Offset_MethodSignature + _etwEvent.UnicodeStringLength(Offset_MethodSignature);
                        }

                        return _offset_ClrInstanceID;
                    }
                }

                /// <summary>
                /// Retrieves the MethodID field.
                /// </summary>
                public ulong MethodID => BitConverter.ToUInt64(_etwEvent.Data[Offset_MethodID..]);

                /// <summary>
                /// Retrieves the ModuleID field.
                /// </summary>
                public ulong ModuleID => BitConverter.ToUInt64(_etwEvent.Data[Offset_ModuleID..]);

                /// <summary>
                /// Retrieves the MethodStartAddress field.
                /// </summary>
                public ulong MethodStartAddress => BitConverter.ToUInt64(_etwEvent.Data[Offset_MethodStartAddress..]);

                /// <summary>
                /// Retrieves the MethodSize field.
                /// </summary>
                public uint MethodSize => BitConverter.ToUInt32(_etwEvent.Data[Offset_MethodSize..]);

                /// <summary>
                /// Retrieves the MethodToken field.
                /// </summary>
                public uint MethodToken => BitConverter.ToUInt32(_etwEvent.Data[Offset_MethodToken..]);

                /// <summary>
                /// Retrieves the MethodFlags field.
                /// </summary>
                public MethodFlagsMap MethodFlags => (MethodFlagsMap)BitConverter.ToUInt32(_etwEvent.Data[Offset_MethodFlags..]);

                /// <summary>
                /// Retrieves the MethodNamespace field.
                /// </summary>
                public string MethodNamespace => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_MethodNamespace..]);

                /// <summary>
                /// Retrieves the MethodName field.
                /// </summary>
                public string MethodName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_MethodName..]);

                /// <summary>
                /// Retrieves the MethodSignature field.
                /// </summary>
                public string MethodSignature => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_MethodSignature..]);

                /// <summary>
                /// Retrieves the ClrInstanceID field.
                /// </summary>
                public ushort ClrInstanceID => BitConverter.ToUInt16(_etwEvent.Data[Offset_ClrInstanceID..]);

                /// <summary>
                /// Creates a new MethodDCStopVerboseData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public MethodDCStopVerboseData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_MethodID = -1;
                    _offset_ModuleID = -1;
                    _offset_MethodStartAddress = -1;
                    _offset_MethodSize = -1;
                    _offset_MethodToken = -1;
                    _offset_MethodFlags = -1;
                    _offset_MethodNamespace = -1;
                    _offset_MethodName = -1;
                    _offset_MethodSignature = -1;
                    _offset_ClrInstanceID = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a MethodDCStartComplete event.
        /// </summary>
        public readonly ref struct MethodDCStartCompleteEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "MethodDCStartComplete";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 145,
                Version = 1,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = (EtwEventOpcode)Opcodes.DCStartComplete,
                Task = (ushort)Tasks.Method,
                Keyword = (ulong)Keywords.LoaderRundownKeyword | (ulong)Keywords.JitRundownKeyword | (ulong)Keywords.NGenRundownKeyword | (ulong)Keywords.JittedMethodILToNativeMapRundownKeyword
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

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
            public MethodDCStartCompleteData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new MethodDCStartCompleteEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public MethodDCStartCompleteEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a MethodDCStartComplete event.
            /// </summary>
            public ref struct MethodDCStartCompleteData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ClrInstanceID;

                private int Offset_ClrInstanceID
                {
                    get
                    {
                        if (_offset_ClrInstanceID == -1)
                        {
                            _offset_ClrInstanceID = 0;
                        }

                        return _offset_ClrInstanceID;
                    }
                }

                /// <summary>
                /// Retrieves the ClrInstanceID field.
                /// </summary>
                public ushort ClrInstanceID => BitConverter.ToUInt16(_etwEvent.Data[Offset_ClrInstanceID..]);

                /// <summary>
                /// Creates a new MethodDCStartCompleteData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public MethodDCStartCompleteData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ClrInstanceID = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a MethodDCStopComplete event.
        /// </summary>
        public readonly ref struct MethodDCStopCompleteEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "MethodDCStopComplete";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 146,
                Version = 1,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = (EtwEventOpcode)Opcodes.DCStopComplete,
                Task = (ushort)Tasks.Method,
                Keyword = (ulong)Keywords.LoaderRundownKeyword | (ulong)Keywords.JitRundownKeyword | (ulong)Keywords.NGenRundownKeyword | (ulong)Keywords.JittedMethodILToNativeMapRundownKeyword
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

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
            public MethodDCStopCompleteData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new MethodDCStopCompleteEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public MethodDCStopCompleteEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a MethodDCStopComplete event.
            /// </summary>
            public ref struct MethodDCStopCompleteData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ClrInstanceID;

                private int Offset_ClrInstanceID
                {
                    get
                    {
                        if (_offset_ClrInstanceID == -1)
                        {
                            _offset_ClrInstanceID = 0;
                        }

                        return _offset_ClrInstanceID;
                    }
                }

                /// <summary>
                /// Retrieves the ClrInstanceID field.
                /// </summary>
                public ushort ClrInstanceID => BitConverter.ToUInt16(_etwEvent.Data[Offset_ClrInstanceID..]);

                /// <summary>
                /// Creates a new MethodDCStopCompleteData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public MethodDCStopCompleteData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ClrInstanceID = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a MethodDCStartInit event.
        /// </summary>
        public readonly ref struct MethodDCStartInitEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "MethodDCStartInit";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 147,
                Version = 1,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = (EtwEventOpcode)Opcodes.DCStartInit,
                Task = (ushort)Tasks.Method,
                Keyword = (ulong)Keywords.LoaderRundownKeyword | (ulong)Keywords.JitRundownKeyword | (ulong)Keywords.NGenRundownKeyword | (ulong)Keywords.JittedMethodILToNativeMapRundownKeyword
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

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
            public MethodDCStartInitData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new MethodDCStartInitEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public MethodDCStartInitEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a MethodDCStartInit event.
            /// </summary>
            public ref struct MethodDCStartInitData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ClrInstanceID;

                private int Offset_ClrInstanceID
                {
                    get
                    {
                        if (_offset_ClrInstanceID == -1)
                        {
                            _offset_ClrInstanceID = 0;
                        }

                        return _offset_ClrInstanceID;
                    }
                }

                /// <summary>
                /// Retrieves the ClrInstanceID field.
                /// </summary>
                public ushort ClrInstanceID => BitConverter.ToUInt16(_etwEvent.Data[Offset_ClrInstanceID..]);

                /// <summary>
                /// Creates a new MethodDCStartInitData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public MethodDCStartInitData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ClrInstanceID = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a MethodDCStopInit event.
        /// </summary>
        public readonly ref struct MethodDCStopInitEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "MethodDCStopInit";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 148,
                Version = 1,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = (EtwEventOpcode)Opcodes.DCStopInit,
                Task = (ushort)Tasks.Method,
                Keyword = (ulong)Keywords.LoaderRundownKeyword | (ulong)Keywords.JitRundownKeyword | (ulong)Keywords.NGenRundownKeyword | (ulong)Keywords.JittedMethodILToNativeMapRundownKeyword
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

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
            public MethodDCStopInitData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new MethodDCStopInitEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public MethodDCStopInitEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a MethodDCStopInit event.
            /// </summary>
            public ref struct MethodDCStopInitData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ClrInstanceID;

                private int Offset_ClrInstanceID
                {
                    get
                    {
                        if (_offset_ClrInstanceID == -1)
                        {
                            _offset_ClrInstanceID = 0;
                        }

                        return _offset_ClrInstanceID;
                    }
                }

                /// <summary>
                /// Retrieves the ClrInstanceID field.
                /// </summary>
                public ushort ClrInstanceID => BitConverter.ToUInt16(_etwEvent.Data[Offset_ClrInstanceID..]);

                /// <summary>
                /// Creates a new MethodDCStopInitData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public MethodDCStopInitData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ClrInstanceID = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a LoaderDomainModuleDCStart event.
        /// </summary>
        public readonly ref struct LoaderDomainModuleDCStartEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "LoaderDomainModuleDCStart";

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
                Version = 1,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = (EtwEventOpcode)Opcodes.DomainModuleDCStart,
                Task = (ushort)Tasks.Loader,
                Keyword = (ulong)Keywords.LoaderRundownKeyword
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

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
            public LoaderDomainModuleDCStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new LoaderDomainModuleDCStartEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public LoaderDomainModuleDCStartEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a LoaderDomainModuleDCStart event.
            /// </summary>
            public ref struct LoaderDomainModuleDCStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ModuleID;
                private int _offset_AssemblyID;
                private int _offset_AppDomainID;
                private int _offset_ModuleFlags;
                private int _offset_Reserved1;
                private int _offset_ModuleILPath;
                private int _offset_ModuleNativePath;
                private int _offset_ClrInstanceID;

                private int Offset_ModuleID
                {
                    get
                    {
                        if (_offset_ModuleID == -1)
                        {
                            _offset_ModuleID = 0;
                        }

                        return _offset_ModuleID;
                    }
                }

                private int Offset_AssemblyID
                {
                    get
                    {
                        if (_offset_AssemblyID == -1)
                        {
                            _offset_AssemblyID = Offset_ModuleID + 8;
                        }

                        return _offset_AssemblyID;
                    }
                }

                private int Offset_AppDomainID
                {
                    get
                    {
                        if (_offset_AppDomainID == -1)
                        {
                            _offset_AppDomainID = Offset_AssemblyID + 8;
                        }

                        return _offset_AppDomainID;
                    }
                }

                private int Offset_ModuleFlags
                {
                    get
                    {
                        if (_offset_ModuleFlags == -1)
                        {
                            _offset_ModuleFlags = Offset_AppDomainID + 8;
                        }

                        return _offset_ModuleFlags;
                    }
                }

                private int Offset_Reserved1
                {
                    get
                    {
                        if (_offset_Reserved1 == -1)
                        {
                            _offset_Reserved1 = Offset_ModuleFlags + 4;
                        }

                        return _offset_Reserved1;
                    }
                }

                private int Offset_ModuleILPath
                {
                    get
                    {
                        if (_offset_ModuleILPath == -1)
                        {
                            _offset_ModuleILPath = Offset_Reserved1 + 4;
                        }

                        return _offset_ModuleILPath;
                    }
                }

                private int Offset_ModuleNativePath
                {
                    get
                    {
                        if (_offset_ModuleNativePath == -1)
                        {
                            _offset_ModuleNativePath = Offset_ModuleILPath + _etwEvent.UnicodeStringLength(Offset_ModuleILPath);
                        }

                        return _offset_ModuleNativePath;
                    }
                }

                private int Offset_ClrInstanceID
                {
                    get
                    {
                        if (_offset_ClrInstanceID == -1)
                        {
                            _offset_ClrInstanceID = Offset_ModuleNativePath + _etwEvent.UnicodeStringLength(Offset_ModuleNativePath);
                        }

                        return _offset_ClrInstanceID;
                    }
                }

                /// <summary>
                /// Retrieves the ModuleID field.
                /// </summary>
                public ulong ModuleID => BitConverter.ToUInt64(_etwEvent.Data[Offset_ModuleID..]);

                /// <summary>
                /// Retrieves the AssemblyID field.
                /// </summary>
                public ulong AssemblyID => BitConverter.ToUInt64(_etwEvent.Data[Offset_AssemblyID..]);

                /// <summary>
                /// Retrieves the AppDomainID field.
                /// </summary>
                public ulong AppDomainID => BitConverter.ToUInt64(_etwEvent.Data[Offset_AppDomainID..]);

                /// <summary>
                /// Retrieves the ModuleFlags field.
                /// </summary>
                public ModuleFlagsMap ModuleFlags => (ModuleFlagsMap)BitConverter.ToUInt32(_etwEvent.Data[Offset_ModuleFlags..]);

                /// <summary>
                /// Retrieves the Reserved1 field.
                /// </summary>
                public uint Reserved1 => BitConverter.ToUInt32(_etwEvent.Data[Offset_Reserved1..]);

                /// <summary>
                /// Retrieves the ModuleILPath field.
                /// </summary>
                public string ModuleILPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ModuleILPath..]);

                /// <summary>
                /// Retrieves the ModuleNativePath field.
                /// </summary>
                public string ModuleNativePath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ModuleNativePath..]);

                /// <summary>
                /// Retrieves the ClrInstanceID field.
                /// </summary>
                public ushort ClrInstanceID => BitConverter.ToUInt16(_etwEvent.Data[Offset_ClrInstanceID..]);

                /// <summary>
                /// Creates a new LoaderDomainModuleDCStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public LoaderDomainModuleDCStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ModuleID = -1;
                    _offset_AssemblyID = -1;
                    _offset_AppDomainID = -1;
                    _offset_ModuleFlags = -1;
                    _offset_Reserved1 = -1;
                    _offset_ModuleILPath = -1;
                    _offset_ModuleNativePath = -1;
                    _offset_ClrInstanceID = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a LoaderDomainModuleDCStop event.
        /// </summary>
        public readonly ref struct LoaderDomainModuleDCStopEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "LoaderDomainModuleDCStop";

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
                Version = 1,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = (EtwEventOpcode)Opcodes.DomainModuleDCStop,
                Task = (ushort)Tasks.Loader,
                Keyword = (ulong)Keywords.LoaderRundownKeyword
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

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
            public LoaderDomainModuleDCStopData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new LoaderDomainModuleDCStopEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public LoaderDomainModuleDCStopEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a LoaderDomainModuleDCStop event.
            /// </summary>
            public ref struct LoaderDomainModuleDCStopData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ModuleID;
                private int _offset_AssemblyID;
                private int _offset_AppDomainID;
                private int _offset_ModuleFlags;
                private int _offset_Reserved1;
                private int _offset_ModuleILPath;
                private int _offset_ModuleNativePath;
                private int _offset_ClrInstanceID;

                private int Offset_ModuleID
                {
                    get
                    {
                        if (_offset_ModuleID == -1)
                        {
                            _offset_ModuleID = 0;
                        }

                        return _offset_ModuleID;
                    }
                }

                private int Offset_AssemblyID
                {
                    get
                    {
                        if (_offset_AssemblyID == -1)
                        {
                            _offset_AssemblyID = Offset_ModuleID + 8;
                        }

                        return _offset_AssemblyID;
                    }
                }

                private int Offset_AppDomainID
                {
                    get
                    {
                        if (_offset_AppDomainID == -1)
                        {
                            _offset_AppDomainID = Offset_AssemblyID + 8;
                        }

                        return _offset_AppDomainID;
                    }
                }

                private int Offset_ModuleFlags
                {
                    get
                    {
                        if (_offset_ModuleFlags == -1)
                        {
                            _offset_ModuleFlags = Offset_AppDomainID + 8;
                        }

                        return _offset_ModuleFlags;
                    }
                }

                private int Offset_Reserved1
                {
                    get
                    {
                        if (_offset_Reserved1 == -1)
                        {
                            _offset_Reserved1 = Offset_ModuleFlags + 4;
                        }

                        return _offset_Reserved1;
                    }
                }

                private int Offset_ModuleILPath
                {
                    get
                    {
                        if (_offset_ModuleILPath == -1)
                        {
                            _offset_ModuleILPath = Offset_Reserved1 + 4;
                        }

                        return _offset_ModuleILPath;
                    }
                }

                private int Offset_ModuleNativePath
                {
                    get
                    {
                        if (_offset_ModuleNativePath == -1)
                        {
                            _offset_ModuleNativePath = Offset_ModuleILPath + _etwEvent.UnicodeStringLength(Offset_ModuleILPath);
                        }

                        return _offset_ModuleNativePath;
                    }
                }

                private int Offset_ClrInstanceID
                {
                    get
                    {
                        if (_offset_ClrInstanceID == -1)
                        {
                            _offset_ClrInstanceID = Offset_ModuleNativePath + _etwEvent.UnicodeStringLength(Offset_ModuleNativePath);
                        }

                        return _offset_ClrInstanceID;
                    }
                }

                /// <summary>
                /// Retrieves the ModuleID field.
                /// </summary>
                public ulong ModuleID => BitConverter.ToUInt64(_etwEvent.Data[Offset_ModuleID..]);

                /// <summary>
                /// Retrieves the AssemblyID field.
                /// </summary>
                public ulong AssemblyID => BitConverter.ToUInt64(_etwEvent.Data[Offset_AssemblyID..]);

                /// <summary>
                /// Retrieves the AppDomainID field.
                /// </summary>
                public ulong AppDomainID => BitConverter.ToUInt64(_etwEvent.Data[Offset_AppDomainID..]);

                /// <summary>
                /// Retrieves the ModuleFlags field.
                /// </summary>
                public ModuleFlagsMap ModuleFlags => (ModuleFlagsMap)BitConverter.ToUInt32(_etwEvent.Data[Offset_ModuleFlags..]);

                /// <summary>
                /// Retrieves the Reserved1 field.
                /// </summary>
                public uint Reserved1 => BitConverter.ToUInt32(_etwEvent.Data[Offset_Reserved1..]);

                /// <summary>
                /// Retrieves the ModuleILPath field.
                /// </summary>
                public string ModuleILPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ModuleILPath..]);

                /// <summary>
                /// Retrieves the ModuleNativePath field.
                /// </summary>
                public string ModuleNativePath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ModuleNativePath..]);

                /// <summary>
                /// Retrieves the ClrInstanceID field.
                /// </summary>
                public ushort ClrInstanceID => BitConverter.ToUInt16(_etwEvent.Data[Offset_ClrInstanceID..]);

                /// <summary>
                /// Creates a new LoaderDomainModuleDCStopData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public LoaderDomainModuleDCStopData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ModuleID = -1;
                    _offset_AssemblyID = -1;
                    _offset_AppDomainID = -1;
                    _offset_ModuleFlags = -1;
                    _offset_Reserved1 = -1;
                    _offset_ModuleILPath = -1;
                    _offset_ModuleNativePath = -1;
                    _offset_ClrInstanceID = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a LoaderModuleDCStart event.
        /// </summary>
        public readonly ref struct LoaderModuleDCStartEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "LoaderModuleDCStart";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 153,
                Version = 1,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = (EtwEventOpcode)Opcodes.DCStart,
                Task = (ushort)Tasks.Loader,
                Keyword = (ulong)Keywords.LoaderRundownKeyword | (ulong)Keywords.PerfTrackRundownKeyword
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

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
            public LoaderModuleDCStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new LoaderModuleDCStartEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public LoaderModuleDCStartEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a LoaderModuleDCStart event.
            /// </summary>
            public ref struct LoaderModuleDCStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ModuleID;
                private int _offset_AssemblyID;
                private int _offset_ModuleFlags;
                private int _offset_Reserved1;
                private int _offset_ModuleILPath;
                private int _offset_ModuleNativePath;
                private int _offset_ClrInstanceID;

                private int Offset_ModuleID
                {
                    get
                    {
                        if (_offset_ModuleID == -1)
                        {
                            _offset_ModuleID = 0;
                        }

                        return _offset_ModuleID;
                    }
                }

                private int Offset_AssemblyID
                {
                    get
                    {
                        if (_offset_AssemblyID == -1)
                        {
                            _offset_AssemblyID = Offset_ModuleID + 8;
                        }

                        return _offset_AssemblyID;
                    }
                }

                private int Offset_ModuleFlags
                {
                    get
                    {
                        if (_offset_ModuleFlags == -1)
                        {
                            _offset_ModuleFlags = Offset_AssemblyID + 8;
                        }

                        return _offset_ModuleFlags;
                    }
                }

                private int Offset_Reserved1
                {
                    get
                    {
                        if (_offset_Reserved1 == -1)
                        {
                            _offset_Reserved1 = Offset_ModuleFlags + 4;
                        }

                        return _offset_Reserved1;
                    }
                }

                private int Offset_ModuleILPath
                {
                    get
                    {
                        if (_offset_ModuleILPath == -1)
                        {
                            _offset_ModuleILPath = Offset_Reserved1 + 4;
                        }

                        return _offset_ModuleILPath;
                    }
                }

                private int Offset_ModuleNativePath
                {
                    get
                    {
                        if (_offset_ModuleNativePath == -1)
                        {
                            _offset_ModuleNativePath = Offset_ModuleILPath + _etwEvent.UnicodeStringLength(Offset_ModuleILPath);
                        }

                        return _offset_ModuleNativePath;
                    }
                }

                private int Offset_ClrInstanceID
                {
                    get
                    {
                        if (_offset_ClrInstanceID == -1)
                        {
                            _offset_ClrInstanceID = Offset_ModuleNativePath + _etwEvent.UnicodeStringLength(Offset_ModuleNativePath);
                        }

                        return _offset_ClrInstanceID;
                    }
                }

                /// <summary>
                /// Retrieves the ModuleID field.
                /// </summary>
                public ulong ModuleID => BitConverter.ToUInt64(_etwEvent.Data[Offset_ModuleID..]);

                /// <summary>
                /// Retrieves the AssemblyID field.
                /// </summary>
                public ulong AssemblyID => BitConverter.ToUInt64(_etwEvent.Data[Offset_AssemblyID..]);

                /// <summary>
                /// Retrieves the ModuleFlags field.
                /// </summary>
                public ModuleFlagsMap ModuleFlags => (ModuleFlagsMap)BitConverter.ToUInt32(_etwEvent.Data[Offset_ModuleFlags..]);

                /// <summary>
                /// Retrieves the Reserved1 field.
                /// </summary>
                public uint Reserved1 => BitConverter.ToUInt32(_etwEvent.Data[Offset_Reserved1..]);

                /// <summary>
                /// Retrieves the ModuleILPath field.
                /// </summary>
                public string ModuleILPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ModuleILPath..]);

                /// <summary>
                /// Retrieves the ModuleNativePath field.
                /// </summary>
                public string ModuleNativePath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ModuleNativePath..]);

                /// <summary>
                /// Retrieves the ClrInstanceID field.
                /// </summary>
                public ushort ClrInstanceID => BitConverter.ToUInt16(_etwEvent.Data[Offset_ClrInstanceID..]);

                /// <summary>
                /// Creates a new LoaderModuleDCStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public LoaderModuleDCStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ModuleID = -1;
                    _offset_AssemblyID = -1;
                    _offset_ModuleFlags = -1;
                    _offset_Reserved1 = -1;
                    _offset_ModuleILPath = -1;
                    _offset_ModuleNativePath = -1;
                    _offset_ClrInstanceID = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a LoaderModuleDCStop event.
        /// </summary>
        public readonly ref struct LoaderModuleDCStopEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "LoaderModuleDCStop";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 154,
                Version = 1,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = (EtwEventOpcode)Opcodes.DCStop,
                Task = (ushort)Tasks.Loader,
                Keyword = (ulong)Keywords.LoaderRundownKeyword | (ulong)Keywords.PerfTrackRundownKeyword
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

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
            public LoaderModuleDCStopData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new LoaderModuleDCStopEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public LoaderModuleDCStopEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a LoaderModuleDCStop event.
            /// </summary>
            public ref struct LoaderModuleDCStopData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ModuleID;
                private int _offset_AssemblyID;
                private int _offset_ModuleFlags;
                private int _offset_Reserved1;
                private int _offset_ModuleILPath;
                private int _offset_ModuleNativePath;
                private int _offset_ClrInstanceID;

                private int Offset_ModuleID
                {
                    get
                    {
                        if (_offset_ModuleID == -1)
                        {
                            _offset_ModuleID = 0;
                        }

                        return _offset_ModuleID;
                    }
                }

                private int Offset_AssemblyID
                {
                    get
                    {
                        if (_offset_AssemblyID == -1)
                        {
                            _offset_AssemblyID = Offset_ModuleID + 8;
                        }

                        return _offset_AssemblyID;
                    }
                }

                private int Offset_ModuleFlags
                {
                    get
                    {
                        if (_offset_ModuleFlags == -1)
                        {
                            _offset_ModuleFlags = Offset_AssemblyID + 8;
                        }

                        return _offset_ModuleFlags;
                    }
                }

                private int Offset_Reserved1
                {
                    get
                    {
                        if (_offset_Reserved1 == -1)
                        {
                            _offset_Reserved1 = Offset_ModuleFlags + 4;
                        }

                        return _offset_Reserved1;
                    }
                }

                private int Offset_ModuleILPath
                {
                    get
                    {
                        if (_offset_ModuleILPath == -1)
                        {
                            _offset_ModuleILPath = Offset_Reserved1 + 4;
                        }

                        return _offset_ModuleILPath;
                    }
                }

                private int Offset_ModuleNativePath
                {
                    get
                    {
                        if (_offset_ModuleNativePath == -1)
                        {
                            _offset_ModuleNativePath = Offset_ModuleILPath + _etwEvent.UnicodeStringLength(Offset_ModuleILPath);
                        }

                        return _offset_ModuleNativePath;
                    }
                }

                private int Offset_ClrInstanceID
                {
                    get
                    {
                        if (_offset_ClrInstanceID == -1)
                        {
                            _offset_ClrInstanceID = Offset_ModuleNativePath + _etwEvent.UnicodeStringLength(Offset_ModuleNativePath);
                        }

                        return _offset_ClrInstanceID;
                    }
                }

                /// <summary>
                /// Retrieves the ModuleID field.
                /// </summary>
                public ulong ModuleID => BitConverter.ToUInt64(_etwEvent.Data[Offset_ModuleID..]);

                /// <summary>
                /// Retrieves the AssemblyID field.
                /// </summary>
                public ulong AssemblyID => BitConverter.ToUInt64(_etwEvent.Data[Offset_AssemblyID..]);

                /// <summary>
                /// Retrieves the ModuleFlags field.
                /// </summary>
                public ModuleFlagsMap ModuleFlags => (ModuleFlagsMap)BitConverter.ToUInt32(_etwEvent.Data[Offset_ModuleFlags..]);

                /// <summary>
                /// Retrieves the Reserved1 field.
                /// </summary>
                public uint Reserved1 => BitConverter.ToUInt32(_etwEvent.Data[Offset_Reserved1..]);

                /// <summary>
                /// Retrieves the ModuleILPath field.
                /// </summary>
                public string ModuleILPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ModuleILPath..]);

                /// <summary>
                /// Retrieves the ModuleNativePath field.
                /// </summary>
                public string ModuleNativePath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ModuleNativePath..]);

                /// <summary>
                /// Retrieves the ClrInstanceID field.
                /// </summary>
                public ushort ClrInstanceID => BitConverter.ToUInt16(_etwEvent.Data[Offset_ClrInstanceID..]);

                /// <summary>
                /// Creates a new LoaderModuleDCStopData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public LoaderModuleDCStopData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ModuleID = -1;
                    _offset_AssemblyID = -1;
                    _offset_ModuleFlags = -1;
                    _offset_Reserved1 = -1;
                    _offset_ModuleILPath = -1;
                    _offset_ModuleNativePath = -1;
                    _offset_ClrInstanceID = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a LoaderAssemblyDCStart event.
        /// </summary>
        public readonly ref struct LoaderAssemblyDCStartEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "LoaderAssemblyDCStart";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 155,
                Version = 1,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = (EtwEventOpcode)Opcodes.DCStartVerbose,
                Task = (ushort)Tasks.Loader,
                Keyword = (ulong)Keywords.LoaderRundownKeyword
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

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
            public LoaderAssemblyDCStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new LoaderAssemblyDCStartEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public LoaderAssemblyDCStartEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a LoaderAssemblyDCStart event.
            /// </summary>
            public ref struct LoaderAssemblyDCStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_AssemblyID;
                private int _offset_AppDomainID;
                private int _offset_BindingID;
                private int _offset_AssemblyFlags;
                private int _offset_FullyQualifiedAssemblyName;
                private int _offset_ClrInstanceID;

                private int Offset_AssemblyID
                {
                    get
                    {
                        if (_offset_AssemblyID == -1)
                        {
                            _offset_AssemblyID = 0;
                        }

                        return _offset_AssemblyID;
                    }
                }

                private int Offset_AppDomainID
                {
                    get
                    {
                        if (_offset_AppDomainID == -1)
                        {
                            _offset_AppDomainID = Offset_AssemblyID + 8;
                        }

                        return _offset_AppDomainID;
                    }
                }

                private int Offset_BindingID
                {
                    get
                    {
                        if (_offset_BindingID == -1)
                        {
                            _offset_BindingID = Offset_AppDomainID + 8;
                        }

                        return _offset_BindingID;
                    }
                }

                private int Offset_AssemblyFlags
                {
                    get
                    {
                        if (_offset_AssemblyFlags == -1)
                        {
                            _offset_AssemblyFlags = Offset_BindingID + 8;
                        }

                        return _offset_AssemblyFlags;
                    }
                }

                private int Offset_FullyQualifiedAssemblyName
                {
                    get
                    {
                        if (_offset_FullyQualifiedAssemblyName == -1)
                        {
                            _offset_FullyQualifiedAssemblyName = Offset_AssemblyFlags + 4;
                        }

                        return _offset_FullyQualifiedAssemblyName;
                    }
                }

                private int Offset_ClrInstanceID
                {
                    get
                    {
                        if (_offset_ClrInstanceID == -1)
                        {
                            _offset_ClrInstanceID = Offset_FullyQualifiedAssemblyName + _etwEvent.UnicodeStringLength(Offset_FullyQualifiedAssemblyName);
                        }

                        return _offset_ClrInstanceID;
                    }
                }

                /// <summary>
                /// Retrieves the AssemblyID field.
                /// </summary>
                public ulong AssemblyID => BitConverter.ToUInt64(_etwEvent.Data[Offset_AssemblyID..]);

                /// <summary>
                /// Retrieves the AppDomainID field.
                /// </summary>
                public ulong AppDomainID => BitConverter.ToUInt64(_etwEvent.Data[Offset_AppDomainID..]);

                /// <summary>
                /// Retrieves the BindingID field.
                /// </summary>
                public ulong BindingID => BitConverter.ToUInt64(_etwEvent.Data[Offset_BindingID..]);

                /// <summary>
                /// Retrieves the AssemblyFlags field.
                /// </summary>
                public AssemblyFlagsMap AssemblyFlags => (AssemblyFlagsMap)BitConverter.ToUInt32(_etwEvent.Data[Offset_AssemblyFlags..]);

                /// <summary>
                /// Retrieves the FullyQualifiedAssemblyName field.
                /// </summary>
                public string FullyQualifiedAssemblyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FullyQualifiedAssemblyName..]);

                /// <summary>
                /// Retrieves the ClrInstanceID field.
                /// </summary>
                public ushort ClrInstanceID => BitConverter.ToUInt16(_etwEvent.Data[Offset_ClrInstanceID..]);

                /// <summary>
                /// Creates a new LoaderAssemblyDCStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public LoaderAssemblyDCStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_AssemblyID = -1;
                    _offset_AppDomainID = -1;
                    _offset_BindingID = -1;
                    _offset_AssemblyFlags = -1;
                    _offset_FullyQualifiedAssemblyName = -1;
                    _offset_ClrInstanceID = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a LoaderAssemblyDCStop event.
        /// </summary>
        public readonly ref struct LoaderAssemblyDCStopEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "LoaderAssemblyDCStop";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 156,
                Version = 1,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = (EtwEventOpcode)Opcodes.DCStopVerbose,
                Task = (ushort)Tasks.Loader,
                Keyword = (ulong)Keywords.LoaderRundownKeyword
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

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
            public LoaderAssemblyDCStopData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new LoaderAssemblyDCStopEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public LoaderAssemblyDCStopEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a LoaderAssemblyDCStop event.
            /// </summary>
            public ref struct LoaderAssemblyDCStopData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_AssemblyID;
                private int _offset_AppDomainID;
                private int _offset_BindingID;
                private int _offset_AssemblyFlags;
                private int _offset_FullyQualifiedAssemblyName;
                private int _offset_ClrInstanceID;

                private int Offset_AssemblyID
                {
                    get
                    {
                        if (_offset_AssemblyID == -1)
                        {
                            _offset_AssemblyID = 0;
                        }

                        return _offset_AssemblyID;
                    }
                }

                private int Offset_AppDomainID
                {
                    get
                    {
                        if (_offset_AppDomainID == -1)
                        {
                            _offset_AppDomainID = Offset_AssemblyID + 8;
                        }

                        return _offset_AppDomainID;
                    }
                }

                private int Offset_BindingID
                {
                    get
                    {
                        if (_offset_BindingID == -1)
                        {
                            _offset_BindingID = Offset_AppDomainID + 8;
                        }

                        return _offset_BindingID;
                    }
                }

                private int Offset_AssemblyFlags
                {
                    get
                    {
                        if (_offset_AssemblyFlags == -1)
                        {
                            _offset_AssemblyFlags = Offset_BindingID + 8;
                        }

                        return _offset_AssemblyFlags;
                    }
                }

                private int Offset_FullyQualifiedAssemblyName
                {
                    get
                    {
                        if (_offset_FullyQualifiedAssemblyName == -1)
                        {
                            _offset_FullyQualifiedAssemblyName = Offset_AssemblyFlags + 4;
                        }

                        return _offset_FullyQualifiedAssemblyName;
                    }
                }

                private int Offset_ClrInstanceID
                {
                    get
                    {
                        if (_offset_ClrInstanceID == -1)
                        {
                            _offset_ClrInstanceID = Offset_FullyQualifiedAssemblyName + _etwEvent.UnicodeStringLength(Offset_FullyQualifiedAssemblyName);
                        }

                        return _offset_ClrInstanceID;
                    }
                }

                /// <summary>
                /// Retrieves the AssemblyID field.
                /// </summary>
                public ulong AssemblyID => BitConverter.ToUInt64(_etwEvent.Data[Offset_AssemblyID..]);

                /// <summary>
                /// Retrieves the AppDomainID field.
                /// </summary>
                public ulong AppDomainID => BitConverter.ToUInt64(_etwEvent.Data[Offset_AppDomainID..]);

                /// <summary>
                /// Retrieves the BindingID field.
                /// </summary>
                public ulong BindingID => BitConverter.ToUInt64(_etwEvent.Data[Offset_BindingID..]);

                /// <summary>
                /// Retrieves the AssemblyFlags field.
                /// </summary>
                public AssemblyFlagsMap AssemblyFlags => (AssemblyFlagsMap)BitConverter.ToUInt32(_etwEvent.Data[Offset_AssemblyFlags..]);

                /// <summary>
                /// Retrieves the FullyQualifiedAssemblyName field.
                /// </summary>
                public string FullyQualifiedAssemblyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FullyQualifiedAssemblyName..]);

                /// <summary>
                /// Retrieves the ClrInstanceID field.
                /// </summary>
                public ushort ClrInstanceID => BitConverter.ToUInt16(_etwEvent.Data[Offset_ClrInstanceID..]);

                /// <summary>
                /// Creates a new LoaderAssemblyDCStopData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public LoaderAssemblyDCStopData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_AssemblyID = -1;
                    _offset_AppDomainID = -1;
                    _offset_BindingID = -1;
                    _offset_AssemblyFlags = -1;
                    _offset_FullyQualifiedAssemblyName = -1;
                    _offset_ClrInstanceID = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a LoaderAppDomainDCStart event.
        /// </summary>
        public readonly ref struct LoaderAppDomainDCStartEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "LoaderAppDomainDCStart";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 157,
                Version = 1,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = (EtwEventOpcode)Opcodes.AppDomainDCStart,
                Task = (ushort)Tasks.Loader,
                Keyword = (ulong)Keywords.LoaderRundownKeyword
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

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
            public LoaderAppDomainDCStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new LoaderAppDomainDCStartEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public LoaderAppDomainDCStartEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a LoaderAppDomainDCStart event.
            /// </summary>
            public ref struct LoaderAppDomainDCStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_AppDomainID;
                private int _offset_AppDomainFlags;
                private int _offset_AppDomainName;
                private int _offset_AppDomainIndex;
                private int _offset_ClrInstanceID;

                private int Offset_AppDomainID
                {
                    get
                    {
                        if (_offset_AppDomainID == -1)
                        {
                            _offset_AppDomainID = 0;
                        }

                        return _offset_AppDomainID;
                    }
                }

                private int Offset_AppDomainFlags
                {
                    get
                    {
                        if (_offset_AppDomainFlags == -1)
                        {
                            _offset_AppDomainFlags = Offset_AppDomainID + 8;
                        }

                        return _offset_AppDomainFlags;
                    }
                }

                private int Offset_AppDomainName
                {
                    get
                    {
                        if (_offset_AppDomainName == -1)
                        {
                            _offset_AppDomainName = Offset_AppDomainFlags + 4;
                        }

                        return _offset_AppDomainName;
                    }
                }

                private int Offset_AppDomainIndex
                {
                    get
                    {
                        if (_offset_AppDomainIndex == -1)
                        {
                            _offset_AppDomainIndex = Offset_AppDomainName + _etwEvent.UnicodeStringLength(Offset_AppDomainName);
                        }

                        return _offset_AppDomainIndex;
                    }
                }

                private int Offset_ClrInstanceID
                {
                    get
                    {
                        if (_offset_ClrInstanceID == -1)
                        {
                            _offset_ClrInstanceID = Offset_AppDomainIndex + 4;
                        }

                        return _offset_ClrInstanceID;
                    }
                }

                /// <summary>
                /// Retrieves the AppDomainID field.
                /// </summary>
                public ulong AppDomainID => BitConverter.ToUInt64(_etwEvent.Data[Offset_AppDomainID..]);

                /// <summary>
                /// Retrieves the AppDomainFlags field.
                /// </summary>
                public AppDomainFlagsMap AppDomainFlags => (AppDomainFlagsMap)BitConverter.ToUInt32(_etwEvent.Data[Offset_AppDomainFlags..]);

                /// <summary>
                /// Retrieves the AppDomainName field.
                /// </summary>
                public string AppDomainName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_AppDomainName..]);

                /// <summary>
                /// Retrieves the AppDomainIndex field.
                /// </summary>
                public uint AppDomainIndex => BitConverter.ToUInt32(_etwEvent.Data[Offset_AppDomainIndex..]);

                /// <summary>
                /// Retrieves the ClrInstanceID field.
                /// </summary>
                public ushort ClrInstanceID => BitConverter.ToUInt16(_etwEvent.Data[Offset_ClrInstanceID..]);

                /// <summary>
                /// Creates a new LoaderAppDomainDCStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public LoaderAppDomainDCStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_AppDomainID = -1;
                    _offset_AppDomainFlags = -1;
                    _offset_AppDomainName = -1;
                    _offset_AppDomainIndex = -1;
                    _offset_ClrInstanceID = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a LoaderAppDomainDCStop event.
        /// </summary>
        public readonly ref struct LoaderAppDomainDCStopEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "LoaderAppDomainDCStop";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 158,
                Version = 1,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = (EtwEventOpcode)Opcodes.AppDomainDCStop,
                Task = (ushort)Tasks.Loader,
                Keyword = (ulong)Keywords.LoaderRundownKeyword
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

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
            public LoaderAppDomainDCStopData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new LoaderAppDomainDCStopEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public LoaderAppDomainDCStopEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a LoaderAppDomainDCStop event.
            /// </summary>
            public ref struct LoaderAppDomainDCStopData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_AppDomainID;
                private int _offset_AppDomainFlags;
                private int _offset_AppDomainName;
                private int _offset_AppDomainIndex;
                private int _offset_ClrInstanceID;

                private int Offset_AppDomainID
                {
                    get
                    {
                        if (_offset_AppDomainID == -1)
                        {
                            _offset_AppDomainID = 0;
                        }

                        return _offset_AppDomainID;
                    }
                }

                private int Offset_AppDomainFlags
                {
                    get
                    {
                        if (_offset_AppDomainFlags == -1)
                        {
                            _offset_AppDomainFlags = Offset_AppDomainID + 8;
                        }

                        return _offset_AppDomainFlags;
                    }
                }

                private int Offset_AppDomainName
                {
                    get
                    {
                        if (_offset_AppDomainName == -1)
                        {
                            _offset_AppDomainName = Offset_AppDomainFlags + 4;
                        }

                        return _offset_AppDomainName;
                    }
                }

                private int Offset_AppDomainIndex
                {
                    get
                    {
                        if (_offset_AppDomainIndex == -1)
                        {
                            _offset_AppDomainIndex = Offset_AppDomainName + _etwEvent.UnicodeStringLength(Offset_AppDomainName);
                        }

                        return _offset_AppDomainIndex;
                    }
                }

                private int Offset_ClrInstanceID
                {
                    get
                    {
                        if (_offset_ClrInstanceID == -1)
                        {
                            _offset_ClrInstanceID = Offset_AppDomainIndex + 4;
                        }

                        return _offset_ClrInstanceID;
                    }
                }

                /// <summary>
                /// Retrieves the AppDomainID field.
                /// </summary>
                public ulong AppDomainID => BitConverter.ToUInt64(_etwEvent.Data[Offset_AppDomainID..]);

                /// <summary>
                /// Retrieves the AppDomainFlags field.
                /// </summary>
                public AppDomainFlagsMap AppDomainFlags => (AppDomainFlagsMap)BitConverter.ToUInt32(_etwEvent.Data[Offset_AppDomainFlags..]);

                /// <summary>
                /// Retrieves the AppDomainName field.
                /// </summary>
                public string AppDomainName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_AppDomainName..]);

                /// <summary>
                /// Retrieves the AppDomainIndex field.
                /// </summary>
                public uint AppDomainIndex => BitConverter.ToUInt32(_etwEvent.Data[Offset_AppDomainIndex..]);

                /// <summary>
                /// Retrieves the ClrInstanceID field.
                /// </summary>
                public ushort ClrInstanceID => BitConverter.ToUInt16(_etwEvent.Data[Offset_ClrInstanceID..]);

                /// <summary>
                /// Creates a new LoaderAppDomainDCStopData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public LoaderAppDomainDCStopData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_AppDomainID = -1;
                    _offset_AppDomainFlags = -1;
                    _offset_AppDomainName = -1;
                    _offset_AppDomainIndex = -1;
                    _offset_ClrInstanceID = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a MethodDCStart event.
        /// </summary>
        public readonly ref struct MethodDCStartEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "MethodDCStart";

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
                Version = 2,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = (EtwEventOpcode)Opcodes.DCStart,
                Task = (ushort)Tasks.Method,
                Keyword = (ulong)Keywords.JitRundownKeyword | (ulong)Keywords.NGenRundownKeyword
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

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
            public MethodDCStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new MethodDCStartEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public MethodDCStartEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a MethodDCStart event.
            /// </summary>
            public ref struct MethodDCStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_MethodID;
                private int _offset_ModuleID;
                private int _offset_MethodStartAddress;
                private int _offset_MethodSize;
                private int _offset_MethodToken;
                private int _offset_MethodFlags;
                private int _offset_ClrInstanceID;
                private int _offset_ReJITID;

                private int Offset_MethodID
                {
                    get
                    {
                        if (_offset_MethodID == -1)
                        {
                            _offset_MethodID = 0;
                        }

                        return _offset_MethodID;
                    }
                }

                private int Offset_ModuleID
                {
                    get
                    {
                        if (_offset_ModuleID == -1)
                        {
                            _offset_ModuleID = Offset_MethodID + 8;
                        }

                        return _offset_ModuleID;
                    }
                }

                private int Offset_MethodStartAddress
                {
                    get
                    {
                        if (_offset_MethodStartAddress == -1)
                        {
                            _offset_MethodStartAddress = Offset_ModuleID + 8;
                        }

                        return _offset_MethodStartAddress;
                    }
                }

                private int Offset_MethodSize
                {
                    get
                    {
                        if (_offset_MethodSize == -1)
                        {
                            _offset_MethodSize = Offset_MethodStartAddress + 8;
                        }

                        return _offset_MethodSize;
                    }
                }

                private int Offset_MethodToken
                {
                    get
                    {
                        if (_offset_MethodToken == -1)
                        {
                            _offset_MethodToken = Offset_MethodSize + 4;
                        }

                        return _offset_MethodToken;
                    }
                }

                private int Offset_MethodFlags
                {
                    get
                    {
                        if (_offset_MethodFlags == -1)
                        {
                            _offset_MethodFlags = Offset_MethodToken + 4;
                        }

                        return _offset_MethodFlags;
                    }
                }

                private int Offset_ClrInstanceID
                {
                    get
                    {
                        if (_offset_ClrInstanceID == -1)
                        {
                            _offset_ClrInstanceID = Offset_MethodFlags + 4;
                        }

                        return _offset_ClrInstanceID;
                    }
                }

                private int Offset_ReJITID
                {
                    get
                    {
                        if (_offset_ReJITID == -1)
                        {
                            _offset_ReJITID = Offset_ClrInstanceID + 2;
                        }

                        return _offset_ReJITID;
                    }
                }

                /// <summary>
                /// Retrieves the MethodID field.
                /// </summary>
                public ulong MethodID => BitConverter.ToUInt64(_etwEvent.Data[Offset_MethodID..]);

                /// <summary>
                /// Retrieves the ModuleID field.
                /// </summary>
                public ulong ModuleID => BitConverter.ToUInt64(_etwEvent.Data[Offset_ModuleID..]);

                /// <summary>
                /// Retrieves the MethodStartAddress field.
                /// </summary>
                public ulong MethodStartAddress => BitConverter.ToUInt64(_etwEvent.Data[Offset_MethodStartAddress..]);

                /// <summary>
                /// Retrieves the MethodSize field.
                /// </summary>
                public uint MethodSize => BitConverter.ToUInt32(_etwEvent.Data[Offset_MethodSize..]);

                /// <summary>
                /// Retrieves the MethodToken field.
                /// </summary>
                public uint MethodToken => BitConverter.ToUInt32(_etwEvent.Data[Offset_MethodToken..]);

                /// <summary>
                /// Retrieves the MethodFlags field.
                /// </summary>
                public MethodFlagsMap MethodFlags => (MethodFlagsMap)BitConverter.ToUInt32(_etwEvent.Data[Offset_MethodFlags..]);

                /// <summary>
                /// Retrieves the ClrInstanceID field.
                /// </summary>
                public ushort ClrInstanceID => BitConverter.ToUInt16(_etwEvent.Data[Offset_ClrInstanceID..]);

                /// <summary>
                /// Retrieves the ReJITID field.
                /// </summary>
                public ulong ReJITID => BitConverter.ToUInt64(_etwEvent.Data[Offset_ReJITID..]);

                /// <summary>
                /// Creates a new MethodDCStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public MethodDCStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_MethodID = -1;
                    _offset_ModuleID = -1;
                    _offset_MethodStartAddress = -1;
                    _offset_MethodSize = -1;
                    _offset_MethodToken = -1;
                    _offset_MethodFlags = -1;
                    _offset_ClrInstanceID = -1;
                    _offset_ReJITID = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a MethodDCStop event.
        /// </summary>
        public readonly ref struct MethodDCStopEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "MethodDCStop";

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
                Version = 2,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = (EtwEventOpcode)Opcodes.DCStop,
                Task = (ushort)Tasks.Method,
                Keyword = (ulong)Keywords.JitRundownKeyword | (ulong)Keywords.NGenRundownKeyword
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

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
            public MethodDCStopData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new MethodDCStopEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public MethodDCStopEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a MethodDCStop event.
            /// </summary>
            public ref struct MethodDCStopData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_MethodID;
                private int _offset_ModuleID;
                private int _offset_MethodStartAddress;
                private int _offset_MethodSize;
                private int _offset_MethodToken;
                private int _offset_MethodFlags;
                private int _offset_ClrInstanceID;
                private int _offset_ReJITID;

                private int Offset_MethodID
                {
                    get
                    {
                        if (_offset_MethodID == -1)
                        {
                            _offset_MethodID = 0;
                        }

                        return _offset_MethodID;
                    }
                }

                private int Offset_ModuleID
                {
                    get
                    {
                        if (_offset_ModuleID == -1)
                        {
                            _offset_ModuleID = Offset_MethodID + 8;
                        }

                        return _offset_ModuleID;
                    }
                }

                private int Offset_MethodStartAddress
                {
                    get
                    {
                        if (_offset_MethodStartAddress == -1)
                        {
                            _offset_MethodStartAddress = Offset_ModuleID + 8;
                        }

                        return _offset_MethodStartAddress;
                    }
                }

                private int Offset_MethodSize
                {
                    get
                    {
                        if (_offset_MethodSize == -1)
                        {
                            _offset_MethodSize = Offset_MethodStartAddress + 8;
                        }

                        return _offset_MethodSize;
                    }
                }

                private int Offset_MethodToken
                {
                    get
                    {
                        if (_offset_MethodToken == -1)
                        {
                            _offset_MethodToken = Offset_MethodSize + 4;
                        }

                        return _offset_MethodToken;
                    }
                }

                private int Offset_MethodFlags
                {
                    get
                    {
                        if (_offset_MethodFlags == -1)
                        {
                            _offset_MethodFlags = Offset_MethodToken + 4;
                        }

                        return _offset_MethodFlags;
                    }
                }

                private int Offset_ClrInstanceID
                {
                    get
                    {
                        if (_offset_ClrInstanceID == -1)
                        {
                            _offset_ClrInstanceID = Offset_MethodFlags + 4;
                        }

                        return _offset_ClrInstanceID;
                    }
                }

                private int Offset_ReJITID
                {
                    get
                    {
                        if (_offset_ReJITID == -1)
                        {
                            _offset_ReJITID = Offset_ClrInstanceID + 2;
                        }

                        return _offset_ReJITID;
                    }
                }

                /// <summary>
                /// Retrieves the MethodID field.
                /// </summary>
                public ulong MethodID => BitConverter.ToUInt64(_etwEvent.Data[Offset_MethodID..]);

                /// <summary>
                /// Retrieves the ModuleID field.
                /// </summary>
                public ulong ModuleID => BitConverter.ToUInt64(_etwEvent.Data[Offset_ModuleID..]);

                /// <summary>
                /// Retrieves the MethodStartAddress field.
                /// </summary>
                public ulong MethodStartAddress => BitConverter.ToUInt64(_etwEvent.Data[Offset_MethodStartAddress..]);

                /// <summary>
                /// Retrieves the MethodSize field.
                /// </summary>
                public uint MethodSize => BitConverter.ToUInt32(_etwEvent.Data[Offset_MethodSize..]);

                /// <summary>
                /// Retrieves the MethodToken field.
                /// </summary>
                public uint MethodToken => BitConverter.ToUInt32(_etwEvent.Data[Offset_MethodToken..]);

                /// <summary>
                /// Retrieves the MethodFlags field.
                /// </summary>
                public MethodFlagsMap MethodFlags => (MethodFlagsMap)BitConverter.ToUInt32(_etwEvent.Data[Offset_MethodFlags..]);

                /// <summary>
                /// Retrieves the ClrInstanceID field.
                /// </summary>
                public ushort ClrInstanceID => BitConverter.ToUInt16(_etwEvent.Data[Offset_ClrInstanceID..]);

                /// <summary>
                /// Retrieves the ReJITID field.
                /// </summary>
                public ulong ReJITID => BitConverter.ToUInt64(_etwEvent.Data[Offset_ReJITID..]);

                /// <summary>
                /// Creates a new MethodDCStopData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public MethodDCStopData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_MethodID = -1;
                    _offset_ModuleID = -1;
                    _offset_MethodStartAddress = -1;
                    _offset_MethodSize = -1;
                    _offset_MethodToken = -1;
                    _offset_MethodFlags = -1;
                    _offset_ClrInstanceID = -1;
                    _offset_ReJITID = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a MethodDCStartVerbose event.
        /// </summary>
        public readonly ref struct MethodDCStartVerboseEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "MethodDCStartVerbose";

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
                Version = 2,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = (EtwEventOpcode)Opcodes.DCStartVerbose,
                Task = (ushort)Tasks.Method,
                Keyword = (ulong)Keywords.JitRundownKeyword | (ulong)Keywords.NGenRundownKeyword
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

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
            public MethodDCStartVerboseData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new MethodDCStartVerboseEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public MethodDCStartVerboseEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a MethodDCStartVerbose event.
            /// </summary>
            public ref struct MethodDCStartVerboseData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_MethodID;
                private int _offset_ModuleID;
                private int _offset_MethodStartAddress;
                private int _offset_MethodSize;
                private int _offset_MethodToken;
                private int _offset_MethodFlags;
                private int _offset_MethodNamespace;
                private int _offset_MethodName;
                private int _offset_MethodSignature;
                private int _offset_ClrInstanceID;
                private int _offset_ReJITID;

                private int Offset_MethodID
                {
                    get
                    {
                        if (_offset_MethodID == -1)
                        {
                            _offset_MethodID = 0;
                        }

                        return _offset_MethodID;
                    }
                }

                private int Offset_ModuleID
                {
                    get
                    {
                        if (_offset_ModuleID == -1)
                        {
                            _offset_ModuleID = Offset_MethodID + 8;
                        }

                        return _offset_ModuleID;
                    }
                }

                private int Offset_MethodStartAddress
                {
                    get
                    {
                        if (_offset_MethodStartAddress == -1)
                        {
                            _offset_MethodStartAddress = Offset_ModuleID + 8;
                        }

                        return _offset_MethodStartAddress;
                    }
                }

                private int Offset_MethodSize
                {
                    get
                    {
                        if (_offset_MethodSize == -1)
                        {
                            _offset_MethodSize = Offset_MethodStartAddress + 8;
                        }

                        return _offset_MethodSize;
                    }
                }

                private int Offset_MethodToken
                {
                    get
                    {
                        if (_offset_MethodToken == -1)
                        {
                            _offset_MethodToken = Offset_MethodSize + 4;
                        }

                        return _offset_MethodToken;
                    }
                }

                private int Offset_MethodFlags
                {
                    get
                    {
                        if (_offset_MethodFlags == -1)
                        {
                            _offset_MethodFlags = Offset_MethodToken + 4;
                        }

                        return _offset_MethodFlags;
                    }
                }

                private int Offset_MethodNamespace
                {
                    get
                    {
                        if (_offset_MethodNamespace == -1)
                        {
                            _offset_MethodNamespace = Offset_MethodFlags + 4;
                        }

                        return _offset_MethodNamespace;
                    }
                }

                private int Offset_MethodName
                {
                    get
                    {
                        if (_offset_MethodName == -1)
                        {
                            _offset_MethodName = Offset_MethodNamespace + _etwEvent.UnicodeStringLength(Offset_MethodNamespace);
                        }

                        return _offset_MethodName;
                    }
                }

                private int Offset_MethodSignature
                {
                    get
                    {
                        if (_offset_MethodSignature == -1)
                        {
                            _offset_MethodSignature = Offset_MethodName + _etwEvent.UnicodeStringLength(Offset_MethodName);
                        }

                        return _offset_MethodSignature;
                    }
                }

                private int Offset_ClrInstanceID
                {
                    get
                    {
                        if (_offset_ClrInstanceID == -1)
                        {
                            _offset_ClrInstanceID = Offset_MethodSignature + _etwEvent.UnicodeStringLength(Offset_MethodSignature);
                        }

                        return _offset_ClrInstanceID;
                    }
                }

                private int Offset_ReJITID
                {
                    get
                    {
                        if (_offset_ReJITID == -1)
                        {
                            _offset_ReJITID = Offset_ClrInstanceID + 2;
                        }

                        return _offset_ReJITID;
                    }
                }

                /// <summary>
                /// Retrieves the MethodID field.
                /// </summary>
                public ulong MethodID => BitConverter.ToUInt64(_etwEvent.Data[Offset_MethodID..]);

                /// <summary>
                /// Retrieves the ModuleID field.
                /// </summary>
                public ulong ModuleID => BitConverter.ToUInt64(_etwEvent.Data[Offset_ModuleID..]);

                /// <summary>
                /// Retrieves the MethodStartAddress field.
                /// </summary>
                public ulong MethodStartAddress => BitConverter.ToUInt64(_etwEvent.Data[Offset_MethodStartAddress..]);

                /// <summary>
                /// Retrieves the MethodSize field.
                /// </summary>
                public uint MethodSize => BitConverter.ToUInt32(_etwEvent.Data[Offset_MethodSize..]);

                /// <summary>
                /// Retrieves the MethodToken field.
                /// </summary>
                public uint MethodToken => BitConverter.ToUInt32(_etwEvent.Data[Offset_MethodToken..]);

                /// <summary>
                /// Retrieves the MethodFlags field.
                /// </summary>
                public MethodFlagsMap MethodFlags => (MethodFlagsMap)BitConverter.ToUInt32(_etwEvent.Data[Offset_MethodFlags..]);

                /// <summary>
                /// Retrieves the MethodNamespace field.
                /// </summary>
                public string MethodNamespace => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_MethodNamespace..]);

                /// <summary>
                /// Retrieves the MethodName field.
                /// </summary>
                public string MethodName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_MethodName..]);

                /// <summary>
                /// Retrieves the MethodSignature field.
                /// </summary>
                public string MethodSignature => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_MethodSignature..]);

                /// <summary>
                /// Retrieves the ClrInstanceID field.
                /// </summary>
                public ushort ClrInstanceID => BitConverter.ToUInt16(_etwEvent.Data[Offset_ClrInstanceID..]);

                /// <summary>
                /// Retrieves the ReJITID field.
                /// </summary>
                public ulong ReJITID => BitConverter.ToUInt64(_etwEvent.Data[Offset_ReJITID..]);

                /// <summary>
                /// Creates a new MethodDCStartVerboseData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public MethodDCStartVerboseData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_MethodID = -1;
                    _offset_ModuleID = -1;
                    _offset_MethodStartAddress = -1;
                    _offset_MethodSize = -1;
                    _offset_MethodToken = -1;
                    _offset_MethodFlags = -1;
                    _offset_MethodNamespace = -1;
                    _offset_MethodName = -1;
                    _offset_MethodSignature = -1;
                    _offset_ClrInstanceID = -1;
                    _offset_ReJITID = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a MethodDCStopVerbose event.
        /// </summary>
        public readonly ref struct MethodDCStopVerboseEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "MethodDCStopVerbose";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 144,
                Version = 2,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = (EtwEventOpcode)Opcodes.DCStopVerbose,
                Task = (ushort)Tasks.Method,
                Keyword = (ulong)Keywords.JitRundownKeyword | (ulong)Keywords.NGenRundownKeyword
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

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
            public MethodDCStopVerboseData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new MethodDCStopVerboseEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public MethodDCStopVerboseEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a MethodDCStopVerbose event.
            /// </summary>
            public ref struct MethodDCStopVerboseData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_MethodID;
                private int _offset_ModuleID;
                private int _offset_MethodStartAddress;
                private int _offset_MethodSize;
                private int _offset_MethodToken;
                private int _offset_MethodFlags;
                private int _offset_MethodNamespace;
                private int _offset_MethodName;
                private int _offset_MethodSignature;
                private int _offset_ClrInstanceID;
                private int _offset_ReJITID;

                private int Offset_MethodID
                {
                    get
                    {
                        if (_offset_MethodID == -1)
                        {
                            _offset_MethodID = 0;
                        }

                        return _offset_MethodID;
                    }
                }

                private int Offset_ModuleID
                {
                    get
                    {
                        if (_offset_ModuleID == -1)
                        {
                            _offset_ModuleID = Offset_MethodID + 8;
                        }

                        return _offset_ModuleID;
                    }
                }

                private int Offset_MethodStartAddress
                {
                    get
                    {
                        if (_offset_MethodStartAddress == -1)
                        {
                            _offset_MethodStartAddress = Offset_ModuleID + 8;
                        }

                        return _offset_MethodStartAddress;
                    }
                }

                private int Offset_MethodSize
                {
                    get
                    {
                        if (_offset_MethodSize == -1)
                        {
                            _offset_MethodSize = Offset_MethodStartAddress + 8;
                        }

                        return _offset_MethodSize;
                    }
                }

                private int Offset_MethodToken
                {
                    get
                    {
                        if (_offset_MethodToken == -1)
                        {
                            _offset_MethodToken = Offset_MethodSize + 4;
                        }

                        return _offset_MethodToken;
                    }
                }

                private int Offset_MethodFlags
                {
                    get
                    {
                        if (_offset_MethodFlags == -1)
                        {
                            _offset_MethodFlags = Offset_MethodToken + 4;
                        }

                        return _offset_MethodFlags;
                    }
                }

                private int Offset_MethodNamespace
                {
                    get
                    {
                        if (_offset_MethodNamespace == -1)
                        {
                            _offset_MethodNamespace = Offset_MethodFlags + 4;
                        }

                        return _offset_MethodNamespace;
                    }
                }

                private int Offset_MethodName
                {
                    get
                    {
                        if (_offset_MethodName == -1)
                        {
                            _offset_MethodName = Offset_MethodNamespace + _etwEvent.UnicodeStringLength(Offset_MethodNamespace);
                        }

                        return _offset_MethodName;
                    }
                }

                private int Offset_MethodSignature
                {
                    get
                    {
                        if (_offset_MethodSignature == -1)
                        {
                            _offset_MethodSignature = Offset_MethodName + _etwEvent.UnicodeStringLength(Offset_MethodName);
                        }

                        return _offset_MethodSignature;
                    }
                }

                private int Offset_ClrInstanceID
                {
                    get
                    {
                        if (_offset_ClrInstanceID == -1)
                        {
                            _offset_ClrInstanceID = Offset_MethodSignature + _etwEvent.UnicodeStringLength(Offset_MethodSignature);
                        }

                        return _offset_ClrInstanceID;
                    }
                }

                private int Offset_ReJITID
                {
                    get
                    {
                        if (_offset_ReJITID == -1)
                        {
                            _offset_ReJITID = Offset_ClrInstanceID + 2;
                        }

                        return _offset_ReJITID;
                    }
                }

                /// <summary>
                /// Retrieves the MethodID field.
                /// </summary>
                public ulong MethodID => BitConverter.ToUInt64(_etwEvent.Data[Offset_MethodID..]);

                /// <summary>
                /// Retrieves the ModuleID field.
                /// </summary>
                public ulong ModuleID => BitConverter.ToUInt64(_etwEvent.Data[Offset_ModuleID..]);

                /// <summary>
                /// Retrieves the MethodStartAddress field.
                /// </summary>
                public ulong MethodStartAddress => BitConverter.ToUInt64(_etwEvent.Data[Offset_MethodStartAddress..]);

                /// <summary>
                /// Retrieves the MethodSize field.
                /// </summary>
                public uint MethodSize => BitConverter.ToUInt32(_etwEvent.Data[Offset_MethodSize..]);

                /// <summary>
                /// Retrieves the MethodToken field.
                /// </summary>
                public uint MethodToken => BitConverter.ToUInt32(_etwEvent.Data[Offset_MethodToken..]);

                /// <summary>
                /// Retrieves the MethodFlags field.
                /// </summary>
                public MethodFlagsMap MethodFlags => (MethodFlagsMap)BitConverter.ToUInt32(_etwEvent.Data[Offset_MethodFlags..]);

                /// <summary>
                /// Retrieves the MethodNamespace field.
                /// </summary>
                public string MethodNamespace => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_MethodNamespace..]);

                /// <summary>
                /// Retrieves the MethodName field.
                /// </summary>
                public string MethodName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_MethodName..]);

                /// <summary>
                /// Retrieves the MethodSignature field.
                /// </summary>
                public string MethodSignature => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_MethodSignature..]);

                /// <summary>
                /// Retrieves the ClrInstanceID field.
                /// </summary>
                public ushort ClrInstanceID => BitConverter.ToUInt16(_etwEvent.Data[Offset_ClrInstanceID..]);

                /// <summary>
                /// Retrieves the ReJITID field.
                /// </summary>
                public ulong ReJITID => BitConverter.ToUInt64(_etwEvent.Data[Offset_ReJITID..]);

                /// <summary>
                /// Creates a new MethodDCStopVerboseData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public MethodDCStopVerboseData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_MethodID = -1;
                    _offset_ModuleID = -1;
                    _offset_MethodStartAddress = -1;
                    _offset_MethodSize = -1;
                    _offset_MethodToken = -1;
                    _offset_MethodFlags = -1;
                    _offset_MethodNamespace = -1;
                    _offset_MethodName = -1;
                    _offset_MethodSignature = -1;
                    _offset_ClrInstanceID = -1;
                    _offset_ReJITID = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a LoaderModuleDCStart event.
        /// </summary>
        public readonly ref struct LoaderModuleDCStartEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "LoaderModuleDCStart";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 153,
                Version = 2,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = (EtwEventOpcode)Opcodes.DCStart,
                Task = (ushort)Tasks.Loader,
                Keyword = (ulong)Keywords.LoaderRundownKeyword | (ulong)Keywords.PerfTrackRundownKeyword
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

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
            public LoaderModuleDCStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new LoaderModuleDCStartEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public LoaderModuleDCStartEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a LoaderModuleDCStart event.
            /// </summary>
            public ref struct LoaderModuleDCStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ModuleID;
                private int _offset_AssemblyID;
                private int _offset_ModuleFlags;
                private int _offset_Reserved1;
                private int _offset_ModuleILPath;
                private int _offset_ModuleNativePath;
                private int _offset_ClrInstanceID;
                private int _offset_ManagedPdbSignature;
                private int _offset_ManagedPdbAge;
                private int _offset_ManagedPdbBuildPath;
                private int _offset_NativePdbSignature;
                private int _offset_NativePdbAge;
                private int _offset_NativePdbBuildPath;

                private int Offset_ModuleID
                {
                    get
                    {
                        if (_offset_ModuleID == -1)
                        {
                            _offset_ModuleID = 0;
                        }

                        return _offset_ModuleID;
                    }
                }

                private int Offset_AssemblyID
                {
                    get
                    {
                        if (_offset_AssemblyID == -1)
                        {
                            _offset_AssemblyID = Offset_ModuleID + 8;
                        }

                        return _offset_AssemblyID;
                    }
                }

                private int Offset_ModuleFlags
                {
                    get
                    {
                        if (_offset_ModuleFlags == -1)
                        {
                            _offset_ModuleFlags = Offset_AssemblyID + 8;
                        }

                        return _offset_ModuleFlags;
                    }
                }

                private int Offset_Reserved1
                {
                    get
                    {
                        if (_offset_Reserved1 == -1)
                        {
                            _offset_Reserved1 = Offset_ModuleFlags + 4;
                        }

                        return _offset_Reserved1;
                    }
                }

                private int Offset_ModuleILPath
                {
                    get
                    {
                        if (_offset_ModuleILPath == -1)
                        {
                            _offset_ModuleILPath = Offset_Reserved1 + 4;
                        }

                        return _offset_ModuleILPath;
                    }
                }

                private int Offset_ModuleNativePath
                {
                    get
                    {
                        if (_offset_ModuleNativePath == -1)
                        {
                            _offset_ModuleNativePath = Offset_ModuleILPath + _etwEvent.UnicodeStringLength(Offset_ModuleILPath);
                        }

                        return _offset_ModuleNativePath;
                    }
                }

                private int Offset_ClrInstanceID
                {
                    get
                    {
                        if (_offset_ClrInstanceID == -1)
                        {
                            _offset_ClrInstanceID = Offset_ModuleNativePath + _etwEvent.UnicodeStringLength(Offset_ModuleNativePath);
                        }

                        return _offset_ClrInstanceID;
                    }
                }

                private int Offset_ManagedPdbSignature
                {
                    get
                    {
                        if (_offset_ManagedPdbSignature == -1)
                        {
                            _offset_ManagedPdbSignature = Offset_ClrInstanceID + 2;
                        }

                        return _offset_ManagedPdbSignature;
                    }
                }

                private int Offset_ManagedPdbAge
                {
                    get
                    {
                        if (_offset_ManagedPdbAge == -1)
                        {
                            _offset_ManagedPdbAge = Offset_ManagedPdbSignature + 16;
                        }

                        return _offset_ManagedPdbAge;
                    }
                }

                private int Offset_ManagedPdbBuildPath
                {
                    get
                    {
                        if (_offset_ManagedPdbBuildPath == -1)
                        {
                            _offset_ManagedPdbBuildPath = Offset_ManagedPdbAge + 4;
                        }

                        return _offset_ManagedPdbBuildPath;
                    }
                }

                private int Offset_NativePdbSignature
                {
                    get
                    {
                        if (_offset_NativePdbSignature == -1)
                        {
                            _offset_NativePdbSignature = Offset_ManagedPdbBuildPath + _etwEvent.UnicodeStringLength(Offset_ManagedPdbBuildPath);
                        }

                        return _offset_NativePdbSignature;
                    }
                }

                private int Offset_NativePdbAge
                {
                    get
                    {
                        if (_offset_NativePdbAge == -1)
                        {
                            _offset_NativePdbAge = Offset_NativePdbSignature + 16;
                        }

                        return _offset_NativePdbAge;
                    }
                }

                private int Offset_NativePdbBuildPath
                {
                    get
                    {
                        if (_offset_NativePdbBuildPath == -1)
                        {
                            _offset_NativePdbBuildPath = Offset_NativePdbAge + 4;
                        }

                        return _offset_NativePdbBuildPath;
                    }
                }

                /// <summary>
                /// Retrieves the ModuleID field.
                /// </summary>
                public ulong ModuleID => BitConverter.ToUInt64(_etwEvent.Data[Offset_ModuleID..]);

                /// <summary>
                /// Retrieves the AssemblyID field.
                /// </summary>
                public ulong AssemblyID => BitConverter.ToUInt64(_etwEvent.Data[Offset_AssemblyID..]);

                /// <summary>
                /// Retrieves the ModuleFlags field.
                /// </summary>
                public ModuleFlagsMap ModuleFlags => (ModuleFlagsMap)BitConverter.ToUInt32(_etwEvent.Data[Offset_ModuleFlags..]);

                /// <summary>
                /// Retrieves the Reserved1 field.
                /// </summary>
                public uint Reserved1 => BitConverter.ToUInt32(_etwEvent.Data[Offset_Reserved1..]);

                /// <summary>
                /// Retrieves the ModuleILPath field.
                /// </summary>
                public string ModuleILPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ModuleILPath..]);

                /// <summary>
                /// Retrieves the ModuleNativePath field.
                /// </summary>
                public string ModuleNativePath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ModuleNativePath..]);

                /// <summary>
                /// Retrieves the ClrInstanceID field.
                /// </summary>
                public ushort ClrInstanceID => BitConverter.ToUInt16(_etwEvent.Data[Offset_ClrInstanceID..]);

                /// <summary>
                /// Retrieves the ManagedPdbSignature field.
                /// </summary>
                public Guid ManagedPdbSignature => new(_etwEvent.Data[Offset_ManagedPdbSignature..]);

                /// <summary>
                /// Retrieves the ManagedPdbAge field.
                /// </summary>
                public uint ManagedPdbAge => BitConverter.ToUInt32(_etwEvent.Data[Offset_ManagedPdbAge..]);

                /// <summary>
                /// Retrieves the ManagedPdbBuildPath field.
                /// </summary>
                public string ManagedPdbBuildPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ManagedPdbBuildPath..]);

                /// <summary>
                /// Retrieves the NativePdbSignature field.
                /// </summary>
                public Guid NativePdbSignature => new(_etwEvent.Data[Offset_NativePdbSignature..]);

                /// <summary>
                /// Retrieves the NativePdbAge field.
                /// </summary>
                public uint NativePdbAge => BitConverter.ToUInt32(_etwEvent.Data[Offset_NativePdbAge..]);

                /// <summary>
                /// Retrieves the NativePdbBuildPath field.
                /// </summary>
                public string NativePdbBuildPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_NativePdbBuildPath..]);

                /// <summary>
                /// Creates a new LoaderModuleDCStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public LoaderModuleDCStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ModuleID = -1;
                    _offset_AssemblyID = -1;
                    _offset_ModuleFlags = -1;
                    _offset_Reserved1 = -1;
                    _offset_ModuleILPath = -1;
                    _offset_ModuleNativePath = -1;
                    _offset_ClrInstanceID = -1;
                    _offset_ManagedPdbSignature = -1;
                    _offset_ManagedPdbAge = -1;
                    _offset_ManagedPdbBuildPath = -1;
                    _offset_NativePdbSignature = -1;
                    _offset_NativePdbAge = -1;
                    _offset_NativePdbBuildPath = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a LoaderModuleDCStop event.
        /// </summary>
        public readonly ref struct LoaderModuleDCStopEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "LoaderModuleDCStop";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 154,
                Version = 2,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = (EtwEventOpcode)Opcodes.DCStop,
                Task = (ushort)Tasks.Loader,
                Keyword = (ulong)Keywords.LoaderRundownKeyword | (ulong)Keywords.PerfTrackRundownKeyword
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

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
            public LoaderModuleDCStopData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new LoaderModuleDCStopEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public LoaderModuleDCStopEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a LoaderModuleDCStop event.
            /// </summary>
            public ref struct LoaderModuleDCStopData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ModuleID;
                private int _offset_AssemblyID;
                private int _offset_ModuleFlags;
                private int _offset_Reserved1;
                private int _offset_ModuleILPath;
                private int _offset_ModuleNativePath;
                private int _offset_ClrInstanceID;
                private int _offset_ManagedPdbSignature;
                private int _offset_ManagedPdbAge;
                private int _offset_ManagedPdbBuildPath;
                private int _offset_NativePdbSignature;
                private int _offset_NativePdbAge;
                private int _offset_NativePdbBuildPath;

                private int Offset_ModuleID
                {
                    get
                    {
                        if (_offset_ModuleID == -1)
                        {
                            _offset_ModuleID = 0;
                        }

                        return _offset_ModuleID;
                    }
                }

                private int Offset_AssemblyID
                {
                    get
                    {
                        if (_offset_AssemblyID == -1)
                        {
                            _offset_AssemblyID = Offset_ModuleID + 8;
                        }

                        return _offset_AssemblyID;
                    }
                }

                private int Offset_ModuleFlags
                {
                    get
                    {
                        if (_offset_ModuleFlags == -1)
                        {
                            _offset_ModuleFlags = Offset_AssemblyID + 8;
                        }

                        return _offset_ModuleFlags;
                    }
                }

                private int Offset_Reserved1
                {
                    get
                    {
                        if (_offset_Reserved1 == -1)
                        {
                            _offset_Reserved1 = Offset_ModuleFlags + 4;
                        }

                        return _offset_Reserved1;
                    }
                }

                private int Offset_ModuleILPath
                {
                    get
                    {
                        if (_offset_ModuleILPath == -1)
                        {
                            _offset_ModuleILPath = Offset_Reserved1 + 4;
                        }

                        return _offset_ModuleILPath;
                    }
                }

                private int Offset_ModuleNativePath
                {
                    get
                    {
                        if (_offset_ModuleNativePath == -1)
                        {
                            _offset_ModuleNativePath = Offset_ModuleILPath + _etwEvent.UnicodeStringLength(Offset_ModuleILPath);
                        }

                        return _offset_ModuleNativePath;
                    }
                }

                private int Offset_ClrInstanceID
                {
                    get
                    {
                        if (_offset_ClrInstanceID == -1)
                        {
                            _offset_ClrInstanceID = Offset_ModuleNativePath + _etwEvent.UnicodeStringLength(Offset_ModuleNativePath);
                        }

                        return _offset_ClrInstanceID;
                    }
                }

                private int Offset_ManagedPdbSignature
                {
                    get
                    {
                        if (_offset_ManagedPdbSignature == -1)
                        {
                            _offset_ManagedPdbSignature = Offset_ClrInstanceID + 2;
                        }

                        return _offset_ManagedPdbSignature;
                    }
                }

                private int Offset_ManagedPdbAge
                {
                    get
                    {
                        if (_offset_ManagedPdbAge == -1)
                        {
                            _offset_ManagedPdbAge = Offset_ManagedPdbSignature + 16;
                        }

                        return _offset_ManagedPdbAge;
                    }
                }

                private int Offset_ManagedPdbBuildPath
                {
                    get
                    {
                        if (_offset_ManagedPdbBuildPath == -1)
                        {
                            _offset_ManagedPdbBuildPath = Offset_ManagedPdbAge + 4;
                        }

                        return _offset_ManagedPdbBuildPath;
                    }
                }

                private int Offset_NativePdbSignature
                {
                    get
                    {
                        if (_offset_NativePdbSignature == -1)
                        {
                            _offset_NativePdbSignature = Offset_ManagedPdbBuildPath + _etwEvent.UnicodeStringLength(Offset_ManagedPdbBuildPath);
                        }

                        return _offset_NativePdbSignature;
                    }
                }

                private int Offset_NativePdbAge
                {
                    get
                    {
                        if (_offset_NativePdbAge == -1)
                        {
                            _offset_NativePdbAge = Offset_NativePdbSignature + 16;
                        }

                        return _offset_NativePdbAge;
                    }
                }

                private int Offset_NativePdbBuildPath
                {
                    get
                    {
                        if (_offset_NativePdbBuildPath == -1)
                        {
                            _offset_NativePdbBuildPath = Offset_NativePdbAge + 4;
                        }

                        return _offset_NativePdbBuildPath;
                    }
                }

                /// <summary>
                /// Retrieves the ModuleID field.
                /// </summary>
                public ulong ModuleID => BitConverter.ToUInt64(_etwEvent.Data[Offset_ModuleID..]);

                /// <summary>
                /// Retrieves the AssemblyID field.
                /// </summary>
                public ulong AssemblyID => BitConverter.ToUInt64(_etwEvent.Data[Offset_AssemblyID..]);

                /// <summary>
                /// Retrieves the ModuleFlags field.
                /// </summary>
                public ModuleFlagsMap ModuleFlags => (ModuleFlagsMap)BitConverter.ToUInt32(_etwEvent.Data[Offset_ModuleFlags..]);

                /// <summary>
                /// Retrieves the Reserved1 field.
                /// </summary>
                public uint Reserved1 => BitConverter.ToUInt32(_etwEvent.Data[Offset_Reserved1..]);

                /// <summary>
                /// Retrieves the ModuleILPath field.
                /// </summary>
                public string ModuleILPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ModuleILPath..]);

                /// <summary>
                /// Retrieves the ModuleNativePath field.
                /// </summary>
                public string ModuleNativePath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ModuleNativePath..]);

                /// <summary>
                /// Retrieves the ClrInstanceID field.
                /// </summary>
                public ushort ClrInstanceID => BitConverter.ToUInt16(_etwEvent.Data[Offset_ClrInstanceID..]);

                /// <summary>
                /// Retrieves the ManagedPdbSignature field.
                /// </summary>
                public Guid ManagedPdbSignature => new(_etwEvent.Data[Offset_ManagedPdbSignature..]);

                /// <summary>
                /// Retrieves the ManagedPdbAge field.
                /// </summary>
                public uint ManagedPdbAge => BitConverter.ToUInt32(_etwEvent.Data[Offset_ManagedPdbAge..]);

                /// <summary>
                /// Retrieves the ManagedPdbBuildPath field.
                /// </summary>
                public string ManagedPdbBuildPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ManagedPdbBuildPath..]);

                /// <summary>
                /// Retrieves the NativePdbSignature field.
                /// </summary>
                public Guid NativePdbSignature => new(_etwEvent.Data[Offset_NativePdbSignature..]);

                /// <summary>
                /// Retrieves the NativePdbAge field.
                /// </summary>
                public uint NativePdbAge => BitConverter.ToUInt32(_etwEvent.Data[Offset_NativePdbAge..]);

                /// <summary>
                /// Retrieves the NativePdbBuildPath field.
                /// </summary>
                public string NativePdbBuildPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_NativePdbBuildPath..]);

                /// <summary>
                /// Creates a new LoaderModuleDCStopData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public LoaderModuleDCStopData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ModuleID = -1;
                    _offset_AssemblyID = -1;
                    _offset_ModuleFlags = -1;
                    _offset_Reserved1 = -1;
                    _offset_ModuleILPath = -1;
                    _offset_ModuleNativePath = -1;
                    _offset_ClrInstanceID = -1;
                    _offset_ManagedPdbSignature = -1;
                    _offset_ManagedPdbAge = -1;
                    _offset_ManagedPdbBuildPath = -1;
                    _offset_NativePdbSignature = -1;
                    _offset_NativePdbAge = -1;
                    _offset_NativePdbBuildPath = -1;
                }
            }

        }

        /// <summary>
        /// AppDomainFlagsMap.
        /// </summary>
        [Flags]
        public enum AppDomainFlagsMap : ulong
        {
            /// <summary>
            /// Default.
            /// </summary>
            Default = 0x0000000000000001,
            /// <summary>
            /// Executable.
            /// </summary>
            Executable = 0x0000000000000002,
            /// <summary>
            /// Shared.
            /// </summary>
            Shared = 0x0000000000000004,
        }

        /// <summary>
        /// AssemblyFlagsMap.
        /// </summary>
        [Flags]
        public enum AssemblyFlagsMap : ulong
        {
            /// <summary>
            /// DomainNeutral.
            /// </summary>
            DomainNeutral = 0x0000000000000001,
            /// <summary>
            /// Dynamic.
            /// </summary>
            Dynamic = 0x0000000000000002,
            /// <summary>
            /// Native.
            /// </summary>
            Native = 0x0000000000000004,
            /// <summary>
            /// Collectible.
            /// </summary>
            Collectible = 0x0000000000000008,
        }

        /// <summary>
        /// MethodFlagsMap.
        /// </summary>
        [Flags]
        public enum MethodFlagsMap : ulong
        {
            /// <summary>
            /// Dynamic.
            /// </summary>
            Dynamic = 0x0000000000000001,
            /// <summary>
            /// Generic.
            /// </summary>
            Generic = 0x0000000000000002,
            /// <summary>
            /// HasSharedGenericCode.
            /// </summary>
            HasSharedGenericCode = 0x0000000000000004,
            /// <summary>
            /// Jitted.
            /// </summary>
            Jitted = 0x0000000000000008,
        }

        /// <summary>
        /// ModuleFlagsMap.
        /// </summary>
        [Flags]
        public enum ModuleFlagsMap : ulong
        {
            /// <summary>
            /// DomainNeutral.
            /// </summary>
            DomainNeutral = 0x0000000000000001,
            /// <summary>
            /// Native.
            /// </summary>
            Native = 0x0000000000000002,
            /// <summary>
            /// Dynamic.
            /// </summary>
            Dynamic = 0x0000000000000004,
            /// <summary>
            /// Manifest.
            /// </summary>
            Manifest = 0x0000000000000008,
        }

        /// <summary>
        /// ModuleRangeTypeMap.
        /// </summary>
        [Flags]
        public enum ModuleRangeTypeMap : ulong
        {
            /// <summary>
            /// ColdRange.
            /// </summary>
            ColdRange = 0x0000000000000004,
        }

        /// <summary>
        /// RuntimeSkuMap.
        /// </summary>
        [Flags]
        public enum RuntimeSkuMap : ulong
        {
            /// <summary>
            /// DesktopClr.
            /// </summary>
            DesktopClr = 0x0000000000000001,
            /// <summary>
            /// CoreClr.
            /// </summary>
            CoreClr = 0x0000000000000002,
        }

        /// <summary>
        /// StartupFlagsMap.
        /// </summary>
        [Flags]
        public enum StartupFlagsMap : ulong
        {
            /// <summary>
            /// CONCURRENT_GC.
            /// </summary>
            CONCURRENT_GC = 0x0000000000000001,
            /// <summary>
            /// LOADER_OPTIMIZATION_SINGLE_DOMAIN.
            /// </summary>
            LOADER_OPTIMIZATION_SINGLE_DOMAIN = 0x0000000000000002,
            /// <summary>
            /// LOADER_OPTIMIZATION_MULTI_DOMAIN.
            /// </summary>
            LOADER_OPTIMIZATION_MULTI_DOMAIN = 0x0000000000000004,
            /// <summary>
            /// LOADER_SAFEMODE.
            /// </summary>
            LOADER_SAFEMODE = 0x0000000000000010,
            /// <summary>
            /// LOADER_SETPREFERENCE.
            /// </summary>
            LOADER_SETPREFERENCE = 0x0000000000000100,
            /// <summary>
            /// SERVER_GC.
            /// </summary>
            SERVER_GC = 0x0000000000001000,
            /// <summary>
            /// HOARD_GC_VM.
            /// </summary>
            HOARD_GC_VM = 0x0000000000002000,
            /// <summary>
            /// SINGLE_VERSION_HOSTING_INTERFACE.
            /// </summary>
            SINGLE_VERSION_HOSTING_INTERFACE = 0x0000000000004000,
            /// <summary>
            /// LEGACY_IMPERSONATION.
            /// </summary>
            LEGACY_IMPERSONATION = 0x0000000000010000,
            /// <summary>
            /// DISABLE_COMMITTHREADSTACK.
            /// </summary>
            DISABLE_COMMITTHREADSTACK = 0x0000000000020000,
            /// <summary>
            /// ALWAYSFLOW_IMPERSONATION.
            /// </summary>
            ALWAYSFLOW_IMPERSONATION = 0x0000000000040000,
            /// <summary>
            /// TRIM_GC_COMMIT.
            /// </summary>
            TRIM_GC_COMMIT = 0x0000000000080000,
            /// <summary>
            /// ETW.
            /// </summary>
            ETW = 0x0000000000100000,
            /// <summary>
            /// SERVER_BUILD.
            /// </summary>
            SERVER_BUILD = 0x0000000000200000,
            /// <summary>
            /// ARM.
            /// </summary>
            ARM = 0x0000000000400000,
        }

        /// <summary>
        /// StartupModeMap.
        /// </summary>
        [Flags]
        public enum StartupModeMap : ulong
        {
            /// <summary>
            /// ManagedExe.
            /// </summary>
            ManagedExe = 0x0000000000000001,
            /// <summary>
            /// HostedClr.
            /// </summary>
            HostedClr = 0x0000000000000002,
            /// <summary>
            /// IjwDll.
            /// </summary>
            IjwDll = 0x0000000000000004,
            /// <summary>
            /// ComActivated.
            /// </summary>
            ComActivated = 0x0000000000000008,
            /// <summary>
            /// Other.
            /// </summary>
            Other = 0x0000000000000010,
        }

        /// <summary>
        /// ThreadFlagsMap.
        /// </summary>
        [Flags]
        public enum ThreadFlagsMap : ulong
        {
            /// <summary>
            /// GCSpecial.
            /// </summary>
            GCSpecial = 0x0000000000000001,
            /// <summary>
            /// Finalizer.
            /// </summary>
            Finalizer = 0x0000000000000002,
            /// <summary>
            /// ThreadPoolWorker.
            /// </summary>
            ThreadPoolWorker = 0x0000000000000004,
        }
    }
}
