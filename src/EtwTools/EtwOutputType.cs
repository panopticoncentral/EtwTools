namespace EtwTools
{
#pragma warning disable CA1720 // Identifier contains type name

    /// <summary>
    /// The output type of a property.
    /// </summary>
    public enum EtwOutputType
    {
        /// <summary>
        /// Null.
        /// </summary>
        Null,

        /// <summary>
        /// String.
        /// </summary>
        String,

        /// <summary>
        /// Date/time.
        /// </summary>
        DateTime,

        /// <summary>
        /// Byte.
        /// </summary>
        Byte,

        /// <summary>
        /// Unsigned byte.
        /// </summary>
        UnsignedByte,

        /// <summary>
        /// Signed short.
        /// </summary>
        Short,

        /// <summary>
        /// Unsigned short.
        /// </summary>
        UnsignedShort,

        /// <summary>
        /// Signed integer.
        /// </summary>
        Int,

        /// <summary>
        /// Unsigned integer.
        /// </summary>
        UnsignedInt,

        /// <summary>
        /// Signed long.
        /// </summary>
        Long,

        /// <summary>
        /// Unsigned long.
        /// </summary>
        UnsignedLong,

        /// <summary>
        /// Single floating-point.
        /// </summary>
        Float,

        /// <summary>
        /// Double floating-point.
        /// </summary>
        Double,

        /// <summary>
        /// Boolean.
        /// </summary>
        Boolean,

        /// <summary>
        /// GUID.
        /// </summary>
        Guid,

        /// <summary>
        /// Hexadecimal binary.
        /// </summary>
        HexBinary,

        /// <summary>
        /// Hexadecimal signed byte.
        /// </summary>
        HexInt8,

        /// <summary>
        /// Hexadecimal signed short.
        /// </summary>
        HexInt16,

        /// <summary>
        /// Hexadecimal signed integer.
        /// </summary>
        HexInt32,

        /// <summary>
        /// Hexadecimal signed long.
        /// </summary>
        HexInt64,

        /// <summary>
        /// Process ID.
        /// </summary>
        Pid,

        /// <summary>
        /// Thread ID.
        /// </summary>
        Tid,

        /// <summary>
        /// Port.
        /// </summary>
        Port,

        /// <summary>
        /// IPV4 address.
        /// </summary>
        Ipv4,

        /// <summary>
        /// IPV6 address.
        /// </summary>
        Ipv6,

        /// <summary>
        /// Socket address.
        /// </summary>
        SocketAddress,

        /// <summary>
        /// CIM date/time.
        /// </summary>
        CimDateTime,

        /// <summary>
        /// ETW time.
        /// </summary>
        EtwTime,

        /// <summary>
        /// XML.
        /// </summary>
        Xml,

        /// <summary>
        /// Error code.
        /// </summary>
        ErrorCode,

        /// <summary>
        /// Reduced string.
        /// </summary>
        ReducedString = 300,

        /// <summary>
        /// No printing.
        /// </summary>
        NoPrint
    };

#pragma warning restore CA1720 // Identifier contains type name
}
