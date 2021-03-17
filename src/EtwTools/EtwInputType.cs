namespace EtwTools
{
#pragma warning disable CA1720 // Identifier contains type name

    /// <summary>
    /// The input type of a property.
    /// </summary>
    public enum EtwInputType
    {
        /// <summary>
        /// Null.
        /// </summary>
        Null,

        /// <summary>
        /// Unicode string.
        /// </summary>
        UnicodeString,

        /// <summary>
        /// ANSI string.
        /// </summary>
        AnsiString,

        /// <summary>
        /// Signed byte.
        /// </summary>
        Int8,

        /// <summary>
        /// Unsigned byte.
        /// </summary>
        Uint8,

        /// <summary>
        /// Signed short.
        /// </summary>
        Int16,

        /// <summary>
        /// Unsigned short.
        /// </summary>
        Uint16,

        /// <summary>
        /// Signed integer.
        /// </summary>
        Int32,

        /// <summary>
        /// Unsigned integer.
        /// </summary>
        Uint32,

        /// <summary>
        /// Signed long.
        /// </summary>
        Int64,

        /// <summary>
        /// Unsigned long.
        /// </summary>
        Uint64,

        /// <summary>
        /// Single.
        /// </summary>
        Float,

        /// <summary>
        /// Double.
        /// </summary>
        Double,

        /// <summary>
        /// Boolean.
        /// </summary>
        Boolean,

        /// <summary>
        /// Binary.
        /// </summary>
        Binary,

        /// <summary>
        /// GUID.
        /// </summary>
        Guid,

        /// <summary>
        /// Pointer.
        /// </summary>
        Pointer,

        /// <summary>
        /// File time.
        /// </summary>
        Filetime,

        /// <summary>
        /// System time.
        /// </summary>
        Systemtime,

        /// <summary>
        /// SID.
        /// </summary>
        Sid,

        /// <summary>
        /// Hex signed integer.
        /// </summary>
        HexInt32,

        /// <summary>
        /// Hex signed long.
        /// </summary>
        HexInt64,

        /// <summary>
        /// Counted Unicode string.
        /// </summary>
        CountedString = 300,

        /// <summary>
        /// Counted ANSI string.
        /// </summary>
        CountedAnsiString,

        /// <summary>
        /// Reverse counted Unicode string.
        /// </summary>
        ReverseCountedString,

        /// <summary>
        /// Reverse counted ANSI string.
        /// </summary>
        ReverseCountedAnsiString,

        /// <summary>
        /// Non-NULL terminated Unicode string.
        /// </summary>
        NonNullTerminatedString,

        /// <summary>
        /// Non-NULL terminated ANSI string.
        /// </summary>
        NonNullTerminatedAnsiString,

        /// <summary>
        /// Unicode character.
        /// </summary>
        UnicodeChar,

        /// <summary>
        /// ANSI character.
        /// </summary>
        AnsiChar,

        /// <summary>
        /// Size.
        /// </summary>
        SizeT,

        /// <summary>
        /// Hex dump.
        /// </summary>
        HexDump,

        /// <summary>
        /// WBEM SID.
        /// </summary>
        WbemSid
    };

#pragma warning restore CA1720 // Identifier contains type name
}
