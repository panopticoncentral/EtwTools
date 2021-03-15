namespace EtwTools
{
    /// <summary>
    /// Description of an ETW event's property.
    /// </summary>
    public abstract record EtwPropertyDescriptor
    {
        /// <summary>
        /// The name of the property.
        /// </summary>
        public string Name { get; init; }

        internal static unsafe EtwPropertyDescriptor Create(Native.TraceEventInfo* traceEventInfo, Native.EventPropertyInfo* propertyInfo)
        {
            if ((propertyInfo->PropertyFlags & Native.PropertyFlags.Struct) != 0)
            {
                // UNDONE
                return null;
            }
            else if ((propertyInfo->PropertyFlags & Native.PropertyFlags.HasCustomSchema) != 0)
            {
                // UNDONE
                return null;
            }
            else
            {
                return new EtwSimplePropertyDescriptor
                {
                    Name = new string((char*)(((byte*)traceEventInfo) + propertyInfo->NameOffset)),
                    InputType = (EtwInputType)propertyInfo->Union1,
                    OutputType = (EtwOutputType)propertyInfo->Union2,
                    MapName = propertyInfo->Union3 == 0 ? null : new string((char*)(((byte*)traceEventInfo) + propertyInfo->Union3))
                };
            }
        }
    }
}
