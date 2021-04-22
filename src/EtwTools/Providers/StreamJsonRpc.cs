using System;

#pragma warning disable CA1707 // Identifiers should not contain underscores

namespace EtwTools
{
    /// <summary>
    /// Provider for StreamJsonRpc ({f0cffe53-bcc5-53f5-8873-995568808a3b})
    /// </summary>
    public sealed class StreamJsonRpcProvider
    {
        /// <summary>
        /// Provider ID.
        /// </summary>
        public static readonly Guid Id = new("{f0cffe53-bcc5-53f5-8873-995568808a3b}");

        /// <summary>
        /// Provider name.
        /// </summary>
        public const string Name = "StreamJsonRpc";

        /// <summary>
        /// An event wrapper for a EventSourceMessage event.
        /// </summary>
        public readonly ref struct EventSourceMessageEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "EventSourceMessage";

            /// <summary>
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
                Opcode = EtwEventType.Info,
                Task = (ushort)Tasks.EventSourceMessage,
                Keyword = 0
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public EventSourceMessageData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new EventSourceMessageEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public EventSourceMessageEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a EventSourceMessage event.
            /// </summary>
            public readonly ref struct EventSourceMessageData
            {
                private readonly EtwEvent _etwEvent;

                private const int Offset_Message = 0;

                /// <summary>
                /// Retrieves the Message field.
                /// </summary>
                public string Message => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Message..]);

                /// <summary>
                /// Creates a new EventSourceMessageData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public EventSourceMessageData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a SendingNotification event.
        /// </summary>
        public readonly ref struct SendingNotificationEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SendingNotification";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 1,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Verbose,
                Opcode = EtwEventType.End,
                Task = (ushort)Tasks.Notification,
                Keyword = 0
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public SendingNotificationData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new SendingNotificationEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SendingNotificationEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a SendingNotification event.
            /// </summary>
            public readonly ref struct SendingNotificationData
            {
                private readonly EtwEvent _etwEvent;

                private const int Offset_Method = 0;
                private readonly int _offset_Args;

                /// <summary>
                /// Retrieves the Method field.
                /// </summary>
                public string Method => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Method.._offset_Args]);

                /// <summary>
                /// Retrieves the Args field.
                /// </summary>
                public string Args => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_Args..]);

                /// <summary>
                /// Creates a new SendingNotificationData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public SendingNotificationData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Args = Offset_Method + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, Offset_Method);
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ReceivedResult event.
        /// </summary>
        public readonly ref struct ReceivedResultEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ReceivedResult";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 4,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventType.Stop,
                Task = (ushort)Tasks.OutboundCall,
                Keyword = 0
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public ReceivedResultData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ReceivedResultEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ReceivedResultEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ReceivedResult event.
            /// </summary>
            public readonly ref struct ReceivedResultData
            {
                private readonly EtwEvent _etwEvent;

                private const int Offset_RequestId = 0;

                /// <summary>
                /// Retrieves the RequestId field.
                /// </summary>
                public long RequestId => BitConverter.ToInt64(_etwEvent.Data[Offset_RequestId..]);

                /// <summary>
                /// Creates a new ReceivedResultData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ReceivedResultData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ReceivedError event.
        /// </summary>
        public readonly ref struct ReceivedErrorEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ReceivedError";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 5,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Warning,
                Opcode = EtwEventType.Stop,
                Task = (ushort)Tasks.OutboundCall,
                Keyword = 0
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public ReceivedErrorData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ReceivedErrorEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ReceivedErrorEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ReceivedError event.
            /// </summary>
            public readonly ref struct ReceivedErrorData
            {
                private readonly EtwEvent _etwEvent;

                private const int Offset_RequestId = 0;
                private const int Offset_ErrorCode = 8;

                /// <summary>
                /// Retrieves the RequestId field.
                /// </summary>
                public long RequestId => BitConverter.ToInt64(_etwEvent.Data[Offset_RequestId..Offset_ErrorCode]);

                /// <summary>
                /// Retrieves the ErrorCode field.
                /// </summary>
                public JsonRpcErrorCode ErrorCode => (JsonRpcErrorCode)BitConverter.ToUInt32(_etwEvent.Data[Offset_ErrorCode..]);

                /// <summary>
                /// Creates a new ReceivedErrorData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ReceivedErrorData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ReceivedNoResponse event.
        /// </summary>
        public readonly ref struct ReceivedNoResponseEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ReceivedNoResponse";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 6,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Warning,
                Opcode = EtwEventType.Stop,
                Task = (ushort)Tasks.OutboundCall,
                Keyword = 0
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public ReceivedNoResponseData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ReceivedNoResponseEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ReceivedNoResponseEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ReceivedNoResponse event.
            /// </summary>
            public readonly ref struct ReceivedNoResponseData
            {
                private readonly EtwEvent _etwEvent;

                private const int Offset_RequestId = 0;

                /// <summary>
                /// Retrieves the RequestId field.
                /// </summary>
                public long RequestId => BitConverter.ToInt64(_etwEvent.Data[Offset_RequestId..]);

                /// <summary>
                /// Creates a new ReceivedNoResponseData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ReceivedNoResponseData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a SendingCancellationRequest event.
        /// </summary>
        public readonly ref struct SendingCancellationRequestEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SendingCancellationRequest";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 3,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventType.End,
                Task = (ushort)Tasks.Cancellation,
                Keyword = 0
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public SendingCancellationRequestData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new SendingCancellationRequestEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SendingCancellationRequestEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a SendingCancellationRequest event.
            /// </summary>
            public readonly ref struct SendingCancellationRequestData
            {
                private readonly EtwEvent _etwEvent;

                private const int Offset_RequestId = 0;

                /// <summary>
                /// Retrieves the RequestId field.
                /// </summary>
                public long RequestId => BitConverter.ToInt64(_etwEvent.Data[Offset_RequestId..]);

                /// <summary>
                /// Creates a new SendingCancellationRequestData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public SendingCancellationRequestData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ReceivedNotification event.
        /// </summary>
        public readonly ref struct ReceivedNotificationEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ReceivedNotification";

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
                Channel = 0,
                Level = EtwTraceLevel.Verbose,
                Opcode = EtwEventType.Recieve,
                Task = (ushort)Tasks.Notification,
                Keyword = 0
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public ReceivedNotificationData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ReceivedNotificationEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ReceivedNotificationEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ReceivedNotification event.
            /// </summary>
            public readonly ref struct ReceivedNotificationData
            {
                private readonly EtwEvent _etwEvent;

                private const int Offset_Method = 0;
                private readonly int _offset_Args;

                /// <summary>
                /// Retrieves the Method field.
                /// </summary>
                public string Method => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Method.._offset_Args]);

                /// <summary>
                /// Retrieves the Args field.
                /// </summary>
                public string Args => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_Args..]);

                /// <summary>
                /// Creates a new ReceivedNotificationData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ReceivedNotificationData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Args = Offset_Method + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, Offset_Method);
                }
            }

        }

        /// <summary>
        /// An event wrapper for a SendingResult event.
        /// </summary>
        public readonly ref struct SendingResultEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SendingResult";

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
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventType.Stop,
                Task = (ushort)Tasks.InboundCall,
                Keyword = 0
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public SendingResultData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new SendingResultEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SendingResultEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a SendingResult event.
            /// </summary>
            public readonly ref struct SendingResultData
            {
                private readonly EtwEvent _etwEvent;

                private const int Offset_RequestId = 0;

                /// <summary>
                /// Retrieves the RequestId field.
                /// </summary>
                public long RequestId => BitConverter.ToInt64(_etwEvent.Data[Offset_RequestId..]);

                /// <summary>
                /// Creates a new SendingResultData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public SendingResultData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a SendingError event.
        /// </summary>
        public readonly ref struct SendingErrorEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SendingError";

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
                Channel = 0,
                Level = EtwTraceLevel.Warning,
                Opcode = EtwEventType.Stop,
                Task = (ushort)Tasks.InboundCall,
                Keyword = 0
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public SendingErrorData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new SendingErrorEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SendingErrorEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a SendingError event.
            /// </summary>
            public readonly ref struct SendingErrorData
            {
                private readonly EtwEvent _etwEvent;

                private const int Offset_RequestId = 0;
                private const int Offset_ErrorCode = 8;

                /// <summary>
                /// Retrieves the RequestId field.
                /// </summary>
                public long RequestId => BitConverter.ToInt64(_etwEvent.Data[Offset_RequestId..Offset_ErrorCode]);

                /// <summary>
                /// Retrieves the ErrorCode field.
                /// </summary>
                public JsonRpcErrorCode ErrorCode => (JsonRpcErrorCode)BitConverter.ToUInt32(_etwEvent.Data[Offset_ErrorCode..]);

                /// <summary>
                /// Creates a new SendingErrorData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public SendingErrorData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ReceivedCancellationRequest event.
        /// </summary>
        public readonly ref struct ReceivedCancellationRequestEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ReceivedCancellationRequest";

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
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventType.Recieve,
                Task = (ushort)Tasks.Cancellation,
                Keyword = 0
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public ReceivedCancellationRequestData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ReceivedCancellationRequestEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ReceivedCancellationRequestEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ReceivedCancellationRequest event.
            /// </summary>
            public readonly ref struct ReceivedCancellationRequestData
            {
                private readonly EtwEvent _etwEvent;

                private const int Offset_RequestId = 0;

                /// <summary>
                /// Retrieves the RequestId field.
                /// </summary>
                public long RequestId => BitConverter.ToInt64(_etwEvent.Data[Offset_RequestId..]);

                /// <summary>
                /// Creates a new ReceivedCancellationRequestData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ReceivedCancellationRequestData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a TransmissionQueued event.
        /// </summary>
        public readonly ref struct TransmissionQueuedEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "TransmissionQueued";

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
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventType.Start,
                Task = (ushort)Tasks.MessageTransmission,
                Keyword = 0
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Creates a new TransmissionQueuedEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public TransmissionQueuedEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a TransmissionCompleted event.
        /// </summary>
        public readonly ref struct TransmissionCompletedEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "TransmissionCompleted";

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
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventType.Stop,
                Task = (ushort)Tasks.MessageTransmission,
                Keyword = 0
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Creates a new TransmissionCompletedEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public TransmissionCompletedEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a HandlerTransmitted event.
        /// </summary>
        public readonly ref struct HandlerTransmittedEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "HandlerTransmitted";

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
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventType.End,
                Task = (ushort)Tasks.MessageHandler,
                Keyword = 0
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public HandlerTransmittedData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new HandlerTransmittedEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public HandlerTransmittedEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a HandlerTransmitted event.
            /// </summary>
            public readonly ref struct HandlerTransmittedData
            {
                private readonly EtwEvent _etwEvent;

                private const int Offset_Size = 0;

                /// <summary>
                /// Retrieves the Size field.
                /// </summary>
                public long Size => BitConverter.ToInt64(_etwEvent.Data[Offset_Size..]);

                /// <summary>
                /// Creates a new HandlerTransmittedData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public HandlerTransmittedData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a HandlerReceived event.
        /// </summary>
        public readonly ref struct HandlerReceivedEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "HandlerReceived";

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
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Information,
                Opcode = EtwEventType.Recieve,
                Task = (ushort)Tasks.MessageHandler,
                Keyword = 0
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public HandlerReceivedData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new HandlerReceivedEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public HandlerReceivedEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a HandlerReceived event.
            /// </summary>
            public readonly ref struct HandlerReceivedData
            {
                private readonly EtwEvent _etwEvent;

                private const int Offset_Size = 0;

                /// <summary>
                /// Retrieves the Size field.
                /// </summary>
                public long Size => BitConverter.ToInt64(_etwEvent.Data[Offset_Size..]);

                /// <summary>
                /// Creates a new HandlerReceivedData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public HandlerReceivedData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a SendingRequest event.
        /// </summary>
        public readonly ref struct SendingRequestEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SendingRequest";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 2,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.Verbose,
                Opcode = EtwEventType.Start,
                Task = (ushort)Tasks.OutboundCall,
                Keyword = 0
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public SendingRequestData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new SendingRequestEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SendingRequestEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a SendingRequest event.
            /// </summary>
            public readonly ref struct SendingRequestData
            {
                private readonly EtwEvent _etwEvent;

                private const int Offset_RequestId = 0;
                private const int Offset_Method = 8;
                private readonly int _offset_Args;

                /// <summary>
                /// Retrieves the RequestId field.
                /// </summary>
                public long RequestId => BitConverter.ToInt64(_etwEvent.Data[Offset_RequestId..Offset_Method]);

                /// <summary>
                /// Retrieves the Method field.
                /// </summary>
                public string Method => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Method.._offset_Args]);

                /// <summary>
                /// Retrieves the Args field.
                /// </summary>
                public string Args => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_Args..]);

                /// <summary>
                /// Creates a new SendingRequestData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public SendingRequestData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Args = Offset_Method + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, Offset_Method);
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ReceivedRequest event.
        /// </summary>
        public readonly ref struct ReceivedRequestEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ReceivedRequest";

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
                Channel = 0,
                Level = EtwTraceLevel.Verbose,
                Opcode = EtwEventType.Start,
                Task = (ushort)Tasks.InboundCall,
                Keyword = 0
            };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Data for the event.
            /// </summary>
            public ReceivedRequestData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ReceivedRequestEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ReceivedRequestEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a ReceivedRequest event.
            /// </summary>
            public readonly ref struct ReceivedRequestData
            {
                private readonly EtwEvent _etwEvent;

                private const int Offset_RequestId = 0;
                private const int Offset_Method = 8;
                private readonly int _offset_Args;

                /// <summary>
                /// Retrieves the RequestId field.
                /// </summary>
                public long RequestId => BitConverter.ToInt64(_etwEvent.Data[Offset_RequestId..Offset_Method]);

                /// <summary>
                /// Retrieves the Method field.
                /// </summary>
                public string Method => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Method.._offset_Args]);

                /// <summary>
                /// Retrieves the Args field.
                /// </summary>
                public string Args => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_Args..]);

                /// <summary>
                /// Creates a new ReceivedRequestData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ReceivedRequestData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_Args = Offset_Method + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, Offset_Method);
                }
            }

        }

        /// <summary>
        /// Tasks supported by StreamJsonRpc.
        /// </summary>
        public enum Tasks : ushort
        {
            /// <summary>
            /// 'OutboundCall' task.
            /// </summary>
            OutboundCall = 1,
            /// <summary>
            /// 'InboundCall' task.
            /// </summary>
            InboundCall = 2,
            /// <summary>
            /// 'MessageTransmission' task.
            /// </summary>
            MessageTransmission = 3,
            /// <summary>
            /// 'Cancellation' task.
            /// </summary>
            Cancellation = 4,
            /// <summary>
            /// 'Notification' task.
            /// </summary>
            Notification = 5,
            /// <summary>
            /// 'MessageHandler' task.
            /// </summary>
            MessageHandler = 6,
            /// <summary>
            /// 'EventSourceMessage' task.
            /// </summary>
            EventSourceMessage = 65534,
        }

        /// <summary>
        /// Keywords supported by StreamJsonRpc.
        /// </summary>
        [Flags]
        public enum Keywords : ulong
        {
            /// <summary>
            /// 'Session3' keyword.
            /// </summary>
            Session3 = 0x0000100000000000,
            /// <summary>
            /// 'Session2' keyword.
            /// </summary>
            Session2 = 0x0000200000000000,
            /// <summary>
            /// 'Session1' keyword.
            /// </summary>
            Session1 = 0x0000400000000000,
            /// <summary>
            /// 'Session0' keyword.
            /// </summary>
            Session0 = 0x0000800000000000,
        }

        /// <summary>
        /// JsonRpcErrorCode.
        /// </summary>
        public enum JsonRpcErrorCode
        {
            /// <summary>
            /// InvocationError.
            /// </summary>
            InvocationError = -32000,
            /// <summary>
            /// NoMarshaledObjectFound.
            /// </summary>
            NoMarshaledObjectFound = -32001,
            /// <summary>
            /// ResponseSerializationFailure.
            /// </summary>
            ResponseSerializationFailure = -32003,
            /// <summary>
            /// InvocationErrorWithException.
            /// </summary>
            InvocationErrorWithException = -32004,
            /// <summary>
            /// ParseError.
            /// </summary>
            ParseError = -32700,
            /// <summary>
            /// InvalidRequest.
            /// </summary>
            InvalidRequest = -32600,
            /// <summary>
            /// MethodNotFound.
            /// </summary>
            MethodNotFound = -32601,
            /// <summary>
            /// InvalidParams.
            /// </summary>
            InvalidParams = -32602,
            /// <summary>
            /// InternalError.
            /// </summary>
            InternalError = -32603,
            /// <summary>
            /// RequestCanceled.
            /// </summary>
            RequestCanceled = -32800,
        }
    }
}
