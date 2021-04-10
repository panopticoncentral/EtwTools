using System;

namespace EtwTools.Providers.System.Diagnostics.Eventing
{
    /// <summary>
    /// Provider for System.Diagnostics.Eventing.FrameworkEventSource (8e9f5090-2d75-4d03-8a81-e5afbf85daf1)
    /// </summary>
    public sealed class FrameworkEventSourceProvider
    {
        /// <summary>
        /// Provider ID.
        /// </summary>
        public static readonly Guid Id = new("8e9f5090-2d75-4d03-8a81-e5afbf85daf1");

        /// <summary>
        /// Provider name.
        /// </summary>
        public const string Name = "System.Diagnostics.Eventing.FrameworkEventSource";

        /// <summary>
        /// An event wrapper for a ResourceManagerLookupStarted event.
        /// </summary>
        public readonly ref struct ResourceManagerLookupStartedEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_BaseName = 0;
            private readonly int _offset_MainAssemblyName;
            private readonly int _offset_CultureName;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 64;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ResourceManagerLookupStarted";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = FrameworkEventSourceProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 1, Version = 0, Channel = 0, Level = (EtwTraceLevel)4, Opcode = 0, Task = 0, Keyword = 0x0000F00000000002 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the BaseName field.
            /// </summary>
            public string BaseName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_BaseName.._offset_MainAssemblyName]);

            /// <summary>
            /// Retrieves the MainAssemblyName field.
            /// </summary>
            public string MainAssemblyName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_MainAssemblyName.._offset_CultureName]);

            /// <summary>
            /// Retrieves the CultureName field.
            /// </summary>
            public string CultureName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_CultureName..]);

            /// <summary>
            /// Creates a new ResourceManagerLookupStartedEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ResourceManagerLookupStartedEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
                _offset_MainAssemblyName = Offset_BaseName + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, Offset_BaseName);
                _offset_CultureName = _offset_MainAssemblyName + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, _offset_MainAssemblyName);
            }
        }

        /// <summary>
        /// An event wrapper for a ResourceManagerLookingForResourceSet event.
        /// </summary>
        public readonly ref struct ResourceManagerLookingForResourceSetEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_BaseName = 0;
            private readonly int _offset_MainAssemblyName;
            private readonly int _offset_CultureName;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 65;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ResourceManagerLookingForResourceSet";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = FrameworkEventSourceProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 2, Version = 0, Channel = 0, Level = (EtwTraceLevel)4, Opcode = 0, Task = 0, Keyword = 0x0000F00000000002 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the BaseName field.
            /// </summary>
            public string BaseName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_BaseName.._offset_MainAssemblyName]);

            /// <summary>
            /// Retrieves the MainAssemblyName field.
            /// </summary>
            public string MainAssemblyName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_MainAssemblyName.._offset_CultureName]);

            /// <summary>
            /// Retrieves the CultureName field.
            /// </summary>
            public string CultureName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_CultureName..]);

            /// <summary>
            /// Creates a new ResourceManagerLookingForResourceSetEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ResourceManagerLookingForResourceSetEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
                _offset_MainAssemblyName = Offset_BaseName + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, Offset_BaseName);
                _offset_CultureName = _offset_MainAssemblyName + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, _offset_MainAssemblyName);
            }
        }

        /// <summary>
        /// An event wrapper for a ResourceManagerFoundResourceSetInCache event.
        /// </summary>
        public readonly ref struct ResourceManagerFoundResourceSetInCacheEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_BaseName = 0;
            private readonly int _offset_MainAssemblyName;
            private readonly int _offset_CultureName;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 66;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ResourceManagerFoundResourceSetInCache";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = FrameworkEventSourceProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 3, Version = 0, Channel = 0, Level = (EtwTraceLevel)4, Opcode = 0, Task = 0, Keyword = 0x0000F00000000002 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the BaseName field.
            /// </summary>
            public string BaseName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_BaseName.._offset_MainAssemblyName]);

            /// <summary>
            /// Retrieves the MainAssemblyName field.
            /// </summary>
            public string MainAssemblyName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_MainAssemblyName.._offset_CultureName]);

            /// <summary>
            /// Retrieves the CultureName field.
            /// </summary>
            public string CultureName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_CultureName..]);

            /// <summary>
            /// Creates a new ResourceManagerFoundResourceSetInCacheEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ResourceManagerFoundResourceSetInCacheEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
                _offset_MainAssemblyName = Offset_BaseName + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, Offset_BaseName);
                _offset_CultureName = _offset_MainAssemblyName + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, _offset_MainAssemblyName);
            }
        }

        /// <summary>
        /// An event wrapper for a ResourceManagerFoundResourceSetInCacheUnexpected event.
        /// </summary>
        public readonly ref struct ResourceManagerFoundResourceSetInCacheUnexpectedEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_BaseName = 0;
            private readonly int _offset_MainAssemblyName;
            private readonly int _offset_CultureName;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 67;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ResourceManagerFoundResourceSetInCacheUnexpected";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = FrameworkEventSourceProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 4, Version = 0, Channel = 0, Level = (EtwTraceLevel)3, Opcode = 0, Task = 0, Keyword = 0x0000F00000000002 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the BaseName field.
            /// </summary>
            public string BaseName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_BaseName.._offset_MainAssemblyName]);

            /// <summary>
            /// Retrieves the MainAssemblyName field.
            /// </summary>
            public string MainAssemblyName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_MainAssemblyName.._offset_CultureName]);

            /// <summary>
            /// Retrieves the CultureName field.
            /// </summary>
            public string CultureName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_CultureName..]);

            /// <summary>
            /// Creates a new ResourceManagerFoundResourceSetInCacheUnexpectedEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ResourceManagerFoundResourceSetInCacheUnexpectedEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
                _offset_MainAssemblyName = Offset_BaseName + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, Offset_BaseName);
                _offset_CultureName = _offset_MainAssemblyName + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, _offset_MainAssemblyName);
            }
        }

        /// <summary>
        /// An event wrapper for a ResourceManagerStreamFound event.
        /// </summary>
        public readonly ref struct ResourceManagerStreamFoundEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_BaseName = 0;
            private readonly int _offset_MainAssemblyName;
            private readonly int _offset_CultureName;
            private readonly int _offset_LoadedAssemblyName;
            private readonly int _offset_ResourceFileName;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 68;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ResourceManagerStreamFound";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = FrameworkEventSourceProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 5, Version = 0, Channel = 0, Level = (EtwTraceLevel)4, Opcode = 0, Task = 0, Keyword = 0x0000F00000000002 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the BaseName field.
            /// </summary>
            public string BaseName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_BaseName.._offset_MainAssemblyName]);

            /// <summary>
            /// Retrieves the MainAssemblyName field.
            /// </summary>
            public string MainAssemblyName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_MainAssemblyName.._offset_CultureName]);

            /// <summary>
            /// Retrieves the CultureName field.
            /// </summary>
            public string CultureName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_CultureName.._offset_LoadedAssemblyName]);

            /// <summary>
            /// Retrieves the LoadedAssemblyName field.
            /// </summary>
            public string LoadedAssemblyName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_LoadedAssemblyName.._offset_ResourceFileName]);

            /// <summary>
            /// Retrieves the ResourceFileName field.
            /// </summary>
            public string ResourceFileName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_ResourceFileName..]);

            /// <summary>
            /// Creates a new ResourceManagerStreamFoundEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ResourceManagerStreamFoundEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
                _offset_MainAssemblyName = Offset_BaseName + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, Offset_BaseName);
                _offset_CultureName = _offset_MainAssemblyName + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, _offset_MainAssemblyName);
                _offset_LoadedAssemblyName = _offset_CultureName + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, _offset_CultureName);
                _offset_ResourceFileName = _offset_LoadedAssemblyName + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, _offset_LoadedAssemblyName);
            }
        }

        /// <summary>
        /// An event wrapper for a ResourceManagerStreamNotFound event.
        /// </summary>
        public readonly ref struct ResourceManagerStreamNotFoundEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_BaseName = 0;
            private readonly int _offset_MainAssemblyName;
            private readonly int _offset_CultureName;
            private readonly int _offset_LoadedAssemblyName;
            private readonly int _offset_ResourceFileName;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 69;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ResourceManagerStreamNotFound";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = FrameworkEventSourceProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 6, Version = 0, Channel = 0, Level = (EtwTraceLevel)3, Opcode = 0, Task = 0, Keyword = 0x0000F00000000002 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the BaseName field.
            /// </summary>
            public string BaseName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_BaseName.._offset_MainAssemblyName]);

            /// <summary>
            /// Retrieves the MainAssemblyName field.
            /// </summary>
            public string MainAssemblyName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_MainAssemblyName.._offset_CultureName]);

            /// <summary>
            /// Retrieves the CultureName field.
            /// </summary>
            public string CultureName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_CultureName.._offset_LoadedAssemblyName]);

            /// <summary>
            /// Retrieves the LoadedAssemblyName field.
            /// </summary>
            public string LoadedAssemblyName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_LoadedAssemblyName.._offset_ResourceFileName]);

            /// <summary>
            /// Retrieves the ResourceFileName field.
            /// </summary>
            public string ResourceFileName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_ResourceFileName..]);

            /// <summary>
            /// Creates a new ResourceManagerStreamNotFoundEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ResourceManagerStreamNotFoundEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
                _offset_MainAssemblyName = Offset_BaseName + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, Offset_BaseName);
                _offset_CultureName = _offset_MainAssemblyName + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, _offset_MainAssemblyName);
                _offset_LoadedAssemblyName = _offset_CultureName + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, _offset_CultureName);
                _offset_ResourceFileName = _offset_LoadedAssemblyName + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, _offset_LoadedAssemblyName);
            }
        }

        /// <summary>
        /// An event wrapper for a ResourceManagerGetSatelliteAssemblySucceeded event.
        /// </summary>
        public readonly ref struct ResourceManagerGetSatelliteAssemblySucceededEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_BaseName = 0;
            private readonly int _offset_MainAssemblyName;
            private readonly int _offset_CultureName;
            private readonly int _offset_AssemblyName;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 70;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ResourceManagerGetSatelliteAssemblySucceeded";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = FrameworkEventSourceProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 7, Version = 0, Channel = 0, Level = (EtwTraceLevel)4, Opcode = 0, Task = 0, Keyword = 0x0000F00000000002 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the BaseName field.
            /// </summary>
            public string BaseName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_BaseName.._offset_MainAssemblyName]);

            /// <summary>
            /// Retrieves the MainAssemblyName field.
            /// </summary>
            public string MainAssemblyName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_MainAssemblyName.._offset_CultureName]);

            /// <summary>
            /// Retrieves the CultureName field.
            /// </summary>
            public string CultureName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_CultureName.._offset_AssemblyName]);

            /// <summary>
            /// Retrieves the AssemblyName field.
            /// </summary>
            public string AssemblyName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_AssemblyName..]);

            /// <summary>
            /// Creates a new ResourceManagerGetSatelliteAssemblySucceededEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ResourceManagerGetSatelliteAssemblySucceededEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
                _offset_MainAssemblyName = Offset_BaseName + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, Offset_BaseName);
                _offset_CultureName = _offset_MainAssemblyName + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, _offset_MainAssemblyName);
                _offset_AssemblyName = _offset_CultureName + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, _offset_CultureName);
            }
        }

        /// <summary>
        /// An event wrapper for a ResourceManagerGetSatelliteAssemblyFailed event.
        /// </summary>
        public readonly ref struct ResourceManagerGetSatelliteAssemblyFailedEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_BaseName = 0;
            private readonly int _offset_MainAssemblyName;
            private readonly int _offset_CultureName;
            private readonly int _offset_AssemblyName;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 71;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ResourceManagerGetSatelliteAssemblyFailed";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = FrameworkEventSourceProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 8, Version = 0, Channel = 0, Level = (EtwTraceLevel)3, Opcode = 0, Task = 0, Keyword = 0x0000F00000000002 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the BaseName field.
            /// </summary>
            public string BaseName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_BaseName.._offset_MainAssemblyName]);

            /// <summary>
            /// Retrieves the MainAssemblyName field.
            /// </summary>
            public string MainAssemblyName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_MainAssemblyName.._offset_CultureName]);

            /// <summary>
            /// Retrieves the CultureName field.
            /// </summary>
            public string CultureName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_CultureName.._offset_AssemblyName]);

            /// <summary>
            /// Retrieves the AssemblyName field.
            /// </summary>
            public string AssemblyName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_AssemblyName..]);

            /// <summary>
            /// Creates a new ResourceManagerGetSatelliteAssemblyFailedEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ResourceManagerGetSatelliteAssemblyFailedEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
                _offset_MainAssemblyName = Offset_BaseName + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, Offset_BaseName);
                _offset_CultureName = _offset_MainAssemblyName + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, _offset_MainAssemblyName);
                _offset_AssemblyName = _offset_CultureName + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, _offset_CultureName);
            }
        }

        /// <summary>
        /// An event wrapper for a ResourceManagerCaseInsensitiveResourceStreamLookupSucceeded event.
        /// </summary>
        public readonly ref struct ResourceManagerCaseInsensitiveResourceStreamLookupSucceededEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_BaseName = 0;
            private readonly int _offset_MainAssemblyName;
            private readonly int _offset_AssemblyName;
            private readonly int _offset_ResourceFileName;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 72;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ResourceManagerCaseInsensitiveResourceStreamLookupSucceeded";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = FrameworkEventSourceProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 9, Version = 0, Channel = 0, Level = (EtwTraceLevel)4, Opcode = 0, Task = 0, Keyword = 0x0000F00000000002 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the BaseName field.
            /// </summary>
            public string BaseName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_BaseName.._offset_MainAssemblyName]);

            /// <summary>
            /// Retrieves the MainAssemblyName field.
            /// </summary>
            public string MainAssemblyName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_MainAssemblyName.._offset_AssemblyName]);

            /// <summary>
            /// Retrieves the AssemblyName field.
            /// </summary>
            public string AssemblyName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_AssemblyName.._offset_ResourceFileName]);

            /// <summary>
            /// Retrieves the ResourceFileName field.
            /// </summary>
            public string ResourceFileName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_ResourceFileName..]);

            /// <summary>
            /// Creates a new ResourceManagerCaseInsensitiveResourceStreamLookupSucceededEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ResourceManagerCaseInsensitiveResourceStreamLookupSucceededEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
                _offset_MainAssemblyName = Offset_BaseName + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, Offset_BaseName);
                _offset_AssemblyName = _offset_MainAssemblyName + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, _offset_MainAssemblyName);
                _offset_ResourceFileName = _offset_AssemblyName + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, _offset_AssemblyName);
            }
        }

        /// <summary>
        /// An event wrapper for a ResourceManagerCaseInsensitiveResourceStreamLookupFailed event.
        /// </summary>
        public readonly ref struct ResourceManagerCaseInsensitiveResourceStreamLookupFailedEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_BaseName = 0;
            private readonly int _offset_MainAssemblyName;
            private readonly int _offset_AssemblyName;
            private readonly int _offset_ResourceFileName;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 73;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ResourceManagerCaseInsensitiveResourceStreamLookupFailed";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = FrameworkEventSourceProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 10, Version = 0, Channel = 0, Level = (EtwTraceLevel)3, Opcode = 0, Task = 0, Keyword = 0x0000F00000000002 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the BaseName field.
            /// </summary>
            public string BaseName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_BaseName.._offset_MainAssemblyName]);

            /// <summary>
            /// Retrieves the MainAssemblyName field.
            /// </summary>
            public string MainAssemblyName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_MainAssemblyName.._offset_AssemblyName]);

            /// <summary>
            /// Retrieves the AssemblyName field.
            /// </summary>
            public string AssemblyName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_AssemblyName.._offset_ResourceFileName]);

            /// <summary>
            /// Retrieves the ResourceFileName field.
            /// </summary>
            public string ResourceFileName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_ResourceFileName..]);

            /// <summary>
            /// Creates a new ResourceManagerCaseInsensitiveResourceStreamLookupFailedEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ResourceManagerCaseInsensitiveResourceStreamLookupFailedEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
                _offset_MainAssemblyName = Offset_BaseName + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, Offset_BaseName);
                _offset_AssemblyName = _offset_MainAssemblyName + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, _offset_MainAssemblyName);
                _offset_ResourceFileName = _offset_AssemblyName + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, _offset_AssemblyName);
            }
        }

        /// <summary>
        /// An event wrapper for a ResourceManagerManifestResourceAccessDenied event.
        /// </summary>
        public readonly ref struct ResourceManagerManifestResourceAccessDeniedEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_BaseName = 0;
            private readonly int _offset_MainAssemblyName;
            private readonly int _offset_AssemblyName;
            private readonly int _offset_CanonicalName;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 74;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ResourceManagerManifestResourceAccessDenied";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = FrameworkEventSourceProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 11, Version = 0, Channel = 0, Level = (EtwTraceLevel)2, Opcode = 0, Task = 0, Keyword = 0x0000F00000000002 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the BaseName field.
            /// </summary>
            public string BaseName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_BaseName.._offset_MainAssemblyName]);

            /// <summary>
            /// Retrieves the MainAssemblyName field.
            /// </summary>
            public string MainAssemblyName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_MainAssemblyName.._offset_AssemblyName]);

            /// <summary>
            /// Retrieves the AssemblyName field.
            /// </summary>
            public string AssemblyName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_AssemblyName.._offset_CanonicalName]);

            /// <summary>
            /// Retrieves the CanonicalName field.
            /// </summary>
            public string CanonicalName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_CanonicalName..]);

            /// <summary>
            /// Creates a new ResourceManagerManifestResourceAccessDeniedEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ResourceManagerManifestResourceAccessDeniedEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
                _offset_MainAssemblyName = Offset_BaseName + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, Offset_BaseName);
                _offset_AssemblyName = _offset_MainAssemblyName + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, _offset_MainAssemblyName);
                _offset_CanonicalName = _offset_AssemblyName + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, _offset_AssemblyName);
            }
        }

        /// <summary>
        /// An event wrapper for a ResourceManagerNeutralResourcesSufficient event.
        /// </summary>
        public readonly ref struct ResourceManagerNeutralResourcesSufficientEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_BaseName = 0;
            private readonly int _offset_MainAssemblyName;
            private readonly int _offset_CultureName;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 75;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ResourceManagerNeutralResourcesSufficient";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = FrameworkEventSourceProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 12, Version = 0, Channel = 0, Level = (EtwTraceLevel)4, Opcode = 0, Task = 0, Keyword = 0x0000F00000000002 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the BaseName field.
            /// </summary>
            public string BaseName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_BaseName.._offset_MainAssemblyName]);

            /// <summary>
            /// Retrieves the MainAssemblyName field.
            /// </summary>
            public string MainAssemblyName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_MainAssemblyName.._offset_CultureName]);

            /// <summary>
            /// Retrieves the CultureName field.
            /// </summary>
            public string CultureName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_CultureName..]);

            /// <summary>
            /// Creates a new ResourceManagerNeutralResourcesSufficientEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ResourceManagerNeutralResourcesSufficientEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
                _offset_MainAssemblyName = Offset_BaseName + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, Offset_BaseName);
                _offset_CultureName = _offset_MainAssemblyName + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, _offset_MainAssemblyName);
            }
        }

        /// <summary>
        /// An event wrapper for a ResourceManagerNeutralResourceAttributeMissing event.
        /// </summary>
        public readonly ref struct ResourceManagerNeutralResourceAttributeMissingEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_MainAssemblyName = 0;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 76;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ResourceManagerNeutralResourceAttributeMissing";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = FrameworkEventSourceProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 13, Version = 0, Channel = 0, Level = (EtwTraceLevel)3, Opcode = 0, Task = 0, Keyword = 0x0000F00000000002 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the MainAssemblyName field.
            /// </summary>
            public string MainAssemblyName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_MainAssemblyName..]);

            /// <summary>
            /// Creates a new ResourceManagerNeutralResourceAttributeMissingEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ResourceManagerNeutralResourceAttributeMissingEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a ResourceManagerCreatingResourceSet event.
        /// </summary>
        public readonly ref struct ResourceManagerCreatingResourceSetEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_BaseName = 0;
            private readonly int _offset_MainAssemblyName;
            private readonly int _offset_CultureName;
            private readonly int _offset_FileName;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 77;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ResourceManagerCreatingResourceSet";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = FrameworkEventSourceProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 14, Version = 0, Channel = 0, Level = (EtwTraceLevel)4, Opcode = 0, Task = 0, Keyword = 0x0000F00000000002 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the BaseName field.
            /// </summary>
            public string BaseName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_BaseName.._offset_MainAssemblyName]);

            /// <summary>
            /// Retrieves the MainAssemblyName field.
            /// </summary>
            public string MainAssemblyName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_MainAssemblyName.._offset_CultureName]);

            /// <summary>
            /// Retrieves the CultureName field.
            /// </summary>
            public string CultureName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_CultureName.._offset_FileName]);

            /// <summary>
            /// Retrieves the FileName field.
            /// </summary>
            public string FileName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_FileName..]);

            /// <summary>
            /// Creates a new ResourceManagerCreatingResourceSetEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ResourceManagerCreatingResourceSetEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
                _offset_MainAssemblyName = Offset_BaseName + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, Offset_BaseName);
                _offset_CultureName = _offset_MainAssemblyName + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, _offset_MainAssemblyName);
                _offset_FileName = _offset_CultureName + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, _offset_CultureName);
            }
        }

        /// <summary>
        /// An event wrapper for a ResourceManagerNotCreatingResourceSet event.
        /// </summary>
        public readonly ref struct ResourceManagerNotCreatingResourceSetEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_BaseName = 0;
            private readonly int _offset_MainAssemblyName;
            private readonly int _offset_CultureName;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 78;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ResourceManagerNotCreatingResourceSet";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = FrameworkEventSourceProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 15, Version = 0, Channel = 0, Level = (EtwTraceLevel)4, Opcode = 0, Task = 0, Keyword = 0x0000F00000000002 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the BaseName field.
            /// </summary>
            public string BaseName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_BaseName.._offset_MainAssemblyName]);

            /// <summary>
            /// Retrieves the MainAssemblyName field.
            /// </summary>
            public string MainAssemblyName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_MainAssemblyName.._offset_CultureName]);

            /// <summary>
            /// Retrieves the CultureName field.
            /// </summary>
            public string CultureName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_CultureName..]);

            /// <summary>
            /// Creates a new ResourceManagerNotCreatingResourceSetEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ResourceManagerNotCreatingResourceSetEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
                _offset_MainAssemblyName = Offset_BaseName + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, Offset_BaseName);
                _offset_CultureName = _offset_MainAssemblyName + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, _offset_MainAssemblyName);
            }
        }

        /// <summary>
        /// An event wrapper for a ResourceManagerLookupFailed event.
        /// </summary>
        public readonly ref struct ResourceManagerLookupFailedEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_BaseName = 0;
            private readonly int _offset_MainAssemblyName;
            private readonly int _offset_CultureName;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 79;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ResourceManagerLookupFailed";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = FrameworkEventSourceProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 16, Version = 0, Channel = 0, Level = (EtwTraceLevel)3, Opcode = 0, Task = 0, Keyword = 0x0000F00000000002 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the BaseName field.
            /// </summary>
            public string BaseName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_BaseName.._offset_MainAssemblyName]);

            /// <summary>
            /// Retrieves the MainAssemblyName field.
            /// </summary>
            public string MainAssemblyName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_MainAssemblyName.._offset_CultureName]);

            /// <summary>
            /// Retrieves the CultureName field.
            /// </summary>
            public string CultureName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_CultureName..]);

            /// <summary>
            /// Creates a new ResourceManagerLookupFailedEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ResourceManagerLookupFailedEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
                _offset_MainAssemblyName = Offset_BaseName + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, Offset_BaseName);
                _offset_CultureName = _offset_MainAssemblyName + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, _offset_MainAssemblyName);
            }
        }

        /// <summary>
        /// An event wrapper for a ResourceManagerReleasingResources event.
        /// </summary>
        public readonly ref struct ResourceManagerReleasingResourcesEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_BaseName = 0;
            private readonly int _offset_MainAssemblyName;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 80;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ResourceManagerReleasingResources";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = FrameworkEventSourceProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 17, Version = 0, Channel = 0, Level = (EtwTraceLevel)4, Opcode = 0, Task = 0, Keyword = 0x0000F00000000002 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the BaseName field.
            /// </summary>
            public string BaseName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_BaseName.._offset_MainAssemblyName]);

            /// <summary>
            /// Retrieves the MainAssemblyName field.
            /// </summary>
            public string MainAssemblyName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_MainAssemblyName..]);

            /// <summary>
            /// Creates a new ResourceManagerReleasingResourcesEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ResourceManagerReleasingResourcesEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
                _offset_MainAssemblyName = Offset_BaseName + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, Offset_BaseName);
            }
        }

        /// <summary>
        /// An event wrapper for a ResourceManagerNeutralResourcesNotFound event.
        /// </summary>
        public readonly ref struct ResourceManagerNeutralResourcesNotFoundEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_BaseName = 0;
            private readonly int _offset_MainAssemblyName;
            private readonly int _offset_ResName;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 81;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ResourceManagerNeutralResourcesNotFound";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = FrameworkEventSourceProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 18, Version = 0, Channel = 0, Level = (EtwTraceLevel)3, Opcode = 0, Task = 0, Keyword = 0x0000F00000000002 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the BaseName field.
            /// </summary>
            public string BaseName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_BaseName.._offset_MainAssemblyName]);

            /// <summary>
            /// Retrieves the MainAssemblyName field.
            /// </summary>
            public string MainAssemblyName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_MainAssemblyName.._offset_ResName]);

            /// <summary>
            /// Retrieves the ResName field.
            /// </summary>
            public string ResName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_ResName..]);

            /// <summary>
            /// Creates a new ResourceManagerNeutralResourcesNotFoundEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ResourceManagerNeutralResourcesNotFoundEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
                _offset_MainAssemblyName = Offset_BaseName + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, Offset_BaseName);
                _offset_ResName = _offset_MainAssemblyName + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, _offset_MainAssemblyName);
            }
        }

        /// <summary>
        /// An event wrapper for a ResourceManagerNeutralResourcesFound event.
        /// </summary>
        public readonly ref struct ResourceManagerNeutralResourcesFoundEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_BaseName = 0;
            private readonly int _offset_MainAssemblyName;
            private readonly int _offset_ResName;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 82;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ResourceManagerNeutralResourcesFound";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = FrameworkEventSourceProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 19, Version = 0, Channel = 0, Level = (EtwTraceLevel)4, Opcode = 0, Task = 0, Keyword = 0x0000F00000000002 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the BaseName field.
            /// </summary>
            public string BaseName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_BaseName.._offset_MainAssemblyName]);

            /// <summary>
            /// Retrieves the MainAssemblyName field.
            /// </summary>
            public string MainAssemblyName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_MainAssemblyName.._offset_ResName]);

            /// <summary>
            /// Retrieves the ResName field.
            /// </summary>
            public string ResName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_ResName..]);

            /// <summary>
            /// Creates a new ResourceManagerNeutralResourcesFoundEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ResourceManagerNeutralResourcesFoundEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
                _offset_MainAssemblyName = Offset_BaseName + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, Offset_BaseName);
                _offset_ResName = _offset_MainAssemblyName + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, _offset_MainAssemblyName);
            }
        }

        /// <summary>
        /// An event wrapper for a ResourceManagerAddingCultureFromConfigFile event.
        /// </summary>
        public readonly ref struct ResourceManagerAddingCultureFromConfigFileEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_BaseName = 0;
            private readonly int _offset_MainAssemblyName;
            private readonly int _offset_CultureName;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 83;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ResourceManagerAddingCultureFromConfigFile";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = FrameworkEventSourceProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 20, Version = 0, Channel = 0, Level = (EtwTraceLevel)4, Opcode = 0, Task = 0, Keyword = 0x0000F00000000002 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the BaseName field.
            /// </summary>
            public string BaseName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_BaseName.._offset_MainAssemblyName]);

            /// <summary>
            /// Retrieves the MainAssemblyName field.
            /// </summary>
            public string MainAssemblyName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_MainAssemblyName.._offset_CultureName]);

            /// <summary>
            /// Retrieves the CultureName field.
            /// </summary>
            public string CultureName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_CultureName..]);

            /// <summary>
            /// Creates a new ResourceManagerAddingCultureFromConfigFileEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ResourceManagerAddingCultureFromConfigFileEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
                _offset_MainAssemblyName = Offset_BaseName + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, Offset_BaseName);
                _offset_CultureName = _offset_MainAssemblyName + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, _offset_MainAssemblyName);
            }
        }

        /// <summary>
        /// An event wrapper for a ResourceManagerCultureNotFoundInConfigFile event.
        /// </summary>
        public readonly ref struct ResourceManagerCultureNotFoundInConfigFileEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_BaseName = 0;
            private readonly int _offset_MainAssemblyName;
            private readonly int _offset_CultureName;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 84;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ResourceManagerCultureNotFoundInConfigFile";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = FrameworkEventSourceProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 21, Version = 0, Channel = 0, Level = (EtwTraceLevel)4, Opcode = 0, Task = 0, Keyword = 0x0000F00000000002 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the BaseName field.
            /// </summary>
            public string BaseName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_BaseName.._offset_MainAssemblyName]);

            /// <summary>
            /// Retrieves the MainAssemblyName field.
            /// </summary>
            public string MainAssemblyName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_MainAssemblyName.._offset_CultureName]);

            /// <summary>
            /// Retrieves the CultureName field.
            /// </summary>
            public string CultureName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_CultureName..]);

            /// <summary>
            /// Creates a new ResourceManagerCultureNotFoundInConfigFileEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ResourceManagerCultureNotFoundInConfigFileEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
                _offset_MainAssemblyName = Offset_BaseName + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, Offset_BaseName);
                _offset_CultureName = _offset_MainAssemblyName + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, _offset_MainAssemblyName);
            }
        }

        /// <summary>
        /// An event wrapper for a ResourceManagerCultureFoundInConfigFile event.
        /// </summary>
        public readonly ref struct ResourceManagerCultureFoundInConfigFileEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_BaseName = 0;
            private readonly int _offset_MainAssemblyName;
            private readonly int _offset_CultureName;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 85;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ResourceManagerCultureFoundInConfigFile";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = FrameworkEventSourceProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 22, Version = 0, Channel = 0, Level = (EtwTraceLevel)4, Opcode = 0, Task = 0, Keyword = 0x0000F00000000002 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the BaseName field.
            /// </summary>
            public string BaseName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_BaseName.._offset_MainAssemblyName]);

            /// <summary>
            /// Retrieves the MainAssemblyName field.
            /// </summary>
            public string MainAssemblyName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_MainAssemblyName.._offset_CultureName]);

            /// <summary>
            /// Retrieves the CultureName field.
            /// </summary>
            public string CultureName => global::System.Text.Encoding.Unicode.GetString(_etwEvent.Data[_offset_CultureName..]);

            /// <summary>
            /// Creates a new ResourceManagerCultureFoundInConfigFileEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ResourceManagerCultureFoundInConfigFileEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
                _offset_MainAssemblyName = Offset_BaseName + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, Offset_BaseName);
                _offset_CultureName = _offset_MainAssemblyName + EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, _offset_MainAssemblyName);
            }
        }

        /// <summary>
        /// An event wrapper for a ThreadPoolEnqueueWork event.
        /// </summary>
        public readonly ref struct ThreadPoolEnqueueWorkEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_WorkID = 0;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 86;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ThreadPoolEnqueueWork";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = FrameworkEventSourceProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 30, Version = 0, Channel = 0, Level = (EtwTraceLevel)5, Opcode = 0, Task = 0, Keyword = 0x0000F00000000012 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the WorkID field.
            /// </summary>
            public long WorkID => BitConverter.ToInt64(_etwEvent.Data[Offset_WorkID..]);

            /// <summary>
            /// Creates a new ThreadPoolEnqueueWorkEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ThreadPoolEnqueueWorkEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }

        /// <summary>
        /// An event wrapper for a ThreadPoolDequeueWork event.
        /// </summary>
        public readonly ref struct ThreadPoolDequeueWorkEvent
        {
            private readonly EtwEvent _etwEvent;

            private const int Offset_WorkID = 0;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = 87;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ThreadPoolDequeueWork";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = FrameworkEventSourceProvider.Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor { Id = 31, Version = 0, Channel = 0, Level = (EtwTraceLevel)5, Opcode = 0, Task = 0, Keyword = 0x0000F00000000012 };

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// Retrieves the WorkID field.
            /// </summary>
            public long WorkID => BitConverter.ToInt64(_etwEvent.Data[Offset_WorkID..]);

            /// <summary>
            /// Creates a new ThreadPoolDequeueWorkEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ThreadPoolDequeueWorkEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }
        }
    }
}
