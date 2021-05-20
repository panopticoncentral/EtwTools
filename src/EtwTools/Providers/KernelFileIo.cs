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
    /// Provider for Kernel-FileIo (90cbdc39-4a3e-11d1-84f4-0000f80464e3)
    /// </summary>
    public sealed class KernelFileIoProvider
    {
        /// <summary>s
        /// Provider ID.
        /// </summary>
        public static readonly Guid Id = new("90cbdc39-4a3e-11d1-84f4-0000f80464e3");

        /// <summary>
        /// Provider name.
        /// </summary>
        public const string Name = "Kernel-FileIo";

        /// <summary>
        /// Opcodes supported by KernelFileIo.
        /// </summary>
        public enum Opcodes
        {
            /// <summary>
            /// 'FileCreate' opcode.
            /// </summary>
            FileCreate = 32,
            /// <summary>
            /// 'FileDelete' opcode.
            /// </summary>
            FileDelete = 35,
            /// <summary>
            /// 'FileRundown' opcode.
            /// </summary>
            FileRundown = 36,
            /// <summary>
            /// 'MapFile' opcode.
            /// </summary>
            MapFile = 37,
            /// <summary>
            /// 'UnmapFile' opcode.
            /// </summary>
            UnmapFile = 38,
            /// <summary>
            /// 'MapFileDCStart' opcode.
            /// </summary>
            MapFileDCStart = 39,
            /// <summary>
            /// 'MapFileDCEnd' opcode.
            /// </summary>
            MapFileDCEnd = 40,
            /// <summary>
            /// 'Create' opcode.
            /// </summary>
            Create = 64,
            /// <summary>
            /// 'Cleanup' opcode.
            /// </summary>
            Cleanup = 65,
            /// <summary>
            /// 'Close' opcode.
            /// </summary>
            Close = 66,
            /// <summary>
            /// 'Read' opcode.
            /// </summary>
            Read = 67,
            /// <summary>
            /// 'Write' opcode.
            /// </summary>
            Write = 68,
            /// <summary>
            /// 'SetInfo' opcode.
            /// </summary>
            SetInfo = 69,
            /// <summary>
            /// 'Delete' opcode.
            /// </summary>
            Delete = 70,
            /// <summary>
            /// 'Rename' opcode.
            /// </summary>
            Rename = 71,
            /// <summary>
            /// 'DirEnum' opcode.
            /// </summary>
            DirEnum = 72,
            /// <summary>
            /// 'Flush' opcode.
            /// </summary>
            Flush = 73,
            /// <summary>
            /// 'QueryInfo' opcode.
            /// </summary>
            QueryInfo = 74,
            /// <summary>
            /// 'FSControl' opcode.
            /// </summary>
            FSControl = 75,
            /// <summary>
            /// 'OperationEnd' opcode.
            /// </summary>
            OperationEnd = 76,
            /// <summary>
            /// 'DirNotify' opcode.
            /// </summary>
            DirNotify = 77,
            /// <summary>
            /// 'DletePath' opcode.
            /// </summary>
            DletePath = 79,
            /// <summary>
            /// 'RenamePath' opcode.
            /// </summary>
            RenamePath = 80,
            /// <summary>
            /// 'SetLinkPath' opcode.
            /// </summary>
            SetLinkPath = 81,
            /// <summary>
            /// 'PreOpInit' opcode.
            /// </summary>
            PreOpInit = 96,
            /// <summary>
            /// 'PostOpInit' opcode.
            /// </summary>
            PostOpInit = 97,
            /// <summary>
            /// 'PreOpCompletion' opcode.
            /// </summary>
            PreOpCompletion = 98,
            /// <summary>
            /// 'PostOpCompletion' opcode.
            /// </summary>
            PostOpCompletion = 99,
            /// <summary>
            /// 'PreOpFailure' opcode.
            /// </summary>
            PreOpFailure = 100,
            /// <summary>
            /// 'PostOpFailure' opcode.
            /// </summary>
            PostOpFailure = 101,
        }

        /// <summary>
        /// An event wrapper for a Name event.
        /// </summary>
        public readonly ref struct NameEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Name";

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
            public NameData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new NameEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public NameEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a NameEvent.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator NameEvent(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Name event.
            /// </summary>
            public ref struct NameData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_FileObject;
                private int _offset_FileName;

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = 0;
                        }

                        return _offset_FileObject;
                    }
                }

                private int Offset_FileName
                {
                    get
                    {
                        if (_offset_FileName == -1)
                        {
                            _offset_FileName = Offset_FileObject + _etwEvent.AddressSize;
                        }

                        return _offset_FileName;
                    }
                }

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..Offset_FileName]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..Offset_FileName]);

                /// <summary>
                /// Retrieves the FileName field.
                /// </summary>
                public string FileName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FileName..]);

                /// <summary>
                /// Creates a new NameData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public NameData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_FileObject = -1;
                    _offset_FileName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Name event.
        /// </summary>
        public readonly ref struct NameEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Name";

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
            public NameData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new NameEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public NameEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a NameEventV1.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator NameEventV1(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Name event.
            /// </summary>
            public ref struct NameData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_FileObject;
                private int _offset_FileName;

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = 0;
                        }

                        return _offset_FileObject;
                    }
                }

                private int Offset_FileName
                {
                    get
                    {
                        if (_offset_FileName == -1)
                        {
                            _offset_FileName = Offset_FileObject + _etwEvent.AddressSize;
                        }

                        return _offset_FileName;
                    }
                }

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..Offset_FileName]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..Offset_FileName]);

                /// <summary>
                /// Retrieves the FileName field.
                /// </summary>
                public string FileName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FileName..]);

                /// <summary>
                /// Creates a new NameData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public NameData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_FileObject = -1;
                    _offset_FileName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a FileCreate event.
        /// </summary>
        public readonly ref struct FileCreateEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "FileCreate";

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
                Opcode = (EtwEventOpcode)Opcodes.FileCreate,
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
            public FileCreateData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new FileCreateEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public FileCreateEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a FileCreateEventV1.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator FileCreateEventV1(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a FileCreate event.
            /// </summary>
            public ref struct FileCreateData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_FileObject;
                private int _offset_FileName;

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = 0;
                        }

                        return _offset_FileObject;
                    }
                }

                private int Offset_FileName
                {
                    get
                    {
                        if (_offset_FileName == -1)
                        {
                            _offset_FileName = Offset_FileObject + _etwEvent.AddressSize;
                        }

                        return _offset_FileName;
                    }
                }

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..Offset_FileName]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..Offset_FileName]);

                /// <summary>
                /// Retrieves the FileName field.
                /// </summary>
                public string FileName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FileName..]);

                /// <summary>
                /// Creates a new FileCreateData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public FileCreateData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_FileObject = -1;
                    _offset_FileName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Name event.
        /// </summary>
        public readonly ref struct NameEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Name";

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
            public NameData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new NameEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public NameEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a NameEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator NameEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Name event.
            /// </summary>
            public ref struct NameData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_FileObject;
                private int _offset_FileName;

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = 0;
                        }

                        return _offset_FileObject;
                    }
                }

                private int Offset_FileName
                {
                    get
                    {
                        if (_offset_FileName == -1)
                        {
                            _offset_FileName = Offset_FileObject + _etwEvent.AddressSize;
                        }

                        return _offset_FileName;
                    }
                }

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..Offset_FileName]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..Offset_FileName]);

                /// <summary>
                /// Retrieves the FileName field.
                /// </summary>
                public string FileName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FileName..]);

                /// <summary>
                /// Creates a new NameData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public NameData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_FileObject = -1;
                    _offset_FileName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a FileCreate event.
        /// </summary>
        public readonly ref struct FileCreateEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "FileCreate";

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
                Opcode = (EtwEventOpcode)Opcodes.FileCreate,
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
            public FileCreateData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new FileCreateEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public FileCreateEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a FileCreateEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator FileCreateEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a FileCreate event.
            /// </summary>
            public ref struct FileCreateData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_FileObject;
                private int _offset_FileName;

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = 0;
                        }

                        return _offset_FileObject;
                    }
                }

                private int Offset_FileName
                {
                    get
                    {
                        if (_offset_FileName == -1)
                        {
                            _offset_FileName = Offset_FileObject + _etwEvent.AddressSize;
                        }

                        return _offset_FileName;
                    }
                }

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..Offset_FileName]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..Offset_FileName]);

                /// <summary>
                /// Retrieves the FileName field.
                /// </summary>
                public string FileName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FileName..]);

                /// <summary>
                /// Creates a new FileCreateData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public FileCreateData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_FileObject = -1;
                    _offset_FileName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a FileDelete event.
        /// </summary>
        public readonly ref struct FileDeleteEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "FileDelete";

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
                Opcode = (EtwEventOpcode)Opcodes.FileDelete,
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
            public FileDeleteData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new FileDeleteEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public FileDeleteEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a FileDeleteEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator FileDeleteEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a FileDelete event.
            /// </summary>
            public ref struct FileDeleteData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_FileObject;
                private int _offset_FileName;

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = 0;
                        }

                        return _offset_FileObject;
                    }
                }

                private int Offset_FileName
                {
                    get
                    {
                        if (_offset_FileName == -1)
                        {
                            _offset_FileName = Offset_FileObject + _etwEvent.AddressSize;
                        }

                        return _offset_FileName;
                    }
                }

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..Offset_FileName]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..Offset_FileName]);

                /// <summary>
                /// Retrieves the FileName field.
                /// </summary>
                public string FileName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FileName..]);

                /// <summary>
                /// Creates a new FileDeleteData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public FileDeleteData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_FileObject = -1;
                    _offset_FileName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a FileRundown event.
        /// </summary>
        public readonly ref struct FileRundownEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "FileRundown";

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
                Opcode = (EtwEventOpcode)Opcodes.FileRundown,
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
            public FileRundownData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new FileRundownEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public FileRundownEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a FileRundownEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator FileRundownEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a FileRundown event.
            /// </summary>
            public ref struct FileRundownData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_FileObject;
                private int _offset_FileName;

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = 0;
                        }

                        return _offset_FileObject;
                    }
                }

                private int Offset_FileName
                {
                    get
                    {
                        if (_offset_FileName == -1)
                        {
                            _offset_FileName = Offset_FileObject + _etwEvent.AddressSize;
                        }

                        return _offset_FileName;
                    }
                }

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..Offset_FileName]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..Offset_FileName]);

                /// <summary>
                /// Retrieves the FileName field.
                /// </summary>
                public string FileName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FileName..]);

                /// <summary>
                /// Creates a new FileRundownData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public FileRundownData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_FileObject = -1;
                    _offset_FileName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Create event.
        /// </summary>
        public readonly ref struct CreateEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Create";

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
                Opcode = (EtwEventOpcode)Opcodes.Create,
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
            public CreateData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new CreateEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public CreateEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a CreateEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator CreateEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Create event.
            /// </summary>
            public ref struct CreateData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_IrpPtr;
                private int _offset_TTID;
                private int _offset_FileObject;
                private int _offset_CreateOptions;
                private int _offset_FileAttributes;
                private int _offset_ShareAccess;
                private int _offset_OpenPath;

                private int Offset_IrpPtr
                {
                    get
                    {
                        if (_offset_IrpPtr == -1)
                        {
                            _offset_IrpPtr = 0;
                        }

                        return _offset_IrpPtr;
                    }
                }

                private int Offset_TTID
                {
                    get
                    {
                        if (_offset_TTID == -1)
                        {
                            _offset_TTID = Offset_IrpPtr + _etwEvent.AddressSize;
                        }

                        return _offset_TTID;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_TTID + _etwEvent.AddressSize;
                        }

                        return _offset_FileObject;
                    }
                }

                private int Offset_CreateOptions
                {
                    get
                    {
                        if (_offset_CreateOptions == -1)
                        {
                            _offset_CreateOptions = Offset_FileObject + _etwEvent.AddressSize;
                        }

                        return _offset_CreateOptions;
                    }
                }

                private int Offset_FileAttributes
                {
                    get
                    {
                        if (_offset_FileAttributes == -1)
                        {
                            _offset_FileAttributes = Offset_CreateOptions + 4;
                        }

                        return _offset_FileAttributes;
                    }
                }

                private int Offset_ShareAccess
                {
                    get
                    {
                        if (_offset_ShareAccess == -1)
                        {
                            _offset_ShareAccess = Offset_FileAttributes + 4;
                        }

                        return _offset_ShareAccess;
                    }
                }

                private int Offset_OpenPath
                {
                    get
                    {
                        if (_offset_OpenPath == -1)
                        {
                            _offset_OpenPath = Offset_ShareAccess + 4;
                        }

                        return _offset_OpenPath;
                    }
                }

                /// <summary>
                /// Retrieves the IrpPtr field.
                /// </summary>
                public ulong IrpPtr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_IrpPtr..Offset_TTID]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_IrpPtr..Offset_TTID]);

                /// <summary>
                /// Retrieves the TTID field.
                /// </summary>
                public ulong TTID => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_TTID..Offset_FileObject]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_TTID..Offset_FileObject]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..Offset_CreateOptions]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..Offset_CreateOptions]);

                /// <summary>
                /// Retrieves the CreateOptions field.
                /// </summary>
                public uint CreateOptions => BitConverter.ToUInt32(_etwEvent.Data[Offset_CreateOptions..Offset_FileAttributes]);

                /// <summary>
                /// Retrieves the FileAttributes field.
                /// </summary>
                public uint FileAttributes => BitConverter.ToUInt32(_etwEvent.Data[Offset_FileAttributes..Offset_ShareAccess]);

                /// <summary>
                /// Retrieves the ShareAccess field.
                /// </summary>
                public uint ShareAccess => BitConverter.ToUInt32(_etwEvent.Data[Offset_ShareAccess..Offset_OpenPath]);

                /// <summary>
                /// Retrieves the OpenPath field.
                /// </summary>
                public string OpenPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_OpenPath..]);

                /// <summary>
                /// Creates a new CreateData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public CreateData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_IrpPtr = -1;
                    _offset_TTID = -1;
                    _offset_FileObject = -1;
                    _offset_CreateOptions = -1;
                    _offset_FileAttributes = -1;
                    _offset_ShareAccess = -1;
                    _offset_OpenPath = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Cleanup event.
        /// </summary>
        public readonly ref struct CleanupEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Cleanup";

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
                Opcode = (EtwEventOpcode)Opcodes.Cleanup,
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
            public CleanupData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new CleanupEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public CleanupEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a CleanupEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator CleanupEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Cleanup event.
            /// </summary>
            public ref struct CleanupData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_IrpPtr;
                private int _offset_TTID;
                private int _offset_FileObject;
                private int _offset_FileKey;

                private int Offset_IrpPtr
                {
                    get
                    {
                        if (_offset_IrpPtr == -1)
                        {
                            _offset_IrpPtr = 0;
                        }

                        return _offset_IrpPtr;
                    }
                }

                private int Offset_TTID
                {
                    get
                    {
                        if (_offset_TTID == -1)
                        {
                            _offset_TTID = Offset_IrpPtr + _etwEvent.AddressSize;
                        }

                        return _offset_TTID;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_TTID + _etwEvent.AddressSize;
                        }

                        return _offset_FileObject;
                    }
                }

                private int Offset_FileKey
                {
                    get
                    {
                        if (_offset_FileKey == -1)
                        {
                            _offset_FileKey = Offset_FileObject + _etwEvent.AddressSize;
                        }

                        return _offset_FileKey;
                    }
                }

                /// <summary>
                /// Retrieves the IrpPtr field.
                /// </summary>
                public ulong IrpPtr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_IrpPtr..Offset_TTID]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_IrpPtr..Offset_TTID]);

                /// <summary>
                /// Retrieves the TTID field.
                /// </summary>
                public ulong TTID => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_TTID..Offset_FileObject]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_TTID..Offset_FileObject]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..Offset_FileKey]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..Offset_FileKey]);

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..]);

                /// <summary>
                /// Creates a new CleanupData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public CleanupData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_IrpPtr = -1;
                    _offset_TTID = -1;
                    _offset_FileObject = -1;
                    _offset_FileKey = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Close event.
        /// </summary>
        public readonly ref struct CloseEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Close";

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
                Opcode = (EtwEventOpcode)Opcodes.Close,
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
            public CloseData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new CloseEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public CloseEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a CloseEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator CloseEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Close event.
            /// </summary>
            public ref struct CloseData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_IrpPtr;
                private int _offset_TTID;
                private int _offset_FileObject;
                private int _offset_FileKey;

                private int Offset_IrpPtr
                {
                    get
                    {
                        if (_offset_IrpPtr == -1)
                        {
                            _offset_IrpPtr = 0;
                        }

                        return _offset_IrpPtr;
                    }
                }

                private int Offset_TTID
                {
                    get
                    {
                        if (_offset_TTID == -1)
                        {
                            _offset_TTID = Offset_IrpPtr + _etwEvent.AddressSize;
                        }

                        return _offset_TTID;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_TTID + _etwEvent.AddressSize;
                        }

                        return _offset_FileObject;
                    }
                }

                private int Offset_FileKey
                {
                    get
                    {
                        if (_offset_FileKey == -1)
                        {
                            _offset_FileKey = Offset_FileObject + _etwEvent.AddressSize;
                        }

                        return _offset_FileKey;
                    }
                }

                /// <summary>
                /// Retrieves the IrpPtr field.
                /// </summary>
                public ulong IrpPtr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_IrpPtr..Offset_TTID]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_IrpPtr..Offset_TTID]);

                /// <summary>
                /// Retrieves the TTID field.
                /// </summary>
                public ulong TTID => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_TTID..Offset_FileObject]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_TTID..Offset_FileObject]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..Offset_FileKey]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..Offset_FileKey]);

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..]);

                /// <summary>
                /// Creates a new CloseData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public CloseData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_IrpPtr = -1;
                    _offset_TTID = -1;
                    _offset_FileObject = -1;
                    _offset_FileKey = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Flush event.
        /// </summary>
        public readonly ref struct FlushEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Flush";

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
                Opcode = (EtwEventOpcode)Opcodes.Flush,
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
            public FlushData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new FlushEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public FlushEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a FlushEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator FlushEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Flush event.
            /// </summary>
            public ref struct FlushData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_IrpPtr;
                private int _offset_TTID;
                private int _offset_FileObject;
                private int _offset_FileKey;

                private int Offset_IrpPtr
                {
                    get
                    {
                        if (_offset_IrpPtr == -1)
                        {
                            _offset_IrpPtr = 0;
                        }

                        return _offset_IrpPtr;
                    }
                }

                private int Offset_TTID
                {
                    get
                    {
                        if (_offset_TTID == -1)
                        {
                            _offset_TTID = Offset_IrpPtr + _etwEvent.AddressSize;
                        }

                        return _offset_TTID;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_TTID + _etwEvent.AddressSize;
                        }

                        return _offset_FileObject;
                    }
                }

                private int Offset_FileKey
                {
                    get
                    {
                        if (_offset_FileKey == -1)
                        {
                            _offset_FileKey = Offset_FileObject + _etwEvent.AddressSize;
                        }

                        return _offset_FileKey;
                    }
                }

                /// <summary>
                /// Retrieves the IrpPtr field.
                /// </summary>
                public ulong IrpPtr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_IrpPtr..Offset_TTID]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_IrpPtr..Offset_TTID]);

                /// <summary>
                /// Retrieves the TTID field.
                /// </summary>
                public ulong TTID => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_TTID..Offset_FileObject]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_TTID..Offset_FileObject]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..Offset_FileKey]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..Offset_FileKey]);

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..]);

                /// <summary>
                /// Creates a new FlushData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public FlushData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_IrpPtr = -1;
                    _offset_TTID = -1;
                    _offset_FileObject = -1;
                    _offset_FileKey = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Read event.
        /// </summary>
        public readonly ref struct ReadEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Read";

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
                Opcode = (EtwEventOpcode)Opcodes.Read,
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
            public ReadData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ReadEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ReadEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a ReadEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator ReadEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Read event.
            /// </summary>
            public ref struct ReadData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Offset;
                private int _offset_IrpPtr;
                private int _offset_TTID;
                private int _offset_FileObject;
                private int _offset_FileKey;
                private int _offset_IoSize;
                private int _offset_IoFlags;

                private int Offset_Offset
                {
                    get
                    {
                        if (_offset_Offset == -1)
                        {
                            _offset_Offset = 0;
                        }

                        return _offset_Offset;
                    }
                }

                private int Offset_IrpPtr
                {
                    get
                    {
                        if (_offset_IrpPtr == -1)
                        {
                            _offset_IrpPtr = Offset_Offset + 8;
                        }

                        return _offset_IrpPtr;
                    }
                }

                private int Offset_TTID
                {
                    get
                    {
                        if (_offset_TTID == -1)
                        {
                            _offset_TTID = Offset_IrpPtr + _etwEvent.AddressSize;
                        }

                        return _offset_TTID;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_TTID + _etwEvent.AddressSize;
                        }

                        return _offset_FileObject;
                    }
                }

                private int Offset_FileKey
                {
                    get
                    {
                        if (_offset_FileKey == -1)
                        {
                            _offset_FileKey = Offset_FileObject + _etwEvent.AddressSize;
                        }

                        return _offset_FileKey;
                    }
                }

                private int Offset_IoSize
                {
                    get
                    {
                        if (_offset_IoSize == -1)
                        {
                            _offset_IoSize = Offset_FileKey + _etwEvent.AddressSize;
                        }

                        return _offset_IoSize;
                    }
                }

                private int Offset_IoFlags
                {
                    get
                    {
                        if (_offset_IoFlags == -1)
                        {
                            _offset_IoFlags = Offset_IoSize + 4;
                        }

                        return _offset_IoFlags;
                    }
                }

                /// <summary>
                /// Retrieves the Offset field.
                /// </summary>
                public ulong Offset => BitConverter.ToUInt64(_etwEvent.Data[Offset_Offset..Offset_IrpPtr]);

                /// <summary>
                /// Retrieves the IrpPtr field.
                /// </summary>
                public ulong IrpPtr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_IrpPtr..Offset_TTID]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_IrpPtr..Offset_TTID]);

                /// <summary>
                /// Retrieves the TTID field.
                /// </summary>
                public ulong TTID => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_TTID..Offset_FileObject]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_TTID..Offset_FileObject]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..Offset_FileKey]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..Offset_FileKey]);

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..Offset_IoSize]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..Offset_IoSize]);

                /// <summary>
                /// Retrieves the IoSize field.
                /// </summary>
                public uint IoSize => BitConverter.ToUInt32(_etwEvent.Data[Offset_IoSize..Offset_IoFlags]);

                /// <summary>
                /// Retrieves the IoFlags field.
                /// </summary>
                public uint IoFlags => BitConverter.ToUInt32(_etwEvent.Data[Offset_IoFlags..]);

                /// <summary>
                /// Creates a new ReadData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ReadData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Offset = -1;
                    _offset_IrpPtr = -1;
                    _offset_TTID = -1;
                    _offset_FileObject = -1;
                    _offset_FileKey = -1;
                    _offset_IoSize = -1;
                    _offset_IoFlags = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Write event.
        /// </summary>
        public readonly ref struct WriteEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Write";

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
                Opcode = (EtwEventOpcode)Opcodes.Write,
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
            public WriteData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new WriteEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public WriteEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a WriteEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator WriteEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Write event.
            /// </summary>
            public ref struct WriteData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Offset;
                private int _offset_IrpPtr;
                private int _offset_TTID;
                private int _offset_FileObject;
                private int _offset_FileKey;
                private int _offset_IoSize;
                private int _offset_IoFlags;

                private int Offset_Offset
                {
                    get
                    {
                        if (_offset_Offset == -1)
                        {
                            _offset_Offset = 0;
                        }

                        return _offset_Offset;
                    }
                }

                private int Offset_IrpPtr
                {
                    get
                    {
                        if (_offset_IrpPtr == -1)
                        {
                            _offset_IrpPtr = Offset_Offset + 8;
                        }

                        return _offset_IrpPtr;
                    }
                }

                private int Offset_TTID
                {
                    get
                    {
                        if (_offset_TTID == -1)
                        {
                            _offset_TTID = Offset_IrpPtr + _etwEvent.AddressSize;
                        }

                        return _offset_TTID;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_TTID + _etwEvent.AddressSize;
                        }

                        return _offset_FileObject;
                    }
                }

                private int Offset_FileKey
                {
                    get
                    {
                        if (_offset_FileKey == -1)
                        {
                            _offset_FileKey = Offset_FileObject + _etwEvent.AddressSize;
                        }

                        return _offset_FileKey;
                    }
                }

                private int Offset_IoSize
                {
                    get
                    {
                        if (_offset_IoSize == -1)
                        {
                            _offset_IoSize = Offset_FileKey + _etwEvent.AddressSize;
                        }

                        return _offset_IoSize;
                    }
                }

                private int Offset_IoFlags
                {
                    get
                    {
                        if (_offset_IoFlags == -1)
                        {
                            _offset_IoFlags = Offset_IoSize + 4;
                        }

                        return _offset_IoFlags;
                    }
                }

                /// <summary>
                /// Retrieves the Offset field.
                /// </summary>
                public ulong Offset => BitConverter.ToUInt64(_etwEvent.Data[Offset_Offset..Offset_IrpPtr]);

                /// <summary>
                /// Retrieves the IrpPtr field.
                /// </summary>
                public ulong IrpPtr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_IrpPtr..Offset_TTID]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_IrpPtr..Offset_TTID]);

                /// <summary>
                /// Retrieves the TTID field.
                /// </summary>
                public ulong TTID => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_TTID..Offset_FileObject]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_TTID..Offset_FileObject]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..Offset_FileKey]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..Offset_FileKey]);

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..Offset_IoSize]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..Offset_IoSize]);

                /// <summary>
                /// Retrieves the IoSize field.
                /// </summary>
                public uint IoSize => BitConverter.ToUInt32(_etwEvent.Data[Offset_IoSize..Offset_IoFlags]);

                /// <summary>
                /// Retrieves the IoFlags field.
                /// </summary>
                public uint IoFlags => BitConverter.ToUInt32(_etwEvent.Data[Offset_IoFlags..]);

                /// <summary>
                /// Creates a new WriteData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public WriteData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Offset = -1;
                    _offset_IrpPtr = -1;
                    _offset_TTID = -1;
                    _offset_FileObject = -1;
                    _offset_FileKey = -1;
                    _offset_IoSize = -1;
                    _offset_IoFlags = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a SetInfo event.
        /// </summary>
        public readonly ref struct SetInfoEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SetInfo";

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
                Opcode = (EtwEventOpcode)Opcodes.SetInfo,
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
            public SetInfoData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new SetInfoEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SetInfoEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a SetInfoEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator SetInfoEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a SetInfo event.
            /// </summary>
            public ref struct SetInfoData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_IrpPtr;
                private int _offset_TTID;
                private int _offset_FileObject;
                private int _offset_FileKey;
                private int _offset_ExtraInfo;
                private int _offset_InfoClass;

                private int Offset_IrpPtr
                {
                    get
                    {
                        if (_offset_IrpPtr == -1)
                        {
                            _offset_IrpPtr = 0;
                        }

                        return _offset_IrpPtr;
                    }
                }

                private int Offset_TTID
                {
                    get
                    {
                        if (_offset_TTID == -1)
                        {
                            _offset_TTID = Offset_IrpPtr + _etwEvent.AddressSize;
                        }

                        return _offset_TTID;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_TTID + _etwEvent.AddressSize;
                        }

                        return _offset_FileObject;
                    }
                }

                private int Offset_FileKey
                {
                    get
                    {
                        if (_offset_FileKey == -1)
                        {
                            _offset_FileKey = Offset_FileObject + _etwEvent.AddressSize;
                        }

                        return _offset_FileKey;
                    }
                }

                private int Offset_ExtraInfo
                {
                    get
                    {
                        if (_offset_ExtraInfo == -1)
                        {
                            _offset_ExtraInfo = Offset_FileKey + _etwEvent.AddressSize;
                        }

                        return _offset_ExtraInfo;
                    }
                }

                private int Offset_InfoClass
                {
                    get
                    {
                        if (_offset_InfoClass == -1)
                        {
                            _offset_InfoClass = Offset_ExtraInfo + _etwEvent.AddressSize;
                        }

                        return _offset_InfoClass;
                    }
                }

                /// <summary>
                /// Retrieves the IrpPtr field.
                /// </summary>
                public ulong IrpPtr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_IrpPtr..Offset_TTID]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_IrpPtr..Offset_TTID]);

                /// <summary>
                /// Retrieves the TTID field.
                /// </summary>
                public ulong TTID => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_TTID..Offset_FileObject]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_TTID..Offset_FileObject]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..Offset_FileKey]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..Offset_FileKey]);

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..Offset_ExtraInfo]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..Offset_ExtraInfo]);

                /// <summary>
                /// Retrieves the ExtraInfo field.
                /// </summary>
                public ulong ExtraInfo => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ExtraInfo..Offset_InfoClass]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ExtraInfo..Offset_InfoClass]);

                /// <summary>
                /// Retrieves the InfoClass field.
                /// </summary>
                public uint InfoClass => BitConverter.ToUInt32(_etwEvent.Data[Offset_InfoClass..]);

                /// <summary>
                /// Creates a new SetInfoData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public SetInfoData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_IrpPtr = -1;
                    _offset_TTID = -1;
                    _offset_FileObject = -1;
                    _offset_FileKey = -1;
                    _offset_ExtraInfo = -1;
                    _offset_InfoClass = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Delete event.
        /// </summary>
        public readonly ref struct DeleteEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Delete";

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
                Opcode = (EtwEventOpcode)Opcodes.Delete,
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
            public DeleteData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DeleteEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DeleteEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a DeleteEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator DeleteEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Delete event.
            /// </summary>
            public ref struct DeleteData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_IrpPtr;
                private int _offset_TTID;
                private int _offset_FileObject;
                private int _offset_FileKey;
                private int _offset_ExtraInfo;
                private int _offset_InfoClass;

                private int Offset_IrpPtr
                {
                    get
                    {
                        if (_offset_IrpPtr == -1)
                        {
                            _offset_IrpPtr = 0;
                        }

                        return _offset_IrpPtr;
                    }
                }

                private int Offset_TTID
                {
                    get
                    {
                        if (_offset_TTID == -1)
                        {
                            _offset_TTID = Offset_IrpPtr + _etwEvent.AddressSize;
                        }

                        return _offset_TTID;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_TTID + _etwEvent.AddressSize;
                        }

                        return _offset_FileObject;
                    }
                }

                private int Offset_FileKey
                {
                    get
                    {
                        if (_offset_FileKey == -1)
                        {
                            _offset_FileKey = Offset_FileObject + _etwEvent.AddressSize;
                        }

                        return _offset_FileKey;
                    }
                }

                private int Offset_ExtraInfo
                {
                    get
                    {
                        if (_offset_ExtraInfo == -1)
                        {
                            _offset_ExtraInfo = Offset_FileKey + _etwEvent.AddressSize;
                        }

                        return _offset_ExtraInfo;
                    }
                }

                private int Offset_InfoClass
                {
                    get
                    {
                        if (_offset_InfoClass == -1)
                        {
                            _offset_InfoClass = Offset_ExtraInfo + _etwEvent.AddressSize;
                        }

                        return _offset_InfoClass;
                    }
                }

                /// <summary>
                /// Retrieves the IrpPtr field.
                /// </summary>
                public ulong IrpPtr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_IrpPtr..Offset_TTID]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_IrpPtr..Offset_TTID]);

                /// <summary>
                /// Retrieves the TTID field.
                /// </summary>
                public ulong TTID => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_TTID..Offset_FileObject]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_TTID..Offset_FileObject]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..Offset_FileKey]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..Offset_FileKey]);

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..Offset_ExtraInfo]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..Offset_ExtraInfo]);

                /// <summary>
                /// Retrieves the ExtraInfo field.
                /// </summary>
                public ulong ExtraInfo => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ExtraInfo..Offset_InfoClass]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ExtraInfo..Offset_InfoClass]);

                /// <summary>
                /// Retrieves the InfoClass field.
                /// </summary>
                public uint InfoClass => BitConverter.ToUInt32(_etwEvent.Data[Offset_InfoClass..]);

                /// <summary>
                /// Creates a new DeleteData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DeleteData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_IrpPtr = -1;
                    _offset_TTID = -1;
                    _offset_FileObject = -1;
                    _offset_FileKey = -1;
                    _offset_ExtraInfo = -1;
                    _offset_InfoClass = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Rename event.
        /// </summary>
        public readonly ref struct RenameEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Rename";

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
                Opcode = (EtwEventOpcode)Opcodes.Rename,
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
            public RenameData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new RenameEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public RenameEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a RenameEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator RenameEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Rename event.
            /// </summary>
            public ref struct RenameData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_IrpPtr;
                private int _offset_TTID;
                private int _offset_FileObject;
                private int _offset_FileKey;
                private int _offset_ExtraInfo;
                private int _offset_InfoClass;

                private int Offset_IrpPtr
                {
                    get
                    {
                        if (_offset_IrpPtr == -1)
                        {
                            _offset_IrpPtr = 0;
                        }

                        return _offset_IrpPtr;
                    }
                }

                private int Offset_TTID
                {
                    get
                    {
                        if (_offset_TTID == -1)
                        {
                            _offset_TTID = Offset_IrpPtr + _etwEvent.AddressSize;
                        }

                        return _offset_TTID;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_TTID + _etwEvent.AddressSize;
                        }

                        return _offset_FileObject;
                    }
                }

                private int Offset_FileKey
                {
                    get
                    {
                        if (_offset_FileKey == -1)
                        {
                            _offset_FileKey = Offset_FileObject + _etwEvent.AddressSize;
                        }

                        return _offset_FileKey;
                    }
                }

                private int Offset_ExtraInfo
                {
                    get
                    {
                        if (_offset_ExtraInfo == -1)
                        {
                            _offset_ExtraInfo = Offset_FileKey + _etwEvent.AddressSize;
                        }

                        return _offset_ExtraInfo;
                    }
                }

                private int Offset_InfoClass
                {
                    get
                    {
                        if (_offset_InfoClass == -1)
                        {
                            _offset_InfoClass = Offset_ExtraInfo + _etwEvent.AddressSize;
                        }

                        return _offset_InfoClass;
                    }
                }

                /// <summary>
                /// Retrieves the IrpPtr field.
                /// </summary>
                public ulong IrpPtr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_IrpPtr..Offset_TTID]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_IrpPtr..Offset_TTID]);

                /// <summary>
                /// Retrieves the TTID field.
                /// </summary>
                public ulong TTID => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_TTID..Offset_FileObject]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_TTID..Offset_FileObject]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..Offset_FileKey]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..Offset_FileKey]);

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..Offset_ExtraInfo]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..Offset_ExtraInfo]);

                /// <summary>
                /// Retrieves the ExtraInfo field.
                /// </summary>
                public ulong ExtraInfo => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ExtraInfo..Offset_InfoClass]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ExtraInfo..Offset_InfoClass]);

                /// <summary>
                /// Retrieves the InfoClass field.
                /// </summary>
                public uint InfoClass => BitConverter.ToUInt32(_etwEvent.Data[Offset_InfoClass..]);

                /// <summary>
                /// Creates a new RenameData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public RenameData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_IrpPtr = -1;
                    _offset_TTID = -1;
                    _offset_FileObject = -1;
                    _offset_FileKey = -1;
                    _offset_ExtraInfo = -1;
                    _offset_InfoClass = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a QueryInfo event.
        /// </summary>
        public readonly ref struct QueryInfoEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "QueryInfo";

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
                Opcode = (EtwEventOpcode)Opcodes.QueryInfo,
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
            public QueryInfoData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new QueryInfoEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public QueryInfoEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a QueryInfoEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator QueryInfoEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a QueryInfo event.
            /// </summary>
            public ref struct QueryInfoData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_IrpPtr;
                private int _offset_TTID;
                private int _offset_FileObject;
                private int _offset_FileKey;
                private int _offset_ExtraInfo;
                private int _offset_InfoClass;

                private int Offset_IrpPtr
                {
                    get
                    {
                        if (_offset_IrpPtr == -1)
                        {
                            _offset_IrpPtr = 0;
                        }

                        return _offset_IrpPtr;
                    }
                }

                private int Offset_TTID
                {
                    get
                    {
                        if (_offset_TTID == -1)
                        {
                            _offset_TTID = Offset_IrpPtr + _etwEvent.AddressSize;
                        }

                        return _offset_TTID;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_TTID + _etwEvent.AddressSize;
                        }

                        return _offset_FileObject;
                    }
                }

                private int Offset_FileKey
                {
                    get
                    {
                        if (_offset_FileKey == -1)
                        {
                            _offset_FileKey = Offset_FileObject + _etwEvent.AddressSize;
                        }

                        return _offset_FileKey;
                    }
                }

                private int Offset_ExtraInfo
                {
                    get
                    {
                        if (_offset_ExtraInfo == -1)
                        {
                            _offset_ExtraInfo = Offset_FileKey + _etwEvent.AddressSize;
                        }

                        return _offset_ExtraInfo;
                    }
                }

                private int Offset_InfoClass
                {
                    get
                    {
                        if (_offset_InfoClass == -1)
                        {
                            _offset_InfoClass = Offset_ExtraInfo + _etwEvent.AddressSize;
                        }

                        return _offset_InfoClass;
                    }
                }

                /// <summary>
                /// Retrieves the IrpPtr field.
                /// </summary>
                public ulong IrpPtr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_IrpPtr..Offset_TTID]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_IrpPtr..Offset_TTID]);

                /// <summary>
                /// Retrieves the TTID field.
                /// </summary>
                public ulong TTID => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_TTID..Offset_FileObject]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_TTID..Offset_FileObject]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..Offset_FileKey]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..Offset_FileKey]);

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..Offset_ExtraInfo]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..Offset_ExtraInfo]);

                /// <summary>
                /// Retrieves the ExtraInfo field.
                /// </summary>
                public ulong ExtraInfo => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ExtraInfo..Offset_InfoClass]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ExtraInfo..Offset_InfoClass]);

                /// <summary>
                /// Retrieves the InfoClass field.
                /// </summary>
                public uint InfoClass => BitConverter.ToUInt32(_etwEvent.Data[Offset_InfoClass..]);

                /// <summary>
                /// Creates a new QueryInfoData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public QueryInfoData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_IrpPtr = -1;
                    _offset_TTID = -1;
                    _offset_FileObject = -1;
                    _offset_FileKey = -1;
                    _offset_ExtraInfo = -1;
                    _offset_InfoClass = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a FSControl event.
        /// </summary>
        public readonly ref struct FSControlEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "FSControl";

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
                Opcode = (EtwEventOpcode)Opcodes.FSControl,
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
            public FSControlData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new FSControlEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public FSControlEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a FSControlEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator FSControlEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a FSControl event.
            /// </summary>
            public ref struct FSControlData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_IrpPtr;
                private int _offset_TTID;
                private int _offset_FileObject;
                private int _offset_FileKey;
                private int _offset_ExtraInfo;
                private int _offset_InfoClass;

                private int Offset_IrpPtr
                {
                    get
                    {
                        if (_offset_IrpPtr == -1)
                        {
                            _offset_IrpPtr = 0;
                        }

                        return _offset_IrpPtr;
                    }
                }

                private int Offset_TTID
                {
                    get
                    {
                        if (_offset_TTID == -1)
                        {
                            _offset_TTID = Offset_IrpPtr + _etwEvent.AddressSize;
                        }

                        return _offset_TTID;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_TTID + _etwEvent.AddressSize;
                        }

                        return _offset_FileObject;
                    }
                }

                private int Offset_FileKey
                {
                    get
                    {
                        if (_offset_FileKey == -1)
                        {
                            _offset_FileKey = Offset_FileObject + _etwEvent.AddressSize;
                        }

                        return _offset_FileKey;
                    }
                }

                private int Offset_ExtraInfo
                {
                    get
                    {
                        if (_offset_ExtraInfo == -1)
                        {
                            _offset_ExtraInfo = Offset_FileKey + _etwEvent.AddressSize;
                        }

                        return _offset_ExtraInfo;
                    }
                }

                private int Offset_InfoClass
                {
                    get
                    {
                        if (_offset_InfoClass == -1)
                        {
                            _offset_InfoClass = Offset_ExtraInfo + _etwEvent.AddressSize;
                        }

                        return _offset_InfoClass;
                    }
                }

                /// <summary>
                /// Retrieves the IrpPtr field.
                /// </summary>
                public ulong IrpPtr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_IrpPtr..Offset_TTID]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_IrpPtr..Offset_TTID]);

                /// <summary>
                /// Retrieves the TTID field.
                /// </summary>
                public ulong TTID => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_TTID..Offset_FileObject]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_TTID..Offset_FileObject]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..Offset_FileKey]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..Offset_FileKey]);

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..Offset_ExtraInfo]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..Offset_ExtraInfo]);

                /// <summary>
                /// Retrieves the ExtraInfo field.
                /// </summary>
                public ulong ExtraInfo => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ExtraInfo..Offset_InfoClass]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ExtraInfo..Offset_InfoClass]);

                /// <summary>
                /// Retrieves the InfoClass field.
                /// </summary>
                public uint InfoClass => BitConverter.ToUInt32(_etwEvent.Data[Offset_InfoClass..]);

                /// <summary>
                /// Creates a new FSControlData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public FSControlData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_IrpPtr = -1;
                    _offset_TTID = -1;
                    _offset_FileObject = -1;
                    _offset_FileKey = -1;
                    _offset_ExtraInfo = -1;
                    _offset_InfoClass = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DirEnum event.
        /// </summary>
        public readonly ref struct DirEnumEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DirEnum";

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
                Opcode = (EtwEventOpcode)Opcodes.DirEnum,
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
            public DirEnumData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DirEnumEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DirEnumEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a DirEnumEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator DirEnumEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a DirEnum event.
            /// </summary>
            public ref struct DirEnumData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_IrpPtr;
                private int _offset_TTID;
                private int _offset_FileObject;
                private int _offset_FileKey;
                private int _offset_Length;
                private int _offset_InfoClass;
                private int _offset_FileIndex;
                private int _offset_FileName;

                private int Offset_IrpPtr
                {
                    get
                    {
                        if (_offset_IrpPtr == -1)
                        {
                            _offset_IrpPtr = 0;
                        }

                        return _offset_IrpPtr;
                    }
                }

                private int Offset_TTID
                {
                    get
                    {
                        if (_offset_TTID == -1)
                        {
                            _offset_TTID = Offset_IrpPtr + _etwEvent.AddressSize;
                        }

                        return _offset_TTID;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_TTID + _etwEvent.AddressSize;
                        }

                        return _offset_FileObject;
                    }
                }

                private int Offset_FileKey
                {
                    get
                    {
                        if (_offset_FileKey == -1)
                        {
                            _offset_FileKey = Offset_FileObject + _etwEvent.AddressSize;
                        }

                        return _offset_FileKey;
                    }
                }

                private int Offset_Length
                {
                    get
                    {
                        if (_offset_Length == -1)
                        {
                            _offset_Length = Offset_FileKey + _etwEvent.AddressSize;
                        }

                        return _offset_Length;
                    }
                }

                private int Offset_InfoClass
                {
                    get
                    {
                        if (_offset_InfoClass == -1)
                        {
                            _offset_InfoClass = Offset_Length + 4;
                        }

                        return _offset_InfoClass;
                    }
                }

                private int Offset_FileIndex
                {
                    get
                    {
                        if (_offset_FileIndex == -1)
                        {
                            _offset_FileIndex = Offset_InfoClass + 4;
                        }

                        return _offset_FileIndex;
                    }
                }

                private int Offset_FileName
                {
                    get
                    {
                        if (_offset_FileName == -1)
                        {
                            _offset_FileName = Offset_FileIndex + 4;
                        }

                        return _offset_FileName;
                    }
                }

                /// <summary>
                /// Retrieves the IrpPtr field.
                /// </summary>
                public ulong IrpPtr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_IrpPtr..Offset_TTID]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_IrpPtr..Offset_TTID]);

                /// <summary>
                /// Retrieves the TTID field.
                /// </summary>
                public ulong TTID => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_TTID..Offset_FileObject]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_TTID..Offset_FileObject]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..Offset_FileKey]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..Offset_FileKey]);

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..Offset_Length]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..Offset_Length]);

                /// <summary>
                /// Retrieves the Length field.
                /// </summary>
                public uint Length => BitConverter.ToUInt32(_etwEvent.Data[Offset_Length..Offset_InfoClass]);

                /// <summary>
                /// Retrieves the InfoClass field.
                /// </summary>
                public uint InfoClass => BitConverter.ToUInt32(_etwEvent.Data[Offset_InfoClass..Offset_FileIndex]);

                /// <summary>
                /// Retrieves the FileIndex field.
                /// </summary>
                public uint FileIndex => BitConverter.ToUInt32(_etwEvent.Data[Offset_FileIndex..Offset_FileName]);

                /// <summary>
                /// Retrieves the FileName field.
                /// </summary>
                public string FileName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FileName..]);

                /// <summary>
                /// Creates a new DirEnumData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DirEnumData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_IrpPtr = -1;
                    _offset_TTID = -1;
                    _offset_FileObject = -1;
                    _offset_FileKey = -1;
                    _offset_Length = -1;
                    _offset_InfoClass = -1;
                    _offset_FileIndex = -1;
                    _offset_FileName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DirNotify event.
        /// </summary>
        public readonly ref struct DirNotifyEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DirNotify";

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
                Opcode = (EtwEventOpcode)Opcodes.DirNotify,
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
            public DirNotifyData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DirNotifyEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DirNotifyEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a DirNotifyEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator DirNotifyEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a DirNotify event.
            /// </summary>
            public ref struct DirNotifyData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_IrpPtr;
                private int _offset_TTID;
                private int _offset_FileObject;
                private int _offset_FileKey;
                private int _offset_Length;
                private int _offset_InfoClass;
                private int _offset_FileIndex;
                private int _offset_FileName;

                private int Offset_IrpPtr
                {
                    get
                    {
                        if (_offset_IrpPtr == -1)
                        {
                            _offset_IrpPtr = 0;
                        }

                        return _offset_IrpPtr;
                    }
                }

                private int Offset_TTID
                {
                    get
                    {
                        if (_offset_TTID == -1)
                        {
                            _offset_TTID = Offset_IrpPtr + _etwEvent.AddressSize;
                        }

                        return _offset_TTID;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_TTID + _etwEvent.AddressSize;
                        }

                        return _offset_FileObject;
                    }
                }

                private int Offset_FileKey
                {
                    get
                    {
                        if (_offset_FileKey == -1)
                        {
                            _offset_FileKey = Offset_FileObject + _etwEvent.AddressSize;
                        }

                        return _offset_FileKey;
                    }
                }

                private int Offset_Length
                {
                    get
                    {
                        if (_offset_Length == -1)
                        {
                            _offset_Length = Offset_FileKey + _etwEvent.AddressSize;
                        }

                        return _offset_Length;
                    }
                }

                private int Offset_InfoClass
                {
                    get
                    {
                        if (_offset_InfoClass == -1)
                        {
                            _offset_InfoClass = Offset_Length + 4;
                        }

                        return _offset_InfoClass;
                    }
                }

                private int Offset_FileIndex
                {
                    get
                    {
                        if (_offset_FileIndex == -1)
                        {
                            _offset_FileIndex = Offset_InfoClass + 4;
                        }

                        return _offset_FileIndex;
                    }
                }

                private int Offset_FileName
                {
                    get
                    {
                        if (_offset_FileName == -1)
                        {
                            _offset_FileName = Offset_FileIndex + 4;
                        }

                        return _offset_FileName;
                    }
                }

                /// <summary>
                /// Retrieves the IrpPtr field.
                /// </summary>
                public ulong IrpPtr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_IrpPtr..Offset_TTID]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_IrpPtr..Offset_TTID]);

                /// <summary>
                /// Retrieves the TTID field.
                /// </summary>
                public ulong TTID => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_TTID..Offset_FileObject]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_TTID..Offset_FileObject]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..Offset_FileKey]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..Offset_FileKey]);

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..Offset_Length]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..Offset_Length]);

                /// <summary>
                /// Retrieves the Length field.
                /// </summary>
                public uint Length => BitConverter.ToUInt32(_etwEvent.Data[Offset_Length..Offset_InfoClass]);

                /// <summary>
                /// Retrieves the InfoClass field.
                /// </summary>
                public uint InfoClass => BitConverter.ToUInt32(_etwEvent.Data[Offset_InfoClass..Offset_FileIndex]);

                /// <summary>
                /// Retrieves the FileIndex field.
                /// </summary>
                public uint FileIndex => BitConverter.ToUInt32(_etwEvent.Data[Offset_FileIndex..Offset_FileName]);

                /// <summary>
                /// Retrieves the FileName field.
                /// </summary>
                public string FileName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FileName..]);

                /// <summary>
                /// Creates a new DirNotifyData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DirNotifyData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_IrpPtr = -1;
                    _offset_TTID = -1;
                    _offset_FileObject = -1;
                    _offset_FileKey = -1;
                    _offset_Length = -1;
                    _offset_InfoClass = -1;
                    _offset_FileIndex = -1;
                    _offset_FileName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a OperationEnd event.
        /// </summary>
        public readonly ref struct OperationEndEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "OperationEnd";

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
                Opcode = (EtwEventOpcode)Opcodes.OperationEnd,
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
            public OperationEndData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new OperationEndEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public OperationEndEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a OperationEndEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator OperationEndEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a OperationEnd event.
            /// </summary>
            public ref struct OperationEndData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_IrpPtr;
                private int _offset_ExtraInfo;
                private int _offset_NtStatus;

                private int Offset_IrpPtr
                {
                    get
                    {
                        if (_offset_IrpPtr == -1)
                        {
                            _offset_IrpPtr = 0;
                        }

                        return _offset_IrpPtr;
                    }
                }

                private int Offset_ExtraInfo
                {
                    get
                    {
                        if (_offset_ExtraInfo == -1)
                        {
                            _offset_ExtraInfo = Offset_IrpPtr + _etwEvent.AddressSize;
                        }

                        return _offset_ExtraInfo;
                    }
                }

                private int Offset_NtStatus
                {
                    get
                    {
                        if (_offset_NtStatus == -1)
                        {
                            _offset_NtStatus = Offset_ExtraInfo + _etwEvent.AddressSize;
                        }

                        return _offset_NtStatus;
                    }
                }

                /// <summary>
                /// Retrieves the IrpPtr field.
                /// </summary>
                public ulong IrpPtr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_IrpPtr..Offset_ExtraInfo]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_IrpPtr..Offset_ExtraInfo]);

                /// <summary>
                /// Retrieves the ExtraInfo field.
                /// </summary>
                public ulong ExtraInfo => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ExtraInfo..Offset_NtStatus]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ExtraInfo..Offset_NtStatus]);

                /// <summary>
                /// Retrieves the NtStatus field.
                /// </summary>
                public uint NtStatus => BitConverter.ToUInt32(_etwEvent.Data[Offset_NtStatus..]);

                /// <summary>
                /// Creates a new OperationEndData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public OperationEndData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_IrpPtr = -1;
                    _offset_ExtraInfo = -1;
                    _offset_NtStatus = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a MapFile event.
        /// </summary>
        public readonly ref struct MapFileEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "MapFile";

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
                Opcode = (EtwEventOpcode)Opcodes.MapFile,
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
            public MapFileData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new MapFileEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public MapFileEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a MapFileEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator MapFileEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a MapFile event.
            /// </summary>
            public ref struct MapFileData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ViewBase;
                private int _offset_FileObject;
                private int _offset_MiscInfo;
                private int _offset_ViewSize;
                private int _offset_ProcessId;

                private int Offset_ViewBase
                {
                    get
                    {
                        if (_offset_ViewBase == -1)
                        {
                            _offset_ViewBase = 0;
                        }

                        return _offset_ViewBase;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_ViewBase + _etwEvent.AddressSize;
                        }

                        return _offset_FileObject;
                    }
                }

                private int Offset_MiscInfo
                {
                    get
                    {
                        if (_offset_MiscInfo == -1)
                        {
                            _offset_MiscInfo = Offset_FileObject + _etwEvent.AddressSize;
                        }

                        return _offset_MiscInfo;
                    }
                }

                private int Offset_ViewSize
                {
                    get
                    {
                        if (_offset_ViewSize == -1)
                        {
                            _offset_ViewSize = Offset_MiscInfo + 8;
                        }

                        return _offset_ViewSize;
                    }
                }

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = Offset_ViewSize + _etwEvent.AddressSize;
                        }

                        return _offset_ProcessId;
                    }
                }

                /// <summary>
                /// Retrieves the ViewBase field.
                /// </summary>
                public ulong ViewBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ViewBase..Offset_FileObject]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ViewBase..Offset_FileObject]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..Offset_MiscInfo]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..Offset_MiscInfo]);

                /// <summary>
                /// Retrieves the MiscInfo field.
                /// </summary>
                public ulong MiscInfo => BitConverter.ToUInt64(_etwEvent.Data[Offset_MiscInfo..Offset_ViewSize]);

                /// <summary>
                /// Retrieves the ViewSize field.
                /// </summary>
                public ulong ViewSize => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ViewSize..Offset_ProcessId]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ViewSize..Offset_ProcessId]);

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..]);

                /// <summary>
                /// Creates a new MapFileData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public MapFileData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ViewBase = -1;
                    _offset_FileObject = -1;
                    _offset_MiscInfo = -1;
                    _offset_ViewSize = -1;
                    _offset_ProcessId = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a UnmapFile event.
        /// </summary>
        public readonly ref struct UnmapFileEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "UnmapFile";

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
                Opcode = (EtwEventOpcode)Opcodes.UnmapFile,
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
            public UnmapFileData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new UnmapFileEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public UnmapFileEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a UnmapFileEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator UnmapFileEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a UnmapFile event.
            /// </summary>
            public ref struct UnmapFileData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ViewBase;
                private int _offset_FileObject;
                private int _offset_MiscInfo;
                private int _offset_ViewSize;
                private int _offset_ProcessId;

                private int Offset_ViewBase
                {
                    get
                    {
                        if (_offset_ViewBase == -1)
                        {
                            _offset_ViewBase = 0;
                        }

                        return _offset_ViewBase;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_ViewBase + _etwEvent.AddressSize;
                        }

                        return _offset_FileObject;
                    }
                }

                private int Offset_MiscInfo
                {
                    get
                    {
                        if (_offset_MiscInfo == -1)
                        {
                            _offset_MiscInfo = Offset_FileObject + _etwEvent.AddressSize;
                        }

                        return _offset_MiscInfo;
                    }
                }

                private int Offset_ViewSize
                {
                    get
                    {
                        if (_offset_ViewSize == -1)
                        {
                            _offset_ViewSize = Offset_MiscInfo + 8;
                        }

                        return _offset_ViewSize;
                    }
                }

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = Offset_ViewSize + _etwEvent.AddressSize;
                        }

                        return _offset_ProcessId;
                    }
                }

                /// <summary>
                /// Retrieves the ViewBase field.
                /// </summary>
                public ulong ViewBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ViewBase..Offset_FileObject]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ViewBase..Offset_FileObject]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..Offset_MiscInfo]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..Offset_MiscInfo]);

                /// <summary>
                /// Retrieves the MiscInfo field.
                /// </summary>
                public ulong MiscInfo => BitConverter.ToUInt64(_etwEvent.Data[Offset_MiscInfo..Offset_ViewSize]);

                /// <summary>
                /// Retrieves the ViewSize field.
                /// </summary>
                public ulong ViewSize => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ViewSize..Offset_ProcessId]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ViewSize..Offset_ProcessId]);

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..]);

                /// <summary>
                /// Creates a new UnmapFileData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public UnmapFileData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ViewBase = -1;
                    _offset_FileObject = -1;
                    _offset_MiscInfo = -1;
                    _offset_ViewSize = -1;
                    _offset_ProcessId = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a MapFileDCStart event.
        /// </summary>
        public readonly ref struct MapFileDCStartEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "MapFileDCStart";

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
                Opcode = (EtwEventOpcode)Opcodes.MapFileDCStart,
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
            public MapFileDCStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new MapFileDCStartEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public MapFileDCStartEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a MapFileDCStartEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator MapFileDCStartEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a MapFileDCStart event.
            /// </summary>
            public ref struct MapFileDCStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ViewBase;
                private int _offset_FileObject;
                private int _offset_MiscInfo;
                private int _offset_ViewSize;
                private int _offset_ProcessId;

                private int Offset_ViewBase
                {
                    get
                    {
                        if (_offset_ViewBase == -1)
                        {
                            _offset_ViewBase = 0;
                        }

                        return _offset_ViewBase;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_ViewBase + _etwEvent.AddressSize;
                        }

                        return _offset_FileObject;
                    }
                }

                private int Offset_MiscInfo
                {
                    get
                    {
                        if (_offset_MiscInfo == -1)
                        {
                            _offset_MiscInfo = Offset_FileObject + _etwEvent.AddressSize;
                        }

                        return _offset_MiscInfo;
                    }
                }

                private int Offset_ViewSize
                {
                    get
                    {
                        if (_offset_ViewSize == -1)
                        {
                            _offset_ViewSize = Offset_MiscInfo + 8;
                        }

                        return _offset_ViewSize;
                    }
                }

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = Offset_ViewSize + _etwEvent.AddressSize;
                        }

                        return _offset_ProcessId;
                    }
                }

                /// <summary>
                /// Retrieves the ViewBase field.
                /// </summary>
                public ulong ViewBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ViewBase..Offset_FileObject]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ViewBase..Offset_FileObject]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..Offset_MiscInfo]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..Offset_MiscInfo]);

                /// <summary>
                /// Retrieves the MiscInfo field.
                /// </summary>
                public ulong MiscInfo => BitConverter.ToUInt64(_etwEvent.Data[Offset_MiscInfo..Offset_ViewSize]);

                /// <summary>
                /// Retrieves the ViewSize field.
                /// </summary>
                public ulong ViewSize => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ViewSize..Offset_ProcessId]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ViewSize..Offset_ProcessId]);

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..]);

                /// <summary>
                /// Creates a new MapFileDCStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public MapFileDCStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ViewBase = -1;
                    _offset_FileObject = -1;
                    _offset_MiscInfo = -1;
                    _offset_ViewSize = -1;
                    _offset_ProcessId = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a MapFileDCEnd event.
        /// </summary>
        public readonly ref struct MapFileDCEndEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "MapFileDCEnd";

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
                Opcode = (EtwEventOpcode)Opcodes.MapFileDCEnd,
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
            public MapFileDCEndData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new MapFileDCEndEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public MapFileDCEndEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a MapFileDCEndEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator MapFileDCEndEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a MapFileDCEnd event.
            /// </summary>
            public ref struct MapFileDCEndData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ViewBase;
                private int _offset_FileObject;
                private int _offset_MiscInfo;
                private int _offset_ViewSize;
                private int _offset_ProcessId;

                private int Offset_ViewBase
                {
                    get
                    {
                        if (_offset_ViewBase == -1)
                        {
                            _offset_ViewBase = 0;
                        }

                        return _offset_ViewBase;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_ViewBase + _etwEvent.AddressSize;
                        }

                        return _offset_FileObject;
                    }
                }

                private int Offset_MiscInfo
                {
                    get
                    {
                        if (_offset_MiscInfo == -1)
                        {
                            _offset_MiscInfo = Offset_FileObject + _etwEvent.AddressSize;
                        }

                        return _offset_MiscInfo;
                    }
                }

                private int Offset_ViewSize
                {
                    get
                    {
                        if (_offset_ViewSize == -1)
                        {
                            _offset_ViewSize = Offset_MiscInfo + 8;
                        }

                        return _offset_ViewSize;
                    }
                }

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = Offset_ViewSize + _etwEvent.AddressSize;
                        }

                        return _offset_ProcessId;
                    }
                }

                /// <summary>
                /// Retrieves the ViewBase field.
                /// </summary>
                public ulong ViewBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ViewBase..Offset_FileObject]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ViewBase..Offset_FileObject]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..Offset_MiscInfo]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..Offset_MiscInfo]);

                /// <summary>
                /// Retrieves the MiscInfo field.
                /// </summary>
                public ulong MiscInfo => BitConverter.ToUInt64(_etwEvent.Data[Offset_MiscInfo..Offset_ViewSize]);

                /// <summary>
                /// Retrieves the ViewSize field.
                /// </summary>
                public ulong ViewSize => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ViewSize..Offset_ProcessId]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ViewSize..Offset_ProcessId]);

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..]);

                /// <summary>
                /// Creates a new MapFileDCEndData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public MapFileDCEndData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ViewBase = -1;
                    _offset_FileObject = -1;
                    _offset_MiscInfo = -1;
                    _offset_ViewSize = -1;
                    _offset_ProcessId = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Name event.
        /// </summary>
        public readonly ref struct NameEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Name";

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
            public NameData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new NameEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public NameEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a NameEventV3.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator NameEventV3(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Name event.
            /// </summary>
            public ref struct NameData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_FileObject;
                private int _offset_FileName;

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = 0;
                        }

                        return _offset_FileObject;
                    }
                }

                private int Offset_FileName
                {
                    get
                    {
                        if (_offset_FileName == -1)
                        {
                            _offset_FileName = Offset_FileObject + _etwEvent.AddressSize;
                        }

                        return _offset_FileName;
                    }
                }

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..Offset_FileName]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..Offset_FileName]);

                /// <summary>
                /// Retrieves the FileName field.
                /// </summary>
                public string FileName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FileName..]);

                /// <summary>
                /// Creates a new NameData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public NameData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_FileObject = -1;
                    _offset_FileName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a FileCreate event.
        /// </summary>
        public readonly ref struct FileCreateEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "FileCreate";

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
                Opcode = (EtwEventOpcode)Opcodes.FileCreate,
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
            public FileCreateData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new FileCreateEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public FileCreateEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a FileCreateEventV3.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator FileCreateEventV3(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a FileCreate event.
            /// </summary>
            public ref struct FileCreateData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_FileObject;
                private int _offset_FileName;

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = 0;
                        }

                        return _offset_FileObject;
                    }
                }

                private int Offset_FileName
                {
                    get
                    {
                        if (_offset_FileName == -1)
                        {
                            _offset_FileName = Offset_FileObject + _etwEvent.AddressSize;
                        }

                        return _offset_FileName;
                    }
                }

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..Offset_FileName]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..Offset_FileName]);

                /// <summary>
                /// Retrieves the FileName field.
                /// </summary>
                public string FileName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FileName..]);

                /// <summary>
                /// Creates a new FileCreateData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public FileCreateData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_FileObject = -1;
                    _offset_FileName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a FileDelete event.
        /// </summary>
        public readonly ref struct FileDeleteEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "FileDelete";

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
                Opcode = (EtwEventOpcode)Opcodes.FileDelete,
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
            public FileDeleteData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new FileDeleteEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public FileDeleteEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a FileDeleteEventV3.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator FileDeleteEventV3(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a FileDelete event.
            /// </summary>
            public ref struct FileDeleteData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_FileObject;
                private int _offset_FileName;

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = 0;
                        }

                        return _offset_FileObject;
                    }
                }

                private int Offset_FileName
                {
                    get
                    {
                        if (_offset_FileName == -1)
                        {
                            _offset_FileName = Offset_FileObject + _etwEvent.AddressSize;
                        }

                        return _offset_FileName;
                    }
                }

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..Offset_FileName]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..Offset_FileName]);

                /// <summary>
                /// Retrieves the FileName field.
                /// </summary>
                public string FileName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FileName..]);

                /// <summary>
                /// Creates a new FileDeleteData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public FileDeleteData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_FileObject = -1;
                    _offset_FileName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a FileRundown event.
        /// </summary>
        public readonly ref struct FileRundownEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "FileRundown";

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
                Opcode = (EtwEventOpcode)Opcodes.FileRundown,
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
            public FileRundownData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new FileRundownEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public FileRundownEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a FileRundownEventV3.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator FileRundownEventV3(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a FileRundown event.
            /// </summary>
            public ref struct FileRundownData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_FileObject;
                private int _offset_FileName;

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = 0;
                        }

                        return _offset_FileObject;
                    }
                }

                private int Offset_FileName
                {
                    get
                    {
                        if (_offset_FileName == -1)
                        {
                            _offset_FileName = Offset_FileObject + _etwEvent.AddressSize;
                        }

                        return _offset_FileName;
                    }
                }

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..Offset_FileName]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..Offset_FileName]);

                /// <summary>
                /// Retrieves the FileName field.
                /// </summary>
                public string FileName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FileName..]);

                /// <summary>
                /// Creates a new FileRundownData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public FileRundownData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_FileObject = -1;
                    _offset_FileName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Create event.
        /// </summary>
        public readonly ref struct CreateEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Create";

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
                Opcode = (EtwEventOpcode)Opcodes.Create,
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
            public CreateData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new CreateEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public CreateEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a CreateEventV3.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator CreateEventV3(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Create event.
            /// </summary>
            public ref struct CreateData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_IrpPtr;
                private int _offset_FileObject;
                private int _offset_TTID;
                private int _offset_CreateOptions;
                private int _offset_FileAttributes;
                private int _offset_ShareAccess;
                private int _offset_OpenPath;

                private int Offset_IrpPtr
                {
                    get
                    {
                        if (_offset_IrpPtr == -1)
                        {
                            _offset_IrpPtr = 0;
                        }

                        return _offset_IrpPtr;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_IrpPtr + _etwEvent.AddressSize;
                        }

                        return _offset_FileObject;
                    }
                }

                private int Offset_TTID
                {
                    get
                    {
                        if (_offset_TTID == -1)
                        {
                            _offset_TTID = Offset_FileObject + _etwEvent.AddressSize;
                        }

                        return _offset_TTID;
                    }
                }

                private int Offset_CreateOptions
                {
                    get
                    {
                        if (_offset_CreateOptions == -1)
                        {
                            _offset_CreateOptions = Offset_TTID + 4;
                        }

                        return _offset_CreateOptions;
                    }
                }

                private int Offset_FileAttributes
                {
                    get
                    {
                        if (_offset_FileAttributes == -1)
                        {
                            _offset_FileAttributes = Offset_CreateOptions + 4;
                        }

                        return _offset_FileAttributes;
                    }
                }

                private int Offset_ShareAccess
                {
                    get
                    {
                        if (_offset_ShareAccess == -1)
                        {
                            _offset_ShareAccess = Offset_FileAttributes + 4;
                        }

                        return _offset_ShareAccess;
                    }
                }

                private int Offset_OpenPath
                {
                    get
                    {
                        if (_offset_OpenPath == -1)
                        {
                            _offset_OpenPath = Offset_ShareAccess + 4;
                        }

                        return _offset_OpenPath;
                    }
                }

                /// <summary>
                /// Retrieves the IrpPtr field.
                /// </summary>
                public ulong IrpPtr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_IrpPtr..Offset_FileObject]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_IrpPtr..Offset_FileObject]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..Offset_TTID]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..Offset_TTID]);

                /// <summary>
                /// Retrieves the TTID field.
                /// </summary>
                public uint TTID => BitConverter.ToUInt32(_etwEvent.Data[Offset_TTID..Offset_CreateOptions]);

                /// <summary>
                /// Retrieves the CreateOptions field.
                /// </summary>
                public uint CreateOptions => BitConverter.ToUInt32(_etwEvent.Data[Offset_CreateOptions..Offset_FileAttributes]);

                /// <summary>
                /// Retrieves the FileAttributes field.
                /// </summary>
                public uint FileAttributes => BitConverter.ToUInt32(_etwEvent.Data[Offset_FileAttributes..Offset_ShareAccess]);

                /// <summary>
                /// Retrieves the ShareAccess field.
                /// </summary>
                public uint ShareAccess => BitConverter.ToUInt32(_etwEvent.Data[Offset_ShareAccess..Offset_OpenPath]);

                /// <summary>
                /// Retrieves the OpenPath field.
                /// </summary>
                public string OpenPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_OpenPath..]);

                /// <summary>
                /// Creates a new CreateData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public CreateData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_IrpPtr = -1;
                    _offset_FileObject = -1;
                    _offset_TTID = -1;
                    _offset_CreateOptions = -1;
                    _offset_FileAttributes = -1;
                    _offset_ShareAccess = -1;
                    _offset_OpenPath = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Cleanup event.
        /// </summary>
        public readonly ref struct CleanupEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Cleanup";

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
                Opcode = (EtwEventOpcode)Opcodes.Cleanup,
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
            public CleanupData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new CleanupEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public CleanupEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a CleanupEventV3.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator CleanupEventV3(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Cleanup event.
            /// </summary>
            public ref struct CleanupData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_IrpPtr;
                private int _offset_FileObject;
                private int _offset_FileKey;
                private int _offset_TTID;

                private int Offset_IrpPtr
                {
                    get
                    {
                        if (_offset_IrpPtr == -1)
                        {
                            _offset_IrpPtr = 0;
                        }

                        return _offset_IrpPtr;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_IrpPtr + _etwEvent.AddressSize;
                        }

                        return _offset_FileObject;
                    }
                }

                private int Offset_FileKey
                {
                    get
                    {
                        if (_offset_FileKey == -1)
                        {
                            _offset_FileKey = Offset_FileObject + _etwEvent.AddressSize;
                        }

                        return _offset_FileKey;
                    }
                }

                private int Offset_TTID
                {
                    get
                    {
                        if (_offset_TTID == -1)
                        {
                            _offset_TTID = Offset_FileKey + _etwEvent.AddressSize;
                        }

                        return _offset_TTID;
                    }
                }

                /// <summary>
                /// Retrieves the IrpPtr field.
                /// </summary>
                public ulong IrpPtr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_IrpPtr..Offset_FileObject]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_IrpPtr..Offset_FileObject]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..Offset_FileKey]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..Offset_FileKey]);

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..Offset_TTID]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..Offset_TTID]);

                /// <summary>
                /// Retrieves the TTID field.
                /// </summary>
                public uint TTID => BitConverter.ToUInt32(_etwEvent.Data[Offset_TTID..]);

                /// <summary>
                /// Creates a new CleanupData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public CleanupData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_IrpPtr = -1;
                    _offset_FileObject = -1;
                    _offset_FileKey = -1;
                    _offset_TTID = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Close event.
        /// </summary>
        public readonly ref struct CloseEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Close";

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
                Opcode = (EtwEventOpcode)Opcodes.Close,
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
            public CloseData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new CloseEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public CloseEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a CloseEventV3.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator CloseEventV3(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Close event.
            /// </summary>
            public ref struct CloseData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_IrpPtr;
                private int _offset_FileObject;
                private int _offset_FileKey;
                private int _offset_TTID;

                private int Offset_IrpPtr
                {
                    get
                    {
                        if (_offset_IrpPtr == -1)
                        {
                            _offset_IrpPtr = 0;
                        }

                        return _offset_IrpPtr;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_IrpPtr + _etwEvent.AddressSize;
                        }

                        return _offset_FileObject;
                    }
                }

                private int Offset_FileKey
                {
                    get
                    {
                        if (_offset_FileKey == -1)
                        {
                            _offset_FileKey = Offset_FileObject + _etwEvent.AddressSize;
                        }

                        return _offset_FileKey;
                    }
                }

                private int Offset_TTID
                {
                    get
                    {
                        if (_offset_TTID == -1)
                        {
                            _offset_TTID = Offset_FileKey + _etwEvent.AddressSize;
                        }

                        return _offset_TTID;
                    }
                }

                /// <summary>
                /// Retrieves the IrpPtr field.
                /// </summary>
                public ulong IrpPtr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_IrpPtr..Offset_FileObject]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_IrpPtr..Offset_FileObject]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..Offset_FileKey]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..Offset_FileKey]);

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..Offset_TTID]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..Offset_TTID]);

                /// <summary>
                /// Retrieves the TTID field.
                /// </summary>
                public uint TTID => BitConverter.ToUInt32(_etwEvent.Data[Offset_TTID..]);

                /// <summary>
                /// Creates a new CloseData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public CloseData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_IrpPtr = -1;
                    _offset_FileObject = -1;
                    _offset_FileKey = -1;
                    _offset_TTID = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Flush event.
        /// </summary>
        public readonly ref struct FlushEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Flush";

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
                Opcode = (EtwEventOpcode)Opcodes.Flush,
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
            public FlushData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new FlushEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public FlushEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a FlushEventV3.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator FlushEventV3(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Flush event.
            /// </summary>
            public ref struct FlushData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_IrpPtr;
                private int _offset_FileObject;
                private int _offset_FileKey;
                private int _offset_TTID;

                private int Offset_IrpPtr
                {
                    get
                    {
                        if (_offset_IrpPtr == -1)
                        {
                            _offset_IrpPtr = 0;
                        }

                        return _offset_IrpPtr;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_IrpPtr + _etwEvent.AddressSize;
                        }

                        return _offset_FileObject;
                    }
                }

                private int Offset_FileKey
                {
                    get
                    {
                        if (_offset_FileKey == -1)
                        {
                            _offset_FileKey = Offset_FileObject + _etwEvent.AddressSize;
                        }

                        return _offset_FileKey;
                    }
                }

                private int Offset_TTID
                {
                    get
                    {
                        if (_offset_TTID == -1)
                        {
                            _offset_TTID = Offset_FileKey + _etwEvent.AddressSize;
                        }

                        return _offset_TTID;
                    }
                }

                /// <summary>
                /// Retrieves the IrpPtr field.
                /// </summary>
                public ulong IrpPtr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_IrpPtr..Offset_FileObject]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_IrpPtr..Offset_FileObject]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..Offset_FileKey]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..Offset_FileKey]);

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..Offset_TTID]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..Offset_TTID]);

                /// <summary>
                /// Retrieves the TTID field.
                /// </summary>
                public uint TTID => BitConverter.ToUInt32(_etwEvent.Data[Offset_TTID..]);

                /// <summary>
                /// Creates a new FlushData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public FlushData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_IrpPtr = -1;
                    _offset_FileObject = -1;
                    _offset_FileKey = -1;
                    _offset_TTID = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Read event.
        /// </summary>
        public readonly ref struct ReadEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Read";

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
                Opcode = (EtwEventOpcode)Opcodes.Read,
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
            public ReadData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ReadEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ReadEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a ReadEventV3.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator ReadEventV3(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Read event.
            /// </summary>
            public ref struct ReadData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Offset;
                private int _offset_IrpPtr;
                private int _offset_FileObject;
                private int _offset_FileKey;
                private int _offset_TTID;
                private int _offset_IoSize;
                private int _offset_IoFlags;

                private int Offset_Offset
                {
                    get
                    {
                        if (_offset_Offset == -1)
                        {
                            _offset_Offset = 0;
                        }

                        return _offset_Offset;
                    }
                }

                private int Offset_IrpPtr
                {
                    get
                    {
                        if (_offset_IrpPtr == -1)
                        {
                            _offset_IrpPtr = Offset_Offset + 8;
                        }

                        return _offset_IrpPtr;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_IrpPtr + _etwEvent.AddressSize;
                        }

                        return _offset_FileObject;
                    }
                }

                private int Offset_FileKey
                {
                    get
                    {
                        if (_offset_FileKey == -1)
                        {
                            _offset_FileKey = Offset_FileObject + _etwEvent.AddressSize;
                        }

                        return _offset_FileKey;
                    }
                }

                private int Offset_TTID
                {
                    get
                    {
                        if (_offset_TTID == -1)
                        {
                            _offset_TTID = Offset_FileKey + _etwEvent.AddressSize;
                        }

                        return _offset_TTID;
                    }
                }

                private int Offset_IoSize
                {
                    get
                    {
                        if (_offset_IoSize == -1)
                        {
                            _offset_IoSize = Offset_TTID + 4;
                        }

                        return _offset_IoSize;
                    }
                }

                private int Offset_IoFlags
                {
                    get
                    {
                        if (_offset_IoFlags == -1)
                        {
                            _offset_IoFlags = Offset_IoSize + 4;
                        }

                        return _offset_IoFlags;
                    }
                }

                /// <summary>
                /// Retrieves the Offset field.
                /// </summary>
                public ulong Offset => BitConverter.ToUInt64(_etwEvent.Data[Offset_Offset..Offset_IrpPtr]);

                /// <summary>
                /// Retrieves the IrpPtr field.
                /// </summary>
                public ulong IrpPtr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_IrpPtr..Offset_FileObject]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_IrpPtr..Offset_FileObject]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..Offset_FileKey]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..Offset_FileKey]);

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..Offset_TTID]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..Offset_TTID]);

                /// <summary>
                /// Retrieves the TTID field.
                /// </summary>
                public uint TTID => BitConverter.ToUInt32(_etwEvent.Data[Offset_TTID..Offset_IoSize]);

                /// <summary>
                /// Retrieves the IoSize field.
                /// </summary>
                public uint IoSize => BitConverter.ToUInt32(_etwEvent.Data[Offset_IoSize..Offset_IoFlags]);

                /// <summary>
                /// Retrieves the IoFlags field.
                /// </summary>
                public uint IoFlags => BitConverter.ToUInt32(_etwEvent.Data[Offset_IoFlags..]);

                /// <summary>
                /// Creates a new ReadData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ReadData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Offset = -1;
                    _offset_IrpPtr = -1;
                    _offset_FileObject = -1;
                    _offset_FileKey = -1;
                    _offset_TTID = -1;
                    _offset_IoSize = -1;
                    _offset_IoFlags = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Write event.
        /// </summary>
        public readonly ref struct WriteEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Write";

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
                Opcode = (EtwEventOpcode)Opcodes.Write,
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
            public WriteData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new WriteEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public WriteEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a WriteEventV3.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator WriteEventV3(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Write event.
            /// </summary>
            public ref struct WriteData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Offset;
                private int _offset_IrpPtr;
                private int _offset_FileObject;
                private int _offset_FileKey;
                private int _offset_TTID;
                private int _offset_IoSize;
                private int _offset_IoFlags;

                private int Offset_Offset
                {
                    get
                    {
                        if (_offset_Offset == -1)
                        {
                            _offset_Offset = 0;
                        }

                        return _offset_Offset;
                    }
                }

                private int Offset_IrpPtr
                {
                    get
                    {
                        if (_offset_IrpPtr == -1)
                        {
                            _offset_IrpPtr = Offset_Offset + 8;
                        }

                        return _offset_IrpPtr;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_IrpPtr + _etwEvent.AddressSize;
                        }

                        return _offset_FileObject;
                    }
                }

                private int Offset_FileKey
                {
                    get
                    {
                        if (_offset_FileKey == -1)
                        {
                            _offset_FileKey = Offset_FileObject + _etwEvent.AddressSize;
                        }

                        return _offset_FileKey;
                    }
                }

                private int Offset_TTID
                {
                    get
                    {
                        if (_offset_TTID == -1)
                        {
                            _offset_TTID = Offset_FileKey + _etwEvent.AddressSize;
                        }

                        return _offset_TTID;
                    }
                }

                private int Offset_IoSize
                {
                    get
                    {
                        if (_offset_IoSize == -1)
                        {
                            _offset_IoSize = Offset_TTID + 4;
                        }

                        return _offset_IoSize;
                    }
                }

                private int Offset_IoFlags
                {
                    get
                    {
                        if (_offset_IoFlags == -1)
                        {
                            _offset_IoFlags = Offset_IoSize + 4;
                        }

                        return _offset_IoFlags;
                    }
                }

                /// <summary>
                /// Retrieves the Offset field.
                /// </summary>
                public ulong Offset => BitConverter.ToUInt64(_etwEvent.Data[Offset_Offset..Offset_IrpPtr]);

                /// <summary>
                /// Retrieves the IrpPtr field.
                /// </summary>
                public ulong IrpPtr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_IrpPtr..Offset_FileObject]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_IrpPtr..Offset_FileObject]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..Offset_FileKey]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..Offset_FileKey]);

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..Offset_TTID]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..Offset_TTID]);

                /// <summary>
                /// Retrieves the TTID field.
                /// </summary>
                public uint TTID => BitConverter.ToUInt32(_etwEvent.Data[Offset_TTID..Offset_IoSize]);

                /// <summary>
                /// Retrieves the IoSize field.
                /// </summary>
                public uint IoSize => BitConverter.ToUInt32(_etwEvent.Data[Offset_IoSize..Offset_IoFlags]);

                /// <summary>
                /// Retrieves the IoFlags field.
                /// </summary>
                public uint IoFlags => BitConverter.ToUInt32(_etwEvent.Data[Offset_IoFlags..]);

                /// <summary>
                /// Creates a new WriteData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public WriteData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Offset = -1;
                    _offset_IrpPtr = -1;
                    _offset_FileObject = -1;
                    _offset_FileKey = -1;
                    _offset_TTID = -1;
                    _offset_IoSize = -1;
                    _offset_IoFlags = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a SetInfo event.
        /// </summary>
        public readonly ref struct SetInfoEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SetInfo";

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
                Opcode = (EtwEventOpcode)Opcodes.SetInfo,
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
            public SetInfoData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new SetInfoEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SetInfoEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a SetInfoEventV3.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator SetInfoEventV3(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a SetInfo event.
            /// </summary>
            public ref struct SetInfoData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_IrpPtr;
                private int _offset_FileObject;
                private int _offset_FileKey;
                private int _offset_ExtraInfo;
                private int _offset_TTID;
                private int _offset_InfoClass;

                private int Offset_IrpPtr
                {
                    get
                    {
                        if (_offset_IrpPtr == -1)
                        {
                            _offset_IrpPtr = 0;
                        }

                        return _offset_IrpPtr;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_IrpPtr + _etwEvent.AddressSize;
                        }

                        return _offset_FileObject;
                    }
                }

                private int Offset_FileKey
                {
                    get
                    {
                        if (_offset_FileKey == -1)
                        {
                            _offset_FileKey = Offset_FileObject + _etwEvent.AddressSize;
                        }

                        return _offset_FileKey;
                    }
                }

                private int Offset_ExtraInfo
                {
                    get
                    {
                        if (_offset_ExtraInfo == -1)
                        {
                            _offset_ExtraInfo = Offset_FileKey + _etwEvent.AddressSize;
                        }

                        return _offset_ExtraInfo;
                    }
                }

                private int Offset_TTID
                {
                    get
                    {
                        if (_offset_TTID == -1)
                        {
                            _offset_TTID = Offset_ExtraInfo + _etwEvent.AddressSize;
                        }

                        return _offset_TTID;
                    }
                }

                private int Offset_InfoClass
                {
                    get
                    {
                        if (_offset_InfoClass == -1)
                        {
                            _offset_InfoClass = Offset_TTID + 4;
                        }

                        return _offset_InfoClass;
                    }
                }

                /// <summary>
                /// Retrieves the IrpPtr field.
                /// </summary>
                public ulong IrpPtr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_IrpPtr..Offset_FileObject]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_IrpPtr..Offset_FileObject]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..Offset_FileKey]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..Offset_FileKey]);

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..Offset_ExtraInfo]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..Offset_ExtraInfo]);

                /// <summary>
                /// Retrieves the ExtraInfo field.
                /// </summary>
                public ulong ExtraInfo => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ExtraInfo..Offset_TTID]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ExtraInfo..Offset_TTID]);

                /// <summary>
                /// Retrieves the TTID field.
                /// </summary>
                public uint TTID => BitConverter.ToUInt32(_etwEvent.Data[Offset_TTID..Offset_InfoClass]);

                /// <summary>
                /// Retrieves the InfoClass field.
                /// </summary>
                public uint InfoClass => BitConverter.ToUInt32(_etwEvent.Data[Offset_InfoClass..]);

                /// <summary>
                /// Creates a new SetInfoData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public SetInfoData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_IrpPtr = -1;
                    _offset_FileObject = -1;
                    _offset_FileKey = -1;
                    _offset_ExtraInfo = -1;
                    _offset_TTID = -1;
                    _offset_InfoClass = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Delete event.
        /// </summary>
        public readonly ref struct DeleteEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Delete";

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
                Opcode = (EtwEventOpcode)Opcodes.Delete,
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
            public DeleteData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DeleteEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DeleteEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a DeleteEventV3.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator DeleteEventV3(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Delete event.
            /// </summary>
            public ref struct DeleteData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_IrpPtr;
                private int _offset_FileObject;
                private int _offset_FileKey;
                private int _offset_ExtraInfo;
                private int _offset_TTID;
                private int _offset_InfoClass;

                private int Offset_IrpPtr
                {
                    get
                    {
                        if (_offset_IrpPtr == -1)
                        {
                            _offset_IrpPtr = 0;
                        }

                        return _offset_IrpPtr;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_IrpPtr + _etwEvent.AddressSize;
                        }

                        return _offset_FileObject;
                    }
                }

                private int Offset_FileKey
                {
                    get
                    {
                        if (_offset_FileKey == -1)
                        {
                            _offset_FileKey = Offset_FileObject + _etwEvent.AddressSize;
                        }

                        return _offset_FileKey;
                    }
                }

                private int Offset_ExtraInfo
                {
                    get
                    {
                        if (_offset_ExtraInfo == -1)
                        {
                            _offset_ExtraInfo = Offset_FileKey + _etwEvent.AddressSize;
                        }

                        return _offset_ExtraInfo;
                    }
                }

                private int Offset_TTID
                {
                    get
                    {
                        if (_offset_TTID == -1)
                        {
                            _offset_TTID = Offset_ExtraInfo + _etwEvent.AddressSize;
                        }

                        return _offset_TTID;
                    }
                }

                private int Offset_InfoClass
                {
                    get
                    {
                        if (_offset_InfoClass == -1)
                        {
                            _offset_InfoClass = Offset_TTID + 4;
                        }

                        return _offset_InfoClass;
                    }
                }

                /// <summary>
                /// Retrieves the IrpPtr field.
                /// </summary>
                public ulong IrpPtr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_IrpPtr..Offset_FileObject]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_IrpPtr..Offset_FileObject]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..Offset_FileKey]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..Offset_FileKey]);

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..Offset_ExtraInfo]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..Offset_ExtraInfo]);

                /// <summary>
                /// Retrieves the ExtraInfo field.
                /// </summary>
                public ulong ExtraInfo => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ExtraInfo..Offset_TTID]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ExtraInfo..Offset_TTID]);

                /// <summary>
                /// Retrieves the TTID field.
                /// </summary>
                public uint TTID => BitConverter.ToUInt32(_etwEvent.Data[Offset_TTID..Offset_InfoClass]);

                /// <summary>
                /// Retrieves the InfoClass field.
                /// </summary>
                public uint InfoClass => BitConverter.ToUInt32(_etwEvent.Data[Offset_InfoClass..]);

                /// <summary>
                /// Creates a new DeleteData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DeleteData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_IrpPtr = -1;
                    _offset_FileObject = -1;
                    _offset_FileKey = -1;
                    _offset_ExtraInfo = -1;
                    _offset_TTID = -1;
                    _offset_InfoClass = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Rename event.
        /// </summary>
        public readonly ref struct RenameEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Rename";

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
                Opcode = (EtwEventOpcode)Opcodes.Rename,
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
            public RenameData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new RenameEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public RenameEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a RenameEventV3.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator RenameEventV3(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Rename event.
            /// </summary>
            public ref struct RenameData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_IrpPtr;
                private int _offset_FileObject;
                private int _offset_FileKey;
                private int _offset_ExtraInfo;
                private int _offset_TTID;
                private int _offset_InfoClass;

                private int Offset_IrpPtr
                {
                    get
                    {
                        if (_offset_IrpPtr == -1)
                        {
                            _offset_IrpPtr = 0;
                        }

                        return _offset_IrpPtr;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_IrpPtr + _etwEvent.AddressSize;
                        }

                        return _offset_FileObject;
                    }
                }

                private int Offset_FileKey
                {
                    get
                    {
                        if (_offset_FileKey == -1)
                        {
                            _offset_FileKey = Offset_FileObject + _etwEvent.AddressSize;
                        }

                        return _offset_FileKey;
                    }
                }

                private int Offset_ExtraInfo
                {
                    get
                    {
                        if (_offset_ExtraInfo == -1)
                        {
                            _offset_ExtraInfo = Offset_FileKey + _etwEvent.AddressSize;
                        }

                        return _offset_ExtraInfo;
                    }
                }

                private int Offset_TTID
                {
                    get
                    {
                        if (_offset_TTID == -1)
                        {
                            _offset_TTID = Offset_ExtraInfo + _etwEvent.AddressSize;
                        }

                        return _offset_TTID;
                    }
                }

                private int Offset_InfoClass
                {
                    get
                    {
                        if (_offset_InfoClass == -1)
                        {
                            _offset_InfoClass = Offset_TTID + 4;
                        }

                        return _offset_InfoClass;
                    }
                }

                /// <summary>
                /// Retrieves the IrpPtr field.
                /// </summary>
                public ulong IrpPtr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_IrpPtr..Offset_FileObject]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_IrpPtr..Offset_FileObject]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..Offset_FileKey]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..Offset_FileKey]);

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..Offset_ExtraInfo]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..Offset_ExtraInfo]);

                /// <summary>
                /// Retrieves the ExtraInfo field.
                /// </summary>
                public ulong ExtraInfo => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ExtraInfo..Offset_TTID]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ExtraInfo..Offset_TTID]);

                /// <summary>
                /// Retrieves the TTID field.
                /// </summary>
                public uint TTID => BitConverter.ToUInt32(_etwEvent.Data[Offset_TTID..Offset_InfoClass]);

                /// <summary>
                /// Retrieves the InfoClass field.
                /// </summary>
                public uint InfoClass => BitConverter.ToUInt32(_etwEvent.Data[Offset_InfoClass..]);

                /// <summary>
                /// Creates a new RenameData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public RenameData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_IrpPtr = -1;
                    _offset_FileObject = -1;
                    _offset_FileKey = -1;
                    _offset_ExtraInfo = -1;
                    _offset_TTID = -1;
                    _offset_InfoClass = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a QueryInfo event.
        /// </summary>
        public readonly ref struct QueryInfoEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "QueryInfo";

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
                Opcode = (EtwEventOpcode)Opcodes.QueryInfo,
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
            public QueryInfoData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new QueryInfoEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public QueryInfoEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a QueryInfoEventV3.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator QueryInfoEventV3(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a QueryInfo event.
            /// </summary>
            public ref struct QueryInfoData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_IrpPtr;
                private int _offset_FileObject;
                private int _offset_FileKey;
                private int _offset_ExtraInfo;
                private int _offset_TTID;
                private int _offset_InfoClass;

                private int Offset_IrpPtr
                {
                    get
                    {
                        if (_offset_IrpPtr == -1)
                        {
                            _offset_IrpPtr = 0;
                        }

                        return _offset_IrpPtr;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_IrpPtr + _etwEvent.AddressSize;
                        }

                        return _offset_FileObject;
                    }
                }

                private int Offset_FileKey
                {
                    get
                    {
                        if (_offset_FileKey == -1)
                        {
                            _offset_FileKey = Offset_FileObject + _etwEvent.AddressSize;
                        }

                        return _offset_FileKey;
                    }
                }

                private int Offset_ExtraInfo
                {
                    get
                    {
                        if (_offset_ExtraInfo == -1)
                        {
                            _offset_ExtraInfo = Offset_FileKey + _etwEvent.AddressSize;
                        }

                        return _offset_ExtraInfo;
                    }
                }

                private int Offset_TTID
                {
                    get
                    {
                        if (_offset_TTID == -1)
                        {
                            _offset_TTID = Offset_ExtraInfo + _etwEvent.AddressSize;
                        }

                        return _offset_TTID;
                    }
                }

                private int Offset_InfoClass
                {
                    get
                    {
                        if (_offset_InfoClass == -1)
                        {
                            _offset_InfoClass = Offset_TTID + 4;
                        }

                        return _offset_InfoClass;
                    }
                }

                /// <summary>
                /// Retrieves the IrpPtr field.
                /// </summary>
                public ulong IrpPtr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_IrpPtr..Offset_FileObject]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_IrpPtr..Offset_FileObject]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..Offset_FileKey]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..Offset_FileKey]);

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..Offset_ExtraInfo]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..Offset_ExtraInfo]);

                /// <summary>
                /// Retrieves the ExtraInfo field.
                /// </summary>
                public ulong ExtraInfo => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ExtraInfo..Offset_TTID]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ExtraInfo..Offset_TTID]);

                /// <summary>
                /// Retrieves the TTID field.
                /// </summary>
                public uint TTID => BitConverter.ToUInt32(_etwEvent.Data[Offset_TTID..Offset_InfoClass]);

                /// <summary>
                /// Retrieves the InfoClass field.
                /// </summary>
                public uint InfoClass => BitConverter.ToUInt32(_etwEvent.Data[Offset_InfoClass..]);

                /// <summary>
                /// Creates a new QueryInfoData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public QueryInfoData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_IrpPtr = -1;
                    _offset_FileObject = -1;
                    _offset_FileKey = -1;
                    _offset_ExtraInfo = -1;
                    _offset_TTID = -1;
                    _offset_InfoClass = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a FSControl event.
        /// </summary>
        public readonly ref struct FSControlEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "FSControl";

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
                Opcode = (EtwEventOpcode)Opcodes.FSControl,
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
            public FSControlData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new FSControlEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public FSControlEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a FSControlEventV3.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator FSControlEventV3(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a FSControl event.
            /// </summary>
            public ref struct FSControlData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_IrpPtr;
                private int _offset_FileObject;
                private int _offset_FileKey;
                private int _offset_ExtraInfo;
                private int _offset_TTID;
                private int _offset_InfoClass;

                private int Offset_IrpPtr
                {
                    get
                    {
                        if (_offset_IrpPtr == -1)
                        {
                            _offset_IrpPtr = 0;
                        }

                        return _offset_IrpPtr;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_IrpPtr + _etwEvent.AddressSize;
                        }

                        return _offset_FileObject;
                    }
                }

                private int Offset_FileKey
                {
                    get
                    {
                        if (_offset_FileKey == -1)
                        {
                            _offset_FileKey = Offset_FileObject + _etwEvent.AddressSize;
                        }

                        return _offset_FileKey;
                    }
                }

                private int Offset_ExtraInfo
                {
                    get
                    {
                        if (_offset_ExtraInfo == -1)
                        {
                            _offset_ExtraInfo = Offset_FileKey + _etwEvent.AddressSize;
                        }

                        return _offset_ExtraInfo;
                    }
                }

                private int Offset_TTID
                {
                    get
                    {
                        if (_offset_TTID == -1)
                        {
                            _offset_TTID = Offset_ExtraInfo + _etwEvent.AddressSize;
                        }

                        return _offset_TTID;
                    }
                }

                private int Offset_InfoClass
                {
                    get
                    {
                        if (_offset_InfoClass == -1)
                        {
                            _offset_InfoClass = Offset_TTID + 4;
                        }

                        return _offset_InfoClass;
                    }
                }

                /// <summary>
                /// Retrieves the IrpPtr field.
                /// </summary>
                public ulong IrpPtr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_IrpPtr..Offset_FileObject]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_IrpPtr..Offset_FileObject]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..Offset_FileKey]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..Offset_FileKey]);

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..Offset_ExtraInfo]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..Offset_ExtraInfo]);

                /// <summary>
                /// Retrieves the ExtraInfo field.
                /// </summary>
                public ulong ExtraInfo => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ExtraInfo..Offset_TTID]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ExtraInfo..Offset_TTID]);

                /// <summary>
                /// Retrieves the TTID field.
                /// </summary>
                public uint TTID => BitConverter.ToUInt32(_etwEvent.Data[Offset_TTID..Offset_InfoClass]);

                /// <summary>
                /// Retrieves the InfoClass field.
                /// </summary>
                public uint InfoClass => BitConverter.ToUInt32(_etwEvent.Data[Offset_InfoClass..]);

                /// <summary>
                /// Creates a new FSControlData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public FSControlData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_IrpPtr = -1;
                    _offset_FileObject = -1;
                    _offset_FileKey = -1;
                    _offset_ExtraInfo = -1;
                    _offset_TTID = -1;
                    _offset_InfoClass = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DirEnum event.
        /// </summary>
        public readonly ref struct DirEnumEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DirEnum";

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
                Opcode = (EtwEventOpcode)Opcodes.DirEnum,
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
            public DirEnumData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DirEnumEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DirEnumEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a DirEnumEventV3.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator DirEnumEventV3(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a DirEnum event.
            /// </summary>
            public ref struct DirEnumData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_IrpPtr;
                private int _offset_FileObject;
                private int _offset_FileKey;
                private int _offset_TTID;
                private int _offset_Length;
                private int _offset_InfoClass;
                private int _offset_FileIndex;
                private int _offset_FileName;

                private int Offset_IrpPtr
                {
                    get
                    {
                        if (_offset_IrpPtr == -1)
                        {
                            _offset_IrpPtr = 0;
                        }

                        return _offset_IrpPtr;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_IrpPtr + _etwEvent.AddressSize;
                        }

                        return _offset_FileObject;
                    }
                }

                private int Offset_FileKey
                {
                    get
                    {
                        if (_offset_FileKey == -1)
                        {
                            _offset_FileKey = Offset_FileObject + _etwEvent.AddressSize;
                        }

                        return _offset_FileKey;
                    }
                }

                private int Offset_TTID
                {
                    get
                    {
                        if (_offset_TTID == -1)
                        {
                            _offset_TTID = Offset_FileKey + _etwEvent.AddressSize;
                        }

                        return _offset_TTID;
                    }
                }

                private int Offset_Length
                {
                    get
                    {
                        if (_offset_Length == -1)
                        {
                            _offset_Length = Offset_TTID + 4;
                        }

                        return _offset_Length;
                    }
                }

                private int Offset_InfoClass
                {
                    get
                    {
                        if (_offset_InfoClass == -1)
                        {
                            _offset_InfoClass = Offset_Length + 4;
                        }

                        return _offset_InfoClass;
                    }
                }

                private int Offset_FileIndex
                {
                    get
                    {
                        if (_offset_FileIndex == -1)
                        {
                            _offset_FileIndex = Offset_InfoClass + 4;
                        }

                        return _offset_FileIndex;
                    }
                }

                private int Offset_FileName
                {
                    get
                    {
                        if (_offset_FileName == -1)
                        {
                            _offset_FileName = Offset_FileIndex + 4;
                        }

                        return _offset_FileName;
                    }
                }

                /// <summary>
                /// Retrieves the IrpPtr field.
                /// </summary>
                public ulong IrpPtr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_IrpPtr..Offset_FileObject]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_IrpPtr..Offset_FileObject]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..Offset_FileKey]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..Offset_FileKey]);

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..Offset_TTID]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..Offset_TTID]);

                /// <summary>
                /// Retrieves the TTID field.
                /// </summary>
                public uint TTID => BitConverter.ToUInt32(_etwEvent.Data[Offset_TTID..Offset_Length]);

                /// <summary>
                /// Retrieves the Length field.
                /// </summary>
                public uint Length => BitConverter.ToUInt32(_etwEvent.Data[Offset_Length..Offset_InfoClass]);

                /// <summary>
                /// Retrieves the InfoClass field.
                /// </summary>
                public uint InfoClass => BitConverter.ToUInt32(_etwEvent.Data[Offset_InfoClass..Offset_FileIndex]);

                /// <summary>
                /// Retrieves the FileIndex field.
                /// </summary>
                public uint FileIndex => BitConverter.ToUInt32(_etwEvent.Data[Offset_FileIndex..Offset_FileName]);

                /// <summary>
                /// Retrieves the FileName field.
                /// </summary>
                public string FileName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FileName..]);

                /// <summary>
                /// Creates a new DirEnumData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DirEnumData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_IrpPtr = -1;
                    _offset_FileObject = -1;
                    _offset_FileKey = -1;
                    _offset_TTID = -1;
                    _offset_Length = -1;
                    _offset_InfoClass = -1;
                    _offset_FileIndex = -1;
                    _offset_FileName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DirNotify event.
        /// </summary>
        public readonly ref struct DirNotifyEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DirNotify";

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
                Opcode = (EtwEventOpcode)Opcodes.DirNotify,
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
            public DirNotifyData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DirNotifyEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DirNotifyEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a DirNotifyEventV3.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator DirNotifyEventV3(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a DirNotify event.
            /// </summary>
            public ref struct DirNotifyData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_IrpPtr;
                private int _offset_FileObject;
                private int _offset_FileKey;
                private int _offset_TTID;
                private int _offset_Length;
                private int _offset_InfoClass;
                private int _offset_FileIndex;
                private int _offset_FileName;

                private int Offset_IrpPtr
                {
                    get
                    {
                        if (_offset_IrpPtr == -1)
                        {
                            _offset_IrpPtr = 0;
                        }

                        return _offset_IrpPtr;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_IrpPtr + _etwEvent.AddressSize;
                        }

                        return _offset_FileObject;
                    }
                }

                private int Offset_FileKey
                {
                    get
                    {
                        if (_offset_FileKey == -1)
                        {
                            _offset_FileKey = Offset_FileObject + _etwEvent.AddressSize;
                        }

                        return _offset_FileKey;
                    }
                }

                private int Offset_TTID
                {
                    get
                    {
                        if (_offset_TTID == -1)
                        {
                            _offset_TTID = Offset_FileKey + _etwEvent.AddressSize;
                        }

                        return _offset_TTID;
                    }
                }

                private int Offset_Length
                {
                    get
                    {
                        if (_offset_Length == -1)
                        {
                            _offset_Length = Offset_TTID + 4;
                        }

                        return _offset_Length;
                    }
                }

                private int Offset_InfoClass
                {
                    get
                    {
                        if (_offset_InfoClass == -1)
                        {
                            _offset_InfoClass = Offset_Length + 4;
                        }

                        return _offset_InfoClass;
                    }
                }

                private int Offset_FileIndex
                {
                    get
                    {
                        if (_offset_FileIndex == -1)
                        {
                            _offset_FileIndex = Offset_InfoClass + 4;
                        }

                        return _offset_FileIndex;
                    }
                }

                private int Offset_FileName
                {
                    get
                    {
                        if (_offset_FileName == -1)
                        {
                            _offset_FileName = Offset_FileIndex + 4;
                        }

                        return _offset_FileName;
                    }
                }

                /// <summary>
                /// Retrieves the IrpPtr field.
                /// </summary>
                public ulong IrpPtr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_IrpPtr..Offset_FileObject]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_IrpPtr..Offset_FileObject]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..Offset_FileKey]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..Offset_FileKey]);

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..Offset_TTID]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..Offset_TTID]);

                /// <summary>
                /// Retrieves the TTID field.
                /// </summary>
                public uint TTID => BitConverter.ToUInt32(_etwEvent.Data[Offset_TTID..Offset_Length]);

                /// <summary>
                /// Retrieves the Length field.
                /// </summary>
                public uint Length => BitConverter.ToUInt32(_etwEvent.Data[Offset_Length..Offset_InfoClass]);

                /// <summary>
                /// Retrieves the InfoClass field.
                /// </summary>
                public uint InfoClass => BitConverter.ToUInt32(_etwEvent.Data[Offset_InfoClass..Offset_FileIndex]);

                /// <summary>
                /// Retrieves the FileIndex field.
                /// </summary>
                public uint FileIndex => BitConverter.ToUInt32(_etwEvent.Data[Offset_FileIndex..Offset_FileName]);

                /// <summary>
                /// Retrieves the FileName field.
                /// </summary>
                public string FileName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FileName..]);

                /// <summary>
                /// Creates a new DirNotifyData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DirNotifyData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_IrpPtr = -1;
                    _offset_FileObject = -1;
                    _offset_FileKey = -1;
                    _offset_TTID = -1;
                    _offset_Length = -1;
                    _offset_InfoClass = -1;
                    _offset_FileIndex = -1;
                    _offset_FileName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a OperationEnd event.
        /// </summary>
        public readonly ref struct OperationEndEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "OperationEnd";

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
                Opcode = (EtwEventOpcode)Opcodes.OperationEnd,
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
            public OperationEndData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new OperationEndEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public OperationEndEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a OperationEndEventV3.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator OperationEndEventV3(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a OperationEnd event.
            /// </summary>
            public ref struct OperationEndData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_IrpPtr;
                private int _offset_ExtraInfo;
                private int _offset_NtStatus;

                private int Offset_IrpPtr
                {
                    get
                    {
                        if (_offset_IrpPtr == -1)
                        {
                            _offset_IrpPtr = 0;
                        }

                        return _offset_IrpPtr;
                    }
                }

                private int Offset_ExtraInfo
                {
                    get
                    {
                        if (_offset_ExtraInfo == -1)
                        {
                            _offset_ExtraInfo = Offset_IrpPtr + _etwEvent.AddressSize;
                        }

                        return _offset_ExtraInfo;
                    }
                }

                private int Offset_NtStatus
                {
                    get
                    {
                        if (_offset_NtStatus == -1)
                        {
                            _offset_NtStatus = Offset_ExtraInfo + _etwEvent.AddressSize;
                        }

                        return _offset_NtStatus;
                    }
                }

                /// <summary>
                /// Retrieves the IrpPtr field.
                /// </summary>
                public ulong IrpPtr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_IrpPtr..Offset_ExtraInfo]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_IrpPtr..Offset_ExtraInfo]);

                /// <summary>
                /// Retrieves the ExtraInfo field.
                /// </summary>
                public ulong ExtraInfo => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ExtraInfo..Offset_NtStatus]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ExtraInfo..Offset_NtStatus]);

                /// <summary>
                /// Retrieves the NtStatus field.
                /// </summary>
                public uint NtStatus => BitConverter.ToUInt32(_etwEvent.Data[Offset_NtStatus..]);

                /// <summary>
                /// Creates a new OperationEndData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public OperationEndData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_IrpPtr = -1;
                    _offset_ExtraInfo = -1;
                    _offset_NtStatus = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DletePath event.
        /// </summary>
        public readonly ref struct DletePathEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DletePath";

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
                Opcode = (EtwEventOpcode)Opcodes.DletePath,
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
            public DletePathData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DletePathEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DletePathEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a DletePathEventV3.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator DletePathEventV3(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a DletePath event.
            /// </summary>
            public ref struct DletePathData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_IrpPtr;
                private int _offset_FileObject;
                private int _offset_FileKey;
                private int _offset_ExtraInfo;
                private int _offset_TTID;
                private int _offset_InfoClass;
                private int _offset_FileName;

                private int Offset_IrpPtr
                {
                    get
                    {
                        if (_offset_IrpPtr == -1)
                        {
                            _offset_IrpPtr = 0;
                        }

                        return _offset_IrpPtr;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_IrpPtr + _etwEvent.AddressSize;
                        }

                        return _offset_FileObject;
                    }
                }

                private int Offset_FileKey
                {
                    get
                    {
                        if (_offset_FileKey == -1)
                        {
                            _offset_FileKey = Offset_FileObject + _etwEvent.AddressSize;
                        }

                        return _offset_FileKey;
                    }
                }

                private int Offset_ExtraInfo
                {
                    get
                    {
                        if (_offset_ExtraInfo == -1)
                        {
                            _offset_ExtraInfo = Offset_FileKey + _etwEvent.AddressSize;
                        }

                        return _offset_ExtraInfo;
                    }
                }

                private int Offset_TTID
                {
                    get
                    {
                        if (_offset_TTID == -1)
                        {
                            _offset_TTID = Offset_ExtraInfo + _etwEvent.AddressSize;
                        }

                        return _offset_TTID;
                    }
                }

                private int Offset_InfoClass
                {
                    get
                    {
                        if (_offset_InfoClass == -1)
                        {
                            _offset_InfoClass = Offset_TTID + 4;
                        }

                        return _offset_InfoClass;
                    }
                }

                private int Offset_FileName
                {
                    get
                    {
                        if (_offset_FileName == -1)
                        {
                            _offset_FileName = Offset_InfoClass + 4;
                        }

                        return _offset_FileName;
                    }
                }

                /// <summary>
                /// Retrieves the IrpPtr field.
                /// </summary>
                public ulong IrpPtr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_IrpPtr..Offset_FileObject]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_IrpPtr..Offset_FileObject]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..Offset_FileKey]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..Offset_FileKey]);

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..Offset_ExtraInfo]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..Offset_ExtraInfo]);

                /// <summary>
                /// Retrieves the ExtraInfo field.
                /// </summary>
                public ulong ExtraInfo => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ExtraInfo..Offset_TTID]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ExtraInfo..Offset_TTID]);

                /// <summary>
                /// Retrieves the TTID field.
                /// </summary>
                public uint TTID => BitConverter.ToUInt32(_etwEvent.Data[Offset_TTID..Offset_InfoClass]);

                /// <summary>
                /// Retrieves the InfoClass field.
                /// </summary>
                public uint InfoClass => BitConverter.ToUInt32(_etwEvent.Data[Offset_InfoClass..Offset_FileName]);

                /// <summary>
                /// Retrieves the FileName field.
                /// </summary>
                public string FileName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FileName..]);

                /// <summary>
                /// Creates a new DletePathData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DletePathData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_IrpPtr = -1;
                    _offset_FileObject = -1;
                    _offset_FileKey = -1;
                    _offset_ExtraInfo = -1;
                    _offset_TTID = -1;
                    _offset_InfoClass = -1;
                    _offset_FileName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a RenamePath event.
        /// </summary>
        public readonly ref struct RenamePathEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "RenamePath";

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
                Opcode = (EtwEventOpcode)Opcodes.RenamePath,
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
            public RenamePathData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new RenamePathEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public RenamePathEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a RenamePathEventV3.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator RenamePathEventV3(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a RenamePath event.
            /// </summary>
            public ref struct RenamePathData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_IrpPtr;
                private int _offset_FileObject;
                private int _offset_FileKey;
                private int _offset_ExtraInfo;
                private int _offset_TTID;
                private int _offset_InfoClass;
                private int _offset_FileName;

                private int Offset_IrpPtr
                {
                    get
                    {
                        if (_offset_IrpPtr == -1)
                        {
                            _offset_IrpPtr = 0;
                        }

                        return _offset_IrpPtr;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_IrpPtr + _etwEvent.AddressSize;
                        }

                        return _offset_FileObject;
                    }
                }

                private int Offset_FileKey
                {
                    get
                    {
                        if (_offset_FileKey == -1)
                        {
                            _offset_FileKey = Offset_FileObject + _etwEvent.AddressSize;
                        }

                        return _offset_FileKey;
                    }
                }

                private int Offset_ExtraInfo
                {
                    get
                    {
                        if (_offset_ExtraInfo == -1)
                        {
                            _offset_ExtraInfo = Offset_FileKey + _etwEvent.AddressSize;
                        }

                        return _offset_ExtraInfo;
                    }
                }

                private int Offset_TTID
                {
                    get
                    {
                        if (_offset_TTID == -1)
                        {
                            _offset_TTID = Offset_ExtraInfo + _etwEvent.AddressSize;
                        }

                        return _offset_TTID;
                    }
                }

                private int Offset_InfoClass
                {
                    get
                    {
                        if (_offset_InfoClass == -1)
                        {
                            _offset_InfoClass = Offset_TTID + 4;
                        }

                        return _offset_InfoClass;
                    }
                }

                private int Offset_FileName
                {
                    get
                    {
                        if (_offset_FileName == -1)
                        {
                            _offset_FileName = Offset_InfoClass + 4;
                        }

                        return _offset_FileName;
                    }
                }

                /// <summary>
                /// Retrieves the IrpPtr field.
                /// </summary>
                public ulong IrpPtr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_IrpPtr..Offset_FileObject]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_IrpPtr..Offset_FileObject]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..Offset_FileKey]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..Offset_FileKey]);

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..Offset_ExtraInfo]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..Offset_ExtraInfo]);

                /// <summary>
                /// Retrieves the ExtraInfo field.
                /// </summary>
                public ulong ExtraInfo => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ExtraInfo..Offset_TTID]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ExtraInfo..Offset_TTID]);

                /// <summary>
                /// Retrieves the TTID field.
                /// </summary>
                public uint TTID => BitConverter.ToUInt32(_etwEvent.Data[Offset_TTID..Offset_InfoClass]);

                /// <summary>
                /// Retrieves the InfoClass field.
                /// </summary>
                public uint InfoClass => BitConverter.ToUInt32(_etwEvent.Data[Offset_InfoClass..Offset_FileName]);

                /// <summary>
                /// Retrieves the FileName field.
                /// </summary>
                public string FileName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FileName..]);

                /// <summary>
                /// Creates a new RenamePathData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public RenamePathData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_IrpPtr = -1;
                    _offset_FileObject = -1;
                    _offset_FileKey = -1;
                    _offset_ExtraInfo = -1;
                    _offset_TTID = -1;
                    _offset_InfoClass = -1;
                    _offset_FileName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a SetLinkPath event.
        /// </summary>
        public readonly ref struct SetLinkPathEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SetLinkPath";

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
                Opcode = (EtwEventOpcode)Opcodes.SetLinkPath,
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
            public SetLinkPathData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new SetLinkPathEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SetLinkPathEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a SetLinkPathEventV3.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator SetLinkPathEventV3(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a SetLinkPath event.
            /// </summary>
            public ref struct SetLinkPathData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_IrpPtr;
                private int _offset_FileObject;
                private int _offset_FileKey;
                private int _offset_ExtraInfo;
                private int _offset_TTID;
                private int _offset_InfoClass;
                private int _offset_FileName;

                private int Offset_IrpPtr
                {
                    get
                    {
                        if (_offset_IrpPtr == -1)
                        {
                            _offset_IrpPtr = 0;
                        }

                        return _offset_IrpPtr;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_IrpPtr + _etwEvent.AddressSize;
                        }

                        return _offset_FileObject;
                    }
                }

                private int Offset_FileKey
                {
                    get
                    {
                        if (_offset_FileKey == -1)
                        {
                            _offset_FileKey = Offset_FileObject + _etwEvent.AddressSize;
                        }

                        return _offset_FileKey;
                    }
                }

                private int Offset_ExtraInfo
                {
                    get
                    {
                        if (_offset_ExtraInfo == -1)
                        {
                            _offset_ExtraInfo = Offset_FileKey + _etwEvent.AddressSize;
                        }

                        return _offset_ExtraInfo;
                    }
                }

                private int Offset_TTID
                {
                    get
                    {
                        if (_offset_TTID == -1)
                        {
                            _offset_TTID = Offset_ExtraInfo + _etwEvent.AddressSize;
                        }

                        return _offset_TTID;
                    }
                }

                private int Offset_InfoClass
                {
                    get
                    {
                        if (_offset_InfoClass == -1)
                        {
                            _offset_InfoClass = Offset_TTID + 4;
                        }

                        return _offset_InfoClass;
                    }
                }

                private int Offset_FileName
                {
                    get
                    {
                        if (_offset_FileName == -1)
                        {
                            _offset_FileName = Offset_InfoClass + 4;
                        }

                        return _offset_FileName;
                    }
                }

                /// <summary>
                /// Retrieves the IrpPtr field.
                /// </summary>
                public ulong IrpPtr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_IrpPtr..Offset_FileObject]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_IrpPtr..Offset_FileObject]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..Offset_FileKey]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..Offset_FileKey]);

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..Offset_ExtraInfo]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..Offset_ExtraInfo]);

                /// <summary>
                /// Retrieves the ExtraInfo field.
                /// </summary>
                public ulong ExtraInfo => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ExtraInfo..Offset_TTID]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ExtraInfo..Offset_TTID]);

                /// <summary>
                /// Retrieves the TTID field.
                /// </summary>
                public uint TTID => BitConverter.ToUInt32(_etwEvent.Data[Offset_TTID..Offset_InfoClass]);

                /// <summary>
                /// Retrieves the InfoClass field.
                /// </summary>
                public uint InfoClass => BitConverter.ToUInt32(_etwEvent.Data[Offset_InfoClass..Offset_FileName]);

                /// <summary>
                /// Retrieves the FileName field.
                /// </summary>
                public string FileName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FileName..]);

                /// <summary>
                /// Creates a new SetLinkPathData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public SetLinkPathData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_IrpPtr = -1;
                    _offset_FileObject = -1;
                    _offset_FileKey = -1;
                    _offset_ExtraInfo = -1;
                    _offset_TTID = -1;
                    _offset_InfoClass = -1;
                    _offset_FileName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a PreOpInit event.
        /// </summary>
        public readonly ref struct PreOpInitEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "PreOpInit";

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
                Opcode = (EtwEventOpcode)Opcodes.PreOpInit,
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
            public PreOpInitData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new PreOpInitEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public PreOpInitEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a PreOpInitEventV3.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator PreOpInitEventV3(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a PreOpInit event.
            /// </summary>
            public ref struct PreOpInitData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_RoutineAddr;
                private int _offset_FileObject;
                private int _offset_FileContext;
                private int _offset_IrpPtr;
                private int _offset_CallbackDataPtr;
                private int _offset_MajorFunction;

                private int Offset_RoutineAddr
                {
                    get
                    {
                        if (_offset_RoutineAddr == -1)
                        {
                            _offset_RoutineAddr = 0;
                        }

                        return _offset_RoutineAddr;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_RoutineAddr + _etwEvent.AddressSize;
                        }

                        return _offset_FileObject;
                    }
                }

                private int Offset_FileContext
                {
                    get
                    {
                        if (_offset_FileContext == -1)
                        {
                            _offset_FileContext = Offset_FileObject + _etwEvent.AddressSize;
                        }

                        return _offset_FileContext;
                    }
                }

                private int Offset_IrpPtr
                {
                    get
                    {
                        if (_offset_IrpPtr == -1)
                        {
                            _offset_IrpPtr = Offset_FileContext + _etwEvent.AddressSize;
                        }

                        return _offset_IrpPtr;
                    }
                }

                private int Offset_CallbackDataPtr
                {
                    get
                    {
                        if (_offset_CallbackDataPtr == -1)
                        {
                            _offset_CallbackDataPtr = Offset_IrpPtr + _etwEvent.AddressSize;
                        }

                        return _offset_CallbackDataPtr;
                    }
                }

                private int Offset_MajorFunction
                {
                    get
                    {
                        if (_offset_MajorFunction == -1)
                        {
                            _offset_MajorFunction = Offset_CallbackDataPtr + _etwEvent.AddressSize;
                        }

                        return _offset_MajorFunction;
                    }
                }

                /// <summary>
                /// Retrieves the RoutineAddr field.
                /// </summary>
                public ulong RoutineAddr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_RoutineAddr..Offset_FileObject]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_RoutineAddr..Offset_FileObject]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..Offset_FileContext]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..Offset_FileContext]);

                /// <summary>
                /// Retrieves the FileContext field.
                /// </summary>
                public ulong FileContext => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileContext..Offset_IrpPtr]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileContext..Offset_IrpPtr]);

                /// <summary>
                /// Retrieves the IrpPtr field.
                /// </summary>
                public ulong IrpPtr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_IrpPtr..Offset_CallbackDataPtr]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_IrpPtr..Offset_CallbackDataPtr]);

                /// <summary>
                /// Retrieves the CallbackDataPtr field.
                /// </summary>
                public ulong CallbackDataPtr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_CallbackDataPtr..Offset_MajorFunction]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_CallbackDataPtr..Offset_MajorFunction]);

                /// <summary>
                /// Retrieves the MajorFunction field.
                /// </summary>
                public uint MajorFunction => BitConverter.ToUInt32(_etwEvent.Data[Offset_MajorFunction..]);

                /// <summary>
                /// Creates a new PreOpInitData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public PreOpInitData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_RoutineAddr = -1;
                    _offset_FileObject = -1;
                    _offset_FileContext = -1;
                    _offset_IrpPtr = -1;
                    _offset_CallbackDataPtr = -1;
                    _offset_MajorFunction = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a PostOpInit event.
        /// </summary>
        public readonly ref struct PostOpInitEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "PostOpInit";

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
                Opcode = (EtwEventOpcode)Opcodes.PostOpInit,
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
            public PostOpInitData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new PostOpInitEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public PostOpInitEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a PostOpInitEventV3.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator PostOpInitEventV3(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a PostOpInit event.
            /// </summary>
            public ref struct PostOpInitData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_RoutineAddr;
                private int _offset_FileObject;
                private int _offset_FileContext;
                private int _offset_IrpPtr;
                private int _offset_CallbackDataPtr;
                private int _offset_MajorFunction;

                private int Offset_RoutineAddr
                {
                    get
                    {
                        if (_offset_RoutineAddr == -1)
                        {
                            _offset_RoutineAddr = 0;
                        }

                        return _offset_RoutineAddr;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_RoutineAddr + _etwEvent.AddressSize;
                        }

                        return _offset_FileObject;
                    }
                }

                private int Offset_FileContext
                {
                    get
                    {
                        if (_offset_FileContext == -1)
                        {
                            _offset_FileContext = Offset_FileObject + _etwEvent.AddressSize;
                        }

                        return _offset_FileContext;
                    }
                }

                private int Offset_IrpPtr
                {
                    get
                    {
                        if (_offset_IrpPtr == -1)
                        {
                            _offset_IrpPtr = Offset_FileContext + _etwEvent.AddressSize;
                        }

                        return _offset_IrpPtr;
                    }
                }

                private int Offset_CallbackDataPtr
                {
                    get
                    {
                        if (_offset_CallbackDataPtr == -1)
                        {
                            _offset_CallbackDataPtr = Offset_IrpPtr + _etwEvent.AddressSize;
                        }

                        return _offset_CallbackDataPtr;
                    }
                }

                private int Offset_MajorFunction
                {
                    get
                    {
                        if (_offset_MajorFunction == -1)
                        {
                            _offset_MajorFunction = Offset_CallbackDataPtr + _etwEvent.AddressSize;
                        }

                        return _offset_MajorFunction;
                    }
                }

                /// <summary>
                /// Retrieves the RoutineAddr field.
                /// </summary>
                public ulong RoutineAddr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_RoutineAddr..Offset_FileObject]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_RoutineAddr..Offset_FileObject]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..Offset_FileContext]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..Offset_FileContext]);

                /// <summary>
                /// Retrieves the FileContext field.
                /// </summary>
                public ulong FileContext => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileContext..Offset_IrpPtr]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileContext..Offset_IrpPtr]);

                /// <summary>
                /// Retrieves the IrpPtr field.
                /// </summary>
                public ulong IrpPtr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_IrpPtr..Offset_CallbackDataPtr]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_IrpPtr..Offset_CallbackDataPtr]);

                /// <summary>
                /// Retrieves the CallbackDataPtr field.
                /// </summary>
                public ulong CallbackDataPtr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_CallbackDataPtr..Offset_MajorFunction]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_CallbackDataPtr..Offset_MajorFunction]);

                /// <summary>
                /// Retrieves the MajorFunction field.
                /// </summary>
                public uint MajorFunction => BitConverter.ToUInt32(_etwEvent.Data[Offset_MajorFunction..]);

                /// <summary>
                /// Creates a new PostOpInitData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public PostOpInitData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_RoutineAddr = -1;
                    _offset_FileObject = -1;
                    _offset_FileContext = -1;
                    _offset_IrpPtr = -1;
                    _offset_CallbackDataPtr = -1;
                    _offset_MajorFunction = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a PreOpCompletion event.
        /// </summary>
        public readonly ref struct PreOpCompletionEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "PreOpCompletion";

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
                Opcode = (EtwEventOpcode)Opcodes.PreOpCompletion,
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
            public PreOpCompletionData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new PreOpCompletionEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public PreOpCompletionEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a PreOpCompletionEventV3.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator PreOpCompletionEventV3(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a PreOpCompletion event.
            /// </summary>
            public ref struct PreOpCompletionData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_InitialTime;
                private int _offset_RoutineAddr;
                private int _offset_FileObject;
                private int _offset_FileContext;
                private int _offset_IrpPtr;
                private int _offset_CallbackDataPtr;
                private int _offset_MajorFunction;

                private int Offset_InitialTime
                {
                    get
                    {
                        if (_offset_InitialTime == -1)
                        {
                            _offset_InitialTime = 0;
                        }

                        return _offset_InitialTime;
                    }
                }

                private int Offset_RoutineAddr
                {
                    get
                    {
                        if (_offset_RoutineAddr == -1)
                        {
                            _offset_RoutineAddr = Offset_InitialTime + 8;
                        }

                        return _offset_RoutineAddr;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_RoutineAddr + _etwEvent.AddressSize;
                        }

                        return _offset_FileObject;
                    }
                }

                private int Offset_FileContext
                {
                    get
                    {
                        if (_offset_FileContext == -1)
                        {
                            _offset_FileContext = Offset_FileObject + _etwEvent.AddressSize;
                        }

                        return _offset_FileContext;
                    }
                }

                private int Offset_IrpPtr
                {
                    get
                    {
                        if (_offset_IrpPtr == -1)
                        {
                            _offset_IrpPtr = Offset_FileContext + _etwEvent.AddressSize;
                        }

                        return _offset_IrpPtr;
                    }
                }

                private int Offset_CallbackDataPtr
                {
                    get
                    {
                        if (_offset_CallbackDataPtr == -1)
                        {
                            _offset_CallbackDataPtr = Offset_IrpPtr + _etwEvent.AddressSize;
                        }

                        return _offset_CallbackDataPtr;
                    }
                }

                private int Offset_MajorFunction
                {
                    get
                    {
                        if (_offset_MajorFunction == -1)
                        {
                            _offset_MajorFunction = Offset_CallbackDataPtr + _etwEvent.AddressSize;
                        }

                        return _offset_MajorFunction;
                    }
                }

                /// <summary>
                /// Retrieves the InitialTime field.
                /// </summary>
                public ulong InitialTime => BitConverter.ToUInt64(_etwEvent.Data[Offset_InitialTime..Offset_RoutineAddr]);

                /// <summary>
                /// Retrieves the RoutineAddr field.
                /// </summary>
                public ulong RoutineAddr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_RoutineAddr..Offset_FileObject]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_RoutineAddr..Offset_FileObject]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..Offset_FileContext]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..Offset_FileContext]);

                /// <summary>
                /// Retrieves the FileContext field.
                /// </summary>
                public ulong FileContext => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileContext..Offset_IrpPtr]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileContext..Offset_IrpPtr]);

                /// <summary>
                /// Retrieves the IrpPtr field.
                /// </summary>
                public ulong IrpPtr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_IrpPtr..Offset_CallbackDataPtr]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_IrpPtr..Offset_CallbackDataPtr]);

                /// <summary>
                /// Retrieves the CallbackDataPtr field.
                /// </summary>
                public ulong CallbackDataPtr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_CallbackDataPtr..Offset_MajorFunction]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_CallbackDataPtr..Offset_MajorFunction]);

                /// <summary>
                /// Retrieves the MajorFunction field.
                /// </summary>
                public uint MajorFunction => BitConverter.ToUInt32(_etwEvent.Data[Offset_MajorFunction..]);

                /// <summary>
                /// Creates a new PreOpCompletionData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public PreOpCompletionData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_InitialTime = -1;
                    _offset_RoutineAddr = -1;
                    _offset_FileObject = -1;
                    _offset_FileContext = -1;
                    _offset_IrpPtr = -1;
                    _offset_CallbackDataPtr = -1;
                    _offset_MajorFunction = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a PostOpCompletion event.
        /// </summary>
        public readonly ref struct PostOpCompletionEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "PostOpCompletion";

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
                Opcode = (EtwEventOpcode)Opcodes.PostOpCompletion,
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
            public PostOpCompletionData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new PostOpCompletionEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public PostOpCompletionEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a PostOpCompletionEventV3.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator PostOpCompletionEventV3(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a PostOpCompletion event.
            /// </summary>
            public ref struct PostOpCompletionData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_InitialTime;
                private int _offset_RoutineAddr;
                private int _offset_FileObject;
                private int _offset_FileContext;
                private int _offset_IrpPtr;
                private int _offset_CallbackDataPtr;
                private int _offset_MajorFunction;

                private int Offset_InitialTime
                {
                    get
                    {
                        if (_offset_InitialTime == -1)
                        {
                            _offset_InitialTime = 0;
                        }

                        return _offset_InitialTime;
                    }
                }

                private int Offset_RoutineAddr
                {
                    get
                    {
                        if (_offset_RoutineAddr == -1)
                        {
                            _offset_RoutineAddr = Offset_InitialTime + 8;
                        }

                        return _offset_RoutineAddr;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_RoutineAddr + _etwEvent.AddressSize;
                        }

                        return _offset_FileObject;
                    }
                }

                private int Offset_FileContext
                {
                    get
                    {
                        if (_offset_FileContext == -1)
                        {
                            _offset_FileContext = Offset_FileObject + _etwEvent.AddressSize;
                        }

                        return _offset_FileContext;
                    }
                }

                private int Offset_IrpPtr
                {
                    get
                    {
                        if (_offset_IrpPtr == -1)
                        {
                            _offset_IrpPtr = Offset_FileContext + _etwEvent.AddressSize;
                        }

                        return _offset_IrpPtr;
                    }
                }

                private int Offset_CallbackDataPtr
                {
                    get
                    {
                        if (_offset_CallbackDataPtr == -1)
                        {
                            _offset_CallbackDataPtr = Offset_IrpPtr + _etwEvent.AddressSize;
                        }

                        return _offset_CallbackDataPtr;
                    }
                }

                private int Offset_MajorFunction
                {
                    get
                    {
                        if (_offset_MajorFunction == -1)
                        {
                            _offset_MajorFunction = Offset_CallbackDataPtr + _etwEvent.AddressSize;
                        }

                        return _offset_MajorFunction;
                    }
                }

                /// <summary>
                /// Retrieves the InitialTime field.
                /// </summary>
                public ulong InitialTime => BitConverter.ToUInt64(_etwEvent.Data[Offset_InitialTime..Offset_RoutineAddr]);

                /// <summary>
                /// Retrieves the RoutineAddr field.
                /// </summary>
                public ulong RoutineAddr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_RoutineAddr..Offset_FileObject]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_RoutineAddr..Offset_FileObject]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..Offset_FileContext]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..Offset_FileContext]);

                /// <summary>
                /// Retrieves the FileContext field.
                /// </summary>
                public ulong FileContext => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileContext..Offset_IrpPtr]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileContext..Offset_IrpPtr]);

                /// <summary>
                /// Retrieves the IrpPtr field.
                /// </summary>
                public ulong IrpPtr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_IrpPtr..Offset_CallbackDataPtr]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_IrpPtr..Offset_CallbackDataPtr]);

                /// <summary>
                /// Retrieves the CallbackDataPtr field.
                /// </summary>
                public ulong CallbackDataPtr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_CallbackDataPtr..Offset_MajorFunction]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_CallbackDataPtr..Offset_MajorFunction]);

                /// <summary>
                /// Retrieves the MajorFunction field.
                /// </summary>
                public uint MajorFunction => BitConverter.ToUInt32(_etwEvent.Data[Offset_MajorFunction..]);

                /// <summary>
                /// Creates a new PostOpCompletionData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public PostOpCompletionData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_InitialTime = -1;
                    _offset_RoutineAddr = -1;
                    _offset_FileObject = -1;
                    _offset_FileContext = -1;
                    _offset_IrpPtr = -1;
                    _offset_CallbackDataPtr = -1;
                    _offset_MajorFunction = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a PreOpFailure event.
        /// </summary>
        public readonly ref struct PreOpFailureEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "PreOpFailure";

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
                Opcode = (EtwEventOpcode)Opcodes.PreOpFailure,
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
            public PreOpFailureData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new PreOpFailureEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public PreOpFailureEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a PreOpFailureEventV3.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator PreOpFailureEventV3(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a PreOpFailure event.
            /// </summary>
            public ref struct PreOpFailureData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_RoutineAddr;
                private int _offset_FileObject;
                private int _offset_FileContext;
                private int _offset_IrpPtr;
                private int _offset_CallbackDataPtr;
                private int _offset_MajorFunction;
                private int _offset_Status;

                private int Offset_RoutineAddr
                {
                    get
                    {
                        if (_offset_RoutineAddr == -1)
                        {
                            _offset_RoutineAddr = 0;
                        }

                        return _offset_RoutineAddr;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_RoutineAddr + _etwEvent.AddressSize;
                        }

                        return _offset_FileObject;
                    }
                }

                private int Offset_FileContext
                {
                    get
                    {
                        if (_offset_FileContext == -1)
                        {
                            _offset_FileContext = Offset_FileObject + _etwEvent.AddressSize;
                        }

                        return _offset_FileContext;
                    }
                }

                private int Offset_IrpPtr
                {
                    get
                    {
                        if (_offset_IrpPtr == -1)
                        {
                            _offset_IrpPtr = Offset_FileContext + _etwEvent.AddressSize;
                        }

                        return _offset_IrpPtr;
                    }
                }

                private int Offset_CallbackDataPtr
                {
                    get
                    {
                        if (_offset_CallbackDataPtr == -1)
                        {
                            _offset_CallbackDataPtr = Offset_IrpPtr + _etwEvent.AddressSize;
                        }

                        return _offset_CallbackDataPtr;
                    }
                }

                private int Offset_MajorFunction
                {
                    get
                    {
                        if (_offset_MajorFunction == -1)
                        {
                            _offset_MajorFunction = Offset_CallbackDataPtr + _etwEvent.AddressSize;
                        }

                        return _offset_MajorFunction;
                    }
                }

                private int Offset_Status
                {
                    get
                    {
                        if (_offset_Status == -1)
                        {
                            _offset_Status = Offset_MajorFunction + 4;
                        }

                        return _offset_Status;
                    }
                }

                /// <summary>
                /// Retrieves the RoutineAddr field.
                /// </summary>
                public ulong RoutineAddr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_RoutineAddr..Offset_FileObject]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_RoutineAddr..Offset_FileObject]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..Offset_FileContext]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..Offset_FileContext]);

                /// <summary>
                /// Retrieves the FileContext field.
                /// </summary>
                public ulong FileContext => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileContext..Offset_IrpPtr]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileContext..Offset_IrpPtr]);

                /// <summary>
                /// Retrieves the IrpPtr field.
                /// </summary>
                public ulong IrpPtr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_IrpPtr..Offset_CallbackDataPtr]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_IrpPtr..Offset_CallbackDataPtr]);

                /// <summary>
                /// Retrieves the CallbackDataPtr field.
                /// </summary>
                public ulong CallbackDataPtr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_CallbackDataPtr..Offset_MajorFunction]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_CallbackDataPtr..Offset_MajorFunction]);

                /// <summary>
                /// Retrieves the MajorFunction field.
                /// </summary>
                public uint MajorFunction => BitConverter.ToUInt32(_etwEvent.Data[Offset_MajorFunction..Offset_Status]);

                /// <summary>
                /// Retrieves the Status field.
                /// </summary>
                public uint Status => BitConverter.ToUInt32(_etwEvent.Data[Offset_Status..]);

                /// <summary>
                /// Creates a new PreOpFailureData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public PreOpFailureData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_RoutineAddr = -1;
                    _offset_FileObject = -1;
                    _offset_FileContext = -1;
                    _offset_IrpPtr = -1;
                    _offset_CallbackDataPtr = -1;
                    _offset_MajorFunction = -1;
                    _offset_Status = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a PostOpFailure event.
        /// </summary>
        public readonly ref struct PostOpFailureEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "PostOpFailure";

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
                Opcode = (EtwEventOpcode)Opcodes.PostOpFailure,
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
            public PostOpFailureData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new PostOpFailureEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public PostOpFailureEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a PostOpFailureEventV3.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator PostOpFailureEventV3(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a PostOpFailure event.
            /// </summary>
            public ref struct PostOpFailureData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_RoutineAddr;
                private int _offset_FileObject;
                private int _offset_FileContext;
                private int _offset_IrpPtr;
                private int _offset_CallbackDataPtr;
                private int _offset_MajorFunction;
                private int _offset_Status;

                private int Offset_RoutineAddr
                {
                    get
                    {
                        if (_offset_RoutineAddr == -1)
                        {
                            _offset_RoutineAddr = 0;
                        }

                        return _offset_RoutineAddr;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_RoutineAddr + _etwEvent.AddressSize;
                        }

                        return _offset_FileObject;
                    }
                }

                private int Offset_FileContext
                {
                    get
                    {
                        if (_offset_FileContext == -1)
                        {
                            _offset_FileContext = Offset_FileObject + _etwEvent.AddressSize;
                        }

                        return _offset_FileContext;
                    }
                }

                private int Offset_IrpPtr
                {
                    get
                    {
                        if (_offset_IrpPtr == -1)
                        {
                            _offset_IrpPtr = Offset_FileContext + _etwEvent.AddressSize;
                        }

                        return _offset_IrpPtr;
                    }
                }

                private int Offset_CallbackDataPtr
                {
                    get
                    {
                        if (_offset_CallbackDataPtr == -1)
                        {
                            _offset_CallbackDataPtr = Offset_IrpPtr + _etwEvent.AddressSize;
                        }

                        return _offset_CallbackDataPtr;
                    }
                }

                private int Offset_MajorFunction
                {
                    get
                    {
                        if (_offset_MajorFunction == -1)
                        {
                            _offset_MajorFunction = Offset_CallbackDataPtr + _etwEvent.AddressSize;
                        }

                        return _offset_MajorFunction;
                    }
                }

                private int Offset_Status
                {
                    get
                    {
                        if (_offset_Status == -1)
                        {
                            _offset_Status = Offset_MajorFunction + 4;
                        }

                        return _offset_Status;
                    }
                }

                /// <summary>
                /// Retrieves the RoutineAddr field.
                /// </summary>
                public ulong RoutineAddr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_RoutineAddr..Offset_FileObject]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_RoutineAddr..Offset_FileObject]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..Offset_FileContext]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..Offset_FileContext]);

                /// <summary>
                /// Retrieves the FileContext field.
                /// </summary>
                public ulong FileContext => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileContext..Offset_IrpPtr]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileContext..Offset_IrpPtr]);

                /// <summary>
                /// Retrieves the IrpPtr field.
                /// </summary>
                public ulong IrpPtr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_IrpPtr..Offset_CallbackDataPtr]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_IrpPtr..Offset_CallbackDataPtr]);

                /// <summary>
                /// Retrieves the CallbackDataPtr field.
                /// </summary>
                public ulong CallbackDataPtr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_CallbackDataPtr..Offset_MajorFunction]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_CallbackDataPtr..Offset_MajorFunction]);

                /// <summary>
                /// Retrieves the MajorFunction field.
                /// </summary>
                public uint MajorFunction => BitConverter.ToUInt32(_etwEvent.Data[Offset_MajorFunction..Offset_Status]);

                /// <summary>
                /// Retrieves the Status field.
                /// </summary>
                public uint Status => BitConverter.ToUInt32(_etwEvent.Data[Offset_Status..]);

                /// <summary>
                /// Creates a new PostOpFailureData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public PostOpFailureData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_RoutineAddr = -1;
                    _offset_FileObject = -1;
                    _offset_FileContext = -1;
                    _offset_IrpPtr = -1;
                    _offset_CallbackDataPtr = -1;
                    _offset_MajorFunction = -1;
                    _offset_Status = -1;
                }
            }

        }
    }
}
