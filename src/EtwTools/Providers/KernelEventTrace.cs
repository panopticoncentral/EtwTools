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
    /// Provider for Kernel-EventTrace (68fdd900-4a3e-11d1-84f4-0000f80464e3)
    /// </summary>
    public sealed class KernelEventTraceProvider
    {
        /// <summary>s
        /// Provider ID.
        /// </summary>
        public static readonly Guid Id = new("68fdd900-4a3e-11d1-84f4-0000f80464e3");

        /// <summary>
        /// Provider name.
        /// </summary>
        public const string Name = "Kernel-EventTrace";

        /// <summary>
        /// Opcodes supported by KernelEventTrace.
        /// </summary>
        public enum Opcodes
        {
            /// <summary>
            /// 'EndExtension' opcode.
            /// </summary>
            EndExtension = 32,
            /// <summary>
            /// 'DbgIdRSDS' opcode.
            /// </summary>
            DbgIdRSDS = 64,
            /// <summary>
            /// 'BuildInfo' opcode.
            /// </summary>
            BuildInfo = 66,
            /// <summary>
            /// 'ProviderBinaryPath' opcode.
            /// </summary>
            ProviderBinaryPath = 67,
            /// <summary>
            /// 'PartitionInfoExtension' opcode.
            /// </summary>
            PartitionInfoExtension = 80,
            /// <summary>
            /// 'LastDroppedTimes' opcode.
            /// </summary>
            LastDroppedTimes = 82,
        }

        /// <summary>
        /// An event wrapper for a RDComplete event.
        /// </summary>
        public readonly ref struct RDCompleteEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "RDComplete";

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
                Opcode = EtwEventOpcode.Checkpoint,
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
            /// Creates a new RDCompleteEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public RDCompleteEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a RDCompleteEvent.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator RDCompleteEvent(EtwEvent etwEvent) => new(etwEvent);
        }

        /// <summary>
        /// An event wrapper for a Extension event.
        /// </summary>
        public readonly ref struct ExtensionEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Extension";

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
                Opcode = EtwEventOpcode.Extension,
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
            public ExtensionData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ExtensionEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ExtensionEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a ExtensionEvent.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator ExtensionEvent(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Extension event.
            /// </summary>
            public ref struct ExtensionData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_GroupMask1;
                private int _offset_GroupMask2;
                private int _offset_GroupMask3;
                private int _offset_GroupMask4;
                private int _offset_GroupMask5;
                private int _offset_GroupMask6;
                private int _offset_GroupMask7;
                private int _offset_GroupMask8;

                private int Offset_GroupMask1
                {
                    get
                    {
                        if (_offset_GroupMask1 == -1)
                        {
                            _offset_GroupMask1 = 0;
                        }

                        return _offset_GroupMask1;
                    }
                }

                private int Offset_GroupMask2
                {
                    get
                    {
                        if (_offset_GroupMask2 == -1)
                        {
                            _offset_GroupMask2 = Offset_GroupMask1 + 4;
                        }

                        return _offset_GroupMask2;
                    }
                }

                private int Offset_GroupMask3
                {
                    get
                    {
                        if (_offset_GroupMask3 == -1)
                        {
                            _offset_GroupMask3 = Offset_GroupMask2 + 4;
                        }

                        return _offset_GroupMask3;
                    }
                }

                private int Offset_GroupMask4
                {
                    get
                    {
                        if (_offset_GroupMask4 == -1)
                        {
                            _offset_GroupMask4 = Offset_GroupMask3 + 4;
                        }

                        return _offset_GroupMask4;
                    }
                }

                private int Offset_GroupMask5
                {
                    get
                    {
                        if (_offset_GroupMask5 == -1)
                        {
                            _offset_GroupMask5 = Offset_GroupMask4 + 4;
                        }

                        return _offset_GroupMask5;
                    }
                }

                private int Offset_GroupMask6
                {
                    get
                    {
                        if (_offset_GroupMask6 == -1)
                        {
                            _offset_GroupMask6 = Offset_GroupMask5 + 4;
                        }

                        return _offset_GroupMask6;
                    }
                }

                private int Offset_GroupMask7
                {
                    get
                    {
                        if (_offset_GroupMask7 == -1)
                        {
                            _offset_GroupMask7 = Offset_GroupMask6 + 4;
                        }

                        return _offset_GroupMask7;
                    }
                }

                private int Offset_GroupMask8
                {
                    get
                    {
                        if (_offset_GroupMask8 == -1)
                        {
                            _offset_GroupMask8 = Offset_GroupMask7 + 4;
                        }

                        return _offset_GroupMask8;
                    }
                }

                /// <summary>
                /// Retrieves the GroupMask1 field.
                /// </summary>
                public uint GroupMask1 => BitConverter.ToUInt32(_etwEvent.Data[Offset_GroupMask1..Offset_GroupMask2]);

                /// <summary>
                /// Retrieves the GroupMask2 field.
                /// </summary>
                public uint GroupMask2 => BitConverter.ToUInt32(_etwEvent.Data[Offset_GroupMask2..Offset_GroupMask3]);

                /// <summary>
                /// Retrieves the GroupMask3 field.
                /// </summary>
                public uint GroupMask3 => BitConverter.ToUInt32(_etwEvent.Data[Offset_GroupMask3..Offset_GroupMask4]);

                /// <summary>
                /// Retrieves the GroupMask4 field.
                /// </summary>
                public uint GroupMask4 => BitConverter.ToUInt32(_etwEvent.Data[Offset_GroupMask4..Offset_GroupMask5]);

                /// <summary>
                /// Retrieves the GroupMask5 field.
                /// </summary>
                public uint GroupMask5 => BitConverter.ToUInt32(_etwEvent.Data[Offset_GroupMask5..Offset_GroupMask6]);

                /// <summary>
                /// Retrieves the GroupMask6 field.
                /// </summary>
                public uint GroupMask6 => BitConverter.ToUInt32(_etwEvent.Data[Offset_GroupMask6..Offset_GroupMask7]);

                /// <summary>
                /// Retrieves the GroupMask7 field.
                /// </summary>
                public uint GroupMask7 => BitConverter.ToUInt32(_etwEvent.Data[Offset_GroupMask7..Offset_GroupMask8]);

                /// <summary>
                /// Retrieves the GroupMask8 field.
                /// </summary>
                public uint GroupMask8 => BitConverter.ToUInt32(_etwEvent.Data[Offset_GroupMask8..]);

                /// <summary>
                /// Creates a new ExtensionData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ExtensionData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_GroupMask1 = -1;
                    _offset_GroupMask2 = -1;
                    _offset_GroupMask3 = -1;
                    _offset_GroupMask4 = -1;
                    _offset_GroupMask5 = -1;
                    _offset_GroupMask6 = -1;
                    _offset_GroupMask7 = -1;
                    _offset_GroupMask8 = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a EndExtension event.
        /// </summary>
        public readonly ref struct EndExtensionEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "EndExtension";

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
                Opcode = (EtwEventOpcode)Opcodes.EndExtension,
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
            public EndExtensionData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new EndExtensionEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public EndExtensionEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a EndExtensionEvent.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator EndExtensionEvent(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a EndExtension event.
            /// </summary>
            public ref struct EndExtensionData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_GroupMask1;
                private int _offset_GroupMask2;
                private int _offset_GroupMask3;
                private int _offset_GroupMask4;
                private int _offset_GroupMask5;
                private int _offset_GroupMask6;
                private int _offset_GroupMask7;
                private int _offset_GroupMask8;

                private int Offset_GroupMask1
                {
                    get
                    {
                        if (_offset_GroupMask1 == -1)
                        {
                            _offset_GroupMask1 = 0;
                        }

                        return _offset_GroupMask1;
                    }
                }

                private int Offset_GroupMask2
                {
                    get
                    {
                        if (_offset_GroupMask2 == -1)
                        {
                            _offset_GroupMask2 = Offset_GroupMask1 + 4;
                        }

                        return _offset_GroupMask2;
                    }
                }

                private int Offset_GroupMask3
                {
                    get
                    {
                        if (_offset_GroupMask3 == -1)
                        {
                            _offset_GroupMask3 = Offset_GroupMask2 + 4;
                        }

                        return _offset_GroupMask3;
                    }
                }

                private int Offset_GroupMask4
                {
                    get
                    {
                        if (_offset_GroupMask4 == -1)
                        {
                            _offset_GroupMask4 = Offset_GroupMask3 + 4;
                        }

                        return _offset_GroupMask4;
                    }
                }

                private int Offset_GroupMask5
                {
                    get
                    {
                        if (_offset_GroupMask5 == -1)
                        {
                            _offset_GroupMask5 = Offset_GroupMask4 + 4;
                        }

                        return _offset_GroupMask5;
                    }
                }

                private int Offset_GroupMask6
                {
                    get
                    {
                        if (_offset_GroupMask6 == -1)
                        {
                            _offset_GroupMask6 = Offset_GroupMask5 + 4;
                        }

                        return _offset_GroupMask6;
                    }
                }

                private int Offset_GroupMask7
                {
                    get
                    {
                        if (_offset_GroupMask7 == -1)
                        {
                            _offset_GroupMask7 = Offset_GroupMask6 + 4;
                        }

                        return _offset_GroupMask7;
                    }
                }

                private int Offset_GroupMask8
                {
                    get
                    {
                        if (_offset_GroupMask8 == -1)
                        {
                            _offset_GroupMask8 = Offset_GroupMask7 + 4;
                        }

                        return _offset_GroupMask8;
                    }
                }

                /// <summary>
                /// Retrieves the GroupMask1 field.
                /// </summary>
                public uint GroupMask1 => BitConverter.ToUInt32(_etwEvent.Data[Offset_GroupMask1..Offset_GroupMask2]);

                /// <summary>
                /// Retrieves the GroupMask2 field.
                /// </summary>
                public uint GroupMask2 => BitConverter.ToUInt32(_etwEvent.Data[Offset_GroupMask2..Offset_GroupMask3]);

                /// <summary>
                /// Retrieves the GroupMask3 field.
                /// </summary>
                public uint GroupMask3 => BitConverter.ToUInt32(_etwEvent.Data[Offset_GroupMask3..Offset_GroupMask4]);

                /// <summary>
                /// Retrieves the GroupMask4 field.
                /// </summary>
                public uint GroupMask4 => BitConverter.ToUInt32(_etwEvent.Data[Offset_GroupMask4..Offset_GroupMask5]);

                /// <summary>
                /// Retrieves the GroupMask5 field.
                /// </summary>
                public uint GroupMask5 => BitConverter.ToUInt32(_etwEvent.Data[Offset_GroupMask5..Offset_GroupMask6]);

                /// <summary>
                /// Retrieves the GroupMask6 field.
                /// </summary>
                public uint GroupMask6 => BitConverter.ToUInt32(_etwEvent.Data[Offset_GroupMask6..Offset_GroupMask7]);

                /// <summary>
                /// Retrieves the GroupMask7 field.
                /// </summary>
                public uint GroupMask7 => BitConverter.ToUInt32(_etwEvent.Data[Offset_GroupMask7..Offset_GroupMask8]);

                /// <summary>
                /// Retrieves the GroupMask8 field.
                /// </summary>
                public uint GroupMask8 => BitConverter.ToUInt32(_etwEvent.Data[Offset_GroupMask8..]);

                /// <summary>
                /// Creates a new EndExtensionData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public EndExtensionData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_GroupMask1 = -1;
                    _offset_GroupMask2 = -1;
                    _offset_GroupMask3 = -1;
                    _offset_GroupMask4 = -1;
                    _offset_GroupMask5 = -1;
                    _offset_GroupMask6 = -1;
                    _offset_GroupMask7 = -1;
                    _offset_GroupMask8 = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Header event.
        /// </summary>
        public readonly ref struct HeaderEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Header";

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
            public HeaderData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new HeaderEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public HeaderEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a HeaderEvent.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator HeaderEvent(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Header event.
            /// </summary>
            public ref struct HeaderData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_BufferSize;
                private int _offset_Version;
                private int _offset_ProviderVersion;
                private int _offset_NumberOfProcessors;
                private int _offset_EndTime;
                private int _offset_TimerResolution;
                private int _offset_MaxFileSize;
                private int _offset_LogFileMode;
                private int _offset_BuffersWritten;
                private int _offset_StartBuffers;
                private int _offset_PointerSize;
                private int _offset_EventsLost;
                private int _offset_CPUSpeed;
                private int _offset_LoggerName;
                private int _offset_LogFileName;
                private int _offset_TimeZoneInformation;
                private int _offset_BootTime;
                private int _offset_PerfFreq;
                private int _offset_StartTime;
                private int _offset_ReservedFlags;
                private int _offset_BuffersLost;
                private int _offset_SessionNameString;
                private int _offset_LogFileNameString;

                private int Offset_BufferSize
                {
                    get
                    {
                        if (_offset_BufferSize == -1)
                        {
                            _offset_BufferSize = 0;
                        }

                        return _offset_BufferSize;
                    }
                }

                private int Offset_Version
                {
                    get
                    {
                        if (_offset_Version == -1)
                        {
                            _offset_Version = Offset_BufferSize + 4;
                        }

                        return _offset_Version;
                    }
                }

                private int Offset_ProviderVersion
                {
                    get
                    {
                        if (_offset_ProviderVersion == -1)
                        {
                            _offset_ProviderVersion = Offset_Version + 4;
                        }

                        return _offset_ProviderVersion;
                    }
                }

                private int Offset_NumberOfProcessors
                {
                    get
                    {
                        if (_offset_NumberOfProcessors == -1)
                        {
                            _offset_NumberOfProcessors = Offset_ProviderVersion + 4;
                        }

                        return _offset_NumberOfProcessors;
                    }
                }

                private int Offset_EndTime
                {
                    get
                    {
                        if (_offset_EndTime == -1)
                        {
                            _offset_EndTime = Offset_NumberOfProcessors + 4;
                        }

                        return _offset_EndTime;
                    }
                }

                private int Offset_TimerResolution
                {
                    get
                    {
                        if (_offset_TimerResolution == -1)
                        {
                            _offset_TimerResolution = Offset_EndTime + 8;
                        }

                        return _offset_TimerResolution;
                    }
                }

                private int Offset_MaxFileSize
                {
                    get
                    {
                        if (_offset_MaxFileSize == -1)
                        {
                            _offset_MaxFileSize = Offset_TimerResolution + 4;
                        }

                        return _offset_MaxFileSize;
                    }
                }

                private int Offset_LogFileMode
                {
                    get
                    {
                        if (_offset_LogFileMode == -1)
                        {
                            _offset_LogFileMode = Offset_MaxFileSize + 4;
                        }

                        return _offset_LogFileMode;
                    }
                }

                private int Offset_BuffersWritten
                {
                    get
                    {
                        if (_offset_BuffersWritten == -1)
                        {
                            _offset_BuffersWritten = Offset_LogFileMode + 4;
                        }

                        return _offset_BuffersWritten;
                    }
                }

                private int Offset_StartBuffers
                {
                    get
                    {
                        if (_offset_StartBuffers == -1)
                        {
                            _offset_StartBuffers = Offset_BuffersWritten + 4;
                        }

                        return _offset_StartBuffers;
                    }
                }

                private int Offset_PointerSize
                {
                    get
                    {
                        if (_offset_PointerSize == -1)
                        {
                            _offset_PointerSize = Offset_StartBuffers + 4;
                        }

                        return _offset_PointerSize;
                    }
                }

                private int Offset_EventsLost
                {
                    get
                    {
                        if (_offset_EventsLost == -1)
                        {
                            _offset_EventsLost = Offset_PointerSize + 4;
                        }

                        return _offset_EventsLost;
                    }
                }

                private int Offset_CPUSpeed
                {
                    get
                    {
                        if (_offset_CPUSpeed == -1)
                        {
                            _offset_CPUSpeed = Offset_EventsLost + 4;
                        }

                        return _offset_CPUSpeed;
                    }
                }

                private int Offset_LoggerName
                {
                    get
                    {
                        if (_offset_LoggerName == -1)
                        {
                            _offset_LoggerName = Offset_CPUSpeed + 4;
                        }

                        return _offset_LoggerName;
                    }
                }

                private int Offset_LogFileName
                {
                    get
                    {
                        if (_offset_LogFileName == -1)
                        {
                            _offset_LogFileName = Offset_LoggerName + _etwEvent.AddressSize;
                        }

                        return _offset_LogFileName;
                    }
                }

                private int Offset_TimeZoneInformation
                {
                    get
                    {
                        if (_offset_TimeZoneInformation == -1)
                        {
                            _offset_TimeZoneInformation = Offset_LogFileName + _etwEvent.AddressSize;
                        }

                        return _offset_TimeZoneInformation;
                    }
                }

                private int Offset_BootTime
                {
                    get
                    {
                        if (_offset_BootTime == -1)
                        {
                            _offset_BootTime = Offset_TimeZoneInformation + 1;
                        }

                        return _offset_BootTime;
                    }
                }

                private int Offset_PerfFreq
                {
                    get
                    {
                        if (_offset_PerfFreq == -1)
                        {
                            _offset_PerfFreq = Offset_BootTime + 8;
                        }

                        return _offset_PerfFreq;
                    }
                }

                private int Offset_StartTime
                {
                    get
                    {
                        if (_offset_StartTime == -1)
                        {
                            _offset_StartTime = Offset_PerfFreq + 8;
                        }

                        return _offset_StartTime;
                    }
                }

                private int Offset_ReservedFlags
                {
                    get
                    {
                        if (_offset_ReservedFlags == -1)
                        {
                            _offset_ReservedFlags = Offset_StartTime + 8;
                        }

                        return _offset_ReservedFlags;
                    }
                }

                private int Offset_BuffersLost
                {
                    get
                    {
                        if (_offset_BuffersLost == -1)
                        {
                            _offset_BuffersLost = Offset_ReservedFlags + 4;
                        }

                        return _offset_BuffersLost;
                    }
                }

                private int Offset_SessionNameString
                {
                    get
                    {
                        if (_offset_SessionNameString == -1)
                        {
                            _offset_SessionNameString = Offset_BuffersLost + 4;
                        }

                        return _offset_SessionNameString;
                    }
                }

                private int Offset_LogFileNameString
                {
                    get
                    {
                        if (_offset_LogFileNameString == -1)
                        {
                            _offset_LogFileNameString = Offset_SessionNameString + _etwEvent.UnicodeStringLength(Offset_SessionNameString);
                        }

                        return _offset_LogFileNameString;
                    }
                }

                /// <summary>
                /// Retrieves the BufferSize field.
                /// </summary>
                public uint BufferSize => BitConverter.ToUInt32(_etwEvent.Data[Offset_BufferSize..Offset_Version]);

                /// <summary>
                /// Retrieves the Version field.
                /// </summary>
                public uint Version => BitConverter.ToUInt32(_etwEvent.Data[Offset_Version..Offset_ProviderVersion]);

                /// <summary>
                /// Retrieves the ProviderVersion field.
                /// </summary>
                public uint ProviderVersion => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProviderVersion..Offset_NumberOfProcessors]);

                /// <summary>
                /// Retrieves the NumberOfProcessors field.
                /// </summary>
                public uint NumberOfProcessors => BitConverter.ToUInt32(_etwEvent.Data[Offset_NumberOfProcessors..Offset_EndTime]);

                /// <summary>
                /// Retrieves the EndTime field.
                /// </summary>
                public ulong EndTime => BitConverter.ToUInt64(_etwEvent.Data[Offset_EndTime..Offset_TimerResolution]);

                /// <summary>
                /// Retrieves the TimerResolution field.
                /// </summary>
                public uint TimerResolution => BitConverter.ToUInt32(_etwEvent.Data[Offset_TimerResolution..Offset_MaxFileSize]);

                /// <summary>
                /// Retrieves the MaxFileSize field.
                /// </summary>
                public uint MaxFileSize => BitConverter.ToUInt32(_etwEvent.Data[Offset_MaxFileSize..Offset_LogFileMode]);

                /// <summary>
                /// Retrieves the LogFileMode field.
                /// </summary>
                public uint LogFileMode => BitConverter.ToUInt32(_etwEvent.Data[Offset_LogFileMode..Offset_BuffersWritten]);

                /// <summary>
                /// Retrieves the BuffersWritten field.
                /// </summary>
                public uint BuffersWritten => BitConverter.ToUInt32(_etwEvent.Data[Offset_BuffersWritten..Offset_StartBuffers]);

                /// <summary>
                /// Retrieves the StartBuffers field.
                /// </summary>
                public uint StartBuffers => BitConverter.ToUInt32(_etwEvent.Data[Offset_StartBuffers..Offset_PointerSize]);

                /// <summary>
                /// Retrieves the PointerSize field.
                /// </summary>
                public uint PointerSize => BitConverter.ToUInt32(_etwEvent.Data[Offset_PointerSize..Offset_EventsLost]);

                /// <summary>
                /// Retrieves the EventsLost field.
                /// </summary>
                public uint EventsLost => BitConverter.ToUInt32(_etwEvent.Data[Offset_EventsLost..Offset_CPUSpeed]);

                /// <summary>
                /// Retrieves the CPUSpeed field.
                /// </summary>
                public uint CPUSpeed => BitConverter.ToUInt32(_etwEvent.Data[Offset_CPUSpeed..Offset_LoggerName]);

                /// <summary>
                /// Retrieves the LoggerName field.
                /// </summary>
                public ulong LoggerName => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_LoggerName..Offset_LogFileName]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_LoggerName..Offset_LogFileName]);

                /// <summary>
                /// Retrieves the LogFileName field.
                /// </summary>
                public ulong LogFileName => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_LogFileName..Offset_TimeZoneInformation]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_LogFileName..Offset_TimeZoneInformation]);

                /// <summary>
                /// Retrieves the TimeZoneInformation field.
                /// </summary>
                public byte TimeZoneInformation => _etwEvent.Data[Offset_TimeZoneInformation];

                /// <summary>
                /// Retrieves the BootTime field.
                /// </summary>
                public ulong BootTime => BitConverter.ToUInt64(_etwEvent.Data[Offset_BootTime..Offset_PerfFreq]);

                /// <summary>
                /// Retrieves the PerfFreq field.
                /// </summary>
                public ulong PerfFreq => BitConverter.ToUInt64(_etwEvent.Data[Offset_PerfFreq..Offset_StartTime]);

                /// <summary>
                /// Retrieves the StartTime field.
                /// </summary>
                public ulong StartTime => BitConverter.ToUInt64(_etwEvent.Data[Offset_StartTime..Offset_ReservedFlags]);

                /// <summary>
                /// Retrieves the ReservedFlags field.
                /// </summary>
                public uint ReservedFlags => BitConverter.ToUInt32(_etwEvent.Data[Offset_ReservedFlags..Offset_BuffersLost]);

                /// <summary>
                /// Retrieves the BuffersLost field.
                /// </summary>
                public uint BuffersLost => BitConverter.ToUInt32(_etwEvent.Data[Offset_BuffersLost..Offset_SessionNameString]);

                /// <summary>
                /// Retrieves the SessionNameString field.
                /// </summary>
                public string SessionNameString => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_SessionNameString..Offset_LogFileNameString]);

                /// <summary>
                /// Retrieves the LogFileNameString field.
                /// </summary>
                public string LogFileNameString => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_LogFileNameString..]);

                /// <summary>
                /// Creates a new HeaderData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public HeaderData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_BufferSize = -1;
                    _offset_Version = -1;
                    _offset_ProviderVersion = -1;
                    _offset_NumberOfProcessors = -1;
                    _offset_EndTime = -1;
                    _offset_TimerResolution = -1;
                    _offset_MaxFileSize = -1;
                    _offset_LogFileMode = -1;
                    _offset_BuffersWritten = -1;
                    _offset_StartBuffers = -1;
                    _offset_PointerSize = -1;
                    _offset_EventsLost = -1;
                    _offset_CPUSpeed = -1;
                    _offset_LoggerName = -1;
                    _offset_LogFileName = -1;
                    _offset_TimeZoneInformation = -1;
                    _offset_BootTime = -1;
                    _offset_PerfFreq = -1;
                    _offset_StartTime = -1;
                    _offset_ReservedFlags = -1;
                    _offset_BuffersLost = -1;
                    _offset_SessionNameString = -1;
                    _offset_LogFileNameString = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Header event.
        /// </summary>
        public readonly ref struct HeaderEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Header";

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
                Opcode = EtwEventOpcode.Info,
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
            public HeaderData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new HeaderEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public HeaderEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a HeaderEventV1.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator HeaderEventV1(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Header event.
            /// </summary>
            public ref struct HeaderData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_BufferSize;
                private int _offset_Version;
                private int _offset_ProviderVersion;
                private int _offset_NumberOfProcessors;
                private int _offset_EndTime;
                private int _offset_TimerResolution;
                private int _offset_MaxFileSize;
                private int _offset_LogFileMode;
                private int _offset_BuffersWritten;
                private int _offset_StartBuffers;
                private int _offset_PointerSize;
                private int _offset_EventsLost;
                private int _offset_CPUSpeed;
                private int _offset_LoggerName;
                private int _offset_LogFileName;
                private int _offset_TimeZoneInformation;
                private int _offset_BootTime;
                private int _offset_PerfFreq;
                private int _offset_StartTime;
                private int _offset_ReservedFlags;
                private int _offset_BuffersLost;
                private int _offset_SessionNameString;
                private int _offset_LogFileNameString;

                private int Offset_BufferSize
                {
                    get
                    {
                        if (_offset_BufferSize == -1)
                        {
                            _offset_BufferSize = 0;
                        }

                        return _offset_BufferSize;
                    }
                }

                private int Offset_Version
                {
                    get
                    {
                        if (_offset_Version == -1)
                        {
                            _offset_Version = Offset_BufferSize + 4;
                        }

                        return _offset_Version;
                    }
                }

                private int Offset_ProviderVersion
                {
                    get
                    {
                        if (_offset_ProviderVersion == -1)
                        {
                            _offset_ProviderVersion = Offset_Version + 4;
                        }

                        return _offset_ProviderVersion;
                    }
                }

                private int Offset_NumberOfProcessors
                {
                    get
                    {
                        if (_offset_NumberOfProcessors == -1)
                        {
                            _offset_NumberOfProcessors = Offset_ProviderVersion + 4;
                        }

                        return _offset_NumberOfProcessors;
                    }
                }

                private int Offset_EndTime
                {
                    get
                    {
                        if (_offset_EndTime == -1)
                        {
                            _offset_EndTime = Offset_NumberOfProcessors + 4;
                        }

                        return _offset_EndTime;
                    }
                }

                private int Offset_TimerResolution
                {
                    get
                    {
                        if (_offset_TimerResolution == -1)
                        {
                            _offset_TimerResolution = Offset_EndTime + 8;
                        }

                        return _offset_TimerResolution;
                    }
                }

                private int Offset_MaxFileSize
                {
                    get
                    {
                        if (_offset_MaxFileSize == -1)
                        {
                            _offset_MaxFileSize = Offset_TimerResolution + 4;
                        }

                        return _offset_MaxFileSize;
                    }
                }

                private int Offset_LogFileMode
                {
                    get
                    {
                        if (_offset_LogFileMode == -1)
                        {
                            _offset_LogFileMode = Offset_MaxFileSize + 4;
                        }

                        return _offset_LogFileMode;
                    }
                }

                private int Offset_BuffersWritten
                {
                    get
                    {
                        if (_offset_BuffersWritten == -1)
                        {
                            _offset_BuffersWritten = Offset_LogFileMode + 4;
                        }

                        return _offset_BuffersWritten;
                    }
                }

                private int Offset_StartBuffers
                {
                    get
                    {
                        if (_offset_StartBuffers == -1)
                        {
                            _offset_StartBuffers = Offset_BuffersWritten + 4;
                        }

                        return _offset_StartBuffers;
                    }
                }

                private int Offset_PointerSize
                {
                    get
                    {
                        if (_offset_PointerSize == -1)
                        {
                            _offset_PointerSize = Offset_StartBuffers + 4;
                        }

                        return _offset_PointerSize;
                    }
                }

                private int Offset_EventsLost
                {
                    get
                    {
                        if (_offset_EventsLost == -1)
                        {
                            _offset_EventsLost = Offset_PointerSize + 4;
                        }

                        return _offset_EventsLost;
                    }
                }

                private int Offset_CPUSpeed
                {
                    get
                    {
                        if (_offset_CPUSpeed == -1)
                        {
                            _offset_CPUSpeed = Offset_EventsLost + 4;
                        }

                        return _offset_CPUSpeed;
                    }
                }

                private int Offset_LoggerName
                {
                    get
                    {
                        if (_offset_LoggerName == -1)
                        {
                            _offset_LoggerName = Offset_CPUSpeed + 4;
                        }

                        return _offset_LoggerName;
                    }
                }

                private int Offset_LogFileName
                {
                    get
                    {
                        if (_offset_LogFileName == -1)
                        {
                            _offset_LogFileName = Offset_LoggerName + _etwEvent.AddressSize;
                        }

                        return _offset_LogFileName;
                    }
                }

                private int Offset_TimeZoneInformation
                {
                    get
                    {
                        if (_offset_TimeZoneInformation == -1)
                        {
                            _offset_TimeZoneInformation = Offset_LogFileName + _etwEvent.AddressSize;
                        }

                        return _offset_TimeZoneInformation;
                    }
                }

                private int Offset_BootTime
                {
                    get
                    {
                        if (_offset_BootTime == -1)
                        {
                            _offset_BootTime = Offset_TimeZoneInformation + 1;
                        }

                        return _offset_BootTime;
                    }
                }

                private int Offset_PerfFreq
                {
                    get
                    {
                        if (_offset_PerfFreq == -1)
                        {
                            _offset_PerfFreq = Offset_BootTime + 8;
                        }

                        return _offset_PerfFreq;
                    }
                }

                private int Offset_StartTime
                {
                    get
                    {
                        if (_offset_StartTime == -1)
                        {
                            _offset_StartTime = Offset_PerfFreq + 8;
                        }

                        return _offset_StartTime;
                    }
                }

                private int Offset_ReservedFlags
                {
                    get
                    {
                        if (_offset_ReservedFlags == -1)
                        {
                            _offset_ReservedFlags = Offset_StartTime + 8;
                        }

                        return _offset_ReservedFlags;
                    }
                }

                private int Offset_BuffersLost
                {
                    get
                    {
                        if (_offset_BuffersLost == -1)
                        {
                            _offset_BuffersLost = Offset_ReservedFlags + 4;
                        }

                        return _offset_BuffersLost;
                    }
                }

                private int Offset_SessionNameString
                {
                    get
                    {
                        if (_offset_SessionNameString == -1)
                        {
                            _offset_SessionNameString = Offset_BuffersLost + 4;
                        }

                        return _offset_SessionNameString;
                    }
                }

                private int Offset_LogFileNameString
                {
                    get
                    {
                        if (_offset_LogFileNameString == -1)
                        {
                            _offset_LogFileNameString = Offset_SessionNameString + _etwEvent.UnicodeStringLength(Offset_SessionNameString);
                        }

                        return _offset_LogFileNameString;
                    }
                }

                /// <summary>
                /// Retrieves the BufferSize field.
                /// </summary>
                public uint BufferSize => BitConverter.ToUInt32(_etwEvent.Data[Offset_BufferSize..Offset_Version]);

                /// <summary>
                /// Retrieves the Version field.
                /// </summary>
                public uint Version => BitConverter.ToUInt32(_etwEvent.Data[Offset_Version..Offset_ProviderVersion]);

                /// <summary>
                /// Retrieves the ProviderVersion field.
                /// </summary>
                public uint ProviderVersion => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProviderVersion..Offset_NumberOfProcessors]);

                /// <summary>
                /// Retrieves the NumberOfProcessors field.
                /// </summary>
                public uint NumberOfProcessors => BitConverter.ToUInt32(_etwEvent.Data[Offset_NumberOfProcessors..Offset_EndTime]);

                /// <summary>
                /// Retrieves the EndTime field.
                /// </summary>
                public ulong EndTime => BitConverter.ToUInt64(_etwEvent.Data[Offset_EndTime..Offset_TimerResolution]);

                /// <summary>
                /// Retrieves the TimerResolution field.
                /// </summary>
                public uint TimerResolution => BitConverter.ToUInt32(_etwEvent.Data[Offset_TimerResolution..Offset_MaxFileSize]);

                /// <summary>
                /// Retrieves the MaxFileSize field.
                /// </summary>
                public uint MaxFileSize => BitConverter.ToUInt32(_etwEvent.Data[Offset_MaxFileSize..Offset_LogFileMode]);

                /// <summary>
                /// Retrieves the LogFileMode field.
                /// </summary>
                public uint LogFileMode => BitConverter.ToUInt32(_etwEvent.Data[Offset_LogFileMode..Offset_BuffersWritten]);

                /// <summary>
                /// Retrieves the BuffersWritten field.
                /// </summary>
                public uint BuffersWritten => BitConverter.ToUInt32(_etwEvent.Data[Offset_BuffersWritten..Offset_StartBuffers]);

                /// <summary>
                /// Retrieves the StartBuffers field.
                /// </summary>
                public uint StartBuffers => BitConverter.ToUInt32(_etwEvent.Data[Offset_StartBuffers..Offset_PointerSize]);

                /// <summary>
                /// Retrieves the PointerSize field.
                /// </summary>
                public uint PointerSize => BitConverter.ToUInt32(_etwEvent.Data[Offset_PointerSize..Offset_EventsLost]);

                /// <summary>
                /// Retrieves the EventsLost field.
                /// </summary>
                public uint EventsLost => BitConverter.ToUInt32(_etwEvent.Data[Offset_EventsLost..Offset_CPUSpeed]);

                /// <summary>
                /// Retrieves the CPUSpeed field.
                /// </summary>
                public uint CPUSpeed => BitConverter.ToUInt32(_etwEvent.Data[Offset_CPUSpeed..Offset_LoggerName]);

                /// <summary>
                /// Retrieves the LoggerName field.
                /// </summary>
                public ulong LoggerName => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_LoggerName..Offset_LogFileName]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_LoggerName..Offset_LogFileName]);

                /// <summary>
                /// Retrieves the LogFileName field.
                /// </summary>
                public ulong LogFileName => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_LogFileName..Offset_TimeZoneInformation]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_LogFileName..Offset_TimeZoneInformation]);

                /// <summary>
                /// Retrieves the TimeZoneInformation field.
                /// </summary>
                public byte TimeZoneInformation => _etwEvent.Data[Offset_TimeZoneInformation];

                /// <summary>
                /// Retrieves the BootTime field.
                /// </summary>
                public ulong BootTime => BitConverter.ToUInt64(_etwEvent.Data[Offset_BootTime..Offset_PerfFreq]);

                /// <summary>
                /// Retrieves the PerfFreq field.
                /// </summary>
                public ulong PerfFreq => BitConverter.ToUInt64(_etwEvent.Data[Offset_PerfFreq..Offset_StartTime]);

                /// <summary>
                /// Retrieves the StartTime field.
                /// </summary>
                public ulong StartTime => BitConverter.ToUInt64(_etwEvent.Data[Offset_StartTime..Offset_ReservedFlags]);

                /// <summary>
                /// Retrieves the ReservedFlags field.
                /// </summary>
                public uint ReservedFlags => BitConverter.ToUInt32(_etwEvent.Data[Offset_ReservedFlags..Offset_BuffersLost]);

                /// <summary>
                /// Retrieves the BuffersLost field.
                /// </summary>
                public uint BuffersLost => BitConverter.ToUInt32(_etwEvent.Data[Offset_BuffersLost..Offset_SessionNameString]);

                /// <summary>
                /// Retrieves the SessionNameString field.
                /// </summary>
                public string SessionNameString => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_SessionNameString..Offset_LogFileNameString]);

                /// <summary>
                /// Retrieves the LogFileNameString field.
                /// </summary>
                public string LogFileNameString => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_LogFileNameString..]);

                /// <summary>
                /// Creates a new HeaderData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public HeaderData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_BufferSize = -1;
                    _offset_Version = -1;
                    _offset_ProviderVersion = -1;
                    _offset_NumberOfProcessors = -1;
                    _offset_EndTime = -1;
                    _offset_TimerResolution = -1;
                    _offset_MaxFileSize = -1;
                    _offset_LogFileMode = -1;
                    _offset_BuffersWritten = -1;
                    _offset_StartBuffers = -1;
                    _offset_PointerSize = -1;
                    _offset_EventsLost = -1;
                    _offset_CPUSpeed = -1;
                    _offset_LoggerName = -1;
                    _offset_LogFileName = -1;
                    _offset_TimeZoneInformation = -1;
                    _offset_BootTime = -1;
                    _offset_PerfFreq = -1;
                    _offset_StartTime = -1;
                    _offset_ReservedFlags = -1;
                    _offset_BuffersLost = -1;
                    _offset_SessionNameString = -1;
                    _offset_LogFileNameString = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a RDComplete event.
        /// </summary>
        public readonly ref struct RDCompleteEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "RDComplete";

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
                Opcode = EtwEventOpcode.Checkpoint,
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
            /// Creates a new RDCompleteEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public RDCompleteEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a RDCompleteEventV1.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator RDCompleteEventV1(EtwEvent etwEvent) => new(etwEvent);
        }

        /// <summary>
        /// An event wrapper for a Extension event.
        /// </summary>
        public readonly ref struct ExtensionEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Extension";

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
                Opcode = EtwEventOpcode.Extension,
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
            public ExtensionData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ExtensionEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ExtensionEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a ExtensionEventV1.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator ExtensionEventV1(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Extension event.
            /// </summary>
            public ref struct ExtensionData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_GroupMask1;
                private int _offset_GroupMask2;
                private int _offset_GroupMask3;
                private int _offset_GroupMask4;
                private int _offset_GroupMask5;
                private int _offset_GroupMask6;
                private int _offset_GroupMask7;
                private int _offset_GroupMask8;

                private int Offset_GroupMask1
                {
                    get
                    {
                        if (_offset_GroupMask1 == -1)
                        {
                            _offset_GroupMask1 = 0;
                        }

                        return _offset_GroupMask1;
                    }
                }

                private int Offset_GroupMask2
                {
                    get
                    {
                        if (_offset_GroupMask2 == -1)
                        {
                            _offset_GroupMask2 = Offset_GroupMask1 + 4;
                        }

                        return _offset_GroupMask2;
                    }
                }

                private int Offset_GroupMask3
                {
                    get
                    {
                        if (_offset_GroupMask3 == -1)
                        {
                            _offset_GroupMask3 = Offset_GroupMask2 + 4;
                        }

                        return _offset_GroupMask3;
                    }
                }

                private int Offset_GroupMask4
                {
                    get
                    {
                        if (_offset_GroupMask4 == -1)
                        {
                            _offset_GroupMask4 = Offset_GroupMask3 + 4;
                        }

                        return _offset_GroupMask4;
                    }
                }

                private int Offset_GroupMask5
                {
                    get
                    {
                        if (_offset_GroupMask5 == -1)
                        {
                            _offset_GroupMask5 = Offset_GroupMask4 + 4;
                        }

                        return _offset_GroupMask5;
                    }
                }

                private int Offset_GroupMask6
                {
                    get
                    {
                        if (_offset_GroupMask6 == -1)
                        {
                            _offset_GroupMask6 = Offset_GroupMask5 + 4;
                        }

                        return _offset_GroupMask6;
                    }
                }

                private int Offset_GroupMask7
                {
                    get
                    {
                        if (_offset_GroupMask7 == -1)
                        {
                            _offset_GroupMask7 = Offset_GroupMask6 + 4;
                        }

                        return _offset_GroupMask7;
                    }
                }

                private int Offset_GroupMask8
                {
                    get
                    {
                        if (_offset_GroupMask8 == -1)
                        {
                            _offset_GroupMask8 = Offset_GroupMask7 + 4;
                        }

                        return _offset_GroupMask8;
                    }
                }

                /// <summary>
                /// Retrieves the GroupMask1 field.
                /// </summary>
                public uint GroupMask1 => BitConverter.ToUInt32(_etwEvent.Data[Offset_GroupMask1..Offset_GroupMask2]);

                /// <summary>
                /// Retrieves the GroupMask2 field.
                /// </summary>
                public uint GroupMask2 => BitConverter.ToUInt32(_etwEvent.Data[Offset_GroupMask2..Offset_GroupMask3]);

                /// <summary>
                /// Retrieves the GroupMask3 field.
                /// </summary>
                public uint GroupMask3 => BitConverter.ToUInt32(_etwEvent.Data[Offset_GroupMask3..Offset_GroupMask4]);

                /// <summary>
                /// Retrieves the GroupMask4 field.
                /// </summary>
                public uint GroupMask4 => BitConverter.ToUInt32(_etwEvent.Data[Offset_GroupMask4..Offset_GroupMask5]);

                /// <summary>
                /// Retrieves the GroupMask5 field.
                /// </summary>
                public uint GroupMask5 => BitConverter.ToUInt32(_etwEvent.Data[Offset_GroupMask5..Offset_GroupMask6]);

                /// <summary>
                /// Retrieves the GroupMask6 field.
                /// </summary>
                public uint GroupMask6 => BitConverter.ToUInt32(_etwEvent.Data[Offset_GroupMask6..Offset_GroupMask7]);

                /// <summary>
                /// Retrieves the GroupMask7 field.
                /// </summary>
                public uint GroupMask7 => BitConverter.ToUInt32(_etwEvent.Data[Offset_GroupMask7..Offset_GroupMask8]);

                /// <summary>
                /// Retrieves the GroupMask8 field.
                /// </summary>
                public uint GroupMask8 => BitConverter.ToUInt32(_etwEvent.Data[Offset_GroupMask8..]);

                /// <summary>
                /// Creates a new ExtensionData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ExtensionData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_GroupMask1 = -1;
                    _offset_GroupMask2 = -1;
                    _offset_GroupMask3 = -1;
                    _offset_GroupMask4 = -1;
                    _offset_GroupMask5 = -1;
                    _offset_GroupMask6 = -1;
                    _offset_GroupMask7 = -1;
                    _offset_GroupMask8 = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a EndExtension event.
        /// </summary>
        public readonly ref struct EndExtensionEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "EndExtension";

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
                Opcode = (EtwEventOpcode)Opcodes.EndExtension,
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
            public EndExtensionData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new EndExtensionEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public EndExtensionEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a EndExtensionEventV1.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator EndExtensionEventV1(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a EndExtension event.
            /// </summary>
            public ref struct EndExtensionData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_GroupMask1;
                private int _offset_GroupMask2;
                private int _offset_GroupMask3;
                private int _offset_GroupMask4;
                private int _offset_GroupMask5;
                private int _offset_GroupMask6;
                private int _offset_GroupMask7;
                private int _offset_GroupMask8;

                private int Offset_GroupMask1
                {
                    get
                    {
                        if (_offset_GroupMask1 == -1)
                        {
                            _offset_GroupMask1 = 0;
                        }

                        return _offset_GroupMask1;
                    }
                }

                private int Offset_GroupMask2
                {
                    get
                    {
                        if (_offset_GroupMask2 == -1)
                        {
                            _offset_GroupMask2 = Offset_GroupMask1 + 4;
                        }

                        return _offset_GroupMask2;
                    }
                }

                private int Offset_GroupMask3
                {
                    get
                    {
                        if (_offset_GroupMask3 == -1)
                        {
                            _offset_GroupMask3 = Offset_GroupMask2 + 4;
                        }

                        return _offset_GroupMask3;
                    }
                }

                private int Offset_GroupMask4
                {
                    get
                    {
                        if (_offset_GroupMask4 == -1)
                        {
                            _offset_GroupMask4 = Offset_GroupMask3 + 4;
                        }

                        return _offset_GroupMask4;
                    }
                }

                private int Offset_GroupMask5
                {
                    get
                    {
                        if (_offset_GroupMask5 == -1)
                        {
                            _offset_GroupMask5 = Offset_GroupMask4 + 4;
                        }

                        return _offset_GroupMask5;
                    }
                }

                private int Offset_GroupMask6
                {
                    get
                    {
                        if (_offset_GroupMask6 == -1)
                        {
                            _offset_GroupMask6 = Offset_GroupMask5 + 4;
                        }

                        return _offset_GroupMask6;
                    }
                }

                private int Offset_GroupMask7
                {
                    get
                    {
                        if (_offset_GroupMask7 == -1)
                        {
                            _offset_GroupMask7 = Offset_GroupMask6 + 4;
                        }

                        return _offset_GroupMask7;
                    }
                }

                private int Offset_GroupMask8
                {
                    get
                    {
                        if (_offset_GroupMask8 == -1)
                        {
                            _offset_GroupMask8 = Offset_GroupMask7 + 4;
                        }

                        return _offset_GroupMask8;
                    }
                }

                /// <summary>
                /// Retrieves the GroupMask1 field.
                /// </summary>
                public uint GroupMask1 => BitConverter.ToUInt32(_etwEvent.Data[Offset_GroupMask1..Offset_GroupMask2]);

                /// <summary>
                /// Retrieves the GroupMask2 field.
                /// </summary>
                public uint GroupMask2 => BitConverter.ToUInt32(_etwEvent.Data[Offset_GroupMask2..Offset_GroupMask3]);

                /// <summary>
                /// Retrieves the GroupMask3 field.
                /// </summary>
                public uint GroupMask3 => BitConverter.ToUInt32(_etwEvent.Data[Offset_GroupMask3..Offset_GroupMask4]);

                /// <summary>
                /// Retrieves the GroupMask4 field.
                /// </summary>
                public uint GroupMask4 => BitConverter.ToUInt32(_etwEvent.Data[Offset_GroupMask4..Offset_GroupMask5]);

                /// <summary>
                /// Retrieves the GroupMask5 field.
                /// </summary>
                public uint GroupMask5 => BitConverter.ToUInt32(_etwEvent.Data[Offset_GroupMask5..Offset_GroupMask6]);

                /// <summary>
                /// Retrieves the GroupMask6 field.
                /// </summary>
                public uint GroupMask6 => BitConverter.ToUInt32(_etwEvent.Data[Offset_GroupMask6..Offset_GroupMask7]);

                /// <summary>
                /// Retrieves the GroupMask7 field.
                /// </summary>
                public uint GroupMask7 => BitConverter.ToUInt32(_etwEvent.Data[Offset_GroupMask7..Offset_GroupMask8]);

                /// <summary>
                /// Retrieves the GroupMask8 field.
                /// </summary>
                public uint GroupMask8 => BitConverter.ToUInt32(_etwEvent.Data[Offset_GroupMask8..]);

                /// <summary>
                /// Creates a new EndExtensionData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public EndExtensionData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_GroupMask1 = -1;
                    _offset_GroupMask2 = -1;
                    _offset_GroupMask3 = -1;
                    _offset_GroupMask4 = -1;
                    _offset_GroupMask5 = -1;
                    _offset_GroupMask6 = -1;
                    _offset_GroupMask7 = -1;
                    _offset_GroupMask8 = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Header event.
        /// </summary>
        public readonly ref struct HeaderEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Header";

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
                Opcode = EtwEventOpcode.Info,
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
            public HeaderData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new HeaderEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public HeaderEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a HeaderEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator HeaderEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Header event.
            /// </summary>
            public ref struct HeaderData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_BufferSize;
                private int _offset_Version;
                private int _offset_ProviderVersion;
                private int _offset_NumberOfProcessors;
                private int _offset_EndTime;
                private int _offset_TimerResolution;
                private int _offset_MaxFileSize;
                private int _offset_LogFileMode;
                private int _offset_BuffersWritten;
                private int _offset_StartBuffers;
                private int _offset_PointerSize;
                private int _offset_EventsLost;
                private int _offset_CPUSpeed;
                private int _offset_LoggerName;
                private int _offset_LogFileName;
                private int _offset_TimeZoneInformation;
                private int _offset_BootTime;
                private int _offset_PerfFreq;
                private int _offset_StartTime;
                private int _offset_ReservedFlags;
                private int _offset_BuffersLost;
                private int _offset_SessionNameString;
                private int _offset_LogFileNameString;

                private int Offset_BufferSize
                {
                    get
                    {
                        if (_offset_BufferSize == -1)
                        {
                            _offset_BufferSize = 0;
                        }

                        return _offset_BufferSize;
                    }
                }

                private int Offset_Version
                {
                    get
                    {
                        if (_offset_Version == -1)
                        {
                            _offset_Version = Offset_BufferSize + 4;
                        }

                        return _offset_Version;
                    }
                }

                private int Offset_ProviderVersion
                {
                    get
                    {
                        if (_offset_ProviderVersion == -1)
                        {
                            _offset_ProviderVersion = Offset_Version + 4;
                        }

                        return _offset_ProviderVersion;
                    }
                }

                private int Offset_NumberOfProcessors
                {
                    get
                    {
                        if (_offset_NumberOfProcessors == -1)
                        {
                            _offset_NumberOfProcessors = Offset_ProviderVersion + 4;
                        }

                        return _offset_NumberOfProcessors;
                    }
                }

                private int Offset_EndTime
                {
                    get
                    {
                        if (_offset_EndTime == -1)
                        {
                            _offset_EndTime = Offset_NumberOfProcessors + 4;
                        }

                        return _offset_EndTime;
                    }
                }

                private int Offset_TimerResolution
                {
                    get
                    {
                        if (_offset_TimerResolution == -1)
                        {
                            _offset_TimerResolution = Offset_EndTime + 8;
                        }

                        return _offset_TimerResolution;
                    }
                }

                private int Offset_MaxFileSize
                {
                    get
                    {
                        if (_offset_MaxFileSize == -1)
                        {
                            _offset_MaxFileSize = Offset_TimerResolution + 4;
                        }

                        return _offset_MaxFileSize;
                    }
                }

                private int Offset_LogFileMode
                {
                    get
                    {
                        if (_offset_LogFileMode == -1)
                        {
                            _offset_LogFileMode = Offset_MaxFileSize + 4;
                        }

                        return _offset_LogFileMode;
                    }
                }

                private int Offset_BuffersWritten
                {
                    get
                    {
                        if (_offset_BuffersWritten == -1)
                        {
                            _offset_BuffersWritten = Offset_LogFileMode + 4;
                        }

                        return _offset_BuffersWritten;
                    }
                }

                private int Offset_StartBuffers
                {
                    get
                    {
                        if (_offset_StartBuffers == -1)
                        {
                            _offset_StartBuffers = Offset_BuffersWritten + 4;
                        }

                        return _offset_StartBuffers;
                    }
                }

                private int Offset_PointerSize
                {
                    get
                    {
                        if (_offset_PointerSize == -1)
                        {
                            _offset_PointerSize = Offset_StartBuffers + 4;
                        }

                        return _offset_PointerSize;
                    }
                }

                private int Offset_EventsLost
                {
                    get
                    {
                        if (_offset_EventsLost == -1)
                        {
                            _offset_EventsLost = Offset_PointerSize + 4;
                        }

                        return _offset_EventsLost;
                    }
                }

                private int Offset_CPUSpeed
                {
                    get
                    {
                        if (_offset_CPUSpeed == -1)
                        {
                            _offset_CPUSpeed = Offset_EventsLost + 4;
                        }

                        return _offset_CPUSpeed;
                    }
                }

                private int Offset_LoggerName
                {
                    get
                    {
                        if (_offset_LoggerName == -1)
                        {
                            _offset_LoggerName = Offset_CPUSpeed + 4;
                        }

                        return _offset_LoggerName;
                    }
                }

                private int Offset_LogFileName
                {
                    get
                    {
                        if (_offset_LogFileName == -1)
                        {
                            _offset_LogFileName = Offset_LoggerName + _etwEvent.AddressSize;
                        }

                        return _offset_LogFileName;
                    }
                }

                private int Offset_TimeZoneInformation
                {
                    get
                    {
                        if (_offset_TimeZoneInformation == -1)
                        {
                            _offset_TimeZoneInformation = Offset_LogFileName + _etwEvent.AddressSize;
                        }

                        return _offset_TimeZoneInformation;
                    }
                }

                private int Offset_BootTime
                {
                    get
                    {
                        if (_offset_BootTime == -1)
                        {
                            _offset_BootTime = Offset_TimeZoneInformation + 1;
                        }

                        return _offset_BootTime;
                    }
                }

                private int Offset_PerfFreq
                {
                    get
                    {
                        if (_offset_PerfFreq == -1)
                        {
                            _offset_PerfFreq = Offset_BootTime + 8;
                        }

                        return _offset_PerfFreq;
                    }
                }

                private int Offset_StartTime
                {
                    get
                    {
                        if (_offset_StartTime == -1)
                        {
                            _offset_StartTime = Offset_PerfFreq + 8;
                        }

                        return _offset_StartTime;
                    }
                }

                private int Offset_ReservedFlags
                {
                    get
                    {
                        if (_offset_ReservedFlags == -1)
                        {
                            _offset_ReservedFlags = Offset_StartTime + 8;
                        }

                        return _offset_ReservedFlags;
                    }
                }

                private int Offset_BuffersLost
                {
                    get
                    {
                        if (_offset_BuffersLost == -1)
                        {
                            _offset_BuffersLost = Offset_ReservedFlags + 4;
                        }

                        return _offset_BuffersLost;
                    }
                }

                private int Offset_SessionNameString
                {
                    get
                    {
                        if (_offset_SessionNameString == -1)
                        {
                            _offset_SessionNameString = Offset_BuffersLost + 4;
                        }

                        return _offset_SessionNameString;
                    }
                }

                private int Offset_LogFileNameString
                {
                    get
                    {
                        if (_offset_LogFileNameString == -1)
                        {
                            _offset_LogFileNameString = Offset_SessionNameString + _etwEvent.UnicodeStringLength(Offset_SessionNameString);
                        }

                        return _offset_LogFileNameString;
                    }
                }

                /// <summary>
                /// Retrieves the BufferSize field.
                /// </summary>
                public uint BufferSize => BitConverter.ToUInt32(_etwEvent.Data[Offset_BufferSize..Offset_Version]);

                /// <summary>
                /// Retrieves the Version field.
                /// </summary>
                public uint Version => BitConverter.ToUInt32(_etwEvent.Data[Offset_Version..Offset_ProviderVersion]);

                /// <summary>
                /// Retrieves the ProviderVersion field.
                /// </summary>
                public uint ProviderVersion => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProviderVersion..Offset_NumberOfProcessors]);

                /// <summary>
                /// Retrieves the NumberOfProcessors field.
                /// </summary>
                public uint NumberOfProcessors => BitConverter.ToUInt32(_etwEvent.Data[Offset_NumberOfProcessors..Offset_EndTime]);

                /// <summary>
                /// Retrieves the EndTime field.
                /// </summary>
                public ulong EndTime => BitConverter.ToUInt64(_etwEvent.Data[Offset_EndTime..Offset_TimerResolution]);

                /// <summary>
                /// Retrieves the TimerResolution field.
                /// </summary>
                public uint TimerResolution => BitConverter.ToUInt32(_etwEvent.Data[Offset_TimerResolution..Offset_MaxFileSize]);

                /// <summary>
                /// Retrieves the MaxFileSize field.
                /// </summary>
                public uint MaxFileSize => BitConverter.ToUInt32(_etwEvent.Data[Offset_MaxFileSize..Offset_LogFileMode]);

                /// <summary>
                /// Retrieves the LogFileMode field.
                /// </summary>
                public uint LogFileMode => BitConverter.ToUInt32(_etwEvent.Data[Offset_LogFileMode..Offset_BuffersWritten]);

                /// <summary>
                /// Retrieves the BuffersWritten field.
                /// </summary>
                public uint BuffersWritten => BitConverter.ToUInt32(_etwEvent.Data[Offset_BuffersWritten..Offset_StartBuffers]);

                /// <summary>
                /// Retrieves the StartBuffers field.
                /// </summary>
                public uint StartBuffers => BitConverter.ToUInt32(_etwEvent.Data[Offset_StartBuffers..Offset_PointerSize]);

                /// <summary>
                /// Retrieves the PointerSize field.
                /// </summary>
                public uint PointerSize => BitConverter.ToUInt32(_etwEvent.Data[Offset_PointerSize..Offset_EventsLost]);

                /// <summary>
                /// Retrieves the EventsLost field.
                /// </summary>
                public uint EventsLost => BitConverter.ToUInt32(_etwEvent.Data[Offset_EventsLost..Offset_CPUSpeed]);

                /// <summary>
                /// Retrieves the CPUSpeed field.
                /// </summary>
                public uint CPUSpeed => BitConverter.ToUInt32(_etwEvent.Data[Offset_CPUSpeed..Offset_LoggerName]);

                /// <summary>
                /// Retrieves the LoggerName field.
                /// </summary>
                public ulong LoggerName => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_LoggerName..Offset_LogFileName]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_LoggerName..Offset_LogFileName]);

                /// <summary>
                /// Retrieves the LogFileName field.
                /// </summary>
                public ulong LogFileName => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_LogFileName..Offset_TimeZoneInformation]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_LogFileName..Offset_TimeZoneInformation]);

                /// <summary>
                /// Retrieves the TimeZoneInformation field.
                /// </summary>
                public byte TimeZoneInformation => _etwEvent.Data[Offset_TimeZoneInformation];

                /// <summary>
                /// Retrieves the BootTime field.
                /// </summary>
                public ulong BootTime => BitConverter.ToUInt64(_etwEvent.Data[Offset_BootTime..Offset_PerfFreq]);

                /// <summary>
                /// Retrieves the PerfFreq field.
                /// </summary>
                public ulong PerfFreq => BitConverter.ToUInt64(_etwEvent.Data[Offset_PerfFreq..Offset_StartTime]);

                /// <summary>
                /// Retrieves the StartTime field.
                /// </summary>
                public ulong StartTime => BitConverter.ToUInt64(_etwEvent.Data[Offset_StartTime..Offset_ReservedFlags]);

                /// <summary>
                /// Retrieves the ReservedFlags field.
                /// </summary>
                public uint ReservedFlags => BitConverter.ToUInt32(_etwEvent.Data[Offset_ReservedFlags..Offset_BuffersLost]);

                /// <summary>
                /// Retrieves the BuffersLost field.
                /// </summary>
                public uint BuffersLost => BitConverter.ToUInt32(_etwEvent.Data[Offset_BuffersLost..Offset_SessionNameString]);

                /// <summary>
                /// Retrieves the SessionNameString field.
                /// </summary>
                public string SessionNameString => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_SessionNameString..Offset_LogFileNameString]);

                /// <summary>
                /// Retrieves the LogFileNameString field.
                /// </summary>
                public string LogFileNameString => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_LogFileNameString..]);

                /// <summary>
                /// Creates a new HeaderData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public HeaderData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_BufferSize = -1;
                    _offset_Version = -1;
                    _offset_ProviderVersion = -1;
                    _offset_NumberOfProcessors = -1;
                    _offset_EndTime = -1;
                    _offset_TimerResolution = -1;
                    _offset_MaxFileSize = -1;
                    _offset_LogFileMode = -1;
                    _offset_BuffersWritten = -1;
                    _offset_StartBuffers = -1;
                    _offset_PointerSize = -1;
                    _offset_EventsLost = -1;
                    _offset_CPUSpeed = -1;
                    _offset_LoggerName = -1;
                    _offset_LogFileName = -1;
                    _offset_TimeZoneInformation = -1;
                    _offset_BootTime = -1;
                    _offset_PerfFreq = -1;
                    _offset_StartTime = -1;
                    _offset_ReservedFlags = -1;
                    _offset_BuffersLost = -1;
                    _offset_SessionNameString = -1;
                    _offset_LogFileNameString = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Extension event.
        /// </summary>
        public readonly ref struct ExtensionEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Extension";

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
                Opcode = EtwEventOpcode.Extension,
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
            public ExtensionData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ExtensionEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ExtensionEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a ExtensionEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator ExtensionEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Extension event.
            /// </summary>
            public ref struct ExtensionData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_GroupMask1;
                private int _offset_GroupMask2;
                private int _offset_GroupMask3;
                private int _offset_GroupMask4;
                private int _offset_GroupMask5;
                private int _offset_GroupMask6;
                private int _offset_GroupMask7;
                private int _offset_GroupMask8;
                private int _offset_KernelEventVersion;

                private int Offset_GroupMask1
                {
                    get
                    {
                        if (_offset_GroupMask1 == -1)
                        {
                            _offset_GroupMask1 = 0;
                        }

                        return _offset_GroupMask1;
                    }
                }

                private int Offset_GroupMask2
                {
                    get
                    {
                        if (_offset_GroupMask2 == -1)
                        {
                            _offset_GroupMask2 = Offset_GroupMask1 + 4;
                        }

                        return _offset_GroupMask2;
                    }
                }

                private int Offset_GroupMask3
                {
                    get
                    {
                        if (_offset_GroupMask3 == -1)
                        {
                            _offset_GroupMask3 = Offset_GroupMask2 + 4;
                        }

                        return _offset_GroupMask3;
                    }
                }

                private int Offset_GroupMask4
                {
                    get
                    {
                        if (_offset_GroupMask4 == -1)
                        {
                            _offset_GroupMask4 = Offset_GroupMask3 + 4;
                        }

                        return _offset_GroupMask4;
                    }
                }

                private int Offset_GroupMask5
                {
                    get
                    {
                        if (_offset_GroupMask5 == -1)
                        {
                            _offset_GroupMask5 = Offset_GroupMask4 + 4;
                        }

                        return _offset_GroupMask5;
                    }
                }

                private int Offset_GroupMask6
                {
                    get
                    {
                        if (_offset_GroupMask6 == -1)
                        {
                            _offset_GroupMask6 = Offset_GroupMask5 + 4;
                        }

                        return _offset_GroupMask6;
                    }
                }

                private int Offset_GroupMask7
                {
                    get
                    {
                        if (_offset_GroupMask7 == -1)
                        {
                            _offset_GroupMask7 = Offset_GroupMask6 + 4;
                        }

                        return _offset_GroupMask7;
                    }
                }

                private int Offset_GroupMask8
                {
                    get
                    {
                        if (_offset_GroupMask8 == -1)
                        {
                            _offset_GroupMask8 = Offset_GroupMask7 + 4;
                        }

                        return _offset_GroupMask8;
                    }
                }

                private int Offset_KernelEventVersion
                {
                    get
                    {
                        if (_offset_KernelEventVersion == -1)
                        {
                            _offset_KernelEventVersion = Offset_GroupMask8 + 4;
                        }

                        return _offset_KernelEventVersion;
                    }
                }

                /// <summary>
                /// Retrieves the GroupMask1 field.
                /// </summary>
                public uint GroupMask1 => BitConverter.ToUInt32(_etwEvent.Data[Offset_GroupMask1..Offset_GroupMask2]);

                /// <summary>
                /// Retrieves the GroupMask2 field.
                /// </summary>
                public uint GroupMask2 => BitConverter.ToUInt32(_etwEvent.Data[Offset_GroupMask2..Offset_GroupMask3]);

                /// <summary>
                /// Retrieves the GroupMask3 field.
                /// </summary>
                public uint GroupMask3 => BitConverter.ToUInt32(_etwEvent.Data[Offset_GroupMask3..Offset_GroupMask4]);

                /// <summary>
                /// Retrieves the GroupMask4 field.
                /// </summary>
                public uint GroupMask4 => BitConverter.ToUInt32(_etwEvent.Data[Offset_GroupMask4..Offset_GroupMask5]);

                /// <summary>
                /// Retrieves the GroupMask5 field.
                /// </summary>
                public uint GroupMask5 => BitConverter.ToUInt32(_etwEvent.Data[Offset_GroupMask5..Offset_GroupMask6]);

                /// <summary>
                /// Retrieves the GroupMask6 field.
                /// </summary>
                public uint GroupMask6 => BitConverter.ToUInt32(_etwEvent.Data[Offset_GroupMask6..Offset_GroupMask7]);

                /// <summary>
                /// Retrieves the GroupMask7 field.
                /// </summary>
                public uint GroupMask7 => BitConverter.ToUInt32(_etwEvent.Data[Offset_GroupMask7..Offset_GroupMask8]);

                /// <summary>
                /// Retrieves the GroupMask8 field.
                /// </summary>
                public uint GroupMask8 => BitConverter.ToUInt32(_etwEvent.Data[Offset_GroupMask8..Offset_KernelEventVersion]);

                /// <summary>
                /// Retrieves the KernelEventVersion field.
                /// </summary>
                public uint KernelEventVersion => BitConverter.ToUInt32(_etwEvent.Data[Offset_KernelEventVersion..]);

                /// <summary>
                /// Creates a new ExtensionData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ExtensionData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_GroupMask1 = -1;
                    _offset_GroupMask2 = -1;
                    _offset_GroupMask3 = -1;
                    _offset_GroupMask4 = -1;
                    _offset_GroupMask5 = -1;
                    _offset_GroupMask6 = -1;
                    _offset_GroupMask7 = -1;
                    _offset_GroupMask8 = -1;
                    _offset_KernelEventVersion = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a EndExtension event.
        /// </summary>
        public readonly ref struct EndExtensionEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "EndExtension";

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
                Opcode = (EtwEventOpcode)Opcodes.EndExtension,
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
            public EndExtensionData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new EndExtensionEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public EndExtensionEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a EndExtensionEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator EndExtensionEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a EndExtension event.
            /// </summary>
            public ref struct EndExtensionData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_GroupMask1;
                private int _offset_GroupMask2;
                private int _offset_GroupMask3;
                private int _offset_GroupMask4;
                private int _offset_GroupMask5;
                private int _offset_GroupMask6;
                private int _offset_GroupMask7;
                private int _offset_GroupMask8;
                private int _offset_KernelEventVersion;

                private int Offset_GroupMask1
                {
                    get
                    {
                        if (_offset_GroupMask1 == -1)
                        {
                            _offset_GroupMask1 = 0;
                        }

                        return _offset_GroupMask1;
                    }
                }

                private int Offset_GroupMask2
                {
                    get
                    {
                        if (_offset_GroupMask2 == -1)
                        {
                            _offset_GroupMask2 = Offset_GroupMask1 + 4;
                        }

                        return _offset_GroupMask2;
                    }
                }

                private int Offset_GroupMask3
                {
                    get
                    {
                        if (_offset_GroupMask3 == -1)
                        {
                            _offset_GroupMask3 = Offset_GroupMask2 + 4;
                        }

                        return _offset_GroupMask3;
                    }
                }

                private int Offset_GroupMask4
                {
                    get
                    {
                        if (_offset_GroupMask4 == -1)
                        {
                            _offset_GroupMask4 = Offset_GroupMask3 + 4;
                        }

                        return _offset_GroupMask4;
                    }
                }

                private int Offset_GroupMask5
                {
                    get
                    {
                        if (_offset_GroupMask5 == -1)
                        {
                            _offset_GroupMask5 = Offset_GroupMask4 + 4;
                        }

                        return _offset_GroupMask5;
                    }
                }

                private int Offset_GroupMask6
                {
                    get
                    {
                        if (_offset_GroupMask6 == -1)
                        {
                            _offset_GroupMask6 = Offset_GroupMask5 + 4;
                        }

                        return _offset_GroupMask6;
                    }
                }

                private int Offset_GroupMask7
                {
                    get
                    {
                        if (_offset_GroupMask7 == -1)
                        {
                            _offset_GroupMask7 = Offset_GroupMask6 + 4;
                        }

                        return _offset_GroupMask7;
                    }
                }

                private int Offset_GroupMask8
                {
                    get
                    {
                        if (_offset_GroupMask8 == -1)
                        {
                            _offset_GroupMask8 = Offset_GroupMask7 + 4;
                        }

                        return _offset_GroupMask8;
                    }
                }

                private int Offset_KernelEventVersion
                {
                    get
                    {
                        if (_offset_KernelEventVersion == -1)
                        {
                            _offset_KernelEventVersion = Offset_GroupMask8 + 4;
                        }

                        return _offset_KernelEventVersion;
                    }
                }

                /// <summary>
                /// Retrieves the GroupMask1 field.
                /// </summary>
                public uint GroupMask1 => BitConverter.ToUInt32(_etwEvent.Data[Offset_GroupMask1..Offset_GroupMask2]);

                /// <summary>
                /// Retrieves the GroupMask2 field.
                /// </summary>
                public uint GroupMask2 => BitConverter.ToUInt32(_etwEvent.Data[Offset_GroupMask2..Offset_GroupMask3]);

                /// <summary>
                /// Retrieves the GroupMask3 field.
                /// </summary>
                public uint GroupMask3 => BitConverter.ToUInt32(_etwEvent.Data[Offset_GroupMask3..Offset_GroupMask4]);

                /// <summary>
                /// Retrieves the GroupMask4 field.
                /// </summary>
                public uint GroupMask4 => BitConverter.ToUInt32(_etwEvent.Data[Offset_GroupMask4..Offset_GroupMask5]);

                /// <summary>
                /// Retrieves the GroupMask5 field.
                /// </summary>
                public uint GroupMask5 => BitConverter.ToUInt32(_etwEvent.Data[Offset_GroupMask5..Offset_GroupMask6]);

                /// <summary>
                /// Retrieves the GroupMask6 field.
                /// </summary>
                public uint GroupMask6 => BitConverter.ToUInt32(_etwEvent.Data[Offset_GroupMask6..Offset_GroupMask7]);

                /// <summary>
                /// Retrieves the GroupMask7 field.
                /// </summary>
                public uint GroupMask7 => BitConverter.ToUInt32(_etwEvent.Data[Offset_GroupMask7..Offset_GroupMask8]);

                /// <summary>
                /// Retrieves the GroupMask8 field.
                /// </summary>
                public uint GroupMask8 => BitConverter.ToUInt32(_etwEvent.Data[Offset_GroupMask8..Offset_KernelEventVersion]);

                /// <summary>
                /// Retrieves the KernelEventVersion field.
                /// </summary>
                public uint KernelEventVersion => BitConverter.ToUInt32(_etwEvent.Data[Offset_KernelEventVersion..]);

                /// <summary>
                /// Creates a new EndExtensionData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public EndExtensionData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_GroupMask1 = -1;
                    _offset_GroupMask2 = -1;
                    _offset_GroupMask3 = -1;
                    _offset_GroupMask4 = -1;
                    _offset_GroupMask5 = -1;
                    _offset_GroupMask6 = -1;
                    _offset_GroupMask7 = -1;
                    _offset_GroupMask8 = -1;
                    _offset_KernelEventVersion = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a RDComplete event.
        /// </summary>
        public readonly ref struct RDCompleteEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "RDComplete";

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
                Opcode = EtwEventOpcode.Checkpoint,
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
            /// Creates a new RDCompleteEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public RDCompleteEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a RDCompleteEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator RDCompleteEventV2(EtwEvent etwEvent) => new(etwEvent);
        }

        /// <summary>
        /// An event wrapper for a DbgIdRSDS event.
        /// </summary>
        public readonly ref struct DbgIdRSDSEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DbgIdRSDS";

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
                Opcode = (EtwEventOpcode)Opcodes.DbgIdRSDS,
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
            public DbgIdRSDSData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DbgIdRSDSEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DbgIdRSDSEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a DbgIdRSDSEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator DbgIdRSDSEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a DbgIdRSDS event.
            /// </summary>
            public ref struct DbgIdRSDSData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Guid;
                private int _offset_Age;
                private int _offset_PdbName;

                private int Offset_Guid
                {
                    get
                    {
                        if (_offset_Guid == -1)
                        {
                            _offset_Guid = 0;
                        }

                        return _offset_Guid;
                    }
                }

                private int Offset_Age
                {
                    get
                    {
                        if (_offset_Age == -1)
                        {
                            _offset_Age = Offset_Guid + 16;
                        }

                        return _offset_Age;
                    }
                }

                private int Offset_PdbName
                {
                    get
                    {
                        if (_offset_PdbName == -1)
                        {
                            _offset_PdbName = Offset_Age + 4;
                        }

                        return _offset_PdbName;
                    }
                }

                /// <summary>
                /// Retrieves the Guid field.
                /// </summary>
                public Guid Guid => new(_etwEvent.Data[Offset_Guid..Offset_Age]);

                /// <summary>
                /// Retrieves the Age field.
                /// </summary>
                public uint Age => BitConverter.ToUInt32(_etwEvent.Data[Offset_Age..Offset_PdbName]);

                /// <summary>
                /// Retrieves the PdbName field.
                /// </summary>
                public string PdbName => System.Text.Encoding.ASCII.GetString(_etwEvent.Data[Offset_PdbName..]);

                /// <summary>
                /// Creates a new DbgIdRSDSData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DbgIdRSDSData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Guid = -1;
                    _offset_Age = -1;
                    _offset_PdbName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a BuildInfo event.
        /// </summary>
        public readonly ref struct BuildInfoEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "BuildInfo";

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
                Opcode = (EtwEventOpcode)Opcodes.BuildInfo,
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
            public BuildInfoData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new BuildInfoEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public BuildInfoEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a BuildInfoEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator BuildInfoEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a BuildInfo event.
            /// </summary>
            public ref struct BuildInfoData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_BuildString;

                private int Offset_BuildString
                {
                    get
                    {
                        if (_offset_BuildString == -1)
                        {
                            _offset_BuildString = 0;
                        }

                        return _offset_BuildString;
                    }
                }

                /// <summary>
                /// Retrieves the BuildString field.
                /// </summary>
                public string BuildString => System.Text.Encoding.ASCII.GetString(_etwEvent.Data[Offset_BuildString..]);

                /// <summary>
                /// Creates a new BuildInfoData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public BuildInfoData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_BuildString = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ProviderBinaryPath event.
        /// </summary>
        public readonly ref struct ProviderBinaryPathEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ProviderBinaryPath";

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
                Opcode = (EtwEventOpcode)Opcodes.ProviderBinaryPath,
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
            public ProviderBinaryPathData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ProviderBinaryPathEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ProviderBinaryPathEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a ProviderBinaryPathEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator ProviderBinaryPathEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a ProviderBinaryPath event.
            /// </summary>
            public ref struct ProviderBinaryPathData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_GuidCount;
                private int _offset_Guid;
                private int _offset_BinaryPath;

                private int Offset_GuidCount
                {
                    get
                    {
                        if (_offset_GuidCount == -1)
                        {
                            _offset_GuidCount = 0;
                        }

                        return _offset_GuidCount;
                    }
                }

                private int Offset_Guid
                {
                    get
                    {
                        if (_offset_Guid == -1)
                        {
                            _offset_Guid = Offset_GuidCount + 4;
                        }

                        return _offset_Guid;
                    }
                }

                private int Offset_BinaryPath
                {
                    get
                    {
                        if (_offset_BinaryPath == -1)
                        {
                            _offset_BinaryPath = Offset_Guid + (16 * (int)GuidCount);
                        }

                        return _offset_BinaryPath;
                    }
                }

                /// <summary>
                /// Retrieves the GuidCount field.
                /// </summary>
                public uint GuidCount => BitConverter.ToUInt32(_etwEvent.Data[Offset_GuidCount..Offset_Guid]);

                /// <summary>
                /// Retrieves the Guid field.
                /// </summary>
                public EtwEvent.StructEnumerable<Guid> Guid => new(_etwEvent, Offset_Guid, GuidCount);

                /// <summary>
                /// Retrieves the BinaryPath field.
                /// </summary>
                public string BinaryPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_BinaryPath..]);

                /// <summary>
                /// Creates a new ProviderBinaryPathData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ProviderBinaryPathData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_GuidCount = -1;
                    _offset_Guid = -1;
                    _offset_BinaryPath = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a PartitionInfoExtension event.
        /// </summary>
        public readonly ref struct PartitionInfoExtensionEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "PartitionInfoExtension";

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
                Opcode = (EtwEventOpcode)Opcodes.PartitionInfoExtension,
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
            public PartitionInfoExtensionData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new PartitionInfoExtensionEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public PartitionInfoExtensionEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a PartitionInfoExtensionEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator PartitionInfoExtensionEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a PartitionInfoExtension event.
            /// </summary>
            public ref struct PartitionInfoExtensionData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_EventVersion;
                private int _offset_Reserved;
                private int _offset_PartitionType;
                private int _offset_QpcOffsetFromRoot;
                private int _offset_PartitionId;
                private int _offset_ParentId;

                private int Offset_EventVersion
                {
                    get
                    {
                        if (_offset_EventVersion == -1)
                        {
                            _offset_EventVersion = 0;
                        }

                        return _offset_EventVersion;
                    }
                }

                private int Offset_Reserved
                {
                    get
                    {
                        if (_offset_Reserved == -1)
                        {
                            _offset_Reserved = Offset_EventVersion + 2;
                        }

                        return _offset_Reserved;
                    }
                }

                private int Offset_PartitionType
                {
                    get
                    {
                        if (_offset_PartitionType == -1)
                        {
                            _offset_PartitionType = Offset_Reserved + 2;
                        }

                        return _offset_PartitionType;
                    }
                }

                private int Offset_QpcOffsetFromRoot
                {
                    get
                    {
                        if (_offset_QpcOffsetFromRoot == -1)
                        {
                            _offset_QpcOffsetFromRoot = Offset_PartitionType + 4;
                        }

                        return _offset_QpcOffsetFromRoot;
                    }
                }

                private int Offset_PartitionId
                {
                    get
                    {
                        if (_offset_PartitionId == -1)
                        {
                            _offset_PartitionId = Offset_QpcOffsetFromRoot + 8;
                        }

                        return _offset_PartitionId;
                    }
                }

                private int Offset_ParentId
                {
                    get
                    {
                        if (_offset_ParentId == -1)
                        {
                            _offset_ParentId = Offset_PartitionId + 16;
                        }

                        return _offset_ParentId;
                    }
                }

                /// <summary>
                /// Retrieves the EventVersion field.
                /// </summary>
                public ushort EventVersion => BitConverter.ToUInt16(_etwEvent.Data[Offset_EventVersion..Offset_Reserved]);

                /// <summary>
                /// Retrieves the Reserved field.
                /// </summary>
                public ushort Reserved => BitConverter.ToUInt16(_etwEvent.Data[Offset_Reserved..Offset_PartitionType]);

                /// <summary>
                /// Retrieves the PartitionType field.
                /// </summary>
                public uint PartitionType => BitConverter.ToUInt32(_etwEvent.Data[Offset_PartitionType..Offset_QpcOffsetFromRoot]);

                /// <summary>
                /// Retrieves the QpcOffsetFromRoot field.
                /// </summary>
                public long QpcOffsetFromRoot => BitConverter.ToInt64(_etwEvent.Data[Offset_QpcOffsetFromRoot..Offset_PartitionId]);

                /// <summary>
                /// Retrieves the PartitionId field.
                /// </summary>
                public Guid PartitionId => new(_etwEvent.Data[Offset_PartitionId..Offset_ParentId]);

                /// <summary>
                /// Retrieves the ParentId field.
                /// </summary>
                public Guid ParentId => new(_etwEvent.Data[Offset_ParentId..]);

                /// <summary>
                /// Creates a new PartitionInfoExtensionData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public PartitionInfoExtensionData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_EventVersion = -1;
                    _offset_Reserved = -1;
                    _offset_PartitionType = -1;
                    _offset_QpcOffsetFromRoot = -1;
                    _offset_PartitionId = -1;
                    _offset_ParentId = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a LastDroppedTimes event.
        /// </summary>
        public readonly ref struct LastDroppedTimesEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "LastDroppedTimes";

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
                Opcode = (EtwEventOpcode)Opcodes.LastDroppedTimes,
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
            public LastDroppedTimesData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new LastDroppedTimesEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public LastDroppedTimesEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a LastDroppedTimesEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator LastDroppedTimesEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a LastDroppedTimes event.
            /// </summary>
            public ref struct LastDroppedTimesData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_TimeStampCount;
                private int _offset_Padding;
                private int _offset_TimeStamp;

                private int Offset_TimeStampCount
                {
                    get
                    {
                        if (_offset_TimeStampCount == -1)
                        {
                            _offset_TimeStampCount = 0;
                        }

                        return _offset_TimeStampCount;
                    }
                }

                private int Offset_Padding
                {
                    get
                    {
                        if (_offset_Padding == -1)
                        {
                            _offset_Padding = Offset_TimeStampCount + 4;
                        }

                        return _offset_Padding;
                    }
                }

                private int Offset_TimeStamp
                {
                    get
                    {
                        if (_offset_TimeStamp == -1)
                        {
                            _offset_TimeStamp = Offset_Padding + 4;
                        }

                        return _offset_TimeStamp;
                    }
                }

                /// <summary>
                /// Retrieves the TimeStampCount field.
                /// </summary>
                public uint TimeStampCount => BitConverter.ToUInt32(_etwEvent.Data[Offset_TimeStampCount..Offset_Padding]);

                /// <summary>
                /// Retrieves the Padding field.
                /// </summary>
                public uint Padding => BitConverter.ToUInt32(_etwEvent.Data[Offset_Padding..Offset_TimeStamp]);

                /// <summary>
                /// Retrieves the TimeStamp field.
                /// </summary>
                public EtwEvent.StructEnumerable<ulong> TimeStamp => new(_etwEvent, Offset_TimeStamp, TimeStampCount);

                /// <summary>
                /// Creates a new LastDroppedTimesData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public LastDroppedTimesData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_TimeStampCount = -1;
                    _offset_Padding = -1;
                    _offset_TimeStamp = -1;
                }
            }

        }
    }
}
