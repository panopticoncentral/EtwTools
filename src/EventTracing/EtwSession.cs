using System;
using System.Collections.Generic;

namespace EventTracing
{
    public sealed unsafe class EtwSession
    {
        private const int MaxNameSize = 1024;

        public Guid Id { get; }

        public string Name { get; }

        public EtwSession(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public static IReadOnlyList<EtwSession> GetAllSessions()
        {
            var hr = (Native.Hresult)Native.QueryAllTraces(null, 0, out var sessionCount);
            if (hr != Native.Hresult.ErrorMoreData)
            {
                hr.ThrowException();
            }

            var sizeOfProperties = sizeof(Native.EventTraceProperties) + (sizeof(char) * MaxNameSize) + (sizeof(char) * MaxNameSize);
            var sessionsArray = stackalloc byte[sessionCount * sizeOfProperties];
            var propertiesArray = stackalloc Native.EventTraceProperties*[sessionCount];

            for (var i = 0; i < sessionCount; i++)
            {
                var properties = (Native.EventTraceProperties*)&sessionsArray[sizeOfProperties * i];
                properties->Wnode.BufferSize = (uint)sizeOfProperties;
                properties->LoggerNameOffset = (uint)sizeof(Native.EventTraceProperties);
                properties->LogFileNameOffset = (uint)sizeof(Native.EventTraceProperties) + (sizeof(char) * MaxNameSize);
                propertiesArray[i] = properties;
            }

            ((Native.Hresult)Native.QueryAllTraces(propertiesArray, sessionCount, out sessionCount)).ThrowException();

            var list = new List<EtwSession>();
            for (var i = 0; i < sessionCount; i++)
            {
                list.Add(new EtwSession(propertiesArray[i]->Wnode.Guid, new string((char*)&((byte*)propertiesArray[i])[propertiesArray[i]->LoggerNameOffset])));
            }

            return list;
        }
    }
}
