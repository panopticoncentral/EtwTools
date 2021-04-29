using System;

#pragma warning disable CA1707 // Identifiers should not contain underscores
#pragma warning disable CA1720 // Identifier contains type name

namespace EtwTools
{
    /// <summary>
    /// Provider for Dotnet (319dc449-ada5-50f7-428e-957db6791668)
    /// </summary>
    public sealed class DotnetProvider
    {
        /// <summary>s
        /// Provider ID.
        /// </summary>
        public static readonly Guid Id = new("319dc449-ada5-50f7-428e-957db6791668");

        /// <summary>
        /// Provider name.
        /// </summary>
        public const string Name = "Dotnet";

        /// <summary>
        /// An event wrapper for a AssemblyInfo event.
        /// </summary>
        public readonly ref struct AssemblyInfoEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "AssemblyInfo";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 2652,
                Version = 42,
                Channel = 11,
                Level = EtwTraceLevel.Verbose,
                Opcode = EtwEventOpcode.Info,
                Task = 0,
                Keyword = 35184372088832
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
            public AssemblyInfoData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new AssemblyInfoEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public AssemblyInfoEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// A data wrapper for a AssemblyInfo event.
            /// </summary>
            public readonly ref struct AssemblyInfoData
            {
                private readonly EtwEvent _etwEvent;

                private const int Offset_TargetFrameworkAttribute = 0;
                private readonly int _offset_AssemblyName;

                /// <summary>
                /// Retrieves the TargetFrameworkAttribute field.
                /// </summary>
                public string TargetFrameworkAttribute => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_TargetFrameworkAttribute.._offset_AssemblyName]);

                /// <summary>
                /// Retrieves the AssemblyName field.
                /// </summary>
                public string AssemblyName => System.Text.Encoding.ASCII.GetString(_etwEvent.Data[_offset_AssemblyName..]);

                /// <summary>
                /// Creates a new AssemblyInfoData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public AssemblyInfoData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_AssemblyName = Offset_TargetFrameworkAttribute + EtwEvent.UnicodeStringEnumerable.UnicodeStringEnumerator.StringLength(etwEvent.Data, Offset_TargetFrameworkAttribute);
                }
            }

        }
    }
}
