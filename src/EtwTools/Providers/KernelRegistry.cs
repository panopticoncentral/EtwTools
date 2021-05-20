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
    /// Provider for Kernel-Registry (ae53722e-c863-11d2-8659-00c04fa321a1)
    /// </summary>
    public sealed class KernelRegistryProvider
    {
        /// <summary>s
        /// Provider ID.
        /// </summary>
        public static readonly Guid Id = new("ae53722e-c863-11d2-8659-00c04fa321a1");

        /// <summary>
        /// Provider name.
        /// </summary>
        public const string Name = "Kernel-Registry";

        /// <summary>
        /// Opcodes supported by KernelRegistry.
        /// </summary>
        public enum Opcodes
        {
            /// <summary>
            /// 'Create' opcode.
            /// </summary>
            Create = 10,
            /// <summary>
            /// 'Open' opcode.
            /// </summary>
            Open = 11,
            /// <summary>
            /// 'Delete' opcode.
            /// </summary>
            Delete = 12,
            /// <summary>
            /// 'Query' opcode.
            /// </summary>
            Query = 13,
            /// <summary>
            /// 'SetValue' opcode.
            /// </summary>
            SetValue = 14,
            /// <summary>
            /// 'DeleteValue' opcode.
            /// </summary>
            DeleteValue = 15,
            /// <summary>
            /// 'QueryValue' opcode.
            /// </summary>
            QueryValue = 16,
            /// <summary>
            /// 'EnumerateKey' opcode.
            /// </summary>
            EnumerateKey = 17,
            /// <summary>
            /// 'EnumerateValueKey' opcode.
            /// </summary>
            EnumerateValueKey = 18,
            /// <summary>
            /// 'QueryMultipleValue' opcode.
            /// </summary>
            QueryMultipleValue = 19,
            /// <summary>
            /// 'SetInformation' opcode.
            /// </summary>
            SetInformation = 20,
            /// <summary>
            /// 'Flush' opcode.
            /// </summary>
            Flush = 21,
            /// <summary>
            /// 'RunDown' opcode.
            /// </summary>
            RunDown = 22,
            /// <summary>
            /// 'KCBDelete' opcode.
            /// </summary>
            KCBDelete = 23,
            /// <summary>
            /// 'KCBRundownBegin' opcode.
            /// </summary>
            KCBRundownBegin = 24,
            /// <summary>
            /// 'KCBRundownEnd' opcode.
            /// </summary>
            KCBRundownEnd = 25,
            /// <summary>
            /// 'Virtualize' opcode.
            /// </summary>
            Virtualize = 26,
            /// <summary>
            /// 'Close' opcode.
            /// </summary>
            Close = 27,
            /// <summary>
            /// 'SetSecurity' opcode.
            /// </summary>
            SetSecurity = 28,
            /// <summary>
            /// 'QuerySecurity' opcode.
            /// </summary>
            QuerySecurity = 29,
            /// <summary>
            /// 'TxRCommit' opcode.
            /// </summary>
            TxRCommit = 30,
            /// <summary>
            /// 'TxRPrepare' opcode.
            /// </summary>
            TxRPrepare = 31,
            /// <summary>
            /// 'TxRRollback' opcode.
            /// </summary>
            TxRRollback = 32,
            /// <summary>
            /// 'Counters' opcode.
            /// </summary>
            Counters = 34,
            /// <summary>
            /// 'Config' opcode.
            /// </summary>
            Config = 35,
            /// <summary>
            /// 'HiveInit' opcode.
            /// </summary>
            HiveInit = 36,
            /// <summary>
            /// 'HiveDestroy' opcode.
            /// </summary>
            HiveDestroy = 37,
            /// <summary>
            /// 'HiveLink' opcode.
            /// </summary>
            HiveLink = 38,
            /// <summary>
            /// 'HiveDCEnd' opcode.
            /// </summary>
            HiveDCEnd = 39,
            /// <summary>
            /// 'HiveDirty' opcode.
            /// </summary>
            HiveDirty = 40,
            /// <summary>
            /// 'ChangeNotify' opcode.
            /// </summary>
            ChangeNotify = 48,
        }

        /// <summary>
        /// An event wrapper for a Create event.
        /// </summary>
        public readonly ref struct CreateEvent
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
                Version = 0,
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
            /// Creates a new CreateEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public CreateEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a CreateEvent.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator CreateEvent(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Create event.
            /// </summary>
            public ref struct CreateData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Status;
                private int _offset_KeyHandle;
                private int _offset_ElapsedTime;
                private int _offset_KeyName;

                private int Offset_Status
                {
                    get
                    {
                        if (_offset_Status == -1)
                        {
                            _offset_Status = 0;
                        }

                        return _offset_Status;
                    }
                }

                private int Offset_KeyHandle
                {
                    get
                    {
                        if (_offset_KeyHandle == -1)
                        {
                            _offset_KeyHandle = Offset_Status + _etwEvent.AddressSize;
                        }

                        return _offset_KeyHandle;
                    }
                }

                private int Offset_ElapsedTime
                {
                    get
                    {
                        if (_offset_ElapsedTime == -1)
                        {
                            _offset_ElapsedTime = Offset_KeyHandle + _etwEvent.AddressSize;
                        }

                        return _offset_ElapsedTime;
                    }
                }

                private int Offset_KeyName
                {
                    get
                    {
                        if (_offset_KeyName == -1)
                        {
                            _offset_KeyName = Offset_ElapsedTime + 8;
                        }

                        return _offset_KeyName;
                    }
                }

                /// <summary>
                /// Retrieves the Status field.
                /// </summary>
                public ulong Status => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Status..Offset_KeyHandle]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Status..Offset_KeyHandle]);

                /// <summary>
                /// Retrieves the KeyHandle field.
                /// </summary>
                public ulong KeyHandle => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_KeyHandle..Offset_ElapsedTime]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_KeyHandle..Offset_ElapsedTime]);

                /// <summary>
                /// Retrieves the ElapsedTime field.
                /// </summary>
                public long ElapsedTime => BitConverter.ToInt64(_etwEvent.Data[Offset_ElapsedTime..Offset_KeyName]);

                /// <summary>
                /// Retrieves the KeyName field.
                /// </summary>
                public string KeyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_KeyName..]);

                /// <summary>
                /// Creates a new CreateData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public CreateData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Status = -1;
                    _offset_KeyHandle = -1;
                    _offset_ElapsedTime = -1;
                    _offset_KeyName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Open event.
        /// </summary>
        public readonly ref struct OpenEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Open";

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
                Opcode = (EtwEventOpcode)Opcodes.Open,
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
            public OpenData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new OpenEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public OpenEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a OpenEvent.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator OpenEvent(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Open event.
            /// </summary>
            public ref struct OpenData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Status;
                private int _offset_KeyHandle;
                private int _offset_ElapsedTime;
                private int _offset_KeyName;

                private int Offset_Status
                {
                    get
                    {
                        if (_offset_Status == -1)
                        {
                            _offset_Status = 0;
                        }

                        return _offset_Status;
                    }
                }

                private int Offset_KeyHandle
                {
                    get
                    {
                        if (_offset_KeyHandle == -1)
                        {
                            _offset_KeyHandle = Offset_Status + _etwEvent.AddressSize;
                        }

                        return _offset_KeyHandle;
                    }
                }

                private int Offset_ElapsedTime
                {
                    get
                    {
                        if (_offset_ElapsedTime == -1)
                        {
                            _offset_ElapsedTime = Offset_KeyHandle + _etwEvent.AddressSize;
                        }

                        return _offset_ElapsedTime;
                    }
                }

                private int Offset_KeyName
                {
                    get
                    {
                        if (_offset_KeyName == -1)
                        {
                            _offset_KeyName = Offset_ElapsedTime + 8;
                        }

                        return _offset_KeyName;
                    }
                }

                /// <summary>
                /// Retrieves the Status field.
                /// </summary>
                public ulong Status => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Status..Offset_KeyHandle]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Status..Offset_KeyHandle]);

                /// <summary>
                /// Retrieves the KeyHandle field.
                /// </summary>
                public ulong KeyHandle => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_KeyHandle..Offset_ElapsedTime]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_KeyHandle..Offset_ElapsedTime]);

                /// <summary>
                /// Retrieves the ElapsedTime field.
                /// </summary>
                public long ElapsedTime => BitConverter.ToInt64(_etwEvent.Data[Offset_ElapsedTime..Offset_KeyName]);

                /// <summary>
                /// Retrieves the KeyName field.
                /// </summary>
                public string KeyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_KeyName..]);

                /// <summary>
                /// Creates a new OpenData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public OpenData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Status = -1;
                    _offset_KeyHandle = -1;
                    _offset_ElapsedTime = -1;
                    _offset_KeyName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Delete event.
        /// </summary>
        public readonly ref struct DeleteEvent
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
                Version = 0,
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
            /// Creates a new DeleteEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DeleteEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a DeleteEvent.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator DeleteEvent(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Delete event.
            /// </summary>
            public ref struct DeleteData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Status;
                private int _offset_KeyHandle;
                private int _offset_ElapsedTime;
                private int _offset_KeyName;

                private int Offset_Status
                {
                    get
                    {
                        if (_offset_Status == -1)
                        {
                            _offset_Status = 0;
                        }

                        return _offset_Status;
                    }
                }

                private int Offset_KeyHandle
                {
                    get
                    {
                        if (_offset_KeyHandle == -1)
                        {
                            _offset_KeyHandle = Offset_Status + _etwEvent.AddressSize;
                        }

                        return _offset_KeyHandle;
                    }
                }

                private int Offset_ElapsedTime
                {
                    get
                    {
                        if (_offset_ElapsedTime == -1)
                        {
                            _offset_ElapsedTime = Offset_KeyHandle + _etwEvent.AddressSize;
                        }

                        return _offset_ElapsedTime;
                    }
                }

                private int Offset_KeyName
                {
                    get
                    {
                        if (_offset_KeyName == -1)
                        {
                            _offset_KeyName = Offset_ElapsedTime + 8;
                        }

                        return _offset_KeyName;
                    }
                }

                /// <summary>
                /// Retrieves the Status field.
                /// </summary>
                public ulong Status => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Status..Offset_KeyHandle]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Status..Offset_KeyHandle]);

                /// <summary>
                /// Retrieves the KeyHandle field.
                /// </summary>
                public ulong KeyHandle => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_KeyHandle..Offset_ElapsedTime]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_KeyHandle..Offset_ElapsedTime]);

                /// <summary>
                /// Retrieves the ElapsedTime field.
                /// </summary>
                public long ElapsedTime => BitConverter.ToInt64(_etwEvent.Data[Offset_ElapsedTime..Offset_KeyName]);

                /// <summary>
                /// Retrieves the KeyName field.
                /// </summary>
                public string KeyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_KeyName..]);

                /// <summary>
                /// Creates a new DeleteData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DeleteData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Status = -1;
                    _offset_KeyHandle = -1;
                    _offset_ElapsedTime = -1;
                    _offset_KeyName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Query event.
        /// </summary>
        public readonly ref struct QueryEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Query";

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
                Opcode = (EtwEventOpcode)Opcodes.Query,
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
            public QueryData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new QueryEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public QueryEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a QueryEvent.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator QueryEvent(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Query event.
            /// </summary>
            public ref struct QueryData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Status;
                private int _offset_KeyHandle;
                private int _offset_ElapsedTime;
                private int _offset_KeyName;

                private int Offset_Status
                {
                    get
                    {
                        if (_offset_Status == -1)
                        {
                            _offset_Status = 0;
                        }

                        return _offset_Status;
                    }
                }

                private int Offset_KeyHandle
                {
                    get
                    {
                        if (_offset_KeyHandle == -1)
                        {
                            _offset_KeyHandle = Offset_Status + _etwEvent.AddressSize;
                        }

                        return _offset_KeyHandle;
                    }
                }

                private int Offset_ElapsedTime
                {
                    get
                    {
                        if (_offset_ElapsedTime == -1)
                        {
                            _offset_ElapsedTime = Offset_KeyHandle + _etwEvent.AddressSize;
                        }

                        return _offset_ElapsedTime;
                    }
                }

                private int Offset_KeyName
                {
                    get
                    {
                        if (_offset_KeyName == -1)
                        {
                            _offset_KeyName = Offset_ElapsedTime + 8;
                        }

                        return _offset_KeyName;
                    }
                }

                /// <summary>
                /// Retrieves the Status field.
                /// </summary>
                public ulong Status => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Status..Offset_KeyHandle]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Status..Offset_KeyHandle]);

                /// <summary>
                /// Retrieves the KeyHandle field.
                /// </summary>
                public ulong KeyHandle => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_KeyHandle..Offset_ElapsedTime]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_KeyHandle..Offset_ElapsedTime]);

                /// <summary>
                /// Retrieves the ElapsedTime field.
                /// </summary>
                public long ElapsedTime => BitConverter.ToInt64(_etwEvent.Data[Offset_ElapsedTime..Offset_KeyName]);

                /// <summary>
                /// Retrieves the KeyName field.
                /// </summary>
                public string KeyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_KeyName..]);

                /// <summary>
                /// Creates a new QueryData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public QueryData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Status = -1;
                    _offset_KeyHandle = -1;
                    _offset_ElapsedTime = -1;
                    _offset_KeyName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a SetValue event.
        /// </summary>
        public readonly ref struct SetValueEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SetValue";

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
                Opcode = (EtwEventOpcode)Opcodes.SetValue,
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
            public SetValueData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new SetValueEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SetValueEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a SetValueEvent.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator SetValueEvent(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a SetValue event.
            /// </summary>
            public ref struct SetValueData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Status;
                private int _offset_KeyHandle;
                private int _offset_ElapsedTime;
                private int _offset_KeyName;

                private int Offset_Status
                {
                    get
                    {
                        if (_offset_Status == -1)
                        {
                            _offset_Status = 0;
                        }

                        return _offset_Status;
                    }
                }

                private int Offset_KeyHandle
                {
                    get
                    {
                        if (_offset_KeyHandle == -1)
                        {
                            _offset_KeyHandle = Offset_Status + _etwEvent.AddressSize;
                        }

                        return _offset_KeyHandle;
                    }
                }

                private int Offset_ElapsedTime
                {
                    get
                    {
                        if (_offset_ElapsedTime == -1)
                        {
                            _offset_ElapsedTime = Offset_KeyHandle + _etwEvent.AddressSize;
                        }

                        return _offset_ElapsedTime;
                    }
                }

                private int Offset_KeyName
                {
                    get
                    {
                        if (_offset_KeyName == -1)
                        {
                            _offset_KeyName = Offset_ElapsedTime + 8;
                        }

                        return _offset_KeyName;
                    }
                }

                /// <summary>
                /// Retrieves the Status field.
                /// </summary>
                public ulong Status => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Status..Offset_KeyHandle]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Status..Offset_KeyHandle]);

                /// <summary>
                /// Retrieves the KeyHandle field.
                /// </summary>
                public ulong KeyHandle => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_KeyHandle..Offset_ElapsedTime]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_KeyHandle..Offset_ElapsedTime]);

                /// <summary>
                /// Retrieves the ElapsedTime field.
                /// </summary>
                public long ElapsedTime => BitConverter.ToInt64(_etwEvent.Data[Offset_ElapsedTime..Offset_KeyName]);

                /// <summary>
                /// Retrieves the KeyName field.
                /// </summary>
                public string KeyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_KeyName..]);

                /// <summary>
                /// Creates a new SetValueData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public SetValueData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Status = -1;
                    _offset_KeyHandle = -1;
                    _offset_ElapsedTime = -1;
                    _offset_KeyName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DeleteValue event.
        /// </summary>
        public readonly ref struct DeleteValueEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DeleteValue";

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
                Opcode = (EtwEventOpcode)Opcodes.DeleteValue,
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
            public DeleteValueData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DeleteValueEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DeleteValueEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a DeleteValueEvent.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator DeleteValueEvent(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a DeleteValue event.
            /// </summary>
            public ref struct DeleteValueData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Status;
                private int _offset_KeyHandle;
                private int _offset_ElapsedTime;
                private int _offset_KeyName;

                private int Offset_Status
                {
                    get
                    {
                        if (_offset_Status == -1)
                        {
                            _offset_Status = 0;
                        }

                        return _offset_Status;
                    }
                }

                private int Offset_KeyHandle
                {
                    get
                    {
                        if (_offset_KeyHandle == -1)
                        {
                            _offset_KeyHandle = Offset_Status + _etwEvent.AddressSize;
                        }

                        return _offset_KeyHandle;
                    }
                }

                private int Offset_ElapsedTime
                {
                    get
                    {
                        if (_offset_ElapsedTime == -1)
                        {
                            _offset_ElapsedTime = Offset_KeyHandle + _etwEvent.AddressSize;
                        }

                        return _offset_ElapsedTime;
                    }
                }

                private int Offset_KeyName
                {
                    get
                    {
                        if (_offset_KeyName == -1)
                        {
                            _offset_KeyName = Offset_ElapsedTime + 8;
                        }

                        return _offset_KeyName;
                    }
                }

                /// <summary>
                /// Retrieves the Status field.
                /// </summary>
                public ulong Status => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Status..Offset_KeyHandle]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Status..Offset_KeyHandle]);

                /// <summary>
                /// Retrieves the KeyHandle field.
                /// </summary>
                public ulong KeyHandle => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_KeyHandle..Offset_ElapsedTime]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_KeyHandle..Offset_ElapsedTime]);

                /// <summary>
                /// Retrieves the ElapsedTime field.
                /// </summary>
                public long ElapsedTime => BitConverter.ToInt64(_etwEvent.Data[Offset_ElapsedTime..Offset_KeyName]);

                /// <summary>
                /// Retrieves the KeyName field.
                /// </summary>
                public string KeyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_KeyName..]);

                /// <summary>
                /// Creates a new DeleteValueData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DeleteValueData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Status = -1;
                    _offset_KeyHandle = -1;
                    _offset_ElapsedTime = -1;
                    _offset_KeyName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a QueryValue event.
        /// </summary>
        public readonly ref struct QueryValueEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "QueryValue";

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
                Opcode = (EtwEventOpcode)Opcodes.QueryValue,
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
            public QueryValueData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new QueryValueEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public QueryValueEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a QueryValueEvent.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator QueryValueEvent(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a QueryValue event.
            /// </summary>
            public ref struct QueryValueData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Status;
                private int _offset_KeyHandle;
                private int _offset_ElapsedTime;
                private int _offset_KeyName;

                private int Offset_Status
                {
                    get
                    {
                        if (_offset_Status == -1)
                        {
                            _offset_Status = 0;
                        }

                        return _offset_Status;
                    }
                }

                private int Offset_KeyHandle
                {
                    get
                    {
                        if (_offset_KeyHandle == -1)
                        {
                            _offset_KeyHandle = Offset_Status + _etwEvent.AddressSize;
                        }

                        return _offset_KeyHandle;
                    }
                }

                private int Offset_ElapsedTime
                {
                    get
                    {
                        if (_offset_ElapsedTime == -1)
                        {
                            _offset_ElapsedTime = Offset_KeyHandle + _etwEvent.AddressSize;
                        }

                        return _offset_ElapsedTime;
                    }
                }

                private int Offset_KeyName
                {
                    get
                    {
                        if (_offset_KeyName == -1)
                        {
                            _offset_KeyName = Offset_ElapsedTime + 8;
                        }

                        return _offset_KeyName;
                    }
                }

                /// <summary>
                /// Retrieves the Status field.
                /// </summary>
                public ulong Status => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Status..Offset_KeyHandle]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Status..Offset_KeyHandle]);

                /// <summary>
                /// Retrieves the KeyHandle field.
                /// </summary>
                public ulong KeyHandle => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_KeyHandle..Offset_ElapsedTime]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_KeyHandle..Offset_ElapsedTime]);

                /// <summary>
                /// Retrieves the ElapsedTime field.
                /// </summary>
                public long ElapsedTime => BitConverter.ToInt64(_etwEvent.Data[Offset_ElapsedTime..Offset_KeyName]);

                /// <summary>
                /// Retrieves the KeyName field.
                /// </summary>
                public string KeyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_KeyName..]);

                /// <summary>
                /// Creates a new QueryValueData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public QueryValueData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Status = -1;
                    _offset_KeyHandle = -1;
                    _offset_ElapsedTime = -1;
                    _offset_KeyName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a EnumerateKey event.
        /// </summary>
        public readonly ref struct EnumerateKeyEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "EnumerateKey";

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
                Opcode = (EtwEventOpcode)Opcodes.EnumerateKey,
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
            public EnumerateKeyData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new EnumerateKeyEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public EnumerateKeyEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a EnumerateKeyEvent.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator EnumerateKeyEvent(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a EnumerateKey event.
            /// </summary>
            public ref struct EnumerateKeyData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Status;
                private int _offset_KeyHandle;
                private int _offset_ElapsedTime;
                private int _offset_KeyName;

                private int Offset_Status
                {
                    get
                    {
                        if (_offset_Status == -1)
                        {
                            _offset_Status = 0;
                        }

                        return _offset_Status;
                    }
                }

                private int Offset_KeyHandle
                {
                    get
                    {
                        if (_offset_KeyHandle == -1)
                        {
                            _offset_KeyHandle = Offset_Status + _etwEvent.AddressSize;
                        }

                        return _offset_KeyHandle;
                    }
                }

                private int Offset_ElapsedTime
                {
                    get
                    {
                        if (_offset_ElapsedTime == -1)
                        {
                            _offset_ElapsedTime = Offset_KeyHandle + _etwEvent.AddressSize;
                        }

                        return _offset_ElapsedTime;
                    }
                }

                private int Offset_KeyName
                {
                    get
                    {
                        if (_offset_KeyName == -1)
                        {
                            _offset_KeyName = Offset_ElapsedTime + 8;
                        }

                        return _offset_KeyName;
                    }
                }

                /// <summary>
                /// Retrieves the Status field.
                /// </summary>
                public ulong Status => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Status..Offset_KeyHandle]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Status..Offset_KeyHandle]);

                /// <summary>
                /// Retrieves the KeyHandle field.
                /// </summary>
                public ulong KeyHandle => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_KeyHandle..Offset_ElapsedTime]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_KeyHandle..Offset_ElapsedTime]);

                /// <summary>
                /// Retrieves the ElapsedTime field.
                /// </summary>
                public long ElapsedTime => BitConverter.ToInt64(_etwEvent.Data[Offset_ElapsedTime..Offset_KeyName]);

                /// <summary>
                /// Retrieves the KeyName field.
                /// </summary>
                public string KeyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_KeyName..]);

                /// <summary>
                /// Creates a new EnumerateKeyData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public EnumerateKeyData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Status = -1;
                    _offset_KeyHandle = -1;
                    _offset_ElapsedTime = -1;
                    _offset_KeyName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a EnumerateValueKey event.
        /// </summary>
        public readonly ref struct EnumerateValueKeyEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "EnumerateValueKey";

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
                Opcode = (EtwEventOpcode)Opcodes.EnumerateValueKey,
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
            public EnumerateValueKeyData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new EnumerateValueKeyEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public EnumerateValueKeyEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a EnumerateValueKeyEvent.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator EnumerateValueKeyEvent(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a EnumerateValueKey event.
            /// </summary>
            public ref struct EnumerateValueKeyData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Status;
                private int _offset_KeyHandle;
                private int _offset_ElapsedTime;
                private int _offset_KeyName;

                private int Offset_Status
                {
                    get
                    {
                        if (_offset_Status == -1)
                        {
                            _offset_Status = 0;
                        }

                        return _offset_Status;
                    }
                }

                private int Offset_KeyHandle
                {
                    get
                    {
                        if (_offset_KeyHandle == -1)
                        {
                            _offset_KeyHandle = Offset_Status + _etwEvent.AddressSize;
                        }

                        return _offset_KeyHandle;
                    }
                }

                private int Offset_ElapsedTime
                {
                    get
                    {
                        if (_offset_ElapsedTime == -1)
                        {
                            _offset_ElapsedTime = Offset_KeyHandle + _etwEvent.AddressSize;
                        }

                        return _offset_ElapsedTime;
                    }
                }

                private int Offset_KeyName
                {
                    get
                    {
                        if (_offset_KeyName == -1)
                        {
                            _offset_KeyName = Offset_ElapsedTime + 8;
                        }

                        return _offset_KeyName;
                    }
                }

                /// <summary>
                /// Retrieves the Status field.
                /// </summary>
                public ulong Status => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Status..Offset_KeyHandle]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Status..Offset_KeyHandle]);

                /// <summary>
                /// Retrieves the KeyHandle field.
                /// </summary>
                public ulong KeyHandle => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_KeyHandle..Offset_ElapsedTime]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_KeyHandle..Offset_ElapsedTime]);

                /// <summary>
                /// Retrieves the ElapsedTime field.
                /// </summary>
                public long ElapsedTime => BitConverter.ToInt64(_etwEvent.Data[Offset_ElapsedTime..Offset_KeyName]);

                /// <summary>
                /// Retrieves the KeyName field.
                /// </summary>
                public string KeyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_KeyName..]);

                /// <summary>
                /// Creates a new EnumerateValueKeyData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public EnumerateValueKeyData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Status = -1;
                    _offset_KeyHandle = -1;
                    _offset_ElapsedTime = -1;
                    _offset_KeyName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a QueryMultipleValue event.
        /// </summary>
        public readonly ref struct QueryMultipleValueEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "QueryMultipleValue";

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
                Opcode = (EtwEventOpcode)Opcodes.QueryMultipleValue,
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
            public QueryMultipleValueData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new QueryMultipleValueEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public QueryMultipleValueEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a QueryMultipleValueEvent.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator QueryMultipleValueEvent(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a QueryMultipleValue event.
            /// </summary>
            public ref struct QueryMultipleValueData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Status;
                private int _offset_KeyHandle;
                private int _offset_ElapsedTime;
                private int _offset_KeyName;

                private int Offset_Status
                {
                    get
                    {
                        if (_offset_Status == -1)
                        {
                            _offset_Status = 0;
                        }

                        return _offset_Status;
                    }
                }

                private int Offset_KeyHandle
                {
                    get
                    {
                        if (_offset_KeyHandle == -1)
                        {
                            _offset_KeyHandle = Offset_Status + _etwEvent.AddressSize;
                        }

                        return _offset_KeyHandle;
                    }
                }

                private int Offset_ElapsedTime
                {
                    get
                    {
                        if (_offset_ElapsedTime == -1)
                        {
                            _offset_ElapsedTime = Offset_KeyHandle + _etwEvent.AddressSize;
                        }

                        return _offset_ElapsedTime;
                    }
                }

                private int Offset_KeyName
                {
                    get
                    {
                        if (_offset_KeyName == -1)
                        {
                            _offset_KeyName = Offset_ElapsedTime + 8;
                        }

                        return _offset_KeyName;
                    }
                }

                /// <summary>
                /// Retrieves the Status field.
                /// </summary>
                public ulong Status => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Status..Offset_KeyHandle]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Status..Offset_KeyHandle]);

                /// <summary>
                /// Retrieves the KeyHandle field.
                /// </summary>
                public ulong KeyHandle => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_KeyHandle..Offset_ElapsedTime]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_KeyHandle..Offset_ElapsedTime]);

                /// <summary>
                /// Retrieves the ElapsedTime field.
                /// </summary>
                public long ElapsedTime => BitConverter.ToInt64(_etwEvent.Data[Offset_ElapsedTime..Offset_KeyName]);

                /// <summary>
                /// Retrieves the KeyName field.
                /// </summary>
                public string KeyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_KeyName..]);

                /// <summary>
                /// Creates a new QueryMultipleValueData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public QueryMultipleValueData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Status = -1;
                    _offset_KeyHandle = -1;
                    _offset_ElapsedTime = -1;
                    _offset_KeyName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a SetInformation event.
        /// </summary>
        public readonly ref struct SetInformationEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SetInformation";

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
                Opcode = (EtwEventOpcode)Opcodes.SetInformation,
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
            public SetInformationData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new SetInformationEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SetInformationEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a SetInformationEvent.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator SetInformationEvent(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a SetInformation event.
            /// </summary>
            public ref struct SetInformationData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Status;
                private int _offset_KeyHandle;
                private int _offset_ElapsedTime;
                private int _offset_KeyName;

                private int Offset_Status
                {
                    get
                    {
                        if (_offset_Status == -1)
                        {
                            _offset_Status = 0;
                        }

                        return _offset_Status;
                    }
                }

                private int Offset_KeyHandle
                {
                    get
                    {
                        if (_offset_KeyHandle == -1)
                        {
                            _offset_KeyHandle = Offset_Status + _etwEvent.AddressSize;
                        }

                        return _offset_KeyHandle;
                    }
                }

                private int Offset_ElapsedTime
                {
                    get
                    {
                        if (_offset_ElapsedTime == -1)
                        {
                            _offset_ElapsedTime = Offset_KeyHandle + _etwEvent.AddressSize;
                        }

                        return _offset_ElapsedTime;
                    }
                }

                private int Offset_KeyName
                {
                    get
                    {
                        if (_offset_KeyName == -1)
                        {
                            _offset_KeyName = Offset_ElapsedTime + 8;
                        }

                        return _offset_KeyName;
                    }
                }

                /// <summary>
                /// Retrieves the Status field.
                /// </summary>
                public ulong Status => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Status..Offset_KeyHandle]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Status..Offset_KeyHandle]);

                /// <summary>
                /// Retrieves the KeyHandle field.
                /// </summary>
                public ulong KeyHandle => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_KeyHandle..Offset_ElapsedTime]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_KeyHandle..Offset_ElapsedTime]);

                /// <summary>
                /// Retrieves the ElapsedTime field.
                /// </summary>
                public long ElapsedTime => BitConverter.ToInt64(_etwEvent.Data[Offset_ElapsedTime..Offset_KeyName]);

                /// <summary>
                /// Retrieves the KeyName field.
                /// </summary>
                public string KeyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_KeyName..]);

                /// <summary>
                /// Creates a new SetInformationData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public SetInformationData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Status = -1;
                    _offset_KeyHandle = -1;
                    _offset_ElapsedTime = -1;
                    _offset_KeyName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Flush event.
        /// </summary>
        public readonly ref struct FlushEvent
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
                Version = 0,
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
            /// Creates a new FlushEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public FlushEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a FlushEvent.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator FlushEvent(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Flush event.
            /// </summary>
            public ref struct FlushData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Status;
                private int _offset_KeyHandle;
                private int _offset_ElapsedTime;
                private int _offset_KeyName;

                private int Offset_Status
                {
                    get
                    {
                        if (_offset_Status == -1)
                        {
                            _offset_Status = 0;
                        }

                        return _offset_Status;
                    }
                }

                private int Offset_KeyHandle
                {
                    get
                    {
                        if (_offset_KeyHandle == -1)
                        {
                            _offset_KeyHandle = Offset_Status + _etwEvent.AddressSize;
                        }

                        return _offset_KeyHandle;
                    }
                }

                private int Offset_ElapsedTime
                {
                    get
                    {
                        if (_offset_ElapsedTime == -1)
                        {
                            _offset_ElapsedTime = Offset_KeyHandle + _etwEvent.AddressSize;
                        }

                        return _offset_ElapsedTime;
                    }
                }

                private int Offset_KeyName
                {
                    get
                    {
                        if (_offset_KeyName == -1)
                        {
                            _offset_KeyName = Offset_ElapsedTime + 8;
                        }

                        return _offset_KeyName;
                    }
                }

                /// <summary>
                /// Retrieves the Status field.
                /// </summary>
                public ulong Status => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Status..Offset_KeyHandle]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Status..Offset_KeyHandle]);

                /// <summary>
                /// Retrieves the KeyHandle field.
                /// </summary>
                public ulong KeyHandle => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_KeyHandle..Offset_ElapsedTime]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_KeyHandle..Offset_ElapsedTime]);

                /// <summary>
                /// Retrieves the ElapsedTime field.
                /// </summary>
                public long ElapsedTime => BitConverter.ToInt64(_etwEvent.Data[Offset_ElapsedTime..Offset_KeyName]);

                /// <summary>
                /// Retrieves the KeyName field.
                /// </summary>
                public string KeyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_KeyName..]);

                /// <summary>
                /// Creates a new FlushData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public FlushData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Status = -1;
                    _offset_KeyHandle = -1;
                    _offset_ElapsedTime = -1;
                    _offset_KeyName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Create event.
        /// </summary>
        public readonly ref struct CreateEventV1
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
                Version = 1,
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
            /// Creates a new CreateEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public CreateEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a CreateEventV1.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator CreateEventV1(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Create event.
            /// </summary>
            public ref struct CreateData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Status;
                private int _offset_KeyHandle;
                private int _offset_ElapsedTime;
                private int _offset_Index;
                private int _offset_KeyName;

                private int Offset_Status
                {
                    get
                    {
                        if (_offset_Status == -1)
                        {
                            _offset_Status = 0;
                        }

                        return _offset_Status;
                    }
                }

                private int Offset_KeyHandle
                {
                    get
                    {
                        if (_offset_KeyHandle == -1)
                        {
                            _offset_KeyHandle = Offset_Status + _etwEvent.AddressSize;
                        }

                        return _offset_KeyHandle;
                    }
                }

                private int Offset_ElapsedTime
                {
                    get
                    {
                        if (_offset_ElapsedTime == -1)
                        {
                            _offset_ElapsedTime = Offset_KeyHandle + _etwEvent.AddressSize;
                        }

                        return _offset_ElapsedTime;
                    }
                }

                private int Offset_Index
                {
                    get
                    {
                        if (_offset_Index == -1)
                        {
                            _offset_Index = Offset_ElapsedTime + 8;
                        }

                        return _offset_Index;
                    }
                }

                private int Offset_KeyName
                {
                    get
                    {
                        if (_offset_KeyName == -1)
                        {
                            _offset_KeyName = Offset_Index + 4;
                        }

                        return _offset_KeyName;
                    }
                }

                /// <summary>
                /// Retrieves the Status field.
                /// </summary>
                public ulong Status => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Status..Offset_KeyHandle]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Status..Offset_KeyHandle]);

                /// <summary>
                /// Retrieves the KeyHandle field.
                /// </summary>
                public ulong KeyHandle => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_KeyHandle..Offset_ElapsedTime]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_KeyHandle..Offset_ElapsedTime]);

                /// <summary>
                /// Retrieves the ElapsedTime field.
                /// </summary>
                public long ElapsedTime => BitConverter.ToInt64(_etwEvent.Data[Offset_ElapsedTime..Offset_Index]);

                /// <summary>
                /// Retrieves the Index field.
                /// </summary>
                public uint Index => BitConverter.ToUInt32(_etwEvent.Data[Offset_Index..Offset_KeyName]);

                /// <summary>
                /// Retrieves the KeyName field.
                /// </summary>
                public string KeyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_KeyName..]);

                /// <summary>
                /// Creates a new CreateData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public CreateData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Status = -1;
                    _offset_KeyHandle = -1;
                    _offset_ElapsedTime = -1;
                    _offset_Index = -1;
                    _offset_KeyName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Open event.
        /// </summary>
        public readonly ref struct OpenEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Open";

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
                Opcode = (EtwEventOpcode)Opcodes.Open,
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
            public OpenData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new OpenEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public OpenEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a OpenEventV1.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator OpenEventV1(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Open event.
            /// </summary>
            public ref struct OpenData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Status;
                private int _offset_KeyHandle;
                private int _offset_ElapsedTime;
                private int _offset_Index;
                private int _offset_KeyName;

                private int Offset_Status
                {
                    get
                    {
                        if (_offset_Status == -1)
                        {
                            _offset_Status = 0;
                        }

                        return _offset_Status;
                    }
                }

                private int Offset_KeyHandle
                {
                    get
                    {
                        if (_offset_KeyHandle == -1)
                        {
                            _offset_KeyHandle = Offset_Status + _etwEvent.AddressSize;
                        }

                        return _offset_KeyHandle;
                    }
                }

                private int Offset_ElapsedTime
                {
                    get
                    {
                        if (_offset_ElapsedTime == -1)
                        {
                            _offset_ElapsedTime = Offset_KeyHandle + _etwEvent.AddressSize;
                        }

                        return _offset_ElapsedTime;
                    }
                }

                private int Offset_Index
                {
                    get
                    {
                        if (_offset_Index == -1)
                        {
                            _offset_Index = Offset_ElapsedTime + 8;
                        }

                        return _offset_Index;
                    }
                }

                private int Offset_KeyName
                {
                    get
                    {
                        if (_offset_KeyName == -1)
                        {
                            _offset_KeyName = Offset_Index + 4;
                        }

                        return _offset_KeyName;
                    }
                }

                /// <summary>
                /// Retrieves the Status field.
                /// </summary>
                public ulong Status => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Status..Offset_KeyHandle]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Status..Offset_KeyHandle]);

                /// <summary>
                /// Retrieves the KeyHandle field.
                /// </summary>
                public ulong KeyHandle => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_KeyHandle..Offset_ElapsedTime]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_KeyHandle..Offset_ElapsedTime]);

                /// <summary>
                /// Retrieves the ElapsedTime field.
                /// </summary>
                public long ElapsedTime => BitConverter.ToInt64(_etwEvent.Data[Offset_ElapsedTime..Offset_Index]);

                /// <summary>
                /// Retrieves the Index field.
                /// </summary>
                public uint Index => BitConverter.ToUInt32(_etwEvent.Data[Offset_Index..Offset_KeyName]);

                /// <summary>
                /// Retrieves the KeyName field.
                /// </summary>
                public string KeyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_KeyName..]);

                /// <summary>
                /// Creates a new OpenData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public OpenData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Status = -1;
                    _offset_KeyHandle = -1;
                    _offset_ElapsedTime = -1;
                    _offset_Index = -1;
                    _offset_KeyName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Delete event.
        /// </summary>
        public readonly ref struct DeleteEventV1
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
                Version = 1,
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
            /// Creates a new DeleteEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DeleteEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a DeleteEventV1.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator DeleteEventV1(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Delete event.
            /// </summary>
            public ref struct DeleteData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Status;
                private int _offset_KeyHandle;
                private int _offset_ElapsedTime;
                private int _offset_Index;
                private int _offset_KeyName;

                private int Offset_Status
                {
                    get
                    {
                        if (_offset_Status == -1)
                        {
                            _offset_Status = 0;
                        }

                        return _offset_Status;
                    }
                }

                private int Offset_KeyHandle
                {
                    get
                    {
                        if (_offset_KeyHandle == -1)
                        {
                            _offset_KeyHandle = Offset_Status + _etwEvent.AddressSize;
                        }

                        return _offset_KeyHandle;
                    }
                }

                private int Offset_ElapsedTime
                {
                    get
                    {
                        if (_offset_ElapsedTime == -1)
                        {
                            _offset_ElapsedTime = Offset_KeyHandle + _etwEvent.AddressSize;
                        }

                        return _offset_ElapsedTime;
                    }
                }

                private int Offset_Index
                {
                    get
                    {
                        if (_offset_Index == -1)
                        {
                            _offset_Index = Offset_ElapsedTime + 8;
                        }

                        return _offset_Index;
                    }
                }

                private int Offset_KeyName
                {
                    get
                    {
                        if (_offset_KeyName == -1)
                        {
                            _offset_KeyName = Offset_Index + 4;
                        }

                        return _offset_KeyName;
                    }
                }

                /// <summary>
                /// Retrieves the Status field.
                /// </summary>
                public ulong Status => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Status..Offset_KeyHandle]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Status..Offset_KeyHandle]);

                /// <summary>
                /// Retrieves the KeyHandle field.
                /// </summary>
                public ulong KeyHandle => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_KeyHandle..Offset_ElapsedTime]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_KeyHandle..Offset_ElapsedTime]);

                /// <summary>
                /// Retrieves the ElapsedTime field.
                /// </summary>
                public long ElapsedTime => BitConverter.ToInt64(_etwEvent.Data[Offset_ElapsedTime..Offset_Index]);

                /// <summary>
                /// Retrieves the Index field.
                /// </summary>
                public uint Index => BitConverter.ToUInt32(_etwEvent.Data[Offset_Index..Offset_KeyName]);

                /// <summary>
                /// Retrieves the KeyName field.
                /// </summary>
                public string KeyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_KeyName..]);

                /// <summary>
                /// Creates a new DeleteData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DeleteData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Status = -1;
                    _offset_KeyHandle = -1;
                    _offset_ElapsedTime = -1;
                    _offset_Index = -1;
                    _offset_KeyName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Query event.
        /// </summary>
        public readonly ref struct QueryEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Query";

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
                Opcode = (EtwEventOpcode)Opcodes.Query,
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
            public QueryData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new QueryEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public QueryEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a QueryEventV1.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator QueryEventV1(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Query event.
            /// </summary>
            public ref struct QueryData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Status;
                private int _offset_KeyHandle;
                private int _offset_ElapsedTime;
                private int _offset_Index;
                private int _offset_KeyName;

                private int Offset_Status
                {
                    get
                    {
                        if (_offset_Status == -1)
                        {
                            _offset_Status = 0;
                        }

                        return _offset_Status;
                    }
                }

                private int Offset_KeyHandle
                {
                    get
                    {
                        if (_offset_KeyHandle == -1)
                        {
                            _offset_KeyHandle = Offset_Status + _etwEvent.AddressSize;
                        }

                        return _offset_KeyHandle;
                    }
                }

                private int Offset_ElapsedTime
                {
                    get
                    {
                        if (_offset_ElapsedTime == -1)
                        {
                            _offset_ElapsedTime = Offset_KeyHandle + _etwEvent.AddressSize;
                        }

                        return _offset_ElapsedTime;
                    }
                }

                private int Offset_Index
                {
                    get
                    {
                        if (_offset_Index == -1)
                        {
                            _offset_Index = Offset_ElapsedTime + 8;
                        }

                        return _offset_Index;
                    }
                }

                private int Offset_KeyName
                {
                    get
                    {
                        if (_offset_KeyName == -1)
                        {
                            _offset_KeyName = Offset_Index + 4;
                        }

                        return _offset_KeyName;
                    }
                }

                /// <summary>
                /// Retrieves the Status field.
                /// </summary>
                public ulong Status => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Status..Offset_KeyHandle]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Status..Offset_KeyHandle]);

                /// <summary>
                /// Retrieves the KeyHandle field.
                /// </summary>
                public ulong KeyHandle => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_KeyHandle..Offset_ElapsedTime]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_KeyHandle..Offset_ElapsedTime]);

                /// <summary>
                /// Retrieves the ElapsedTime field.
                /// </summary>
                public long ElapsedTime => BitConverter.ToInt64(_etwEvent.Data[Offset_ElapsedTime..Offset_Index]);

                /// <summary>
                /// Retrieves the Index field.
                /// </summary>
                public uint Index => BitConverter.ToUInt32(_etwEvent.Data[Offset_Index..Offset_KeyName]);

                /// <summary>
                /// Retrieves the KeyName field.
                /// </summary>
                public string KeyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_KeyName..]);

                /// <summary>
                /// Creates a new QueryData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public QueryData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Status = -1;
                    _offset_KeyHandle = -1;
                    _offset_ElapsedTime = -1;
                    _offset_Index = -1;
                    _offset_KeyName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a SetValue event.
        /// </summary>
        public readonly ref struct SetValueEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SetValue";

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
                Opcode = (EtwEventOpcode)Opcodes.SetValue,
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
            public SetValueData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new SetValueEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SetValueEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a SetValueEventV1.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator SetValueEventV1(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a SetValue event.
            /// </summary>
            public ref struct SetValueData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Status;
                private int _offset_KeyHandle;
                private int _offset_ElapsedTime;
                private int _offset_Index;
                private int _offset_KeyName;

                private int Offset_Status
                {
                    get
                    {
                        if (_offset_Status == -1)
                        {
                            _offset_Status = 0;
                        }

                        return _offset_Status;
                    }
                }

                private int Offset_KeyHandle
                {
                    get
                    {
                        if (_offset_KeyHandle == -1)
                        {
                            _offset_KeyHandle = Offset_Status + _etwEvent.AddressSize;
                        }

                        return _offset_KeyHandle;
                    }
                }

                private int Offset_ElapsedTime
                {
                    get
                    {
                        if (_offset_ElapsedTime == -1)
                        {
                            _offset_ElapsedTime = Offset_KeyHandle + _etwEvent.AddressSize;
                        }

                        return _offset_ElapsedTime;
                    }
                }

                private int Offset_Index
                {
                    get
                    {
                        if (_offset_Index == -1)
                        {
                            _offset_Index = Offset_ElapsedTime + 8;
                        }

                        return _offset_Index;
                    }
                }

                private int Offset_KeyName
                {
                    get
                    {
                        if (_offset_KeyName == -1)
                        {
                            _offset_KeyName = Offset_Index + 4;
                        }

                        return _offset_KeyName;
                    }
                }

                /// <summary>
                /// Retrieves the Status field.
                /// </summary>
                public ulong Status => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Status..Offset_KeyHandle]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Status..Offset_KeyHandle]);

                /// <summary>
                /// Retrieves the KeyHandle field.
                /// </summary>
                public ulong KeyHandle => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_KeyHandle..Offset_ElapsedTime]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_KeyHandle..Offset_ElapsedTime]);

                /// <summary>
                /// Retrieves the ElapsedTime field.
                /// </summary>
                public long ElapsedTime => BitConverter.ToInt64(_etwEvent.Data[Offset_ElapsedTime..Offset_Index]);

                /// <summary>
                /// Retrieves the Index field.
                /// </summary>
                public uint Index => BitConverter.ToUInt32(_etwEvent.Data[Offset_Index..Offset_KeyName]);

                /// <summary>
                /// Retrieves the KeyName field.
                /// </summary>
                public string KeyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_KeyName..]);

                /// <summary>
                /// Creates a new SetValueData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public SetValueData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Status = -1;
                    _offset_KeyHandle = -1;
                    _offset_ElapsedTime = -1;
                    _offset_Index = -1;
                    _offset_KeyName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DeleteValue event.
        /// </summary>
        public readonly ref struct DeleteValueEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DeleteValue";

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
                Opcode = (EtwEventOpcode)Opcodes.DeleteValue,
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
            public DeleteValueData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DeleteValueEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DeleteValueEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a DeleteValueEventV1.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator DeleteValueEventV1(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a DeleteValue event.
            /// </summary>
            public ref struct DeleteValueData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Status;
                private int _offset_KeyHandle;
                private int _offset_ElapsedTime;
                private int _offset_Index;
                private int _offset_KeyName;

                private int Offset_Status
                {
                    get
                    {
                        if (_offset_Status == -1)
                        {
                            _offset_Status = 0;
                        }

                        return _offset_Status;
                    }
                }

                private int Offset_KeyHandle
                {
                    get
                    {
                        if (_offset_KeyHandle == -1)
                        {
                            _offset_KeyHandle = Offset_Status + _etwEvent.AddressSize;
                        }

                        return _offset_KeyHandle;
                    }
                }

                private int Offset_ElapsedTime
                {
                    get
                    {
                        if (_offset_ElapsedTime == -1)
                        {
                            _offset_ElapsedTime = Offset_KeyHandle + _etwEvent.AddressSize;
                        }

                        return _offset_ElapsedTime;
                    }
                }

                private int Offset_Index
                {
                    get
                    {
                        if (_offset_Index == -1)
                        {
                            _offset_Index = Offset_ElapsedTime + 8;
                        }

                        return _offset_Index;
                    }
                }

                private int Offset_KeyName
                {
                    get
                    {
                        if (_offset_KeyName == -1)
                        {
                            _offset_KeyName = Offset_Index + 4;
                        }

                        return _offset_KeyName;
                    }
                }

                /// <summary>
                /// Retrieves the Status field.
                /// </summary>
                public ulong Status => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Status..Offset_KeyHandle]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Status..Offset_KeyHandle]);

                /// <summary>
                /// Retrieves the KeyHandle field.
                /// </summary>
                public ulong KeyHandle => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_KeyHandle..Offset_ElapsedTime]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_KeyHandle..Offset_ElapsedTime]);

                /// <summary>
                /// Retrieves the ElapsedTime field.
                /// </summary>
                public long ElapsedTime => BitConverter.ToInt64(_etwEvent.Data[Offset_ElapsedTime..Offset_Index]);

                /// <summary>
                /// Retrieves the Index field.
                /// </summary>
                public uint Index => BitConverter.ToUInt32(_etwEvent.Data[Offset_Index..Offset_KeyName]);

                /// <summary>
                /// Retrieves the KeyName field.
                /// </summary>
                public string KeyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_KeyName..]);

                /// <summary>
                /// Creates a new DeleteValueData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DeleteValueData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Status = -1;
                    _offset_KeyHandle = -1;
                    _offset_ElapsedTime = -1;
                    _offset_Index = -1;
                    _offset_KeyName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a QueryValue event.
        /// </summary>
        public readonly ref struct QueryValueEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "QueryValue";

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
                Opcode = (EtwEventOpcode)Opcodes.QueryValue,
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
            public QueryValueData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new QueryValueEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public QueryValueEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a QueryValueEventV1.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator QueryValueEventV1(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a QueryValue event.
            /// </summary>
            public ref struct QueryValueData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Status;
                private int _offset_KeyHandle;
                private int _offset_ElapsedTime;
                private int _offset_Index;
                private int _offset_KeyName;

                private int Offset_Status
                {
                    get
                    {
                        if (_offset_Status == -1)
                        {
                            _offset_Status = 0;
                        }

                        return _offset_Status;
                    }
                }

                private int Offset_KeyHandle
                {
                    get
                    {
                        if (_offset_KeyHandle == -1)
                        {
                            _offset_KeyHandle = Offset_Status + _etwEvent.AddressSize;
                        }

                        return _offset_KeyHandle;
                    }
                }

                private int Offset_ElapsedTime
                {
                    get
                    {
                        if (_offset_ElapsedTime == -1)
                        {
                            _offset_ElapsedTime = Offset_KeyHandle + _etwEvent.AddressSize;
                        }

                        return _offset_ElapsedTime;
                    }
                }

                private int Offset_Index
                {
                    get
                    {
                        if (_offset_Index == -1)
                        {
                            _offset_Index = Offset_ElapsedTime + 8;
                        }

                        return _offset_Index;
                    }
                }

                private int Offset_KeyName
                {
                    get
                    {
                        if (_offset_KeyName == -1)
                        {
                            _offset_KeyName = Offset_Index + 4;
                        }

                        return _offset_KeyName;
                    }
                }

                /// <summary>
                /// Retrieves the Status field.
                /// </summary>
                public ulong Status => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Status..Offset_KeyHandle]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Status..Offset_KeyHandle]);

                /// <summary>
                /// Retrieves the KeyHandle field.
                /// </summary>
                public ulong KeyHandle => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_KeyHandle..Offset_ElapsedTime]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_KeyHandle..Offset_ElapsedTime]);

                /// <summary>
                /// Retrieves the ElapsedTime field.
                /// </summary>
                public long ElapsedTime => BitConverter.ToInt64(_etwEvent.Data[Offset_ElapsedTime..Offset_Index]);

                /// <summary>
                /// Retrieves the Index field.
                /// </summary>
                public uint Index => BitConverter.ToUInt32(_etwEvent.Data[Offset_Index..Offset_KeyName]);

                /// <summary>
                /// Retrieves the KeyName field.
                /// </summary>
                public string KeyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_KeyName..]);

                /// <summary>
                /// Creates a new QueryValueData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public QueryValueData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Status = -1;
                    _offset_KeyHandle = -1;
                    _offset_ElapsedTime = -1;
                    _offset_Index = -1;
                    _offset_KeyName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a EnumerateKey event.
        /// </summary>
        public readonly ref struct EnumerateKeyEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "EnumerateKey";

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
                Opcode = (EtwEventOpcode)Opcodes.EnumerateKey,
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
            public EnumerateKeyData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new EnumerateKeyEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public EnumerateKeyEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a EnumerateKeyEventV1.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator EnumerateKeyEventV1(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a EnumerateKey event.
            /// </summary>
            public ref struct EnumerateKeyData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Status;
                private int _offset_KeyHandle;
                private int _offset_ElapsedTime;
                private int _offset_Index;
                private int _offset_KeyName;

                private int Offset_Status
                {
                    get
                    {
                        if (_offset_Status == -1)
                        {
                            _offset_Status = 0;
                        }

                        return _offset_Status;
                    }
                }

                private int Offset_KeyHandle
                {
                    get
                    {
                        if (_offset_KeyHandle == -1)
                        {
                            _offset_KeyHandle = Offset_Status + _etwEvent.AddressSize;
                        }

                        return _offset_KeyHandle;
                    }
                }

                private int Offset_ElapsedTime
                {
                    get
                    {
                        if (_offset_ElapsedTime == -1)
                        {
                            _offset_ElapsedTime = Offset_KeyHandle + _etwEvent.AddressSize;
                        }

                        return _offset_ElapsedTime;
                    }
                }

                private int Offset_Index
                {
                    get
                    {
                        if (_offset_Index == -1)
                        {
                            _offset_Index = Offset_ElapsedTime + 8;
                        }

                        return _offset_Index;
                    }
                }

                private int Offset_KeyName
                {
                    get
                    {
                        if (_offset_KeyName == -1)
                        {
                            _offset_KeyName = Offset_Index + 4;
                        }

                        return _offset_KeyName;
                    }
                }

                /// <summary>
                /// Retrieves the Status field.
                /// </summary>
                public ulong Status => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Status..Offset_KeyHandle]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Status..Offset_KeyHandle]);

                /// <summary>
                /// Retrieves the KeyHandle field.
                /// </summary>
                public ulong KeyHandle => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_KeyHandle..Offset_ElapsedTime]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_KeyHandle..Offset_ElapsedTime]);

                /// <summary>
                /// Retrieves the ElapsedTime field.
                /// </summary>
                public long ElapsedTime => BitConverter.ToInt64(_etwEvent.Data[Offset_ElapsedTime..Offset_Index]);

                /// <summary>
                /// Retrieves the Index field.
                /// </summary>
                public uint Index => BitConverter.ToUInt32(_etwEvent.Data[Offset_Index..Offset_KeyName]);

                /// <summary>
                /// Retrieves the KeyName field.
                /// </summary>
                public string KeyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_KeyName..]);

                /// <summary>
                /// Creates a new EnumerateKeyData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public EnumerateKeyData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Status = -1;
                    _offset_KeyHandle = -1;
                    _offset_ElapsedTime = -1;
                    _offset_Index = -1;
                    _offset_KeyName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a EnumerateValueKey event.
        /// </summary>
        public readonly ref struct EnumerateValueKeyEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "EnumerateValueKey";

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
                Opcode = (EtwEventOpcode)Opcodes.EnumerateValueKey,
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
            public EnumerateValueKeyData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new EnumerateValueKeyEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public EnumerateValueKeyEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a EnumerateValueKeyEventV1.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator EnumerateValueKeyEventV1(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a EnumerateValueKey event.
            /// </summary>
            public ref struct EnumerateValueKeyData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Status;
                private int _offset_KeyHandle;
                private int _offset_ElapsedTime;
                private int _offset_Index;
                private int _offset_KeyName;

                private int Offset_Status
                {
                    get
                    {
                        if (_offset_Status == -1)
                        {
                            _offset_Status = 0;
                        }

                        return _offset_Status;
                    }
                }

                private int Offset_KeyHandle
                {
                    get
                    {
                        if (_offset_KeyHandle == -1)
                        {
                            _offset_KeyHandle = Offset_Status + _etwEvent.AddressSize;
                        }

                        return _offset_KeyHandle;
                    }
                }

                private int Offset_ElapsedTime
                {
                    get
                    {
                        if (_offset_ElapsedTime == -1)
                        {
                            _offset_ElapsedTime = Offset_KeyHandle + _etwEvent.AddressSize;
                        }

                        return _offset_ElapsedTime;
                    }
                }

                private int Offset_Index
                {
                    get
                    {
                        if (_offset_Index == -1)
                        {
                            _offset_Index = Offset_ElapsedTime + 8;
                        }

                        return _offset_Index;
                    }
                }

                private int Offset_KeyName
                {
                    get
                    {
                        if (_offset_KeyName == -1)
                        {
                            _offset_KeyName = Offset_Index + 4;
                        }

                        return _offset_KeyName;
                    }
                }

                /// <summary>
                /// Retrieves the Status field.
                /// </summary>
                public ulong Status => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Status..Offset_KeyHandle]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Status..Offset_KeyHandle]);

                /// <summary>
                /// Retrieves the KeyHandle field.
                /// </summary>
                public ulong KeyHandle => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_KeyHandle..Offset_ElapsedTime]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_KeyHandle..Offset_ElapsedTime]);

                /// <summary>
                /// Retrieves the ElapsedTime field.
                /// </summary>
                public long ElapsedTime => BitConverter.ToInt64(_etwEvent.Data[Offset_ElapsedTime..Offset_Index]);

                /// <summary>
                /// Retrieves the Index field.
                /// </summary>
                public uint Index => BitConverter.ToUInt32(_etwEvent.Data[Offset_Index..Offset_KeyName]);

                /// <summary>
                /// Retrieves the KeyName field.
                /// </summary>
                public string KeyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_KeyName..]);

                /// <summary>
                /// Creates a new EnumerateValueKeyData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public EnumerateValueKeyData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Status = -1;
                    _offset_KeyHandle = -1;
                    _offset_ElapsedTime = -1;
                    _offset_Index = -1;
                    _offset_KeyName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a QueryMultipleValue event.
        /// </summary>
        public readonly ref struct QueryMultipleValueEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "QueryMultipleValue";

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
                Opcode = (EtwEventOpcode)Opcodes.QueryMultipleValue,
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
            public QueryMultipleValueData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new QueryMultipleValueEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public QueryMultipleValueEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a QueryMultipleValueEventV1.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator QueryMultipleValueEventV1(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a QueryMultipleValue event.
            /// </summary>
            public ref struct QueryMultipleValueData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Status;
                private int _offset_KeyHandle;
                private int _offset_ElapsedTime;
                private int _offset_Index;
                private int _offset_KeyName;

                private int Offset_Status
                {
                    get
                    {
                        if (_offset_Status == -1)
                        {
                            _offset_Status = 0;
                        }

                        return _offset_Status;
                    }
                }

                private int Offset_KeyHandle
                {
                    get
                    {
                        if (_offset_KeyHandle == -1)
                        {
                            _offset_KeyHandle = Offset_Status + _etwEvent.AddressSize;
                        }

                        return _offset_KeyHandle;
                    }
                }

                private int Offset_ElapsedTime
                {
                    get
                    {
                        if (_offset_ElapsedTime == -1)
                        {
                            _offset_ElapsedTime = Offset_KeyHandle + _etwEvent.AddressSize;
                        }

                        return _offset_ElapsedTime;
                    }
                }

                private int Offset_Index
                {
                    get
                    {
                        if (_offset_Index == -1)
                        {
                            _offset_Index = Offset_ElapsedTime + 8;
                        }

                        return _offset_Index;
                    }
                }

                private int Offset_KeyName
                {
                    get
                    {
                        if (_offset_KeyName == -1)
                        {
                            _offset_KeyName = Offset_Index + 4;
                        }

                        return _offset_KeyName;
                    }
                }

                /// <summary>
                /// Retrieves the Status field.
                /// </summary>
                public ulong Status => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Status..Offset_KeyHandle]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Status..Offset_KeyHandle]);

                /// <summary>
                /// Retrieves the KeyHandle field.
                /// </summary>
                public ulong KeyHandle => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_KeyHandle..Offset_ElapsedTime]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_KeyHandle..Offset_ElapsedTime]);

                /// <summary>
                /// Retrieves the ElapsedTime field.
                /// </summary>
                public long ElapsedTime => BitConverter.ToInt64(_etwEvent.Data[Offset_ElapsedTime..Offset_Index]);

                /// <summary>
                /// Retrieves the Index field.
                /// </summary>
                public uint Index => BitConverter.ToUInt32(_etwEvent.Data[Offset_Index..Offset_KeyName]);

                /// <summary>
                /// Retrieves the KeyName field.
                /// </summary>
                public string KeyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_KeyName..]);

                /// <summary>
                /// Creates a new QueryMultipleValueData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public QueryMultipleValueData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Status = -1;
                    _offset_KeyHandle = -1;
                    _offset_ElapsedTime = -1;
                    _offset_Index = -1;
                    _offset_KeyName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a SetInformation event.
        /// </summary>
        public readonly ref struct SetInformationEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SetInformation";

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
                Opcode = (EtwEventOpcode)Opcodes.SetInformation,
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
            public SetInformationData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new SetInformationEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SetInformationEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a SetInformationEventV1.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator SetInformationEventV1(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a SetInformation event.
            /// </summary>
            public ref struct SetInformationData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Status;
                private int _offset_KeyHandle;
                private int _offset_ElapsedTime;
                private int _offset_Index;
                private int _offset_KeyName;

                private int Offset_Status
                {
                    get
                    {
                        if (_offset_Status == -1)
                        {
                            _offset_Status = 0;
                        }

                        return _offset_Status;
                    }
                }

                private int Offset_KeyHandle
                {
                    get
                    {
                        if (_offset_KeyHandle == -1)
                        {
                            _offset_KeyHandle = Offset_Status + _etwEvent.AddressSize;
                        }

                        return _offset_KeyHandle;
                    }
                }

                private int Offset_ElapsedTime
                {
                    get
                    {
                        if (_offset_ElapsedTime == -1)
                        {
                            _offset_ElapsedTime = Offset_KeyHandle + _etwEvent.AddressSize;
                        }

                        return _offset_ElapsedTime;
                    }
                }

                private int Offset_Index
                {
                    get
                    {
                        if (_offset_Index == -1)
                        {
                            _offset_Index = Offset_ElapsedTime + 8;
                        }

                        return _offset_Index;
                    }
                }

                private int Offset_KeyName
                {
                    get
                    {
                        if (_offset_KeyName == -1)
                        {
                            _offset_KeyName = Offset_Index + 4;
                        }

                        return _offset_KeyName;
                    }
                }

                /// <summary>
                /// Retrieves the Status field.
                /// </summary>
                public ulong Status => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Status..Offset_KeyHandle]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Status..Offset_KeyHandle]);

                /// <summary>
                /// Retrieves the KeyHandle field.
                /// </summary>
                public ulong KeyHandle => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_KeyHandle..Offset_ElapsedTime]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_KeyHandle..Offset_ElapsedTime]);

                /// <summary>
                /// Retrieves the ElapsedTime field.
                /// </summary>
                public long ElapsedTime => BitConverter.ToInt64(_etwEvent.Data[Offset_ElapsedTime..Offset_Index]);

                /// <summary>
                /// Retrieves the Index field.
                /// </summary>
                public uint Index => BitConverter.ToUInt32(_etwEvent.Data[Offset_Index..Offset_KeyName]);

                /// <summary>
                /// Retrieves the KeyName field.
                /// </summary>
                public string KeyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_KeyName..]);

                /// <summary>
                /// Creates a new SetInformationData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public SetInformationData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Status = -1;
                    _offset_KeyHandle = -1;
                    _offset_ElapsedTime = -1;
                    _offset_Index = -1;
                    _offset_KeyName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Flush event.
        /// </summary>
        public readonly ref struct FlushEventV1
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
                Version = 1,
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
            /// Creates a new FlushEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public FlushEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a FlushEventV1.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator FlushEventV1(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Flush event.
            /// </summary>
            public ref struct FlushData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Status;
                private int _offset_KeyHandle;
                private int _offset_ElapsedTime;
                private int _offset_Index;
                private int _offset_KeyName;

                private int Offset_Status
                {
                    get
                    {
                        if (_offset_Status == -1)
                        {
                            _offset_Status = 0;
                        }

                        return _offset_Status;
                    }
                }

                private int Offset_KeyHandle
                {
                    get
                    {
                        if (_offset_KeyHandle == -1)
                        {
                            _offset_KeyHandle = Offset_Status + _etwEvent.AddressSize;
                        }

                        return _offset_KeyHandle;
                    }
                }

                private int Offset_ElapsedTime
                {
                    get
                    {
                        if (_offset_ElapsedTime == -1)
                        {
                            _offset_ElapsedTime = Offset_KeyHandle + _etwEvent.AddressSize;
                        }

                        return _offset_ElapsedTime;
                    }
                }

                private int Offset_Index
                {
                    get
                    {
                        if (_offset_Index == -1)
                        {
                            _offset_Index = Offset_ElapsedTime + 8;
                        }

                        return _offset_Index;
                    }
                }

                private int Offset_KeyName
                {
                    get
                    {
                        if (_offset_KeyName == -1)
                        {
                            _offset_KeyName = Offset_Index + 4;
                        }

                        return _offset_KeyName;
                    }
                }

                /// <summary>
                /// Retrieves the Status field.
                /// </summary>
                public ulong Status => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Status..Offset_KeyHandle]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Status..Offset_KeyHandle]);

                /// <summary>
                /// Retrieves the KeyHandle field.
                /// </summary>
                public ulong KeyHandle => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_KeyHandle..Offset_ElapsedTime]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_KeyHandle..Offset_ElapsedTime]);

                /// <summary>
                /// Retrieves the ElapsedTime field.
                /// </summary>
                public long ElapsedTime => BitConverter.ToInt64(_etwEvent.Data[Offset_ElapsedTime..Offset_Index]);

                /// <summary>
                /// Retrieves the Index field.
                /// </summary>
                public uint Index => BitConverter.ToUInt32(_etwEvent.Data[Offset_Index..Offset_KeyName]);

                /// <summary>
                /// Retrieves the KeyName field.
                /// </summary>
                public string KeyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_KeyName..]);

                /// <summary>
                /// Creates a new FlushData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public FlushData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Status = -1;
                    _offset_KeyHandle = -1;
                    _offset_ElapsedTime = -1;
                    _offset_Index = -1;
                    _offset_KeyName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a RunDown event.
        /// </summary>
        public readonly ref struct RunDownEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "RunDown";

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
                Opcode = (EtwEventOpcode)Opcodes.RunDown,
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
            public RunDownData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new RunDownEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public RunDownEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a RunDownEventV1.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator RunDownEventV1(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a RunDown event.
            /// </summary>
            public ref struct RunDownData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Status;
                private int _offset_KeyHandle;
                private int _offset_ElapsedTime;
                private int _offset_Index;
                private int _offset_KeyName;

                private int Offset_Status
                {
                    get
                    {
                        if (_offset_Status == -1)
                        {
                            _offset_Status = 0;
                        }

                        return _offset_Status;
                    }
                }

                private int Offset_KeyHandle
                {
                    get
                    {
                        if (_offset_KeyHandle == -1)
                        {
                            _offset_KeyHandle = Offset_Status + _etwEvent.AddressSize;
                        }

                        return _offset_KeyHandle;
                    }
                }

                private int Offset_ElapsedTime
                {
                    get
                    {
                        if (_offset_ElapsedTime == -1)
                        {
                            _offset_ElapsedTime = Offset_KeyHandle + _etwEvent.AddressSize;
                        }

                        return _offset_ElapsedTime;
                    }
                }

                private int Offset_Index
                {
                    get
                    {
                        if (_offset_Index == -1)
                        {
                            _offset_Index = Offset_ElapsedTime + 8;
                        }

                        return _offset_Index;
                    }
                }

                private int Offset_KeyName
                {
                    get
                    {
                        if (_offset_KeyName == -1)
                        {
                            _offset_KeyName = Offset_Index + 4;
                        }

                        return _offset_KeyName;
                    }
                }

                /// <summary>
                /// Retrieves the Status field.
                /// </summary>
                public ulong Status => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Status..Offset_KeyHandle]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Status..Offset_KeyHandle]);

                /// <summary>
                /// Retrieves the KeyHandle field.
                /// </summary>
                public ulong KeyHandle => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_KeyHandle..Offset_ElapsedTime]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_KeyHandle..Offset_ElapsedTime]);

                /// <summary>
                /// Retrieves the ElapsedTime field.
                /// </summary>
                public long ElapsedTime => BitConverter.ToInt64(_etwEvent.Data[Offset_ElapsedTime..Offset_Index]);

                /// <summary>
                /// Retrieves the Index field.
                /// </summary>
                public uint Index => BitConverter.ToUInt32(_etwEvent.Data[Offset_Index..Offset_KeyName]);

                /// <summary>
                /// Retrieves the KeyName field.
                /// </summary>
                public string KeyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_KeyName..]);

                /// <summary>
                /// Creates a new RunDownData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public RunDownData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Status = -1;
                    _offset_KeyHandle = -1;
                    _offset_ElapsedTime = -1;
                    _offset_Index = -1;
                    _offset_KeyName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a HiveDirty event.
        /// </summary>
        public readonly ref struct HiveDirtyEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "HiveDirty";

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
                Opcode = (EtwEventOpcode)Opcodes.HiveDirty,
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
            public HiveDirtyData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new HiveDirtyEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public HiveDirtyEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a HiveDirtyEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator HiveDirtyEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a HiveDirty event.
            /// </summary>
            public ref struct HiveDirtyData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Hive;
                private int _offset_LinkPath;
                private int _offset_DirtyReason;

                private int Offset_Hive
                {
                    get
                    {
                        if (_offset_Hive == -1)
                        {
                            _offset_Hive = 0;
                        }

                        return _offset_Hive;
                    }
                }

                private int Offset_LinkPath
                {
                    get
                    {
                        if (_offset_LinkPath == -1)
                        {
                            _offset_LinkPath = Offset_Hive + _etwEvent.AddressSize;
                        }

                        return _offset_LinkPath;
                    }
                }

                private int Offset_DirtyReason
                {
                    get
                    {
                        if (_offset_DirtyReason == -1)
                        {
                            _offset_DirtyReason = Offset_LinkPath + _etwEvent.UnicodeStringLength(Offset_LinkPath);
                        }

                        return _offset_DirtyReason;
                    }
                }

                /// <summary>
                /// Retrieves the Hive field.
                /// </summary>
                public ulong Hive => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Hive..Offset_LinkPath]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Hive..Offset_LinkPath]);

                /// <summary>
                /// Retrieves the LinkPath field.
                /// </summary>
                public string LinkPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_LinkPath..Offset_DirtyReason]);

                /// <summary>
                /// Retrieves the DirtyReason field.
                /// </summary>
                public uint DirtyReason => BitConverter.ToUInt32(_etwEvent.Data[Offset_DirtyReason..]);

                /// <summary>
                /// Creates a new HiveDirtyData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public HiveDirtyData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Hive = -1;
                    _offset_LinkPath = -1;
                    _offset_DirtyReason = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Config event.
        /// </summary>
        public readonly ref struct ConfigEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Config";

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
                Opcode = (EtwEventOpcode)Opcodes.Config,
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
            public ConfigData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ConfigEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ConfigEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a ConfigEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator ConfigEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Config event.
            /// </summary>
            public ref struct ConfigData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_CurrentControlSet;

                private int Offset_CurrentControlSet
                {
                    get
                    {
                        if (_offset_CurrentControlSet == -1)
                        {
                            _offset_CurrentControlSet = 0;
                        }

                        return _offset_CurrentControlSet;
                    }
                }

                /// <summary>
                /// Retrieves the CurrentControlSet field.
                /// </summary>
                public uint CurrentControlSet => BitConverter.ToUInt32(_etwEvent.Data[Offset_CurrentControlSet..]);

                /// <summary>
                /// Creates a new ConfigData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ConfigData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_CurrentControlSet = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a HiveDestroy event.
        /// </summary>
        public readonly ref struct HiveDestroyEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "HiveDestroy";

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
                Opcode = (EtwEventOpcode)Opcodes.HiveDestroy,
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
            public HiveDestroyData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new HiveDestroyEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public HiveDestroyEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a HiveDestroyEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator HiveDestroyEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a HiveDestroy event.
            /// </summary>
            public ref struct HiveDestroyData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Hive;
                private int _offset_FileName;
                private int _offset_Path;

                private int Offset_Hive
                {
                    get
                    {
                        if (_offset_Hive == -1)
                        {
                            _offset_Hive = 0;
                        }

                        return _offset_Hive;
                    }
                }

                private int Offset_FileName
                {
                    get
                    {
                        if (_offset_FileName == -1)
                        {
                            _offset_FileName = Offset_Hive + _etwEvent.AddressSize;
                        }

                        return _offset_FileName;
                    }
                }

                private int Offset_Path
                {
                    get
                    {
                        if (_offset_Path == -1)
                        {
                            _offset_Path = Offset_FileName + _etwEvent.UnicodeStringLength(Offset_FileName);
                        }

                        return _offset_Path;
                    }
                }

                /// <summary>
                /// Retrieves the Hive field.
                /// </summary>
                public ulong Hive => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Hive..Offset_FileName]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Hive..Offset_FileName]);

                /// <summary>
                /// Retrieves the FileName field.
                /// </summary>
                public string FileName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FileName..Offset_Path]);

                /// <summary>
                /// Retrieves the Path field.
                /// </summary>
                public string Path => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Path..]);

                /// <summary>
                /// Creates a new HiveDestroyData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public HiveDestroyData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Hive = -1;
                    _offset_FileName = -1;
                    _offset_Path = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Counters event.
        /// </summary>
        public readonly ref struct CountersEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Counters";

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
                Opcode = (EtwEventOpcode)Opcodes.Counters,
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
            public CountersData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new CountersEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public CountersEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a CountersEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator CountersEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Counters event.
            /// </summary>
            public ref struct CountersData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Counter1;
                private int _offset_Counter2;
                private int _offset_Counter3;
                private int _offset_Counter4;
                private int _offset_Counter5;
                private int _offset_Counter6;
                private int _offset_Counter7;
                private int _offset_Counter8;
                private int _offset_Counter9;
                private int _offset_Counter10;
                private int _offset_Counter11;

                private int Offset_Counter1
                {
                    get
                    {
                        if (_offset_Counter1 == -1)
                        {
                            _offset_Counter1 = 0;
                        }

                        return _offset_Counter1;
                    }
                }

                private int Offset_Counter2
                {
                    get
                    {
                        if (_offset_Counter2 == -1)
                        {
                            _offset_Counter2 = Offset_Counter1 + 8;
                        }

                        return _offset_Counter2;
                    }
                }

                private int Offset_Counter3
                {
                    get
                    {
                        if (_offset_Counter3 == -1)
                        {
                            _offset_Counter3 = Offset_Counter2 + 8;
                        }

                        return _offset_Counter3;
                    }
                }

                private int Offset_Counter4
                {
                    get
                    {
                        if (_offset_Counter4 == -1)
                        {
                            _offset_Counter4 = Offset_Counter3 + 8;
                        }

                        return _offset_Counter4;
                    }
                }

                private int Offset_Counter5
                {
                    get
                    {
                        if (_offset_Counter5 == -1)
                        {
                            _offset_Counter5 = Offset_Counter4 + 8;
                        }

                        return _offset_Counter5;
                    }
                }

                private int Offset_Counter6
                {
                    get
                    {
                        if (_offset_Counter6 == -1)
                        {
                            _offset_Counter6 = Offset_Counter5 + 8;
                        }

                        return _offset_Counter6;
                    }
                }

                private int Offset_Counter7
                {
                    get
                    {
                        if (_offset_Counter7 == -1)
                        {
                            _offset_Counter7 = Offset_Counter6 + 8;
                        }

                        return _offset_Counter7;
                    }
                }

                private int Offset_Counter8
                {
                    get
                    {
                        if (_offset_Counter8 == -1)
                        {
                            _offset_Counter8 = Offset_Counter7 + 8;
                        }

                        return _offset_Counter8;
                    }
                }

                private int Offset_Counter9
                {
                    get
                    {
                        if (_offset_Counter9 == -1)
                        {
                            _offset_Counter9 = Offset_Counter8 + 8;
                        }

                        return _offset_Counter9;
                    }
                }

                private int Offset_Counter10
                {
                    get
                    {
                        if (_offset_Counter10 == -1)
                        {
                            _offset_Counter10 = Offset_Counter9 + 8;
                        }

                        return _offset_Counter10;
                    }
                }

                private int Offset_Counter11
                {
                    get
                    {
                        if (_offset_Counter11 == -1)
                        {
                            _offset_Counter11 = Offset_Counter10 + 8;
                        }

                        return _offset_Counter11;
                    }
                }

                /// <summary>
                /// Retrieves the Counter1 field.
                /// </summary>
                public ulong Counter1 => BitConverter.ToUInt64(_etwEvent.Data[Offset_Counter1..Offset_Counter2]);

                /// <summary>
                /// Retrieves the Counter2 field.
                /// </summary>
                public ulong Counter2 => BitConverter.ToUInt64(_etwEvent.Data[Offset_Counter2..Offset_Counter3]);

                /// <summary>
                /// Retrieves the Counter3 field.
                /// </summary>
                public ulong Counter3 => BitConverter.ToUInt64(_etwEvent.Data[Offset_Counter3..Offset_Counter4]);

                /// <summary>
                /// Retrieves the Counter4 field.
                /// </summary>
                public ulong Counter4 => BitConverter.ToUInt64(_etwEvent.Data[Offset_Counter4..Offset_Counter5]);

                /// <summary>
                /// Retrieves the Counter5 field.
                /// </summary>
                public ulong Counter5 => BitConverter.ToUInt64(_etwEvent.Data[Offset_Counter5..Offset_Counter6]);

                /// <summary>
                /// Retrieves the Counter6 field.
                /// </summary>
                public ulong Counter6 => BitConverter.ToUInt64(_etwEvent.Data[Offset_Counter6..Offset_Counter7]);

                /// <summary>
                /// Retrieves the Counter7 field.
                /// </summary>
                public ulong Counter7 => BitConverter.ToUInt64(_etwEvent.Data[Offset_Counter7..Offset_Counter8]);

                /// <summary>
                /// Retrieves the Counter8 field.
                /// </summary>
                public ulong Counter8 => BitConverter.ToUInt64(_etwEvent.Data[Offset_Counter8..Offset_Counter9]);

                /// <summary>
                /// Retrieves the Counter9 field.
                /// </summary>
                public ulong Counter9 => BitConverter.ToUInt64(_etwEvent.Data[Offset_Counter9..Offset_Counter10]);

                /// <summary>
                /// Retrieves the Counter10 field.
                /// </summary>
                public ulong Counter10 => BitConverter.ToUInt64(_etwEvent.Data[Offset_Counter10..Offset_Counter11]);

                /// <summary>
                /// Retrieves the Counter11 field.
                /// </summary>
                public ulong Counter11 => BitConverter.ToUInt64(_etwEvent.Data[Offset_Counter11..]);

                /// <summary>
                /// Creates a new CountersData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public CountersData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Counter1 = -1;
                    _offset_Counter2 = -1;
                    _offset_Counter3 = -1;
                    _offset_Counter4 = -1;
                    _offset_Counter5 = -1;
                    _offset_Counter6 = -1;
                    _offset_Counter7 = -1;
                    _offset_Counter8 = -1;
                    _offset_Counter9 = -1;
                    _offset_Counter10 = -1;
                    _offset_Counter11 = -1;
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

                private int _offset_InitialTime;
                private int _offset_Status;
                private int _offset_Index;
                private int _offset_KeyHandle;
                private int _offset_KeyName;

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

                private int Offset_Status
                {
                    get
                    {
                        if (_offset_Status == -1)
                        {
                            _offset_Status = Offset_InitialTime + 8;
                        }

                        return _offset_Status;
                    }
                }

                private int Offset_Index
                {
                    get
                    {
                        if (_offset_Index == -1)
                        {
                            _offset_Index = Offset_Status + 4;
                        }

                        return _offset_Index;
                    }
                }

                private int Offset_KeyHandle
                {
                    get
                    {
                        if (_offset_KeyHandle == -1)
                        {
                            _offset_KeyHandle = Offset_Index + 4;
                        }

                        return _offset_KeyHandle;
                    }
                }

                private int Offset_KeyName
                {
                    get
                    {
                        if (_offset_KeyName == -1)
                        {
                            _offset_KeyName = Offset_KeyHandle + _etwEvent.AddressSize;
                        }

                        return _offset_KeyName;
                    }
                }

                /// <summary>
                /// Retrieves the InitialTime field.
                /// </summary>
                public long InitialTime => BitConverter.ToInt64(_etwEvent.Data[Offset_InitialTime..Offset_Status]);

                /// <summary>
                /// Retrieves the Status field.
                /// </summary>
                public uint Status => BitConverter.ToUInt32(_etwEvent.Data[Offset_Status..Offset_Index]);

                /// <summary>
                /// Retrieves the Index field.
                /// </summary>
                public uint Index => BitConverter.ToUInt32(_etwEvent.Data[Offset_Index..Offset_KeyHandle]);

                /// <summary>
                /// Retrieves the KeyHandle field.
                /// </summary>
                public ulong KeyHandle => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_KeyHandle..Offset_KeyName]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_KeyHandle..Offset_KeyName]);

                /// <summary>
                /// Retrieves the KeyName field.
                /// </summary>
                public string KeyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_KeyName..]);

                /// <summary>
                /// Creates a new CreateData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public CreateData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_InitialTime = -1;
                    _offset_Status = -1;
                    _offset_Index = -1;
                    _offset_KeyHandle = -1;
                    _offset_KeyName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Open event.
        /// </summary>
        public readonly ref struct OpenEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Open";

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
                Opcode = (EtwEventOpcode)Opcodes.Open,
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
            public OpenData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new OpenEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public OpenEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a OpenEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator OpenEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Open event.
            /// </summary>
            public ref struct OpenData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_InitialTime;
                private int _offset_Status;
                private int _offset_Index;
                private int _offset_KeyHandle;
                private int _offset_KeyName;

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

                private int Offset_Status
                {
                    get
                    {
                        if (_offset_Status == -1)
                        {
                            _offset_Status = Offset_InitialTime + 8;
                        }

                        return _offset_Status;
                    }
                }

                private int Offset_Index
                {
                    get
                    {
                        if (_offset_Index == -1)
                        {
                            _offset_Index = Offset_Status + 4;
                        }

                        return _offset_Index;
                    }
                }

                private int Offset_KeyHandle
                {
                    get
                    {
                        if (_offset_KeyHandle == -1)
                        {
                            _offset_KeyHandle = Offset_Index + 4;
                        }

                        return _offset_KeyHandle;
                    }
                }

                private int Offset_KeyName
                {
                    get
                    {
                        if (_offset_KeyName == -1)
                        {
                            _offset_KeyName = Offset_KeyHandle + _etwEvent.AddressSize;
                        }

                        return _offset_KeyName;
                    }
                }

                /// <summary>
                /// Retrieves the InitialTime field.
                /// </summary>
                public long InitialTime => BitConverter.ToInt64(_etwEvent.Data[Offset_InitialTime..Offset_Status]);

                /// <summary>
                /// Retrieves the Status field.
                /// </summary>
                public uint Status => BitConverter.ToUInt32(_etwEvent.Data[Offset_Status..Offset_Index]);

                /// <summary>
                /// Retrieves the Index field.
                /// </summary>
                public uint Index => BitConverter.ToUInt32(_etwEvent.Data[Offset_Index..Offset_KeyHandle]);

                /// <summary>
                /// Retrieves the KeyHandle field.
                /// </summary>
                public ulong KeyHandle => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_KeyHandle..Offset_KeyName]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_KeyHandle..Offset_KeyName]);

                /// <summary>
                /// Retrieves the KeyName field.
                /// </summary>
                public string KeyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_KeyName..]);

                /// <summary>
                /// Creates a new OpenData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public OpenData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_InitialTime = -1;
                    _offset_Status = -1;
                    _offset_Index = -1;
                    _offset_KeyHandle = -1;
                    _offset_KeyName = -1;
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

                private int _offset_InitialTime;
                private int _offset_Status;
                private int _offset_Index;
                private int _offset_KeyHandle;
                private int _offset_KeyName;

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

                private int Offset_Status
                {
                    get
                    {
                        if (_offset_Status == -1)
                        {
                            _offset_Status = Offset_InitialTime + 8;
                        }

                        return _offset_Status;
                    }
                }

                private int Offset_Index
                {
                    get
                    {
                        if (_offset_Index == -1)
                        {
                            _offset_Index = Offset_Status + 4;
                        }

                        return _offset_Index;
                    }
                }

                private int Offset_KeyHandle
                {
                    get
                    {
                        if (_offset_KeyHandle == -1)
                        {
                            _offset_KeyHandle = Offset_Index + 4;
                        }

                        return _offset_KeyHandle;
                    }
                }

                private int Offset_KeyName
                {
                    get
                    {
                        if (_offset_KeyName == -1)
                        {
                            _offset_KeyName = Offset_KeyHandle + _etwEvent.AddressSize;
                        }

                        return _offset_KeyName;
                    }
                }

                /// <summary>
                /// Retrieves the InitialTime field.
                /// </summary>
                public long InitialTime => BitConverter.ToInt64(_etwEvent.Data[Offset_InitialTime..Offset_Status]);

                /// <summary>
                /// Retrieves the Status field.
                /// </summary>
                public uint Status => BitConverter.ToUInt32(_etwEvent.Data[Offset_Status..Offset_Index]);

                /// <summary>
                /// Retrieves the Index field.
                /// </summary>
                public uint Index => BitConverter.ToUInt32(_etwEvent.Data[Offset_Index..Offset_KeyHandle]);

                /// <summary>
                /// Retrieves the KeyHandle field.
                /// </summary>
                public ulong KeyHandle => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_KeyHandle..Offset_KeyName]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_KeyHandle..Offset_KeyName]);

                /// <summary>
                /// Retrieves the KeyName field.
                /// </summary>
                public string KeyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_KeyName..]);

                /// <summary>
                /// Creates a new DeleteData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DeleteData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_InitialTime = -1;
                    _offset_Status = -1;
                    _offset_Index = -1;
                    _offset_KeyHandle = -1;
                    _offset_KeyName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Query event.
        /// </summary>
        public readonly ref struct QueryEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Query";

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
                Opcode = (EtwEventOpcode)Opcodes.Query,
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
            public QueryData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new QueryEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public QueryEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a QueryEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator QueryEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Query event.
            /// </summary>
            public ref struct QueryData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_InitialTime;
                private int _offset_Status;
                private int _offset_Index;
                private int _offset_KeyHandle;
                private int _offset_KeyName;

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

                private int Offset_Status
                {
                    get
                    {
                        if (_offset_Status == -1)
                        {
                            _offset_Status = Offset_InitialTime + 8;
                        }

                        return _offset_Status;
                    }
                }

                private int Offset_Index
                {
                    get
                    {
                        if (_offset_Index == -1)
                        {
                            _offset_Index = Offset_Status + 4;
                        }

                        return _offset_Index;
                    }
                }

                private int Offset_KeyHandle
                {
                    get
                    {
                        if (_offset_KeyHandle == -1)
                        {
                            _offset_KeyHandle = Offset_Index + 4;
                        }

                        return _offset_KeyHandle;
                    }
                }

                private int Offset_KeyName
                {
                    get
                    {
                        if (_offset_KeyName == -1)
                        {
                            _offset_KeyName = Offset_KeyHandle + _etwEvent.AddressSize;
                        }

                        return _offset_KeyName;
                    }
                }

                /// <summary>
                /// Retrieves the InitialTime field.
                /// </summary>
                public long InitialTime => BitConverter.ToInt64(_etwEvent.Data[Offset_InitialTime..Offset_Status]);

                /// <summary>
                /// Retrieves the Status field.
                /// </summary>
                public uint Status => BitConverter.ToUInt32(_etwEvent.Data[Offset_Status..Offset_Index]);

                /// <summary>
                /// Retrieves the Index field.
                /// </summary>
                public uint Index => BitConverter.ToUInt32(_etwEvent.Data[Offset_Index..Offset_KeyHandle]);

                /// <summary>
                /// Retrieves the KeyHandle field.
                /// </summary>
                public ulong KeyHandle => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_KeyHandle..Offset_KeyName]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_KeyHandle..Offset_KeyName]);

                /// <summary>
                /// Retrieves the KeyName field.
                /// </summary>
                public string KeyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_KeyName..]);

                /// <summary>
                /// Creates a new QueryData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public QueryData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_InitialTime = -1;
                    _offset_Status = -1;
                    _offset_Index = -1;
                    _offset_KeyHandle = -1;
                    _offset_KeyName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a SetValue event.
        /// </summary>
        public readonly ref struct SetValueEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SetValue";

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
                Opcode = (EtwEventOpcode)Opcodes.SetValue,
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
            public SetValueData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new SetValueEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SetValueEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a SetValueEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator SetValueEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a SetValue event.
            /// </summary>
            public ref struct SetValueData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_InitialTime;
                private int _offset_Status;
                private int _offset_Index;
                private int _offset_KeyHandle;
                private int _offset_KeyName;

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

                private int Offset_Status
                {
                    get
                    {
                        if (_offset_Status == -1)
                        {
                            _offset_Status = Offset_InitialTime + 8;
                        }

                        return _offset_Status;
                    }
                }

                private int Offset_Index
                {
                    get
                    {
                        if (_offset_Index == -1)
                        {
                            _offset_Index = Offset_Status + 4;
                        }

                        return _offset_Index;
                    }
                }

                private int Offset_KeyHandle
                {
                    get
                    {
                        if (_offset_KeyHandle == -1)
                        {
                            _offset_KeyHandle = Offset_Index + 4;
                        }

                        return _offset_KeyHandle;
                    }
                }

                private int Offset_KeyName
                {
                    get
                    {
                        if (_offset_KeyName == -1)
                        {
                            _offset_KeyName = Offset_KeyHandle + _etwEvent.AddressSize;
                        }

                        return _offset_KeyName;
                    }
                }

                /// <summary>
                /// Retrieves the InitialTime field.
                /// </summary>
                public long InitialTime => BitConverter.ToInt64(_etwEvent.Data[Offset_InitialTime..Offset_Status]);

                /// <summary>
                /// Retrieves the Status field.
                /// </summary>
                public uint Status => BitConverter.ToUInt32(_etwEvent.Data[Offset_Status..Offset_Index]);

                /// <summary>
                /// Retrieves the Index field.
                /// </summary>
                public uint Index => BitConverter.ToUInt32(_etwEvent.Data[Offset_Index..Offset_KeyHandle]);

                /// <summary>
                /// Retrieves the KeyHandle field.
                /// </summary>
                public ulong KeyHandle => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_KeyHandle..Offset_KeyName]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_KeyHandle..Offset_KeyName]);

                /// <summary>
                /// Retrieves the KeyName field.
                /// </summary>
                public string KeyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_KeyName..]);

                /// <summary>
                /// Creates a new SetValueData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public SetValueData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_InitialTime = -1;
                    _offset_Status = -1;
                    _offset_Index = -1;
                    _offset_KeyHandle = -1;
                    _offset_KeyName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DeleteValue event.
        /// </summary>
        public readonly ref struct DeleteValueEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DeleteValue";

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
                Opcode = (EtwEventOpcode)Opcodes.DeleteValue,
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
            public DeleteValueData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DeleteValueEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DeleteValueEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a DeleteValueEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator DeleteValueEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a DeleteValue event.
            /// </summary>
            public ref struct DeleteValueData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_InitialTime;
                private int _offset_Status;
                private int _offset_Index;
                private int _offset_KeyHandle;
                private int _offset_KeyName;

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

                private int Offset_Status
                {
                    get
                    {
                        if (_offset_Status == -1)
                        {
                            _offset_Status = Offset_InitialTime + 8;
                        }

                        return _offset_Status;
                    }
                }

                private int Offset_Index
                {
                    get
                    {
                        if (_offset_Index == -1)
                        {
                            _offset_Index = Offset_Status + 4;
                        }

                        return _offset_Index;
                    }
                }

                private int Offset_KeyHandle
                {
                    get
                    {
                        if (_offset_KeyHandle == -1)
                        {
                            _offset_KeyHandle = Offset_Index + 4;
                        }

                        return _offset_KeyHandle;
                    }
                }

                private int Offset_KeyName
                {
                    get
                    {
                        if (_offset_KeyName == -1)
                        {
                            _offset_KeyName = Offset_KeyHandle + _etwEvent.AddressSize;
                        }

                        return _offset_KeyName;
                    }
                }

                /// <summary>
                /// Retrieves the InitialTime field.
                /// </summary>
                public long InitialTime => BitConverter.ToInt64(_etwEvent.Data[Offset_InitialTime..Offset_Status]);

                /// <summary>
                /// Retrieves the Status field.
                /// </summary>
                public uint Status => BitConverter.ToUInt32(_etwEvent.Data[Offset_Status..Offset_Index]);

                /// <summary>
                /// Retrieves the Index field.
                /// </summary>
                public uint Index => BitConverter.ToUInt32(_etwEvent.Data[Offset_Index..Offset_KeyHandle]);

                /// <summary>
                /// Retrieves the KeyHandle field.
                /// </summary>
                public ulong KeyHandle => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_KeyHandle..Offset_KeyName]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_KeyHandle..Offset_KeyName]);

                /// <summary>
                /// Retrieves the KeyName field.
                /// </summary>
                public string KeyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_KeyName..]);

                /// <summary>
                /// Creates a new DeleteValueData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DeleteValueData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_InitialTime = -1;
                    _offset_Status = -1;
                    _offset_Index = -1;
                    _offset_KeyHandle = -1;
                    _offset_KeyName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a QueryValue event.
        /// </summary>
        public readonly ref struct QueryValueEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "QueryValue";

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
                Opcode = (EtwEventOpcode)Opcodes.QueryValue,
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
            public QueryValueData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new QueryValueEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public QueryValueEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a QueryValueEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator QueryValueEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a QueryValue event.
            /// </summary>
            public ref struct QueryValueData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_InitialTime;
                private int _offset_Status;
                private int _offset_Index;
                private int _offset_KeyHandle;
                private int _offset_KeyName;

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

                private int Offset_Status
                {
                    get
                    {
                        if (_offset_Status == -1)
                        {
                            _offset_Status = Offset_InitialTime + 8;
                        }

                        return _offset_Status;
                    }
                }

                private int Offset_Index
                {
                    get
                    {
                        if (_offset_Index == -1)
                        {
                            _offset_Index = Offset_Status + 4;
                        }

                        return _offset_Index;
                    }
                }

                private int Offset_KeyHandle
                {
                    get
                    {
                        if (_offset_KeyHandle == -1)
                        {
                            _offset_KeyHandle = Offset_Index + 4;
                        }

                        return _offset_KeyHandle;
                    }
                }

                private int Offset_KeyName
                {
                    get
                    {
                        if (_offset_KeyName == -1)
                        {
                            _offset_KeyName = Offset_KeyHandle + _etwEvent.AddressSize;
                        }

                        return _offset_KeyName;
                    }
                }

                /// <summary>
                /// Retrieves the InitialTime field.
                /// </summary>
                public long InitialTime => BitConverter.ToInt64(_etwEvent.Data[Offset_InitialTime..Offset_Status]);

                /// <summary>
                /// Retrieves the Status field.
                /// </summary>
                public uint Status => BitConverter.ToUInt32(_etwEvent.Data[Offset_Status..Offset_Index]);

                /// <summary>
                /// Retrieves the Index field.
                /// </summary>
                public uint Index => BitConverter.ToUInt32(_etwEvent.Data[Offset_Index..Offset_KeyHandle]);

                /// <summary>
                /// Retrieves the KeyHandle field.
                /// </summary>
                public ulong KeyHandle => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_KeyHandle..Offset_KeyName]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_KeyHandle..Offset_KeyName]);

                /// <summary>
                /// Retrieves the KeyName field.
                /// </summary>
                public string KeyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_KeyName..]);

                /// <summary>
                /// Creates a new QueryValueData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public QueryValueData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_InitialTime = -1;
                    _offset_Status = -1;
                    _offset_Index = -1;
                    _offset_KeyHandle = -1;
                    _offset_KeyName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a EnumerateKey event.
        /// </summary>
        public readonly ref struct EnumerateKeyEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "EnumerateKey";

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
                Opcode = (EtwEventOpcode)Opcodes.EnumerateKey,
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
            public EnumerateKeyData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new EnumerateKeyEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public EnumerateKeyEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a EnumerateKeyEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator EnumerateKeyEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a EnumerateKey event.
            /// </summary>
            public ref struct EnumerateKeyData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_InitialTime;
                private int _offset_Status;
                private int _offset_Index;
                private int _offset_KeyHandle;
                private int _offset_KeyName;

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

                private int Offset_Status
                {
                    get
                    {
                        if (_offset_Status == -1)
                        {
                            _offset_Status = Offset_InitialTime + 8;
                        }

                        return _offset_Status;
                    }
                }

                private int Offset_Index
                {
                    get
                    {
                        if (_offset_Index == -1)
                        {
                            _offset_Index = Offset_Status + 4;
                        }

                        return _offset_Index;
                    }
                }

                private int Offset_KeyHandle
                {
                    get
                    {
                        if (_offset_KeyHandle == -1)
                        {
                            _offset_KeyHandle = Offset_Index + 4;
                        }

                        return _offset_KeyHandle;
                    }
                }

                private int Offset_KeyName
                {
                    get
                    {
                        if (_offset_KeyName == -1)
                        {
                            _offset_KeyName = Offset_KeyHandle + _etwEvent.AddressSize;
                        }

                        return _offset_KeyName;
                    }
                }

                /// <summary>
                /// Retrieves the InitialTime field.
                /// </summary>
                public long InitialTime => BitConverter.ToInt64(_etwEvent.Data[Offset_InitialTime..Offset_Status]);

                /// <summary>
                /// Retrieves the Status field.
                /// </summary>
                public uint Status => BitConverter.ToUInt32(_etwEvent.Data[Offset_Status..Offset_Index]);

                /// <summary>
                /// Retrieves the Index field.
                /// </summary>
                public uint Index => BitConverter.ToUInt32(_etwEvent.Data[Offset_Index..Offset_KeyHandle]);

                /// <summary>
                /// Retrieves the KeyHandle field.
                /// </summary>
                public ulong KeyHandle => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_KeyHandle..Offset_KeyName]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_KeyHandle..Offset_KeyName]);

                /// <summary>
                /// Retrieves the KeyName field.
                /// </summary>
                public string KeyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_KeyName..]);

                /// <summary>
                /// Creates a new EnumerateKeyData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public EnumerateKeyData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_InitialTime = -1;
                    _offset_Status = -1;
                    _offset_Index = -1;
                    _offset_KeyHandle = -1;
                    _offset_KeyName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a EnumerateValueKey event.
        /// </summary>
        public readonly ref struct EnumerateValueKeyEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "EnumerateValueKey";

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
                Opcode = (EtwEventOpcode)Opcodes.EnumerateValueKey,
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
            public EnumerateValueKeyData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new EnumerateValueKeyEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public EnumerateValueKeyEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a EnumerateValueKeyEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator EnumerateValueKeyEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a EnumerateValueKey event.
            /// </summary>
            public ref struct EnumerateValueKeyData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_InitialTime;
                private int _offset_Status;
                private int _offset_Index;
                private int _offset_KeyHandle;
                private int _offset_KeyName;

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

                private int Offset_Status
                {
                    get
                    {
                        if (_offset_Status == -1)
                        {
                            _offset_Status = Offset_InitialTime + 8;
                        }

                        return _offset_Status;
                    }
                }

                private int Offset_Index
                {
                    get
                    {
                        if (_offset_Index == -1)
                        {
                            _offset_Index = Offset_Status + 4;
                        }

                        return _offset_Index;
                    }
                }

                private int Offset_KeyHandle
                {
                    get
                    {
                        if (_offset_KeyHandle == -1)
                        {
                            _offset_KeyHandle = Offset_Index + 4;
                        }

                        return _offset_KeyHandle;
                    }
                }

                private int Offset_KeyName
                {
                    get
                    {
                        if (_offset_KeyName == -1)
                        {
                            _offset_KeyName = Offset_KeyHandle + _etwEvent.AddressSize;
                        }

                        return _offset_KeyName;
                    }
                }

                /// <summary>
                /// Retrieves the InitialTime field.
                /// </summary>
                public long InitialTime => BitConverter.ToInt64(_etwEvent.Data[Offset_InitialTime..Offset_Status]);

                /// <summary>
                /// Retrieves the Status field.
                /// </summary>
                public uint Status => BitConverter.ToUInt32(_etwEvent.Data[Offset_Status..Offset_Index]);

                /// <summary>
                /// Retrieves the Index field.
                /// </summary>
                public uint Index => BitConverter.ToUInt32(_etwEvent.Data[Offset_Index..Offset_KeyHandle]);

                /// <summary>
                /// Retrieves the KeyHandle field.
                /// </summary>
                public ulong KeyHandle => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_KeyHandle..Offset_KeyName]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_KeyHandle..Offset_KeyName]);

                /// <summary>
                /// Retrieves the KeyName field.
                /// </summary>
                public string KeyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_KeyName..]);

                /// <summary>
                /// Creates a new EnumerateValueKeyData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public EnumerateValueKeyData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_InitialTime = -1;
                    _offset_Status = -1;
                    _offset_Index = -1;
                    _offset_KeyHandle = -1;
                    _offset_KeyName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a QueryMultipleValue event.
        /// </summary>
        public readonly ref struct QueryMultipleValueEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "QueryMultipleValue";

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
                Opcode = (EtwEventOpcode)Opcodes.QueryMultipleValue,
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
            public QueryMultipleValueData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new QueryMultipleValueEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public QueryMultipleValueEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a QueryMultipleValueEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator QueryMultipleValueEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a QueryMultipleValue event.
            /// </summary>
            public ref struct QueryMultipleValueData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_InitialTime;
                private int _offset_Status;
                private int _offset_Index;
                private int _offset_KeyHandle;
                private int _offset_KeyName;

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

                private int Offset_Status
                {
                    get
                    {
                        if (_offset_Status == -1)
                        {
                            _offset_Status = Offset_InitialTime + 8;
                        }

                        return _offset_Status;
                    }
                }

                private int Offset_Index
                {
                    get
                    {
                        if (_offset_Index == -1)
                        {
                            _offset_Index = Offset_Status + 4;
                        }

                        return _offset_Index;
                    }
                }

                private int Offset_KeyHandle
                {
                    get
                    {
                        if (_offset_KeyHandle == -1)
                        {
                            _offset_KeyHandle = Offset_Index + 4;
                        }

                        return _offset_KeyHandle;
                    }
                }

                private int Offset_KeyName
                {
                    get
                    {
                        if (_offset_KeyName == -1)
                        {
                            _offset_KeyName = Offset_KeyHandle + _etwEvent.AddressSize;
                        }

                        return _offset_KeyName;
                    }
                }

                /// <summary>
                /// Retrieves the InitialTime field.
                /// </summary>
                public long InitialTime => BitConverter.ToInt64(_etwEvent.Data[Offset_InitialTime..Offset_Status]);

                /// <summary>
                /// Retrieves the Status field.
                /// </summary>
                public uint Status => BitConverter.ToUInt32(_etwEvent.Data[Offset_Status..Offset_Index]);

                /// <summary>
                /// Retrieves the Index field.
                /// </summary>
                public uint Index => BitConverter.ToUInt32(_etwEvent.Data[Offset_Index..Offset_KeyHandle]);

                /// <summary>
                /// Retrieves the KeyHandle field.
                /// </summary>
                public ulong KeyHandle => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_KeyHandle..Offset_KeyName]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_KeyHandle..Offset_KeyName]);

                /// <summary>
                /// Retrieves the KeyName field.
                /// </summary>
                public string KeyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_KeyName..]);

                /// <summary>
                /// Creates a new QueryMultipleValueData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public QueryMultipleValueData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_InitialTime = -1;
                    _offset_Status = -1;
                    _offset_Index = -1;
                    _offset_KeyHandle = -1;
                    _offset_KeyName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a SetInformation event.
        /// </summary>
        public readonly ref struct SetInformationEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SetInformation";

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
                Opcode = (EtwEventOpcode)Opcodes.SetInformation,
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
            public SetInformationData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new SetInformationEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SetInformationEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a SetInformationEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator SetInformationEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a SetInformation event.
            /// </summary>
            public ref struct SetInformationData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_InitialTime;
                private int _offset_Status;
                private int _offset_Index;
                private int _offset_KeyHandle;
                private int _offset_KeyName;

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

                private int Offset_Status
                {
                    get
                    {
                        if (_offset_Status == -1)
                        {
                            _offset_Status = Offset_InitialTime + 8;
                        }

                        return _offset_Status;
                    }
                }

                private int Offset_Index
                {
                    get
                    {
                        if (_offset_Index == -1)
                        {
                            _offset_Index = Offset_Status + 4;
                        }

                        return _offset_Index;
                    }
                }

                private int Offset_KeyHandle
                {
                    get
                    {
                        if (_offset_KeyHandle == -1)
                        {
                            _offset_KeyHandle = Offset_Index + 4;
                        }

                        return _offset_KeyHandle;
                    }
                }

                private int Offset_KeyName
                {
                    get
                    {
                        if (_offset_KeyName == -1)
                        {
                            _offset_KeyName = Offset_KeyHandle + _etwEvent.AddressSize;
                        }

                        return _offset_KeyName;
                    }
                }

                /// <summary>
                /// Retrieves the InitialTime field.
                /// </summary>
                public long InitialTime => BitConverter.ToInt64(_etwEvent.Data[Offset_InitialTime..Offset_Status]);

                /// <summary>
                /// Retrieves the Status field.
                /// </summary>
                public uint Status => BitConverter.ToUInt32(_etwEvent.Data[Offset_Status..Offset_Index]);

                /// <summary>
                /// Retrieves the Index field.
                /// </summary>
                public uint Index => BitConverter.ToUInt32(_etwEvent.Data[Offset_Index..Offset_KeyHandle]);

                /// <summary>
                /// Retrieves the KeyHandle field.
                /// </summary>
                public ulong KeyHandle => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_KeyHandle..Offset_KeyName]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_KeyHandle..Offset_KeyName]);

                /// <summary>
                /// Retrieves the KeyName field.
                /// </summary>
                public string KeyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_KeyName..]);

                /// <summary>
                /// Creates a new SetInformationData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public SetInformationData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_InitialTime = -1;
                    _offset_Status = -1;
                    _offset_Index = -1;
                    _offset_KeyHandle = -1;
                    _offset_KeyName = -1;
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

                private int _offset_InitialTime;
                private int _offset_Status;
                private int _offset_Index;
                private int _offset_KeyHandle;
                private int _offset_KeyName;

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

                private int Offset_Status
                {
                    get
                    {
                        if (_offset_Status == -1)
                        {
                            _offset_Status = Offset_InitialTime + 8;
                        }

                        return _offset_Status;
                    }
                }

                private int Offset_Index
                {
                    get
                    {
                        if (_offset_Index == -1)
                        {
                            _offset_Index = Offset_Status + 4;
                        }

                        return _offset_Index;
                    }
                }

                private int Offset_KeyHandle
                {
                    get
                    {
                        if (_offset_KeyHandle == -1)
                        {
                            _offset_KeyHandle = Offset_Index + 4;
                        }

                        return _offset_KeyHandle;
                    }
                }

                private int Offset_KeyName
                {
                    get
                    {
                        if (_offset_KeyName == -1)
                        {
                            _offset_KeyName = Offset_KeyHandle + _etwEvent.AddressSize;
                        }

                        return _offset_KeyName;
                    }
                }

                /// <summary>
                /// Retrieves the InitialTime field.
                /// </summary>
                public long InitialTime => BitConverter.ToInt64(_etwEvent.Data[Offset_InitialTime..Offset_Status]);

                /// <summary>
                /// Retrieves the Status field.
                /// </summary>
                public uint Status => BitConverter.ToUInt32(_etwEvent.Data[Offset_Status..Offset_Index]);

                /// <summary>
                /// Retrieves the Index field.
                /// </summary>
                public uint Index => BitConverter.ToUInt32(_etwEvent.Data[Offset_Index..Offset_KeyHandle]);

                /// <summary>
                /// Retrieves the KeyHandle field.
                /// </summary>
                public ulong KeyHandle => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_KeyHandle..Offset_KeyName]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_KeyHandle..Offset_KeyName]);

                /// <summary>
                /// Retrieves the KeyName field.
                /// </summary>
                public string KeyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_KeyName..]);

                /// <summary>
                /// Creates a new FlushData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public FlushData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_InitialTime = -1;
                    _offset_Status = -1;
                    _offset_Index = -1;
                    _offset_KeyHandle = -1;
                    _offset_KeyName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a KCBCreate event.
        /// </summary>
        public readonly ref struct KCBCreateEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "KCBCreate";

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
                Opcode = (EtwEventOpcode)Opcodes.RunDown,
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
            public KCBCreateData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new KCBCreateEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public KCBCreateEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a KCBCreateEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator KCBCreateEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a KCBCreate event.
            /// </summary>
            public ref struct KCBCreateData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_InitialTime;
                private int _offset_Status;
                private int _offset_Index;
                private int _offset_KeyHandle;
                private int _offset_KeyName;

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

                private int Offset_Status
                {
                    get
                    {
                        if (_offset_Status == -1)
                        {
                            _offset_Status = Offset_InitialTime + 8;
                        }

                        return _offset_Status;
                    }
                }

                private int Offset_Index
                {
                    get
                    {
                        if (_offset_Index == -1)
                        {
                            _offset_Index = Offset_Status + 4;
                        }

                        return _offset_Index;
                    }
                }

                private int Offset_KeyHandle
                {
                    get
                    {
                        if (_offset_KeyHandle == -1)
                        {
                            _offset_KeyHandle = Offset_Index + 4;
                        }

                        return _offset_KeyHandle;
                    }
                }

                private int Offset_KeyName
                {
                    get
                    {
                        if (_offset_KeyName == -1)
                        {
                            _offset_KeyName = Offset_KeyHandle + _etwEvent.AddressSize;
                        }

                        return _offset_KeyName;
                    }
                }

                /// <summary>
                /// Retrieves the InitialTime field.
                /// </summary>
                public long InitialTime => BitConverter.ToInt64(_etwEvent.Data[Offset_InitialTime..Offset_Status]);

                /// <summary>
                /// Retrieves the Status field.
                /// </summary>
                public uint Status => BitConverter.ToUInt32(_etwEvent.Data[Offset_Status..Offset_Index]);

                /// <summary>
                /// Retrieves the Index field.
                /// </summary>
                public uint Index => BitConverter.ToUInt32(_etwEvent.Data[Offset_Index..Offset_KeyHandle]);

                /// <summary>
                /// Retrieves the KeyHandle field.
                /// </summary>
                public ulong KeyHandle => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_KeyHandle..Offset_KeyName]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_KeyHandle..Offset_KeyName]);

                /// <summary>
                /// Retrieves the KeyName field.
                /// </summary>
                public string KeyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_KeyName..]);

                /// <summary>
                /// Creates a new KCBCreateData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public KCBCreateData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_InitialTime = -1;
                    _offset_Status = -1;
                    _offset_Index = -1;
                    _offset_KeyHandle = -1;
                    _offset_KeyName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a KCBDelete event.
        /// </summary>
        public readonly ref struct KCBDeleteEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "KCBDelete";

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
                Opcode = (EtwEventOpcode)Opcodes.KCBDelete,
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
            public KCBDeleteData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new KCBDeleteEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public KCBDeleteEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a KCBDeleteEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator KCBDeleteEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a KCBDelete event.
            /// </summary>
            public ref struct KCBDeleteData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_InitialTime;
                private int _offset_Status;
                private int _offset_Index;
                private int _offset_KeyHandle;
                private int _offset_KeyName;

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

                private int Offset_Status
                {
                    get
                    {
                        if (_offset_Status == -1)
                        {
                            _offset_Status = Offset_InitialTime + 8;
                        }

                        return _offset_Status;
                    }
                }

                private int Offset_Index
                {
                    get
                    {
                        if (_offset_Index == -1)
                        {
                            _offset_Index = Offset_Status + 4;
                        }

                        return _offset_Index;
                    }
                }

                private int Offset_KeyHandle
                {
                    get
                    {
                        if (_offset_KeyHandle == -1)
                        {
                            _offset_KeyHandle = Offset_Index + 4;
                        }

                        return _offset_KeyHandle;
                    }
                }

                private int Offset_KeyName
                {
                    get
                    {
                        if (_offset_KeyName == -1)
                        {
                            _offset_KeyName = Offset_KeyHandle + _etwEvent.AddressSize;
                        }

                        return _offset_KeyName;
                    }
                }

                /// <summary>
                /// Retrieves the InitialTime field.
                /// </summary>
                public long InitialTime => BitConverter.ToInt64(_etwEvent.Data[Offset_InitialTime..Offset_Status]);

                /// <summary>
                /// Retrieves the Status field.
                /// </summary>
                public uint Status => BitConverter.ToUInt32(_etwEvent.Data[Offset_Status..Offset_Index]);

                /// <summary>
                /// Retrieves the Index field.
                /// </summary>
                public uint Index => BitConverter.ToUInt32(_etwEvent.Data[Offset_Index..Offset_KeyHandle]);

                /// <summary>
                /// Retrieves the KeyHandle field.
                /// </summary>
                public ulong KeyHandle => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_KeyHandle..Offset_KeyName]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_KeyHandle..Offset_KeyName]);

                /// <summary>
                /// Retrieves the KeyName field.
                /// </summary>
                public string KeyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_KeyName..]);

                /// <summary>
                /// Creates a new KCBDeleteData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public KCBDeleteData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_InitialTime = -1;
                    _offset_Status = -1;
                    _offset_Index = -1;
                    _offset_KeyHandle = -1;
                    _offset_KeyName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a KCBRundownBegin event.
        /// </summary>
        public readonly ref struct KCBRundownBeginEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "KCBRundownBegin";

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
                Opcode = (EtwEventOpcode)Opcodes.KCBRundownBegin,
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
            public KCBRundownBeginData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new KCBRundownBeginEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public KCBRundownBeginEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a KCBRundownBeginEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator KCBRundownBeginEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a KCBRundownBegin event.
            /// </summary>
            public ref struct KCBRundownBeginData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_InitialTime;
                private int _offset_Status;
                private int _offset_Index;
                private int _offset_KeyHandle;
                private int _offset_KeyName;

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

                private int Offset_Status
                {
                    get
                    {
                        if (_offset_Status == -1)
                        {
                            _offset_Status = Offset_InitialTime + 8;
                        }

                        return _offset_Status;
                    }
                }

                private int Offset_Index
                {
                    get
                    {
                        if (_offset_Index == -1)
                        {
                            _offset_Index = Offset_Status + 4;
                        }

                        return _offset_Index;
                    }
                }

                private int Offset_KeyHandle
                {
                    get
                    {
                        if (_offset_KeyHandle == -1)
                        {
                            _offset_KeyHandle = Offset_Index + 4;
                        }

                        return _offset_KeyHandle;
                    }
                }

                private int Offset_KeyName
                {
                    get
                    {
                        if (_offset_KeyName == -1)
                        {
                            _offset_KeyName = Offset_KeyHandle + _etwEvent.AddressSize;
                        }

                        return _offset_KeyName;
                    }
                }

                /// <summary>
                /// Retrieves the InitialTime field.
                /// </summary>
                public long InitialTime => BitConverter.ToInt64(_etwEvent.Data[Offset_InitialTime..Offset_Status]);

                /// <summary>
                /// Retrieves the Status field.
                /// </summary>
                public uint Status => BitConverter.ToUInt32(_etwEvent.Data[Offset_Status..Offset_Index]);

                /// <summary>
                /// Retrieves the Index field.
                /// </summary>
                public uint Index => BitConverter.ToUInt32(_etwEvent.Data[Offset_Index..Offset_KeyHandle]);

                /// <summary>
                /// Retrieves the KeyHandle field.
                /// </summary>
                public ulong KeyHandle => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_KeyHandle..Offset_KeyName]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_KeyHandle..Offset_KeyName]);

                /// <summary>
                /// Retrieves the KeyName field.
                /// </summary>
                public string KeyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_KeyName..]);

                /// <summary>
                /// Creates a new KCBRundownBeginData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public KCBRundownBeginData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_InitialTime = -1;
                    _offset_Status = -1;
                    _offset_Index = -1;
                    _offset_KeyHandle = -1;
                    _offset_KeyName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a KCBRundownEnd event.
        /// </summary>
        public readonly ref struct KCBRundownEndEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "KCBRundownEnd";

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
                Opcode = (EtwEventOpcode)Opcodes.KCBRundownEnd,
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
            public KCBRundownEndData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new KCBRundownEndEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public KCBRundownEndEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a KCBRundownEndEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator KCBRundownEndEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a KCBRundownEnd event.
            /// </summary>
            public ref struct KCBRundownEndData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_InitialTime;
                private int _offset_Status;
                private int _offset_Index;
                private int _offset_KeyHandle;
                private int _offset_KeyName;

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

                private int Offset_Status
                {
                    get
                    {
                        if (_offset_Status == -1)
                        {
                            _offset_Status = Offset_InitialTime + 8;
                        }

                        return _offset_Status;
                    }
                }

                private int Offset_Index
                {
                    get
                    {
                        if (_offset_Index == -1)
                        {
                            _offset_Index = Offset_Status + 4;
                        }

                        return _offset_Index;
                    }
                }

                private int Offset_KeyHandle
                {
                    get
                    {
                        if (_offset_KeyHandle == -1)
                        {
                            _offset_KeyHandle = Offset_Index + 4;
                        }

                        return _offset_KeyHandle;
                    }
                }

                private int Offset_KeyName
                {
                    get
                    {
                        if (_offset_KeyName == -1)
                        {
                            _offset_KeyName = Offset_KeyHandle + _etwEvent.AddressSize;
                        }

                        return _offset_KeyName;
                    }
                }

                /// <summary>
                /// Retrieves the InitialTime field.
                /// </summary>
                public long InitialTime => BitConverter.ToInt64(_etwEvent.Data[Offset_InitialTime..Offset_Status]);

                /// <summary>
                /// Retrieves the Status field.
                /// </summary>
                public uint Status => BitConverter.ToUInt32(_etwEvent.Data[Offset_Status..Offset_Index]);

                /// <summary>
                /// Retrieves the Index field.
                /// </summary>
                public uint Index => BitConverter.ToUInt32(_etwEvent.Data[Offset_Index..Offset_KeyHandle]);

                /// <summary>
                /// Retrieves the KeyHandle field.
                /// </summary>
                public ulong KeyHandle => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_KeyHandle..Offset_KeyName]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_KeyHandle..Offset_KeyName]);

                /// <summary>
                /// Retrieves the KeyName field.
                /// </summary>
                public string KeyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_KeyName..]);

                /// <summary>
                /// Creates a new KCBRundownEndData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public KCBRundownEndData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_InitialTime = -1;
                    _offset_Status = -1;
                    _offset_Index = -1;
                    _offset_KeyHandle = -1;
                    _offset_KeyName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Virtualize event.
        /// </summary>
        public readonly ref struct VirtualizeEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Virtualize";

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
                Opcode = (EtwEventOpcode)Opcodes.Virtualize,
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
            public VirtualizeData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new VirtualizeEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public VirtualizeEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a VirtualizeEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator VirtualizeEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Virtualize event.
            /// </summary>
            public ref struct VirtualizeData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_InitialTime;
                private int _offset_Status;
                private int _offset_Index;
                private int _offset_KeyHandle;
                private int _offset_KeyName;

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

                private int Offset_Status
                {
                    get
                    {
                        if (_offset_Status == -1)
                        {
                            _offset_Status = Offset_InitialTime + 8;
                        }

                        return _offset_Status;
                    }
                }

                private int Offset_Index
                {
                    get
                    {
                        if (_offset_Index == -1)
                        {
                            _offset_Index = Offset_Status + 4;
                        }

                        return _offset_Index;
                    }
                }

                private int Offset_KeyHandle
                {
                    get
                    {
                        if (_offset_KeyHandle == -1)
                        {
                            _offset_KeyHandle = Offset_Index + 4;
                        }

                        return _offset_KeyHandle;
                    }
                }

                private int Offset_KeyName
                {
                    get
                    {
                        if (_offset_KeyName == -1)
                        {
                            _offset_KeyName = Offset_KeyHandle + _etwEvent.AddressSize;
                        }

                        return _offset_KeyName;
                    }
                }

                /// <summary>
                /// Retrieves the InitialTime field.
                /// </summary>
                public long InitialTime => BitConverter.ToInt64(_etwEvent.Data[Offset_InitialTime..Offset_Status]);

                /// <summary>
                /// Retrieves the Status field.
                /// </summary>
                public uint Status => BitConverter.ToUInt32(_etwEvent.Data[Offset_Status..Offset_Index]);

                /// <summary>
                /// Retrieves the Index field.
                /// </summary>
                public uint Index => BitConverter.ToUInt32(_etwEvent.Data[Offset_Index..Offset_KeyHandle]);

                /// <summary>
                /// Retrieves the KeyHandle field.
                /// </summary>
                public ulong KeyHandle => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_KeyHandle..Offset_KeyName]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_KeyHandle..Offset_KeyName]);

                /// <summary>
                /// Retrieves the KeyName field.
                /// </summary>
                public string KeyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_KeyName..]);

                /// <summary>
                /// Creates a new VirtualizeData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public VirtualizeData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_InitialTime = -1;
                    _offset_Status = -1;
                    _offset_Index = -1;
                    _offset_KeyHandle = -1;
                    _offset_KeyName = -1;
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

                private int _offset_InitialTime;
                private int _offset_Status;
                private int _offset_Index;
                private int _offset_KeyHandle;
                private int _offset_KeyName;

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

                private int Offset_Status
                {
                    get
                    {
                        if (_offset_Status == -1)
                        {
                            _offset_Status = Offset_InitialTime + 8;
                        }

                        return _offset_Status;
                    }
                }

                private int Offset_Index
                {
                    get
                    {
                        if (_offset_Index == -1)
                        {
                            _offset_Index = Offset_Status + 4;
                        }

                        return _offset_Index;
                    }
                }

                private int Offset_KeyHandle
                {
                    get
                    {
                        if (_offset_KeyHandle == -1)
                        {
                            _offset_KeyHandle = Offset_Index + 4;
                        }

                        return _offset_KeyHandle;
                    }
                }

                private int Offset_KeyName
                {
                    get
                    {
                        if (_offset_KeyName == -1)
                        {
                            _offset_KeyName = Offset_KeyHandle + _etwEvent.AddressSize;
                        }

                        return _offset_KeyName;
                    }
                }

                /// <summary>
                /// Retrieves the InitialTime field.
                /// </summary>
                public long InitialTime => BitConverter.ToInt64(_etwEvent.Data[Offset_InitialTime..Offset_Status]);

                /// <summary>
                /// Retrieves the Status field.
                /// </summary>
                public uint Status => BitConverter.ToUInt32(_etwEvent.Data[Offset_Status..Offset_Index]);

                /// <summary>
                /// Retrieves the Index field.
                /// </summary>
                public uint Index => BitConverter.ToUInt32(_etwEvent.Data[Offset_Index..Offset_KeyHandle]);

                /// <summary>
                /// Retrieves the KeyHandle field.
                /// </summary>
                public ulong KeyHandle => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_KeyHandle..Offset_KeyName]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_KeyHandle..Offset_KeyName]);

                /// <summary>
                /// Retrieves the KeyName field.
                /// </summary>
                public string KeyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_KeyName..]);

                /// <summary>
                /// Creates a new CloseData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public CloseData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_InitialTime = -1;
                    _offset_Status = -1;
                    _offset_Index = -1;
                    _offset_KeyHandle = -1;
                    _offset_KeyName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a SetSecurity event.
        /// </summary>
        public readonly ref struct SetSecurityEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SetSecurity";

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
                Opcode = (EtwEventOpcode)Opcodes.SetSecurity,
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
            public SetSecurityData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new SetSecurityEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SetSecurityEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a SetSecurityEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator SetSecurityEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a SetSecurity event.
            /// </summary>
            public ref struct SetSecurityData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_InitialTime;
                private int _offset_Status;
                private int _offset_Index;
                private int _offset_KeyHandle;
                private int _offset_KeyName;

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

                private int Offset_Status
                {
                    get
                    {
                        if (_offset_Status == -1)
                        {
                            _offset_Status = Offset_InitialTime + 8;
                        }

                        return _offset_Status;
                    }
                }

                private int Offset_Index
                {
                    get
                    {
                        if (_offset_Index == -1)
                        {
                            _offset_Index = Offset_Status + 4;
                        }

                        return _offset_Index;
                    }
                }

                private int Offset_KeyHandle
                {
                    get
                    {
                        if (_offset_KeyHandle == -1)
                        {
                            _offset_KeyHandle = Offset_Index + 4;
                        }

                        return _offset_KeyHandle;
                    }
                }

                private int Offset_KeyName
                {
                    get
                    {
                        if (_offset_KeyName == -1)
                        {
                            _offset_KeyName = Offset_KeyHandle + _etwEvent.AddressSize;
                        }

                        return _offset_KeyName;
                    }
                }

                /// <summary>
                /// Retrieves the InitialTime field.
                /// </summary>
                public long InitialTime => BitConverter.ToInt64(_etwEvent.Data[Offset_InitialTime..Offset_Status]);

                /// <summary>
                /// Retrieves the Status field.
                /// </summary>
                public uint Status => BitConverter.ToUInt32(_etwEvent.Data[Offset_Status..Offset_Index]);

                /// <summary>
                /// Retrieves the Index field.
                /// </summary>
                public uint Index => BitConverter.ToUInt32(_etwEvent.Data[Offset_Index..Offset_KeyHandle]);

                /// <summary>
                /// Retrieves the KeyHandle field.
                /// </summary>
                public ulong KeyHandle => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_KeyHandle..Offset_KeyName]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_KeyHandle..Offset_KeyName]);

                /// <summary>
                /// Retrieves the KeyName field.
                /// </summary>
                public string KeyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_KeyName..]);

                /// <summary>
                /// Creates a new SetSecurityData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public SetSecurityData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_InitialTime = -1;
                    _offset_Status = -1;
                    _offset_Index = -1;
                    _offset_KeyHandle = -1;
                    _offset_KeyName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a QuerySecurity event.
        /// </summary>
        public readonly ref struct QuerySecurityEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "QuerySecurity";

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
                Opcode = (EtwEventOpcode)Opcodes.QuerySecurity,
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
            public QuerySecurityData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new QuerySecurityEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public QuerySecurityEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a QuerySecurityEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator QuerySecurityEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a QuerySecurity event.
            /// </summary>
            public ref struct QuerySecurityData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_InitialTime;
                private int _offset_Status;
                private int _offset_Index;
                private int _offset_KeyHandle;
                private int _offset_KeyName;

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

                private int Offset_Status
                {
                    get
                    {
                        if (_offset_Status == -1)
                        {
                            _offset_Status = Offset_InitialTime + 8;
                        }

                        return _offset_Status;
                    }
                }

                private int Offset_Index
                {
                    get
                    {
                        if (_offset_Index == -1)
                        {
                            _offset_Index = Offset_Status + 4;
                        }

                        return _offset_Index;
                    }
                }

                private int Offset_KeyHandle
                {
                    get
                    {
                        if (_offset_KeyHandle == -1)
                        {
                            _offset_KeyHandle = Offset_Index + 4;
                        }

                        return _offset_KeyHandle;
                    }
                }

                private int Offset_KeyName
                {
                    get
                    {
                        if (_offset_KeyName == -1)
                        {
                            _offset_KeyName = Offset_KeyHandle + _etwEvent.AddressSize;
                        }

                        return _offset_KeyName;
                    }
                }

                /// <summary>
                /// Retrieves the InitialTime field.
                /// </summary>
                public long InitialTime => BitConverter.ToInt64(_etwEvent.Data[Offset_InitialTime..Offset_Status]);

                /// <summary>
                /// Retrieves the Status field.
                /// </summary>
                public uint Status => BitConverter.ToUInt32(_etwEvent.Data[Offset_Status..Offset_Index]);

                /// <summary>
                /// Retrieves the Index field.
                /// </summary>
                public uint Index => BitConverter.ToUInt32(_etwEvent.Data[Offset_Index..Offset_KeyHandle]);

                /// <summary>
                /// Retrieves the KeyHandle field.
                /// </summary>
                public ulong KeyHandle => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_KeyHandle..Offset_KeyName]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_KeyHandle..Offset_KeyName]);

                /// <summary>
                /// Retrieves the KeyName field.
                /// </summary>
                public string KeyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_KeyName..]);

                /// <summary>
                /// Creates a new QuerySecurityData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public QuerySecurityData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_InitialTime = -1;
                    _offset_Status = -1;
                    _offset_Index = -1;
                    _offset_KeyHandle = -1;
                    _offset_KeyName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a HiveInit event.
        /// </summary>
        public readonly ref struct HiveInitEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "HiveInit";

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
                Opcode = (EtwEventOpcode)Opcodes.HiveInit,
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
            public HiveInitData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new HiveInitEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public HiveInitEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a HiveInitEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator HiveInitEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a HiveInit event.
            /// </summary>
            public ref struct HiveInitData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Hive;
                private int _offset_OperationType;
                private int _offset_PoolTag;
                private int _offset_Size;
                private int _offset_FileName;

                private int Offset_Hive
                {
                    get
                    {
                        if (_offset_Hive == -1)
                        {
                            _offset_Hive = 0;
                        }

                        return _offset_Hive;
                    }
                }

                private int Offset_OperationType
                {
                    get
                    {
                        if (_offset_OperationType == -1)
                        {
                            _offset_OperationType = Offset_Hive + _etwEvent.AddressSize;
                        }

                        return _offset_OperationType;
                    }
                }

                private int Offset_PoolTag
                {
                    get
                    {
                        if (_offset_PoolTag == -1)
                        {
                            _offset_PoolTag = Offset_OperationType + 4;
                        }

                        return _offset_PoolTag;
                    }
                }

                private int Offset_Size
                {
                    get
                    {
                        if (_offset_Size == -1)
                        {
                            _offset_Size = Offset_PoolTag + 4;
                        }

                        return _offset_Size;
                    }
                }

                private int Offset_FileName
                {
                    get
                    {
                        if (_offset_FileName == -1)
                        {
                            _offset_FileName = Offset_Size + 4;
                        }

                        return _offset_FileName;
                    }
                }

                /// <summary>
                /// Retrieves the Hive field.
                /// </summary>
                public ulong Hive => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Hive..Offset_OperationType]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Hive..Offset_OperationType]);

                /// <summary>
                /// Retrieves the OperationType field.
                /// </summary>
                public uint OperationType => BitConverter.ToUInt32(_etwEvent.Data[Offset_OperationType..Offset_PoolTag]);

                /// <summary>
                /// Retrieves the PoolTag field.
                /// </summary>
                public uint PoolTag => BitConverter.ToUInt32(_etwEvent.Data[Offset_PoolTag..Offset_Size]);

                /// <summary>
                /// Retrieves the Size field.
                /// </summary>
                public uint Size => BitConverter.ToUInt32(_etwEvent.Data[Offset_Size..Offset_FileName]);

                /// <summary>
                /// Retrieves the FileName field.
                /// </summary>
                public string FileName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FileName..]);

                /// <summary>
                /// Creates a new HiveInitData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public HiveInitData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Hive = -1;
                    _offset_OperationType = -1;
                    _offset_PoolTag = -1;
                    _offset_Size = -1;
                    _offset_FileName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a TxRCommit event.
        /// </summary>
        public readonly ref struct TxRCommitEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "TxRCommit";

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
                Opcode = (EtwEventOpcode)Opcodes.TxRCommit,
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
            public TxRCommitData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new TxRCommitEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public TxRCommitEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a TxRCommitEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator TxRCommitEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a TxRCommit event.
            /// </summary>
            public ref struct TxRCommitData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_TxrGUID;
                private int _offset_Status;
                private int _offset_UowCount;
                private int _offset_OperationTime;
                private int _offset_Hive;

                private int Offset_TxrGUID
                {
                    get
                    {
                        if (_offset_TxrGUID == -1)
                        {
                            _offset_TxrGUID = 0;
                        }

                        return _offset_TxrGUID;
                    }
                }

                private int Offset_Status
                {
                    get
                    {
                        if (_offset_Status == -1)
                        {
                            _offset_Status = Offset_TxrGUID + 16;
                        }

                        return _offset_Status;
                    }
                }

                private int Offset_UowCount
                {
                    get
                    {
                        if (_offset_UowCount == -1)
                        {
                            _offset_UowCount = Offset_Status + 4;
                        }

                        return _offset_UowCount;
                    }
                }

                private int Offset_OperationTime
                {
                    get
                    {
                        if (_offset_OperationTime == -1)
                        {
                            _offset_OperationTime = Offset_UowCount + 4;
                        }

                        return _offset_OperationTime;
                    }
                }

                private int Offset_Hive
                {
                    get
                    {
                        if (_offset_Hive == -1)
                        {
                            _offset_Hive = Offset_OperationTime + 8;
                        }

                        return _offset_Hive;
                    }
                }

                /// <summary>
                /// Retrieves the TxrGUID field.
                /// </summary>
                public Guid TxrGUID => new(_etwEvent.Data[Offset_TxrGUID..Offset_Status]);

                /// <summary>
                /// Retrieves the Status field.
                /// </summary>
                public uint Status => BitConverter.ToUInt32(_etwEvent.Data[Offset_Status..Offset_UowCount]);

                /// <summary>
                /// Retrieves the UowCount field.
                /// </summary>
                public uint UowCount => BitConverter.ToUInt32(_etwEvent.Data[Offset_UowCount..Offset_OperationTime]);

                /// <summary>
                /// Retrieves the OperationTime field.
                /// </summary>
                public ulong OperationTime => BitConverter.ToUInt64(_etwEvent.Data[Offset_OperationTime..Offset_Hive]);

                /// <summary>
                /// Retrieves the Hive field.
                /// </summary>
                public string Hive => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Hive..]);

                /// <summary>
                /// Creates a new TxRCommitData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public TxRCommitData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_TxrGUID = -1;
                    _offset_Status = -1;
                    _offset_UowCount = -1;
                    _offset_OperationTime = -1;
                    _offset_Hive = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a TxRPrepare event.
        /// </summary>
        public readonly ref struct TxRPrepareEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "TxRPrepare";

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
                Opcode = (EtwEventOpcode)Opcodes.TxRPrepare,
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
            public TxRPrepareData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new TxRPrepareEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public TxRPrepareEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a TxRPrepareEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator TxRPrepareEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a TxRPrepare event.
            /// </summary>
            public ref struct TxRPrepareData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_TxrGUID;
                private int _offset_Status;
                private int _offset_UowCount;
                private int _offset_OperationTime;
                private int _offset_Hive;

                private int Offset_TxrGUID
                {
                    get
                    {
                        if (_offset_TxrGUID == -1)
                        {
                            _offset_TxrGUID = 0;
                        }

                        return _offset_TxrGUID;
                    }
                }

                private int Offset_Status
                {
                    get
                    {
                        if (_offset_Status == -1)
                        {
                            _offset_Status = Offset_TxrGUID + 16;
                        }

                        return _offset_Status;
                    }
                }

                private int Offset_UowCount
                {
                    get
                    {
                        if (_offset_UowCount == -1)
                        {
                            _offset_UowCount = Offset_Status + 4;
                        }

                        return _offset_UowCount;
                    }
                }

                private int Offset_OperationTime
                {
                    get
                    {
                        if (_offset_OperationTime == -1)
                        {
                            _offset_OperationTime = Offset_UowCount + 4;
                        }

                        return _offset_OperationTime;
                    }
                }

                private int Offset_Hive
                {
                    get
                    {
                        if (_offset_Hive == -1)
                        {
                            _offset_Hive = Offset_OperationTime + 8;
                        }

                        return _offset_Hive;
                    }
                }

                /// <summary>
                /// Retrieves the TxrGUID field.
                /// </summary>
                public Guid TxrGUID => new(_etwEvent.Data[Offset_TxrGUID..Offset_Status]);

                /// <summary>
                /// Retrieves the Status field.
                /// </summary>
                public uint Status => BitConverter.ToUInt32(_etwEvent.Data[Offset_Status..Offset_UowCount]);

                /// <summary>
                /// Retrieves the UowCount field.
                /// </summary>
                public uint UowCount => BitConverter.ToUInt32(_etwEvent.Data[Offset_UowCount..Offset_OperationTime]);

                /// <summary>
                /// Retrieves the OperationTime field.
                /// </summary>
                public ulong OperationTime => BitConverter.ToUInt64(_etwEvent.Data[Offset_OperationTime..Offset_Hive]);

                /// <summary>
                /// Retrieves the Hive field.
                /// </summary>
                public string Hive => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Hive..]);

                /// <summary>
                /// Creates a new TxRPrepareData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public TxRPrepareData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_TxrGUID = -1;
                    _offset_Status = -1;
                    _offset_UowCount = -1;
                    _offset_OperationTime = -1;
                    _offset_Hive = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a TxRRollback event.
        /// </summary>
        public readonly ref struct TxRRollbackEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "TxRRollback";

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
                Opcode = (EtwEventOpcode)Opcodes.TxRRollback,
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
            public TxRRollbackData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new TxRRollbackEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public TxRRollbackEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a TxRRollbackEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator TxRRollbackEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a TxRRollback event.
            /// </summary>
            public ref struct TxRRollbackData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_TxrGUID;
                private int _offset_Status;
                private int _offset_UowCount;
                private int _offset_OperationTime;
                private int _offset_Hive;

                private int Offset_TxrGUID
                {
                    get
                    {
                        if (_offset_TxrGUID == -1)
                        {
                            _offset_TxrGUID = 0;
                        }

                        return _offset_TxrGUID;
                    }
                }

                private int Offset_Status
                {
                    get
                    {
                        if (_offset_Status == -1)
                        {
                            _offset_Status = Offset_TxrGUID + 16;
                        }

                        return _offset_Status;
                    }
                }

                private int Offset_UowCount
                {
                    get
                    {
                        if (_offset_UowCount == -1)
                        {
                            _offset_UowCount = Offset_Status + 4;
                        }

                        return _offset_UowCount;
                    }
                }

                private int Offset_OperationTime
                {
                    get
                    {
                        if (_offset_OperationTime == -1)
                        {
                            _offset_OperationTime = Offset_UowCount + 4;
                        }

                        return _offset_OperationTime;
                    }
                }

                private int Offset_Hive
                {
                    get
                    {
                        if (_offset_Hive == -1)
                        {
                            _offset_Hive = Offset_OperationTime + 8;
                        }

                        return _offset_Hive;
                    }
                }

                /// <summary>
                /// Retrieves the TxrGUID field.
                /// </summary>
                public Guid TxrGUID => new(_etwEvent.Data[Offset_TxrGUID..Offset_Status]);

                /// <summary>
                /// Retrieves the Status field.
                /// </summary>
                public uint Status => BitConverter.ToUInt32(_etwEvent.Data[Offset_Status..Offset_UowCount]);

                /// <summary>
                /// Retrieves the UowCount field.
                /// </summary>
                public uint UowCount => BitConverter.ToUInt32(_etwEvent.Data[Offset_UowCount..Offset_OperationTime]);

                /// <summary>
                /// Retrieves the OperationTime field.
                /// </summary>
                public ulong OperationTime => BitConverter.ToUInt64(_etwEvent.Data[Offset_OperationTime..Offset_Hive]);

                /// <summary>
                /// Retrieves the Hive field.
                /// </summary>
                public string Hive => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Hive..]);

                /// <summary>
                /// Creates a new TxRRollbackData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public TxRRollbackData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_TxrGUID = -1;
                    _offset_Status = -1;
                    _offset_UowCount = -1;
                    _offset_OperationTime = -1;
                    _offset_Hive = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a HiveDCEnd event.
        /// </summary>
        public readonly ref struct HiveDCEndEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "HiveDCEnd";

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
                Opcode = (EtwEventOpcode)Opcodes.HiveDCEnd,
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
            public HiveDCEndData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new HiveDCEndEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public HiveDCEndEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a HiveDCEndEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator HiveDCEndEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a HiveDCEnd event.
            /// </summary>
            public ref struct HiveDCEndData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Size;
                private int _offset_Hive;
                private int _offset_LoadedKeyCount;
                private int _offset_FileName;
                private int _offset_LinkPath;

                private int Offset_Size
                {
                    get
                    {
                        if (_offset_Size == -1)
                        {
                            _offset_Size = 0;
                        }

                        return _offset_Size;
                    }
                }

                private int Offset_Hive
                {
                    get
                    {
                        if (_offset_Hive == -1)
                        {
                            _offset_Hive = Offset_Size + 8;
                        }

                        return _offset_Hive;
                    }
                }

                private int Offset_LoadedKeyCount
                {
                    get
                    {
                        if (_offset_LoadedKeyCount == -1)
                        {
                            _offset_LoadedKeyCount = Offset_Hive + _etwEvent.AddressSize;
                        }

                        return _offset_LoadedKeyCount;
                    }
                }

                private int Offset_FileName
                {
                    get
                    {
                        if (_offset_FileName == -1)
                        {
                            _offset_FileName = Offset_LoadedKeyCount + 4;
                        }

                        return _offset_FileName;
                    }
                }

                private int Offset_LinkPath
                {
                    get
                    {
                        if (_offset_LinkPath == -1)
                        {
                            _offset_LinkPath = Offset_FileName + _etwEvent.UnicodeStringLength(Offset_FileName);
                        }

                        return _offset_LinkPath;
                    }
                }

                /// <summary>
                /// Retrieves the Size field.
                /// </summary>
                public ulong Size => BitConverter.ToUInt64(_etwEvent.Data[Offset_Size..Offset_Hive]);

                /// <summary>
                /// Retrieves the Hive field.
                /// </summary>
                public ulong Hive => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Hive..Offset_LoadedKeyCount]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Hive..Offset_LoadedKeyCount]);

                /// <summary>
                /// Retrieves the LoadedKeyCount field.
                /// </summary>
                public uint LoadedKeyCount => BitConverter.ToUInt32(_etwEvent.Data[Offset_LoadedKeyCount..Offset_FileName]);

                /// <summary>
                /// Retrieves the FileName field.
                /// </summary>
                public string FileName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FileName..Offset_LinkPath]);

                /// <summary>
                /// Retrieves the LinkPath field.
                /// </summary>
                public string LinkPath => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_LinkPath..]);

                /// <summary>
                /// Creates a new HiveDCEndData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public HiveDCEndData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Size = -1;
                    _offset_Hive = -1;
                    _offset_LoadedKeyCount = -1;
                    _offset_FileName = -1;
                    _offset_LinkPath = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ChangeNotify event.
        /// </summary>
        public readonly ref struct ChangeNotifyEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ChangeNotify";

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
                Opcode = (EtwEventOpcode)Opcodes.ChangeNotify,
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
            public ChangeNotifyData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ChangeNotifyEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ChangeNotifyEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a ChangeNotifyEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator ChangeNotifyEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a ChangeNotify event.
            /// </summary>
            public ref struct ChangeNotifyData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Notification;
                private int _offset_KeyHandle;
                private int _offset_Type;
                private int _offset_WatchSubtree;
                private int _offset_Primary;

                private int Offset_Notification
                {
                    get
                    {
                        if (_offset_Notification == -1)
                        {
                            _offset_Notification = 0;
                        }

                        return _offset_Notification;
                    }
                }

                private int Offset_KeyHandle
                {
                    get
                    {
                        if (_offset_KeyHandle == -1)
                        {
                            _offset_KeyHandle = Offset_Notification + _etwEvent.AddressSize;
                        }

                        return _offset_KeyHandle;
                    }
                }

                private int Offset_Type
                {
                    get
                    {
                        if (_offset_Type == -1)
                        {
                            _offset_Type = Offset_KeyHandle + _etwEvent.AddressSize;
                        }

                        return _offset_Type;
                    }
                }

                private int Offset_WatchSubtree
                {
                    get
                    {
                        if (_offset_WatchSubtree == -1)
                        {
                            _offset_WatchSubtree = Offset_Type + 1;
                        }

                        return _offset_WatchSubtree;
                    }
                }

                private int Offset_Primary
                {
                    get
                    {
                        if (_offset_Primary == -1)
                        {
                            _offset_Primary = Offset_WatchSubtree + 1;
                        }

                        return _offset_Primary;
                    }
                }

                /// <summary>
                /// Retrieves the Notification field.
                /// </summary>
                public ulong Notification => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Notification..Offset_KeyHandle]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Notification..Offset_KeyHandle]);

                /// <summary>
                /// Retrieves the KeyHandle field.
                /// </summary>
                public ulong KeyHandle => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_KeyHandle..Offset_Type]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_KeyHandle..Offset_Type]);

                /// <summary>
                /// Retrieves the Type field.
                /// </summary>
                public byte Type => _etwEvent.Data[Offset_Type];

                /// <summary>
                /// Retrieves the WatchSubtree field.
                /// </summary>
                public byte WatchSubtree => _etwEvent.Data[Offset_WatchSubtree];

                /// <summary>
                /// Retrieves the Primary field.
                /// </summary>
                public byte Primary => _etwEvent.Data[Offset_Primary];

                /// <summary>
                /// Creates a new ChangeNotifyData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ChangeNotifyData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Notification = -1;
                    _offset_KeyHandle = -1;
                    _offset_Type = -1;
                    _offset_WatchSubtree = -1;
                    _offset_Primary = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a HiveLink event.
        /// </summary>
        public readonly ref struct HiveLinkEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "HiveLink";

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
                Opcode = (EtwEventOpcode)Opcodes.HiveLink,
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
            public HiveLinkData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new HiveLinkEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public HiveLinkEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a HiveLinkEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator HiveLinkEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a HiveLink event.
            /// </summary>
            public ref struct HiveLinkData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Hive;
                private int _offset_Path;

                private int Offset_Hive
                {
                    get
                    {
                        if (_offset_Hive == -1)
                        {
                            _offset_Hive = 0;
                        }

                        return _offset_Hive;
                    }
                }

                private int Offset_Path
                {
                    get
                    {
                        if (_offset_Path == -1)
                        {
                            _offset_Path = Offset_Hive + _etwEvent.AddressSize;
                        }

                        return _offset_Path;
                    }
                }

                /// <summary>
                /// Retrieves the Hive field.
                /// </summary>
                public ulong Hive => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Hive..Offset_Path]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Hive..Offset_Path]);

                /// <summary>
                /// Retrieves the Path field.
                /// </summary>
                public string Path => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Path..]);

                /// <summary>
                /// Creates a new HiveLinkData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public HiveLinkData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Hive = -1;
                    _offset_Path = -1;
                }
            }

        }
    }
}
