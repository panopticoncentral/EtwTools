using System;

#pragma warning disable IDE0004 // Remove Unnecessary Cast
#pragma warning disable CA1707 // Identifiers should not contain underscores
#pragma warning disable CA1720 // Identifier contains type name

namespace EtwTools
{
    /// <summary>
    /// Provider for Kernel-PerfInfo (ce1dbfb4-137e-4da6-87b0-3f59aa102cbc)
    /// </summary>
    public sealed class KernelPerfInfoProvider
    {
        /// <summary>s
        /// Provider ID.
        /// </summary>
        public static readonly Guid Id = new("ce1dbfb4-137e-4da6-87b0-3f59aa102cbc");

        /// <summary>
        /// Provider name.
        /// </summary>
        public const string Name = "Kernel-PerfInfo";

        /// <summary>
        /// Opcodes supported by KernelPerfInfo.
        /// </summary>
        public enum Opcodes
        {
            /// <summary>
            /// 'Mark' opcode.
            /// </summary>
            Mark = 34,
            /// <summary>
            /// 'SampleProf' opcode.
            /// </summary>
            SampleProf = 46,
            /// <summary>
            /// 'PmcCounterProf' opcode.
            /// </summary>
            PmcCounterProf = 47,
            /// <summary>
            /// 'PmcCtrConfig' opcode.
            /// </summary>
            PmcCtrConfig = 48,
            /// <summary>
            /// 'ISR_MSI' opcode.
            /// </summary>
            ISR_MSI = 50,
            /// <summary>
            /// 'SysClEnter' opcode.
            /// </summary>
            SysClEnter = 51,
            /// <summary>
            /// 'SysClExit' opcode.
            /// </summary>
            SysClExit = 52,
            /// <summary>
            /// 'DebuggerEnabled' opcode.
            /// </summary>
            DebuggerEnabled = 58,
            /// <summary>
            /// 'ThreadedDPC' opcode.
            /// </summary>
            ThreadedDPC = 66,
            /// <summary>
            /// 'ISR' opcode.
            /// </summary>
            ISR = 67,
            /// <summary>
            /// 'DPC' opcode.
            /// </summary>
            DPC = 68,
            /// <summary>
            /// 'TimerDPC' opcode.
            /// </summary>
            TimerDPC = 69,
            /// <summary>
            /// 'IOTimer' opcode.
            /// </summary>
            IOTimer = 70,
            /// <summary>
            /// 'SetInterval' opcode.
            /// </summary>
            SetInterval = 72,
            /// <summary>
            /// 'SampledProfileIntervalCollectionStart' opcode.
            /// </summary>
            SampledProfileIntervalCollectionStart = 73,
            /// <summary>
            /// 'SampledProfileIntervalCollectionEnd' opcode.
            /// </summary>
            SampledProfileIntervalCollectionEnd = 74,
            /// <summary>
            /// 'SpinlockConfigureCollectionStart' opcode.
            /// </summary>
            SpinlockConfigureCollectionStart = 75,
            /// <summary>
            /// 'SpinlockConfigureCollectionEnd' opcode.
            /// </summary>
            SpinlockConfigureCollectionEnd = 76,
            /// <summary>
            /// 'ISR_Unexpected' opcode.
            /// </summary>
            ISR_Unexpected = 92,
            /// <summary>
            /// 'IoStartTimer' opcode.
            /// </summary>
            IoStartTimer = 93,
            /// <summary>
            /// 'IoStopTimer' opcode.
            /// </summary>
            IoStopTimer = 94,
            /// <summary>
            /// 'ISR_PASS' opcode.
            /// </summary>
            ISR_PASS = 95,
            /// <summary>
            /// 'WdfISR' opcode.
            /// </summary>
            WdfISR = 96,
            /// <summary>
            /// 'WdfPassiveISR' opcode.
            /// </summary>
            WdfPassiveISR = 97,
            /// <summary>
            /// 'WdfDPC' opcode.
            /// </summary>
            WdfDPC = 98,
            /// <summary>
            /// 'WdfWorkItem' opcode.
            /// </summary>
            WdfWorkItem = 103,
            /// <summary>
            /// 'SetKTimer2' opcode.
            /// </summary>
            SetKTimer2 = 104,
            /// <summary>
            /// 'ExpireKTimer2' opcode.
            /// </summary>
            ExpireKTimer2 = 105,
            /// <summary>
            /// 'CancelKTimer2' opcode.
            /// </summary>
            CancelKTimer2 = 106,
            /// <summary>
            /// 'DisableKTimer2' opcode.
            /// </summary>
            DisableKTimer2 = 107,
            /// <summary>
            /// 'FinalizeKTimer2' opcode.
            /// </summary>
            FinalizeKTimer2 = 108,
            /// <summary>
            /// 'KernelHypercall' opcode.
            /// </summary>
            KernelHypercall = 114,
        }

        /// <summary>
        /// An event wrapper for a Mark event.
        /// </summary>
        public readonly ref struct MarkEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Mark";

            /// <summary>
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
                Opcode = (EtwEventOpcode)Opcodes.Mark,
                Task = 0,
                Keyword = 0
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public MarkData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new MarkEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public MarkEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a Mark event.
            /// </summary>
            public ref struct MarkData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Message;
                private int _offset_Padding;

                private int Offset_Message
                {
                    get
                    {
                        if (_offset_Message == -1)
                        {
                            _offset_Message = 0;
                        }

                        return _offset_Message;
                    }
                }

                private int Offset_Padding
                {
                    get
                    {
                        if (_offset_Padding == -1)
                        {
                            _offset_Padding = Offset_Message + EtwEvent.AnsiStringEnumerable.AnsiStringEnumerator.StringLength(_etwEvent.Data, Offset_Message);
                        }

                        return _offset_Padding;
                    }
                }

                /// <summary>
                /// Retrieves the Message field.
                /// </summary>
                public string Message => System.Text.Encoding.ASCII.GetString(_etwEvent.Data[Offset_Message..]);

                /// <summary>
                /// Retrieves the Padding field.
                /// </summary>
                public char Padding => BitConverter.ToChar(_etwEvent.Data[Offset_Padding..]);

                /// <summary>
                /// Creates a new MarkData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public MarkData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Message = -1;
                    _offset_Padding = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a SampleProf event.
        /// </summary>
        public readonly ref struct SampleProfEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SampleProf";

            /// <summary>
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
                Opcode = (EtwEventOpcode)Opcodes.SampleProf,
                Task = 0,
                Keyword = 0
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public SampleProfData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new SampleProfEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SampleProfEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a SampleProf event.
            /// </summary>
            public ref struct SampleProfData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_InstructionPointer;
                private int _offset_ThreadId;
                private int _offset_Count;

                private int Offset_InstructionPointer
                {
                    get
                    {
                        if (_offset_InstructionPointer == -1)
                        {
                            _offset_InstructionPointer = 0;
                        }

                        return _offset_InstructionPointer;
                    }
                }

                private int Offset_ThreadId
                {
                    get
                    {
                        if (_offset_ThreadId == -1)
                        {
                            _offset_ThreadId = Offset_InstructionPointer + _etwEvent.AddressSize;
                        }

                        return _offset_ThreadId;
                    }
                }

                private int Offset_Count
                {
                    get
                    {
                        if (_offset_Count == -1)
                        {
                            _offset_Count = Offset_ThreadId + 4;
                        }

                        return _offset_Count;
                    }
                }

                /// <summary>
                /// Retrieves the InstructionPointer field.
                /// </summary>
                public ulong InstructionPointer => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_InstructionPointer..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_InstructionPointer..]);

                /// <summary>
                /// Retrieves the ThreadId field.
                /// </summary>
                public uint ThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ThreadId..]);

                /// <summary>
                /// Retrieves the Count field.
                /// </summary>
                public ushort Count => BitConverter.ToUInt16(_etwEvent.Data[Offset_Count..]);

                /// <summary>
                /// Creates a new SampleProfData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public SampleProfData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_InstructionPointer = -1;
                    _offset_ThreadId = -1;
                    _offset_Count = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DPC event.
        /// </summary>
        public readonly ref struct DPCEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DPC";

            /// <summary>
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
                Opcode = (EtwEventOpcode)Opcodes.DPC,
                Task = 0,
                Keyword = 0
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public DPCData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DPCEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DPCEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a DPC event.
            /// </summary>
            public ref struct DPCData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_InitialTime;
                private int _offset_Routine;

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

                private int Offset_Routine
                {
                    get
                    {
                        if (_offset_Routine == -1)
                        {
                            _offset_Routine = Offset_InitialTime + 8;
                        }

                        return _offset_Routine;
                    }
                }

                /// <summary>
                /// Retrieves the InitialTime field.
                /// </summary>
                public ulong InitialTime => BitConverter.ToUInt64(_etwEvent.Data[Offset_InitialTime..]);

                /// <summary>
                /// Retrieves the Routine field.
                /// </summary>
                public ulong Routine => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Routine..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Routine..]);

                /// <summary>
                /// Creates a new DPCData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DPCData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_InitialTime = -1;
                    _offset_Routine = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a TimerDPC event.
        /// </summary>
        public readonly ref struct TimerDPCEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "TimerDPC";

            /// <summary>
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
                Opcode = (EtwEventOpcode)Opcodes.TimerDPC,
                Task = 0,
                Keyword = 0
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public TimerDPCData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new TimerDPCEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public TimerDPCEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a TimerDPC event.
            /// </summary>
            public ref struct TimerDPCData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_InitialTime;
                private int _offset_Routine;

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

                private int Offset_Routine
                {
                    get
                    {
                        if (_offset_Routine == -1)
                        {
                            _offset_Routine = Offset_InitialTime + 8;
                        }

                        return _offset_Routine;
                    }
                }

                /// <summary>
                /// Retrieves the InitialTime field.
                /// </summary>
                public ulong InitialTime => BitConverter.ToUInt64(_etwEvent.Data[Offset_InitialTime..]);

                /// <summary>
                /// Retrieves the Routine field.
                /// </summary>
                public ulong Routine => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Routine..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Routine..]);

                /// <summary>
                /// Creates a new TimerDPCData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public TimerDPCData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_InitialTime = -1;
                    _offset_Routine = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ISR event.
        /// </summary>
        public readonly ref struct ISREventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ISR";

            /// <summary>
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
                Opcode = (EtwEventOpcode)Opcodes.ISR,
                Task = 0,
                Keyword = 0
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public ISRData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ISREventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ISREventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ISR event.
            /// </summary>
            public ref struct ISRData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_InitialTime;
                private int _offset_Routine;
                private int _offset_ReturnValue;

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

                private int Offset_Routine
                {
                    get
                    {
                        if (_offset_Routine == -1)
                        {
                            _offset_Routine = Offset_InitialTime + 8;
                        }

                        return _offset_Routine;
                    }
                }

                private int Offset_ReturnValue
                {
                    get
                    {
                        if (_offset_ReturnValue == -1)
                        {
                            _offset_ReturnValue = Offset_Routine + _etwEvent.AddressSize;
                        }

                        return _offset_ReturnValue;
                    }
                }

                /// <summary>
                /// Retrieves the InitialTime field.
                /// </summary>
                public ulong InitialTime => BitConverter.ToUInt64(_etwEvent.Data[Offset_InitialTime..]);

                /// <summary>
                /// Retrieves the Routine field.
                /// </summary>
                public ulong Routine => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Routine..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Routine..]);

                /// <summary>
                /// Retrieves the ReturnValue field.
                /// </summary>
                public uint ReturnValue => BitConverter.ToUInt32(_etwEvent.Data[Offset_ReturnValue..]);

                /// <summary>
                /// Creates a new ISRData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ISRData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_InitialTime = -1;
                    _offset_Routine = -1;
                    _offset_ReturnValue = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ISR-PASS event.
        /// </summary>
        public readonly ref struct ISR_PASSEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ISR-PASS";

            /// <summary>
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
                Opcode = (EtwEventOpcode)Opcodes.ISR_PASS,
                Task = 0,
                Keyword = 0
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public ISR_PASSData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ISR_PASSEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ISR_PASSEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ISR_PASS event.
            /// </summary>
            public ref struct ISR_PASSData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_InitialTime;
                private int _offset_Routine;
                private int _offset_ReturnValue;

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

                private int Offset_Routine
                {
                    get
                    {
                        if (_offset_Routine == -1)
                        {
                            _offset_Routine = Offset_InitialTime + 8;
                        }

                        return _offset_Routine;
                    }
                }

                private int Offset_ReturnValue
                {
                    get
                    {
                        if (_offset_ReturnValue == -1)
                        {
                            _offset_ReturnValue = Offset_Routine + _etwEvent.AddressSize;
                        }

                        return _offset_ReturnValue;
                    }
                }

                /// <summary>
                /// Retrieves the InitialTime field.
                /// </summary>
                public ulong InitialTime => BitConverter.ToUInt64(_etwEvent.Data[Offset_InitialTime..]);

                /// <summary>
                /// Retrieves the Routine field.
                /// </summary>
                public ulong Routine => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Routine..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Routine..]);

                /// <summary>
                /// Retrieves the ReturnValue field.
                /// </summary>
                public uint ReturnValue => BitConverter.ToUInt32(_etwEvent.Data[Offset_ReturnValue..]);

                /// <summary>
                /// Creates a new ISR_PASSData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ISR_PASSData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_InitialTime = -1;
                    _offset_Routine = -1;
                    _offset_ReturnValue = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a SampleProf event.
        /// </summary>
        public readonly ref struct SampleProfEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SampleProf";

            /// <summary>
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
                Opcode = (EtwEventOpcode)Opcodes.SampleProf,
                Task = 0,
                Keyword = 0
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public SampleProfData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new SampleProfEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SampleProfEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a SampleProf event.
            /// </summary>
            public ref struct SampleProfData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_InstructionPointer;
                private int _offset_ThreadId;
                private int _offset_Count;
                private int _offset_Reserved;

                private int Offset_InstructionPointer
                {
                    get
                    {
                        if (_offset_InstructionPointer == -1)
                        {
                            _offset_InstructionPointer = 0;
                        }

                        return _offset_InstructionPointer;
                    }
                }

                private int Offset_ThreadId
                {
                    get
                    {
                        if (_offset_ThreadId == -1)
                        {
                            _offset_ThreadId = Offset_InstructionPointer + _etwEvent.AddressSize;
                        }

                        return _offset_ThreadId;
                    }
                }

                private int Offset_Count
                {
                    get
                    {
                        if (_offset_Count == -1)
                        {
                            _offset_Count = Offset_ThreadId + 4;
                        }

                        return _offset_Count;
                    }
                }

                private int Offset_Reserved
                {
                    get
                    {
                        if (_offset_Reserved == -1)
                        {
                            _offset_Reserved = Offset_Count + 2;
                        }

                        return _offset_Reserved;
                    }
                }

                /// <summary>
                /// Retrieves the InstructionPointer field.
                /// </summary>
                public ulong InstructionPointer => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_InstructionPointer..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_InstructionPointer..]);

                /// <summary>
                /// Retrieves the ThreadId field.
                /// </summary>
                public uint ThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ThreadId..]);

                /// <summary>
                /// Retrieves the Count field.
                /// </summary>
                public ushort Count => BitConverter.ToUInt16(_etwEvent.Data[Offset_Count..]);

                /// <summary>
                /// Retrieves the Reserved field.
                /// </summary>
                public ushort Reserved => BitConverter.ToUInt16(_etwEvent.Data[Offset_Reserved..]);

                /// <summary>
                /// Creates a new SampleProfData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public SampleProfData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_InstructionPointer = -1;
                    _offset_ThreadId = -1;
                    _offset_Count = -1;
                    _offset_Reserved = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a PmcCounterProf event.
        /// </summary>
        public readonly ref struct PmcCounterProfEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "PmcCounterProf";

            /// <summary>
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
                Opcode = (EtwEventOpcode)Opcodes.PmcCounterProf,
                Task = 0,
                Keyword = 0
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public PmcCounterProfData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new PmcCounterProfEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public PmcCounterProfEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a PmcCounterProf event.
            /// </summary>
            public ref struct PmcCounterProfData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_InstructionPointer;
                private int _offset_ThreadId;
                private int _offset_ProfileSource;
                private int _offset_Reserved;

                private int Offset_InstructionPointer
                {
                    get
                    {
                        if (_offset_InstructionPointer == -1)
                        {
                            _offset_InstructionPointer = 0;
                        }

                        return _offset_InstructionPointer;
                    }
                }

                private int Offset_ThreadId
                {
                    get
                    {
                        if (_offset_ThreadId == -1)
                        {
                            _offset_ThreadId = Offset_InstructionPointer + _etwEvent.AddressSize;
                        }

                        return _offset_ThreadId;
                    }
                }

                private int Offset_ProfileSource
                {
                    get
                    {
                        if (_offset_ProfileSource == -1)
                        {
                            _offset_ProfileSource = Offset_ThreadId + 4;
                        }

                        return _offset_ProfileSource;
                    }
                }

                private int Offset_Reserved
                {
                    get
                    {
                        if (_offset_Reserved == -1)
                        {
                            _offset_Reserved = Offset_ProfileSource + 2;
                        }

                        return _offset_Reserved;
                    }
                }

                /// <summary>
                /// Retrieves the InstructionPointer field.
                /// </summary>
                public ulong InstructionPointer => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_InstructionPointer..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_InstructionPointer..]);

                /// <summary>
                /// Retrieves the ThreadId field.
                /// </summary>
                public uint ThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ThreadId..]);

                /// <summary>
                /// Retrieves the ProfileSource field.
                /// </summary>
                public ushort ProfileSource => BitConverter.ToUInt16(_etwEvent.Data[Offset_ProfileSource..]);

                /// <summary>
                /// Retrieves the Reserved field.
                /// </summary>
                public ushort Reserved => BitConverter.ToUInt16(_etwEvent.Data[Offset_Reserved..]);

                /// <summary>
                /// Creates a new PmcCounterProfData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public PmcCounterProfData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_InstructionPointer = -1;
                    _offset_ThreadId = -1;
                    _offset_ProfileSource = -1;
                    _offset_Reserved = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a SetInterval event.
        /// </summary>
        public readonly ref struct SetIntervalEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SetInterval";

            /// <summary>
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
                Opcode = (EtwEventOpcode)Opcodes.SetInterval,
                Task = 0,
                Keyword = 0
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public SetIntervalData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new SetIntervalEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SetIntervalEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a SetInterval event.
            /// </summary>
            public ref struct SetIntervalData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Source;
                private int _offset_NewInterval;
                private int _offset_OldInterval;

                private int Offset_Source
                {
                    get
                    {
                        if (_offset_Source == -1)
                        {
                            _offset_Source = 0;
                        }

                        return _offset_Source;
                    }
                }

                private int Offset_NewInterval
                {
                    get
                    {
                        if (_offset_NewInterval == -1)
                        {
                            _offset_NewInterval = Offset_Source + 4;
                        }

                        return _offset_NewInterval;
                    }
                }

                private int Offset_OldInterval
                {
                    get
                    {
                        if (_offset_OldInterval == -1)
                        {
                            _offset_OldInterval = Offset_NewInterval + 4;
                        }

                        return _offset_OldInterval;
                    }
                }

                /// <summary>
                /// Retrieves the Source field.
                /// </summary>
                public uint Source => BitConverter.ToUInt32(_etwEvent.Data[Offset_Source..]);

                /// <summary>
                /// Retrieves the NewInterval field.
                /// </summary>
                public uint NewInterval => BitConverter.ToUInt32(_etwEvent.Data[Offset_NewInterval..]);

                /// <summary>
                /// Retrieves the OldInterval field.
                /// </summary>
                public uint OldInterval => BitConverter.ToUInt32(_etwEvent.Data[Offset_OldInterval..]);

                /// <summary>
                /// Creates a new SetIntervalData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public SetIntervalData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Source = -1;
                    _offset_NewInterval = -1;
                    _offset_OldInterval = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a SampledProfileIntervalCollectionStart event.
        /// </summary>
        public readonly ref struct SampledProfileIntervalCollectionStartEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SampledProfileIntervalCollectionStart";

            /// <summary>
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
                Opcode = (EtwEventOpcode)Opcodes.SampledProfileIntervalCollectionStart,
                Task = 0,
                Keyword = 0
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public SampledProfileIntervalCollectionStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new SampledProfileIntervalCollectionStartEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SampledProfileIntervalCollectionStartEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a SampledProfileIntervalCollectionStart event.
            /// </summary>
            public ref struct SampledProfileIntervalCollectionStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Source;
                private int _offset_NewInterval;
                private int _offset_OldInterval;

                private int Offset_Source
                {
                    get
                    {
                        if (_offset_Source == -1)
                        {
                            _offset_Source = 0;
                        }

                        return _offset_Source;
                    }
                }

                private int Offset_NewInterval
                {
                    get
                    {
                        if (_offset_NewInterval == -1)
                        {
                            _offset_NewInterval = Offset_Source + 4;
                        }

                        return _offset_NewInterval;
                    }
                }

                private int Offset_OldInterval
                {
                    get
                    {
                        if (_offset_OldInterval == -1)
                        {
                            _offset_OldInterval = Offset_NewInterval + 4;
                        }

                        return _offset_OldInterval;
                    }
                }

                /// <summary>
                /// Retrieves the Source field.
                /// </summary>
                public uint Source => BitConverter.ToUInt32(_etwEvent.Data[Offset_Source..]);

                /// <summary>
                /// Retrieves the NewInterval field.
                /// </summary>
                public uint NewInterval => BitConverter.ToUInt32(_etwEvent.Data[Offset_NewInterval..]);

                /// <summary>
                /// Retrieves the OldInterval field.
                /// </summary>
                public uint OldInterval => BitConverter.ToUInt32(_etwEvent.Data[Offset_OldInterval..]);

                /// <summary>
                /// Creates a new SampledProfileIntervalCollectionStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public SampledProfileIntervalCollectionStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Source = -1;
                    _offset_NewInterval = -1;
                    _offset_OldInterval = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a SampledProfileIntervalCollectionEnd event.
        /// </summary>
        public readonly ref struct SampledProfileIntervalCollectionEndEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SampledProfileIntervalCollectionEnd";

            /// <summary>
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
                Opcode = (EtwEventOpcode)Opcodes.SampledProfileIntervalCollectionEnd,
                Task = 0,
                Keyword = 0
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public SampledProfileIntervalCollectionEndData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new SampledProfileIntervalCollectionEndEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SampledProfileIntervalCollectionEndEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a SampledProfileIntervalCollectionEnd event.
            /// </summary>
            public ref struct SampledProfileIntervalCollectionEndData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Source;
                private int _offset_NewInterval;
                private int _offset_OldInterval;

                private int Offset_Source
                {
                    get
                    {
                        if (_offset_Source == -1)
                        {
                            _offset_Source = 0;
                        }

                        return _offset_Source;
                    }
                }

                private int Offset_NewInterval
                {
                    get
                    {
                        if (_offset_NewInterval == -1)
                        {
                            _offset_NewInterval = Offset_Source + 4;
                        }

                        return _offset_NewInterval;
                    }
                }

                private int Offset_OldInterval
                {
                    get
                    {
                        if (_offset_OldInterval == -1)
                        {
                            _offset_OldInterval = Offset_NewInterval + 4;
                        }

                        return _offset_OldInterval;
                    }
                }

                /// <summary>
                /// Retrieves the Source field.
                /// </summary>
                public uint Source => BitConverter.ToUInt32(_etwEvent.Data[Offset_Source..]);

                /// <summary>
                /// Retrieves the NewInterval field.
                /// </summary>
                public uint NewInterval => BitConverter.ToUInt32(_etwEvent.Data[Offset_NewInterval..]);

                /// <summary>
                /// Retrieves the OldInterval field.
                /// </summary>
                public uint OldInterval => BitConverter.ToUInt32(_etwEvent.Data[Offset_OldInterval..]);

                /// <summary>
                /// Creates a new SampledProfileIntervalCollectionEndData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public SampledProfileIntervalCollectionEndData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Source = -1;
                    _offset_NewInterval = -1;
                    _offset_OldInterval = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a PmcCtrConfig event.
        /// </summary>
        public readonly ref struct PmcCtrConfigEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "PmcCtrConfig";

            /// <summary>
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
                Opcode = (EtwEventOpcode)Opcodes.PmcCtrConfig,
                Task = 0,
                Keyword = 0
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public PmcCtrConfigData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new PmcCtrConfigEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public PmcCtrConfigEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a PmcCtrConfig event.
            /// </summary>
            public ref struct PmcCtrConfigData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_CounterCount;
                private int _offset_CounterName;

                private int Offset_CounterCount
                {
                    get
                    {
                        if (_offset_CounterCount == -1)
                        {
                            _offset_CounterCount = 0;
                        }

                        return _offset_CounterCount;
                    }
                }

                private int Offset_CounterName
                {
                    get
                    {
                        if (_offset_CounterName == -1)
                        {
                            _offset_CounterName = Offset_CounterCount + 4;
                        }

                        return _offset_CounterName;
                    }
                }

                /// <summary>
                /// Retrieves the CounterCount field.
                /// </summary>
                public uint CounterCount => BitConverter.ToUInt32(_etwEvent.Data[Offset_CounterCount..]);

                /// <summary>
                /// Retrieves the CounterName field.
                /// </summary>
                public EtwEvent.UnicodeStringEnumerable CounterName => new(_etwEvent, Offset_CounterName, CounterCount);

                /// <summary>
                /// Creates a new PmcCtrConfigData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public PmcCtrConfigData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_CounterCount = -1;
                    _offset_CounterName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a SpinlockConfigureCollectionStart event.
        /// </summary>
        public readonly ref struct SpinlockConfigureCollectionStartEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SpinlockConfigureCollectionStart";

            /// <summary>
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
                Opcode = (EtwEventOpcode)Opcodes.SpinlockConfigureCollectionStart,
                Task = 0,
                Keyword = 0
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public SpinlockConfigureCollectionStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new SpinlockConfigureCollectionStartEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SpinlockConfigureCollectionStartEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a SpinlockConfigureCollectionStart event.
            /// </summary>
            public ref struct SpinlockConfigureCollectionStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_SpinLockSpinThreshold;
                private int _offset_SpinLockContentionSampleRate;
                private int _offset_SpinLockAcquireSampleRate;

                private int Offset_SpinLockSpinThreshold
                {
                    get
                    {
                        if (_offset_SpinLockSpinThreshold == -1)
                        {
                            _offset_SpinLockSpinThreshold = 0;
                        }

                        return _offset_SpinLockSpinThreshold;
                    }
                }

                private int Offset_SpinLockContentionSampleRate
                {
                    get
                    {
                        if (_offset_SpinLockContentionSampleRate == -1)
                        {
                            _offset_SpinLockContentionSampleRate = Offset_SpinLockSpinThreshold + 4;
                        }

                        return _offset_SpinLockContentionSampleRate;
                    }
                }

                private int Offset_SpinLockAcquireSampleRate
                {
                    get
                    {
                        if (_offset_SpinLockAcquireSampleRate == -1)
                        {
                            _offset_SpinLockAcquireSampleRate = Offset_SpinLockContentionSampleRate + 4;
                        }

                        return _offset_SpinLockAcquireSampleRate;
                    }
                }

                /// <summary>
                /// Retrieves the SpinLockSpinThreshold field.
                /// </summary>
                public uint SpinLockSpinThreshold => BitConverter.ToUInt32(_etwEvent.Data[Offset_SpinLockSpinThreshold..]);

                /// <summary>
                /// Retrieves the SpinLockContentionSampleRate field.
                /// </summary>
                public uint SpinLockContentionSampleRate => BitConverter.ToUInt32(_etwEvent.Data[Offset_SpinLockContentionSampleRate..]);

                /// <summary>
                /// Retrieves the SpinLockAcquireSampleRate field.
                /// </summary>
                public uint SpinLockAcquireSampleRate => BitConverter.ToUInt32(_etwEvent.Data[Offset_SpinLockAcquireSampleRate..]);

                /// <summary>
                /// Creates a new SpinlockConfigureCollectionStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public SpinlockConfigureCollectionStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_SpinLockSpinThreshold = -1;
                    _offset_SpinLockContentionSampleRate = -1;
                    _offset_SpinLockAcquireSampleRate = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a SpinlockConfigureCollectionEnd event.
        /// </summary>
        public readonly ref struct SpinlockConfigureCollectionEndEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SpinlockConfigureCollectionEnd";

            /// <summary>
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
                Opcode = (EtwEventOpcode)Opcodes.SpinlockConfigureCollectionEnd,
                Task = 0,
                Keyword = 0
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public SpinlockConfigureCollectionEndData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new SpinlockConfigureCollectionEndEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SpinlockConfigureCollectionEndEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a SpinlockConfigureCollectionEnd event.
            /// </summary>
            public ref struct SpinlockConfigureCollectionEndData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_SpinLockSpinThreshold;
                private int _offset_SpinLockContentionSampleRate;
                private int _offset_SpinLockAcquireSampleRate;

                private int Offset_SpinLockSpinThreshold
                {
                    get
                    {
                        if (_offset_SpinLockSpinThreshold == -1)
                        {
                            _offset_SpinLockSpinThreshold = 0;
                        }

                        return _offset_SpinLockSpinThreshold;
                    }
                }

                private int Offset_SpinLockContentionSampleRate
                {
                    get
                    {
                        if (_offset_SpinLockContentionSampleRate == -1)
                        {
                            _offset_SpinLockContentionSampleRate = Offset_SpinLockSpinThreshold + 4;
                        }

                        return _offset_SpinLockContentionSampleRate;
                    }
                }

                private int Offset_SpinLockAcquireSampleRate
                {
                    get
                    {
                        if (_offset_SpinLockAcquireSampleRate == -1)
                        {
                            _offset_SpinLockAcquireSampleRate = Offset_SpinLockContentionSampleRate + 4;
                        }

                        return _offset_SpinLockAcquireSampleRate;
                    }
                }

                /// <summary>
                /// Retrieves the SpinLockSpinThreshold field.
                /// </summary>
                public uint SpinLockSpinThreshold => BitConverter.ToUInt32(_etwEvent.Data[Offset_SpinLockSpinThreshold..]);

                /// <summary>
                /// Retrieves the SpinLockContentionSampleRate field.
                /// </summary>
                public uint SpinLockContentionSampleRate => BitConverter.ToUInt32(_etwEvent.Data[Offset_SpinLockContentionSampleRate..]);

                /// <summary>
                /// Retrieves the SpinLockAcquireSampleRate field.
                /// </summary>
                public uint SpinLockAcquireSampleRate => BitConverter.ToUInt32(_etwEvent.Data[Offset_SpinLockAcquireSampleRate..]);

                /// <summary>
                /// Creates a new SpinlockConfigureCollectionEndData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public SpinlockConfigureCollectionEndData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_SpinLockSpinThreshold = -1;
                    _offset_SpinLockContentionSampleRate = -1;
                    _offset_SpinLockAcquireSampleRate = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a SysClEnter event.
        /// </summary>
        public readonly ref struct SysClEnterEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SysClEnter";

            /// <summary>
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
                Opcode = (EtwEventOpcode)Opcodes.SysClEnter,
                Task = 0,
                Keyword = 0
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public SysClEnterData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new SysClEnterEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SysClEnterEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a SysClEnter event.
            /// </summary>
            public ref struct SysClEnterData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_SysCallAddress;

                private int Offset_SysCallAddress
                {
                    get
                    {
                        if (_offset_SysCallAddress == -1)
                        {
                            _offset_SysCallAddress = 0;
                        }

                        return _offset_SysCallAddress;
                    }
                }

                /// <summary>
                /// Retrieves the SysCallAddress field.
                /// </summary>
                public ulong SysCallAddress => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_SysCallAddress..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_SysCallAddress..]);

                /// <summary>
                /// Creates a new SysClEnterData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public SysClEnterData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_SysCallAddress = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a SysClExit event.
        /// </summary>
        public readonly ref struct SysClExitEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SysClExit";

            /// <summary>
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
                Opcode = (EtwEventOpcode)Opcodes.SysClExit,
                Task = 0,
                Keyword = 0
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public SysClExitData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new SysClExitEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SysClExitEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a SysClExit event.
            /// </summary>
            public ref struct SysClExitData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_SysCallNtStatus;

                private int Offset_SysCallNtStatus
                {
                    get
                    {
                        if (_offset_SysCallNtStatus == -1)
                        {
                            _offset_SysCallNtStatus = 0;
                        }

                        return _offset_SysCallNtStatus;
                    }
                }

                /// <summary>
                /// Retrieves the SysCallNtStatus field.
                /// </summary>
                public uint SysCallNtStatus => BitConverter.ToUInt32(_etwEvent.Data[Offset_SysCallNtStatus..]);

                /// <summary>
                /// Creates a new SysClExitData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public SysClExitData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_SysCallNtStatus = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ISR event.
        /// </summary>
        public readonly ref struct ISREventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ISR";

            /// <summary>
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
                Opcode = (EtwEventOpcode)Opcodes.ISR,
                Task = 0,
                Keyword = 0
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public ISRData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ISREventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ISREventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ISR event.
            /// </summary>
            public ref struct ISRData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_InitialTime;
                private int _offset_Routine;
                private int _offset_ReturnValue;
                private int _offset_Vector;
                private int _offset_Reserved;

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

                private int Offset_Routine
                {
                    get
                    {
                        if (_offset_Routine == -1)
                        {
                            _offset_Routine = Offset_InitialTime + 8;
                        }

                        return _offset_Routine;
                    }
                }

                private int Offset_ReturnValue
                {
                    get
                    {
                        if (_offset_ReturnValue == -1)
                        {
                            _offset_ReturnValue = Offset_Routine + _etwEvent.AddressSize;
                        }

                        return _offset_ReturnValue;
                    }
                }

                private int Offset_Vector
                {
                    get
                    {
                        if (_offset_Vector == -1)
                        {
                            _offset_Vector = Offset_ReturnValue + 1;
                        }

                        return _offset_Vector;
                    }
                }

                private int Offset_Reserved
                {
                    get
                    {
                        if (_offset_Reserved == -1)
                        {
                            _offset_Reserved = Offset_Vector + 2;
                        }

                        return _offset_Reserved;
                    }
                }

                /// <summary>
                /// Retrieves the InitialTime field.
                /// </summary>
                public ulong InitialTime => BitConverter.ToUInt64(_etwEvent.Data[Offset_InitialTime..]);

                /// <summary>
                /// Retrieves the Routine field.
                /// </summary>
                public ulong Routine => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Routine..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Routine..]);

                /// <summary>
                /// Retrieves the ReturnValue field.
                /// </summary>
                public byte ReturnValue => _etwEvent.Data[Offset_ReturnValue];

                /// <summary>
                /// Retrieves the Vector field.
                /// </summary>
                public ushort Vector => BitConverter.ToUInt16(_etwEvent.Data[Offset_Vector..]);

                /// <summary>
                /// Retrieves the Reserved field.
                /// </summary>
                public byte Reserved => _etwEvent.Data[Offset_Reserved];

                /// <summary>
                /// Creates a new ISRData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ISRData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_InitialTime = -1;
                    _offset_Routine = -1;
                    _offset_ReturnValue = -1;
                    _offset_Vector = -1;
                    _offset_Reserved = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ISR-PASS event.
        /// </summary>
        public readonly ref struct ISR_PASSEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ISR-PASS";

            /// <summary>
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
                Opcode = (EtwEventOpcode)Opcodes.ISR_PASS,
                Task = 0,
                Keyword = 0
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public ISR_PASSData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ISR_PASSEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ISR_PASSEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ISR_PASS event.
            /// </summary>
            public ref struct ISR_PASSData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_InitialTime;
                private int _offset_Routine;
                private int _offset_ReturnValue;
                private int _offset_Vector;
                private int _offset_Reserved;

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

                private int Offset_Routine
                {
                    get
                    {
                        if (_offset_Routine == -1)
                        {
                            _offset_Routine = Offset_InitialTime + 8;
                        }

                        return _offset_Routine;
                    }
                }

                private int Offset_ReturnValue
                {
                    get
                    {
                        if (_offset_ReturnValue == -1)
                        {
                            _offset_ReturnValue = Offset_Routine + _etwEvent.AddressSize;
                        }

                        return _offset_ReturnValue;
                    }
                }

                private int Offset_Vector
                {
                    get
                    {
                        if (_offset_Vector == -1)
                        {
                            _offset_Vector = Offset_ReturnValue + 1;
                        }

                        return _offset_Vector;
                    }
                }

                private int Offset_Reserved
                {
                    get
                    {
                        if (_offset_Reserved == -1)
                        {
                            _offset_Reserved = Offset_Vector + 2;
                        }

                        return _offset_Reserved;
                    }
                }

                /// <summary>
                /// Retrieves the InitialTime field.
                /// </summary>
                public ulong InitialTime => BitConverter.ToUInt64(_etwEvent.Data[Offset_InitialTime..]);

                /// <summary>
                /// Retrieves the Routine field.
                /// </summary>
                public ulong Routine => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Routine..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Routine..]);

                /// <summary>
                /// Retrieves the ReturnValue field.
                /// </summary>
                public byte ReturnValue => _etwEvent.Data[Offset_ReturnValue];

                /// <summary>
                /// Retrieves the Vector field.
                /// </summary>
                public ushort Vector => BitConverter.ToUInt16(_etwEvent.Data[Offset_Vector..]);

                /// <summary>
                /// Retrieves the Reserved field.
                /// </summary>
                public byte Reserved => _etwEvent.Data[Offset_Reserved];

                /// <summary>
                /// Creates a new ISR_PASSData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ISR_PASSData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_InitialTime = -1;
                    _offset_Routine = -1;
                    _offset_ReturnValue = -1;
                    _offset_Vector = -1;
                    _offset_Reserved = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ISR-MSI event.
        /// </summary>
        public readonly ref struct ISR_MSIEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ISR-MSI";

            /// <summary>
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
                Opcode = (EtwEventOpcode)Opcodes.ISR_MSI,
                Task = 0,
                Keyword = 0
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public ISR_MSIData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ISR_MSIEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ISR_MSIEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ISR_MSI event.
            /// </summary>
            public ref struct ISR_MSIData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_InitialTime;
                private int _offset_Routine;
                private int _offset_ReturnValue;
                private int _offset_Vector;
                private int _offset_Reserved;
                private int _offset_MessageNumber;

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

                private int Offset_Routine
                {
                    get
                    {
                        if (_offset_Routine == -1)
                        {
                            _offset_Routine = Offset_InitialTime + 8;
                        }

                        return _offset_Routine;
                    }
                }

                private int Offset_ReturnValue
                {
                    get
                    {
                        if (_offset_ReturnValue == -1)
                        {
                            _offset_ReturnValue = Offset_Routine + _etwEvent.AddressSize;
                        }

                        return _offset_ReturnValue;
                    }
                }

                private int Offset_Vector
                {
                    get
                    {
                        if (_offset_Vector == -1)
                        {
                            _offset_Vector = Offset_ReturnValue + 1;
                        }

                        return _offset_Vector;
                    }
                }

                private int Offset_Reserved
                {
                    get
                    {
                        if (_offset_Reserved == -1)
                        {
                            _offset_Reserved = Offset_Vector + 2;
                        }

                        return _offset_Reserved;
                    }
                }

                private int Offset_MessageNumber
                {
                    get
                    {
                        if (_offset_MessageNumber == -1)
                        {
                            _offset_MessageNumber = Offset_Reserved + 1;
                        }

                        return _offset_MessageNumber;
                    }
                }

                /// <summary>
                /// Retrieves the InitialTime field.
                /// </summary>
                public ulong InitialTime => BitConverter.ToUInt64(_etwEvent.Data[Offset_InitialTime..]);

                /// <summary>
                /// Retrieves the Routine field.
                /// </summary>
                public ulong Routine => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Routine..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Routine..]);

                /// <summary>
                /// Retrieves the ReturnValue field.
                /// </summary>
                public byte ReturnValue => _etwEvent.Data[Offset_ReturnValue];

                /// <summary>
                /// Retrieves the Vector field.
                /// </summary>
                public ushort Vector => BitConverter.ToUInt16(_etwEvent.Data[Offset_Vector..]);

                /// <summary>
                /// Retrieves the Reserved field.
                /// </summary>
                public byte Reserved => _etwEvent.Data[Offset_Reserved];

                /// <summary>
                /// Retrieves the MessageNumber field.
                /// </summary>
                public uint MessageNumber => BitConverter.ToUInt32(_etwEvent.Data[Offset_MessageNumber..]);

                /// <summary>
                /// Creates a new ISR_MSIData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ISR_MSIData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_InitialTime = -1;
                    _offset_Routine = -1;
                    _offset_ReturnValue = -1;
                    _offset_Vector = -1;
                    _offset_Reserved = -1;
                    _offset_MessageNumber = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ISR-Unexpected event.
        /// </summary>
        public readonly ref struct ISR_UnexpectedEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ISR-Unexpected";

            /// <summary>
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
                Opcode = (EtwEventOpcode)Opcodes.ISR_Unexpected,
                Task = 0,
                Keyword = 0
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public ISR_UnexpectedData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ISR_UnexpectedEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ISR_UnexpectedEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ISR_Unexpected event.
            /// </summary>
            public ref struct ISR_UnexpectedData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Vector;

                private int Offset_Vector
                {
                    get
                    {
                        if (_offset_Vector == -1)
                        {
                            _offset_Vector = 0;
                        }

                        return _offset_Vector;
                    }
                }

                /// <summary>
                /// Retrieves the Vector field.
                /// </summary>
                public ushort Vector => BitConverter.ToUInt16(_etwEvent.Data[Offset_Vector..]);

                /// <summary>
                /// Creates a new ISR_UnexpectedData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ISR_UnexpectedData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Vector = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ThreadedDPC event.
        /// </summary>
        public readonly ref struct ThreadedDPCEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ThreadedDPC";

            /// <summary>
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
                Opcode = (EtwEventOpcode)Opcodes.ThreadedDPC,
                Task = 0,
                Keyword = 0
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public ThreadedDPCData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ThreadedDPCEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ThreadedDPCEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ThreadedDPC event.
            /// </summary>
            public ref struct ThreadedDPCData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_InitialTime;
                private int _offset_Routine;

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

                private int Offset_Routine
                {
                    get
                    {
                        if (_offset_Routine == -1)
                        {
                            _offset_Routine = Offset_InitialTime + 8;
                        }

                        return _offset_Routine;
                    }
                }

                /// <summary>
                /// Retrieves the InitialTime field.
                /// </summary>
                public ulong InitialTime => BitConverter.ToUInt64(_etwEvent.Data[Offset_InitialTime..]);

                /// <summary>
                /// Retrieves the Routine field.
                /// </summary>
                public ulong Routine => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Routine..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Routine..]);

                /// <summary>
                /// Creates a new ThreadedDPCData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ThreadedDPCData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_InitialTime = -1;
                    _offset_Routine = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DPC event.
        /// </summary>
        public readonly ref struct DPCEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DPC";

            /// <summary>
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
                Opcode = (EtwEventOpcode)Opcodes.DPC,
                Task = 0,
                Keyword = 0
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public DPCData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DPCEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DPCEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a DPC event.
            /// </summary>
            public ref struct DPCData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_InitialTime;
                private int _offset_Routine;

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

                private int Offset_Routine
                {
                    get
                    {
                        if (_offset_Routine == -1)
                        {
                            _offset_Routine = Offset_InitialTime + 8;
                        }

                        return _offset_Routine;
                    }
                }

                /// <summary>
                /// Retrieves the InitialTime field.
                /// </summary>
                public ulong InitialTime => BitConverter.ToUInt64(_etwEvent.Data[Offset_InitialTime..]);

                /// <summary>
                /// Retrieves the Routine field.
                /// </summary>
                public ulong Routine => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Routine..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Routine..]);

                /// <summary>
                /// Creates a new DPCData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DPCData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_InitialTime = -1;
                    _offset_Routine = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a TimerDPC event.
        /// </summary>
        public readonly ref struct TimerDPCEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "TimerDPC";

            /// <summary>
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
                Opcode = (EtwEventOpcode)Opcodes.TimerDPC,
                Task = 0,
                Keyword = 0
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public TimerDPCData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new TimerDPCEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public TimerDPCEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a TimerDPC event.
            /// </summary>
            public ref struct TimerDPCData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_InitialTime;
                private int _offset_Routine;

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

                private int Offset_Routine
                {
                    get
                    {
                        if (_offset_Routine == -1)
                        {
                            _offset_Routine = Offset_InitialTime + 8;
                        }

                        return _offset_Routine;
                    }
                }

                /// <summary>
                /// Retrieves the InitialTime field.
                /// </summary>
                public ulong InitialTime => BitConverter.ToUInt64(_etwEvent.Data[Offset_InitialTime..]);

                /// <summary>
                /// Retrieves the Routine field.
                /// </summary>
                public ulong Routine => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Routine..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Routine..]);

                /// <summary>
                /// Creates a new TimerDPCData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public TimerDPCData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_InitialTime = -1;
                    _offset_Routine = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a IOTimer event.
        /// </summary>
        public readonly ref struct IOTimerEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "IOTimer";

            /// <summary>
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
                Opcode = (EtwEventOpcode)Opcodes.IOTimer,
                Task = 0,
                Keyword = 0
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public IOTimerData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new IOTimerEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public IOTimerEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a IOTimer event.
            /// </summary>
            public ref struct IOTimerData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_InitialTime;
                private int _offset_Routine;

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

                private int Offset_Routine
                {
                    get
                    {
                        if (_offset_Routine == -1)
                        {
                            _offset_Routine = Offset_InitialTime + 8;
                        }

                        return _offset_Routine;
                    }
                }

                /// <summary>
                /// Retrieves the InitialTime field.
                /// </summary>
                public ulong InitialTime => BitConverter.ToUInt64(_etwEvent.Data[Offset_InitialTime..]);

                /// <summary>
                /// Retrieves the Routine field.
                /// </summary>
                public ulong Routine => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Routine..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Routine..]);

                /// <summary>
                /// Creates a new IOTimerData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public IOTimerData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_InitialTime = -1;
                    _offset_Routine = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a WdfDPC event.
        /// </summary>
        public readonly ref struct WdfDPCEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "WdfDPC";

            /// <summary>
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
                Opcode = (EtwEventOpcode)Opcodes.WdfDPC,
                Task = 0,
                Keyword = 0
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public WdfDPCData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new WdfDPCEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public WdfDPCEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a WdfDPC event.
            /// </summary>
            public ref struct WdfDPCData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Routine;

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

                /// <summary>
                /// Retrieves the Routine field.
                /// </summary>
                public ulong Routine => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Routine..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Routine..]);

                /// <summary>
                /// Creates a new WdfDPCData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public WdfDPCData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Routine = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a WdfISR event.
        /// </summary>
        public readonly ref struct WdfISREventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "WdfISR";

            /// <summary>
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
                Opcode = (EtwEventOpcode)Opcodes.WdfISR,
                Task = 0,
                Keyword = 0
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public WdfISRData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new WdfISREventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public WdfISREventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a WdfISR event.
            /// </summary>
            public ref struct WdfISRData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Routine;

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

                /// <summary>
                /// Retrieves the Routine field.
                /// </summary>
                public ulong Routine => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Routine..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Routine..]);

                /// <summary>
                /// Creates a new WdfISRData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public WdfISRData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Routine = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a WdfPassiveISR event.
        /// </summary>
        public readonly ref struct WdfPassiveISREventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "WdfPassiveISR";

            /// <summary>
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
                Opcode = (EtwEventOpcode)Opcodes.WdfPassiveISR,
                Task = 0,
                Keyword = 0
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public WdfPassiveISRData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new WdfPassiveISREventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public WdfPassiveISREventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a WdfPassiveISR event.
            /// </summary>
            public ref struct WdfPassiveISRData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Routine;

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

                /// <summary>
                /// Retrieves the Routine field.
                /// </summary>
                public ulong Routine => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Routine..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Routine..]);

                /// <summary>
                /// Creates a new WdfPassiveISRData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public WdfPassiveISRData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Routine = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a WdfWorkItem event.
        /// </summary>
        public readonly ref struct WdfWorkItemEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "WdfWorkItem";

            /// <summary>
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
                Opcode = (EtwEventOpcode)Opcodes.WdfWorkItem,
                Task = 0,
                Keyword = 0
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public WdfWorkItemData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new WdfWorkItemEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public WdfWorkItemEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a WdfWorkItem event.
            /// </summary>
            public ref struct WdfWorkItemData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Routine;

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

                /// <summary>
                /// Retrieves the Routine field.
                /// </summary>
                public ulong Routine => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Routine..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Routine..]);

                /// <summary>
                /// Creates a new WdfWorkItemData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public WdfWorkItemData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Routine = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DebuggerEnabled event.
        /// </summary>
        public readonly ref struct DebuggerEnabledEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DebuggerEnabled";

            /// <summary>
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
                Opcode = (EtwEventOpcode)Opcodes.DebuggerEnabled,
                Task = 0,
                Keyword = 0
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Creates a new DebuggerEnabledEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DebuggerEnabledEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a IoStartTimer event.
        /// </summary>
        public readonly ref struct IoStartTimerEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "IoStartTimer";

            /// <summary>
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
                Opcode = (EtwEventOpcode)Opcodes.IoStartTimer,
                Task = 0,
                Keyword = 0
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public IoStartTimerData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new IoStartTimerEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public IoStartTimerEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a IoStartTimer event.
            /// </summary>
            public ref struct IoStartTimerData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_DeviceObject;
                private int _offset_TimerRoutine;

                private int Offset_DeviceObject
                {
                    get
                    {
                        if (_offset_DeviceObject == -1)
                        {
                            _offset_DeviceObject = 0;
                        }

                        return _offset_DeviceObject;
                    }
                }

                private int Offset_TimerRoutine
                {
                    get
                    {
                        if (_offset_TimerRoutine == -1)
                        {
                            _offset_TimerRoutine = Offset_DeviceObject + _etwEvent.AddressSize;
                        }

                        return _offset_TimerRoutine;
                    }
                }

                /// <summary>
                /// Retrieves the DeviceObject field.
                /// </summary>
                public ulong DeviceObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_DeviceObject..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_DeviceObject..]);

                /// <summary>
                /// Retrieves the TimerRoutine field.
                /// </summary>
                public ulong TimerRoutine => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_TimerRoutine..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_TimerRoutine..]);

                /// <summary>
                /// Creates a new IoStartTimerData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public IoStartTimerData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_DeviceObject = -1;
                    _offset_TimerRoutine = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a IoStopTimer event.
        /// </summary>
        public readonly ref struct IoStopTimerEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "IoStopTimer";

            /// <summary>
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
                Opcode = (EtwEventOpcode)Opcodes.IoStopTimer,
                Task = 0,
                Keyword = 0
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public IoStopTimerData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new IoStopTimerEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public IoStopTimerEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a IoStopTimer event.
            /// </summary>
            public ref struct IoStopTimerData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_DeviceObject;
                private int _offset_TimerRoutine;

                private int Offset_DeviceObject
                {
                    get
                    {
                        if (_offset_DeviceObject == -1)
                        {
                            _offset_DeviceObject = 0;
                        }

                        return _offset_DeviceObject;
                    }
                }

                private int Offset_TimerRoutine
                {
                    get
                    {
                        if (_offset_TimerRoutine == -1)
                        {
                            _offset_TimerRoutine = Offset_DeviceObject + _etwEvent.AddressSize;
                        }

                        return _offset_TimerRoutine;
                    }
                }

                /// <summary>
                /// Retrieves the DeviceObject field.
                /// </summary>
                public ulong DeviceObject => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_DeviceObject..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_DeviceObject..]);

                /// <summary>
                /// Retrieves the TimerRoutine field.
                /// </summary>
                public ulong TimerRoutine => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_TimerRoutine..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_TimerRoutine..]);

                /// <summary>
                /// Creates a new IoStopTimerData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public IoStopTimerData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_DeviceObject = -1;
                    _offset_TimerRoutine = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a SetKTimer2 event.
        /// </summary>
        public readonly ref struct SetKTimer2EventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SetKTimer2";

            /// <summary>
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
                Opcode = (EtwEventOpcode)Opcodes.SetKTimer2,
                Task = 0,
                Keyword = 0
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public SetKTimer2Data Data => new(_etwEvent);

            /// <summary>
            /// Creates a new SetKTimer2EventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SetKTimer2EventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a SetKTimer2 event.
            /// </summary>
            public ref struct SetKTimer2Data
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_DueTime;
                private int _offset_MaximumDueTime;
                private int _offset_Period;
                private int _offset_Timer;
                private int _offset_Callback;
                private int _offset_CallbackContext;
                private int _offset_TimerFlags;

                private int Offset_DueTime
                {
                    get
                    {
                        if (_offset_DueTime == -1)
                        {
                            _offset_DueTime = 0;
                        }

                        return _offset_DueTime;
                    }
                }

                private int Offset_MaximumDueTime
                {
                    get
                    {
                        if (_offset_MaximumDueTime == -1)
                        {
                            _offset_MaximumDueTime = Offset_DueTime + 8;
                        }

                        return _offset_MaximumDueTime;
                    }
                }

                private int Offset_Period
                {
                    get
                    {
                        if (_offset_Period == -1)
                        {
                            _offset_Period = Offset_MaximumDueTime + 8;
                        }

                        return _offset_Period;
                    }
                }

                private int Offset_Timer
                {
                    get
                    {
                        if (_offset_Timer == -1)
                        {
                            _offset_Timer = Offset_Period + 8;
                        }

                        return _offset_Timer;
                    }
                }

                private int Offset_Callback
                {
                    get
                    {
                        if (_offset_Callback == -1)
                        {
                            _offset_Callback = Offset_Timer + _etwEvent.AddressSize;
                        }

                        return _offset_Callback;
                    }
                }

                private int Offset_CallbackContext
                {
                    get
                    {
                        if (_offset_CallbackContext == -1)
                        {
                            _offset_CallbackContext = Offset_Callback + _etwEvent.AddressSize;
                        }

                        return _offset_CallbackContext;
                    }
                }

                private int Offset_TimerFlags
                {
                    get
                    {
                        if (_offset_TimerFlags == -1)
                        {
                            _offset_TimerFlags = Offset_CallbackContext + _etwEvent.AddressSize;
                        }

                        return _offset_TimerFlags;
                    }
                }

                /// <summary>
                /// Retrieves the DueTime field.
                /// </summary>
                public ulong DueTime => BitConverter.ToUInt64(_etwEvent.Data[Offset_DueTime..]);

                /// <summary>
                /// Retrieves the MaximumDueTime field.
                /// </summary>
                public ulong MaximumDueTime => BitConverter.ToUInt64(_etwEvent.Data[Offset_MaximumDueTime..]);

                /// <summary>
                /// Retrieves the Period field.
                /// </summary>
                public ulong Period => BitConverter.ToUInt64(_etwEvent.Data[Offset_Period..]);

                /// <summary>
                /// Retrieves the Timer field.
                /// </summary>
                public ulong Timer => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Timer..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Timer..]);

                /// <summary>
                /// Retrieves the Callback field.
                /// </summary>
                public ulong Callback => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Callback..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Callback..]);

                /// <summary>
                /// Retrieves the CallbackContext field.
                /// </summary>
                public ulong CallbackContext => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_CallbackContext..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_CallbackContext..]);

                /// <summary>
                /// Retrieves the TimerFlags field.
                /// </summary>
                public byte TimerFlags => _etwEvent.Data[Offset_TimerFlags];

                /// <summary>
                /// Creates a new SetKTimer2Data.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public SetKTimer2Data(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_DueTime = -1;
                    _offset_MaximumDueTime = -1;
                    _offset_Period = -1;
                    _offset_Timer = -1;
                    _offset_Callback = -1;
                    _offset_CallbackContext = -1;
                    _offset_TimerFlags = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ExpireKTimer2 event.
        /// </summary>
        public readonly ref struct ExpireKTimer2EventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ExpireKTimer2";

            /// <summary>
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
                Opcode = (EtwEventOpcode)Opcodes.ExpireKTimer2,
                Task = 0,
                Keyword = 0
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public ExpireKTimer2Data Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ExpireKTimer2EventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ExpireKTimer2EventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ExpireKTimer2 event.
            /// </summary>
            public ref struct ExpireKTimer2Data
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_DueTime;
                private int _offset_MaximumDueTime;
                private int _offset_Period;
                private int _offset_Timer;
                private int _offset_Callback;
                private int _offset_CallbackContext;
                private int _offset_TimerFlags;

                private int Offset_DueTime
                {
                    get
                    {
                        if (_offset_DueTime == -1)
                        {
                            _offset_DueTime = 0;
                        }

                        return _offset_DueTime;
                    }
                }

                private int Offset_MaximumDueTime
                {
                    get
                    {
                        if (_offset_MaximumDueTime == -1)
                        {
                            _offset_MaximumDueTime = Offset_DueTime + 8;
                        }

                        return _offset_MaximumDueTime;
                    }
                }

                private int Offset_Period
                {
                    get
                    {
                        if (_offset_Period == -1)
                        {
                            _offset_Period = Offset_MaximumDueTime + 8;
                        }

                        return _offset_Period;
                    }
                }

                private int Offset_Timer
                {
                    get
                    {
                        if (_offset_Timer == -1)
                        {
                            _offset_Timer = Offset_Period + 8;
                        }

                        return _offset_Timer;
                    }
                }

                private int Offset_Callback
                {
                    get
                    {
                        if (_offset_Callback == -1)
                        {
                            _offset_Callback = Offset_Timer + _etwEvent.AddressSize;
                        }

                        return _offset_Callback;
                    }
                }

                private int Offset_CallbackContext
                {
                    get
                    {
                        if (_offset_CallbackContext == -1)
                        {
                            _offset_CallbackContext = Offset_Callback + _etwEvent.AddressSize;
                        }

                        return _offset_CallbackContext;
                    }
                }

                private int Offset_TimerFlags
                {
                    get
                    {
                        if (_offset_TimerFlags == -1)
                        {
                            _offset_TimerFlags = Offset_CallbackContext + _etwEvent.AddressSize;
                        }

                        return _offset_TimerFlags;
                    }
                }

                /// <summary>
                /// Retrieves the DueTime field.
                /// </summary>
                public ulong DueTime => BitConverter.ToUInt64(_etwEvent.Data[Offset_DueTime..]);

                /// <summary>
                /// Retrieves the MaximumDueTime field.
                /// </summary>
                public ulong MaximumDueTime => BitConverter.ToUInt64(_etwEvent.Data[Offset_MaximumDueTime..]);

                /// <summary>
                /// Retrieves the Period field.
                /// </summary>
                public ulong Period => BitConverter.ToUInt64(_etwEvent.Data[Offset_Period..]);

                /// <summary>
                /// Retrieves the Timer field.
                /// </summary>
                public ulong Timer => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Timer..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Timer..]);

                /// <summary>
                /// Retrieves the Callback field.
                /// </summary>
                public ulong Callback => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Callback..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Callback..]);

                /// <summary>
                /// Retrieves the CallbackContext field.
                /// </summary>
                public ulong CallbackContext => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_CallbackContext..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_CallbackContext..]);

                /// <summary>
                /// Retrieves the TimerFlags field.
                /// </summary>
                public byte TimerFlags => _etwEvent.Data[Offset_TimerFlags];

                /// <summary>
                /// Creates a new ExpireKTimer2Data.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ExpireKTimer2Data(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_DueTime = -1;
                    _offset_MaximumDueTime = -1;
                    _offset_Period = -1;
                    _offset_Timer = -1;
                    _offset_Callback = -1;
                    _offset_CallbackContext = -1;
                    _offset_TimerFlags = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a CancelKTimer2 event.
        /// </summary>
        public readonly ref struct CancelKTimer2EventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "CancelKTimer2";

            /// <summary>
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
                Opcode = (EtwEventOpcode)Opcodes.CancelKTimer2,
                Task = 0,
                Keyword = 0
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public CancelKTimer2Data Data => new(_etwEvent);

            /// <summary>
            /// Creates a new CancelKTimer2EventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public CancelKTimer2EventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a CancelKTimer2 event.
            /// </summary>
            public ref struct CancelKTimer2Data
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Timer;

                private int Offset_Timer
                {
                    get
                    {
                        if (_offset_Timer == -1)
                        {
                            _offset_Timer = 0;
                        }

                        return _offset_Timer;
                    }
                }

                /// <summary>
                /// Retrieves the Timer field.
                /// </summary>
                public ulong Timer => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Timer..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Timer..]);

                /// <summary>
                /// Creates a new CancelKTimer2Data.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public CancelKTimer2Data(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Timer = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DisableKTimer2 event.
        /// </summary>
        public readonly ref struct DisableKTimer2EventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DisableKTimer2";

            /// <summary>
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
                Opcode = (EtwEventOpcode)Opcodes.DisableKTimer2,
                Task = 0,
                Keyword = 0
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public DisableKTimer2Data Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DisableKTimer2EventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DisableKTimer2EventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a DisableKTimer2 event.
            /// </summary>
            public ref struct DisableKTimer2Data
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Timer;
                private int _offset_DisableCallback;
                private int _offset_DisableContext;
                private int _offset_TimerFlags;

                private int Offset_Timer
                {
                    get
                    {
                        if (_offset_Timer == -1)
                        {
                            _offset_Timer = 0;
                        }

                        return _offset_Timer;
                    }
                }

                private int Offset_DisableCallback
                {
                    get
                    {
                        if (_offset_DisableCallback == -1)
                        {
                            _offset_DisableCallback = Offset_Timer + _etwEvent.AddressSize;
                        }

                        return _offset_DisableCallback;
                    }
                }

                private int Offset_DisableContext
                {
                    get
                    {
                        if (_offset_DisableContext == -1)
                        {
                            _offset_DisableContext = Offset_DisableCallback + _etwEvent.AddressSize;
                        }

                        return _offset_DisableContext;
                    }
                }

                private int Offset_TimerFlags
                {
                    get
                    {
                        if (_offset_TimerFlags == -1)
                        {
                            _offset_TimerFlags = Offset_DisableContext + _etwEvent.AddressSize;
                        }

                        return _offset_TimerFlags;
                    }
                }

                /// <summary>
                /// Retrieves the Timer field.
                /// </summary>
                public ulong Timer => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Timer..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Timer..]);

                /// <summary>
                /// Retrieves the DisableCallback field.
                /// </summary>
                public ulong DisableCallback => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_DisableCallback..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_DisableCallback..]);

                /// <summary>
                /// Retrieves the DisableContext field.
                /// </summary>
                public ulong DisableContext => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_DisableContext..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_DisableContext..]);

                /// <summary>
                /// Retrieves the TimerFlags field.
                /// </summary>
                public byte TimerFlags => _etwEvent.Data[Offset_TimerFlags];

                /// <summary>
                /// Creates a new DisableKTimer2Data.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DisableKTimer2Data(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Timer = -1;
                    _offset_DisableCallback = -1;
                    _offset_DisableContext = -1;
                    _offset_TimerFlags = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a FinalizeKTimer2 event.
        /// </summary>
        public readonly ref struct FinalizeKTimer2EventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "FinalizeKTimer2";

            /// <summary>
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
                Opcode = (EtwEventOpcode)Opcodes.FinalizeKTimer2,
                Task = 0,
                Keyword = 0
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public FinalizeKTimer2Data Data => new(_etwEvent);

            /// <summary>
            /// Creates a new FinalizeKTimer2EventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public FinalizeKTimer2EventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a FinalizeKTimer2 event.
            /// </summary>
            public ref struct FinalizeKTimer2Data
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Timer;
                private int _offset_DisableCallback;
                private int _offset_DisableContext;

                private int Offset_Timer
                {
                    get
                    {
                        if (_offset_Timer == -1)
                        {
                            _offset_Timer = 0;
                        }

                        return _offset_Timer;
                    }
                }

                private int Offset_DisableCallback
                {
                    get
                    {
                        if (_offset_DisableCallback == -1)
                        {
                            _offset_DisableCallback = Offset_Timer + _etwEvent.AddressSize;
                        }

                        return _offset_DisableCallback;
                    }
                }

                private int Offset_DisableContext
                {
                    get
                    {
                        if (_offset_DisableContext == -1)
                        {
                            _offset_DisableContext = Offset_DisableCallback + _etwEvent.AddressSize;
                        }

                        return _offset_DisableContext;
                    }
                }

                /// <summary>
                /// Retrieves the Timer field.
                /// </summary>
                public ulong Timer => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Timer..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Timer..]);

                /// <summary>
                /// Retrieves the DisableCallback field.
                /// </summary>
                public ulong DisableCallback => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_DisableCallback..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_DisableCallback..]);

                /// <summary>
                /// Retrieves the DisableContext field.
                /// </summary>
                public ulong DisableContext => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_DisableContext..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_DisableContext..]);

                /// <summary>
                /// Creates a new FinalizeKTimer2Data.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public FinalizeKTimer2Data(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Timer = -1;
                    _offset_DisableCallback = -1;
                    _offset_DisableContext = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a KernelHypercall event.
        /// </summary>
        public readonly ref struct KernelHypercallEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "KernelHypercall";

            /// <summary>
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
                Opcode = (EtwEventOpcode)Opcodes.KernelHypercall,
                Task = 0,
                Keyword = 0
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public KernelHypercallData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new KernelHypercallEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public KernelHypercallEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a KernelHypercall event.
            /// </summary>
            public ref struct KernelHypercallData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_CallCode;
                private int _offset_IsFast;
                private int _offset_IsNested;

                private int Offset_CallCode
                {
                    get
                    {
                        if (_offset_CallCode == -1)
                        {
                            _offset_CallCode = 0;
                        }

                        return _offset_CallCode;
                    }
                }

                private int Offset_IsFast
                {
                    get
                    {
                        if (_offset_IsFast == -1)
                        {
                            _offset_IsFast = Offset_CallCode + 4;
                        }

                        return _offset_IsFast;
                    }
                }

                private int Offset_IsNested
                {
                    get
                    {
                        if (_offset_IsNested == -1)
                        {
                            _offset_IsNested = Offset_IsFast + 1;
                        }

                        return _offset_IsNested;
                    }
                }

                /// <summary>
                /// Retrieves the CallCode field.
                /// </summary>
                public uint CallCode => BitConverter.ToUInt32(_etwEvent.Data[Offset_CallCode..]);

                /// <summary>
                /// Retrieves the IsFast field.
                /// </summary>
                public byte IsFast => _etwEvent.Data[Offset_IsFast];

                /// <summary>
                /// Retrieves the IsNested field.
                /// </summary>
                public byte IsNested => _etwEvent.Data[Offset_IsNested];

                /// <summary>
                /// Creates a new KernelHypercallData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public KernelHypercallData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_CallCode = -1;
                    _offset_IsFast = -1;
                    _offset_IsNested = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a SampledProfileIntervalCollectionStart event.
        /// </summary>
        public readonly ref struct SampledProfileIntervalCollectionStartEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SampledProfileIntervalCollectionStart";

            /// <summary>
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
                Opcode = (EtwEventOpcode)Opcodes.SampledProfileIntervalCollectionStart,
                Task = 0,
                Keyword = 0
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public SampledProfileIntervalCollectionStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new SampledProfileIntervalCollectionStartEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SampledProfileIntervalCollectionStartEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a SampledProfileIntervalCollectionStart event.
            /// </summary>
            public ref struct SampledProfileIntervalCollectionStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Source;
                private int _offset_NewInterval;
                private int _offset_OldInterval;
                private int _offset_SourceName;

                private int Offset_Source
                {
                    get
                    {
                        if (_offset_Source == -1)
                        {
                            _offset_Source = 0;
                        }

                        return _offset_Source;
                    }
                }

                private int Offset_NewInterval
                {
                    get
                    {
                        if (_offset_NewInterval == -1)
                        {
                            _offset_NewInterval = Offset_Source + 4;
                        }

                        return _offset_NewInterval;
                    }
                }

                private int Offset_OldInterval
                {
                    get
                    {
                        if (_offset_OldInterval == -1)
                        {
                            _offset_OldInterval = Offset_NewInterval + 4;
                        }

                        return _offset_OldInterval;
                    }
                }

                private int Offset_SourceName
                {
                    get
                    {
                        if (_offset_SourceName == -1)
                        {
                            _offset_SourceName = Offset_OldInterval + 4;
                        }

                        return _offset_SourceName;
                    }
                }

                /// <summary>
                /// Retrieves the Source field.
                /// </summary>
                public uint Source => BitConverter.ToUInt32(_etwEvent.Data[Offset_Source..]);

                /// <summary>
                /// Retrieves the NewInterval field.
                /// </summary>
                public uint NewInterval => BitConverter.ToUInt32(_etwEvent.Data[Offset_NewInterval..]);

                /// <summary>
                /// Retrieves the OldInterval field.
                /// </summary>
                public uint OldInterval => BitConverter.ToUInt32(_etwEvent.Data[Offset_OldInterval..]);

                /// <summary>
                /// Retrieves the SourceName field.
                /// </summary>
                public string SourceName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_SourceName..]);

                /// <summary>
                /// Creates a new SampledProfileIntervalCollectionStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public SampledProfileIntervalCollectionStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Source = -1;
                    _offset_NewInterval = -1;
                    _offset_OldInterval = -1;
                    _offset_SourceName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a SampledProfileIntervalCollectionEnd event.
        /// </summary>
        public readonly ref struct SampledProfileIntervalCollectionEndEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SampledProfileIntervalCollectionEnd";

            /// <summary>
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
                Opcode = (EtwEventOpcode)Opcodes.SampledProfileIntervalCollectionEnd,
                Task = 0,
                Keyword = 0
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public SampledProfileIntervalCollectionEndData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new SampledProfileIntervalCollectionEndEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SampledProfileIntervalCollectionEndEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a SampledProfileIntervalCollectionEnd event.
            /// </summary>
            public ref struct SampledProfileIntervalCollectionEndData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_Source;
                private int _offset_NewInterval;
                private int _offset_OldInterval;
                private int _offset_SourceName;

                private int Offset_Source
                {
                    get
                    {
                        if (_offset_Source == -1)
                        {
                            _offset_Source = 0;
                        }

                        return _offset_Source;
                    }
                }

                private int Offset_NewInterval
                {
                    get
                    {
                        if (_offset_NewInterval == -1)
                        {
                            _offset_NewInterval = Offset_Source + 4;
                        }

                        return _offset_NewInterval;
                    }
                }

                private int Offset_OldInterval
                {
                    get
                    {
                        if (_offset_OldInterval == -1)
                        {
                            _offset_OldInterval = Offset_NewInterval + 4;
                        }

                        return _offset_OldInterval;
                    }
                }

                private int Offset_SourceName
                {
                    get
                    {
                        if (_offset_SourceName == -1)
                        {
                            _offset_SourceName = Offset_OldInterval + 4;
                        }

                        return _offset_SourceName;
                    }
                }

                /// <summary>
                /// Retrieves the Source field.
                /// </summary>
                public uint Source => BitConverter.ToUInt32(_etwEvent.Data[Offset_Source..]);

                /// <summary>
                /// Retrieves the NewInterval field.
                /// </summary>
                public uint NewInterval => BitConverter.ToUInt32(_etwEvent.Data[Offset_NewInterval..]);

                /// <summary>
                /// Retrieves the OldInterval field.
                /// </summary>
                public uint OldInterval => BitConverter.ToUInt32(_etwEvent.Data[Offset_OldInterval..]);

                /// <summary>
                /// Retrieves the SourceName field.
                /// </summary>
                public string SourceName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_SourceName..]);

                /// <summary>
                /// Creates a new SampledProfileIntervalCollectionEndData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public SampledProfileIntervalCollectionEndData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Source = -1;
                    _offset_NewInterval = -1;
                    _offset_OldInterval = -1;
                    _offset_SourceName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a SpinlockConfigureCollectionStart event.
        /// </summary>
        public readonly ref struct SpinlockConfigureCollectionStartEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SpinlockConfigureCollectionStart";

            /// <summary>
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
                Opcode = (EtwEventOpcode)Opcodes.SpinlockConfigureCollectionStart,
                Task = 0,
                Keyword = 0
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public SpinlockConfigureCollectionStartData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new SpinlockConfigureCollectionStartEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SpinlockConfigureCollectionStartEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a SpinlockConfigureCollectionStart event.
            /// </summary>
            public ref struct SpinlockConfigureCollectionStartData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_SpinLockSpinThreshold;
                private int _offset_SpinLockContentionSampleRate;
                private int _offset_SpinLockAcquireSampleRate;
                private int _offset_SpinLockHoldThreshold;

                private int Offset_SpinLockSpinThreshold
                {
                    get
                    {
                        if (_offset_SpinLockSpinThreshold == -1)
                        {
                            _offset_SpinLockSpinThreshold = 0;
                        }

                        return _offset_SpinLockSpinThreshold;
                    }
                }

                private int Offset_SpinLockContentionSampleRate
                {
                    get
                    {
                        if (_offset_SpinLockContentionSampleRate == -1)
                        {
                            _offset_SpinLockContentionSampleRate = Offset_SpinLockSpinThreshold + 4;
                        }

                        return _offset_SpinLockContentionSampleRate;
                    }
                }

                private int Offset_SpinLockAcquireSampleRate
                {
                    get
                    {
                        if (_offset_SpinLockAcquireSampleRate == -1)
                        {
                            _offset_SpinLockAcquireSampleRate = Offset_SpinLockContentionSampleRate + 4;
                        }

                        return _offset_SpinLockAcquireSampleRate;
                    }
                }

                private int Offset_SpinLockHoldThreshold
                {
                    get
                    {
                        if (_offset_SpinLockHoldThreshold == -1)
                        {
                            _offset_SpinLockHoldThreshold = Offset_SpinLockAcquireSampleRate + 4;
                        }

                        return _offset_SpinLockHoldThreshold;
                    }
                }

                /// <summary>
                /// Retrieves the SpinLockSpinThreshold field.
                /// </summary>
                public uint SpinLockSpinThreshold => BitConverter.ToUInt32(_etwEvent.Data[Offset_SpinLockSpinThreshold..]);

                /// <summary>
                /// Retrieves the SpinLockContentionSampleRate field.
                /// </summary>
                public uint SpinLockContentionSampleRate => BitConverter.ToUInt32(_etwEvent.Data[Offset_SpinLockContentionSampleRate..]);

                /// <summary>
                /// Retrieves the SpinLockAcquireSampleRate field.
                /// </summary>
                public uint SpinLockAcquireSampleRate => BitConverter.ToUInt32(_etwEvent.Data[Offset_SpinLockAcquireSampleRate..]);

                /// <summary>
                /// Retrieves the SpinLockHoldThreshold field.
                /// </summary>
                public uint SpinLockHoldThreshold => BitConverter.ToUInt32(_etwEvent.Data[Offset_SpinLockHoldThreshold..]);

                /// <summary>
                /// Creates a new SpinlockConfigureCollectionStartData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public SpinlockConfigureCollectionStartData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_SpinLockSpinThreshold = -1;
                    _offset_SpinLockContentionSampleRate = -1;
                    _offset_SpinLockAcquireSampleRate = -1;
                    _offset_SpinLockHoldThreshold = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a SpinlockConfigureCollectionEnd event.
        /// </summary>
        public readonly ref struct SpinlockConfigureCollectionEndEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SpinlockConfigureCollectionEnd";

            /// <summary>
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
                Opcode = (EtwEventOpcode)Opcodes.SpinlockConfigureCollectionEnd,
                Task = 0,
                Keyword = 0
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public SpinlockConfigureCollectionEndData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new SpinlockConfigureCollectionEndEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SpinlockConfigureCollectionEndEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a SpinlockConfigureCollectionEnd event.
            /// </summary>
            public ref struct SpinlockConfigureCollectionEndData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_SpinLockSpinThreshold;
                private int _offset_SpinLockContentionSampleRate;
                private int _offset_SpinLockAcquireSampleRate;
                private int _offset_SpinLockHoldThreshold;

                private int Offset_SpinLockSpinThreshold
                {
                    get
                    {
                        if (_offset_SpinLockSpinThreshold == -1)
                        {
                            _offset_SpinLockSpinThreshold = 0;
                        }

                        return _offset_SpinLockSpinThreshold;
                    }
                }

                private int Offset_SpinLockContentionSampleRate
                {
                    get
                    {
                        if (_offset_SpinLockContentionSampleRate == -1)
                        {
                            _offset_SpinLockContentionSampleRate = Offset_SpinLockSpinThreshold + 4;
                        }

                        return _offset_SpinLockContentionSampleRate;
                    }
                }

                private int Offset_SpinLockAcquireSampleRate
                {
                    get
                    {
                        if (_offset_SpinLockAcquireSampleRate == -1)
                        {
                            _offset_SpinLockAcquireSampleRate = Offset_SpinLockContentionSampleRate + 4;
                        }

                        return _offset_SpinLockAcquireSampleRate;
                    }
                }

                private int Offset_SpinLockHoldThreshold
                {
                    get
                    {
                        if (_offset_SpinLockHoldThreshold == -1)
                        {
                            _offset_SpinLockHoldThreshold = Offset_SpinLockAcquireSampleRate + 4;
                        }

                        return _offset_SpinLockHoldThreshold;
                    }
                }

                /// <summary>
                /// Retrieves the SpinLockSpinThreshold field.
                /// </summary>
                public uint SpinLockSpinThreshold => BitConverter.ToUInt32(_etwEvent.Data[Offset_SpinLockSpinThreshold..]);

                /// <summary>
                /// Retrieves the SpinLockContentionSampleRate field.
                /// </summary>
                public uint SpinLockContentionSampleRate => BitConverter.ToUInt32(_etwEvent.Data[Offset_SpinLockContentionSampleRate..]);

                /// <summary>
                /// Retrieves the SpinLockAcquireSampleRate field.
                /// </summary>
                public uint SpinLockAcquireSampleRate => BitConverter.ToUInt32(_etwEvent.Data[Offset_SpinLockAcquireSampleRate..]);

                /// <summary>
                /// Retrieves the SpinLockHoldThreshold field.
                /// </summary>
                public uint SpinLockHoldThreshold => BitConverter.ToUInt32(_etwEvent.Data[Offset_SpinLockHoldThreshold..]);

                /// <summary>
                /// Creates a new SpinlockConfigureCollectionEndData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public SpinlockConfigureCollectionEndData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_SpinLockSpinThreshold = -1;
                    _offset_SpinLockContentionSampleRate = -1;
                    _offset_SpinLockAcquireSampleRate = -1;
                    _offset_SpinLockHoldThreshold = -1;
                }
            }

        }
    }
}
