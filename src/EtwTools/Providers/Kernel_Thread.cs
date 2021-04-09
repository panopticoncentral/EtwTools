using System;

namespace EtwTools.Providers.Kernel
{
    /// <summary>
    /// Provider for Kernel-Thread (3d6fa8d1-fe05-11d0-9dda-00c04fd7ba7c)
    /// </summary>
    public sealed class ThreadProvider
    {
        /// <summary>
        /// Provider ID.
        /// </summary>
        public static readonly Guid Id = new("3d6fa8d1-fe05-11d0-9dda-00c04fd7ba7c");

        /// <summary>
        /// Provider name.
        /// </summary>
        public const string Name = "Kernel-Thread";

        /// <summary>
        /// An event wrapper for a Start event.
        /// </summary>
        public readonly ref struct StartEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_ProcessId = 0;
            private const int Offset_ThreadId = 4;
            private const int Offset_StackBase = 8;
            private readonly int _offset_StackLimit;
            private readonly int _offset_UserStackBase;
            private readonly int _offset_UserStackLimit;
            private readonly int _offset_Affinity;
            private readonly int _offset_Win32StartAddr;
            private readonly int _offset_TebBase;
            private readonly int _offset_SubProcessTag;
            private readonly int _offset_BasePriority;
            private readonly int _offset_PagePriority;
            private readonly int _offset_IoPriority;
            private readonly int _offset_ThreadFlags;
            private readonly int _offset_ThreadName;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 39;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Start";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = ThreadProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 4, Channel = 0, Level = 0, Opcode = (EtwEventType)1, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the ProcessId field.
            /// </summary>
            public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..Offset_ThreadId]);

            /// <summary>
            /// Retrieves the ThreadId field.
            /// </summary>
            public uint ThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ThreadId..Offset_StackBase]);

            /// <summary>
            /// Retrieves the StackBase field.
            /// </summary>
            public ulong StackBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_StackBase.._offset_StackLimit]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_StackBase.._offset_StackLimit]);

            /// <summary>
            /// Retrieves the StackLimit field.
            /// </summary>
            public ulong StackLimit => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[_offset_StackLimit.._offset_UserStackBase]) : BitConverter.ToUInt64(_etwEvent.Data[_offset_StackLimit.._offset_UserStackBase]);

            /// <summary>
            /// Retrieves the UserStackBase field.
            /// </summary>
            public ulong UserStackBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[_offset_UserStackBase.._offset_UserStackLimit]) : BitConverter.ToUInt64(_etwEvent.Data[_offset_UserStackBase.._offset_UserStackLimit]);

            /// <summary>
            /// Retrieves the UserStackLimit field.
            /// </summary>
            public ulong UserStackLimit => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[_offset_UserStackLimit.._offset_Affinity]) : BitConverter.ToUInt64(_etwEvent.Data[_offset_UserStackLimit.._offset_Affinity]);

            /// <summary>
            /// Retrieves the Affinity field.
            /// </summary>
            public ulong Affinity => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[_offset_Affinity.._offset_Win32StartAddr]) : BitConverter.ToUInt64(_etwEvent.Data[_offset_Affinity.._offset_Win32StartAddr]);

            /// <summary>
            /// Retrieves the Win32StartAddr field.
            /// </summary>
            public ulong Win32StartAddr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[_offset_Win32StartAddr.._offset_TebBase]) : BitConverter.ToUInt64(_etwEvent.Data[_offset_Win32StartAddr.._offset_TebBase]);

            /// <summary>
            /// Retrieves the TebBase field.
            /// </summary>
            public ulong TebBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[_offset_TebBase.._offset_SubProcessTag]) : BitConverter.ToUInt64(_etwEvent.Data[_offset_TebBase.._offset_SubProcessTag]);

            /// <summary>
            /// Retrieves the SubProcessTag field.
            /// </summary>
            public uint SubProcessTag => BitConverter.ToUInt32(_etwEvent.Data[_offset_SubProcessTag.._offset_BasePriority]);

            /// <summary>
            /// Retrieves the BasePriority field.
            /// </summary>
            public byte BasePriority => _etwEvent.Data[_offset_BasePriority];

            /// <summary>
            /// Retrieves the PagePriority field.
            /// </summary>
            public byte PagePriority => _etwEvent.Data[_offset_PagePriority];

            /// <summary>
            /// Retrieves the IoPriority field.
            /// </summary>
            public byte IoPriority => _etwEvent.Data[_offset_IoPriority];

            /// <summary>
            /// Retrieves the ThreadFlags field.
            /// </summary>
            public byte ThreadFlags => _etwEvent.Data[_offset_ThreadFlags];

            /// <summary>
            /// Retrieves the ThreadName field.
            /// </summary>
            public string ThreadName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_ThreadName..]);

            /// <summary>
            /// Creates a new StartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public StartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
                _offset_StackLimit = Offset_StackBase + etwEvent.AddressSize;
                _offset_UserStackBase = _offset_StackLimit + etwEvent.AddressSize;
                _offset_UserStackLimit = _offset_UserStackBase + etwEvent.AddressSize;
                _offset_Affinity = _offset_UserStackLimit + etwEvent.AddressSize;
                _offset_Win32StartAddr = _offset_Affinity + etwEvent.AddressSize;
                _offset_TebBase = _offset_Win32StartAddr + etwEvent.AddressSize;
                _offset_SubProcessTag = _offset_TebBase + etwEvent.AddressSize;
                _offset_BasePriority = _offset_SubProcessTag + 4;
                _offset_PagePriority = _offset_BasePriority + 1;
                _offset_IoPriority = _offset_PagePriority + 1;
                _offset_ThreadFlags = _offset_IoPriority + 1;
                _offset_ThreadName = _offset_ThreadFlags + 1;
            }
        }

        /// <summary>
        /// An event wrapper for a End event.
        /// </summary>
        public readonly ref struct EndEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_ProcessId = 0;
            private const int Offset_ThreadId = 4;
            private const int Offset_StackBase = 8;
            private readonly int _offset_StackLimit;
            private readonly int _offset_UserStackBase;
            private readonly int _offset_UserStackLimit;
            private readonly int _offset_Affinity;
            private readonly int _offset_Win32StartAddr;
            private readonly int _offset_TebBase;
            private readonly int _offset_SubProcessTag;
            private readonly int _offset_BasePriority;
            private readonly int _offset_PagePriority;
            private readonly int _offset_IoPriority;
            private readonly int _offset_ThreadFlags;
            private readonly int _offset_ThreadName;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 40;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "End";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = ThreadProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 4, Channel = 0, Level = 0, Opcode = (EtwEventType)2, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the ProcessId field.
            /// </summary>
            public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..Offset_ThreadId]);

            /// <summary>
            /// Retrieves the ThreadId field.
            /// </summary>
            public uint ThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ThreadId..Offset_StackBase]);

            /// <summary>
            /// Retrieves the StackBase field.
            /// </summary>
            public ulong StackBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_StackBase.._offset_StackLimit]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_StackBase.._offset_StackLimit]);

            /// <summary>
            /// Retrieves the StackLimit field.
            /// </summary>
            public ulong StackLimit => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[_offset_StackLimit.._offset_UserStackBase]) : BitConverter.ToUInt64(_etwEvent.Data[_offset_StackLimit.._offset_UserStackBase]);

            /// <summary>
            /// Retrieves the UserStackBase field.
            /// </summary>
            public ulong UserStackBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[_offset_UserStackBase.._offset_UserStackLimit]) : BitConverter.ToUInt64(_etwEvent.Data[_offset_UserStackBase.._offset_UserStackLimit]);

            /// <summary>
            /// Retrieves the UserStackLimit field.
            /// </summary>
            public ulong UserStackLimit => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[_offset_UserStackLimit.._offset_Affinity]) : BitConverter.ToUInt64(_etwEvent.Data[_offset_UserStackLimit.._offset_Affinity]);

            /// <summary>
            /// Retrieves the Affinity field.
            /// </summary>
            public ulong Affinity => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[_offset_Affinity.._offset_Win32StartAddr]) : BitConverter.ToUInt64(_etwEvent.Data[_offset_Affinity.._offset_Win32StartAddr]);

            /// <summary>
            /// Retrieves the Win32StartAddr field.
            /// </summary>
            public ulong Win32StartAddr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[_offset_Win32StartAddr.._offset_TebBase]) : BitConverter.ToUInt64(_etwEvent.Data[_offset_Win32StartAddr.._offset_TebBase]);

            /// <summary>
            /// Retrieves the TebBase field.
            /// </summary>
            public ulong TebBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[_offset_TebBase.._offset_SubProcessTag]) : BitConverter.ToUInt64(_etwEvent.Data[_offset_TebBase.._offset_SubProcessTag]);

            /// <summary>
            /// Retrieves the SubProcessTag field.
            /// </summary>
            public uint SubProcessTag => BitConverter.ToUInt32(_etwEvent.Data[_offset_SubProcessTag.._offset_BasePriority]);

            /// <summary>
            /// Retrieves the BasePriority field.
            /// </summary>
            public byte BasePriority => _etwEvent.Data[_offset_BasePriority];

            /// <summary>
            /// Retrieves the PagePriority field.
            /// </summary>
            public byte PagePriority => _etwEvent.Data[_offset_PagePriority];

            /// <summary>
            /// Retrieves the IoPriority field.
            /// </summary>
            public byte IoPriority => _etwEvent.Data[_offset_IoPriority];

            /// <summary>
            /// Retrieves the ThreadFlags field.
            /// </summary>
            public byte ThreadFlags => _etwEvent.Data[_offset_ThreadFlags];

            /// <summary>
            /// Retrieves the ThreadName field.
            /// </summary>
            public string ThreadName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_ThreadName..]);

            /// <summary>
            /// Creates a new EndEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public EndEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
                _offset_StackLimit = Offset_StackBase + etwEvent.AddressSize;
                _offset_UserStackBase = _offset_StackLimit + etwEvent.AddressSize;
                _offset_UserStackLimit = _offset_UserStackBase + etwEvent.AddressSize;
                _offset_Affinity = _offset_UserStackLimit + etwEvent.AddressSize;
                _offset_Win32StartAddr = _offset_Affinity + etwEvent.AddressSize;
                _offset_TebBase = _offset_Win32StartAddr + etwEvent.AddressSize;
                _offset_SubProcessTag = _offset_TebBase + etwEvent.AddressSize;
                _offset_BasePriority = _offset_SubProcessTag + 4;
                _offset_PagePriority = _offset_BasePriority + 1;
                _offset_IoPriority = _offset_PagePriority + 1;
                _offset_ThreadFlags = _offset_IoPriority + 1;
                _offset_ThreadName = _offset_ThreadFlags + 1;
            }
        }

        /// <summary>
        /// An event wrapper for a DCStart event.
        /// </summary>
        public readonly ref struct DCStartEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_ProcessId = 0;
            private const int Offset_ThreadId = 4;
            private const int Offset_StackBase = 8;
            private readonly int _offset_StackLimit;
            private readonly int _offset_UserStackBase;
            private readonly int _offset_UserStackLimit;
            private readonly int _offset_Affinity;
            private readonly int _offset_Win32StartAddr;
            private readonly int _offset_TebBase;
            private readonly int _offset_SubProcessTag;
            private readonly int _offset_BasePriority;
            private readonly int _offset_PagePriority;
            private readonly int _offset_IoPriority;
            private readonly int _offset_ThreadFlags;
            private readonly int _offset_ThreadName;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 41;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DCStart";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = ThreadProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 4, Channel = 0, Level = 0, Opcode = (EtwEventType)3, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the ProcessId field.
            /// </summary>
            public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..Offset_ThreadId]);

            /// <summary>
            /// Retrieves the ThreadId field.
            /// </summary>
            public uint ThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ThreadId..Offset_StackBase]);

            /// <summary>
            /// Retrieves the StackBase field.
            /// </summary>
            public ulong StackBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_StackBase.._offset_StackLimit]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_StackBase.._offset_StackLimit]);

            /// <summary>
            /// Retrieves the StackLimit field.
            /// </summary>
            public ulong StackLimit => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[_offset_StackLimit.._offset_UserStackBase]) : BitConverter.ToUInt64(_etwEvent.Data[_offset_StackLimit.._offset_UserStackBase]);

            /// <summary>
            /// Retrieves the UserStackBase field.
            /// </summary>
            public ulong UserStackBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[_offset_UserStackBase.._offset_UserStackLimit]) : BitConverter.ToUInt64(_etwEvent.Data[_offset_UserStackBase.._offset_UserStackLimit]);

            /// <summary>
            /// Retrieves the UserStackLimit field.
            /// </summary>
            public ulong UserStackLimit => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[_offset_UserStackLimit.._offset_Affinity]) : BitConverter.ToUInt64(_etwEvent.Data[_offset_UserStackLimit.._offset_Affinity]);

            /// <summary>
            /// Retrieves the Affinity field.
            /// </summary>
            public ulong Affinity => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[_offset_Affinity.._offset_Win32StartAddr]) : BitConverter.ToUInt64(_etwEvent.Data[_offset_Affinity.._offset_Win32StartAddr]);

            /// <summary>
            /// Retrieves the Win32StartAddr field.
            /// </summary>
            public ulong Win32StartAddr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[_offset_Win32StartAddr.._offset_TebBase]) : BitConverter.ToUInt64(_etwEvent.Data[_offset_Win32StartAddr.._offset_TebBase]);

            /// <summary>
            /// Retrieves the TebBase field.
            /// </summary>
            public ulong TebBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[_offset_TebBase.._offset_SubProcessTag]) : BitConverter.ToUInt64(_etwEvent.Data[_offset_TebBase.._offset_SubProcessTag]);

            /// <summary>
            /// Retrieves the SubProcessTag field.
            /// </summary>
            public uint SubProcessTag => BitConverter.ToUInt32(_etwEvent.Data[_offset_SubProcessTag.._offset_BasePriority]);

            /// <summary>
            /// Retrieves the BasePriority field.
            /// </summary>
            public byte BasePriority => _etwEvent.Data[_offset_BasePriority];

            /// <summary>
            /// Retrieves the PagePriority field.
            /// </summary>
            public byte PagePriority => _etwEvent.Data[_offset_PagePriority];

            /// <summary>
            /// Retrieves the IoPriority field.
            /// </summary>
            public byte IoPriority => _etwEvent.Data[_offset_IoPriority];

            /// <summary>
            /// Retrieves the ThreadFlags field.
            /// </summary>
            public byte ThreadFlags => _etwEvent.Data[_offset_ThreadFlags];

            /// <summary>
            /// Retrieves the ThreadName field.
            /// </summary>
            public string ThreadName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_ThreadName..]);

            /// <summary>
            /// Creates a new DCStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DCStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
                _offset_StackLimit = Offset_StackBase + etwEvent.AddressSize;
                _offset_UserStackBase = _offset_StackLimit + etwEvent.AddressSize;
                _offset_UserStackLimit = _offset_UserStackBase + etwEvent.AddressSize;
                _offset_Affinity = _offset_UserStackLimit + etwEvent.AddressSize;
                _offset_Win32StartAddr = _offset_Affinity + etwEvent.AddressSize;
                _offset_TebBase = _offset_Win32StartAddr + etwEvent.AddressSize;
                _offset_SubProcessTag = _offset_TebBase + etwEvent.AddressSize;
                _offset_BasePriority = _offset_SubProcessTag + 4;
                _offset_PagePriority = _offset_BasePriority + 1;
                _offset_IoPriority = _offset_PagePriority + 1;
                _offset_ThreadFlags = _offset_IoPriority + 1;
                _offset_ThreadName = _offset_ThreadFlags + 1;
            }
        }

        /// <summary>
        /// An event wrapper for a DCEnd event.
        /// </summary>
        public readonly ref struct DCEndEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_ProcessId = 0;
            private const int Offset_ThreadId = 4;
            private const int Offset_StackBase = 8;
            private readonly int _offset_StackLimit;
            private readonly int _offset_UserStackBase;
            private readonly int _offset_UserStackLimit;
            private readonly int _offset_Affinity;
            private readonly int _offset_Win32StartAddr;
            private readonly int _offset_TebBase;
            private readonly int _offset_SubProcessTag;
            private readonly int _offset_BasePriority;
            private readonly int _offset_PagePriority;
            private readonly int _offset_IoPriority;
            private readonly int _offset_ThreadFlags;
            private readonly int _offset_ThreadName;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 42;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DCEnd";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = ThreadProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 4, Channel = 0, Level = 0, Opcode = (EtwEventType)4, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the ProcessId field.
            /// </summary>
            public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..Offset_ThreadId]);

            /// <summary>
            /// Retrieves the ThreadId field.
            /// </summary>
            public uint ThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ThreadId..Offset_StackBase]);

            /// <summary>
            /// Retrieves the StackBase field.
            /// </summary>
            public ulong StackBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_StackBase.._offset_StackLimit]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_StackBase.._offset_StackLimit]);

            /// <summary>
            /// Retrieves the StackLimit field.
            /// </summary>
            public ulong StackLimit => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[_offset_StackLimit.._offset_UserStackBase]) : BitConverter.ToUInt64(_etwEvent.Data[_offset_StackLimit.._offset_UserStackBase]);

            /// <summary>
            /// Retrieves the UserStackBase field.
            /// </summary>
            public ulong UserStackBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[_offset_UserStackBase.._offset_UserStackLimit]) : BitConverter.ToUInt64(_etwEvent.Data[_offset_UserStackBase.._offset_UserStackLimit]);

            /// <summary>
            /// Retrieves the UserStackLimit field.
            /// </summary>
            public ulong UserStackLimit => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[_offset_UserStackLimit.._offset_Affinity]) : BitConverter.ToUInt64(_etwEvent.Data[_offset_UserStackLimit.._offset_Affinity]);

            /// <summary>
            /// Retrieves the Affinity field.
            /// </summary>
            public ulong Affinity => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[_offset_Affinity.._offset_Win32StartAddr]) : BitConverter.ToUInt64(_etwEvent.Data[_offset_Affinity.._offset_Win32StartAddr]);

            /// <summary>
            /// Retrieves the Win32StartAddr field.
            /// </summary>
            public ulong Win32StartAddr => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[_offset_Win32StartAddr.._offset_TebBase]) : BitConverter.ToUInt64(_etwEvent.Data[_offset_Win32StartAddr.._offset_TebBase]);

            /// <summary>
            /// Retrieves the TebBase field.
            /// </summary>
            public ulong TebBase => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[_offset_TebBase.._offset_SubProcessTag]) : BitConverter.ToUInt64(_etwEvent.Data[_offset_TebBase.._offset_SubProcessTag]);

            /// <summary>
            /// Retrieves the SubProcessTag field.
            /// </summary>
            public uint SubProcessTag => BitConverter.ToUInt32(_etwEvent.Data[_offset_SubProcessTag.._offset_BasePriority]);

            /// <summary>
            /// Retrieves the BasePriority field.
            /// </summary>
            public byte BasePriority => _etwEvent.Data[_offset_BasePriority];

            /// <summary>
            /// Retrieves the PagePriority field.
            /// </summary>
            public byte PagePriority => _etwEvent.Data[_offset_PagePriority];

            /// <summary>
            /// Retrieves the IoPriority field.
            /// </summary>
            public byte IoPriority => _etwEvent.Data[_offset_IoPriority];

            /// <summary>
            /// Retrieves the ThreadFlags field.
            /// </summary>
            public byte ThreadFlags => _etwEvent.Data[_offset_ThreadFlags];

            /// <summary>
            /// Retrieves the ThreadName field.
            /// </summary>
            public string ThreadName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_ThreadName..]);

            /// <summary>
            /// Creates a new DCEndEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DCEndEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
                _offset_StackLimit = Offset_StackBase + etwEvent.AddressSize;
                _offset_UserStackBase = _offset_StackLimit + etwEvent.AddressSize;
                _offset_UserStackLimit = _offset_UserStackBase + etwEvent.AddressSize;
                _offset_Affinity = _offset_UserStackLimit + etwEvent.AddressSize;
                _offset_Win32StartAddr = _offset_Affinity + etwEvent.AddressSize;
                _offset_TebBase = _offset_Win32StartAddr + etwEvent.AddressSize;
                _offset_SubProcessTag = _offset_TebBase + etwEvent.AddressSize;
                _offset_BasePriority = _offset_SubProcessTag + 4;
                _offset_PagePriority = _offset_BasePriority + 1;
                _offset_IoPriority = _offset_PagePriority + 1;
                _offset_ThreadFlags = _offset_IoPriority + 1;
                _offset_ThreadName = _offset_ThreadFlags + 1;
            }
        }

        /// <summary>
        /// An event wrapper for a CSwitch event.
        /// </summary>
        public readonly ref struct CSwitchEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_NewThreadId = 0;
            private const int Offset_OldThreadId = 4;
            private const int Offset_NewThreadPriority = 8;
            private const int Offset_OldThreadPriority = 9;
            private const int Offset_PreviousCState = 10;
            private const int Offset__padding = 11;
            private const int Offset_OldThreadWaitReason = 12;
            private const int Offset_ThreadFlags = 13;
            private const int Offset_OldThreadState = 14;
            private const int Offset_OldThreadWaitIdealProcessor = 15;
            private const int Offset_NewThreadWaitTime = 16;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 43;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "CSwitch";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = ThreadProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 4, Channel = 0, Level = 0, Opcode = (EtwEventType)36, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the NewThreadId field.
            /// </summary>
            public uint NewThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_NewThreadId..Offset_OldThreadId]);

            /// <summary>
            /// Retrieves the OldThreadId field.
            /// </summary>
            public uint OldThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_OldThreadId..Offset_NewThreadPriority]);

            /// <summary>
            /// Retrieves the NewThreadPriority field.
            /// </summary>
            public sbyte NewThreadPriority => (sbyte)_etwEvent.Data[Offset_NewThreadPriority];

            /// <summary>
            /// Retrieves the OldThreadPriority field.
            /// </summary>
            public sbyte OldThreadPriority => (sbyte)_etwEvent.Data[Offset_OldThreadPriority];

            /// <summary>
            /// Retrieves the PreviousCState field.
            /// </summary>
            public byte PreviousCState => _etwEvent.Data[Offset_PreviousCState];

            /// <summary>
            /// Retrieves the OldThreadWaitReason field.
            /// </summary>
            public sbyte OldThreadWaitReason => (sbyte)_etwEvent.Data[Offset_OldThreadWaitReason];

            /// <summary>
            /// Retrieves the ThreadFlags field.
            /// </summary>
            public sbyte ThreadFlags => (sbyte)_etwEvent.Data[Offset_ThreadFlags];

            /// <summary>
            /// Retrieves the OldThreadState field.
            /// </summary>
            public sbyte OldThreadState => (sbyte)_etwEvent.Data[Offset_OldThreadState];

            /// <summary>
            /// Retrieves the OldThreadWaitIdealProcessor field.
            /// </summary>
            public sbyte OldThreadWaitIdealProcessor => (sbyte)_etwEvent.Data[Offset_OldThreadWaitIdealProcessor];

            /// <summary>
            /// Retrieves the NewThreadWaitTime field.
            /// </summary>
            public uint NewThreadWaitTime => BitConverter.ToUInt32(_etwEvent.Data[Offset_NewThreadWaitTime..]);

            /// <summary>
            /// Creates a new CSwitchEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public CSwitchEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a CompCS event.
        /// </summary>
        public readonly ref struct CompCSEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 44;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "CompCS";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = ThreadProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)37, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Creates a new CompCSEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public CompCSEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a SpinLock event.
        /// </summary>
        public readonly ref struct SpinLockEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_SpinLockAddress = 0;
            private readonly int _offset_CallerAddress;
            private readonly int _offset_AcquireTime;
            private readonly int _offset_ReleaseTime;
            private readonly int _offset_WaitTimeInCycles;
            private readonly int _offset_SpinCount;
            private readonly int _offset_ThreadId;
            private readonly int _offset_InterruptCount;
            private readonly int _offset_Irql;
            private readonly int _offset_AcquireDepth;
            private readonly int _offset_Flag;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 45;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SpinLock";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = ThreadProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)41, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the SpinLockAddress field.
            /// </summary>
            public ulong SpinLockAddress => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_SpinLockAddress.._offset_CallerAddress]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_SpinLockAddress.._offset_CallerAddress]);

            /// <summary>
            /// Retrieves the CallerAddress field.
            /// </summary>
            public ulong CallerAddress => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[_offset_CallerAddress.._offset_AcquireTime]) : BitConverter.ToUInt64(_etwEvent.Data[_offset_CallerAddress.._offset_AcquireTime]);

            /// <summary>
            /// Retrieves the AcquireTime field.
            /// </summary>
            public ulong AcquireTime => BitConverter.ToUInt64(_etwEvent.Data[_offset_AcquireTime.._offset_ReleaseTime]);

            /// <summary>
            /// Retrieves the ReleaseTime field.
            /// </summary>
            public ulong ReleaseTime => BitConverter.ToUInt64(_etwEvent.Data[_offset_ReleaseTime.._offset_WaitTimeInCycles]);

            /// <summary>
            /// Retrieves the WaitTimeInCycles field.
            /// </summary>
            public uint WaitTimeInCycles => BitConverter.ToUInt32(_etwEvent.Data[_offset_WaitTimeInCycles.._offset_SpinCount]);

            /// <summary>
            /// Retrieves the SpinCount field.
            /// </summary>
            public uint SpinCount => BitConverter.ToUInt32(_etwEvent.Data[_offset_SpinCount.._offset_ThreadId]);

            /// <summary>
            /// Retrieves the ThreadId field.
            /// </summary>
            public uint ThreadId => BitConverter.ToUInt32(_etwEvent.Data[_offset_ThreadId.._offset_InterruptCount]);

            /// <summary>
            /// Retrieves the InterruptCount field.
            /// </summary>
            public uint InterruptCount => BitConverter.ToUInt32(_etwEvent.Data[_offset_InterruptCount.._offset_Irql]);

            /// <summary>
            /// Retrieves the Irql field.
            /// </summary>
            public byte Irql => _etwEvent.Data[_offset_Irql];

            /// <summary>
            /// Retrieves the AcquireDepth field.
            /// </summary>
            public byte AcquireDepth => _etwEvent.Data[_offset_AcquireDepth];

            /// <summary>
            /// Retrieves the Flag field.
            /// </summary>
            public byte Flag => _etwEvent.Data[_offset_Flag];

            /// <summary>
            /// Creates a new SpinLockEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SpinLockEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
                _offset_CallerAddress = Offset_SpinLockAddress + etwEvent.AddressSize;
                _offset_AcquireTime = _offset_CallerAddress + etwEvent.AddressSize;
                _offset_ReleaseTime = _offset_AcquireTime + 8;
                _offset_WaitTimeInCycles = _offset_ReleaseTime + 8;
                _offset_SpinCount = _offset_WaitTimeInCycles + 4;
                _offset_ThreadId = _offset_SpinCount + 4;
                _offset_InterruptCount = _offset_ThreadId + 4;
                _offset_Irql = _offset_InterruptCount + 4;
                _offset_AcquireDepth = _offset_Irql + 1;
                _offset_Flag = _offset_AcquireDepth + 1;
            }
        }

        /// <summary>
        /// An event wrapper for a SetPriority event.
        /// </summary>
        public readonly ref struct SetPriorityEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_ThreadId = 0;
            private const int Offset_OldPriority = 4;
            private const int Offset_NewPriority = 5;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 46;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SetPriority";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = ThreadProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 3, Channel = 0, Level = 0, Opcode = (EtwEventType)48, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the ThreadId field.
            /// </summary>
            public uint ThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ThreadId..Offset_OldPriority]);

            /// <summary>
            /// Retrieves the OldPriority field.
            /// </summary>
            public byte OldPriority => _etwEvent.Data[Offset_OldPriority];

            /// <summary>
            /// Retrieves the NewPriority field.
            /// </summary>
            public byte NewPriority => _etwEvent.Data[Offset_NewPriority];

            /// <summary>
            /// Creates a new SetPriorityEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SetPriorityEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a SetBasePriority event.
        /// </summary>
        public readonly ref struct SetBasePriorityEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_ThreadId = 0;
            private const int Offset_OldPriority = 4;
            private const int Offset_NewPriority = 5;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 47;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SetBasePriority";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = ThreadProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 3, Channel = 0, Level = 0, Opcode = (EtwEventType)49, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the ThreadId field.
            /// </summary>
            public uint ThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ThreadId..Offset_OldPriority]);

            /// <summary>
            /// Retrieves the OldPriority field.
            /// </summary>
            public byte OldPriority => _etwEvent.Data[Offset_OldPriority];

            /// <summary>
            /// Retrieves the NewPriority field.
            /// </summary>
            public byte NewPriority => _etwEvent.Data[Offset_NewPriority];

            /// <summary>
            /// Creates a new SetBasePriorityEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SetBasePriorityEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a ReadyThread event.
        /// </summary>
        public readonly ref struct ReadyThreadEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_ThreadId = 0;
            private const int Offset_AdjustReason = 4;
            private const int Offset_AdjustIncrement = 5;
            private const int Offset_Flags = 6;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 48;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ReadyThread";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = ThreadProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)50, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the ThreadId field.
            /// </summary>
            public uint ThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ThreadId..Offset_AdjustReason]);

            /// <summary>
            /// Retrieves the AdjustReason field.
            /// </summary>
            public sbyte AdjustReason => (sbyte)_etwEvent.Data[Offset_AdjustReason];

            /// <summary>
            /// Retrieves the AdjustIncrement field.
            /// </summary>
            public sbyte AdjustIncrement => (sbyte)_etwEvent.Data[Offset_AdjustIncrement];

            /// <summary>
            /// Retrieves the Flags field.
            /// </summary>
            public sbyte Flags => (sbyte)_etwEvent.Data[Offset_Flags];

            /// <summary>
            /// Creates a new ReadyThreadEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ReadyThreadEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a SetPagePriority event.
        /// </summary>
        public readonly ref struct SetPagePriorityEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_ThreadId = 0;
            private const int Offset_OldPriority = 4;
            private const int Offset_NewPriority = 5;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 49;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SetPagePriority";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = ThreadProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 3, Channel = 0, Level = 0, Opcode = (EtwEventType)51, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the ThreadId field.
            /// </summary>
            public uint ThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ThreadId..Offset_OldPriority]);

            /// <summary>
            /// Retrieves the OldPriority field.
            /// </summary>
            public byte OldPriority => _etwEvent.Data[Offset_OldPriority];

            /// <summary>
            /// Retrieves the NewPriority field.
            /// </summary>
            public byte NewPriority => _etwEvent.Data[Offset_NewPriority];

            /// <summary>
            /// Creates a new SetPagePriorityEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SetPagePriorityEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a SetIoPriority event.
        /// </summary>
        public readonly ref struct SetIoPriorityEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_ThreadId = 0;
            private const int Offset_OldPriority = 4;
            private const int Offset_NewPriority = 5;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 50;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SetIoPriority";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = ThreadProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 3, Channel = 0, Level = 0, Opcode = (EtwEventType)52, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the ThreadId field.
            /// </summary>
            public uint ThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ThreadId..Offset_OldPriority]);

            /// <summary>
            /// Retrieves the OldPriority field.
            /// </summary>
            public byte OldPriority => _etwEvent.Data[Offset_OldPriority];

            /// <summary>
            /// Retrieves the NewPriority field.
            /// </summary>
            public byte NewPriority => _etwEvent.Data[Offset_NewPriority];

            /// <summary>
            /// Creates a new SetIoPriorityEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SetIoPriorityEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a ThreadAffinity event.
        /// </summary>
        public readonly ref struct ThreadAffinityEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_Affinity = 0;
            private readonly int _offset_ThreadId;
            private readonly int _offset_Group;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 51;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ThreadAffinity";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = ThreadProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)53, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the Affinity field.
            /// </summary>
            public ulong Affinity => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Affinity.._offset_ThreadId]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Affinity.._offset_ThreadId]);

            /// <summary>
            /// Retrieves the ThreadId field.
            /// </summary>
            public uint ThreadId => BitConverter.ToUInt32(_etwEvent.Data[_offset_ThreadId.._offset_Group]);

            /// <summary>
            /// Retrieves the Group field.
            /// </summary>
            public ushort Group => BitConverter.ToUInt16(_etwEvent.Data[_offset_Group..]);

            /// <summary>
            /// Creates a new ThreadAffinityEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ThreadAffinityEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
                _offset_ThreadId = Offset_Affinity + etwEvent.AddressSize;
                _offset_Group = _offset_ThreadId + 4;
            }
        }

        /// <summary>
        /// An event wrapper for a WorkerThread event.
        /// </summary>
        public readonly ref struct WorkerThreadEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_ThreadId = 0;
            private const int Offset_StartTime = 4;
            private const int Offset_ThreadRoutine = 12;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 52;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "WorkerThread";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = ThreadProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)57, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the ThreadId field.
            /// </summary>
            public uint ThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ThreadId..Offset_StartTime]);

            /// <summary>
            /// Retrieves the StartTime field.
            /// </summary>
            public ulong StartTime => BitConverter.ToUInt64(_etwEvent.Data[Offset_StartTime..Offset_ThreadRoutine]);

            /// <summary>
            /// Retrieves the ThreadRoutine field.
            /// </summary>
            public ulong ThreadRoutine => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_ThreadRoutine..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_ThreadRoutine..]);

            /// <summary>
            /// Creates a new WorkerThreadEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public WorkerThreadEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a AntiStarvationBoost event.
        /// </summary>
        public readonly ref struct AntiStarvationBoostEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_ThreadId = 0;
            private const int Offset_ProcessorIndex = 4;
            private const int Offset_Priority = 6;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 53;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "AntiStarvationBoost";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = ThreadProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)60, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the ThreadId field.
            /// </summary>
            public uint ThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ThreadId..Offset_ProcessorIndex]);

            /// <summary>
            /// Retrieves the ProcessorIndex field.
            /// </summary>
            public ushort ProcessorIndex => BitConverter.ToUInt16(_etwEvent.Data[Offset_ProcessorIndex..Offset_Priority]);

            /// <summary>
            /// Retrieves the Priority field.
            /// </summary>
            public byte Priority => _etwEvent.Data[Offset_Priority];

            /// <summary>
            /// Creates a new AntiStarvationBoostEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public AntiStarvationBoostEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a ThreadMigration event.
        /// </summary>
        public readonly ref struct ThreadMigrationEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_ThreadId = 0;
            private const int Offset_SourceProcessorIndex = 4;
            private const int Offset_TargetProcessorIndex = 6;
            private const int Offset_Priority = 8;
            private const int Offset_IdealProcessorAdjust = 9;
            private const int Offset_OldIdealProcessorIndex = 10;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 54;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ThreadMigration";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = ThreadProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)61, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the ThreadId field.
            /// </summary>
            public uint ThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ThreadId..Offset_SourceProcessorIndex]);

            /// <summary>
            /// Retrieves the SourceProcessorIndex field.
            /// </summary>
            public ushort SourceProcessorIndex => BitConverter.ToUInt16(_etwEvent.Data[Offset_SourceProcessorIndex..Offset_TargetProcessorIndex]);

            /// <summary>
            /// Retrieves the TargetProcessorIndex field.
            /// </summary>
            public ushort TargetProcessorIndex => BitConverter.ToUInt16(_etwEvent.Data[Offset_TargetProcessorIndex..Offset_Priority]);

            /// <summary>
            /// Retrieves the Priority field.
            /// </summary>
            public byte Priority => _etwEvent.Data[Offset_Priority];

            /// <summary>
            /// Retrieves the IdealProcessorAdjust field.
            /// </summary>
            public bool IdealProcessorAdjust => _etwEvent.Data[Offset_IdealProcessorAdjust] != 0;

            /// <summary>
            /// Retrieves the OldIdealProcessorIndex field.
            /// </summary>
            public ushort OldIdealProcessorIndex => BitConverter.ToUInt16(_etwEvent.Data[Offset_OldIdealProcessorIndex..]);

            /// <summary>
            /// Creates a new ThreadMigrationEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ThreadMigrationEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a KernelQueueEnqueue event.
        /// </summary>
        public readonly ref struct KernelQueueEnqueueEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_Entry = 0;
            private readonly int _offset_ThreadId;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 55;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "KernelQueueEnqueue";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = ThreadProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)62, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the Entry field.
            /// </summary>
            public ulong Entry => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Entry.._offset_ThreadId]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Entry.._offset_ThreadId]);

            /// <summary>
            /// Retrieves the ThreadId field.
            /// </summary>
            public uint ThreadId => BitConverter.ToUInt32(_etwEvent.Data[_offset_ThreadId..]);

            /// <summary>
            /// Creates a new KernelQueueEnqueueEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public KernelQueueEnqueueEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
                _offset_ThreadId = Offset_Entry + etwEvent.AddressSize;
            }
        }

        /// <summary>
        /// An event wrapper for a KernelQueueDequeue event.
        /// </summary>
        public readonly ref struct KernelQueueDequeueEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_ThreadId = 0;
            private const int Offset_EntryCount = 4;
            private const int Offset_Entries = 8;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 56;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "KernelQueueDequeue";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = ThreadProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)63, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the ThreadId field.
            /// </summary>
            public uint ThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ThreadId..Offset_EntryCount]);

            /// <summary>
            /// Retrieves the EntryCount field.
            /// </summary>
            public uint EntryCount => BitConverter.ToUInt32(_etwEvent.Data[Offset_EntryCount..Offset_Entries]);

            /// <summary>
            /// Retrieves the Entries field.
            /// </summary>
            public EtwEvent.AddressEnumerable Entries => new(_etwEvent.Data[Offset_Entries..], _etwEvent.AddressSize, EntryCount);

            /// <summary>
            /// Creates a new KernelQueueDequeueEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public KernelQueueDequeueEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a WorkerThreadStart event.
        /// </summary>
        public readonly ref struct WorkerThreadStartEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_CallbackRoutine = 0;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 57;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "WorkerThreadStart";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = ThreadProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)64, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the CallbackRoutine field.
            /// </summary>
            public ulong CallbackRoutine => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_CallbackRoutine..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_CallbackRoutine..]);

            /// <summary>
            /// Creates a new WorkerThreadStartEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public WorkerThreadStartEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a WorkerThreadStop event.
        /// </summary>
        public readonly ref struct WorkerThreadStopEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_CallbackRoutine = 0;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 58;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "WorkerThreadStop";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = ThreadProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)65, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the CallbackRoutine field.
            /// </summary>
            public ulong CallbackRoutine => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_CallbackRoutine..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_CallbackRoutine..]);

            /// <summary>
            /// Creates a new WorkerThreadStopEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public WorkerThreadStopEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a AutoBoostSetFloor event.
        /// </summary>
        public readonly ref struct AutoBoostSetFloorEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_Lock = 0;
            private readonly int _offset_ThreadId;
            private readonly int _offset_NewCpuPriorityFloor;
            private readonly int _offset_OldCpuPriority;
            private readonly int _offset_IoPriorities;
            private readonly int _offset_BoostFlags;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 59;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "AutoBoostSetFloor";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = ThreadProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)66, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the Lock field.
            /// </summary>
            public ulong Lock => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_Lock.._offset_ThreadId]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_Lock.._offset_ThreadId]);

            /// <summary>
            /// Retrieves the ThreadId field.
            /// </summary>
            public uint ThreadId => BitConverter.ToUInt32(_etwEvent.Data[_offset_ThreadId.._offset_NewCpuPriorityFloor]);

            /// <summary>
            /// Retrieves the NewCpuPriorityFloor field.
            /// </summary>
            public byte NewCpuPriorityFloor => _etwEvent.Data[_offset_NewCpuPriorityFloor];

            /// <summary>
            /// Retrieves the OldCpuPriority field.
            /// </summary>
            public byte OldCpuPriority => _etwEvent.Data[_offset_OldCpuPriority];

            /// <summary>
            /// Retrieves the IoPriorities field.
            /// </summary>
            public byte IoPriorities => _etwEvent.Data[_offset_IoPriorities];

            /// <summary>
            /// Retrieves the BoostFlags field.
            /// </summary>
            public byte BoostFlags => _etwEvent.Data[_offset_BoostFlags];

            /// <summary>
            /// Creates a new AutoBoostSetFloorEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public AutoBoostSetFloorEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
                _offset_ThreadId = Offset_Lock + etwEvent.AddressSize;
                _offset_NewCpuPriorityFloor = _offset_ThreadId + 4;
                _offset_OldCpuPriority = _offset_NewCpuPriorityFloor + 1;
                _offset_IoPriorities = _offset_OldCpuPriority + 1;
                _offset_BoostFlags = _offset_IoPriorities + 1;
            }
        }

        /// <summary>
        /// An event wrapper for a AutoBoostClearFloor event.
        /// </summary>
        public readonly ref struct AutoBoostClearFloorEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_LockAddress = 0;
            private readonly int _offset_ThreadId;
            private readonly int _offset_BoostBitmap;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 60;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "AutoBoostClearFloor";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = ThreadProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)67, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the LockAddress field.
            /// </summary>
            public ulong LockAddress => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_LockAddress.._offset_ThreadId]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_LockAddress.._offset_ThreadId]);

            /// <summary>
            /// Retrieves the ThreadId field.
            /// </summary>
            public uint ThreadId => BitConverter.ToUInt32(_etwEvent.Data[_offset_ThreadId.._offset_BoostBitmap]);

            /// <summary>
            /// Retrieves the BoostBitmap field.
            /// </summary>
            public uint BoostBitmap => BitConverter.ToUInt32(_etwEvent.Data[_offset_BoostBitmap..]);

            /// <summary>
            /// Creates a new AutoBoostClearFloorEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public AutoBoostClearFloorEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
                _offset_ThreadId = Offset_LockAddress + etwEvent.AddressSize;
                _offset_BoostBitmap = _offset_ThreadId + 4;
            }
        }

        /// <summary>
        /// An event wrapper for a AutoBoostEntryExhaustion event.
        /// </summary>
        public readonly ref struct AutoBoostEntryExhaustionEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_LockAddress = 0;
            private readonly int _offset_ThreadId;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 61;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "AutoBoostEntryExhaustion";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = ThreadProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)68, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the LockAddress field.
            /// </summary>
            public ulong LockAddress => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_LockAddress.._offset_ThreadId]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_LockAddress.._offset_ThreadId]);

            /// <summary>
            /// Retrieves the ThreadId field.
            /// </summary>
            public uint ThreadId => BitConverter.ToUInt32(_etwEvent.Data[_offset_ThreadId..]);

            /// <summary>
            /// Creates a new AutoBoostEntryExhaustionEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public AutoBoostEntryExhaustionEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
                _offset_ThreadId = Offset_LockAddress + etwEvent.AddressSize;
            }
        }

        /// <summary>
        /// An event wrapper for a SubProcessTagChanged event.
        /// </summary>
        public readonly ref struct SubProcessTagChangedEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_OldTag = 0;
            private const int Offset_NewTag = 4;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 62;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SubProcessTagChanged";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = ThreadProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)69, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the OldTag field.
            /// </summary>
            public uint OldTag => BitConverter.ToUInt32(_etwEvent.Data[Offset_OldTag..Offset_NewTag]);

            /// <summary>
            /// Retrieves the NewTag field.
            /// </summary>
            public uint NewTag => BitConverter.ToUInt32(_etwEvent.Data[Offset_NewTag..]);

            /// <summary>
            /// Creates a new SubProcessTagChangedEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SubProcessTagChangedEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a SetName event.
        /// </summary>
        public readonly ref struct SetNameEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_ProcessId = 0;
            private const int Offset_ThreadId = 4;
            private const int Offset_ThreadName = 8;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 63;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "SetName";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = ThreadProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 0, Version = 2, Channel = 0, Level = 0, Opcode = (EtwEventType)72, Task = 0, Keyword = 0x0000000000000000 };

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the ProcessId field.
            /// </summary>
            public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..Offset_ThreadId]);

            /// <summary>
            /// Retrieves the ThreadId field.
            /// </summary>
            public uint ThreadId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ThreadId..Offset_ThreadName]);

            /// <summary>
            /// Retrieves the ThreadName field.
            /// </summary>
            public string ThreadName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ThreadName..]);

            /// <summary>
            /// Creates a new SetNameEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public SetNameEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }
    }
}
