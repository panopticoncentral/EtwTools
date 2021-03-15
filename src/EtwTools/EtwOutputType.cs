namespace EtwTools
{
    public enum EtwOutputType
    {
        Null,
        String,
        DateTime,
        Byte,
        UnsignedByte,
        Short,
        UnsignedShort,
        Int,
        UnsignedInt,
        Long,
        UnsignedLong,
        Float,
        Double,
        Boolean,
        Guid,
        HexBinary,
        HexInt8,
        HexInt16,
        HexInt32,
        HexInt64,
        Pid,
        Tid,
        Port,
        Ipv4,
        Ipv6,
        SocketAddress,
        CimDateTime,
        EtwTime,
        Xml,
        ErrorCode,
        ReducedString = 300,
        NoPrint
    };

}
