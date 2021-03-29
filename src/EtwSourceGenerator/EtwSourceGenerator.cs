using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using Newtonsoft.Json;

if (args.Length != 1)
{
    return -1;
}

var providers = JsonConvert.DeserializeObject<Provider[]>(File.ReadAllText(args[0]));

var idToProvider = new Dictionary<Guid, Provider>();

foreach (var provider in providers)
{
    if (idToProvider.TryGetValue(provider.Id, out var _))
    {
        Console.WriteLine($"Found duplicate provider ID {provider.Id}.");
        continue;
    }

    idToProvider.Add(provider.Id, provider);
}

var builder = new StringBuilder(@"using System;
using System.Collections.Generic;

namespace EtwTools
{
    public partial class EtwProvider
    {
        private static readonly Dictionary<Guid, string> s_providerNames = new()
        {
");

foreach (var kvp in idToProvider)
{
    _ = builder.AppendLine($"            {{ Guid.Parse(\"{kvp.Key}\"), \"{kvp.Value.Name}\" }},");
}

_ = builder.Append(@"        };
    }
}");

File.WriteAllText("EtwProvider.generated.cs", builder.ToString());

return 0;

internal sealed class Provider
{
    public string Name { get; set; }
    public Guid Id { get; set; }
}
