using System.Collections.Generic;

using EventTracing;

namespace Trace
{
    internal sealed class TraceSpecification
    {
        public KernelSpecification Kernel { get; set; }

        public sealed class KernelSpecification
        {
            public IReadOnlyDictionary<SystemTraceProvider, TraceState> Providers { get; set; }
        }
    }
}
