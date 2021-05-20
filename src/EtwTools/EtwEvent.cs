using System;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security.Principal;
using System.Text;

namespace EtwTools
{
    /// <summary>
    /// An ETW event.
    /// </summary>
    public readonly unsafe ref struct EtwEvent
    {
        private readonly Native.EventRecord* _eventRecord;

        /// <summary>
        /// The process the event was recorded in.
        /// </summary>
        public uint ProcessId => _eventRecord->EventHeader.ProcessId;

        /// <summary>
        /// The thread the event was recorded on.
        /// </summary>
        public uint ThreadId => _eventRecord->EventHeader.ThreadId;

        /// <summary>
        /// The timestamp of the event.
        /// </summary>
        public long Timestamp => _eventRecord->EventHeader.TimeStamp;

        /// <summary>
        /// The event provider.
        /// </summary>
        public Guid Provider => _eventRecord->EventHeader.ProviderId;

        /// <summary>
        /// Event descriptor.
        /// </summary>
        public EtwEventDescriptor Descriptor => _eventRecord->EventHeader.EventDescriptor;

        /// <summary>
        /// Timing information for the event.
        /// </summary>
        public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time =>
            (
                (_eventRecord->EventHeader.Flags & (Native.EventHeaderFlags.PrivateSession | Native.EventHeaderFlags.NoCpuTime)) == 0 ? _eventRecord->EventHeader.KernelTime : null,
                (_eventRecord->EventHeader.Flags & (Native.EventHeaderFlags.PrivateSession | Native.EventHeaderFlags.NoCpuTime)) == 0 ? _eventRecord->EventHeader.UserTime : null,
                (_eventRecord->EventHeader.Flags & (Native.EventHeaderFlags.PrivateSession | Native.EventHeaderFlags.NoCpuTime)) != 0 ? (_eventRecord->EventHeader.KernelTime & (_eventRecord->EventHeader.UserTime << sizeof(uint))) : null
            );

        /// <summary>
        /// The processor number the event was recorded on.
        /// </summary>
        public byte ProcessorNumber => _eventRecord->BufferContext.ProcessorNumber;

        /// <summary>
        /// The event data.
        /// </summary>
        public Span<byte> Data => _eventRecord->UserData;

        /// <summary>
        /// The address size for the event.
        /// </summary>
        public int AddressSize => (_eventRecord->EventHeader.Flags & Native.EventHeaderFlags.x64Header) != 0 ? 8 : 4;

        internal EtwEvent(Native.EventRecord* eventRecord) : this()
        {
            _eventRecord = eventRecord;
        }

        /// <summary>
        /// Returns the known name of the event.
        /// </summary>
        /// <returns>The known name, or null otherwise.</returns>
        public static string GetKnownEventName(Guid providerId, EtwEventDescriptor descriptor) => EtwProvider.s_knownProviders.TryGetValue(providerId, out var knownProvider) && knownProvider.Events != null && knownProvider.Events.TryGetValue(descriptor, out var knownEvent) ? knownEvent : null;

        private bool TryGetExtendedData(Native.EventHeaderExtendedType type, out Native.EventHeaderExtendedDataItem extendedData)
        {
            foreach (var item in _eventRecord->ExtendedData)
            {
                if (item.ExtType == type)
                {
                    extendedData = item;
                    return true;
                }
            }

            extendedData = default;
            return false;
        }

        /// <summary>
        /// Gets the ID of the related activity, if any.
        /// </summary>
        /// <param name="relatedActivityId">The related activity ID.</param>
        /// <returns>Whether a value was returned.</returns>
        public bool TryGetRelatedActivityId(out Guid relatedActivityId)
        {
            if (!TryGetExtendedData(Native.EventHeaderExtendedType.RelatedActivityId, out var item))
            {
                relatedActivityId = default;
                return false;
            }

            relatedActivityId = *(Guid*)item.DataPtr;
            return true;
        }

        /// <summary>
        /// Gets the SID of the user emitting the event, if any.
        /// </summary>
        /// <param name="securityIdentifier">The SID.</param>
        /// <returns>Whether a value was returned.</returns>
        [SupportedOSPlatform("windows")]
        public bool TryGetSecurityIdentifier(out SecurityIdentifier securityIdentifier)
        {
            if (!TryGetExtendedData(Native.EventHeaderExtendedType.Sid, out var item))
            {
                securityIdentifier = default;
                return false;
            }

            securityIdentifier = new SecurityIdentifier((nint)item.DataPtr);
            return true;
        }

        /// <summary>
        /// Gets the terminal service ID the event occurred in, if any.
        /// </summary>
        /// <param name="tsId">The terminal service ID.</param>
        /// <returns>Whether a value was returned.</returns>
        public bool TryGetTsId(out uint tsId)
        {
            if (!TryGetExtendedData(Native.EventHeaderExtendedType.TsId, out var item))
            {
                tsId = default;
                return false;
            }

            tsId = *(uint*)item.DataPtr;
            return true;
        }

        /// <summary>
        /// Gets the instance information for the event, if any.
        /// </summary>
        /// <param name="instanceInformation">The instance information.</param>
        /// <returns>Whether a value was returned.</returns>
        public bool TryGetInstanceInformation(out InstanceInformation instanceInformation)
        {
            if (!TryGetExtendedData(Native.EventHeaderExtendedType.InstanceInfo, out var item))
            {
                instanceInformation = default;
                return false;
            }

            instanceInformation = *(InstanceInformation*)item.DataPtr;
            return true;
        }

        /// <summary>
        /// Gets the stack trace for the event, if any.
        /// </summary>
        /// <typeparam name="T">The size of the addresses on the stack.</typeparam>
        /// <param name="stackTrace">The stack trace.</param>
        /// <returns>Whether a value was returned.</returns>
        public bool TryGetStackTrace<T>(out StackTrace<T> stackTrace)
            where T : unmanaged
        {
            var type = Native.EventHeaderExtendedType.None;
            stackTrace = default;

            if (typeof(T) == typeof(uint))
            {
                type = Native.EventHeaderExtendedType.StackTrace32;
            }
            else if (typeof(T) == typeof(ulong))
            {
                type = Native.EventHeaderExtendedType.StackTrace64;
            }
            else
            {
                return false;
            }

            if (!TryGetExtendedData(type, out var item))
            {
                return false;
            }

            stackTrace = new StackTrace<T>
            {
                MatchId = *(ulong*)item.DataPtr,
                Addresses = new Span<T>((void*)(item.DataPtr + sizeof(ulong)), (item.DataSize - sizeof(ulong)) / sizeof(T))
            };
            return true;
        }

        /// <summary>
        /// Gets the PEBS index.
        /// </summary>
        /// <param name="pebsIndex">The PEBS index.</param>
        /// <returns>Whether a value was returned.</returns>
        public bool TryGetPebsIndex(out ulong pebsIndex)
        {
            if (!TryGetExtendedData(Native.EventHeaderExtendedType.PebsIndex, out var item))
            {
                pebsIndex = default;
                return false;
            }

            pebsIndex = *(ulong*)item.DataPtr;
            return true;
        }

        /// <summary>
        /// Gets the PMC counters.
        /// </summary>
        /// <param name="pmcCounters">The PMC counters.</param>
        /// <returns>Whether a value was returned.</returns>
        public bool TryGetPmcCounters(out Span<ulong> pmcCounters)
        {
            if (!TryGetExtendedData(Native.EventHeaderExtendedType.PmcCounters, out var item))
            {
                pmcCounters = default;
                return false;
            }

            pmcCounters = new Span<ulong>((void*)item.DataPtr, item.DataSize / sizeof(ulong));
            return true;
        }

        /// <summary>
        /// Gets the event key index.
        /// </summary>
        /// <param name="eventKey">The event key index.</param>
        /// <returns>Whether a value was returned.</returns>
        public bool TryGetEventKey(out ulong eventKey)
        {
            if (!TryGetExtendedData(Native.EventHeaderExtendedType.EventKey, out var item))
            {
                eventKey = default;
                return false;
            }

            eventKey = *(ulong*)item.DataPtr;
            return true;
        }

        /// <summary>
        /// Whether the event has TraceLogging event schema.
        /// </summary>
        /// <returns>Whether the event has TraceLogging event schema.</returns>
        public bool HasTraceLoggingEventSchema() =>
            TryGetExtendedData(Native.EventHeaderExtendedType.EventSchemaTl, out var _);

        // No accessor for ProvTraits since it seems to be internal use only.

        /// <summary>
        /// Gets the process start key.
        /// </summary>
        /// <param name="processStartKey">The process start key.</param>
        /// <returns>Whether a value was returned.</returns>
        public bool TryGetProcessStartKey(out ulong processStartKey)
        {
            if (!TryGetExtendedData(Native.EventHeaderExtendedType.ProcessStartKey, out var item))
            {
                processStartKey = default;
                return false;
            }

            processStartKey = *(ulong*)item.DataPtr;
            return true;
        }

        // No accessor for ControlGuid since it seems to be internal use only.

        // No accessor for QpcDelta since it seems to be internal use only.

        // No accessor for ContainerId since it seems to be internal use only.

        /// <summary>
        /// Gets the stack key for the event, if any.
        /// </summary>
        /// <typeparam name="T">The size of the stack key.</typeparam>
        /// <param name="stackKey">The stack key.</param>
        /// <returns>Whether a value was returned.</returns>
        public bool TryGetStackKey<T>(out StackKey<T> stackKey)
            where T : unmanaged
        {
            var type = Native.EventHeaderExtendedType.None;
            stackKey = default;

            if (typeof(T) == typeof(uint))
            {
                type = Native.EventHeaderExtendedType.StackKey32;
            }
            else if (typeof(T) == typeof(ulong))
            {
                type = Native.EventHeaderExtendedType.StackKey64;
            }
            else
            {
                return false;
            }

            if (!TryGetExtendedData(type, out var item))
            {
                return false;
            }

            stackKey = new StackKey<T>
            {
                MatchId = *(ulong*)item.DataPtr,
                Key = *(T*)(item.DataPtr + sizeof(ulong))
            };
            return true;
        }

        /// <summary>
        /// Gets the description of the event, if it is self-describing.
        /// </summary>
        /// <param name="eventInfo">The event description, if there is one.</param>
        /// <returns>True if event is self-describing, false otherwise.</returns>
        public bool TryGetEventInfo(out EtwEventInfo eventInfo)
        {
            eventInfo = default;

            if (!HasTraceLoggingEventSchema())
            {
                return false;
            }

            uint eventBufferSize = 0;
            var hr = (Native.Hresult)Native.TdhGetEventInformation(_eventRecord, 0, null, null, &eventBufferSize);
            if (hr != Native.Hresult.ErrorInsufficientBuffer)
            {
                return false;
            }

            fixed (byte* eventBuffer = new byte[(int)eventBufferSize])
            {
                var traceEventInfo = (Native.TraceEventInfo*)eventBuffer;
                ((Native.Hresult)Native.TdhGetEventInformation(_eventRecord, 0, null, traceEventInfo, &eventBufferSize)).ThrowException();
                eventInfo = new EtwEventInfo(traceEventInfo);
            }

            return true;
        }

        internal SecurityIdentifier GetWbemSid(int offset)
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                throw new InvalidOperationException();
            }

            fixed (byte* buffer = Data)
            {
                return new((nint)(buffer + (AddressSize * 2)));
            }
        }

        internal int AnsiStringLength(int offset)
        {
            var start = offset;
            while ((offset < Data.Length) && (Data[offset] != 0x00))
            {
                offset++;
            }
            offset++;

            return offset - start;
        }

        internal int AnsiStringArrayLength(int offset, uint count)
        {
            var start = offset;

            for (var i = 0; i < count; i++)
            {
                offset += AnsiStringLength(offset);
            }

            return offset - start;
        }

        internal int UnicodeStringLength(int offset)
        {
            var start = offset;
            while ((offset < Data.Length) && ((Data[offset] != 0x00) || (Data[offset + 1] != 0x00)))
            {
                offset += 2;
            }
            offset += 2;

            return offset - start;
        }

        internal int UnicodeStringArrayLength(int offset, uint count)
        {
            var start = offset;

            for (var i = 0; i < count; i++)
            {
                offset += UnicodeStringLength(offset);
            }

            return offset - start;
        }

        internal int GetWbemSidLength(int offset) =>
            !RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                ? throw new InvalidOperationException()
                : GetWbemSid(offset).BinaryLength + (AddressSize * 2);

        /// <summary>
        /// Relationship information for an event.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public readonly struct InstanceInformation
        {
            /// <summary>
            /// The unique transaction identifier of the event.
            /// </summary>
            public uint InstanceId { get; }

            /// <summary>
            /// The unique transaction identifier of the parent event, if any.
            /// </summary>
            public uint ParentInstanceId { get; }

            /// <summary>
            /// The provider GUID of the parent event.
            /// </summary>
            public Guid ParentGuid { get; }
        }

        /// <summary>
        /// A stack trace.
        /// </summary>
        /// <typeparam name="T">The size of stack addresses.</typeparam>
        public ref struct StackTrace<T>
        {
            /// <summary>
            /// Unique stack identifier.
            /// </summary>
            public ulong MatchId { get; init; }

            /// <summary>
            /// Stack addresses.
            /// </summary>
            public Span<T> Addresses { get; init; }
        }

        /// <summary>
        /// A stack key.
        /// </summary>
        /// <typeparam name="T">The size of stack key.</typeparam>
        public ref struct StackKey<T>
        {
            /// <summary>
            /// Unique stack identifier.
            /// </summary>
            public ulong MatchId { get; init; }

            /// <summary>
            /// Stack key.
            /// </summary>
            public T Key { get; init; }
        }

        /// <summary>
        /// A structure that can enumerate addresses without allocation.
        /// </summary>
        public ref struct AddressEnumerable
        {
            private readonly EtwEvent _event;
            private readonly int _offset;
            private readonly uint _count;

            internal AddressEnumerable(EtwEvent e, int offset) :
                this(e, offset, uint.MaxValue)
            {
            }

            internal AddressEnumerable(EtwEvent e, int offset, uint count)
            {
                _event = e;
                _offset = offset;
                _count = count;
            }

            /// <summary>
            /// Gets an enumerator.
            /// </summary>
            /// <returns>The enumerator.</returns>
            public AddressEnumerator GetEnumerator() => new(this);

            /// <summary>
            /// A structure that enumerates over an address collection.
            /// </summary>
            public ref struct AddressEnumerator
            {
                private readonly AddressEnumerable _enumerable;
                private int _offset;
                private int _index;

                /// <summary>
                /// The current value, if any.
                /// </summary>
                public ulong Current => ((_offset < _enumerable._event.Data.Length) && (_index <= _enumerable._count))
                    ? _enumerable._event.AddressSize == 4
                        ? BitConverter.ToUInt32(_enumerable._event.Data[_offset..])
                        : BitConverter.ToUInt64(_enumerable._event.Data[_offset..])
                    : throw new InvalidOperationException();

                internal AddressEnumerator(AddressEnumerable enumerable)
                {
                    _enumerable = enumerable;
                    _offset = int.MaxValue;
                    _index = 0;
                }

                /// <summary>
                /// Moves to the next address.
                /// </summary>
                /// <returns>Whether there is another address.</returns>
                public bool MoveNext()
                {
                    if (_offset == int.MaxValue)
                    {
                        _offset = _enumerable._offset;
                        _index = 1;
                        return true;
                    }

                    _offset += _enumerable._event.AddressSize;
                    _index++;
                    return (_offset < _enumerable._event.Data.Length) && (_index <= _enumerable._count);
                }
            }
        }

        /// <summary>
        /// A structure that can enumerate Unicode strings.
        /// </summary>
        public ref struct UnicodeStringEnumerable
        {
            private readonly EtwEvent _event;
            private readonly int _offset;
            private readonly uint _count;

            internal UnicodeStringEnumerable(EtwEvent e, int offset) :
                this(e, offset, uint.MaxValue)
            {
            }

            internal UnicodeStringEnumerable(EtwEvent e, int offset, uint count)
            {
                _event = e;
                _offset = offset;
                _count = count;
            }

            /// <summary>
            /// Gets an enumerator.
            /// </summary>
            /// <returns>The enumerator.</returns>
            public UnicodeStringEnumerator GetEnumerator() => new(this);

            /// <summary>
            /// A structure that enumerates over an address collection.
            /// </summary>
            public ref struct UnicodeStringEnumerator
            {
                private readonly UnicodeStringEnumerable _enumerable;
                private int _offset;
                private int _index;

                /// <summary>
                /// The current value, if any.
                /// </summary>
                public string Current => ((_offset < _enumerable._event.Data.Length) && (_index <= _enumerable._count))
                    ? Encoding.Unicode.GetString(_enumerable._event.Data[_offset..(_offset + _enumerable._event.UnicodeStringLength(_offset))])
                    : throw new InvalidOperationException();

                internal UnicodeStringEnumerator(UnicodeStringEnumerable enumerable)
                {
                    _enumerable = enumerable;
                    _offset = int.MaxValue;
                    _index = 0;
                }

                /// <summary>
                /// Moves to the next address.
                /// </summary>
                /// <returns>Whether there is another address.</returns>
                public bool MoveNext()
                {
                    if (_offset == int.MaxValue)
                    {
                        _offset = _enumerable._offset;
                        _index = 1;
                        return true;
                    }

                    _offset += _enumerable._event.UnicodeStringLength(_offset);
                    _index++;
                    return (_offset < _enumerable._event.Data.Length) && (_index <= _enumerable._count);
                }
            }
        }

        /// <summary>
        /// A structure that can enumerate ANSI strings.
        /// </summary>
        public ref struct AnsiStringEnumerable
        {
            private readonly EtwEvent _event;
            private readonly int _offset;
            private readonly uint _count;

            internal AnsiStringEnumerable(EtwEvent e, int offset) :
                this(e, offset, uint.MaxValue)
            {
            }

            internal AnsiStringEnumerable(EtwEvent e, int offset, uint count)
            {
                _event = e;
                _offset = offset;
                _count = count;
            }

            /// <summary>
            /// Gets an enumerator.
            /// </summary>
            /// <returns>The enumerator.</returns>
            public AnsiStringEnumerator GetEnumerator() => new(this);

            /// <summary>
            /// A structure that enumerates over an address collection.
            /// </summary>
            public ref struct AnsiStringEnumerator
            {
                private readonly AnsiStringEnumerable _enumerable;
                private int _offset;
                private int _index;

                /// <summary>
                /// The current value, if any.
                /// </summary>
                public string Current => ((_offset < _enumerable._event.Data.Length) && (_index <= _enumerable._count))
                    ? Encoding.ASCII.GetString(_enumerable._event.Data[_offset..(_offset + _enumerable._event.AnsiStringLength(_offset))])
                    : throw new InvalidOperationException();

                internal AnsiStringEnumerator(AnsiStringEnumerable enumerable)
                {
                    _enumerable = enumerable;
                    _offset = int.MaxValue;
                    _index = 0;
                }

                /// <summary>
                /// Moves to the next address.
                /// </summary>
                /// <returns>Whether there is another address.</returns>
                public bool MoveNext()
                {
                    if (_offset == int.MaxValue)
                    {
                        _offset = _enumerable._offset;
                        _index = 1;
                        return true;
                    }

                    _offset += _enumerable._event.AnsiStringLength(_offset);
                    _index++;
                    return (_offset < _enumerable._event.Data.Length) && (_index <= _enumerable._count);
                }
            }
        }

        /// <summary>
        /// A structure that can enumerate structures.
        /// </summary>
        public ref struct StructEnumerable<T> where T : unmanaged
        {
            private readonly EtwEvent _event;
            private readonly int _offset;
            private readonly uint _count;

            internal StructEnumerable(EtwEvent e, int offset) :
                this(e, offset, uint.MaxValue)
            {
            }

            internal StructEnumerable(EtwEvent e, int offset, uint count)
            {
                _event = e;
                _offset = offset;
                _count = count;
            }

            /// <summary>
            /// Gets an enumerator.
            /// </summary>
            /// <returns>The enumerator.</returns>
            public StructEnumerator GetEnumerator() => new(this);

            /// <summary>
            /// A structure that enumerates over an address collection.
            /// </summary>
            public ref struct StructEnumerator
            {
                private readonly StructEnumerable<T> _enumerable;
                private int _offset;
                private int _index;

                /// <summary>
                /// The current value, if any.
                /// </summary>
                public T Current => ((_offset < _enumerable._event.Data.Length) && (_index <= _enumerable._count))
                    ? MemoryMarshal.AsRef<T>(_enumerable._event.Data[_offset..])
                    : throw new InvalidOperationException();

                internal StructEnumerator(StructEnumerable<T> enumerable)
                {
                    _enumerable = enumerable;
                    _offset = int.MaxValue;
                    _index = 0;
                }

                /// <summary>
                /// Moves to the next address.
                /// </summary>
                /// <returns>Whether there is another address.</returns>
                public bool MoveNext()
                {
                    if (_offset == int.MaxValue)
                    {
                        _offset = _enumerable._offset;
                        _index = 1;
                        return true;
                    }

                    _offset += sizeof(T);
                    _index++;
                    return (_offset < _enumerable._event.Data.Length) && (_index <= _enumerable._count);
                }
            }
        }
    }
}
