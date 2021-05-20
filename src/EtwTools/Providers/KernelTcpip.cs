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
    /// Provider for Kernel-Tcpip (9a280ac0-c8e0-11d1-84e2-00c04fb998a2)
    /// </summary>
    public sealed class KernelTcpipProvider
    {
        /// <summary>s
        /// Provider ID.
        /// </summary>
        public static readonly Guid Id = new("9a280ac0-c8e0-11d1-84e2-00c04fb998a2");

        /// <summary>
        /// Provider name.
        /// </summary>
        public const string Name = "Kernel-Tcpip";

        /// <summary>
        /// Opcodes supported by KernelTcpip.
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
            /// 'Connect' opcode.
            /// </summary>
            Connect = 12,
            /// <summary>
            /// 'Disconnect' opcode.
            /// </summary>
            Disconnect = 13,
            /// <summary>
            /// 'Retransmit' opcode.
            /// </summary>
            Retransmit = 14,
            /// <summary>
            /// 'Accept' opcode.
            /// </summary>
            Accept = 15,
            /// <summary>
            /// 'Reconnect' opcode.
            /// </summary>
            Reconnect = 16,
            /// <summary>
            /// 'Fail' opcode.
            /// </summary>
            Fail = 17,
            /// <summary>
            /// 'TCPCopy' opcode.
            /// </summary>
            TCPCopy = 18,
            /// <summary>
            /// 'ARPCopy' opcode.
            /// </summary>
            ARPCopy = 19,
            /// <summary>
            /// 'FullACK' opcode.
            /// </summary>
            FullACK = 20,
            /// <summary>
            /// 'PartACK' opcode.
            /// </summary>
            PartACK = 21,
            /// <summary>
            /// 'DupACK' opcode.
            /// </summary>
            DupACK = 22,
            /// <summary>
            /// 'SendIPV6' opcode.
            /// </summary>
            SendIPV6 = 26,
            /// <summary>
            /// 'RecvIPV6' opcode.
            /// </summary>
            RecvIPV6 = 27,
            /// <summary>
            /// 'ConnectIPV6' opcode.
            /// </summary>
            ConnectIPV6 = 28,
            /// <summary>
            /// 'DisconnectIPV6' opcode.
            /// </summary>
            DisconnectIPV6 = 29,
            /// <summary>
            /// 'RetransmitIPV6' opcode.
            /// </summary>
            RetransmitIPV6 = 30,
            /// <summary>
            /// 'AcceptIPV6' opcode.
            /// </summary>
            AcceptIPV6 = 31,
            /// <summary>
            /// 'ReconnectIPV6' opcode.
            /// </summary>
            ReconnectIPV6 = 32,
            /// <summary>
            /// 'TCPCopyIPV6' opcode.
            /// </summary>
            TCPCopyIPV6 = 34,
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
            /// A data wrapper for a Send event.
            /// </summary>
            public ref struct SendData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_daddr;
                private int _offset_saddr;
                private int _offset_dport;
                private int _offset_sport;
                private int _offset_size;
                private int _offset_PID;

                private int Offset_daddr
                {
                    get
                    {
                        if (_offset_daddr == -1)
                        {
                            _offset_daddr = 0;
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

                private int Offset_PID
                {
                    get
                    {
                        if (_offset_PID == -1)
                        {
                            _offset_PID = Offset_size + 4;
                        }

                        return _offset_PID;
                    }
                }

                /// <summary>
                /// Retrieves the daddr field.
                /// </summary>
                public uint daddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_daddr..]);

                /// <summary>
                /// Retrieves the saddr field.
                /// </summary>
                public uint saddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_saddr..]);

                /// <summary>
                /// Retrieves the dport field.
                /// </summary>
                public ushort dport => BitConverter.ToUInt16(_etwEvent.Data[Offset_dport..]);

                /// <summary>
                /// Retrieves the sport field.
                /// </summary>
                public ushort sport => BitConverter.ToUInt16(_etwEvent.Data[Offset_sport..]);

                /// <summary>
                /// Retrieves the size field.
                /// </summary>
                public uint size => BitConverter.ToUInt32(_etwEvent.Data[Offset_size..]);

                /// <summary>
                /// Retrieves the PID field.
                /// </summary>
                public uint PID => BitConverter.ToUInt32(_etwEvent.Data[Offset_PID..]);

                /// <summary>
                /// Creates a new SendData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public SendData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_daddr = -1;
                    _offset_saddr = -1;
                    _offset_dport = -1;
                    _offset_sport = -1;
                    _offset_size = -1;
                    _offset_PID = -1;
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
            /// A data wrapper for a Recv event.
            /// </summary>
            public ref struct RecvData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_daddr;
                private int _offset_saddr;
                private int _offset_dport;
                private int _offset_sport;
                private int _offset_size;
                private int _offset_PID;

                private int Offset_daddr
                {
                    get
                    {
                        if (_offset_daddr == -1)
                        {
                            _offset_daddr = 0;
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

                private int Offset_PID
                {
                    get
                    {
                        if (_offset_PID == -1)
                        {
                            _offset_PID = Offset_size + 4;
                        }

                        return _offset_PID;
                    }
                }

                /// <summary>
                /// Retrieves the daddr field.
                /// </summary>
                public uint daddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_daddr..]);

                /// <summary>
                /// Retrieves the saddr field.
                /// </summary>
                public uint saddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_saddr..]);

                /// <summary>
                /// Retrieves the dport field.
                /// </summary>
                public ushort dport => BitConverter.ToUInt16(_etwEvent.Data[Offset_dport..]);

                /// <summary>
                /// Retrieves the sport field.
                /// </summary>
                public ushort sport => BitConverter.ToUInt16(_etwEvent.Data[Offset_sport..]);

                /// <summary>
                /// Retrieves the size field.
                /// </summary>
                public uint size => BitConverter.ToUInt32(_etwEvent.Data[Offset_size..]);

                /// <summary>
                /// Retrieves the PID field.
                /// </summary>
                public uint PID => BitConverter.ToUInt32(_etwEvent.Data[Offset_PID..]);

                /// <summary>
                /// Creates a new RecvData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public RecvData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_daddr = -1;
                    _offset_saddr = -1;
                    _offset_dport = -1;
                    _offset_sport = -1;
                    _offset_size = -1;
                    _offset_PID = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Connect event.
        /// </summary>
        public readonly ref struct ConnectEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Connect";

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
                Opcode = (EtwEventOpcode)Opcodes.Connect,
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
            public ConnectData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ConnectEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ConnectEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a Connect event.
            /// </summary>
            public ref struct ConnectData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_daddr;
                private int _offset_saddr;
                private int _offset_dport;
                private int _offset_sport;
                private int _offset_size;
                private int _offset_PID;

                private int Offset_daddr
                {
                    get
                    {
                        if (_offset_daddr == -1)
                        {
                            _offset_daddr = 0;
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

                private int Offset_PID
                {
                    get
                    {
                        if (_offset_PID == -1)
                        {
                            _offset_PID = Offset_size + 4;
                        }

                        return _offset_PID;
                    }
                }

                /// <summary>
                /// Retrieves the daddr field.
                /// </summary>
                public uint daddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_daddr..]);

                /// <summary>
                /// Retrieves the saddr field.
                /// </summary>
                public uint saddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_saddr..]);

                /// <summary>
                /// Retrieves the dport field.
                /// </summary>
                public ushort dport => BitConverter.ToUInt16(_etwEvent.Data[Offset_dport..]);

                /// <summary>
                /// Retrieves the sport field.
                /// </summary>
                public ushort sport => BitConverter.ToUInt16(_etwEvent.Data[Offset_sport..]);

                /// <summary>
                /// Retrieves the size field.
                /// </summary>
                public uint size => BitConverter.ToUInt32(_etwEvent.Data[Offset_size..]);

                /// <summary>
                /// Retrieves the PID field.
                /// </summary>
                public uint PID => BitConverter.ToUInt32(_etwEvent.Data[Offset_PID..]);

                /// <summary>
                /// Creates a new ConnectData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ConnectData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_daddr = -1;
                    _offset_saddr = -1;
                    _offset_dport = -1;
                    _offset_sport = -1;
                    _offset_size = -1;
                    _offset_PID = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Disconnect event.
        /// </summary>
        public readonly ref struct DisconnectEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Disconnect";

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
                Opcode = (EtwEventOpcode)Opcodes.Disconnect,
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
            public DisconnectData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DisconnectEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DisconnectEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a Disconnect event.
            /// </summary>
            public ref struct DisconnectData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_daddr;
                private int _offset_saddr;
                private int _offset_dport;
                private int _offset_sport;
                private int _offset_size;
                private int _offset_PID;

                private int Offset_daddr
                {
                    get
                    {
                        if (_offset_daddr == -1)
                        {
                            _offset_daddr = 0;
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

                private int Offset_PID
                {
                    get
                    {
                        if (_offset_PID == -1)
                        {
                            _offset_PID = Offset_size + 4;
                        }

                        return _offset_PID;
                    }
                }

                /// <summary>
                /// Retrieves the daddr field.
                /// </summary>
                public uint daddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_daddr..]);

                /// <summary>
                /// Retrieves the saddr field.
                /// </summary>
                public uint saddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_saddr..]);

                /// <summary>
                /// Retrieves the dport field.
                /// </summary>
                public ushort dport => BitConverter.ToUInt16(_etwEvent.Data[Offset_dport..]);

                /// <summary>
                /// Retrieves the sport field.
                /// </summary>
                public ushort sport => BitConverter.ToUInt16(_etwEvent.Data[Offset_sport..]);

                /// <summary>
                /// Retrieves the size field.
                /// </summary>
                public uint size => BitConverter.ToUInt32(_etwEvent.Data[Offset_size..]);

                /// <summary>
                /// Retrieves the PID field.
                /// </summary>
                public uint PID => BitConverter.ToUInt32(_etwEvent.Data[Offset_PID..]);

                /// <summary>
                /// Creates a new DisconnectData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DisconnectData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_daddr = -1;
                    _offset_saddr = -1;
                    _offset_dport = -1;
                    _offset_sport = -1;
                    _offset_size = -1;
                    _offset_PID = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Retransmit event.
        /// </summary>
        public readonly ref struct RetransmitEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Retransmit";

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
                Opcode = (EtwEventOpcode)Opcodes.Retransmit,
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
            public RetransmitData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new RetransmitEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public RetransmitEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a Retransmit event.
            /// </summary>
            public ref struct RetransmitData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_daddr;
                private int _offset_saddr;
                private int _offset_dport;
                private int _offset_sport;
                private int _offset_size;
                private int _offset_PID;

                private int Offset_daddr
                {
                    get
                    {
                        if (_offset_daddr == -1)
                        {
                            _offset_daddr = 0;
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

                private int Offset_PID
                {
                    get
                    {
                        if (_offset_PID == -1)
                        {
                            _offset_PID = Offset_size + 4;
                        }

                        return _offset_PID;
                    }
                }

                /// <summary>
                /// Retrieves the daddr field.
                /// </summary>
                public uint daddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_daddr..]);

                /// <summary>
                /// Retrieves the saddr field.
                /// </summary>
                public uint saddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_saddr..]);

                /// <summary>
                /// Retrieves the dport field.
                /// </summary>
                public ushort dport => BitConverter.ToUInt16(_etwEvent.Data[Offset_dport..]);

                /// <summary>
                /// Retrieves the sport field.
                /// </summary>
                public ushort sport => BitConverter.ToUInt16(_etwEvent.Data[Offset_sport..]);

                /// <summary>
                /// Retrieves the size field.
                /// </summary>
                public uint size => BitConverter.ToUInt32(_etwEvent.Data[Offset_size..]);

                /// <summary>
                /// Retrieves the PID field.
                /// </summary>
                public uint PID => BitConverter.ToUInt32(_etwEvent.Data[Offset_PID..]);

                /// <summary>
                /// Creates a new RetransmitData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public RetransmitData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_daddr = -1;
                    _offset_saddr = -1;
                    _offset_dport = -1;
                    _offset_sport = -1;
                    _offset_size = -1;
                    _offset_PID = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Accept event.
        /// </summary>
        public readonly ref struct AcceptEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Accept";

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
                Opcode = (EtwEventOpcode)Opcodes.Accept,
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
            public AcceptData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new AcceptEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public AcceptEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a Accept event.
            /// </summary>
            public ref struct AcceptData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_daddr;
                private int _offset_saddr;
                private int _offset_dport;
                private int _offset_sport;
                private int _offset_size;
                private int _offset_PID;

                private int Offset_daddr
                {
                    get
                    {
                        if (_offset_daddr == -1)
                        {
                            _offset_daddr = 0;
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

                private int Offset_PID
                {
                    get
                    {
                        if (_offset_PID == -1)
                        {
                            _offset_PID = Offset_size + 4;
                        }

                        return _offset_PID;
                    }
                }

                /// <summary>
                /// Retrieves the daddr field.
                /// </summary>
                public uint daddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_daddr..]);

                /// <summary>
                /// Retrieves the saddr field.
                /// </summary>
                public uint saddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_saddr..]);

                /// <summary>
                /// Retrieves the dport field.
                /// </summary>
                public ushort dport => BitConverter.ToUInt16(_etwEvent.Data[Offset_dport..]);

                /// <summary>
                /// Retrieves the sport field.
                /// </summary>
                public ushort sport => BitConverter.ToUInt16(_etwEvent.Data[Offset_sport..]);

                /// <summary>
                /// Retrieves the size field.
                /// </summary>
                public uint size => BitConverter.ToUInt32(_etwEvent.Data[Offset_size..]);

                /// <summary>
                /// Retrieves the PID field.
                /// </summary>
                public uint PID => BitConverter.ToUInt32(_etwEvent.Data[Offset_PID..]);

                /// <summary>
                /// Creates a new AcceptData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public AcceptData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_daddr = -1;
                    _offset_saddr = -1;
                    _offset_dport = -1;
                    _offset_sport = -1;
                    _offset_size = -1;
                    _offset_PID = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Fail event.
        /// </summary>
        public readonly ref struct FailEventV1
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
                Version = 1,
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
            /// Creates a new FailEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public FailEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a Fail event.
            /// </summary>
            public ref struct FailData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Proto;

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

                /// <summary>
                /// Retrieves the Proto field.
                /// </summary>
                public uint Proto => BitConverter.ToUInt32(_etwEvent.Data[Offset_Proto..]);

                /// <summary>
                /// Creates a new FailData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public FailData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Proto = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a TCPCopy event.
        /// </summary>
        public readonly ref struct TCPCopyEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "TCPCopy";

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
                Opcode = (EtwEventOpcode)Opcodes.TCPCopy,
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
            public TCPCopyData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new TCPCopyEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public TCPCopyEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a TCPCopy event.
            /// </summary>
            public ref struct TCPCopyData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_PID;
                private int _offset_size;
                private int _offset_daddr;
                private int _offset_saddr;
                private int _offset_dport;
                private int _offset_sport;
                private int _offset_connid;
                private int _offset_seqnum;

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

                private int Offset_connid
                {
                    get
                    {
                        if (_offset_connid == -1)
                        {
                            _offset_connid = Offset_sport + 2;
                        }

                        return _offset_connid;
                    }
                }

                private int Offset_seqnum
                {
                    get
                    {
                        if (_offset_seqnum == -1)
                        {
                            _offset_seqnum = Offset_connid + _etwEvent.AddressSize;
                        }

                        return _offset_seqnum;
                    }
                }

                /// <summary>
                /// Retrieves the PID field.
                /// </summary>
                public uint PID => BitConverter.ToUInt32(_etwEvent.Data[Offset_PID..]);

                /// <summary>
                /// Retrieves the size field.
                /// </summary>
                public uint size => BitConverter.ToUInt32(_etwEvent.Data[Offset_size..]);

                /// <summary>
                /// Retrieves the daddr field.
                /// </summary>
                public uint daddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_daddr..]);

                /// <summary>
                /// Retrieves the saddr field.
                /// </summary>
                public uint saddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_saddr..]);

                /// <summary>
                /// Retrieves the dport field.
                /// </summary>
                public ushort dport => BitConverter.ToUInt16(_etwEvent.Data[Offset_dport..]);

                /// <summary>
                /// Retrieves the sport field.
                /// </summary>
                public ushort sport => BitConverter.ToUInt16(_etwEvent.Data[Offset_sport..]);

                /// <summary>
                /// Retrieves the connid field.
                /// </summary>
                public ulong connid => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_connid..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_connid..]);

                /// <summary>
                /// Retrieves the seqnum field.
                /// </summary>
                public uint seqnum => BitConverter.ToUInt32(_etwEvent.Data[Offset_seqnum..]);

                /// <summary>
                /// Creates a new TCPCopyData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public TCPCopyData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_PID = -1;
                    _offset_size = -1;
                    _offset_daddr = -1;
                    _offset_saddr = -1;
                    _offset_dport = -1;
                    _offset_sport = -1;
                    _offset_connid = -1;
                    _offset_seqnum = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ARPCopy event.
        /// </summary>
        public readonly ref struct ARPCopyEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ARPCopy";

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
                Opcode = (EtwEventOpcode)Opcodes.ARPCopy,
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
            public ARPCopyData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ARPCopyEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ARPCopyEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ARPCopy event.
            /// </summary>
            public ref struct ARPCopyData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_PID;
                private int _offset_size;
                private int _offset_daddr;
                private int _offset_saddr;
                private int _offset_dport;
                private int _offset_sport;
                private int _offset_connid;
                private int _offset_seqnum;

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

                private int Offset_connid
                {
                    get
                    {
                        if (_offset_connid == -1)
                        {
                            _offset_connid = Offset_sport + 2;
                        }

                        return _offset_connid;
                    }
                }

                private int Offset_seqnum
                {
                    get
                    {
                        if (_offset_seqnum == -1)
                        {
                            _offset_seqnum = Offset_connid + _etwEvent.AddressSize;
                        }

                        return _offset_seqnum;
                    }
                }

                /// <summary>
                /// Retrieves the PID field.
                /// </summary>
                public uint PID => BitConverter.ToUInt32(_etwEvent.Data[Offset_PID..]);

                /// <summary>
                /// Retrieves the size field.
                /// </summary>
                public uint size => BitConverter.ToUInt32(_etwEvent.Data[Offset_size..]);

                /// <summary>
                /// Retrieves the daddr field.
                /// </summary>
                public uint daddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_daddr..]);

                /// <summary>
                /// Retrieves the saddr field.
                /// </summary>
                public uint saddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_saddr..]);

                /// <summary>
                /// Retrieves the dport field.
                /// </summary>
                public ushort dport => BitConverter.ToUInt16(_etwEvent.Data[Offset_dport..]);

                /// <summary>
                /// Retrieves the sport field.
                /// </summary>
                public ushort sport => BitConverter.ToUInt16(_etwEvent.Data[Offset_sport..]);

                /// <summary>
                /// Retrieves the connid field.
                /// </summary>
                public ulong connid => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_connid..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_connid..]);

                /// <summary>
                /// Retrieves the seqnum field.
                /// </summary>
                public uint seqnum => BitConverter.ToUInt32(_etwEvent.Data[Offset_seqnum..]);

                /// <summary>
                /// Creates a new ARPCopyData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ARPCopyData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_PID = -1;
                    _offset_size = -1;
                    _offset_daddr = -1;
                    _offset_saddr = -1;
                    _offset_dport = -1;
                    _offset_sport = -1;
                    _offset_connid = -1;
                    _offset_seqnum = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a FullACK event.
        /// </summary>
        public readonly ref struct FullACKEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "FullACK";

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
                Opcode = (EtwEventOpcode)Opcodes.FullACK,
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
            public FullACKData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new FullACKEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public FullACKEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a FullACK event.
            /// </summary>
            public ref struct FullACKData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_PID;
                private int _offset_size;
                private int _offset_daddr;
                private int _offset_saddr;
                private int _offset_dport;
                private int _offset_sport;
                private int _offset_connid;
                private int _offset_seqnum;

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

                private int Offset_connid
                {
                    get
                    {
                        if (_offset_connid == -1)
                        {
                            _offset_connid = Offset_sport + 2;
                        }

                        return _offset_connid;
                    }
                }

                private int Offset_seqnum
                {
                    get
                    {
                        if (_offset_seqnum == -1)
                        {
                            _offset_seqnum = Offset_connid + _etwEvent.AddressSize;
                        }

                        return _offset_seqnum;
                    }
                }

                /// <summary>
                /// Retrieves the PID field.
                /// </summary>
                public uint PID => BitConverter.ToUInt32(_etwEvent.Data[Offset_PID..]);

                /// <summary>
                /// Retrieves the size field.
                /// </summary>
                public uint size => BitConverter.ToUInt32(_etwEvent.Data[Offset_size..]);

                /// <summary>
                /// Retrieves the daddr field.
                /// </summary>
                public uint daddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_daddr..]);

                /// <summary>
                /// Retrieves the saddr field.
                /// </summary>
                public uint saddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_saddr..]);

                /// <summary>
                /// Retrieves the dport field.
                /// </summary>
                public ushort dport => BitConverter.ToUInt16(_etwEvent.Data[Offset_dport..]);

                /// <summary>
                /// Retrieves the sport field.
                /// </summary>
                public ushort sport => BitConverter.ToUInt16(_etwEvent.Data[Offset_sport..]);

                /// <summary>
                /// Retrieves the connid field.
                /// </summary>
                public ulong connid => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_connid..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_connid..]);

                /// <summary>
                /// Retrieves the seqnum field.
                /// </summary>
                public uint seqnum => BitConverter.ToUInt32(_etwEvent.Data[Offset_seqnum..]);

                /// <summary>
                /// Creates a new FullACKData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public FullACKData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_PID = -1;
                    _offset_size = -1;
                    _offset_daddr = -1;
                    _offset_saddr = -1;
                    _offset_dport = -1;
                    _offset_sport = -1;
                    _offset_connid = -1;
                    _offset_seqnum = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a PartACK event.
        /// </summary>
        public readonly ref struct PartACKEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "PartACK";

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
                Opcode = (EtwEventOpcode)Opcodes.PartACK,
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
            public PartACKData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new PartACKEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public PartACKEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a PartACK event.
            /// </summary>
            public ref struct PartACKData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_PID;
                private int _offset_size;
                private int _offset_daddr;
                private int _offset_saddr;
                private int _offset_dport;
                private int _offset_sport;
                private int _offset_connid;
                private int _offset_seqnum;

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

                private int Offset_connid
                {
                    get
                    {
                        if (_offset_connid == -1)
                        {
                            _offset_connid = Offset_sport + 2;
                        }

                        return _offset_connid;
                    }
                }

                private int Offset_seqnum
                {
                    get
                    {
                        if (_offset_seqnum == -1)
                        {
                            _offset_seqnum = Offset_connid + _etwEvent.AddressSize;
                        }

                        return _offset_seqnum;
                    }
                }

                /// <summary>
                /// Retrieves the PID field.
                /// </summary>
                public uint PID => BitConverter.ToUInt32(_etwEvent.Data[Offset_PID..]);

                /// <summary>
                /// Retrieves the size field.
                /// </summary>
                public uint size => BitConverter.ToUInt32(_etwEvent.Data[Offset_size..]);

                /// <summary>
                /// Retrieves the daddr field.
                /// </summary>
                public uint daddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_daddr..]);

                /// <summary>
                /// Retrieves the saddr field.
                /// </summary>
                public uint saddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_saddr..]);

                /// <summary>
                /// Retrieves the dport field.
                /// </summary>
                public ushort dport => BitConverter.ToUInt16(_etwEvent.Data[Offset_dport..]);

                /// <summary>
                /// Retrieves the sport field.
                /// </summary>
                public ushort sport => BitConverter.ToUInt16(_etwEvent.Data[Offset_sport..]);

                /// <summary>
                /// Retrieves the connid field.
                /// </summary>
                public ulong connid => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_connid..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_connid..]);

                /// <summary>
                /// Retrieves the seqnum field.
                /// </summary>
                public uint seqnum => BitConverter.ToUInt32(_etwEvent.Data[Offset_seqnum..]);

                /// <summary>
                /// Creates a new PartACKData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public PartACKData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_PID = -1;
                    _offset_size = -1;
                    _offset_daddr = -1;
                    _offset_saddr = -1;
                    _offset_dport = -1;
                    _offset_sport = -1;
                    _offset_connid = -1;
                    _offset_seqnum = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DupACK event.
        /// </summary>
        public readonly ref struct DupACKEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DupACK";

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
                Opcode = (EtwEventOpcode)Opcodes.DupACK,
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
            public DupACKData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DupACKEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DupACKEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a DupACK event.
            /// </summary>
            public ref struct DupACKData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_PID;
                private int _offset_size;
                private int _offset_daddr;
                private int _offset_saddr;
                private int _offset_dport;
                private int _offset_sport;
                private int _offset_connid;
                private int _offset_seqnum;

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

                private int Offset_connid
                {
                    get
                    {
                        if (_offset_connid == -1)
                        {
                            _offset_connid = Offset_sport + 2;
                        }

                        return _offset_connid;
                    }
                }

                private int Offset_seqnum
                {
                    get
                    {
                        if (_offset_seqnum == -1)
                        {
                            _offset_seqnum = Offset_connid + _etwEvent.AddressSize;
                        }

                        return _offset_seqnum;
                    }
                }

                /// <summary>
                /// Retrieves the PID field.
                /// </summary>
                public uint PID => BitConverter.ToUInt32(_etwEvent.Data[Offset_PID..]);

                /// <summary>
                /// Retrieves the size field.
                /// </summary>
                public uint size => BitConverter.ToUInt32(_etwEvent.Data[Offset_size..]);

                /// <summary>
                /// Retrieves the daddr field.
                /// </summary>
                public uint daddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_daddr..]);

                /// <summary>
                /// Retrieves the saddr field.
                /// </summary>
                public uint saddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_saddr..]);

                /// <summary>
                /// Retrieves the dport field.
                /// </summary>
                public ushort dport => BitConverter.ToUInt16(_etwEvent.Data[Offset_dport..]);

                /// <summary>
                /// Retrieves the sport field.
                /// </summary>
                public ushort sport => BitConverter.ToUInt16(_etwEvent.Data[Offset_sport..]);

                /// <summary>
                /// Retrieves the connid field.
                /// </summary>
                public ulong connid => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_connid..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_connid..]);

                /// <summary>
                /// Retrieves the seqnum field.
                /// </summary>
                public uint seqnum => BitConverter.ToUInt32(_etwEvent.Data[Offset_seqnum..]);

                /// <summary>
                /// Creates a new DupACKData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DupACKData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_PID = -1;
                    _offset_size = -1;
                    _offset_daddr = -1;
                    _offset_saddr = -1;
                    _offset_dport = -1;
                    _offset_sport = -1;
                    _offset_connid = -1;
                    _offset_seqnum = -1;
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
                private int _offset_startime;
                private int _offset_endtime;
                private int _offset_connid;
                private int _offset_seqnum;

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

                private int Offset_startime
                {
                    get
                    {
                        if (_offset_startime == -1)
                        {
                            _offset_startime = Offset_sport + 2;
                        }

                        return _offset_startime;
                    }
                }

                private int Offset_endtime
                {
                    get
                    {
                        if (_offset_endtime == -1)
                        {
                            _offset_endtime = Offset_startime + 4;
                        }

                        return _offset_endtime;
                    }
                }

                private int Offset_connid
                {
                    get
                    {
                        if (_offset_connid == -1)
                        {
                            _offset_connid = Offset_endtime + 4;
                        }

                        return _offset_connid;
                    }
                }

                private int Offset_seqnum
                {
                    get
                    {
                        if (_offset_seqnum == -1)
                        {
                            _offset_seqnum = Offset_connid + _etwEvent.AddressSize;
                        }

                        return _offset_seqnum;
                    }
                }

                /// <summary>
                /// Retrieves the PID field.
                /// </summary>
                public uint PID => BitConverter.ToUInt32(_etwEvent.Data[Offset_PID..]);

                /// <summary>
                /// Retrieves the size field.
                /// </summary>
                public uint size => BitConverter.ToUInt32(_etwEvent.Data[Offset_size..]);

                /// <summary>
                /// Retrieves the daddr field.
                /// </summary>
                public uint daddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_daddr..]);

                /// <summary>
                /// Retrieves the saddr field.
                /// </summary>
                public uint saddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_saddr..]);

                /// <summary>
                /// Retrieves the dport field.
                /// </summary>
                public ushort dport => BitConverter.ToUInt16(_etwEvent.Data[Offset_dport..]);

                /// <summary>
                /// Retrieves the sport field.
                /// </summary>
                public ushort sport => BitConverter.ToUInt16(_etwEvent.Data[Offset_sport..]);

                /// <summary>
                /// Retrieves the startime field.
                /// </summary>
                public uint startime => BitConverter.ToUInt32(_etwEvent.Data[Offset_startime..]);

                /// <summary>
                /// Retrieves the endtime field.
                /// </summary>
                public uint endtime => BitConverter.ToUInt32(_etwEvent.Data[Offset_endtime..]);

                /// <summary>
                /// Retrieves the connid field.
                /// </summary>
                public ulong connid => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_connid..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_connid..]);

                /// <summary>
                /// Retrieves the seqnum field.
                /// </summary>
                public uint seqnum => BitConverter.ToUInt32(_etwEvent.Data[Offset_seqnum..]);

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
                    _offset_startime = -1;
                    _offset_endtime = -1;
                    _offset_connid = -1;
                    _offset_seqnum = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Disconnect event.
        /// </summary>
        public readonly ref struct DisconnectEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Disconnect";

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
                Opcode = (EtwEventOpcode)Opcodes.Disconnect,
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
            public DisconnectData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DisconnectEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DisconnectEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a Disconnect event.
            /// </summary>
            public ref struct DisconnectData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_PID;
                private int _offset_size;
                private int _offset_daddr;
                private int _offset_saddr;
                private int _offset_dport;
                private int _offset_sport;
                private int _offset_connid;
                private int _offset_seqnum;

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

                private int Offset_connid
                {
                    get
                    {
                        if (_offset_connid == -1)
                        {
                            _offset_connid = Offset_sport + 2;
                        }

                        return _offset_connid;
                    }
                }

                private int Offset_seqnum
                {
                    get
                    {
                        if (_offset_seqnum == -1)
                        {
                            _offset_seqnum = Offset_connid + _etwEvent.AddressSize;
                        }

                        return _offset_seqnum;
                    }
                }

                /// <summary>
                /// Retrieves the PID field.
                /// </summary>
                public uint PID => BitConverter.ToUInt32(_etwEvent.Data[Offset_PID..]);

                /// <summary>
                /// Retrieves the size field.
                /// </summary>
                public uint size => BitConverter.ToUInt32(_etwEvent.Data[Offset_size..]);

                /// <summary>
                /// Retrieves the daddr field.
                /// </summary>
                public uint daddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_daddr..]);

                /// <summary>
                /// Retrieves the saddr field.
                /// </summary>
                public uint saddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_saddr..]);

                /// <summary>
                /// Retrieves the dport field.
                /// </summary>
                public ushort dport => BitConverter.ToUInt16(_etwEvent.Data[Offset_dport..]);

                /// <summary>
                /// Retrieves the sport field.
                /// </summary>
                public ushort sport => BitConverter.ToUInt16(_etwEvent.Data[Offset_sport..]);

                /// <summary>
                /// Retrieves the connid field.
                /// </summary>
                public ulong connid => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_connid..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_connid..]);

                /// <summary>
                /// Retrieves the seqnum field.
                /// </summary>
                public uint seqnum => BitConverter.ToUInt32(_etwEvent.Data[Offset_seqnum..]);

                /// <summary>
                /// Creates a new DisconnectData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DisconnectData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_PID = -1;
                    _offset_size = -1;
                    _offset_daddr = -1;
                    _offset_saddr = -1;
                    _offset_dport = -1;
                    _offset_sport = -1;
                    _offset_connid = -1;
                    _offset_seqnum = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Retransmit event.
        /// </summary>
        public readonly ref struct RetransmitEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Retransmit";

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
                Opcode = (EtwEventOpcode)Opcodes.Retransmit,
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
            public RetransmitData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new RetransmitEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public RetransmitEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a Retransmit event.
            /// </summary>
            public ref struct RetransmitData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_PID;
                private int _offset_size;
                private int _offset_daddr;
                private int _offset_saddr;
                private int _offset_dport;
                private int _offset_sport;
                private int _offset_connid;
                private int _offset_seqnum;

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

                private int Offset_connid
                {
                    get
                    {
                        if (_offset_connid == -1)
                        {
                            _offset_connid = Offset_sport + 2;
                        }

                        return _offset_connid;
                    }
                }

                private int Offset_seqnum
                {
                    get
                    {
                        if (_offset_seqnum == -1)
                        {
                            _offset_seqnum = Offset_connid + _etwEvent.AddressSize;
                        }

                        return _offset_seqnum;
                    }
                }

                /// <summary>
                /// Retrieves the PID field.
                /// </summary>
                public uint PID => BitConverter.ToUInt32(_etwEvent.Data[Offset_PID..]);

                /// <summary>
                /// Retrieves the size field.
                /// </summary>
                public uint size => BitConverter.ToUInt32(_etwEvent.Data[Offset_size..]);

                /// <summary>
                /// Retrieves the daddr field.
                /// </summary>
                public uint daddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_daddr..]);

                /// <summary>
                /// Retrieves the saddr field.
                /// </summary>
                public uint saddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_saddr..]);

                /// <summary>
                /// Retrieves the dport field.
                /// </summary>
                public ushort dport => BitConverter.ToUInt16(_etwEvent.Data[Offset_dport..]);

                /// <summary>
                /// Retrieves the sport field.
                /// </summary>
                public ushort sport => BitConverter.ToUInt16(_etwEvent.Data[Offset_sport..]);

                /// <summary>
                /// Retrieves the connid field.
                /// </summary>
                public ulong connid => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_connid..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_connid..]);

                /// <summary>
                /// Retrieves the seqnum field.
                /// </summary>
                public uint seqnum => BitConverter.ToUInt32(_etwEvent.Data[Offset_seqnum..]);

                /// <summary>
                /// Creates a new RetransmitData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public RetransmitData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_PID = -1;
                    _offset_size = -1;
                    _offset_daddr = -1;
                    _offset_saddr = -1;
                    _offset_dport = -1;
                    _offset_sport = -1;
                    _offset_connid = -1;
                    _offset_seqnum = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Reconnect event.
        /// </summary>
        public readonly ref struct ReconnectEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Reconnect";

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
                Opcode = (EtwEventOpcode)Opcodes.Reconnect,
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
            public ReconnectData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ReconnectEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ReconnectEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a Reconnect event.
            /// </summary>
            public ref struct ReconnectData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_PID;
                private int _offset_size;
                private int _offset_daddr;
                private int _offset_saddr;
                private int _offset_dport;
                private int _offset_sport;
                private int _offset_connid;
                private int _offset_seqnum;

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

                private int Offset_connid
                {
                    get
                    {
                        if (_offset_connid == -1)
                        {
                            _offset_connid = Offset_sport + 2;
                        }

                        return _offset_connid;
                    }
                }

                private int Offset_seqnum
                {
                    get
                    {
                        if (_offset_seqnum == -1)
                        {
                            _offset_seqnum = Offset_connid + _etwEvent.AddressSize;
                        }

                        return _offset_seqnum;
                    }
                }

                /// <summary>
                /// Retrieves the PID field.
                /// </summary>
                public uint PID => BitConverter.ToUInt32(_etwEvent.Data[Offset_PID..]);

                /// <summary>
                /// Retrieves the size field.
                /// </summary>
                public uint size => BitConverter.ToUInt32(_etwEvent.Data[Offset_size..]);

                /// <summary>
                /// Retrieves the daddr field.
                /// </summary>
                public uint daddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_daddr..]);

                /// <summary>
                /// Retrieves the saddr field.
                /// </summary>
                public uint saddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_saddr..]);

                /// <summary>
                /// Retrieves the dport field.
                /// </summary>
                public ushort dport => BitConverter.ToUInt16(_etwEvent.Data[Offset_dport..]);

                /// <summary>
                /// Retrieves the sport field.
                /// </summary>
                public ushort sport => BitConverter.ToUInt16(_etwEvent.Data[Offset_sport..]);

                /// <summary>
                /// Retrieves the connid field.
                /// </summary>
                public ulong connid => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_connid..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_connid..]);

                /// <summary>
                /// Retrieves the seqnum field.
                /// </summary>
                public uint seqnum => BitConverter.ToUInt32(_etwEvent.Data[Offset_seqnum..]);

                /// <summary>
                /// Creates a new ReconnectData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ReconnectData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_PID = -1;
                    _offset_size = -1;
                    _offset_daddr = -1;
                    _offset_saddr = -1;
                    _offset_dport = -1;
                    _offset_sport = -1;
                    _offset_connid = -1;
                    _offset_seqnum = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Connect event.
        /// </summary>
        public readonly ref struct ConnectEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Connect";

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
                Opcode = (EtwEventOpcode)Opcodes.Connect,
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
            public ConnectData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ConnectEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ConnectEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a Connect event.
            /// </summary>
            public ref struct ConnectData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_PID;
                private int _offset_size;
                private int _offset_daddr;
                private int _offset_saddr;
                private int _offset_dport;
                private int _offset_sport;
                private int _offset_mss;
                private int _offset_sackopt;
                private int _offset_tsopt;
                private int _offset_wsopt;
                private int _offset_rcvwin;
                private int _offset_rcvwinscale;
                private int _offset_sndwinscale;
                private int _offset_connid;
                private int _offset_seqnum;

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

                private int Offset_mss
                {
                    get
                    {
                        if (_offset_mss == -1)
                        {
                            _offset_mss = Offset_sport + 2;
                        }

                        return _offset_mss;
                    }
                }

                private int Offset_sackopt
                {
                    get
                    {
                        if (_offset_sackopt == -1)
                        {
                            _offset_sackopt = Offset_mss + 2;
                        }

                        return _offset_sackopt;
                    }
                }

                private int Offset_tsopt
                {
                    get
                    {
                        if (_offset_tsopt == -1)
                        {
                            _offset_tsopt = Offset_sackopt + 2;
                        }

                        return _offset_tsopt;
                    }
                }

                private int Offset_wsopt
                {
                    get
                    {
                        if (_offset_wsopt == -1)
                        {
                            _offset_wsopt = Offset_tsopt + 2;
                        }

                        return _offset_wsopt;
                    }
                }

                private int Offset_rcvwin
                {
                    get
                    {
                        if (_offset_rcvwin == -1)
                        {
                            _offset_rcvwin = Offset_wsopt + 2;
                        }

                        return _offset_rcvwin;
                    }
                }

                private int Offset_rcvwinscale
                {
                    get
                    {
                        if (_offset_rcvwinscale == -1)
                        {
                            _offset_rcvwinscale = Offset_rcvwin + 4;
                        }

                        return _offset_rcvwinscale;
                    }
                }

                private int Offset_sndwinscale
                {
                    get
                    {
                        if (_offset_sndwinscale == -1)
                        {
                            _offset_sndwinscale = Offset_rcvwinscale + 2;
                        }

                        return _offset_sndwinscale;
                    }
                }

                private int Offset_connid
                {
                    get
                    {
                        if (_offset_connid == -1)
                        {
                            _offset_connid = Offset_sndwinscale + 2;
                        }

                        return _offset_connid;
                    }
                }

                private int Offset_seqnum
                {
                    get
                    {
                        if (_offset_seqnum == -1)
                        {
                            _offset_seqnum = Offset_connid + _etwEvent.AddressSize;
                        }

                        return _offset_seqnum;
                    }
                }

                /// <summary>
                /// Retrieves the PID field.
                /// </summary>
                public uint PID => BitConverter.ToUInt32(_etwEvent.Data[Offset_PID..]);

                /// <summary>
                /// Retrieves the size field.
                /// </summary>
                public uint size => BitConverter.ToUInt32(_etwEvent.Data[Offset_size..]);

                /// <summary>
                /// Retrieves the daddr field.
                /// </summary>
                public uint daddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_daddr..]);

                /// <summary>
                /// Retrieves the saddr field.
                /// </summary>
                public uint saddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_saddr..]);

                /// <summary>
                /// Retrieves the dport field.
                /// </summary>
                public ushort dport => BitConverter.ToUInt16(_etwEvent.Data[Offset_dport..]);

                /// <summary>
                /// Retrieves the sport field.
                /// </summary>
                public ushort sport => BitConverter.ToUInt16(_etwEvent.Data[Offset_sport..]);

                /// <summary>
                /// Retrieves the mss field.
                /// </summary>
                public ushort mss => BitConverter.ToUInt16(_etwEvent.Data[Offset_mss..]);

                /// <summary>
                /// Retrieves the sackopt field.
                /// </summary>
                public ushort sackopt => BitConverter.ToUInt16(_etwEvent.Data[Offset_sackopt..]);

                /// <summary>
                /// Retrieves the tsopt field.
                /// </summary>
                public ushort tsopt => BitConverter.ToUInt16(_etwEvent.Data[Offset_tsopt..]);

                /// <summary>
                /// Retrieves the wsopt field.
                /// </summary>
                public ushort wsopt => BitConverter.ToUInt16(_etwEvent.Data[Offset_wsopt..]);

                /// <summary>
                /// Retrieves the rcvwin field.
                /// </summary>
                public uint rcvwin => BitConverter.ToUInt32(_etwEvent.Data[Offset_rcvwin..]);

                /// <summary>
                /// Retrieves the rcvwinscale field.
                /// </summary>
                public short rcvwinscale => BitConverter.ToInt16(_etwEvent.Data[Offset_rcvwinscale..]);

                /// <summary>
                /// Retrieves the sndwinscale field.
                /// </summary>
                public short sndwinscale => BitConverter.ToInt16(_etwEvent.Data[Offset_sndwinscale..]);

                /// <summary>
                /// Retrieves the connid field.
                /// </summary>
                public ulong connid => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_connid..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_connid..]);

                /// <summary>
                /// Retrieves the seqnum field.
                /// </summary>
                public uint seqnum => BitConverter.ToUInt32(_etwEvent.Data[Offset_seqnum..]);

                /// <summary>
                /// Creates a new ConnectData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ConnectData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_PID = -1;
                    _offset_size = -1;
                    _offset_daddr = -1;
                    _offset_saddr = -1;
                    _offset_dport = -1;
                    _offset_sport = -1;
                    _offset_mss = -1;
                    _offset_sackopt = -1;
                    _offset_tsopt = -1;
                    _offset_wsopt = -1;
                    _offset_rcvwin = -1;
                    _offset_rcvwinscale = -1;
                    _offset_sndwinscale = -1;
                    _offset_connid = -1;
                    _offset_seqnum = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Accept event.
        /// </summary>
        public readonly ref struct AcceptEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Accept";

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
                Opcode = (EtwEventOpcode)Opcodes.Accept,
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
            public AcceptData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new AcceptEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public AcceptEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a Accept event.
            /// </summary>
            public ref struct AcceptData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_PID;
                private int _offset_size;
                private int _offset_daddr;
                private int _offset_saddr;
                private int _offset_dport;
                private int _offset_sport;
                private int _offset_mss;
                private int _offset_sackopt;
                private int _offset_tsopt;
                private int _offset_wsopt;
                private int _offset_rcvwin;
                private int _offset_rcvwinscale;
                private int _offset_sndwinscale;
                private int _offset_connid;
                private int _offset_seqnum;

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

                private int Offset_mss
                {
                    get
                    {
                        if (_offset_mss == -1)
                        {
                            _offset_mss = Offset_sport + 2;
                        }

                        return _offset_mss;
                    }
                }

                private int Offset_sackopt
                {
                    get
                    {
                        if (_offset_sackopt == -1)
                        {
                            _offset_sackopt = Offset_mss + 2;
                        }

                        return _offset_sackopt;
                    }
                }

                private int Offset_tsopt
                {
                    get
                    {
                        if (_offset_tsopt == -1)
                        {
                            _offset_tsopt = Offset_sackopt + 2;
                        }

                        return _offset_tsopt;
                    }
                }

                private int Offset_wsopt
                {
                    get
                    {
                        if (_offset_wsopt == -1)
                        {
                            _offset_wsopt = Offset_tsopt + 2;
                        }

                        return _offset_wsopt;
                    }
                }

                private int Offset_rcvwin
                {
                    get
                    {
                        if (_offset_rcvwin == -1)
                        {
                            _offset_rcvwin = Offset_wsopt + 2;
                        }

                        return _offset_rcvwin;
                    }
                }

                private int Offset_rcvwinscale
                {
                    get
                    {
                        if (_offset_rcvwinscale == -1)
                        {
                            _offset_rcvwinscale = Offset_rcvwin + 4;
                        }

                        return _offset_rcvwinscale;
                    }
                }

                private int Offset_sndwinscale
                {
                    get
                    {
                        if (_offset_sndwinscale == -1)
                        {
                            _offset_sndwinscale = Offset_rcvwinscale + 2;
                        }

                        return _offset_sndwinscale;
                    }
                }

                private int Offset_connid
                {
                    get
                    {
                        if (_offset_connid == -1)
                        {
                            _offset_connid = Offset_sndwinscale + 2;
                        }

                        return _offset_connid;
                    }
                }

                private int Offset_seqnum
                {
                    get
                    {
                        if (_offset_seqnum == -1)
                        {
                            _offset_seqnum = Offset_connid + _etwEvent.AddressSize;
                        }

                        return _offset_seqnum;
                    }
                }

                /// <summary>
                /// Retrieves the PID field.
                /// </summary>
                public uint PID => BitConverter.ToUInt32(_etwEvent.Data[Offset_PID..]);

                /// <summary>
                /// Retrieves the size field.
                /// </summary>
                public uint size => BitConverter.ToUInt32(_etwEvent.Data[Offset_size..]);

                /// <summary>
                /// Retrieves the daddr field.
                /// </summary>
                public uint daddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_daddr..]);

                /// <summary>
                /// Retrieves the saddr field.
                /// </summary>
                public uint saddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_saddr..]);

                /// <summary>
                /// Retrieves the dport field.
                /// </summary>
                public ushort dport => BitConverter.ToUInt16(_etwEvent.Data[Offset_dport..]);

                /// <summary>
                /// Retrieves the sport field.
                /// </summary>
                public ushort sport => BitConverter.ToUInt16(_etwEvent.Data[Offset_sport..]);

                /// <summary>
                /// Retrieves the mss field.
                /// </summary>
                public ushort mss => BitConverter.ToUInt16(_etwEvent.Data[Offset_mss..]);

                /// <summary>
                /// Retrieves the sackopt field.
                /// </summary>
                public ushort sackopt => BitConverter.ToUInt16(_etwEvent.Data[Offset_sackopt..]);

                /// <summary>
                /// Retrieves the tsopt field.
                /// </summary>
                public ushort tsopt => BitConverter.ToUInt16(_etwEvent.Data[Offset_tsopt..]);

                /// <summary>
                /// Retrieves the wsopt field.
                /// </summary>
                public ushort wsopt => BitConverter.ToUInt16(_etwEvent.Data[Offset_wsopt..]);

                /// <summary>
                /// Retrieves the rcvwin field.
                /// </summary>
                public uint rcvwin => BitConverter.ToUInt32(_etwEvent.Data[Offset_rcvwin..]);

                /// <summary>
                /// Retrieves the rcvwinscale field.
                /// </summary>
                public short rcvwinscale => BitConverter.ToInt16(_etwEvent.Data[Offset_rcvwinscale..]);

                /// <summary>
                /// Retrieves the sndwinscale field.
                /// </summary>
                public short sndwinscale => BitConverter.ToInt16(_etwEvent.Data[Offset_sndwinscale..]);

                /// <summary>
                /// Retrieves the connid field.
                /// </summary>
                public ulong connid => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_connid..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_connid..]);

                /// <summary>
                /// Retrieves the seqnum field.
                /// </summary>
                public uint seqnum => BitConverter.ToUInt32(_etwEvent.Data[Offset_seqnum..]);

                /// <summary>
                /// Creates a new AcceptData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public AcceptData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_PID = -1;
                    _offset_size = -1;
                    _offset_daddr = -1;
                    _offset_saddr = -1;
                    _offset_dport = -1;
                    _offset_sport = -1;
                    _offset_mss = -1;
                    _offset_sackopt = -1;
                    _offset_tsopt = -1;
                    _offset_wsopt = -1;
                    _offset_rcvwin = -1;
                    _offset_rcvwinscale = -1;
                    _offset_sndwinscale = -1;
                    _offset_connid = -1;
                    _offset_seqnum = -1;
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
                private int _offset_connid;
                private int _offset_seqnum;

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

                private int Offset_connid
                {
                    get
                    {
                        if (_offset_connid == -1)
                        {
                            _offset_connid = Offset_sport + 2;
                        }

                        return _offset_connid;
                    }
                }

                private int Offset_seqnum
                {
                    get
                    {
                        if (_offset_seqnum == -1)
                        {
                            _offset_seqnum = Offset_connid + _etwEvent.AddressSize;
                        }

                        return _offset_seqnum;
                    }
                }

                /// <summary>
                /// Retrieves the PID field.
                /// </summary>
                public uint PID => BitConverter.ToUInt32(_etwEvent.Data[Offset_PID..]);

                /// <summary>
                /// Retrieves the size field.
                /// </summary>
                public uint size => BitConverter.ToUInt32(_etwEvent.Data[Offset_size..]);

                /// <summary>
                /// Retrieves the daddr field.
                /// </summary>
                public uint daddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_daddr..]);

                /// <summary>
                /// Retrieves the saddr field.
                /// </summary>
                public uint saddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_saddr..]);

                /// <summary>
                /// Retrieves the dport field.
                /// </summary>
                public ushort dport => BitConverter.ToUInt16(_etwEvent.Data[Offset_dport..]);

                /// <summary>
                /// Retrieves the sport field.
                /// </summary>
                public ushort sport => BitConverter.ToUInt16(_etwEvent.Data[Offset_sport..]);

                /// <summary>
                /// Retrieves the connid field.
                /// </summary>
                public ulong connid => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_connid..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_connid..]);

                /// <summary>
                /// Retrieves the seqnum field.
                /// </summary>
                public uint seqnum => BitConverter.ToUInt32(_etwEvent.Data[Offset_seqnum..]);

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
                    _offset_connid = -1;
                    _offset_seqnum = -1;
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
                public uint PID => BitConverter.ToUInt32(_etwEvent.Data[Offset_PID..]);

                /// <summary>
                /// Retrieves the size field.
                /// </summary>
                public uint size => BitConverter.ToUInt32(_etwEvent.Data[Offset_size..]);

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
                public ushort dport => BitConverter.ToUInt16(_etwEvent.Data[Offset_dport..]);

                /// <summary>
                /// Retrieves the sport field.
                /// </summary>
                public ushort sport => BitConverter.ToUInt16(_etwEvent.Data[Offset_sport..]);

                /// <summary>
                /// Retrieves the seqnum field.
                /// </summary>
                public uint seqnum => BitConverter.ToUInt32(_etwEvent.Data[Offset_seqnum..]);

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
        /// An event wrapper for a DisconnectIPV6 event.
        /// </summary>
        public readonly ref struct DisconnectIPV6EventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DisconnectIPV6";

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
                Opcode = (EtwEventOpcode)Opcodes.DisconnectIPV6,
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
            public DisconnectIPV6Data Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DisconnectIPV6EventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DisconnectIPV6EventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a DisconnectIPV6 event.
            /// </summary>
            public ref struct DisconnectIPV6Data
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
                public uint PID => BitConverter.ToUInt32(_etwEvent.Data[Offset_PID..]);

                /// <summary>
                /// Retrieves the size field.
                /// </summary>
                public uint size => BitConverter.ToUInt32(_etwEvent.Data[Offset_size..]);

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
                public ushort dport => BitConverter.ToUInt16(_etwEvent.Data[Offset_dport..]);

                /// <summary>
                /// Retrieves the sport field.
                /// </summary>
                public ushort sport => BitConverter.ToUInt16(_etwEvent.Data[Offset_sport..]);

                /// <summary>
                /// Retrieves the seqnum field.
                /// </summary>
                public uint seqnum => BitConverter.ToUInt32(_etwEvent.Data[Offset_seqnum..]);

                /// <summary>
                /// Retrieves the connid field.
                /// </summary>
                public ulong connid => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_connid..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_connid..]);

                /// <summary>
                /// Creates a new DisconnectIPV6Data.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DisconnectIPV6Data(EtwEvent etwEvent)
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
        /// An event wrapper for a RetransmitIPV6 event.
        /// </summary>
        public readonly ref struct RetransmitIPV6EventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "RetransmitIPV6";

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
                Opcode = (EtwEventOpcode)Opcodes.RetransmitIPV6,
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
            public RetransmitIPV6Data Data => new(_etwEvent);

            /// <summary>
            /// Creates a new RetransmitIPV6EventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public RetransmitIPV6EventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a RetransmitIPV6 event.
            /// </summary>
            public ref struct RetransmitIPV6Data
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
                public uint PID => BitConverter.ToUInt32(_etwEvent.Data[Offset_PID..]);

                /// <summary>
                /// Retrieves the size field.
                /// </summary>
                public uint size => BitConverter.ToUInt32(_etwEvent.Data[Offset_size..]);

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
                public ushort dport => BitConverter.ToUInt16(_etwEvent.Data[Offset_dport..]);

                /// <summary>
                /// Retrieves the sport field.
                /// </summary>
                public ushort sport => BitConverter.ToUInt16(_etwEvent.Data[Offset_sport..]);

                /// <summary>
                /// Retrieves the seqnum field.
                /// </summary>
                public uint seqnum => BitConverter.ToUInt32(_etwEvent.Data[Offset_seqnum..]);

                /// <summary>
                /// Retrieves the connid field.
                /// </summary>
                public ulong connid => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_connid..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_connid..]);

                /// <summary>
                /// Creates a new RetransmitIPV6Data.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public RetransmitIPV6Data(EtwEvent etwEvent)
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
        /// An event wrapper for a ReconnectIPV6 event.
        /// </summary>
        public readonly ref struct ReconnectIPV6EventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ReconnectIPV6";

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
                Opcode = (EtwEventOpcode)Opcodes.ReconnectIPV6,
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
            public ReconnectIPV6Data Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ReconnectIPV6EventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ReconnectIPV6EventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ReconnectIPV6 event.
            /// </summary>
            public ref struct ReconnectIPV6Data
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
                public uint PID => BitConverter.ToUInt32(_etwEvent.Data[Offset_PID..]);

                /// <summary>
                /// Retrieves the size field.
                /// </summary>
                public uint size => BitConverter.ToUInt32(_etwEvent.Data[Offset_size..]);

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
                public ushort dport => BitConverter.ToUInt16(_etwEvent.Data[Offset_dport..]);

                /// <summary>
                /// Retrieves the sport field.
                /// </summary>
                public ushort sport => BitConverter.ToUInt16(_etwEvent.Data[Offset_sport..]);

                /// <summary>
                /// Retrieves the seqnum field.
                /// </summary>
                public uint seqnum => BitConverter.ToUInt32(_etwEvent.Data[Offset_seqnum..]);

                /// <summary>
                /// Retrieves the connid field.
                /// </summary>
                public ulong connid => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_connid..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_connid..]);

                /// <summary>
                /// Creates a new ReconnectIPV6Data.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ReconnectIPV6Data(EtwEvent etwEvent)
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
        /// An event wrapper for a TCPCopyIPV6 event.
        /// </summary>
        public readonly ref struct TCPCopyIPV6EventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "TCPCopyIPV6";

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
                Opcode = (EtwEventOpcode)Opcodes.TCPCopyIPV6,
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
            public TCPCopyIPV6Data Data => new(_etwEvent);

            /// <summary>
            /// Creates a new TCPCopyIPV6EventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public TCPCopyIPV6EventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a TCPCopyIPV6 event.
            /// </summary>
            public ref struct TCPCopyIPV6Data
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
                public uint PID => BitConverter.ToUInt32(_etwEvent.Data[Offset_PID..]);

                /// <summary>
                /// Retrieves the size field.
                /// </summary>
                public uint size => BitConverter.ToUInt32(_etwEvent.Data[Offset_size..]);

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
                public ushort dport => BitConverter.ToUInt16(_etwEvent.Data[Offset_dport..]);

                /// <summary>
                /// Retrieves the sport field.
                /// </summary>
                public ushort sport => BitConverter.ToUInt16(_etwEvent.Data[Offset_sport..]);

                /// <summary>
                /// Retrieves the seqnum field.
                /// </summary>
                public uint seqnum => BitConverter.ToUInt32(_etwEvent.Data[Offset_seqnum..]);

                /// <summary>
                /// Retrieves the connid field.
                /// </summary>
                public ulong connid => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_connid..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_connid..]);

                /// <summary>
                /// Creates a new TCPCopyIPV6Data.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public TCPCopyIPV6Data(EtwEvent etwEvent)
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
                private int _offset_startime;
                private int _offset_endtime;
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

                private int Offset_startime
                {
                    get
                    {
                        if (_offset_startime == -1)
                        {
                            _offset_startime = Offset_sport + 2;
                        }

                        return _offset_startime;
                    }
                }

                private int Offset_endtime
                {
                    get
                    {
                        if (_offset_endtime == -1)
                        {
                            _offset_endtime = Offset_startime + 4;
                        }

                        return _offset_endtime;
                    }
                }

                private int Offset_seqnum
                {
                    get
                    {
                        if (_offset_seqnum == -1)
                        {
                            _offset_seqnum = Offset_endtime + 4;
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
                public uint PID => BitConverter.ToUInt32(_etwEvent.Data[Offset_PID..]);

                /// <summary>
                /// Retrieves the size field.
                /// </summary>
                public uint size => BitConverter.ToUInt32(_etwEvent.Data[Offset_size..]);

                /// <summary>
                /// Retrieves the daddr field.
                /// </summary>
                public uint daddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_daddr..]);

                /// <summary>
                /// Retrieves the saddr field.
                /// </summary>
                public uint saddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_saddr..]);

                /// <summary>
                /// Retrieves the dport field.
                /// </summary>
                public ushort dport => BitConverter.ToUInt16(_etwEvent.Data[Offset_dport..]);

                /// <summary>
                /// Retrieves the sport field.
                /// </summary>
                public ushort sport => BitConverter.ToUInt16(_etwEvent.Data[Offset_sport..]);

                /// <summary>
                /// Retrieves the startime field.
                /// </summary>
                public uint startime => BitConverter.ToUInt32(_etwEvent.Data[Offset_startime..]);

                /// <summary>
                /// Retrieves the endtime field.
                /// </summary>
                public uint endtime => BitConverter.ToUInt32(_etwEvent.Data[Offset_endtime..]);

                /// <summary>
                /// Retrieves the seqnum field.
                /// </summary>
                public uint seqnum => BitConverter.ToUInt32(_etwEvent.Data[Offset_seqnum..]);

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
                    _offset_startime = -1;
                    _offset_endtime = -1;
                    _offset_seqnum = -1;
                    _offset_connid = -1;
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
                public ushort Proto => BitConverter.ToUInt16(_etwEvent.Data[Offset_Proto..]);

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
        /// An event wrapper for a ConnectIPV4 event.
        /// </summary>
        public readonly ref struct ConnectIPV4EventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ConnectIPV4";

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
                Opcode = (EtwEventOpcode)Opcodes.Connect,
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
            public ConnectIPV4Data Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ConnectIPV4EventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ConnectIPV4EventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ConnectIPV4 event.
            /// </summary>
            public ref struct ConnectIPV4Data
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_PID;
                private int _offset_size;
                private int _offset_daddr;
                private int _offset_saddr;
                private int _offset_dport;
                private int _offset_sport;
                private int _offset_mss;
                private int _offset_sackopt;
                private int _offset_tsopt;
                private int _offset_wsopt;
                private int _offset_rcvwin;
                private int _offset_rcvwinscale;
                private int _offset_sndwinscale;
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

                private int Offset_mss
                {
                    get
                    {
                        if (_offset_mss == -1)
                        {
                            _offset_mss = Offset_sport + 2;
                        }

                        return _offset_mss;
                    }
                }

                private int Offset_sackopt
                {
                    get
                    {
                        if (_offset_sackopt == -1)
                        {
                            _offset_sackopt = Offset_mss + 2;
                        }

                        return _offset_sackopt;
                    }
                }

                private int Offset_tsopt
                {
                    get
                    {
                        if (_offset_tsopt == -1)
                        {
                            _offset_tsopt = Offset_sackopt + 2;
                        }

                        return _offset_tsopt;
                    }
                }

                private int Offset_wsopt
                {
                    get
                    {
                        if (_offset_wsopt == -1)
                        {
                            _offset_wsopt = Offset_tsopt + 2;
                        }

                        return _offset_wsopt;
                    }
                }

                private int Offset_rcvwin
                {
                    get
                    {
                        if (_offset_rcvwin == -1)
                        {
                            _offset_rcvwin = Offset_wsopt + 2;
                        }

                        return _offset_rcvwin;
                    }
                }

                private int Offset_rcvwinscale
                {
                    get
                    {
                        if (_offset_rcvwinscale == -1)
                        {
                            _offset_rcvwinscale = Offset_rcvwin + 4;
                        }

                        return _offset_rcvwinscale;
                    }
                }

                private int Offset_sndwinscale
                {
                    get
                    {
                        if (_offset_sndwinscale == -1)
                        {
                            _offset_sndwinscale = Offset_rcvwinscale + 2;
                        }

                        return _offset_sndwinscale;
                    }
                }

                private int Offset_seqnum
                {
                    get
                    {
                        if (_offset_seqnum == -1)
                        {
                            _offset_seqnum = Offset_sndwinscale + 2;
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
                public uint PID => BitConverter.ToUInt32(_etwEvent.Data[Offset_PID..]);

                /// <summary>
                /// Retrieves the size field.
                /// </summary>
                public uint size => BitConverter.ToUInt32(_etwEvent.Data[Offset_size..]);

                /// <summary>
                /// Retrieves the daddr field.
                /// </summary>
                public uint daddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_daddr..]);

                /// <summary>
                /// Retrieves the saddr field.
                /// </summary>
                public uint saddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_saddr..]);

                /// <summary>
                /// Retrieves the dport field.
                /// </summary>
                public ushort dport => BitConverter.ToUInt16(_etwEvent.Data[Offset_dport..]);

                /// <summary>
                /// Retrieves the sport field.
                /// </summary>
                public ushort sport => BitConverter.ToUInt16(_etwEvent.Data[Offset_sport..]);

                /// <summary>
                /// Retrieves the mss field.
                /// </summary>
                public ushort mss => BitConverter.ToUInt16(_etwEvent.Data[Offset_mss..]);

                /// <summary>
                /// Retrieves the sackopt field.
                /// </summary>
                public ushort sackopt => BitConverter.ToUInt16(_etwEvent.Data[Offset_sackopt..]);

                /// <summary>
                /// Retrieves the tsopt field.
                /// </summary>
                public ushort tsopt => BitConverter.ToUInt16(_etwEvent.Data[Offset_tsopt..]);

                /// <summary>
                /// Retrieves the wsopt field.
                /// </summary>
                public ushort wsopt => BitConverter.ToUInt16(_etwEvent.Data[Offset_wsopt..]);

                /// <summary>
                /// Retrieves the rcvwin field.
                /// </summary>
                public uint rcvwin => BitConverter.ToUInt32(_etwEvent.Data[Offset_rcvwin..]);

                /// <summary>
                /// Retrieves the rcvwinscale field.
                /// </summary>
                public short rcvwinscale => BitConverter.ToInt16(_etwEvent.Data[Offset_rcvwinscale..]);

                /// <summary>
                /// Retrieves the sndwinscale field.
                /// </summary>
                public short sndwinscale => BitConverter.ToInt16(_etwEvent.Data[Offset_sndwinscale..]);

                /// <summary>
                /// Retrieves the seqnum field.
                /// </summary>
                public uint seqnum => BitConverter.ToUInt32(_etwEvent.Data[Offset_seqnum..]);

                /// <summary>
                /// Retrieves the connid field.
                /// </summary>
                public ulong connid => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_connid..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_connid..]);

                /// <summary>
                /// Creates a new ConnectIPV4Data.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ConnectIPV4Data(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_PID = -1;
                    _offset_size = -1;
                    _offset_daddr = -1;
                    _offset_saddr = -1;
                    _offset_dport = -1;
                    _offset_sport = -1;
                    _offset_mss = -1;
                    _offset_sackopt = -1;
                    _offset_tsopt = -1;
                    _offset_wsopt = -1;
                    _offset_rcvwin = -1;
                    _offset_rcvwinscale = -1;
                    _offset_sndwinscale = -1;
                    _offset_seqnum = -1;
                    _offset_connid = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a AcceptIPV4 event.
        /// </summary>
        public readonly ref struct AcceptIPV4EventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "AcceptIPV4";

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
                Opcode = (EtwEventOpcode)Opcodes.Accept,
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
            public AcceptIPV4Data Data => new(_etwEvent);

            /// <summary>
            /// Creates a new AcceptIPV4EventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public AcceptIPV4EventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a AcceptIPV4 event.
            /// </summary>
            public ref struct AcceptIPV4Data
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_PID;
                private int _offset_size;
                private int _offset_daddr;
                private int _offset_saddr;
                private int _offset_dport;
                private int _offset_sport;
                private int _offset_mss;
                private int _offset_sackopt;
                private int _offset_tsopt;
                private int _offset_wsopt;
                private int _offset_rcvwin;
                private int _offset_rcvwinscale;
                private int _offset_sndwinscale;
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

                private int Offset_mss
                {
                    get
                    {
                        if (_offset_mss == -1)
                        {
                            _offset_mss = Offset_sport + 2;
                        }

                        return _offset_mss;
                    }
                }

                private int Offset_sackopt
                {
                    get
                    {
                        if (_offset_sackopt == -1)
                        {
                            _offset_sackopt = Offset_mss + 2;
                        }

                        return _offset_sackopt;
                    }
                }

                private int Offset_tsopt
                {
                    get
                    {
                        if (_offset_tsopt == -1)
                        {
                            _offset_tsopt = Offset_sackopt + 2;
                        }

                        return _offset_tsopt;
                    }
                }

                private int Offset_wsopt
                {
                    get
                    {
                        if (_offset_wsopt == -1)
                        {
                            _offset_wsopt = Offset_tsopt + 2;
                        }

                        return _offset_wsopt;
                    }
                }

                private int Offset_rcvwin
                {
                    get
                    {
                        if (_offset_rcvwin == -1)
                        {
                            _offset_rcvwin = Offset_wsopt + 2;
                        }

                        return _offset_rcvwin;
                    }
                }

                private int Offset_rcvwinscale
                {
                    get
                    {
                        if (_offset_rcvwinscale == -1)
                        {
                            _offset_rcvwinscale = Offset_rcvwin + 4;
                        }

                        return _offset_rcvwinscale;
                    }
                }

                private int Offset_sndwinscale
                {
                    get
                    {
                        if (_offset_sndwinscale == -1)
                        {
                            _offset_sndwinscale = Offset_rcvwinscale + 2;
                        }

                        return _offset_sndwinscale;
                    }
                }

                private int Offset_seqnum
                {
                    get
                    {
                        if (_offset_seqnum == -1)
                        {
                            _offset_seqnum = Offset_sndwinscale + 2;
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
                public uint PID => BitConverter.ToUInt32(_etwEvent.Data[Offset_PID..]);

                /// <summary>
                /// Retrieves the size field.
                /// </summary>
                public uint size => BitConverter.ToUInt32(_etwEvent.Data[Offset_size..]);

                /// <summary>
                /// Retrieves the daddr field.
                /// </summary>
                public uint daddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_daddr..]);

                /// <summary>
                /// Retrieves the saddr field.
                /// </summary>
                public uint saddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_saddr..]);

                /// <summary>
                /// Retrieves the dport field.
                /// </summary>
                public ushort dport => BitConverter.ToUInt16(_etwEvent.Data[Offset_dport..]);

                /// <summary>
                /// Retrieves the sport field.
                /// </summary>
                public ushort sport => BitConverter.ToUInt16(_etwEvent.Data[Offset_sport..]);

                /// <summary>
                /// Retrieves the mss field.
                /// </summary>
                public ushort mss => BitConverter.ToUInt16(_etwEvent.Data[Offset_mss..]);

                /// <summary>
                /// Retrieves the sackopt field.
                /// </summary>
                public ushort sackopt => BitConverter.ToUInt16(_etwEvent.Data[Offset_sackopt..]);

                /// <summary>
                /// Retrieves the tsopt field.
                /// </summary>
                public ushort tsopt => BitConverter.ToUInt16(_etwEvent.Data[Offset_tsopt..]);

                /// <summary>
                /// Retrieves the wsopt field.
                /// </summary>
                public ushort wsopt => BitConverter.ToUInt16(_etwEvent.Data[Offset_wsopt..]);

                /// <summary>
                /// Retrieves the rcvwin field.
                /// </summary>
                public uint rcvwin => BitConverter.ToUInt32(_etwEvent.Data[Offset_rcvwin..]);

                /// <summary>
                /// Retrieves the rcvwinscale field.
                /// </summary>
                public short rcvwinscale => BitConverter.ToInt16(_etwEvent.Data[Offset_rcvwinscale..]);

                /// <summary>
                /// Retrieves the sndwinscale field.
                /// </summary>
                public short sndwinscale => BitConverter.ToInt16(_etwEvent.Data[Offset_sndwinscale..]);

                /// <summary>
                /// Retrieves the seqnum field.
                /// </summary>
                public uint seqnum => BitConverter.ToUInt32(_etwEvent.Data[Offset_seqnum..]);

                /// <summary>
                /// Retrieves the connid field.
                /// </summary>
                public ulong connid => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_connid..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_connid..]);

                /// <summary>
                /// Creates a new AcceptIPV4Data.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public AcceptIPV4Data(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_PID = -1;
                    _offset_size = -1;
                    _offset_daddr = -1;
                    _offset_saddr = -1;
                    _offset_dport = -1;
                    _offset_sport = -1;
                    _offset_mss = -1;
                    _offset_sackopt = -1;
                    _offset_tsopt = -1;
                    _offset_wsopt = -1;
                    _offset_rcvwin = -1;
                    _offset_rcvwinscale = -1;
                    _offset_sndwinscale = -1;
                    _offset_seqnum = -1;
                    _offset_connid = -1;
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
                private int _offset_startime;
                private int _offset_endtime;
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

                private int Offset_startime
                {
                    get
                    {
                        if (_offset_startime == -1)
                        {
                            _offset_startime = Offset_sport + 2;
                        }

                        return _offset_startime;
                    }
                }

                private int Offset_endtime
                {
                    get
                    {
                        if (_offset_endtime == -1)
                        {
                            _offset_endtime = Offset_startime + 4;
                        }

                        return _offset_endtime;
                    }
                }

                private int Offset_seqnum
                {
                    get
                    {
                        if (_offset_seqnum == -1)
                        {
                            _offset_seqnum = Offset_endtime + 4;
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
                public uint PID => BitConverter.ToUInt32(_etwEvent.Data[Offset_PID..]);

                /// <summary>
                /// Retrieves the size field.
                /// </summary>
                public uint size => BitConverter.ToUInt32(_etwEvent.Data[Offset_size..]);

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
                public ushort dport => BitConverter.ToUInt16(_etwEvent.Data[Offset_dport..]);

                /// <summary>
                /// Retrieves the sport field.
                /// </summary>
                public ushort sport => BitConverter.ToUInt16(_etwEvent.Data[Offset_sport..]);

                /// <summary>
                /// Retrieves the startime field.
                /// </summary>
                public uint startime => BitConverter.ToUInt32(_etwEvent.Data[Offset_startime..]);

                /// <summary>
                /// Retrieves the endtime field.
                /// </summary>
                public uint endtime => BitConverter.ToUInt32(_etwEvent.Data[Offset_endtime..]);

                /// <summary>
                /// Retrieves the seqnum field.
                /// </summary>
                public uint seqnum => BitConverter.ToUInt32(_etwEvent.Data[Offset_seqnum..]);

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
                    _offset_startime = -1;
                    _offset_endtime = -1;
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
                public uint PID => BitConverter.ToUInt32(_etwEvent.Data[Offset_PID..]);

                /// <summary>
                /// Retrieves the size field.
                /// </summary>
                public uint size => BitConverter.ToUInt32(_etwEvent.Data[Offset_size..]);

                /// <summary>
                /// Retrieves the daddr field.
                /// </summary>
                public uint daddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_daddr..]);

                /// <summary>
                /// Retrieves the saddr field.
                /// </summary>
                public uint saddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_saddr..]);

                /// <summary>
                /// Retrieves the dport field.
                /// </summary>
                public ushort dport => BitConverter.ToUInt16(_etwEvent.Data[Offset_dport..]);

                /// <summary>
                /// Retrieves the sport field.
                /// </summary>
                public ushort sport => BitConverter.ToUInt16(_etwEvent.Data[Offset_sport..]);

                /// <summary>
                /// Retrieves the seqnum field.
                /// </summary>
                public uint seqnum => BitConverter.ToUInt32(_etwEvent.Data[Offset_seqnum..]);

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

        /// <summary>
        /// An event wrapper for a DisconnectIPV4 event.
        /// </summary>
        public readonly ref struct DisconnectIPV4EventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DisconnectIPV4";

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
                Opcode = (EtwEventOpcode)Opcodes.Disconnect,
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
            public DisconnectIPV4Data Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DisconnectIPV4EventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DisconnectIPV4EventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a DisconnectIPV4 event.
            /// </summary>
            public ref struct DisconnectIPV4Data
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
                public uint PID => BitConverter.ToUInt32(_etwEvent.Data[Offset_PID..]);

                /// <summary>
                /// Retrieves the size field.
                /// </summary>
                public uint size => BitConverter.ToUInt32(_etwEvent.Data[Offset_size..]);

                /// <summary>
                /// Retrieves the daddr field.
                /// </summary>
                public uint daddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_daddr..]);

                /// <summary>
                /// Retrieves the saddr field.
                /// </summary>
                public uint saddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_saddr..]);

                /// <summary>
                /// Retrieves the dport field.
                /// </summary>
                public ushort dport => BitConverter.ToUInt16(_etwEvent.Data[Offset_dport..]);

                /// <summary>
                /// Retrieves the sport field.
                /// </summary>
                public ushort sport => BitConverter.ToUInt16(_etwEvent.Data[Offset_sport..]);

                /// <summary>
                /// Retrieves the seqnum field.
                /// </summary>
                public uint seqnum => BitConverter.ToUInt32(_etwEvent.Data[Offset_seqnum..]);

                /// <summary>
                /// Retrieves the connid field.
                /// </summary>
                public ulong connid => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_connid..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_connid..]);

                /// <summary>
                /// Creates a new DisconnectIPV4Data.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DisconnectIPV4Data(EtwEvent etwEvent)
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
        /// An event wrapper for a RetransmitIPV4 event.
        /// </summary>
        public readonly ref struct RetransmitIPV4EventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "RetransmitIPV4";

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
                Opcode = (EtwEventOpcode)Opcodes.Retransmit,
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
            public RetransmitIPV4Data Data => new(_etwEvent);

            /// <summary>
            /// Creates a new RetransmitIPV4EventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public RetransmitIPV4EventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a RetransmitIPV4 event.
            /// </summary>
            public ref struct RetransmitIPV4Data
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
                public uint PID => BitConverter.ToUInt32(_etwEvent.Data[Offset_PID..]);

                /// <summary>
                /// Retrieves the size field.
                /// </summary>
                public uint size => BitConverter.ToUInt32(_etwEvent.Data[Offset_size..]);

                /// <summary>
                /// Retrieves the daddr field.
                /// </summary>
                public uint daddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_daddr..]);

                /// <summary>
                /// Retrieves the saddr field.
                /// </summary>
                public uint saddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_saddr..]);

                /// <summary>
                /// Retrieves the dport field.
                /// </summary>
                public ushort dport => BitConverter.ToUInt16(_etwEvent.Data[Offset_dport..]);

                /// <summary>
                /// Retrieves the sport field.
                /// </summary>
                public ushort sport => BitConverter.ToUInt16(_etwEvent.Data[Offset_sport..]);

                /// <summary>
                /// Retrieves the seqnum field.
                /// </summary>
                public uint seqnum => BitConverter.ToUInt32(_etwEvent.Data[Offset_seqnum..]);

                /// <summary>
                /// Retrieves the connid field.
                /// </summary>
                public ulong connid => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_connid..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_connid..]);

                /// <summary>
                /// Creates a new RetransmitIPV4Data.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public RetransmitIPV4Data(EtwEvent etwEvent)
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
        /// An event wrapper for a ReconnectIPV4 event.
        /// </summary>
        public readonly ref struct ReconnectIPV4EventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ReconnectIPV4";

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
                Opcode = (EtwEventOpcode)Opcodes.Reconnect,
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
            public ReconnectIPV4Data Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ReconnectIPV4EventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ReconnectIPV4EventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ReconnectIPV4 event.
            /// </summary>
            public ref struct ReconnectIPV4Data
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
                public uint PID => BitConverter.ToUInt32(_etwEvent.Data[Offset_PID..]);

                /// <summary>
                /// Retrieves the size field.
                /// </summary>
                public uint size => BitConverter.ToUInt32(_etwEvent.Data[Offset_size..]);

                /// <summary>
                /// Retrieves the daddr field.
                /// </summary>
                public uint daddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_daddr..]);

                /// <summary>
                /// Retrieves the saddr field.
                /// </summary>
                public uint saddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_saddr..]);

                /// <summary>
                /// Retrieves the dport field.
                /// </summary>
                public ushort dport => BitConverter.ToUInt16(_etwEvent.Data[Offset_dport..]);

                /// <summary>
                /// Retrieves the sport field.
                /// </summary>
                public ushort sport => BitConverter.ToUInt16(_etwEvent.Data[Offset_sport..]);

                /// <summary>
                /// Retrieves the seqnum field.
                /// </summary>
                public uint seqnum => BitConverter.ToUInt32(_etwEvent.Data[Offset_seqnum..]);

                /// <summary>
                /// Retrieves the connid field.
                /// </summary>
                public ulong connid => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_connid..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_connid..]);

                /// <summary>
                /// Creates a new ReconnectIPV4Data.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ReconnectIPV4Data(EtwEvent etwEvent)
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
        /// An event wrapper for a TCPCopyIPV4 event.
        /// </summary>
        public readonly ref struct TCPCopyIPV4EventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "TCPCopyIPV4";

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
                Opcode = (EtwEventOpcode)Opcodes.TCPCopy,
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
            public TCPCopyIPV4Data Data => new(_etwEvent);

            /// <summary>
            /// Creates a new TCPCopyIPV4EventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public TCPCopyIPV4EventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a TCPCopyIPV4 event.
            /// </summary>
            public ref struct TCPCopyIPV4Data
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
                public uint PID => BitConverter.ToUInt32(_etwEvent.Data[Offset_PID..]);

                /// <summary>
                /// Retrieves the size field.
                /// </summary>
                public uint size => BitConverter.ToUInt32(_etwEvent.Data[Offset_size..]);

                /// <summary>
                /// Retrieves the daddr field.
                /// </summary>
                public uint daddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_daddr..]);

                /// <summary>
                /// Retrieves the saddr field.
                /// </summary>
                public uint saddr => BitConverter.ToUInt32(_etwEvent.Data[Offset_saddr..]);

                /// <summary>
                /// Retrieves the dport field.
                /// </summary>
                public ushort dport => BitConverter.ToUInt16(_etwEvent.Data[Offset_dport..]);

                /// <summary>
                /// Retrieves the sport field.
                /// </summary>
                public ushort sport => BitConverter.ToUInt16(_etwEvent.Data[Offset_sport..]);

                /// <summary>
                /// Retrieves the seqnum field.
                /// </summary>
                public uint seqnum => BitConverter.ToUInt32(_etwEvent.Data[Offset_seqnum..]);

                /// <summary>
                /// Retrieves the connid field.
                /// </summary>
                public ulong connid => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_connid..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_connid..]);

                /// <summary>
                /// Creates a new TCPCopyIPV4Data.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public TCPCopyIPV4Data(EtwEvent etwEvent)
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
        /// An event wrapper for a ConnectIPV6 event.
        /// </summary>
        public readonly ref struct ConnectIPV6EventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ConnectIPV6";

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
                Opcode = (EtwEventOpcode)Opcodes.ConnectIPV6,
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
            public ConnectIPV6Data Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ConnectIPV6EventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ConnectIPV6EventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ConnectIPV6 event.
            /// </summary>
            public ref struct ConnectIPV6Data
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_PID;
                private int _offset_size;
                private int _offset_daddr;
                private int _offset_saddr;
                private int _offset_dport;
                private int _offset_sport;
                private int _offset_mss;
                private int _offset_sackopt;
                private int _offset_tsopt;
                private int _offset_wsopt;
                private int _offset_rcvwin;
                private int _offset_rcvwinscale;
                private int _offset_sndwinscale;
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

                private int Offset_mss
                {
                    get
                    {
                        if (_offset_mss == -1)
                        {
                            _offset_mss = Offset_sport + 2;
                        }

                        return _offset_mss;
                    }
                }

                private int Offset_sackopt
                {
                    get
                    {
                        if (_offset_sackopt == -1)
                        {
                            _offset_sackopt = Offset_mss + 2;
                        }

                        return _offset_sackopt;
                    }
                }

                private int Offset_tsopt
                {
                    get
                    {
                        if (_offset_tsopt == -1)
                        {
                            _offset_tsopt = Offset_sackopt + 2;
                        }

                        return _offset_tsopt;
                    }
                }

                private int Offset_wsopt
                {
                    get
                    {
                        if (_offset_wsopt == -1)
                        {
                            _offset_wsopt = Offset_tsopt + 2;
                        }

                        return _offset_wsopt;
                    }
                }

                private int Offset_rcvwin
                {
                    get
                    {
                        if (_offset_rcvwin == -1)
                        {
                            _offset_rcvwin = Offset_wsopt + 2;
                        }

                        return _offset_rcvwin;
                    }
                }

                private int Offset_rcvwinscale
                {
                    get
                    {
                        if (_offset_rcvwinscale == -1)
                        {
                            _offset_rcvwinscale = Offset_rcvwin + 4;
                        }

                        return _offset_rcvwinscale;
                    }
                }

                private int Offset_sndwinscale
                {
                    get
                    {
                        if (_offset_sndwinscale == -1)
                        {
                            _offset_sndwinscale = Offset_rcvwinscale + 2;
                        }

                        return _offset_sndwinscale;
                    }
                }

                private int Offset_seqnum
                {
                    get
                    {
                        if (_offset_seqnum == -1)
                        {
                            _offset_seqnum = Offset_sndwinscale + 2;
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
                public uint PID => BitConverter.ToUInt32(_etwEvent.Data[Offset_PID..]);

                /// <summary>
                /// Retrieves the size field.
                /// </summary>
                public uint size => BitConverter.ToUInt32(_etwEvent.Data[Offset_size..]);

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
                public ushort dport => BitConverter.ToUInt16(_etwEvent.Data[Offset_dport..]);

                /// <summary>
                /// Retrieves the sport field.
                /// </summary>
                public ushort sport => BitConverter.ToUInt16(_etwEvent.Data[Offset_sport..]);

                /// <summary>
                /// Retrieves the mss field.
                /// </summary>
                public ushort mss => BitConverter.ToUInt16(_etwEvent.Data[Offset_mss..]);

                /// <summary>
                /// Retrieves the sackopt field.
                /// </summary>
                public ushort sackopt => BitConverter.ToUInt16(_etwEvent.Data[Offset_sackopt..]);

                /// <summary>
                /// Retrieves the tsopt field.
                /// </summary>
                public ushort tsopt => BitConverter.ToUInt16(_etwEvent.Data[Offset_tsopt..]);

                /// <summary>
                /// Retrieves the wsopt field.
                /// </summary>
                public ushort wsopt => BitConverter.ToUInt16(_etwEvent.Data[Offset_wsopt..]);

                /// <summary>
                /// Retrieves the rcvwin field.
                /// </summary>
                public uint rcvwin => BitConverter.ToUInt32(_etwEvent.Data[Offset_rcvwin..]);

                /// <summary>
                /// Retrieves the rcvwinscale field.
                /// </summary>
                public short rcvwinscale => BitConverter.ToInt16(_etwEvent.Data[Offset_rcvwinscale..]);

                /// <summary>
                /// Retrieves the sndwinscale field.
                /// </summary>
                public short sndwinscale => BitConverter.ToInt16(_etwEvent.Data[Offset_sndwinscale..]);

                /// <summary>
                /// Retrieves the seqnum field.
                /// </summary>
                public uint seqnum => BitConverter.ToUInt32(_etwEvent.Data[Offset_seqnum..]);

                /// <summary>
                /// Retrieves the connid field.
                /// </summary>
                public ulong connid => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_connid..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_connid..]);

                /// <summary>
                /// Creates a new ConnectIPV6Data.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ConnectIPV6Data(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_PID = -1;
                    _offset_size = -1;
                    _offset_daddr = -1;
                    _offset_saddr = -1;
                    _offset_dport = -1;
                    _offset_sport = -1;
                    _offset_mss = -1;
                    _offset_sackopt = -1;
                    _offset_tsopt = -1;
                    _offset_wsopt = -1;
                    _offset_rcvwin = -1;
                    _offset_rcvwinscale = -1;
                    _offset_sndwinscale = -1;
                    _offset_seqnum = -1;
                    _offset_connid = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a AcceptIPV6 event.
        /// </summary>
        public readonly ref struct AcceptIPV6EventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "AcceptIPV6";

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
                Opcode = (EtwEventOpcode)Opcodes.AcceptIPV6,
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
            public AcceptIPV6Data Data => new(_etwEvent);

            /// <summary>
            /// Creates a new AcceptIPV6EventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public AcceptIPV6EventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a AcceptIPV6 event.
            /// </summary>
            public ref struct AcceptIPV6Data
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_PID;
                private int _offset_size;
                private int _offset_daddr;
                private int _offset_saddr;
                private int _offset_dport;
                private int _offset_sport;
                private int _offset_mss;
                private int _offset_sackopt;
                private int _offset_tsopt;
                private int _offset_wsopt;
                private int _offset_rcvwin;
                private int _offset_rcvwinscale;
                private int _offset_sndwinscale;
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

                private int Offset_mss
                {
                    get
                    {
                        if (_offset_mss == -1)
                        {
                            _offset_mss = Offset_sport + 2;
                        }

                        return _offset_mss;
                    }
                }

                private int Offset_sackopt
                {
                    get
                    {
                        if (_offset_sackopt == -1)
                        {
                            _offset_sackopt = Offset_mss + 2;
                        }

                        return _offset_sackopt;
                    }
                }

                private int Offset_tsopt
                {
                    get
                    {
                        if (_offset_tsopt == -1)
                        {
                            _offset_tsopt = Offset_sackopt + 2;
                        }

                        return _offset_tsopt;
                    }
                }

                private int Offset_wsopt
                {
                    get
                    {
                        if (_offset_wsopt == -1)
                        {
                            _offset_wsopt = Offset_tsopt + 2;
                        }

                        return _offset_wsopt;
                    }
                }

                private int Offset_rcvwin
                {
                    get
                    {
                        if (_offset_rcvwin == -1)
                        {
                            _offset_rcvwin = Offset_wsopt + 2;
                        }

                        return _offset_rcvwin;
                    }
                }

                private int Offset_rcvwinscale
                {
                    get
                    {
                        if (_offset_rcvwinscale == -1)
                        {
                            _offset_rcvwinscale = Offset_rcvwin + 4;
                        }

                        return _offset_rcvwinscale;
                    }
                }

                private int Offset_sndwinscale
                {
                    get
                    {
                        if (_offset_sndwinscale == -1)
                        {
                            _offset_sndwinscale = Offset_rcvwinscale + 2;
                        }

                        return _offset_sndwinscale;
                    }
                }

                private int Offset_seqnum
                {
                    get
                    {
                        if (_offset_seqnum == -1)
                        {
                            _offset_seqnum = Offset_sndwinscale + 2;
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
                public uint PID => BitConverter.ToUInt32(_etwEvent.Data[Offset_PID..]);

                /// <summary>
                /// Retrieves the size field.
                /// </summary>
                public uint size => BitConverter.ToUInt32(_etwEvent.Data[Offset_size..]);

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
                public ushort dport => BitConverter.ToUInt16(_etwEvent.Data[Offset_dport..]);

                /// <summary>
                /// Retrieves the sport field.
                /// </summary>
                public ushort sport => BitConverter.ToUInt16(_etwEvent.Data[Offset_sport..]);

                /// <summary>
                /// Retrieves the mss field.
                /// </summary>
                public ushort mss => BitConverter.ToUInt16(_etwEvent.Data[Offset_mss..]);

                /// <summary>
                /// Retrieves the sackopt field.
                /// </summary>
                public ushort sackopt => BitConverter.ToUInt16(_etwEvent.Data[Offset_sackopt..]);

                /// <summary>
                /// Retrieves the tsopt field.
                /// </summary>
                public ushort tsopt => BitConverter.ToUInt16(_etwEvent.Data[Offset_tsopt..]);

                /// <summary>
                /// Retrieves the wsopt field.
                /// </summary>
                public ushort wsopt => BitConverter.ToUInt16(_etwEvent.Data[Offset_wsopt..]);

                /// <summary>
                /// Retrieves the rcvwin field.
                /// </summary>
                public uint rcvwin => BitConverter.ToUInt32(_etwEvent.Data[Offset_rcvwin..]);

                /// <summary>
                /// Retrieves the rcvwinscale field.
                /// </summary>
                public short rcvwinscale => BitConverter.ToInt16(_etwEvent.Data[Offset_rcvwinscale..]);

                /// <summary>
                /// Retrieves the sndwinscale field.
                /// </summary>
                public short sndwinscale => BitConverter.ToInt16(_etwEvent.Data[Offset_sndwinscale..]);

                /// <summary>
                /// Retrieves the seqnum field.
                /// </summary>
                public uint seqnum => BitConverter.ToUInt32(_etwEvent.Data[Offset_seqnum..]);

                /// <summary>
                /// Retrieves the connid field.
                /// </summary>
                public ulong connid => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_connid..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_connid..]);

                /// <summary>
                /// Creates a new AcceptIPV6Data.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public AcceptIPV6Data(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_PID = -1;
                    _offset_size = -1;
                    _offset_daddr = -1;
                    _offset_saddr = -1;
                    _offset_dport = -1;
                    _offset_sport = -1;
                    _offset_mss = -1;
                    _offset_sackopt = -1;
                    _offset_tsopt = -1;
                    _offset_wsopt = -1;
                    _offset_rcvwin = -1;
                    _offset_rcvwinscale = -1;
                    _offset_sndwinscale = -1;
                    _offset_seqnum = -1;
                    _offset_connid = -1;
                }
            }

        }
    }
}
