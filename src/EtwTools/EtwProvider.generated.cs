using System;
using System.Collections.Generic;

namespace EtwTools
{
    public partial class EtwProvider
    {
        private static readonly Dictionary<Guid, string> s_providerNames = new()
        {
            { Guid.Parse("cfeb0608-330e-4410-b00d-56d8da9986e6"), "Microsoft-Antimalware-AMFilter" },
            { Guid.Parse("e13c0d23-ccbc-4e12-931b-d9cc2eee27e4"), "Microsoft-Windows-DotNETRuntime" },
            { Guid.Parse("a669021c-c450-4609-a035-5af59af4df18"), "Microsoft-Windows-DotNETRuntimeRundown" },
            { Guid.Parse("331c3b3a-2005-44c2-ac5e-77220c37d6b4"), "Microsoft-Windows-Kernel-Power" },
            { Guid.Parse("b675ec37-bdb6-4648-bc92-f3fdc74d3ca2"), "Microsoft-Windows-Kernel-EventTracing" },
            { Guid.Parse("edd08927-9cc4-4e65-b970-c2560fb5c289"), "Microsoft-Windows-Kernel-File" },
            { Guid.Parse("22fb2cd6-0e7b-422b-a0c7-2fad1fd0e716"), "Microsoft-Windows-Kernel-Process" },
            { Guid.Parse("2ed6006e-4729-4609-b423-3ee7bcd678ef"), "Microsoft-Windows-NDIS-PacketCapture" },
            { Guid.Parse("2f07e2ee-15db-40f1-90ef-9d7ba282188a"), "Microsoft-Windows-TCPIP" },
        };

        private static readonly Dictionary<Guid, EtwProvider> s_providers = new()
        {
            { Guid.Parse("cfeb0608-330e-4410-b00d-56d8da9986e6"), new EtwProvider(Guid.Parse("cfeb0608-330e-4410-b00d-56d8da9986e6")) },
            { Guid.Parse("e13c0d23-ccbc-4e12-931b-d9cc2eee27e4"), new EtwProvider(Guid.Parse("e13c0d23-ccbc-4e12-931b-d9cc2eee27e4")) },
            { Guid.Parse("a669021c-c450-4609-a035-5af59af4df18"), new EtwProvider(Guid.Parse("a669021c-c450-4609-a035-5af59af4df18")) },
            { Guid.Parse("331c3b3a-2005-44c2-ac5e-77220c37d6b4"), new EtwProvider(Guid.Parse("331c3b3a-2005-44c2-ac5e-77220c37d6b4")) },
            { Guid.Parse("b675ec37-bdb6-4648-bc92-f3fdc74d3ca2"), new EtwProvider(Guid.Parse("b675ec37-bdb6-4648-bc92-f3fdc74d3ca2")) },
            { Guid.Parse("edd08927-9cc4-4e65-b970-c2560fb5c289"), new EtwProvider(Guid.Parse("edd08927-9cc4-4e65-b970-c2560fb5c289")) },
            { Guid.Parse("22fb2cd6-0e7b-422b-a0c7-2fad1fd0e716"), new EtwProvider(Guid.Parse("22fb2cd6-0e7b-422b-a0c7-2fad1fd0e716")) },
            { Guid.Parse("2ed6006e-4729-4609-b423-3ee7bcd678ef"), new EtwProvider(Guid.Parse("2ed6006e-4729-4609-b423-3ee7bcd678ef")) },
            { Guid.Parse("2f07e2ee-15db-40f1-90ef-9d7ba282188a"), new EtwProvider(Guid.Parse("2f07e2ee-15db-40f1-90ef-9d7ba282188a")) },
        };
    }
}