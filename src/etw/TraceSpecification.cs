using System.Collections.Generic;

namespace EtwTools
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
