using System;

namespace EtwTools
{
    /// <summary>
    /// Additional properties that can be enabled for a provider.
    /// </summary>
    [Flags]
    public enum TraceProperties : uint
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0x0,

        /// <summary>
        /// Include in the extended data the security identifier (SID) of the user.
        /// </summary>
        SecurityIdentifier = 0x1,

        /// <summary>
        /// Include in the extended data the terminal session identifier.
        /// </summary>
        TerminalSessionIdentifier = 0x2,

        /// <summary>
        /// Include in the extended data a call stack trace for events written using <c>EventWrite</c>.
        /// </summary>
        StackTrace = 0x4,

        /// <summary>
        /// Filters out all events that do not have a non-zero keyword specified.
        /// </summary>
        IgnoreKeyword0 = 0x10,

        /// <summary>
        /// Indicates that this should enable a Provider Group rather than an individual Event Provider.
        /// </summary>
        ProviderGroup = 0x20,

        /// <summary>
        /// Include the Process Start Key in the extended data.
        /// </summary>
        ProcessStartKey = 0x80,

        /// <summary>
        /// Include the Event Key in the extended data.
        /// </summary>
        EventKey = 0x100,

        /// <summary>
        /// Filters out all events that are either marked as an InPrivate event or come from a process that is marked as InPrivate.
        /// </summary>
        ExcludeInPrivate = 0x200,

        /// <summary>
        /// All known properties.
        /// </summary>
        All = SecurityIdentifier | TerminalSessionIdentifier | StackTrace | IgnoreKeyword0 | ProviderGroup | ProcessStartKey | EventKey | ExcludeInPrivate
    }
}
