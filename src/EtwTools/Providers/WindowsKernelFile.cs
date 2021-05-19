using System;

#pragma warning disable IDE0004 // Remove Unnecessary Cast
#pragma warning disable CA1707 // Identifiers should not contain underscores
#pragma warning disable CA1720 // Identifier contains type name

namespace EtwTools
{
    /// <summary>
    /// Provider for Microsoft-Windows-Kernel-File (edd08927-9cc4-4e65-b970-c2560fb5c289)
    /// </summary>
    public sealed class WindowsKernelFileProvider
    {
        /// <summary>s
        /// Provider ID.
        /// </summary>
        public static readonly Guid Id = new("edd08927-9cc4-4e65-b970-c2560fb5c289");

        /// <summary>
        /// Provider name.
        /// </summary>
        public const string Name = "Microsoft-Windows-Kernel-File";

        /// <summary>
        /// Tasks supported by Microsoft-Windows-Kernel-File.
        /// </summary>
        public enum Tasks : ushort
        {
            /// <summary>
            /// 'NameCreate' task.
            /// </summary>
            NameCreate = 10,
            /// <summary>
            /// 'NameDelete' task.
            /// </summary>
            NameDelete = 11,
            /// <summary>
            /// 'Create' task.
            /// </summary>
            Create = 12,
            /// <summary>
            /// 'Cleanup' task.
            /// </summary>
            Cleanup = 13,
            /// <summary>
            /// 'Close' task.
            /// </summary>
            Close = 14,
            /// <summary>
            /// 'Read' task.
            /// </summary>
            Read = 15,
            /// <summary>
            /// 'Write' task.
            /// </summary>
            Write = 16,
            /// <summary>
            /// 'SetInformation' task.
            /// </summary>
            SetInformation = 17,
            /// <summary>
            /// 'SetDelete' task.
            /// </summary>
            SetDelete = 18,
            /// <summary>
            /// 'Rename' task.
            /// </summary>
            Rename = 19,
            /// <summary>
            /// 'DirEnum' task.
            /// </summary>
            DirEnum = 20,
            /// <summary>
            /// 'Flush' task.
            /// </summary>
            Flush = 21,
            /// <summary>
            /// 'QueryInformation' task.
            /// </summary>
            QueryInformation = 22,
            /// <summary>
            /// 'FSCTL' task.
            /// </summary>
            FSCTL = 23,
            /// <summary>
            /// 'OperationEnd' task.
            /// </summary>
            OperationEnd = 24,
            /// <summary>
            /// 'DirNotify' task.
            /// </summary>
            DirNotify = 25,
            /// <summary>
            /// 'DeletePath' task.
            /// </summary>
            DeletePath = 26,
            /// <summary>
            /// 'RenamePath' task.
            /// </summary>
            RenamePath = 27,
            /// <summary>
            /// 'SetLinkPath' task.
            /// </summary>
            SetLinkPath = 28,
            /// <summary>
            /// 'CreateNewFile' task.
            /// </summary>
            CreateNewFile = 30,
            /// <summary>
            /// 'SetSecurity' task.
            /// </summary>
            SetSecurity = 31,
            /// <summary>
            /// 'QuerySecurity' task.
            /// </summary>
            QuerySecurity = 32,
            /// <summary>
            /// 'SetEA' task.
            /// </summary>
            SetEA = 33,
            /// <summary>
            /// 'QueryEA' task.
            /// </summary>
            QueryEA = 34,
        }

        /// <summary>
        /// Keywords supported by WindowsKernelFile.
        /// </summary>
        [Flags]
        public enum Keywords : ulong
        {
            /// <summary>
            /// 'KERNEL_FILE_KEYWORD_FILENAME' keyword.
            /// </summary>
            KERNEL_FILE_KEYWORD_FILENAME = 0x0000000000000010,
            /// <summary>
            /// 'KERNEL_FILE_KEYWORD_FILEIO' keyword.
            /// </summary>
            KERNEL_FILE_KEYWORD_FILEIO = 0x0000000000000020,
            /// <summary>
            /// 'KERNEL_FILE_KEYWORD_OP_END' keyword.
            /// </summary>
            KERNEL_FILE_KEYWORD_OP_END = 0x0000000000000040,
            /// <summary>
            /// 'KERNEL_FILE_KEYWORD_CREATE' keyword.
            /// </summary>
            KERNEL_FILE_KEYWORD_CREATE = 0x0000000000000080,
            /// <summary>
            /// 'KERNEL_FILE_KEYWORD_READ' keyword.
            /// </summary>
            KERNEL_FILE_KEYWORD_READ = 0x0000000000000100,
            /// <summary>
            /// 'KERNEL_FILE_KEYWORD_WRITE' keyword.
            /// </summary>
            KERNEL_FILE_KEYWORD_WRITE = 0x0000000000000200,
            /// <summary>
            /// 'KERNEL_FILE_KEYWORD_DELETE_PATH' keyword.
            /// </summary>
            KERNEL_FILE_KEYWORD_DELETE_PATH = 0x0000000000000400,
            /// <summary>
            /// 'KERNEL_FILE_KEYWORD_RENAME_SETLINK_PATH' keyword.
            /// </summary>
            KERNEL_FILE_KEYWORD_RENAME_SETLINK_PATH = 0x0000000000000800,
            /// <summary>
            /// 'KERNEL_FILE_KEYWORD_CREATE_NEW_FILE' keyword.
            /// </summary>
            KERNEL_FILE_KEYWORD_CREATE_NEW_FILE = 0x0000000000001000,
            /// <summary>
            /// 'Microsoft_Windows_Kernel_File_Analytic' keyword.
            /// </summary>
            Microsoft_Windows_Kernel_File_Analytic = 0x8000000000000000,
        }

        /// <summary>
        /// An event wrapper for a NameCreateInfo event.
        /// </summary>
        public readonly ref struct NameCreateInfoEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "NameCreateInfo";

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
                Channel = 16,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.NameCreate,
                Keyword = (ulong)Keywords.KERNEL_FILE_KEYWORD_FILENAME
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public NameCreateInfoData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new NameCreateInfoEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public NameCreateInfoEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a NameCreateInfo event.
            /// </summary>
            public ref struct NameCreateInfoData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_FileKey;
                private int _offset_FileName;

                private int Offset_FileKey
                {
                    get
                    {
                        if (_offset_FileKey == -1)
                        {
                            _offset_FileKey = 0;
                        }

                        return _offset_FileKey;
                    }
                }

                private int Offset_FileName
                {
                    get
                    {
                        if (_offset_FileName == -1)
                        {
                            _offset_FileName = Offset_FileKey + _etwEvent.AddressSize;
                        }

                        return _offset_FileName;
                    }
                }

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..]);

                /// <summary>
                /// Retrieves the FileName field.
                /// </summary>
                public string FileName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FileName..]);

                /// <summary>
                /// Creates a new NameCreateInfoData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public NameCreateInfoData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_FileKey = -1;
                    _offset_FileName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a NameDeleteInfo event.
        /// </summary>
        public readonly ref struct NameDeleteInfoEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "NameDeleteInfo";

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
                Channel = 16,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.NameDelete,
                Keyword = (ulong)Keywords.KERNEL_FILE_KEYWORD_FILENAME
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public NameDeleteInfoData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new NameDeleteInfoEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public NameDeleteInfoEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a NameDeleteInfo event.
            /// </summary>
            public ref struct NameDeleteInfoData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_FileKey;
                private int _offset_FileName;

                private int Offset_FileKey
                {
                    get
                    {
                        if (_offset_FileKey == -1)
                        {
                            _offset_FileKey = 0;
                        }

                        return _offset_FileKey;
                    }
                }

                private int Offset_FileName
                {
                    get
                    {
                        if (_offset_FileName == -1)
                        {
                            _offset_FileName = Offset_FileKey + _etwEvent.AddressSize;
                        }

                        return _offset_FileName;
                    }
                }

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..]);

                /// <summary>
                /// Retrieves the FileName field.
                /// </summary>
                public string FileName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FileName..]);

                /// <summary>
                /// Creates a new NameDeleteInfoData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public NameDeleteInfoData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_FileKey = -1;
                    _offset_FileName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a CreateInfo event.
        /// </summary>
        public readonly ref struct CreateInfoEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "CreateInfo";

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
                Channel = 16,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.Create,
                Keyword = (ulong)Keywords.KERNEL_FILE_KEYWORD_FILEIO | (ulong)Keywords.KERNEL_FILE_KEYWORD_CREATE
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public CreateInfoData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new CreateInfoEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public CreateInfoEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a CreateInfo event.
            /// </summary>
            public ref struct CreateInfoData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Irp;
                private int _offset_ThreadId;
                private int _offset_FileObject;
                private int _offset_CreateOptions;
                private int _offset_CreateAttributes;
                private int _offset_ShareAccess;
                private int _offset_FileName;

                private int Offset_Irp
                {
                    get
                    {
                        if (_offset_Irp == -1)
                        {
                            _offset_Irp = 0;
                        }

                        return _offset_Irp;
                    }
                }

                private int Offset_ThreadId
                {
                    get
                    {
                        if (_offset_ThreadId == -1)
                        {
                            _offset_ThreadId = Offset_Irp + _etwEvent.AddressSize;
                        }

                        return _offset_ThreadId;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_ThreadId + _etwEvent.AddressSize;
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

                private int Offset_CreateAttributes
                {
                    get
                    {
                        if (_offset_CreateAttributes == -1)
                        {
                            _offset_CreateAttributes = Offset_CreateOptions + 4;
                        }

                        return _offset_CreateAttributes;
                    }
                }

                private int Offset_ShareAccess
                {
                    get
                    {
                        if (_offset_ShareAccess == -1)
                        {
                            _offset_ShareAccess = Offset_CreateAttributes + 4;
                        }

                        return _offset_ShareAccess;
                    }
                }

                private int Offset_FileName
                {
                    get
                    {
                        if (_offset_FileName == -1)
                        {
                            _offset_FileName = Offset_ShareAccess + 4;
                        }

                        return _offset_FileName;
                    }
                }

                /// <summary>
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Retrieves the ThreadId field.
                /// </summary>
                public ulong ThreadId => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ThreadId..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ThreadId..]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..]);

                /// <summary>
                /// Retrieves the CreateOptions field.
                /// </summary>
                public uint CreateOptions => BitConverter.ToUInt32(_etwEvent.Data[Offset_CreateOptions..]);

                /// <summary>
                /// Retrieves the CreateAttributes field.
                /// </summary>
                public uint CreateAttributes => BitConverter.ToUInt32(_etwEvent.Data[Offset_CreateAttributes..]);

                /// <summary>
                /// Retrieves the ShareAccess field.
                /// </summary>
                public uint ShareAccess => BitConverter.ToUInt32(_etwEvent.Data[Offset_ShareAccess..]);

                /// <summary>
                /// Retrieves the FileName field.
                /// </summary>
                public string FileName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FileName..]);

                /// <summary>
                /// Creates a new CreateInfoData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public CreateInfoData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Irp = -1;
                    _offset_ThreadId = -1;
                    _offset_FileObject = -1;
                    _offset_CreateOptions = -1;
                    _offset_CreateAttributes = -1;
                    _offset_ShareAccess = -1;
                    _offset_FileName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a CleanupInfo event.
        /// </summary>
        public readonly ref struct CleanupInfoEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "CleanupInfo";

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
                Channel = 16,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.Cleanup,
                Keyword = (ulong)Keywords.KERNEL_FILE_KEYWORD_FILEIO
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public CleanupInfoData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new CleanupInfoEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public CleanupInfoEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a CleanupInfo event.
            /// </summary>
            public ref struct CleanupInfoData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Irp;
                private int _offset_ThreadId;
                private int _offset_FileObject;
                private int _offset_FileKey;

                private int Offset_Irp
                {
                    get
                    {
                        if (_offset_Irp == -1)
                        {
                            _offset_Irp = 0;
                        }

                        return _offset_Irp;
                    }
                }

                private int Offset_ThreadId
                {
                    get
                    {
                        if (_offset_ThreadId == -1)
                        {
                            _offset_ThreadId = Offset_Irp + _etwEvent.AddressSize;
                        }

                        return _offset_ThreadId;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_ThreadId + _etwEvent.AddressSize;
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
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Retrieves the ThreadId field.
                /// </summary>
                public ulong ThreadId => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ThreadId..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ThreadId..]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..]);

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..]);

                /// <summary>
                /// Creates a new CleanupInfoData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public CleanupInfoData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Irp = -1;
                    _offset_ThreadId = -1;
                    _offset_FileObject = -1;
                    _offset_FileKey = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a CloseInfo event.
        /// </summary>
        public readonly ref struct CloseInfoEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "CloseInfo";

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
                Channel = 16,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.Close,
                Keyword = (ulong)Keywords.KERNEL_FILE_KEYWORD_FILEIO
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public CloseInfoData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new CloseInfoEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public CloseInfoEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a CloseInfo event.
            /// </summary>
            public ref struct CloseInfoData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Irp;
                private int _offset_ThreadId;
                private int _offset_FileObject;
                private int _offset_FileKey;

                private int Offset_Irp
                {
                    get
                    {
                        if (_offset_Irp == -1)
                        {
                            _offset_Irp = 0;
                        }

                        return _offset_Irp;
                    }
                }

                private int Offset_ThreadId
                {
                    get
                    {
                        if (_offset_ThreadId == -1)
                        {
                            _offset_ThreadId = Offset_Irp + _etwEvent.AddressSize;
                        }

                        return _offset_ThreadId;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_ThreadId + _etwEvent.AddressSize;
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
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Retrieves the ThreadId field.
                /// </summary>
                public ulong ThreadId => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ThreadId..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ThreadId..]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..]);

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..]);

                /// <summary>
                /// Creates a new CloseInfoData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public CloseInfoData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Irp = -1;
                    _offset_ThreadId = -1;
                    _offset_FileObject = -1;
                    _offset_FileKey = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ReadInfo event.
        /// </summary>
        public readonly ref struct ReadInfoEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ReadInfo";

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
                Channel = 16,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.Read,
                Keyword = (ulong)Keywords.KERNEL_FILE_KEYWORD_FILEIO | (ulong)Keywords.KERNEL_FILE_KEYWORD_READ
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public ReadInfoData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ReadInfoEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ReadInfoEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ReadInfo event.
            /// </summary>
            public ref struct ReadInfoData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ByteOffset;
                private int _offset_Irp;
                private int _offset_ThreadId;
                private int _offset_FileObject;
                private int _offset_FileKey;
                private int _offset_IOSize;
                private int _offset_IOFlags;

                private int Offset_ByteOffset
                {
                    get
                    {
                        if (_offset_ByteOffset == -1)
                        {
                            _offset_ByteOffset = 0;
                        }

                        return _offset_ByteOffset;
                    }
                }

                private int Offset_Irp
                {
                    get
                    {
                        if (_offset_Irp == -1)
                        {
                            _offset_Irp = Offset_ByteOffset + 8;
                        }

                        return _offset_Irp;
                    }
                }

                private int Offset_ThreadId
                {
                    get
                    {
                        if (_offset_ThreadId == -1)
                        {
                            _offset_ThreadId = Offset_Irp + _etwEvent.AddressSize;
                        }

                        return _offset_ThreadId;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_ThreadId + _etwEvent.AddressSize;
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

                private int Offset_IOSize
                {
                    get
                    {
                        if (_offset_IOSize == -1)
                        {
                            _offset_IOSize = Offset_FileKey + _etwEvent.AddressSize;
                        }

                        return _offset_IOSize;
                    }
                }

                private int Offset_IOFlags
                {
                    get
                    {
                        if (_offset_IOFlags == -1)
                        {
                            _offset_IOFlags = Offset_IOSize + 4;
                        }

                        return _offset_IOFlags;
                    }
                }

                /// <summary>
                /// Retrieves the ByteOffset field.
                /// </summary>
                public ulong ByteOffset => BitConverter.ToUInt64(_etwEvent.Data[Offset_ByteOffset..]);

                /// <summary>
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Retrieves the ThreadId field.
                /// </summary>
                public ulong ThreadId => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ThreadId..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ThreadId..]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..]);

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..]);

                /// <summary>
                /// Retrieves the IOSize field.
                /// </summary>
                public uint IOSize => BitConverter.ToUInt32(_etwEvent.Data[Offset_IOSize..]);

                /// <summary>
                /// Retrieves the IOFlags field.
                /// </summary>
                public uint IOFlags => BitConverter.ToUInt32(_etwEvent.Data[Offset_IOFlags..]);

                /// <summary>
                /// Creates a new ReadInfoData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ReadInfoData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ByteOffset = -1;
                    _offset_Irp = -1;
                    _offset_ThreadId = -1;
                    _offset_FileObject = -1;
                    _offset_FileKey = -1;
                    _offset_IOSize = -1;
                    _offset_IOFlags = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a WriteInfo event.
        /// </summary>
        public readonly ref struct WriteInfoEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "WriteInfo";

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
                Channel = 16,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.Write,
                Keyword = (ulong)Keywords.KERNEL_FILE_KEYWORD_FILEIO | (ulong)Keywords.KERNEL_FILE_KEYWORD_WRITE
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public WriteInfoData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new WriteInfoEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public WriteInfoEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a WriteInfo event.
            /// </summary>
            public ref struct WriteInfoData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ByteOffset;
                private int _offset_Irp;
                private int _offset_ThreadId;
                private int _offset_FileObject;
                private int _offset_FileKey;
                private int _offset_IOSize;
                private int _offset_IOFlags;

                private int Offset_ByteOffset
                {
                    get
                    {
                        if (_offset_ByteOffset == -1)
                        {
                            _offset_ByteOffset = 0;
                        }

                        return _offset_ByteOffset;
                    }
                }

                private int Offset_Irp
                {
                    get
                    {
                        if (_offset_Irp == -1)
                        {
                            _offset_Irp = Offset_ByteOffset + 8;
                        }

                        return _offset_Irp;
                    }
                }

                private int Offset_ThreadId
                {
                    get
                    {
                        if (_offset_ThreadId == -1)
                        {
                            _offset_ThreadId = Offset_Irp + _etwEvent.AddressSize;
                        }

                        return _offset_ThreadId;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_ThreadId + _etwEvent.AddressSize;
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

                private int Offset_IOSize
                {
                    get
                    {
                        if (_offset_IOSize == -1)
                        {
                            _offset_IOSize = Offset_FileKey + _etwEvent.AddressSize;
                        }

                        return _offset_IOSize;
                    }
                }

                private int Offset_IOFlags
                {
                    get
                    {
                        if (_offset_IOFlags == -1)
                        {
                            _offset_IOFlags = Offset_IOSize + 4;
                        }

                        return _offset_IOFlags;
                    }
                }

                /// <summary>
                /// Retrieves the ByteOffset field.
                /// </summary>
                public ulong ByteOffset => BitConverter.ToUInt64(_etwEvent.Data[Offset_ByteOffset..]);

                /// <summary>
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Retrieves the ThreadId field.
                /// </summary>
                public ulong ThreadId => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ThreadId..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ThreadId..]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..]);

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..]);

                /// <summary>
                /// Retrieves the IOSize field.
                /// </summary>
                public uint IOSize => BitConverter.ToUInt32(_etwEvent.Data[Offset_IOSize..]);

                /// <summary>
                /// Retrieves the IOFlags field.
                /// </summary>
                public uint IOFlags => BitConverter.ToUInt32(_etwEvent.Data[Offset_IOFlags..]);

                /// <summary>
                /// Creates a new WriteInfoData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public WriteInfoData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ByteOffset = -1;
                    _offset_Irp = -1;
                    _offset_ThreadId = -1;
                    _offset_FileObject = -1;
                    _offset_FileKey = -1;
                    _offset_IOSize = -1;
                    _offset_IOFlags = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a SetInformationInfo event.
        /// </summary>
        public readonly ref struct SetInformationInfoEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SetInformationInfo";

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
                Channel = 16,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.SetInformation,
                Keyword = (ulong)Keywords.KERNEL_FILE_KEYWORD_FILEIO
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public SetInformationInfoData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new SetInformationInfoEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SetInformationInfoEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a SetInformationInfo event.
            /// </summary>
            public ref struct SetInformationInfoData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Irp;
                private int _offset_ThreadId;
                private int _offset_FileObject;
                private int _offset_FileKey;
                private int _offset_ExtraInformation;
                private int _offset_InfoClass;

                private int Offset_Irp
                {
                    get
                    {
                        if (_offset_Irp == -1)
                        {
                            _offset_Irp = 0;
                        }

                        return _offset_Irp;
                    }
                }

                private int Offset_ThreadId
                {
                    get
                    {
                        if (_offset_ThreadId == -1)
                        {
                            _offset_ThreadId = Offset_Irp + _etwEvent.AddressSize;
                        }

                        return _offset_ThreadId;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_ThreadId + _etwEvent.AddressSize;
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

                private int Offset_ExtraInformation
                {
                    get
                    {
                        if (_offset_ExtraInformation == -1)
                        {
                            _offset_ExtraInformation = Offset_FileKey + _etwEvent.AddressSize;
                        }

                        return _offset_ExtraInformation;
                    }
                }

                private int Offset_InfoClass
                {
                    get
                    {
                        if (_offset_InfoClass == -1)
                        {
                            _offset_InfoClass = Offset_ExtraInformation + _etwEvent.AddressSize;
                        }

                        return _offset_InfoClass;
                    }
                }

                /// <summary>
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Retrieves the ThreadId field.
                /// </summary>
                public ulong ThreadId => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ThreadId..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ThreadId..]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..]);

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..]);

                /// <summary>
                /// Retrieves the ExtraInformation field.
                /// </summary>
                public ulong ExtraInformation => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ExtraInformation..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ExtraInformation..]);

                /// <summary>
                /// Retrieves the InfoClass field.
                /// </summary>
                public uint InfoClass => BitConverter.ToUInt32(_etwEvent.Data[Offset_InfoClass..]);

                /// <summary>
                /// Creates a new SetInformationInfoData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public SetInformationInfoData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Irp = -1;
                    _offset_ThreadId = -1;
                    _offset_FileObject = -1;
                    _offset_FileKey = -1;
                    _offset_ExtraInformation = -1;
                    _offset_InfoClass = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a SetDeleteInfo event.
        /// </summary>
        public readonly ref struct SetDeleteInfoEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SetDeleteInfo";

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
                Channel = 16,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.SetDelete,
                Keyword = (ulong)Keywords.KERNEL_FILE_KEYWORD_FILEIO
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public SetDeleteInfoData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new SetDeleteInfoEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SetDeleteInfoEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a SetDeleteInfo event.
            /// </summary>
            public ref struct SetDeleteInfoData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Irp;
                private int _offset_ThreadId;
                private int _offset_FileObject;
                private int _offset_FileKey;
                private int _offset_ExtraInformation;
                private int _offset_InfoClass;

                private int Offset_Irp
                {
                    get
                    {
                        if (_offset_Irp == -1)
                        {
                            _offset_Irp = 0;
                        }

                        return _offset_Irp;
                    }
                }

                private int Offset_ThreadId
                {
                    get
                    {
                        if (_offset_ThreadId == -1)
                        {
                            _offset_ThreadId = Offset_Irp + _etwEvent.AddressSize;
                        }

                        return _offset_ThreadId;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_ThreadId + _etwEvent.AddressSize;
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

                private int Offset_ExtraInformation
                {
                    get
                    {
                        if (_offset_ExtraInformation == -1)
                        {
                            _offset_ExtraInformation = Offset_FileKey + _etwEvent.AddressSize;
                        }

                        return _offset_ExtraInformation;
                    }
                }

                private int Offset_InfoClass
                {
                    get
                    {
                        if (_offset_InfoClass == -1)
                        {
                            _offset_InfoClass = Offset_ExtraInformation + _etwEvent.AddressSize;
                        }

                        return _offset_InfoClass;
                    }
                }

                /// <summary>
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Retrieves the ThreadId field.
                /// </summary>
                public ulong ThreadId => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ThreadId..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ThreadId..]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..]);

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..]);

                /// <summary>
                /// Retrieves the ExtraInformation field.
                /// </summary>
                public ulong ExtraInformation => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ExtraInformation..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ExtraInformation..]);

                /// <summary>
                /// Retrieves the InfoClass field.
                /// </summary>
                public uint InfoClass => BitConverter.ToUInt32(_etwEvent.Data[Offset_InfoClass..]);

                /// <summary>
                /// Creates a new SetDeleteInfoData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public SetDeleteInfoData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Irp = -1;
                    _offset_ThreadId = -1;
                    _offset_FileObject = -1;
                    _offset_FileKey = -1;
                    _offset_ExtraInformation = -1;
                    _offset_InfoClass = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a RenameInfo event.
        /// </summary>
        public readonly ref struct RenameInfoEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "RenameInfo";

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
                Channel = 16,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.Rename,
                Keyword = (ulong)Keywords.KERNEL_FILE_KEYWORD_FILEIO
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public RenameInfoData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new RenameInfoEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public RenameInfoEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a RenameInfo event.
            /// </summary>
            public ref struct RenameInfoData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Irp;
                private int _offset_ThreadId;
                private int _offset_FileObject;
                private int _offset_FileKey;
                private int _offset_ExtraInformation;
                private int _offset_InfoClass;

                private int Offset_Irp
                {
                    get
                    {
                        if (_offset_Irp == -1)
                        {
                            _offset_Irp = 0;
                        }

                        return _offset_Irp;
                    }
                }

                private int Offset_ThreadId
                {
                    get
                    {
                        if (_offset_ThreadId == -1)
                        {
                            _offset_ThreadId = Offset_Irp + _etwEvent.AddressSize;
                        }

                        return _offset_ThreadId;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_ThreadId + _etwEvent.AddressSize;
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

                private int Offset_ExtraInformation
                {
                    get
                    {
                        if (_offset_ExtraInformation == -1)
                        {
                            _offset_ExtraInformation = Offset_FileKey + _etwEvent.AddressSize;
                        }

                        return _offset_ExtraInformation;
                    }
                }

                private int Offset_InfoClass
                {
                    get
                    {
                        if (_offset_InfoClass == -1)
                        {
                            _offset_InfoClass = Offset_ExtraInformation + _etwEvent.AddressSize;
                        }

                        return _offset_InfoClass;
                    }
                }

                /// <summary>
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Retrieves the ThreadId field.
                /// </summary>
                public ulong ThreadId => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ThreadId..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ThreadId..]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..]);

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..]);

                /// <summary>
                /// Retrieves the ExtraInformation field.
                /// </summary>
                public ulong ExtraInformation => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ExtraInformation..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ExtraInformation..]);

                /// <summary>
                /// Retrieves the InfoClass field.
                /// </summary>
                public uint InfoClass => BitConverter.ToUInt32(_etwEvent.Data[Offset_InfoClass..]);

                /// <summary>
                /// Creates a new RenameInfoData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public RenameInfoData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Irp = -1;
                    _offset_ThreadId = -1;
                    _offset_FileObject = -1;
                    _offset_FileKey = -1;
                    _offset_ExtraInformation = -1;
                    _offset_InfoClass = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DirEnumInfo event.
        /// </summary>
        public readonly ref struct DirEnumInfoEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DirEnumInfo";

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
                Channel = 16,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.DirEnum,
                Keyword = (ulong)Keywords.KERNEL_FILE_KEYWORD_FILEIO
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public DirEnumInfoData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DirEnumInfoEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DirEnumInfoEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a DirEnumInfo event.
            /// </summary>
            public ref struct DirEnumInfoData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Irp;
                private int _offset_ThreadId;
                private int _offset_FileObject;
                private int _offset_FileKey;
                private int _offset_Length;
                private int _offset_InfoClass;
                private int _offset_FileIndex;
                private int _offset_FileName;

                private int Offset_Irp
                {
                    get
                    {
                        if (_offset_Irp == -1)
                        {
                            _offset_Irp = 0;
                        }

                        return _offset_Irp;
                    }
                }

                private int Offset_ThreadId
                {
                    get
                    {
                        if (_offset_ThreadId == -1)
                        {
                            _offset_ThreadId = Offset_Irp + _etwEvent.AddressSize;
                        }

                        return _offset_ThreadId;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_ThreadId + _etwEvent.AddressSize;
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
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Retrieves the ThreadId field.
                /// </summary>
                public ulong ThreadId => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ThreadId..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ThreadId..]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..]);

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..]);

                /// <summary>
                /// Retrieves the Length field.
                /// </summary>
                public uint Length => BitConverter.ToUInt32(_etwEvent.Data[Offset_Length..]);

                /// <summary>
                /// Retrieves the InfoClass field.
                /// </summary>
                public uint InfoClass => BitConverter.ToUInt32(_etwEvent.Data[Offset_InfoClass..]);

                /// <summary>
                /// Retrieves the FileIndex field.
                /// </summary>
                public uint FileIndex => BitConverter.ToUInt32(_etwEvent.Data[Offset_FileIndex..]);

                /// <summary>
                /// Retrieves the FileName field.
                /// </summary>
                public string FileName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FileName..]);

                /// <summary>
                /// Creates a new DirEnumInfoData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DirEnumInfoData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Irp = -1;
                    _offset_ThreadId = -1;
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
        /// An event wrapper for a FlushInfo event.
        /// </summary>
        public readonly ref struct FlushInfoEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "FlushInfo";

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
                Channel = 16,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.Flush,
                Keyword = (ulong)Keywords.KERNEL_FILE_KEYWORD_FILEIO
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public FlushInfoData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new FlushInfoEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public FlushInfoEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a FlushInfo event.
            /// </summary>
            public ref struct FlushInfoData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Irp;
                private int _offset_ThreadId;
                private int _offset_FileObject;
                private int _offset_FileKey;

                private int Offset_Irp
                {
                    get
                    {
                        if (_offset_Irp == -1)
                        {
                            _offset_Irp = 0;
                        }

                        return _offset_Irp;
                    }
                }

                private int Offset_ThreadId
                {
                    get
                    {
                        if (_offset_ThreadId == -1)
                        {
                            _offset_ThreadId = Offset_Irp + _etwEvent.AddressSize;
                        }

                        return _offset_ThreadId;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_ThreadId + _etwEvent.AddressSize;
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
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Retrieves the ThreadId field.
                /// </summary>
                public ulong ThreadId => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ThreadId..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ThreadId..]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..]);

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..]);

                /// <summary>
                /// Creates a new FlushInfoData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public FlushInfoData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Irp = -1;
                    _offset_ThreadId = -1;
                    _offset_FileObject = -1;
                    _offset_FileKey = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a QueryInformationInfo event.
        /// </summary>
        public readonly ref struct QueryInformationInfoEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "QueryInformationInfo";

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
                Channel = 16,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.QueryInformation,
                Keyword = (ulong)Keywords.KERNEL_FILE_KEYWORD_FILEIO
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public QueryInformationInfoData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new QueryInformationInfoEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public QueryInformationInfoEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a QueryInformationInfo event.
            /// </summary>
            public ref struct QueryInformationInfoData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Irp;
                private int _offset_ThreadId;
                private int _offset_FileObject;
                private int _offset_FileKey;
                private int _offset_ExtraInformation;
                private int _offset_InfoClass;

                private int Offset_Irp
                {
                    get
                    {
                        if (_offset_Irp == -1)
                        {
                            _offset_Irp = 0;
                        }

                        return _offset_Irp;
                    }
                }

                private int Offset_ThreadId
                {
                    get
                    {
                        if (_offset_ThreadId == -1)
                        {
                            _offset_ThreadId = Offset_Irp + _etwEvent.AddressSize;
                        }

                        return _offset_ThreadId;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_ThreadId + _etwEvent.AddressSize;
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

                private int Offset_ExtraInformation
                {
                    get
                    {
                        if (_offset_ExtraInformation == -1)
                        {
                            _offset_ExtraInformation = Offset_FileKey + _etwEvent.AddressSize;
                        }

                        return _offset_ExtraInformation;
                    }
                }

                private int Offset_InfoClass
                {
                    get
                    {
                        if (_offset_InfoClass == -1)
                        {
                            _offset_InfoClass = Offset_ExtraInformation + _etwEvent.AddressSize;
                        }

                        return _offset_InfoClass;
                    }
                }

                /// <summary>
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Retrieves the ThreadId field.
                /// </summary>
                public ulong ThreadId => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ThreadId..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ThreadId..]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..]);

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..]);

                /// <summary>
                /// Retrieves the ExtraInformation field.
                /// </summary>
                public ulong ExtraInformation => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ExtraInformation..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ExtraInformation..]);

                /// <summary>
                /// Retrieves the InfoClass field.
                /// </summary>
                public uint InfoClass => BitConverter.ToUInt32(_etwEvent.Data[Offset_InfoClass..]);

                /// <summary>
                /// Creates a new QueryInformationInfoData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public QueryInformationInfoData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Irp = -1;
                    _offset_ThreadId = -1;
                    _offset_FileObject = -1;
                    _offset_FileKey = -1;
                    _offset_ExtraInformation = -1;
                    _offset_InfoClass = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a FSCTLInfo event.
        /// </summary>
        public readonly ref struct FSCTLInfoEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "FSCTLInfo";

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
                Channel = 16,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.FSCTL,
                Keyword = (ulong)Keywords.KERNEL_FILE_KEYWORD_FILEIO
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public FSCTLInfoData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new FSCTLInfoEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public FSCTLInfoEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a FSCTLInfo event.
            /// </summary>
            public ref struct FSCTLInfoData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Irp;
                private int _offset_ThreadId;
                private int _offset_FileObject;
                private int _offset_FileKey;
                private int _offset_ExtraInformation;
                private int _offset_InfoClass;

                private int Offset_Irp
                {
                    get
                    {
                        if (_offset_Irp == -1)
                        {
                            _offset_Irp = 0;
                        }

                        return _offset_Irp;
                    }
                }

                private int Offset_ThreadId
                {
                    get
                    {
                        if (_offset_ThreadId == -1)
                        {
                            _offset_ThreadId = Offset_Irp + _etwEvent.AddressSize;
                        }

                        return _offset_ThreadId;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_ThreadId + _etwEvent.AddressSize;
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

                private int Offset_ExtraInformation
                {
                    get
                    {
                        if (_offset_ExtraInformation == -1)
                        {
                            _offset_ExtraInformation = Offset_FileKey + _etwEvent.AddressSize;
                        }

                        return _offset_ExtraInformation;
                    }
                }

                private int Offset_InfoClass
                {
                    get
                    {
                        if (_offset_InfoClass == -1)
                        {
                            _offset_InfoClass = Offset_ExtraInformation + _etwEvent.AddressSize;
                        }

                        return _offset_InfoClass;
                    }
                }

                /// <summary>
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Retrieves the ThreadId field.
                /// </summary>
                public ulong ThreadId => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ThreadId..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ThreadId..]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..]);

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..]);

                /// <summary>
                /// Retrieves the ExtraInformation field.
                /// </summary>
                public ulong ExtraInformation => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ExtraInformation..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ExtraInformation..]);

                /// <summary>
                /// Retrieves the InfoClass field.
                /// </summary>
                public uint InfoClass => BitConverter.ToUInt32(_etwEvent.Data[Offset_InfoClass..]);

                /// <summary>
                /// Creates a new FSCTLInfoData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public FSCTLInfoData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Irp = -1;
                    _offset_ThreadId = -1;
                    _offset_FileObject = -1;
                    _offset_FileKey = -1;
                    _offset_ExtraInformation = -1;
                    _offset_InfoClass = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a OperationEndInfo event.
        /// </summary>
        public readonly ref struct OperationEndInfoEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "OperationEndInfo";

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
                Channel = 16,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.OperationEnd,
                Keyword = (ulong)Keywords.KERNEL_FILE_KEYWORD_FILEIO | (ulong)Keywords.KERNEL_FILE_KEYWORD_OP_END
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public OperationEndInfoData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new OperationEndInfoEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public OperationEndInfoEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a OperationEndInfo event.
            /// </summary>
            public ref struct OperationEndInfoData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Irp;
                private int _offset_ExtraInformation;
                private int _offset_Status;

                private int Offset_Irp
                {
                    get
                    {
                        if (_offset_Irp == -1)
                        {
                            _offset_Irp = 0;
                        }

                        return _offset_Irp;
                    }
                }

                private int Offset_ExtraInformation
                {
                    get
                    {
                        if (_offset_ExtraInformation == -1)
                        {
                            _offset_ExtraInformation = Offset_Irp + _etwEvent.AddressSize;
                        }

                        return _offset_ExtraInformation;
                    }
                }

                private int Offset_Status
                {
                    get
                    {
                        if (_offset_Status == -1)
                        {
                            _offset_Status = Offset_ExtraInformation + _etwEvent.AddressSize;
                        }

                        return _offset_Status;
                    }
                }

                /// <summary>
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Retrieves the ExtraInformation field.
                /// </summary>
                public ulong ExtraInformation => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ExtraInformation..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ExtraInformation..]);

                /// <summary>
                /// Retrieves the Status field.
                /// </summary>
                public uint Status => BitConverter.ToUInt32(_etwEvent.Data[Offset_Status..]);

                /// <summary>
                /// Creates a new OperationEndInfoData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public OperationEndInfoData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Irp = -1;
                    _offset_ExtraInformation = -1;
                    _offset_Status = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DirNotifyInfo event.
        /// </summary>
        public readonly ref struct DirNotifyInfoEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DirNotifyInfo";

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
                Channel = 16,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.DirNotify,
                Keyword = (ulong)Keywords.KERNEL_FILE_KEYWORD_FILEIO
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public DirNotifyInfoData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DirNotifyInfoEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DirNotifyInfoEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a DirNotifyInfo event.
            /// </summary>
            public ref struct DirNotifyInfoData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Irp;
                private int _offset_ThreadId;
                private int _offset_FileObject;
                private int _offset_FileKey;
                private int _offset_Length;
                private int _offset_InfoClass;
                private int _offset_FileIndex;
                private int _offset_FileName;

                private int Offset_Irp
                {
                    get
                    {
                        if (_offset_Irp == -1)
                        {
                            _offset_Irp = 0;
                        }

                        return _offset_Irp;
                    }
                }

                private int Offset_ThreadId
                {
                    get
                    {
                        if (_offset_ThreadId == -1)
                        {
                            _offset_ThreadId = Offset_Irp + _etwEvent.AddressSize;
                        }

                        return _offset_ThreadId;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_ThreadId + _etwEvent.AddressSize;
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
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Retrieves the ThreadId field.
                /// </summary>
                public ulong ThreadId => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ThreadId..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ThreadId..]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..]);

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..]);

                /// <summary>
                /// Retrieves the Length field.
                /// </summary>
                public uint Length => BitConverter.ToUInt32(_etwEvent.Data[Offset_Length..]);

                /// <summary>
                /// Retrieves the InfoClass field.
                /// </summary>
                public uint InfoClass => BitConverter.ToUInt32(_etwEvent.Data[Offset_InfoClass..]);

                /// <summary>
                /// Retrieves the FileIndex field.
                /// </summary>
                public uint FileIndex => BitConverter.ToUInt32(_etwEvent.Data[Offset_FileIndex..]);

                /// <summary>
                /// Retrieves the FileName field.
                /// </summary>
                public string FileName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FileName..]);

                /// <summary>
                /// Creates a new DirNotifyInfoData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DirNotifyInfoData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Irp = -1;
                    _offset_ThreadId = -1;
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
        /// An event wrapper for a DeletePathInfo event.
        /// </summary>
        public readonly ref struct DeletePathInfoEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DeletePathInfo";

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
                Channel = 16,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.DeletePath,
                Keyword = (ulong)Keywords.KERNEL_FILE_KEYWORD_DELETE_PATH
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public DeletePathInfoData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DeletePathInfoEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DeletePathInfoEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a DeletePathInfo event.
            /// </summary>
            public ref struct DeletePathInfoData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Irp;
                private int _offset_ThreadId;
                private int _offset_FileObject;
                private int _offset_FileKey;
                private int _offset_ExtraInformation;
                private int _offset_InfoClass;
                private int _offset_FilePath;

                private int Offset_Irp
                {
                    get
                    {
                        if (_offset_Irp == -1)
                        {
                            _offset_Irp = 0;
                        }

                        return _offset_Irp;
                    }
                }

                private int Offset_ThreadId
                {
                    get
                    {
                        if (_offset_ThreadId == -1)
                        {
                            _offset_ThreadId = Offset_Irp + _etwEvent.AddressSize;
                        }

                        return _offset_ThreadId;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_ThreadId + _etwEvent.AddressSize;
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

                private int Offset_ExtraInformation
                {
                    get
                    {
                        if (_offset_ExtraInformation == -1)
                        {
                            _offset_ExtraInformation = Offset_FileKey + _etwEvent.AddressSize;
                        }

                        return _offset_ExtraInformation;
                    }
                }

                private int Offset_InfoClass
                {
                    get
                    {
                        if (_offset_InfoClass == -1)
                        {
                            _offset_InfoClass = Offset_ExtraInformation + _etwEvent.AddressSize;
                        }

                        return _offset_InfoClass;
                    }
                }

                private int Offset_FilePath
                {
                    get
                    {
                        if (_offset_FilePath == -1)
                        {
                            _offset_FilePath = Offset_InfoClass + 4;
                        }

                        return _offset_FilePath;
                    }
                }

                /// <summary>
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Retrieves the ThreadId field.
                /// </summary>
                public ulong ThreadId => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ThreadId..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ThreadId..]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..]);

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..]);

                /// <summary>
                /// Retrieves the ExtraInformation field.
                /// </summary>
                public ulong ExtraInformation => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ExtraInformation..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ExtraInformation..]);

                /// <summary>
                /// Retrieves the InfoClass field.
                /// </summary>
                public uint InfoClass => BitConverter.ToUInt32(_etwEvent.Data[Offset_InfoClass..]);

                /// <summary>
                /// Retrieves the FilePath field.
                /// </summary>
                public string FilePath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FilePath..]);

                /// <summary>
                /// Creates a new DeletePathInfoData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DeletePathInfoData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Irp = -1;
                    _offset_ThreadId = -1;
                    _offset_FileObject = -1;
                    _offset_FileKey = -1;
                    _offset_ExtraInformation = -1;
                    _offset_InfoClass = -1;
                    _offset_FilePath = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a RenamePathInfo event.
        /// </summary>
        public readonly ref struct RenamePathInfoEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "RenamePathInfo";

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
                Channel = 16,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.RenamePath,
                Keyword = (ulong)Keywords.KERNEL_FILE_KEYWORD_RENAME_SETLINK_PATH
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public RenamePathInfoData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new RenamePathInfoEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public RenamePathInfoEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a RenamePathInfo event.
            /// </summary>
            public ref struct RenamePathInfoData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Irp;
                private int _offset_ThreadId;
                private int _offset_FileObject;
                private int _offset_FileKey;
                private int _offset_ExtraInformation;
                private int _offset_InfoClass;
                private int _offset_FilePath;

                private int Offset_Irp
                {
                    get
                    {
                        if (_offset_Irp == -1)
                        {
                            _offset_Irp = 0;
                        }

                        return _offset_Irp;
                    }
                }

                private int Offset_ThreadId
                {
                    get
                    {
                        if (_offset_ThreadId == -1)
                        {
                            _offset_ThreadId = Offset_Irp + _etwEvent.AddressSize;
                        }

                        return _offset_ThreadId;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_ThreadId + _etwEvent.AddressSize;
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

                private int Offset_ExtraInformation
                {
                    get
                    {
                        if (_offset_ExtraInformation == -1)
                        {
                            _offset_ExtraInformation = Offset_FileKey + _etwEvent.AddressSize;
                        }

                        return _offset_ExtraInformation;
                    }
                }

                private int Offset_InfoClass
                {
                    get
                    {
                        if (_offset_InfoClass == -1)
                        {
                            _offset_InfoClass = Offset_ExtraInformation + _etwEvent.AddressSize;
                        }

                        return _offset_InfoClass;
                    }
                }

                private int Offset_FilePath
                {
                    get
                    {
                        if (_offset_FilePath == -1)
                        {
                            _offset_FilePath = Offset_InfoClass + 4;
                        }

                        return _offset_FilePath;
                    }
                }

                /// <summary>
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Retrieves the ThreadId field.
                /// </summary>
                public ulong ThreadId => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ThreadId..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ThreadId..]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..]);

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..]);

                /// <summary>
                /// Retrieves the ExtraInformation field.
                /// </summary>
                public ulong ExtraInformation => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ExtraInformation..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ExtraInformation..]);

                /// <summary>
                /// Retrieves the InfoClass field.
                /// </summary>
                public uint InfoClass => BitConverter.ToUInt32(_etwEvent.Data[Offset_InfoClass..]);

                /// <summary>
                /// Retrieves the FilePath field.
                /// </summary>
                public string FilePath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FilePath..]);

                /// <summary>
                /// Creates a new RenamePathInfoData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public RenamePathInfoData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Irp = -1;
                    _offset_ThreadId = -1;
                    _offset_FileObject = -1;
                    _offset_FileKey = -1;
                    _offset_ExtraInformation = -1;
                    _offset_InfoClass = -1;
                    _offset_FilePath = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a SetLinkPathInfo event.
        /// </summary>
        public readonly ref struct SetLinkPathInfoEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SetLinkPathInfo";

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
                Channel = 16,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.SetLinkPath,
                Keyword = (ulong)Keywords.KERNEL_FILE_KEYWORD_RENAME_SETLINK_PATH
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public SetLinkPathInfoData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new SetLinkPathInfoEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SetLinkPathInfoEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a SetLinkPathInfo event.
            /// </summary>
            public ref struct SetLinkPathInfoData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Irp;
                private int _offset_ThreadId;
                private int _offset_FileObject;
                private int _offset_FileKey;
                private int _offset_ExtraInformation;
                private int _offset_InfoClass;
                private int _offset_FilePath;

                private int Offset_Irp
                {
                    get
                    {
                        if (_offset_Irp == -1)
                        {
                            _offset_Irp = 0;
                        }

                        return _offset_Irp;
                    }
                }

                private int Offset_ThreadId
                {
                    get
                    {
                        if (_offset_ThreadId == -1)
                        {
                            _offset_ThreadId = Offset_Irp + _etwEvent.AddressSize;
                        }

                        return _offset_ThreadId;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_ThreadId + _etwEvent.AddressSize;
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

                private int Offset_ExtraInformation
                {
                    get
                    {
                        if (_offset_ExtraInformation == -1)
                        {
                            _offset_ExtraInformation = Offset_FileKey + _etwEvent.AddressSize;
                        }

                        return _offset_ExtraInformation;
                    }
                }

                private int Offset_InfoClass
                {
                    get
                    {
                        if (_offset_InfoClass == -1)
                        {
                            _offset_InfoClass = Offset_ExtraInformation + _etwEvent.AddressSize;
                        }

                        return _offset_InfoClass;
                    }
                }

                private int Offset_FilePath
                {
                    get
                    {
                        if (_offset_FilePath == -1)
                        {
                            _offset_FilePath = Offset_InfoClass + 4;
                        }

                        return _offset_FilePath;
                    }
                }

                /// <summary>
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Retrieves the ThreadId field.
                /// </summary>
                public ulong ThreadId => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ThreadId..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ThreadId..]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..]);

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..]);

                /// <summary>
                /// Retrieves the ExtraInformation field.
                /// </summary>
                public ulong ExtraInformation => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ExtraInformation..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ExtraInformation..]);

                /// <summary>
                /// Retrieves the InfoClass field.
                /// </summary>
                public uint InfoClass => BitConverter.ToUInt32(_etwEvent.Data[Offset_InfoClass..]);

                /// <summary>
                /// Retrieves the FilePath field.
                /// </summary>
                public string FilePath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FilePath..]);

                /// <summary>
                /// Creates a new SetLinkPathInfoData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public SetLinkPathInfoData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Irp = -1;
                    _offset_ThreadId = -1;
                    _offset_FileObject = -1;
                    _offset_FileKey = -1;
                    _offset_ExtraInformation = -1;
                    _offset_InfoClass = -1;
                    _offset_FilePath = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a SetLinkInfo event.
        /// </summary>
        public readonly ref struct SetLinkInfoEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SetLinkInfo";

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
                Channel = 16,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.Rename,
                Keyword = (ulong)Keywords.KERNEL_FILE_KEYWORD_FILEIO
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public SetLinkInfoData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new SetLinkInfoEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SetLinkInfoEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a SetLinkInfo event.
            /// </summary>
            public ref struct SetLinkInfoData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Irp;
                private int _offset_ThreadId;
                private int _offset_FileObject;
                private int _offset_FileKey;
                private int _offset_ExtraInformation;
                private int _offset_InfoClass;

                private int Offset_Irp
                {
                    get
                    {
                        if (_offset_Irp == -1)
                        {
                            _offset_Irp = 0;
                        }

                        return _offset_Irp;
                    }
                }

                private int Offset_ThreadId
                {
                    get
                    {
                        if (_offset_ThreadId == -1)
                        {
                            _offset_ThreadId = Offset_Irp + _etwEvent.AddressSize;
                        }

                        return _offset_ThreadId;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_ThreadId + _etwEvent.AddressSize;
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

                private int Offset_ExtraInformation
                {
                    get
                    {
                        if (_offset_ExtraInformation == -1)
                        {
                            _offset_ExtraInformation = Offset_FileKey + _etwEvent.AddressSize;
                        }

                        return _offset_ExtraInformation;
                    }
                }

                private int Offset_InfoClass
                {
                    get
                    {
                        if (_offset_InfoClass == -1)
                        {
                            _offset_InfoClass = Offset_ExtraInformation + _etwEvent.AddressSize;
                        }

                        return _offset_InfoClass;
                    }
                }

                /// <summary>
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Retrieves the ThreadId field.
                /// </summary>
                public ulong ThreadId => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ThreadId..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ThreadId..]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..]);

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..]);

                /// <summary>
                /// Retrieves the ExtraInformation field.
                /// </summary>
                public ulong ExtraInformation => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ExtraInformation..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ExtraInformation..]);

                /// <summary>
                /// Retrieves the InfoClass field.
                /// </summary>
                public uint InfoClass => BitConverter.ToUInt32(_etwEvent.Data[Offset_InfoClass..]);

                /// <summary>
                /// Creates a new SetLinkInfoData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public SetLinkInfoData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Irp = -1;
                    _offset_ThreadId = -1;
                    _offset_FileObject = -1;
                    _offset_FileKey = -1;
                    _offset_ExtraInformation = -1;
                    _offset_InfoClass = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a CreateNewFileInfo event.
        /// </summary>
        public readonly ref struct CreateNewFileInfoEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "CreateNewFileInfo";

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
                Channel = 16,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.CreateNewFile,
                Keyword = (ulong)Keywords.KERNEL_FILE_KEYWORD_CREATE_NEW_FILE
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public CreateNewFileInfoData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new CreateNewFileInfoEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public CreateNewFileInfoEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a CreateNewFileInfo event.
            /// </summary>
            public ref struct CreateNewFileInfoData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Irp;
                private int _offset_ThreadId;
                private int _offset_FileObject;
                private int _offset_CreateOptions;
                private int _offset_CreateAttributes;
                private int _offset_ShareAccess;
                private int _offset_FileName;

                private int Offset_Irp
                {
                    get
                    {
                        if (_offset_Irp == -1)
                        {
                            _offset_Irp = 0;
                        }

                        return _offset_Irp;
                    }
                }

                private int Offset_ThreadId
                {
                    get
                    {
                        if (_offset_ThreadId == -1)
                        {
                            _offset_ThreadId = Offset_Irp + _etwEvent.AddressSize;
                        }

                        return _offset_ThreadId;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_ThreadId + _etwEvent.AddressSize;
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

                private int Offset_CreateAttributes
                {
                    get
                    {
                        if (_offset_CreateAttributes == -1)
                        {
                            _offset_CreateAttributes = Offset_CreateOptions + 4;
                        }

                        return _offset_CreateAttributes;
                    }
                }

                private int Offset_ShareAccess
                {
                    get
                    {
                        if (_offset_ShareAccess == -1)
                        {
                            _offset_ShareAccess = Offset_CreateAttributes + 4;
                        }

                        return _offset_ShareAccess;
                    }
                }

                private int Offset_FileName
                {
                    get
                    {
                        if (_offset_FileName == -1)
                        {
                            _offset_FileName = Offset_ShareAccess + 4;
                        }

                        return _offset_FileName;
                    }
                }

                /// <summary>
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Retrieves the ThreadId field.
                /// </summary>
                public ulong ThreadId => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ThreadId..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ThreadId..]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..]);

                /// <summary>
                /// Retrieves the CreateOptions field.
                /// </summary>
                public uint CreateOptions => BitConverter.ToUInt32(_etwEvent.Data[Offset_CreateOptions..]);

                /// <summary>
                /// Retrieves the CreateAttributes field.
                /// </summary>
                public uint CreateAttributes => BitConverter.ToUInt32(_etwEvent.Data[Offset_CreateAttributes..]);

                /// <summary>
                /// Retrieves the ShareAccess field.
                /// </summary>
                public uint ShareAccess => BitConverter.ToUInt32(_etwEvent.Data[Offset_ShareAccess..]);

                /// <summary>
                /// Retrieves the FileName field.
                /// </summary>
                public string FileName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FileName..]);

                /// <summary>
                /// Creates a new CreateNewFileInfoData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public CreateNewFileInfoData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Irp = -1;
                    _offset_ThreadId = -1;
                    _offset_FileObject = -1;
                    _offset_CreateOptions = -1;
                    _offset_CreateAttributes = -1;
                    _offset_ShareAccess = -1;
                    _offset_FileName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a CreateInfo event.
        /// </summary>
        public readonly ref struct CreateInfoEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "CreateInfo";

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
                Version = 1,
                Channel = 16,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.Create,
                Keyword = (ulong)Keywords.KERNEL_FILE_KEYWORD_FILEIO | (ulong)Keywords.KERNEL_FILE_KEYWORD_CREATE
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public CreateInfoData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new CreateInfoEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public CreateInfoEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a CreateInfo event.
            /// </summary>
            public ref struct CreateInfoData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Irp;
                private int _offset_FileObject;
                private int _offset_IssuingThreadId;
                private int _offset_CreateOptions;
                private int _offset_CreateAttributes;
                private int _offset_ShareAccess;
                private int _offset_FileName;

                private int Offset_Irp
                {
                    get
                    {
                        if (_offset_Irp == -1)
                        {
                            _offset_Irp = 0;
                        }

                        return _offset_Irp;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_Irp + _etwEvent.AddressSize;
                        }

                        return _offset_FileObject;
                    }
                }

                private int Offset_IssuingThreadId
                {
                    get
                    {
                        if (_offset_IssuingThreadId == -1)
                        {
                            _offset_IssuingThreadId = Offset_FileObject + _etwEvent.AddressSize;
                        }

                        return _offset_IssuingThreadId;
                    }
                }

                private int Offset_CreateOptions
                {
                    get
                    {
                        if (_offset_CreateOptions == -1)
                        {
                            _offset_CreateOptions = Offset_IssuingThreadId + 4;
                        }

                        return _offset_CreateOptions;
                    }
                }

                private int Offset_CreateAttributes
                {
                    get
                    {
                        if (_offset_CreateAttributes == -1)
                        {
                            _offset_CreateAttributes = Offset_CreateOptions + 4;
                        }

                        return _offset_CreateAttributes;
                    }
                }

                private int Offset_ShareAccess
                {
                    get
                    {
                        if (_offset_ShareAccess == -1)
                        {
                            _offset_ShareAccess = Offset_CreateAttributes + 4;
                        }

                        return _offset_ShareAccess;
                    }
                }

                private int Offset_FileName
                {
                    get
                    {
                        if (_offset_FileName == -1)
                        {
                            _offset_FileName = Offset_ShareAccess + 4;
                        }

                        return _offset_FileName;
                    }
                }

                /// <summary>
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..]);

                /// <summary>
                /// Retrieves the IssuingThreadId field.
                /// </summary>
                public uint IssuingThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_IssuingThreadId..]);

                /// <summary>
                /// Retrieves the CreateOptions field.
                /// </summary>
                public uint CreateOptions => BitConverter.ToUInt32(_etwEvent.Data[Offset_CreateOptions..]);

                /// <summary>
                /// Retrieves the CreateAttributes field.
                /// </summary>
                public uint CreateAttributes => BitConverter.ToUInt32(_etwEvent.Data[Offset_CreateAttributes..]);

                /// <summary>
                /// Retrieves the ShareAccess field.
                /// </summary>
                public uint ShareAccess => BitConverter.ToUInt32(_etwEvent.Data[Offset_ShareAccess..]);

                /// <summary>
                /// Retrieves the FileName field.
                /// </summary>
                public string FileName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FileName..]);

                /// <summary>
                /// Creates a new CreateInfoData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public CreateInfoData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Irp = -1;
                    _offset_FileObject = -1;
                    _offset_IssuingThreadId = -1;
                    _offset_CreateOptions = -1;
                    _offset_CreateAttributes = -1;
                    _offset_ShareAccess = -1;
                    _offset_FileName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a CleanupInfo event.
        /// </summary>
        public readonly ref struct CleanupInfoEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "CleanupInfo";

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
                Version = 1,
                Channel = 16,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.Cleanup,
                Keyword = (ulong)Keywords.KERNEL_FILE_KEYWORD_FILEIO
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public CleanupInfoData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new CleanupInfoEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public CleanupInfoEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a CleanupInfo event.
            /// </summary>
            public ref struct CleanupInfoData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Irp;
                private int _offset_FileObject;
                private int _offset_FileKey;
                private int _offset_IssuingThreadId;

                private int Offset_Irp
                {
                    get
                    {
                        if (_offset_Irp == -1)
                        {
                            _offset_Irp = 0;
                        }

                        return _offset_Irp;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_Irp + _etwEvent.AddressSize;
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

                private int Offset_IssuingThreadId
                {
                    get
                    {
                        if (_offset_IssuingThreadId == -1)
                        {
                            _offset_IssuingThreadId = Offset_FileKey + _etwEvent.AddressSize;
                        }

                        return _offset_IssuingThreadId;
                    }
                }

                /// <summary>
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..]);

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..]);

                /// <summary>
                /// Retrieves the IssuingThreadId field.
                /// </summary>
                public uint IssuingThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_IssuingThreadId..]);

                /// <summary>
                /// Creates a new CleanupInfoData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public CleanupInfoData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Irp = -1;
                    _offset_FileObject = -1;
                    _offset_FileKey = -1;
                    _offset_IssuingThreadId = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a CloseInfo event.
        /// </summary>
        public readonly ref struct CloseInfoEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "CloseInfo";

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
                Channel = 16,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.Close,
                Keyword = (ulong)Keywords.KERNEL_FILE_KEYWORD_FILEIO
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public CloseInfoData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new CloseInfoEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public CloseInfoEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a CloseInfo event.
            /// </summary>
            public ref struct CloseInfoData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Irp;
                private int _offset_FileObject;
                private int _offset_FileKey;
                private int _offset_IssuingThreadId;

                private int Offset_Irp
                {
                    get
                    {
                        if (_offset_Irp == -1)
                        {
                            _offset_Irp = 0;
                        }

                        return _offset_Irp;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_Irp + _etwEvent.AddressSize;
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

                private int Offset_IssuingThreadId
                {
                    get
                    {
                        if (_offset_IssuingThreadId == -1)
                        {
                            _offset_IssuingThreadId = Offset_FileKey + _etwEvent.AddressSize;
                        }

                        return _offset_IssuingThreadId;
                    }
                }

                /// <summary>
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..]);

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..]);

                /// <summary>
                /// Retrieves the IssuingThreadId field.
                /// </summary>
                public uint IssuingThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_IssuingThreadId..]);

                /// <summary>
                /// Creates a new CloseInfoData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public CloseInfoData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Irp = -1;
                    _offset_FileObject = -1;
                    _offset_FileKey = -1;
                    _offset_IssuingThreadId = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ReadInfo event.
        /// </summary>
        public readonly ref struct ReadInfoEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ReadInfo";

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
                Channel = 16,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.Read,
                Keyword = (ulong)Keywords.KERNEL_FILE_KEYWORD_FILEIO | (ulong)Keywords.KERNEL_FILE_KEYWORD_READ
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public ReadInfoData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ReadInfoEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ReadInfoEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ReadInfo event.
            /// </summary>
            public ref struct ReadInfoData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ByteOffset;
                private int _offset_Irp;
                private int _offset_FileObject;
                private int _offset_FileKey;
                private int _offset_IssuingThreadId;
                private int _offset_IOSize;
                private int _offset_IOFlags;
                private int _offset_ExtraFlags;

                private int Offset_ByteOffset
                {
                    get
                    {
                        if (_offset_ByteOffset == -1)
                        {
                            _offset_ByteOffset = 0;
                        }

                        return _offset_ByteOffset;
                    }
                }

                private int Offset_Irp
                {
                    get
                    {
                        if (_offset_Irp == -1)
                        {
                            _offset_Irp = Offset_ByteOffset + 8;
                        }

                        return _offset_Irp;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_Irp + _etwEvent.AddressSize;
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

                private int Offset_IssuingThreadId
                {
                    get
                    {
                        if (_offset_IssuingThreadId == -1)
                        {
                            _offset_IssuingThreadId = Offset_FileKey + _etwEvent.AddressSize;
                        }

                        return _offset_IssuingThreadId;
                    }
                }

                private int Offset_IOSize
                {
                    get
                    {
                        if (_offset_IOSize == -1)
                        {
                            _offset_IOSize = Offset_IssuingThreadId + 4;
                        }

                        return _offset_IOSize;
                    }
                }

                private int Offset_IOFlags
                {
                    get
                    {
                        if (_offset_IOFlags == -1)
                        {
                            _offset_IOFlags = Offset_IOSize + 4;
                        }

                        return _offset_IOFlags;
                    }
                }

                private int Offset_ExtraFlags
                {
                    get
                    {
                        if (_offset_ExtraFlags == -1)
                        {
                            _offset_ExtraFlags = Offset_IOFlags + 4;
                        }

                        return _offset_ExtraFlags;
                    }
                }

                /// <summary>
                /// Retrieves the ByteOffset field.
                /// </summary>
                public ulong ByteOffset => BitConverter.ToUInt64(_etwEvent.Data[Offset_ByteOffset..]);

                /// <summary>
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..]);

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..]);

                /// <summary>
                /// Retrieves the IssuingThreadId field.
                /// </summary>
                public uint IssuingThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_IssuingThreadId..]);

                /// <summary>
                /// Retrieves the IOSize field.
                /// </summary>
                public uint IOSize => BitConverter.ToUInt32(_etwEvent.Data[Offset_IOSize..]);

                /// <summary>
                /// Retrieves the IOFlags field.
                /// </summary>
                public uint IOFlags => BitConverter.ToUInt32(_etwEvent.Data[Offset_IOFlags..]);

                /// <summary>
                /// Retrieves the ExtraFlags field.
                /// </summary>
                public uint ExtraFlags => BitConverter.ToUInt32(_etwEvent.Data[Offset_ExtraFlags..]);

                /// <summary>
                /// Creates a new ReadInfoData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ReadInfoData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ByteOffset = -1;
                    _offset_Irp = -1;
                    _offset_FileObject = -1;
                    _offset_FileKey = -1;
                    _offset_IssuingThreadId = -1;
                    _offset_IOSize = -1;
                    _offset_IOFlags = -1;
                    _offset_ExtraFlags = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a WriteInfo event.
        /// </summary>
        public readonly ref struct WriteInfoEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "WriteInfo";

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
                Channel = 16,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.Write,
                Keyword = (ulong)Keywords.KERNEL_FILE_KEYWORD_FILEIO | (ulong)Keywords.KERNEL_FILE_KEYWORD_WRITE
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public WriteInfoData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new WriteInfoEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public WriteInfoEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a WriteInfo event.
            /// </summary>
            public ref struct WriteInfoData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ByteOffset;
                private int _offset_Irp;
                private int _offset_FileObject;
                private int _offset_FileKey;
                private int _offset_IssuingThreadId;
                private int _offset_IOSize;
                private int _offset_IOFlags;
                private int _offset_ExtraFlags;

                private int Offset_ByteOffset
                {
                    get
                    {
                        if (_offset_ByteOffset == -1)
                        {
                            _offset_ByteOffset = 0;
                        }

                        return _offset_ByteOffset;
                    }
                }

                private int Offset_Irp
                {
                    get
                    {
                        if (_offset_Irp == -1)
                        {
                            _offset_Irp = Offset_ByteOffset + 8;
                        }

                        return _offset_Irp;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_Irp + _etwEvent.AddressSize;
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

                private int Offset_IssuingThreadId
                {
                    get
                    {
                        if (_offset_IssuingThreadId == -1)
                        {
                            _offset_IssuingThreadId = Offset_FileKey + _etwEvent.AddressSize;
                        }

                        return _offset_IssuingThreadId;
                    }
                }

                private int Offset_IOSize
                {
                    get
                    {
                        if (_offset_IOSize == -1)
                        {
                            _offset_IOSize = Offset_IssuingThreadId + 4;
                        }

                        return _offset_IOSize;
                    }
                }

                private int Offset_IOFlags
                {
                    get
                    {
                        if (_offset_IOFlags == -1)
                        {
                            _offset_IOFlags = Offset_IOSize + 4;
                        }

                        return _offset_IOFlags;
                    }
                }

                private int Offset_ExtraFlags
                {
                    get
                    {
                        if (_offset_ExtraFlags == -1)
                        {
                            _offset_ExtraFlags = Offset_IOFlags + 4;
                        }

                        return _offset_ExtraFlags;
                    }
                }

                /// <summary>
                /// Retrieves the ByteOffset field.
                /// </summary>
                public ulong ByteOffset => BitConverter.ToUInt64(_etwEvent.Data[Offset_ByteOffset..]);

                /// <summary>
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..]);

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..]);

                /// <summary>
                /// Retrieves the IssuingThreadId field.
                /// </summary>
                public uint IssuingThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_IssuingThreadId..]);

                /// <summary>
                /// Retrieves the IOSize field.
                /// </summary>
                public uint IOSize => BitConverter.ToUInt32(_etwEvent.Data[Offset_IOSize..]);

                /// <summary>
                /// Retrieves the IOFlags field.
                /// </summary>
                public uint IOFlags => BitConverter.ToUInt32(_etwEvent.Data[Offset_IOFlags..]);

                /// <summary>
                /// Retrieves the ExtraFlags field.
                /// </summary>
                public uint ExtraFlags => BitConverter.ToUInt32(_etwEvent.Data[Offset_ExtraFlags..]);

                /// <summary>
                /// Creates a new WriteInfoData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public WriteInfoData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ByteOffset = -1;
                    _offset_Irp = -1;
                    _offset_FileObject = -1;
                    _offset_FileKey = -1;
                    _offset_IssuingThreadId = -1;
                    _offset_IOSize = -1;
                    _offset_IOFlags = -1;
                    _offset_ExtraFlags = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a SetInformationInfo event.
        /// </summary>
        public readonly ref struct SetInformationInfoEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SetInformationInfo";

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
                Channel = 16,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.SetInformation,
                Keyword = (ulong)Keywords.KERNEL_FILE_KEYWORD_FILEIO
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public SetInformationInfoData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new SetInformationInfoEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SetInformationInfoEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a SetInformationInfo event.
            /// </summary>
            public ref struct SetInformationInfoData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Irp;
                private int _offset_FileObject;
                private int _offset_FileKey;
                private int _offset_ExtraInformation;
                private int _offset_IssuingThreadId;
                private int _offset_InfoClass;

                private int Offset_Irp
                {
                    get
                    {
                        if (_offset_Irp == -1)
                        {
                            _offset_Irp = 0;
                        }

                        return _offset_Irp;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_Irp + _etwEvent.AddressSize;
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

                private int Offset_ExtraInformation
                {
                    get
                    {
                        if (_offset_ExtraInformation == -1)
                        {
                            _offset_ExtraInformation = Offset_FileKey + _etwEvent.AddressSize;
                        }

                        return _offset_ExtraInformation;
                    }
                }

                private int Offset_IssuingThreadId
                {
                    get
                    {
                        if (_offset_IssuingThreadId == -1)
                        {
                            _offset_IssuingThreadId = Offset_ExtraInformation + _etwEvent.AddressSize;
                        }

                        return _offset_IssuingThreadId;
                    }
                }

                private int Offset_InfoClass
                {
                    get
                    {
                        if (_offset_InfoClass == -1)
                        {
                            _offset_InfoClass = Offset_IssuingThreadId + 4;
                        }

                        return _offset_InfoClass;
                    }
                }

                /// <summary>
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..]);

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..]);

                /// <summary>
                /// Retrieves the ExtraInformation field.
                /// </summary>
                public ulong ExtraInformation => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ExtraInformation..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ExtraInformation..]);

                /// <summary>
                /// Retrieves the IssuingThreadId field.
                /// </summary>
                public uint IssuingThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_IssuingThreadId..]);

                /// <summary>
                /// Retrieves the InfoClass field.
                /// </summary>
                public uint InfoClass => BitConverter.ToUInt32(_etwEvent.Data[Offset_InfoClass..]);

                /// <summary>
                /// Creates a new SetInformationInfoData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public SetInformationInfoData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Irp = -1;
                    _offset_FileObject = -1;
                    _offset_FileKey = -1;
                    _offset_ExtraInformation = -1;
                    _offset_IssuingThreadId = -1;
                    _offset_InfoClass = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a SetDeleteInfo event.
        /// </summary>
        public readonly ref struct SetDeleteInfoEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SetDeleteInfo";

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
                Channel = 16,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.SetDelete,
                Keyword = (ulong)Keywords.KERNEL_FILE_KEYWORD_FILEIO
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public SetDeleteInfoData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new SetDeleteInfoEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SetDeleteInfoEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a SetDeleteInfo event.
            /// </summary>
            public ref struct SetDeleteInfoData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Irp;
                private int _offset_FileObject;
                private int _offset_FileKey;
                private int _offset_ExtraInformation;
                private int _offset_IssuingThreadId;
                private int _offset_InfoClass;

                private int Offset_Irp
                {
                    get
                    {
                        if (_offset_Irp == -1)
                        {
                            _offset_Irp = 0;
                        }

                        return _offset_Irp;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_Irp + _etwEvent.AddressSize;
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

                private int Offset_ExtraInformation
                {
                    get
                    {
                        if (_offset_ExtraInformation == -1)
                        {
                            _offset_ExtraInformation = Offset_FileKey + _etwEvent.AddressSize;
                        }

                        return _offset_ExtraInformation;
                    }
                }

                private int Offset_IssuingThreadId
                {
                    get
                    {
                        if (_offset_IssuingThreadId == -1)
                        {
                            _offset_IssuingThreadId = Offset_ExtraInformation + _etwEvent.AddressSize;
                        }

                        return _offset_IssuingThreadId;
                    }
                }

                private int Offset_InfoClass
                {
                    get
                    {
                        if (_offset_InfoClass == -1)
                        {
                            _offset_InfoClass = Offset_IssuingThreadId + 4;
                        }

                        return _offset_InfoClass;
                    }
                }

                /// <summary>
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..]);

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..]);

                /// <summary>
                /// Retrieves the ExtraInformation field.
                /// </summary>
                public ulong ExtraInformation => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ExtraInformation..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ExtraInformation..]);

                /// <summary>
                /// Retrieves the IssuingThreadId field.
                /// </summary>
                public uint IssuingThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_IssuingThreadId..]);

                /// <summary>
                /// Retrieves the InfoClass field.
                /// </summary>
                public uint InfoClass => BitConverter.ToUInt32(_etwEvent.Data[Offset_InfoClass..]);

                /// <summary>
                /// Creates a new SetDeleteInfoData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public SetDeleteInfoData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Irp = -1;
                    _offset_FileObject = -1;
                    _offset_FileKey = -1;
                    _offset_ExtraInformation = -1;
                    _offset_IssuingThreadId = -1;
                    _offset_InfoClass = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a RenameInfo event.
        /// </summary>
        public readonly ref struct RenameInfoEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "RenameInfo";

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
                Version = 1,
                Channel = 16,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.Rename,
                Keyword = (ulong)Keywords.KERNEL_FILE_KEYWORD_FILEIO
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public RenameInfoData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new RenameInfoEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public RenameInfoEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a RenameInfo event.
            /// </summary>
            public ref struct RenameInfoData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Irp;
                private int _offset_FileObject;
                private int _offset_FileKey;
                private int _offset_ExtraInformation;
                private int _offset_IssuingThreadId;
                private int _offset_InfoClass;

                private int Offset_Irp
                {
                    get
                    {
                        if (_offset_Irp == -1)
                        {
                            _offset_Irp = 0;
                        }

                        return _offset_Irp;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_Irp + _etwEvent.AddressSize;
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

                private int Offset_ExtraInformation
                {
                    get
                    {
                        if (_offset_ExtraInformation == -1)
                        {
                            _offset_ExtraInformation = Offset_FileKey + _etwEvent.AddressSize;
                        }

                        return _offset_ExtraInformation;
                    }
                }

                private int Offset_IssuingThreadId
                {
                    get
                    {
                        if (_offset_IssuingThreadId == -1)
                        {
                            _offset_IssuingThreadId = Offset_ExtraInformation + _etwEvent.AddressSize;
                        }

                        return _offset_IssuingThreadId;
                    }
                }

                private int Offset_InfoClass
                {
                    get
                    {
                        if (_offset_InfoClass == -1)
                        {
                            _offset_InfoClass = Offset_IssuingThreadId + 4;
                        }

                        return _offset_InfoClass;
                    }
                }

                /// <summary>
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..]);

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..]);

                /// <summary>
                /// Retrieves the ExtraInformation field.
                /// </summary>
                public ulong ExtraInformation => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ExtraInformation..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ExtraInformation..]);

                /// <summary>
                /// Retrieves the IssuingThreadId field.
                /// </summary>
                public uint IssuingThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_IssuingThreadId..]);

                /// <summary>
                /// Retrieves the InfoClass field.
                /// </summary>
                public uint InfoClass => BitConverter.ToUInt32(_etwEvent.Data[Offset_InfoClass..]);

                /// <summary>
                /// Creates a new RenameInfoData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public RenameInfoData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Irp = -1;
                    _offset_FileObject = -1;
                    _offset_FileKey = -1;
                    _offset_ExtraInformation = -1;
                    _offset_IssuingThreadId = -1;
                    _offset_InfoClass = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DirEnumInfo event.
        /// </summary>
        public readonly ref struct DirEnumInfoEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DirEnumInfo";

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
                Version = 1,
                Channel = 16,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.DirEnum,
                Keyword = (ulong)Keywords.KERNEL_FILE_KEYWORD_FILEIO
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public DirEnumInfoData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DirEnumInfoEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DirEnumInfoEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a DirEnumInfo event.
            /// </summary>
            public ref struct DirEnumInfoData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Irp;
                private int _offset_FileObject;
                private int _offset_FileKey;
                private int _offset_IssuingThreadId;
                private int _offset_Length;
                private int _offset_InfoClass;
                private int _offset_FileIndex;
                private int _offset_FileName;

                private int Offset_Irp
                {
                    get
                    {
                        if (_offset_Irp == -1)
                        {
                            _offset_Irp = 0;
                        }

                        return _offset_Irp;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_Irp + _etwEvent.AddressSize;
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

                private int Offset_IssuingThreadId
                {
                    get
                    {
                        if (_offset_IssuingThreadId == -1)
                        {
                            _offset_IssuingThreadId = Offset_FileKey + _etwEvent.AddressSize;
                        }

                        return _offset_IssuingThreadId;
                    }
                }

                private int Offset_Length
                {
                    get
                    {
                        if (_offset_Length == -1)
                        {
                            _offset_Length = Offset_IssuingThreadId + 4;
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
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..]);

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..]);

                /// <summary>
                /// Retrieves the IssuingThreadId field.
                /// </summary>
                public uint IssuingThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_IssuingThreadId..]);

                /// <summary>
                /// Retrieves the Length field.
                /// </summary>
                public uint Length => BitConverter.ToUInt32(_etwEvent.Data[Offset_Length..]);

                /// <summary>
                /// Retrieves the InfoClass field.
                /// </summary>
                public uint InfoClass => BitConverter.ToUInt32(_etwEvent.Data[Offset_InfoClass..]);

                /// <summary>
                /// Retrieves the FileIndex field.
                /// </summary>
                public uint FileIndex => BitConverter.ToUInt32(_etwEvent.Data[Offset_FileIndex..]);

                /// <summary>
                /// Retrieves the FileName field.
                /// </summary>
                public string FileName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FileName..]);

                /// <summary>
                /// Creates a new DirEnumInfoData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DirEnumInfoData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Irp = -1;
                    _offset_FileObject = -1;
                    _offset_FileKey = -1;
                    _offset_IssuingThreadId = -1;
                    _offset_Length = -1;
                    _offset_InfoClass = -1;
                    _offset_FileIndex = -1;
                    _offset_FileName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a FlushInfo event.
        /// </summary>
        public readonly ref struct FlushInfoEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "FlushInfo";

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
                Version = 1,
                Channel = 16,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.Flush,
                Keyword = (ulong)Keywords.KERNEL_FILE_KEYWORD_FILEIO
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public FlushInfoData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new FlushInfoEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public FlushInfoEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a FlushInfo event.
            /// </summary>
            public ref struct FlushInfoData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Irp;
                private int _offset_FileObject;
                private int _offset_FileKey;
                private int _offset_IssuingThreadId;

                private int Offset_Irp
                {
                    get
                    {
                        if (_offset_Irp == -1)
                        {
                            _offset_Irp = 0;
                        }

                        return _offset_Irp;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_Irp + _etwEvent.AddressSize;
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

                private int Offset_IssuingThreadId
                {
                    get
                    {
                        if (_offset_IssuingThreadId == -1)
                        {
                            _offset_IssuingThreadId = Offset_FileKey + _etwEvent.AddressSize;
                        }

                        return _offset_IssuingThreadId;
                    }
                }

                /// <summary>
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..]);

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..]);

                /// <summary>
                /// Retrieves the IssuingThreadId field.
                /// </summary>
                public uint IssuingThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_IssuingThreadId..]);

                /// <summary>
                /// Creates a new FlushInfoData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public FlushInfoData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Irp = -1;
                    _offset_FileObject = -1;
                    _offset_FileKey = -1;
                    _offset_IssuingThreadId = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a QueryInformationInfo event.
        /// </summary>
        public readonly ref struct QueryInformationInfoEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "QueryInformationInfo";

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
                Version = 1,
                Channel = 16,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.QueryInformation,
                Keyword = (ulong)Keywords.KERNEL_FILE_KEYWORD_FILEIO
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public QueryInformationInfoData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new QueryInformationInfoEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public QueryInformationInfoEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a QueryInformationInfo event.
            /// </summary>
            public ref struct QueryInformationInfoData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Irp;
                private int _offset_FileObject;
                private int _offset_FileKey;
                private int _offset_ExtraInformation;
                private int _offset_IssuingThreadId;
                private int _offset_InfoClass;

                private int Offset_Irp
                {
                    get
                    {
                        if (_offset_Irp == -1)
                        {
                            _offset_Irp = 0;
                        }

                        return _offset_Irp;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_Irp + _etwEvent.AddressSize;
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

                private int Offset_ExtraInformation
                {
                    get
                    {
                        if (_offset_ExtraInformation == -1)
                        {
                            _offset_ExtraInformation = Offset_FileKey + _etwEvent.AddressSize;
                        }

                        return _offset_ExtraInformation;
                    }
                }

                private int Offset_IssuingThreadId
                {
                    get
                    {
                        if (_offset_IssuingThreadId == -1)
                        {
                            _offset_IssuingThreadId = Offset_ExtraInformation + _etwEvent.AddressSize;
                        }

                        return _offset_IssuingThreadId;
                    }
                }

                private int Offset_InfoClass
                {
                    get
                    {
                        if (_offset_InfoClass == -1)
                        {
                            _offset_InfoClass = Offset_IssuingThreadId + 4;
                        }

                        return _offset_InfoClass;
                    }
                }

                /// <summary>
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..]);

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..]);

                /// <summary>
                /// Retrieves the ExtraInformation field.
                /// </summary>
                public ulong ExtraInformation => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ExtraInformation..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ExtraInformation..]);

                /// <summary>
                /// Retrieves the IssuingThreadId field.
                /// </summary>
                public uint IssuingThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_IssuingThreadId..]);

                /// <summary>
                /// Retrieves the InfoClass field.
                /// </summary>
                public uint InfoClass => BitConverter.ToUInt32(_etwEvent.Data[Offset_InfoClass..]);

                /// <summary>
                /// Creates a new QueryInformationInfoData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public QueryInformationInfoData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Irp = -1;
                    _offset_FileObject = -1;
                    _offset_FileKey = -1;
                    _offset_ExtraInformation = -1;
                    _offset_IssuingThreadId = -1;
                    _offset_InfoClass = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a FSCTLInfo event.
        /// </summary>
        public readonly ref struct FSCTLInfoEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "FSCTLInfo";

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
                Version = 1,
                Channel = 16,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.FSCTL,
                Keyword = (ulong)Keywords.KERNEL_FILE_KEYWORD_FILEIO
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public FSCTLInfoData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new FSCTLInfoEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public FSCTLInfoEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a FSCTLInfo event.
            /// </summary>
            public ref struct FSCTLInfoData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Irp;
                private int _offset_FileObject;
                private int _offset_FileKey;
                private int _offset_ExtraInformation;
                private int _offset_IssuingThreadId;
                private int _offset_InfoClass;

                private int Offset_Irp
                {
                    get
                    {
                        if (_offset_Irp == -1)
                        {
                            _offset_Irp = 0;
                        }

                        return _offset_Irp;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_Irp + _etwEvent.AddressSize;
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

                private int Offset_ExtraInformation
                {
                    get
                    {
                        if (_offset_ExtraInformation == -1)
                        {
                            _offset_ExtraInformation = Offset_FileKey + _etwEvent.AddressSize;
                        }

                        return _offset_ExtraInformation;
                    }
                }

                private int Offset_IssuingThreadId
                {
                    get
                    {
                        if (_offset_IssuingThreadId == -1)
                        {
                            _offset_IssuingThreadId = Offset_ExtraInformation + _etwEvent.AddressSize;
                        }

                        return _offset_IssuingThreadId;
                    }
                }

                private int Offset_InfoClass
                {
                    get
                    {
                        if (_offset_InfoClass == -1)
                        {
                            _offset_InfoClass = Offset_IssuingThreadId + 4;
                        }

                        return _offset_InfoClass;
                    }
                }

                /// <summary>
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..]);

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..]);

                /// <summary>
                /// Retrieves the ExtraInformation field.
                /// </summary>
                public ulong ExtraInformation => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ExtraInformation..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ExtraInformation..]);

                /// <summary>
                /// Retrieves the IssuingThreadId field.
                /// </summary>
                public uint IssuingThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_IssuingThreadId..]);

                /// <summary>
                /// Retrieves the InfoClass field.
                /// </summary>
                public uint InfoClass => BitConverter.ToUInt32(_etwEvent.Data[Offset_InfoClass..]);

                /// <summary>
                /// Creates a new FSCTLInfoData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public FSCTLInfoData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Irp = -1;
                    _offset_FileObject = -1;
                    _offset_FileKey = -1;
                    _offset_ExtraInformation = -1;
                    _offset_IssuingThreadId = -1;
                    _offset_InfoClass = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DirNotifyInfo event.
        /// </summary>
        public readonly ref struct DirNotifyInfoEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DirNotifyInfo";

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
                Version = 1,
                Channel = 16,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.DirNotify,
                Keyword = (ulong)Keywords.KERNEL_FILE_KEYWORD_FILEIO
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public DirNotifyInfoData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DirNotifyInfoEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DirNotifyInfoEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a DirNotifyInfo event.
            /// </summary>
            public ref struct DirNotifyInfoData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Irp;
                private int _offset_FileObject;
                private int _offset_FileKey;
                private int _offset_IssuingThreadId;
                private int _offset_Length;
                private int _offset_InfoClass;
                private int _offset_FileIndex;
                private int _offset_FileName;

                private int Offset_Irp
                {
                    get
                    {
                        if (_offset_Irp == -1)
                        {
                            _offset_Irp = 0;
                        }

                        return _offset_Irp;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_Irp + _etwEvent.AddressSize;
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

                private int Offset_IssuingThreadId
                {
                    get
                    {
                        if (_offset_IssuingThreadId == -1)
                        {
                            _offset_IssuingThreadId = Offset_FileKey + _etwEvent.AddressSize;
                        }

                        return _offset_IssuingThreadId;
                    }
                }

                private int Offset_Length
                {
                    get
                    {
                        if (_offset_Length == -1)
                        {
                            _offset_Length = Offset_IssuingThreadId + 4;
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
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..]);

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..]);

                /// <summary>
                /// Retrieves the IssuingThreadId field.
                /// </summary>
                public uint IssuingThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_IssuingThreadId..]);

                /// <summary>
                /// Retrieves the Length field.
                /// </summary>
                public uint Length => BitConverter.ToUInt32(_etwEvent.Data[Offset_Length..]);

                /// <summary>
                /// Retrieves the InfoClass field.
                /// </summary>
                public uint InfoClass => BitConverter.ToUInt32(_etwEvent.Data[Offset_InfoClass..]);

                /// <summary>
                /// Retrieves the FileIndex field.
                /// </summary>
                public uint FileIndex => BitConverter.ToUInt32(_etwEvent.Data[Offset_FileIndex..]);

                /// <summary>
                /// Retrieves the FileName field.
                /// </summary>
                public string FileName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FileName..]);

                /// <summary>
                /// Creates a new DirNotifyInfoData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DirNotifyInfoData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Irp = -1;
                    _offset_FileObject = -1;
                    _offset_FileKey = -1;
                    _offset_IssuingThreadId = -1;
                    _offset_Length = -1;
                    _offset_InfoClass = -1;
                    _offset_FileIndex = -1;
                    _offset_FileName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DeletePathInfo event.
        /// </summary>
        public readonly ref struct DeletePathInfoEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DeletePathInfo";

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
                Version = 1,
                Channel = 16,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.DeletePath,
                Keyword = (ulong)Keywords.KERNEL_FILE_KEYWORD_DELETE_PATH
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public DeletePathInfoData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DeletePathInfoEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DeletePathInfoEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a DeletePathInfo event.
            /// </summary>
            public ref struct DeletePathInfoData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Irp;
                private int _offset_FileObject;
                private int _offset_FileKey;
                private int _offset_ExtraInformation;
                private int _offset_IssuingThreadId;
                private int _offset_InfoClass;
                private int _offset_FilePath;

                private int Offset_Irp
                {
                    get
                    {
                        if (_offset_Irp == -1)
                        {
                            _offset_Irp = 0;
                        }

                        return _offset_Irp;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_Irp + _etwEvent.AddressSize;
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

                private int Offset_ExtraInformation
                {
                    get
                    {
                        if (_offset_ExtraInformation == -1)
                        {
                            _offset_ExtraInformation = Offset_FileKey + _etwEvent.AddressSize;
                        }

                        return _offset_ExtraInformation;
                    }
                }

                private int Offset_IssuingThreadId
                {
                    get
                    {
                        if (_offset_IssuingThreadId == -1)
                        {
                            _offset_IssuingThreadId = Offset_ExtraInformation + _etwEvent.AddressSize;
                        }

                        return _offset_IssuingThreadId;
                    }
                }

                private int Offset_InfoClass
                {
                    get
                    {
                        if (_offset_InfoClass == -1)
                        {
                            _offset_InfoClass = Offset_IssuingThreadId + 4;
                        }

                        return _offset_InfoClass;
                    }
                }

                private int Offset_FilePath
                {
                    get
                    {
                        if (_offset_FilePath == -1)
                        {
                            _offset_FilePath = Offset_InfoClass + 4;
                        }

                        return _offset_FilePath;
                    }
                }

                /// <summary>
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..]);

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..]);

                /// <summary>
                /// Retrieves the ExtraInformation field.
                /// </summary>
                public ulong ExtraInformation => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ExtraInformation..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ExtraInformation..]);

                /// <summary>
                /// Retrieves the IssuingThreadId field.
                /// </summary>
                public uint IssuingThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_IssuingThreadId..]);

                /// <summary>
                /// Retrieves the InfoClass field.
                /// </summary>
                public uint InfoClass => BitConverter.ToUInt32(_etwEvent.Data[Offset_InfoClass..]);

                /// <summary>
                /// Retrieves the FilePath field.
                /// </summary>
                public string FilePath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FilePath..]);

                /// <summary>
                /// Creates a new DeletePathInfoData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DeletePathInfoData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Irp = -1;
                    _offset_FileObject = -1;
                    _offset_FileKey = -1;
                    _offset_ExtraInformation = -1;
                    _offset_IssuingThreadId = -1;
                    _offset_InfoClass = -1;
                    _offset_FilePath = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a RenamePathInfo event.
        /// </summary>
        public readonly ref struct RenamePathInfoEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "RenamePathInfo";

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
                Version = 1,
                Channel = 16,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.RenamePath,
                Keyword = (ulong)Keywords.KERNEL_FILE_KEYWORD_RENAME_SETLINK_PATH
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public RenamePathInfoData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new RenamePathInfoEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public RenamePathInfoEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a RenamePathInfo event.
            /// </summary>
            public ref struct RenamePathInfoData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Irp;
                private int _offset_FileObject;
                private int _offset_FileKey;
                private int _offset_ExtraInformation;
                private int _offset_IssuingThreadId;
                private int _offset_InfoClass;
                private int _offset_FilePath;

                private int Offset_Irp
                {
                    get
                    {
                        if (_offset_Irp == -1)
                        {
                            _offset_Irp = 0;
                        }

                        return _offset_Irp;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_Irp + _etwEvent.AddressSize;
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

                private int Offset_ExtraInformation
                {
                    get
                    {
                        if (_offset_ExtraInformation == -1)
                        {
                            _offset_ExtraInformation = Offset_FileKey + _etwEvent.AddressSize;
                        }

                        return _offset_ExtraInformation;
                    }
                }

                private int Offset_IssuingThreadId
                {
                    get
                    {
                        if (_offset_IssuingThreadId == -1)
                        {
                            _offset_IssuingThreadId = Offset_ExtraInformation + _etwEvent.AddressSize;
                        }

                        return _offset_IssuingThreadId;
                    }
                }

                private int Offset_InfoClass
                {
                    get
                    {
                        if (_offset_InfoClass == -1)
                        {
                            _offset_InfoClass = Offset_IssuingThreadId + 4;
                        }

                        return _offset_InfoClass;
                    }
                }

                private int Offset_FilePath
                {
                    get
                    {
                        if (_offset_FilePath == -1)
                        {
                            _offset_FilePath = Offset_InfoClass + 4;
                        }

                        return _offset_FilePath;
                    }
                }

                /// <summary>
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..]);

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..]);

                /// <summary>
                /// Retrieves the ExtraInformation field.
                /// </summary>
                public ulong ExtraInformation => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ExtraInformation..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ExtraInformation..]);

                /// <summary>
                /// Retrieves the IssuingThreadId field.
                /// </summary>
                public uint IssuingThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_IssuingThreadId..]);

                /// <summary>
                /// Retrieves the InfoClass field.
                /// </summary>
                public uint InfoClass => BitConverter.ToUInt32(_etwEvent.Data[Offset_InfoClass..]);

                /// <summary>
                /// Retrieves the FilePath field.
                /// </summary>
                public string FilePath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FilePath..]);

                /// <summary>
                /// Creates a new RenamePathInfoData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public RenamePathInfoData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Irp = -1;
                    _offset_FileObject = -1;
                    _offset_FileKey = -1;
                    _offset_ExtraInformation = -1;
                    _offset_IssuingThreadId = -1;
                    _offset_InfoClass = -1;
                    _offset_FilePath = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a SetLinkPathInfo event.
        /// </summary>
        public readonly ref struct SetLinkPathInfoEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SetLinkPathInfo";

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
                Version = 1,
                Channel = 16,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.SetLinkPath,
                Keyword = (ulong)Keywords.KERNEL_FILE_KEYWORD_RENAME_SETLINK_PATH
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public SetLinkPathInfoData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new SetLinkPathInfoEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SetLinkPathInfoEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a SetLinkPathInfo event.
            /// </summary>
            public ref struct SetLinkPathInfoData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Irp;
                private int _offset_FileObject;
                private int _offset_FileKey;
                private int _offset_ExtraInformation;
                private int _offset_IssuingThreadId;
                private int _offset_InfoClass;
                private int _offset_FilePath;

                private int Offset_Irp
                {
                    get
                    {
                        if (_offset_Irp == -1)
                        {
                            _offset_Irp = 0;
                        }

                        return _offset_Irp;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_Irp + _etwEvent.AddressSize;
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

                private int Offset_ExtraInformation
                {
                    get
                    {
                        if (_offset_ExtraInformation == -1)
                        {
                            _offset_ExtraInformation = Offset_FileKey + _etwEvent.AddressSize;
                        }

                        return _offset_ExtraInformation;
                    }
                }

                private int Offset_IssuingThreadId
                {
                    get
                    {
                        if (_offset_IssuingThreadId == -1)
                        {
                            _offset_IssuingThreadId = Offset_ExtraInformation + _etwEvent.AddressSize;
                        }

                        return _offset_IssuingThreadId;
                    }
                }

                private int Offset_InfoClass
                {
                    get
                    {
                        if (_offset_InfoClass == -1)
                        {
                            _offset_InfoClass = Offset_IssuingThreadId + 4;
                        }

                        return _offset_InfoClass;
                    }
                }

                private int Offset_FilePath
                {
                    get
                    {
                        if (_offset_FilePath == -1)
                        {
                            _offset_FilePath = Offset_InfoClass + 4;
                        }

                        return _offset_FilePath;
                    }
                }

                /// <summary>
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..]);

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..]);

                /// <summary>
                /// Retrieves the ExtraInformation field.
                /// </summary>
                public ulong ExtraInformation => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ExtraInformation..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ExtraInformation..]);

                /// <summary>
                /// Retrieves the IssuingThreadId field.
                /// </summary>
                public uint IssuingThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_IssuingThreadId..]);

                /// <summary>
                /// Retrieves the InfoClass field.
                /// </summary>
                public uint InfoClass => BitConverter.ToUInt32(_etwEvent.Data[Offset_InfoClass..]);

                /// <summary>
                /// Retrieves the FilePath field.
                /// </summary>
                public string FilePath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FilePath..]);

                /// <summary>
                /// Creates a new SetLinkPathInfoData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public SetLinkPathInfoData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Irp = -1;
                    _offset_FileObject = -1;
                    _offset_FileKey = -1;
                    _offset_ExtraInformation = -1;
                    _offset_IssuingThreadId = -1;
                    _offset_InfoClass = -1;
                    _offset_FilePath = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a SetLinkInfo event.
        /// </summary>
        public readonly ref struct SetLinkInfoEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SetLinkInfo";

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
                Version = 1,
                Channel = 16,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.Rename,
                Keyword = (ulong)Keywords.KERNEL_FILE_KEYWORD_FILEIO
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public SetLinkInfoData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new SetLinkInfoEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SetLinkInfoEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a SetLinkInfo event.
            /// </summary>
            public ref struct SetLinkInfoData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Irp;
                private int _offset_FileObject;
                private int _offset_FileKey;
                private int _offset_ExtraInformation;
                private int _offset_IssuingThreadId;
                private int _offset_InfoClass;

                private int Offset_Irp
                {
                    get
                    {
                        if (_offset_Irp == -1)
                        {
                            _offset_Irp = 0;
                        }

                        return _offset_Irp;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_Irp + _etwEvent.AddressSize;
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

                private int Offset_ExtraInformation
                {
                    get
                    {
                        if (_offset_ExtraInformation == -1)
                        {
                            _offset_ExtraInformation = Offset_FileKey + _etwEvent.AddressSize;
                        }

                        return _offset_ExtraInformation;
                    }
                }

                private int Offset_IssuingThreadId
                {
                    get
                    {
                        if (_offset_IssuingThreadId == -1)
                        {
                            _offset_IssuingThreadId = Offset_ExtraInformation + _etwEvent.AddressSize;
                        }

                        return _offset_IssuingThreadId;
                    }
                }

                private int Offset_InfoClass
                {
                    get
                    {
                        if (_offset_InfoClass == -1)
                        {
                            _offset_InfoClass = Offset_IssuingThreadId + 4;
                        }

                        return _offset_InfoClass;
                    }
                }

                /// <summary>
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..]);

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..]);

                /// <summary>
                /// Retrieves the ExtraInformation field.
                /// </summary>
                public ulong ExtraInformation => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ExtraInformation..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ExtraInformation..]);

                /// <summary>
                /// Retrieves the IssuingThreadId field.
                /// </summary>
                public uint IssuingThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_IssuingThreadId..]);

                /// <summary>
                /// Retrieves the InfoClass field.
                /// </summary>
                public uint InfoClass => BitConverter.ToUInt32(_etwEvent.Data[Offset_InfoClass..]);

                /// <summary>
                /// Creates a new SetLinkInfoData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public SetLinkInfoData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Irp = -1;
                    _offset_FileObject = -1;
                    _offset_FileKey = -1;
                    _offset_ExtraInformation = -1;
                    _offset_IssuingThreadId = -1;
                    _offset_InfoClass = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a CreateNewFileInfo event.
        /// </summary>
        public readonly ref struct CreateNewFileInfoEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "CreateNewFileInfo";

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
                Version = 1,
                Channel = 16,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.CreateNewFile,
                Keyword = (ulong)Keywords.KERNEL_FILE_KEYWORD_CREATE_NEW_FILE
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public CreateNewFileInfoData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new CreateNewFileInfoEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public CreateNewFileInfoEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a CreateNewFileInfo event.
            /// </summary>
            public ref struct CreateNewFileInfoData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Irp;
                private int _offset_FileObject;
                private int _offset_IssuingThreadId;
                private int _offset_CreateOptions;
                private int _offset_CreateAttributes;
                private int _offset_ShareAccess;
                private int _offset_FileName;

                private int Offset_Irp
                {
                    get
                    {
                        if (_offset_Irp == -1)
                        {
                            _offset_Irp = 0;
                        }

                        return _offset_Irp;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_Irp + _etwEvent.AddressSize;
                        }

                        return _offset_FileObject;
                    }
                }

                private int Offset_IssuingThreadId
                {
                    get
                    {
                        if (_offset_IssuingThreadId == -1)
                        {
                            _offset_IssuingThreadId = Offset_FileObject + _etwEvent.AddressSize;
                        }

                        return _offset_IssuingThreadId;
                    }
                }

                private int Offset_CreateOptions
                {
                    get
                    {
                        if (_offset_CreateOptions == -1)
                        {
                            _offset_CreateOptions = Offset_IssuingThreadId + 4;
                        }

                        return _offset_CreateOptions;
                    }
                }

                private int Offset_CreateAttributes
                {
                    get
                    {
                        if (_offset_CreateAttributes == -1)
                        {
                            _offset_CreateAttributes = Offset_CreateOptions + 4;
                        }

                        return _offset_CreateAttributes;
                    }
                }

                private int Offset_ShareAccess
                {
                    get
                    {
                        if (_offset_ShareAccess == -1)
                        {
                            _offset_ShareAccess = Offset_CreateAttributes + 4;
                        }

                        return _offset_ShareAccess;
                    }
                }

                private int Offset_FileName
                {
                    get
                    {
                        if (_offset_FileName == -1)
                        {
                            _offset_FileName = Offset_ShareAccess + 4;
                        }

                        return _offset_FileName;
                    }
                }

                /// <summary>
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..]);

                /// <summary>
                /// Retrieves the IssuingThreadId field.
                /// </summary>
                public uint IssuingThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_IssuingThreadId..]);

                /// <summary>
                /// Retrieves the CreateOptions field.
                /// </summary>
                public uint CreateOptions => BitConverter.ToUInt32(_etwEvent.Data[Offset_CreateOptions..]);

                /// <summary>
                /// Retrieves the CreateAttributes field.
                /// </summary>
                public uint CreateAttributes => BitConverter.ToUInt32(_etwEvent.Data[Offset_CreateAttributes..]);

                /// <summary>
                /// Retrieves the ShareAccess field.
                /// </summary>
                public uint ShareAccess => BitConverter.ToUInt32(_etwEvent.Data[Offset_ShareAccess..]);

                /// <summary>
                /// Retrieves the FileName field.
                /// </summary>
                public string FileName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FileName..]);

                /// <summary>
                /// Creates a new CreateNewFileInfoData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public CreateNewFileInfoData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Irp = -1;
                    _offset_FileObject = -1;
                    _offset_IssuingThreadId = -1;
                    _offset_CreateOptions = -1;
                    _offset_CreateAttributes = -1;
                    _offset_ShareAccess = -1;
                    _offset_FileName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a SetSecurityInfo event.
        /// </summary>
        public readonly ref struct SetSecurityInfoEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SetSecurityInfo";

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
                Version = 1,
                Channel = 16,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.SetSecurity,
                Keyword = (ulong)Keywords.KERNEL_FILE_KEYWORD_FILEIO
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public SetSecurityInfoData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new SetSecurityInfoEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SetSecurityInfoEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a SetSecurityInfo event.
            /// </summary>
            public ref struct SetSecurityInfoData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Irp;
                private int _offset_FileObject;
                private int _offset_FileKey;
                private int _offset_ExtraInformation;
                private int _offset_IssuingThreadId;
                private int _offset_InfoClass;

                private int Offset_Irp
                {
                    get
                    {
                        if (_offset_Irp == -1)
                        {
                            _offset_Irp = 0;
                        }

                        return _offset_Irp;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_Irp + _etwEvent.AddressSize;
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

                private int Offset_ExtraInformation
                {
                    get
                    {
                        if (_offset_ExtraInformation == -1)
                        {
                            _offset_ExtraInformation = Offset_FileKey + _etwEvent.AddressSize;
                        }

                        return _offset_ExtraInformation;
                    }
                }

                private int Offset_IssuingThreadId
                {
                    get
                    {
                        if (_offset_IssuingThreadId == -1)
                        {
                            _offset_IssuingThreadId = Offset_ExtraInformation + _etwEvent.AddressSize;
                        }

                        return _offset_IssuingThreadId;
                    }
                }

                private int Offset_InfoClass
                {
                    get
                    {
                        if (_offset_InfoClass == -1)
                        {
                            _offset_InfoClass = Offset_IssuingThreadId + 4;
                        }

                        return _offset_InfoClass;
                    }
                }

                /// <summary>
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..]);

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..]);

                /// <summary>
                /// Retrieves the ExtraInformation field.
                /// </summary>
                public ulong ExtraInformation => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ExtraInformation..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ExtraInformation..]);

                /// <summary>
                /// Retrieves the IssuingThreadId field.
                /// </summary>
                public uint IssuingThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_IssuingThreadId..]);

                /// <summary>
                /// Retrieves the InfoClass field.
                /// </summary>
                public uint InfoClass => BitConverter.ToUInt32(_etwEvent.Data[Offset_InfoClass..]);

                /// <summary>
                /// Creates a new SetSecurityInfoData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public SetSecurityInfoData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Irp = -1;
                    _offset_FileObject = -1;
                    _offset_FileKey = -1;
                    _offset_ExtraInformation = -1;
                    _offset_IssuingThreadId = -1;
                    _offset_InfoClass = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a QuerySecurityInfo event.
        /// </summary>
        public readonly ref struct QuerySecurityInfoEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "QuerySecurityInfo";

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
                Version = 1,
                Channel = 16,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.QuerySecurity,
                Keyword = (ulong)Keywords.KERNEL_FILE_KEYWORD_FILEIO
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public QuerySecurityInfoData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new QuerySecurityInfoEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public QuerySecurityInfoEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a QuerySecurityInfo event.
            /// </summary>
            public ref struct QuerySecurityInfoData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Irp;
                private int _offset_FileObject;
                private int _offset_FileKey;
                private int _offset_ExtraInformation;
                private int _offset_IssuingThreadId;
                private int _offset_InfoClass;

                private int Offset_Irp
                {
                    get
                    {
                        if (_offset_Irp == -1)
                        {
                            _offset_Irp = 0;
                        }

                        return _offset_Irp;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_Irp + _etwEvent.AddressSize;
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

                private int Offset_ExtraInformation
                {
                    get
                    {
                        if (_offset_ExtraInformation == -1)
                        {
                            _offset_ExtraInformation = Offset_FileKey + _etwEvent.AddressSize;
                        }

                        return _offset_ExtraInformation;
                    }
                }

                private int Offset_IssuingThreadId
                {
                    get
                    {
                        if (_offset_IssuingThreadId == -1)
                        {
                            _offset_IssuingThreadId = Offset_ExtraInformation + _etwEvent.AddressSize;
                        }

                        return _offset_IssuingThreadId;
                    }
                }

                private int Offset_InfoClass
                {
                    get
                    {
                        if (_offset_InfoClass == -1)
                        {
                            _offset_InfoClass = Offset_IssuingThreadId + 4;
                        }

                        return _offset_InfoClass;
                    }
                }

                /// <summary>
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..]);

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..]);

                /// <summary>
                /// Retrieves the ExtraInformation field.
                /// </summary>
                public ulong ExtraInformation => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ExtraInformation..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ExtraInformation..]);

                /// <summary>
                /// Retrieves the IssuingThreadId field.
                /// </summary>
                public uint IssuingThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_IssuingThreadId..]);

                /// <summary>
                /// Retrieves the InfoClass field.
                /// </summary>
                public uint InfoClass => BitConverter.ToUInt32(_etwEvent.Data[Offset_InfoClass..]);

                /// <summary>
                /// Creates a new QuerySecurityInfoData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public QuerySecurityInfoData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Irp = -1;
                    _offset_FileObject = -1;
                    _offset_FileKey = -1;
                    _offset_ExtraInformation = -1;
                    _offset_IssuingThreadId = -1;
                    _offset_InfoClass = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a SetEAInfo event.
        /// </summary>
        public readonly ref struct SetEAInfoEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SetEAInfo";

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
                Version = 1,
                Channel = 16,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.SetEA,
                Keyword = (ulong)Keywords.KERNEL_FILE_KEYWORD_FILEIO
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public SetEAInfoData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new SetEAInfoEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SetEAInfoEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a SetEAInfo event.
            /// </summary>
            public ref struct SetEAInfoData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Irp;
                private int _offset_FileObject;
                private int _offset_FileKey;
                private int _offset_ExtraInformation;
                private int _offset_IssuingThreadId;
                private int _offset_InfoClass;

                private int Offset_Irp
                {
                    get
                    {
                        if (_offset_Irp == -1)
                        {
                            _offset_Irp = 0;
                        }

                        return _offset_Irp;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_Irp + _etwEvent.AddressSize;
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

                private int Offset_ExtraInformation
                {
                    get
                    {
                        if (_offset_ExtraInformation == -1)
                        {
                            _offset_ExtraInformation = Offset_FileKey + _etwEvent.AddressSize;
                        }

                        return _offset_ExtraInformation;
                    }
                }

                private int Offset_IssuingThreadId
                {
                    get
                    {
                        if (_offset_IssuingThreadId == -1)
                        {
                            _offset_IssuingThreadId = Offset_ExtraInformation + _etwEvent.AddressSize;
                        }

                        return _offset_IssuingThreadId;
                    }
                }

                private int Offset_InfoClass
                {
                    get
                    {
                        if (_offset_InfoClass == -1)
                        {
                            _offset_InfoClass = Offset_IssuingThreadId + 4;
                        }

                        return _offset_InfoClass;
                    }
                }

                /// <summary>
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..]);

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..]);

                /// <summary>
                /// Retrieves the ExtraInformation field.
                /// </summary>
                public ulong ExtraInformation => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ExtraInformation..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ExtraInformation..]);

                /// <summary>
                /// Retrieves the IssuingThreadId field.
                /// </summary>
                public uint IssuingThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_IssuingThreadId..]);

                /// <summary>
                /// Retrieves the InfoClass field.
                /// </summary>
                public uint InfoClass => BitConverter.ToUInt32(_etwEvent.Data[Offset_InfoClass..]);

                /// <summary>
                /// Creates a new SetEAInfoData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public SetEAInfoData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Irp = -1;
                    _offset_FileObject = -1;
                    _offset_FileKey = -1;
                    _offset_ExtraInformation = -1;
                    _offset_IssuingThreadId = -1;
                    _offset_InfoClass = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a QueryEAInfo event.
        /// </summary>
        public readonly ref struct QueryEAInfoEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "QueryEAInfo";

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
                Version = 1,
                Channel = 16,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventOpcode.Info,
                Task = (ushort)Tasks.QueryEA,
                Keyword = (ulong)Keywords.KERNEL_FILE_KEYWORD_FILEIO
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public QueryEAInfoData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new QueryEAInfoEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public QueryEAInfoEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a QueryEAInfo event.
            /// </summary>
            public ref struct QueryEAInfoData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Irp;
                private int _offset_FileObject;
                private int _offset_FileKey;
                private int _offset_ExtraInformation;
                private int _offset_IssuingThreadId;
                private int _offset_InfoClass;

                private int Offset_Irp
                {
                    get
                    {
                        if (_offset_Irp == -1)
                        {
                            _offset_Irp = 0;
                        }

                        return _offset_Irp;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_Irp + _etwEvent.AddressSize;
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

                private int Offset_ExtraInformation
                {
                    get
                    {
                        if (_offset_ExtraInformation == -1)
                        {
                            _offset_ExtraInformation = Offset_FileKey + _etwEvent.AddressSize;
                        }

                        return _offset_ExtraInformation;
                    }
                }

                private int Offset_IssuingThreadId
                {
                    get
                    {
                        if (_offset_IssuingThreadId == -1)
                        {
                            _offset_IssuingThreadId = Offset_ExtraInformation + _etwEvent.AddressSize;
                        }

                        return _offset_IssuingThreadId;
                    }
                }

                private int Offset_InfoClass
                {
                    get
                    {
                        if (_offset_InfoClass == -1)
                        {
                            _offset_InfoClass = Offset_IssuingThreadId + 4;
                        }

                        return _offset_InfoClass;
                    }
                }

                /// <summary>
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..]);

                /// <summary>
                /// Retrieves the FileKey field.
                /// </summary>
                public ulong FileKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileKey..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileKey..]);

                /// <summary>
                /// Retrieves the ExtraInformation field.
                /// </summary>
                public ulong ExtraInformation => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ExtraInformation..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ExtraInformation..]);

                /// <summary>
                /// Retrieves the IssuingThreadId field.
                /// </summary>
                public uint IssuingThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_IssuingThreadId..]);

                /// <summary>
                /// Retrieves the InfoClass field.
                /// </summary>
                public uint InfoClass => BitConverter.ToUInt32(_etwEvent.Data[Offset_InfoClass..]);

                /// <summary>
                /// Creates a new QueryEAInfoData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public QueryEAInfoData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Irp = -1;
                    _offset_FileObject = -1;
                    _offset_FileKey = -1;
                    _offset_ExtraInformation = -1;
                    _offset_IssuingThreadId = -1;
                    _offset_InfoClass = -1;
                }
            }

        }
    }
}
