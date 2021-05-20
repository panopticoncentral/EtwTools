using System;

#pragma warning disable IDE0079 // Remove unnecessary suppression
#pragma warning disable IDE0004 // Remove Unnecessary Cast
#pragma warning disable IDE1006 // Naming Styles
#pragma warning disable CA1416 // Validate platform compatibility
#pragma warning disable CA1707 // Identifiers should not contain underscores
#pragma warning disable CA1720 // Identifier contains type name

namespace EtwTools
{
    /// <summary>
    /// Provider for Kernel-SystemConfig (01853a65-418f-4f36-aefc-dc0f1d2fd235)
    /// </summary>
    public sealed class KernelSystemConfigProvider
    {
        /// <summary>s
        /// Provider ID.
        /// </summary>
        public static readonly Guid Id = new("01853a65-418f-4f36-aefc-dc0f1d2fd235");

        /// <summary>
        /// Provider name.
        /// </summary>
        public const string Name = "Kernel-SystemConfig";

        /// <summary>
        /// Opcodes supported by KernelSystemConfig.
        /// </summary>
        public enum Opcodes
        {
            /// <summary>
            /// 'CPU' opcode.
            /// </summary>
            CPU = 10,
            /// <summary>
            /// 'PhyDisk' opcode.
            /// </summary>
            PhyDisk = 11,
            /// <summary>
            /// 'LogDisk' opcode.
            /// </summary>
            LogDisk = 12,
            /// <summary>
            /// 'NIC' opcode.
            /// </summary>
            NIC = 13,
            /// <summary>
            /// 'Video' opcode.
            /// </summary>
            Video = 14,
            /// <summary>
            /// 'Services' opcode.
            /// </summary>
            Services = 15,
            /// <summary>
            /// 'Power' opcode.
            /// </summary>
            Power = 16,
            /// <summary>
            /// 'Network' opcode.
            /// </summary>
            Network = 17,
            /// <summary>
            /// 'OpticalDisk' opcode.
            /// </summary>
            OpticalDisk = 18,
            /// <summary>
            /// 'IRQ' opcode.
            /// </summary>
            IRQ = 21,
            /// <summary>
            /// 'PnP' opcode.
            /// </summary>
            PnP = 22,
            /// <summary>
            /// 'IDEChannel' opcode.
            /// </summary>
            IDEChannel = 23,
            /// <summary>
            /// 'NumaNode' opcode.
            /// </summary>
            NumaNode = 24,
            /// <summary>
            /// 'Platform' opcode.
            /// </summary>
            Platform = 25,
            /// <summary>
            /// 'ProcessorGroup' opcode.
            /// </summary>
            ProcessorGroup = 26,
            /// <summary>
            /// 'ProcessorNumber' opcode.
            /// </summary>
            ProcessorNumber = 27,
            /// <summary>
            /// 'DPI' opcode.
            /// </summary>
            DPI = 28,
            /// <summary>
            /// 'CodeIntegrity' opcode.
            /// </summary>
            CodeIntegrity = 29,
            /// <summary>
            /// 'TelemetryConfiguration' opcode.
            /// </summary>
            TelemetryConfiguration = 30,
            /// <summary>
            /// 'Defragmentation' opcode.
            /// </summary>
            Defragmentation = 31,
            /// <summary>
            /// 'MobilePlatform' opcode.
            /// </summary>
            MobilePlatform = 32,
            /// <summary>
            /// 'DeviceFamily' opcode.
            /// </summary>
            DeviceFamily = 33,
            /// <summary>
            /// 'FlightIds' opcode.
            /// </summary>
            FlightIds = 34,
            /// <summary>
            /// 'Processors' opcode.
            /// </summary>
            Processors = 35,
            /// <summary>
            /// 'VirtualizationConfigInfo' opcode.
            /// </summary>
            VirtualizationConfigInfo = 36,
            /// <summary>
            /// 'BootConfigInfo' opcode.
            /// </summary>
            BootConfigInfo = 37,
        }

        /// <summary>
        /// An event wrapper for a CPU event.
        /// </summary>
        public readonly ref struct CPUEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "CPU";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 0,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.CPU,
                Task = 0,
                Keyword = 0
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
            public CPUData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new CPUEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public CPUEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a CPUEvent.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator CPUEvent(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a CPU event.
            /// </summary>
            public ref struct CPUData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_MHz;
                private int _offset_NumberOfProcessors;
                private int _offset_MemSize;
                private int _offset_PageSize;
                private int _offset_AllocationGranularity;
                private int _offset_ComputerName;
                private int _offset_DomainName;
                private int _offset_HyperThreadingFlag;

                private int Offset_MHz
                {
                    get
                    {
                        if (_offset_MHz == -1)
                        {
                            _offset_MHz = 0;
                        }

                        return _offset_MHz;
                    }
                }

                private int Offset_NumberOfProcessors
                {
                    get
                    {
                        if (_offset_NumberOfProcessors == -1)
                        {
                            _offset_NumberOfProcessors = Offset_MHz + 4;
                        }

                        return _offset_NumberOfProcessors;
                    }
                }

                private int Offset_MemSize
                {
                    get
                    {
                        if (_offset_MemSize == -1)
                        {
                            _offset_MemSize = Offset_NumberOfProcessors + 4;
                        }

                        return _offset_MemSize;
                    }
                }

                private int Offset_PageSize
                {
                    get
                    {
                        if (_offset_PageSize == -1)
                        {
                            _offset_PageSize = Offset_MemSize + 4;
                        }

                        return _offset_PageSize;
                    }
                }

                private int Offset_AllocationGranularity
                {
                    get
                    {
                        if (_offset_AllocationGranularity == -1)
                        {
                            _offset_AllocationGranularity = Offset_PageSize + 4;
                        }

                        return _offset_AllocationGranularity;
                    }
                }

                private int Offset_ComputerName
                {
                    get
                    {
                        if (_offset_ComputerName == -1)
                        {
                            _offset_ComputerName = Offset_AllocationGranularity + 4;
                        }

                        return _offset_ComputerName;
                    }
                }

                private int Offset_DomainName
                {
                    get
                    {
                        if (_offset_DomainName == -1)
                        {
                            _offset_DomainName = Offset_ComputerName + 2;
                        }

                        return _offset_DomainName;
                    }
                }

                private int Offset_HyperThreadingFlag
                {
                    get
                    {
                        if (_offset_HyperThreadingFlag == -1)
                        {
                            _offset_HyperThreadingFlag = Offset_DomainName + 2;
                        }

                        return _offset_HyperThreadingFlag;
                    }
                }

                /// <summary>
                /// Retrieves the MHz field.
                /// </summary>
                public uint MHz => BitConverter.ToUInt32(_etwEvent.Data[Offset_MHz..Offset_NumberOfProcessors]);

                /// <summary>
                /// Retrieves the NumberOfProcessors field.
                /// </summary>
                public uint NumberOfProcessors => BitConverter.ToUInt32(_etwEvent.Data[Offset_NumberOfProcessors..Offset_MemSize]);

                /// <summary>
                /// Retrieves the MemSize field.
                /// </summary>
                public uint MemSize => BitConverter.ToUInt32(_etwEvent.Data[Offset_MemSize..Offset_PageSize]);

                /// <summary>
                /// Retrieves the PageSize field.
                /// </summary>
                public uint PageSize => BitConverter.ToUInt32(_etwEvent.Data[Offset_PageSize..Offset_AllocationGranularity]);

                /// <summary>
                /// Retrieves the AllocationGranularity field.
                /// </summary>
                public uint AllocationGranularity => BitConverter.ToUInt32(_etwEvent.Data[Offset_AllocationGranularity..Offset_ComputerName]);

                /// <summary>
                /// Retrieves the ComputerName field.
                /// </summary>
                public char ComputerName => BitConverter.ToChar(_etwEvent.Data[Offset_ComputerName..Offset_DomainName]);

                /// <summary>
                /// Retrieves the DomainName field.
                /// </summary>
                public char DomainName => BitConverter.ToChar(_etwEvent.Data[Offset_DomainName..Offset_HyperThreadingFlag]);

                /// <summary>
                /// Retrieves the HyperThreadingFlag field.
                /// </summary>
                public ulong HyperThreadingFlag => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_HyperThreadingFlag..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_HyperThreadingFlag..]);

                /// <summary>
                /// Creates a new CPUData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public CPUData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_MHz = -1;
                    _offset_NumberOfProcessors = -1;
                    _offset_MemSize = -1;
                    _offset_PageSize = -1;
                    _offset_AllocationGranularity = -1;
                    _offset_ComputerName = -1;
                    _offset_DomainName = -1;
                    _offset_HyperThreadingFlag = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a PhyDisk event.
        /// </summary>
        public readonly ref struct PhyDiskEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "PhyDisk";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 0,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.PhyDisk,
                Task = 0,
                Keyword = 0
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
            public PhyDiskData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new PhyDiskEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public PhyDiskEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a PhyDiskEvent.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator PhyDiskEvent(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a PhyDisk event.
            /// </summary>
            public ref struct PhyDiskData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_DiskNumber;
                private int _offset_BytesPerSector;
                private int _offset_SectorsPerTrack;
                private int _offset_TracksPerCylinder;
                private int _offset_Cylinders;
                private int _offset_SCSIPort;
                private int _offset_SCSIPath;
                private int _offset_SCSITarget;
                private int _offset_SCSILun;
                private int _offset_Manufacturer;
                private int _offset_PartitionCount;
                private int _offset_WriteCacheEnabled;
                private int _offset_Pad;
                private int _offset_BootDriveLetter;
                private int _offset_Spare;

                private int Offset_DiskNumber
                {
                    get
                    {
                        if (_offset_DiskNumber == -1)
                        {
                            _offset_DiskNumber = 0;
                        }

                        return _offset_DiskNumber;
                    }
                }

                private int Offset_BytesPerSector
                {
                    get
                    {
                        if (_offset_BytesPerSector == -1)
                        {
                            _offset_BytesPerSector = Offset_DiskNumber + 4;
                        }

                        return _offset_BytesPerSector;
                    }
                }

                private int Offset_SectorsPerTrack
                {
                    get
                    {
                        if (_offset_SectorsPerTrack == -1)
                        {
                            _offset_SectorsPerTrack = Offset_BytesPerSector + 4;
                        }

                        return _offset_SectorsPerTrack;
                    }
                }

                private int Offset_TracksPerCylinder
                {
                    get
                    {
                        if (_offset_TracksPerCylinder == -1)
                        {
                            _offset_TracksPerCylinder = Offset_SectorsPerTrack + 4;
                        }

                        return _offset_TracksPerCylinder;
                    }
                }

                private int Offset_Cylinders
                {
                    get
                    {
                        if (_offset_Cylinders == -1)
                        {
                            _offset_Cylinders = Offset_TracksPerCylinder + 4;
                        }

                        return _offset_Cylinders;
                    }
                }

                private int Offset_SCSIPort
                {
                    get
                    {
                        if (_offset_SCSIPort == -1)
                        {
                            _offset_SCSIPort = Offset_Cylinders + 8;
                        }

                        return _offset_SCSIPort;
                    }
                }

                private int Offset_SCSIPath
                {
                    get
                    {
                        if (_offset_SCSIPath == -1)
                        {
                            _offset_SCSIPath = Offset_SCSIPort + 4;
                        }

                        return _offset_SCSIPath;
                    }
                }

                private int Offset_SCSITarget
                {
                    get
                    {
                        if (_offset_SCSITarget == -1)
                        {
                            _offset_SCSITarget = Offset_SCSIPath + 4;
                        }

                        return _offset_SCSITarget;
                    }
                }

                private int Offset_SCSILun
                {
                    get
                    {
                        if (_offset_SCSILun == -1)
                        {
                            _offset_SCSILun = Offset_SCSITarget + 4;
                        }

                        return _offset_SCSILun;
                    }
                }

                private int Offset_Manufacturer
                {
                    get
                    {
                        if (_offset_Manufacturer == -1)
                        {
                            _offset_Manufacturer = Offset_SCSILun + 4;
                        }

                        return _offset_Manufacturer;
                    }
                }

                private int Offset_PartitionCount
                {
                    get
                    {
                        if (_offset_PartitionCount == -1)
                        {
                            _offset_PartitionCount = Offset_Manufacturer + 2;
                        }

                        return _offset_PartitionCount;
                    }
                }

                private int Offset_WriteCacheEnabled
                {
                    get
                    {
                        if (_offset_WriteCacheEnabled == -1)
                        {
                            _offset_WriteCacheEnabled = Offset_PartitionCount + 4;
                        }

                        return _offset_WriteCacheEnabled;
                    }
                }

                private int Offset_Pad
                {
                    get
                    {
                        if (_offset_Pad == -1)
                        {
                            _offset_Pad = Offset_WriteCacheEnabled + 1;
                        }

                        return _offset_Pad;
                    }
                }

                private int Offset_BootDriveLetter
                {
                    get
                    {
                        if (_offset_BootDriveLetter == -1)
                        {
                            _offset_BootDriveLetter = Offset_Pad + 1;
                        }

                        return _offset_BootDriveLetter;
                    }
                }

                private int Offset_Spare
                {
                    get
                    {
                        if (_offset_Spare == -1)
                        {
                            _offset_Spare = Offset_BootDriveLetter + 2;
                        }

                        return _offset_Spare;
                    }
                }

                /// <summary>
                /// Retrieves the DiskNumber field.
                /// </summary>
                public uint DiskNumber => BitConverter.ToUInt32(_etwEvent.Data[Offset_DiskNumber..Offset_BytesPerSector]);

                /// <summary>
                /// Retrieves the BytesPerSector field.
                /// </summary>
                public uint BytesPerSector => BitConverter.ToUInt32(_etwEvent.Data[Offset_BytesPerSector..Offset_SectorsPerTrack]);

                /// <summary>
                /// Retrieves the SectorsPerTrack field.
                /// </summary>
                public uint SectorsPerTrack => BitConverter.ToUInt32(_etwEvent.Data[Offset_SectorsPerTrack..Offset_TracksPerCylinder]);

                /// <summary>
                /// Retrieves the TracksPerCylinder field.
                /// </summary>
                public uint TracksPerCylinder => BitConverter.ToUInt32(_etwEvent.Data[Offset_TracksPerCylinder..Offset_Cylinders]);

                /// <summary>
                /// Retrieves the Cylinders field.
                /// </summary>
                public ulong Cylinders => BitConverter.ToUInt64(_etwEvent.Data[Offset_Cylinders..Offset_SCSIPort]);

                /// <summary>
                /// Retrieves the SCSIPort field.
                /// </summary>
                public uint SCSIPort => BitConverter.ToUInt32(_etwEvent.Data[Offset_SCSIPort..Offset_SCSIPath]);

                /// <summary>
                /// Retrieves the SCSIPath field.
                /// </summary>
                public uint SCSIPath => BitConverter.ToUInt32(_etwEvent.Data[Offset_SCSIPath..Offset_SCSITarget]);

                /// <summary>
                /// Retrieves the SCSITarget field.
                /// </summary>
                public uint SCSITarget => BitConverter.ToUInt32(_etwEvent.Data[Offset_SCSITarget..Offset_SCSILun]);

                /// <summary>
                /// Retrieves the SCSILun field.
                /// </summary>
                public uint SCSILun => BitConverter.ToUInt32(_etwEvent.Data[Offset_SCSILun..Offset_Manufacturer]);

                /// <summary>
                /// Retrieves the Manufacturer field.
                /// </summary>
                public char Manufacturer => BitConverter.ToChar(_etwEvent.Data[Offset_Manufacturer..Offset_PartitionCount]);

                /// <summary>
                /// Retrieves the PartitionCount field.
                /// </summary>
                public uint PartitionCount => BitConverter.ToUInt32(_etwEvent.Data[Offset_PartitionCount..Offset_WriteCacheEnabled]);

                /// <summary>
                /// Retrieves the WriteCacheEnabled field.
                /// </summary>
                public byte WriteCacheEnabled => _etwEvent.Data[Offset_WriteCacheEnabled];

                /// <summary>
                /// Retrieves the Pad field.
                /// </summary>
                public byte Pad => _etwEvent.Data[Offset_Pad];

                /// <summary>
                /// Retrieves the BootDriveLetter field.
                /// </summary>
                public char BootDriveLetter => BitConverter.ToChar(_etwEvent.Data[Offset_BootDriveLetter..Offset_Spare]);

                /// <summary>
                /// Retrieves the Spare field.
                /// </summary>
                public char Spare => BitConverter.ToChar(_etwEvent.Data[Offset_Spare..]);

                /// <summary>
                /// Creates a new PhyDiskData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public PhyDiskData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_DiskNumber = -1;
                    _offset_BytesPerSector = -1;
                    _offset_SectorsPerTrack = -1;
                    _offset_TracksPerCylinder = -1;
                    _offset_Cylinders = -1;
                    _offset_SCSIPort = -1;
                    _offset_SCSIPath = -1;
                    _offset_SCSITarget = -1;
                    _offset_SCSILun = -1;
                    _offset_Manufacturer = -1;
                    _offset_PartitionCount = -1;
                    _offset_WriteCacheEnabled = -1;
                    _offset_Pad = -1;
                    _offset_BootDriveLetter = -1;
                    _offset_Spare = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a LogDisk event.
        /// </summary>
        public readonly ref struct LogDiskEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "LogDisk";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 0,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.LogDisk,
                Task = 0,
                Keyword = 0
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
            public LogDiskData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new LogDiskEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public LogDiskEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a LogDiskEvent.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator LogDiskEvent(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a LogDisk event.
            /// </summary>
            public ref struct LogDiskData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_StartOffset;
                private int _offset_PartitionSize;
                private int _offset_DiskNumber;
                private int _offset_Size;
                private int _offset_DriveType;
                private int _offset_DriveLetterString;
                private int _offset_Pad1;
                private int _offset_PartitionNumber;
                private int _offset_SectorsPerCluster;
                private int _offset_BytesPerSector;
                private int _offset_Pad2;
                private int _offset_NumberOfFreeClusters;
                private int _offset_TotalNumberOfClusters;
                private int _offset_FileSystem;
                private int _offset_VolumeExt;

                private int Offset_StartOffset
                {
                    get
                    {
                        if (_offset_StartOffset == -1)
                        {
                            _offset_StartOffset = 0;
                        }

                        return _offset_StartOffset;
                    }
                }

                private int Offset_PartitionSize
                {
                    get
                    {
                        if (_offset_PartitionSize == -1)
                        {
                            _offset_PartitionSize = Offset_StartOffset + 8;
                        }

                        return _offset_PartitionSize;
                    }
                }

                private int Offset_DiskNumber
                {
                    get
                    {
                        if (_offset_DiskNumber == -1)
                        {
                            _offset_DiskNumber = Offset_PartitionSize + 8;
                        }

                        return _offset_DiskNumber;
                    }
                }

                private int Offset_Size
                {
                    get
                    {
                        if (_offset_Size == -1)
                        {
                            _offset_Size = Offset_DiskNumber + 4;
                        }

                        return _offset_Size;
                    }
                }

                private int Offset_DriveType
                {
                    get
                    {
                        if (_offset_DriveType == -1)
                        {
                            _offset_DriveType = Offset_Size + 4;
                        }

                        return _offset_DriveType;
                    }
                }

                private int Offset_DriveLetterString
                {
                    get
                    {
                        if (_offset_DriveLetterString == -1)
                        {
                            _offset_DriveLetterString = Offset_DriveType + 4;
                        }

                        return _offset_DriveLetterString;
                    }
                }

                private int Offset_Pad1
                {
                    get
                    {
                        if (_offset_Pad1 == -1)
                        {
                            _offset_Pad1 = Offset_DriveLetterString + 2;
                        }

                        return _offset_Pad1;
                    }
                }

                private int Offset_PartitionNumber
                {
                    get
                    {
                        if (_offset_PartitionNumber == -1)
                        {
                            _offset_PartitionNumber = Offset_Pad1 + 4;
                        }

                        return _offset_PartitionNumber;
                    }
                }

                private int Offset_SectorsPerCluster
                {
                    get
                    {
                        if (_offset_SectorsPerCluster == -1)
                        {
                            _offset_SectorsPerCluster = Offset_PartitionNumber + 4;
                        }

                        return _offset_SectorsPerCluster;
                    }
                }

                private int Offset_BytesPerSector
                {
                    get
                    {
                        if (_offset_BytesPerSector == -1)
                        {
                            _offset_BytesPerSector = Offset_SectorsPerCluster + 4;
                        }

                        return _offset_BytesPerSector;
                    }
                }

                private int Offset_Pad2
                {
                    get
                    {
                        if (_offset_Pad2 == -1)
                        {
                            _offset_Pad2 = Offset_BytesPerSector + 4;
                        }

                        return _offset_Pad2;
                    }
                }

                private int Offset_NumberOfFreeClusters
                {
                    get
                    {
                        if (_offset_NumberOfFreeClusters == -1)
                        {
                            _offset_NumberOfFreeClusters = Offset_Pad2 + 4;
                        }

                        return _offset_NumberOfFreeClusters;
                    }
                }

                private int Offset_TotalNumberOfClusters
                {
                    get
                    {
                        if (_offset_TotalNumberOfClusters == -1)
                        {
                            _offset_TotalNumberOfClusters = Offset_NumberOfFreeClusters + 8;
                        }

                        return _offset_TotalNumberOfClusters;
                    }
                }

                private int Offset_FileSystem
                {
                    get
                    {
                        if (_offset_FileSystem == -1)
                        {
                            _offset_FileSystem = Offset_TotalNumberOfClusters + 8;
                        }

                        return _offset_FileSystem;
                    }
                }

                private int Offset_VolumeExt
                {
                    get
                    {
                        if (_offset_VolumeExt == -1)
                        {
                            _offset_VolumeExt = Offset_FileSystem + 2;
                        }

                        return _offset_VolumeExt;
                    }
                }

                /// <summary>
                /// Retrieves the StartOffset field.
                /// </summary>
                public ulong StartOffset => BitConverter.ToUInt64(_etwEvent.Data[Offset_StartOffset..Offset_PartitionSize]);

                /// <summary>
                /// Retrieves the PartitionSize field.
                /// </summary>
                public ulong PartitionSize => BitConverter.ToUInt64(_etwEvent.Data[Offset_PartitionSize..Offset_DiskNumber]);

                /// <summary>
                /// Retrieves the DiskNumber field.
                /// </summary>
                public uint DiskNumber => BitConverter.ToUInt32(_etwEvent.Data[Offset_DiskNumber..Offset_Size]);

                /// <summary>
                /// Retrieves the Size field.
                /// </summary>
                public uint Size => BitConverter.ToUInt32(_etwEvent.Data[Offset_Size..Offset_DriveType]);

                /// <summary>
                /// Retrieves the DriveType field.
                /// </summary>
                public uint DriveType => BitConverter.ToUInt32(_etwEvent.Data[Offset_DriveType..Offset_DriveLetterString]);

                /// <summary>
                /// Retrieves the DriveLetterString field.
                /// </summary>
                public char DriveLetterString => BitConverter.ToChar(_etwEvent.Data[Offset_DriveLetterString..Offset_Pad1]);

                /// <summary>
                /// Retrieves the Pad1 field.
                /// </summary>
                public uint Pad1 => BitConverter.ToUInt32(_etwEvent.Data[Offset_Pad1..Offset_PartitionNumber]);

                /// <summary>
                /// Retrieves the PartitionNumber field.
                /// </summary>
                public uint PartitionNumber => BitConverter.ToUInt32(_etwEvent.Data[Offset_PartitionNumber..Offset_SectorsPerCluster]);

                /// <summary>
                /// Retrieves the SectorsPerCluster field.
                /// </summary>
                public uint SectorsPerCluster => BitConverter.ToUInt32(_etwEvent.Data[Offset_SectorsPerCluster..Offset_BytesPerSector]);

                /// <summary>
                /// Retrieves the BytesPerSector field.
                /// </summary>
                public uint BytesPerSector => BitConverter.ToUInt32(_etwEvent.Data[Offset_BytesPerSector..Offset_Pad2]);

                /// <summary>
                /// Retrieves the Pad2 field.
                /// </summary>
                public uint Pad2 => BitConverter.ToUInt32(_etwEvent.Data[Offset_Pad2..Offset_NumberOfFreeClusters]);

                /// <summary>
                /// Retrieves the NumberOfFreeClusters field.
                /// </summary>
                public long NumberOfFreeClusters => BitConverter.ToInt64(_etwEvent.Data[Offset_NumberOfFreeClusters..Offset_TotalNumberOfClusters]);

                /// <summary>
                /// Retrieves the TotalNumberOfClusters field.
                /// </summary>
                public long TotalNumberOfClusters => BitConverter.ToInt64(_etwEvent.Data[Offset_TotalNumberOfClusters..Offset_FileSystem]);

                /// <summary>
                /// Retrieves the FileSystem field.
                /// </summary>
                public char FileSystem => BitConverter.ToChar(_etwEvent.Data[Offset_FileSystem..Offset_VolumeExt]);

                /// <summary>
                /// Retrieves the VolumeExt field.
                /// </summary>
                public uint VolumeExt => BitConverter.ToUInt32(_etwEvent.Data[Offset_VolumeExt..]);

                /// <summary>
                /// Creates a new LogDiskData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public LogDiskData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_StartOffset = -1;
                    _offset_PartitionSize = -1;
                    _offset_DiskNumber = -1;
                    _offset_Size = -1;
                    _offset_DriveType = -1;
                    _offset_DriveLetterString = -1;
                    _offset_Pad1 = -1;
                    _offset_PartitionNumber = -1;
                    _offset_SectorsPerCluster = -1;
                    _offset_BytesPerSector = -1;
                    _offset_Pad2 = -1;
                    _offset_NumberOfFreeClusters = -1;
                    _offset_TotalNumberOfClusters = -1;
                    _offset_FileSystem = -1;
                    _offset_VolumeExt = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a NIC event.
        /// </summary>
        public readonly ref struct NICEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "NIC";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 0,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.NIC,
                Task = 0,
                Keyword = 0
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
            public NICData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new NICEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public NICEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a NICEvent.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator NICEvent(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a NIC event.
            /// </summary>
            public ref struct NICData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_NICName;
                private int _offset_Index;
                private int _offset_PhysicalAddrLen;
                private int _offset_PhysicalAddr;
                private int _offset_Size;
                private int _offset_IpAddress;
                private int _offset_SubnetMask;
                private int _offset_DhcpServer;
                private int _offset_Gateway;
                private int _offset_PrimaryWinsServer;
                private int _offset_SecondaryWinsServer;
                private int _offset_DnsServer1;
                private int _offset_DnsServer2;
                private int _offset_DnsServer3;
                private int _offset_DnsServer4;
                private int _offset_Data;

                private int Offset_NICName
                {
                    get
                    {
                        if (_offset_NICName == -1)
                        {
                            _offset_NICName = 0;
                        }

                        return _offset_NICName;
                    }
                }

                private int Offset_Index
                {
                    get
                    {
                        if (_offset_Index == -1)
                        {
                            _offset_Index = Offset_NICName + 2;
                        }

                        return _offset_Index;
                    }
                }

                private int Offset_PhysicalAddrLen
                {
                    get
                    {
                        if (_offset_PhysicalAddrLen == -1)
                        {
                            _offset_PhysicalAddrLen = Offset_Index + 4;
                        }

                        return _offset_PhysicalAddrLen;
                    }
                }

                private int Offset_PhysicalAddr
                {
                    get
                    {
                        if (_offset_PhysicalAddr == -1)
                        {
                            _offset_PhysicalAddr = Offset_PhysicalAddrLen + 4;
                        }

                        return _offset_PhysicalAddr;
                    }
                }

                private int Offset_Size
                {
                    get
                    {
                        if (_offset_Size == -1)
                        {
                            _offset_Size = Offset_PhysicalAddr + 2;
                        }

                        return _offset_Size;
                    }
                }

                private int Offset_IpAddress
                {
                    get
                    {
                        if (_offset_IpAddress == -1)
                        {
                            _offset_IpAddress = Offset_Size + 4;
                        }

                        return _offset_IpAddress;
                    }
                }

                private int Offset_SubnetMask
                {
                    get
                    {
                        if (_offset_SubnetMask == -1)
                        {
                            _offset_SubnetMask = Offset_IpAddress + 4;
                        }

                        return _offset_SubnetMask;
                    }
                }

                private int Offset_DhcpServer
                {
                    get
                    {
                        if (_offset_DhcpServer == -1)
                        {
                            _offset_DhcpServer = Offset_SubnetMask + 4;
                        }

                        return _offset_DhcpServer;
                    }
                }

                private int Offset_Gateway
                {
                    get
                    {
                        if (_offset_Gateway == -1)
                        {
                            _offset_Gateway = Offset_DhcpServer + 4;
                        }

                        return _offset_Gateway;
                    }
                }

                private int Offset_PrimaryWinsServer
                {
                    get
                    {
                        if (_offset_PrimaryWinsServer == -1)
                        {
                            _offset_PrimaryWinsServer = Offset_Gateway + 4;
                        }

                        return _offset_PrimaryWinsServer;
                    }
                }

                private int Offset_SecondaryWinsServer
                {
                    get
                    {
                        if (_offset_SecondaryWinsServer == -1)
                        {
                            _offset_SecondaryWinsServer = Offset_PrimaryWinsServer + 4;
                        }

                        return _offset_SecondaryWinsServer;
                    }
                }

                private int Offset_DnsServer1
                {
                    get
                    {
                        if (_offset_DnsServer1 == -1)
                        {
                            _offset_DnsServer1 = Offset_SecondaryWinsServer + 4;
                        }

                        return _offset_DnsServer1;
                    }
                }

                private int Offset_DnsServer2
                {
                    get
                    {
                        if (_offset_DnsServer2 == -1)
                        {
                            _offset_DnsServer2 = Offset_DnsServer1 + 4;
                        }

                        return _offset_DnsServer2;
                    }
                }

                private int Offset_DnsServer3
                {
                    get
                    {
                        if (_offset_DnsServer3 == -1)
                        {
                            _offset_DnsServer3 = Offset_DnsServer2 + 4;
                        }

                        return _offset_DnsServer3;
                    }
                }

                private int Offset_DnsServer4
                {
                    get
                    {
                        if (_offset_DnsServer4 == -1)
                        {
                            _offset_DnsServer4 = Offset_DnsServer3 + 4;
                        }

                        return _offset_DnsServer4;
                    }
                }

                private int Offset_Data
                {
                    get
                    {
                        if (_offset_Data == -1)
                        {
                            _offset_Data = Offset_DnsServer4 + 4;
                        }

                        return _offset_Data;
                    }
                }

                /// <summary>
                /// Retrieves the NICName field.
                /// </summary>
                public char NICName => BitConverter.ToChar(_etwEvent.Data[Offset_NICName..Offset_Index]);

                /// <summary>
                /// Retrieves the Index field.
                /// </summary>
                public uint Index => BitConverter.ToUInt32(_etwEvent.Data[Offset_Index..Offset_PhysicalAddrLen]);

                /// <summary>
                /// Retrieves the PhysicalAddrLen field.
                /// </summary>
                public uint PhysicalAddrLen => BitConverter.ToUInt32(_etwEvent.Data[Offset_PhysicalAddrLen..Offset_PhysicalAddr]);

                /// <summary>
                /// Retrieves the PhysicalAddr field.
                /// </summary>
                public char PhysicalAddr => BitConverter.ToChar(_etwEvent.Data[Offset_PhysicalAddr..Offset_Size]);

                /// <summary>
                /// Retrieves the Size field.
                /// </summary>
                public uint Size => BitConverter.ToUInt32(_etwEvent.Data[Offset_Size..Offset_IpAddress]);

                /// <summary>
                /// Retrieves the IpAddress field.
                /// </summary>
                public int IpAddress => BitConverter.ToInt32(_etwEvent.Data[Offset_IpAddress..Offset_SubnetMask]);

                /// <summary>
                /// Retrieves the SubnetMask field.
                /// </summary>
                public int SubnetMask => BitConverter.ToInt32(_etwEvent.Data[Offset_SubnetMask..Offset_DhcpServer]);

                /// <summary>
                /// Retrieves the DhcpServer field.
                /// </summary>
                public int DhcpServer => BitConverter.ToInt32(_etwEvent.Data[Offset_DhcpServer..Offset_Gateway]);

                /// <summary>
                /// Retrieves the Gateway field.
                /// </summary>
                public int Gateway => BitConverter.ToInt32(_etwEvent.Data[Offset_Gateway..Offset_PrimaryWinsServer]);

                /// <summary>
                /// Retrieves the PrimaryWinsServer field.
                /// </summary>
                public int PrimaryWinsServer => BitConverter.ToInt32(_etwEvent.Data[Offset_PrimaryWinsServer..Offset_SecondaryWinsServer]);

                /// <summary>
                /// Retrieves the SecondaryWinsServer field.
                /// </summary>
                public int SecondaryWinsServer => BitConverter.ToInt32(_etwEvent.Data[Offset_SecondaryWinsServer..Offset_DnsServer1]);

                /// <summary>
                /// Retrieves the DnsServer1 field.
                /// </summary>
                public int DnsServer1 => BitConverter.ToInt32(_etwEvent.Data[Offset_DnsServer1..Offset_DnsServer2]);

                /// <summary>
                /// Retrieves the DnsServer2 field.
                /// </summary>
                public int DnsServer2 => BitConverter.ToInt32(_etwEvent.Data[Offset_DnsServer2..Offset_DnsServer3]);

                /// <summary>
                /// Retrieves the DnsServer3 field.
                /// </summary>
                public int DnsServer3 => BitConverter.ToInt32(_etwEvent.Data[Offset_DnsServer3..Offset_DnsServer4]);

                /// <summary>
                /// Retrieves the DnsServer4 field.
                /// </summary>
                public int DnsServer4 => BitConverter.ToInt32(_etwEvent.Data[Offset_DnsServer4..Offset_Data]);

                /// <summary>
                /// Retrieves the Data field.
                /// </summary>
                public uint Data => BitConverter.ToUInt32(_etwEvent.Data[Offset_Data..]);

                /// <summary>
                /// Creates a new NICData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public NICData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_NICName = -1;
                    _offset_Index = -1;
                    _offset_PhysicalAddrLen = -1;
                    _offset_PhysicalAddr = -1;
                    _offset_Size = -1;
                    _offset_IpAddress = -1;
                    _offset_SubnetMask = -1;
                    _offset_DhcpServer = -1;
                    _offset_Gateway = -1;
                    _offset_PrimaryWinsServer = -1;
                    _offset_SecondaryWinsServer = -1;
                    _offset_DnsServer1 = -1;
                    _offset_DnsServer2 = -1;
                    _offset_DnsServer3 = -1;
                    _offset_DnsServer4 = -1;
                    _offset_Data = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Video event.
        /// </summary>
        public readonly ref struct VideoEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Video";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 0,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.Video,
                Task = 0,
                Keyword = 0
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
            public VideoData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new VideoEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public VideoEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a VideoEvent.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator VideoEvent(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Video event.
            /// </summary>
            public ref struct VideoData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_MemorySize;
                private int _offset_XResolution;
                private int _offset_YResolution;
                private int _offset_BitsPerPixel;
                private int _offset_VRefresh;
                private int _offset_ChipType;
                private int _offset_DACType;
                private int _offset_AdapterString;
                private int _offset_BiosString;
                private int _offset_DeviceId;
                private int _offset_StateFlags;

                private int Offset_MemorySize
                {
                    get
                    {
                        if (_offset_MemorySize == -1)
                        {
                            _offset_MemorySize = 0;
                        }

                        return _offset_MemorySize;
                    }
                }

                private int Offset_XResolution
                {
                    get
                    {
                        if (_offset_XResolution == -1)
                        {
                            _offset_XResolution = Offset_MemorySize + 4;
                        }

                        return _offset_XResolution;
                    }
                }

                private int Offset_YResolution
                {
                    get
                    {
                        if (_offset_YResolution == -1)
                        {
                            _offset_YResolution = Offset_XResolution + 4;
                        }

                        return _offset_YResolution;
                    }
                }

                private int Offset_BitsPerPixel
                {
                    get
                    {
                        if (_offset_BitsPerPixel == -1)
                        {
                            _offset_BitsPerPixel = Offset_YResolution + 4;
                        }

                        return _offset_BitsPerPixel;
                    }
                }

                private int Offset_VRefresh
                {
                    get
                    {
                        if (_offset_VRefresh == -1)
                        {
                            _offset_VRefresh = Offset_BitsPerPixel + 4;
                        }

                        return _offset_VRefresh;
                    }
                }

                private int Offset_ChipType
                {
                    get
                    {
                        if (_offset_ChipType == -1)
                        {
                            _offset_ChipType = Offset_VRefresh + 4;
                        }

                        return _offset_ChipType;
                    }
                }

                private int Offset_DACType
                {
                    get
                    {
                        if (_offset_DACType == -1)
                        {
                            _offset_DACType = Offset_ChipType + 2;
                        }

                        return _offset_DACType;
                    }
                }

                private int Offset_AdapterString
                {
                    get
                    {
                        if (_offset_AdapterString == -1)
                        {
                            _offset_AdapterString = Offset_DACType + 2;
                        }

                        return _offset_AdapterString;
                    }
                }

                private int Offset_BiosString
                {
                    get
                    {
                        if (_offset_BiosString == -1)
                        {
                            _offset_BiosString = Offset_AdapterString + 2;
                        }

                        return _offset_BiosString;
                    }
                }

                private int Offset_DeviceId
                {
                    get
                    {
                        if (_offset_DeviceId == -1)
                        {
                            _offset_DeviceId = Offset_BiosString + 2;
                        }

                        return _offset_DeviceId;
                    }
                }

                private int Offset_StateFlags
                {
                    get
                    {
                        if (_offset_StateFlags == -1)
                        {
                            _offset_StateFlags = Offset_DeviceId + 2;
                        }

                        return _offset_StateFlags;
                    }
                }

                /// <summary>
                /// Retrieves the MemorySize field.
                /// </summary>
                public uint MemorySize => BitConverter.ToUInt32(_etwEvent.Data[Offset_MemorySize..Offset_XResolution]);

                /// <summary>
                /// Retrieves the XResolution field.
                /// </summary>
                public uint XResolution => BitConverter.ToUInt32(_etwEvent.Data[Offset_XResolution..Offset_YResolution]);

                /// <summary>
                /// Retrieves the YResolution field.
                /// </summary>
                public uint YResolution => BitConverter.ToUInt32(_etwEvent.Data[Offset_YResolution..Offset_BitsPerPixel]);

                /// <summary>
                /// Retrieves the BitsPerPixel field.
                /// </summary>
                public uint BitsPerPixel => BitConverter.ToUInt32(_etwEvent.Data[Offset_BitsPerPixel..Offset_VRefresh]);

                /// <summary>
                /// Retrieves the VRefresh field.
                /// </summary>
                public uint VRefresh => BitConverter.ToUInt32(_etwEvent.Data[Offset_VRefresh..Offset_ChipType]);

                /// <summary>
                /// Retrieves the ChipType field.
                /// </summary>
                public char ChipType => BitConverter.ToChar(_etwEvent.Data[Offset_ChipType..Offset_DACType]);

                /// <summary>
                /// Retrieves the DACType field.
                /// </summary>
                public char DACType => BitConverter.ToChar(_etwEvent.Data[Offset_DACType..Offset_AdapterString]);

                /// <summary>
                /// Retrieves the AdapterString field.
                /// </summary>
                public char AdapterString => BitConverter.ToChar(_etwEvent.Data[Offset_AdapterString..Offset_BiosString]);

                /// <summary>
                /// Retrieves the BiosString field.
                /// </summary>
                public char BiosString => BitConverter.ToChar(_etwEvent.Data[Offset_BiosString..Offset_DeviceId]);

                /// <summary>
                /// Retrieves the DeviceId field.
                /// </summary>
                public char DeviceId => BitConverter.ToChar(_etwEvent.Data[Offset_DeviceId..Offset_StateFlags]);

                /// <summary>
                /// Retrieves the StateFlags field.
                /// </summary>
                public uint StateFlags => BitConverter.ToUInt32(_etwEvent.Data[Offset_StateFlags..]);

                /// <summary>
                /// Creates a new VideoData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public VideoData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_MemorySize = -1;
                    _offset_XResolution = -1;
                    _offset_YResolution = -1;
                    _offset_BitsPerPixel = -1;
                    _offset_VRefresh = -1;
                    _offset_ChipType = -1;
                    _offset_DACType = -1;
                    _offset_AdapterString = -1;
                    _offset_BiosString = -1;
                    _offset_DeviceId = -1;
                    _offset_StateFlags = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Services event.
        /// </summary>
        public readonly ref struct ServicesEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Services";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 0,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.Services,
                Task = 0,
                Keyword = 0
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
            public ServicesData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ServicesEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ServicesEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a ServicesEvent.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator ServicesEvent(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Services event.
            /// </summary>
            public ref struct ServicesData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ServiceName;
                private int _offset_DisplayName;
                private int _offset_ProcessName;
                private int _offset_ProcessId;

                private int Offset_ServiceName
                {
                    get
                    {
                        if (_offset_ServiceName == -1)
                        {
                            _offset_ServiceName = 0;
                        }

                        return _offset_ServiceName;
                    }
                }

                private int Offset_DisplayName
                {
                    get
                    {
                        if (_offset_DisplayName == -1)
                        {
                            _offset_DisplayName = Offset_ServiceName + 2;
                        }

                        return _offset_DisplayName;
                    }
                }

                private int Offset_ProcessName
                {
                    get
                    {
                        if (_offset_ProcessName == -1)
                        {
                            _offset_ProcessName = Offset_DisplayName + 2;
                        }

                        return _offset_ProcessName;
                    }
                }

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = Offset_ProcessName + 2;
                        }

                        return _offset_ProcessId;
                    }
                }

                /// <summary>
                /// Retrieves the ServiceName field.
                /// </summary>
                public char ServiceName => BitConverter.ToChar(_etwEvent.Data[Offset_ServiceName..Offset_DisplayName]);

                /// <summary>
                /// Retrieves the DisplayName field.
                /// </summary>
                public char DisplayName => BitConverter.ToChar(_etwEvent.Data[Offset_DisplayName..Offset_ProcessName]);

                /// <summary>
                /// Retrieves the ProcessName field.
                /// </summary>
                public char ProcessName => BitConverter.ToChar(_etwEvent.Data[Offset_ProcessName..Offset_ProcessId]);

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..]);

                /// <summary>
                /// Creates a new ServicesData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ServicesData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ServiceName = -1;
                    _offset_DisplayName = -1;
                    _offset_ProcessName = -1;
                    _offset_ProcessId = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Power event.
        /// </summary>
        public readonly ref struct PowerEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Power";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 0,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.Power,
                Task = 0,
                Keyword = 0
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
            public PowerData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new PowerEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public PowerEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a PowerEvent.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator PowerEvent(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Power event.
            /// </summary>
            public ref struct PowerData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_S1;
                private int _offset_S2;
                private int _offset_S3;
                private int _offset_S4;
                private int _offset_S5;
                private int _offset_Pad1;
                private int _offset_Pad2;
                private int _offset_Pad3;

                private int Offset_S1
                {
                    get
                    {
                        if (_offset_S1 == -1)
                        {
                            _offset_S1 = 0;
                        }

                        return _offset_S1;
                    }
                }

                private int Offset_S2
                {
                    get
                    {
                        if (_offset_S2 == -1)
                        {
                            _offset_S2 = Offset_S1 + 1;
                        }

                        return _offset_S2;
                    }
                }

                private int Offset_S3
                {
                    get
                    {
                        if (_offset_S3 == -1)
                        {
                            _offset_S3 = Offset_S2 + 1;
                        }

                        return _offset_S3;
                    }
                }

                private int Offset_S4
                {
                    get
                    {
                        if (_offset_S4 == -1)
                        {
                            _offset_S4 = Offset_S3 + 1;
                        }

                        return _offset_S4;
                    }
                }

                private int Offset_S5
                {
                    get
                    {
                        if (_offset_S5 == -1)
                        {
                            _offset_S5 = Offset_S4 + 1;
                        }

                        return _offset_S5;
                    }
                }

                private int Offset_Pad1
                {
                    get
                    {
                        if (_offset_Pad1 == -1)
                        {
                            _offset_Pad1 = Offset_S5 + 1;
                        }

                        return _offset_Pad1;
                    }
                }

                private int Offset_Pad2
                {
                    get
                    {
                        if (_offset_Pad2 == -1)
                        {
                            _offset_Pad2 = Offset_Pad1 + 1;
                        }

                        return _offset_Pad2;
                    }
                }

                private int Offset_Pad3
                {
                    get
                    {
                        if (_offset_Pad3 == -1)
                        {
                            _offset_Pad3 = Offset_Pad2 + 1;
                        }

                        return _offset_Pad3;
                    }
                }

                /// <summary>
                /// Retrieves the S1 field.
                /// </summary>
                public byte S1 => _etwEvent.Data[Offset_S1];

                /// <summary>
                /// Retrieves the S2 field.
                /// </summary>
                public byte S2 => _etwEvent.Data[Offset_S2];

                /// <summary>
                /// Retrieves the S3 field.
                /// </summary>
                public byte S3 => _etwEvent.Data[Offset_S3];

                /// <summary>
                /// Retrieves the S4 field.
                /// </summary>
                public byte S4 => _etwEvent.Data[Offset_S4];

                /// <summary>
                /// Retrieves the S5 field.
                /// </summary>
                public byte S5 => _etwEvent.Data[Offset_S5];

                /// <summary>
                /// Retrieves the Pad1 field.
                /// </summary>
                public byte Pad1 => _etwEvent.Data[Offset_Pad1];

                /// <summary>
                /// Retrieves the Pad2 field.
                /// </summary>
                public byte Pad2 => _etwEvent.Data[Offset_Pad2];

                /// <summary>
                /// Retrieves the Pad3 field.
                /// </summary>
                public byte Pad3 => _etwEvent.Data[Offset_Pad3];

                /// <summary>
                /// Creates a new PowerData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public PowerData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_S1 = -1;
                    _offset_S2 = -1;
                    _offset_S3 = -1;
                    _offset_S4 = -1;
                    _offset_S5 = -1;
                    _offset_Pad1 = -1;
                    _offset_Pad2 = -1;
                    _offset_Pad3 = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a IRQ event.
        /// </summary>
        public readonly ref struct IRQEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "IRQ";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 0,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.IRQ,
                Task = 0,
                Keyword = 0
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
            public IRQData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new IRQEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public IRQEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a IRQEvent.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator IRQEvent(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a IRQ event.
            /// </summary>
            public ref struct IRQData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_IRQAffinity;
                private int _offset_IRQNum;
                private int _offset_DeviceDescriptionLen;
                private int _offset_DeviceDescription;

                private int Offset_IRQAffinity
                {
                    get
                    {
                        if (_offset_IRQAffinity == -1)
                        {
                            _offset_IRQAffinity = 0;
                        }

                        return _offset_IRQAffinity;
                    }
                }

                private int Offset_IRQNum
                {
                    get
                    {
                        if (_offset_IRQNum == -1)
                        {
                            _offset_IRQNum = Offset_IRQAffinity + 8;
                        }

                        return _offset_IRQNum;
                    }
                }

                private int Offset_DeviceDescriptionLen
                {
                    get
                    {
                        if (_offset_DeviceDescriptionLen == -1)
                        {
                            _offset_DeviceDescriptionLen = Offset_IRQNum + 4;
                        }

                        return _offset_DeviceDescriptionLen;
                    }
                }

                private int Offset_DeviceDescription
                {
                    get
                    {
                        if (_offset_DeviceDescription == -1)
                        {
                            _offset_DeviceDescription = Offset_DeviceDescriptionLen + 4;
                        }

                        return _offset_DeviceDescription;
                    }
                }

                /// <summary>
                /// Retrieves the IRQAffinity field.
                /// </summary>
                public ulong IRQAffinity => BitConverter.ToUInt64(_etwEvent.Data[Offset_IRQAffinity..Offset_IRQNum]);

                /// <summary>
                /// Retrieves the IRQNum field.
                /// </summary>
                public uint IRQNum => BitConverter.ToUInt32(_etwEvent.Data[Offset_IRQNum..Offset_DeviceDescriptionLen]);

                /// <summary>
                /// Retrieves the DeviceDescriptionLen field.
                /// </summary>
                public uint DeviceDescriptionLen => BitConverter.ToUInt32(_etwEvent.Data[Offset_DeviceDescriptionLen..Offset_DeviceDescription]);

                /// <summary>
                /// Retrieves the DeviceDescription field.
                /// </summary>
                public string DeviceDescription => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_DeviceDescription..]);

                /// <summary>
                /// Creates a new IRQData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public IRQData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_IRQAffinity = -1;
                    _offset_IRQNum = -1;
                    _offset_DeviceDescriptionLen = -1;
                    _offset_DeviceDescription = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a PnP event.
        /// </summary>
        public readonly ref struct PnPEvent
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "PnP";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 0,
                Version = 0,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.PnP,
                Task = 0,
                Keyword = 0
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
            public PnPData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new PnPEvent.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public PnPEvent(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a PnPEvent.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator PnPEvent(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a PnP event.
            /// </summary>
            public ref struct PnPData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_IDLength;
                private int _offset_DescriptionLength;
                private int _offset_FriendlyNameLength;
                private int _offset_DeviceID;
                private int _offset_DeviceDescription;
                private int _offset_FriendlyName;

                private int Offset_IDLength
                {
                    get
                    {
                        if (_offset_IDLength == -1)
                        {
                            _offset_IDLength = 0;
                        }

                        return _offset_IDLength;
                    }
                }

                private int Offset_DescriptionLength
                {
                    get
                    {
                        if (_offset_DescriptionLength == -1)
                        {
                            _offset_DescriptionLength = Offset_IDLength + 4;
                        }

                        return _offset_DescriptionLength;
                    }
                }

                private int Offset_FriendlyNameLength
                {
                    get
                    {
                        if (_offset_FriendlyNameLength == -1)
                        {
                            _offset_FriendlyNameLength = Offset_DescriptionLength + 4;
                        }

                        return _offset_FriendlyNameLength;
                    }
                }

                private int Offset_DeviceID
                {
                    get
                    {
                        if (_offset_DeviceID == -1)
                        {
                            _offset_DeviceID = Offset_FriendlyNameLength + 4;
                        }

                        return _offset_DeviceID;
                    }
                }

                private int Offset_DeviceDescription
                {
                    get
                    {
                        if (_offset_DeviceDescription == -1)
                        {
                            _offset_DeviceDescription = Offset_DeviceID + _etwEvent.UnicodeStringLength(Offset_DeviceID);
                        }

                        return _offset_DeviceDescription;
                    }
                }

                private int Offset_FriendlyName
                {
                    get
                    {
                        if (_offset_FriendlyName == -1)
                        {
                            _offset_FriendlyName = Offset_DeviceDescription + _etwEvent.UnicodeStringLength(Offset_DeviceDescription);
                        }

                        return _offset_FriendlyName;
                    }
                }

                /// <summary>
                /// Retrieves the IDLength field.
                /// </summary>
                public uint IDLength => BitConverter.ToUInt32(_etwEvent.Data[Offset_IDLength..Offset_DescriptionLength]);

                /// <summary>
                /// Retrieves the DescriptionLength field.
                /// </summary>
                public uint DescriptionLength => BitConverter.ToUInt32(_etwEvent.Data[Offset_DescriptionLength..Offset_FriendlyNameLength]);

                /// <summary>
                /// Retrieves the FriendlyNameLength field.
                /// </summary>
                public uint FriendlyNameLength => BitConverter.ToUInt32(_etwEvent.Data[Offset_FriendlyNameLength..Offset_DeviceID]);

                /// <summary>
                /// Retrieves the DeviceID field.
                /// </summary>
                public string DeviceID => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_DeviceID..Offset_DeviceDescription]);

                /// <summary>
                /// Retrieves the DeviceDescription field.
                /// </summary>
                public string DeviceDescription => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_DeviceDescription..Offset_FriendlyName]);

                /// <summary>
                /// Retrieves the FriendlyName field.
                /// </summary>
                public string FriendlyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FriendlyName..]);

                /// <summary>
                /// Creates a new PnPData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public PnPData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_IDLength = -1;
                    _offset_DescriptionLength = -1;
                    _offset_FriendlyNameLength = -1;
                    _offset_DeviceID = -1;
                    _offset_DeviceDescription = -1;
                    _offset_FriendlyName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a CPU event.
        /// </summary>
        public readonly ref struct CPUEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "CPU";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 0,
                Version = 1,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.CPU,
                Task = 0,
                Keyword = 0
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
            public CPUData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new CPUEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public CPUEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a CPUEventV1.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator CPUEventV1(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a CPU event.
            /// </summary>
            public ref struct CPUData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_MHz;
                private int _offset_NumberOfProcessors;
                private int _offset_MemSize;
                private int _offset_PageSize;
                private int _offset_AllocationGranularity;
                private int _offset_ComputerName;
                private int _offset_DomainName;
                private int _offset_HyperThreadingFlag;

                private int Offset_MHz
                {
                    get
                    {
                        if (_offset_MHz == -1)
                        {
                            _offset_MHz = 0;
                        }

                        return _offset_MHz;
                    }
                }

                private int Offset_NumberOfProcessors
                {
                    get
                    {
                        if (_offset_NumberOfProcessors == -1)
                        {
                            _offset_NumberOfProcessors = Offset_MHz + 4;
                        }

                        return _offset_NumberOfProcessors;
                    }
                }

                private int Offset_MemSize
                {
                    get
                    {
                        if (_offset_MemSize == -1)
                        {
                            _offset_MemSize = Offset_NumberOfProcessors + 4;
                        }

                        return _offset_MemSize;
                    }
                }

                private int Offset_PageSize
                {
                    get
                    {
                        if (_offset_PageSize == -1)
                        {
                            _offset_PageSize = Offset_MemSize + 4;
                        }

                        return _offset_PageSize;
                    }
                }

                private int Offset_AllocationGranularity
                {
                    get
                    {
                        if (_offset_AllocationGranularity == -1)
                        {
                            _offset_AllocationGranularity = Offset_PageSize + 4;
                        }

                        return _offset_AllocationGranularity;
                    }
                }

                private int Offset_ComputerName
                {
                    get
                    {
                        if (_offset_ComputerName == -1)
                        {
                            _offset_ComputerName = Offset_AllocationGranularity + 4;
                        }

                        return _offset_ComputerName;
                    }
                }

                private int Offset_DomainName
                {
                    get
                    {
                        if (_offset_DomainName == -1)
                        {
                            _offset_DomainName = Offset_ComputerName + 2;
                        }

                        return _offset_DomainName;
                    }
                }

                private int Offset_HyperThreadingFlag
                {
                    get
                    {
                        if (_offset_HyperThreadingFlag == -1)
                        {
                            _offset_HyperThreadingFlag = Offset_DomainName + 2;
                        }

                        return _offset_HyperThreadingFlag;
                    }
                }

                /// <summary>
                /// Retrieves the MHz field.
                /// </summary>
                public uint MHz => BitConverter.ToUInt32(_etwEvent.Data[Offset_MHz..Offset_NumberOfProcessors]);

                /// <summary>
                /// Retrieves the NumberOfProcessors field.
                /// </summary>
                public uint NumberOfProcessors => BitConverter.ToUInt32(_etwEvent.Data[Offset_NumberOfProcessors..Offset_MemSize]);

                /// <summary>
                /// Retrieves the MemSize field.
                /// </summary>
                public uint MemSize => BitConverter.ToUInt32(_etwEvent.Data[Offset_MemSize..Offset_PageSize]);

                /// <summary>
                /// Retrieves the PageSize field.
                /// </summary>
                public uint PageSize => BitConverter.ToUInt32(_etwEvent.Data[Offset_PageSize..Offset_AllocationGranularity]);

                /// <summary>
                /// Retrieves the AllocationGranularity field.
                /// </summary>
                public uint AllocationGranularity => BitConverter.ToUInt32(_etwEvent.Data[Offset_AllocationGranularity..Offset_ComputerName]);

                /// <summary>
                /// Retrieves the ComputerName field.
                /// </summary>
                public char ComputerName => BitConverter.ToChar(_etwEvent.Data[Offset_ComputerName..Offset_DomainName]);

                /// <summary>
                /// Retrieves the DomainName field.
                /// </summary>
                public char DomainName => BitConverter.ToChar(_etwEvent.Data[Offset_DomainName..Offset_HyperThreadingFlag]);

                /// <summary>
                /// Retrieves the HyperThreadingFlag field.
                /// </summary>
                public ulong HyperThreadingFlag => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_HyperThreadingFlag..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_HyperThreadingFlag..]);

                /// <summary>
                /// Creates a new CPUData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public CPUData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_MHz = -1;
                    _offset_NumberOfProcessors = -1;
                    _offset_MemSize = -1;
                    _offset_PageSize = -1;
                    _offset_AllocationGranularity = -1;
                    _offset_ComputerName = -1;
                    _offset_DomainName = -1;
                    _offset_HyperThreadingFlag = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a PhyDisk event.
        /// </summary>
        public readonly ref struct PhyDiskEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "PhyDisk";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 0,
                Version = 1,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.PhyDisk,
                Task = 0,
                Keyword = 0
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
            public PhyDiskData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new PhyDiskEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public PhyDiskEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a PhyDiskEventV1.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator PhyDiskEventV1(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a PhyDisk event.
            /// </summary>
            public ref struct PhyDiskData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_DiskNumber;
                private int _offset_BytesPerSector;
                private int _offset_SectorsPerTrack;
                private int _offset_TracksPerCylinder;
                private int _offset_Cylinders;
                private int _offset_SCSIPort;
                private int _offset_SCSIPath;
                private int _offset_SCSITarget;
                private int _offset_SCSILun;
                private int _offset_Manufacturer;
                private int _offset_PartitionCount;
                private int _offset_WriteCacheEnabled;
                private int _offset_Pad;
                private int _offset_BootDriveLetter;
                private int _offset_Spare;

                private int Offset_DiskNumber
                {
                    get
                    {
                        if (_offset_DiskNumber == -1)
                        {
                            _offset_DiskNumber = 0;
                        }

                        return _offset_DiskNumber;
                    }
                }

                private int Offset_BytesPerSector
                {
                    get
                    {
                        if (_offset_BytesPerSector == -1)
                        {
                            _offset_BytesPerSector = Offset_DiskNumber + 4;
                        }

                        return _offset_BytesPerSector;
                    }
                }

                private int Offset_SectorsPerTrack
                {
                    get
                    {
                        if (_offset_SectorsPerTrack == -1)
                        {
                            _offset_SectorsPerTrack = Offset_BytesPerSector + 4;
                        }

                        return _offset_SectorsPerTrack;
                    }
                }

                private int Offset_TracksPerCylinder
                {
                    get
                    {
                        if (_offset_TracksPerCylinder == -1)
                        {
                            _offset_TracksPerCylinder = Offset_SectorsPerTrack + 4;
                        }

                        return _offset_TracksPerCylinder;
                    }
                }

                private int Offset_Cylinders
                {
                    get
                    {
                        if (_offset_Cylinders == -1)
                        {
                            _offset_Cylinders = Offset_TracksPerCylinder + 4;
                        }

                        return _offset_Cylinders;
                    }
                }

                private int Offset_SCSIPort
                {
                    get
                    {
                        if (_offset_SCSIPort == -1)
                        {
                            _offset_SCSIPort = Offset_Cylinders + 8;
                        }

                        return _offset_SCSIPort;
                    }
                }

                private int Offset_SCSIPath
                {
                    get
                    {
                        if (_offset_SCSIPath == -1)
                        {
                            _offset_SCSIPath = Offset_SCSIPort + 4;
                        }

                        return _offset_SCSIPath;
                    }
                }

                private int Offset_SCSITarget
                {
                    get
                    {
                        if (_offset_SCSITarget == -1)
                        {
                            _offset_SCSITarget = Offset_SCSIPath + 4;
                        }

                        return _offset_SCSITarget;
                    }
                }

                private int Offset_SCSILun
                {
                    get
                    {
                        if (_offset_SCSILun == -1)
                        {
                            _offset_SCSILun = Offset_SCSITarget + 4;
                        }

                        return _offset_SCSILun;
                    }
                }

                private int Offset_Manufacturer
                {
                    get
                    {
                        if (_offset_Manufacturer == -1)
                        {
                            _offset_Manufacturer = Offset_SCSILun + 4;
                        }

                        return _offset_Manufacturer;
                    }
                }

                private int Offset_PartitionCount
                {
                    get
                    {
                        if (_offset_PartitionCount == -1)
                        {
                            _offset_PartitionCount = Offset_Manufacturer + 2;
                        }

                        return _offset_PartitionCount;
                    }
                }

                private int Offset_WriteCacheEnabled
                {
                    get
                    {
                        if (_offset_WriteCacheEnabled == -1)
                        {
                            _offset_WriteCacheEnabled = Offset_PartitionCount + 4;
                        }

                        return _offset_WriteCacheEnabled;
                    }
                }

                private int Offset_Pad
                {
                    get
                    {
                        if (_offset_Pad == -1)
                        {
                            _offset_Pad = Offset_WriteCacheEnabled + 1;
                        }

                        return _offset_Pad;
                    }
                }

                private int Offset_BootDriveLetter
                {
                    get
                    {
                        if (_offset_BootDriveLetter == -1)
                        {
                            _offset_BootDriveLetter = Offset_Pad + 1;
                        }

                        return _offset_BootDriveLetter;
                    }
                }

                private int Offset_Spare
                {
                    get
                    {
                        if (_offset_Spare == -1)
                        {
                            _offset_Spare = Offset_BootDriveLetter + 2;
                        }

                        return _offset_Spare;
                    }
                }

                /// <summary>
                /// Retrieves the DiskNumber field.
                /// </summary>
                public uint DiskNumber => BitConverter.ToUInt32(_etwEvent.Data[Offset_DiskNumber..Offset_BytesPerSector]);

                /// <summary>
                /// Retrieves the BytesPerSector field.
                /// </summary>
                public uint BytesPerSector => BitConverter.ToUInt32(_etwEvent.Data[Offset_BytesPerSector..Offset_SectorsPerTrack]);

                /// <summary>
                /// Retrieves the SectorsPerTrack field.
                /// </summary>
                public uint SectorsPerTrack => BitConverter.ToUInt32(_etwEvent.Data[Offset_SectorsPerTrack..Offset_TracksPerCylinder]);

                /// <summary>
                /// Retrieves the TracksPerCylinder field.
                /// </summary>
                public uint TracksPerCylinder => BitConverter.ToUInt32(_etwEvent.Data[Offset_TracksPerCylinder..Offset_Cylinders]);

                /// <summary>
                /// Retrieves the Cylinders field.
                /// </summary>
                public ulong Cylinders => BitConverter.ToUInt64(_etwEvent.Data[Offset_Cylinders..Offset_SCSIPort]);

                /// <summary>
                /// Retrieves the SCSIPort field.
                /// </summary>
                public uint SCSIPort => BitConverter.ToUInt32(_etwEvent.Data[Offset_SCSIPort..Offset_SCSIPath]);

                /// <summary>
                /// Retrieves the SCSIPath field.
                /// </summary>
                public uint SCSIPath => BitConverter.ToUInt32(_etwEvent.Data[Offset_SCSIPath..Offset_SCSITarget]);

                /// <summary>
                /// Retrieves the SCSITarget field.
                /// </summary>
                public uint SCSITarget => BitConverter.ToUInt32(_etwEvent.Data[Offset_SCSITarget..Offset_SCSILun]);

                /// <summary>
                /// Retrieves the SCSILun field.
                /// </summary>
                public uint SCSILun => BitConverter.ToUInt32(_etwEvent.Data[Offset_SCSILun..Offset_Manufacturer]);

                /// <summary>
                /// Retrieves the Manufacturer field.
                /// </summary>
                public char Manufacturer => BitConverter.ToChar(_etwEvent.Data[Offset_Manufacturer..Offset_PartitionCount]);

                /// <summary>
                /// Retrieves the PartitionCount field.
                /// </summary>
                public uint PartitionCount => BitConverter.ToUInt32(_etwEvent.Data[Offset_PartitionCount..Offset_WriteCacheEnabled]);

                /// <summary>
                /// Retrieves the WriteCacheEnabled field.
                /// </summary>
                public byte WriteCacheEnabled => _etwEvent.Data[Offset_WriteCacheEnabled];

                /// <summary>
                /// Retrieves the Pad field.
                /// </summary>
                public byte Pad => _etwEvent.Data[Offset_Pad];

                /// <summary>
                /// Retrieves the BootDriveLetter field.
                /// </summary>
                public char BootDriveLetter => BitConverter.ToChar(_etwEvent.Data[Offset_BootDriveLetter..Offset_Spare]);

                /// <summary>
                /// Retrieves the Spare field.
                /// </summary>
                public char Spare => BitConverter.ToChar(_etwEvent.Data[Offset_Spare..]);

                /// <summary>
                /// Creates a new PhyDiskData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public PhyDiskData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_DiskNumber = -1;
                    _offset_BytesPerSector = -1;
                    _offset_SectorsPerTrack = -1;
                    _offset_TracksPerCylinder = -1;
                    _offset_Cylinders = -1;
                    _offset_SCSIPort = -1;
                    _offset_SCSIPath = -1;
                    _offset_SCSITarget = -1;
                    _offset_SCSILun = -1;
                    _offset_Manufacturer = -1;
                    _offset_PartitionCount = -1;
                    _offset_WriteCacheEnabled = -1;
                    _offset_Pad = -1;
                    _offset_BootDriveLetter = -1;
                    _offset_Spare = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a LogDisk event.
        /// </summary>
        public readonly ref struct LogDiskEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "LogDisk";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 0,
                Version = 1,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.LogDisk,
                Task = 0,
                Keyword = 0
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
            public LogDiskData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new LogDiskEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public LogDiskEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a LogDiskEventV1.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator LogDiskEventV1(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a LogDisk event.
            /// </summary>
            public ref struct LogDiskData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_StartOffset;
                private int _offset_PartitionSize;
                private int _offset_DiskNumber;
                private int _offset_Size;
                private int _offset_DriveType;
                private int _offset_DriveLetterString;
                private int _offset_Pad1;
                private int _offset_PartitionNumber;
                private int _offset_SectorsPerCluster;
                private int _offset_BytesPerSector;
                private int _offset_Pad2;
                private int _offset_NumberOfFreeClusters;
                private int _offset_TotalNumberOfClusters;
                private int _offset_FileSystem;
                private int _offset_VolumeExt;

                private int Offset_StartOffset
                {
                    get
                    {
                        if (_offset_StartOffset == -1)
                        {
                            _offset_StartOffset = 0;
                        }

                        return _offset_StartOffset;
                    }
                }

                private int Offset_PartitionSize
                {
                    get
                    {
                        if (_offset_PartitionSize == -1)
                        {
                            _offset_PartitionSize = Offset_StartOffset + 8;
                        }

                        return _offset_PartitionSize;
                    }
                }

                private int Offset_DiskNumber
                {
                    get
                    {
                        if (_offset_DiskNumber == -1)
                        {
                            _offset_DiskNumber = Offset_PartitionSize + 8;
                        }

                        return _offset_DiskNumber;
                    }
                }

                private int Offset_Size
                {
                    get
                    {
                        if (_offset_Size == -1)
                        {
                            _offset_Size = Offset_DiskNumber + 4;
                        }

                        return _offset_Size;
                    }
                }

                private int Offset_DriveType
                {
                    get
                    {
                        if (_offset_DriveType == -1)
                        {
                            _offset_DriveType = Offset_Size + 4;
                        }

                        return _offset_DriveType;
                    }
                }

                private int Offset_DriveLetterString
                {
                    get
                    {
                        if (_offset_DriveLetterString == -1)
                        {
                            _offset_DriveLetterString = Offset_DriveType + 4;
                        }

                        return _offset_DriveLetterString;
                    }
                }

                private int Offset_Pad1
                {
                    get
                    {
                        if (_offset_Pad1 == -1)
                        {
                            _offset_Pad1 = Offset_DriveLetterString + 2;
                        }

                        return _offset_Pad1;
                    }
                }

                private int Offset_PartitionNumber
                {
                    get
                    {
                        if (_offset_PartitionNumber == -1)
                        {
                            _offset_PartitionNumber = Offset_Pad1 + 4;
                        }

                        return _offset_PartitionNumber;
                    }
                }

                private int Offset_SectorsPerCluster
                {
                    get
                    {
                        if (_offset_SectorsPerCluster == -1)
                        {
                            _offset_SectorsPerCluster = Offset_PartitionNumber + 4;
                        }

                        return _offset_SectorsPerCluster;
                    }
                }

                private int Offset_BytesPerSector
                {
                    get
                    {
                        if (_offset_BytesPerSector == -1)
                        {
                            _offset_BytesPerSector = Offset_SectorsPerCluster + 4;
                        }

                        return _offset_BytesPerSector;
                    }
                }

                private int Offset_Pad2
                {
                    get
                    {
                        if (_offset_Pad2 == -1)
                        {
                            _offset_Pad2 = Offset_BytesPerSector + 4;
                        }

                        return _offset_Pad2;
                    }
                }

                private int Offset_NumberOfFreeClusters
                {
                    get
                    {
                        if (_offset_NumberOfFreeClusters == -1)
                        {
                            _offset_NumberOfFreeClusters = Offset_Pad2 + 4;
                        }

                        return _offset_NumberOfFreeClusters;
                    }
                }

                private int Offset_TotalNumberOfClusters
                {
                    get
                    {
                        if (_offset_TotalNumberOfClusters == -1)
                        {
                            _offset_TotalNumberOfClusters = Offset_NumberOfFreeClusters + 8;
                        }

                        return _offset_TotalNumberOfClusters;
                    }
                }

                private int Offset_FileSystem
                {
                    get
                    {
                        if (_offset_FileSystem == -1)
                        {
                            _offset_FileSystem = Offset_TotalNumberOfClusters + 8;
                        }

                        return _offset_FileSystem;
                    }
                }

                private int Offset_VolumeExt
                {
                    get
                    {
                        if (_offset_VolumeExt == -1)
                        {
                            _offset_VolumeExt = Offset_FileSystem + 2;
                        }

                        return _offset_VolumeExt;
                    }
                }

                /// <summary>
                /// Retrieves the StartOffset field.
                /// </summary>
                public ulong StartOffset => BitConverter.ToUInt64(_etwEvent.Data[Offset_StartOffset..Offset_PartitionSize]);

                /// <summary>
                /// Retrieves the PartitionSize field.
                /// </summary>
                public ulong PartitionSize => BitConverter.ToUInt64(_etwEvent.Data[Offset_PartitionSize..Offset_DiskNumber]);

                /// <summary>
                /// Retrieves the DiskNumber field.
                /// </summary>
                public uint DiskNumber => BitConverter.ToUInt32(_etwEvent.Data[Offset_DiskNumber..Offset_Size]);

                /// <summary>
                /// Retrieves the Size field.
                /// </summary>
                public uint Size => BitConverter.ToUInt32(_etwEvent.Data[Offset_Size..Offset_DriveType]);

                /// <summary>
                /// Retrieves the DriveType field.
                /// </summary>
                public uint DriveType => BitConverter.ToUInt32(_etwEvent.Data[Offset_DriveType..Offset_DriveLetterString]);

                /// <summary>
                /// Retrieves the DriveLetterString field.
                /// </summary>
                public char DriveLetterString => BitConverter.ToChar(_etwEvent.Data[Offset_DriveLetterString..Offset_Pad1]);

                /// <summary>
                /// Retrieves the Pad1 field.
                /// </summary>
                public uint Pad1 => BitConverter.ToUInt32(_etwEvent.Data[Offset_Pad1..Offset_PartitionNumber]);

                /// <summary>
                /// Retrieves the PartitionNumber field.
                /// </summary>
                public uint PartitionNumber => BitConverter.ToUInt32(_etwEvent.Data[Offset_PartitionNumber..Offset_SectorsPerCluster]);

                /// <summary>
                /// Retrieves the SectorsPerCluster field.
                /// </summary>
                public uint SectorsPerCluster => BitConverter.ToUInt32(_etwEvent.Data[Offset_SectorsPerCluster..Offset_BytesPerSector]);

                /// <summary>
                /// Retrieves the BytesPerSector field.
                /// </summary>
                public uint BytesPerSector => BitConverter.ToUInt32(_etwEvent.Data[Offset_BytesPerSector..Offset_Pad2]);

                /// <summary>
                /// Retrieves the Pad2 field.
                /// </summary>
                public uint Pad2 => BitConverter.ToUInt32(_etwEvent.Data[Offset_Pad2..Offset_NumberOfFreeClusters]);

                /// <summary>
                /// Retrieves the NumberOfFreeClusters field.
                /// </summary>
                public long NumberOfFreeClusters => BitConverter.ToInt64(_etwEvent.Data[Offset_NumberOfFreeClusters..Offset_TotalNumberOfClusters]);

                /// <summary>
                /// Retrieves the TotalNumberOfClusters field.
                /// </summary>
                public long TotalNumberOfClusters => BitConverter.ToInt64(_etwEvent.Data[Offset_TotalNumberOfClusters..Offset_FileSystem]);

                /// <summary>
                /// Retrieves the FileSystem field.
                /// </summary>
                public char FileSystem => BitConverter.ToChar(_etwEvent.Data[Offset_FileSystem..Offset_VolumeExt]);

                /// <summary>
                /// Retrieves the VolumeExt field.
                /// </summary>
                public uint VolumeExt => BitConverter.ToUInt32(_etwEvent.Data[Offset_VolumeExt..]);

                /// <summary>
                /// Creates a new LogDiskData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public LogDiskData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_StartOffset = -1;
                    _offset_PartitionSize = -1;
                    _offset_DiskNumber = -1;
                    _offset_Size = -1;
                    _offset_DriveType = -1;
                    _offset_DriveLetterString = -1;
                    _offset_Pad1 = -1;
                    _offset_PartitionNumber = -1;
                    _offset_SectorsPerCluster = -1;
                    _offset_BytesPerSector = -1;
                    _offset_Pad2 = -1;
                    _offset_NumberOfFreeClusters = -1;
                    _offset_TotalNumberOfClusters = -1;
                    _offset_FileSystem = -1;
                    _offset_VolumeExt = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a NIC event.
        /// </summary>
        public readonly ref struct NICEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "NIC";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 0,
                Version = 1,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.NIC,
                Task = 0,
                Keyword = 0
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
            public NICData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new NICEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public NICEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a NICEventV1.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator NICEventV1(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a NIC event.
            /// </summary>
            public ref struct NICData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_NICName;
                private int _offset_Index;
                private int _offset_PhysicalAddrLen;
                private int _offset_PhysicalAddr;
                private int _offset_Size;
                private int _offset_IpAddress;
                private int _offset_SubnetMask;
                private int _offset_DhcpServer;
                private int _offset_Gateway;
                private int _offset_PrimaryWinsServer;
                private int _offset_SecondaryWinsServer;
                private int _offset_DnsServer1;
                private int _offset_DnsServer2;
                private int _offset_DnsServer3;
                private int _offset_DnsServer4;
                private int _offset_Data;

                private int Offset_NICName
                {
                    get
                    {
                        if (_offset_NICName == -1)
                        {
                            _offset_NICName = 0;
                        }

                        return _offset_NICName;
                    }
                }

                private int Offset_Index
                {
                    get
                    {
                        if (_offset_Index == -1)
                        {
                            _offset_Index = Offset_NICName + 2;
                        }

                        return _offset_Index;
                    }
                }

                private int Offset_PhysicalAddrLen
                {
                    get
                    {
                        if (_offset_PhysicalAddrLen == -1)
                        {
                            _offset_PhysicalAddrLen = Offset_Index + 4;
                        }

                        return _offset_PhysicalAddrLen;
                    }
                }

                private int Offset_PhysicalAddr
                {
                    get
                    {
                        if (_offset_PhysicalAddr == -1)
                        {
                            _offset_PhysicalAddr = Offset_PhysicalAddrLen + 4;
                        }

                        return _offset_PhysicalAddr;
                    }
                }

                private int Offset_Size
                {
                    get
                    {
                        if (_offset_Size == -1)
                        {
                            _offset_Size = Offset_PhysicalAddr + 2;
                        }

                        return _offset_Size;
                    }
                }

                private int Offset_IpAddress
                {
                    get
                    {
                        if (_offset_IpAddress == -1)
                        {
                            _offset_IpAddress = Offset_Size + 4;
                        }

                        return _offset_IpAddress;
                    }
                }

                private int Offset_SubnetMask
                {
                    get
                    {
                        if (_offset_SubnetMask == -1)
                        {
                            _offset_SubnetMask = Offset_IpAddress + 4;
                        }

                        return _offset_SubnetMask;
                    }
                }

                private int Offset_DhcpServer
                {
                    get
                    {
                        if (_offset_DhcpServer == -1)
                        {
                            _offset_DhcpServer = Offset_SubnetMask + 4;
                        }

                        return _offset_DhcpServer;
                    }
                }

                private int Offset_Gateway
                {
                    get
                    {
                        if (_offset_Gateway == -1)
                        {
                            _offset_Gateway = Offset_DhcpServer + 4;
                        }

                        return _offset_Gateway;
                    }
                }

                private int Offset_PrimaryWinsServer
                {
                    get
                    {
                        if (_offset_PrimaryWinsServer == -1)
                        {
                            _offset_PrimaryWinsServer = Offset_Gateway + 4;
                        }

                        return _offset_PrimaryWinsServer;
                    }
                }

                private int Offset_SecondaryWinsServer
                {
                    get
                    {
                        if (_offset_SecondaryWinsServer == -1)
                        {
                            _offset_SecondaryWinsServer = Offset_PrimaryWinsServer + 4;
                        }

                        return _offset_SecondaryWinsServer;
                    }
                }

                private int Offset_DnsServer1
                {
                    get
                    {
                        if (_offset_DnsServer1 == -1)
                        {
                            _offset_DnsServer1 = Offset_SecondaryWinsServer + 4;
                        }

                        return _offset_DnsServer1;
                    }
                }

                private int Offset_DnsServer2
                {
                    get
                    {
                        if (_offset_DnsServer2 == -1)
                        {
                            _offset_DnsServer2 = Offset_DnsServer1 + 4;
                        }

                        return _offset_DnsServer2;
                    }
                }

                private int Offset_DnsServer3
                {
                    get
                    {
                        if (_offset_DnsServer3 == -1)
                        {
                            _offset_DnsServer3 = Offset_DnsServer2 + 4;
                        }

                        return _offset_DnsServer3;
                    }
                }

                private int Offset_DnsServer4
                {
                    get
                    {
                        if (_offset_DnsServer4 == -1)
                        {
                            _offset_DnsServer4 = Offset_DnsServer3 + 4;
                        }

                        return _offset_DnsServer4;
                    }
                }

                private int Offset_Data
                {
                    get
                    {
                        if (_offset_Data == -1)
                        {
                            _offset_Data = Offset_DnsServer4 + 4;
                        }

                        return _offset_Data;
                    }
                }

                /// <summary>
                /// Retrieves the NICName field.
                /// </summary>
                public char NICName => BitConverter.ToChar(_etwEvent.Data[Offset_NICName..Offset_Index]);

                /// <summary>
                /// Retrieves the Index field.
                /// </summary>
                public uint Index => BitConverter.ToUInt32(_etwEvent.Data[Offset_Index..Offset_PhysicalAddrLen]);

                /// <summary>
                /// Retrieves the PhysicalAddrLen field.
                /// </summary>
                public uint PhysicalAddrLen => BitConverter.ToUInt32(_etwEvent.Data[Offset_PhysicalAddrLen..Offset_PhysicalAddr]);

                /// <summary>
                /// Retrieves the PhysicalAddr field.
                /// </summary>
                public char PhysicalAddr => BitConverter.ToChar(_etwEvent.Data[Offset_PhysicalAddr..Offset_Size]);

                /// <summary>
                /// Retrieves the Size field.
                /// </summary>
                public uint Size => BitConverter.ToUInt32(_etwEvent.Data[Offset_Size..Offset_IpAddress]);

                /// <summary>
                /// Retrieves the IpAddress field.
                /// </summary>
                public int IpAddress => BitConverter.ToInt32(_etwEvent.Data[Offset_IpAddress..Offset_SubnetMask]);

                /// <summary>
                /// Retrieves the SubnetMask field.
                /// </summary>
                public int SubnetMask => BitConverter.ToInt32(_etwEvent.Data[Offset_SubnetMask..Offset_DhcpServer]);

                /// <summary>
                /// Retrieves the DhcpServer field.
                /// </summary>
                public int DhcpServer => BitConverter.ToInt32(_etwEvent.Data[Offset_DhcpServer..Offset_Gateway]);

                /// <summary>
                /// Retrieves the Gateway field.
                /// </summary>
                public int Gateway => BitConverter.ToInt32(_etwEvent.Data[Offset_Gateway..Offset_PrimaryWinsServer]);

                /// <summary>
                /// Retrieves the PrimaryWinsServer field.
                /// </summary>
                public int PrimaryWinsServer => BitConverter.ToInt32(_etwEvent.Data[Offset_PrimaryWinsServer..Offset_SecondaryWinsServer]);

                /// <summary>
                /// Retrieves the SecondaryWinsServer field.
                /// </summary>
                public int SecondaryWinsServer => BitConverter.ToInt32(_etwEvent.Data[Offset_SecondaryWinsServer..Offset_DnsServer1]);

                /// <summary>
                /// Retrieves the DnsServer1 field.
                /// </summary>
                public int DnsServer1 => BitConverter.ToInt32(_etwEvent.Data[Offset_DnsServer1..Offset_DnsServer2]);

                /// <summary>
                /// Retrieves the DnsServer2 field.
                /// </summary>
                public int DnsServer2 => BitConverter.ToInt32(_etwEvent.Data[Offset_DnsServer2..Offset_DnsServer3]);

                /// <summary>
                /// Retrieves the DnsServer3 field.
                /// </summary>
                public int DnsServer3 => BitConverter.ToInt32(_etwEvent.Data[Offset_DnsServer3..Offset_DnsServer4]);

                /// <summary>
                /// Retrieves the DnsServer4 field.
                /// </summary>
                public int DnsServer4 => BitConverter.ToInt32(_etwEvent.Data[Offset_DnsServer4..Offset_Data]);

                /// <summary>
                /// Retrieves the Data field.
                /// </summary>
                public uint Data => BitConverter.ToUInt32(_etwEvent.Data[Offset_Data..]);

                /// <summary>
                /// Creates a new NICData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public NICData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_NICName = -1;
                    _offset_Index = -1;
                    _offset_PhysicalAddrLen = -1;
                    _offset_PhysicalAddr = -1;
                    _offset_Size = -1;
                    _offset_IpAddress = -1;
                    _offset_SubnetMask = -1;
                    _offset_DhcpServer = -1;
                    _offset_Gateway = -1;
                    _offset_PrimaryWinsServer = -1;
                    _offset_SecondaryWinsServer = -1;
                    _offset_DnsServer1 = -1;
                    _offset_DnsServer2 = -1;
                    _offset_DnsServer3 = -1;
                    _offset_DnsServer4 = -1;
                    _offset_Data = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Video event.
        /// </summary>
        public readonly ref struct VideoEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Video";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 0,
                Version = 1,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.Video,
                Task = 0,
                Keyword = 0
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
            public VideoData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new VideoEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public VideoEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a VideoEventV1.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator VideoEventV1(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Video event.
            /// </summary>
            public ref struct VideoData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_MemorySize;
                private int _offset_XResolution;
                private int _offset_YResolution;
                private int _offset_BitsPerPixel;
                private int _offset_VRefresh;
                private int _offset_ChipType;
                private int _offset_DACType;
                private int _offset_AdapterString;
                private int _offset_BiosString;
                private int _offset_DeviceId;
                private int _offset_StateFlags;

                private int Offset_MemorySize
                {
                    get
                    {
                        if (_offset_MemorySize == -1)
                        {
                            _offset_MemorySize = 0;
                        }

                        return _offset_MemorySize;
                    }
                }

                private int Offset_XResolution
                {
                    get
                    {
                        if (_offset_XResolution == -1)
                        {
                            _offset_XResolution = Offset_MemorySize + 4;
                        }

                        return _offset_XResolution;
                    }
                }

                private int Offset_YResolution
                {
                    get
                    {
                        if (_offset_YResolution == -1)
                        {
                            _offset_YResolution = Offset_XResolution + 4;
                        }

                        return _offset_YResolution;
                    }
                }

                private int Offset_BitsPerPixel
                {
                    get
                    {
                        if (_offset_BitsPerPixel == -1)
                        {
                            _offset_BitsPerPixel = Offset_YResolution + 4;
                        }

                        return _offset_BitsPerPixel;
                    }
                }

                private int Offset_VRefresh
                {
                    get
                    {
                        if (_offset_VRefresh == -1)
                        {
                            _offset_VRefresh = Offset_BitsPerPixel + 4;
                        }

                        return _offset_VRefresh;
                    }
                }

                private int Offset_ChipType
                {
                    get
                    {
                        if (_offset_ChipType == -1)
                        {
                            _offset_ChipType = Offset_VRefresh + 4;
                        }

                        return _offset_ChipType;
                    }
                }

                private int Offset_DACType
                {
                    get
                    {
                        if (_offset_DACType == -1)
                        {
                            _offset_DACType = Offset_ChipType + 2;
                        }

                        return _offset_DACType;
                    }
                }

                private int Offset_AdapterString
                {
                    get
                    {
                        if (_offset_AdapterString == -1)
                        {
                            _offset_AdapterString = Offset_DACType + 2;
                        }

                        return _offset_AdapterString;
                    }
                }

                private int Offset_BiosString
                {
                    get
                    {
                        if (_offset_BiosString == -1)
                        {
                            _offset_BiosString = Offset_AdapterString + 2;
                        }

                        return _offset_BiosString;
                    }
                }

                private int Offset_DeviceId
                {
                    get
                    {
                        if (_offset_DeviceId == -1)
                        {
                            _offset_DeviceId = Offset_BiosString + 2;
                        }

                        return _offset_DeviceId;
                    }
                }

                private int Offset_StateFlags
                {
                    get
                    {
                        if (_offset_StateFlags == -1)
                        {
                            _offset_StateFlags = Offset_DeviceId + 2;
                        }

                        return _offset_StateFlags;
                    }
                }

                /// <summary>
                /// Retrieves the MemorySize field.
                /// </summary>
                public uint MemorySize => BitConverter.ToUInt32(_etwEvent.Data[Offset_MemorySize..Offset_XResolution]);

                /// <summary>
                /// Retrieves the XResolution field.
                /// </summary>
                public uint XResolution => BitConverter.ToUInt32(_etwEvent.Data[Offset_XResolution..Offset_YResolution]);

                /// <summary>
                /// Retrieves the YResolution field.
                /// </summary>
                public uint YResolution => BitConverter.ToUInt32(_etwEvent.Data[Offset_YResolution..Offset_BitsPerPixel]);

                /// <summary>
                /// Retrieves the BitsPerPixel field.
                /// </summary>
                public uint BitsPerPixel => BitConverter.ToUInt32(_etwEvent.Data[Offset_BitsPerPixel..Offset_VRefresh]);

                /// <summary>
                /// Retrieves the VRefresh field.
                /// </summary>
                public uint VRefresh => BitConverter.ToUInt32(_etwEvent.Data[Offset_VRefresh..Offset_ChipType]);

                /// <summary>
                /// Retrieves the ChipType field.
                /// </summary>
                public char ChipType => BitConverter.ToChar(_etwEvent.Data[Offset_ChipType..Offset_DACType]);

                /// <summary>
                /// Retrieves the DACType field.
                /// </summary>
                public char DACType => BitConverter.ToChar(_etwEvent.Data[Offset_DACType..Offset_AdapterString]);

                /// <summary>
                /// Retrieves the AdapterString field.
                /// </summary>
                public char AdapterString => BitConverter.ToChar(_etwEvent.Data[Offset_AdapterString..Offset_BiosString]);

                /// <summary>
                /// Retrieves the BiosString field.
                /// </summary>
                public char BiosString => BitConverter.ToChar(_etwEvent.Data[Offset_BiosString..Offset_DeviceId]);

                /// <summary>
                /// Retrieves the DeviceId field.
                /// </summary>
                public char DeviceId => BitConverter.ToChar(_etwEvent.Data[Offset_DeviceId..Offset_StateFlags]);

                /// <summary>
                /// Retrieves the StateFlags field.
                /// </summary>
                public uint StateFlags => BitConverter.ToUInt32(_etwEvent.Data[Offset_StateFlags..]);

                /// <summary>
                /// Creates a new VideoData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public VideoData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_MemorySize = -1;
                    _offset_XResolution = -1;
                    _offset_YResolution = -1;
                    _offset_BitsPerPixel = -1;
                    _offset_VRefresh = -1;
                    _offset_ChipType = -1;
                    _offset_DACType = -1;
                    _offset_AdapterString = -1;
                    _offset_BiosString = -1;
                    _offset_DeviceId = -1;
                    _offset_StateFlags = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Services event.
        /// </summary>
        public readonly ref struct ServicesEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Services";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 0,
                Version = 1,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.Services,
                Task = 0,
                Keyword = 0
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
            public ServicesData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ServicesEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ServicesEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a ServicesEventV1.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator ServicesEventV1(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Services event.
            /// </summary>
            public ref struct ServicesData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ServiceName;
                private int _offset_DisplayName;
                private int _offset_ProcessName;
                private int _offset_ProcessId;

                private int Offset_ServiceName
                {
                    get
                    {
                        if (_offset_ServiceName == -1)
                        {
                            _offset_ServiceName = 0;
                        }

                        return _offset_ServiceName;
                    }
                }

                private int Offset_DisplayName
                {
                    get
                    {
                        if (_offset_DisplayName == -1)
                        {
                            _offset_DisplayName = Offset_ServiceName + 2;
                        }

                        return _offset_DisplayName;
                    }
                }

                private int Offset_ProcessName
                {
                    get
                    {
                        if (_offset_ProcessName == -1)
                        {
                            _offset_ProcessName = Offset_DisplayName + 2;
                        }

                        return _offset_ProcessName;
                    }
                }

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = Offset_ProcessName + 2;
                        }

                        return _offset_ProcessId;
                    }
                }

                /// <summary>
                /// Retrieves the ServiceName field.
                /// </summary>
                public char ServiceName => BitConverter.ToChar(_etwEvent.Data[Offset_ServiceName..Offset_DisplayName]);

                /// <summary>
                /// Retrieves the DisplayName field.
                /// </summary>
                public char DisplayName => BitConverter.ToChar(_etwEvent.Data[Offset_DisplayName..Offset_ProcessName]);

                /// <summary>
                /// Retrieves the ProcessName field.
                /// </summary>
                public char ProcessName => BitConverter.ToChar(_etwEvent.Data[Offset_ProcessName..Offset_ProcessId]);

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..]);

                /// <summary>
                /// Creates a new ServicesData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ServicesData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ServiceName = -1;
                    _offset_DisplayName = -1;
                    _offset_ProcessName = -1;
                    _offset_ProcessId = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Power event.
        /// </summary>
        public readonly ref struct PowerEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Power";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 0,
                Version = 1,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.Power,
                Task = 0,
                Keyword = 0
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
            public PowerData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new PowerEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public PowerEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a PowerEventV1.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator PowerEventV1(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Power event.
            /// </summary>
            public ref struct PowerData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_S1;
                private int _offset_S2;
                private int _offset_S3;
                private int _offset_S4;
                private int _offset_S5;
                private int _offset_Pad1;
                private int _offset_Pad2;
                private int _offset_Pad3;

                private int Offset_S1
                {
                    get
                    {
                        if (_offset_S1 == -1)
                        {
                            _offset_S1 = 0;
                        }

                        return _offset_S1;
                    }
                }

                private int Offset_S2
                {
                    get
                    {
                        if (_offset_S2 == -1)
                        {
                            _offset_S2 = Offset_S1 + 1;
                        }

                        return _offset_S2;
                    }
                }

                private int Offset_S3
                {
                    get
                    {
                        if (_offset_S3 == -1)
                        {
                            _offset_S3 = Offset_S2 + 1;
                        }

                        return _offset_S3;
                    }
                }

                private int Offset_S4
                {
                    get
                    {
                        if (_offset_S4 == -1)
                        {
                            _offset_S4 = Offset_S3 + 1;
                        }

                        return _offset_S4;
                    }
                }

                private int Offset_S5
                {
                    get
                    {
                        if (_offset_S5 == -1)
                        {
                            _offset_S5 = Offset_S4 + 1;
                        }

                        return _offset_S5;
                    }
                }

                private int Offset_Pad1
                {
                    get
                    {
                        if (_offset_Pad1 == -1)
                        {
                            _offset_Pad1 = Offset_S5 + 1;
                        }

                        return _offset_Pad1;
                    }
                }

                private int Offset_Pad2
                {
                    get
                    {
                        if (_offset_Pad2 == -1)
                        {
                            _offset_Pad2 = Offset_Pad1 + 1;
                        }

                        return _offset_Pad2;
                    }
                }

                private int Offset_Pad3
                {
                    get
                    {
                        if (_offset_Pad3 == -1)
                        {
                            _offset_Pad3 = Offset_Pad2 + 1;
                        }

                        return _offset_Pad3;
                    }
                }

                /// <summary>
                /// Retrieves the S1 field.
                /// </summary>
                public byte S1 => _etwEvent.Data[Offset_S1];

                /// <summary>
                /// Retrieves the S2 field.
                /// </summary>
                public byte S2 => _etwEvent.Data[Offset_S2];

                /// <summary>
                /// Retrieves the S3 field.
                /// </summary>
                public byte S3 => _etwEvent.Data[Offset_S3];

                /// <summary>
                /// Retrieves the S4 field.
                /// </summary>
                public byte S4 => _etwEvent.Data[Offset_S4];

                /// <summary>
                /// Retrieves the S5 field.
                /// </summary>
                public byte S5 => _etwEvent.Data[Offset_S5];

                /// <summary>
                /// Retrieves the Pad1 field.
                /// </summary>
                public byte Pad1 => _etwEvent.Data[Offset_Pad1];

                /// <summary>
                /// Retrieves the Pad2 field.
                /// </summary>
                public byte Pad2 => _etwEvent.Data[Offset_Pad2];

                /// <summary>
                /// Retrieves the Pad3 field.
                /// </summary>
                public byte Pad3 => _etwEvent.Data[Offset_Pad3];

                /// <summary>
                /// Creates a new PowerData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public PowerData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_S1 = -1;
                    _offset_S2 = -1;
                    _offset_S3 = -1;
                    _offset_S4 = -1;
                    _offset_S5 = -1;
                    _offset_Pad1 = -1;
                    _offset_Pad2 = -1;
                    _offset_Pad3 = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a IRQ event.
        /// </summary>
        public readonly ref struct IRQEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "IRQ";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 0,
                Version = 1,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.IRQ,
                Task = 0,
                Keyword = 0
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
            public IRQData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new IRQEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public IRQEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a IRQEventV1.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator IRQEventV1(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a IRQ event.
            /// </summary>
            public ref struct IRQData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_IRQAffinity;
                private int _offset_IRQNum;
                private int _offset_DeviceDescriptionLen;
                private int _offset_DeviceDescription;

                private int Offset_IRQAffinity
                {
                    get
                    {
                        if (_offset_IRQAffinity == -1)
                        {
                            _offset_IRQAffinity = 0;
                        }

                        return _offset_IRQAffinity;
                    }
                }

                private int Offset_IRQNum
                {
                    get
                    {
                        if (_offset_IRQNum == -1)
                        {
                            _offset_IRQNum = Offset_IRQAffinity + 8;
                        }

                        return _offset_IRQNum;
                    }
                }

                private int Offset_DeviceDescriptionLen
                {
                    get
                    {
                        if (_offset_DeviceDescriptionLen == -1)
                        {
                            _offset_DeviceDescriptionLen = Offset_IRQNum + 4;
                        }

                        return _offset_DeviceDescriptionLen;
                    }
                }

                private int Offset_DeviceDescription
                {
                    get
                    {
                        if (_offset_DeviceDescription == -1)
                        {
                            _offset_DeviceDescription = Offset_DeviceDescriptionLen + 4;
                        }

                        return _offset_DeviceDescription;
                    }
                }

                /// <summary>
                /// Retrieves the IRQAffinity field.
                /// </summary>
                public ulong IRQAffinity => BitConverter.ToUInt64(_etwEvent.Data[Offset_IRQAffinity..Offset_IRQNum]);

                /// <summary>
                /// Retrieves the IRQNum field.
                /// </summary>
                public uint IRQNum => BitConverter.ToUInt32(_etwEvent.Data[Offset_IRQNum..Offset_DeviceDescriptionLen]);

                /// <summary>
                /// Retrieves the DeviceDescriptionLen field.
                /// </summary>
                public uint DeviceDescriptionLen => BitConverter.ToUInt32(_etwEvent.Data[Offset_DeviceDescriptionLen..Offset_DeviceDescription]);

                /// <summary>
                /// Retrieves the DeviceDescription field.
                /// </summary>
                public string DeviceDescription => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_DeviceDescription..]);

                /// <summary>
                /// Creates a new IRQData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public IRQData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_IRQAffinity = -1;
                    _offset_IRQNum = -1;
                    _offset_DeviceDescriptionLen = -1;
                    _offset_DeviceDescription = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a PnP event.
        /// </summary>
        public readonly ref struct PnPEventV1
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "PnP";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 0,
                Version = 1,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.PnP,
                Task = 0,
                Keyword = 0
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
            public PnPData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new PnPEventV1.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public PnPEventV1(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a PnPEventV1.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator PnPEventV1(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a PnP event.
            /// </summary>
            public ref struct PnPData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_IDLength;
                private int _offset_DescriptionLength;
                private int _offset_FriendlyNameLength;
                private int _offset_DeviceID;
                private int _offset_DeviceDescription;
                private int _offset_FriendlyName;

                private int Offset_IDLength
                {
                    get
                    {
                        if (_offset_IDLength == -1)
                        {
                            _offset_IDLength = 0;
                        }

                        return _offset_IDLength;
                    }
                }

                private int Offset_DescriptionLength
                {
                    get
                    {
                        if (_offset_DescriptionLength == -1)
                        {
                            _offset_DescriptionLength = Offset_IDLength + 4;
                        }

                        return _offset_DescriptionLength;
                    }
                }

                private int Offset_FriendlyNameLength
                {
                    get
                    {
                        if (_offset_FriendlyNameLength == -1)
                        {
                            _offset_FriendlyNameLength = Offset_DescriptionLength + 4;
                        }

                        return _offset_FriendlyNameLength;
                    }
                }

                private int Offset_DeviceID
                {
                    get
                    {
                        if (_offset_DeviceID == -1)
                        {
                            _offset_DeviceID = Offset_FriendlyNameLength + 4;
                        }

                        return _offset_DeviceID;
                    }
                }

                private int Offset_DeviceDescription
                {
                    get
                    {
                        if (_offset_DeviceDescription == -1)
                        {
                            _offset_DeviceDescription = Offset_DeviceID + _etwEvent.UnicodeStringLength(Offset_DeviceID);
                        }

                        return _offset_DeviceDescription;
                    }
                }

                private int Offset_FriendlyName
                {
                    get
                    {
                        if (_offset_FriendlyName == -1)
                        {
                            _offset_FriendlyName = Offset_DeviceDescription + _etwEvent.UnicodeStringLength(Offset_DeviceDescription);
                        }

                        return _offset_FriendlyName;
                    }
                }

                /// <summary>
                /// Retrieves the IDLength field.
                /// </summary>
                public uint IDLength => BitConverter.ToUInt32(_etwEvent.Data[Offset_IDLength..Offset_DescriptionLength]);

                /// <summary>
                /// Retrieves the DescriptionLength field.
                /// </summary>
                public uint DescriptionLength => BitConverter.ToUInt32(_etwEvent.Data[Offset_DescriptionLength..Offset_FriendlyNameLength]);

                /// <summary>
                /// Retrieves the FriendlyNameLength field.
                /// </summary>
                public uint FriendlyNameLength => BitConverter.ToUInt32(_etwEvent.Data[Offset_FriendlyNameLength..Offset_DeviceID]);

                /// <summary>
                /// Retrieves the DeviceID field.
                /// </summary>
                public string DeviceID => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_DeviceID..Offset_DeviceDescription]);

                /// <summary>
                /// Retrieves the DeviceDescription field.
                /// </summary>
                public string DeviceDescription => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_DeviceDescription..Offset_FriendlyName]);

                /// <summary>
                /// Retrieves the FriendlyName field.
                /// </summary>
                public string FriendlyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FriendlyName..]);

                /// <summary>
                /// Creates a new PnPData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public PnPData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_IDLength = -1;
                    _offset_DescriptionLength = -1;
                    _offset_FriendlyNameLength = -1;
                    _offset_DeviceID = -1;
                    _offset_DeviceDescription = -1;
                    _offset_FriendlyName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a CPU event.
        /// </summary>
        public readonly ref struct CPUEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "CPU";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 0,
                Version = 2,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.CPU,
                Task = 0,
                Keyword = 0
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
            public CPUData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new CPUEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public CPUEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a CPUEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator CPUEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a CPU event.
            /// </summary>
            public ref struct CPUData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_MHz;
                private int _offset_NumberOfProcessors;
                private int _offset_MemSize;
                private int _offset_PageSize;
                private int _offset_AllocationGranularity;
                private int _offset_ComputerName;
                private int _offset_DomainName;
                private int _offset_HyperThreadingFlag;

                private int Offset_MHz
                {
                    get
                    {
                        if (_offset_MHz == -1)
                        {
                            _offset_MHz = 0;
                        }

                        return _offset_MHz;
                    }
                }

                private int Offset_NumberOfProcessors
                {
                    get
                    {
                        if (_offset_NumberOfProcessors == -1)
                        {
                            _offset_NumberOfProcessors = Offset_MHz + 4;
                        }

                        return _offset_NumberOfProcessors;
                    }
                }

                private int Offset_MemSize
                {
                    get
                    {
                        if (_offset_MemSize == -1)
                        {
                            _offset_MemSize = Offset_NumberOfProcessors + 4;
                        }

                        return _offset_MemSize;
                    }
                }

                private int Offset_PageSize
                {
                    get
                    {
                        if (_offset_PageSize == -1)
                        {
                            _offset_PageSize = Offset_MemSize + 4;
                        }

                        return _offset_PageSize;
                    }
                }

                private int Offset_AllocationGranularity
                {
                    get
                    {
                        if (_offset_AllocationGranularity == -1)
                        {
                            _offset_AllocationGranularity = Offset_PageSize + 4;
                        }

                        return _offset_AllocationGranularity;
                    }
                }

                private int Offset_ComputerName
                {
                    get
                    {
                        if (_offset_ComputerName == -1)
                        {
                            _offset_ComputerName = Offset_AllocationGranularity + 4;
                        }

                        return _offset_ComputerName;
                    }
                }

                private int Offset_DomainName
                {
                    get
                    {
                        if (_offset_DomainName == -1)
                        {
                            _offset_DomainName = Offset_ComputerName + 2;
                        }

                        return _offset_DomainName;
                    }
                }

                private int Offset_HyperThreadingFlag
                {
                    get
                    {
                        if (_offset_HyperThreadingFlag == -1)
                        {
                            _offset_HyperThreadingFlag = Offset_DomainName + 2;
                        }

                        return _offset_HyperThreadingFlag;
                    }
                }

                /// <summary>
                /// Retrieves the MHz field.
                /// </summary>
                public uint MHz => BitConverter.ToUInt32(_etwEvent.Data[Offset_MHz..Offset_NumberOfProcessors]);

                /// <summary>
                /// Retrieves the NumberOfProcessors field.
                /// </summary>
                public uint NumberOfProcessors => BitConverter.ToUInt32(_etwEvent.Data[Offset_NumberOfProcessors..Offset_MemSize]);

                /// <summary>
                /// Retrieves the MemSize field.
                /// </summary>
                public uint MemSize => BitConverter.ToUInt32(_etwEvent.Data[Offset_MemSize..Offset_PageSize]);

                /// <summary>
                /// Retrieves the PageSize field.
                /// </summary>
                public uint PageSize => BitConverter.ToUInt32(_etwEvent.Data[Offset_PageSize..Offset_AllocationGranularity]);

                /// <summary>
                /// Retrieves the AllocationGranularity field.
                /// </summary>
                public uint AllocationGranularity => BitConverter.ToUInt32(_etwEvent.Data[Offset_AllocationGranularity..Offset_ComputerName]);

                /// <summary>
                /// Retrieves the ComputerName field.
                /// </summary>
                public char ComputerName => BitConverter.ToChar(_etwEvent.Data[Offset_ComputerName..Offset_DomainName]);

                /// <summary>
                /// Retrieves the DomainName field.
                /// </summary>
                public char DomainName => BitConverter.ToChar(_etwEvent.Data[Offset_DomainName..Offset_HyperThreadingFlag]);

                /// <summary>
                /// Retrieves the HyperThreadingFlag field.
                /// </summary>
                public ulong HyperThreadingFlag => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_HyperThreadingFlag..]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_HyperThreadingFlag..]);

                /// <summary>
                /// Creates a new CPUData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public CPUData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_MHz = -1;
                    _offset_NumberOfProcessors = -1;
                    _offset_MemSize = -1;
                    _offset_PageSize = -1;
                    _offset_AllocationGranularity = -1;
                    _offset_ComputerName = -1;
                    _offset_DomainName = -1;
                    _offset_HyperThreadingFlag = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a PhyDisk event.
        /// </summary>
        public readonly ref struct PhyDiskEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "PhyDisk";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 0,
                Version = 2,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.PhyDisk,
                Task = 0,
                Keyword = 0
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
            public PhyDiskData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new PhyDiskEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public PhyDiskEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a PhyDiskEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator PhyDiskEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a PhyDisk event.
            /// </summary>
            public ref struct PhyDiskData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_DiskNumber;
                private int _offset_BytesPerSector;
                private int _offset_SectorsPerTrack;
                private int _offset_TracksPerCylinder;
                private int _offset_Cylinders;
                private int _offset_SCSIPort;
                private int _offset_SCSIPath;
                private int _offset_SCSITarget;
                private int _offset_SCSILun;
                private int _offset_Manufacturer;
                private int _offset_PartitionCount;
                private int _offset_WriteCacheEnabled;
                private int _offset_Pad;
                private int _offset_BootDriveLetter;
                private int _offset_Spare;

                private int Offset_DiskNumber
                {
                    get
                    {
                        if (_offset_DiskNumber == -1)
                        {
                            _offset_DiskNumber = 0;
                        }

                        return _offset_DiskNumber;
                    }
                }

                private int Offset_BytesPerSector
                {
                    get
                    {
                        if (_offset_BytesPerSector == -1)
                        {
                            _offset_BytesPerSector = Offset_DiskNumber + 4;
                        }

                        return _offset_BytesPerSector;
                    }
                }

                private int Offset_SectorsPerTrack
                {
                    get
                    {
                        if (_offset_SectorsPerTrack == -1)
                        {
                            _offset_SectorsPerTrack = Offset_BytesPerSector + 4;
                        }

                        return _offset_SectorsPerTrack;
                    }
                }

                private int Offset_TracksPerCylinder
                {
                    get
                    {
                        if (_offset_TracksPerCylinder == -1)
                        {
                            _offset_TracksPerCylinder = Offset_SectorsPerTrack + 4;
                        }

                        return _offset_TracksPerCylinder;
                    }
                }

                private int Offset_Cylinders
                {
                    get
                    {
                        if (_offset_Cylinders == -1)
                        {
                            _offset_Cylinders = Offset_TracksPerCylinder + 4;
                        }

                        return _offset_Cylinders;
                    }
                }

                private int Offset_SCSIPort
                {
                    get
                    {
                        if (_offset_SCSIPort == -1)
                        {
                            _offset_SCSIPort = Offset_Cylinders + 8;
                        }

                        return _offset_SCSIPort;
                    }
                }

                private int Offset_SCSIPath
                {
                    get
                    {
                        if (_offset_SCSIPath == -1)
                        {
                            _offset_SCSIPath = Offset_SCSIPort + 4;
                        }

                        return _offset_SCSIPath;
                    }
                }

                private int Offset_SCSITarget
                {
                    get
                    {
                        if (_offset_SCSITarget == -1)
                        {
                            _offset_SCSITarget = Offset_SCSIPath + 4;
                        }

                        return _offset_SCSITarget;
                    }
                }

                private int Offset_SCSILun
                {
                    get
                    {
                        if (_offset_SCSILun == -1)
                        {
                            _offset_SCSILun = Offset_SCSITarget + 4;
                        }

                        return _offset_SCSILun;
                    }
                }

                private int Offset_Manufacturer
                {
                    get
                    {
                        if (_offset_Manufacturer == -1)
                        {
                            _offset_Manufacturer = Offset_SCSILun + 4;
                        }

                        return _offset_Manufacturer;
                    }
                }

                private int Offset_PartitionCount
                {
                    get
                    {
                        if (_offset_PartitionCount == -1)
                        {
                            _offset_PartitionCount = Offset_Manufacturer + 2;
                        }

                        return _offset_PartitionCount;
                    }
                }

                private int Offset_WriteCacheEnabled
                {
                    get
                    {
                        if (_offset_WriteCacheEnabled == -1)
                        {
                            _offset_WriteCacheEnabled = Offset_PartitionCount + 4;
                        }

                        return _offset_WriteCacheEnabled;
                    }
                }

                private int Offset_Pad
                {
                    get
                    {
                        if (_offset_Pad == -1)
                        {
                            _offset_Pad = Offset_WriteCacheEnabled + 1;
                        }

                        return _offset_Pad;
                    }
                }

                private int Offset_BootDriveLetter
                {
                    get
                    {
                        if (_offset_BootDriveLetter == -1)
                        {
                            _offset_BootDriveLetter = Offset_Pad + 1;
                        }

                        return _offset_BootDriveLetter;
                    }
                }

                private int Offset_Spare
                {
                    get
                    {
                        if (_offset_Spare == -1)
                        {
                            _offset_Spare = Offset_BootDriveLetter + 2;
                        }

                        return _offset_Spare;
                    }
                }

                /// <summary>
                /// Retrieves the DiskNumber field.
                /// </summary>
                public uint DiskNumber => BitConverter.ToUInt32(_etwEvent.Data[Offset_DiskNumber..Offset_BytesPerSector]);

                /// <summary>
                /// Retrieves the BytesPerSector field.
                /// </summary>
                public uint BytesPerSector => BitConverter.ToUInt32(_etwEvent.Data[Offset_BytesPerSector..Offset_SectorsPerTrack]);

                /// <summary>
                /// Retrieves the SectorsPerTrack field.
                /// </summary>
                public uint SectorsPerTrack => BitConverter.ToUInt32(_etwEvent.Data[Offset_SectorsPerTrack..Offset_TracksPerCylinder]);

                /// <summary>
                /// Retrieves the TracksPerCylinder field.
                /// </summary>
                public uint TracksPerCylinder => BitConverter.ToUInt32(_etwEvent.Data[Offset_TracksPerCylinder..Offset_Cylinders]);

                /// <summary>
                /// Retrieves the Cylinders field.
                /// </summary>
                public ulong Cylinders => BitConverter.ToUInt64(_etwEvent.Data[Offset_Cylinders..Offset_SCSIPort]);

                /// <summary>
                /// Retrieves the SCSIPort field.
                /// </summary>
                public uint SCSIPort => BitConverter.ToUInt32(_etwEvent.Data[Offset_SCSIPort..Offset_SCSIPath]);

                /// <summary>
                /// Retrieves the SCSIPath field.
                /// </summary>
                public uint SCSIPath => BitConverter.ToUInt32(_etwEvent.Data[Offset_SCSIPath..Offset_SCSITarget]);

                /// <summary>
                /// Retrieves the SCSITarget field.
                /// </summary>
                public uint SCSITarget => BitConverter.ToUInt32(_etwEvent.Data[Offset_SCSITarget..Offset_SCSILun]);

                /// <summary>
                /// Retrieves the SCSILun field.
                /// </summary>
                public uint SCSILun => BitConverter.ToUInt32(_etwEvent.Data[Offset_SCSILun..Offset_Manufacturer]);

                /// <summary>
                /// Retrieves the Manufacturer field.
                /// </summary>
                public char Manufacturer => BitConverter.ToChar(_etwEvent.Data[Offset_Manufacturer..Offset_PartitionCount]);

                /// <summary>
                /// Retrieves the PartitionCount field.
                /// </summary>
                public uint PartitionCount => BitConverter.ToUInt32(_etwEvent.Data[Offset_PartitionCount..Offset_WriteCacheEnabled]);

                /// <summary>
                /// Retrieves the WriteCacheEnabled field.
                /// </summary>
                public byte WriteCacheEnabled => _etwEvent.Data[Offset_WriteCacheEnabled];

                /// <summary>
                /// Retrieves the Pad field.
                /// </summary>
                public byte Pad => _etwEvent.Data[Offset_Pad];

                /// <summary>
                /// Retrieves the BootDriveLetter field.
                /// </summary>
                public char BootDriveLetter => BitConverter.ToChar(_etwEvent.Data[Offset_BootDriveLetter..Offset_Spare]);

                /// <summary>
                /// Retrieves the Spare field.
                /// </summary>
                public char Spare => BitConverter.ToChar(_etwEvent.Data[Offset_Spare..]);

                /// <summary>
                /// Creates a new PhyDiskData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public PhyDiskData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_DiskNumber = -1;
                    _offset_BytesPerSector = -1;
                    _offset_SectorsPerTrack = -1;
                    _offset_TracksPerCylinder = -1;
                    _offset_Cylinders = -1;
                    _offset_SCSIPort = -1;
                    _offset_SCSIPath = -1;
                    _offset_SCSITarget = -1;
                    _offset_SCSILun = -1;
                    _offset_Manufacturer = -1;
                    _offset_PartitionCount = -1;
                    _offset_WriteCacheEnabled = -1;
                    _offset_Pad = -1;
                    _offset_BootDriveLetter = -1;
                    _offset_Spare = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a LogDisk event.
        /// </summary>
        public readonly ref struct LogDiskEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "LogDisk";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 0,
                Version = 2,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.LogDisk,
                Task = 0,
                Keyword = 0
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
            public LogDiskData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new LogDiskEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public LogDiskEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a LogDiskEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator LogDiskEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a LogDisk event.
            /// </summary>
            public ref struct LogDiskData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_StartOffset;
                private int _offset_PartitionSize;
                private int _offset_DiskNumber;
                private int _offset_Size;
                private int _offset_DriveType;
                private int _offset_DriveLetterString;
                private int _offset_Pad1;
                private int _offset_PartitionNumber;
                private int _offset_SectorsPerCluster;
                private int _offset_BytesPerSector;
                private int _offset_Pad2;
                private int _offset_NumberOfFreeClusters;
                private int _offset_TotalNumberOfClusters;
                private int _offset_FileSystem;
                private int _offset_VolumeExt;
                private int _offset_Pad3;

                private int Offset_StartOffset
                {
                    get
                    {
                        if (_offset_StartOffset == -1)
                        {
                            _offset_StartOffset = 0;
                        }

                        return _offset_StartOffset;
                    }
                }

                private int Offset_PartitionSize
                {
                    get
                    {
                        if (_offset_PartitionSize == -1)
                        {
                            _offset_PartitionSize = Offset_StartOffset + 8;
                        }

                        return _offset_PartitionSize;
                    }
                }

                private int Offset_DiskNumber
                {
                    get
                    {
                        if (_offset_DiskNumber == -1)
                        {
                            _offset_DiskNumber = Offset_PartitionSize + 8;
                        }

                        return _offset_DiskNumber;
                    }
                }

                private int Offset_Size
                {
                    get
                    {
                        if (_offset_Size == -1)
                        {
                            _offset_Size = Offset_DiskNumber + 4;
                        }

                        return _offset_Size;
                    }
                }

                private int Offset_DriveType
                {
                    get
                    {
                        if (_offset_DriveType == -1)
                        {
                            _offset_DriveType = Offset_Size + 4;
                        }

                        return _offset_DriveType;
                    }
                }

                private int Offset_DriveLetterString
                {
                    get
                    {
                        if (_offset_DriveLetterString == -1)
                        {
                            _offset_DriveLetterString = Offset_DriveType + 4;
                        }

                        return _offset_DriveLetterString;
                    }
                }

                private int Offset_Pad1
                {
                    get
                    {
                        if (_offset_Pad1 == -1)
                        {
                            _offset_Pad1 = Offset_DriveLetterString + 2;
                        }

                        return _offset_Pad1;
                    }
                }

                private int Offset_PartitionNumber
                {
                    get
                    {
                        if (_offset_PartitionNumber == -1)
                        {
                            _offset_PartitionNumber = Offset_Pad1 + 4;
                        }

                        return _offset_PartitionNumber;
                    }
                }

                private int Offset_SectorsPerCluster
                {
                    get
                    {
                        if (_offset_SectorsPerCluster == -1)
                        {
                            _offset_SectorsPerCluster = Offset_PartitionNumber + 4;
                        }

                        return _offset_SectorsPerCluster;
                    }
                }

                private int Offset_BytesPerSector
                {
                    get
                    {
                        if (_offset_BytesPerSector == -1)
                        {
                            _offset_BytesPerSector = Offset_SectorsPerCluster + 4;
                        }

                        return _offset_BytesPerSector;
                    }
                }

                private int Offset_Pad2
                {
                    get
                    {
                        if (_offset_Pad2 == -1)
                        {
                            _offset_Pad2 = Offset_BytesPerSector + 4;
                        }

                        return _offset_Pad2;
                    }
                }

                private int Offset_NumberOfFreeClusters
                {
                    get
                    {
                        if (_offset_NumberOfFreeClusters == -1)
                        {
                            _offset_NumberOfFreeClusters = Offset_Pad2 + 4;
                        }

                        return _offset_NumberOfFreeClusters;
                    }
                }

                private int Offset_TotalNumberOfClusters
                {
                    get
                    {
                        if (_offset_TotalNumberOfClusters == -1)
                        {
                            _offset_TotalNumberOfClusters = Offset_NumberOfFreeClusters + 8;
                        }

                        return _offset_TotalNumberOfClusters;
                    }
                }

                private int Offset_FileSystem
                {
                    get
                    {
                        if (_offset_FileSystem == -1)
                        {
                            _offset_FileSystem = Offset_TotalNumberOfClusters + 8;
                        }

                        return _offset_FileSystem;
                    }
                }

                private int Offset_VolumeExt
                {
                    get
                    {
                        if (_offset_VolumeExt == -1)
                        {
                            _offset_VolumeExt = Offset_FileSystem + 2;
                        }

                        return _offset_VolumeExt;
                    }
                }

                private int Offset_Pad3
                {
                    get
                    {
                        if (_offset_Pad3 == -1)
                        {
                            _offset_Pad3 = Offset_VolumeExt + 4;
                        }

                        return _offset_Pad3;
                    }
                }

                /// <summary>
                /// Retrieves the StartOffset field.
                /// </summary>
                public ulong StartOffset => BitConverter.ToUInt64(_etwEvent.Data[Offset_StartOffset..Offset_PartitionSize]);

                /// <summary>
                /// Retrieves the PartitionSize field.
                /// </summary>
                public ulong PartitionSize => BitConverter.ToUInt64(_etwEvent.Data[Offset_PartitionSize..Offset_DiskNumber]);

                /// <summary>
                /// Retrieves the DiskNumber field.
                /// </summary>
                public uint DiskNumber => BitConverter.ToUInt32(_etwEvent.Data[Offset_DiskNumber..Offset_Size]);

                /// <summary>
                /// Retrieves the Size field.
                /// </summary>
                public uint Size => BitConverter.ToUInt32(_etwEvent.Data[Offset_Size..Offset_DriveType]);

                /// <summary>
                /// Retrieves the DriveType field.
                /// </summary>
                public uint DriveType => BitConverter.ToUInt32(_etwEvent.Data[Offset_DriveType..Offset_DriveLetterString]);

                /// <summary>
                /// Retrieves the DriveLetterString field.
                /// </summary>
                public char DriveLetterString => BitConverter.ToChar(_etwEvent.Data[Offset_DriveLetterString..Offset_Pad1]);

                /// <summary>
                /// Retrieves the Pad1 field.
                /// </summary>
                public uint Pad1 => BitConverter.ToUInt32(_etwEvent.Data[Offset_Pad1..Offset_PartitionNumber]);

                /// <summary>
                /// Retrieves the PartitionNumber field.
                /// </summary>
                public uint PartitionNumber => BitConverter.ToUInt32(_etwEvent.Data[Offset_PartitionNumber..Offset_SectorsPerCluster]);

                /// <summary>
                /// Retrieves the SectorsPerCluster field.
                /// </summary>
                public uint SectorsPerCluster => BitConverter.ToUInt32(_etwEvent.Data[Offset_SectorsPerCluster..Offset_BytesPerSector]);

                /// <summary>
                /// Retrieves the BytesPerSector field.
                /// </summary>
                public uint BytesPerSector => BitConverter.ToUInt32(_etwEvent.Data[Offset_BytesPerSector..Offset_Pad2]);

                /// <summary>
                /// Retrieves the Pad2 field.
                /// </summary>
                public uint Pad2 => BitConverter.ToUInt32(_etwEvent.Data[Offset_Pad2..Offset_NumberOfFreeClusters]);

                /// <summary>
                /// Retrieves the NumberOfFreeClusters field.
                /// </summary>
                public long NumberOfFreeClusters => BitConverter.ToInt64(_etwEvent.Data[Offset_NumberOfFreeClusters..Offset_TotalNumberOfClusters]);

                /// <summary>
                /// Retrieves the TotalNumberOfClusters field.
                /// </summary>
                public long TotalNumberOfClusters => BitConverter.ToInt64(_etwEvent.Data[Offset_TotalNumberOfClusters..Offset_FileSystem]);

                /// <summary>
                /// Retrieves the FileSystem field.
                /// </summary>
                public char FileSystem => BitConverter.ToChar(_etwEvent.Data[Offset_FileSystem..Offset_VolumeExt]);

                /// <summary>
                /// Retrieves the VolumeExt field.
                /// </summary>
                public uint VolumeExt => BitConverter.ToUInt32(_etwEvent.Data[Offset_VolumeExt..Offset_Pad3]);

                /// <summary>
                /// Retrieves the Pad3 field.
                /// </summary>
                public uint Pad3 => BitConverter.ToUInt32(_etwEvent.Data[Offset_Pad3..]);

                /// <summary>
                /// Creates a new LogDiskData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public LogDiskData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_StartOffset = -1;
                    _offset_PartitionSize = -1;
                    _offset_DiskNumber = -1;
                    _offset_Size = -1;
                    _offset_DriveType = -1;
                    _offset_DriveLetterString = -1;
                    _offset_Pad1 = -1;
                    _offset_PartitionNumber = -1;
                    _offset_SectorsPerCluster = -1;
                    _offset_BytesPerSector = -1;
                    _offset_Pad2 = -1;
                    _offset_NumberOfFreeClusters = -1;
                    _offset_TotalNumberOfClusters = -1;
                    _offset_FileSystem = -1;
                    _offset_VolumeExt = -1;
                    _offset_Pad3 = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a NIC event.
        /// </summary>
        public readonly ref struct NICEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "NIC";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 0,
                Version = 2,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.NIC,
                Task = 0,
                Keyword = 0
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
            public NICData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new NICEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public NICEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a NICEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator NICEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a NIC event.
            /// </summary>
            public ref struct NICData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_PhysicalAddr;
                private int _offset_PhysicalAddrLen;
                private int _offset_Ipv4Index;
                private int _offset_Ipv6Index;
                private int _offset_NICDescription;
                private int _offset_IpAddresses;
                private int _offset_DnsServerAddresses;

                private int Offset_PhysicalAddr
                {
                    get
                    {
                        if (_offset_PhysicalAddr == -1)
                        {
                            _offset_PhysicalAddr = 0;
                        }

                        return _offset_PhysicalAddr;
                    }
                }

                private int Offset_PhysicalAddrLen
                {
                    get
                    {
                        if (_offset_PhysicalAddrLen == -1)
                        {
                            _offset_PhysicalAddrLen = Offset_PhysicalAddr + 8;
                        }

                        return _offset_PhysicalAddrLen;
                    }
                }

                private int Offset_Ipv4Index
                {
                    get
                    {
                        if (_offset_Ipv4Index == -1)
                        {
                            _offset_Ipv4Index = Offset_PhysicalAddrLen + 4;
                        }

                        return _offset_Ipv4Index;
                    }
                }

                private int Offset_Ipv6Index
                {
                    get
                    {
                        if (_offset_Ipv6Index == -1)
                        {
                            _offset_Ipv6Index = Offset_Ipv4Index + 4;
                        }

                        return _offset_Ipv6Index;
                    }
                }

                private int Offset_NICDescription
                {
                    get
                    {
                        if (_offset_NICDescription == -1)
                        {
                            _offset_NICDescription = Offset_Ipv6Index + 4;
                        }

                        return _offset_NICDescription;
                    }
                }

                private int Offset_IpAddresses
                {
                    get
                    {
                        if (_offset_IpAddresses == -1)
                        {
                            _offset_IpAddresses = Offset_NICDescription + _etwEvent.UnicodeStringLength(Offset_NICDescription);
                        }

                        return _offset_IpAddresses;
                    }
                }

                private int Offset_DnsServerAddresses
                {
                    get
                    {
                        if (_offset_DnsServerAddresses == -1)
                        {
                            _offset_DnsServerAddresses = Offset_IpAddresses + _etwEvent.UnicodeStringLength(Offset_IpAddresses);
                        }

                        return _offset_DnsServerAddresses;
                    }
                }

                /// <summary>
                /// Retrieves the PhysicalAddr field.
                /// </summary>
                public ulong PhysicalAddr => BitConverter.ToUInt64(_etwEvent.Data[Offset_PhysicalAddr..Offset_PhysicalAddrLen]);

                /// <summary>
                /// Retrieves the PhysicalAddrLen field.
                /// </summary>
                public uint PhysicalAddrLen => BitConverter.ToUInt32(_etwEvent.Data[Offset_PhysicalAddrLen..Offset_Ipv4Index]);

                /// <summary>
                /// Retrieves the Ipv4Index field.
                /// </summary>
                public uint Ipv4Index => BitConverter.ToUInt32(_etwEvent.Data[Offset_Ipv4Index..Offset_Ipv6Index]);

                /// <summary>
                /// Retrieves the Ipv6Index field.
                /// </summary>
                public uint Ipv6Index => BitConverter.ToUInt32(_etwEvent.Data[Offset_Ipv6Index..Offset_NICDescription]);

                /// <summary>
                /// Retrieves the NICDescription field.
                /// </summary>
                public string NICDescription => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_NICDescription..Offset_IpAddresses]);

                /// <summary>
                /// Retrieves the IpAddresses field.
                /// </summary>
                public string IpAddresses => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_IpAddresses..Offset_DnsServerAddresses]);

                /// <summary>
                /// Retrieves the DnsServerAddresses field.
                /// </summary>
                public string DnsServerAddresses => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_DnsServerAddresses..]);

                /// <summary>
                /// Creates a new NICData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public NICData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_PhysicalAddr = -1;
                    _offset_PhysicalAddrLen = -1;
                    _offset_Ipv4Index = -1;
                    _offset_Ipv6Index = -1;
                    _offset_NICDescription = -1;
                    _offset_IpAddresses = -1;
                    _offset_DnsServerAddresses = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Video event.
        /// </summary>
        public readonly ref struct VideoEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Video";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 0,
                Version = 2,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.Video,
                Task = 0,
                Keyword = 0
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
            public VideoData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new VideoEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public VideoEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a VideoEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator VideoEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Video event.
            /// </summary>
            public ref struct VideoData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_MemorySize;
                private int _offset_XResolution;
                private int _offset_YResolution;
                private int _offset_BitsPerPixel;
                private int _offset_VRefresh;
                private int _offset_ChipType;
                private int _offset_DACType;
                private int _offset_AdapterString;
                private int _offset_BiosString;
                private int _offset_DeviceId;
                private int _offset_StateFlags;

                private int Offset_MemorySize
                {
                    get
                    {
                        if (_offset_MemorySize == -1)
                        {
                            _offset_MemorySize = 0;
                        }

                        return _offset_MemorySize;
                    }
                }

                private int Offset_XResolution
                {
                    get
                    {
                        if (_offset_XResolution == -1)
                        {
                            _offset_XResolution = Offset_MemorySize + 4;
                        }

                        return _offset_XResolution;
                    }
                }

                private int Offset_YResolution
                {
                    get
                    {
                        if (_offset_YResolution == -1)
                        {
                            _offset_YResolution = Offset_XResolution + 4;
                        }

                        return _offset_YResolution;
                    }
                }

                private int Offset_BitsPerPixel
                {
                    get
                    {
                        if (_offset_BitsPerPixel == -1)
                        {
                            _offset_BitsPerPixel = Offset_YResolution + 4;
                        }

                        return _offset_BitsPerPixel;
                    }
                }

                private int Offset_VRefresh
                {
                    get
                    {
                        if (_offset_VRefresh == -1)
                        {
                            _offset_VRefresh = Offset_BitsPerPixel + 4;
                        }

                        return _offset_VRefresh;
                    }
                }

                private int Offset_ChipType
                {
                    get
                    {
                        if (_offset_ChipType == -1)
                        {
                            _offset_ChipType = Offset_VRefresh + 4;
                        }

                        return _offset_ChipType;
                    }
                }

                private int Offset_DACType
                {
                    get
                    {
                        if (_offset_DACType == -1)
                        {
                            _offset_DACType = Offset_ChipType + 2;
                        }

                        return _offset_DACType;
                    }
                }

                private int Offset_AdapterString
                {
                    get
                    {
                        if (_offset_AdapterString == -1)
                        {
                            _offset_AdapterString = Offset_DACType + 2;
                        }

                        return _offset_AdapterString;
                    }
                }

                private int Offset_BiosString
                {
                    get
                    {
                        if (_offset_BiosString == -1)
                        {
                            _offset_BiosString = Offset_AdapterString + 2;
                        }

                        return _offset_BiosString;
                    }
                }

                private int Offset_DeviceId
                {
                    get
                    {
                        if (_offset_DeviceId == -1)
                        {
                            _offset_DeviceId = Offset_BiosString + 2;
                        }

                        return _offset_DeviceId;
                    }
                }

                private int Offset_StateFlags
                {
                    get
                    {
                        if (_offset_StateFlags == -1)
                        {
                            _offset_StateFlags = Offset_DeviceId + 2;
                        }

                        return _offset_StateFlags;
                    }
                }

                /// <summary>
                /// Retrieves the MemorySize field.
                /// </summary>
                public uint MemorySize => BitConverter.ToUInt32(_etwEvent.Data[Offset_MemorySize..Offset_XResolution]);

                /// <summary>
                /// Retrieves the XResolution field.
                /// </summary>
                public uint XResolution => BitConverter.ToUInt32(_etwEvent.Data[Offset_XResolution..Offset_YResolution]);

                /// <summary>
                /// Retrieves the YResolution field.
                /// </summary>
                public uint YResolution => BitConverter.ToUInt32(_etwEvent.Data[Offset_YResolution..Offset_BitsPerPixel]);

                /// <summary>
                /// Retrieves the BitsPerPixel field.
                /// </summary>
                public uint BitsPerPixel => BitConverter.ToUInt32(_etwEvent.Data[Offset_BitsPerPixel..Offset_VRefresh]);

                /// <summary>
                /// Retrieves the VRefresh field.
                /// </summary>
                public uint VRefresh => BitConverter.ToUInt32(_etwEvent.Data[Offset_VRefresh..Offset_ChipType]);

                /// <summary>
                /// Retrieves the ChipType field.
                /// </summary>
                public char ChipType => BitConverter.ToChar(_etwEvent.Data[Offset_ChipType..Offset_DACType]);

                /// <summary>
                /// Retrieves the DACType field.
                /// </summary>
                public char DACType => BitConverter.ToChar(_etwEvent.Data[Offset_DACType..Offset_AdapterString]);

                /// <summary>
                /// Retrieves the AdapterString field.
                /// </summary>
                public char AdapterString => BitConverter.ToChar(_etwEvent.Data[Offset_AdapterString..Offset_BiosString]);

                /// <summary>
                /// Retrieves the BiosString field.
                /// </summary>
                public char BiosString => BitConverter.ToChar(_etwEvent.Data[Offset_BiosString..Offset_DeviceId]);

                /// <summary>
                /// Retrieves the DeviceId field.
                /// </summary>
                public char DeviceId => BitConverter.ToChar(_etwEvent.Data[Offset_DeviceId..Offset_StateFlags]);

                /// <summary>
                /// Retrieves the StateFlags field.
                /// </summary>
                public uint StateFlags => BitConverter.ToUInt32(_etwEvent.Data[Offset_StateFlags..]);

                /// <summary>
                /// Creates a new VideoData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public VideoData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_MemorySize = -1;
                    _offset_XResolution = -1;
                    _offset_YResolution = -1;
                    _offset_BitsPerPixel = -1;
                    _offset_VRefresh = -1;
                    _offset_ChipType = -1;
                    _offset_DACType = -1;
                    _offset_AdapterString = -1;
                    _offset_BiosString = -1;
                    _offset_DeviceId = -1;
                    _offset_StateFlags = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Services event.
        /// </summary>
        public readonly ref struct ServicesEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Services";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 0,
                Version = 2,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.Services,
                Task = 0,
                Keyword = 0
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
            public ServicesData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ServicesEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ServicesEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a ServicesEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator ServicesEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Services event.
            /// </summary>
            public ref struct ServicesData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProcessId;
                private int _offset_ServiceState;
                private int _offset_SubProcessTag;
                private int _offset_ServiceName;
                private int _offset_DisplayName;
                private int _offset_ProcessName;

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = 0;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_ServiceState
                {
                    get
                    {
                        if (_offset_ServiceState == -1)
                        {
                            _offset_ServiceState = Offset_ProcessId + 4;
                        }

                        return _offset_ServiceState;
                    }
                }

                private int Offset_SubProcessTag
                {
                    get
                    {
                        if (_offset_SubProcessTag == -1)
                        {
                            _offset_SubProcessTag = Offset_ServiceState + 4;
                        }

                        return _offset_SubProcessTag;
                    }
                }

                private int Offset_ServiceName
                {
                    get
                    {
                        if (_offset_ServiceName == -1)
                        {
                            _offset_ServiceName = Offset_SubProcessTag + 4;
                        }

                        return _offset_ServiceName;
                    }
                }

                private int Offset_DisplayName
                {
                    get
                    {
                        if (_offset_DisplayName == -1)
                        {
                            _offset_DisplayName = Offset_ServiceName + _etwEvent.UnicodeStringLength(Offset_ServiceName);
                        }

                        return _offset_DisplayName;
                    }
                }

                private int Offset_ProcessName
                {
                    get
                    {
                        if (_offset_ProcessName == -1)
                        {
                            _offset_ProcessName = Offset_DisplayName + _etwEvent.UnicodeStringLength(Offset_DisplayName);
                        }

                        return _offset_ProcessName;
                    }
                }

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..Offset_ServiceState]);

                /// <summary>
                /// Retrieves the ServiceState field.
                /// </summary>
                public uint ServiceState => BitConverter.ToUInt32(_etwEvent.Data[Offset_ServiceState..Offset_SubProcessTag]);

                /// <summary>
                /// Retrieves the SubProcessTag field.
                /// </summary>
                public uint SubProcessTag => BitConverter.ToUInt32(_etwEvent.Data[Offset_SubProcessTag..Offset_ServiceName]);

                /// <summary>
                /// Retrieves the ServiceName field.
                /// </summary>
                public string ServiceName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ServiceName..Offset_DisplayName]);

                /// <summary>
                /// Retrieves the DisplayName field.
                /// </summary>
                public string DisplayName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_DisplayName..Offset_ProcessName]);

                /// <summary>
                /// Retrieves the ProcessName field.
                /// </summary>
                public string ProcessName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProcessName..]);

                /// <summary>
                /// Creates a new ServicesData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ServicesData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProcessId = -1;
                    _offset_ServiceState = -1;
                    _offset_SubProcessTag = -1;
                    _offset_ServiceName = -1;
                    _offset_DisplayName = -1;
                    _offset_ProcessName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Power event.
        /// </summary>
        public readonly ref struct PowerEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Power";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 0,
                Version = 2,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.Power,
                Task = 0,
                Keyword = 0
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
            public PowerData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new PowerEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public PowerEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a PowerEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator PowerEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Power event.
            /// </summary>
            public ref struct PowerData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_S1;
                private int _offset_S2;
                private int _offset_S3;
                private int _offset_S4;
                private int _offset_S5;
                private int _offset_Pad1;
                private int _offset_Pad2;
                private int _offset_Pad3;

                private int Offset_S1
                {
                    get
                    {
                        if (_offset_S1 == -1)
                        {
                            _offset_S1 = 0;
                        }

                        return _offset_S1;
                    }
                }

                private int Offset_S2
                {
                    get
                    {
                        if (_offset_S2 == -1)
                        {
                            _offset_S2 = Offset_S1 + 1;
                        }

                        return _offset_S2;
                    }
                }

                private int Offset_S3
                {
                    get
                    {
                        if (_offset_S3 == -1)
                        {
                            _offset_S3 = Offset_S2 + 1;
                        }

                        return _offset_S3;
                    }
                }

                private int Offset_S4
                {
                    get
                    {
                        if (_offset_S4 == -1)
                        {
                            _offset_S4 = Offset_S3 + 1;
                        }

                        return _offset_S4;
                    }
                }

                private int Offset_S5
                {
                    get
                    {
                        if (_offset_S5 == -1)
                        {
                            _offset_S5 = Offset_S4 + 1;
                        }

                        return _offset_S5;
                    }
                }

                private int Offset_Pad1
                {
                    get
                    {
                        if (_offset_Pad1 == -1)
                        {
                            _offset_Pad1 = Offset_S5 + 1;
                        }

                        return _offset_Pad1;
                    }
                }

                private int Offset_Pad2
                {
                    get
                    {
                        if (_offset_Pad2 == -1)
                        {
                            _offset_Pad2 = Offset_Pad1 + 1;
                        }

                        return _offset_Pad2;
                    }
                }

                private int Offset_Pad3
                {
                    get
                    {
                        if (_offset_Pad3 == -1)
                        {
                            _offset_Pad3 = Offset_Pad2 + 1;
                        }

                        return _offset_Pad3;
                    }
                }

                /// <summary>
                /// Retrieves the S1 field.
                /// </summary>
                public byte S1 => _etwEvent.Data[Offset_S1];

                /// <summary>
                /// Retrieves the S2 field.
                /// </summary>
                public byte S2 => _etwEvent.Data[Offset_S2];

                /// <summary>
                /// Retrieves the S3 field.
                /// </summary>
                public byte S3 => _etwEvent.Data[Offset_S3];

                /// <summary>
                /// Retrieves the S4 field.
                /// </summary>
                public byte S4 => _etwEvent.Data[Offset_S4];

                /// <summary>
                /// Retrieves the S5 field.
                /// </summary>
                public byte S5 => _etwEvent.Data[Offset_S5];

                /// <summary>
                /// Retrieves the Pad1 field.
                /// </summary>
                public byte Pad1 => _etwEvent.Data[Offset_Pad1];

                /// <summary>
                /// Retrieves the Pad2 field.
                /// </summary>
                public byte Pad2 => _etwEvent.Data[Offset_Pad2];

                /// <summary>
                /// Retrieves the Pad3 field.
                /// </summary>
                public byte Pad3 => _etwEvent.Data[Offset_Pad3];

                /// <summary>
                /// Creates a new PowerData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public PowerData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_S1 = -1;
                    _offset_S2 = -1;
                    _offset_S3 = -1;
                    _offset_S4 = -1;
                    _offset_S5 = -1;
                    _offset_Pad1 = -1;
                    _offset_Pad2 = -1;
                    _offset_Pad3 = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Network event.
        /// </summary>
        public readonly ref struct NetworkEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Network";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 0,
                Version = 2,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.Network,
                Task = 0,
                Keyword = 0
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
            public NetworkData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new NetworkEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public NetworkEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a NetworkEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator NetworkEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Network event.
            /// </summary>
            public ref struct NetworkData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_TcbTablePartitions;
                private int _offset_MaxHashTableSize;
                private int _offset_MaxUserPort;
                private int _offset_TcpTimedWaitDelay;

                private int Offset_TcbTablePartitions
                {
                    get
                    {
                        if (_offset_TcbTablePartitions == -1)
                        {
                            _offset_TcbTablePartitions = 0;
                        }

                        return _offset_TcbTablePartitions;
                    }
                }

                private int Offset_MaxHashTableSize
                {
                    get
                    {
                        if (_offset_MaxHashTableSize == -1)
                        {
                            _offset_MaxHashTableSize = Offset_TcbTablePartitions + 4;
                        }

                        return _offset_MaxHashTableSize;
                    }
                }

                private int Offset_MaxUserPort
                {
                    get
                    {
                        if (_offset_MaxUserPort == -1)
                        {
                            _offset_MaxUserPort = Offset_MaxHashTableSize + 4;
                        }

                        return _offset_MaxUserPort;
                    }
                }

                private int Offset_TcpTimedWaitDelay
                {
                    get
                    {
                        if (_offset_TcpTimedWaitDelay == -1)
                        {
                            _offset_TcpTimedWaitDelay = Offset_MaxUserPort + 4;
                        }

                        return _offset_TcpTimedWaitDelay;
                    }
                }

                /// <summary>
                /// Retrieves the TcbTablePartitions field.
                /// </summary>
                public uint TcbTablePartitions => BitConverter.ToUInt32(_etwEvent.Data[Offset_TcbTablePartitions..Offset_MaxHashTableSize]);

                /// <summary>
                /// Retrieves the MaxHashTableSize field.
                /// </summary>
                public uint MaxHashTableSize => BitConverter.ToUInt32(_etwEvent.Data[Offset_MaxHashTableSize..Offset_MaxUserPort]);

                /// <summary>
                /// Retrieves the MaxUserPort field.
                /// </summary>
                public uint MaxUserPort => BitConverter.ToUInt32(_etwEvent.Data[Offset_MaxUserPort..Offset_TcpTimedWaitDelay]);

                /// <summary>
                /// Retrieves the TcpTimedWaitDelay field.
                /// </summary>
                public uint TcpTimedWaitDelay => BitConverter.ToUInt32(_etwEvent.Data[Offset_TcpTimedWaitDelay..]);

                /// <summary>
                /// Creates a new NetworkData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public NetworkData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_TcbTablePartitions = -1;
                    _offset_MaxHashTableSize = -1;
                    _offset_MaxUserPort = -1;
                    _offset_TcpTimedWaitDelay = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a OpticalDisk event.
        /// </summary>
        public readonly ref struct OpticalDiskEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "OpticalDisk";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 0,
                Version = 2,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.OpticalDisk,
                Task = 0,
                Keyword = 0
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
            public OpticalDiskData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new OpticalDiskEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public OpticalDiskEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a OpticalDiskEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator OpticalDiskEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a OpticalDisk event.
            /// </summary>
            public ref struct OpticalDiskData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_DiskNumber;
                private int _offset_BusType;
                private int _offset_DeviceType;
                private int _offset_MediaType;
                private int _offset_StartingOffset;
                private int _offset_Size;
                private int _offset_NumberOfFreeBlocks;
                private int _offset_TotalNumberOfBlocks;
                private int _offset_NextWritableAddress;
                private int _offset_NumberOfSessions;
                private int _offset_NumberOfTracks;
                private int _offset_BytesPerSector;
                private int _offset_DiscStatus;
                private int _offset_LastSessionStatus;
                private int _offset_DriveLetter;
                private int _offset_FileSystemName;
                private int _offset_DeviceName;
                private int _offset_ManufacturerName;

                private int Offset_DiskNumber
                {
                    get
                    {
                        if (_offset_DiskNumber == -1)
                        {
                            _offset_DiskNumber = 0;
                        }

                        return _offset_DiskNumber;
                    }
                }

                private int Offset_BusType
                {
                    get
                    {
                        if (_offset_BusType == -1)
                        {
                            _offset_BusType = Offset_DiskNumber + 2;
                        }

                        return _offset_BusType;
                    }
                }

                private int Offset_DeviceType
                {
                    get
                    {
                        if (_offset_DeviceType == -1)
                        {
                            _offset_DeviceType = Offset_BusType + 2;
                        }

                        return _offset_DeviceType;
                    }
                }

                private int Offset_MediaType
                {
                    get
                    {
                        if (_offset_MediaType == -1)
                        {
                            _offset_MediaType = Offset_DeviceType + 2;
                        }

                        return _offset_MediaType;
                    }
                }

                private int Offset_StartingOffset
                {
                    get
                    {
                        if (_offset_StartingOffset == -1)
                        {
                            _offset_StartingOffset = Offset_MediaType + 2;
                        }

                        return _offset_StartingOffset;
                    }
                }

                private int Offset_Size
                {
                    get
                    {
                        if (_offset_Size == -1)
                        {
                            _offset_Size = Offset_StartingOffset + 8;
                        }

                        return _offset_Size;
                    }
                }

                private int Offset_NumberOfFreeBlocks
                {
                    get
                    {
                        if (_offset_NumberOfFreeBlocks == -1)
                        {
                            _offset_NumberOfFreeBlocks = Offset_Size + 8;
                        }

                        return _offset_NumberOfFreeBlocks;
                    }
                }

                private int Offset_TotalNumberOfBlocks
                {
                    get
                    {
                        if (_offset_TotalNumberOfBlocks == -1)
                        {
                            _offset_TotalNumberOfBlocks = Offset_NumberOfFreeBlocks + 8;
                        }

                        return _offset_TotalNumberOfBlocks;
                    }
                }

                private int Offset_NextWritableAddress
                {
                    get
                    {
                        if (_offset_NextWritableAddress == -1)
                        {
                            _offset_NextWritableAddress = Offset_TotalNumberOfBlocks + 8;
                        }

                        return _offset_NextWritableAddress;
                    }
                }

                private int Offset_NumberOfSessions
                {
                    get
                    {
                        if (_offset_NumberOfSessions == -1)
                        {
                            _offset_NumberOfSessions = Offset_NextWritableAddress + 8;
                        }

                        return _offset_NumberOfSessions;
                    }
                }

                private int Offset_NumberOfTracks
                {
                    get
                    {
                        if (_offset_NumberOfTracks == -1)
                        {
                            _offset_NumberOfTracks = Offset_NumberOfSessions + 4;
                        }

                        return _offset_NumberOfTracks;
                    }
                }

                private int Offset_BytesPerSector
                {
                    get
                    {
                        if (_offset_BytesPerSector == -1)
                        {
                            _offset_BytesPerSector = Offset_NumberOfTracks + 4;
                        }

                        return _offset_BytesPerSector;
                    }
                }

                private int Offset_DiscStatus
                {
                    get
                    {
                        if (_offset_DiscStatus == -1)
                        {
                            _offset_DiscStatus = Offset_BytesPerSector + 4;
                        }

                        return _offset_DiscStatus;
                    }
                }

                private int Offset_LastSessionStatus
                {
                    get
                    {
                        if (_offset_LastSessionStatus == -1)
                        {
                            _offset_LastSessionStatus = Offset_DiscStatus + 2;
                        }

                        return _offset_LastSessionStatus;
                    }
                }

                private int Offset_DriveLetter
                {
                    get
                    {
                        if (_offset_DriveLetter == -1)
                        {
                            _offset_DriveLetter = Offset_LastSessionStatus + 2;
                        }

                        return _offset_DriveLetter;
                    }
                }

                private int Offset_FileSystemName
                {
                    get
                    {
                        if (_offset_FileSystemName == -1)
                        {
                            _offset_FileSystemName = Offset_DriveLetter + _etwEvent.UnicodeStringLength(Offset_DriveLetter);
                        }

                        return _offset_FileSystemName;
                    }
                }

                private int Offset_DeviceName
                {
                    get
                    {
                        if (_offset_DeviceName == -1)
                        {
                            _offset_DeviceName = Offset_FileSystemName + _etwEvent.UnicodeStringLength(Offset_FileSystemName);
                        }

                        return _offset_DeviceName;
                    }
                }

                private int Offset_ManufacturerName
                {
                    get
                    {
                        if (_offset_ManufacturerName == -1)
                        {
                            _offset_ManufacturerName = Offset_DeviceName + _etwEvent.AnsiStringLength(Offset_DeviceName);
                        }

                        return _offset_ManufacturerName;
                    }
                }

                /// <summary>
                /// Retrieves the DiskNumber field.
                /// </summary>
                public ushort DiskNumber => BitConverter.ToUInt16(_etwEvent.Data[Offset_DiskNumber..Offset_BusType]);

                /// <summary>
                /// Retrieves the BusType field.
                /// </summary>
                public ushort BusType => BitConverter.ToUInt16(_etwEvent.Data[Offset_BusType..Offset_DeviceType]);

                /// <summary>
                /// Retrieves the DeviceType field.
                /// </summary>
                public ushort DeviceType => BitConverter.ToUInt16(_etwEvent.Data[Offset_DeviceType..Offset_MediaType]);

                /// <summary>
                /// Retrieves the MediaType field.
                /// </summary>
                public ushort MediaType => BitConverter.ToUInt16(_etwEvent.Data[Offset_MediaType..Offset_StartingOffset]);

                /// <summary>
                /// Retrieves the StartingOffset field.
                /// </summary>
                public ulong StartingOffset => BitConverter.ToUInt64(_etwEvent.Data[Offset_StartingOffset..Offset_Size]);

                /// <summary>
                /// Retrieves the Size field.
                /// </summary>
                public ulong Size => BitConverter.ToUInt64(_etwEvent.Data[Offset_Size..Offset_NumberOfFreeBlocks]);

                /// <summary>
                /// Retrieves the NumberOfFreeBlocks field.
                /// </summary>
                public ulong NumberOfFreeBlocks => BitConverter.ToUInt64(_etwEvent.Data[Offset_NumberOfFreeBlocks..Offset_TotalNumberOfBlocks]);

                /// <summary>
                /// Retrieves the TotalNumberOfBlocks field.
                /// </summary>
                public ulong TotalNumberOfBlocks => BitConverter.ToUInt64(_etwEvent.Data[Offset_TotalNumberOfBlocks..Offset_NextWritableAddress]);

                /// <summary>
                /// Retrieves the NextWritableAddress field.
                /// </summary>
                public ulong NextWritableAddress => BitConverter.ToUInt64(_etwEvent.Data[Offset_NextWritableAddress..Offset_NumberOfSessions]);

                /// <summary>
                /// Retrieves the NumberOfSessions field.
                /// </summary>
                public uint NumberOfSessions => BitConverter.ToUInt32(_etwEvent.Data[Offset_NumberOfSessions..Offset_NumberOfTracks]);

                /// <summary>
                /// Retrieves the NumberOfTracks field.
                /// </summary>
                public uint NumberOfTracks => BitConverter.ToUInt32(_etwEvent.Data[Offset_NumberOfTracks..Offset_BytesPerSector]);

                /// <summary>
                /// Retrieves the BytesPerSector field.
                /// </summary>
                public uint BytesPerSector => BitConverter.ToUInt32(_etwEvent.Data[Offset_BytesPerSector..Offset_DiscStatus]);

                /// <summary>
                /// Retrieves the DiscStatus field.
                /// </summary>
                public ushort DiscStatus => BitConverter.ToUInt16(_etwEvent.Data[Offset_DiscStatus..Offset_LastSessionStatus]);

                /// <summary>
                /// Retrieves the LastSessionStatus field.
                /// </summary>
                public ushort LastSessionStatus => BitConverter.ToUInt16(_etwEvent.Data[Offset_LastSessionStatus..Offset_DriveLetter]);

                /// <summary>
                /// Retrieves the DriveLetter field.
                /// </summary>
                public string DriveLetter => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_DriveLetter..Offset_FileSystemName]);

                /// <summary>
                /// Retrieves the FileSystemName field.
                /// </summary>
                public string FileSystemName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FileSystemName..Offset_DeviceName]);

                /// <summary>
                /// Retrieves the DeviceName field.
                /// </summary>
                public string DeviceName => System.Text.Encoding.ASCII.GetString(_etwEvent.Data[Offset_DeviceName..Offset_ManufacturerName]);

                /// <summary>
                /// Retrieves the ManufacturerName field.
                /// </summary>
                public string ManufacturerName => System.Text.Encoding.ASCII.GetString(_etwEvent.Data[Offset_ManufacturerName..]);

                /// <summary>
                /// Creates a new OpticalDiskData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public OpticalDiskData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_DiskNumber = -1;
                    _offset_BusType = -1;
                    _offset_DeviceType = -1;
                    _offset_MediaType = -1;
                    _offset_StartingOffset = -1;
                    _offset_Size = -1;
                    _offset_NumberOfFreeBlocks = -1;
                    _offset_TotalNumberOfBlocks = -1;
                    _offset_NextWritableAddress = -1;
                    _offset_NumberOfSessions = -1;
                    _offset_NumberOfTracks = -1;
                    _offset_BytesPerSector = -1;
                    _offset_DiscStatus = -1;
                    _offset_LastSessionStatus = -1;
                    _offset_DriveLetter = -1;
                    _offset_FileSystemName = -1;
                    _offset_DeviceName = -1;
                    _offset_ManufacturerName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a IRQ event.
        /// </summary>
        public readonly ref struct IRQEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "IRQ";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 0,
                Version = 2,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.IRQ,
                Task = 0,
                Keyword = 0
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
            public IRQData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new IRQEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public IRQEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a IRQEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator IRQEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a IRQ event.
            /// </summary>
            public ref struct IRQData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_IRQAffinity;
                private int _offset_IRQNum;
                private int _offset_DeviceDescriptionLen;
                private int _offset_DeviceDescription;

                private int Offset_IRQAffinity
                {
                    get
                    {
                        if (_offset_IRQAffinity == -1)
                        {
                            _offset_IRQAffinity = 0;
                        }

                        return _offset_IRQAffinity;
                    }
                }

                private int Offset_IRQNum
                {
                    get
                    {
                        if (_offset_IRQNum == -1)
                        {
                            _offset_IRQNum = Offset_IRQAffinity + 8;
                        }

                        return _offset_IRQNum;
                    }
                }

                private int Offset_DeviceDescriptionLen
                {
                    get
                    {
                        if (_offset_DeviceDescriptionLen == -1)
                        {
                            _offset_DeviceDescriptionLen = Offset_IRQNum + 4;
                        }

                        return _offset_DeviceDescriptionLen;
                    }
                }

                private int Offset_DeviceDescription
                {
                    get
                    {
                        if (_offset_DeviceDescription == -1)
                        {
                            _offset_DeviceDescription = Offset_DeviceDescriptionLen + 4;
                        }

                        return _offset_DeviceDescription;
                    }
                }

                /// <summary>
                /// Retrieves the IRQAffinity field.
                /// </summary>
                public ulong IRQAffinity => BitConverter.ToUInt64(_etwEvent.Data[Offset_IRQAffinity..Offset_IRQNum]);

                /// <summary>
                /// Retrieves the IRQNum field.
                /// </summary>
                public uint IRQNum => BitConverter.ToUInt32(_etwEvent.Data[Offset_IRQNum..Offset_DeviceDescriptionLen]);

                /// <summary>
                /// Retrieves the DeviceDescriptionLen field.
                /// </summary>
                public uint DeviceDescriptionLen => BitConverter.ToUInt32(_etwEvent.Data[Offset_DeviceDescriptionLen..Offset_DeviceDescription]);

                /// <summary>
                /// Retrieves the DeviceDescription field.
                /// </summary>
                public string DeviceDescription => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_DeviceDescription..]);

                /// <summary>
                /// Creates a new IRQData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public IRQData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_IRQAffinity = -1;
                    _offset_IRQNum = -1;
                    _offset_DeviceDescriptionLen = -1;
                    _offset_DeviceDescription = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a PnP event.
        /// </summary>
        public readonly ref struct PnPEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "PnP";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 0,
                Version = 2,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.PnP,
                Task = 0,
                Keyword = 0
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
            public PnPData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new PnPEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public PnPEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a PnPEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator PnPEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a PnP event.
            /// </summary>
            public ref struct PnPData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_IDLength;
                private int _offset_DescriptionLength;
                private int _offset_FriendlyNameLength;
                private int _offset_DeviceID;
                private int _offset_DeviceDescription;
                private int _offset_FriendlyName;

                private int Offset_IDLength
                {
                    get
                    {
                        if (_offset_IDLength == -1)
                        {
                            _offset_IDLength = 0;
                        }

                        return _offset_IDLength;
                    }
                }

                private int Offset_DescriptionLength
                {
                    get
                    {
                        if (_offset_DescriptionLength == -1)
                        {
                            _offset_DescriptionLength = Offset_IDLength + 4;
                        }

                        return _offset_DescriptionLength;
                    }
                }

                private int Offset_FriendlyNameLength
                {
                    get
                    {
                        if (_offset_FriendlyNameLength == -1)
                        {
                            _offset_FriendlyNameLength = Offset_DescriptionLength + 4;
                        }

                        return _offset_FriendlyNameLength;
                    }
                }

                private int Offset_DeviceID
                {
                    get
                    {
                        if (_offset_DeviceID == -1)
                        {
                            _offset_DeviceID = Offset_FriendlyNameLength + 4;
                        }

                        return _offset_DeviceID;
                    }
                }

                private int Offset_DeviceDescription
                {
                    get
                    {
                        if (_offset_DeviceDescription == -1)
                        {
                            _offset_DeviceDescription = Offset_DeviceID + _etwEvent.UnicodeStringLength(Offset_DeviceID);
                        }

                        return _offset_DeviceDescription;
                    }
                }

                private int Offset_FriendlyName
                {
                    get
                    {
                        if (_offset_FriendlyName == -1)
                        {
                            _offset_FriendlyName = Offset_DeviceDescription + _etwEvent.UnicodeStringLength(Offset_DeviceDescription);
                        }

                        return _offset_FriendlyName;
                    }
                }

                /// <summary>
                /// Retrieves the IDLength field.
                /// </summary>
                public uint IDLength => BitConverter.ToUInt32(_etwEvent.Data[Offset_IDLength..Offset_DescriptionLength]);

                /// <summary>
                /// Retrieves the DescriptionLength field.
                /// </summary>
                public uint DescriptionLength => BitConverter.ToUInt32(_etwEvent.Data[Offset_DescriptionLength..Offset_FriendlyNameLength]);

                /// <summary>
                /// Retrieves the FriendlyNameLength field.
                /// </summary>
                public uint FriendlyNameLength => BitConverter.ToUInt32(_etwEvent.Data[Offset_FriendlyNameLength..Offset_DeviceID]);

                /// <summary>
                /// Retrieves the DeviceID field.
                /// </summary>
                public string DeviceID => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_DeviceID..Offset_DeviceDescription]);

                /// <summary>
                /// Retrieves the DeviceDescription field.
                /// </summary>
                public string DeviceDescription => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_DeviceDescription..Offset_FriendlyName]);

                /// <summary>
                /// Retrieves the FriendlyName field.
                /// </summary>
                public string FriendlyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FriendlyName..]);

                /// <summary>
                /// Creates a new PnPData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public PnPData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_IDLength = -1;
                    _offset_DescriptionLength = -1;
                    _offset_FriendlyNameLength = -1;
                    _offset_DeviceID = -1;
                    _offset_DeviceDescription = -1;
                    _offset_FriendlyName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a IDEChannel event.
        /// </summary>
        public readonly ref struct IDEChannelEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "IDEChannel";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 0,
                Version = 2,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.IDEChannel,
                Task = 0,
                Keyword = 0
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
            public IDEChannelData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new IDEChannelEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public IDEChannelEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a IDEChannelEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator IDEChannelEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a IDEChannel event.
            /// </summary>
            public ref struct IDEChannelData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_TargetId;
                private int _offset_DeviceType;
                private int _offset_DeviceTimingMode;
                private int _offset_LocationInformationLen;
                private int _offset_LocationInformation;

                private int Offset_TargetId
                {
                    get
                    {
                        if (_offset_TargetId == -1)
                        {
                            _offset_TargetId = 0;
                        }

                        return _offset_TargetId;
                    }
                }

                private int Offset_DeviceType
                {
                    get
                    {
                        if (_offset_DeviceType == -1)
                        {
                            _offset_DeviceType = Offset_TargetId + 4;
                        }

                        return _offset_DeviceType;
                    }
                }

                private int Offset_DeviceTimingMode
                {
                    get
                    {
                        if (_offset_DeviceTimingMode == -1)
                        {
                            _offset_DeviceTimingMode = Offset_DeviceType + 4;
                        }

                        return _offset_DeviceTimingMode;
                    }
                }

                private int Offset_LocationInformationLen
                {
                    get
                    {
                        if (_offset_LocationInformationLen == -1)
                        {
                            _offset_LocationInformationLen = Offset_DeviceTimingMode + 4;
                        }

                        return _offset_LocationInformationLen;
                    }
                }

                private int Offset_LocationInformation
                {
                    get
                    {
                        if (_offset_LocationInformation == -1)
                        {
                            _offset_LocationInformation = Offset_LocationInformationLen + 4;
                        }

                        return _offset_LocationInformation;
                    }
                }

                /// <summary>
                /// Retrieves the TargetId field.
                /// </summary>
                public uint TargetId => BitConverter.ToUInt32(_etwEvent.Data[Offset_TargetId..Offset_DeviceType]);

                /// <summary>
                /// Retrieves the DeviceType field.
                /// </summary>
                public uint DeviceType => BitConverter.ToUInt32(_etwEvent.Data[Offset_DeviceType..Offset_DeviceTimingMode]);

                /// <summary>
                /// Retrieves the DeviceTimingMode field.
                /// </summary>
                public uint DeviceTimingMode => BitConverter.ToUInt32(_etwEvent.Data[Offset_DeviceTimingMode..Offset_LocationInformationLen]);

                /// <summary>
                /// Retrieves the LocationInformationLen field.
                /// </summary>
                public uint LocationInformationLen => BitConverter.ToUInt32(_etwEvent.Data[Offset_LocationInformationLen..Offset_LocationInformation]);

                /// <summary>
                /// Retrieves the LocationInformation field.
                /// </summary>
                public string LocationInformation => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_LocationInformation..]);

                /// <summary>
                /// Creates a new IDEChannelData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public IDEChannelData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_TargetId = -1;
                    _offset_DeviceType = -1;
                    _offset_DeviceTimingMode = -1;
                    _offset_LocationInformationLen = -1;
                    _offset_LocationInformation = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a NumaNode event.
        /// </summary>
        public readonly ref struct NumaNodeEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "NumaNode";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 0,
                Version = 2,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.NumaNode,
                Task = 0,
                Keyword = 0
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
            public NumaNodeData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new NumaNodeEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public NumaNodeEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a NumaNodeEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator NumaNodeEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a NumaNode event.
            /// </summary>
            public ref struct NumaNodeData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_NodeCount;
                private int _offset_NodeMap;

                private int Offset_NodeCount
                {
                    get
                    {
                        if (_offset_NodeCount == -1)
                        {
                            _offset_NodeCount = 0;
                        }

                        return _offset_NodeCount;
                    }
                }

                private int Offset_NodeMap
                {
                    get
                    {
                        if (_offset_NodeMap == -1)
                        {
                            _offset_NodeMap = Offset_NodeCount + 4;
                        }

                        return _offset_NodeMap;
                    }
                }

                /// <summary>
                /// Retrieves the NodeCount field.
                /// </summary>
                public uint NodeCount => BitConverter.ToUInt32(_etwEvent.Data[Offset_NodeCount..Offset_NodeMap]);

                /// <summary>
                /// Retrieves the NodeMap field.
                /// </summary>
                public EtwEvent.StructEnumerable<ulong> NodeMap => new(_etwEvent, Offset_NodeMap, NodeCount);

                /// <summary>
                /// Creates a new NumaNodeData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public NumaNodeData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_NodeCount = -1;
                    _offset_NodeMap = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Platform event.
        /// </summary>
        public readonly ref struct PlatformEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Platform";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 0,
                Version = 2,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.Platform,
                Task = 0,
                Keyword = 0
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
            public PlatformData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new PlatformEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public PlatformEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a PlatformEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator PlatformEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Platform event.
            /// </summary>
            public ref struct PlatformData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_SystemManufacturer;
                private int _offset_SystemProductName;
                private int _offset_BiosDate;
                private int _offset_BiosVersion;

                private int Offset_SystemManufacturer
                {
                    get
                    {
                        if (_offset_SystemManufacturer == -1)
                        {
                            _offset_SystemManufacturer = 0;
                        }

                        return _offset_SystemManufacturer;
                    }
                }

                private int Offset_SystemProductName
                {
                    get
                    {
                        if (_offset_SystemProductName == -1)
                        {
                            _offset_SystemProductName = Offset_SystemManufacturer + _etwEvent.UnicodeStringLength(Offset_SystemManufacturer);
                        }

                        return _offset_SystemProductName;
                    }
                }

                private int Offset_BiosDate
                {
                    get
                    {
                        if (_offset_BiosDate == -1)
                        {
                            _offset_BiosDate = Offset_SystemProductName + _etwEvent.UnicodeStringLength(Offset_SystemProductName);
                        }

                        return _offset_BiosDate;
                    }
                }

                private int Offset_BiosVersion
                {
                    get
                    {
                        if (_offset_BiosVersion == -1)
                        {
                            _offset_BiosVersion = Offset_BiosDate + _etwEvent.UnicodeStringLength(Offset_BiosDate);
                        }

                        return _offset_BiosVersion;
                    }
                }

                /// <summary>
                /// Retrieves the SystemManufacturer field.
                /// </summary>
                public string SystemManufacturer => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_SystemManufacturer..Offset_SystemProductName]);

                /// <summary>
                /// Retrieves the SystemProductName field.
                /// </summary>
                public string SystemProductName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_SystemProductName..Offset_BiosDate]);

                /// <summary>
                /// Retrieves the BiosDate field.
                /// </summary>
                public string BiosDate => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_BiosDate..Offset_BiosVersion]);

                /// <summary>
                /// Retrieves the BiosVersion field.
                /// </summary>
                public string BiosVersion => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_BiosVersion..]);

                /// <summary>
                /// Creates a new PlatformData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public PlatformData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_SystemManufacturer = -1;
                    _offset_SystemProductName = -1;
                    _offset_BiosDate = -1;
                    _offset_BiosVersion = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ProcessorGroup event.
        /// </summary>
        public readonly ref struct ProcessorGroupEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ProcessorGroup";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 0,
                Version = 2,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.ProcessorGroup,
                Task = 0,
                Keyword = 0
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
            public ProcessorGroupData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ProcessorGroupEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ProcessorGroupEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a ProcessorGroupEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator ProcessorGroupEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a ProcessorGroup event.
            /// </summary>
            public ref struct ProcessorGroupData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_GroupCount;
                private int _offset_Affinity;

                private int Offset_GroupCount
                {
                    get
                    {
                        if (_offset_GroupCount == -1)
                        {
                            _offset_GroupCount = 0;
                        }

                        return _offset_GroupCount;
                    }
                }

                private int Offset_Affinity
                {
                    get
                    {
                        if (_offset_Affinity == -1)
                        {
                            _offset_Affinity = Offset_GroupCount + 4;
                        }

                        return _offset_Affinity;
                    }
                }

                /// <summary>
                /// Retrieves the GroupCount field.
                /// </summary>
                public uint GroupCount => BitConverter.ToUInt32(_etwEvent.Data[Offset_GroupCount..Offset_Affinity]);

                /// <summary>
                /// Retrieves the Affinity field.
                /// </summary>
                public EtwEvent.AddressEnumerable Affinity => new(_etwEvent, Offset_Affinity, GroupCount);

                /// <summary>
                /// Creates a new ProcessorGroupData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ProcessorGroupData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_GroupCount = -1;
                    _offset_Affinity = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a ProcessorNumber event.
        /// </summary>
        public readonly ref struct ProcessorNumberEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "ProcessorNumber";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 0,
                Version = 2,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.ProcessorNumber,
                Task = 0,
                Keyword = 0
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
            public ProcessorNumberData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ProcessorNumberEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ProcessorNumberEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a ProcessorNumberEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator ProcessorNumberEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a ProcessorNumber event.
            /// </summary>
            public ref struct ProcessorNumberData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProcessorCount;
                private int _offset_ProcessorNumber;

                private int Offset_ProcessorCount
                {
                    get
                    {
                        if (_offset_ProcessorCount == -1)
                        {
                            _offset_ProcessorCount = 0;
                        }

                        return _offset_ProcessorCount;
                    }
                }

                private int Offset_ProcessorNumber
                {
                    get
                    {
                        if (_offset_ProcessorNumber == -1)
                        {
                            _offset_ProcessorNumber = Offset_ProcessorCount + 4;
                        }

                        return _offset_ProcessorNumber;
                    }
                }

                /// <summary>
                /// Retrieves the ProcessorCount field.
                /// </summary>
                public uint ProcessorCount => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessorCount..Offset_ProcessorNumber]);

                /// <summary>
                /// Retrieves the ProcessorNumber field.
                /// </summary>
                public EtwEvent.StructEnumerable<uint> ProcessorNumber => new(_etwEvent, Offset_ProcessorNumber, ProcessorCount);

                /// <summary>
                /// Creates a new ProcessorNumberData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ProcessorNumberData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProcessorCount = -1;
                    _offset_ProcessorNumber = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DPI event.
        /// </summary>
        public readonly ref struct DPIEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DPI";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 0,
                Version = 2,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.DPI,
                Task = 0,
                Keyword = 0
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
            public DPIData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DPIEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DPIEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a DPIEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator DPIEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a DPI event.
            /// </summary>
            public ref struct DPIData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_MachineDPI;
                private int _offset_UserDPI;

                private int Offset_MachineDPI
                {
                    get
                    {
                        if (_offset_MachineDPI == -1)
                        {
                            _offset_MachineDPI = 0;
                        }

                        return _offset_MachineDPI;
                    }
                }

                private int Offset_UserDPI
                {
                    get
                    {
                        if (_offset_UserDPI == -1)
                        {
                            _offset_UserDPI = Offset_MachineDPI + 4;
                        }

                        return _offset_UserDPI;
                    }
                }

                /// <summary>
                /// Retrieves the MachineDPI field.
                /// </summary>
                public uint MachineDPI => BitConverter.ToUInt32(_etwEvent.Data[Offset_MachineDPI..Offset_UserDPI]);

                /// <summary>
                /// Retrieves the UserDPI field.
                /// </summary>
                public uint UserDPI => BitConverter.ToUInt32(_etwEvent.Data[Offset_UserDPI..]);

                /// <summary>
                /// Creates a new DPIData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DPIData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_MachineDPI = -1;
                    _offset_UserDPI = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a CodeIntegrity event.
        /// </summary>
        public readonly ref struct CodeIntegrityEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "CodeIntegrity";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 0,
                Version = 2,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.CodeIntegrity,
                Task = 0,
                Keyword = 0
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
            public CodeIntegrityData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new CodeIntegrityEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public CodeIntegrityEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a CodeIntegrityEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator CodeIntegrityEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a CodeIntegrity event.
            /// </summary>
            public ref struct CodeIntegrityData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_CodeIntegrityInfo;

                private int Offset_CodeIntegrityInfo
                {
                    get
                    {
                        if (_offset_CodeIntegrityInfo == -1)
                        {
                            _offset_CodeIntegrityInfo = 0;
                        }

                        return _offset_CodeIntegrityInfo;
                    }
                }

                /// <summary>
                /// Retrieves the CodeIntegrityInfo field.
                /// </summary>
                public uint CodeIntegrityInfo => BitConverter.ToUInt32(_etwEvent.Data[Offset_CodeIntegrityInfo..]);

                /// <summary>
                /// Creates a new CodeIntegrityData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public CodeIntegrityData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_CodeIntegrityInfo = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a TelemetryConfiguration event.
        /// </summary>
        public readonly ref struct TelemetryConfigurationEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "TelemetryConfiguration";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 0,
                Version = 2,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.TelemetryConfiguration,
                Task = 0,
                Keyword = 0
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
            public TelemetryConfigurationData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new TelemetryConfigurationEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public TelemetryConfigurationEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a TelemetryConfigurationEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator TelemetryConfigurationEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a TelemetryConfiguration event.
            /// </summary>
            public ref struct TelemetryConfigurationData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_MachineId;

                private int Offset_MachineId
                {
                    get
                    {
                        if (_offset_MachineId == -1)
                        {
                            _offset_MachineId = 0;
                        }

                        return _offset_MachineId;
                    }
                }

                /// <summary>
                /// Retrieves the MachineId field.
                /// </summary>
                public Guid MachineId => new(_etwEvent.Data[Offset_MachineId..]);

                /// <summary>
                /// Creates a new TelemetryConfigurationData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public TelemetryConfigurationData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_MachineId = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Defragmentation event.
        /// </summary>
        public readonly ref struct DefragmentationEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Defragmentation";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 0,
                Version = 2,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.Defragmentation,
                Task = 0,
                Keyword = 0
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
            public DefragmentationData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DefragmentationEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DefragmentationEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a DefragmentationEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator DefragmentationEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Defragmentation event.
            /// </summary>
            public ref struct DefragmentationData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_AlignmentClusters;
                private int _offset_AvgFreeSpaceSize;
                private int _offset_ClustersPerSlab;
                private int _offset_FragmentedDirectoryExtents;
                private int _offset_FragmentedExtents;
                private int _offset_FreeSpaceCount;
                private int _offset_LargestFreeSpaceSize;
                private int _offset_LastRunActualPurgeClusters;
                private int _offset_LastRunClustersTrimmed;
                private int _offset_LastRunFullDefragTime;
                private int _offset_LastRunTime;
                private int _offset_MFTSize;
                private int _offset_TotalClusters;
                private int _offset_TotalUsedClusters;
                private int _offset_AvgFragmentsPerFile;
                private int _offset_BytesPerCluster;
                private int _offset_DirectoryCount;
                private int _offset_FragmentedDirectories;
                private int _offset_FragmentedFiles;
                private int _offset_FragmentedSpace;
                private int _offset_HardwareIssue;
                private int _offset_InUseMFTRecords;
                private int _offset_InUseSlabs;
                private int _offset_LastRunActualPurgeSlabs;
                private int _offset_LastRunInitialBackedSlabs;
                private int _offset_LastRunPercentFragmentation;
                private int _offset_LastRunPinnedSlabs;
                private int _offset_LastRunPotentialPurgeSlabs;
                private int _offset_LastRunSpaceInefficientSlabs;
                private int _offset_LastRunTrimmedSlabs;
                private int _offset_LastRunUnknownEvictFailSlabs;
                private int _offset_LastRunVolsnapPinnedSlabs;
                private int _offset_MFTFragmentCount;
                private int _offset_MovableFiles;
                private int _offset_TotalMFTRecords;
                private int _offset_TotalSlabs;
                private int _offset_UnmovableFiles;
                private int _offset_VolumeId;
                private int _offset_VolumePathNames;

                private int Offset_AlignmentClusters
                {
                    get
                    {
                        if (_offset_AlignmentClusters == -1)
                        {
                            _offset_AlignmentClusters = 0;
                        }

                        return _offset_AlignmentClusters;
                    }
                }

                private int Offset_AvgFreeSpaceSize
                {
                    get
                    {
                        if (_offset_AvgFreeSpaceSize == -1)
                        {
                            _offset_AvgFreeSpaceSize = Offset_AlignmentClusters + 8;
                        }

                        return _offset_AvgFreeSpaceSize;
                    }
                }

                private int Offset_ClustersPerSlab
                {
                    get
                    {
                        if (_offset_ClustersPerSlab == -1)
                        {
                            _offset_ClustersPerSlab = Offset_AvgFreeSpaceSize + 8;
                        }

                        return _offset_ClustersPerSlab;
                    }
                }

                private int Offset_FragmentedDirectoryExtents
                {
                    get
                    {
                        if (_offset_FragmentedDirectoryExtents == -1)
                        {
                            _offset_FragmentedDirectoryExtents = Offset_ClustersPerSlab + 8;
                        }

                        return _offset_FragmentedDirectoryExtents;
                    }
                }

                private int Offset_FragmentedExtents
                {
                    get
                    {
                        if (_offset_FragmentedExtents == -1)
                        {
                            _offset_FragmentedExtents = Offset_FragmentedDirectoryExtents + 8;
                        }

                        return _offset_FragmentedExtents;
                    }
                }

                private int Offset_FreeSpaceCount
                {
                    get
                    {
                        if (_offset_FreeSpaceCount == -1)
                        {
                            _offset_FreeSpaceCount = Offset_FragmentedExtents + 8;
                        }

                        return _offset_FreeSpaceCount;
                    }
                }

                private int Offset_LargestFreeSpaceSize
                {
                    get
                    {
                        if (_offset_LargestFreeSpaceSize == -1)
                        {
                            _offset_LargestFreeSpaceSize = Offset_FreeSpaceCount + 8;
                        }

                        return _offset_LargestFreeSpaceSize;
                    }
                }

                private int Offset_LastRunActualPurgeClusters
                {
                    get
                    {
                        if (_offset_LastRunActualPurgeClusters == -1)
                        {
                            _offset_LastRunActualPurgeClusters = Offset_LargestFreeSpaceSize + 8;
                        }

                        return _offset_LastRunActualPurgeClusters;
                    }
                }

                private int Offset_LastRunClustersTrimmed
                {
                    get
                    {
                        if (_offset_LastRunClustersTrimmed == -1)
                        {
                            _offset_LastRunClustersTrimmed = Offset_LastRunActualPurgeClusters + 8;
                        }

                        return _offset_LastRunClustersTrimmed;
                    }
                }

                private int Offset_LastRunFullDefragTime
                {
                    get
                    {
                        if (_offset_LastRunFullDefragTime == -1)
                        {
                            _offset_LastRunFullDefragTime = Offset_LastRunClustersTrimmed + 8;
                        }

                        return _offset_LastRunFullDefragTime;
                    }
                }

                private int Offset_LastRunTime
                {
                    get
                    {
                        if (_offset_LastRunTime == -1)
                        {
                            _offset_LastRunTime = Offset_LastRunFullDefragTime + 8;
                        }

                        return _offset_LastRunTime;
                    }
                }

                private int Offset_MFTSize
                {
                    get
                    {
                        if (_offset_MFTSize == -1)
                        {
                            _offset_MFTSize = Offset_LastRunTime + 8;
                        }

                        return _offset_MFTSize;
                    }
                }

                private int Offset_TotalClusters
                {
                    get
                    {
                        if (_offset_TotalClusters == -1)
                        {
                            _offset_TotalClusters = Offset_MFTSize + 8;
                        }

                        return _offset_TotalClusters;
                    }
                }

                private int Offset_TotalUsedClusters
                {
                    get
                    {
                        if (_offset_TotalUsedClusters == -1)
                        {
                            _offset_TotalUsedClusters = Offset_TotalClusters + 8;
                        }

                        return _offset_TotalUsedClusters;
                    }
                }

                private int Offset_AvgFragmentsPerFile
                {
                    get
                    {
                        if (_offset_AvgFragmentsPerFile == -1)
                        {
                            _offset_AvgFragmentsPerFile = Offset_TotalUsedClusters + 8;
                        }

                        return _offset_AvgFragmentsPerFile;
                    }
                }

                private int Offset_BytesPerCluster
                {
                    get
                    {
                        if (_offset_BytesPerCluster == -1)
                        {
                            _offset_BytesPerCluster = Offset_AvgFragmentsPerFile + 4;
                        }

                        return _offset_BytesPerCluster;
                    }
                }

                private int Offset_DirectoryCount
                {
                    get
                    {
                        if (_offset_DirectoryCount == -1)
                        {
                            _offset_DirectoryCount = Offset_BytesPerCluster + 4;
                        }

                        return _offset_DirectoryCount;
                    }
                }

                private int Offset_FragmentedDirectories
                {
                    get
                    {
                        if (_offset_FragmentedDirectories == -1)
                        {
                            _offset_FragmentedDirectories = Offset_DirectoryCount + 4;
                        }

                        return _offset_FragmentedDirectories;
                    }
                }

                private int Offset_FragmentedFiles
                {
                    get
                    {
                        if (_offset_FragmentedFiles == -1)
                        {
                            _offset_FragmentedFiles = Offset_FragmentedDirectories + 4;
                        }

                        return _offset_FragmentedFiles;
                    }
                }

                private int Offset_FragmentedSpace
                {
                    get
                    {
                        if (_offset_FragmentedSpace == -1)
                        {
                            _offset_FragmentedSpace = Offset_FragmentedFiles + 4;
                        }

                        return _offset_FragmentedSpace;
                    }
                }

                private int Offset_HardwareIssue
                {
                    get
                    {
                        if (_offset_HardwareIssue == -1)
                        {
                            _offset_HardwareIssue = Offset_FragmentedSpace + 4;
                        }

                        return _offset_HardwareIssue;
                    }
                }

                private int Offset_InUseMFTRecords
                {
                    get
                    {
                        if (_offset_InUseMFTRecords == -1)
                        {
                            _offset_InUseMFTRecords = Offset_HardwareIssue + 4;
                        }

                        return _offset_InUseMFTRecords;
                    }
                }

                private int Offset_InUseSlabs
                {
                    get
                    {
                        if (_offset_InUseSlabs == -1)
                        {
                            _offset_InUseSlabs = Offset_InUseMFTRecords + 4;
                        }

                        return _offset_InUseSlabs;
                    }
                }

                private int Offset_LastRunActualPurgeSlabs
                {
                    get
                    {
                        if (_offset_LastRunActualPurgeSlabs == -1)
                        {
                            _offset_LastRunActualPurgeSlabs = Offset_InUseSlabs + 4;
                        }

                        return _offset_LastRunActualPurgeSlabs;
                    }
                }

                private int Offset_LastRunInitialBackedSlabs
                {
                    get
                    {
                        if (_offset_LastRunInitialBackedSlabs == -1)
                        {
                            _offset_LastRunInitialBackedSlabs = Offset_LastRunActualPurgeSlabs + 4;
                        }

                        return _offset_LastRunInitialBackedSlabs;
                    }
                }

                private int Offset_LastRunPercentFragmentation
                {
                    get
                    {
                        if (_offset_LastRunPercentFragmentation == -1)
                        {
                            _offset_LastRunPercentFragmentation = Offset_LastRunInitialBackedSlabs + 4;
                        }

                        return _offset_LastRunPercentFragmentation;
                    }
                }

                private int Offset_LastRunPinnedSlabs
                {
                    get
                    {
                        if (_offset_LastRunPinnedSlabs == -1)
                        {
                            _offset_LastRunPinnedSlabs = Offset_LastRunPercentFragmentation + 4;
                        }

                        return _offset_LastRunPinnedSlabs;
                    }
                }

                private int Offset_LastRunPotentialPurgeSlabs
                {
                    get
                    {
                        if (_offset_LastRunPotentialPurgeSlabs == -1)
                        {
                            _offset_LastRunPotentialPurgeSlabs = Offset_LastRunPinnedSlabs + 4;
                        }

                        return _offset_LastRunPotentialPurgeSlabs;
                    }
                }

                private int Offset_LastRunSpaceInefficientSlabs
                {
                    get
                    {
                        if (_offset_LastRunSpaceInefficientSlabs == -1)
                        {
                            _offset_LastRunSpaceInefficientSlabs = Offset_LastRunPotentialPurgeSlabs + 4;
                        }

                        return _offset_LastRunSpaceInefficientSlabs;
                    }
                }

                private int Offset_LastRunTrimmedSlabs
                {
                    get
                    {
                        if (_offset_LastRunTrimmedSlabs == -1)
                        {
                            _offset_LastRunTrimmedSlabs = Offset_LastRunSpaceInefficientSlabs + 4;
                        }

                        return _offset_LastRunTrimmedSlabs;
                    }
                }

                private int Offset_LastRunUnknownEvictFailSlabs
                {
                    get
                    {
                        if (_offset_LastRunUnknownEvictFailSlabs == -1)
                        {
                            _offset_LastRunUnknownEvictFailSlabs = Offset_LastRunTrimmedSlabs + 4;
                        }

                        return _offset_LastRunUnknownEvictFailSlabs;
                    }
                }

                private int Offset_LastRunVolsnapPinnedSlabs
                {
                    get
                    {
                        if (_offset_LastRunVolsnapPinnedSlabs == -1)
                        {
                            _offset_LastRunVolsnapPinnedSlabs = Offset_LastRunUnknownEvictFailSlabs + 4;
                        }

                        return _offset_LastRunVolsnapPinnedSlabs;
                    }
                }

                private int Offset_MFTFragmentCount
                {
                    get
                    {
                        if (_offset_MFTFragmentCount == -1)
                        {
                            _offset_MFTFragmentCount = Offset_LastRunVolsnapPinnedSlabs + 4;
                        }

                        return _offset_MFTFragmentCount;
                    }
                }

                private int Offset_MovableFiles
                {
                    get
                    {
                        if (_offset_MovableFiles == -1)
                        {
                            _offset_MovableFiles = Offset_MFTFragmentCount + 4;
                        }

                        return _offset_MovableFiles;
                    }
                }

                private int Offset_TotalMFTRecords
                {
                    get
                    {
                        if (_offset_TotalMFTRecords == -1)
                        {
                            _offset_TotalMFTRecords = Offset_MovableFiles + 4;
                        }

                        return _offset_TotalMFTRecords;
                    }
                }

                private int Offset_TotalSlabs
                {
                    get
                    {
                        if (_offset_TotalSlabs == -1)
                        {
                            _offset_TotalSlabs = Offset_TotalMFTRecords + 4;
                        }

                        return _offset_TotalSlabs;
                    }
                }

                private int Offset_UnmovableFiles
                {
                    get
                    {
                        if (_offset_UnmovableFiles == -1)
                        {
                            _offset_UnmovableFiles = Offset_TotalSlabs + 4;
                        }

                        return _offset_UnmovableFiles;
                    }
                }

                private int Offset_VolumeId
                {
                    get
                    {
                        if (_offset_VolumeId == -1)
                        {
                            _offset_VolumeId = Offset_UnmovableFiles + 4;
                        }

                        return _offset_VolumeId;
                    }
                }

                private int Offset_VolumePathNames
                {
                    get
                    {
                        if (_offset_VolumePathNames == -1)
                        {
                            _offset_VolumePathNames = Offset_VolumeId + 16;
                        }

                        return _offset_VolumePathNames;
                    }
                }

                /// <summary>
                /// Retrieves the AlignmentClusters field.
                /// </summary>
                public ulong AlignmentClusters => BitConverter.ToUInt64(_etwEvent.Data[Offset_AlignmentClusters..Offset_AvgFreeSpaceSize]);

                /// <summary>
                /// Retrieves the AvgFreeSpaceSize field.
                /// </summary>
                public ulong AvgFreeSpaceSize => BitConverter.ToUInt64(_etwEvent.Data[Offset_AvgFreeSpaceSize..Offset_ClustersPerSlab]);

                /// <summary>
                /// Retrieves the ClustersPerSlab field.
                /// </summary>
                public ulong ClustersPerSlab => BitConverter.ToUInt64(_etwEvent.Data[Offset_ClustersPerSlab..Offset_FragmentedDirectoryExtents]);

                /// <summary>
                /// Retrieves the FragmentedDirectoryExtents field.
                /// </summary>
                public ulong FragmentedDirectoryExtents => BitConverter.ToUInt64(_etwEvent.Data[Offset_FragmentedDirectoryExtents..Offset_FragmentedExtents]);

                /// <summary>
                /// Retrieves the FragmentedExtents field.
                /// </summary>
                public ulong FragmentedExtents => BitConverter.ToUInt64(_etwEvent.Data[Offset_FragmentedExtents..Offset_FreeSpaceCount]);

                /// <summary>
                /// Retrieves the FreeSpaceCount field.
                /// </summary>
                public ulong FreeSpaceCount => BitConverter.ToUInt64(_etwEvent.Data[Offset_FreeSpaceCount..Offset_LargestFreeSpaceSize]);

                /// <summary>
                /// Retrieves the LargestFreeSpaceSize field.
                /// </summary>
                public ulong LargestFreeSpaceSize => BitConverter.ToUInt64(_etwEvent.Data[Offset_LargestFreeSpaceSize..Offset_LastRunActualPurgeClusters]);

                /// <summary>
                /// Retrieves the LastRunActualPurgeClusters field.
                /// </summary>
                public ulong LastRunActualPurgeClusters => BitConverter.ToUInt64(_etwEvent.Data[Offset_LastRunActualPurgeClusters..Offset_LastRunClustersTrimmed]);

                /// <summary>
                /// Retrieves the LastRunClustersTrimmed field.
                /// </summary>
                public ulong LastRunClustersTrimmed => BitConverter.ToUInt64(_etwEvent.Data[Offset_LastRunClustersTrimmed..Offset_LastRunFullDefragTime]);

                /// <summary>
                /// Retrieves the LastRunFullDefragTime field.
                /// </summary>
                public ulong LastRunFullDefragTime => BitConverter.ToUInt64(_etwEvent.Data[Offset_LastRunFullDefragTime..Offset_LastRunTime]);

                /// <summary>
                /// Retrieves the LastRunTime field.
                /// </summary>
                public ulong LastRunTime => BitConverter.ToUInt64(_etwEvent.Data[Offset_LastRunTime..Offset_MFTSize]);

                /// <summary>
                /// Retrieves the MFTSize field.
                /// </summary>
                public ulong MFTSize => BitConverter.ToUInt64(_etwEvent.Data[Offset_MFTSize..Offset_TotalClusters]);

                /// <summary>
                /// Retrieves the TotalClusters field.
                /// </summary>
                public ulong TotalClusters => BitConverter.ToUInt64(_etwEvent.Data[Offset_TotalClusters..Offset_TotalUsedClusters]);

                /// <summary>
                /// Retrieves the TotalUsedClusters field.
                /// </summary>
                public ulong TotalUsedClusters => BitConverter.ToUInt64(_etwEvent.Data[Offset_TotalUsedClusters..Offset_AvgFragmentsPerFile]);

                /// <summary>
                /// Retrieves the AvgFragmentsPerFile field.
                /// </summary>
                public uint AvgFragmentsPerFile => BitConverter.ToUInt32(_etwEvent.Data[Offset_AvgFragmentsPerFile..Offset_BytesPerCluster]);

                /// <summary>
                /// Retrieves the BytesPerCluster field.
                /// </summary>
                public uint BytesPerCluster => BitConverter.ToUInt32(_etwEvent.Data[Offset_BytesPerCluster..Offset_DirectoryCount]);

                /// <summary>
                /// Retrieves the DirectoryCount field.
                /// </summary>
                public uint DirectoryCount => BitConverter.ToUInt32(_etwEvent.Data[Offset_DirectoryCount..Offset_FragmentedDirectories]);

                /// <summary>
                /// Retrieves the FragmentedDirectories field.
                /// </summary>
                public uint FragmentedDirectories => BitConverter.ToUInt32(_etwEvent.Data[Offset_FragmentedDirectories..Offset_FragmentedFiles]);

                /// <summary>
                /// Retrieves the FragmentedFiles field.
                /// </summary>
                public uint FragmentedFiles => BitConverter.ToUInt32(_etwEvent.Data[Offset_FragmentedFiles..Offset_FragmentedSpace]);

                /// <summary>
                /// Retrieves the FragmentedSpace field.
                /// </summary>
                public uint FragmentedSpace => BitConverter.ToUInt32(_etwEvent.Data[Offset_FragmentedSpace..Offset_HardwareIssue]);

                /// <summary>
                /// Retrieves the HardwareIssue field.
                /// </summary>
                public uint HardwareIssue => BitConverter.ToUInt32(_etwEvent.Data[Offset_HardwareIssue..Offset_InUseMFTRecords]);

                /// <summary>
                /// Retrieves the InUseMFTRecords field.
                /// </summary>
                public uint InUseMFTRecords => BitConverter.ToUInt32(_etwEvent.Data[Offset_InUseMFTRecords..Offset_InUseSlabs]);

                /// <summary>
                /// Retrieves the InUseSlabs field.
                /// </summary>
                public uint InUseSlabs => BitConverter.ToUInt32(_etwEvent.Data[Offset_InUseSlabs..Offset_LastRunActualPurgeSlabs]);

                /// <summary>
                /// Retrieves the LastRunActualPurgeSlabs field.
                /// </summary>
                public uint LastRunActualPurgeSlabs => BitConverter.ToUInt32(_etwEvent.Data[Offset_LastRunActualPurgeSlabs..Offset_LastRunInitialBackedSlabs]);

                /// <summary>
                /// Retrieves the LastRunInitialBackedSlabs field.
                /// </summary>
                public uint LastRunInitialBackedSlabs => BitConverter.ToUInt32(_etwEvent.Data[Offset_LastRunInitialBackedSlabs..Offset_LastRunPercentFragmentation]);

                /// <summary>
                /// Retrieves the LastRunPercentFragmentation field.
                /// </summary>
                public uint LastRunPercentFragmentation => BitConverter.ToUInt32(_etwEvent.Data[Offset_LastRunPercentFragmentation..Offset_LastRunPinnedSlabs]);

                /// <summary>
                /// Retrieves the LastRunPinnedSlabs field.
                /// </summary>
                public uint LastRunPinnedSlabs => BitConverter.ToUInt32(_etwEvent.Data[Offset_LastRunPinnedSlabs..Offset_LastRunPotentialPurgeSlabs]);

                /// <summary>
                /// Retrieves the LastRunPotentialPurgeSlabs field.
                /// </summary>
                public uint LastRunPotentialPurgeSlabs => BitConverter.ToUInt32(_etwEvent.Data[Offset_LastRunPotentialPurgeSlabs..Offset_LastRunSpaceInefficientSlabs]);

                /// <summary>
                /// Retrieves the LastRunSpaceInefficientSlabs field.
                /// </summary>
                public uint LastRunSpaceInefficientSlabs => BitConverter.ToUInt32(_etwEvent.Data[Offset_LastRunSpaceInefficientSlabs..Offset_LastRunTrimmedSlabs]);

                /// <summary>
                /// Retrieves the LastRunTrimmedSlabs field.
                /// </summary>
                public uint LastRunTrimmedSlabs => BitConverter.ToUInt32(_etwEvent.Data[Offset_LastRunTrimmedSlabs..Offset_LastRunUnknownEvictFailSlabs]);

                /// <summary>
                /// Retrieves the LastRunUnknownEvictFailSlabs field.
                /// </summary>
                public uint LastRunUnknownEvictFailSlabs => BitConverter.ToUInt32(_etwEvent.Data[Offset_LastRunUnknownEvictFailSlabs..Offset_LastRunVolsnapPinnedSlabs]);

                /// <summary>
                /// Retrieves the LastRunVolsnapPinnedSlabs field.
                /// </summary>
                public uint LastRunVolsnapPinnedSlabs => BitConverter.ToUInt32(_etwEvent.Data[Offset_LastRunVolsnapPinnedSlabs..Offset_MFTFragmentCount]);

                /// <summary>
                /// Retrieves the MFTFragmentCount field.
                /// </summary>
                public uint MFTFragmentCount => BitConverter.ToUInt32(_etwEvent.Data[Offset_MFTFragmentCount..Offset_MovableFiles]);

                /// <summary>
                /// Retrieves the MovableFiles field.
                /// </summary>
                public uint MovableFiles => BitConverter.ToUInt32(_etwEvent.Data[Offset_MovableFiles..Offset_TotalMFTRecords]);

                /// <summary>
                /// Retrieves the TotalMFTRecords field.
                /// </summary>
                public uint TotalMFTRecords => BitConverter.ToUInt32(_etwEvent.Data[Offset_TotalMFTRecords..Offset_TotalSlabs]);

                /// <summary>
                /// Retrieves the TotalSlabs field.
                /// </summary>
                public uint TotalSlabs => BitConverter.ToUInt32(_etwEvent.Data[Offset_TotalSlabs..Offset_UnmovableFiles]);

                /// <summary>
                /// Retrieves the UnmovableFiles field.
                /// </summary>
                public uint UnmovableFiles => BitConverter.ToUInt32(_etwEvent.Data[Offset_UnmovableFiles..Offset_VolumeId]);

                /// <summary>
                /// Retrieves the VolumeId field.
                /// </summary>
                public Guid VolumeId => new(_etwEvent.Data[Offset_VolumeId..Offset_VolumePathNames]);

                /// <summary>
                /// Retrieves the VolumePathNames field.
                /// </summary>
                public string VolumePathNames => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_VolumePathNames..]);

                /// <summary>
                /// Creates a new DefragmentationData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DefragmentationData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_AlignmentClusters = -1;
                    _offset_AvgFreeSpaceSize = -1;
                    _offset_ClustersPerSlab = -1;
                    _offset_FragmentedDirectoryExtents = -1;
                    _offset_FragmentedExtents = -1;
                    _offset_FreeSpaceCount = -1;
                    _offset_LargestFreeSpaceSize = -1;
                    _offset_LastRunActualPurgeClusters = -1;
                    _offset_LastRunClustersTrimmed = -1;
                    _offset_LastRunFullDefragTime = -1;
                    _offset_LastRunTime = -1;
                    _offset_MFTSize = -1;
                    _offset_TotalClusters = -1;
                    _offset_TotalUsedClusters = -1;
                    _offset_AvgFragmentsPerFile = -1;
                    _offset_BytesPerCluster = -1;
                    _offset_DirectoryCount = -1;
                    _offset_FragmentedDirectories = -1;
                    _offset_FragmentedFiles = -1;
                    _offset_FragmentedSpace = -1;
                    _offset_HardwareIssue = -1;
                    _offset_InUseMFTRecords = -1;
                    _offset_InUseSlabs = -1;
                    _offset_LastRunActualPurgeSlabs = -1;
                    _offset_LastRunInitialBackedSlabs = -1;
                    _offset_LastRunPercentFragmentation = -1;
                    _offset_LastRunPinnedSlabs = -1;
                    _offset_LastRunPotentialPurgeSlabs = -1;
                    _offset_LastRunSpaceInefficientSlabs = -1;
                    _offset_LastRunTrimmedSlabs = -1;
                    _offset_LastRunUnknownEvictFailSlabs = -1;
                    _offset_LastRunVolsnapPinnedSlabs = -1;
                    _offset_MFTFragmentCount = -1;
                    _offset_MovableFiles = -1;
                    _offset_TotalMFTRecords = -1;
                    _offset_TotalSlabs = -1;
                    _offset_UnmovableFiles = -1;
                    _offset_VolumeId = -1;
                    _offset_VolumePathNames = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a MobilePlatform event.
        /// </summary>
        public readonly ref struct MobilePlatformEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "MobilePlatform";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 0,
                Version = 2,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.MobilePlatform,
                Task = 0,
                Keyword = 0
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
            public MobilePlatformData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new MobilePlatformEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public MobilePlatformEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a MobilePlatformEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator MobilePlatformEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a MobilePlatform event.
            /// </summary>
            public ref struct MobilePlatformData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_BootLoaderVersion;
                private int _offset_FirmwareRevision;
                private int _offset_FriendlyName;
                private int _offset_HardwareRevision;
                private int _offset_Manufacturer;
                private int _offset_ManufacturerDisplayName;
                private int _offset_ManufacturerModelName;
                private int _offset_MobileOperatorDisplayName;
                private int _offset_MobileOperatorName;
                private int _offset_ModelName;
                private int _offset_RadioHardwareRevision;
                private int _offset_RadioSoftwareRevision;
                private int _offset_ROMVersion;
                private int _offset_SOCVersion;
                private int _offset_HardwareVariant;

                private int Offset_BootLoaderVersion
                {
                    get
                    {
                        if (_offset_BootLoaderVersion == -1)
                        {
                            _offset_BootLoaderVersion = 0;
                        }

                        return _offset_BootLoaderVersion;
                    }
                }

                private int Offset_FirmwareRevision
                {
                    get
                    {
                        if (_offset_FirmwareRevision == -1)
                        {
                            _offset_FirmwareRevision = Offset_BootLoaderVersion + _etwEvent.UnicodeStringLength(Offset_BootLoaderVersion);
                        }

                        return _offset_FirmwareRevision;
                    }
                }

                private int Offset_FriendlyName
                {
                    get
                    {
                        if (_offset_FriendlyName == -1)
                        {
                            _offset_FriendlyName = Offset_FirmwareRevision + _etwEvent.UnicodeStringLength(Offset_FirmwareRevision);
                        }

                        return _offset_FriendlyName;
                    }
                }

                private int Offset_HardwareRevision
                {
                    get
                    {
                        if (_offset_HardwareRevision == -1)
                        {
                            _offset_HardwareRevision = Offset_FriendlyName + _etwEvent.UnicodeStringLength(Offset_FriendlyName);
                        }

                        return _offset_HardwareRevision;
                    }
                }

                private int Offset_Manufacturer
                {
                    get
                    {
                        if (_offset_Manufacturer == -1)
                        {
                            _offset_Manufacturer = Offset_HardwareRevision + _etwEvent.UnicodeStringLength(Offset_HardwareRevision);
                        }

                        return _offset_Manufacturer;
                    }
                }

                private int Offset_ManufacturerDisplayName
                {
                    get
                    {
                        if (_offset_ManufacturerDisplayName == -1)
                        {
                            _offset_ManufacturerDisplayName = Offset_Manufacturer + _etwEvent.UnicodeStringLength(Offset_Manufacturer);
                        }

                        return _offset_ManufacturerDisplayName;
                    }
                }

                private int Offset_ManufacturerModelName
                {
                    get
                    {
                        if (_offset_ManufacturerModelName == -1)
                        {
                            _offset_ManufacturerModelName = Offset_ManufacturerDisplayName + _etwEvent.UnicodeStringLength(Offset_ManufacturerDisplayName);
                        }

                        return _offset_ManufacturerModelName;
                    }
                }

                private int Offset_MobileOperatorDisplayName
                {
                    get
                    {
                        if (_offset_MobileOperatorDisplayName == -1)
                        {
                            _offset_MobileOperatorDisplayName = Offset_ManufacturerModelName + _etwEvent.UnicodeStringLength(Offset_ManufacturerModelName);
                        }

                        return _offset_MobileOperatorDisplayName;
                    }
                }

                private int Offset_MobileOperatorName
                {
                    get
                    {
                        if (_offset_MobileOperatorName == -1)
                        {
                            _offset_MobileOperatorName = Offset_MobileOperatorDisplayName + _etwEvent.UnicodeStringLength(Offset_MobileOperatorDisplayName);
                        }

                        return _offset_MobileOperatorName;
                    }
                }

                private int Offset_ModelName
                {
                    get
                    {
                        if (_offset_ModelName == -1)
                        {
                            _offset_ModelName = Offset_MobileOperatorName + _etwEvent.UnicodeStringLength(Offset_MobileOperatorName);
                        }

                        return _offset_ModelName;
                    }
                }

                private int Offset_RadioHardwareRevision
                {
                    get
                    {
                        if (_offset_RadioHardwareRevision == -1)
                        {
                            _offset_RadioHardwareRevision = Offset_ModelName + _etwEvent.UnicodeStringLength(Offset_ModelName);
                        }

                        return _offset_RadioHardwareRevision;
                    }
                }

                private int Offset_RadioSoftwareRevision
                {
                    get
                    {
                        if (_offset_RadioSoftwareRevision == -1)
                        {
                            _offset_RadioSoftwareRevision = Offset_RadioHardwareRevision + _etwEvent.UnicodeStringLength(Offset_RadioHardwareRevision);
                        }

                        return _offset_RadioSoftwareRevision;
                    }
                }

                private int Offset_ROMVersion
                {
                    get
                    {
                        if (_offset_ROMVersion == -1)
                        {
                            _offset_ROMVersion = Offset_RadioSoftwareRevision + _etwEvent.UnicodeStringLength(Offset_RadioSoftwareRevision);
                        }

                        return _offset_ROMVersion;
                    }
                }

                private int Offset_SOCVersion
                {
                    get
                    {
                        if (_offset_SOCVersion == -1)
                        {
                            _offset_SOCVersion = Offset_ROMVersion + _etwEvent.UnicodeStringLength(Offset_ROMVersion);
                        }

                        return _offset_SOCVersion;
                    }
                }

                private int Offset_HardwareVariant
                {
                    get
                    {
                        if (_offset_HardwareVariant == -1)
                        {
                            _offset_HardwareVariant = Offset_SOCVersion + _etwEvent.UnicodeStringLength(Offset_SOCVersion);
                        }

                        return _offset_HardwareVariant;
                    }
                }

                /// <summary>
                /// Retrieves the BootLoaderVersion field.
                /// </summary>
                public string BootLoaderVersion => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_BootLoaderVersion..Offset_FirmwareRevision]);

                /// <summary>
                /// Retrieves the FirmwareRevision field.
                /// </summary>
                public string FirmwareRevision => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FirmwareRevision..Offset_FriendlyName]);

                /// <summary>
                /// Retrieves the FriendlyName field.
                /// </summary>
                public string FriendlyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FriendlyName..Offset_HardwareRevision]);

                /// <summary>
                /// Retrieves the HardwareRevision field.
                /// </summary>
                public string HardwareRevision => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_HardwareRevision..Offset_Manufacturer]);

                /// <summary>
                /// Retrieves the Manufacturer field.
                /// </summary>
                public string Manufacturer => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_Manufacturer..Offset_ManufacturerDisplayName]);

                /// <summary>
                /// Retrieves the ManufacturerDisplayName field.
                /// </summary>
                public string ManufacturerDisplayName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ManufacturerDisplayName..Offset_ManufacturerModelName]);

                /// <summary>
                /// Retrieves the ManufacturerModelName field.
                /// </summary>
                public string ManufacturerModelName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ManufacturerModelName..Offset_MobileOperatorDisplayName]);

                /// <summary>
                /// Retrieves the MobileOperatorDisplayName field.
                /// </summary>
                public string MobileOperatorDisplayName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_MobileOperatorDisplayName..Offset_MobileOperatorName]);

                /// <summary>
                /// Retrieves the MobileOperatorName field.
                /// </summary>
                public string MobileOperatorName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_MobileOperatorName..Offset_ModelName]);

                /// <summary>
                /// Retrieves the ModelName field.
                /// </summary>
                public string ModelName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ModelName..Offset_RadioHardwareRevision]);

                /// <summary>
                /// Retrieves the RadioHardwareRevision field.
                /// </summary>
                public string RadioHardwareRevision => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_RadioHardwareRevision..Offset_RadioSoftwareRevision]);

                /// <summary>
                /// Retrieves the RadioSoftwareRevision field.
                /// </summary>
                public string RadioSoftwareRevision => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_RadioSoftwareRevision..Offset_ROMVersion]);

                /// <summary>
                /// Retrieves the ROMVersion field.
                /// </summary>
                public string ROMVersion => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ROMVersion..Offset_SOCVersion]);

                /// <summary>
                /// Retrieves the SOCVersion field.
                /// </summary>
                public string SOCVersion => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_SOCVersion..Offset_HardwareVariant]);

                /// <summary>
                /// Retrieves the HardwareVariant field.
                /// </summary>
                public string HardwareVariant => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_HardwareVariant..]);

                /// <summary>
                /// Creates a new MobilePlatformData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public MobilePlatformData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_BootLoaderVersion = -1;
                    _offset_FirmwareRevision = -1;
                    _offset_FriendlyName = -1;
                    _offset_HardwareRevision = -1;
                    _offset_Manufacturer = -1;
                    _offset_ManufacturerDisplayName = -1;
                    _offset_ManufacturerModelName = -1;
                    _offset_MobileOperatorDisplayName = -1;
                    _offset_MobileOperatorName = -1;
                    _offset_ModelName = -1;
                    _offset_RadioHardwareRevision = -1;
                    _offset_RadioSoftwareRevision = -1;
                    _offset_ROMVersion = -1;
                    _offset_SOCVersion = -1;
                    _offset_HardwareVariant = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a DeviceFamily event.
        /// </summary>
        public readonly ref struct DeviceFamilyEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "DeviceFamily";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 0,
                Version = 2,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.DeviceFamily,
                Task = 0,
                Keyword = 0
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
            public DeviceFamilyData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new DeviceFamilyEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public DeviceFamilyEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a DeviceFamilyEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator DeviceFamilyEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a DeviceFamily event.
            /// </summary>
            public ref struct DeviceFamilyData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_UAPInfo;
                private int _offset_DeviceFamily;
                private int _offset_DeviceForm;

                private int Offset_UAPInfo
                {
                    get
                    {
                        if (_offset_UAPInfo == -1)
                        {
                            _offset_UAPInfo = 0;
                        }

                        return _offset_UAPInfo;
                    }
                }

                private int Offset_DeviceFamily
                {
                    get
                    {
                        if (_offset_DeviceFamily == -1)
                        {
                            _offset_DeviceFamily = Offset_UAPInfo + 8;
                        }

                        return _offset_DeviceFamily;
                    }
                }

                private int Offset_DeviceForm
                {
                    get
                    {
                        if (_offset_DeviceForm == -1)
                        {
                            _offset_DeviceForm = Offset_DeviceFamily + 4;
                        }

                        return _offset_DeviceForm;
                    }
                }

                /// <summary>
                /// Retrieves the UAPInfo field.
                /// </summary>
                public ulong UAPInfo => BitConverter.ToUInt64(_etwEvent.Data[Offset_UAPInfo..Offset_DeviceFamily]);

                /// <summary>
                /// Retrieves the DeviceFamily field.
                /// </summary>
                public uint DeviceFamily => BitConverter.ToUInt32(_etwEvent.Data[Offset_DeviceFamily..Offset_DeviceForm]);

                /// <summary>
                /// Retrieves the DeviceForm field.
                /// </summary>
                public uint DeviceForm => BitConverter.ToUInt32(_etwEvent.Data[Offset_DeviceForm..]);

                /// <summary>
                /// Creates a new DeviceFamilyData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public DeviceFamilyData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_UAPInfo = -1;
                    _offset_DeviceFamily = -1;
                    _offset_DeviceForm = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a FlightIds event.
        /// </summary>
        public readonly ref struct FlightIdsEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "FlightIds";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 0,
                Version = 2,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.FlightIds,
                Task = 0,
                Keyword = 0
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
            public FlightIdsData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new FlightIdsEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public FlightIdsEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a FlightIdsEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator FlightIdsEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a FlightIds event.
            /// </summary>
            public ref struct FlightIdsData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_UpdateId;
                private int _offset_FlightIdList;

                private int Offset_UpdateId
                {
                    get
                    {
                        if (_offset_UpdateId == -1)
                        {
                            _offset_UpdateId = 0;
                        }

                        return _offset_UpdateId;
                    }
                }

                private int Offset_FlightIdList
                {
                    get
                    {
                        if (_offset_FlightIdList == -1)
                        {
                            _offset_FlightIdList = Offset_UpdateId + _etwEvent.UnicodeStringLength(Offset_UpdateId);
                        }

                        return _offset_FlightIdList;
                    }
                }

                /// <summary>
                /// Retrieves the UpdateId field.
                /// </summary>
                public string UpdateId => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_UpdateId..Offset_FlightIdList]);

                /// <summary>
                /// Retrieves the FlightIdList field.
                /// </summary>
                public string FlightIdList => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FlightIdList..]);

                /// <summary>
                /// Creates a new FlightIdsData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public FlightIdsData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_UpdateId = -1;
                    _offset_FlightIdList = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Processors event.
        /// </summary>
        public readonly ref struct ProcessorsEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Processors";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 0,
                Version = 2,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.Processors,
                Task = 0,
                Keyword = 0
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
            public ProcessorsData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ProcessorsEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ProcessorsEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a ProcessorsEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator ProcessorsEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Processors event.
            /// </summary>
            public ref struct ProcessorsData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProcessorIndex;
                private int _offset_FeatureSet;
                private int _offset_ProcessorSpeed;
                private int _offset_ProcessorName;
                private int _offset_VendorIdentifier;
                private int _offset_ProcessorIdentifier;

                private int Offset_ProcessorIndex
                {
                    get
                    {
                        if (_offset_ProcessorIndex == -1)
                        {
                            _offset_ProcessorIndex = 0;
                        }

                        return _offset_ProcessorIndex;
                    }
                }

                private int Offset_FeatureSet
                {
                    get
                    {
                        if (_offset_FeatureSet == -1)
                        {
                            _offset_FeatureSet = Offset_ProcessorIndex + 4;
                        }

                        return _offset_FeatureSet;
                    }
                }

                private int Offset_ProcessorSpeed
                {
                    get
                    {
                        if (_offset_ProcessorSpeed == -1)
                        {
                            _offset_ProcessorSpeed = Offset_FeatureSet + 4;
                        }

                        return _offset_ProcessorSpeed;
                    }
                }

                private int Offset_ProcessorName
                {
                    get
                    {
                        if (_offset_ProcessorName == -1)
                        {
                            _offset_ProcessorName = Offset_ProcessorSpeed + 4;
                        }

                        return _offset_ProcessorName;
                    }
                }

                private int Offset_VendorIdentifier
                {
                    get
                    {
                        if (_offset_VendorIdentifier == -1)
                        {
                            _offset_VendorIdentifier = Offset_ProcessorName + 2;
                        }

                        return _offset_VendorIdentifier;
                    }
                }

                private int Offset_ProcessorIdentifier
                {
                    get
                    {
                        if (_offset_ProcessorIdentifier == -1)
                        {
                            _offset_ProcessorIdentifier = Offset_VendorIdentifier + 2;
                        }

                        return _offset_ProcessorIdentifier;
                    }
                }

                /// <summary>
                /// Retrieves the ProcessorIndex field.
                /// </summary>
                public uint ProcessorIndex => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessorIndex..Offset_FeatureSet]);

                /// <summary>
                /// Retrieves the FeatureSet field.
                /// </summary>
                public uint FeatureSet => BitConverter.ToUInt32(_etwEvent.Data[Offset_FeatureSet..Offset_ProcessorSpeed]);

                /// <summary>
                /// Retrieves the ProcessorSpeed field.
                /// </summary>
                public uint ProcessorSpeed => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessorSpeed..Offset_ProcessorName]);

                /// <summary>
                /// Retrieves the ProcessorName field.
                /// </summary>
                public char ProcessorName => BitConverter.ToChar(_etwEvent.Data[Offset_ProcessorName..Offset_VendorIdentifier]);

                /// <summary>
                /// Retrieves the VendorIdentifier field.
                /// </summary>
                public char VendorIdentifier => BitConverter.ToChar(_etwEvent.Data[Offset_VendorIdentifier..Offset_ProcessorIdentifier]);

                /// <summary>
                /// Retrieves the ProcessorIdentifier field.
                /// </summary>
                public char ProcessorIdentifier => BitConverter.ToChar(_etwEvent.Data[Offset_ProcessorIdentifier..]);

                /// <summary>
                /// Creates a new ProcessorsData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ProcessorsData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProcessorIndex = -1;
                    _offset_FeatureSet = -1;
                    _offset_ProcessorSpeed = -1;
                    _offset_ProcessorName = -1;
                    _offset_VendorIdentifier = -1;
                    _offset_ProcessorIdentifier = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a VirtualizationConfigInfo event.
        /// </summary>
        public readonly ref struct VirtualizationConfigInfoEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "VirtualizationConfigInfo";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 0,
                Version = 2,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.VirtualizationConfigInfo,
                Task = 0,
                Keyword = 0
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
            public VirtualizationConfigInfoData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new VirtualizationConfigInfoEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public VirtualizationConfigInfoEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a VirtualizationConfigInfoEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator VirtualizationConfigInfoEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a VirtualizationConfigInfo event.
            /// </summary>
            public ref struct VirtualizationConfigInfoData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_VbsEnabled;
                private int _offset_HvciEnabled;
                private int _offset_HyperVisorEnabled;
                private int _offset_Reserved;

                private int Offset_VbsEnabled
                {
                    get
                    {
                        if (_offset_VbsEnabled == -1)
                        {
                            _offset_VbsEnabled = 0;
                        }

                        return _offset_VbsEnabled;
                    }
                }

                private int Offset_HvciEnabled
                {
                    get
                    {
                        if (_offset_HvciEnabled == -1)
                        {
                            _offset_HvciEnabled = Offset_VbsEnabled + 1;
                        }

                        return _offset_HvciEnabled;
                    }
                }

                private int Offset_HyperVisorEnabled
                {
                    get
                    {
                        if (_offset_HyperVisorEnabled == -1)
                        {
                            _offset_HyperVisorEnabled = Offset_HvciEnabled + 1;
                        }

                        return _offset_HyperVisorEnabled;
                    }
                }

                private int Offset_Reserved
                {
                    get
                    {
                        if (_offset_Reserved == -1)
                        {
                            _offset_Reserved = Offset_HyperVisorEnabled + 1;
                        }

                        return _offset_Reserved;
                    }
                }

                /// <summary>
                /// Retrieves the VbsEnabled field.
                /// </summary>
                public byte VbsEnabled => _etwEvent.Data[Offset_VbsEnabled];

                /// <summary>
                /// Retrieves the HvciEnabled field.
                /// </summary>
                public byte HvciEnabled => _etwEvent.Data[Offset_HvciEnabled];

                /// <summary>
                /// Retrieves the HyperVisorEnabled field.
                /// </summary>
                public byte HyperVisorEnabled => _etwEvent.Data[Offset_HyperVisorEnabled];

                /// <summary>
                /// Retrieves the Reserved field.
                /// </summary>
                public byte Reserved => _etwEvent.Data[Offset_Reserved];

                /// <summary>
                /// Creates a new VirtualizationConfigInfoData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public VirtualizationConfigInfoData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_VbsEnabled = -1;
                    _offset_HvciEnabled = -1;
                    _offset_HyperVisorEnabled = -1;
                    _offset_Reserved = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a BootConfigInfo event.
        /// </summary>
        public readonly ref struct BootConfigInfoEventV2
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "BootConfigInfo";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 0,
                Version = 2,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.BootConfigInfo,
                Task = 0,
                Keyword = 0
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
            public BootConfigInfoData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new BootConfigInfoEventV2.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public BootConfigInfoEventV2(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a BootConfigInfoEventV2.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator BootConfigInfoEventV2(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a BootConfigInfo event.
            /// </summary>
            public ref struct BootConfigInfoData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_BootFlags;
                private int _offset_FirmwareType;
                private int _offset_SecureBootEnabled;
                private int _offset_SecureBootCapable;
                private int _offset_Reserved1;
                private int _offset_Reserved2;

                private int Offset_BootFlags
                {
                    get
                    {
                        if (_offset_BootFlags == -1)
                        {
                            _offset_BootFlags = 0;
                        }

                        return _offset_BootFlags;
                    }
                }

                private int Offset_FirmwareType
                {
                    get
                    {
                        if (_offset_FirmwareType == -1)
                        {
                            _offset_FirmwareType = Offset_BootFlags + 8;
                        }

                        return _offset_FirmwareType;
                    }
                }

                private int Offset_SecureBootEnabled
                {
                    get
                    {
                        if (_offset_SecureBootEnabled == -1)
                        {
                            _offset_SecureBootEnabled = Offset_FirmwareType + 4;
                        }

                        return _offset_SecureBootEnabled;
                    }
                }

                private int Offset_SecureBootCapable
                {
                    get
                    {
                        if (_offset_SecureBootCapable == -1)
                        {
                            _offset_SecureBootCapable = Offset_SecureBootEnabled + 1;
                        }

                        return _offset_SecureBootCapable;
                    }
                }

                private int Offset_Reserved1
                {
                    get
                    {
                        if (_offset_Reserved1 == -1)
                        {
                            _offset_Reserved1 = Offset_SecureBootCapable + 1;
                        }

                        return _offset_Reserved1;
                    }
                }

                private int Offset_Reserved2
                {
                    get
                    {
                        if (_offset_Reserved2 == -1)
                        {
                            _offset_Reserved2 = Offset_Reserved1 + 1;
                        }

                        return _offset_Reserved2;
                    }
                }

                /// <summary>
                /// Retrieves the BootFlags field.
                /// </summary>
                public ulong BootFlags => BitConverter.ToUInt64(_etwEvent.Data[Offset_BootFlags..Offset_FirmwareType]);

                /// <summary>
                /// Retrieves the FirmwareType field.
                /// </summary>
                public uint FirmwareType => BitConverter.ToUInt32(_etwEvent.Data[Offset_FirmwareType..Offset_SecureBootEnabled]);

                /// <summary>
                /// Retrieves the SecureBootEnabled field.
                /// </summary>
                public byte SecureBootEnabled => _etwEvent.Data[Offset_SecureBootEnabled];

                /// <summary>
                /// Retrieves the SecureBootCapable field.
                /// </summary>
                public byte SecureBootCapable => _etwEvent.Data[Offset_SecureBootCapable];

                /// <summary>
                /// Retrieves the Reserved1 field.
                /// </summary>
                public byte Reserved1 => _etwEvent.Data[Offset_Reserved1];

                /// <summary>
                /// Retrieves the Reserved2 field.
                /// </summary>
                public byte Reserved2 => _etwEvent.Data[Offset_Reserved2];

                /// <summary>
                /// Creates a new BootConfigInfoData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public BootConfigInfoData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_BootFlags = -1;
                    _offset_FirmwareType = -1;
                    _offset_SecureBootEnabled = -1;
                    _offset_SecureBootCapable = -1;
                    _offset_Reserved1 = -1;
                    _offset_Reserved2 = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a CPU event.
        /// </summary>
        public readonly ref struct CPUEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "CPU";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 0,
                Version = 3,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.CPU,
                Task = 0,
                Keyword = 0
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
            public CPUData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new CPUEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public CPUEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a CPUEventV3.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator CPUEventV3(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a CPU event.
            /// </summary>
            public ref struct CPUData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_MHz;
                private int _offset_NumberOfProcessors;
                private int _offset_MemSize;
                private int _offset_PageSize;
                private int _offset_AllocationGranularity;
                private int _offset_ComputerName;
                private int _offset_DomainName;
                private int _offset_HyperThreadingFlag;
                private int _offset_HighestUserAddress;
                private int _offset_ProcessorArchitecture;
                private int _offset_ProcessorLevel;
                private int _offset_ProcessorRevision;
                private int _offset_PaeEnabled;
                private int _offset_NxEnabled;
                private int _offset_MemorySpeed;

                private int Offset_MHz
                {
                    get
                    {
                        if (_offset_MHz == -1)
                        {
                            _offset_MHz = 0;
                        }

                        return _offset_MHz;
                    }
                }

                private int Offset_NumberOfProcessors
                {
                    get
                    {
                        if (_offset_NumberOfProcessors == -1)
                        {
                            _offset_NumberOfProcessors = Offset_MHz + 4;
                        }

                        return _offset_NumberOfProcessors;
                    }
                }

                private int Offset_MemSize
                {
                    get
                    {
                        if (_offset_MemSize == -1)
                        {
                            _offset_MemSize = Offset_NumberOfProcessors + 4;
                        }

                        return _offset_MemSize;
                    }
                }

                private int Offset_PageSize
                {
                    get
                    {
                        if (_offset_PageSize == -1)
                        {
                            _offset_PageSize = Offset_MemSize + 4;
                        }

                        return _offset_PageSize;
                    }
                }

                private int Offset_AllocationGranularity
                {
                    get
                    {
                        if (_offset_AllocationGranularity == -1)
                        {
                            _offset_AllocationGranularity = Offset_PageSize + 4;
                        }

                        return _offset_AllocationGranularity;
                    }
                }

                private int Offset_ComputerName
                {
                    get
                    {
                        if (_offset_ComputerName == -1)
                        {
                            _offset_ComputerName = Offset_AllocationGranularity + 4;
                        }

                        return _offset_ComputerName;
                    }
                }

                private int Offset_DomainName
                {
                    get
                    {
                        if (_offset_DomainName == -1)
                        {
                            _offset_DomainName = Offset_ComputerName + 2;
                        }

                        return _offset_DomainName;
                    }
                }

                private int Offset_HyperThreadingFlag
                {
                    get
                    {
                        if (_offset_HyperThreadingFlag == -1)
                        {
                            _offset_HyperThreadingFlag = Offset_DomainName + 2;
                        }

                        return _offset_HyperThreadingFlag;
                    }
                }

                private int Offset_HighestUserAddress
                {
                    get
                    {
                        if (_offset_HighestUserAddress == -1)
                        {
                            _offset_HighestUserAddress = Offset_HyperThreadingFlag + _etwEvent.AddressSize;
                        }

                        return _offset_HighestUserAddress;
                    }
                }

                private int Offset_ProcessorArchitecture
                {
                    get
                    {
                        if (_offset_ProcessorArchitecture == -1)
                        {
                            _offset_ProcessorArchitecture = Offset_HighestUserAddress + _etwEvent.AddressSize;
                        }

                        return _offset_ProcessorArchitecture;
                    }
                }

                private int Offset_ProcessorLevel
                {
                    get
                    {
                        if (_offset_ProcessorLevel == -1)
                        {
                            _offset_ProcessorLevel = Offset_ProcessorArchitecture + 2;
                        }

                        return _offset_ProcessorLevel;
                    }
                }

                private int Offset_ProcessorRevision
                {
                    get
                    {
                        if (_offset_ProcessorRevision == -1)
                        {
                            _offset_ProcessorRevision = Offset_ProcessorLevel + 2;
                        }

                        return _offset_ProcessorRevision;
                    }
                }

                private int Offset_PaeEnabled
                {
                    get
                    {
                        if (_offset_PaeEnabled == -1)
                        {
                            _offset_PaeEnabled = Offset_ProcessorRevision + 2;
                        }

                        return _offset_PaeEnabled;
                    }
                }

                private int Offset_NxEnabled
                {
                    get
                    {
                        if (_offset_NxEnabled == -1)
                        {
                            _offset_NxEnabled = Offset_PaeEnabled + 1;
                        }

                        return _offset_NxEnabled;
                    }
                }

                private int Offset_MemorySpeed
                {
                    get
                    {
                        if (_offset_MemorySpeed == -1)
                        {
                            _offset_MemorySpeed = Offset_NxEnabled + 1;
                        }

                        return _offset_MemorySpeed;
                    }
                }

                /// <summary>
                /// Retrieves the MHz field.
                /// </summary>
                public uint MHz => BitConverter.ToUInt32(_etwEvent.Data[Offset_MHz..Offset_NumberOfProcessors]);

                /// <summary>
                /// Retrieves the NumberOfProcessors field.
                /// </summary>
                public uint NumberOfProcessors => BitConverter.ToUInt32(_etwEvent.Data[Offset_NumberOfProcessors..Offset_MemSize]);

                /// <summary>
                /// Retrieves the MemSize field.
                /// </summary>
                public uint MemSize => BitConverter.ToUInt32(_etwEvent.Data[Offset_MemSize..Offset_PageSize]);

                /// <summary>
                /// Retrieves the PageSize field.
                /// </summary>
                public uint PageSize => BitConverter.ToUInt32(_etwEvent.Data[Offset_PageSize..Offset_AllocationGranularity]);

                /// <summary>
                /// Retrieves the AllocationGranularity field.
                /// </summary>
                public uint AllocationGranularity => BitConverter.ToUInt32(_etwEvent.Data[Offset_AllocationGranularity..Offset_ComputerName]);

                /// <summary>
                /// Retrieves the ComputerName field.
                /// </summary>
                public char ComputerName => BitConverter.ToChar(_etwEvent.Data[Offset_ComputerName..Offset_DomainName]);

                /// <summary>
                /// Retrieves the DomainName field.
                /// </summary>
                public char DomainName => BitConverter.ToChar(_etwEvent.Data[Offset_DomainName..Offset_HyperThreadingFlag]);

                /// <summary>
                /// Retrieves the HyperThreadingFlag field.
                /// </summary>
                public ulong HyperThreadingFlag => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_HyperThreadingFlag..Offset_HighestUserAddress]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_HyperThreadingFlag..Offset_HighestUserAddress]);

                /// <summary>
                /// Retrieves the HighestUserAddress field.
                /// </summary>
                public ulong HighestUserAddress => _etwEvent.AddressSize == 4 ? BitConverter.ToUInt32(_etwEvent.Data[Offset_HighestUserAddress..Offset_ProcessorArchitecture]) : BitConverter.ToUInt64(_etwEvent.Data[Offset_HighestUserAddress..Offset_ProcessorArchitecture]);

                /// <summary>
                /// Retrieves the ProcessorArchitecture field.
                /// </summary>
                public ushort ProcessorArchitecture => BitConverter.ToUInt16(_etwEvent.Data[Offset_ProcessorArchitecture..Offset_ProcessorLevel]);

                /// <summary>
                /// Retrieves the ProcessorLevel field.
                /// </summary>
                public ushort ProcessorLevel => BitConverter.ToUInt16(_etwEvent.Data[Offset_ProcessorLevel..Offset_ProcessorRevision]);

                /// <summary>
                /// Retrieves the ProcessorRevision field.
                /// </summary>
                public ushort ProcessorRevision => BitConverter.ToUInt16(_etwEvent.Data[Offset_ProcessorRevision..Offset_PaeEnabled]);

                /// <summary>
                /// Retrieves the PaeEnabled field.
                /// </summary>
                public byte PaeEnabled => _etwEvent.Data[Offset_PaeEnabled];

                /// <summary>
                /// Retrieves the NxEnabled field.
                /// </summary>
                public byte NxEnabled => _etwEvent.Data[Offset_NxEnabled];

                /// <summary>
                /// Retrieves the MemorySpeed field.
                /// </summary>
                public uint MemorySpeed => BitConverter.ToUInt32(_etwEvent.Data[Offset_MemorySpeed..]);

                /// <summary>
                /// Creates a new CPUData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public CPUData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_MHz = -1;
                    _offset_NumberOfProcessors = -1;
                    _offset_MemSize = -1;
                    _offset_PageSize = -1;
                    _offset_AllocationGranularity = -1;
                    _offset_ComputerName = -1;
                    _offset_DomainName = -1;
                    _offset_HyperThreadingFlag = -1;
                    _offset_HighestUserAddress = -1;
                    _offset_ProcessorArchitecture = -1;
                    _offset_ProcessorLevel = -1;
                    _offset_ProcessorRevision = -1;
                    _offset_PaeEnabled = -1;
                    _offset_NxEnabled = -1;
                    _offset_MemorySpeed = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a IRQ event.
        /// </summary>
        public readonly ref struct IRQEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "IRQ";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 0,
                Version = 3,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.IRQ,
                Task = 0,
                Keyword = 0
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
            public IRQData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new IRQEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public IRQEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a IRQEventV3.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator IRQEventV3(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a IRQ event.
            /// </summary>
            public ref struct IRQData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_IRQAffinity;
                private int _offset_IRQGroup;
                private int _offset_Reserved;
                private int _offset_IRQNum;
                private int _offset_DeviceDescriptionLen;
                private int _offset_DeviceDescription;

                private int Offset_IRQAffinity
                {
                    get
                    {
                        if (_offset_IRQAffinity == -1)
                        {
                            _offset_IRQAffinity = 0;
                        }

                        return _offset_IRQAffinity;
                    }
                }

                private int Offset_IRQGroup
                {
                    get
                    {
                        if (_offset_IRQGroup == -1)
                        {
                            _offset_IRQGroup = Offset_IRQAffinity + 8;
                        }

                        return _offset_IRQGroup;
                    }
                }

                private int Offset_Reserved
                {
                    get
                    {
                        if (_offset_Reserved == -1)
                        {
                            _offset_Reserved = Offset_IRQGroup + 2;
                        }

                        return _offset_Reserved;
                    }
                }

                private int Offset_IRQNum
                {
                    get
                    {
                        if (_offset_IRQNum == -1)
                        {
                            _offset_IRQNum = Offset_Reserved + 2;
                        }

                        return _offset_IRQNum;
                    }
                }

                private int Offset_DeviceDescriptionLen
                {
                    get
                    {
                        if (_offset_DeviceDescriptionLen == -1)
                        {
                            _offset_DeviceDescriptionLen = Offset_IRQNum + 4;
                        }

                        return _offset_DeviceDescriptionLen;
                    }
                }

                private int Offset_DeviceDescription
                {
                    get
                    {
                        if (_offset_DeviceDescription == -1)
                        {
                            _offset_DeviceDescription = Offset_DeviceDescriptionLen + 4;
                        }

                        return _offset_DeviceDescription;
                    }
                }

                /// <summary>
                /// Retrieves the IRQAffinity field.
                /// </summary>
                public ulong IRQAffinity => BitConverter.ToUInt64(_etwEvent.Data[Offset_IRQAffinity..Offset_IRQGroup]);

                /// <summary>
                /// Retrieves the IRQGroup field.
                /// </summary>
                public ushort IRQGroup => BitConverter.ToUInt16(_etwEvent.Data[Offset_IRQGroup..Offset_Reserved]);

                /// <summary>
                /// Retrieves the Reserved field.
                /// </summary>
                public ushort Reserved => BitConverter.ToUInt16(_etwEvent.Data[Offset_Reserved..Offset_IRQNum]);

                /// <summary>
                /// Retrieves the IRQNum field.
                /// </summary>
                public uint IRQNum => BitConverter.ToUInt32(_etwEvent.Data[Offset_IRQNum..Offset_DeviceDescriptionLen]);

                /// <summary>
                /// Retrieves the DeviceDescriptionLen field.
                /// </summary>
                public uint DeviceDescriptionLen => BitConverter.ToUInt32(_etwEvent.Data[Offset_DeviceDescriptionLen..Offset_DeviceDescription]);

                /// <summary>
                /// Retrieves the DeviceDescription field.
                /// </summary>
                public string DeviceDescription => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_DeviceDescription..]);

                /// <summary>
                /// Creates a new IRQData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public IRQData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_IRQAffinity = -1;
                    _offset_IRQGroup = -1;
                    _offset_Reserved = -1;
                    _offset_IRQNum = -1;
                    _offset_DeviceDescriptionLen = -1;
                    _offset_DeviceDescription = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a Services event.
        /// </summary>
        public readonly ref struct ServicesEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "Services";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 0,
                Version = 3,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.Services,
                Task = 0,
                Keyword = 0
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
            public ServicesData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new ServicesEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public ServicesEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a ServicesEventV3.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator ServicesEventV3(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a Services event.
            /// </summary>
            public ref struct ServicesData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ProcessId;
                private int _offset_ServiceState;
                private int _offset_SubProcessTag;
                private int _offset_ServiceName;
                private int _offset_DisplayName;
                private int _offset_ProcessName;
                private int _offset_LoadOrderGroup;
                private int _offset_SvchostGroup;

                private int Offset_ProcessId
                {
                    get
                    {
                        if (_offset_ProcessId == -1)
                        {
                            _offset_ProcessId = 0;
                        }

                        return _offset_ProcessId;
                    }
                }

                private int Offset_ServiceState
                {
                    get
                    {
                        if (_offset_ServiceState == -1)
                        {
                            _offset_ServiceState = Offset_ProcessId + 4;
                        }

                        return _offset_ServiceState;
                    }
                }

                private int Offset_SubProcessTag
                {
                    get
                    {
                        if (_offset_SubProcessTag == -1)
                        {
                            _offset_SubProcessTag = Offset_ServiceState + 4;
                        }

                        return _offset_SubProcessTag;
                    }
                }

                private int Offset_ServiceName
                {
                    get
                    {
                        if (_offset_ServiceName == -1)
                        {
                            _offset_ServiceName = Offset_SubProcessTag + 4;
                        }

                        return _offset_ServiceName;
                    }
                }

                private int Offset_DisplayName
                {
                    get
                    {
                        if (_offset_DisplayName == -1)
                        {
                            _offset_DisplayName = Offset_ServiceName + _etwEvent.UnicodeStringLength(Offset_ServiceName);
                        }

                        return _offset_DisplayName;
                    }
                }

                private int Offset_ProcessName
                {
                    get
                    {
                        if (_offset_ProcessName == -1)
                        {
                            _offset_ProcessName = Offset_DisplayName + _etwEvent.UnicodeStringLength(Offset_DisplayName);
                        }

                        return _offset_ProcessName;
                    }
                }

                private int Offset_LoadOrderGroup
                {
                    get
                    {
                        if (_offset_LoadOrderGroup == -1)
                        {
                            _offset_LoadOrderGroup = Offset_ProcessName + _etwEvent.UnicodeStringLength(Offset_ProcessName);
                        }

                        return _offset_LoadOrderGroup;
                    }
                }

                private int Offset_SvchostGroup
                {
                    get
                    {
                        if (_offset_SvchostGroup == -1)
                        {
                            _offset_SvchostGroup = Offset_LoadOrderGroup + _etwEvent.UnicodeStringLength(Offset_LoadOrderGroup);
                        }

                        return _offset_SvchostGroup;
                    }
                }

                /// <summary>
                /// Retrieves the ProcessId field.
                /// </summary>
                public uint ProcessId => BitConverter.ToUInt32(_etwEvent.Data[Offset_ProcessId..Offset_ServiceState]);

                /// <summary>
                /// Retrieves the ServiceState field.
                /// </summary>
                public uint ServiceState => BitConverter.ToUInt32(_etwEvent.Data[Offset_ServiceState..Offset_SubProcessTag]);

                /// <summary>
                /// Retrieves the SubProcessTag field.
                /// </summary>
                public uint SubProcessTag => BitConverter.ToUInt32(_etwEvent.Data[Offset_SubProcessTag..Offset_ServiceName]);

                /// <summary>
                /// Retrieves the ServiceName field.
                /// </summary>
                public string ServiceName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ServiceName..Offset_DisplayName]);

                /// <summary>
                /// Retrieves the DisplayName field.
                /// </summary>
                public string DisplayName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_DisplayName..Offset_ProcessName]);

                /// <summary>
                /// Retrieves the ProcessName field.
                /// </summary>
                public string ProcessName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ProcessName..Offset_LoadOrderGroup]);

                /// <summary>
                /// Retrieves the LoadOrderGroup field.
                /// </summary>
                public string LoadOrderGroup => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_LoadOrderGroup..Offset_SvchostGroup]);

                /// <summary>
                /// Retrieves the SvchostGroup field.
                /// </summary>
                public string SvchostGroup => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_SvchostGroup..]);

                /// <summary>
                /// Creates a new ServicesData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public ServicesData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ProcessId = -1;
                    _offset_ServiceState = -1;
                    _offset_SubProcessTag = -1;
                    _offset_ServiceName = -1;
                    _offset_DisplayName = -1;
                    _offset_ProcessName = -1;
                    _offset_LoadOrderGroup = -1;
                    _offset_SvchostGroup = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a PnP event.
        /// </summary>
        public readonly ref struct PnPEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "PnP";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 0,
                Version = 3,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.PnP,
                Task = 0,
                Keyword = 0
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
            public PnPData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new PnPEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public PnPEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a PnPEventV3.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator PnPEventV3(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a PnP event.
            /// </summary>
            public ref struct PnPData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_IDLength;
                private int _offset_DescriptionLength;
                private int _offset_FriendlyNameLength;
                private int _offset_DeviceID;
                private int _offset_DeviceDescription;
                private int _offset_FriendlyName;
                private int _offset_PdoName;

                private int Offset_IDLength
                {
                    get
                    {
                        if (_offset_IDLength == -1)
                        {
                            _offset_IDLength = 0;
                        }

                        return _offset_IDLength;
                    }
                }

                private int Offset_DescriptionLength
                {
                    get
                    {
                        if (_offset_DescriptionLength == -1)
                        {
                            _offset_DescriptionLength = Offset_IDLength + 4;
                        }

                        return _offset_DescriptionLength;
                    }
                }

                private int Offset_FriendlyNameLength
                {
                    get
                    {
                        if (_offset_FriendlyNameLength == -1)
                        {
                            _offset_FriendlyNameLength = Offset_DescriptionLength + 4;
                        }

                        return _offset_FriendlyNameLength;
                    }
                }

                private int Offset_DeviceID
                {
                    get
                    {
                        if (_offset_DeviceID == -1)
                        {
                            _offset_DeviceID = Offset_FriendlyNameLength + 4;
                        }

                        return _offset_DeviceID;
                    }
                }

                private int Offset_DeviceDescription
                {
                    get
                    {
                        if (_offset_DeviceDescription == -1)
                        {
                            _offset_DeviceDescription = Offset_DeviceID + _etwEvent.UnicodeStringLength(Offset_DeviceID);
                        }

                        return _offset_DeviceDescription;
                    }
                }

                private int Offset_FriendlyName
                {
                    get
                    {
                        if (_offset_FriendlyName == -1)
                        {
                            _offset_FriendlyName = Offset_DeviceDescription + _etwEvent.UnicodeStringLength(Offset_DeviceDescription);
                        }

                        return _offset_FriendlyName;
                    }
                }

                private int Offset_PdoName
                {
                    get
                    {
                        if (_offset_PdoName == -1)
                        {
                            _offset_PdoName = Offset_FriendlyName + _etwEvent.UnicodeStringLength(Offset_FriendlyName);
                        }

                        return _offset_PdoName;
                    }
                }

                /// <summary>
                /// Retrieves the IDLength field.
                /// </summary>
                public uint IDLength => BitConverter.ToUInt32(_etwEvent.Data[Offset_IDLength..Offset_DescriptionLength]);

                /// <summary>
                /// Retrieves the DescriptionLength field.
                /// </summary>
                public uint DescriptionLength => BitConverter.ToUInt32(_etwEvent.Data[Offset_DescriptionLength..Offset_FriendlyNameLength]);

                /// <summary>
                /// Retrieves the FriendlyNameLength field.
                /// </summary>
                public uint FriendlyNameLength => BitConverter.ToUInt32(_etwEvent.Data[Offset_FriendlyNameLength..Offset_DeviceID]);

                /// <summary>
                /// Retrieves the DeviceID field.
                /// </summary>
                public string DeviceID => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_DeviceID..Offset_DeviceDescription]);

                /// <summary>
                /// Retrieves the DeviceDescription field.
                /// </summary>
                public string DeviceDescription => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_DeviceDescription..Offset_FriendlyName]);

                /// <summary>
                /// Retrieves the FriendlyName field.
                /// </summary>
                public string FriendlyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FriendlyName..Offset_PdoName]);

                /// <summary>
                /// Retrieves the PdoName field.
                /// </summary>
                public string PdoName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_PdoName..]);

                /// <summary>
                /// Creates a new PnPData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public PnPData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_IDLength = -1;
                    _offset_DescriptionLength = -1;
                    _offset_FriendlyNameLength = -1;
                    _offset_DeviceID = -1;
                    _offset_DeviceDescription = -1;
                    _offset_FriendlyName = -1;
                    _offset_PdoName = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a MobilePlatform event.
        /// </summary>
        public readonly ref struct MobilePlatformEventV3
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "MobilePlatform";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 0,
                Version = 3,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.MobilePlatform,
                Task = 0,
                Keyword = 0
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
            public MobilePlatformData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new MobilePlatformEventV3.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public MobilePlatformEventV3(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a MobilePlatformEventV3.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator MobilePlatformEventV3(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a MobilePlatform event.
            /// </summary>
            public ref struct MobilePlatformData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_DeviceManufacturer;
                private int _offset_DeviceManufacturerDisplayName;
                private int _offset_DeviceModel;
                private int _offset_DeviceModelDisplayName;
                private int _offset_MobileOperator;
                private int _offset_MobileOperatorDisplayName;
                private int _offset_HardwareVersion;
                private int _offset_SocVersion;
                private int _offset_RadioHardwareVersion;
                private int _offset_RadioSoftwareVersion;
                private int _offset_BspVersion;
                private int _offset_OemSoftwareVersion;

                private int Offset_DeviceManufacturer
                {
                    get
                    {
                        if (_offset_DeviceManufacturer == -1)
                        {
                            _offset_DeviceManufacturer = 0;
                        }

                        return _offset_DeviceManufacturer;
                    }
                }

                private int Offset_DeviceManufacturerDisplayName
                {
                    get
                    {
                        if (_offset_DeviceManufacturerDisplayName == -1)
                        {
                            _offset_DeviceManufacturerDisplayName = Offset_DeviceManufacturer + _etwEvent.UnicodeStringLength(Offset_DeviceManufacturer);
                        }

                        return _offset_DeviceManufacturerDisplayName;
                    }
                }

                private int Offset_DeviceModel
                {
                    get
                    {
                        if (_offset_DeviceModel == -1)
                        {
                            _offset_DeviceModel = Offset_DeviceManufacturerDisplayName + _etwEvent.UnicodeStringLength(Offset_DeviceManufacturerDisplayName);
                        }

                        return _offset_DeviceModel;
                    }
                }

                private int Offset_DeviceModelDisplayName
                {
                    get
                    {
                        if (_offset_DeviceModelDisplayName == -1)
                        {
                            _offset_DeviceModelDisplayName = Offset_DeviceModel + _etwEvent.UnicodeStringLength(Offset_DeviceModel);
                        }

                        return _offset_DeviceModelDisplayName;
                    }
                }

                private int Offset_MobileOperator
                {
                    get
                    {
                        if (_offset_MobileOperator == -1)
                        {
                            _offset_MobileOperator = Offset_DeviceModelDisplayName + _etwEvent.UnicodeStringLength(Offset_DeviceModelDisplayName);
                        }

                        return _offset_MobileOperator;
                    }
                }

                private int Offset_MobileOperatorDisplayName
                {
                    get
                    {
                        if (_offset_MobileOperatorDisplayName == -1)
                        {
                            _offset_MobileOperatorDisplayName = Offset_MobileOperator + _etwEvent.UnicodeStringLength(Offset_MobileOperator);
                        }

                        return _offset_MobileOperatorDisplayName;
                    }
                }

                private int Offset_HardwareVersion
                {
                    get
                    {
                        if (_offset_HardwareVersion == -1)
                        {
                            _offset_HardwareVersion = Offset_MobileOperatorDisplayName + _etwEvent.UnicodeStringLength(Offset_MobileOperatorDisplayName);
                        }

                        return _offset_HardwareVersion;
                    }
                }

                private int Offset_SocVersion
                {
                    get
                    {
                        if (_offset_SocVersion == -1)
                        {
                            _offset_SocVersion = Offset_HardwareVersion + _etwEvent.UnicodeStringLength(Offset_HardwareVersion);
                        }

                        return _offset_SocVersion;
                    }
                }

                private int Offset_RadioHardwareVersion
                {
                    get
                    {
                        if (_offset_RadioHardwareVersion == -1)
                        {
                            _offset_RadioHardwareVersion = Offset_SocVersion + _etwEvent.UnicodeStringLength(Offset_SocVersion);
                        }

                        return _offset_RadioHardwareVersion;
                    }
                }

                private int Offset_RadioSoftwareVersion
                {
                    get
                    {
                        if (_offset_RadioSoftwareVersion == -1)
                        {
                            _offset_RadioSoftwareVersion = Offset_RadioHardwareVersion + _etwEvent.UnicodeStringLength(Offset_RadioHardwareVersion);
                        }

                        return _offset_RadioSoftwareVersion;
                    }
                }

                private int Offset_BspVersion
                {
                    get
                    {
                        if (_offset_BspVersion == -1)
                        {
                            _offset_BspVersion = Offset_RadioSoftwareVersion + _etwEvent.UnicodeStringLength(Offset_RadioSoftwareVersion);
                        }

                        return _offset_BspVersion;
                    }
                }

                private int Offset_OemSoftwareVersion
                {
                    get
                    {
                        if (_offset_OemSoftwareVersion == -1)
                        {
                            _offset_OemSoftwareVersion = Offset_BspVersion + _etwEvent.UnicodeStringLength(Offset_BspVersion);
                        }

                        return _offset_OemSoftwareVersion;
                    }
                }

                /// <summary>
                /// Retrieves the DeviceManufacturer field.
                /// </summary>
                public string DeviceManufacturer => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_DeviceManufacturer..Offset_DeviceManufacturerDisplayName]);

                /// <summary>
                /// Retrieves the DeviceManufacturerDisplayName field.
                /// </summary>
                public string DeviceManufacturerDisplayName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_DeviceManufacturerDisplayName..Offset_DeviceModel]);

                /// <summary>
                /// Retrieves the DeviceModel field.
                /// </summary>
                public string DeviceModel => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_DeviceModel..Offset_DeviceModelDisplayName]);

                /// <summary>
                /// Retrieves the DeviceModelDisplayName field.
                /// </summary>
                public string DeviceModelDisplayName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_DeviceModelDisplayName..Offset_MobileOperator]);

                /// <summary>
                /// Retrieves the MobileOperator field.
                /// </summary>
                public string MobileOperator => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_MobileOperator..Offset_MobileOperatorDisplayName]);

                /// <summary>
                /// Retrieves the MobileOperatorDisplayName field.
                /// </summary>
                public string MobileOperatorDisplayName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_MobileOperatorDisplayName..Offset_HardwareVersion]);

                /// <summary>
                /// Retrieves the HardwareVersion field.
                /// </summary>
                public string HardwareVersion => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_HardwareVersion..Offset_SocVersion]);

                /// <summary>
                /// Retrieves the SocVersion field.
                /// </summary>
                public string SocVersion => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_SocVersion..Offset_RadioHardwareVersion]);

                /// <summary>
                /// Retrieves the RadioHardwareVersion field.
                /// </summary>
                public string RadioHardwareVersion => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_RadioHardwareVersion..Offset_RadioSoftwareVersion]);

                /// <summary>
                /// Retrieves the RadioSoftwareVersion field.
                /// </summary>
                public string RadioSoftwareVersion => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_RadioSoftwareVersion..Offset_BspVersion]);

                /// <summary>
                /// Retrieves the BspVersion field.
                /// </summary>
                public string BspVersion => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_BspVersion..Offset_OemSoftwareVersion]);

                /// <summary>
                /// Retrieves the OemSoftwareVersion field.
                /// </summary>
                public string OemSoftwareVersion => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_OemSoftwareVersion..]);

                /// <summary>
                /// Creates a new MobilePlatformData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public MobilePlatformData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_DeviceManufacturer = -1;
                    _offset_DeviceManufacturerDisplayName = -1;
                    _offset_DeviceModel = -1;
                    _offset_DeviceModelDisplayName = -1;
                    _offset_MobileOperator = -1;
                    _offset_MobileOperatorDisplayName = -1;
                    _offset_HardwareVersion = -1;
                    _offset_SocVersion = -1;
                    _offset_RadioHardwareVersion = -1;
                    _offset_RadioSoftwareVersion = -1;
                    _offset_BspVersion = -1;
                    _offset_OemSoftwareVersion = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a PnP event.
        /// </summary>
        public readonly ref struct PnPEventV4
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "PnP";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 0,
                Version = 4,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.PnP,
                Task = 0,
                Keyword = 0
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
            public PnPData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new PnPEventV4.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public PnPEventV4(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a PnPEventV4.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator PnPEventV4(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a PnP event.
            /// </summary>
            public ref struct PnPData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ClassGuid;
                private int _offset_UpperFiltersCount;
                private int _offset_LowerFiltersCount;
                private int _offset_DeviceID;
                private int _offset_DeviceDescription;
                private int _offset_FriendlyName;
                private int _offset_PdoName;
                private int _offset_ServiceName;
                private int _offset_UpperFilters;
                private int _offset_LowerFilters;

                private int Offset_ClassGuid
                {
                    get
                    {
                        if (_offset_ClassGuid == -1)
                        {
                            _offset_ClassGuid = 0;
                        }

                        return _offset_ClassGuid;
                    }
                }

                private int Offset_UpperFiltersCount
                {
                    get
                    {
                        if (_offset_UpperFiltersCount == -1)
                        {
                            _offset_UpperFiltersCount = Offset_ClassGuid + 16;
                        }

                        return _offset_UpperFiltersCount;
                    }
                }

                private int Offset_LowerFiltersCount
                {
                    get
                    {
                        if (_offset_LowerFiltersCount == -1)
                        {
                            _offset_LowerFiltersCount = Offset_UpperFiltersCount + 4;
                        }

                        return _offset_LowerFiltersCount;
                    }
                }

                private int Offset_DeviceID
                {
                    get
                    {
                        if (_offset_DeviceID == -1)
                        {
                            _offset_DeviceID = Offset_LowerFiltersCount + 4;
                        }

                        return _offset_DeviceID;
                    }
                }

                private int Offset_DeviceDescription
                {
                    get
                    {
                        if (_offset_DeviceDescription == -1)
                        {
                            _offset_DeviceDescription = Offset_DeviceID + _etwEvent.UnicodeStringLength(Offset_DeviceID);
                        }

                        return _offset_DeviceDescription;
                    }
                }

                private int Offset_FriendlyName
                {
                    get
                    {
                        if (_offset_FriendlyName == -1)
                        {
                            _offset_FriendlyName = Offset_DeviceDescription + _etwEvent.UnicodeStringLength(Offset_DeviceDescription);
                        }

                        return _offset_FriendlyName;
                    }
                }

                private int Offset_PdoName
                {
                    get
                    {
                        if (_offset_PdoName == -1)
                        {
                            _offset_PdoName = Offset_FriendlyName + _etwEvent.UnicodeStringLength(Offset_FriendlyName);
                        }

                        return _offset_PdoName;
                    }
                }

                private int Offset_ServiceName
                {
                    get
                    {
                        if (_offset_ServiceName == -1)
                        {
                            _offset_ServiceName = Offset_PdoName + _etwEvent.UnicodeStringLength(Offset_PdoName);
                        }

                        return _offset_ServiceName;
                    }
                }

                private int Offset_UpperFilters
                {
                    get
                    {
                        if (_offset_UpperFilters == -1)
                        {
                            _offset_UpperFilters = Offset_ServiceName + _etwEvent.UnicodeStringLength(Offset_ServiceName);
                        }

                        return _offset_UpperFilters;
                    }
                }

                private int Offset_LowerFilters
                {
                    get
                    {
                        if (_offset_LowerFilters == -1)
                        {
                            _offset_LowerFilters = Offset_UpperFilters + _etwEvent.UnicodeStringArrayLength(Offset_UpperFilters, UpperFiltersCount);
                        }

                        return _offset_LowerFilters;
                    }
                }

                /// <summary>
                /// Retrieves the ClassGuid field.
                /// </summary>
                public Guid ClassGuid => new(_etwEvent.Data[Offset_ClassGuid..Offset_UpperFiltersCount]);

                /// <summary>
                /// Retrieves the UpperFiltersCount field.
                /// </summary>
                public uint UpperFiltersCount => BitConverter.ToUInt32(_etwEvent.Data[Offset_UpperFiltersCount..Offset_LowerFiltersCount]);

                /// <summary>
                /// Retrieves the LowerFiltersCount field.
                /// </summary>
                public uint LowerFiltersCount => BitConverter.ToUInt32(_etwEvent.Data[Offset_LowerFiltersCount..Offset_DeviceID]);

                /// <summary>
                /// Retrieves the DeviceID field.
                /// </summary>
                public string DeviceID => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_DeviceID..Offset_DeviceDescription]);

                /// <summary>
                /// Retrieves the DeviceDescription field.
                /// </summary>
                public string DeviceDescription => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_DeviceDescription..Offset_FriendlyName]);

                /// <summary>
                /// Retrieves the FriendlyName field.
                /// </summary>
                public string FriendlyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FriendlyName..Offset_PdoName]);

                /// <summary>
                /// Retrieves the PdoName field.
                /// </summary>
                public string PdoName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_PdoName..Offset_ServiceName]);

                /// <summary>
                /// Retrieves the ServiceName field.
                /// </summary>
                public string ServiceName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ServiceName..Offset_UpperFilters]);

                /// <summary>
                /// Retrieves the UpperFilters field.
                /// </summary>
                public EtwEvent.UnicodeStringEnumerable UpperFilters => new(_etwEvent, Offset_UpperFilters, UpperFiltersCount);

                /// <summary>
                /// Retrieves the LowerFilters field.
                /// </summary>
                public EtwEvent.UnicodeStringEnumerable LowerFilters => new(_etwEvent, Offset_LowerFilters, LowerFiltersCount);

                /// <summary>
                /// Creates a new PnPData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public PnPData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ClassGuid = -1;
                    _offset_UpperFiltersCount = -1;
                    _offset_LowerFiltersCount = -1;
                    _offset_DeviceID = -1;
                    _offset_DeviceDescription = -1;
                    _offset_FriendlyName = -1;
                    _offset_PdoName = -1;
                    _offset_ServiceName = -1;
                    _offset_UpperFilters = -1;
                    _offset_LowerFilters = -1;
                }
            }

        }

        /// <summary>
        /// An event wrapper for a PnP event.
        /// </summary>
        public readonly ref struct PnPEventV5
        {
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = "PnP";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor { get; } = new EtwEventDescriptor
            {
                Id = 0,
                Version = 5,
                Channel = 0,
                Level = EtwTraceLevel.None,
                Opcode = (EtwEventOpcode)Opcodes.PnP,
                Task = 0,
                Keyword = 0
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
            public PnPData Data => new(_etwEvent);

            /// <summary>
            /// Creates a new PnPEventV5.
            /// </summary>
            /// <param name="etwEvent">The event.</param>
            public PnPEventV5(EtwEvent etwEvent)
            {
                _etwEvent = etwEvent;
            }

            /// <summary>
            /// Converts a generic ETW event to a PnPEventV5.
            /// </summary>
            /// <param name="etwEvent"></param>
            public static explicit operator PnPEventV5(EtwEvent etwEvent) => new(etwEvent);

            /// <summary>
            /// A data wrapper for a PnP event.
            /// </summary>
            public ref struct PnPData
            {
                private readonly EtwEvent _etwEvent;

                private int _offset_ClassGuid;
                private int _offset_UpperFiltersCount;
                private int _offset_LowerFiltersCount;
                private int _offset_DevStatus;
                private int _offset_DevProblem;
                private int _offset_DeviceID;
                private int _offset_DeviceDescription;
                private int _offset_FriendlyName;
                private int _offset_PdoName;
                private int _offset_ServiceName;
                private int _offset_UpperFilters;
                private int _offset_LowerFilters;

                private int Offset_ClassGuid
                {
                    get
                    {
                        if (_offset_ClassGuid == -1)
                        {
                            _offset_ClassGuid = 0;
                        }

                        return _offset_ClassGuid;
                    }
                }

                private int Offset_UpperFiltersCount
                {
                    get
                    {
                        if (_offset_UpperFiltersCount == -1)
                        {
                            _offset_UpperFiltersCount = Offset_ClassGuid + 16;
                        }

                        return _offset_UpperFiltersCount;
                    }
                }

                private int Offset_LowerFiltersCount
                {
                    get
                    {
                        if (_offset_LowerFiltersCount == -1)
                        {
                            _offset_LowerFiltersCount = Offset_UpperFiltersCount + 4;
                        }

                        return _offset_LowerFiltersCount;
                    }
                }

                private int Offset_DevStatus
                {
                    get
                    {
                        if (_offset_DevStatus == -1)
                        {
                            _offset_DevStatus = Offset_LowerFiltersCount + 4;
                        }

                        return _offset_DevStatus;
                    }
                }

                private int Offset_DevProblem
                {
                    get
                    {
                        if (_offset_DevProblem == -1)
                        {
                            _offset_DevProblem = Offset_DevStatus + 4;
                        }

                        return _offset_DevProblem;
                    }
                }

                private int Offset_DeviceID
                {
                    get
                    {
                        if (_offset_DeviceID == -1)
                        {
                            _offset_DeviceID = Offset_DevProblem + 4;
                        }

                        return _offset_DeviceID;
                    }
                }

                private int Offset_DeviceDescription
                {
                    get
                    {
                        if (_offset_DeviceDescription == -1)
                        {
                            _offset_DeviceDescription = Offset_DeviceID + _etwEvent.UnicodeStringLength(Offset_DeviceID);
                        }

                        return _offset_DeviceDescription;
                    }
                }

                private int Offset_FriendlyName
                {
                    get
                    {
                        if (_offset_FriendlyName == -1)
                        {
                            _offset_FriendlyName = Offset_DeviceDescription + _etwEvent.UnicodeStringLength(Offset_DeviceDescription);
                        }

                        return _offset_FriendlyName;
                    }
                }

                private int Offset_PdoName
                {
                    get
                    {
                        if (_offset_PdoName == -1)
                        {
                            _offset_PdoName = Offset_FriendlyName + _etwEvent.UnicodeStringLength(Offset_FriendlyName);
                        }

                        return _offset_PdoName;
                    }
                }

                private int Offset_ServiceName
                {
                    get
                    {
                        if (_offset_ServiceName == -1)
                        {
                            _offset_ServiceName = Offset_PdoName + _etwEvent.UnicodeStringLength(Offset_PdoName);
                        }

                        return _offset_ServiceName;
                    }
                }

                private int Offset_UpperFilters
                {
                    get
                    {
                        if (_offset_UpperFilters == -1)
                        {
                            _offset_UpperFilters = Offset_ServiceName + _etwEvent.UnicodeStringLength(Offset_ServiceName);
                        }

                        return _offset_UpperFilters;
                    }
                }

                private int Offset_LowerFilters
                {
                    get
                    {
                        if (_offset_LowerFilters == -1)
                        {
                            _offset_LowerFilters = Offset_UpperFilters + _etwEvent.UnicodeStringArrayLength(Offset_UpperFilters, UpperFiltersCount);
                        }

                        return _offset_LowerFilters;
                    }
                }

                /// <summary>
                /// Retrieves the ClassGuid field.
                /// </summary>
                public Guid ClassGuid => new(_etwEvent.Data[Offset_ClassGuid..Offset_UpperFiltersCount]);

                /// <summary>
                /// Retrieves the UpperFiltersCount field.
                /// </summary>
                public uint UpperFiltersCount => BitConverter.ToUInt32(_etwEvent.Data[Offset_UpperFiltersCount..Offset_LowerFiltersCount]);

                /// <summary>
                /// Retrieves the LowerFiltersCount field.
                /// </summary>
                public uint LowerFiltersCount => BitConverter.ToUInt32(_etwEvent.Data[Offset_LowerFiltersCount..Offset_DevStatus]);

                /// <summary>
                /// Retrieves the DevStatus field.
                /// </summary>
                public uint DevStatus => BitConverter.ToUInt32(_etwEvent.Data[Offset_DevStatus..Offset_DevProblem]);

                /// <summary>
                /// Retrieves the DevProblem field.
                /// </summary>
                public uint DevProblem => BitConverter.ToUInt32(_etwEvent.Data[Offset_DevProblem..Offset_DeviceID]);

                /// <summary>
                /// Retrieves the DeviceID field.
                /// </summary>
                public string DeviceID => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_DeviceID..Offset_DeviceDescription]);

                /// <summary>
                /// Retrieves the DeviceDescription field.
                /// </summary>
                public string DeviceDescription => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_DeviceDescription..Offset_FriendlyName]);

                /// <summary>
                /// Retrieves the FriendlyName field.
                /// </summary>
                public string FriendlyName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_FriendlyName..Offset_PdoName]);

                /// <summary>
                /// Retrieves the PdoName field.
                /// </summary>
                public string PdoName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_PdoName..Offset_ServiceName]);

                /// <summary>
                /// Retrieves the ServiceName field.
                /// </summary>
                public string ServiceName => System.Text.Encoding.Unicode.GetString(_etwEvent.Data[Offset_ServiceName..Offset_UpperFilters]);

                /// <summary>
                /// Retrieves the UpperFilters field.
                /// </summary>
                public EtwEvent.UnicodeStringEnumerable UpperFilters => new(_etwEvent, Offset_UpperFilters, UpperFiltersCount);

                /// <summary>
                /// Retrieves the LowerFilters field.
                /// </summary>
                public EtwEvent.UnicodeStringEnumerable LowerFilters => new(_etwEvent, Offset_LowerFilters, LowerFiltersCount);

                /// <summary>
                /// Creates a new PnPData.
                /// </summary>
                /// <param name="etwEvent">The event.</param>
                public PnPData(EtwEvent etwEvent)
                {
                    _etwEvent = etwEvent;
                    _offset_ClassGuid = -1;
                    _offset_UpperFiltersCount = -1;
                    _offset_LowerFiltersCount = -1;
                    _offset_DevStatus = -1;
                    _offset_DevProblem = -1;
                    _offset_DeviceID = -1;
                    _offset_DeviceDescription = -1;
                    _offset_FriendlyName = -1;
                    _offset_PdoName = -1;
                    _offset_ServiceName = -1;
                    _offset_UpperFilters = -1;
                    _offset_LowerFilters = -1;
                }
            }

        }
    }
}
