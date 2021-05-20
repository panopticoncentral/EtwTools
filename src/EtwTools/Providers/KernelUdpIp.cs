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
    /// Provider for Kernel-UdpIp (bf3a50c5-a9c9-4988-a005-2df0b7c80f80)
    /// </summary>
    public sealed class KernelUdpIpProvider
    {
        /// <summary>s
        /// Provider ID.
        /// </summary>
        public static readonly Guid Id = new("bf3a50c5-a9c9-4988-a005-2df0b7c80f80");

        /// <summary>
        /// Provider name.
        /// </summary>
        public const string Name = "Kernel-UdpIp";

        /// <summary>
        /// Opcodes supported by KernelUdpIp.
        /// </summary>
        public enum Opcodes
        {
            /// <summary>
            /// 'Send' opcode.
            /// </summary>
            Send = 10,
            /// <summary>
            /// 'Recv' opcode.
            /// </summary>
            Recv = 11,
            /// <summary>
            /// 'Fail' opcode.
            /// </summary>
            Fail = 17,
            /// <summary>
            /// 'SendIPV6' opcode.
            /// </summary>
            SendIPV6 = 26,
            /// <summary>
            /// 'RecvIPV6' opcode.
            /// </summary>
            RecvIPV6 = 27,
        }

        /// <summary>
        /// An event wrapper for a Send event.
        /// </summary>
        public readonly ref struct SendEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Send";

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
                Opcode = (EtwEventOpcode)Opcodes.Send,
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
            public SendData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new SendEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SendEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a SendEvent.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator SendEvent(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Send event.
            /// </summary>
            public ref struct SendData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_context;
                private int _offset_saddr;
                private int _offset_sport;
                private int _offset_size;
                private int _offset_daddr;
                private int _offset_dport;
                private int _offset_dsize;

                private int Offset_context
                {
                    get
                    {
                        if (_offset_context == -1)
                        {
                            _offset_context = 0;
                        }

                        return _offset_context;
                    }
                }

                private int Offset_saddr
                {
                    get
                    {
                        if (_offset_saddr == -1)
                        {
                            _offset_saddr = Offset_context + _etwEvent.AddressSize;
                        }

                        return _offset_saddr;
                    }
                }

                private int Offset_sport
                {
                    get
                    {
                        if (_offset_sport == -1)
                        {
                            _offset_sport = Offset_saddr + 4;
                        }

                        return _offset_sport;
                    }
                }

                private int Offset_size
                {
                    get
                    {
                        if (_offset_size == -1)
                        {
                            _offset_size = Offset_sport + 2;
                        }

                        return _offset_size;
                    }
                }

                private int Offset_daddr
                {
                    get
                    {
                        if (_offset_daddr == -1)
                        {
                            _offset_daddr = Offset_size + 2;
                        }

                        return _offset_daddr;
                    }
                }

                private int Offset_dport
                {
                    get
                    {
                        if (_offset_dport == -1)
                        {
                            _offset_dport = Offset_daddr + 4;
                        }

                        return _offset_dport;
                    }
                }

                private int Offset_dsize
                {
                    get
                    {
                        if (_offset_dsize == -1)
                        {
                            _offset_dsize = Offset_dport + 2;
                        }

                        return _offset_dsize;
                    }
                }

                /// <summary>
                /// Retrieves the context field.
                /// </summary>
                public ulong context => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_context..Offset_saddr]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_context..Offset_saddr]);

                /// <summary>
                /// Retrieves the saddr field.
                /// </summary>
                public uint saddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_saddr..Offset_sport]);

                /// <summary>
                /// Retrieves the sport field.
                /// </summary>
                public ushort sport => BitConverter.ToUInt16(_etwEvent.Data[Offset_sport..Offset_size]);

                /// <summary>
                /// Retrieves the size field.
                /// </summary>
                public ushort size => BitConverter.ToUInt16(_etwEvent.Data[Offset_size..Offset_daddr]);

                /// <summary>
                /// Retrieves the daddr field.
                /// </summary>
                public uint daddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_daddr..Offset_dport]);

                /// <summary>
                /// Retrieves the dport field.
                /// </summary>
                public ushort dport => BitConverter.ToUInt16(_etwEvent.Data[Offset_dport..Offset_dsize]);

                /// <summary>
                /// Retrieves the dsize field.
                /// </summary>
                public ushort dsize => BitConverter.ToUInt16(_etwEvent.Data[Offset_dsize..]);

                /// <summary>
                /// Creates a new SendData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public SendData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_context = -1;
                    _offset_saddr = -1;
                    _offset_sport = -1;
                    _offset_size = -1;
                    _offset_daddr = -1;
                    _offset_dport = -1;
                    _offset_dsize = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Recv event.
        /// </summary>
        public readonly ref struct RecvEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Recv";

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
                Opcode = (EtwEventOpcode)Opcodes.Recv,
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
            public RecvData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new RecvEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public RecvEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a RecvEvent.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator RecvEvent(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Recv event.
            /// </summary>
            public ref struct RecvData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_context;
                private int _offset_saddr;
                private int _offset_sport;
                private int _offset_size;
                private int _offset_daddr;
                private int _offset_dport;
                private int _offset_dsize;

                private int Offset_context
                {
                    get
                    {
                        if (_offset_context == -1)
                        {
                            _offset_context = 0;
                        }

                        return _offset_context;
                    }
                }

                private int Offset_saddr
                {
                    get
                    {
                        if (_offset_saddr == -1)
                        {
                            _offset_saddr = Offset_context + _etwEvent.AddressSize;
                        }

                        return _offset_saddr;
                    }
                }

                private int Offset_sport
                {
                    get
                    {
                        if (_offset_sport == -1)
                        {
                            _offset_sport = Offset_saddr + 4;
                        }

                        return _offset_sport;
                    }
                }

                private int Offset_size
                {
                    get
                    {
                        if (_offset_size == -1)
                        {
                            _offset_size = Offset_sport + 2;
                        }

                        return _offset_size;
                    }
                }

                private int Offset_daddr
                {
                    get
                    {
                        if (_offset_daddr == -1)
                        {
                            _offset_daddr = Offset_size + 2;
                        }

                        return _offset_daddr;
                    }
                }

                private int Offset_dport
                {
                    get
                    {
                        if (_offset_dport == -1)
                        {
                            _offset_dport = Offset_daddr + 4;
                        }

                        return _offset_dport;
                    }
                }

                private int Offset_dsize
                {
                    get
                    {
                        if (_offset_dsize == -1)
                        {
                            _offset_dsize = Offset_dport + 2;
                        }

                        return _offset_dsize;
                    }
                }

                /// <summary>
                /// Retrieves the context field.
                /// </summary>
                public ulong context => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_context..Offset_saddr]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_context..Offset_saddr]);

                /// <summary>
                /// Retrieves the saddr field.
                /// </summary>
                public uint saddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_saddr..Offset_sport]);

                /// <summary>
                /// Retrieves the sport field.
                /// </summary>
                public ushort sport => BitConverter.ToUInt16(_etwEvent.Data[Offset_sport..Offset_size]);

                /// <summary>
                /// Retrieves the size field.
                /// </summary>
                public ushort size => BitConverter.ToUInt16(_etwEvent.Data[Offset_size..Offset_daddr]);

                /// <summary>
                /// Retrieves the daddr field.
                /// </summary>
                public uint daddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_daddr..Offset_dport]);

                /// <summary>
                /// Retrieves the dport field.
                /// </summary>
                public ushort dport => BitConverter.ToUInt16(_etwEvent.Data[Offset_dport..Offset_dsize]);

                /// <summary>
                /// Retrieves the dsize field.
                /// </summary>
                public ushort dsize => BitConverter.ToUInt16(_etwEvent.Data[Offset_dsize..]);

                /// <summary>
                /// Creates a new RecvData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public RecvData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_context = -1;
                    _offset_saddr = -1;
                    _offset_sport = -1;
                    _offset_size = -1;
                    _offset_daddr = -1;
                    _offset_dport = -1;
                    _offset_dsize = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Send event.
        /// </summary>
        public readonly ref struct SendEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Send";

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
                Opcode = (EtwEventOpcode)Opcodes.Send,
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
            public SendData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new SendEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SendEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a SendEventV1.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator SendEventV1(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Send event.
            /// </summary>
            public ref struct SendData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_PID;
                private int _offset_size;
                private int _offset_daddr;
                private int _offset_saddr;
                private int _offset_dport;
                private int _offset_sport;

                private int Offset_PID
                {
                    get
                    {
                        if (_offset_PID == -1)
                        {
                            _offset_PID = 0;
                        }

                        return _offset_PID;
                    }
                }

                private int Offset_size
                {
                    get
                    {
                        if (_offset_size == -1)
                        {
                            _offset_size = Offset_PID + 4;
                        }

                        return _offset_size;
                    }
                }

                private int Offset_daddr
                {
                    get
                    {
                        if (_offset_daddr == -1)
                        {
                            _offset_daddr = Offset_size + 4;
                        }

                        return _offset_daddr;
                    }
                }

                private int Offset_saddr
                {
                    get
                    {
                        if (_offset_saddr == -1)
                        {
                            _offset_saddr = Offset_daddr + 4;
                        }

                        return _offset_saddr;
                    }
                }

                private int Offset_dport
                {
                    get
                    {
                        if (_offset_dport == -1)
                        {
                            _offset_dport = Offset_saddr + 4;
                        }

                        return _offset_dport;
                    }
                }

                private int Offset_sport
                {
                    get
                    {
                        if (_offset_sport == -1)
                        {
                            _offset_sport = Offset_dport + 2;
                        }

                        return _offset_sport;
                    }
                }

                /// <summary>
                /// Retrieves the PID field.
                /// </summary>
                public uint PID => BitConverter.ToUInt32(_etwEvent.Data[Offset_PID..Offset_size]);

                /// <summary>
                /// Retrieves the size field.
                /// </summary>
                public uint size => BitConverter.ToUInt32(_etwEvent.Data[Offset_size..Offset_daddr]);

                /// <summary>
                /// Retrieves the daddr field.
                /// </summary>
                public uint daddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_daddr..Offset_saddr]);

                /// <summary>
                /// Retrieves the saddr field.
                /// </summary>
                public uint saddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_saddr..Offset_dport]);

                /// <summary>
                /// Retrieves the dport field.
                /// </summary>
                public ushort dport => BitConverter.ToUInt16(_etwEvent.Data[Offset_dport..Offset_sport]);

                /// <summary>
                /// Retrieves the sport field.
                /// </summary>
                public ushort sport => BitConverter.ToUInt16(_etwEvent.Data[Offset_sport..]);

                /// <summary>
                /// Creates a new SendData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public SendData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_PID = -1;
                    _offset_size = -1;
                    _offset_daddr = -1;
                    _offset_saddr = -1;
                    _offset_dport = -1;
                    _offset_sport = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Recv event.
        /// </summary>
        public readonly ref struct RecvEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Recv";

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
                Opcode = (EtwEventOpcode)Opcodes.Recv,
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
            public RecvData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new RecvEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public RecvEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a RecvEventV1.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator RecvEventV1(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Recv event.
            /// </summary>
            public ref struct RecvData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_PID;
                private int _offset_size;
                private int _offset_daddr;
                private int _offset_saddr;
                private int _offset_dport;
                private int _offset_sport;

                private int Offset_PID
                {
                    get
                    {
                        if (_offset_PID == -1)
                        {
                            _offset_PID = 0;
                        }

                        return _offset_PID;
                    }
                }

                private int Offset_size
                {
                    get
                    {
                        if (_offset_size == -1)
                        {
                            _offset_size = Offset_PID + 4;
                        }

                        return _offset_size;
                    }
                }

                private int Offset_daddr
                {
                    get
                    {
                        if (_offset_daddr == -1)
                        {
                            _offset_daddr = Offset_size + 4;
                        }

                        return _offset_daddr;
                    }
                }

                private int Offset_saddr
                {
                    get
                    {
                        if (_offset_saddr == -1)
                        {
                            _offset_saddr = Offset_daddr + 4;
                        }

                        return _offset_saddr;
                    }
                }

                private int Offset_dport
                {
                    get
                    {
                        if (_offset_dport == -1)
                        {
                            _offset_dport = Offset_saddr + 4;
                        }

                        return _offset_dport;
                    }
                }

                private int Offset_sport
                {
                    get
                    {
                        if (_offset_sport == -1)
                        {
                            _offset_sport = Offset_dport + 2;
                        }

                        return _offset_sport;
                    }
                }

                /// <summary>
                /// Retrieves the PID field.
                /// </summary>
                public uint PID => BitConverter.ToUInt32(_etwEvent.Data[Offset_PID..Offset_size]);

                /// <summary>
                /// Retrieves the size field.
                /// </summary>
                public uint size => BitConverter.ToUInt32(_etwEvent.Data[Offset_size..Offset_daddr]);

                /// <summary>
                /// Retrieves the daddr field.
                /// </summary>
                public uint daddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_daddr..Offset_saddr]);

                /// <summary>
                /// Retrieves the saddr field.
                /// </summary>
                public uint saddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_saddr..Offset_dport]);

                /// <summary>
                /// Retrieves the dport field.
                /// </summary>
                public ushort dport => BitConverter.ToUInt16(_etwEvent.Data[Offset_dport..Offset_sport]);

                /// <summary>
                /// Retrieves the sport field.
                /// </summary>
                public ushort sport => BitConverter.ToUInt16(_etwEvent.Data[Offset_sport..]);

                /// <summary>
                /// Creates a new RecvData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public RecvData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_PID = -1;
                    _offset_size = -1;
                    _offset_daddr = -1;
                    _offset_saddr = -1;
                    _offset_dport = -1;
                    _offset_sport = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Fail event.
        /// </summary>
        public readonly ref struct FailEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Fail";

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
                Opcode = (EtwEventOpcode)Opcodes.Fail,
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
            public FailData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new FailEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public FailEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a FailEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator FailEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Fail event.
            /// </summary>
            public ref struct FailData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Proto;
                private int _offset_FailureCode;

                private int Offset_Proto
                {
                    get
                    {
                        if (_offset_Proto == -1)
                        {
                            _offset_Proto = 0;
                        }

                        return _offset_Proto;
                    }
                }

                private int Offset_FailureCode
                {
                    get
                    {
                        if (_offset_FailureCode == -1)
                        {
                            _offset_FailureCode = Offset_Proto + 2;
                        }

                        return _offset_FailureCode;
                    }
                }

                /// <summary>
                /// Retrieves the Proto field.
                /// </summary>
                public ushort Proto => BitConverter.ToUInt16(_etwEvent.Data[Offset_Proto..Offset_FailureCode]);

                /// <summary>
                /// Retrieves the FailureCode field.
                /// </summary>
                public ushort FailureCode => BitConverter.ToUInt16(_etwEvent.Data[Offset_FailureCode..]);

                /// <summary>
                /// Creates a new FailData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public FailData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Proto = -1;
                    _offset_FailureCode = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a SendIPV6 event.
        /// </summary>
        public readonly ref struct SendIPV6EventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SendIPV6";

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
                Opcode = (EtwEventOpcode)Opcodes.SendIPV6,
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
            public SendIPV6Data Data => new(_etwEvent);

            /// <summary>
            /// Creates a new SendIPV6EventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SendIPV6EventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a SendIPV6EventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator SendIPV6EventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a SendIPV6 event.
            /// </summary>
            public ref struct SendIPV6Data
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_PID;
                private int _offset_size;
                private int _offset_daddr;
                private int _offset_saddr;
                private int _offset_dport;
                private int _offset_sport;
                private int _offset_seqnum;
                private int _offset_connid;

                private int Offset_PID
                {
                    get
                    {
                        if (_offset_PID == -1)
                        {
                            _offset_PID = 0;
                        }

                        return _offset_PID;
                    }
                }

                private int Offset_size
                {
                    get
                    {
                        if (_offset_size == -1)
                        {
                            _offset_size = Offset_PID + 4;
                        }

                        return _offset_size;
                    }
                }

                private int Offset_daddr
                {
                    get
                    {
                        if (_offset_daddr == -1)
                        {
                            _offset_daddr = Offset_size + 4;
                        }

                        return _offset_daddr;
                    }
                }

                private int Offset_saddr
                {
                    get
                    {
                        if (_offset_saddr == -1)
                        {
                            _offset_saddr = Offset_daddr + 1;
                        }

                        return _offset_saddr;
                    }
                }

                private int Offset_dport
                {
                    get
                    {
                        if (_offset_dport == -1)
                        {
                            _offset_dport = Offset_saddr + 1;
                        }

                        return _offset_dport;
                    }
                }

                private int Offset_sport
                {
                    get
                    {
                        if (_offset_sport == -1)
                        {
                            _offset_sport = Offset_dport + 2;
                        }

                        return _offset_sport;
                    }
                }

                private int Offset_seqnum
                {
                    get
                    {
                        if (_offset_seqnum == -1)
                        {
                            _offset_seqnum = Offset_sport + 2;
                        }

                        return _offset_seqnum;
                    }
                }

                private int Offset_connid
                {
                    get
                    {
                        if (_offset_connid == -1)
                        {
                            _offset_connid = Offset_seqnum + 4;
                        }

                        return _offset_connid;
                    }
                }

                /// <summary>
                /// Retrieves the PID field.
                /// </summary>
                public uint PID => BitConverter.ToUInt32(_etwEvent.Data[Offset_PID..Offset_size]);

                /// <summary>
                /// Retrieves the size field.
                /// </summary>
                public uint size => BitConverter.ToUInt32(_etwEvent.Data[Offset_size..Offset_daddr]);

                /// <summary>
                /// Retrieves the daddr field.
                /// </summary>
                public byte daddr => _etwEvent.Data[Offset_daddr];

                /// <summary>
                /// Retrieves the saddr field.
                /// </summary>
                public byte saddr => _etwEvent.Data[Offset_saddr];

                /// <summary>
                /// Retrieves the dport field.
                /// </summary>
                public ushort dport => BitConverter.ToUInt16(_etwEvent.Data[Offset_dport..Offset_sport]);

                /// <summary>
                /// Retrieves the sport field.
                /// </summary>
                public ushort sport => BitConverter.ToUInt16(_etwEvent.Data[Offset_sport..Offset_seqnum]);

                /// <summary>
                /// Retrieves the seqnum field.
                /// </summary>
                public uint seqnum => BitConverter.ToUInt32(_etwEvent.Data[Offset_seqnum..Offset_connid]);

                /// <summary>
                /// Retrieves the connid field.
                /// </summary>
                public ulong connid => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_connid..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_connid..]);

                /// <summary>
                /// Creates a new SendIPV6Data.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public SendIPV6Data(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_PID = -1;
                    _offset_size = -1;
                    _offset_daddr = -1;
                    _offset_saddr = -1;
                    _offset_dport = -1;
                    _offset_sport = -1;
                    _offset_seqnum = -1;
                    _offset_connid = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a RecvIPV6 event.
        /// </summary>
        public readonly ref struct RecvIPV6EventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "RecvIPV6";

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
                Opcode = (EtwEventOpcode)Opcodes.RecvIPV6,
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
            public RecvIPV6Data Data => new(_etwEvent);

            /// <summary>
            /// Creates a new RecvIPV6EventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public RecvIPV6EventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a RecvIPV6EventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator RecvIPV6EventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a RecvIPV6 event.
            /// </summary>
            public ref struct RecvIPV6Data
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_PID;
                private int _offset_size;
                private int _offset_daddr;
                private int _offset_saddr;
                private int _offset_dport;
                private int _offset_sport;
                private int _offset_seqnum;
                private int _offset_connid;

                private int Offset_PID
                {
                    get
                    {
                        if (_offset_PID == -1)
                        {
                            _offset_PID = 0;
                        }

                        return _offset_PID;
                    }
                }

                private int Offset_size
                {
                    get
                    {
                        if (_offset_size == -1)
                        {
                            _offset_size = Offset_PID + 4;
                        }

                        return _offset_size;
                    }
                }

                private int Offset_daddr
                {
                    get
                    {
                        if (_offset_daddr == -1)
                        {
                            _offset_daddr = Offset_size + 4;
                        }

                        return _offset_daddr;
                    }
                }

                private int Offset_saddr
                {
                    get
                    {
                        if (_offset_saddr == -1)
                        {
                            _offset_saddr = Offset_daddr + 1;
                        }

                        return _offset_saddr;
                    }
                }

                private int Offset_dport
                {
                    get
                    {
                        if (_offset_dport == -1)
                        {
                            _offset_dport = Offset_saddr + 1;
                        }

                        return _offset_dport;
                    }
                }

                private int Offset_sport
                {
                    get
                    {
                        if (_offset_sport == -1)
                        {
                            _offset_sport = Offset_dport + 2;
                        }

                        return _offset_sport;
                    }
                }

                private int Offset_seqnum
                {
                    get
                    {
                        if (_offset_seqnum == -1)
                        {
                            _offset_seqnum = Offset_sport + 2;
                        }

                        return _offset_seqnum;
                    }
                }

                private int Offset_connid
                {
                    get
                    {
                        if (_offset_connid == -1)
                        {
                            _offset_connid = Offset_seqnum + 4;
                        }

                        return _offset_connid;
                    }
                }

                /// <summary>
                /// Retrieves the PID field.
                /// </summary>
                public uint PID => BitConverter.ToUInt32(_etwEvent.Data[Offset_PID..Offset_size]);

                /// <summary>
                /// Retrieves the size field.
                /// </summary>
                public uint size => BitConverter.ToUInt32(_etwEvent.Data[Offset_size..Offset_daddr]);

                /// <summary>
                /// Retrieves the daddr field.
                /// </summary>
                public byte daddr => _etwEvent.Data[Offset_daddr];

                /// <summary>
                /// Retrieves the saddr field.
                /// </summary>
                public byte saddr => _etwEvent.Data[Offset_saddr];

                /// <summary>
                /// Retrieves the dport field.
                /// </summary>
                public ushort dport => BitConverter.ToUInt16(_etwEvent.Data[Offset_dport..Offset_sport]);

                /// <summary>
                /// Retrieves the sport field.
                /// </summary>
                public ushort sport => BitConverter.ToUInt16(_etwEvent.Data[Offset_sport..Offset_seqnum]);

                /// <summary>
                /// Retrieves the seqnum field.
                /// </summary>
                public uint seqnum => BitConverter.ToUInt32(_etwEvent.Data[Offset_seqnum..Offset_connid]);

                /// <summary>
                /// Retrieves the connid field.
                /// </summary>
                public ulong connid => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_connid..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_connid..]);

                /// <summary>
                /// Creates a new RecvIPV6Data.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public RecvIPV6Data(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_PID = -1;
                    _offset_size = -1;
                    _offset_daddr = -1;
                    _offset_saddr = -1;
                    _offset_dport = -1;
                    _offset_sport = -1;
                    _offset_seqnum = -1;
                    _offset_connid = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a SendIPV4 event.
        /// </summary>
        public readonly ref struct SendIPV4EventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SendIPV4";

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
                Opcode = (EtwEventOpcode)Opcodes.Send,
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
            public SendIPV4Data Data => new(_etwEvent);

            /// <summary>
            /// Creates a new SendIPV4EventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SendIPV4EventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a SendIPV4EventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator SendIPV4EventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a SendIPV4 event.
            /// </summary>
            public ref struct SendIPV4Data
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_PID;
                private int _offset_size;
                private int _offset_daddr;
                private int _offset_saddr;
                private int _offset_dport;
                private int _offset_sport;
                private int _offset_seqnum;
                private int _offset_connid;

                private int Offset_PID
                {
                    get
                    {
                        if (_offset_PID == -1)
                        {
                            _offset_PID = 0;
                        }

                        return _offset_PID;
                    }
                }

                private int Offset_size
                {
                    get
                    {
                        if (_offset_size == -1)
                        {
                            _offset_size = Offset_PID + 4;
                        }

                        return _offset_size;
                    }
                }

                private int Offset_daddr
                {
                    get
                    {
                        if (_offset_daddr == -1)
                        {
                            _offset_daddr = Offset_size + 4;
                        }

                        return _offset_daddr;
                    }
                }

                private int Offset_saddr
                {
                    get
                    {
                        if (_offset_saddr == -1)
                        {
                            _offset_saddr = Offset_daddr + 4;
                        }

                        return _offset_saddr;
                    }
                }

                private int Offset_dport
                {
                    get
                    {
                        if (_offset_dport == -1)
                        {
                            _offset_dport = Offset_saddr + 4;
                        }

                        return _offset_dport;
                    }
                }

                private int Offset_sport
                {
                    get
                    {
                        if (_offset_sport == -1)
                        {
                            _offset_sport = Offset_dport + 2;
                        }

                        return _offset_sport;
                    }
                }

                private int Offset_seqnum
                {
                    get
                    {
                        if (_offset_seqnum == -1)
                        {
                            _offset_seqnum = Offset_sport + 2;
                        }

                        return _offset_seqnum;
                    }
                }

                private int Offset_connid
                {
                    get
                    {
                        if (_offset_connid == -1)
                        {
                            _offset_connid = Offset_seqnum + 4;
                        }

                        return _offset_connid;
                    }
                }

                /// <summary>
                /// Retrieves the PID field.
                /// </summary>
                public uint PID => BitConverter.ToUInt32(_etwEvent.Data[Offset_PID..Offset_size]);

                /// <summary>
                /// Retrieves the size field.
                /// </summary>
                public uint size => BitConverter.ToUInt32(_etwEvent.Data[Offset_size..Offset_daddr]);

                /// <summary>
                /// Retrieves the daddr field.
                /// </summary>
                public uint daddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_daddr..Offset_saddr]);

                /// <summary>
                /// Retrieves the saddr field.
                /// </summary>
                public uint saddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_saddr..Offset_dport]);

                /// <summary>
                /// Retrieves the dport field.
                /// </summary>
                public ushort dport => BitConverter.ToUInt16(_etwEvent.Data[Offset_dport..Offset_sport]);

                /// <summary>
                /// Retrieves the sport field.
                /// </summary>
                public ushort sport => BitConverter.ToUInt16(_etwEvent.Data[Offset_sport..Offset_seqnum]);

                /// <summary>
                /// Retrieves the seqnum field.
                /// </summary>
                public uint seqnum => BitConverter.ToUInt32(_etwEvent.Data[Offset_seqnum..Offset_connid]);

                /// <summary>
                /// Retrieves the connid field.
                /// </summary>
                public ulong connid => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_connid..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_connid..]);

                /// <summary>
                /// Creates a new SendIPV4Data.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public SendIPV4Data(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_PID = -1;
                    _offset_size = -1;
                    _offset_daddr = -1;
                    _offset_saddr = -1;
                    _offset_dport = -1;
                    _offset_sport = -1;
                    _offset_seqnum = -1;
                    _offset_connid = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a RecvIPV4 event.
        /// </summary>
        public readonly ref struct RecvIPV4EventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "RecvIPV4";

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
                Opcode = (EtwEventOpcode)Opcodes.Recv,
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
            public RecvIPV4Data Data => new(_etwEvent);

            /// <summary>
            /// Creates a new RecvIPV4EventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public RecvIPV4EventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a RecvIPV4EventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator RecvIPV4EventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a RecvIPV4 event.
            /// </summary>
            public ref struct RecvIPV4Data
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_PID;
                private int _offset_size;
                private int _offset_daddr;
                private int _offset_saddr;
                private int _offset_dport;
                private int _offset_sport;
                private int _offset_seqnum;
                private int _offset_connid;

                private int Offset_PID
                {
                    get
                    {
                        if (_offset_PID == -1)
                        {
                            _offset_PID = 0;
                        }

                        return _offset_PID;
                    }
                }

                private int Offset_size
                {
                    get
                    {
                        if (_offset_size == -1)
                        {
                            _offset_size = Offset_PID + 4;
                        }

                        return _offset_size;
                    }
                }

                private int Offset_daddr
                {
                    get
                    {
                        if (_offset_daddr == -1)
                        {
                            _offset_daddr = Offset_size + 4;
                        }

                        return _offset_daddr;
                    }
                }

                private int Offset_saddr
                {
                    get
                    {
                        if (_offset_saddr == -1)
                        {
                            _offset_saddr = Offset_daddr + 4;
                        }

                        return _offset_saddr;
                    }
                }

                private int Offset_dport
                {
                    get
                    {
                        if (_offset_dport == -1)
                        {
                            _offset_dport = Offset_saddr + 4;
                        }

                        return _offset_dport;
                    }
                }

                private int Offset_sport
                {
                    get
                    {
                        if (_offset_sport == -1)
                        {
                            _offset_sport = Offset_dport + 2;
                        }

                        return _offset_sport;
                    }
                }

                private int Offset_seqnum
                {
                    get
                    {
                        if (_offset_seqnum == -1)
                        {
                            _offset_seqnum = Offset_sport + 2;
                        }

                        return _offset_seqnum;
                    }
                }

                private int Offset_connid
                {
                    get
                    {
                        if (_offset_connid == -1)
                        {
                            _offset_connid = Offset_seqnum + 4;
                        }

                        return _offset_connid;
                    }
                }

                /// <summary>
                /// Retrieves the PID field.
                /// </summary>
                public uint PID => BitConverter.ToUInt32(_etwEvent.Data[Offset_PID..Offset_size]);

                /// <summary>
                /// Retrieves the size field.
                /// </summary>
                public uint size => BitConverter.ToUInt32(_etwEvent.Data[Offset_size..Offset_daddr]);

                /// <summary>
                /// Retrieves the daddr field.
                /// </summary>
                public uint daddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_daddr..Offset_saddr]);

                /// <summary>
                /// Retrieves the saddr field.
                /// </summary>
                public uint saddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_saddr..Offset_dport]);

                /// <summary>
                /// Retrieves the dport field.
                /// </summary>
                public ushort dport => BitConverter.ToUInt16(_etwEvent.Data[Offset_dport..Offset_sport]);

                /// <summary>
                /// Retrieves the sport field.
                /// </summary>
                public ushort sport => BitConverter.ToUInt16(_etwEvent.Data[Offset_sport..Offset_seqnum]);

                /// <summary>
                /// Retrieves the seqnum field.
                /// </summary>
                public uint seqnum => BitConverter.ToUInt32(_etwEvent.Data[Offset_seqnum..Offset_connid]);

                /// <summary>
                /// Retrieves the connid field.
                /// </summary>
                public ulong connid => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_connid..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_connid..]);

                /// <summary>
                /// Creates a new RecvIPV4Data.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public RecvIPV4Data(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_PID = -1;
                    _offset_size = -1;
                    _offset_daddr = -1;
                    _offset_saddr = -1;
                    _offset_dport = -1;
                    _offset_sport = -1;
                    _offset_seqnum = -1;
                    _offset_connid = -1;
                }
            }

        }
    }
}
