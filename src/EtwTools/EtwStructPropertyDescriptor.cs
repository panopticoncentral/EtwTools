using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtwTools
{
    public sealed record EtwStructPropertyDescriptor : EtwPropertyDescriptor
    {
        public override PropertyKind Kind => PropertyKind.Struct;

        public IReadOnlyList<EtwPropertyDescriptor> Properties { get; init; }
    }
}
