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

        public abstract PropertyKind Kind { get; }

        public PropertySize Length { get; init; }

        public PropertySize Count { get; init; }

        internal static unsafe EtwPropertyDescriptor Create(Native.TraceEventInfo* traceEventInfo, Native.EventPropertyInfo* propertyInfo)
        {
            if ((propertyInfo->PropertyFlags & Native.PropertyFlags.Struct) != 0)
            {
                var properties = new EtwPropertyDescriptor[propertyInfo->Union2];
                for (var i = 0; i < propertyInfo->Union2; i++)
                {
                    var eventBuffer = (byte*)traceEventInfo;
                    var currentProperty = (Native.EventPropertyInfo*)(eventBuffer + sizeof(Native.TraceEventInfo) + (sizeof(Native.EventPropertyInfo) * (i + propertyInfo->Union1)));
                    properties[i] = Create(traceEventInfo, currentProperty);
                }

                return new EtwStructPropertyDescriptor
                {
                    Name = new string((char*)(((byte*)traceEventInfo) + propertyInfo->NameOffset)),
                    Properties = properties
                };
            }
            else if ((propertyInfo->PropertyFlags & Native.PropertyFlags.HasCustomSchema) != 0)
            {
                return new EtwCustomSchemaPropertyDescriptor
                {
                    Name = new string((char*)(((byte*)traceEventInfo) + propertyInfo->NameOffset))
                };
            }
            else
            {
                return new EtwSimplePropertyDescriptor
                {
                    Name = new string((char*)(((byte*)traceEventInfo) + propertyInfo->NameOffset)),
                    InputType = (EtwInputType)propertyInfo->Union1,
                    OutputType = (EtwOutputType)propertyInfo->Union2,
                    MapName = propertyInfo->Union3 == 0 ? null : new string((char*)(((byte*)traceEventInfo) + propertyInfo->Union3)),
                    Length = new PropertySize
                    {
                        Size = propertyInfo->Length,
                        Kind = (propertyInfo->PropertyFlags & Native.PropertyFlags.ParamLength) != 0
                            ? PropertySizeKind.Property
                            : (propertyInfo->PropertyFlags & Native.PropertyFlags.ParamFixedLength) != 0
                                ? PropertySizeKind.Fixed
                                : PropertySizeKind.Regular
                    },
                    Count = new PropertySize
                    {
                        Size = propertyInfo->Count,
                        Kind = (propertyInfo->PropertyFlags & Native.PropertyFlags.ParamCount) != 0
                            ? PropertySizeKind.Property
                            : (propertyInfo->PropertyFlags & Native.PropertyFlags.ParamFixedCount) != 0
                                ? PropertySizeKind.Fixed
                                : PropertySizeKind.Regular
                    }
                };
            }
        }

        public enum PropertyKind
        {
            Simple,
            CustomSchema,
            Struct
        }

        public enum PropertySizeKind
        {
            Regular,
            Property,
            Fixed
        }

        public struct PropertySize
        {
            public uint Size { get; init; }
            public PropertySizeKind Kind { get; init; }
        }
    }
}
