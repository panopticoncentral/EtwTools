using System;
using System.Collections.Generic;

namespace EtwTools
{
    /// <summary>
    /// Description of an ETW event's property.
    /// </summary>
    public sealed record EtwPropertyInfo
    {
        /// <summary>
        /// The name of the property.
        /// </summary>
        public string Name { get; init; }

        /// <summary>
        /// The input type of the property.
        /// </summary>
        public EtwInputType InputType { get; init; }

        /// <summary>
        /// The desired output type of the property.
        /// </summary>
        public EtwOutputType OutputType { get; init; }

        /// <summary>
        /// The name of the map type of the property, if any.
        /// </summary>
        public string MapName { get; init; }

        /// <summary>
        /// The structure properties, if any.
        /// </summary>
        public IReadOnlyList<EtwPropertyInfo> Properties { get; init; }

        /// <summary>
        /// The length of the property.
        /// </summary>
        public PropertySize Length { get; init; }

        /// <summary>
        /// The count of the property.
        /// </summary>
        public PropertySize Count { get; init; }

        /// <summary>
        /// Property tags.
        /// </summary>
        public uint Tags { get; init; }

        internal static unsafe EtwPropertyInfo Create(Native.TraceEventInfo* traceEventInfo, Native.EventPropertyInfo* propertyInfo)
        {
            if ((propertyInfo->PropertyFlags & Native.PropertyFlags.HasCustomSchema) != 0)
            {
                throw new InvalidOperationException();
            }

            if ((propertyInfo->PropertyFlags & Native.PropertyFlags.Struct) != 0)
            {
                var properties = new EtwPropertyInfo[propertyInfo->Union2];
                for (var i = 0; i < propertyInfo->Union2; i++)
                {
                    var eventBuffer = (byte*)traceEventInfo;
                    var currentProperty = (Native.EventPropertyInfo*)(eventBuffer + sizeof(Native.TraceEventInfo) + (sizeof(Native.EventPropertyInfo) * (i + propertyInfo->Union1)));
                    properties[i] = Create(traceEventInfo, currentProperty);
                }

                return new EtwPropertyInfo
                {
                    Name = new string((char*)(((byte*)traceEventInfo) + propertyInfo->NameOffset)),
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
                    },
                    Properties = properties,
                    Tags = propertyInfo->Tags
                };
            }
            else
            {
                return new EtwPropertyInfo
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
                    },
                    Tags = propertyInfo->Tags
                };
            }
        }

        /// <summary>
        /// The kind of a size (length, count) property.
        /// </summary>
        public enum PropertySizeKind
        {
            /// <summary>
            /// Regular size.
            /// </summary>
            Regular,

            /// <summary>
            /// Size is specified by property at offset.
            /// </summary>
            Property,

            /// <summary>
            /// Fixed size.
            /// </summary>
            Fixed
        }

        /// <summary>
        /// A size (length, count) property.
        /// </summary>
        public struct PropertySize
        {
            /// <summary>
            /// The size value.
            /// </summary>
            public uint Size { get; init; }

            /// <summary>
            /// The size kind.
            /// </summary>
            public PropertySizeKind Kind { get; init; }
        }
    }
}
