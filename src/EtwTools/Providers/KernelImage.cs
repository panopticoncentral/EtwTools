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
    /// Provider for Kernel-Image (2cb15d1d-5fc1-11d2-abe1-00a0c911f518)
    /// </summary>
    public sealed class KernelImageProvider
    {
        /// <summary>s
        /// Provider ID.
        /// </summary>
        public static readonly Guid Id = new("2cb15d1d-5fc1-11d2-abe1-00a0c911f518");

        /// <summary>
        /// Provider name.
        /// </summary>
        public const string Name = "Kernel-Image";

        /// <summary>
        /// Opcodes supported by KernelImage.
        /// </summary>
        public enum Opcodes
        {
            /// <summary>
            /// 'Load' opcode.
            /// </summary>
            Load = 10,
            /// <summary>
            /// 'KernelBase' opcode.
            /// </summary>
            KernelBase = 33,
            /// <summary>
            /// 'HypercallPage' opcode.
            /// </summary>
            HypercallPage = 34,
            /// <summary>
            /// 'LoaderLockAttempt' opcode.
            /// </summary>
            LoaderLockAttempt = 128,
            /// <summary>
            /// 'LoaderLockAcquire' opcode.
            /// </summary>
            LoaderLockAcquire = 129,
            /// <summary>
            /// 'LoaderLockTriedAndFailed' opcode.
            /// </summary>
            LoaderLockTriedAndFailed = 130,
            /// <summary>
            /// 'LoaderLockWait' opcode.
            /// </summary>
            LoaderLockWait = 131,
            /// <summary>
            /// 'ProcessInitDone' opcode.
            /// </summary>
            ProcessInitDone = 132,
            /// <summary>
            /// 'CreateSectionBegin' opcode.
            /// </summary>
            CreateSectionBegin = 133,
            /// <summary>
            /// 'CreateSectionEnd' opcode.
            /// </summary>
            CreateSectionEnd = 134,
            /// <summary>
            /// 'MapViewBegin' opcode.
            /// </summary>
            MapViewBegin = 135,
            /// <summary>
            /// 'RelocateImageBegin' opcode.
            /// </summary>
            RelocateImageBegin = 144,
            /// <summary>
            /// 'RelocateImageEnd' opcode.
            /// </summary>
            RelocateImageEnd = 145,
            /// <summary>
            /// 'HandleOldDescsBegin' opcode.
            /// </summary>
            HandleOldDescsBegin = 146,
            /// <summary>
            /// 'HandleOldDescsEnd' opcode.
            /// </summary>
            HandleOldDescsEnd = 147,
            /// <summary>
            /// 'HandleNewDescsBegin' opcode.
            /// </summary>
            HandleNewDescsBegin = 148,
            /// <summary>
            /// 'HandleNewDescsEnd' opcode.
            /// </summary>
            HandleNewDescsEnd = 149,
            /// <summary>
            /// 'DllMainExit' opcode.
            /// </summary>
            DllMainExit = 150,
            /// <summary>
            /// 'FindDllByName' opcode.
            /// </summary>
            FindDllByName = 160,
            /// <summary>
            /// 'MapViewEnd' opcode.
            /// </summary>
            MapViewEnd = 161,
            /// <summary>
            /// 'LoaderLockRelease' opcode.
            /// </summary>
            LoaderLockRelease = 162,
            /// <summary>
            /// 'DllMainEnter' opcode.
            /// </summary>
            DllMainEnter = 163,
            /// <summary>
            /// 'LoaderError' opcode.
            /// </summary>
            LoaderError = 164,
            /// <summary>
            /// 'MapViewStart' opcode.
            /// </summary>
            MapViewStart = 165,
            /// <summary>
            /// 'SnappingStart' opcode.
            /// </summary>
            SnappingStart = 166,
            /// <summary>
            /// 'SnappingEnd' opcode.
            /// </summary>
            SnappingEnd = 167,
            /// <summary>
            /// 'LoadingStart' opcode.
            /// </summary>
            LoadingStart = 168,
            /// <summary>
            /// 'LoadingEnd' opcode.
            /// </summary>
            LoadingEnd = 169,
            /// <summary>
            /// 'FoundKnownDll' opcode.
            /// </summary>
            FoundKnownDll = 170,
            /// <summary>
            /// 'AbnormalTermination' opcode.
            /// </summary>
            AbnormalTermination = 171,
            /// <summary>
            /// 'ModulePlaceHolder' opcode.
            /// </summary>
            ModulePlaceHolder = 172,
            /// <summary>
            /// 'ReadyToInit' opcode.
            /// </summary>
            ReadyToInit = 173,
            /// <summary>
            /// 'ReadyToRun' opcode.
            /// </summary>
            ReadyToRun = 174,
            /// <summary>
            /// 'NewDllLoad' opcode.
            /// </summary>
            NewDllLoad = 176,
            /// <summary>
            /// 'NewDllLoadAsData' opcode.
            /// </summary>
            NewDllLoadAsData = 177,
            /// <summary>
            /// 'DllSearchPathExternal' opcode.
            /// </summary>
            DllSearchPathExternal = 192,
            /// <summary>
            /// 'DllSearchPathInternal' opcode.
            /// </summary>
            DllSearchPathInternal = 193,
            /// <summary>
            /// 'ApiSetResolving' opcode.
            /// </summary>
            ApiSetResolving = 208,
            /// <summary>
            /// 'ApiSetHosted' opcode.
            /// </summary>
            ApiSetHosted = 209,
            /// <summary>
            /// 'ApiSetUnhosted' opcode.
            /// </summary>
            ApiSetUnhosted = 210,
            /// <summary>
            /// 'ApiSetUnresolved' opcode.
            /// </summary>
            ApiSetUnresolved = 211,
            /// <summary>
            /// 'DllSearchResults' opcode.
            /// </summary>
            DllSearchResults = 212,
            /// <summary>
            /// 'DllPathSearchResults' opcode.
            /// </summary>
            DllPathSearchResults = 213,
        }

        /// <summary>
        /// An event wrapper for a Load event.
        /// </summary>
        public readonly ref struct LoadEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Load";

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
                Opcode = (EtwEventOpcode)Opcodes.Load,
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
            public LoadData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new LoadEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public LoadEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a LoadEvent.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator LoadEvent(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Load event.
            /// </summary>
            public ref struct LoadData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_BaseAddress;
                private int _offset_ModuleSize;
                private int _offset_ImageFileName;

                private int Offset_BaseAddress
                {
                    get
                    {
                        if (_offset_BaseAddress == -1)
                        {
                            _offset_BaseAddress = 0;
                        }

                        return _offset_BaseAddress;
                    }
                }

                private int Offset_ModuleSize
                {
                    get
                    {
                        if (_offset_ModuleSize == -1)
                        {
                            _offset_ModuleSize = Offset_BaseAddress + _etwEvent.AddressSize;
                        }

                        return _offset_ModuleSize;
                    }
                }

                private int Offset_ImageFileName
                {
                    get
                    {
                        if (_offset_ImageFileName == -1)
                        {
                            _offset_ImageFileName = Offset_ModuleSize + 4;
                        }

                        return _offset_ImageFileName;
                    }
                }

                /// <summary>
                /// Retrieves the BaseAddress field.
                /// </summary>
                public ulong BaseAddress => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_BaseAddress..Offset_ModuleSize]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_BaseAddress..Offset_ModuleSize]);

                /// <summary>
                /// Retrieves the ModuleSize field.
                /// </summary>
                public uint ModuleSize => BitConverter.ToUInt32(_etwEvent.Data[Offset_ModuleSize..Offset_ImageFileName]);

                /// <summary>
                /// Retrieves the ImageFileName field.
                /// </summary>
                public string ImageFileName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ImageFileName..]);

                /// <summary>
                /// Creates a new LoadData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public LoadData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_BaseAddress = -1;
                    _offset_ModuleSize = -1;
                    _offset_ImageFileName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Load event.
        /// </summary>
        public readonly ref struct LoadEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Load";

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
                Opcode = (EtwEventOpcode)Opcodes.Load,
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
            public LoadData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new LoadEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public LoadEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a LoadEventV1.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator LoadEventV1(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Load event.
            /// </summary>
            public ref struct LoadData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ImageBase;
                private int _offset_ImageSize;
                private int _offset_ProcessId;
                private int _offset_FileName;

                private int Offset_ImageBase
                {
                    get
                    {
                        if (_offset_ImageBase == -1)
                        {
                            _offset_ImageBase = 0;
                        }

                        return _offset_ImageBase;
                    }
                }

                private int Offset_ImageSize
                {
                    get
                    {
                        if (_offset_ImageSize == -1)
                        {
                            _offset_ImageSize = Offset_ImageBase + _etwEvent.AddressSize;
                        }

                        return _offset_ImageSize;
                    }
                }

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = Offset_ImageSize + _etwEvent.AddressSize;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_FileName
                {
                    get
                    {
                        if (_offset_FileName == -1)
                        {
                            _offset_FileName = Offset_ProcessId + 4;
                        }

                        return _offset_FileName;
                    }
                }

                /// <summary>
                /// Retrieves the ImageBase field.
                /// </summary>
                public ulong ImageBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ImageBase..Offset_ImageSize]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ImageBase..Offset_ImageSize]);

                /// <summary>
                /// Retrieves the ImageSize field.
                /// </summary>
                public ulong ImageSize => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ImageSize..Offset_ProcessId]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ImageSize..Offset_ProcessId]);

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..Offset_FileName]);

                /// <summary>
                /// Retrieves the FileName field.
                /// </summary>
                public string FileName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FileName..]);

                /// <summary>
                /// Creates a new LoadData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public LoadData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ImageBase = -1;
                    _offset_ImageSize = -1;
                    _offset_ProcessId = -1;
                    _offset_FileName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a KernelBase event.
        /// </summary>
        public readonly ref struct KernelBaseEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "KernelBase";

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
                Opcode = (EtwEventOpcode)Opcodes.KernelBase,
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
            public KernelBaseData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new KernelBaseEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public KernelBaseEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a KernelBaseEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator KernelBaseEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a KernelBase event.
            /// </summary>
            public ref struct KernelBaseData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ImageBase;

                private int Offset_ImageBase
                {
                    get
                    {
                        if (_offset_ImageBase == -1)
                        {
                            _offset_ImageBase = 0;
                        }

                        return _offset_ImageBase;
                    }
                }

                /// <summary>
                /// Retrieves the ImageBase field.
                /// </summary>
                public ulong ImageBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ImageBase..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ImageBase..]);

                /// <summary>
                /// Creates a new KernelBaseData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public KernelBaseData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ImageBase = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a LoaderLockAttempt event.
        /// </summary>
        public readonly ref struct LoaderLockAttemptEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "LoaderLockAttempt";

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
                Opcode = (EtwEventOpcode)Opcodes.LoaderLockAttempt,
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
            /// Creates a new LoaderLockAttemptEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public LoaderLockAttemptEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a LoaderLockAttemptEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator LoaderLockAttemptEventV2(EtwEvent etwEvent) => new(etwEvent);
        }

        /// <summary>
        /// An event wrapper for a LoaderLockAcquire event.
        /// </summary>
        public readonly ref struct LoaderLockAcquireEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "LoaderLockAcquire";

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
                Opcode = (EtwEventOpcode)Opcodes.LoaderLockAcquire,
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
            /// Creates a new LoaderLockAcquireEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public LoaderLockAcquireEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a LoaderLockAcquireEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator LoaderLockAcquireEventV2(EtwEvent etwEvent) => new(etwEvent);
        }

        /// <summary>
        /// An event wrapper for a LoaderLockTriedAndFailed event.
        /// </summary>
        public readonly ref struct LoaderLockTriedAndFailedEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "LoaderLockTriedAndFailed";

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
                Opcode = (EtwEventOpcode)Opcodes.LoaderLockTriedAndFailed,
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
            /// Creates a new LoaderLockTriedAndFailedEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public LoaderLockTriedAndFailedEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a LoaderLockTriedAndFailedEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator LoaderLockTriedAndFailedEventV2(EtwEvent etwEvent) => new(etwEvent);
        }

        /// <summary>
        /// An event wrapper for a LoaderLockWait event.
        /// </summary>
        public readonly ref struct LoaderLockWaitEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "LoaderLockWait";

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
                Opcode = (EtwEventOpcode)Opcodes.LoaderLockWait,
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
            /// Creates a new LoaderLockWaitEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public LoaderLockWaitEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a LoaderLockWaitEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator LoaderLockWaitEventV2(EtwEvent etwEvent) => new(etwEvent);
        }

        /// <summary>
        /// An event wrapper for a ProcessInitDone event.
        /// </summary>
        public readonly ref struct ProcessInitDoneEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ProcessInitDone";

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
                Opcode = (EtwEventOpcode)Opcodes.ProcessInitDone,
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
            /// Creates a new ProcessInitDoneEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ProcessInitDoneEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a ProcessInitDoneEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator ProcessInitDoneEventV2(EtwEvent etwEvent) => new(etwEvent);
        }

        /// <summary>
        /// An event wrapper for a CreateSectionBegin event.
        /// </summary>
        public readonly ref struct CreateSectionBeginEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "CreateSectionBegin";

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
                Opcode = (EtwEventOpcode)Opcodes.CreateSectionBegin,
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
            /// Creates a new CreateSectionBeginEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public CreateSectionBeginEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a CreateSectionBeginEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator CreateSectionBeginEventV2(EtwEvent etwEvent) => new(etwEvent);
        }

        /// <summary>
        /// An event wrapper for a CreateSectionEnd event.
        /// </summary>
        public readonly ref struct CreateSectionEndEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "CreateSectionEnd";

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
                Opcode = (EtwEventOpcode)Opcodes.CreateSectionEnd,
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
            /// Creates a new CreateSectionEndEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public CreateSectionEndEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a CreateSectionEndEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator CreateSectionEndEventV2(EtwEvent etwEvent) => new(etwEvent);
        }

        /// <summary>
        /// An event wrapper for a MapViewBegin event.
        /// </summary>
        public readonly ref struct MapViewBeginEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "MapViewBegin";

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
                Opcode = (EtwEventOpcode)Opcodes.MapViewBegin,
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
            /// Creates a new MapViewBeginEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public MapViewBeginEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a MapViewBeginEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator MapViewBeginEventV2(EtwEvent etwEvent) => new(etwEvent);
        }

        /// <summary>
        /// An event wrapper for a FindDllByName event.
        /// </summary>
        public readonly ref struct FindDllByNameEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "FindDllByName";

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
                Opcode = (EtwEventOpcode)Opcodes.FindDllByName,
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
            public FindDllByNameData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new FindDllByNameEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public FindDllByNameEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a FindDllByNameEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator FindDllByNameEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a FindDllByName event.
            /// </summary>
            public ref struct FindDllByNameData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_BaseAddress;
                private int _offset_ErrorOpcode;
                private int _offset_Code;
                private int _offset_String;

                private int Offset_BaseAddress
                {
                    get
                    {
                        if (_offset_BaseAddress == -1)
                        {
                            _offset_BaseAddress = 0;
                        }

                        return _offset_BaseAddress;
                    }
                }

                private int Offset_ErrorOpcode
                {
                    get
                    {
                        if (_offset_ErrorOpcode == -1)
                        {
                            _offset_ErrorOpcode = Offset_BaseAddress + 8;
                        }

                        return _offset_ErrorOpcode;
                    }
                }

                private int Offset_Code
                {
                    get
                    {
                        if (_offset_Code == -1)
                        {
                            _offset_Code = Offset_ErrorOpcode + 1;
                        }

                        return _offset_Code;
                    }
                }

                private int Offset_String
                {
                    get
                    {
                        if (_offset_String == -1)
                        {
                            _offset_String = Offset_Code + 1;
                        }

                        return _offset_String;
                    }
                }

                /// <summary>
                /// Retrieves the BaseAddress field.
                /// </summary>
                public ulong BaseAddress => BitConverter.ToUInt64(_etwEvent.Data[Offset_BaseAddress..Offset_ErrorOpcode]);

                /// <summary>
                /// Retrieves the ErrorOpcode field.
                /// </summary>
                public byte ErrorOpcode => _etwEvent.Data[Offset_ErrorOpcode];

                /// <summary>
                /// Retrieves the Code field.
                /// </summary>
                public sbyte Code => (sbyte)_etwEvent.Data[Offset_Code];

                /// <summary>
                /// Retrieves the String field.
                /// </summary>
                public string String => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_String..]);

                /// <summary>
                /// Creates a new FindDllByNameData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public FindDllByNameData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_BaseAddress = -1;
                    _offset_ErrorOpcode = -1;
                    _offset_Code = -1;
                    _offset_String = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a MapViewEnd event.
        /// </summary>
        public readonly ref struct MapViewEndEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "MapViewEnd";

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
                Opcode = (EtwEventOpcode)Opcodes.MapViewEnd,
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
            public MapViewEndData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new MapViewEndEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public MapViewEndEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a MapViewEndEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator MapViewEndEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a MapViewEnd event.
            /// </summary>
            public ref struct MapViewEndData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_BaseAddress;
                private int _offset_ErrorOpcode;
                private int _offset_Code;
                private int _offset_String;

                private int Offset_BaseAddress
                {
                    get
                    {
                        if (_offset_BaseAddress == -1)
                        {
                            _offset_BaseAddress = 0;
                        }

                        return _offset_BaseAddress;
                    }
                }

                private int Offset_ErrorOpcode
                {
                    get
                    {
                        if (_offset_ErrorOpcode == -1)
                        {
                            _offset_ErrorOpcode = Offset_BaseAddress + 8;
                        }

                        return _offset_ErrorOpcode;
                    }
                }

                private int Offset_Code
                {
                    get
                    {
                        if (_offset_Code == -1)
                        {
                            _offset_Code = Offset_ErrorOpcode + 1;
                        }

                        return _offset_Code;
                    }
                }

                private int Offset_String
                {
                    get
                    {
                        if (_offset_String == -1)
                        {
                            _offset_String = Offset_Code + 1;
                        }

                        return _offset_String;
                    }
                }

                /// <summary>
                /// Retrieves the BaseAddress field.
                /// </summary>
                public ulong BaseAddress => BitConverter.ToUInt64(_etwEvent.Data[Offset_BaseAddress..Offset_ErrorOpcode]);

                /// <summary>
                /// Retrieves the ErrorOpcode field.
                /// </summary>
                public byte ErrorOpcode => _etwEvent.Data[Offset_ErrorOpcode];

                /// <summary>
                /// Retrieves the Code field.
                /// </summary>
                public sbyte Code => (sbyte)_etwEvent.Data[Offset_Code];

                /// <summary>
                /// Retrieves the String field.
                /// </summary>
                public string String => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_String..]);

                /// <summary>
                /// Creates a new MapViewEndData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public MapViewEndData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_BaseAddress = -1;
                    _offset_ErrorOpcode = -1;
                    _offset_Code = -1;
                    _offset_String = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a LoaderLockRelease event.
        /// </summary>
        public readonly ref struct LoaderLockReleaseEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "LoaderLockRelease";

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
                Opcode = (EtwEventOpcode)Opcodes.LoaderLockRelease,
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
            public LoaderLockReleaseData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new LoaderLockReleaseEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public LoaderLockReleaseEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a LoaderLockReleaseEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator LoaderLockReleaseEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a LoaderLockRelease event.
            /// </summary>
            public ref struct LoaderLockReleaseData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_BaseAddress;
                private int _offset_ErrorOpcode;
                private int _offset_Code;
                private int _offset_String;

                private int Offset_BaseAddress
                {
                    get
                    {
                        if (_offset_BaseAddress == -1)
                        {
                            _offset_BaseAddress = 0;
                        }

                        return _offset_BaseAddress;
                    }
                }

                private int Offset_ErrorOpcode
                {
                    get
                    {
                        if (_offset_ErrorOpcode == -1)
                        {
                            _offset_ErrorOpcode = Offset_BaseAddress + 8;
                        }

                        return _offset_ErrorOpcode;
                    }
                }

                private int Offset_Code
                {
                    get
                    {
                        if (_offset_Code == -1)
                        {
                            _offset_Code = Offset_ErrorOpcode + 1;
                        }

                        return _offset_Code;
                    }
                }

                private int Offset_String
                {
                    get
                    {
                        if (_offset_String == -1)
                        {
                            _offset_String = Offset_Code + 1;
                        }

                        return _offset_String;
                    }
                }

                /// <summary>
                /// Retrieves the BaseAddress field.
                /// </summary>
                public ulong BaseAddress => BitConverter.ToUInt64(_etwEvent.Data[Offset_BaseAddress..Offset_ErrorOpcode]);

                /// <summary>
                /// Retrieves the ErrorOpcode field.
                /// </summary>
                public byte ErrorOpcode => _etwEvent.Data[Offset_ErrorOpcode];

                /// <summary>
                /// Retrieves the Code field.
                /// </summary>
                public sbyte Code => (sbyte)_etwEvent.Data[Offset_Code];

                /// <summary>
                /// Retrieves the String field.
                /// </summary>
                public string String => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_String..]);

                /// <summary>
                /// Creates a new LoaderLockReleaseData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public LoaderLockReleaseData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_BaseAddress = -1;
                    _offset_ErrorOpcode = -1;
                    _offset_Code = -1;
                    _offset_String = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DllMainEnter event.
        /// </summary>
        public readonly ref struct DllMainEnterEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DllMainEnter";

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
                Opcode = (EtwEventOpcode)Opcodes.DllMainEnter,
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
            public DllMainEnterData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DllMainEnterEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DllMainEnterEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a DllMainEnterEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator DllMainEnterEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a DllMainEnter event.
            /// </summary>
            public ref struct DllMainEnterData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_BaseAddress;
                private int _offset_ErrorOpcode;
                private int _offset_Code;
                private int _offset_String;

                private int Offset_BaseAddress
                {
                    get
                    {
                        if (_offset_BaseAddress == -1)
                        {
                            _offset_BaseAddress = 0;
                        }

                        return _offset_BaseAddress;
                    }
                }

                private int Offset_ErrorOpcode
                {
                    get
                    {
                        if (_offset_ErrorOpcode == -1)
                        {
                            _offset_ErrorOpcode = Offset_BaseAddress + 8;
                        }

                        return _offset_ErrorOpcode;
                    }
                }

                private int Offset_Code
                {
                    get
                    {
                        if (_offset_Code == -1)
                        {
                            _offset_Code = Offset_ErrorOpcode + 1;
                        }

                        return _offset_Code;
                    }
                }

                private int Offset_String
                {
                    get
                    {
                        if (_offset_String == -1)
                        {
                            _offset_String = Offset_Code + 1;
                        }

                        return _offset_String;
                    }
                }

                /// <summary>
                /// Retrieves the BaseAddress field.
                /// </summary>
                public ulong BaseAddress => BitConverter.ToUInt64(_etwEvent.Data[Offset_BaseAddress..Offset_ErrorOpcode]);

                /// <summary>
                /// Retrieves the ErrorOpcode field.
                /// </summary>
                public byte ErrorOpcode => _etwEvent.Data[Offset_ErrorOpcode];

                /// <summary>
                /// Retrieves the Code field.
                /// </summary>
                public sbyte Code => (sbyte)_etwEvent.Data[Offset_Code];

                /// <summary>
                /// Retrieves the String field.
                /// </summary>
                public string String => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_String..]);

                /// <summary>
                /// Creates a new DllMainEnterData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DllMainEnterData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_BaseAddress = -1;
                    _offset_ErrorOpcode = -1;
                    _offset_Code = -1;
                    _offset_String = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a LoaderError event.
        /// </summary>
        public readonly ref struct LoaderErrorEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "LoaderError";

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
                Opcode = (EtwEventOpcode)Opcodes.LoaderError,
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
            public LoaderErrorData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new LoaderErrorEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public LoaderErrorEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a LoaderErrorEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator LoaderErrorEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a LoaderError event.
            /// </summary>
            public ref struct LoaderErrorData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_BaseAddress;
                private int _offset_ErrorOpcode;
                private int _offset_Code;
                private int _offset_String;

                private int Offset_BaseAddress
                {
                    get
                    {
                        if (_offset_BaseAddress == -1)
                        {
                            _offset_BaseAddress = 0;
                        }

                        return _offset_BaseAddress;
                    }
                }

                private int Offset_ErrorOpcode
                {
                    get
                    {
                        if (_offset_ErrorOpcode == -1)
                        {
                            _offset_ErrorOpcode = Offset_BaseAddress + 8;
                        }

                        return _offset_ErrorOpcode;
                    }
                }

                private int Offset_Code
                {
                    get
                    {
                        if (_offset_Code == -1)
                        {
                            _offset_Code = Offset_ErrorOpcode + 1;
                        }

                        return _offset_Code;
                    }
                }

                private int Offset_String
                {
                    get
                    {
                        if (_offset_String == -1)
                        {
                            _offset_String = Offset_Code + 1;
                        }

                        return _offset_String;
                    }
                }

                /// <summary>
                /// Retrieves the BaseAddress field.
                /// </summary>
                public ulong BaseAddress => BitConverter.ToUInt64(_etwEvent.Data[Offset_BaseAddress..Offset_ErrorOpcode]);

                /// <summary>
                /// Retrieves the ErrorOpcode field.
                /// </summary>
                public byte ErrorOpcode => _etwEvent.Data[Offset_ErrorOpcode];

                /// <summary>
                /// Retrieves the Code field.
                /// </summary>
                public sbyte Code => (sbyte)_etwEvent.Data[Offset_Code];

                /// <summary>
                /// Retrieves the String field.
                /// </summary>
                public string String => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_String..]);

                /// <summary>
                /// Creates a new LoaderErrorData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public LoaderErrorData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_BaseAddress = -1;
                    _offset_ErrorOpcode = -1;
                    _offset_Code = -1;
                    _offset_String = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a RelocateImageBegin event.
        /// </summary>
        public readonly ref struct RelocateImageBeginEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "RelocateImageBegin";

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
                Opcode = (EtwEventOpcode)Opcodes.RelocateImageBegin,
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
            public RelocateImageBeginData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new RelocateImageBeginEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public RelocateImageBeginEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a RelocateImageBeginEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator RelocateImageBeginEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a RelocateImageBegin event.
            /// </summary>
            public ref struct RelocateImageBeginData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_BaseAddress;

                private int Offset_BaseAddress
                {
                    get
                    {
                        if (_offset_BaseAddress == -1)
                        {
                            _offset_BaseAddress = 0;
                        }

                        return _offset_BaseAddress;
                    }
                }

                /// <summary>
                /// Retrieves the BaseAddress field.
                /// </summary>
                public ulong BaseAddress => BitConverter.ToUInt64(_etwEvent.Data[Offset_BaseAddress..]);

                /// <summary>
                /// Creates a new RelocateImageBeginData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public RelocateImageBeginData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_BaseAddress = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a RelocateImageEnd event.
        /// </summary>
        public readonly ref struct RelocateImageEndEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "RelocateImageEnd";

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
                Opcode = (EtwEventOpcode)Opcodes.RelocateImageEnd,
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
            public RelocateImageEndData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new RelocateImageEndEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public RelocateImageEndEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a RelocateImageEndEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator RelocateImageEndEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a RelocateImageEnd event.
            /// </summary>
            public ref struct RelocateImageEndData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_BaseAddress;

                private int Offset_BaseAddress
                {
                    get
                    {
                        if (_offset_BaseAddress == -1)
                        {
                            _offset_BaseAddress = 0;
                        }

                        return _offset_BaseAddress;
                    }
                }

                /// <summary>
                /// Retrieves the BaseAddress field.
                /// </summary>
                public ulong BaseAddress => BitConverter.ToUInt64(_etwEvent.Data[Offset_BaseAddress..]);

                /// <summary>
                /// Creates a new RelocateImageEndData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public RelocateImageEndData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_BaseAddress = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a HandleOldDescsBegin event.
        /// </summary>
        public readonly ref struct HandleOldDescsBeginEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "HandleOldDescsBegin";

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
                Opcode = (EtwEventOpcode)Opcodes.HandleOldDescsBegin,
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
            public HandleOldDescsBeginData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new HandleOldDescsBeginEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public HandleOldDescsBeginEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a HandleOldDescsBeginEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator HandleOldDescsBeginEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a HandleOldDescsBegin event.
            /// </summary>
            public ref struct HandleOldDescsBeginData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_BaseAddress;

                private int Offset_BaseAddress
                {
                    get
                    {
                        if (_offset_BaseAddress == -1)
                        {
                            _offset_BaseAddress = 0;
                        }

                        return _offset_BaseAddress;
                    }
                }

                /// <summary>
                /// Retrieves the BaseAddress field.
                /// </summary>
                public ulong BaseAddress => BitConverter.ToUInt64(_etwEvent.Data[Offset_BaseAddress..]);

                /// <summary>
                /// Creates a new HandleOldDescsBeginData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public HandleOldDescsBeginData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_BaseAddress = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a HandleOldDescsEnd event.
        /// </summary>
        public readonly ref struct HandleOldDescsEndEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "HandleOldDescsEnd";

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
                Opcode = (EtwEventOpcode)Opcodes.HandleOldDescsEnd,
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
            public HandleOldDescsEndData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new HandleOldDescsEndEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public HandleOldDescsEndEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a HandleOldDescsEndEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator HandleOldDescsEndEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a HandleOldDescsEnd event.
            /// </summary>
            public ref struct HandleOldDescsEndData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_BaseAddress;

                private int Offset_BaseAddress
                {
                    get
                    {
                        if (_offset_BaseAddress == -1)
                        {
                            _offset_BaseAddress = 0;
                        }

                        return _offset_BaseAddress;
                    }
                }

                /// <summary>
                /// Retrieves the BaseAddress field.
                /// </summary>
                public ulong BaseAddress => BitConverter.ToUInt64(_etwEvent.Data[Offset_BaseAddress..]);

                /// <summary>
                /// Creates a new HandleOldDescsEndData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public HandleOldDescsEndData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_BaseAddress = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a HandleNewDescsBegin event.
        /// </summary>
        public readonly ref struct HandleNewDescsBeginEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "HandleNewDescsBegin";

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
                Opcode = (EtwEventOpcode)Opcodes.HandleNewDescsBegin,
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
            public HandleNewDescsBeginData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new HandleNewDescsBeginEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public HandleNewDescsBeginEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a HandleNewDescsBeginEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator HandleNewDescsBeginEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a HandleNewDescsBegin event.
            /// </summary>
            public ref struct HandleNewDescsBeginData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_BaseAddress;

                private int Offset_BaseAddress
                {
                    get
                    {
                        if (_offset_BaseAddress == -1)
                        {
                            _offset_BaseAddress = 0;
                        }

                        return _offset_BaseAddress;
                    }
                }

                /// <summary>
                /// Retrieves the BaseAddress field.
                /// </summary>
                public ulong BaseAddress => BitConverter.ToUInt64(_etwEvent.Data[Offset_BaseAddress..]);

                /// <summary>
                /// Creates a new HandleNewDescsBeginData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public HandleNewDescsBeginData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_BaseAddress = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a HandleNewDescsEnd event.
        /// </summary>
        public readonly ref struct HandleNewDescsEndEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "HandleNewDescsEnd";

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
                Opcode = (EtwEventOpcode)Opcodes.HandleNewDescsEnd,
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
            public HandleNewDescsEndData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new HandleNewDescsEndEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public HandleNewDescsEndEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a HandleNewDescsEndEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator HandleNewDescsEndEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a HandleNewDescsEnd event.
            /// </summary>
            public ref struct HandleNewDescsEndData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_BaseAddress;

                private int Offset_BaseAddress
                {
                    get
                    {
                        if (_offset_BaseAddress == -1)
                        {
                            _offset_BaseAddress = 0;
                        }

                        return _offset_BaseAddress;
                    }
                }

                /// <summary>
                /// Retrieves the BaseAddress field.
                /// </summary>
                public ulong BaseAddress => BitConverter.ToUInt64(_etwEvent.Data[Offset_BaseAddress..]);

                /// <summary>
                /// Creates a new HandleNewDescsEndData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public HandleNewDescsEndData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_BaseAddress = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DllMainExit event.
        /// </summary>
        public readonly ref struct DllMainExitEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DllMainExit";

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
                Opcode = (EtwEventOpcode)Opcodes.DllMainExit,
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
            public DllMainExitData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DllMainExitEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DllMainExitEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a DllMainExitEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator DllMainExitEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a DllMainExit event.
            /// </summary>
            public ref struct DllMainExitData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_BaseAddress;

                private int Offset_BaseAddress
                {
                    get
                    {
                        if (_offset_BaseAddress == -1)
                        {
                            _offset_BaseAddress = 0;
                        }

                        return _offset_BaseAddress;
                    }
                }

                /// <summary>
                /// Retrieves the BaseAddress field.
                /// </summary>
                public ulong BaseAddress => BitConverter.ToUInt64(_etwEvent.Data[Offset_BaseAddress..]);

                /// <summary>
                /// Creates a new DllMainExitData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DllMainExitData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_BaseAddress = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Load event.
        /// </summary>
        public readonly ref struct LoadEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Load";

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
                Opcode = (EtwEventOpcode)Opcodes.Load,
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
            public LoadData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new LoadEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public LoadEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a LoadEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator LoadEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Load event.
            /// </summary>
            public ref struct LoadData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ImageBase;
                private int _offset_ImageSize;
                private int _offset_ProcessId;
                private int _offset_ImageChecksum;
                private int _offset_TimeDateStamp;
                private int _offset_Reserved0;
                private int _offset_DefaultBase;
                private int _offset_Reserved1;
                private int _offset_Reserved2;
                private int _offset_Reserved3;
                private int _offset_Reserved4;
                private int _offset_FileName;

                private int Offset_ImageBase
                {
                    get
                    {
                        if (_offset_ImageBase == -1)
                        {
                            _offset_ImageBase = 0;
                        }

                        return _offset_ImageBase;
                    }
                }

                private int Offset_ImageSize
                {
                    get
                    {
                        if (_offset_ImageSize == -1)
                        {
                            _offset_ImageSize = Offset_ImageBase + _etwEvent.AddressSize;
                        }

                        return _offset_ImageSize;
                    }
                }

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = Offset_ImageSize + _etwEvent.AddressSize;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_ImageChecksum
                {
                    get
                    {
                        if (_offset_ImageChecksum == -1)
                        {
                            _offset_ImageChecksum = Offset_ProcessId + 4;
                        }

                        return _offset_ImageChecksum;
                    }
                }

                private int Offset_TimeDateStamp
                {
                    get
                    {
                        if (_offset_TimeDateStamp == -1)
                        {
                            _offset_TimeDateStamp = Offset_ImageChecksum + 4;
                        }

                        return _offset_TimeDateStamp;
                    }
                }

                private int Offset_Reserved0
                {
                    get
                    {
                        if (_offset_Reserved0 == -1)
                        {
                            _offset_Reserved0 = Offset_TimeDateStamp + 4;
                        }

                        return _offset_Reserved0;
                    }
                }

                private int Offset_DefaultBase
                {
                    get
                    {
                        if (_offset_DefaultBase == -1)
                        {
                            _offset_DefaultBase = Offset_Reserved0 + 4;
                        }

                        return _offset_DefaultBase;
                    }
                }

                private int Offset_Reserved1
                {
                    get
                    {
                        if (_offset_Reserved1 == -1)
                        {
                            _offset_Reserved1 = Offset_DefaultBase + _etwEvent.AddressSize;
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
                            _offset_Reserved2 = Offset_Reserved1 + 4;
                        }

                        return _offset_Reserved2;
                    }
                }

                private int Offset_Reserved3
                {
                    get
                    {
                        if (_offset_Reserved3 == -1)
                        {
                            _offset_Reserved3 = Offset_Reserved2 + 4;
                        }

                        return _offset_Reserved3;
                    }
                }

                private int Offset_Reserved4
                {
                    get
                    {
                        if (_offset_Reserved4 == -1)
                        {
                            _offset_Reserved4 = Offset_Reserved3 + 4;
                        }

                        return _offset_Reserved4;
                    }
                }

                private int Offset_FileName
                {
                    get
                    {
                        if (_offset_FileName == -1)
                        {
                            _offset_FileName = Offset_Reserved4 + 4;
                        }

                        return _offset_FileName;
                    }
                }

                /// <summary>
                /// Retrieves the ImageBase field.
                /// </summary>
                public ulong ImageBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ImageBase..Offset_ImageSize]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ImageBase..Offset_ImageSize]);

                /// <summary>
                /// Retrieves the ImageSize field.
                /// </summary>
                public ulong ImageSize => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ImageSize..Offset_ProcessId]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ImageSize..Offset_ProcessId]);

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..Offset_ImageChecksum]);

                /// <summary>
                /// Retrieves the ImageChecksum field.
                /// </summary>
                public uint ImageChecksum => BitConverter.ToUInt32(_etwEvent.Data[Offset_ImageChecksum..Offset_TimeDateStamp]);

                /// <summary>
                /// Retrieves the TimeDateStamp field.
                /// </summary>
                public uint TimeDateStamp => BitConverter.ToUInt32(_etwEvent.Data[Offset_TimeDateStamp..Offset_Reserved0]);

                /// <summary>
                /// Retrieves the Reserved0 field.
                /// </summary>
                public uint Reserved0 => BitConverter.ToUInt32(_etwEvent.Data[Offset_Reserved0..Offset_DefaultBase]);

                /// <summary>
                /// Retrieves the DefaultBase field.
                /// </summary>
                public ulong DefaultBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_DefaultBase..Offset_Reserved1]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_DefaultBase..Offset_Reserved1]);

                /// <summary>
                /// Retrieves the Reserved1 field.
                /// </summary>
                public uint Reserved1 => BitConverter.ToUInt32(_etwEvent.Data[Offset_Reserved1..Offset_Reserved2]);

                /// <summary>
                /// Retrieves the Reserved2 field.
                /// </summary>
                public uint Reserved2 => BitConverter.ToUInt32(_etwEvent.Data[Offset_Reserved2..Offset_Reserved3]);

                /// <summary>
                /// Retrieves the Reserved3 field.
                /// </summary>
                public uint Reserved3 => BitConverter.ToUInt32(_etwEvent.Data[Offset_Reserved3..Offset_Reserved4]);

                /// <summary>
                /// Retrieves the Reserved4 field.
                /// </summary>
                public uint Reserved4 => BitConverter.ToUInt32(_etwEvent.Data[Offset_Reserved4..Offset_FileName]);

                /// <summary>
                /// Retrieves the FileName field.
                /// </summary>
                public string FileName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FileName..]);

                /// <summary>
                /// Creates a new LoadData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public LoadData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ImageBase = -1;
                    _offset_ImageSize = -1;
                    _offset_ProcessId = -1;
                    _offset_ImageChecksum = -1;
                    _offset_TimeDateStamp = -1;
                    _offset_Reserved0 = -1;
                    _offset_DefaultBase = -1;
                    _offset_Reserved1 = -1;
                    _offset_Reserved2 = -1;
                    _offset_Reserved3 = -1;
                    _offset_Reserved4 = -1;
                    _offset_FileName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a UnLoad event.
        /// </summary>
        public readonly ref struct UnLoadEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "UnLoad";

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
            public UnLoadData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new UnLoadEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public UnLoadEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a UnLoadEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator UnLoadEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a UnLoad event.
            /// </summary>
            public ref struct UnLoadData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ImageBase;
                private int _offset_ImageSize;
                private int _offset_ProcessId;
                private int _offset_ImageChecksum;
                private int _offset_TimeDateStamp;
                private int _offset_Reserved0;
                private int _offset_DefaultBase;
                private int _offset_Reserved1;
                private int _offset_Reserved2;
                private int _offset_Reserved3;
                private int _offset_Reserved4;
                private int _offset_FileName;

                private int Offset_ImageBase
                {
                    get
                    {
                        if (_offset_ImageBase == -1)
                        {
                            _offset_ImageBase = 0;
                        }

                        return _offset_ImageBase;
                    }
                }

                private int Offset_ImageSize
                {
                    get
                    {
                        if (_offset_ImageSize == -1)
                        {
                            _offset_ImageSize = Offset_ImageBase + _etwEvent.AddressSize;
                        }

                        return _offset_ImageSize;
                    }
                }

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = Offset_ImageSize + _etwEvent.AddressSize;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_ImageChecksum
                {
                    get
                    {
                        if (_offset_ImageChecksum == -1)
                        {
                            _offset_ImageChecksum = Offset_ProcessId + 4;
                        }

                        return _offset_ImageChecksum;
                    }
                }

                private int Offset_TimeDateStamp
                {
                    get
                    {
                        if (_offset_TimeDateStamp == -1)
                        {
                            _offset_TimeDateStamp = Offset_ImageChecksum + 4;
                        }

                        return _offset_TimeDateStamp;
                    }
                }

                private int Offset_Reserved0
                {
                    get
                    {
                        if (_offset_Reserved0 == -1)
                        {
                            _offset_Reserved0 = Offset_TimeDateStamp + 4;
                        }

                        return _offset_Reserved0;
                    }
                }

                private int Offset_DefaultBase
                {
                    get
                    {
                        if (_offset_DefaultBase == -1)
                        {
                            _offset_DefaultBase = Offset_Reserved0 + 4;
                        }

                        return _offset_DefaultBase;
                    }
                }

                private int Offset_Reserved1
                {
                    get
                    {
                        if (_offset_Reserved1 == -1)
                        {
                            _offset_Reserved1 = Offset_DefaultBase + _etwEvent.AddressSize;
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
                            _offset_Reserved2 = Offset_Reserved1 + 4;
                        }

                        return _offset_Reserved2;
                    }
                }

                private int Offset_Reserved3
                {
                    get
                    {
                        if (_offset_Reserved3 == -1)
                        {
                            _offset_Reserved3 = Offset_Reserved2 + 4;
                        }

                        return _offset_Reserved3;
                    }
                }

                private int Offset_Reserved4
                {
                    get
                    {
                        if (_offset_Reserved4 == -1)
                        {
                            _offset_Reserved4 = Offset_Reserved3 + 4;
                        }

                        return _offset_Reserved4;
                    }
                }

                private int Offset_FileName
                {
                    get
                    {
                        if (_offset_FileName == -1)
                        {
                            _offset_FileName = Offset_Reserved4 + 4;
                        }

                        return _offset_FileName;
                    }
                }

                /// <summary>
                /// Retrieves the ImageBase field.
                /// </summary>
                public ulong ImageBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ImageBase..Offset_ImageSize]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ImageBase..Offset_ImageSize]);

                /// <summary>
                /// Retrieves the ImageSize field.
                /// </summary>
                public ulong ImageSize => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ImageSize..Offset_ProcessId]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ImageSize..Offset_ProcessId]);

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..Offset_ImageChecksum]);

                /// <summary>
                /// Retrieves the ImageChecksum field.
                /// </summary>
                public uint ImageChecksum => BitConverter.ToUInt32(_etwEvent.Data[Offset_ImageChecksum..Offset_TimeDateStamp]);

                /// <summary>
                /// Retrieves the TimeDateStamp field.
                /// </summary>
                public uint TimeDateStamp => BitConverter.ToUInt32(_etwEvent.Data[Offset_TimeDateStamp..Offset_Reserved0]);

                /// <summary>
                /// Retrieves the Reserved0 field.
                /// </summary>
                public uint Reserved0 => BitConverter.ToUInt32(_etwEvent.Data[Offset_Reserved0..Offset_DefaultBase]);

                /// <summary>
                /// Retrieves the DefaultBase field.
                /// </summary>
                public ulong DefaultBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_DefaultBase..Offset_Reserved1]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_DefaultBase..Offset_Reserved1]);

                /// <summary>
                /// Retrieves the Reserved1 field.
                /// </summary>
                public uint Reserved1 => BitConverter.ToUInt32(_etwEvent.Data[Offset_Reserved1..Offset_Reserved2]);

                /// <summary>
                /// Retrieves the Reserved2 field.
                /// </summary>
                public uint Reserved2 => BitConverter.ToUInt32(_etwEvent.Data[Offset_Reserved2..Offset_Reserved3]);

                /// <summary>
                /// Retrieves the Reserved3 field.
                /// </summary>
                public uint Reserved3 => BitConverter.ToUInt32(_etwEvent.Data[Offset_Reserved3..Offset_Reserved4]);

                /// <summary>
                /// Retrieves the Reserved4 field.
                /// </summary>
                public uint Reserved4 => BitConverter.ToUInt32(_etwEvent.Data[Offset_Reserved4..Offset_FileName]);

                /// <summary>
                /// Retrieves the FileName field.
                /// </summary>
                public string FileName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FileName..]);

                /// <summary>
                /// Creates a new UnLoadData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public UnLoadData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ImageBase = -1;
                    _offset_ImageSize = -1;
                    _offset_ProcessId = -1;
                    _offset_ImageChecksum = -1;
                    _offset_TimeDateStamp = -1;
                    _offset_Reserved0 = -1;
                    _offset_DefaultBase = -1;
                    _offset_Reserved1 = -1;
                    _offset_Reserved2 = -1;
                    _offset_Reserved3 = -1;
                    _offset_Reserved4 = -1;
                    _offset_FileName = -1;
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
            /// Converts a generic ETW event to a DCStartEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator DCStartEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a DCStart event.
            /// </summary>
            public ref struct DCStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ImageBase;
                private int _offset_ImageSize;
                private int _offset_ProcessId;
                private int _offset_ImageChecksum;
                private int _offset_TimeDateStamp;
                private int _offset_Reserved0;
                private int _offset_DefaultBase;
                private int _offset_Reserved1;
                private int _offset_Reserved2;
                private int _offset_Reserved3;
                private int _offset_Reserved4;
                private int _offset_FileName;

                private int Offset_ImageBase
                {
                    get
                    {
                        if (_offset_ImageBase == -1)
                        {
                            _offset_ImageBase = 0;
                        }

                        return _offset_ImageBase;
                    }
                }

                private int Offset_ImageSize
                {
                    get
                    {
                        if (_offset_ImageSize == -1)
                        {
                            _offset_ImageSize = Offset_ImageBase + _etwEvent.AddressSize;
                        }

                        return _offset_ImageSize;
                    }
                }

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = Offset_ImageSize + _etwEvent.AddressSize;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_ImageChecksum
                {
                    get
                    {
                        if (_offset_ImageChecksum == -1)
                        {
                            _offset_ImageChecksum = Offset_ProcessId + 4;
                        }

                        return _offset_ImageChecksum;
                    }
                }

                private int Offset_TimeDateStamp
                {
                    get
                    {
                        if (_offset_TimeDateStamp == -1)
                        {
                            _offset_TimeDateStamp = Offset_ImageChecksum + 4;
                        }

                        return _offset_TimeDateStamp;
                    }
                }

                private int Offset_Reserved0
                {
                    get
                    {
                        if (_offset_Reserved0 == -1)
                        {
                            _offset_Reserved0 = Offset_TimeDateStamp + 4;
                        }

                        return _offset_Reserved0;
                    }
                }

                private int Offset_DefaultBase
                {
                    get
                    {
                        if (_offset_DefaultBase == -1)
                        {
                            _offset_DefaultBase = Offset_Reserved0 + 4;
                        }

                        return _offset_DefaultBase;
                    }
                }

                private int Offset_Reserved1
                {
                    get
                    {
                        if (_offset_Reserved1 == -1)
                        {
                            _offset_Reserved1 = Offset_DefaultBase + _etwEvent.AddressSize;
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
                            _offset_Reserved2 = Offset_Reserved1 + 4;
                        }

                        return _offset_Reserved2;
                    }
                }

                private int Offset_Reserved3
                {
                    get
                    {
                        if (_offset_Reserved3 == -1)
                        {
                            _offset_Reserved3 = Offset_Reserved2 + 4;
                        }

                        return _offset_Reserved3;
                    }
                }

                private int Offset_Reserved4
                {
                    get
                    {
                        if (_offset_Reserved4 == -1)
                        {
                            _offset_Reserved4 = Offset_Reserved3 + 4;
                        }

                        return _offset_Reserved4;
                    }
                }

                private int Offset_FileName
                {
                    get
                    {
                        if (_offset_FileName == -1)
                        {
                            _offset_FileName = Offset_Reserved4 + 4;
                        }

                        return _offset_FileName;
                    }
                }

                /// <summary>
                /// Retrieves the ImageBase field.
                /// </summary>
                public ulong ImageBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ImageBase..Offset_ImageSize]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ImageBase..Offset_ImageSize]);

                /// <summary>
                /// Retrieves the ImageSize field.
                /// </summary>
                public ulong ImageSize => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ImageSize..Offset_ProcessId]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ImageSize..Offset_ProcessId]);

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..Offset_ImageChecksum]);

                /// <summary>
                /// Retrieves the ImageChecksum field.
                /// </summary>
                public uint ImageChecksum => BitConverter.ToUInt32(_etwEvent.Data[Offset_ImageChecksum..Offset_TimeDateStamp]);

                /// <summary>
                /// Retrieves the TimeDateStamp field.
                /// </summary>
                public uint TimeDateStamp => BitConverter.ToUInt32(_etwEvent.Data[Offset_TimeDateStamp..Offset_Reserved0]);

                /// <summary>
                /// Retrieves the Reserved0 field.
                /// </summary>
                public uint Reserved0 => BitConverter.ToUInt32(_etwEvent.Data[Offset_Reserved0..Offset_DefaultBase]);

                /// <summary>
                /// Retrieves the DefaultBase field.
                /// </summary>
                public ulong DefaultBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_DefaultBase..Offset_Reserved1]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_DefaultBase..Offset_Reserved1]);

                /// <summary>
                /// Retrieves the Reserved1 field.
                /// </summary>
                public uint Reserved1 => BitConverter.ToUInt32(_etwEvent.Data[Offset_Reserved1..Offset_Reserved2]);

                /// <summary>
                /// Retrieves the Reserved2 field.
                /// </summary>
                public uint Reserved2 => BitConverter.ToUInt32(_etwEvent.Data[Offset_Reserved2..Offset_Reserved3]);

                /// <summary>
                /// Retrieves the Reserved3 field.
                /// </summary>
                public uint Reserved3 => BitConverter.ToUInt32(_etwEvent.Data[Offset_Reserved3..Offset_Reserved4]);

                /// <summary>
                /// Retrieves the Reserved4 field.
                /// </summary>
                public uint Reserved4 => BitConverter.ToUInt32(_etwEvent.Data[Offset_Reserved4..Offset_FileName]);

                /// <summary>
                /// Retrieves the FileName field.
                /// </summary>
                public string FileName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FileName..]);

                /// <summary>
                /// Creates a new DCStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DCStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ImageBase = -1;
                    _offset_ImageSize = -1;
                    _offset_ProcessId = -1;
                    _offset_ImageChecksum = -1;
                    _offset_TimeDateStamp = -1;
                    _offset_Reserved0 = -1;
                    _offset_DefaultBase = -1;
                    _offset_Reserved1 = -1;
                    _offset_Reserved2 = -1;
                    _offset_Reserved3 = -1;
                    _offset_Reserved4 = -1;
                    _offset_FileName = -1;
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
            /// Converts a generic ETW event to a DCEndEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator DCEndEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a DCEnd event.
            /// </summary>
            public ref struct DCEndData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ImageBase;
                private int _offset_ImageSize;
                private int _offset_ProcessId;
                private int _offset_ImageChecksum;
                private int _offset_TimeDateStamp;
                private int _offset_Reserved0;
                private int _offset_DefaultBase;
                private int _offset_Reserved1;
                private int _offset_Reserved2;
                private int _offset_Reserved3;
                private int _offset_Reserved4;
                private int _offset_FileName;

                private int Offset_ImageBase
                {
                    get
                    {
                        if (_offset_ImageBase == -1)
                        {
                            _offset_ImageBase = 0;
                        }

                        return _offset_ImageBase;
                    }
                }

                private int Offset_ImageSize
                {
                    get
                    {
                        if (_offset_ImageSize == -1)
                        {
                            _offset_ImageSize = Offset_ImageBase + _etwEvent.AddressSize;
                        }

                        return _offset_ImageSize;
                    }
                }

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = Offset_ImageSize + _etwEvent.AddressSize;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_ImageChecksum
                {
                    get
                    {
                        if (_offset_ImageChecksum == -1)
                        {
                            _offset_ImageChecksum = Offset_ProcessId + 4;
                        }

                        return _offset_ImageChecksum;
                    }
                }

                private int Offset_TimeDateStamp
                {
                    get
                    {
                        if (_offset_TimeDateStamp == -1)
                        {
                            _offset_TimeDateStamp = Offset_ImageChecksum + 4;
                        }

                        return _offset_TimeDateStamp;
                    }
                }

                private int Offset_Reserved0
                {
                    get
                    {
                        if (_offset_Reserved0 == -1)
                        {
                            _offset_Reserved0 = Offset_TimeDateStamp + 4;
                        }

                        return _offset_Reserved0;
                    }
                }

                private int Offset_DefaultBase
                {
                    get
                    {
                        if (_offset_DefaultBase == -1)
                        {
                            _offset_DefaultBase = Offset_Reserved0 + 4;
                        }

                        return _offset_DefaultBase;
                    }
                }

                private int Offset_Reserved1
                {
                    get
                    {
                        if (_offset_Reserved1 == -1)
                        {
                            _offset_Reserved1 = Offset_DefaultBase + _etwEvent.AddressSize;
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
                            _offset_Reserved2 = Offset_Reserved1 + 4;
                        }

                        return _offset_Reserved2;
                    }
                }

                private int Offset_Reserved3
                {
                    get
                    {
                        if (_offset_Reserved3 == -1)
                        {
                            _offset_Reserved3 = Offset_Reserved2 + 4;
                        }

                        return _offset_Reserved3;
                    }
                }

                private int Offset_Reserved4
                {
                    get
                    {
                        if (_offset_Reserved4 == -1)
                        {
                            _offset_Reserved4 = Offset_Reserved3 + 4;
                        }

                        return _offset_Reserved4;
                    }
                }

                private int Offset_FileName
                {
                    get
                    {
                        if (_offset_FileName == -1)
                        {
                            _offset_FileName = Offset_Reserved4 + 4;
                        }

                        return _offset_FileName;
                    }
                }

                /// <summary>
                /// Retrieves the ImageBase field.
                /// </summary>
                public ulong ImageBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ImageBase..Offset_ImageSize]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ImageBase..Offset_ImageSize]);

                /// <summary>
                /// Retrieves the ImageSize field.
                /// </summary>
                public ulong ImageSize => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ImageSize..Offset_ProcessId]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ImageSize..Offset_ProcessId]);

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..Offset_ImageChecksum]);

                /// <summary>
                /// Retrieves the ImageChecksum field.
                /// </summary>
                public uint ImageChecksum => BitConverter.ToUInt32(_etwEvent.Data[Offset_ImageChecksum..Offset_TimeDateStamp]);

                /// <summary>
                /// Retrieves the TimeDateStamp field.
                /// </summary>
                public uint TimeDateStamp => BitConverter.ToUInt32(_etwEvent.Data[Offset_TimeDateStamp..Offset_Reserved0]);

                /// <summary>
                /// Retrieves the Reserved0 field.
                /// </summary>
                public uint Reserved0 => BitConverter.ToUInt32(_etwEvent.Data[Offset_Reserved0..Offset_DefaultBase]);

                /// <summary>
                /// Retrieves the DefaultBase field.
                /// </summary>
                public ulong DefaultBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_DefaultBase..Offset_Reserved1]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_DefaultBase..Offset_Reserved1]);

                /// <summary>
                /// Retrieves the Reserved1 field.
                /// </summary>
                public uint Reserved1 => BitConverter.ToUInt32(_etwEvent.Data[Offset_Reserved1..Offset_Reserved2]);

                /// <summary>
                /// Retrieves the Reserved2 field.
                /// </summary>
                public uint Reserved2 => BitConverter.ToUInt32(_etwEvent.Data[Offset_Reserved2..Offset_Reserved3]);

                /// <summary>
                /// Retrieves the Reserved3 field.
                /// </summary>
                public uint Reserved3 => BitConverter.ToUInt32(_etwEvent.Data[Offset_Reserved3..Offset_Reserved4]);

                /// <summary>
                /// Retrieves the Reserved4 field.
                /// </summary>
                public uint Reserved4 => BitConverter.ToUInt32(_etwEvent.Data[Offset_Reserved4..Offset_FileName]);

                /// <summary>
                /// Retrieves the FileName field.
                /// </summary>
                public string FileName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FileName..]);

                /// <summary>
                /// Creates a new DCEndData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DCEndData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ImageBase = -1;
                    _offset_ImageSize = -1;
                    _offset_ProcessId = -1;
                    _offset_ImageChecksum = -1;
                    _offset_TimeDateStamp = -1;
                    _offset_Reserved0 = -1;
                    _offset_DefaultBase = -1;
                    _offset_Reserved1 = -1;
                    _offset_Reserved2 = -1;
                    _offset_Reserved3 = -1;
                    _offset_Reserved4 = -1;
                    _offset_FileName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a HypercallPage event.
        /// </summary>
        public readonly ref struct HypercallPageEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "HypercallPage";

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
                Opcode = (EtwEventOpcode)Opcodes.HypercallPage,
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
            public HypercallPageData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new HypercallPageEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public HypercallPageEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a HypercallPageEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator HypercallPageEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a HypercallPage event.
            /// </summary>
            public ref struct HypercallPageData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_HypercallPageVa;

                private int Offset_HypercallPageVa
                {
                    get
                    {
                        if (_offset_HypercallPageVa == -1)
                        {
                            _offset_HypercallPageVa = 0;
                        }

                        return _offset_HypercallPageVa;
                    }
                }

                /// <summary>
                /// Retrieves the HypercallPageVa field.
                /// </summary>
                public ulong HypercallPageVa => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_HypercallPageVa..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_HypercallPageVa..]);

                /// <summary>
                /// Creates a new HypercallPageData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public HypercallPageData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_HypercallPageVa = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Load event.
        /// </summary>
        public readonly ref struct LoadEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Load";

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
                Opcode = (EtwEventOpcode)Opcodes.Load,
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
            public LoadData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new LoadEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public LoadEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a LoadEventV3.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator LoadEventV3(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Load event.
            /// </summary>
            public ref struct LoadData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ImageBase;
                private int _offset_ImageSize;
                private int _offset_ProcessId;
                private int _offset_ImageChecksum;
                private int _offset_TimeDateStamp;
                private int _offset_SignatureLevel;
                private int _offset_SignatureType;
                private int _offset_Reserved0;
                private int _offset_DefaultBase;
                private int _offset_Reserved1;
                private int _offset_Reserved2;
                private int _offset_Reserved3;
                private int _offset_Reserved4;
                private int _offset_FileName;

                private int Offset_ImageBase
                {
                    get
                    {
                        if (_offset_ImageBase == -1)
                        {
                            _offset_ImageBase = 0;
                        }

                        return _offset_ImageBase;
                    }
                }

                private int Offset_ImageSize
                {
                    get
                    {
                        if (_offset_ImageSize == -1)
                        {
                            _offset_ImageSize = Offset_ImageBase + _etwEvent.AddressSize;
                        }

                        return _offset_ImageSize;
                    }
                }

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = Offset_ImageSize + _etwEvent.AddressSize;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_ImageChecksum
                {
                    get
                    {
                        if (_offset_ImageChecksum == -1)
                        {
                            _offset_ImageChecksum = Offset_ProcessId + 4;
                        }

                        return _offset_ImageChecksum;
                    }
                }

                private int Offset_TimeDateStamp
                {
                    get
                    {
                        if (_offset_TimeDateStamp == -1)
                        {
                            _offset_TimeDateStamp = Offset_ImageChecksum + 4;
                        }

                        return _offset_TimeDateStamp;
                    }
                }

                private int Offset_SignatureLevel
                {
                    get
                    {
                        if (_offset_SignatureLevel == -1)
                        {
                            _offset_SignatureLevel = Offset_TimeDateStamp + 4;
                        }

                        return _offset_SignatureLevel;
                    }
                }

                private int Offset_SignatureType
                {
                    get
                    {
                        if (_offset_SignatureType == -1)
                        {
                            _offset_SignatureType = Offset_SignatureLevel + 1;
                        }

                        return _offset_SignatureType;
                    }
                }

                private int Offset_Reserved0
                {
                    get
                    {
                        if (_offset_Reserved0 == -1)
                        {
                            _offset_Reserved0 = Offset_SignatureType + 1;
                        }

                        return _offset_Reserved0;
                    }
                }

                private int Offset_DefaultBase
                {
                    get
                    {
                        if (_offset_DefaultBase == -1)
                        {
                            _offset_DefaultBase = Offset_Reserved0 + 2;
                        }

                        return _offset_DefaultBase;
                    }
                }

                private int Offset_Reserved1
                {
                    get
                    {
                        if (_offset_Reserved1 == -1)
                        {
                            _offset_Reserved1 = Offset_DefaultBase + _etwEvent.AddressSize;
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
                            _offset_Reserved2 = Offset_Reserved1 + 4;
                        }

                        return _offset_Reserved2;
                    }
                }

                private int Offset_Reserved3
                {
                    get
                    {
                        if (_offset_Reserved3 == -1)
                        {
                            _offset_Reserved3 = Offset_Reserved2 + 4;
                        }

                        return _offset_Reserved3;
                    }
                }

                private int Offset_Reserved4
                {
                    get
                    {
                        if (_offset_Reserved4 == -1)
                        {
                            _offset_Reserved4 = Offset_Reserved3 + 4;
                        }

                        return _offset_Reserved4;
                    }
                }

                private int Offset_FileName
                {
                    get
                    {
                        if (_offset_FileName == -1)
                        {
                            _offset_FileName = Offset_Reserved4 + 4;
                        }

                        return _offset_FileName;
                    }
                }

                /// <summary>
                /// Retrieves the ImageBase field.
                /// </summary>
                public ulong ImageBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ImageBase..Offset_ImageSize]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ImageBase..Offset_ImageSize]);

                /// <summary>
                /// Retrieves the ImageSize field.
                /// </summary>
                public ulong ImageSize => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ImageSize..Offset_ProcessId]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ImageSize..Offset_ProcessId]);

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..Offset_ImageChecksum]);

                /// <summary>
                /// Retrieves the ImageChecksum field.
                /// </summary>
                public uint ImageChecksum => BitConverter.ToUInt32(_etwEvent.Data[Offset_ImageChecksum..Offset_TimeDateStamp]);

                /// <summary>
                /// Retrieves the TimeDateStamp field.
                /// </summary>
                public uint TimeDateStamp => BitConverter.ToUInt32(_etwEvent.Data[Offset_TimeDateStamp..Offset_SignatureLevel]);

                /// <summary>
                /// Retrieves the SignatureLevel field.
                /// </summary>
                public byte SignatureLevel => _etwEvent.Data[Offset_SignatureLevel];

                /// <summary>
                /// Retrieves the SignatureType field.
                /// </summary>
                public byte SignatureType => _etwEvent.Data[Offset_SignatureType];

                /// <summary>
                /// Retrieves the Reserved0 field.
                /// </summary>
                public ushort Reserved0 => BitConverter.ToUInt16(_etwEvent.Data[Offset_Reserved0..Offset_DefaultBase]);

                /// <summary>
                /// Retrieves the DefaultBase field.
                /// </summary>
                public ulong DefaultBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_DefaultBase..Offset_Reserved1]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_DefaultBase..Offset_Reserved1]);

                /// <summary>
                /// Retrieves the Reserved1 field.
                /// </summary>
                public uint Reserved1 => BitConverter.ToUInt32(_etwEvent.Data[Offset_Reserved1..Offset_Reserved2]);

                /// <summary>
                /// Retrieves the Reserved2 field.
                /// </summary>
                public uint Reserved2 => BitConverter.ToUInt32(_etwEvent.Data[Offset_Reserved2..Offset_Reserved3]);

                /// <summary>
                /// Retrieves the Reserved3 field.
                /// </summary>
                public uint Reserved3 => BitConverter.ToUInt32(_etwEvent.Data[Offset_Reserved3..Offset_Reserved4]);

                /// <summary>
                /// Retrieves the Reserved4 field.
                /// </summary>
                public uint Reserved4 => BitConverter.ToUInt32(_etwEvent.Data[Offset_Reserved4..Offset_FileName]);

                /// <summary>
                /// Retrieves the FileName field.
                /// </summary>
                public string FileName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FileName..]);

                /// <summary>
                /// Creates a new LoadData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public LoadData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ImageBase = -1;
                    _offset_ImageSize = -1;
                    _offset_ProcessId = -1;
                    _offset_ImageChecksum = -1;
                    _offset_TimeDateStamp = -1;
                    _offset_SignatureLevel = -1;
                    _offset_SignatureType = -1;
                    _offset_Reserved0 = -1;
                    _offset_DefaultBase = -1;
                    _offset_Reserved1 = -1;
                    _offset_Reserved2 = -1;
                    _offset_Reserved3 = -1;
                    _offset_Reserved4 = -1;
                    _offset_FileName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a UnLoad event.
        /// </summary>
        public readonly ref struct UnLoadEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "UnLoad";

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
            public UnLoadData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new UnLoadEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public UnLoadEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a UnLoadEventV3.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator UnLoadEventV3(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a UnLoad event.
            /// </summary>
            public ref struct UnLoadData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ImageBase;
                private int _offset_ImageSize;
                private int _offset_ProcessId;
                private int _offset_ImageChecksum;
                private int _offset_TimeDateStamp;
                private int _offset_SignatureLevel;
                private int _offset_SignatureType;
                private int _offset_Reserved0;
                private int _offset_DefaultBase;
                private int _offset_Reserved1;
                private int _offset_Reserved2;
                private int _offset_Reserved3;
                private int _offset_Reserved4;
                private int _offset_FileName;

                private int Offset_ImageBase
                {
                    get
                    {
                        if (_offset_ImageBase == -1)
                        {
                            _offset_ImageBase = 0;
                        }

                        return _offset_ImageBase;
                    }
                }

                private int Offset_ImageSize
                {
                    get
                    {
                        if (_offset_ImageSize == -1)
                        {
                            _offset_ImageSize = Offset_ImageBase + _etwEvent.AddressSize;
                        }

                        return _offset_ImageSize;
                    }
                }

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = Offset_ImageSize + _etwEvent.AddressSize;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_ImageChecksum
                {
                    get
                    {
                        if (_offset_ImageChecksum == -1)
                        {
                            _offset_ImageChecksum = Offset_ProcessId + 4;
                        }

                        return _offset_ImageChecksum;
                    }
                }

                private int Offset_TimeDateStamp
                {
                    get
                    {
                        if (_offset_TimeDateStamp == -1)
                        {
                            _offset_TimeDateStamp = Offset_ImageChecksum + 4;
                        }

                        return _offset_TimeDateStamp;
                    }
                }

                private int Offset_SignatureLevel
                {
                    get
                    {
                        if (_offset_SignatureLevel == -1)
                        {
                            _offset_SignatureLevel = Offset_TimeDateStamp + 4;
                        }

                        return _offset_SignatureLevel;
                    }
                }

                private int Offset_SignatureType
                {
                    get
                    {
                        if (_offset_SignatureType == -1)
                        {
                            _offset_SignatureType = Offset_SignatureLevel + 1;
                        }

                        return _offset_SignatureType;
                    }
                }

                private int Offset_Reserved0
                {
                    get
                    {
                        if (_offset_Reserved0 == -1)
                        {
                            _offset_Reserved0 = Offset_SignatureType + 1;
                        }

                        return _offset_Reserved0;
                    }
                }

                private int Offset_DefaultBase
                {
                    get
                    {
                        if (_offset_DefaultBase == -1)
                        {
                            _offset_DefaultBase = Offset_Reserved0 + 2;
                        }

                        return _offset_DefaultBase;
                    }
                }

                private int Offset_Reserved1
                {
                    get
                    {
                        if (_offset_Reserved1 == -1)
                        {
                            _offset_Reserved1 = Offset_DefaultBase + _etwEvent.AddressSize;
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
                            _offset_Reserved2 = Offset_Reserved1 + 4;
                        }

                        return _offset_Reserved2;
                    }
                }

                private int Offset_Reserved3
                {
                    get
                    {
                        if (_offset_Reserved3 == -1)
                        {
                            _offset_Reserved3 = Offset_Reserved2 + 4;
                        }

                        return _offset_Reserved3;
                    }
                }

                private int Offset_Reserved4
                {
                    get
                    {
                        if (_offset_Reserved4 == -1)
                        {
                            _offset_Reserved4 = Offset_Reserved3 + 4;
                        }

                        return _offset_Reserved4;
                    }
                }

                private int Offset_FileName
                {
                    get
                    {
                        if (_offset_FileName == -1)
                        {
                            _offset_FileName = Offset_Reserved4 + 4;
                        }

                        return _offset_FileName;
                    }
                }

                /// <summary>
                /// Retrieves the ImageBase field.
                /// </summary>
                public ulong ImageBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ImageBase..Offset_ImageSize]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ImageBase..Offset_ImageSize]);

                /// <summary>
                /// Retrieves the ImageSize field.
                /// </summary>
                public ulong ImageSize => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ImageSize..Offset_ProcessId]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ImageSize..Offset_ProcessId]);

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..Offset_ImageChecksum]);

                /// <summary>
                /// Retrieves the ImageChecksum field.
                /// </summary>
                public uint ImageChecksum => BitConverter.ToUInt32(_etwEvent.Data[Offset_ImageChecksum..Offset_TimeDateStamp]);

                /// <summary>
                /// Retrieves the TimeDateStamp field.
                /// </summary>
                public uint TimeDateStamp => BitConverter.ToUInt32(_etwEvent.Data[Offset_TimeDateStamp..Offset_SignatureLevel]);

                /// <summary>
                /// Retrieves the SignatureLevel field.
                /// </summary>
                public byte SignatureLevel => _etwEvent.Data[Offset_SignatureLevel];

                /// <summary>
                /// Retrieves the SignatureType field.
                /// </summary>
                public byte SignatureType => _etwEvent.Data[Offset_SignatureType];

                /// <summary>
                /// Retrieves the Reserved0 field.
                /// </summary>
                public ushort Reserved0 => BitConverter.ToUInt16(_etwEvent.Data[Offset_Reserved0..Offset_DefaultBase]);

                /// <summary>
                /// Retrieves the DefaultBase field.
                /// </summary>
                public ulong DefaultBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_DefaultBase..Offset_Reserved1]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_DefaultBase..Offset_Reserved1]);

                /// <summary>
                /// Retrieves the Reserved1 field.
                /// </summary>
                public uint Reserved1 => BitConverter.ToUInt32(_etwEvent.Data[Offset_Reserved1..Offset_Reserved2]);

                /// <summary>
                /// Retrieves the Reserved2 field.
                /// </summary>
                public uint Reserved2 => BitConverter.ToUInt32(_etwEvent.Data[Offset_Reserved2..Offset_Reserved3]);

                /// <summary>
                /// Retrieves the Reserved3 field.
                /// </summary>
                public uint Reserved3 => BitConverter.ToUInt32(_etwEvent.Data[Offset_Reserved3..Offset_Reserved4]);

                /// <summary>
                /// Retrieves the Reserved4 field.
                /// </summary>
                public uint Reserved4 => BitConverter.ToUInt32(_etwEvent.Data[Offset_Reserved4..Offset_FileName]);

                /// <summary>
                /// Retrieves the FileName field.
                /// </summary>
                public string FileName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FileName..]);

                /// <summary>
                /// Creates a new UnLoadData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public UnLoadData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ImageBase = -1;
                    _offset_ImageSize = -1;
                    _offset_ProcessId = -1;
                    _offset_ImageChecksum = -1;
                    _offset_TimeDateStamp = -1;
                    _offset_SignatureLevel = -1;
                    _offset_SignatureType = -1;
                    _offset_Reserved0 = -1;
                    _offset_DefaultBase = -1;
                    _offset_Reserved1 = -1;
                    _offset_Reserved2 = -1;
                    _offset_Reserved3 = -1;
                    _offset_Reserved4 = -1;
                    _offset_FileName = -1;
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
            /// Converts a generic ETW event to a DCStartEventV3.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator DCStartEventV3(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a DCStart event.
            /// </summary>
            public ref struct DCStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ImageBase;
                private int _offset_ImageSize;
                private int _offset_ProcessId;
                private int _offset_ImageChecksum;
                private int _offset_TimeDateStamp;
                private int _offset_SignatureLevel;
                private int _offset_SignatureType;
                private int _offset_Reserved0;
                private int _offset_DefaultBase;
                private int _offset_Reserved1;
                private int _offset_Reserved2;
                private int _offset_Reserved3;
                private int _offset_Reserved4;
                private int _offset_FileName;

                private int Offset_ImageBase
                {
                    get
                    {
                        if (_offset_ImageBase == -1)
                        {
                            _offset_ImageBase = 0;
                        }

                        return _offset_ImageBase;
                    }
                }

                private int Offset_ImageSize
                {
                    get
                    {
                        if (_offset_ImageSize == -1)
                        {
                            _offset_ImageSize = Offset_ImageBase + _etwEvent.AddressSize;
                        }

                        return _offset_ImageSize;
                    }
                }

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = Offset_ImageSize + _etwEvent.AddressSize;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_ImageChecksum
                {
                    get
                    {
                        if (_offset_ImageChecksum == -1)
                        {
                            _offset_ImageChecksum = Offset_ProcessId + 4;
                        }

                        return _offset_ImageChecksum;
                    }
                }

                private int Offset_TimeDateStamp
                {
                    get
                    {
                        if (_offset_TimeDateStamp == -1)
                        {
                            _offset_TimeDateStamp = Offset_ImageChecksum + 4;
                        }

                        return _offset_TimeDateStamp;
                    }
                }

                private int Offset_SignatureLevel
                {
                    get
                    {
                        if (_offset_SignatureLevel == -1)
                        {
                            _offset_SignatureLevel = Offset_TimeDateStamp + 4;
                        }

                        return _offset_SignatureLevel;
                    }
                }

                private int Offset_SignatureType
                {
                    get
                    {
                        if (_offset_SignatureType == -1)
                        {
                            _offset_SignatureType = Offset_SignatureLevel + 1;
                        }

                        return _offset_SignatureType;
                    }
                }

                private int Offset_Reserved0
                {
                    get
                    {
                        if (_offset_Reserved0 == -1)
                        {
                            _offset_Reserved0 = Offset_SignatureType + 1;
                        }

                        return _offset_Reserved0;
                    }
                }

                private int Offset_DefaultBase
                {
                    get
                    {
                        if (_offset_DefaultBase == -1)
                        {
                            _offset_DefaultBase = Offset_Reserved0 + 2;
                        }

                        return _offset_DefaultBase;
                    }
                }

                private int Offset_Reserved1
                {
                    get
                    {
                        if (_offset_Reserved1 == -1)
                        {
                            _offset_Reserved1 = Offset_DefaultBase + _etwEvent.AddressSize;
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
                            _offset_Reserved2 = Offset_Reserved1 + 4;
                        }

                        return _offset_Reserved2;
                    }
                }

                private int Offset_Reserved3
                {
                    get
                    {
                        if (_offset_Reserved3 == -1)
                        {
                            _offset_Reserved3 = Offset_Reserved2 + 4;
                        }

                        return _offset_Reserved3;
                    }
                }

                private int Offset_Reserved4
                {
                    get
                    {
                        if (_offset_Reserved4 == -1)
                        {
                            _offset_Reserved4 = Offset_Reserved3 + 4;
                        }

                        return _offset_Reserved4;
                    }
                }

                private int Offset_FileName
                {
                    get
                    {
                        if (_offset_FileName == -1)
                        {
                            _offset_FileName = Offset_Reserved4 + 4;
                        }

                        return _offset_FileName;
                    }
                }

                /// <summary>
                /// Retrieves the ImageBase field.
                /// </summary>
                public ulong ImageBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ImageBase..Offset_ImageSize]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ImageBase..Offset_ImageSize]);

                /// <summary>
                /// Retrieves the ImageSize field.
                /// </summary>
                public ulong ImageSize => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ImageSize..Offset_ProcessId]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ImageSize..Offset_ProcessId]);

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..Offset_ImageChecksum]);

                /// <summary>
                /// Retrieves the ImageChecksum field.
                /// </summary>
                public uint ImageChecksum => BitConverter.ToUInt32(_etwEvent.Data[Offset_ImageChecksum..Offset_TimeDateStamp]);

                /// <summary>
                /// Retrieves the TimeDateStamp field.
                /// </summary>
                public uint TimeDateStamp => BitConverter.ToUInt32(_etwEvent.Data[Offset_TimeDateStamp..Offset_SignatureLevel]);

                /// <summary>
                /// Retrieves the SignatureLevel field.
                /// </summary>
                public byte SignatureLevel => _etwEvent.Data[Offset_SignatureLevel];

                /// <summary>
                /// Retrieves the SignatureType field.
                /// </summary>
                public byte SignatureType => _etwEvent.Data[Offset_SignatureType];

                /// <summary>
                /// Retrieves the Reserved0 field.
                /// </summary>
                public ushort Reserved0 => BitConverter.ToUInt16(_etwEvent.Data[Offset_Reserved0..Offset_DefaultBase]);

                /// <summary>
                /// Retrieves the DefaultBase field.
                /// </summary>
                public ulong DefaultBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_DefaultBase..Offset_Reserved1]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_DefaultBase..Offset_Reserved1]);

                /// <summary>
                /// Retrieves the Reserved1 field.
                /// </summary>
                public uint Reserved1 => BitConverter.ToUInt32(_etwEvent.Data[Offset_Reserved1..Offset_Reserved2]);

                /// <summary>
                /// Retrieves the Reserved2 field.
                /// </summary>
                public uint Reserved2 => BitConverter.ToUInt32(_etwEvent.Data[Offset_Reserved2..Offset_Reserved3]);

                /// <summary>
                /// Retrieves the Reserved3 field.
                /// </summary>
                public uint Reserved3 => BitConverter.ToUInt32(_etwEvent.Data[Offset_Reserved3..Offset_Reserved4]);

                /// <summary>
                /// Retrieves the Reserved4 field.
                /// </summary>
                public uint Reserved4 => BitConverter.ToUInt32(_etwEvent.Data[Offset_Reserved4..Offset_FileName]);

                /// <summary>
                /// Retrieves the FileName field.
                /// </summary>
                public string FileName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FileName..]);

                /// <summary>
                /// Creates a new DCStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DCStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ImageBase = -1;
                    _offset_ImageSize = -1;
                    _offset_ProcessId = -1;
                    _offset_ImageChecksum = -1;
                    _offset_TimeDateStamp = -1;
                    _offset_SignatureLevel = -1;
                    _offset_SignatureType = -1;
                    _offset_Reserved0 = -1;
                    _offset_DefaultBase = -1;
                    _offset_Reserved1 = -1;
                    _offset_Reserved2 = -1;
                    _offset_Reserved3 = -1;
                    _offset_Reserved4 = -1;
                    _offset_FileName = -1;
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
            /// Converts a generic ETW event to a DCEndEventV3.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator DCEndEventV3(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a DCEnd event.
            /// </summary>
            public ref struct DCEndData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ImageBase;
                private int _offset_ImageSize;
                private int _offset_ProcessId;
                private int _offset_ImageChecksum;
                private int _offset_TimeDateStamp;
                private int _offset_SignatureLevel;
                private int _offset_SignatureType;
                private int _offset_Reserved0;
                private int _offset_DefaultBase;
                private int _offset_Reserved1;
                private int _offset_Reserved2;
                private int _offset_Reserved3;
                private int _offset_Reserved4;
                private int _offset_FileName;

                private int Offset_ImageBase
                {
                    get
                    {
                        if (_offset_ImageBase == -1)
                        {
                            _offset_ImageBase = 0;
                        }

                        return _offset_ImageBase;
                    }
                }

                private int Offset_ImageSize
                {
                    get
                    {
                        if (_offset_ImageSize == -1)
                        {
                            _offset_ImageSize = Offset_ImageBase + _etwEvent.AddressSize;
                        }

                        return _offset_ImageSize;
                    }
                }

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = Offset_ImageSize + _etwEvent.AddressSize;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_ImageChecksum
                {
                    get
                    {
                        if (_offset_ImageChecksum == -1)
                        {
                            _offset_ImageChecksum = Offset_ProcessId + 4;
                        }

                        return _offset_ImageChecksum;
                    }
                }

                private int Offset_TimeDateStamp
                {
                    get
                    {
                        if (_offset_TimeDateStamp == -1)
                        {
                            _offset_TimeDateStamp = Offset_ImageChecksum + 4;
                        }

                        return _offset_TimeDateStamp;
                    }
                }

                private int Offset_SignatureLevel
                {
                    get
                    {
                        if (_offset_SignatureLevel == -1)
                        {
                            _offset_SignatureLevel = Offset_TimeDateStamp + 4;
                        }

                        return _offset_SignatureLevel;
                    }
                }

                private int Offset_SignatureType
                {
                    get
                    {
                        if (_offset_SignatureType == -1)
                        {
                            _offset_SignatureType = Offset_SignatureLevel + 1;
                        }

                        return _offset_SignatureType;
                    }
                }

                private int Offset_Reserved0
                {
                    get
                    {
                        if (_offset_Reserved0 == -1)
                        {
                            _offset_Reserved0 = Offset_SignatureType + 1;
                        }

                        return _offset_Reserved0;
                    }
                }

                private int Offset_DefaultBase
                {
                    get
                    {
                        if (_offset_DefaultBase == -1)
                        {
                            _offset_DefaultBase = Offset_Reserved0 + 2;
                        }

                        return _offset_DefaultBase;
                    }
                }

                private int Offset_Reserved1
                {
                    get
                    {
                        if (_offset_Reserved1 == -1)
                        {
                            _offset_Reserved1 = Offset_DefaultBase + _etwEvent.AddressSize;
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
                            _offset_Reserved2 = Offset_Reserved1 + 4;
                        }

                        return _offset_Reserved2;
                    }
                }

                private int Offset_Reserved3
                {
                    get
                    {
                        if (_offset_Reserved3 == -1)
                        {
                            _offset_Reserved3 = Offset_Reserved2 + 4;
                        }

                        return _offset_Reserved3;
                    }
                }

                private int Offset_Reserved4
                {
                    get
                    {
                        if (_offset_Reserved4 == -1)
                        {
                            _offset_Reserved4 = Offset_Reserved3 + 4;
                        }

                        return _offset_Reserved4;
                    }
                }

                private int Offset_FileName
                {
                    get
                    {
                        if (_offset_FileName == -1)
                        {
                            _offset_FileName = Offset_Reserved4 + 4;
                        }

                        return _offset_FileName;
                    }
                }

                /// <summary>
                /// Retrieves the ImageBase field.
                /// </summary>
                public ulong ImageBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ImageBase..Offset_ImageSize]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ImageBase..Offset_ImageSize]);

                /// <summary>
                /// Retrieves the ImageSize field.
                /// </summary>
                public ulong ImageSize => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ImageSize..Offset_ProcessId]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ImageSize..Offset_ProcessId]);

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..Offset_ImageChecksum]);

                /// <summary>
                /// Retrieves the ImageChecksum field.
                /// </summary>
                public uint ImageChecksum => BitConverter.ToUInt32(_etwEvent.Data[Offset_ImageChecksum..Offset_TimeDateStamp]);

                /// <summary>
                /// Retrieves the TimeDateStamp field.
                /// </summary>
                public uint TimeDateStamp => BitConverter.ToUInt32(_etwEvent.Data[Offset_TimeDateStamp..Offset_SignatureLevel]);

                /// <summary>
                /// Retrieves the SignatureLevel field.
                /// </summary>
                public byte SignatureLevel => _etwEvent.Data[Offset_SignatureLevel];

                /// <summary>
                /// Retrieves the SignatureType field.
                /// </summary>
                public byte SignatureType => _etwEvent.Data[Offset_SignatureType];

                /// <summary>
                /// Retrieves the Reserved0 field.
                /// </summary>
                public ushort Reserved0 => BitConverter.ToUInt16(_etwEvent.Data[Offset_Reserved0..Offset_DefaultBase]);

                /// <summary>
                /// Retrieves the DefaultBase field.
                /// </summary>
                public ulong DefaultBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_DefaultBase..Offset_Reserved1]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_DefaultBase..Offset_Reserved1]);

                /// <summary>
                /// Retrieves the Reserved1 field.
                /// </summary>
                public uint Reserved1 => BitConverter.ToUInt32(_etwEvent.Data[Offset_Reserved1..Offset_Reserved2]);

                /// <summary>
                /// Retrieves the Reserved2 field.
                /// </summary>
                public uint Reserved2 => BitConverter.ToUInt32(_etwEvent.Data[Offset_Reserved2..Offset_Reserved3]);

                /// <summary>
                /// Retrieves the Reserved3 field.
                /// </summary>
                public uint Reserved3 => BitConverter.ToUInt32(_etwEvent.Data[Offset_Reserved3..Offset_Reserved4]);

                /// <summary>
                /// Retrieves the Reserved4 field.
                /// </summary>
                public uint Reserved4 => BitConverter.ToUInt32(_etwEvent.Data[Offset_Reserved4..Offset_FileName]);

                /// <summary>
                /// Retrieves the FileName field.
                /// </summary>
                public string FileName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FileName..]);

                /// <summary>
                /// Creates a new DCEndData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DCEndData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ImageBase = -1;
                    _offset_ImageSize = -1;
                    _offset_ProcessId = -1;
                    _offset_ImageChecksum = -1;
                    _offset_TimeDateStamp = -1;
                    _offset_SignatureLevel = -1;
                    _offset_SignatureType = -1;
                    _offset_Reserved0 = -1;
                    _offset_DefaultBase = -1;
                    _offset_Reserved1 = -1;
                    _offset_Reserved2 = -1;
                    _offset_Reserved3 = -1;
                    _offset_Reserved4 = -1;
                    _offset_FileName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a MapViewStart event.
        /// </summary>
        public readonly ref struct MapViewStartEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "MapViewStart";

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
                Opcode = (EtwEventOpcode)Opcodes.MapViewStart,
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
            public MapViewStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new MapViewStartEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public MapViewStartEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a MapViewStartEventV3.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator MapViewStartEventV3(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a MapViewStart event.
            /// </summary>
            public ref struct MapViewStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_BaseAddress;
                private int _offset_ErrorOpcode;
                private int _offset_Code;
                private int _offset_String;

                private int Offset_BaseAddress
                {
                    get
                    {
                        if (_offset_BaseAddress == -1)
                        {
                            _offset_BaseAddress = 0;
                        }

                        return _offset_BaseAddress;
                    }
                }

                private int Offset_ErrorOpcode
                {
                    get
                    {
                        if (_offset_ErrorOpcode == -1)
                        {
                            _offset_ErrorOpcode = Offset_BaseAddress + 8;
                        }

                        return _offset_ErrorOpcode;
                    }
                }

                private int Offset_Code
                {
                    get
                    {
                        if (_offset_Code == -1)
                        {
                            _offset_Code = Offset_ErrorOpcode + 1;
                        }

                        return _offset_Code;
                    }
                }

                private int Offset_String
                {
                    get
                    {
                        if (_offset_String == -1)
                        {
                            _offset_String = Offset_Code + 1;
                        }

                        return _offset_String;
                    }
                }

                /// <summary>
                /// Retrieves the BaseAddress field.
                /// </summary>
                public ulong BaseAddress => BitConverter.ToUInt64(_etwEvent.Data[Offset_BaseAddress..Offset_ErrorOpcode]);

                /// <summary>
                /// Retrieves the ErrorOpcode field.
                /// </summary>
                public byte ErrorOpcode => _etwEvent.Data[Offset_ErrorOpcode];

                /// <summary>
                /// Retrieves the Code field.
                /// </summary>
                public sbyte Code => (sbyte)_etwEvent.Data[Offset_Code];

                /// <summary>
                /// Retrieves the String field.
                /// </summary>
                public string String => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_String..]);

                /// <summary>
                /// Creates a new MapViewStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public MapViewStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_BaseAddress = -1;
                    _offset_ErrorOpcode = -1;
                    _offset_Code = -1;
                    _offset_String = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a SnappingStart event.
        /// </summary>
        public readonly ref struct SnappingStartEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SnappingStart";

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
                Opcode = (EtwEventOpcode)Opcodes.SnappingStart,
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
            public SnappingStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new SnappingStartEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SnappingStartEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a SnappingStartEventV3.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator SnappingStartEventV3(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a SnappingStart event.
            /// </summary>
            public ref struct SnappingStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_BaseAddress;
                private int _offset_ErrorOpcode;
                private int _offset_Code;
                private int _offset_String;

                private int Offset_BaseAddress
                {
                    get
                    {
                        if (_offset_BaseAddress == -1)
                        {
                            _offset_BaseAddress = 0;
                        }

                        return _offset_BaseAddress;
                    }
                }

                private int Offset_ErrorOpcode
                {
                    get
                    {
                        if (_offset_ErrorOpcode == -1)
                        {
                            _offset_ErrorOpcode = Offset_BaseAddress + 8;
                        }

                        return _offset_ErrorOpcode;
                    }
                }

                private int Offset_Code
                {
                    get
                    {
                        if (_offset_Code == -1)
                        {
                            _offset_Code = Offset_ErrorOpcode + 1;
                        }

                        return _offset_Code;
                    }
                }

                private int Offset_String
                {
                    get
                    {
                        if (_offset_String == -1)
                        {
                            _offset_String = Offset_Code + 1;
                        }

                        return _offset_String;
                    }
                }

                /// <summary>
                /// Retrieves the BaseAddress field.
                /// </summary>
                public ulong BaseAddress => BitConverter.ToUInt64(_etwEvent.Data[Offset_BaseAddress..Offset_ErrorOpcode]);

                /// <summary>
                /// Retrieves the ErrorOpcode field.
                /// </summary>
                public byte ErrorOpcode => _etwEvent.Data[Offset_ErrorOpcode];

                /// <summary>
                /// Retrieves the Code field.
                /// </summary>
                public sbyte Code => (sbyte)_etwEvent.Data[Offset_Code];

                /// <summary>
                /// Retrieves the String field.
                /// </summary>
                public string String => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_String..]);

                /// <summary>
                /// Creates a new SnappingStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public SnappingStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_BaseAddress = -1;
                    _offset_ErrorOpcode = -1;
                    _offset_Code = -1;
                    _offset_String = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a SnappingEnd event.
        /// </summary>
        public readonly ref struct SnappingEndEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SnappingEnd";

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
                Opcode = (EtwEventOpcode)Opcodes.SnappingEnd,
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
            public SnappingEndData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new SnappingEndEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SnappingEndEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a SnappingEndEventV3.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator SnappingEndEventV3(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a SnappingEnd event.
            /// </summary>
            public ref struct SnappingEndData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_BaseAddress;
                private int _offset_ErrorOpcode;
                private int _offset_Code;
                private int _offset_String;

                private int Offset_BaseAddress
                {
                    get
                    {
                        if (_offset_BaseAddress == -1)
                        {
                            _offset_BaseAddress = 0;
                        }

                        return _offset_BaseAddress;
                    }
                }

                private int Offset_ErrorOpcode
                {
                    get
                    {
                        if (_offset_ErrorOpcode == -1)
                        {
                            _offset_ErrorOpcode = Offset_BaseAddress + 8;
                        }

                        return _offset_ErrorOpcode;
                    }
                }

                private int Offset_Code
                {
                    get
                    {
                        if (_offset_Code == -1)
                        {
                            _offset_Code = Offset_ErrorOpcode + 1;
                        }

                        return _offset_Code;
                    }
                }

                private int Offset_String
                {
                    get
                    {
                        if (_offset_String == -1)
                        {
                            _offset_String = Offset_Code + 1;
                        }

                        return _offset_String;
                    }
                }

                /// <summary>
                /// Retrieves the BaseAddress field.
                /// </summary>
                public ulong BaseAddress => BitConverter.ToUInt64(_etwEvent.Data[Offset_BaseAddress..Offset_ErrorOpcode]);

                /// <summary>
                /// Retrieves the ErrorOpcode field.
                /// </summary>
                public byte ErrorOpcode => _etwEvent.Data[Offset_ErrorOpcode];

                /// <summary>
                /// Retrieves the Code field.
                /// </summary>
                public sbyte Code => (sbyte)_etwEvent.Data[Offset_Code];

                /// <summary>
                /// Retrieves the String field.
                /// </summary>
                public string String => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_String..]);

                /// <summary>
                /// Creates a new SnappingEndData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public SnappingEndData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_BaseAddress = -1;
                    _offset_ErrorOpcode = -1;
                    _offset_Code = -1;
                    _offset_String = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a LoadingStart event.
        /// </summary>
        public readonly ref struct LoadingStartEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "LoadingStart";

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
                Opcode = (EtwEventOpcode)Opcodes.LoadingStart,
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
            public LoadingStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new LoadingStartEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public LoadingStartEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a LoadingStartEventV3.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator LoadingStartEventV3(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a LoadingStart event.
            /// </summary>
            public ref struct LoadingStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_BaseAddress;
                private int _offset_ErrorOpcode;
                private int _offset_Code;
                private int _offset_String;

                private int Offset_BaseAddress
                {
                    get
                    {
                        if (_offset_BaseAddress == -1)
                        {
                            _offset_BaseAddress = 0;
                        }

                        return _offset_BaseAddress;
                    }
                }

                private int Offset_ErrorOpcode
                {
                    get
                    {
                        if (_offset_ErrorOpcode == -1)
                        {
                            _offset_ErrorOpcode = Offset_BaseAddress + 8;
                        }

                        return _offset_ErrorOpcode;
                    }
                }

                private int Offset_Code
                {
                    get
                    {
                        if (_offset_Code == -1)
                        {
                            _offset_Code = Offset_ErrorOpcode + 1;
                        }

                        return _offset_Code;
                    }
                }

                private int Offset_String
                {
                    get
                    {
                        if (_offset_String == -1)
                        {
                            _offset_String = Offset_Code + 1;
                        }

                        return _offset_String;
                    }
                }

                /// <summary>
                /// Retrieves the BaseAddress field.
                /// </summary>
                public ulong BaseAddress => BitConverter.ToUInt64(_etwEvent.Data[Offset_BaseAddress..Offset_ErrorOpcode]);

                /// <summary>
                /// Retrieves the ErrorOpcode field.
                /// </summary>
                public byte ErrorOpcode => _etwEvent.Data[Offset_ErrorOpcode];

                /// <summary>
                /// Retrieves the Code field.
                /// </summary>
                public sbyte Code => (sbyte)_etwEvent.Data[Offset_Code];

                /// <summary>
                /// Retrieves the String field.
                /// </summary>
                public string String => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_String..]);

                /// <summary>
                /// Creates a new LoadingStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public LoadingStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_BaseAddress = -1;
                    _offset_ErrorOpcode = -1;
                    _offset_Code = -1;
                    _offset_String = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a LoadingEnd event.
        /// </summary>
        public readonly ref struct LoadingEndEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "LoadingEnd";

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
                Opcode = (EtwEventOpcode)Opcodes.LoadingEnd,
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
            public LoadingEndData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new LoadingEndEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public LoadingEndEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a LoadingEndEventV3.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator LoadingEndEventV3(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a LoadingEnd event.
            /// </summary>
            public ref struct LoadingEndData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_BaseAddress;
                private int _offset_ErrorOpcode;
                private int _offset_Code;
                private int _offset_String;

                private int Offset_BaseAddress
                {
                    get
                    {
                        if (_offset_BaseAddress == -1)
                        {
                            _offset_BaseAddress = 0;
                        }

                        return _offset_BaseAddress;
                    }
                }

                private int Offset_ErrorOpcode
                {
                    get
                    {
                        if (_offset_ErrorOpcode == -1)
                        {
                            _offset_ErrorOpcode = Offset_BaseAddress + 8;
                        }

                        return _offset_ErrorOpcode;
                    }
                }

                private int Offset_Code
                {
                    get
                    {
                        if (_offset_Code == -1)
                        {
                            _offset_Code = Offset_ErrorOpcode + 1;
                        }

                        return _offset_Code;
                    }
                }

                private int Offset_String
                {
                    get
                    {
                        if (_offset_String == -1)
                        {
                            _offset_String = Offset_Code + 1;
                        }

                        return _offset_String;
                    }
                }

                /// <summary>
                /// Retrieves the BaseAddress field.
                /// </summary>
                public ulong BaseAddress => BitConverter.ToUInt64(_etwEvent.Data[Offset_BaseAddress..Offset_ErrorOpcode]);

                /// <summary>
                /// Retrieves the ErrorOpcode field.
                /// </summary>
                public byte ErrorOpcode => _etwEvent.Data[Offset_ErrorOpcode];

                /// <summary>
                /// Retrieves the Code field.
                /// </summary>
                public sbyte Code => (sbyte)_etwEvent.Data[Offset_Code];

                /// <summary>
                /// Retrieves the String field.
                /// </summary>
                public string String => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_String..]);

                /// <summary>
                /// Creates a new LoadingEndData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public LoadingEndData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_BaseAddress = -1;
                    _offset_ErrorOpcode = -1;
                    _offset_Code = -1;
                    _offset_String = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a FoundKnownDll event.
        /// </summary>
        public readonly ref struct FoundKnownDllEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "FoundKnownDll";

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
                Opcode = (EtwEventOpcode)Opcodes.FoundKnownDll,
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
            public FoundKnownDllData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new FoundKnownDllEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public FoundKnownDllEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a FoundKnownDllEventV3.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator FoundKnownDllEventV3(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a FoundKnownDll event.
            /// </summary>
            public ref struct FoundKnownDllData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_BaseAddress;
                private int _offset_ErrorOpcode;
                private int _offset_Code;
                private int _offset_String;

                private int Offset_BaseAddress
                {
                    get
                    {
                        if (_offset_BaseAddress == -1)
                        {
                            _offset_BaseAddress = 0;
                        }

                        return _offset_BaseAddress;
                    }
                }

                private int Offset_ErrorOpcode
                {
                    get
                    {
                        if (_offset_ErrorOpcode == -1)
                        {
                            _offset_ErrorOpcode = Offset_BaseAddress + 8;
                        }

                        return _offset_ErrorOpcode;
                    }
                }

                private int Offset_Code
                {
                    get
                    {
                        if (_offset_Code == -1)
                        {
                            _offset_Code = Offset_ErrorOpcode + 1;
                        }

                        return _offset_Code;
                    }
                }

                private int Offset_String
                {
                    get
                    {
                        if (_offset_String == -1)
                        {
                            _offset_String = Offset_Code + 1;
                        }

                        return _offset_String;
                    }
                }

                /// <summary>
                /// Retrieves the BaseAddress field.
                /// </summary>
                public ulong BaseAddress => BitConverter.ToUInt64(_etwEvent.Data[Offset_BaseAddress..Offset_ErrorOpcode]);

                /// <summary>
                /// Retrieves the ErrorOpcode field.
                /// </summary>
                public byte ErrorOpcode => _etwEvent.Data[Offset_ErrorOpcode];

                /// <summary>
                /// Retrieves the Code field.
                /// </summary>
                public sbyte Code => (sbyte)_etwEvent.Data[Offset_Code];

                /// <summary>
                /// Retrieves the String field.
                /// </summary>
                public string String => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_String..]);

                /// <summary>
                /// Creates a new FoundKnownDllData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public FoundKnownDllData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_BaseAddress = -1;
                    _offset_ErrorOpcode = -1;
                    _offset_Code = -1;
                    _offset_String = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a AbnormalTermination event.
        /// </summary>
        public readonly ref struct AbnormalTerminationEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "AbnormalTermination";

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
                Opcode = (EtwEventOpcode)Opcodes.AbnormalTermination,
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
            public AbnormalTerminationData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new AbnormalTerminationEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public AbnormalTerminationEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a AbnormalTerminationEventV3.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator AbnormalTerminationEventV3(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a AbnormalTermination event.
            /// </summary>
            public ref struct AbnormalTerminationData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_BaseAddress;
                private int _offset_ErrorOpcode;
                private int _offset_Code;
                private int _offset_String;

                private int Offset_BaseAddress
                {
                    get
                    {
                        if (_offset_BaseAddress == -1)
                        {
                            _offset_BaseAddress = 0;
                        }

                        return _offset_BaseAddress;
                    }
                }

                private int Offset_ErrorOpcode
                {
                    get
                    {
                        if (_offset_ErrorOpcode == -1)
                        {
                            _offset_ErrorOpcode = Offset_BaseAddress + 8;
                        }

                        return _offset_ErrorOpcode;
                    }
                }

                private int Offset_Code
                {
                    get
                    {
                        if (_offset_Code == -1)
                        {
                            _offset_Code = Offset_ErrorOpcode + 1;
                        }

                        return _offset_Code;
                    }
                }

                private int Offset_String
                {
                    get
                    {
                        if (_offset_String == -1)
                        {
                            _offset_String = Offset_Code + 1;
                        }

                        return _offset_String;
                    }
                }

                /// <summary>
                /// Retrieves the BaseAddress field.
                /// </summary>
                public ulong BaseAddress => BitConverter.ToUInt64(_etwEvent.Data[Offset_BaseAddress..Offset_ErrorOpcode]);

                /// <summary>
                /// Retrieves the ErrorOpcode field.
                /// </summary>
                public byte ErrorOpcode => _etwEvent.Data[Offset_ErrorOpcode];

                /// <summary>
                /// Retrieves the Code field.
                /// </summary>
                public sbyte Code => (sbyte)_etwEvent.Data[Offset_Code];

                /// <summary>
                /// Retrieves the String field.
                /// </summary>
                public string String => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_String..]);

                /// <summary>
                /// Creates a new AbnormalTerminationData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public AbnormalTerminationData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_BaseAddress = -1;
                    _offset_ErrorOpcode = -1;
                    _offset_Code = -1;
                    _offset_String = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ModulePlaceHolder event.
        /// </summary>
        public readonly ref struct ModulePlaceHolderEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ModulePlaceHolder";

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
                Opcode = (EtwEventOpcode)Opcodes.ModulePlaceHolder,
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
            public ModulePlaceHolderData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ModulePlaceHolderEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ModulePlaceHolderEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a ModulePlaceHolderEventV3.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator ModulePlaceHolderEventV3(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a ModulePlaceHolder event.
            /// </summary>
            public ref struct ModulePlaceHolderData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_BaseAddress;
                private int _offset_ErrorOpcode;
                private int _offset_Code;
                private int _offset_String;

                private int Offset_BaseAddress
                {
                    get
                    {
                        if (_offset_BaseAddress == -1)
                        {
                            _offset_BaseAddress = 0;
                        }

                        return _offset_BaseAddress;
                    }
                }

                private int Offset_ErrorOpcode
                {
                    get
                    {
                        if (_offset_ErrorOpcode == -1)
                        {
                            _offset_ErrorOpcode = Offset_BaseAddress + 8;
                        }

                        return _offset_ErrorOpcode;
                    }
                }

                private int Offset_Code
                {
                    get
                    {
                        if (_offset_Code == -1)
                        {
                            _offset_Code = Offset_ErrorOpcode + 1;
                        }

                        return _offset_Code;
                    }
                }

                private int Offset_String
                {
                    get
                    {
                        if (_offset_String == -1)
                        {
                            _offset_String = Offset_Code + 1;
                        }

                        return _offset_String;
                    }
                }

                /// <summary>
                /// Retrieves the BaseAddress field.
                /// </summary>
                public ulong BaseAddress => BitConverter.ToUInt64(_etwEvent.Data[Offset_BaseAddress..Offset_ErrorOpcode]);

                /// <summary>
                /// Retrieves the ErrorOpcode field.
                /// </summary>
                public byte ErrorOpcode => _etwEvent.Data[Offset_ErrorOpcode];

                /// <summary>
                /// Retrieves the Code field.
                /// </summary>
                public sbyte Code => (sbyte)_etwEvent.Data[Offset_Code];

                /// <summary>
                /// Retrieves the String field.
                /// </summary>
                public string String => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_String..]);

                /// <summary>
                /// Creates a new ModulePlaceHolderData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ModulePlaceHolderData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_BaseAddress = -1;
                    _offset_ErrorOpcode = -1;
                    _offset_Code = -1;
                    _offset_String = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ReadyToInit event.
        /// </summary>
        public readonly ref struct ReadyToInitEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ReadyToInit";

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
                Opcode = (EtwEventOpcode)Opcodes.ReadyToInit,
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
            public ReadyToInitData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ReadyToInitEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ReadyToInitEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a ReadyToInitEventV3.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator ReadyToInitEventV3(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a ReadyToInit event.
            /// </summary>
            public ref struct ReadyToInitData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_BaseAddress;
                private int _offset_ErrorOpcode;
                private int _offset_Code;
                private int _offset_String;

                private int Offset_BaseAddress
                {
                    get
                    {
                        if (_offset_BaseAddress == -1)
                        {
                            _offset_BaseAddress = 0;
                        }

                        return _offset_BaseAddress;
                    }
                }

                private int Offset_ErrorOpcode
                {
                    get
                    {
                        if (_offset_ErrorOpcode == -1)
                        {
                            _offset_ErrorOpcode = Offset_BaseAddress + 8;
                        }

                        return _offset_ErrorOpcode;
                    }
                }

                private int Offset_Code
                {
                    get
                    {
                        if (_offset_Code == -1)
                        {
                            _offset_Code = Offset_ErrorOpcode + 1;
                        }

                        return _offset_Code;
                    }
                }

                private int Offset_String
                {
                    get
                    {
                        if (_offset_String == -1)
                        {
                            _offset_String = Offset_Code + 1;
                        }

                        return _offset_String;
                    }
                }

                /// <summary>
                /// Retrieves the BaseAddress field.
                /// </summary>
                public ulong BaseAddress => BitConverter.ToUInt64(_etwEvent.Data[Offset_BaseAddress..Offset_ErrorOpcode]);

                /// <summary>
                /// Retrieves the ErrorOpcode field.
                /// </summary>
                public byte ErrorOpcode => _etwEvent.Data[Offset_ErrorOpcode];

                /// <summary>
                /// Retrieves the Code field.
                /// </summary>
                public sbyte Code => (sbyte)_etwEvent.Data[Offset_Code];

                /// <summary>
                /// Retrieves the String field.
                /// </summary>
                public string String => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_String..]);

                /// <summary>
                /// Creates a new ReadyToInitData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ReadyToInitData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_BaseAddress = -1;
                    _offset_ErrorOpcode = -1;
                    _offset_Code = -1;
                    _offset_String = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ReadyToRun event.
        /// </summary>
        public readonly ref struct ReadyToRunEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ReadyToRun";

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
                Opcode = (EtwEventOpcode)Opcodes.ReadyToRun,
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
            public ReadyToRunData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ReadyToRunEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ReadyToRunEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a ReadyToRunEventV3.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator ReadyToRunEventV3(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a ReadyToRun event.
            /// </summary>
            public ref struct ReadyToRunData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_BaseAddress;
                private int _offset_ErrorOpcode;
                private int _offset_Code;
                private int _offset_String;

                private int Offset_BaseAddress
                {
                    get
                    {
                        if (_offset_BaseAddress == -1)
                        {
                            _offset_BaseAddress = 0;
                        }

                        return _offset_BaseAddress;
                    }
                }

                private int Offset_ErrorOpcode
                {
                    get
                    {
                        if (_offset_ErrorOpcode == -1)
                        {
                            _offset_ErrorOpcode = Offset_BaseAddress + 8;
                        }

                        return _offset_ErrorOpcode;
                    }
                }

                private int Offset_Code
                {
                    get
                    {
                        if (_offset_Code == -1)
                        {
                            _offset_Code = Offset_ErrorOpcode + 1;
                        }

                        return _offset_Code;
                    }
                }

                private int Offset_String
                {
                    get
                    {
                        if (_offset_String == -1)
                        {
                            _offset_String = Offset_Code + 1;
                        }

                        return _offset_String;
                    }
                }

                /// <summary>
                /// Retrieves the BaseAddress field.
                /// </summary>
                public ulong BaseAddress => BitConverter.ToUInt64(_etwEvent.Data[Offset_BaseAddress..Offset_ErrorOpcode]);

                /// <summary>
                /// Retrieves the ErrorOpcode field.
                /// </summary>
                public byte ErrorOpcode => _etwEvent.Data[Offset_ErrorOpcode];

                /// <summary>
                /// Retrieves the Code field.
                /// </summary>
                public sbyte Code => (sbyte)_etwEvent.Data[Offset_Code];

                /// <summary>
                /// Retrieves the String field.
                /// </summary>
                public string String => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_String..]);

                /// <summary>
                /// Creates a new ReadyToRunData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ReadyToRunData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_BaseAddress = -1;
                    _offset_ErrorOpcode = -1;
                    _offset_Code = -1;
                    _offset_String = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ApiSetResolving event.
        /// </summary>
        public readonly ref struct ApiSetResolvingEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ApiSetResolving";

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
                Opcode = (EtwEventOpcode)Opcodes.ApiSetResolving,
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
            public ApiSetResolvingData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ApiSetResolvingEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ApiSetResolvingEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a ApiSetResolvingEventV3.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator ApiSetResolvingEventV3(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a ApiSetResolving event.
            /// </summary>
            public ref struct ApiSetResolvingData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_BaseAddress;
                private int _offset_ErrorOpcode;
                private int _offset_Code;
                private int _offset_String;

                private int Offset_BaseAddress
                {
                    get
                    {
                        if (_offset_BaseAddress == -1)
                        {
                            _offset_BaseAddress = 0;
                        }

                        return _offset_BaseAddress;
                    }
                }

                private int Offset_ErrorOpcode
                {
                    get
                    {
                        if (_offset_ErrorOpcode == -1)
                        {
                            _offset_ErrorOpcode = Offset_BaseAddress + 8;
                        }

                        return _offset_ErrorOpcode;
                    }
                }

                private int Offset_Code
                {
                    get
                    {
                        if (_offset_Code == -1)
                        {
                            _offset_Code = Offset_ErrorOpcode + 1;
                        }

                        return _offset_Code;
                    }
                }

                private int Offset_String
                {
                    get
                    {
                        if (_offset_String == -1)
                        {
                            _offset_String = Offset_Code + 1;
                        }

                        return _offset_String;
                    }
                }

                /// <summary>
                /// Retrieves the BaseAddress field.
                /// </summary>
                public ulong BaseAddress => BitConverter.ToUInt64(_etwEvent.Data[Offset_BaseAddress..Offset_ErrorOpcode]);

                /// <summary>
                /// Retrieves the ErrorOpcode field.
                /// </summary>
                public byte ErrorOpcode => _etwEvent.Data[Offset_ErrorOpcode];

                /// <summary>
                /// Retrieves the Code field.
                /// </summary>
                public sbyte Code => (sbyte)_etwEvent.Data[Offset_Code];

                /// <summary>
                /// Retrieves the String field.
                /// </summary>
                public string String => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_String..]);

                /// <summary>
                /// Creates a new ApiSetResolvingData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ApiSetResolvingData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_BaseAddress = -1;
                    _offset_ErrorOpcode = -1;
                    _offset_Code = -1;
                    _offset_String = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ApiSetHosted event.
        /// </summary>
        public readonly ref struct ApiSetHostedEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ApiSetHosted";

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
                Opcode = (EtwEventOpcode)Opcodes.ApiSetHosted,
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
            public ApiSetHostedData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ApiSetHostedEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ApiSetHostedEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a ApiSetHostedEventV3.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator ApiSetHostedEventV3(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a ApiSetHosted event.
            /// </summary>
            public ref struct ApiSetHostedData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_BaseAddress;
                private int _offset_ErrorOpcode;
                private int _offset_Code;
                private int _offset_String;

                private int Offset_BaseAddress
                {
                    get
                    {
                        if (_offset_BaseAddress == -1)
                        {
                            _offset_BaseAddress = 0;
                        }

                        return _offset_BaseAddress;
                    }
                }

                private int Offset_ErrorOpcode
                {
                    get
                    {
                        if (_offset_ErrorOpcode == -1)
                        {
                            _offset_ErrorOpcode = Offset_BaseAddress + 8;
                        }

                        return _offset_ErrorOpcode;
                    }
                }

                private int Offset_Code
                {
                    get
                    {
                        if (_offset_Code == -1)
                        {
                            _offset_Code = Offset_ErrorOpcode + 1;
                        }

                        return _offset_Code;
                    }
                }

                private int Offset_String
                {
                    get
                    {
                        if (_offset_String == -1)
                        {
                            _offset_String = Offset_Code + 1;
                        }

                        return _offset_String;
                    }
                }

                /// <summary>
                /// Retrieves the BaseAddress field.
                /// </summary>
                public ulong BaseAddress => BitConverter.ToUInt64(_etwEvent.Data[Offset_BaseAddress..Offset_ErrorOpcode]);

                /// <summary>
                /// Retrieves the ErrorOpcode field.
                /// </summary>
                public byte ErrorOpcode => _etwEvent.Data[Offset_ErrorOpcode];

                /// <summary>
                /// Retrieves the Code field.
                /// </summary>
                public sbyte Code => (sbyte)_etwEvent.Data[Offset_Code];

                /// <summary>
                /// Retrieves the String field.
                /// </summary>
                public string String => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_String..]);

                /// <summary>
                /// Creates a new ApiSetHostedData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ApiSetHostedData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_BaseAddress = -1;
                    _offset_ErrorOpcode = -1;
                    _offset_Code = -1;
                    _offset_String = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ApiSetUnhosted event.
        /// </summary>
        public readonly ref struct ApiSetUnhostedEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ApiSetUnhosted";

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
                Opcode = (EtwEventOpcode)Opcodes.ApiSetUnhosted,
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
            public ApiSetUnhostedData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ApiSetUnhostedEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ApiSetUnhostedEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a ApiSetUnhostedEventV3.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator ApiSetUnhostedEventV3(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a ApiSetUnhosted event.
            /// </summary>
            public ref struct ApiSetUnhostedData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_BaseAddress;
                private int _offset_ErrorOpcode;
                private int _offset_Code;
                private int _offset_String;

                private int Offset_BaseAddress
                {
                    get
                    {
                        if (_offset_BaseAddress == -1)
                        {
                            _offset_BaseAddress = 0;
                        }

                        return _offset_BaseAddress;
                    }
                }

                private int Offset_ErrorOpcode
                {
                    get
                    {
                        if (_offset_ErrorOpcode == -1)
                        {
                            _offset_ErrorOpcode = Offset_BaseAddress + 8;
                        }

                        return _offset_ErrorOpcode;
                    }
                }

                private int Offset_Code
                {
                    get
                    {
                        if (_offset_Code == -1)
                        {
                            _offset_Code = Offset_ErrorOpcode + 1;
                        }

                        return _offset_Code;
                    }
                }

                private int Offset_String
                {
                    get
                    {
                        if (_offset_String == -1)
                        {
                            _offset_String = Offset_Code + 1;
                        }

                        return _offset_String;
                    }
                }

                /// <summary>
                /// Retrieves the BaseAddress field.
                /// </summary>
                public ulong BaseAddress => BitConverter.ToUInt64(_etwEvent.Data[Offset_BaseAddress..Offset_ErrorOpcode]);

                /// <summary>
                /// Retrieves the ErrorOpcode field.
                /// </summary>
                public byte ErrorOpcode => _etwEvent.Data[Offset_ErrorOpcode];

                /// <summary>
                /// Retrieves the Code field.
                /// </summary>
                public sbyte Code => (sbyte)_etwEvent.Data[Offset_Code];

                /// <summary>
                /// Retrieves the String field.
                /// </summary>
                public string String => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_String..]);

                /// <summary>
                /// Creates a new ApiSetUnhostedData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ApiSetUnhostedData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_BaseAddress = -1;
                    _offset_ErrorOpcode = -1;
                    _offset_Code = -1;
                    _offset_String = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ApiSetUnresolved event.
        /// </summary>
        public readonly ref struct ApiSetUnresolvedEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ApiSetUnresolved";

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
                Opcode = (EtwEventOpcode)Opcodes.ApiSetUnresolved,
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
            public ApiSetUnresolvedData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ApiSetUnresolvedEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ApiSetUnresolvedEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a ApiSetUnresolvedEventV3.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator ApiSetUnresolvedEventV3(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a ApiSetUnresolved event.
            /// </summary>
            public ref struct ApiSetUnresolvedData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_BaseAddress;
                private int _offset_ErrorOpcode;
                private int _offset_Code;
                private int _offset_String;

                private int Offset_BaseAddress
                {
                    get
                    {
                        if (_offset_BaseAddress == -1)
                        {
                            _offset_BaseAddress = 0;
                        }

                        return _offset_BaseAddress;
                    }
                }

                private int Offset_ErrorOpcode
                {
                    get
                    {
                        if (_offset_ErrorOpcode == -1)
                        {
                            _offset_ErrorOpcode = Offset_BaseAddress + 8;
                        }

                        return _offset_ErrorOpcode;
                    }
                }

                private int Offset_Code
                {
                    get
                    {
                        if (_offset_Code == -1)
                        {
                            _offset_Code = Offset_ErrorOpcode + 1;
                        }

                        return _offset_Code;
                    }
                }

                private int Offset_String
                {
                    get
                    {
                        if (_offset_String == -1)
                        {
                            _offset_String = Offset_Code + 1;
                        }

                        return _offset_String;
                    }
                }

                /// <summary>
                /// Retrieves the BaseAddress field.
                /// </summary>
                public ulong BaseAddress => BitConverter.ToUInt64(_etwEvent.Data[Offset_BaseAddress..Offset_ErrorOpcode]);

                /// <summary>
                /// Retrieves the ErrorOpcode field.
                /// </summary>
                public byte ErrorOpcode => _etwEvent.Data[Offset_ErrorOpcode];

                /// <summary>
                /// Retrieves the Code field.
                /// </summary>
                public sbyte Code => (sbyte)_etwEvent.Data[Offset_Code];

                /// <summary>
                /// Retrieves the String field.
                /// </summary>
                public string String => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_String..]);

                /// <summary>
                /// Creates a new ApiSetUnresolvedData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ApiSetUnresolvedData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_BaseAddress = -1;
                    _offset_ErrorOpcode = -1;
                    _offset_Code = -1;
                    _offset_String = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DllSearchPathExternal event.
        /// </summary>
        public readonly ref struct DllSearchPathExternalEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DllSearchPathExternal";

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
                Opcode = (EtwEventOpcode)Opcodes.DllSearchPathExternal,
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
            public DllSearchPathExternalData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DllSearchPathExternalEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DllSearchPathExternalEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a DllSearchPathExternalEventV3.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator DllSearchPathExternalEventV3(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a DllSearchPathExternal event.
            /// </summary>
            public ref struct DllSearchPathExternalData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_BaseAddress;
                private int _offset_ErrorOpcode;
                private int _offset_Code;
                private int _offset_String1;
                private int _offset_String2;

                private int Offset_BaseAddress
                {
                    get
                    {
                        if (_offset_BaseAddress == -1)
                        {
                            _offset_BaseAddress = 0;
                        }

                        return _offset_BaseAddress;
                    }
                }

                private int Offset_ErrorOpcode
                {
                    get
                    {
                        if (_offset_ErrorOpcode == -1)
                        {
                            _offset_ErrorOpcode = Offset_BaseAddress + 8;
                        }

                        return _offset_ErrorOpcode;
                    }
                }

                private int Offset_Code
                {
                    get
                    {
                        if (_offset_Code == -1)
                        {
                            _offset_Code = Offset_ErrorOpcode + 1;
                        }

                        return _offset_Code;
                    }
                }

                private int Offset_String1
                {
                    get
                    {
                        if (_offset_String1 == -1)
                        {
                            _offset_String1 = Offset_Code + 1;
                        }

                        return _offset_String1;
                    }
                }

                private int Offset_String2
                {
                    get
                    {
                        if (_offset_String2 == -1)
                        {
                            _offset_String2 = Offset_String1 + _etwEvent.UnicodeStringLength(Offset_String1);
                        }

                        return _offset_String2;
                    }
                }

                /// <summary>
                /// Retrieves the BaseAddress field.
                /// </summary>
                public ulong BaseAddress => BitConverter.ToUInt64(_etwEvent.Data[Offset_BaseAddress..Offset_ErrorOpcode]);

                /// <summary>
                /// Retrieves the ErrorOpcode field.
                /// </summary>
                public byte ErrorOpcode => _etwEvent.Data[Offset_ErrorOpcode];

                /// <summary>
                /// Retrieves the Code field.
                /// </summary>
                public sbyte Code => (sbyte)_etwEvent.Data[Offset_Code];

                /// <summary>
                /// Retrieves the String1 field.
                /// </summary>
                public string String1 => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_String1..Offset_String2]);

                /// <summary>
                /// Retrieves the String2 field.
                /// </summary>
                public string String2 => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_String2..]);

                /// <summary>
                /// Creates a new DllSearchPathExternalData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DllSearchPathExternalData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_BaseAddress = -1;
                    _offset_ErrorOpcode = -1;
                    _offset_Code = -1;
                    _offset_String1 = -1;
                    _offset_String2 = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DllSearchPathInternal event.
        /// </summary>
        public readonly ref struct DllSearchPathInternalEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DllSearchPathInternal";

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
                Opcode = (EtwEventOpcode)Opcodes.DllSearchPathInternal,
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
            public DllSearchPathInternalData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DllSearchPathInternalEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DllSearchPathInternalEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a DllSearchPathInternalEventV3.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator DllSearchPathInternalEventV3(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a DllSearchPathInternal event.
            /// </summary>
            public ref struct DllSearchPathInternalData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_BaseAddress;
                private int _offset_ErrorOpcode;
                private int _offset_Code;
                private int _offset_String1;
                private int _offset_String2;

                private int Offset_BaseAddress
                {
                    get
                    {
                        if (_offset_BaseAddress == -1)
                        {
                            _offset_BaseAddress = 0;
                        }

                        return _offset_BaseAddress;
                    }
                }

                private int Offset_ErrorOpcode
                {
                    get
                    {
                        if (_offset_ErrorOpcode == -1)
                        {
                            _offset_ErrorOpcode = Offset_BaseAddress + 8;
                        }

                        return _offset_ErrorOpcode;
                    }
                }

                private int Offset_Code
                {
                    get
                    {
                        if (_offset_Code == -1)
                        {
                            _offset_Code = Offset_ErrorOpcode + 1;
                        }

                        return _offset_Code;
                    }
                }

                private int Offset_String1
                {
                    get
                    {
                        if (_offset_String1 == -1)
                        {
                            _offset_String1 = Offset_Code + 1;
                        }

                        return _offset_String1;
                    }
                }

                private int Offset_String2
                {
                    get
                    {
                        if (_offset_String2 == -1)
                        {
                            _offset_String2 = Offset_String1 + _etwEvent.UnicodeStringLength(Offset_String1);
                        }

                        return _offset_String2;
                    }
                }

                /// <summary>
                /// Retrieves the BaseAddress field.
                /// </summary>
                public ulong BaseAddress => BitConverter.ToUInt64(_etwEvent.Data[Offset_BaseAddress..Offset_ErrorOpcode]);

                /// <summary>
                /// Retrieves the ErrorOpcode field.
                /// </summary>
                public byte ErrorOpcode => _etwEvent.Data[Offset_ErrorOpcode];

                /// <summary>
                /// Retrieves the Code field.
                /// </summary>
                public sbyte Code => (sbyte)_etwEvent.Data[Offset_Code];

                /// <summary>
                /// Retrieves the String1 field.
                /// </summary>
                public string String1 => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_String1..Offset_String2]);

                /// <summary>
                /// Retrieves the String2 field.
                /// </summary>
                public string String2 => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_String2..]);

                /// <summary>
                /// Creates a new DllSearchPathInternalData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DllSearchPathInternalData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_BaseAddress = -1;
                    _offset_ErrorOpcode = -1;
                    _offset_Code = -1;
                    _offset_String1 = -1;
                    _offset_String2 = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a NewDllLoad event.
        /// </summary>
        public readonly ref struct NewDllLoadEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "NewDllLoad";

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
                Opcode = (EtwEventOpcode)Opcodes.NewDllLoad,
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
            public NewDllLoadData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new NewDllLoadEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public NewDllLoadEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a NewDllLoadEventV3.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator NewDllLoadEventV3(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a NewDllLoad event.
            /// </summary>
            public ref struct NewDllLoadData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_NewDllBaseAddress;
                private int _offset_ParentDllBaseAddress;
                private int _offset_LoadReason;
                private int _offset_FilePath;

                private int Offset_NewDllBaseAddress
                {
                    get
                    {
                        if (_offset_NewDllBaseAddress == -1)
                        {
                            _offset_NewDllBaseAddress = 0;
                        }

                        return _offset_NewDllBaseAddress;
                    }
                }

                private int Offset_ParentDllBaseAddress
                {
                    get
                    {
                        if (_offset_ParentDllBaseAddress == -1)
                        {
                            _offset_ParentDllBaseAddress = Offset_NewDllBaseAddress + _etwEvent.AddressSize;
                        }

                        return _offset_ParentDllBaseAddress;
                    }
                }

                private int Offset_LoadReason
                {
                    get
                    {
                        if (_offset_LoadReason == -1)
                        {
                            _offset_LoadReason = Offset_ParentDllBaseAddress + _etwEvent.AddressSize;
                        }

                        return _offset_LoadReason;
                    }
                }

                private int Offset_FilePath
                {
                    get
                    {
                        if (_offset_FilePath == -1)
                        {
                            _offset_FilePath = Offset_LoadReason + 4;
                        }

                        return _offset_FilePath;
                    }
                }

                /// <summary>
                /// Retrieves the NewDllBaseAddress field.
                /// </summary>
                public ulong NewDllBaseAddress => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_NewDllBaseAddress..Offset_ParentDllBaseAddress]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_NewDllBaseAddress..Offset_ParentDllBaseAddress]);

                /// <summary>
                /// Retrieves the ParentDllBaseAddress field.
                /// </summary>
                public ulong ParentDllBaseAddress => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ParentDllBaseAddress..Offset_LoadReason]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ParentDllBaseAddress..Offset_LoadReason]);

                /// <summary>
                /// Retrieves the LoadReason field.
                /// </summary>
                public uint LoadReason => BitConverter.ToUInt32(_etwEvent.Data[Offset_LoadReason..Offset_FilePath]);

                /// <summary>
                /// Retrieves the FilePath field.
                /// </summary>
                public string FilePath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FilePath..]);

                /// <summary>
                /// Creates a new NewDllLoadData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public NewDllLoadData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_NewDllBaseAddress = -1;
                    _offset_ParentDllBaseAddress = -1;
                    _offset_LoadReason = -1;
                    _offset_FilePath = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a NewDllLoadAsData event.
        /// </summary>
        public readonly ref struct NewDllLoadAsDataEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "NewDllLoadAsData";

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
                Opcode = (EtwEventOpcode)Opcodes.NewDllLoadAsData,
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
            public NewDllLoadAsDataData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new NewDllLoadAsDataEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public NewDllLoadAsDataEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a NewDllLoadAsDataEventV3.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator NewDllLoadAsDataEventV3(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a NewDllLoadAsData event.
            /// </summary>
            public ref struct NewDllLoadAsDataData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_NewDllBaseAddress;
                private int _offset_ParentDllBaseAddress;
                private int _offset_LoadReason;
                private int _offset_FilePath;

                private int Offset_NewDllBaseAddress
                {
                    get
                    {
                        if (_offset_NewDllBaseAddress == -1)
                        {
                            _offset_NewDllBaseAddress = 0;
                        }

                        return _offset_NewDllBaseAddress;
                    }
                }

                private int Offset_ParentDllBaseAddress
                {
                    get
                    {
                        if (_offset_ParentDllBaseAddress == -1)
                        {
                            _offset_ParentDllBaseAddress = Offset_NewDllBaseAddress + _etwEvent.AddressSize;
                        }

                        return _offset_ParentDllBaseAddress;
                    }
                }

                private int Offset_LoadReason
                {
                    get
                    {
                        if (_offset_LoadReason == -1)
                        {
                            _offset_LoadReason = Offset_ParentDllBaseAddress + _etwEvent.AddressSize;
                        }

                        return _offset_LoadReason;
                    }
                }

                private int Offset_FilePath
                {
                    get
                    {
                        if (_offset_FilePath == -1)
                        {
                            _offset_FilePath = Offset_LoadReason + 4;
                        }

                        return _offset_FilePath;
                    }
                }

                /// <summary>
                /// Retrieves the NewDllBaseAddress field.
                /// </summary>
                public ulong NewDllBaseAddress => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_NewDllBaseAddress..Offset_ParentDllBaseAddress]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_NewDllBaseAddress..Offset_ParentDllBaseAddress]);

                /// <summary>
                /// Retrieves the ParentDllBaseAddress field.
                /// </summary>
                public ulong ParentDllBaseAddress => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ParentDllBaseAddress..Offset_LoadReason]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ParentDllBaseAddress..Offset_LoadReason]);

                /// <summary>
                /// Retrieves the LoadReason field.
                /// </summary>
                public uint LoadReason => BitConverter.ToUInt32(_etwEvent.Data[Offset_LoadReason..Offset_FilePath]);

                /// <summary>
                /// Retrieves the FilePath field.
                /// </summary>
                public string FilePath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FilePath..]);

                /// <summary>
                /// Creates a new NewDllLoadAsDataData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public NewDllLoadAsDataData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_NewDllBaseAddress = -1;
                    _offset_ParentDllBaseAddress = -1;
                    _offset_LoadReason = -1;
                    _offset_FilePath = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DllSearchResults event.
        /// </summary>
        public readonly ref struct DllSearchResultsEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DllSearchResults";

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
                Opcode = (EtwEventOpcode)Opcodes.DllSearchResults,
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
            public DllSearchResultsData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DllSearchResultsEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DllSearchResultsEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a DllSearchResultsEventV3.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator DllSearchResultsEventV3(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a DllSearchResults event.
            /// </summary>
            public ref struct DllSearchResultsData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_LdrLoadFlags;
                private int _offset_LdrSearchFlags;
                private int _offset_SearchInfo;
                private int _offset_LoadReason;
                private int _offset_FullDllName;

                private int Offset_LdrLoadFlags
                {
                    get
                    {
                        if (_offset_LdrLoadFlags == -1)
                        {
                            _offset_LdrLoadFlags = 0;
                        }

                        return _offset_LdrLoadFlags;
                    }
                }

                private int Offset_LdrSearchFlags
                {
                    get
                    {
                        if (_offset_LdrSearchFlags == -1)
                        {
                            _offset_LdrSearchFlags = Offset_LdrLoadFlags + 4;
                        }

                        return _offset_LdrSearchFlags;
                    }
                }

                private int Offset_SearchInfo
                {
                    get
                    {
                        if (_offset_SearchInfo == -1)
                        {
                            _offset_SearchInfo = Offset_LdrSearchFlags + 4;
                        }

                        return _offset_SearchInfo;
                    }
                }

                private int Offset_LoadReason
                {
                    get
                    {
                        if (_offset_LoadReason == -1)
                        {
                            _offset_LoadReason = Offset_SearchInfo + 4;
                        }

                        return _offset_LoadReason;
                    }
                }

                private int Offset_FullDllName
                {
                    get
                    {
                        if (_offset_FullDllName == -1)
                        {
                            _offset_FullDllName = Offset_LoadReason + 4;
                        }

                        return _offset_FullDllName;
                    }
                }

                /// <summary>
                /// Retrieves the LdrLoadFlags field.
                /// </summary>
                public uint LdrLoadFlags => BitConverter.ToUInt32(_etwEvent.Data[Offset_LdrLoadFlags..Offset_LdrSearchFlags]);

                /// <summary>
                /// Retrieves the LdrSearchFlags field.
                /// </summary>
                public uint LdrSearchFlags => BitConverter.ToUInt32(_etwEvent.Data[Offset_LdrSearchFlags..Offset_SearchInfo]);

                /// <summary>
                /// Retrieves the SearchInfo field.
                /// </summary>
                public uint SearchInfo => BitConverter.ToUInt32(_etwEvent.Data[Offset_SearchInfo..Offset_LoadReason]);

                /// <summary>
                /// Retrieves the LoadReason field.
                /// </summary>
                public uint LoadReason => BitConverter.ToUInt32(_etwEvent.Data[Offset_LoadReason..Offset_FullDllName]);

                /// <summary>
                /// Retrieves the FullDllName field.
                /// </summary>
                public string FullDllName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FullDllName..]);

                /// <summary>
                /// Creates a new DllSearchResultsData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DllSearchResultsData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_LdrLoadFlags = -1;
                    _offset_LdrSearchFlags = -1;
                    _offset_SearchInfo = -1;
                    _offset_LoadReason = -1;
                    _offset_FullDllName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DllPathSearchResults event.
        /// </summary>
        public readonly ref struct DllPathSearchResultsEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DllPathSearchResults";

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
                Opcode = (EtwEventOpcode)Opcodes.DllPathSearchResults,
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
            public DllPathSearchResultsData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DllPathSearchResultsEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DllPathSearchResultsEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a DllPathSearchResultsEventV3.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator DllPathSearchResultsEventV3(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a DllPathSearchResults event.
            /// </summary>
            public ref struct DllPathSearchResultsData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_SearchInfo;
                private int _offset_Cwd;
                private int _offset_AppDir;
                private int _offset_DllDir;
                private int _offset_DllLoadDir;

                private int Offset_SearchInfo
                {
                    get
                    {
                        if (_offset_SearchInfo == -1)
                        {
                            _offset_SearchInfo = 0;
                        }

                        return _offset_SearchInfo;
                    }
                }

                private int Offset_Cwd
                {
                    get
                    {
                        if (_offset_Cwd == -1)
                        {
                            _offset_Cwd = Offset_SearchInfo + 4;
                        }

                        return _offset_Cwd;
                    }
                }

                private int Offset_AppDir
                {
                    get
                    {
                        if (_offset_AppDir == -1)
                        {
                            _offset_AppDir = Offset_Cwd + _etwEvent.UnicodeStringLength(Offset_Cwd);
                        }

                        return _offset_AppDir;
                    }
                }

                private int Offset_DllDir
                {
                    get
                    {
                        if (_offset_DllDir == -1)
                        {
                            _offset_DllDir = Offset_AppDir + _etwEvent.UnicodeStringLength(Offset_AppDir);
                        }

                        return _offset_DllDir;
                    }
                }

                private int Offset_DllLoadDir
                {
                    get
                    {
                        if (_offset_DllLoadDir == -1)
                        {
                            _offset_DllLoadDir = Offset_DllDir + _etwEvent.UnicodeStringLength(Offset_DllDir);
                        }

                        return _offset_DllLoadDir;
                    }
                }

                /// <summary>
                /// Retrieves the SearchInfo field.
                /// </summary>
                public uint SearchInfo => BitConverter.ToUInt32(_etwEvent.Data[Offset_SearchInfo..Offset_Cwd]);

                /// <summary>
                /// Retrieves the Cwd field.
                /// </summary>
                public string Cwd => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Cwd..Offset_AppDir]);

                /// <summary>
                /// Retrieves the AppDir field.
                /// </summary>
                public string AppDir => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_AppDir..Offset_DllDir]);

                /// <summary>
                /// Retrieves the DllDir field.
                /// </summary>
                public string DllDir => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_DllDir..Offset_DllLoadDir]);

                /// <summary>
                /// Retrieves the DllLoadDir field.
                /// </summary>
                public string DllLoadDir => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_DllLoadDir..]);

                /// <summary>
                /// Creates a new DllPathSearchResultsData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DllPathSearchResultsData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_SearchInfo = -1;
                    _offset_Cwd = -1;
                    _offset_AppDir = -1;
                    _offset_DllDir = -1;
                    _offset_DllLoadDir = -1;
                }
            }

        }
    }
}
