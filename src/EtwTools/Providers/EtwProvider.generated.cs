using System;
using System.Collections.Generic;
namespace EtwTools
{
    public partial class EtwProvider
    {
        internal static readonly Dictionary<Guid, string> s_knownProviders = new()
        {
            { MicrosoftApplicationInsightsCoreProvider.Id, MicrosoftApplicationInsightsCoreProvider.Name },
            { MicrosoftVisualStudioCpsCoreProvider.Id, MicrosoftVisualStudioCpsCoreProvider.Name },
            { MicrosoftVisualStudioCpsVsProvider.Id, MicrosoftVisualStudioCpsVsProvider.Name },
            { MicrosoftVisualStudioThreadingProvider.Id, MicrosoftVisualStudioThreadingProvider.Name },
            { RoslynEventSourceProvider.Id, RoslynEventSourceProvider.Name },
            { StreamJsonRpcProvider.Id, StreamJsonRpcProvider.Name },
            { System_Diagnostics_Eventing_FrameworkEventSourceProvider.Id, System_Diagnostics_Eventing_FrameworkEventSourceProvider.Name },
            { System_Threading_Tasks_TplEventSourceProvider.Id, System_Threading_Tasks_TplEventSourceProvider.Name },
        };
    }
}