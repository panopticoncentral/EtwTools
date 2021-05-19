using System;

#pragma warning disable IDE0004 // Remove Unnecessary Cast
#pragma warning disable CA1707 // Identifiers should not contain underscores
#pragma warning disable CA1720 // Identifier contains type name

namespace EtwTools
{
    /// <summary>
    /// Provider for Kernel-DiskIo (3d6fa8d4-fe05-11d0-9dda-00c04fd7ba7c)
    /// </summary>
    public sealed class KernelDiskIoProvider
    {
        /// <summary>s
        /// Provider ID.
        /// </summary>
        public static readonly Guid Id = new("3d6fa8d4-fe05-11d0-9dda-00c04fd7ba7c");

        /// <summary>
        /// Provider name.
        /// </summary>
        public const string Name = "Kernel-DiskIo";

        /// <summary>
        /// Opcodes supported by KernelDiskIo.
        /// </summary>
        public enum Opcodes
        {
            /// <summary>
            /// 'Read' opcode.
            /// </summary>
            Read = 10,
            /// <summary>
            /// 'Write' opcode.
            /// </summary>
            Write = 11,
            /// <summary>
            /// 'ReadInit' opcode.
            /// </summary>
            ReadInit = 12,
            /// <summary>
            /// 'WriteInit' opcode.
            /// </summary>
            WriteInit = 13,
            /// <summary>
            /// 'FlushBuffers' opcode.
            /// </summary>
            FlushBuffers = 14,
            /// <summary>
            /// 'FlushInit' opcode.
            /// </summary>
            FlushInit = 15,
            /// <summary>
            /// 'DrvMjFnCall' opcode.
            /// </summary>
            DrvMjFnCall = 34,
            /// <summary>
            /// 'DrvMjFnRet' opcode.
            /// </summary>
            DrvMjFnRet = 35,
            /// <summary>
            /// 'DrvComplRout' opcode.
            /// </summary>
            DrvComplRout = 37,
            /// <summary>
            /// 'DrvComplReq' opcode.
            /// </summary>
            DrvComplReq = 52,
            /// <summary>
            /// 'DrvComplReqRet' opcode.
            /// </summary>
            DrvComplReqRet = 53,
            /// <summary>
            /// 'OpticalRead' opcode.
            /// </summary>
            OpticalRead = 55,
            /// <summary>
            /// 'OpticalWrite' opcode.
            /// </summary>
            OpticalWrite = 56,
            /// <summary>
            /// 'OpticalFlushBuffers' opcode.
            /// </summary>
            OpticalFlushBuffers = 57,
            /// <summary>
            /// 'OpticalReadInit' opcode.
            /// </summary>
            OpticalReadInit = 58,
            /// <summary>
            /// 'OpticalWriteInit' opcode.
            /// </summary>
            OpticalWriteInit = 59,
            /// <summary>
            /// 'OpticalFlushInit' opcode.
            /// </summary>
            OpticalFlushInit = 60,
        }

        /// <summary>
        /// An event wrapper for a Read event.
        /// </summary>
        public readonly ref struct ReadEvent
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
                Version = 0,
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
            /// Creates a new ReadEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ReadEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a Read event.
            /// </summary>
            public ref struct ReadData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_DiskNumber;
                private int _offset_IrpFlags;
                private int _offset_TransferSize;
                private int _offset_Reserved;
                private int _offset_ByteOffset;
                private int _offset_FileObject;

                private int Offset_DiskNumber
                {
                    get
                    {
                        if (_offset_DiskNumber == -1)
                        {
                            _offset_DiskNumber = 0;
                        }

                        return _offset_DiskNumber;
                    }
                }

                private int Offset_IrpFlags
                {
                    get
                    {
                        if (_offset_IrpFlags == -1)
                        {
                            _offset_IrpFlags = Offset_DiskNumber + 4;
                        }

                        return _offset_IrpFlags;
                    }
                }

                private int Offset_TransferSize
                {
                    get
                    {
                        if (_offset_TransferSize == -1)
                        {
                            _offset_TransferSize = Offset_IrpFlags + 4;
                        }

                        return _offset_TransferSize;
                    }
                }

                private int Offset_Reserved
                {
                    get
                    {
                        if (_offset_Reserved == -1)
                        {
                            _offset_Reserved = Offset_TransferSize + 4;
                        }

                        return _offset_Reserved;
                    }
                }

                private int Offset_ByteOffset
                {
                    get
                    {
                        if (_offset_ByteOffset == -1)
                        {
                            _offset_ByteOffset = Offset_Reserved + 4;
                        }

                        return _offset_ByteOffset;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_ByteOffset + 8;
                        }

                        return _offset_FileObject;
                    }
                }

                /// <summary>
                /// Retrieves the DiskNumber field.
                /// </summary>
                public uint DiskNumber => BitConverter.ToUInt32(_etwEvent.Data[Offset_DiskNumber..]);

                /// <summary>
                /// Retrieves the IrpFlags field.
                /// </summary>
                public uint IrpFlags => BitConverter.ToUInt32(_etwEvent.Data[Offset_IrpFlags..]);

                /// <summary>
                /// Retrieves the TransferSize field.
                /// </summary>
                public uint TransferSize => BitConverter.ToUInt32(_etwEvent.Data[Offset_TransferSize..]);

                /// <summary>
                /// Retrieves the Reserved field.
                /// </summary>
                public uint Reserved => BitConverter.ToUInt32(_etwEvent.Data[Offset_Reserved..]);

                /// <summary>
                /// Retrieves the ByteOffset field.
                /// </summary>
                public ulong ByteOffset => BitConverter.ToUInt64(_etwEvent.Data[Offset_ByteOffset..]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..]);

                /// <summary>
                /// Creates a new ReadData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ReadData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_DiskNumber = -1;
                    _offset_IrpFlags = -1;
                    _offset_TransferSize = -1;
                    _offset_Reserved = -1;
                    _offset_ByteOffset = -1;
                    _offset_FileObject = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Write event.
        /// </summary>
        public readonly ref struct WriteEvent
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
                Version = 0,
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
            /// Creates a new WriteEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public WriteEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a Write event.
            /// </summary>
            public ref struct WriteData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_DiskNumber;
                private int _offset_IrpFlags;
                private int _offset_TransferSize;
                private int _offset_Reserved;
                private int _offset_ByteOffset;
                private int _offset_FileObject;

                private int Offset_DiskNumber
                {
                    get
                    {
                        if (_offset_DiskNumber == -1)
                        {
                            _offset_DiskNumber = 0;
                        }

                        return _offset_DiskNumber;
                    }
                }

                private int Offset_IrpFlags
                {
                    get
                    {
                        if (_offset_IrpFlags == -1)
                        {
                            _offset_IrpFlags = Offset_DiskNumber + 4;
                        }

                        return _offset_IrpFlags;
                    }
                }

                private int Offset_TransferSize
                {
                    get
                    {
                        if (_offset_TransferSize == -1)
                        {
                            _offset_TransferSize = Offset_IrpFlags + 4;
                        }

                        return _offset_TransferSize;
                    }
                }

                private int Offset_Reserved
                {
                    get
                    {
                        if (_offset_Reserved == -1)
                        {
                            _offset_Reserved = Offset_TransferSize + 4;
                        }

                        return _offset_Reserved;
                    }
                }

                private int Offset_ByteOffset
                {
                    get
                    {
                        if (_offset_ByteOffset == -1)
                        {
                            _offset_ByteOffset = Offset_Reserved + 4;
                        }

                        return _offset_ByteOffset;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_ByteOffset + 8;
                        }

                        return _offset_FileObject;
                    }
                }

                /// <summary>
                /// Retrieves the DiskNumber field.
                /// </summary>
                public uint DiskNumber => BitConverter.ToUInt32(_etwEvent.Data[Offset_DiskNumber..]);

                /// <summary>
                /// Retrieves the IrpFlags field.
                /// </summary>
                public uint IrpFlags => BitConverter.ToUInt32(_etwEvent.Data[Offset_IrpFlags..]);

                /// <summary>
                /// Retrieves the TransferSize field.
                /// </summary>
                public uint TransferSize => BitConverter.ToUInt32(_etwEvent.Data[Offset_TransferSize..]);

                /// <summary>
                /// Retrieves the Reserved field.
                /// </summary>
                public uint Reserved => BitConverter.ToUInt32(_etwEvent.Data[Offset_Reserved..]);

                /// <summary>
                /// Retrieves the ByteOffset field.
                /// </summary>
                public ulong ByteOffset => BitConverter.ToUInt64(_etwEvent.Data[Offset_ByteOffset..]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..]);

                /// <summary>
                /// Creates a new WriteData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public WriteData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_DiskNumber = -1;
                    _offset_IrpFlags = -1;
                    _offset_TransferSize = -1;
                    _offset_Reserved = -1;
                    _offset_ByteOffset = -1;
                    _offset_FileObject = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DrvMjFnRet event.
        /// </summary>
        public readonly ref struct DrvMjFnRetEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DrvMjFnRet";

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
                Opcode = (EtwEventOpcode)Opcodes.DrvMjFnRet,
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
            public DrvMjFnRetData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DrvMjFnRetEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DrvMjFnRetEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a DrvMjFnRet event.
            /// </summary>
            public ref struct DrvMjFnRetData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_UniqMatchId;
                private int _offset_Irp;

                private int Offset_UniqMatchId
                {
                    get
                    {
                        if (_offset_UniqMatchId == -1)
                        {
                            _offset_UniqMatchId = 0;
                        }

                        return _offset_UniqMatchId;
                    }
                }

                private int Offset_Irp
                {
                    get
                    {
                        if (_offset_Irp == -1)
                        {
                            _offset_Irp = Offset_UniqMatchId + 4;
                        }

                        return _offset_Irp;
                    }
                }

                /// <summary>
                /// Retrieves the UniqMatchId field.
                /// </summary>
                public uint UniqMatchId => BitConverter.ToUInt32(_etwEvent.Data[Offset_UniqMatchId..]);

                /// <summary>
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Creates a new DrvMjFnRetData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DrvMjFnRetData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_UniqMatchId = -1;
                    _offset_Irp = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DrvComplReq event.
        /// </summary>
        public readonly ref struct DrvComplReqEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DrvComplReq";

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
                Opcode = (EtwEventOpcode)Opcodes.DrvComplReq,
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
            public DrvComplReqData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DrvComplReqEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DrvComplReqEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a DrvComplReq event.
            /// </summary>
            public ref struct DrvComplReqData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_RoutineAddr;
                private int _offset_Irp;
                private int _offset_UniqMatchId;

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

                private int Offset_Irp
                {
                    get
                    {
                        if (_offset_Irp == -1)
                        {
                            _offset_Irp = Offset_RoutineAddr + _etwEvent.AddressSize;
                        }

                        return _offset_Irp;
                    }
                }

                private int Offset_UniqMatchId
                {
                    get
                    {
                        if (_offset_UniqMatchId == -1)
                        {
                            _offset_UniqMatchId = Offset_Irp + _etwEvent.AddressSize;
                        }

                        return _offset_UniqMatchId;
                    }
                }

                /// <summary>
                /// Retrieves the RoutineAddr field.
                /// </summary>
                public ulong RoutineAddr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_RoutineAddr..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_RoutineAddr..]);

                /// <summary>
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Retrieves the UniqMatchId field.
                /// </summary>
                public uint UniqMatchId => BitConverter.ToUInt32(_etwEvent.Data[Offset_UniqMatchId..]);

                /// <summary>
                /// Creates a new DrvComplReqData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DrvComplReqData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_RoutineAddr = -1;
                    _offset_Irp = -1;
                    _offset_UniqMatchId = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DrvComplReqRet event.
        /// </summary>
        public readonly ref struct DrvComplReqRetEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DrvComplReqRet";

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
                Opcode = (EtwEventOpcode)Opcodes.DrvComplReqRet,
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
            public DrvComplReqRetData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DrvComplReqRetEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DrvComplReqRetEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a DrvComplReqRet event.
            /// </summary>
            public ref struct DrvComplReqRetData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Irp;
                private int _offset_UniqMatchId;

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

                private int Offset_UniqMatchId
                {
                    get
                    {
                        if (_offset_UniqMatchId == -1)
                        {
                            _offset_UniqMatchId = Offset_Irp + _etwEvent.AddressSize;
                        }

                        return _offset_UniqMatchId;
                    }
                }

                /// <summary>
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Retrieves the UniqMatchId field.
                /// </summary>
                public uint UniqMatchId => BitConverter.ToUInt32(_etwEvent.Data[Offset_UniqMatchId..]);

                /// <summary>
                /// Creates a new DrvComplReqRetData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DrvComplReqRetData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Irp = -1;
                    _offset_UniqMatchId = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Read event.
        /// </summary>
        public readonly ref struct ReadEventV1
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
                Version = 1,
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
            /// Creates a new ReadEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ReadEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a Read event.
            /// </summary>
            public ref struct ReadData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_DiskNumber;
                private int _offset_IrpFlags;
                private int _offset_TransferSize;
                private int _offset_ResponseTime;
                private int _offset_ByteOffset;
                private int _offset_FileObject;
                private int _offset_HighResResponseTime;

                private int Offset_DiskNumber
                {
                    get
                    {
                        if (_offset_DiskNumber == -1)
                        {
                            _offset_DiskNumber = 0;
                        }

                        return _offset_DiskNumber;
                    }
                }

                private int Offset_IrpFlags
                {
                    get
                    {
                        if (_offset_IrpFlags == -1)
                        {
                            _offset_IrpFlags = Offset_DiskNumber + 4;
                        }

                        return _offset_IrpFlags;
                    }
                }

                private int Offset_TransferSize
                {
                    get
                    {
                        if (_offset_TransferSize == -1)
                        {
                            _offset_TransferSize = Offset_IrpFlags + 4;
                        }

                        return _offset_TransferSize;
                    }
                }

                private int Offset_ResponseTime
                {
                    get
                    {
                        if (_offset_ResponseTime == -1)
                        {
                            _offset_ResponseTime = Offset_TransferSize + 4;
                        }

                        return _offset_ResponseTime;
                    }
                }

                private int Offset_ByteOffset
                {
                    get
                    {
                        if (_offset_ByteOffset == -1)
                        {
                            _offset_ByteOffset = Offset_ResponseTime + 4;
                        }

                        return _offset_ByteOffset;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_ByteOffset + 8;
                        }

                        return _offset_FileObject;
                    }
                }

                private int Offset_HighResResponseTime
                {
                    get
                    {
                        if (_offset_HighResResponseTime == -1)
                        {
                            _offset_HighResResponseTime = Offset_FileObject + _etwEvent.AddressSize;
                        }

                        return _offset_HighResResponseTime;
                    }
                }

                /// <summary>
                /// Retrieves the DiskNumber field.
                /// </summary>
                public uint DiskNumber => BitConverter.ToUInt32(_etwEvent.Data[Offset_DiskNumber..]);

                /// <summary>
                /// Retrieves the IrpFlags field.
                /// </summary>
                public uint IrpFlags => BitConverter.ToUInt32(_etwEvent.Data[Offset_IrpFlags..]);

                /// <summary>
                /// Retrieves the TransferSize field.
                /// </summary>
                public uint TransferSize => BitConverter.ToUInt32(_etwEvent.Data[Offset_TransferSize..]);

                /// <summary>
                /// Retrieves the ResponseTime field.
                /// </summary>
                public uint ResponseTime => BitConverter.ToUInt32(_etwEvent.Data[Offset_ResponseTime..]);

                /// <summary>
                /// Retrieves the ByteOffset field.
                /// </summary>
                public ulong ByteOffset => BitConverter.ToUInt64(_etwEvent.Data[Offset_ByteOffset..]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..]);

                /// <summary>
                /// Retrieves the HighResResponseTime field.
                /// </summary>
                public ulong HighResResponseTime => BitConverter.ToUInt64(_etwEvent.Data[Offset_HighResResponseTime..]);

                /// <summary>
                /// Creates a new ReadData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ReadData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_DiskNumber = -1;
                    _offset_IrpFlags = -1;
                    _offset_TransferSize = -1;
                    _offset_ResponseTime = -1;
                    _offset_ByteOffset = -1;
                    _offset_FileObject = -1;
                    _offset_HighResResponseTime = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Write event.
        /// </summary>
        public readonly ref struct WriteEventV1
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
                Version = 1,
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
            /// Creates a new WriteEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public WriteEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a Write event.
            /// </summary>
            public ref struct WriteData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_DiskNumber;
                private int _offset_IrpFlags;
                private int _offset_TransferSize;
                private int _offset_ResponseTime;
                private int _offset_ByteOffset;
                private int _offset_FileObject;
                private int _offset_HighResResponseTime;

                private int Offset_DiskNumber
                {
                    get
                    {
                        if (_offset_DiskNumber == -1)
                        {
                            _offset_DiskNumber = 0;
                        }

                        return _offset_DiskNumber;
                    }
                }

                private int Offset_IrpFlags
                {
                    get
                    {
                        if (_offset_IrpFlags == -1)
                        {
                            _offset_IrpFlags = Offset_DiskNumber + 4;
                        }

                        return _offset_IrpFlags;
                    }
                }

                private int Offset_TransferSize
                {
                    get
                    {
                        if (_offset_TransferSize == -1)
                        {
                            _offset_TransferSize = Offset_IrpFlags + 4;
                        }

                        return _offset_TransferSize;
                    }
                }

                private int Offset_ResponseTime
                {
                    get
                    {
                        if (_offset_ResponseTime == -1)
                        {
                            _offset_ResponseTime = Offset_TransferSize + 4;
                        }

                        return _offset_ResponseTime;
                    }
                }

                private int Offset_ByteOffset
                {
                    get
                    {
                        if (_offset_ByteOffset == -1)
                        {
                            _offset_ByteOffset = Offset_ResponseTime + 4;
                        }

                        return _offset_ByteOffset;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_ByteOffset + 8;
                        }

                        return _offset_FileObject;
                    }
                }

                private int Offset_HighResResponseTime
                {
                    get
                    {
                        if (_offset_HighResResponseTime == -1)
                        {
                            _offset_HighResResponseTime = Offset_FileObject + _etwEvent.AddressSize;
                        }

                        return _offset_HighResResponseTime;
                    }
                }

                /// <summary>
                /// Retrieves the DiskNumber field.
                /// </summary>
                public uint DiskNumber => BitConverter.ToUInt32(_etwEvent.Data[Offset_DiskNumber..]);

                /// <summary>
                /// Retrieves the IrpFlags field.
                /// </summary>
                public uint IrpFlags => BitConverter.ToUInt32(_etwEvent.Data[Offset_IrpFlags..]);

                /// <summary>
                /// Retrieves the TransferSize field.
                /// </summary>
                public uint TransferSize => BitConverter.ToUInt32(_etwEvent.Data[Offset_TransferSize..]);

                /// <summary>
                /// Retrieves the ResponseTime field.
                /// </summary>
                public uint ResponseTime => BitConverter.ToUInt32(_etwEvent.Data[Offset_ResponseTime..]);

                /// <summary>
                /// Retrieves the ByteOffset field.
                /// </summary>
                public ulong ByteOffset => BitConverter.ToUInt64(_etwEvent.Data[Offset_ByteOffset..]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..]);

                /// <summary>
                /// Retrieves the HighResResponseTime field.
                /// </summary>
                public ulong HighResResponseTime => BitConverter.ToUInt64(_etwEvent.Data[Offset_HighResResponseTime..]);

                /// <summary>
                /// Creates a new WriteData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public WriteData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_DiskNumber = -1;
                    _offset_IrpFlags = -1;
                    _offset_TransferSize = -1;
                    _offset_ResponseTime = -1;
                    _offset_ByteOffset = -1;
                    _offset_FileObject = -1;
                    _offset_HighResResponseTime = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DrvMjFnCall event.
        /// </summary>
        public readonly ref struct DrvMjFnCallEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DrvMjFnCall";

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
                Opcode = (EtwEventOpcode)Opcodes.DrvMjFnCall,
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
            public DrvMjFnCallData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DrvMjFnCallEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DrvMjFnCallEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a DrvMjFnCall event.
            /// </summary>
            public ref struct DrvMjFnCallData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_UniqMatchId;
                private int _offset_RoutineAddr;
                private int _offset_Irp;
                private int _offset_MajorFunction;
                private int _offset_MinorFunction;
                private int _offset_FileObject;

                private int Offset_UniqMatchId
                {
                    get
                    {
                        if (_offset_UniqMatchId == -1)
                        {
                            _offset_UniqMatchId = 0;
                        }

                        return _offset_UniqMatchId;
                    }
                }

                private int Offset_RoutineAddr
                {
                    get
                    {
                        if (_offset_RoutineAddr == -1)
                        {
                            _offset_RoutineAddr = Offset_UniqMatchId + 4;
                        }

                        return _offset_RoutineAddr;
                    }
                }

                private int Offset_Irp
                {
                    get
                    {
                        if (_offset_Irp == -1)
                        {
                            _offset_Irp = Offset_RoutineAddr + _etwEvent.AddressSize;
                        }

                        return _offset_Irp;
                    }
                }

                private int Offset_MajorFunction
                {
                    get
                    {
                        if (_offset_MajorFunction == -1)
                        {
                            _offset_MajorFunction = Offset_Irp + _etwEvent.AddressSize;
                        }

                        return _offset_MajorFunction;
                    }
                }

                private int Offset_MinorFunction
                {
                    get
                    {
                        if (_offset_MinorFunction == -1)
                        {
                            _offset_MinorFunction = Offset_MajorFunction + 4;
                        }

                        return _offset_MinorFunction;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_MinorFunction + 4;
                        }

                        return _offset_FileObject;
                    }
                }

                /// <summary>
                /// Retrieves the UniqMatchId field.
                /// </summary>
                public uint UniqMatchId => BitConverter.ToUInt32(_etwEvent.Data[Offset_UniqMatchId..]);

                /// <summary>
                /// Retrieves the RoutineAddr field.
                /// </summary>
                public ulong RoutineAddr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_RoutineAddr..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_RoutineAddr..]);

                /// <summary>
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Retrieves the MajorFunction field.
                /// </summary>
                public uint MajorFunction => BitConverter.ToUInt32(_etwEvent.Data[Offset_MajorFunction..]);

                /// <summary>
                /// Retrieves the MinorFunction field.
                /// </summary>
                public uint MinorFunction => BitConverter.ToUInt32(_etwEvent.Data[Offset_MinorFunction..]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..]);

                /// <summary>
                /// Creates a new DrvMjFnCallData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DrvMjFnCallData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_UniqMatchId = -1;
                    _offset_RoutineAddr = -1;
                    _offset_Irp = -1;
                    _offset_MajorFunction = -1;
                    _offset_MinorFunction = -1;
                    _offset_FileObject = -1;
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
            /// A data wrapper for a Read event.
            /// </summary>
            public ref struct ReadData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_DiskNumber;
                private int _offset_IrpFlags;
                private int _offset_TransferSize;
                private int _offset_Reserved;
                private int _offset_ByteOffset;
                private int _offset_FileObject;
                private int _offset_Irp;
                private int _offset_HighResResponseTime;

                private int Offset_DiskNumber
                {
                    get
                    {
                        if (_offset_DiskNumber == -1)
                        {
                            _offset_DiskNumber = 0;
                        }

                        return _offset_DiskNumber;
                    }
                }

                private int Offset_IrpFlags
                {
                    get
                    {
                        if (_offset_IrpFlags == -1)
                        {
                            _offset_IrpFlags = Offset_DiskNumber + 4;
                        }

                        return _offset_IrpFlags;
                    }
                }

                private int Offset_TransferSize
                {
                    get
                    {
                        if (_offset_TransferSize == -1)
                        {
                            _offset_TransferSize = Offset_IrpFlags + 4;
                        }

                        return _offset_TransferSize;
                    }
                }

                private int Offset_Reserved
                {
                    get
                    {
                        if (_offset_Reserved == -1)
                        {
                            _offset_Reserved = Offset_TransferSize + 4;
                        }

                        return _offset_Reserved;
                    }
                }

                private int Offset_ByteOffset
                {
                    get
                    {
                        if (_offset_ByteOffset == -1)
                        {
                            _offset_ByteOffset = Offset_Reserved + 4;
                        }

                        return _offset_ByteOffset;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_ByteOffset + 8;
                        }

                        return _offset_FileObject;
                    }
                }

                private int Offset_Irp
                {
                    get
                    {
                        if (_offset_Irp == -1)
                        {
                            _offset_Irp = Offset_FileObject + _etwEvent.AddressSize;
                        }

                        return _offset_Irp;
                    }
                }

                private int Offset_HighResResponseTime
                {
                    get
                    {
                        if (_offset_HighResResponseTime == -1)
                        {
                            _offset_HighResResponseTime = Offset_Irp + _etwEvent.AddressSize;
                        }

                        return _offset_HighResResponseTime;
                    }
                }

                /// <summary>
                /// Retrieves the DiskNumber field.
                /// </summary>
                public uint DiskNumber => BitConverter.ToUInt32(_etwEvent.Data[Offset_DiskNumber..]);

                /// <summary>
                /// Retrieves the IrpFlags field.
                /// </summary>
                public uint IrpFlags => BitConverter.ToUInt32(_etwEvent.Data[Offset_IrpFlags..]);

                /// <summary>
                /// Retrieves the TransferSize field.
                /// </summary>
                public uint TransferSize => BitConverter.ToUInt32(_etwEvent.Data[Offset_TransferSize..]);

                /// <summary>
                /// Retrieves the Reserved field.
                /// </summary>
                public uint Reserved => BitConverter.ToUInt32(_etwEvent.Data[Offset_Reserved..]);

                /// <summary>
                /// Retrieves the ByteOffset field.
                /// </summary>
                public ulong ByteOffset => BitConverter.ToUInt64(_etwEvent.Data[Offset_ByteOffset..]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..]);

                /// <summary>
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Retrieves the HighResResponseTime field.
                /// </summary>
                public ulong HighResResponseTime => BitConverter.ToUInt64(_etwEvent.Data[Offset_HighResResponseTime..]);

                /// <summary>
                /// Creates a new ReadData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ReadData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_DiskNumber = -1;
                    _offset_IrpFlags = -1;
                    _offset_TransferSize = -1;
                    _offset_Reserved = -1;
                    _offset_ByteOffset = -1;
                    _offset_FileObject = -1;
                    _offset_Irp = -1;
                    _offset_HighResResponseTime = -1;
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
            /// A data wrapper for a Write event.
            /// </summary>
            public ref struct WriteData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_DiskNumber;
                private int _offset_IrpFlags;
                private int _offset_TransferSize;
                private int _offset_Reserved;
                private int _offset_ByteOffset;
                private int _offset_FileObject;
                private int _offset_Irp;
                private int _offset_HighResResponseTime;

                private int Offset_DiskNumber
                {
                    get
                    {
                        if (_offset_DiskNumber == -1)
                        {
                            _offset_DiskNumber = 0;
                        }

                        return _offset_DiskNumber;
                    }
                }

                private int Offset_IrpFlags
                {
                    get
                    {
                        if (_offset_IrpFlags == -1)
                        {
                            _offset_IrpFlags = Offset_DiskNumber + 4;
                        }

                        return _offset_IrpFlags;
                    }
                }

                private int Offset_TransferSize
                {
                    get
                    {
                        if (_offset_TransferSize == -1)
                        {
                            _offset_TransferSize = Offset_IrpFlags + 4;
                        }

                        return _offset_TransferSize;
                    }
                }

                private int Offset_Reserved
                {
                    get
                    {
                        if (_offset_Reserved == -1)
                        {
                            _offset_Reserved = Offset_TransferSize + 4;
                        }

                        return _offset_Reserved;
                    }
                }

                private int Offset_ByteOffset
                {
                    get
                    {
                        if (_offset_ByteOffset == -1)
                        {
                            _offset_ByteOffset = Offset_Reserved + 4;
                        }

                        return _offset_ByteOffset;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_ByteOffset + 8;
                        }

                        return _offset_FileObject;
                    }
                }

                private int Offset_Irp
                {
                    get
                    {
                        if (_offset_Irp == -1)
                        {
                            _offset_Irp = Offset_FileObject + _etwEvent.AddressSize;
                        }

                        return _offset_Irp;
                    }
                }

                private int Offset_HighResResponseTime
                {
                    get
                    {
                        if (_offset_HighResResponseTime == -1)
                        {
                            _offset_HighResResponseTime = Offset_Irp + _etwEvent.AddressSize;
                        }

                        return _offset_HighResResponseTime;
                    }
                }

                /// <summary>
                /// Retrieves the DiskNumber field.
                /// </summary>
                public uint DiskNumber => BitConverter.ToUInt32(_etwEvent.Data[Offset_DiskNumber..]);

                /// <summary>
                /// Retrieves the IrpFlags field.
                /// </summary>
                public uint IrpFlags => BitConverter.ToUInt32(_etwEvent.Data[Offset_IrpFlags..]);

                /// <summary>
                /// Retrieves the TransferSize field.
                /// </summary>
                public uint TransferSize => BitConverter.ToUInt32(_etwEvent.Data[Offset_TransferSize..]);

                /// <summary>
                /// Retrieves the Reserved field.
                /// </summary>
                public uint Reserved => BitConverter.ToUInt32(_etwEvent.Data[Offset_Reserved..]);

                /// <summary>
                /// Retrieves the ByteOffset field.
                /// </summary>
                public ulong ByteOffset => BitConverter.ToUInt64(_etwEvent.Data[Offset_ByteOffset..]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..]);

                /// <summary>
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Retrieves the HighResResponseTime field.
                /// </summary>
                public ulong HighResResponseTime => BitConverter.ToUInt64(_etwEvent.Data[Offset_HighResResponseTime..]);

                /// <summary>
                /// Creates a new WriteData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public WriteData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_DiskNumber = -1;
                    _offset_IrpFlags = -1;
                    _offset_TransferSize = -1;
                    _offset_Reserved = -1;
                    _offset_ByteOffset = -1;
                    _offset_FileObject = -1;
                    _offset_Irp = -1;
                    _offset_HighResResponseTime = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DrvMjFnRet event.
        /// </summary>
        public readonly ref struct DrvMjFnRetEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DrvMjFnRet";

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
                Opcode = (EtwEventOpcode)Opcodes.DrvMjFnRet,
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
            public DrvMjFnRetData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DrvMjFnRetEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DrvMjFnRetEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a DrvMjFnRet event.
            /// </summary>
            public ref struct DrvMjFnRetData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Irp;
                private int _offset_UniqMatchId;

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

                private int Offset_UniqMatchId
                {
                    get
                    {
                        if (_offset_UniqMatchId == -1)
                        {
                            _offset_UniqMatchId = Offset_Irp + _etwEvent.AddressSize;
                        }

                        return _offset_UniqMatchId;
                    }
                }

                /// <summary>
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Retrieves the UniqMatchId field.
                /// </summary>
                public uint UniqMatchId => BitConverter.ToUInt32(_etwEvent.Data[Offset_UniqMatchId..]);

                /// <summary>
                /// Creates a new DrvMjFnRetData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DrvMjFnRetData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Irp = -1;
                    _offset_UniqMatchId = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DrvComplRout event.
        /// </summary>
        public readonly ref struct DrvComplRoutEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DrvComplRout";

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
                Opcode = (EtwEventOpcode)Opcodes.DrvComplRout,
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
            public DrvComplRoutData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DrvComplRoutEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DrvComplRoutEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a DrvComplRout event.
            /// </summary>
            public ref struct DrvComplRoutData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Routine;
                private int _offset_IrpPtr;
                private int _offset_UniqMatchId;

                private int Offset_Routine
                {
                    get
                    {
                        if (_offset_Routine == -1)
                        {
                            _offset_Routine = 0;
                        }

                        return _offset_Routine;
                    }
                }

                private int Offset_IrpPtr
                {
                    get
                    {
                        if (_offset_IrpPtr == -1)
                        {
                            _offset_IrpPtr = Offset_Routine + _etwEvent.AddressSize;
                        }

                        return _offset_IrpPtr;
                    }
                }

                private int Offset_UniqMatchId
                {
                    get
                    {
                        if (_offset_UniqMatchId == -1)
                        {
                            _offset_UniqMatchId = Offset_IrpPtr + _etwEvent.AddressSize;
                        }

                        return _offset_UniqMatchId;
                    }
                }

                /// <summary>
                /// Retrieves the Routine field.
                /// </summary>
                public ulong Routine => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Routine..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Routine..]);

                /// <summary>
                /// Retrieves the IrpPtr field.
                /// </summary>
                public ulong IrpPtr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_IrpPtr..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_IrpPtr..]);

                /// <summary>
                /// Retrieves the UniqMatchId field.
                /// </summary>
                public uint UniqMatchId => BitConverter.ToUInt32(_etwEvent.Data[Offset_UniqMatchId..]);

                /// <summary>
                /// Creates a new DrvComplRoutData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DrvComplRoutData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Routine = -1;
                    _offset_IrpPtr = -1;
                    _offset_UniqMatchId = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DrvMjFnCall event.
        /// </summary>
        public readonly ref struct DrvMjFnCallEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DrvMjFnCall";

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
                Opcode = (EtwEventOpcode)Opcodes.DrvMjFnCall,
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
            public DrvMjFnCallData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DrvMjFnCallEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DrvMjFnCallEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a DrvMjFnCall event.
            /// </summary>
            public ref struct DrvMjFnCallData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_MajorFunction;
                private int _offset_MinorFunction;
                private int _offset_RoutineAddr;
                private int _offset_FileObject;
                private int _offset_Irp;
                private int _offset_UniqMatchId;

                private int Offset_MajorFunction
                {
                    get
                    {
                        if (_offset_MajorFunction == -1)
                        {
                            _offset_MajorFunction = 0;
                        }

                        return _offset_MajorFunction;
                    }
                }

                private int Offset_MinorFunction
                {
                    get
                    {
                        if (_offset_MinorFunction == -1)
                        {
                            _offset_MinorFunction = Offset_MajorFunction + 4;
                        }

                        return _offset_MinorFunction;
                    }
                }

                private int Offset_RoutineAddr
                {
                    get
                    {
                        if (_offset_RoutineAddr == -1)
                        {
                            _offset_RoutineAddr = Offset_MinorFunction + 4;
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

                private int Offset_Irp
                {
                    get
                    {
                        if (_offset_Irp == -1)
                        {
                            _offset_Irp = Offset_FileObject + _etwEvent.AddressSize;
                        }

                        return _offset_Irp;
                    }
                }

                private int Offset_UniqMatchId
                {
                    get
                    {
                        if (_offset_UniqMatchId == -1)
                        {
                            _offset_UniqMatchId = Offset_Irp + _etwEvent.AddressSize;
                        }

                        return _offset_UniqMatchId;
                    }
                }

                /// <summary>
                /// Retrieves the MajorFunction field.
                /// </summary>
                public uint MajorFunction => BitConverter.ToUInt32(_etwEvent.Data[Offset_MajorFunction..]);

                /// <summary>
                /// Retrieves the MinorFunction field.
                /// </summary>
                public uint MinorFunction => BitConverter.ToUInt32(_etwEvent.Data[Offset_MinorFunction..]);

                /// <summary>
                /// Retrieves the RoutineAddr field.
                /// </summary>
                public ulong RoutineAddr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_RoutineAddr..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_RoutineAddr..]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..]);

                /// <summary>
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Retrieves the UniqMatchId field.
                /// </summary>
                public uint UniqMatchId => BitConverter.ToUInt32(_etwEvent.Data[Offset_UniqMatchId..]);

                /// <summary>
                /// Creates a new DrvMjFnCallData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DrvMjFnCallData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_MajorFunction = -1;
                    _offset_MinorFunction = -1;
                    _offset_RoutineAddr = -1;
                    _offset_FileObject = -1;
                    _offset_Irp = -1;
                    _offset_UniqMatchId = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DrvComplReqRet event.
        /// </summary>
        public readonly ref struct DrvComplReqRetEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DrvComplReqRet";

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
                Opcode = (EtwEventOpcode)Opcodes.DrvComplReqRet,
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
            public DrvComplReqRetData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DrvComplReqRetEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DrvComplReqRetEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a DrvComplReqRet event.
            /// </summary>
            public ref struct DrvComplReqRetData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Irp;
                private int _offset_UniqMatchId;

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

                private int Offset_UniqMatchId
                {
                    get
                    {
                        if (_offset_UniqMatchId == -1)
                        {
                            _offset_UniqMatchId = Offset_Irp + _etwEvent.AddressSize;
                        }

                        return _offset_UniqMatchId;
                    }
                }

                /// <summary>
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Retrieves the UniqMatchId field.
                /// </summary>
                public uint UniqMatchId => BitConverter.ToUInt32(_etwEvent.Data[Offset_UniqMatchId..]);

                /// <summary>
                /// Creates a new DrvComplReqRetData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DrvComplReqRetData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Irp = -1;
                    _offset_UniqMatchId = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a FlushBuffers event.
        /// </summary>
        public readonly ref struct FlushBuffersEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "FlushBuffers";

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
                Opcode = (EtwEventOpcode)Opcodes.FlushBuffers,
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
            public FlushBuffersData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new FlushBuffersEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public FlushBuffersEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a FlushBuffers event.
            /// </summary>
            public ref struct FlushBuffersData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_DiskNumber;
                private int _offset_IrpFlags;
                private int _offset_HighResResponseTime;
                private int _offset_Irp;

                private int Offset_DiskNumber
                {
                    get
                    {
                        if (_offset_DiskNumber == -1)
                        {
                            _offset_DiskNumber = 0;
                        }

                        return _offset_DiskNumber;
                    }
                }

                private int Offset_IrpFlags
                {
                    get
                    {
                        if (_offset_IrpFlags == -1)
                        {
                            _offset_IrpFlags = Offset_DiskNumber + 4;
                        }

                        return _offset_IrpFlags;
                    }
                }

                private int Offset_HighResResponseTime
                {
                    get
                    {
                        if (_offset_HighResResponseTime == -1)
                        {
                            _offset_HighResResponseTime = Offset_IrpFlags + 4;
                        }

                        return _offset_HighResResponseTime;
                    }
                }

                private int Offset_Irp
                {
                    get
                    {
                        if (_offset_Irp == -1)
                        {
                            _offset_Irp = Offset_HighResResponseTime + 8;
                        }

                        return _offset_Irp;
                    }
                }

                /// <summary>
                /// Retrieves the DiskNumber field.
                /// </summary>
                public uint DiskNumber => BitConverter.ToUInt32(_etwEvent.Data[Offset_DiskNumber..]);

                /// <summary>
                /// Retrieves the IrpFlags field.
                /// </summary>
                public uint IrpFlags => BitConverter.ToUInt32(_etwEvent.Data[Offset_IrpFlags..]);

                /// <summary>
                /// Retrieves the HighResResponseTime field.
                /// </summary>
                public ulong HighResResponseTime => BitConverter.ToUInt64(_etwEvent.Data[Offset_HighResResponseTime..]);

                /// <summary>
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Creates a new FlushBuffersData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public FlushBuffersData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_DiskNumber = -1;
                    _offset_IrpFlags = -1;
                    _offset_HighResResponseTime = -1;
                    _offset_Irp = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ReadInit event.
        /// </summary>
        public readonly ref struct ReadInitEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ReadInit";

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
                Opcode = (EtwEventOpcode)Opcodes.ReadInit,
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
            public ReadInitData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ReadInitEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ReadInitEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ReadInit event.
            /// </summary>
            public ref struct ReadInitData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Irp;

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

                /// <summary>
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Creates a new ReadInitData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ReadInitData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Irp = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a WriteInit event.
        /// </summary>
        public readonly ref struct WriteInitEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "WriteInit";

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
                Opcode = (EtwEventOpcode)Opcodes.WriteInit,
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
            public WriteInitData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new WriteInitEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public WriteInitEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a WriteInit event.
            /// </summary>
            public ref struct WriteInitData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Irp;

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

                /// <summary>
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Creates a new WriteInitData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public WriteInitData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Irp = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a FlushInit event.
        /// </summary>
        public readonly ref struct FlushInitEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "FlushInit";

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
                Opcode = (EtwEventOpcode)Opcodes.FlushInit,
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
            public FlushInitData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new FlushInitEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public FlushInitEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a FlushInit event.
            /// </summary>
            public ref struct FlushInitData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Irp;

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

                /// <summary>
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Creates a new FlushInitData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public FlushInitData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Irp = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DrvComplReq event.
        /// </summary>
        public readonly ref struct DrvComplReqEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DrvComplReq";

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
                Opcode = (EtwEventOpcode)Opcodes.DrvComplReq,
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
            public DrvComplReqData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DrvComplReqEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DrvComplReqEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a DrvComplReq event.
            /// </summary>
            public ref struct DrvComplReqData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_RoutineAddr;
                private int _offset_Irp;
                private int _offset_UniqMatchId;

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

                private int Offset_Irp
                {
                    get
                    {
                        if (_offset_Irp == -1)
                        {
                            _offset_Irp = Offset_RoutineAddr + _etwEvent.AddressSize;
                        }

                        return _offset_Irp;
                    }
                }

                private int Offset_UniqMatchId
                {
                    get
                    {
                        if (_offset_UniqMatchId == -1)
                        {
                            _offset_UniqMatchId = Offset_Irp + _etwEvent.AddressSize;
                        }

                        return _offset_UniqMatchId;
                    }
                }

                /// <summary>
                /// Retrieves the RoutineAddr field.
                /// </summary>
                public ulong RoutineAddr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_RoutineAddr..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_RoutineAddr..]);

                /// <summary>
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Retrieves the UniqMatchId field.
                /// </summary>
                public uint UniqMatchId => BitConverter.ToUInt32(_etwEvent.Data[Offset_UniqMatchId..]);

                /// <summary>
                /// Creates a new DrvComplReqData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DrvComplReqData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_RoutineAddr = -1;
                    _offset_Irp = -1;
                    _offset_UniqMatchId = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ReadInit event.
        /// </summary>
        public readonly ref struct ReadInitEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ReadInit";

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
                Opcode = (EtwEventOpcode)Opcodes.ReadInit,
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
            public ReadInitData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ReadInitEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ReadInitEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ReadInit event.
            /// </summary>
            public ref struct ReadInitData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Irp;
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

                private int Offset_IssuingThreadId
                {
                    get
                    {
                        if (_offset_IssuingThreadId == -1)
                        {
                            _offset_IssuingThreadId = Offset_Irp + _etwEvent.AddressSize;
                        }

                        return _offset_IssuingThreadId;
                    }
                }

                /// <summary>
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Retrieves the IssuingThreadId field.
                /// </summary>
                public uint IssuingThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_IssuingThreadId..]);

                /// <summary>
                /// Creates a new ReadInitData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ReadInitData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Irp = -1;
                    _offset_IssuingThreadId = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a WriteInit event.
        /// </summary>
        public readonly ref struct WriteInitEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "WriteInit";

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
                Opcode = (EtwEventOpcode)Opcodes.WriteInit,
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
            public WriteInitData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new WriteInitEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public WriteInitEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a WriteInit event.
            /// </summary>
            public ref struct WriteInitData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Irp;
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

                private int Offset_IssuingThreadId
                {
                    get
                    {
                        if (_offset_IssuingThreadId == -1)
                        {
                            _offset_IssuingThreadId = Offset_Irp + _etwEvent.AddressSize;
                        }

                        return _offset_IssuingThreadId;
                    }
                }

                /// <summary>
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Retrieves the IssuingThreadId field.
                /// </summary>
                public uint IssuingThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_IssuingThreadId..]);

                /// <summary>
                /// Creates a new WriteInitData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public WriteInitData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Irp = -1;
                    _offset_IssuingThreadId = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a FlushInit event.
        /// </summary>
        public readonly ref struct FlushInitEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "FlushInit";

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
                Opcode = (EtwEventOpcode)Opcodes.FlushInit,
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
            public FlushInitData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new FlushInitEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public FlushInitEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a FlushInit event.
            /// </summary>
            public ref struct FlushInitData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Irp;
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

                private int Offset_IssuingThreadId
                {
                    get
                    {
                        if (_offset_IssuingThreadId == -1)
                        {
                            _offset_IssuingThreadId = Offset_Irp + _etwEvent.AddressSize;
                        }

                        return _offset_IssuingThreadId;
                    }
                }

                /// <summary>
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Retrieves the IssuingThreadId field.
                /// </summary>
                public uint IssuingThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_IssuingThreadId..]);

                /// <summary>
                /// Creates a new FlushInitData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public FlushInitData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Irp = -1;
                    _offset_IssuingThreadId = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a OpticalReadInit event.
        /// </summary>
        public readonly ref struct OpticalReadInitEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "OpticalReadInit";

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
                Opcode = (EtwEventOpcode)Opcodes.OpticalReadInit,
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
            public OpticalReadInitData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new OpticalReadInitEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public OpticalReadInitEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a OpticalReadInit event.
            /// </summary>
            public ref struct OpticalReadInitData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Irp;
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

                private int Offset_IssuingThreadId
                {
                    get
                    {
                        if (_offset_IssuingThreadId == -1)
                        {
                            _offset_IssuingThreadId = Offset_Irp + _etwEvent.AddressSize;
                        }

                        return _offset_IssuingThreadId;
                    }
                }

                /// <summary>
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Retrieves the IssuingThreadId field.
                /// </summary>
                public uint IssuingThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_IssuingThreadId..]);

                /// <summary>
                /// Creates a new OpticalReadInitData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public OpticalReadInitData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Irp = -1;
                    _offset_IssuingThreadId = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a OpticalWriteInit event.
        /// </summary>
        public readonly ref struct OpticalWriteInitEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "OpticalWriteInit";

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
                Opcode = (EtwEventOpcode)Opcodes.OpticalWriteInit,
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
            public OpticalWriteInitData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new OpticalWriteInitEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public OpticalWriteInitEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a OpticalWriteInit event.
            /// </summary>
            public ref struct OpticalWriteInitData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Irp;
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

                private int Offset_IssuingThreadId
                {
                    get
                    {
                        if (_offset_IssuingThreadId == -1)
                        {
                            _offset_IssuingThreadId = Offset_Irp + _etwEvent.AddressSize;
                        }

                        return _offset_IssuingThreadId;
                    }
                }

                /// <summary>
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Retrieves the IssuingThreadId field.
                /// </summary>
                public uint IssuingThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_IssuingThreadId..]);

                /// <summary>
                /// Creates a new OpticalWriteInitData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public OpticalWriteInitData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Irp = -1;
                    _offset_IssuingThreadId = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a OpticalFlushInit event.
        /// </summary>
        public readonly ref struct OpticalFlushInitEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "OpticalFlushInit";

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
                Opcode = (EtwEventOpcode)Opcodes.OpticalFlushInit,
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
            public OpticalFlushInitData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new OpticalFlushInitEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public OpticalFlushInitEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a OpticalFlushInit event.
            /// </summary>
            public ref struct OpticalFlushInitData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Irp;
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

                private int Offset_IssuingThreadId
                {
                    get
                    {
                        if (_offset_IssuingThreadId == -1)
                        {
                            _offset_IssuingThreadId = Offset_Irp + _etwEvent.AddressSize;
                        }

                        return _offset_IssuingThreadId;
                    }
                }

                /// <summary>
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Retrieves the IssuingThreadId field.
                /// </summary>
                public uint IssuingThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_IssuingThreadId..]);

                /// <summary>
                /// Creates a new OpticalFlushInitData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public OpticalFlushInitData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Irp = -1;
                    _offset_IssuingThreadId = -1;
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
            /// A data wrapper for a Read event.
            /// </summary>
            public ref struct ReadData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_DiskNumber;
                private int _offset_IrpFlags;
                private int _offset_TransferSize;
                private int _offset_Reserved;
                private int _offset_ByteOffset;
                private int _offset_FileObject;
                private int _offset_Irp;
                private int _offset_HighResResponseTime;
                private int _offset_IssuingThreadId;

                private int Offset_DiskNumber
                {
                    get
                    {
                        if (_offset_DiskNumber == -1)
                        {
                            _offset_DiskNumber = 0;
                        }

                        return _offset_DiskNumber;
                    }
                }

                private int Offset_IrpFlags
                {
                    get
                    {
                        if (_offset_IrpFlags == -1)
                        {
                            _offset_IrpFlags = Offset_DiskNumber + 4;
                        }

                        return _offset_IrpFlags;
                    }
                }

                private int Offset_TransferSize
                {
                    get
                    {
                        if (_offset_TransferSize == -1)
                        {
                            _offset_TransferSize = Offset_IrpFlags + 4;
                        }

                        return _offset_TransferSize;
                    }
                }

                private int Offset_Reserved
                {
                    get
                    {
                        if (_offset_Reserved == -1)
                        {
                            _offset_Reserved = Offset_TransferSize + 4;
                        }

                        return _offset_Reserved;
                    }
                }

                private int Offset_ByteOffset
                {
                    get
                    {
                        if (_offset_ByteOffset == -1)
                        {
                            _offset_ByteOffset = Offset_Reserved + 4;
                        }

                        return _offset_ByteOffset;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_ByteOffset + 8;
                        }

                        return _offset_FileObject;
                    }
                }

                private int Offset_Irp
                {
                    get
                    {
                        if (_offset_Irp == -1)
                        {
                            _offset_Irp = Offset_FileObject + _etwEvent.AddressSize;
                        }

                        return _offset_Irp;
                    }
                }

                private int Offset_HighResResponseTime
                {
                    get
                    {
                        if (_offset_HighResResponseTime == -1)
                        {
                            _offset_HighResResponseTime = Offset_Irp + _etwEvent.AddressSize;
                        }

                        return _offset_HighResResponseTime;
                    }
                }

                private int Offset_IssuingThreadId
                {
                    get
                    {
                        if (_offset_IssuingThreadId == -1)
                        {
                            _offset_IssuingThreadId = Offset_HighResResponseTime + 8;
                        }

                        return _offset_IssuingThreadId;
                    }
                }

                /// <summary>
                /// Retrieves the DiskNumber field.
                /// </summary>
                public uint DiskNumber => BitConverter.ToUInt32(_etwEvent.Data[Offset_DiskNumber..]);

                /// <summary>
                /// Retrieves the IrpFlags field.
                /// </summary>
                public uint IrpFlags => BitConverter.ToUInt32(_etwEvent.Data[Offset_IrpFlags..]);

                /// <summary>
                /// Retrieves the TransferSize field.
                /// </summary>
                public uint TransferSize => BitConverter.ToUInt32(_etwEvent.Data[Offset_TransferSize..]);

                /// <summary>
                /// Retrieves the Reserved field.
                /// </summary>
                public uint Reserved => BitConverter.ToUInt32(_etwEvent.Data[Offset_Reserved..]);

                /// <summary>
                /// Retrieves the ByteOffset field.
                /// </summary>
                public ulong ByteOffset => BitConverter.ToUInt64(_etwEvent.Data[Offset_ByteOffset..]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..]);

                /// <summary>
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Retrieves the HighResResponseTime field.
                /// </summary>
                public ulong HighResResponseTime => BitConverter.ToUInt64(_etwEvent.Data[Offset_HighResResponseTime..]);

                /// <summary>
                /// Retrieves the IssuingThreadId field.
                /// </summary>
                public uint IssuingThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_IssuingThreadId..]);

                /// <summary>
                /// Creates a new ReadData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ReadData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_DiskNumber = -1;
                    _offset_IrpFlags = -1;
                    _offset_TransferSize = -1;
                    _offset_Reserved = -1;
                    _offset_ByteOffset = -1;
                    _offset_FileObject = -1;
                    _offset_Irp = -1;
                    _offset_HighResResponseTime = -1;
                    _offset_IssuingThreadId = -1;
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
            /// A data wrapper for a Write event.
            /// </summary>
            public ref struct WriteData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_DiskNumber;
                private int _offset_IrpFlags;
                private int _offset_TransferSize;
                private int _offset_Reserved;
                private int _offset_ByteOffset;
                private int _offset_FileObject;
                private int _offset_Irp;
                private int _offset_HighResResponseTime;
                private int _offset_IssuingThreadId;

                private int Offset_DiskNumber
                {
                    get
                    {
                        if (_offset_DiskNumber == -1)
                        {
                            _offset_DiskNumber = 0;
                        }

                        return _offset_DiskNumber;
                    }
                }

                private int Offset_IrpFlags
                {
                    get
                    {
                        if (_offset_IrpFlags == -1)
                        {
                            _offset_IrpFlags = Offset_DiskNumber + 4;
                        }

                        return _offset_IrpFlags;
                    }
                }

                private int Offset_TransferSize
                {
                    get
                    {
                        if (_offset_TransferSize == -1)
                        {
                            _offset_TransferSize = Offset_IrpFlags + 4;
                        }

                        return _offset_TransferSize;
                    }
                }

                private int Offset_Reserved
                {
                    get
                    {
                        if (_offset_Reserved == -1)
                        {
                            _offset_Reserved = Offset_TransferSize + 4;
                        }

                        return _offset_Reserved;
                    }
                }

                private int Offset_ByteOffset
                {
                    get
                    {
                        if (_offset_ByteOffset == -1)
                        {
                            _offset_ByteOffset = Offset_Reserved + 4;
                        }

                        return _offset_ByteOffset;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_ByteOffset + 8;
                        }

                        return _offset_FileObject;
                    }
                }

                private int Offset_Irp
                {
                    get
                    {
                        if (_offset_Irp == -1)
                        {
                            _offset_Irp = Offset_FileObject + _etwEvent.AddressSize;
                        }

                        return _offset_Irp;
                    }
                }

                private int Offset_HighResResponseTime
                {
                    get
                    {
                        if (_offset_HighResResponseTime == -1)
                        {
                            _offset_HighResResponseTime = Offset_Irp + _etwEvent.AddressSize;
                        }

                        return _offset_HighResResponseTime;
                    }
                }

                private int Offset_IssuingThreadId
                {
                    get
                    {
                        if (_offset_IssuingThreadId == -1)
                        {
                            _offset_IssuingThreadId = Offset_HighResResponseTime + 8;
                        }

                        return _offset_IssuingThreadId;
                    }
                }

                /// <summary>
                /// Retrieves the DiskNumber field.
                /// </summary>
                public uint DiskNumber => BitConverter.ToUInt32(_etwEvent.Data[Offset_DiskNumber..]);

                /// <summary>
                /// Retrieves the IrpFlags field.
                /// </summary>
                public uint IrpFlags => BitConverter.ToUInt32(_etwEvent.Data[Offset_IrpFlags..]);

                /// <summary>
                /// Retrieves the TransferSize field.
                /// </summary>
                public uint TransferSize => BitConverter.ToUInt32(_etwEvent.Data[Offset_TransferSize..]);

                /// <summary>
                /// Retrieves the Reserved field.
                /// </summary>
                public uint Reserved => BitConverter.ToUInt32(_etwEvent.Data[Offset_Reserved..]);

                /// <summary>
                /// Retrieves the ByteOffset field.
                /// </summary>
                public ulong ByteOffset => BitConverter.ToUInt64(_etwEvent.Data[Offset_ByteOffset..]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..]);

                /// <summary>
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Retrieves the HighResResponseTime field.
                /// </summary>
                public ulong HighResResponseTime => BitConverter.ToUInt64(_etwEvent.Data[Offset_HighResResponseTime..]);

                /// <summary>
                /// Retrieves the IssuingThreadId field.
                /// </summary>
                public uint IssuingThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_IssuingThreadId..]);

                /// <summary>
                /// Creates a new WriteData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public WriteData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_DiskNumber = -1;
                    _offset_IrpFlags = -1;
                    _offset_TransferSize = -1;
                    _offset_Reserved = -1;
                    _offset_ByteOffset = -1;
                    _offset_FileObject = -1;
                    _offset_Irp = -1;
                    _offset_HighResResponseTime = -1;
                    _offset_IssuingThreadId = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a OpticalRead event.
        /// </summary>
        public readonly ref struct OpticalReadEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "OpticalRead";

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
                Opcode = (EtwEventOpcode)Opcodes.OpticalRead,
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
            public OpticalReadData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new OpticalReadEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public OpticalReadEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a OpticalRead event.
            /// </summary>
            public ref struct OpticalReadData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_DiskNumber;
                private int _offset_IrpFlags;
                private int _offset_TransferSize;
                private int _offset_Reserved;
                private int _offset_ByteOffset;
                private int _offset_FileObject;
                private int _offset_Irp;
                private int _offset_HighResResponseTime;
                private int _offset_IssuingThreadId;

                private int Offset_DiskNumber
                {
                    get
                    {
                        if (_offset_DiskNumber == -1)
                        {
                            _offset_DiskNumber = 0;
                        }

                        return _offset_DiskNumber;
                    }
                }

                private int Offset_IrpFlags
                {
                    get
                    {
                        if (_offset_IrpFlags == -1)
                        {
                            _offset_IrpFlags = Offset_DiskNumber + 4;
                        }

                        return _offset_IrpFlags;
                    }
                }

                private int Offset_TransferSize
                {
                    get
                    {
                        if (_offset_TransferSize == -1)
                        {
                            _offset_TransferSize = Offset_IrpFlags + 4;
                        }

                        return _offset_TransferSize;
                    }
                }

                private int Offset_Reserved
                {
                    get
                    {
                        if (_offset_Reserved == -1)
                        {
                            _offset_Reserved = Offset_TransferSize + 4;
                        }

                        return _offset_Reserved;
                    }
                }

                private int Offset_ByteOffset
                {
                    get
                    {
                        if (_offset_ByteOffset == -1)
                        {
                            _offset_ByteOffset = Offset_Reserved + 4;
                        }

                        return _offset_ByteOffset;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_ByteOffset + 8;
                        }

                        return _offset_FileObject;
                    }
                }

                private int Offset_Irp
                {
                    get
                    {
                        if (_offset_Irp == -1)
                        {
                            _offset_Irp = Offset_FileObject + _etwEvent.AddressSize;
                        }

                        return _offset_Irp;
                    }
                }

                private int Offset_HighResResponseTime
                {
                    get
                    {
                        if (_offset_HighResResponseTime == -1)
                        {
                            _offset_HighResResponseTime = Offset_Irp + _etwEvent.AddressSize;
                        }

                        return _offset_HighResResponseTime;
                    }
                }

                private int Offset_IssuingThreadId
                {
                    get
                    {
                        if (_offset_IssuingThreadId == -1)
                        {
                            _offset_IssuingThreadId = Offset_HighResResponseTime + 8;
                        }

                        return _offset_IssuingThreadId;
                    }
                }

                /// <summary>
                /// Retrieves the DiskNumber field.
                /// </summary>
                public uint DiskNumber => BitConverter.ToUInt32(_etwEvent.Data[Offset_DiskNumber..]);

                /// <summary>
                /// Retrieves the IrpFlags field.
                /// </summary>
                public uint IrpFlags => BitConverter.ToUInt32(_etwEvent.Data[Offset_IrpFlags..]);

                /// <summary>
                /// Retrieves the TransferSize field.
                /// </summary>
                public uint TransferSize => BitConverter.ToUInt32(_etwEvent.Data[Offset_TransferSize..]);

                /// <summary>
                /// Retrieves the Reserved field.
                /// </summary>
                public uint Reserved => BitConverter.ToUInt32(_etwEvent.Data[Offset_Reserved..]);

                /// <summary>
                /// Retrieves the ByteOffset field.
                /// </summary>
                public ulong ByteOffset => BitConverter.ToUInt64(_etwEvent.Data[Offset_ByteOffset..]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..]);

                /// <summary>
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Retrieves the HighResResponseTime field.
                /// </summary>
                public ulong HighResResponseTime => BitConverter.ToUInt64(_etwEvent.Data[Offset_HighResResponseTime..]);

                /// <summary>
                /// Retrieves the IssuingThreadId field.
                /// </summary>
                public uint IssuingThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_IssuingThreadId..]);

                /// <summary>
                /// Creates a new OpticalReadData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public OpticalReadData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_DiskNumber = -1;
                    _offset_IrpFlags = -1;
                    _offset_TransferSize = -1;
                    _offset_Reserved = -1;
                    _offset_ByteOffset = -1;
                    _offset_FileObject = -1;
                    _offset_Irp = -1;
                    _offset_HighResResponseTime = -1;
                    _offset_IssuingThreadId = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a OpticalWrite event.
        /// </summary>
        public readonly ref struct OpticalWriteEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "OpticalWrite";

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
                Opcode = (EtwEventOpcode)Opcodes.OpticalWrite,
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
            public OpticalWriteData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new OpticalWriteEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public OpticalWriteEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a OpticalWrite event.
            /// </summary>
            public ref struct OpticalWriteData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_DiskNumber;
                private int _offset_IrpFlags;
                private int _offset_TransferSize;
                private int _offset_Reserved;
                private int _offset_ByteOffset;
                private int _offset_FileObject;
                private int _offset_Irp;
                private int _offset_HighResResponseTime;
                private int _offset_IssuingThreadId;

                private int Offset_DiskNumber
                {
                    get
                    {
                        if (_offset_DiskNumber == -1)
                        {
                            _offset_DiskNumber = 0;
                        }

                        return _offset_DiskNumber;
                    }
                }

                private int Offset_IrpFlags
                {
                    get
                    {
                        if (_offset_IrpFlags == -1)
                        {
                            _offset_IrpFlags = Offset_DiskNumber + 4;
                        }

                        return _offset_IrpFlags;
                    }
                }

                private int Offset_TransferSize
                {
                    get
                    {
                        if (_offset_TransferSize == -1)
                        {
                            _offset_TransferSize = Offset_IrpFlags + 4;
                        }

                        return _offset_TransferSize;
                    }
                }

                private int Offset_Reserved
                {
                    get
                    {
                        if (_offset_Reserved == -1)
                        {
                            _offset_Reserved = Offset_TransferSize + 4;
                        }

                        return _offset_Reserved;
                    }
                }

                private int Offset_ByteOffset
                {
                    get
                    {
                        if (_offset_ByteOffset == -1)
                        {
                            _offset_ByteOffset = Offset_Reserved + 4;
                        }

                        return _offset_ByteOffset;
                    }
                }

                private int Offset_FileObject
                {
                    get
                    {
                        if (_offset_FileObject == -1)
                        {
                            _offset_FileObject = Offset_ByteOffset + 8;
                        }

                        return _offset_FileObject;
                    }
                }

                private int Offset_Irp
                {
                    get
                    {
                        if (_offset_Irp == -1)
                        {
                            _offset_Irp = Offset_FileObject + _etwEvent.AddressSize;
                        }

                        return _offset_Irp;
                    }
                }

                private int Offset_HighResResponseTime
                {
                    get
                    {
                        if (_offset_HighResResponseTime == -1)
                        {
                            _offset_HighResResponseTime = Offset_Irp + _etwEvent.AddressSize;
                        }

                        return _offset_HighResResponseTime;
                    }
                }

                private int Offset_IssuingThreadId
                {
                    get
                    {
                        if (_offset_IssuingThreadId == -1)
                        {
                            _offset_IssuingThreadId = Offset_HighResResponseTime + 8;
                        }

                        return _offset_IssuingThreadId;
                    }
                }

                /// <summary>
                /// Retrieves the DiskNumber field.
                /// </summary>
                public uint DiskNumber => BitConverter.ToUInt32(_etwEvent.Data[Offset_DiskNumber..]);

                /// <summary>
                /// Retrieves the IrpFlags field.
                /// </summary>
                public uint IrpFlags => BitConverter.ToUInt32(_etwEvent.Data[Offset_IrpFlags..]);

                /// <summary>
                /// Retrieves the TransferSize field.
                /// </summary>
                public uint TransferSize => BitConverter.ToUInt32(_etwEvent.Data[Offset_TransferSize..]);

                /// <summary>
                /// Retrieves the Reserved field.
                /// </summary>
                public uint Reserved => BitConverter.ToUInt32(_etwEvent.Data[Offset_Reserved..]);

                /// <summary>
                /// Retrieves the ByteOffset field.
                /// </summary>
                public ulong ByteOffset => BitConverter.ToUInt64(_etwEvent.Data[Offset_ByteOffset..]);

                /// <summary>
                /// Retrieves the FileObject field.
                /// </summary>
                public ulong FileObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_FileObject..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_FileObject..]);

                /// <summary>
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Retrieves the HighResResponseTime field.
                /// </summary>
                public ulong HighResResponseTime => BitConverter.ToUInt64(_etwEvent.Data[Offset_HighResResponseTime..]);

                /// <summary>
                /// Retrieves the IssuingThreadId field.
                /// </summary>
                public uint IssuingThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_IssuingThreadId..]);

                /// <summary>
                /// Creates a new OpticalWriteData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public OpticalWriteData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_DiskNumber = -1;
                    _offset_IrpFlags = -1;
                    _offset_TransferSize = -1;
                    _offset_Reserved = -1;
                    _offset_ByteOffset = -1;
                    _offset_FileObject = -1;
                    _offset_Irp = -1;
                    _offset_HighResResponseTime = -1;
                    _offset_IssuingThreadId = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a FlushBuffers event.
        /// </summary>
        public readonly ref struct FlushBuffersEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "FlushBuffers";

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
                Opcode = (EtwEventOpcode)Opcodes.FlushBuffers,
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
            public FlushBuffersData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new FlushBuffersEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public FlushBuffersEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a FlushBuffers event.
            /// </summary>
            public ref struct FlushBuffersData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_DiskNumber;
                private int _offset_IrpFlags;
                private int _offset_HighResResponseTime;
                private int _offset_Irp;
                private int _offset_IssuingThreadId;

                private int Offset_DiskNumber
                {
                    get
                    {
                        if (_offset_DiskNumber == -1)
                        {
                            _offset_DiskNumber = 0;
                        }

                        return _offset_DiskNumber;
                    }
                }

                private int Offset_IrpFlags
                {
                    get
                    {
                        if (_offset_IrpFlags == -1)
                        {
                            _offset_IrpFlags = Offset_DiskNumber + 4;
                        }

                        return _offset_IrpFlags;
                    }
                }

                private int Offset_HighResResponseTime
                {
                    get
                    {
                        if (_offset_HighResResponseTime == -1)
                        {
                            _offset_HighResResponseTime = Offset_IrpFlags + 4;
                        }

                        return _offset_HighResResponseTime;
                    }
                }

                private int Offset_Irp
                {
                    get
                    {
                        if (_offset_Irp == -1)
                        {
                            _offset_Irp = Offset_HighResResponseTime + 8;
                        }

                        return _offset_Irp;
                    }
                }

                private int Offset_IssuingThreadId
                {
                    get
                    {
                        if (_offset_IssuingThreadId == -1)
                        {
                            _offset_IssuingThreadId = Offset_Irp + _etwEvent.AddressSize;
                        }

                        return _offset_IssuingThreadId;
                    }
                }

                /// <summary>
                /// Retrieves the DiskNumber field.
                /// </summary>
                public uint DiskNumber => BitConverter.ToUInt32(_etwEvent.Data[Offset_DiskNumber..]);

                /// <summary>
                /// Retrieves the IrpFlags field.
                /// </summary>
                public uint IrpFlags => BitConverter.ToUInt32(_etwEvent.Data[Offset_IrpFlags..]);

                /// <summary>
                /// Retrieves the HighResResponseTime field.
                /// </summary>
                public ulong HighResResponseTime => BitConverter.ToUInt64(_etwEvent.Data[Offset_HighResResponseTime..]);

                /// <summary>
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Retrieves the IssuingThreadId field.
                /// </summary>
                public uint IssuingThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_IssuingThreadId..]);

                /// <summary>
                /// Creates a new FlushBuffersData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public FlushBuffersData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_DiskNumber = -1;
                    _offset_IrpFlags = -1;
                    _offset_HighResResponseTime = -1;
                    _offset_Irp = -1;
                    _offset_IssuingThreadId = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a OpticalFlushBuffers event.
        /// </summary>
        public readonly ref struct OpticalFlushBuffersEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "OpticalFlushBuffers";

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
                Opcode = (EtwEventOpcode)Opcodes.OpticalFlushBuffers,
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
            public OpticalFlushBuffersData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new OpticalFlushBuffersEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public OpticalFlushBuffersEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a OpticalFlushBuffers event.
            /// </summary>
            public ref struct OpticalFlushBuffersData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_DiskNumber;
                private int _offset_IrpFlags;
                private int _offset_HighResResponseTime;
                private int _offset_Irp;
                private int _offset_IssuingThreadId;

                private int Offset_DiskNumber
                {
                    get
                    {
                        if (_offset_DiskNumber == -1)
                        {
                            _offset_DiskNumber = 0;
                        }

                        return _offset_DiskNumber;
                    }
                }

                private int Offset_IrpFlags
                {
                    get
                    {
                        if (_offset_IrpFlags == -1)
                        {
                            _offset_IrpFlags = Offset_DiskNumber + 4;
                        }

                        return _offset_IrpFlags;
                    }
                }

                private int Offset_HighResResponseTime
                {
                    get
                    {
                        if (_offset_HighResResponseTime == -1)
                        {
                            _offset_HighResResponseTime = Offset_IrpFlags + 4;
                        }

                        return _offset_HighResResponseTime;
                    }
                }

                private int Offset_Irp
                {
                    get
                    {
                        if (_offset_Irp == -1)
                        {
                            _offset_Irp = Offset_HighResResponseTime + 8;
                        }

                        return _offset_Irp;
                    }
                }

                private int Offset_IssuingThreadId
                {
                    get
                    {
                        if (_offset_IssuingThreadId == -1)
                        {
                            _offset_IssuingThreadId = Offset_Irp + _etwEvent.AddressSize;
                        }

                        return _offset_IssuingThreadId;
                    }
                }

                /// <summary>
                /// Retrieves the DiskNumber field.
                /// </summary>
                public uint DiskNumber => BitConverter.ToUInt32(_etwEvent.Data[Offset_DiskNumber..]);

                /// <summary>
                /// Retrieves the IrpFlags field.
                /// </summary>
                public uint IrpFlags => BitConverter.ToUInt32(_etwEvent.Data[Offset_IrpFlags..]);

                /// <summary>
                /// Retrieves the HighResResponseTime field.
                /// </summary>
                public ulong HighResResponseTime => BitConverter.ToUInt64(_etwEvent.Data[Offset_HighResResponseTime..]);

                /// <summary>
                /// Retrieves the Irp field.
                /// </summary>
                public ulong Irp => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Irp..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Irp..]);

                /// <summary>
                /// Retrieves the IssuingThreadId field.
                /// </summary>
                public uint IssuingThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_IssuingThreadId..]);

                /// <summary>
                /// Creates a new OpticalFlushBuffersData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public OpticalFlushBuffersData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_DiskNumber = -1;
                    _offset_IrpFlags = -1;
                    _offset_HighResResponseTime = -1;
                    _offset_Irp = -1;
                    _offset_IssuingThreadId = -1;
                }
            }

        }
    }
}
