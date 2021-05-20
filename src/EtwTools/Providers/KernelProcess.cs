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
    /// Provider for Kernel-Process (3d6fa8d0-fe05-11d0-9dda-00c04fd7ba7c)
    /// </summary>
    public sealed class KernelProcessProvider
    {
        /// <summary>s
        /// Provider ID.
        /// </summary>
        public static readonly Guid Id = new("3d6fa8d0-fe05-11d0-9dda-00c04fd7ba7c");

        /// <summary>
        /// Provider name.
        /// </summary>
        public const string Name = "Kernel-Process";

        /// <summary>
        /// Opcodes supported by KernelProcess.
        /// </summary>
        public enum Opcodes
        {
            /// <summary>
            /// 'Terminate' opcode.
            /// </summary>
            Terminate = 11,
            /// <summary>
            /// 'PerfCtr' opcode.
            /// </summary>
            PerfCtr = 32,
            /// <summary>
            /// 'PerfCtrRundown' opcode.
            /// </summary>
            PerfCtrRundown = 33,
            /// <summary>
            /// 'InSwap' opcode.
            /// </summary>
            InSwap = 35,
            /// <summary>
            /// 'Defunct' opcode.
            /// </summary>
            Defunct = 39,
            /// <summary>
            /// 'WakeChargeUser' opcode.
            /// </summary>
            WakeChargeUser = 48,
            /// <summary>
            /// 'WakeChargeExecution' opcode.
            /// </summary>
            WakeChargeExecution = 49,
            /// <summary>
            /// 'WakeChargeKernel' opcode.
            /// </summary>
            WakeChargeKernel = 50,
            /// <summary>
            /// 'WakeChargeInstrumentation' opcode.
            /// </summary>
            WakeChargeInstrumentation = 51,
            /// <summary>
            /// 'WakeChargePreserveProcess' opcode.
            /// </summary>
            WakeChargePreserveProcess = 52,
            /// <summary>
            /// 'WakeReleaseUser' opcode.
            /// </summary>
            WakeReleaseUser = 64,
            /// <summary>
            /// 'WakeReleaseExecution' opcode.
            /// </summary>
            WakeReleaseExecution = 65,
            /// <summary>
            /// 'WakeReleaseKernel' opcode.
            /// </summary>
            WakeReleaseKernel = 66,
            /// <summary>
            /// 'WakeReleaseInstrumentation' opcode.
            /// </summary>
            WakeReleaseInstrumentation = 67,
            /// <summary>
            /// 'WakeReleasePreserveProcess' opcode.
            /// </summary>
            WakeReleasePreserveProcess = 68,
            /// <summary>
            /// 'WakeDropUser' opcode.
            /// </summary>
            WakeDropUser = 80,
            /// <summary>
            /// 'WakeDropExecution' opcode.
            /// </summary>
            WakeDropExecution = 81,
            /// <summary>
            /// 'WakeDropKernel' opcode.
            /// </summary>
            WakeDropKernel = 82,
            /// <summary>
            /// 'WakeDropInstrumentation' opcode.
            /// </summary>
            WakeDropInstrumentation = 83,
            /// <summary>
            /// 'WakeDropPreserveProcess' opcode.
            /// </summary>
            WakeDropPreserveProcess = 84,
            /// <summary>
            /// 'WakeEventUser' opcode.
            /// </summary>
            WakeEventUser = 96,
            /// <summary>
            /// 'WakeEventExecution' opcode.
            /// </summary>
            WakeEventExecution = 97,
            /// <summary>
            /// 'WakeEventKernel' opcode.
            /// </summary>
            WakeEventKernel = 98,
            /// <summary>
            /// 'WakeEventInstrumentation' opcode.
            /// </summary>
            WakeEventInstrumentation = 99,
        }

        /// <summary>
        /// An event wrapper for a Start event.
        /// </summary>
        public readonly ref struct StartEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Start";

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
                Opcode = EtwEventOpcode.Start,
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
            public StartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new StartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public StartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a StartEvent.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator StartEvent(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Start event.
            /// </summary>
            public ref struct StartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProcessId;
                private int _offset_ParentId;
                private int _offset_UserSID;
                private int _offset_ImageFileName;

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = 0;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_ParentId
                {
                    get
                    {
                        if (_offset_ParentId == -1)
                        {
                            _offset_ParentId = Offset_ProcessId + _etwEvent.AddressSize;
                        }

                        return _offset_ParentId;
                    }
                }

                private int Offset_UserSID
                {
                    get
                    {
                        if (_offset_UserSID == -1)
                        {
                            _offset_UserSID = Offset_ParentId + _etwEvent.AddressSize;
                        }

                        return _offset_UserSID;
                    }
                }

                private int Offset_ImageFileName
                {
                    get
                    {
                        if (_offset_ImageFileName == -1)
                        {
                            _offset_ImageFileName = Offset_UserSID + _etwEvent.GetWbemSidLength(Offset_UserSID);
                        }

                        return _offset_ImageFileName;
                    }
                }

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public ulong ProcessId => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..Offset_ParentId]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ProcessId..Offset_ParentId]);

                /// <summary>
                /// Retrieves the ParentId field.
                /// </summary>
                public ulong ParentId => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ParentId..Offset_UserSID]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ParentId..Offset_UserSID]);

                /// <summary>
                /// Retrieves the UserSID field.
                /// </summary>
                public System.Security.Principal.SecurityIdentifier UserSID => _etwEvent.GetWbemSid(Offset_UserSID);

                /// <summary>
                /// Retrieves the ImageFileName field.
                /// </summary>
                public string ImageFileName => System.Text.Encoding.ASCII.GetString(_etwEvent.Data[Offset_ImageFileName..]);

                /// <summary>
                /// Creates a new StartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public StartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProcessId = -1;
                    _offset_ParentId = -1;
                    _offset_UserSID = -1;
                    _offset_ImageFileName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a End event.
        /// </summary>
        public readonly ref struct EndEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "End";

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
            public EndData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new EndEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public EndEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a EndEvent.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator EndEvent(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a End event.
            /// </summary>
            public ref struct EndData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProcessId;
                private int _offset_ParentId;
                private int _offset_UserSID;
                private int _offset_ImageFileName;

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = 0;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_ParentId
                {
                    get
                    {
                        if (_offset_ParentId == -1)
                        {
                            _offset_ParentId = Offset_ProcessId + _etwEvent.AddressSize;
                        }

                        return _offset_ParentId;
                    }
                }

                private int Offset_UserSID
                {
                    get
                    {
                        if (_offset_UserSID == -1)
                        {
                            _offset_UserSID = Offset_ParentId + _etwEvent.AddressSize;
                        }

                        return _offset_UserSID;
                    }
                }

                private int Offset_ImageFileName
                {
                    get
                    {
                        if (_offset_ImageFileName == -1)
                        {
                            _offset_ImageFileName = Offset_UserSID + _etwEvent.GetWbemSidLength(Offset_UserSID);
                        }

                        return _offset_ImageFileName;
                    }
                }

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public ulong ProcessId => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..Offset_ParentId]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ProcessId..Offset_ParentId]);

                /// <summary>
                /// Retrieves the ParentId field.
                /// </summary>
                public ulong ParentId => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ParentId..Offset_UserSID]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ParentId..Offset_UserSID]);

                /// <summary>
                /// Retrieves the UserSID field.
                /// </summary>
                public System.Security.Principal.SecurityIdentifier UserSID => _etwEvent.GetWbemSid(Offset_UserSID);

                /// <summary>
                /// Retrieves the ImageFileName field.
                /// </summary>
                public string ImageFileName => System.Text.Encoding.ASCII.GetString(_etwEvent.Data[Offset_ImageFileName..]);

                /// <summary>
                /// Creates a new EndData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public EndData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProcessId = -1;
                    _offset_ParentId = -1;
                    _offset_UserSID = -1;
                    _offset_ImageFileName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DCStart event.
        /// </summary>
        public readonly ref struct DCStartEvent
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
                Version = 0,
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
            /// Creates a new DCStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DCStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a DCStartEvent.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator DCStartEvent(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a DCStart event.
            /// </summary>
            public ref struct DCStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProcessId;
                private int _offset_ParentId;
                private int _offset_UserSID;
                private int _offset_ImageFileName;

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = 0;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_ParentId
                {
                    get
                    {
                        if (_offset_ParentId == -1)
                        {
                            _offset_ParentId = Offset_ProcessId + _etwEvent.AddressSize;
                        }

                        return _offset_ParentId;
                    }
                }

                private int Offset_UserSID
                {
                    get
                    {
                        if (_offset_UserSID == -1)
                        {
                            _offset_UserSID = Offset_ParentId + _etwEvent.AddressSize;
                        }

                        return _offset_UserSID;
                    }
                }

                private int Offset_ImageFileName
                {
                    get
                    {
                        if (_offset_ImageFileName == -1)
                        {
                            _offset_ImageFileName = Offset_UserSID + _etwEvent.GetWbemSidLength(Offset_UserSID);
                        }

                        return _offset_ImageFileName;
                    }
                }

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public ulong ProcessId => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..Offset_ParentId]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ProcessId..Offset_ParentId]);

                /// <summary>
                /// Retrieves the ParentId field.
                /// </summary>
                public ulong ParentId => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ParentId..Offset_UserSID]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ParentId..Offset_UserSID]);

                /// <summary>
                /// Retrieves the UserSID field.
                /// </summary>
                public System.Security.Principal.SecurityIdentifier UserSID => _etwEvent.GetWbemSid(Offset_UserSID);

                /// <summary>
                /// Retrieves the ImageFileName field.
                /// </summary>
                public string ImageFileName => System.Text.Encoding.ASCII.GetString(_etwEvent.Data[Offset_ImageFileName..]);

                /// <summary>
                /// Creates a new DCStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DCStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProcessId = -1;
                    _offset_ParentId = -1;
                    _offset_UserSID = -1;
                    _offset_ImageFileName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DCEnd event.
        /// </summary>
        public readonly ref struct DCEndEvent
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
                Version = 0,
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
            /// Creates a new DCEndEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DCEndEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a DCEndEvent.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator DCEndEvent(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a DCEnd event.
            /// </summary>
            public ref struct DCEndData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProcessId;
                private int _offset_ParentId;
                private int _offset_UserSID;
                private int _offset_ImageFileName;

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = 0;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_ParentId
                {
                    get
                    {
                        if (_offset_ParentId == -1)
                        {
                            _offset_ParentId = Offset_ProcessId + _etwEvent.AddressSize;
                        }

                        return _offset_ParentId;
                    }
                }

                private int Offset_UserSID
                {
                    get
                    {
                        if (_offset_UserSID == -1)
                        {
                            _offset_UserSID = Offset_ParentId + _etwEvent.AddressSize;
                        }

                        return _offset_UserSID;
                    }
                }

                private int Offset_ImageFileName
                {
                    get
                    {
                        if (_offset_ImageFileName == -1)
                        {
                            _offset_ImageFileName = Offset_UserSID + _etwEvent.GetWbemSidLength(Offset_UserSID);
                        }

                        return _offset_ImageFileName;
                    }
                }

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public ulong ProcessId => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..Offset_ParentId]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ProcessId..Offset_ParentId]);

                /// <summary>
                /// Retrieves the ParentId field.
                /// </summary>
                public ulong ParentId => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ParentId..Offset_UserSID]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ParentId..Offset_UserSID]);

                /// <summary>
                /// Retrieves the UserSID field.
                /// </summary>
                public System.Security.Principal.SecurityIdentifier UserSID => _etwEvent.GetWbemSid(Offset_UserSID);

                /// <summary>
                /// Retrieves the ImageFileName field.
                /// </summary>
                public string ImageFileName => System.Text.Encoding.ASCII.GetString(_etwEvent.Data[Offset_ImageFileName..]);

                /// <summary>
                /// Creates a new DCEndData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DCEndData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProcessId = -1;
                    _offset_ParentId = -1;
                    _offset_UserSID = -1;
                    _offset_ImageFileName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Start event.
        /// </summary>
        public readonly ref struct StartEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Start";

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
                Opcode = EtwEventOpcode.Start,
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
            public StartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new StartEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public StartEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a StartEventV1.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator StartEventV1(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Start event.
            /// </summary>
            public ref struct StartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_PageDirectoryBase;
                private int _offset_ProcessId;
                private int _offset_ParentId;
                private int _offset_SessionId;
                private int _offset_ExitStatus;
                private int _offset_UserSID;
                private int _offset_ImageFileName;

                private int Offset_PageDirectoryBase
                {
                    get
                    {
                        if (_offset_PageDirectoryBase == -1)
                        {
                            _offset_PageDirectoryBase = 0;
                        }

                        return _offset_PageDirectoryBase;
                    }
                }

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = Offset_PageDirectoryBase + _etwEvent.AddressSize;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_ParentId
                {
                    get
                    {
                        if (_offset_ParentId == -1)
                        {
                            _offset_ParentId = Offset_ProcessId + 4;
                        }

                        return _offset_ParentId;
                    }
                }

                private int Offset_SessionId
                {
                    get
                    {
                        if (_offset_SessionId == -1)
                        {
                            _offset_SessionId = Offset_ParentId + 4;
                        }

                        return _offset_SessionId;
                    }
                }

                private int Offset_ExitStatus
                {
                    get
                    {
                        if (_offset_ExitStatus == -1)
                        {
                            _offset_ExitStatus = Offset_SessionId + 4;
                        }

                        return _offset_ExitStatus;
                    }
                }

                private int Offset_UserSID
                {
                    get
                    {
                        if (_offset_UserSID == -1)
                        {
                            _offset_UserSID = Offset_ExitStatus + 4;
                        }

                        return _offset_UserSID;
                    }
                }

                private int Offset_ImageFileName
                {
                    get
                    {
                        if (_offset_ImageFileName == -1)
                        {
                            _offset_ImageFileName = Offset_UserSID + _etwEvent.GetWbemSidLength(Offset_UserSID);
                        }

                        return _offset_ImageFileName;
                    }
                }

                /// <summary>
                /// Retrieves the PageDirectoryBase field.
                /// </summary>
                public ulong PageDirectoryBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_PageDirectoryBase..Offset_ProcessId]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_PageDirectoryBase..Offset_ProcessId]);

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..Offset_ParentId]);

                /// <summary>
                /// Retrieves the ParentId field.
                /// </summary>
                public uint ParentId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ParentId..Offset_SessionId]);

                /// <summary>
                /// Retrieves the SessionId field.
                /// </summary>
                public uint SessionId => BitConverter.ToUInt32(_etwEvent.Data[Offset_SessionId..Offset_ExitStatus]);

                /// <summary>
                /// Retrieves the ExitStatus field.
                /// </summary>
                public int ExitStatus => BitConverter.ToInt32(_etwEvent.Data[Offset_ExitStatus..Offset_UserSID]);

                /// <summary>
                /// Retrieves the UserSID field.
                /// </summary>
                public System.Security.Principal.SecurityIdentifier UserSID => _etwEvent.GetWbemSid(Offset_UserSID);

                /// <summary>
                /// Retrieves the ImageFileName field.
                /// </summary>
                public string ImageFileName => System.Text.Encoding.ASCII.GetString(_etwEvent.Data[Offset_ImageFileName..]);

                /// <summary>
                /// Creates a new StartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public StartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_PageDirectoryBase = -1;
                    _offset_ProcessId = -1;
                    _offset_ParentId = -1;
                    _offset_SessionId = -1;
                    _offset_ExitStatus = -1;
                    _offset_UserSID = -1;
                    _offset_ImageFileName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a End event.
        /// </summary>
        public readonly ref struct EndEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "End";

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
            public EndData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new EndEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public EndEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a EndEventV1.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator EndEventV1(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a End event.
            /// </summary>
            public ref struct EndData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_PageDirectoryBase;
                private int _offset_ProcessId;
                private int _offset_ParentId;
                private int _offset_SessionId;
                private int _offset_ExitStatus;
                private int _offset_UserSID;
                private int _offset_ImageFileName;

                private int Offset_PageDirectoryBase
                {
                    get
                    {
                        if (_offset_PageDirectoryBase == -1)
                        {
                            _offset_PageDirectoryBase = 0;
                        }

                        return _offset_PageDirectoryBase;
                    }
                }

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = Offset_PageDirectoryBase + _etwEvent.AddressSize;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_ParentId
                {
                    get
                    {
                        if (_offset_ParentId == -1)
                        {
                            _offset_ParentId = Offset_ProcessId + 4;
                        }

                        return _offset_ParentId;
                    }
                }

                private int Offset_SessionId
                {
                    get
                    {
                        if (_offset_SessionId == -1)
                        {
                            _offset_SessionId = Offset_ParentId + 4;
                        }

                        return _offset_SessionId;
                    }
                }

                private int Offset_ExitStatus
                {
                    get
                    {
                        if (_offset_ExitStatus == -1)
                        {
                            _offset_ExitStatus = Offset_SessionId + 4;
                        }

                        return _offset_ExitStatus;
                    }
                }

                private int Offset_UserSID
                {
                    get
                    {
                        if (_offset_UserSID == -1)
                        {
                            _offset_UserSID = Offset_ExitStatus + 4;
                        }

                        return _offset_UserSID;
                    }
                }

                private int Offset_ImageFileName
                {
                    get
                    {
                        if (_offset_ImageFileName == -1)
                        {
                            _offset_ImageFileName = Offset_UserSID + _etwEvent.GetWbemSidLength(Offset_UserSID);
                        }

                        return _offset_ImageFileName;
                    }
                }

                /// <summary>
                /// Retrieves the PageDirectoryBase field.
                /// </summary>
                public ulong PageDirectoryBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_PageDirectoryBase..Offset_ProcessId]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_PageDirectoryBase..Offset_ProcessId]);

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..Offset_ParentId]);

                /// <summary>
                /// Retrieves the ParentId field.
                /// </summary>
                public uint ParentId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ParentId..Offset_SessionId]);

                /// <summary>
                /// Retrieves the SessionId field.
                /// </summary>
                public uint SessionId => BitConverter.ToUInt32(_etwEvent.Data[Offset_SessionId..Offset_ExitStatus]);

                /// <summary>
                /// Retrieves the ExitStatus field.
                /// </summary>
                public int ExitStatus => BitConverter.ToInt32(_etwEvent.Data[Offset_ExitStatus..Offset_UserSID]);

                /// <summary>
                /// Retrieves the UserSID field.
                /// </summary>
                public System.Security.Principal.SecurityIdentifier UserSID => _etwEvent.GetWbemSid(Offset_UserSID);

                /// <summary>
                /// Retrieves the ImageFileName field.
                /// </summary>
                public string ImageFileName => System.Text.Encoding.ASCII.GetString(_etwEvent.Data[Offset_ImageFileName..]);

                /// <summary>
                /// Creates a new EndData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public EndData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_PageDirectoryBase = -1;
                    _offset_ProcessId = -1;
                    _offset_ParentId = -1;
                    _offset_SessionId = -1;
                    _offset_ExitStatus = -1;
                    _offset_UserSID = -1;
                    _offset_ImageFileName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DCStart event.
        /// </summary>
        public readonly ref struct DCStartEventV1
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
                Version = 1,
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
            /// Creates a new DCStartEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DCStartEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a DCStartEventV1.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator DCStartEventV1(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a DCStart event.
            /// </summary>
            public ref struct DCStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_PageDirectoryBase;
                private int _offset_ProcessId;
                private int _offset_ParentId;
                private int _offset_SessionId;
                private int _offset_ExitStatus;
                private int _offset_UserSID;
                private int _offset_ImageFileName;

                private int Offset_PageDirectoryBase
                {
                    get
                    {
                        if (_offset_PageDirectoryBase == -1)
                        {
                            _offset_PageDirectoryBase = 0;
                        }

                        return _offset_PageDirectoryBase;
                    }
                }

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = Offset_PageDirectoryBase + _etwEvent.AddressSize;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_ParentId
                {
                    get
                    {
                        if (_offset_ParentId == -1)
                        {
                            _offset_ParentId = Offset_ProcessId + 4;
                        }

                        return _offset_ParentId;
                    }
                }

                private int Offset_SessionId
                {
                    get
                    {
                        if (_offset_SessionId == -1)
                        {
                            _offset_SessionId = Offset_ParentId + 4;
                        }

                        return _offset_SessionId;
                    }
                }

                private int Offset_ExitStatus
                {
                    get
                    {
                        if (_offset_ExitStatus == -1)
                        {
                            _offset_ExitStatus = Offset_SessionId + 4;
                        }

                        return _offset_ExitStatus;
                    }
                }

                private int Offset_UserSID
                {
                    get
                    {
                        if (_offset_UserSID == -1)
                        {
                            _offset_UserSID = Offset_ExitStatus + 4;
                        }

                        return _offset_UserSID;
                    }
                }

                private int Offset_ImageFileName
                {
                    get
                    {
                        if (_offset_ImageFileName == -1)
                        {
                            _offset_ImageFileName = Offset_UserSID + _etwEvent.GetWbemSidLength(Offset_UserSID);
                        }

                        return _offset_ImageFileName;
                    }
                }

                /// <summary>
                /// Retrieves the PageDirectoryBase field.
                /// </summary>
                public ulong PageDirectoryBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_PageDirectoryBase..Offset_ProcessId]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_PageDirectoryBase..Offset_ProcessId]);

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..Offset_ParentId]);

                /// <summary>
                /// Retrieves the ParentId field.
                /// </summary>
                public uint ParentId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ParentId..Offset_SessionId]);

                /// <summary>
                /// Retrieves the SessionId field.
                /// </summary>
                public uint SessionId => BitConverter.ToUInt32(_etwEvent.Data[Offset_SessionId..Offset_ExitStatus]);

                /// <summary>
                /// Retrieves the ExitStatus field.
                /// </summary>
                public int ExitStatus => BitConverter.ToInt32(_etwEvent.Data[Offset_ExitStatus..Offset_UserSID]);

                /// <summary>
                /// Retrieves the UserSID field.
                /// </summary>
                public System.Security.Principal.SecurityIdentifier UserSID => _etwEvent.GetWbemSid(Offset_UserSID);

                /// <summary>
                /// Retrieves the ImageFileName field.
                /// </summary>
                public string ImageFileName => System.Text.Encoding.ASCII.GetString(_etwEvent.Data[Offset_ImageFileName..]);

                /// <summary>
                /// Creates a new DCStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DCStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_PageDirectoryBase = -1;
                    _offset_ProcessId = -1;
                    _offset_ParentId = -1;
                    _offset_SessionId = -1;
                    _offset_ExitStatus = -1;
                    _offset_UserSID = -1;
                    _offset_ImageFileName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DCEnd event.
        /// </summary>
        public readonly ref struct DCEndEventV1
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
                Version = 1,
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
            /// Creates a new DCEndEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DCEndEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a DCEndEventV1.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator DCEndEventV1(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a DCEnd event.
            /// </summary>
            public ref struct DCEndData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_PageDirectoryBase;
                private int _offset_ProcessId;
                private int _offset_ParentId;
                private int _offset_SessionId;
                private int _offset_ExitStatus;
                private int _offset_UserSID;
                private int _offset_ImageFileName;

                private int Offset_PageDirectoryBase
                {
                    get
                    {
                        if (_offset_PageDirectoryBase == -1)
                        {
                            _offset_PageDirectoryBase = 0;
                        }

                        return _offset_PageDirectoryBase;
                    }
                }

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = Offset_PageDirectoryBase + _etwEvent.AddressSize;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_ParentId
                {
                    get
                    {
                        if (_offset_ParentId == -1)
                        {
                            _offset_ParentId = Offset_ProcessId + 4;
                        }

                        return _offset_ParentId;
                    }
                }

                private int Offset_SessionId
                {
                    get
                    {
                        if (_offset_SessionId == -1)
                        {
                            _offset_SessionId = Offset_ParentId + 4;
                        }

                        return _offset_SessionId;
                    }
                }

                private int Offset_ExitStatus
                {
                    get
                    {
                        if (_offset_ExitStatus == -1)
                        {
                            _offset_ExitStatus = Offset_SessionId + 4;
                        }

                        return _offset_ExitStatus;
                    }
                }

                private int Offset_UserSID
                {
                    get
                    {
                        if (_offset_UserSID == -1)
                        {
                            _offset_UserSID = Offset_ExitStatus + 4;
                        }

                        return _offset_UserSID;
                    }
                }

                private int Offset_ImageFileName
                {
                    get
                    {
                        if (_offset_ImageFileName == -1)
                        {
                            _offset_ImageFileName = Offset_UserSID + _etwEvent.GetWbemSidLength(Offset_UserSID);
                        }

                        return _offset_ImageFileName;
                    }
                }

                /// <summary>
                /// Retrieves the PageDirectoryBase field.
                /// </summary>
                public ulong PageDirectoryBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_PageDirectoryBase..Offset_ProcessId]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_PageDirectoryBase..Offset_ProcessId]);

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..Offset_ParentId]);

                /// <summary>
                /// Retrieves the ParentId field.
                /// </summary>
                public uint ParentId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ParentId..Offset_SessionId]);

                /// <summary>
                /// Retrieves the SessionId field.
                /// </summary>
                public uint SessionId => BitConverter.ToUInt32(_etwEvent.Data[Offset_SessionId..Offset_ExitStatus]);

                /// <summary>
                /// Retrieves the ExitStatus field.
                /// </summary>
                public int ExitStatus => BitConverter.ToInt32(_etwEvent.Data[Offset_ExitStatus..Offset_UserSID]);

                /// <summary>
                /// Retrieves the UserSID field.
                /// </summary>
                public System.Security.Principal.SecurityIdentifier UserSID => _etwEvent.GetWbemSid(Offset_UserSID);

                /// <summary>
                /// Retrieves the ImageFileName field.
                /// </summary>
                public string ImageFileName => System.Text.Encoding.ASCII.GetString(_etwEvent.Data[Offset_ImageFileName..]);

                /// <summary>
                /// Creates a new DCEndData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DCEndData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_PageDirectoryBase = -1;
                    _offset_ProcessId = -1;
                    _offset_ParentId = -1;
                    _offset_SessionId = -1;
                    _offset_ExitStatus = -1;
                    _offset_UserSID = -1;
                    _offset_ImageFileName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Start event.
        /// </summary>
        public readonly ref struct StartEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Start";

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
                Opcode = EtwEventOpcode.Start,
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
            public StartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new StartEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public StartEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a StartEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator StartEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Start event.
            /// </summary>
            public ref struct StartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_UniqueProcessKey;
                private int _offset_ProcessId;
                private int _offset_ParentId;
                private int _offset_SessionId;
                private int _offset_ExitStatus;
                private int _offset_UserSID;
                private int _offset_ImageFileName;
                private int _offset_CommandLine;

                private int Offset_UniqueProcessKey
                {
                    get
                    {
                        if (_offset_UniqueProcessKey == -1)
                        {
                            _offset_UniqueProcessKey = 0;
                        }

                        return _offset_UniqueProcessKey;
                    }
                }

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = Offset_UniqueProcessKey + _etwEvent.AddressSize;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_ParentId
                {
                    get
                    {
                        if (_offset_ParentId == -1)
                        {
                            _offset_ParentId = Offset_ProcessId + 4;
                        }

                        return _offset_ParentId;
                    }
                }

                private int Offset_SessionId
                {
                    get
                    {
                        if (_offset_SessionId == -1)
                        {
                            _offset_SessionId = Offset_ParentId + 4;
                        }

                        return _offset_SessionId;
                    }
                }

                private int Offset_ExitStatus
                {
                    get
                    {
                        if (_offset_ExitStatus == -1)
                        {
                            _offset_ExitStatus = Offset_SessionId + 4;
                        }

                        return _offset_ExitStatus;
                    }
                }

                private int Offset_UserSID
                {
                    get
                    {
                        if (_offset_UserSID == -1)
                        {
                            _offset_UserSID = Offset_ExitStatus + 4;
                        }

                        return _offset_UserSID;
                    }
                }

                private int Offset_ImageFileName
                {
                    get
                    {
                        if (_offset_ImageFileName == -1)
                        {
                            _offset_ImageFileName = Offset_UserSID + _etwEvent.GetWbemSidLength(Offset_UserSID);
                        }

                        return _offset_ImageFileName;
                    }
                }

                private int Offset_CommandLine
                {
                    get
                    {
                        if (_offset_CommandLine == -1)
                        {
                            _offset_CommandLine = Offset_ImageFileName + _etwEvent.AnsiStringLength(Offset_ImageFileName);
                        }

                        return _offset_CommandLine;
                    }
                }

                /// <summary>
                /// Retrieves the UniqueProcessKey field.
                /// </summary>
                public ulong UniqueProcessKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_UniqueProcessKey..Offset_ProcessId]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_UniqueProcessKey..Offset_ProcessId]);

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..Offset_ParentId]);

                /// <summary>
                /// Retrieves the ParentId field.
                /// </summary>
                public uint ParentId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ParentId..Offset_SessionId]);

                /// <summary>
                /// Retrieves the SessionId field.
                /// </summary>
                public uint SessionId => BitConverter.ToUInt32(_etwEvent.Data[Offset_SessionId..Offset_ExitStatus]);

                /// <summary>
                /// Retrieves the ExitStatus field.
                /// </summary>
                public int ExitStatus => BitConverter.ToInt32(_etwEvent.Data[Offset_ExitStatus..Offset_UserSID]);

                /// <summary>
                /// Retrieves the UserSID field.
                /// </summary>
                public System.Security.Principal.SecurityIdentifier UserSID => _etwEvent.GetWbemSid(Offset_UserSID);

                /// <summary>
                /// Retrieves the ImageFileName field.
                /// </summary>
                public string ImageFileName => System.Text.Encoding.ASCII.GetString(_etwEvent.Data[Offset_ImageFileName..Offset_CommandLine]);

                /// <summary>
                /// Retrieves the CommandLine field.
                /// </summary>
                public string CommandLine => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_CommandLine..]);

                /// <summary>
                /// Creates a new StartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public StartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_UniqueProcessKey = -1;
                    _offset_ProcessId = -1;
                    _offset_ParentId = -1;
                    _offset_SessionId = -1;
                    _offset_ExitStatus = -1;
                    _offset_UserSID = -1;
                    _offset_ImageFileName = -1;
                    _offset_CommandLine = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a End event.
        /// </summary>
        public readonly ref struct EndEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "End";

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
            public EndData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new EndEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public EndEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a EndEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator EndEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a End event.
            /// </summary>
            public ref struct EndData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_UniqueProcessKey;
                private int _offset_ProcessId;
                private int _offset_ParentId;
                private int _offset_SessionId;
                private int _offset_ExitStatus;
                private int _offset_UserSID;
                private int _offset_ImageFileName;
                private int _offset_CommandLine;

                private int Offset_UniqueProcessKey
                {
                    get
                    {
                        if (_offset_UniqueProcessKey == -1)
                        {
                            _offset_UniqueProcessKey = 0;
                        }

                        return _offset_UniqueProcessKey;
                    }
                }

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = Offset_UniqueProcessKey + _etwEvent.AddressSize;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_ParentId
                {
                    get
                    {
                        if (_offset_ParentId == -1)
                        {
                            _offset_ParentId = Offset_ProcessId + 4;
                        }

                        return _offset_ParentId;
                    }
                }

                private int Offset_SessionId
                {
                    get
                    {
                        if (_offset_SessionId == -1)
                        {
                            _offset_SessionId = Offset_ParentId + 4;
                        }

                        return _offset_SessionId;
                    }
                }

                private int Offset_ExitStatus
                {
                    get
                    {
                        if (_offset_ExitStatus == -1)
                        {
                            _offset_ExitStatus = Offset_SessionId + 4;
                        }

                        return _offset_ExitStatus;
                    }
                }

                private int Offset_UserSID
                {
                    get
                    {
                        if (_offset_UserSID == -1)
                        {
                            _offset_UserSID = Offset_ExitStatus + 4;
                        }

                        return _offset_UserSID;
                    }
                }

                private int Offset_ImageFileName
                {
                    get
                    {
                        if (_offset_ImageFileName == -1)
                        {
                            _offset_ImageFileName = Offset_UserSID + _etwEvent.GetWbemSidLength(Offset_UserSID);
                        }

                        return _offset_ImageFileName;
                    }
                }

                private int Offset_CommandLine
                {
                    get
                    {
                        if (_offset_CommandLine == -1)
                        {
                            _offset_CommandLine = Offset_ImageFileName + _etwEvent.AnsiStringLength(Offset_ImageFileName);
                        }

                        return _offset_CommandLine;
                    }
                }

                /// <summary>
                /// Retrieves the UniqueProcessKey field.
                /// </summary>
                public ulong UniqueProcessKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_UniqueProcessKey..Offset_ProcessId]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_UniqueProcessKey..Offset_ProcessId]);

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..Offset_ParentId]);

                /// <summary>
                /// Retrieves the ParentId field.
                /// </summary>
                public uint ParentId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ParentId..Offset_SessionId]);

                /// <summary>
                /// Retrieves the SessionId field.
                /// </summary>
                public uint SessionId => BitConverter.ToUInt32(_etwEvent.Data[Offset_SessionId..Offset_ExitStatus]);

                /// <summary>
                /// Retrieves the ExitStatus field.
                /// </summary>
                public int ExitStatus => BitConverter.ToInt32(_etwEvent.Data[Offset_ExitStatus..Offset_UserSID]);

                /// <summary>
                /// Retrieves the UserSID field.
                /// </summary>
                public System.Security.Principal.SecurityIdentifier UserSID => _etwEvent.GetWbemSid(Offset_UserSID);

                /// <summary>
                /// Retrieves the ImageFileName field.
                /// </summary>
                public string ImageFileName => System.Text.Encoding.ASCII.GetString(_etwEvent.Data[Offset_ImageFileName..Offset_CommandLine]);

                /// <summary>
                /// Retrieves the CommandLine field.
                /// </summary>
                public string CommandLine => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_CommandLine..]);

                /// <summary>
                /// Creates a new EndData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public EndData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_UniqueProcessKey = -1;
                    _offset_ProcessId = -1;
                    _offset_ParentId = -1;
                    _offset_SessionId = -1;
                    _offset_ExitStatus = -1;
                    _offset_UserSID = -1;
                    _offset_ImageFileName = -1;
                    _offset_CommandLine = -1;
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

                private int _offset_UniqueProcessKey;
                private int _offset_ProcessId;
                private int _offset_ParentId;
                private int _offset_SessionId;
                private int _offset_ExitStatus;
                private int _offset_UserSID;
                private int _offset_ImageFileName;
                private int _offset_CommandLine;

                private int Offset_UniqueProcessKey
                {
                    get
                    {
                        if (_offset_UniqueProcessKey == -1)
                        {
                            _offset_UniqueProcessKey = 0;
                        }

                        return _offset_UniqueProcessKey;
                    }
                }

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = Offset_UniqueProcessKey + _etwEvent.AddressSize;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_ParentId
                {
                    get
                    {
                        if (_offset_ParentId == -1)
                        {
                            _offset_ParentId = Offset_ProcessId + 4;
                        }

                        return _offset_ParentId;
                    }
                }

                private int Offset_SessionId
                {
                    get
                    {
                        if (_offset_SessionId == -1)
                        {
                            _offset_SessionId = Offset_ParentId + 4;
                        }

                        return _offset_SessionId;
                    }
                }

                private int Offset_ExitStatus
                {
                    get
                    {
                        if (_offset_ExitStatus == -1)
                        {
                            _offset_ExitStatus = Offset_SessionId + 4;
                        }

                        return _offset_ExitStatus;
                    }
                }

                private int Offset_UserSID
                {
                    get
                    {
                        if (_offset_UserSID == -1)
                        {
                            _offset_UserSID = Offset_ExitStatus + 4;
                        }

                        return _offset_UserSID;
                    }
                }

                private int Offset_ImageFileName
                {
                    get
                    {
                        if (_offset_ImageFileName == -1)
                        {
                            _offset_ImageFileName = Offset_UserSID + _etwEvent.GetWbemSidLength(Offset_UserSID);
                        }

                        return _offset_ImageFileName;
                    }
                }

                private int Offset_CommandLine
                {
                    get
                    {
                        if (_offset_CommandLine == -1)
                        {
                            _offset_CommandLine = Offset_ImageFileName + _etwEvent.AnsiStringLength(Offset_ImageFileName);
                        }

                        return _offset_CommandLine;
                    }
                }

                /// <summary>
                /// Retrieves the UniqueProcessKey field.
                /// </summary>
                public ulong UniqueProcessKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_UniqueProcessKey..Offset_ProcessId]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_UniqueProcessKey..Offset_ProcessId]);

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..Offset_ParentId]);

                /// <summary>
                /// Retrieves the ParentId field.
                /// </summary>
                public uint ParentId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ParentId..Offset_SessionId]);

                /// <summary>
                /// Retrieves the SessionId field.
                /// </summary>
                public uint SessionId => BitConverter.ToUInt32(_etwEvent.Data[Offset_SessionId..Offset_ExitStatus]);

                /// <summary>
                /// Retrieves the ExitStatus field.
                /// </summary>
                public int ExitStatus => BitConverter.ToInt32(_etwEvent.Data[Offset_ExitStatus..Offset_UserSID]);

                /// <summary>
                /// Retrieves the UserSID field.
                /// </summary>
                public System.Security.Principal.SecurityIdentifier UserSID => _etwEvent.GetWbemSid(Offset_UserSID);

                /// <summary>
                /// Retrieves the ImageFileName field.
                /// </summary>
                public string ImageFileName => System.Text.Encoding.ASCII.GetString(_etwEvent.Data[Offset_ImageFileName..Offset_CommandLine]);

                /// <summary>
                /// Retrieves the CommandLine field.
                /// </summary>
                public string CommandLine => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_CommandLine..]);

                /// <summary>
                /// Creates a new DCStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DCStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_UniqueProcessKey = -1;
                    _offset_ProcessId = -1;
                    _offset_ParentId = -1;
                    _offset_SessionId = -1;
                    _offset_ExitStatus = -1;
                    _offset_UserSID = -1;
                    _offset_ImageFileName = -1;
                    _offset_CommandLine = -1;
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

                private int _offset_UniqueProcessKey;
                private int _offset_ProcessId;
                private int _offset_ParentId;
                private int _offset_SessionId;
                private int _offset_ExitStatus;
                private int _offset_UserSID;
                private int _offset_ImageFileName;
                private int _offset_CommandLine;

                private int Offset_UniqueProcessKey
                {
                    get
                    {
                        if (_offset_UniqueProcessKey == -1)
                        {
                            _offset_UniqueProcessKey = 0;
                        }

                        return _offset_UniqueProcessKey;
                    }
                }

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = Offset_UniqueProcessKey + _etwEvent.AddressSize;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_ParentId
                {
                    get
                    {
                        if (_offset_ParentId == -1)
                        {
                            _offset_ParentId = Offset_ProcessId + 4;
                        }

                        return _offset_ParentId;
                    }
                }

                private int Offset_SessionId
                {
                    get
                    {
                        if (_offset_SessionId == -1)
                        {
                            _offset_SessionId = Offset_ParentId + 4;
                        }

                        return _offset_SessionId;
                    }
                }

                private int Offset_ExitStatus
                {
                    get
                    {
                        if (_offset_ExitStatus == -1)
                        {
                            _offset_ExitStatus = Offset_SessionId + 4;
                        }

                        return _offset_ExitStatus;
                    }
                }

                private int Offset_UserSID
                {
                    get
                    {
                        if (_offset_UserSID == -1)
                        {
                            _offset_UserSID = Offset_ExitStatus + 4;
                        }

                        return _offset_UserSID;
                    }
                }

                private int Offset_ImageFileName
                {
                    get
                    {
                        if (_offset_ImageFileName == -1)
                        {
                            _offset_ImageFileName = Offset_UserSID + _etwEvent.GetWbemSidLength(Offset_UserSID);
                        }

                        return _offset_ImageFileName;
                    }
                }

                private int Offset_CommandLine
                {
                    get
                    {
                        if (_offset_CommandLine == -1)
                        {
                            _offset_CommandLine = Offset_ImageFileName + _etwEvent.AnsiStringLength(Offset_ImageFileName);
                        }

                        return _offset_CommandLine;
                    }
                }

                /// <summary>
                /// Retrieves the UniqueProcessKey field.
                /// </summary>
                public ulong UniqueProcessKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_UniqueProcessKey..Offset_ProcessId]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_UniqueProcessKey..Offset_ProcessId]);

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..Offset_ParentId]);

                /// <summary>
                /// Retrieves the ParentId field.
                /// </summary>
                public uint ParentId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ParentId..Offset_SessionId]);

                /// <summary>
                /// Retrieves the SessionId field.
                /// </summary>
                public uint SessionId => BitConverter.ToUInt32(_etwEvent.Data[Offset_SessionId..Offset_ExitStatus]);

                /// <summary>
                /// Retrieves the ExitStatus field.
                /// </summary>
                public int ExitStatus => BitConverter.ToInt32(_etwEvent.Data[Offset_ExitStatus..Offset_UserSID]);

                /// <summary>
                /// Retrieves the UserSID field.
                /// </summary>
                public System.Security.Principal.SecurityIdentifier UserSID => _etwEvent.GetWbemSid(Offset_UserSID);

                /// <summary>
                /// Retrieves the ImageFileName field.
                /// </summary>
                public string ImageFileName => System.Text.Encoding.ASCII.GetString(_etwEvent.Data[Offset_ImageFileName..Offset_CommandLine]);

                /// <summary>
                /// Retrieves the CommandLine field.
                /// </summary>
                public string CommandLine => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_CommandLine..]);

                /// <summary>
                /// Creates a new DCEndData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DCEndData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_UniqueProcessKey = -1;
                    _offset_ProcessId = -1;
                    _offset_ParentId = -1;
                    _offset_SessionId = -1;
                    _offset_ExitStatus = -1;
                    _offset_UserSID = -1;
                    _offset_ImageFileName = -1;
                    _offset_CommandLine = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Defunct event.
        /// </summary>
        public readonly ref struct DefunctEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Defunct";

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
                Opcode = (EtwEventOpcode)Opcodes.Defunct,
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
            public DefunctData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DefunctEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DefunctEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a DefunctEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator DefunctEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Defunct event.
            /// </summary>
            public ref struct DefunctData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_UniqueProcessKey;
                private int _offset_ProcessId;
                private int _offset_ParentId;
                private int _offset_SessionId;
                private int _offset_ExitStatus;
                private int _offset_UserSID;
                private int _offset_ImageFileName;
                private int _offset_CommandLine;

                private int Offset_UniqueProcessKey
                {
                    get
                    {
                        if (_offset_UniqueProcessKey == -1)
                        {
                            _offset_UniqueProcessKey = 0;
                        }

                        return _offset_UniqueProcessKey;
                    }
                }

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = Offset_UniqueProcessKey + _etwEvent.AddressSize;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_ParentId
                {
                    get
                    {
                        if (_offset_ParentId == -1)
                        {
                            _offset_ParentId = Offset_ProcessId + 4;
                        }

                        return _offset_ParentId;
                    }
                }

                private int Offset_SessionId
                {
                    get
                    {
                        if (_offset_SessionId == -1)
                        {
                            _offset_SessionId = Offset_ParentId + 4;
                        }

                        return _offset_SessionId;
                    }
                }

                private int Offset_ExitStatus
                {
                    get
                    {
                        if (_offset_ExitStatus == -1)
                        {
                            _offset_ExitStatus = Offset_SessionId + 4;
                        }

                        return _offset_ExitStatus;
                    }
                }

                private int Offset_UserSID
                {
                    get
                    {
                        if (_offset_UserSID == -1)
                        {
                            _offset_UserSID = Offset_ExitStatus + 4;
                        }

                        return _offset_UserSID;
                    }
                }

                private int Offset_ImageFileName
                {
                    get
                    {
                        if (_offset_ImageFileName == -1)
                        {
                            _offset_ImageFileName = Offset_UserSID + _etwEvent.GetWbemSidLength(Offset_UserSID);
                        }

                        return _offset_ImageFileName;
                    }
                }

                private int Offset_CommandLine
                {
                    get
                    {
                        if (_offset_CommandLine == -1)
                        {
                            _offset_CommandLine = Offset_ImageFileName + _etwEvent.AnsiStringLength(Offset_ImageFileName);
                        }

                        return _offset_CommandLine;
                    }
                }

                /// <summary>
                /// Retrieves the UniqueProcessKey field.
                /// </summary>
                public ulong UniqueProcessKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_UniqueProcessKey..Offset_ProcessId]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_UniqueProcessKey..Offset_ProcessId]);

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..Offset_ParentId]);

                /// <summary>
                /// Retrieves the ParentId field.
                /// </summary>
                public uint ParentId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ParentId..Offset_SessionId]);

                /// <summary>
                /// Retrieves the SessionId field.
                /// </summary>
                public uint SessionId => BitConverter.ToUInt32(_etwEvent.Data[Offset_SessionId..Offset_ExitStatus]);

                /// <summary>
                /// Retrieves the ExitStatus field.
                /// </summary>
                public int ExitStatus => BitConverter.ToInt32(_etwEvent.Data[Offset_ExitStatus..Offset_UserSID]);

                /// <summary>
                /// Retrieves the UserSID field.
                /// </summary>
                public System.Security.Principal.SecurityIdentifier UserSID => _etwEvent.GetWbemSid(Offset_UserSID);

                /// <summary>
                /// Retrieves the ImageFileName field.
                /// </summary>
                public string ImageFileName => System.Text.Encoding.ASCII.GetString(_etwEvent.Data[Offset_ImageFileName..Offset_CommandLine]);

                /// <summary>
                /// Retrieves the CommandLine field.
                /// </summary>
                public string CommandLine => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_CommandLine..]);

                /// <summary>
                /// Creates a new DefunctData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DefunctData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_UniqueProcessKey = -1;
                    _offset_ProcessId = -1;
                    _offset_ParentId = -1;
                    _offset_SessionId = -1;
                    _offset_ExitStatus = -1;
                    _offset_UserSID = -1;
                    _offset_ImageFileName = -1;
                    _offset_CommandLine = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Terminate event.
        /// </summary>
        public readonly ref struct TerminateEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Terminate";

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
                Opcode = (EtwEventOpcode)Opcodes.Terminate,
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
            public TerminateData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new TerminateEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public TerminateEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a TerminateEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator TerminateEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Terminate event.
            /// </summary>
            public ref struct TerminateData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProcessId;

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = 0;
                        }

                        return _offset_ProcessId;
                    }
                }

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..]);

                /// <summary>
                /// Creates a new TerminateData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public TerminateData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProcessId = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a PerfCtr event.
        /// </summary>
        public readonly ref struct PerfCtrEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "PerfCtr";

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
                Opcode = (EtwEventOpcode)Opcodes.PerfCtr,
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
            public PerfCtrData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new PerfCtrEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public PerfCtrEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a PerfCtrEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator PerfCtrEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a PerfCtr event.
            /// </summary>
            public ref struct PerfCtrData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProcessId;
                private int _offset_PageFaultCount;
                private int _offset_HandleCount;
                private int _offset_Reserved;
                private int _offset_PeakVirtualSize;
                private int _offset_PeakWorkingSetSize;
                private int _offset_PeakPagefileUsage;
                private int _offset_QuotaPeakPagedPoolUsage;
                private int _offset_QuotaPeakNonPagedPoolUsage;
                private int _offset_VirtualSize;
                private int _offset_WorkingSetSize;
                private int _offset_PagefileUsage;
                private int _offset_QuotaPagedPoolUsage;
                private int _offset_QuotaNonPagedPoolUsage;
                private int _offset_PrivatePageCount;

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = 0;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_PageFaultCount
                {
                    get
                    {
                        if (_offset_PageFaultCount == -1)
                        {
                            _offset_PageFaultCount = Offset_ProcessId + 4;
                        }

                        return _offset_PageFaultCount;
                    }
                }

                private int Offset_HandleCount
                {
                    get
                    {
                        if (_offset_HandleCount == -1)
                        {
                            _offset_HandleCount = Offset_PageFaultCount + 4;
                        }

                        return _offset_HandleCount;
                    }
                }

                private int Offset_Reserved
                {
                    get
                    {
                        if (_offset_Reserved == -1)
                        {
                            _offset_Reserved = Offset_HandleCount + 4;
                        }

                        return _offset_Reserved;
                    }
                }

                private int Offset_PeakVirtualSize
                {
                    get
                    {
                        if (_offset_PeakVirtualSize == -1)
                        {
                            _offset_PeakVirtualSize = Offset_Reserved + 4;
                        }

                        return _offset_PeakVirtualSize;
                    }
                }

                private int Offset_PeakWorkingSetSize
                {
                    get
                    {
                        if (_offset_PeakWorkingSetSize == -1)
                        {
                            _offset_PeakWorkingSetSize = Offset_PeakVirtualSize + _etwEvent.AddressSize;
                        }

                        return _offset_PeakWorkingSetSize;
                    }
                }

                private int Offset_PeakPagefileUsage
                {
                    get
                    {
                        if (_offset_PeakPagefileUsage == -1)
                        {
                            _offset_PeakPagefileUsage = Offset_PeakWorkingSetSize + _etwEvent.AddressSize;
                        }

                        return _offset_PeakPagefileUsage;
                    }
                }

                private int Offset_QuotaPeakPagedPoolUsage
                {
                    get
                    {
                        if (_offset_QuotaPeakPagedPoolUsage == -1)
                        {
                            _offset_QuotaPeakPagedPoolUsage = Offset_PeakPagefileUsage + _etwEvent.AddressSize;
                        }

                        return _offset_QuotaPeakPagedPoolUsage;
                    }
                }

                private int Offset_QuotaPeakNonPagedPoolUsage
                {
                    get
                    {
                        if (_offset_QuotaPeakNonPagedPoolUsage == -1)
                        {
                            _offset_QuotaPeakNonPagedPoolUsage = Offset_QuotaPeakPagedPoolUsage + _etwEvent.AddressSize;
                        }

                        return _offset_QuotaPeakNonPagedPoolUsage;
                    }
                }

                private int Offset_VirtualSize
                {
                    get
                    {
                        if (_offset_VirtualSize == -1)
                        {
                            _offset_VirtualSize = Offset_QuotaPeakNonPagedPoolUsage + _etwEvent.AddressSize;
                        }

                        return _offset_VirtualSize;
                    }
                }

                private int Offset_WorkingSetSize
                {
                    get
                    {
                        if (_offset_WorkingSetSize == -1)
                        {
                            _offset_WorkingSetSize = Offset_VirtualSize + _etwEvent.AddressSize;
                        }

                        return _offset_WorkingSetSize;
                    }
                }

                private int Offset_PagefileUsage
                {
                    get
                    {
                        if (_offset_PagefileUsage == -1)
                        {
                            _offset_PagefileUsage = Offset_WorkingSetSize + _etwEvent.AddressSize;
                        }

                        return _offset_PagefileUsage;
                    }
                }

                private int Offset_QuotaPagedPoolUsage
                {
                    get
                    {
                        if (_offset_QuotaPagedPoolUsage == -1)
                        {
                            _offset_QuotaPagedPoolUsage = Offset_PagefileUsage + _etwEvent.AddressSize;
                        }

                        return _offset_QuotaPagedPoolUsage;
                    }
                }

                private int Offset_QuotaNonPagedPoolUsage
                {
                    get
                    {
                        if (_offset_QuotaNonPagedPoolUsage == -1)
                        {
                            _offset_QuotaNonPagedPoolUsage = Offset_QuotaPagedPoolUsage + _etwEvent.AddressSize;
                        }

                        return _offset_QuotaNonPagedPoolUsage;
                    }
                }

                private int Offset_PrivatePageCount
                {
                    get
                    {
                        if (_offset_PrivatePageCount == -1)
                        {
                            _offset_PrivatePageCount = Offset_QuotaNonPagedPoolUsage + _etwEvent.AddressSize;
                        }

                        return _offset_PrivatePageCount;
                    }
                }

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..Offset_PageFaultCount]);

                /// <summary>
                /// Retrieves the PageFaultCount field.
                /// </summary>
                public uint PageFaultCount => BitConverter.ToUInt32(_etwEvent.Data[Offset_PageFaultCount..Offset_HandleCount]);

                /// <summary>
                /// Retrieves the HandleCount field.
                /// </summary>
                public uint HandleCount => BitConverter.ToUInt32(_etwEvent.Data[Offset_HandleCount..Offset_Reserved]);

                /// <summary>
                /// Retrieves the Reserved field.
                /// </summary>
                public uint Reserved => BitConverter.ToUInt32(_etwEvent.Data[Offset_Reserved..Offset_PeakVirtualSize]);

                /// <summary>
                /// Retrieves the PeakVirtualSize field.
                /// </summary>
                public ulong PeakVirtualSize => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_PeakVirtualSize..Offset_PeakWorkingSetSize]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_PeakVirtualSize..Offset_PeakWorkingSetSize]);

                /// <summary>
                /// Retrieves the PeakWorkingSetSize field.
                /// </summary>
                public ulong PeakWorkingSetSize => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_PeakWorkingSetSize..Offset_PeakPagefileUsage]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_PeakWorkingSetSize..Offset_PeakPagefileUsage]);

                /// <summary>
                /// Retrieves the PeakPagefileUsage field.
                /// </summary>
                public ulong PeakPagefileUsage => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_PeakPagefileUsage..Offset_QuotaPeakPagedPoolUsage]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_PeakPagefileUsage..Offset_QuotaPeakPagedPoolUsage]);

                /// <summary>
                /// Retrieves the QuotaPeakPagedPoolUsage field.
                /// </summary>
                public ulong QuotaPeakPagedPoolUsage => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_QuotaPeakPagedPoolUsage..Offset_QuotaPeakNonPagedPoolUsage]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_QuotaPeakPagedPoolUsage..Offset_QuotaPeakNonPagedPoolUsage]);

                /// <summary>
                /// Retrieves the QuotaPeakNonPagedPoolUsage field.
                /// </summary>
                public ulong QuotaPeakNonPagedPoolUsage => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_QuotaPeakNonPagedPoolUsage..Offset_VirtualSize]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_QuotaPeakNonPagedPoolUsage..Offset_VirtualSize]);

                /// <summary>
                /// Retrieves the VirtualSize field.
                /// </summary>
                public ulong VirtualSize => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_VirtualSize..Offset_WorkingSetSize]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_VirtualSize..Offset_WorkingSetSize]);

                /// <summary>
                /// Retrieves the WorkingSetSize field.
                /// </summary>
                public ulong WorkingSetSize => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_WorkingSetSize..Offset_PagefileUsage]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_WorkingSetSize..Offset_PagefileUsage]);

                /// <summary>
                /// Retrieves the PagefileUsage field.
                /// </summary>
                public ulong PagefileUsage => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_PagefileUsage..Offset_QuotaPagedPoolUsage]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_PagefileUsage..Offset_QuotaPagedPoolUsage]);

                /// <summary>
                /// Retrieves the QuotaPagedPoolUsage field.
                /// </summary>
                public ulong QuotaPagedPoolUsage => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_QuotaPagedPoolUsage..Offset_QuotaNonPagedPoolUsage]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_QuotaPagedPoolUsage..Offset_QuotaNonPagedPoolUsage]);

                /// <summary>
                /// Retrieves the QuotaNonPagedPoolUsage field.
                /// </summary>
                public ulong QuotaNonPagedPoolUsage => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_QuotaNonPagedPoolUsage..Offset_PrivatePageCount]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_QuotaNonPagedPoolUsage..Offset_PrivatePageCount]);

                /// <summary>
                /// Retrieves the PrivatePageCount field.
                /// </summary>
                public ulong PrivatePageCount => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_PrivatePageCount..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_PrivatePageCount..]);

                /// <summary>
                /// Creates a new PerfCtrData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public PerfCtrData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProcessId = -1;
                    _offset_PageFaultCount = -1;
                    _offset_HandleCount = -1;
                    _offset_Reserved = -1;
                    _offset_PeakVirtualSize = -1;
                    _offset_PeakWorkingSetSize = -1;
                    _offset_PeakPagefileUsage = -1;
                    _offset_QuotaPeakPagedPoolUsage = -1;
                    _offset_QuotaPeakNonPagedPoolUsage = -1;
                    _offset_VirtualSize = -1;
                    _offset_WorkingSetSize = -1;
                    _offset_PagefileUsage = -1;
                    _offset_QuotaPagedPoolUsage = -1;
                    _offset_QuotaNonPagedPoolUsage = -1;
                    _offset_PrivatePageCount = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a PerfCtrRundown event.
        /// </summary>
        public readonly ref struct PerfCtrRundownEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "PerfCtrRundown";

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
                Opcode = (EtwEventOpcode)Opcodes.PerfCtrRundown,
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
            public PerfCtrRundownData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new PerfCtrRundownEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public PerfCtrRundownEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a PerfCtrRundownEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator PerfCtrRundownEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a PerfCtrRundown event.
            /// </summary>
            public ref struct PerfCtrRundownData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProcessId;
                private int _offset_PageFaultCount;
                private int _offset_HandleCount;
                private int _offset_Reserved;
                private int _offset_PeakVirtualSize;
                private int _offset_PeakWorkingSetSize;
                private int _offset_PeakPagefileUsage;
                private int _offset_QuotaPeakPagedPoolUsage;
                private int _offset_QuotaPeakNonPagedPoolUsage;
                private int _offset_VirtualSize;
                private int _offset_WorkingSetSize;
                private int _offset_PagefileUsage;
                private int _offset_QuotaPagedPoolUsage;
                private int _offset_QuotaNonPagedPoolUsage;
                private int _offset_PrivatePageCount;

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = 0;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_PageFaultCount
                {
                    get
                    {
                        if (_offset_PageFaultCount == -1)
                        {
                            _offset_PageFaultCount = Offset_ProcessId + 4;
                        }

                        return _offset_PageFaultCount;
                    }
                }

                private int Offset_HandleCount
                {
                    get
                    {
                        if (_offset_HandleCount == -1)
                        {
                            _offset_HandleCount = Offset_PageFaultCount + 4;
                        }

                        return _offset_HandleCount;
                    }
                }

                private int Offset_Reserved
                {
                    get
                    {
                        if (_offset_Reserved == -1)
                        {
                            _offset_Reserved = Offset_HandleCount + 4;
                        }

                        return _offset_Reserved;
                    }
                }

                private int Offset_PeakVirtualSize
                {
                    get
                    {
                        if (_offset_PeakVirtualSize == -1)
                        {
                            _offset_PeakVirtualSize = Offset_Reserved + 4;
                        }

                        return _offset_PeakVirtualSize;
                    }
                }

                private int Offset_PeakWorkingSetSize
                {
                    get
                    {
                        if (_offset_PeakWorkingSetSize == -1)
                        {
                            _offset_PeakWorkingSetSize = Offset_PeakVirtualSize + _etwEvent.AddressSize;
                        }

                        return _offset_PeakWorkingSetSize;
                    }
                }

                private int Offset_PeakPagefileUsage
                {
                    get
                    {
                        if (_offset_PeakPagefileUsage == -1)
                        {
                            _offset_PeakPagefileUsage = Offset_PeakWorkingSetSize + _etwEvent.AddressSize;
                        }

                        return _offset_PeakPagefileUsage;
                    }
                }

                private int Offset_QuotaPeakPagedPoolUsage
                {
                    get
                    {
                        if (_offset_QuotaPeakPagedPoolUsage == -1)
                        {
                            _offset_QuotaPeakPagedPoolUsage = Offset_PeakPagefileUsage + _etwEvent.AddressSize;
                        }

                        return _offset_QuotaPeakPagedPoolUsage;
                    }
                }

                private int Offset_QuotaPeakNonPagedPoolUsage
                {
                    get
                    {
                        if (_offset_QuotaPeakNonPagedPoolUsage == -1)
                        {
                            _offset_QuotaPeakNonPagedPoolUsage = Offset_QuotaPeakPagedPoolUsage + _etwEvent.AddressSize;
                        }

                        return _offset_QuotaPeakNonPagedPoolUsage;
                    }
                }

                private int Offset_VirtualSize
                {
                    get
                    {
                        if (_offset_VirtualSize == -1)
                        {
                            _offset_VirtualSize = Offset_QuotaPeakNonPagedPoolUsage + _etwEvent.AddressSize;
                        }

                        return _offset_VirtualSize;
                    }
                }

                private int Offset_WorkingSetSize
                {
                    get
                    {
                        if (_offset_WorkingSetSize == -1)
                        {
                            _offset_WorkingSetSize = Offset_VirtualSize + _etwEvent.AddressSize;
                        }

                        return _offset_WorkingSetSize;
                    }
                }

                private int Offset_PagefileUsage
                {
                    get
                    {
                        if (_offset_PagefileUsage == -1)
                        {
                            _offset_PagefileUsage = Offset_WorkingSetSize + _etwEvent.AddressSize;
                        }

                        return _offset_PagefileUsage;
                    }
                }

                private int Offset_QuotaPagedPoolUsage
                {
                    get
                    {
                        if (_offset_QuotaPagedPoolUsage == -1)
                        {
                            _offset_QuotaPagedPoolUsage = Offset_PagefileUsage + _etwEvent.AddressSize;
                        }

                        return _offset_QuotaPagedPoolUsage;
                    }
                }

                private int Offset_QuotaNonPagedPoolUsage
                {
                    get
                    {
                        if (_offset_QuotaNonPagedPoolUsage == -1)
                        {
                            _offset_QuotaNonPagedPoolUsage = Offset_QuotaPagedPoolUsage + _etwEvent.AddressSize;
                        }

                        return _offset_QuotaNonPagedPoolUsage;
                    }
                }

                private int Offset_PrivatePageCount
                {
                    get
                    {
                        if (_offset_PrivatePageCount == -1)
                        {
                            _offset_PrivatePageCount = Offset_QuotaNonPagedPoolUsage + _etwEvent.AddressSize;
                        }

                        return _offset_PrivatePageCount;
                    }
                }

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..Offset_PageFaultCount]);

                /// <summary>
                /// Retrieves the PageFaultCount field.
                /// </summary>
                public uint PageFaultCount => BitConverter.ToUInt32(_etwEvent.Data[Offset_PageFaultCount..Offset_HandleCount]);

                /// <summary>
                /// Retrieves the HandleCount field.
                /// </summary>
                public uint HandleCount => BitConverter.ToUInt32(_etwEvent.Data[Offset_HandleCount..Offset_Reserved]);

                /// <summary>
                /// Retrieves the Reserved field.
                /// </summary>
                public uint Reserved => BitConverter.ToUInt32(_etwEvent.Data[Offset_Reserved..Offset_PeakVirtualSize]);

                /// <summary>
                /// Retrieves the PeakVirtualSize field.
                /// </summary>
                public ulong PeakVirtualSize => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_PeakVirtualSize..Offset_PeakWorkingSetSize]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_PeakVirtualSize..Offset_PeakWorkingSetSize]);

                /// <summary>
                /// Retrieves the PeakWorkingSetSize field.
                /// </summary>
                public ulong PeakWorkingSetSize => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_PeakWorkingSetSize..Offset_PeakPagefileUsage]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_PeakWorkingSetSize..Offset_PeakPagefileUsage]);

                /// <summary>
                /// Retrieves the PeakPagefileUsage field.
                /// </summary>
                public ulong PeakPagefileUsage => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_PeakPagefileUsage..Offset_QuotaPeakPagedPoolUsage]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_PeakPagefileUsage..Offset_QuotaPeakPagedPoolUsage]);

                /// <summary>
                /// Retrieves the QuotaPeakPagedPoolUsage field.
                /// </summary>
                public ulong QuotaPeakPagedPoolUsage => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_QuotaPeakPagedPoolUsage..Offset_QuotaPeakNonPagedPoolUsage]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_QuotaPeakPagedPoolUsage..Offset_QuotaPeakNonPagedPoolUsage]);

                /// <summary>
                /// Retrieves the QuotaPeakNonPagedPoolUsage field.
                /// </summary>
                public ulong QuotaPeakNonPagedPoolUsage => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_QuotaPeakNonPagedPoolUsage..Offset_VirtualSize]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_QuotaPeakNonPagedPoolUsage..Offset_VirtualSize]);

                /// <summary>
                /// Retrieves the VirtualSize field.
                /// </summary>
                public ulong VirtualSize => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_VirtualSize..Offset_WorkingSetSize]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_VirtualSize..Offset_WorkingSetSize]);

                /// <summary>
                /// Retrieves the WorkingSetSize field.
                /// </summary>
                public ulong WorkingSetSize => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_WorkingSetSize..Offset_PagefileUsage]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_WorkingSetSize..Offset_PagefileUsage]);

                /// <summary>
                /// Retrieves the PagefileUsage field.
                /// </summary>
                public ulong PagefileUsage => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_PagefileUsage..Offset_QuotaPagedPoolUsage]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_PagefileUsage..Offset_QuotaPagedPoolUsage]);

                /// <summary>
                /// Retrieves the QuotaPagedPoolUsage field.
                /// </summary>
                public ulong QuotaPagedPoolUsage => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_QuotaPagedPoolUsage..Offset_QuotaNonPagedPoolUsage]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_QuotaPagedPoolUsage..Offset_QuotaNonPagedPoolUsage]);

                /// <summary>
                /// Retrieves the QuotaNonPagedPoolUsage field.
                /// </summary>
                public ulong QuotaNonPagedPoolUsage => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_QuotaNonPagedPoolUsage..Offset_PrivatePageCount]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_QuotaNonPagedPoolUsage..Offset_PrivatePageCount]);

                /// <summary>
                /// Retrieves the PrivatePageCount field.
                /// </summary>
                public ulong PrivatePageCount => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_PrivatePageCount..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_PrivatePageCount..]);

                /// <summary>
                /// Creates a new PerfCtrRundownData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public PerfCtrRundownData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProcessId = -1;
                    _offset_PageFaultCount = -1;
                    _offset_HandleCount = -1;
                    _offset_Reserved = -1;
                    _offset_PeakVirtualSize = -1;
                    _offset_PeakWorkingSetSize = -1;
                    _offset_PeakPagefileUsage = -1;
                    _offset_QuotaPeakPagedPoolUsage = -1;
                    _offset_QuotaPeakNonPagedPoolUsage = -1;
                    _offset_VirtualSize = -1;
                    _offset_WorkingSetSize = -1;
                    _offset_PagefileUsage = -1;
                    _offset_QuotaPagedPoolUsage = -1;
                    _offset_QuotaNonPagedPoolUsage = -1;
                    _offset_PrivatePageCount = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a InSwap event.
        /// </summary>
        public readonly ref struct InSwapEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "InSwap";

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
                Opcode = (EtwEventOpcode)Opcodes.InSwap,
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
            public InSwapData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new InSwapEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public InSwapEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a InSwapEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator InSwapEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a InSwap event.
            /// </summary>
            public ref struct InSwapData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_DirectoryTableBase;
                private int _offset_ProcessId;

                private int Offset_DirectoryTableBase
                {
                    get
                    {
                        if (_offset_DirectoryTableBase == -1)
                        {
                            _offset_DirectoryTableBase = 0;
                        }

                        return _offset_DirectoryTableBase;
                    }
                }

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = Offset_DirectoryTableBase + _etwEvent.AddressSize;
                        }

                        return _offset_ProcessId;
                    }
                }

                /// <summary>
                /// Retrieves the DirectoryTableBase field.
                /// </summary>
                public ulong DirectoryTableBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_DirectoryTableBase..Offset_ProcessId]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_DirectoryTableBase..Offset_ProcessId]);

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..]);

                /// <summary>
                /// Creates a new InSwapData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public InSwapData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_DirectoryTableBase = -1;
                    _offset_ProcessId = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a WakeChargeUser event.
        /// </summary>
        public readonly ref struct WakeChargeUserEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "WakeChargeUser";

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
                Opcode = (EtwEventOpcode)Opcodes.WakeChargeUser,
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
            public WakeChargeUserData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new WakeChargeUserEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public WakeChargeUserEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a WakeChargeUserEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator WakeChargeUserEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a WakeChargeUser event.
            /// </summary>
            public ref struct WakeChargeUserData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Object;
                private int _offset_Tag;
                private int _offset_ProcessId;
                private int _offset_Count;

                private int Offset_Object
                {
                    get
                    {
                        if (_offset_Object == -1)
                        {
                            _offset_Object = 0;
                        }

                        return _offset_Object;
                    }
                }

                private int Offset_Tag
                {
                    get
                    {
                        if (_offset_Tag == -1)
                        {
                            _offset_Tag = Offset_Object + _etwEvent.AddressSize;
                        }

                        return _offset_Tag;
                    }
                }

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = Offset_Tag + _etwEvent.AddressSize;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_Count
                {
                    get
                    {
                        if (_offset_Count == -1)
                        {
                            _offset_Count = Offset_ProcessId + 4;
                        }

                        return _offset_Count;
                    }
                }

                /// <summary>
                /// Retrieves the Object field.
                /// </summary>
                public ulong Object => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Object..Offset_Tag]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Object..Offset_Tag]);

                /// <summary>
                /// Retrieves the Tag field.
                /// </summary>
                public ulong Tag => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Tag..Offset_ProcessId]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Tag..Offset_ProcessId]);

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..Offset_Count]);

                /// <summary>
                /// Retrieves the Count field.
                /// </summary>
                public uint Count => BitConverter.ToUInt32(_etwEvent.Data[Offset_Count..]);

                /// <summary>
                /// Creates a new WakeChargeUserData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public WakeChargeUserData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Object = -1;
                    _offset_Tag = -1;
                    _offset_ProcessId = -1;
                    _offset_Count = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a WakeChargeExecution event.
        /// </summary>
        public readonly ref struct WakeChargeExecutionEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "WakeChargeExecution";

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
                Opcode = (EtwEventOpcode)Opcodes.WakeChargeExecution,
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
            public WakeChargeExecutionData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new WakeChargeExecutionEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public WakeChargeExecutionEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a WakeChargeExecutionEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator WakeChargeExecutionEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a WakeChargeExecution event.
            /// </summary>
            public ref struct WakeChargeExecutionData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Object;
                private int _offset_Tag;
                private int _offset_ProcessId;
                private int _offset_Count;

                private int Offset_Object
                {
                    get
                    {
                        if (_offset_Object == -1)
                        {
                            _offset_Object = 0;
                        }

                        return _offset_Object;
                    }
                }

                private int Offset_Tag
                {
                    get
                    {
                        if (_offset_Tag == -1)
                        {
                            _offset_Tag = Offset_Object + _etwEvent.AddressSize;
                        }

                        return _offset_Tag;
                    }
                }

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = Offset_Tag + _etwEvent.AddressSize;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_Count
                {
                    get
                    {
                        if (_offset_Count == -1)
                        {
                            _offset_Count = Offset_ProcessId + 4;
                        }

                        return _offset_Count;
                    }
                }

                /// <summary>
                /// Retrieves the Object field.
                /// </summary>
                public ulong Object => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Object..Offset_Tag]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Object..Offset_Tag]);

                /// <summary>
                /// Retrieves the Tag field.
                /// </summary>
                public ulong Tag => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Tag..Offset_ProcessId]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Tag..Offset_ProcessId]);

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..Offset_Count]);

                /// <summary>
                /// Retrieves the Count field.
                /// </summary>
                public uint Count => BitConverter.ToUInt32(_etwEvent.Data[Offset_Count..]);

                /// <summary>
                /// Creates a new WakeChargeExecutionData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public WakeChargeExecutionData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Object = -1;
                    _offset_Tag = -1;
                    _offset_ProcessId = -1;
                    _offset_Count = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a WakeChargeKernel event.
        /// </summary>
        public readonly ref struct WakeChargeKernelEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "WakeChargeKernel";

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
                Opcode = (EtwEventOpcode)Opcodes.WakeChargeKernel,
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
            public WakeChargeKernelData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new WakeChargeKernelEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public WakeChargeKernelEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a WakeChargeKernelEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator WakeChargeKernelEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a WakeChargeKernel event.
            /// </summary>
            public ref struct WakeChargeKernelData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Object;
                private int _offset_Tag;
                private int _offset_ProcessId;
                private int _offset_Count;

                private int Offset_Object
                {
                    get
                    {
                        if (_offset_Object == -1)
                        {
                            _offset_Object = 0;
                        }

                        return _offset_Object;
                    }
                }

                private int Offset_Tag
                {
                    get
                    {
                        if (_offset_Tag == -1)
                        {
                            _offset_Tag = Offset_Object + _etwEvent.AddressSize;
                        }

                        return _offset_Tag;
                    }
                }

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = Offset_Tag + _etwEvent.AddressSize;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_Count
                {
                    get
                    {
                        if (_offset_Count == -1)
                        {
                            _offset_Count = Offset_ProcessId + 4;
                        }

                        return _offset_Count;
                    }
                }

                /// <summary>
                /// Retrieves the Object field.
                /// </summary>
                public ulong Object => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Object..Offset_Tag]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Object..Offset_Tag]);

                /// <summary>
                /// Retrieves the Tag field.
                /// </summary>
                public ulong Tag => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Tag..Offset_ProcessId]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Tag..Offset_ProcessId]);

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..Offset_Count]);

                /// <summary>
                /// Retrieves the Count field.
                /// </summary>
                public uint Count => BitConverter.ToUInt32(_etwEvent.Data[Offset_Count..]);

                /// <summary>
                /// Creates a new WakeChargeKernelData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public WakeChargeKernelData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Object = -1;
                    _offset_Tag = -1;
                    _offset_ProcessId = -1;
                    _offset_Count = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a WakeChargeInstrumentation event.
        /// </summary>
        public readonly ref struct WakeChargeInstrumentationEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "WakeChargeInstrumentation";

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
                Opcode = (EtwEventOpcode)Opcodes.WakeChargeInstrumentation,
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
            public WakeChargeInstrumentationData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new WakeChargeInstrumentationEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public WakeChargeInstrumentationEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a WakeChargeInstrumentationEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator WakeChargeInstrumentationEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a WakeChargeInstrumentation event.
            /// </summary>
            public ref struct WakeChargeInstrumentationData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Object;
                private int _offset_Tag;
                private int _offset_ProcessId;
                private int _offset_Count;

                private int Offset_Object
                {
                    get
                    {
                        if (_offset_Object == -1)
                        {
                            _offset_Object = 0;
                        }

                        return _offset_Object;
                    }
                }

                private int Offset_Tag
                {
                    get
                    {
                        if (_offset_Tag == -1)
                        {
                            _offset_Tag = Offset_Object + _etwEvent.AddressSize;
                        }

                        return _offset_Tag;
                    }
                }

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = Offset_Tag + _etwEvent.AddressSize;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_Count
                {
                    get
                    {
                        if (_offset_Count == -1)
                        {
                            _offset_Count = Offset_ProcessId + 4;
                        }

                        return _offset_Count;
                    }
                }

                /// <summary>
                /// Retrieves the Object field.
                /// </summary>
                public ulong Object => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Object..Offset_Tag]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Object..Offset_Tag]);

                /// <summary>
                /// Retrieves the Tag field.
                /// </summary>
                public ulong Tag => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Tag..Offset_ProcessId]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Tag..Offset_ProcessId]);

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..Offset_Count]);

                /// <summary>
                /// Retrieves the Count field.
                /// </summary>
                public uint Count => BitConverter.ToUInt32(_etwEvent.Data[Offset_Count..]);

                /// <summary>
                /// Creates a new WakeChargeInstrumentationData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public WakeChargeInstrumentationData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Object = -1;
                    _offset_Tag = -1;
                    _offset_ProcessId = -1;
                    _offset_Count = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a WakeChargePreserveProcess event.
        /// </summary>
        public readonly ref struct WakeChargePreserveProcessEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "WakeChargePreserveProcess";

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
                Opcode = (EtwEventOpcode)Opcodes.WakeChargePreserveProcess,
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
            public WakeChargePreserveProcessData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new WakeChargePreserveProcessEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public WakeChargePreserveProcessEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a WakeChargePreserveProcessEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator WakeChargePreserveProcessEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a WakeChargePreserveProcess event.
            /// </summary>
            public ref struct WakeChargePreserveProcessData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Object;
                private int _offset_Tag;
                private int _offset_ProcessId;
                private int _offset_Count;

                private int Offset_Object
                {
                    get
                    {
                        if (_offset_Object == -1)
                        {
                            _offset_Object = 0;
                        }

                        return _offset_Object;
                    }
                }

                private int Offset_Tag
                {
                    get
                    {
                        if (_offset_Tag == -1)
                        {
                            _offset_Tag = Offset_Object + _etwEvent.AddressSize;
                        }

                        return _offset_Tag;
                    }
                }

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = Offset_Tag + _etwEvent.AddressSize;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_Count
                {
                    get
                    {
                        if (_offset_Count == -1)
                        {
                            _offset_Count = Offset_ProcessId + 4;
                        }

                        return _offset_Count;
                    }
                }

                /// <summary>
                /// Retrieves the Object field.
                /// </summary>
                public ulong Object => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Object..Offset_Tag]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Object..Offset_Tag]);

                /// <summary>
                /// Retrieves the Tag field.
                /// </summary>
                public ulong Tag => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Tag..Offset_ProcessId]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Tag..Offset_ProcessId]);

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..Offset_Count]);

                /// <summary>
                /// Retrieves the Count field.
                /// </summary>
                public uint Count => BitConverter.ToUInt32(_etwEvent.Data[Offset_Count..]);

                /// <summary>
                /// Creates a new WakeChargePreserveProcessData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public WakeChargePreserveProcessData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Object = -1;
                    _offset_Tag = -1;
                    _offset_ProcessId = -1;
                    _offset_Count = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a WakeReleaseUser event.
        /// </summary>
        public readonly ref struct WakeReleaseUserEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "WakeReleaseUser";

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
                Opcode = (EtwEventOpcode)Opcodes.WakeReleaseUser,
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
            public WakeReleaseUserData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new WakeReleaseUserEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public WakeReleaseUserEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a WakeReleaseUserEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator WakeReleaseUserEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a WakeReleaseUser event.
            /// </summary>
            public ref struct WakeReleaseUserData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Object;
                private int _offset_Tag;
                private int _offset_ProcessId;
                private int _offset_Count;

                private int Offset_Object
                {
                    get
                    {
                        if (_offset_Object == -1)
                        {
                            _offset_Object = 0;
                        }

                        return _offset_Object;
                    }
                }

                private int Offset_Tag
                {
                    get
                    {
                        if (_offset_Tag == -1)
                        {
                            _offset_Tag = Offset_Object + _etwEvent.AddressSize;
                        }

                        return _offset_Tag;
                    }
                }

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = Offset_Tag + _etwEvent.AddressSize;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_Count
                {
                    get
                    {
                        if (_offset_Count == -1)
                        {
                            _offset_Count = Offset_ProcessId + 4;
                        }

                        return _offset_Count;
                    }
                }

                /// <summary>
                /// Retrieves the Object field.
                /// </summary>
                public ulong Object => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Object..Offset_Tag]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Object..Offset_Tag]);

                /// <summary>
                /// Retrieves the Tag field.
                /// </summary>
                public ulong Tag => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Tag..Offset_ProcessId]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Tag..Offset_ProcessId]);

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..Offset_Count]);

                /// <summary>
                /// Retrieves the Count field.
                /// </summary>
                public uint Count => BitConverter.ToUInt32(_etwEvent.Data[Offset_Count..]);

                /// <summary>
                /// Creates a new WakeReleaseUserData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public WakeReleaseUserData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Object = -1;
                    _offset_Tag = -1;
                    _offset_ProcessId = -1;
                    _offset_Count = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a WakeReleaseExecution event.
        /// </summary>
        public readonly ref struct WakeReleaseExecutionEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "WakeReleaseExecution";

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
                Opcode = (EtwEventOpcode)Opcodes.WakeReleaseExecution,
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
            public WakeReleaseExecutionData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new WakeReleaseExecutionEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public WakeReleaseExecutionEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a WakeReleaseExecutionEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator WakeReleaseExecutionEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a WakeReleaseExecution event.
            /// </summary>
            public ref struct WakeReleaseExecutionData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Object;
                private int _offset_Tag;
                private int _offset_ProcessId;
                private int _offset_Count;

                private int Offset_Object
                {
                    get
                    {
                        if (_offset_Object == -1)
                        {
                            _offset_Object = 0;
                        }

                        return _offset_Object;
                    }
                }

                private int Offset_Tag
                {
                    get
                    {
                        if (_offset_Tag == -1)
                        {
                            _offset_Tag = Offset_Object + _etwEvent.AddressSize;
                        }

                        return _offset_Tag;
                    }
                }

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = Offset_Tag + _etwEvent.AddressSize;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_Count
                {
                    get
                    {
                        if (_offset_Count == -1)
                        {
                            _offset_Count = Offset_ProcessId + 4;
                        }

                        return _offset_Count;
                    }
                }

                /// <summary>
                /// Retrieves the Object field.
                /// </summary>
                public ulong Object => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Object..Offset_Tag]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Object..Offset_Tag]);

                /// <summary>
                /// Retrieves the Tag field.
                /// </summary>
                public ulong Tag => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Tag..Offset_ProcessId]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Tag..Offset_ProcessId]);

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..Offset_Count]);

                /// <summary>
                /// Retrieves the Count field.
                /// </summary>
                public uint Count => BitConverter.ToUInt32(_etwEvent.Data[Offset_Count..]);

                /// <summary>
                /// Creates a new WakeReleaseExecutionData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public WakeReleaseExecutionData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Object = -1;
                    _offset_Tag = -1;
                    _offset_ProcessId = -1;
                    _offset_Count = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a WakeReleaseKernel event.
        /// </summary>
        public readonly ref struct WakeReleaseKernelEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "WakeReleaseKernel";

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
                Opcode = (EtwEventOpcode)Opcodes.WakeReleaseKernel,
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
            public WakeReleaseKernelData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new WakeReleaseKernelEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public WakeReleaseKernelEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a WakeReleaseKernelEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator WakeReleaseKernelEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a WakeReleaseKernel event.
            /// </summary>
            public ref struct WakeReleaseKernelData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Object;
                private int _offset_Tag;
                private int _offset_ProcessId;
                private int _offset_Count;

                private int Offset_Object
                {
                    get
                    {
                        if (_offset_Object == -1)
                        {
                            _offset_Object = 0;
                        }

                        return _offset_Object;
                    }
                }

                private int Offset_Tag
                {
                    get
                    {
                        if (_offset_Tag == -1)
                        {
                            _offset_Tag = Offset_Object + _etwEvent.AddressSize;
                        }

                        return _offset_Tag;
                    }
                }

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = Offset_Tag + _etwEvent.AddressSize;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_Count
                {
                    get
                    {
                        if (_offset_Count == -1)
                        {
                            _offset_Count = Offset_ProcessId + 4;
                        }

                        return _offset_Count;
                    }
                }

                /// <summary>
                /// Retrieves the Object field.
                /// </summary>
                public ulong Object => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Object..Offset_Tag]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Object..Offset_Tag]);

                /// <summary>
                /// Retrieves the Tag field.
                /// </summary>
                public ulong Tag => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Tag..Offset_ProcessId]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Tag..Offset_ProcessId]);

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..Offset_Count]);

                /// <summary>
                /// Retrieves the Count field.
                /// </summary>
                public uint Count => BitConverter.ToUInt32(_etwEvent.Data[Offset_Count..]);

                /// <summary>
                /// Creates a new WakeReleaseKernelData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public WakeReleaseKernelData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Object = -1;
                    _offset_Tag = -1;
                    _offset_ProcessId = -1;
                    _offset_Count = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a WakeReleaseInstrumentation event.
        /// </summary>
        public readonly ref struct WakeReleaseInstrumentationEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "WakeReleaseInstrumentation";

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
                Opcode = (EtwEventOpcode)Opcodes.WakeReleaseInstrumentation,
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
            public WakeReleaseInstrumentationData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new WakeReleaseInstrumentationEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public WakeReleaseInstrumentationEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a WakeReleaseInstrumentationEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator WakeReleaseInstrumentationEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a WakeReleaseInstrumentation event.
            /// </summary>
            public ref struct WakeReleaseInstrumentationData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Object;
                private int _offset_Tag;
                private int _offset_ProcessId;
                private int _offset_Count;

                private int Offset_Object
                {
                    get
                    {
                        if (_offset_Object == -1)
                        {
                            _offset_Object = 0;
                        }

                        return _offset_Object;
                    }
                }

                private int Offset_Tag
                {
                    get
                    {
                        if (_offset_Tag == -1)
                        {
                            _offset_Tag = Offset_Object + _etwEvent.AddressSize;
                        }

                        return _offset_Tag;
                    }
                }

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = Offset_Tag + _etwEvent.AddressSize;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_Count
                {
                    get
                    {
                        if (_offset_Count == -1)
                        {
                            _offset_Count = Offset_ProcessId + 4;
                        }

                        return _offset_Count;
                    }
                }

                /// <summary>
                /// Retrieves the Object field.
                /// </summary>
                public ulong Object => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Object..Offset_Tag]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Object..Offset_Tag]);

                /// <summary>
                /// Retrieves the Tag field.
                /// </summary>
                public ulong Tag => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Tag..Offset_ProcessId]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Tag..Offset_ProcessId]);

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..Offset_Count]);

                /// <summary>
                /// Retrieves the Count field.
                /// </summary>
                public uint Count => BitConverter.ToUInt32(_etwEvent.Data[Offset_Count..]);

                /// <summary>
                /// Creates a new WakeReleaseInstrumentationData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public WakeReleaseInstrumentationData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Object = -1;
                    _offset_Tag = -1;
                    _offset_ProcessId = -1;
                    _offset_Count = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a WakeReleasePreserveProcess event.
        /// </summary>
        public readonly ref struct WakeReleasePreserveProcessEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "WakeReleasePreserveProcess";

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
                Opcode = (EtwEventOpcode)Opcodes.WakeReleasePreserveProcess,
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
            public WakeReleasePreserveProcessData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new WakeReleasePreserveProcessEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public WakeReleasePreserveProcessEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a WakeReleasePreserveProcessEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator WakeReleasePreserveProcessEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a WakeReleasePreserveProcess event.
            /// </summary>
            public ref struct WakeReleasePreserveProcessData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Object;
                private int _offset_Tag;
                private int _offset_ProcessId;
                private int _offset_Count;

                private int Offset_Object
                {
                    get
                    {
                        if (_offset_Object == -1)
                        {
                            _offset_Object = 0;
                        }

                        return _offset_Object;
                    }
                }

                private int Offset_Tag
                {
                    get
                    {
                        if (_offset_Tag == -1)
                        {
                            _offset_Tag = Offset_Object + _etwEvent.AddressSize;
                        }

                        return _offset_Tag;
                    }
                }

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = Offset_Tag + _etwEvent.AddressSize;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_Count
                {
                    get
                    {
                        if (_offset_Count == -1)
                        {
                            _offset_Count = Offset_ProcessId + 4;
                        }

                        return _offset_Count;
                    }
                }

                /// <summary>
                /// Retrieves the Object field.
                /// </summary>
                public ulong Object => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Object..Offset_Tag]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Object..Offset_Tag]);

                /// <summary>
                /// Retrieves the Tag field.
                /// </summary>
                public ulong Tag => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Tag..Offset_ProcessId]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Tag..Offset_ProcessId]);

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..Offset_Count]);

                /// <summary>
                /// Retrieves the Count field.
                /// </summary>
                public uint Count => BitConverter.ToUInt32(_etwEvent.Data[Offset_Count..]);

                /// <summary>
                /// Creates a new WakeReleasePreserveProcessData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public WakeReleasePreserveProcessData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Object = -1;
                    _offset_Tag = -1;
                    _offset_ProcessId = -1;
                    _offset_Count = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a WakeDropUser event.
        /// </summary>
        public readonly ref struct WakeDropUserEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "WakeDropUser";

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
                Opcode = (EtwEventOpcode)Opcodes.WakeDropUser,
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
            public WakeDropUserData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new WakeDropUserEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public WakeDropUserEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a WakeDropUserEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator WakeDropUserEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a WakeDropUser event.
            /// </summary>
            public ref struct WakeDropUserData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Object;
                private int _offset_Tag;
                private int _offset_ProcessId;
                private int _offset_Count;

                private int Offset_Object
                {
                    get
                    {
                        if (_offset_Object == -1)
                        {
                            _offset_Object = 0;
                        }

                        return _offset_Object;
                    }
                }

                private int Offset_Tag
                {
                    get
                    {
                        if (_offset_Tag == -1)
                        {
                            _offset_Tag = Offset_Object + _etwEvent.AddressSize;
                        }

                        return _offset_Tag;
                    }
                }

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = Offset_Tag + _etwEvent.AddressSize;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_Count
                {
                    get
                    {
                        if (_offset_Count == -1)
                        {
                            _offset_Count = Offset_ProcessId + 4;
                        }

                        return _offset_Count;
                    }
                }

                /// <summary>
                /// Retrieves the Object field.
                /// </summary>
                public ulong Object => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Object..Offset_Tag]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Object..Offset_Tag]);

                /// <summary>
                /// Retrieves the Tag field.
                /// </summary>
                public ulong Tag => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Tag..Offset_ProcessId]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Tag..Offset_ProcessId]);

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..Offset_Count]);

                /// <summary>
                /// Retrieves the Count field.
                /// </summary>
                public uint Count => BitConverter.ToUInt32(_etwEvent.Data[Offset_Count..]);

                /// <summary>
                /// Creates a new WakeDropUserData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public WakeDropUserData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Object = -1;
                    _offset_Tag = -1;
                    _offset_ProcessId = -1;
                    _offset_Count = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a WakeDropExecution event.
        /// </summary>
        public readonly ref struct WakeDropExecutionEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "WakeDropExecution";

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
                Opcode = (EtwEventOpcode)Opcodes.WakeDropExecution,
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
            public WakeDropExecutionData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new WakeDropExecutionEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public WakeDropExecutionEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a WakeDropExecutionEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator WakeDropExecutionEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a WakeDropExecution event.
            /// </summary>
            public ref struct WakeDropExecutionData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Object;
                private int _offset_Tag;
                private int _offset_ProcessId;
                private int _offset_Count;

                private int Offset_Object
                {
                    get
                    {
                        if (_offset_Object == -1)
                        {
                            _offset_Object = 0;
                        }

                        return _offset_Object;
                    }
                }

                private int Offset_Tag
                {
                    get
                    {
                        if (_offset_Tag == -1)
                        {
                            _offset_Tag = Offset_Object + _etwEvent.AddressSize;
                        }

                        return _offset_Tag;
                    }
                }

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = Offset_Tag + _etwEvent.AddressSize;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_Count
                {
                    get
                    {
                        if (_offset_Count == -1)
                        {
                            _offset_Count = Offset_ProcessId + 4;
                        }

                        return _offset_Count;
                    }
                }

                /// <summary>
                /// Retrieves the Object field.
                /// </summary>
                public ulong Object => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Object..Offset_Tag]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Object..Offset_Tag]);

                /// <summary>
                /// Retrieves the Tag field.
                /// </summary>
                public ulong Tag => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Tag..Offset_ProcessId]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Tag..Offset_ProcessId]);

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..Offset_Count]);

                /// <summary>
                /// Retrieves the Count field.
                /// </summary>
                public uint Count => BitConverter.ToUInt32(_etwEvent.Data[Offset_Count..]);

                /// <summary>
                /// Creates a new WakeDropExecutionData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public WakeDropExecutionData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Object = -1;
                    _offset_Tag = -1;
                    _offset_ProcessId = -1;
                    _offset_Count = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a WakeDropKernel event.
        /// </summary>
        public readonly ref struct WakeDropKernelEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "WakeDropKernel";

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
                Opcode = (EtwEventOpcode)Opcodes.WakeDropKernel,
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
            public WakeDropKernelData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new WakeDropKernelEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public WakeDropKernelEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a WakeDropKernelEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator WakeDropKernelEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a WakeDropKernel event.
            /// </summary>
            public ref struct WakeDropKernelData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Object;
                private int _offset_Tag;
                private int _offset_ProcessId;
                private int _offset_Count;

                private int Offset_Object
                {
                    get
                    {
                        if (_offset_Object == -1)
                        {
                            _offset_Object = 0;
                        }

                        return _offset_Object;
                    }
                }

                private int Offset_Tag
                {
                    get
                    {
                        if (_offset_Tag == -1)
                        {
                            _offset_Tag = Offset_Object + _etwEvent.AddressSize;
                        }

                        return _offset_Tag;
                    }
                }

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = Offset_Tag + _etwEvent.AddressSize;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_Count
                {
                    get
                    {
                        if (_offset_Count == -1)
                        {
                            _offset_Count = Offset_ProcessId + 4;
                        }

                        return _offset_Count;
                    }
                }

                /// <summary>
                /// Retrieves the Object field.
                /// </summary>
                public ulong Object => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Object..Offset_Tag]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Object..Offset_Tag]);

                /// <summary>
                /// Retrieves the Tag field.
                /// </summary>
                public ulong Tag => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Tag..Offset_ProcessId]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Tag..Offset_ProcessId]);

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..Offset_Count]);

                /// <summary>
                /// Retrieves the Count field.
                /// </summary>
                public uint Count => BitConverter.ToUInt32(_etwEvent.Data[Offset_Count..]);

                /// <summary>
                /// Creates a new WakeDropKernelData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public WakeDropKernelData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Object = -1;
                    _offset_Tag = -1;
                    _offset_ProcessId = -1;
                    _offset_Count = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a WakeDropInstrumentation event.
        /// </summary>
        public readonly ref struct WakeDropInstrumentationEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "WakeDropInstrumentation";

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
                Opcode = (EtwEventOpcode)Opcodes.WakeDropInstrumentation,
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
            public WakeDropInstrumentationData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new WakeDropInstrumentationEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public WakeDropInstrumentationEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a WakeDropInstrumentationEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator WakeDropInstrumentationEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a WakeDropInstrumentation event.
            /// </summary>
            public ref struct WakeDropInstrumentationData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Object;
                private int _offset_Tag;
                private int _offset_ProcessId;
                private int _offset_Count;

                private int Offset_Object
                {
                    get
                    {
                        if (_offset_Object == -1)
                        {
                            _offset_Object = 0;
                        }

                        return _offset_Object;
                    }
                }

                private int Offset_Tag
                {
                    get
                    {
                        if (_offset_Tag == -1)
                        {
                            _offset_Tag = Offset_Object + _etwEvent.AddressSize;
                        }

                        return _offset_Tag;
                    }
                }

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = Offset_Tag + _etwEvent.AddressSize;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_Count
                {
                    get
                    {
                        if (_offset_Count == -1)
                        {
                            _offset_Count = Offset_ProcessId + 4;
                        }

                        return _offset_Count;
                    }
                }

                /// <summary>
                /// Retrieves the Object field.
                /// </summary>
                public ulong Object => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Object..Offset_Tag]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Object..Offset_Tag]);

                /// <summary>
                /// Retrieves the Tag field.
                /// </summary>
                public ulong Tag => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Tag..Offset_ProcessId]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Tag..Offset_ProcessId]);

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..Offset_Count]);

                /// <summary>
                /// Retrieves the Count field.
                /// </summary>
                public uint Count => BitConverter.ToUInt32(_etwEvent.Data[Offset_Count..]);

                /// <summary>
                /// Creates a new WakeDropInstrumentationData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public WakeDropInstrumentationData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Object = -1;
                    _offset_Tag = -1;
                    _offset_ProcessId = -1;
                    _offset_Count = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a WakeDropPreserveProcess event.
        /// </summary>
        public readonly ref struct WakeDropPreserveProcessEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "WakeDropPreserveProcess";

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
                Opcode = (EtwEventOpcode)Opcodes.WakeDropPreserveProcess,
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
            public WakeDropPreserveProcessData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new WakeDropPreserveProcessEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public WakeDropPreserveProcessEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a WakeDropPreserveProcessEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator WakeDropPreserveProcessEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a WakeDropPreserveProcess event.
            /// </summary>
            public ref struct WakeDropPreserveProcessData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Object;
                private int _offset_Tag;
                private int _offset_ProcessId;
                private int _offset_Count;

                private int Offset_Object
                {
                    get
                    {
                        if (_offset_Object == -1)
                        {
                            _offset_Object = 0;
                        }

                        return _offset_Object;
                    }
                }

                private int Offset_Tag
                {
                    get
                    {
                        if (_offset_Tag == -1)
                        {
                            _offset_Tag = Offset_Object + _etwEvent.AddressSize;
                        }

                        return _offset_Tag;
                    }
                }

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = Offset_Tag + _etwEvent.AddressSize;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_Count
                {
                    get
                    {
                        if (_offset_Count == -1)
                        {
                            _offset_Count = Offset_ProcessId + 4;
                        }

                        return _offset_Count;
                    }
                }

                /// <summary>
                /// Retrieves the Object field.
                /// </summary>
                public ulong Object => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Object..Offset_Tag]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Object..Offset_Tag]);

                /// <summary>
                /// Retrieves the Tag field.
                /// </summary>
                public ulong Tag => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Tag..Offset_ProcessId]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Tag..Offset_ProcessId]);

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..Offset_Count]);

                /// <summary>
                /// Retrieves the Count field.
                /// </summary>
                public uint Count => BitConverter.ToUInt32(_etwEvent.Data[Offset_Count..]);

                /// <summary>
                /// Creates a new WakeDropPreserveProcessData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public WakeDropPreserveProcessData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Object = -1;
                    _offset_Tag = -1;
                    _offset_ProcessId = -1;
                    _offset_Count = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a WakeEventUser event.
        /// </summary>
        public readonly ref struct WakeEventUserEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "WakeEventUser";

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
                Opcode = (EtwEventOpcode)Opcodes.WakeEventUser,
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
            public WakeEventUserData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new WakeEventUserEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public WakeEventUserEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a WakeEventUserEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator WakeEventUserEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a WakeEventUser event.
            /// </summary>
            public ref struct WakeEventUserData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Object;

                private int Offset_Object
                {
                    get
                    {
                        if (_offset_Object == -1)
                        {
                            _offset_Object = 0;
                        }

                        return _offset_Object;
                    }
                }

                /// <summary>
                /// Retrieves the Object field.
                /// </summary>
                public ulong Object => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Object..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Object..]);

                /// <summary>
                /// Creates a new WakeEventUserData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public WakeEventUserData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Object = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a WakeEventExecution event.
        /// </summary>
        public readonly ref struct WakeEventExecutionEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "WakeEventExecution";

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
                Opcode = (EtwEventOpcode)Opcodes.WakeEventExecution,
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
            public WakeEventExecutionData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new WakeEventExecutionEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public WakeEventExecutionEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a WakeEventExecutionEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator WakeEventExecutionEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a WakeEventExecution event.
            /// </summary>
            public ref struct WakeEventExecutionData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Object;

                private int Offset_Object
                {
                    get
                    {
                        if (_offset_Object == -1)
                        {
                            _offset_Object = 0;
                        }

                        return _offset_Object;
                    }
                }

                /// <summary>
                /// Retrieves the Object field.
                /// </summary>
                public ulong Object => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Object..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Object..]);

                /// <summary>
                /// Creates a new WakeEventExecutionData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public WakeEventExecutionData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Object = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a WakeEventKernel event.
        /// </summary>
        public readonly ref struct WakeEventKernelEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "WakeEventKernel";

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
                Opcode = (EtwEventOpcode)Opcodes.WakeEventKernel,
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
            public WakeEventKernelData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new WakeEventKernelEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public WakeEventKernelEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a WakeEventKernelEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator WakeEventKernelEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a WakeEventKernel event.
            /// </summary>
            public ref struct WakeEventKernelData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Object;

                private int Offset_Object
                {
                    get
                    {
                        if (_offset_Object == -1)
                        {
                            _offset_Object = 0;
                        }

                        return _offset_Object;
                    }
                }

                /// <summary>
                /// Retrieves the Object field.
                /// </summary>
                public ulong Object => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Object..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Object..]);

                /// <summary>
                /// Creates a new WakeEventKernelData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public WakeEventKernelData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Object = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a WakeEventInstrumentation event.
        /// </summary>
        public readonly ref struct WakeEventInstrumentationEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "WakeEventInstrumentation";

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
                Opcode = (EtwEventOpcode)Opcodes.WakeEventInstrumentation,
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
            public WakeEventInstrumentationData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new WakeEventInstrumentationEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public WakeEventInstrumentationEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a WakeEventInstrumentationEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator WakeEventInstrumentationEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a WakeEventInstrumentation event.
            /// </summary>
            public ref struct WakeEventInstrumentationData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Object;

                private int Offset_Object
                {
                    get
                    {
                        if (_offset_Object == -1)
                        {
                            _offset_Object = 0;
                        }

                        return _offset_Object;
                    }
                }

                /// <summary>
                /// Retrieves the Object field.
                /// </summary>
                public ulong Object => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Object..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Object..]);

                /// <summary>
                /// Creates a new WakeEventInstrumentationData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public WakeEventInstrumentationData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Object = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Start event.
        /// </summary>
        public readonly ref struct StartEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Start";

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
                Opcode = EtwEventOpcode.Start,
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
            public StartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new StartEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public StartEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a StartEventV3.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator StartEventV3(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Start event.
            /// </summary>
            public ref struct StartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_UniqueProcessKey;
                private int _offset_ProcessId;
                private int _offset_ParentId;
                private int _offset_SessionId;
                private int _offset_ExitStatus;
                private int _offset_DirectoryTableBase;
                private int _offset_UserSID;
                private int _offset_ImageFileName;
                private int _offset_CommandLine;

                private int Offset_UniqueProcessKey
                {
                    get
                    {
                        if (_offset_UniqueProcessKey == -1)
                        {
                            _offset_UniqueProcessKey = 0;
                        }

                        return _offset_UniqueProcessKey;
                    }
                }

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = Offset_UniqueProcessKey + _etwEvent.AddressSize;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_ParentId
                {
                    get
                    {
                        if (_offset_ParentId == -1)
                        {
                            _offset_ParentId = Offset_ProcessId + 4;
                        }

                        return _offset_ParentId;
                    }
                }

                private int Offset_SessionId
                {
                    get
                    {
                        if (_offset_SessionId == -1)
                        {
                            _offset_SessionId = Offset_ParentId + 4;
                        }

                        return _offset_SessionId;
                    }
                }

                private int Offset_ExitStatus
                {
                    get
                    {
                        if (_offset_ExitStatus == -1)
                        {
                            _offset_ExitStatus = Offset_SessionId + 4;
                        }

                        return _offset_ExitStatus;
                    }
                }

                private int Offset_DirectoryTableBase
                {
                    get
                    {
                        if (_offset_DirectoryTableBase == -1)
                        {
                            _offset_DirectoryTableBase = Offset_ExitStatus + 4;
                        }

                        return _offset_DirectoryTableBase;
                    }
                }

                private int Offset_UserSID
                {
                    get
                    {
                        if (_offset_UserSID == -1)
                        {
                            _offset_UserSID = Offset_DirectoryTableBase + _etwEvent.AddressSize;
                        }

                        return _offset_UserSID;
                    }
                }

                private int Offset_ImageFileName
                {
                    get
                    {
                        if (_offset_ImageFileName == -1)
                        {
                            _offset_ImageFileName = Offset_UserSID + _etwEvent.GetWbemSidLength(Offset_UserSID);
                        }

                        return _offset_ImageFileName;
                    }
                }

                private int Offset_CommandLine
                {
                    get
                    {
                        if (_offset_CommandLine == -1)
                        {
                            _offset_CommandLine = Offset_ImageFileName + _etwEvent.AnsiStringLength(Offset_ImageFileName);
                        }

                        return _offset_CommandLine;
                    }
                }

                /// <summary>
                /// Retrieves the UniqueProcessKey field.
                /// </summary>
                public ulong UniqueProcessKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_UniqueProcessKey..Offset_ProcessId]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_UniqueProcessKey..Offset_ProcessId]);

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..Offset_ParentId]);

                /// <summary>
                /// Retrieves the ParentId field.
                /// </summary>
                public uint ParentId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ParentId..Offset_SessionId]);

                /// <summary>
                /// Retrieves the SessionId field.
                /// </summary>
                public uint SessionId => BitConverter.ToUInt32(_etwEvent.Data[Offset_SessionId..Offset_ExitStatus]);

                /// <summary>
                /// Retrieves the ExitStatus field.
                /// </summary>
                public int ExitStatus => BitConverter.ToInt32(_etwEvent.Data[Offset_ExitStatus..Offset_DirectoryTableBase]);

                /// <summary>
                /// Retrieves the DirectoryTableBase field.
                /// </summary>
                public ulong DirectoryTableBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_DirectoryTableBase..Offset_UserSID]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_DirectoryTableBase..Offset_UserSID]);

                /// <summary>
                /// Retrieves the UserSID field.
                /// </summary>
                public System.Security.Principal.SecurityIdentifier UserSID => _etwEvent.GetWbemSid(Offset_UserSID);

                /// <summary>
                /// Retrieves the ImageFileName field.
                /// </summary>
                public string ImageFileName => System.Text.Encoding.ASCII.GetString(_etwEvent.Data[Offset_ImageFileName..Offset_CommandLine]);

                /// <summary>
                /// Retrieves the CommandLine field.
                /// </summary>
                public string CommandLine => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_CommandLine..]);

                /// <summary>
                /// Creates a new StartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public StartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_UniqueProcessKey = -1;
                    _offset_ProcessId = -1;
                    _offset_ParentId = -1;
                    _offset_SessionId = -1;
                    _offset_ExitStatus = -1;
                    _offset_DirectoryTableBase = -1;
                    _offset_UserSID = -1;
                    _offset_ImageFileName = -1;
                    _offset_CommandLine = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a End event.
        /// </summary>
        public readonly ref struct EndEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "End";

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
            public EndData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new EndEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public EndEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a EndEventV3.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator EndEventV3(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a End event.
            /// </summary>
            public ref struct EndData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_UniqueProcessKey;
                private int _offset_ProcessId;
                private int _offset_ParentId;
                private int _offset_SessionId;
                private int _offset_ExitStatus;
                private int _offset_DirectoryTableBase;
                private int _offset_UserSID;
                private int _offset_ImageFileName;
                private int _offset_CommandLine;

                private int Offset_UniqueProcessKey
                {
                    get
                    {
                        if (_offset_UniqueProcessKey == -1)
                        {
                            _offset_UniqueProcessKey = 0;
                        }

                        return _offset_UniqueProcessKey;
                    }
                }

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = Offset_UniqueProcessKey + _etwEvent.AddressSize;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_ParentId
                {
                    get
                    {
                        if (_offset_ParentId == -1)
                        {
                            _offset_ParentId = Offset_ProcessId + 4;
                        }

                        return _offset_ParentId;
                    }
                }

                private int Offset_SessionId
                {
                    get
                    {
                        if (_offset_SessionId == -1)
                        {
                            _offset_SessionId = Offset_ParentId + 4;
                        }

                        return _offset_SessionId;
                    }
                }

                private int Offset_ExitStatus
                {
                    get
                    {
                        if (_offset_ExitStatus == -1)
                        {
                            _offset_ExitStatus = Offset_SessionId + 4;
                        }

                        return _offset_ExitStatus;
                    }
                }

                private int Offset_DirectoryTableBase
                {
                    get
                    {
                        if (_offset_DirectoryTableBase == -1)
                        {
                            _offset_DirectoryTableBase = Offset_ExitStatus + 4;
                        }

                        return _offset_DirectoryTableBase;
                    }
                }

                private int Offset_UserSID
                {
                    get
                    {
                        if (_offset_UserSID == -1)
                        {
                            _offset_UserSID = Offset_DirectoryTableBase + _etwEvent.AddressSize;
                        }

                        return _offset_UserSID;
                    }
                }

                private int Offset_ImageFileName
                {
                    get
                    {
                        if (_offset_ImageFileName == -1)
                        {
                            _offset_ImageFileName = Offset_UserSID + _etwEvent.GetWbemSidLength(Offset_UserSID);
                        }

                        return _offset_ImageFileName;
                    }
                }

                private int Offset_CommandLine
                {
                    get
                    {
                        if (_offset_CommandLine == -1)
                        {
                            _offset_CommandLine = Offset_ImageFileName + _etwEvent.AnsiStringLength(Offset_ImageFileName);
                        }

                        return _offset_CommandLine;
                    }
                }

                /// <summary>
                /// Retrieves the UniqueProcessKey field.
                /// </summary>
                public ulong UniqueProcessKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_UniqueProcessKey..Offset_ProcessId]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_UniqueProcessKey..Offset_ProcessId]);

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..Offset_ParentId]);

                /// <summary>
                /// Retrieves the ParentId field.
                /// </summary>
                public uint ParentId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ParentId..Offset_SessionId]);

                /// <summary>
                /// Retrieves the SessionId field.
                /// </summary>
                public uint SessionId => BitConverter.ToUInt32(_etwEvent.Data[Offset_SessionId..Offset_ExitStatus]);

                /// <summary>
                /// Retrieves the ExitStatus field.
                /// </summary>
                public int ExitStatus => BitConverter.ToInt32(_etwEvent.Data[Offset_ExitStatus..Offset_DirectoryTableBase]);

                /// <summary>
                /// Retrieves the DirectoryTableBase field.
                /// </summary>
                public ulong DirectoryTableBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_DirectoryTableBase..Offset_UserSID]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_DirectoryTableBase..Offset_UserSID]);

                /// <summary>
                /// Retrieves the UserSID field.
                /// </summary>
                public System.Security.Principal.SecurityIdentifier UserSID => _etwEvent.GetWbemSid(Offset_UserSID);

                /// <summary>
                /// Retrieves the ImageFileName field.
                /// </summary>
                public string ImageFileName => System.Text.Encoding.ASCII.GetString(_etwEvent.Data[Offset_ImageFileName..Offset_CommandLine]);

                /// <summary>
                /// Retrieves the CommandLine field.
                /// </summary>
                public string CommandLine => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_CommandLine..]);

                /// <summary>
                /// Creates a new EndData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public EndData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_UniqueProcessKey = -1;
                    _offset_ProcessId = -1;
                    _offset_ParentId = -1;
                    _offset_SessionId = -1;
                    _offset_ExitStatus = -1;
                    _offset_DirectoryTableBase = -1;
                    _offset_UserSID = -1;
                    _offset_ImageFileName = -1;
                    _offset_CommandLine = -1;
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

                private int _offset_UniqueProcessKey;
                private int _offset_ProcessId;
                private int _offset_ParentId;
                private int _offset_SessionId;
                private int _offset_ExitStatus;
                private int _offset_DirectoryTableBase;
                private int _offset_UserSID;
                private int _offset_ImageFileName;
                private int _offset_CommandLine;

                private int Offset_UniqueProcessKey
                {
                    get
                    {
                        if (_offset_UniqueProcessKey == -1)
                        {
                            _offset_UniqueProcessKey = 0;
                        }

                        return _offset_UniqueProcessKey;
                    }
                }

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = Offset_UniqueProcessKey + _etwEvent.AddressSize;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_ParentId
                {
                    get
                    {
                        if (_offset_ParentId == -1)
                        {
                            _offset_ParentId = Offset_ProcessId + 4;
                        }

                        return _offset_ParentId;
                    }
                }

                private int Offset_SessionId
                {
                    get
                    {
                        if (_offset_SessionId == -1)
                        {
                            _offset_SessionId = Offset_ParentId + 4;
                        }

                        return _offset_SessionId;
                    }
                }

                private int Offset_ExitStatus
                {
                    get
                    {
                        if (_offset_ExitStatus == -1)
                        {
                            _offset_ExitStatus = Offset_SessionId + 4;
                        }

                        return _offset_ExitStatus;
                    }
                }

                private int Offset_DirectoryTableBase
                {
                    get
                    {
                        if (_offset_DirectoryTableBase == -1)
                        {
                            _offset_DirectoryTableBase = Offset_ExitStatus + 4;
                        }

                        return _offset_DirectoryTableBase;
                    }
                }

                private int Offset_UserSID
                {
                    get
                    {
                        if (_offset_UserSID == -1)
                        {
                            _offset_UserSID = Offset_DirectoryTableBase + _etwEvent.AddressSize;
                        }

                        return _offset_UserSID;
                    }
                }

                private int Offset_ImageFileName
                {
                    get
                    {
                        if (_offset_ImageFileName == -1)
                        {
                            _offset_ImageFileName = Offset_UserSID + _etwEvent.GetWbemSidLength(Offset_UserSID);
                        }

                        return _offset_ImageFileName;
                    }
                }

                private int Offset_CommandLine
                {
                    get
                    {
                        if (_offset_CommandLine == -1)
                        {
                            _offset_CommandLine = Offset_ImageFileName + _etwEvent.AnsiStringLength(Offset_ImageFileName);
                        }

                        return _offset_CommandLine;
                    }
                }

                /// <summary>
                /// Retrieves the UniqueProcessKey field.
                /// </summary>
                public ulong UniqueProcessKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_UniqueProcessKey..Offset_ProcessId]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_UniqueProcessKey..Offset_ProcessId]);

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..Offset_ParentId]);

                /// <summary>
                /// Retrieves the ParentId field.
                /// </summary>
                public uint ParentId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ParentId..Offset_SessionId]);

                /// <summary>
                /// Retrieves the SessionId field.
                /// </summary>
                public uint SessionId => BitConverter.ToUInt32(_etwEvent.Data[Offset_SessionId..Offset_ExitStatus]);

                /// <summary>
                /// Retrieves the ExitStatus field.
                /// </summary>
                public int ExitStatus => BitConverter.ToInt32(_etwEvent.Data[Offset_ExitStatus..Offset_DirectoryTableBase]);

                /// <summary>
                /// Retrieves the DirectoryTableBase field.
                /// </summary>
                public ulong DirectoryTableBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_DirectoryTableBase..Offset_UserSID]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_DirectoryTableBase..Offset_UserSID]);

                /// <summary>
                /// Retrieves the UserSID field.
                /// </summary>
                public System.Security.Principal.SecurityIdentifier UserSID => _etwEvent.GetWbemSid(Offset_UserSID);

                /// <summary>
                /// Retrieves the ImageFileName field.
                /// </summary>
                public string ImageFileName => System.Text.Encoding.ASCII.GetString(_etwEvent.Data[Offset_ImageFileName..Offset_CommandLine]);

                /// <summary>
                /// Retrieves the CommandLine field.
                /// </summary>
                public string CommandLine => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_CommandLine..]);

                /// <summary>
                /// Creates a new DCStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DCStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_UniqueProcessKey = -1;
                    _offset_ProcessId = -1;
                    _offset_ParentId = -1;
                    _offset_SessionId = -1;
                    _offset_ExitStatus = -1;
                    _offset_DirectoryTableBase = -1;
                    _offset_UserSID = -1;
                    _offset_ImageFileName = -1;
                    _offset_CommandLine = -1;
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

                private int _offset_UniqueProcessKey;
                private int _offset_ProcessId;
                private int _offset_ParentId;
                private int _offset_SessionId;
                private int _offset_ExitStatus;
                private int _offset_DirectoryTableBase;
                private int _offset_UserSID;
                private int _offset_ImageFileName;
                private int _offset_CommandLine;

                private int Offset_UniqueProcessKey
                {
                    get
                    {
                        if (_offset_UniqueProcessKey == -1)
                        {
                            _offset_UniqueProcessKey = 0;
                        }

                        return _offset_UniqueProcessKey;
                    }
                }

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = Offset_UniqueProcessKey + _etwEvent.AddressSize;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_ParentId
                {
                    get
                    {
                        if (_offset_ParentId == -1)
                        {
                            _offset_ParentId = Offset_ProcessId + 4;
                        }

                        return _offset_ParentId;
                    }
                }

                private int Offset_SessionId
                {
                    get
                    {
                        if (_offset_SessionId == -1)
                        {
                            _offset_SessionId = Offset_ParentId + 4;
                        }

                        return _offset_SessionId;
                    }
                }

                private int Offset_ExitStatus
                {
                    get
                    {
                        if (_offset_ExitStatus == -1)
                        {
                            _offset_ExitStatus = Offset_SessionId + 4;
                        }

                        return _offset_ExitStatus;
                    }
                }

                private int Offset_DirectoryTableBase
                {
                    get
                    {
                        if (_offset_DirectoryTableBase == -1)
                        {
                            _offset_DirectoryTableBase = Offset_ExitStatus + 4;
                        }

                        return _offset_DirectoryTableBase;
                    }
                }

                private int Offset_UserSID
                {
                    get
                    {
                        if (_offset_UserSID == -1)
                        {
                            _offset_UserSID = Offset_DirectoryTableBase + _etwEvent.AddressSize;
                        }

                        return _offset_UserSID;
                    }
                }

                private int Offset_ImageFileName
                {
                    get
                    {
                        if (_offset_ImageFileName == -1)
                        {
                            _offset_ImageFileName = Offset_UserSID + _etwEvent.GetWbemSidLength(Offset_UserSID);
                        }

                        return _offset_ImageFileName;
                    }
                }

                private int Offset_CommandLine
                {
                    get
                    {
                        if (_offset_CommandLine == -1)
                        {
                            _offset_CommandLine = Offset_ImageFileName + _etwEvent.AnsiStringLength(Offset_ImageFileName);
                        }

                        return _offset_CommandLine;
                    }
                }

                /// <summary>
                /// Retrieves the UniqueProcessKey field.
                /// </summary>
                public ulong UniqueProcessKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_UniqueProcessKey..Offset_ProcessId]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_UniqueProcessKey..Offset_ProcessId]);

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..Offset_ParentId]);

                /// <summary>
                /// Retrieves the ParentId field.
                /// </summary>
                public uint ParentId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ParentId..Offset_SessionId]);

                /// <summary>
                /// Retrieves the SessionId field.
                /// </summary>
                public uint SessionId => BitConverter.ToUInt32(_etwEvent.Data[Offset_SessionId..Offset_ExitStatus]);

                /// <summary>
                /// Retrieves the ExitStatus field.
                /// </summary>
                public int ExitStatus => BitConverter.ToInt32(_etwEvent.Data[Offset_ExitStatus..Offset_DirectoryTableBase]);

                /// <summary>
                /// Retrieves the DirectoryTableBase field.
                /// </summary>
                public ulong DirectoryTableBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_DirectoryTableBase..Offset_UserSID]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_DirectoryTableBase..Offset_UserSID]);

                /// <summary>
                /// Retrieves the UserSID field.
                /// </summary>
                public System.Security.Principal.SecurityIdentifier UserSID => _etwEvent.GetWbemSid(Offset_UserSID);

                /// <summary>
                /// Retrieves the ImageFileName field.
                /// </summary>
                public string ImageFileName => System.Text.Encoding.ASCII.GetString(_etwEvent.Data[Offset_ImageFileName..Offset_CommandLine]);

                /// <summary>
                /// Retrieves the CommandLine field.
                /// </summary>
                public string CommandLine => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_CommandLine..]);

                /// <summary>
                /// Creates a new DCEndData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DCEndData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_UniqueProcessKey = -1;
                    _offset_ProcessId = -1;
                    _offset_ParentId = -1;
                    _offset_SessionId = -1;
                    _offset_ExitStatus = -1;
                    _offset_DirectoryTableBase = -1;
                    _offset_UserSID = -1;
                    _offset_ImageFileName = -1;
                    _offset_CommandLine = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Defunct event.
        /// </summary>
        public readonly ref struct DefunctEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Defunct";

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
                Opcode = (EtwEventOpcode)Opcodes.Defunct,
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
            public DefunctData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DefunctEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DefunctEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a DefunctEventV3.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator DefunctEventV3(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Defunct event.
            /// </summary>
            public ref struct DefunctData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_UniqueProcessKey;
                private int _offset_ProcessId;
                private int _offset_ParentId;
                private int _offset_SessionId;
                private int _offset_ExitStatus;
                private int _offset_DirectoryTableBase;
                private int _offset_UserSID;
                private int _offset_ImageFileName;
                private int _offset_CommandLine;

                private int Offset_UniqueProcessKey
                {
                    get
                    {
                        if (_offset_UniqueProcessKey == -1)
                        {
                            _offset_UniqueProcessKey = 0;
                        }

                        return _offset_UniqueProcessKey;
                    }
                }

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = Offset_UniqueProcessKey + _etwEvent.AddressSize;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_ParentId
                {
                    get
                    {
                        if (_offset_ParentId == -1)
                        {
                            _offset_ParentId = Offset_ProcessId + 4;
                        }

                        return _offset_ParentId;
                    }
                }

                private int Offset_SessionId
                {
                    get
                    {
                        if (_offset_SessionId == -1)
                        {
                            _offset_SessionId = Offset_ParentId + 4;
                        }

                        return _offset_SessionId;
                    }
                }

                private int Offset_ExitStatus
                {
                    get
                    {
                        if (_offset_ExitStatus == -1)
                        {
                            _offset_ExitStatus = Offset_SessionId + 4;
                        }

                        return _offset_ExitStatus;
                    }
                }

                private int Offset_DirectoryTableBase
                {
                    get
                    {
                        if (_offset_DirectoryTableBase == -1)
                        {
                            _offset_DirectoryTableBase = Offset_ExitStatus + 4;
                        }

                        return _offset_DirectoryTableBase;
                    }
                }

                private int Offset_UserSID
                {
                    get
                    {
                        if (_offset_UserSID == -1)
                        {
                            _offset_UserSID = Offset_DirectoryTableBase + _etwEvent.AddressSize;
                        }

                        return _offset_UserSID;
                    }
                }

                private int Offset_ImageFileName
                {
                    get
                    {
                        if (_offset_ImageFileName == -1)
                        {
                            _offset_ImageFileName = Offset_UserSID + _etwEvent.GetWbemSidLength(Offset_UserSID);
                        }

                        return _offset_ImageFileName;
                    }
                }

                private int Offset_CommandLine
                {
                    get
                    {
                        if (_offset_CommandLine == -1)
                        {
                            _offset_CommandLine = Offset_ImageFileName + _etwEvent.AnsiStringLength(Offset_ImageFileName);
                        }

                        return _offset_CommandLine;
                    }
                }

                /// <summary>
                /// Retrieves the UniqueProcessKey field.
                /// </summary>
                public ulong UniqueProcessKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_UniqueProcessKey..Offset_ProcessId]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_UniqueProcessKey..Offset_ProcessId]);

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..Offset_ParentId]);

                /// <summary>
                /// Retrieves the ParentId field.
                /// </summary>
                public uint ParentId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ParentId..Offset_SessionId]);

                /// <summary>
                /// Retrieves the SessionId field.
                /// </summary>
                public uint SessionId => BitConverter.ToUInt32(_etwEvent.Data[Offset_SessionId..Offset_ExitStatus]);

                /// <summary>
                /// Retrieves the ExitStatus field.
                /// </summary>
                public int ExitStatus => BitConverter.ToInt32(_etwEvent.Data[Offset_ExitStatus..Offset_DirectoryTableBase]);

                /// <summary>
                /// Retrieves the DirectoryTableBase field.
                /// </summary>
                public ulong DirectoryTableBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_DirectoryTableBase..Offset_UserSID]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_DirectoryTableBase..Offset_UserSID]);

                /// <summary>
                /// Retrieves the UserSID field.
                /// </summary>
                public System.Security.Principal.SecurityIdentifier UserSID => _etwEvent.GetWbemSid(Offset_UserSID);

                /// <summary>
                /// Retrieves the ImageFileName field.
                /// </summary>
                public string ImageFileName => System.Text.Encoding.ASCII.GetString(_etwEvent.Data[Offset_ImageFileName..Offset_CommandLine]);

                /// <summary>
                /// Retrieves the CommandLine field.
                /// </summary>
                public string CommandLine => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_CommandLine..]);

                /// <summary>
                /// Creates a new DefunctData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DefunctData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_UniqueProcessKey = -1;
                    _offset_ProcessId = -1;
                    _offset_ParentId = -1;
                    _offset_SessionId = -1;
                    _offset_ExitStatus = -1;
                    _offset_DirectoryTableBase = -1;
                    _offset_UserSID = -1;
                    _offset_ImageFileName = -1;
                    _offset_CommandLine = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Start event.
        /// </summary>
        public readonly ref struct StartEventV4
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Start";

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
                Version = 4,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = EtwEventOpcode.Start,
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
            public StartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new StartEventV4.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public StartEventV4(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a StartEventV4.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator StartEventV4(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Start event.
            /// </summary>
            public ref struct StartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_UniqueProcessKey;
                private int _offset_ProcessId;
                private int _offset_ParentId;
                private int _offset_SessionId;
                private int _offset_ExitStatus;
                private int _offset_DirectoryTableBase;
                private int _offset_Flags;
                private int _offset_UserSID;
                private int _offset_ImageFileName;
                private int _offset_CommandLine;
                private int _offset_PackageFullName;
                private int _offset_ApplicationId;

                private int Offset_UniqueProcessKey
                {
                    get
                    {
                        if (_offset_UniqueProcessKey == -1)
                        {
                            _offset_UniqueProcessKey = 0;
                        }

                        return _offset_UniqueProcessKey;
                    }
                }

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = Offset_UniqueProcessKey + _etwEvent.AddressSize;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_ParentId
                {
                    get
                    {
                        if (_offset_ParentId == -1)
                        {
                            _offset_ParentId = Offset_ProcessId + 4;
                        }

                        return _offset_ParentId;
                    }
                }

                private int Offset_SessionId
                {
                    get
                    {
                        if (_offset_SessionId == -1)
                        {
                            _offset_SessionId = Offset_ParentId + 4;
                        }

                        return _offset_SessionId;
                    }
                }

                private int Offset_ExitStatus
                {
                    get
                    {
                        if (_offset_ExitStatus == -1)
                        {
                            _offset_ExitStatus = Offset_SessionId + 4;
                        }

                        return _offset_ExitStatus;
                    }
                }

                private int Offset_DirectoryTableBase
                {
                    get
                    {
                        if (_offset_DirectoryTableBase == -1)
                        {
                            _offset_DirectoryTableBase = Offset_ExitStatus + 4;
                        }

                        return _offset_DirectoryTableBase;
                    }
                }

                private int Offset_Flags
                {
                    get
                    {
                        if (_offset_Flags == -1)
                        {
                            _offset_Flags = Offset_DirectoryTableBase + _etwEvent.AddressSize;
                        }

                        return _offset_Flags;
                    }
                }

                private int Offset_UserSID
                {
                    get
                    {
                        if (_offset_UserSID == -1)
                        {
                            _offset_UserSID = Offset_Flags + 4;
                        }

                        return _offset_UserSID;
                    }
                }

                private int Offset_ImageFileName
                {
                    get
                    {
                        if (_offset_ImageFileName == -1)
                        {
                            _offset_ImageFileName = Offset_UserSID + _etwEvent.GetWbemSidLength(Offset_UserSID);
                        }

                        return _offset_ImageFileName;
                    }
                }

                private int Offset_CommandLine
                {
                    get
                    {
                        if (_offset_CommandLine == -1)
                        {
                            _offset_CommandLine = Offset_ImageFileName + _etwEvent.AnsiStringLength(Offset_ImageFileName);
                        }

                        return _offset_CommandLine;
                    }
                }

                private int Offset_PackageFullName
                {
                    get
                    {
                        if (_offset_PackageFullName == -1)
                        {
                            _offset_PackageFullName = Offset_CommandLine + _etwEvent.UnicodeStringLength(Offset_CommandLine);
                        }

                        return _offset_PackageFullName;
                    }
                }

                private int Offset_ApplicationId
                {
                    get
                    {
                        if (_offset_ApplicationId == -1)
                        {
                            _offset_ApplicationId = Offset_PackageFullName + _etwEvent.UnicodeStringLength(Offset_PackageFullName);
                        }

                        return _offset_ApplicationId;
                    }
                }

                /// <summary>
                /// Retrieves the UniqueProcessKey field.
                /// </summary>
                public ulong UniqueProcessKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_UniqueProcessKey..Offset_ProcessId]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_UniqueProcessKey..Offset_ProcessId]);

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..Offset_ParentId]);

                /// <summary>
                /// Retrieves the ParentId field.
                /// </summary>
                public uint ParentId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ParentId..Offset_SessionId]);

                /// <summary>
                /// Retrieves the SessionId field.
                /// </summary>
                public uint SessionId => BitConverter.ToUInt32(_etwEvent.Data[Offset_SessionId..Offset_ExitStatus]);

                /// <summary>
                /// Retrieves the ExitStatus field.
                /// </summary>
                public int ExitStatus => BitConverter.ToInt32(_etwEvent.Data[Offset_ExitStatus..Offset_DirectoryTableBase]);

                /// <summary>
                /// Retrieves the DirectoryTableBase field.
                /// </summary>
                public ulong DirectoryTableBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_DirectoryTableBase..Offset_Flags]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_DirectoryTableBase..Offset_Flags]);

                /// <summary>
                /// Retrieves the Flags field.
                /// </summary>
                public uint Flags => BitConverter.ToUInt32(_etwEvent.Data[Offset_Flags..Offset_UserSID]);

                /// <summary>
                /// Retrieves the UserSID field.
                /// </summary>
                public System.Security.Principal.SecurityIdentifier UserSID => _etwEvent.GetWbemSid(Offset_UserSID);

                /// <summary>
                /// Retrieves the ImageFileName field.
                /// </summary>
                public string ImageFileName => System.Text.Encoding.ASCII.GetString(_etwEvent.Data[Offset_ImageFileName..Offset_CommandLine]);

                /// <summary>
                /// Retrieves the CommandLine field.
                /// </summary>
                public string CommandLine => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_CommandLine..Offset_PackageFullName]);

                /// <summary>
                /// Retrieves the PackageFullName field.
                /// </summary>
                public string PackageFullName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_PackageFullName..Offset_ApplicationId]);

                /// <summary>
                /// Retrieves the ApplicationId field.
                /// </summary>
                public string ApplicationId => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ApplicationId..]);

                /// <summary>
                /// Creates a new StartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public StartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_UniqueProcessKey = -1;
                    _offset_ProcessId = -1;
                    _offset_ParentId = -1;
                    _offset_SessionId = -1;
                    _offset_ExitStatus = -1;
                    _offset_DirectoryTableBase = -1;
                    _offset_Flags = -1;
                    _offset_UserSID = -1;
                    _offset_ImageFileName = -1;
                    _offset_CommandLine = -1;
                    _offset_PackageFullName = -1;
                    _offset_ApplicationId = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a End event.
        /// </summary>
        public readonly ref struct EndEventV4
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "End";

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
                Version = 4,
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
            public EndData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new EndEventV4.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public EndEventV4(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a EndEventV4.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator EndEventV4(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a End event.
            /// </summary>
            public ref struct EndData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_UniqueProcessKey;
                private int _offset_ProcessId;
                private int _offset_ParentId;
                private int _offset_SessionId;
                private int _offset_ExitStatus;
                private int _offset_DirectoryTableBase;
                private int _offset_Flags;
                private int _offset_UserSID;
                private int _offset_ImageFileName;
                private int _offset_CommandLine;
                private int _offset_PackageFullName;
                private int _offset_ApplicationId;

                private int Offset_UniqueProcessKey
                {
                    get
                    {
                        if (_offset_UniqueProcessKey == -1)
                        {
                            _offset_UniqueProcessKey = 0;
                        }

                        return _offset_UniqueProcessKey;
                    }
                }

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = Offset_UniqueProcessKey + _etwEvent.AddressSize;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_ParentId
                {
                    get
                    {
                        if (_offset_ParentId == -1)
                        {
                            _offset_ParentId = Offset_ProcessId + 4;
                        }

                        return _offset_ParentId;
                    }
                }

                private int Offset_SessionId
                {
                    get
                    {
                        if (_offset_SessionId == -1)
                        {
                            _offset_SessionId = Offset_ParentId + 4;
                        }

                        return _offset_SessionId;
                    }
                }

                private int Offset_ExitStatus
                {
                    get
                    {
                        if (_offset_ExitStatus == -1)
                        {
                            _offset_ExitStatus = Offset_SessionId + 4;
                        }

                        return _offset_ExitStatus;
                    }
                }

                private int Offset_DirectoryTableBase
                {
                    get
                    {
                        if (_offset_DirectoryTableBase == -1)
                        {
                            _offset_DirectoryTableBase = Offset_ExitStatus + 4;
                        }

                        return _offset_DirectoryTableBase;
                    }
                }

                private int Offset_Flags
                {
                    get
                    {
                        if (_offset_Flags == -1)
                        {
                            _offset_Flags = Offset_DirectoryTableBase + _etwEvent.AddressSize;
                        }

                        return _offset_Flags;
                    }
                }

                private int Offset_UserSID
                {
                    get
                    {
                        if (_offset_UserSID == -1)
                        {
                            _offset_UserSID = Offset_Flags + 4;
                        }

                        return _offset_UserSID;
                    }
                }

                private int Offset_ImageFileName
                {
                    get
                    {
                        if (_offset_ImageFileName == -1)
                        {
                            _offset_ImageFileName = Offset_UserSID + _etwEvent.GetWbemSidLength(Offset_UserSID);
                        }

                        return _offset_ImageFileName;
                    }
                }

                private int Offset_CommandLine
                {
                    get
                    {
                        if (_offset_CommandLine == -1)
                        {
                            _offset_CommandLine = Offset_ImageFileName + _etwEvent.AnsiStringLength(Offset_ImageFileName);
                        }

                        return _offset_CommandLine;
                    }
                }

                private int Offset_PackageFullName
                {
                    get
                    {
                        if (_offset_PackageFullName == -1)
                        {
                            _offset_PackageFullName = Offset_CommandLine + _etwEvent.UnicodeStringLength(Offset_CommandLine);
                        }

                        return _offset_PackageFullName;
                    }
                }

                private int Offset_ApplicationId
                {
                    get
                    {
                        if (_offset_ApplicationId == -1)
                        {
                            _offset_ApplicationId = Offset_PackageFullName + _etwEvent.UnicodeStringLength(Offset_PackageFullName);
                        }

                        return _offset_ApplicationId;
                    }
                }

                /// <summary>
                /// Retrieves the UniqueProcessKey field.
                /// </summary>
                public ulong UniqueProcessKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_UniqueProcessKey..Offset_ProcessId]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_UniqueProcessKey..Offset_ProcessId]);

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..Offset_ParentId]);

                /// <summary>
                /// Retrieves the ParentId field.
                /// </summary>
                public uint ParentId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ParentId..Offset_SessionId]);

                /// <summary>
                /// Retrieves the SessionId field.
                /// </summary>
                public uint SessionId => BitConverter.ToUInt32(_etwEvent.Data[Offset_SessionId..Offset_ExitStatus]);

                /// <summary>
                /// Retrieves the ExitStatus field.
                /// </summary>
                public int ExitStatus => BitConverter.ToInt32(_etwEvent.Data[Offset_ExitStatus..Offset_DirectoryTableBase]);

                /// <summary>
                /// Retrieves the DirectoryTableBase field.
                /// </summary>
                public ulong DirectoryTableBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_DirectoryTableBase..Offset_Flags]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_DirectoryTableBase..Offset_Flags]);

                /// <summary>
                /// Retrieves the Flags field.
                /// </summary>
                public uint Flags => BitConverter.ToUInt32(_etwEvent.Data[Offset_Flags..Offset_UserSID]);

                /// <summary>
                /// Retrieves the UserSID field.
                /// </summary>
                public System.Security.Principal.SecurityIdentifier UserSID => _etwEvent.GetWbemSid(Offset_UserSID);

                /// <summary>
                /// Retrieves the ImageFileName field.
                /// </summary>
                public string ImageFileName => System.Text.Encoding.ASCII.GetString(_etwEvent.Data[Offset_ImageFileName..Offset_CommandLine]);

                /// <summary>
                /// Retrieves the CommandLine field.
                /// </summary>
                public string CommandLine => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_CommandLine..Offset_PackageFullName]);

                /// <summary>
                /// Retrieves the PackageFullName field.
                /// </summary>
                public string PackageFullName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_PackageFullName..Offset_ApplicationId]);

                /// <summary>
                /// Retrieves the ApplicationId field.
                /// </summary>
                public string ApplicationId => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ApplicationId..]);

                /// <summary>
                /// Creates a new EndData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public EndData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_UniqueProcessKey = -1;
                    _offset_ProcessId = -1;
                    _offset_ParentId = -1;
                    _offset_SessionId = -1;
                    _offset_ExitStatus = -1;
                    _offset_DirectoryTableBase = -1;
                    _offset_Flags = -1;
                    _offset_UserSID = -1;
                    _offset_ImageFileName = -1;
                    _offset_CommandLine = -1;
                    _offset_PackageFullName = -1;
                    _offset_ApplicationId = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DCStart event.
        /// </summary>
        public readonly ref struct DCStartEventV4
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
                Version = 4,
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
            /// Creates a new DCStartEventV4.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DCStartEventV4(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a DCStartEventV4.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator DCStartEventV4(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a DCStart event.
            /// </summary>
            public ref struct DCStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_UniqueProcessKey;
                private int _offset_ProcessId;
                private int _offset_ParentId;
                private int _offset_SessionId;
                private int _offset_ExitStatus;
                private int _offset_DirectoryTableBase;
                private int _offset_Flags;
                private int _offset_UserSID;
                private int _offset_ImageFileName;
                private int _offset_CommandLine;
                private int _offset_PackageFullName;
                private int _offset_ApplicationId;

                private int Offset_UniqueProcessKey
                {
                    get
                    {
                        if (_offset_UniqueProcessKey == -1)
                        {
                            _offset_UniqueProcessKey = 0;
                        }

                        return _offset_UniqueProcessKey;
                    }
                }

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = Offset_UniqueProcessKey + _etwEvent.AddressSize;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_ParentId
                {
                    get
                    {
                        if (_offset_ParentId == -1)
                        {
                            _offset_ParentId = Offset_ProcessId + 4;
                        }

                        return _offset_ParentId;
                    }
                }

                private int Offset_SessionId
                {
                    get
                    {
                        if (_offset_SessionId == -1)
                        {
                            _offset_SessionId = Offset_ParentId + 4;
                        }

                        return _offset_SessionId;
                    }
                }

                private int Offset_ExitStatus
                {
                    get
                    {
                        if (_offset_ExitStatus == -1)
                        {
                            _offset_ExitStatus = Offset_SessionId + 4;
                        }

                        return _offset_ExitStatus;
                    }
                }

                private int Offset_DirectoryTableBase
                {
                    get
                    {
                        if (_offset_DirectoryTableBase == -1)
                        {
                            _offset_DirectoryTableBase = Offset_ExitStatus + 4;
                        }

                        return _offset_DirectoryTableBase;
                    }
                }

                private int Offset_Flags
                {
                    get
                    {
                        if (_offset_Flags == -1)
                        {
                            _offset_Flags = Offset_DirectoryTableBase + _etwEvent.AddressSize;
                        }

                        return _offset_Flags;
                    }
                }

                private int Offset_UserSID
                {
                    get
                    {
                        if (_offset_UserSID == -1)
                        {
                            _offset_UserSID = Offset_Flags + 4;
                        }

                        return _offset_UserSID;
                    }
                }

                private int Offset_ImageFileName
                {
                    get
                    {
                        if (_offset_ImageFileName == -1)
                        {
                            _offset_ImageFileName = Offset_UserSID + _etwEvent.GetWbemSidLength(Offset_UserSID);
                        }

                        return _offset_ImageFileName;
                    }
                }

                private int Offset_CommandLine
                {
                    get
                    {
                        if (_offset_CommandLine == -1)
                        {
                            _offset_CommandLine = Offset_ImageFileName + _etwEvent.AnsiStringLength(Offset_ImageFileName);
                        }

                        return _offset_CommandLine;
                    }
                }

                private int Offset_PackageFullName
                {
                    get
                    {
                        if (_offset_PackageFullName == -1)
                        {
                            _offset_PackageFullName = Offset_CommandLine + _etwEvent.UnicodeStringLength(Offset_CommandLine);
                        }

                        return _offset_PackageFullName;
                    }
                }

                private int Offset_ApplicationId
                {
                    get
                    {
                        if (_offset_ApplicationId == -1)
                        {
                            _offset_ApplicationId = Offset_PackageFullName + _etwEvent.UnicodeStringLength(Offset_PackageFullName);
                        }

                        return _offset_ApplicationId;
                    }
                }

                /// <summary>
                /// Retrieves the UniqueProcessKey field.
                /// </summary>
                public ulong UniqueProcessKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_UniqueProcessKey..Offset_ProcessId]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_UniqueProcessKey..Offset_ProcessId]);

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..Offset_ParentId]);

                /// <summary>
                /// Retrieves the ParentId field.
                /// </summary>
                public uint ParentId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ParentId..Offset_SessionId]);

                /// <summary>
                /// Retrieves the SessionId field.
                /// </summary>
                public uint SessionId => BitConverter.ToUInt32(_etwEvent.Data[Offset_SessionId..Offset_ExitStatus]);

                /// <summary>
                /// Retrieves the ExitStatus field.
                /// </summary>
                public int ExitStatus => BitConverter.ToInt32(_etwEvent.Data[Offset_ExitStatus..Offset_DirectoryTableBase]);

                /// <summary>
                /// Retrieves the DirectoryTableBase field.
                /// </summary>
                public ulong DirectoryTableBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_DirectoryTableBase..Offset_Flags]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_DirectoryTableBase..Offset_Flags]);

                /// <summary>
                /// Retrieves the Flags field.
                /// </summary>
                public uint Flags => BitConverter.ToUInt32(_etwEvent.Data[Offset_Flags..Offset_UserSID]);

                /// <summary>
                /// Retrieves the UserSID field.
                /// </summary>
                public System.Security.Principal.SecurityIdentifier UserSID => _etwEvent.GetWbemSid(Offset_UserSID);

                /// <summary>
                /// Retrieves the ImageFileName field.
                /// </summary>
                public string ImageFileName => System.Text.Encoding.ASCII.GetString(_etwEvent.Data[Offset_ImageFileName..Offset_CommandLine]);

                /// <summary>
                /// Retrieves the CommandLine field.
                /// </summary>
                public string CommandLine => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_CommandLine..Offset_PackageFullName]);

                /// <summary>
                /// Retrieves the PackageFullName field.
                /// </summary>
                public string PackageFullName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_PackageFullName..Offset_ApplicationId]);

                /// <summary>
                /// Retrieves the ApplicationId field.
                /// </summary>
                public string ApplicationId => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ApplicationId..]);

                /// <summary>
                /// Creates a new DCStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DCStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_UniqueProcessKey = -1;
                    _offset_ProcessId = -1;
                    _offset_ParentId = -1;
                    _offset_SessionId = -1;
                    _offset_ExitStatus = -1;
                    _offset_DirectoryTableBase = -1;
                    _offset_Flags = -1;
                    _offset_UserSID = -1;
                    _offset_ImageFileName = -1;
                    _offset_CommandLine = -1;
                    _offset_PackageFullName = -1;
                    _offset_ApplicationId = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DCEnd event.
        /// </summary>
        public readonly ref struct DCEndEventV4
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
                Version = 4,
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
            /// Creates a new DCEndEventV4.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DCEndEventV4(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a DCEndEventV4.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator DCEndEventV4(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a DCEnd event.
            /// </summary>
            public ref struct DCEndData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_UniqueProcessKey;
                private int _offset_ProcessId;
                private int _offset_ParentId;
                private int _offset_SessionId;
                private int _offset_ExitStatus;
                private int _offset_DirectoryTableBase;
                private int _offset_Flags;
                private int _offset_UserSID;
                private int _offset_ImageFileName;
                private int _offset_CommandLine;
                private int _offset_PackageFullName;
                private int _offset_ApplicationId;

                private int Offset_UniqueProcessKey
                {
                    get
                    {
                        if (_offset_UniqueProcessKey == -1)
                        {
                            _offset_UniqueProcessKey = 0;
                        }

                        return _offset_UniqueProcessKey;
                    }
                }

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = Offset_UniqueProcessKey + _etwEvent.AddressSize;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_ParentId
                {
                    get
                    {
                        if (_offset_ParentId == -1)
                        {
                            _offset_ParentId = Offset_ProcessId + 4;
                        }

                        return _offset_ParentId;
                    }
                }

                private int Offset_SessionId
                {
                    get
                    {
                        if (_offset_SessionId == -1)
                        {
                            _offset_SessionId = Offset_ParentId + 4;
                        }

                        return _offset_SessionId;
                    }
                }

                private int Offset_ExitStatus
                {
                    get
                    {
                        if (_offset_ExitStatus == -1)
                        {
                            _offset_ExitStatus = Offset_SessionId + 4;
                        }

                        return _offset_ExitStatus;
                    }
                }

                private int Offset_DirectoryTableBase
                {
                    get
                    {
                        if (_offset_DirectoryTableBase == -1)
                        {
                            _offset_DirectoryTableBase = Offset_ExitStatus + 4;
                        }

                        return _offset_DirectoryTableBase;
                    }
                }

                private int Offset_Flags
                {
                    get
                    {
                        if (_offset_Flags == -1)
                        {
                            _offset_Flags = Offset_DirectoryTableBase + _etwEvent.AddressSize;
                        }

                        return _offset_Flags;
                    }
                }

                private int Offset_UserSID
                {
                    get
                    {
                        if (_offset_UserSID == -1)
                        {
                            _offset_UserSID = Offset_Flags + 4;
                        }

                        return _offset_UserSID;
                    }
                }

                private int Offset_ImageFileName
                {
                    get
                    {
                        if (_offset_ImageFileName == -1)
                        {
                            _offset_ImageFileName = Offset_UserSID + _etwEvent.GetWbemSidLength(Offset_UserSID);
                        }

                        return _offset_ImageFileName;
                    }
                }

                private int Offset_CommandLine
                {
                    get
                    {
                        if (_offset_CommandLine == -1)
                        {
                            _offset_CommandLine = Offset_ImageFileName + _etwEvent.AnsiStringLength(Offset_ImageFileName);
                        }

                        return _offset_CommandLine;
                    }
                }

                private int Offset_PackageFullName
                {
                    get
                    {
                        if (_offset_PackageFullName == -1)
                        {
                            _offset_PackageFullName = Offset_CommandLine + _etwEvent.UnicodeStringLength(Offset_CommandLine);
                        }

                        return _offset_PackageFullName;
                    }
                }

                private int Offset_ApplicationId
                {
                    get
                    {
                        if (_offset_ApplicationId == -1)
                        {
                            _offset_ApplicationId = Offset_PackageFullName + _etwEvent.UnicodeStringLength(Offset_PackageFullName);
                        }

                        return _offset_ApplicationId;
                    }
                }

                /// <summary>
                /// Retrieves the UniqueProcessKey field.
                /// </summary>
                public ulong UniqueProcessKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_UniqueProcessKey..Offset_ProcessId]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_UniqueProcessKey..Offset_ProcessId]);

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..Offset_ParentId]);

                /// <summary>
                /// Retrieves the ParentId field.
                /// </summary>
                public uint ParentId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ParentId..Offset_SessionId]);

                /// <summary>
                /// Retrieves the SessionId field.
                /// </summary>
                public uint SessionId => BitConverter.ToUInt32(_etwEvent.Data[Offset_SessionId..Offset_ExitStatus]);

                /// <summary>
                /// Retrieves the ExitStatus field.
                /// </summary>
                public int ExitStatus => BitConverter.ToInt32(_etwEvent.Data[Offset_ExitStatus..Offset_DirectoryTableBase]);

                /// <summary>
                /// Retrieves the DirectoryTableBase field.
                /// </summary>
                public ulong DirectoryTableBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_DirectoryTableBase..Offset_Flags]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_DirectoryTableBase..Offset_Flags]);

                /// <summary>
                /// Retrieves the Flags field.
                /// </summary>
                public uint Flags => BitConverter.ToUInt32(_etwEvent.Data[Offset_Flags..Offset_UserSID]);

                /// <summary>
                /// Retrieves the UserSID field.
                /// </summary>
                public System.Security.Principal.SecurityIdentifier UserSID => _etwEvent.GetWbemSid(Offset_UserSID);

                /// <summary>
                /// Retrieves the ImageFileName field.
                /// </summary>
                public string ImageFileName => System.Text.Encoding.ASCII.GetString(_etwEvent.Data[Offset_ImageFileName..Offset_CommandLine]);

                /// <summary>
                /// Retrieves the CommandLine field.
                /// </summary>
                public string CommandLine => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_CommandLine..Offset_PackageFullName]);

                /// <summary>
                /// Retrieves the PackageFullName field.
                /// </summary>
                public string PackageFullName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_PackageFullName..Offset_ApplicationId]);

                /// <summary>
                /// Retrieves the ApplicationId field.
                /// </summary>
                public string ApplicationId => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ApplicationId..]);

                /// <summary>
                /// Creates a new DCEndData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DCEndData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_UniqueProcessKey = -1;
                    _offset_ProcessId = -1;
                    _offset_ParentId = -1;
                    _offset_SessionId = -1;
                    _offset_ExitStatus = -1;
                    _offset_DirectoryTableBase = -1;
                    _offset_Flags = -1;
                    _offset_UserSID = -1;
                    _offset_ImageFileName = -1;
                    _offset_CommandLine = -1;
                    _offset_PackageFullName = -1;
                    _offset_ApplicationId = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Defunct event.
        /// </summary>
        public readonly ref struct DefunctEventV4
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Defunct";

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
                Version = 4,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.Defunct,
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
            public DefunctData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DefunctEventV4.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DefunctEventV4(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a DefunctEventV4.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator DefunctEventV4(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Defunct event.
            /// </summary>
            public ref struct DefunctData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_UniqueProcessKey;
                private int _offset_ProcessId;
                private int _offset_ParentId;
                private int _offset_SessionId;
                private int _offset_ExitStatus;
                private int _offset_DirectoryTableBase;
                private int _offset_Flags;
                private int _offset_UserSID;
                private int _offset_ImageFileName;
                private int _offset_CommandLine;
                private int _offset_PackageFullName;
                private int _offset_ApplicationId;

                private int Offset_UniqueProcessKey
                {
                    get
                    {
                        if (_offset_UniqueProcessKey == -1)
                        {
                            _offset_UniqueProcessKey = 0;
                        }

                        return _offset_UniqueProcessKey;
                    }
                }

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = Offset_UniqueProcessKey + _etwEvent.AddressSize;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_ParentId
                {
                    get
                    {
                        if (_offset_ParentId == -1)
                        {
                            _offset_ParentId = Offset_ProcessId + 4;
                        }

                        return _offset_ParentId;
                    }
                }

                private int Offset_SessionId
                {
                    get
                    {
                        if (_offset_SessionId == -1)
                        {
                            _offset_SessionId = Offset_ParentId + 4;
                        }

                        return _offset_SessionId;
                    }
                }

                private int Offset_ExitStatus
                {
                    get
                    {
                        if (_offset_ExitStatus == -1)
                        {
                            _offset_ExitStatus = Offset_SessionId + 4;
                        }

                        return _offset_ExitStatus;
                    }
                }

                private int Offset_DirectoryTableBase
                {
                    get
                    {
                        if (_offset_DirectoryTableBase == -1)
                        {
                            _offset_DirectoryTableBase = Offset_ExitStatus + 4;
                        }

                        return _offset_DirectoryTableBase;
                    }
                }

                private int Offset_Flags
                {
                    get
                    {
                        if (_offset_Flags == -1)
                        {
                            _offset_Flags = Offset_DirectoryTableBase + _etwEvent.AddressSize;
                        }

                        return _offset_Flags;
                    }
                }

                private int Offset_UserSID
                {
                    get
                    {
                        if (_offset_UserSID == -1)
                        {
                            _offset_UserSID = Offset_Flags + 4;
                        }

                        return _offset_UserSID;
                    }
                }

                private int Offset_ImageFileName
                {
                    get
                    {
                        if (_offset_ImageFileName == -1)
                        {
                            _offset_ImageFileName = Offset_UserSID + _etwEvent.GetWbemSidLength(Offset_UserSID);
                        }

                        return _offset_ImageFileName;
                    }
                }

                private int Offset_CommandLine
                {
                    get
                    {
                        if (_offset_CommandLine == -1)
                        {
                            _offset_CommandLine = Offset_ImageFileName + _etwEvent.AnsiStringLength(Offset_ImageFileName);
                        }

                        return _offset_CommandLine;
                    }
                }

                private int Offset_PackageFullName
                {
                    get
                    {
                        if (_offset_PackageFullName == -1)
                        {
                            _offset_PackageFullName = Offset_CommandLine + _etwEvent.UnicodeStringLength(Offset_CommandLine);
                        }

                        return _offset_PackageFullName;
                    }
                }

                private int Offset_ApplicationId
                {
                    get
                    {
                        if (_offset_ApplicationId == -1)
                        {
                            _offset_ApplicationId = Offset_PackageFullName + _etwEvent.UnicodeStringLength(Offset_PackageFullName);
                        }

                        return _offset_ApplicationId;
                    }
                }

                /// <summary>
                /// Retrieves the UniqueProcessKey field.
                /// </summary>
                public ulong UniqueProcessKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_UniqueProcessKey..Offset_ProcessId]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_UniqueProcessKey..Offset_ProcessId]);

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..Offset_ParentId]);

                /// <summary>
                /// Retrieves the ParentId field.
                /// </summary>
                public uint ParentId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ParentId..Offset_SessionId]);

                /// <summary>
                /// Retrieves the SessionId field.
                /// </summary>
                public uint SessionId => BitConverter.ToUInt32(_etwEvent.Data[Offset_SessionId..Offset_ExitStatus]);

                /// <summary>
                /// Retrieves the ExitStatus field.
                /// </summary>
                public int ExitStatus => BitConverter.ToInt32(_etwEvent.Data[Offset_ExitStatus..Offset_DirectoryTableBase]);

                /// <summary>
                /// Retrieves the DirectoryTableBase field.
                /// </summary>
                public ulong DirectoryTableBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_DirectoryTableBase..Offset_Flags]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_DirectoryTableBase..Offset_Flags]);

                /// <summary>
                /// Retrieves the Flags field.
                /// </summary>
                public uint Flags => BitConverter.ToUInt32(_etwEvent.Data[Offset_Flags..Offset_UserSID]);

                /// <summary>
                /// Retrieves the UserSID field.
                /// </summary>
                public System.Security.Principal.SecurityIdentifier UserSID => _etwEvent.GetWbemSid(Offset_UserSID);

                /// <summary>
                /// Retrieves the ImageFileName field.
                /// </summary>
                public string ImageFileName => System.Text.Encoding.ASCII.GetString(_etwEvent.Data[Offset_ImageFileName..Offset_CommandLine]);

                /// <summary>
                /// Retrieves the CommandLine field.
                /// </summary>
                public string CommandLine => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_CommandLine..Offset_PackageFullName]);

                /// <summary>
                /// Retrieves the PackageFullName field.
                /// </summary>
                public string PackageFullName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_PackageFullName..Offset_ApplicationId]);

                /// <summary>
                /// Retrieves the ApplicationId field.
                /// </summary>
                public string ApplicationId => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ApplicationId..]);

                /// <summary>
                /// Creates a new DefunctData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DefunctData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_UniqueProcessKey = -1;
                    _offset_ProcessId = -1;
                    _offset_ParentId = -1;
                    _offset_SessionId = -1;
                    _offset_ExitStatus = -1;
                    _offset_DirectoryTableBase = -1;
                    _offset_Flags = -1;
                    _offset_UserSID = -1;
                    _offset_ImageFileName = -1;
                    _offset_CommandLine = -1;
                    _offset_PackageFullName = -1;
                    _offset_ApplicationId = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Defunct event.
        /// </summary>
        public readonly ref struct DefunctEventV5
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Defunct";

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
                Version = 5,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.Defunct,
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
            public DefunctData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DefunctEventV5.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DefunctEventV5(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a DefunctEventV5.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator DefunctEventV5(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Defunct event.
            /// </summary>
            public ref struct DefunctData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_UniqueProcessKey;
                private int _offset_ProcessId;
                private int _offset_ParentId;
                private int _offset_SessionId;
                private int _offset_ExitStatus;
                private int _offset_DirectoryTableBase;
                private int _offset_Flags;
                private int _offset_UserSID;
                private int _offset_ImageFileName;
                private int _offset_CommandLine;
                private int _offset_PackageFullName;
                private int _offset_ApplicationId;
                private int _offset_ExitTime;

                private int Offset_UniqueProcessKey
                {
                    get
                    {
                        if (_offset_UniqueProcessKey == -1)
                        {
                            _offset_UniqueProcessKey = 0;
                        }

                        return _offset_UniqueProcessKey;
                    }
                }

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = Offset_UniqueProcessKey + _etwEvent.AddressSize;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_ParentId
                {
                    get
                    {
                        if (_offset_ParentId == -1)
                        {
                            _offset_ParentId = Offset_ProcessId + 4;
                        }

                        return _offset_ParentId;
                    }
                }

                private int Offset_SessionId
                {
                    get
                    {
                        if (_offset_SessionId == -1)
                        {
                            _offset_SessionId = Offset_ParentId + 4;
                        }

                        return _offset_SessionId;
                    }
                }

                private int Offset_ExitStatus
                {
                    get
                    {
                        if (_offset_ExitStatus == -1)
                        {
                            _offset_ExitStatus = Offset_SessionId + 4;
                        }

                        return _offset_ExitStatus;
                    }
                }

                private int Offset_DirectoryTableBase
                {
                    get
                    {
                        if (_offset_DirectoryTableBase == -1)
                        {
                            _offset_DirectoryTableBase = Offset_ExitStatus + 4;
                        }

                        return _offset_DirectoryTableBase;
                    }
                }

                private int Offset_Flags
                {
                    get
                    {
                        if (_offset_Flags == -1)
                        {
                            _offset_Flags = Offset_DirectoryTableBase + _etwEvent.AddressSize;
                        }

                        return _offset_Flags;
                    }
                }

                private int Offset_UserSID
                {
                    get
                    {
                        if (_offset_UserSID == -1)
                        {
                            _offset_UserSID = Offset_Flags + 4;
                        }

                        return _offset_UserSID;
                    }
                }

                private int Offset_ImageFileName
                {
                    get
                    {
                        if (_offset_ImageFileName == -1)
                        {
                            _offset_ImageFileName = Offset_UserSID + _etwEvent.GetWbemSidLength(Offset_UserSID);
                        }

                        return _offset_ImageFileName;
                    }
                }

                private int Offset_CommandLine
                {
                    get
                    {
                        if (_offset_CommandLine == -1)
                        {
                            _offset_CommandLine = Offset_ImageFileName + _etwEvent.AnsiStringLength(Offset_ImageFileName);
                        }

                        return _offset_CommandLine;
                    }
                }

                private int Offset_PackageFullName
                {
                    get
                    {
                        if (_offset_PackageFullName == -1)
                        {
                            _offset_PackageFullName = Offset_CommandLine + _etwEvent.UnicodeStringLength(Offset_CommandLine);
                        }

                        return _offset_PackageFullName;
                    }
                }

                private int Offset_ApplicationId
                {
                    get
                    {
                        if (_offset_ApplicationId == -1)
                        {
                            _offset_ApplicationId = Offset_PackageFullName + _etwEvent.UnicodeStringLength(Offset_PackageFullName);
                        }

                        return _offset_ApplicationId;
                    }
                }

                private int Offset_ExitTime
                {
                    get
                    {
                        if (_offset_ExitTime == -1)
                        {
                            _offset_ExitTime = Offset_ApplicationId + _etwEvent.UnicodeStringLength(Offset_ApplicationId);
                        }

                        return _offset_ExitTime;
                    }
                }

                /// <summary>
                /// Retrieves the UniqueProcessKey field.
                /// </summary>
                public ulong UniqueProcessKey => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_UniqueProcessKey..Offset_ProcessId]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_UniqueProcessKey..Offset_ProcessId]);

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..Offset_ParentId]);

                /// <summary>
                /// Retrieves the ParentId field.
                /// </summary>
                public uint ParentId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ParentId..Offset_SessionId]);

                /// <summary>
                /// Retrieves the SessionId field.
                /// </summary>
                public uint SessionId => BitConverter.ToUInt32(_etwEvent.Data[Offset_SessionId..Offset_ExitStatus]);

                /// <summary>
                /// Retrieves the ExitStatus field.
                /// </summary>
                public int ExitStatus => BitConverter.ToInt32(_etwEvent.Data[Offset_ExitStatus..Offset_DirectoryTableBase]);

                /// <summary>
                /// Retrieves the DirectoryTableBase field.
                /// </summary>
                public ulong DirectoryTableBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_DirectoryTableBase..Offset_Flags]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_DirectoryTableBase..Offset_Flags]);

                /// <summary>
                /// Retrieves the Flags field.
                /// </summary>
                public uint Flags => BitConverter.ToUInt32(_etwEvent.Data[Offset_Flags..Offset_UserSID]);

                /// <summary>
                /// Retrieves the UserSID field.
                /// </summary>
                public System.Security.Principal.SecurityIdentifier UserSID => _etwEvent.GetWbemSid(Offset_UserSID);

                /// <summary>
                /// Retrieves the ImageFileName field.
                /// </summary>
                public string ImageFileName => System.Text.Encoding.ASCII.GetString(_etwEvent.Data[Offset_ImageFileName..Offset_CommandLine]);

                /// <summary>
                /// Retrieves the CommandLine field.
                /// </summary>
                public string CommandLine => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_CommandLine..Offset_PackageFullName]);

                /// <summary>
                /// Retrieves the PackageFullName field.
                /// </summary>
                public string PackageFullName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_PackageFullName..Offset_ApplicationId]);

                /// <summary>
                /// Retrieves the ApplicationId field.
                /// </summary>
                public string ApplicationId => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ApplicationId..Offset_ExitTime]);

                /// <summary>
                /// Retrieves the ExitTime field.
                /// </summary>
                public ulong ExitTime => BitConverter.ToUInt64(_etwEvent.Data[Offset_ExitTime..]);

                /// <summary>
                /// Creates a new DefunctData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DefunctData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_UniqueProcessKey = -1;
                    _offset_ProcessId = -1;
                    _offset_ParentId = -1;
                    _offset_SessionId = -1;
                    _offset_ExitStatus = -1;
                    _offset_DirectoryTableBase = -1;
                    _offset_Flags = -1;
                    _offset_UserSID = -1;
                    _offset_ImageFileName = -1;
                    _offset_CommandLine = -1;
                    _offset_PackageFullName = -1;
                    _offset_ApplicationId = -1;
                    _offset_ExitTime = -1;
                }
            }

        }
    }
}
