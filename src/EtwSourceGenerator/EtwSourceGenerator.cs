using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Newtonsoft.Json;

if (args.Length != 2)
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

var providersDirectory = Path.Combine(args[1], "Providers");

string ProviderFullName(Provider provider) => $"Providers.{provider.Name.Replace('-', '.')}Provider";

string ConverterMethod(string datatype, string location) =>
    datatype switch
    {
        "byte" => location,
        "sbyte" => $"(sbyte){location}",
        "bool" => $"{location} != 0",
        "ushort" => $"BitConverter.ToUInt16({location})",
        "short" => $"BitConverter.ToInt16({location})",
        "uint" => $"BitConverter.ToUInt32({location})",
        "int" => $"BitConverter.ToInt32({location})",
        "ulong" => $"BitConverter.ToUInt64({location})",
        "long" => $"BitConverter.ToInt64({location})",
        "string" => $"global::System.Text.Encoding.Unicode.GetString({location})",
        _ => "Unknown"
    };

int Size(string datatype) =>
    datatype switch
    {
        "bool" => 1,
        "byte" => 1,
        "sbyte" => 1,
        "ushort" => 2,
        "short" => 2,
        "uint" => 4,
        "int" => 4,
        "ulong" => 8,
        "long" => 8,
        _ => 0
    };

void CreateEventField(Provider provider, Event e, string name, string datatype, StringBuilder builder, ref int offset)
{
    var returnType = datatype;
    var indexed = false;
    var location = $"_etwEvent.Data{(offset == 0 ? string.Empty : $"[{offset}{(Size(returnType) == 1 ? string.Empty : "..")}]")}";

    if (datatype.EndsWith("[...]", StringComparison.Ordinal))
    {
        returnType = datatype[0..^5];
        indexed = true;
        location = $"_etwEvent.Data[({offset} + (index * sizeof({returnType}))){(Size(returnType) == 1 ? string.Empty : "..")}]";
    }
    else
    {
        offset += Size(datatype);
    }

    if (name.StartsWith('_'))
    {
        return;
    }

    _ = builder.Append($@"

            /// <summary>
            /// Retrieves the {name} field.
            /// </summary>
            public {returnType} {(indexed ? "Get" : string.Empty)}{name}({(indexed ? "int index" : string.Empty)}) => {ConverterMethod(returnType, location)};");
}

string CreateEventFields(Provider provider, Event e)
{
    if (!e.Fields.Any())
    {
        return string.Empty;
    }

    var builder = new StringBuilder();
    var offset = 0;

    foreach (var (name, datatype) in e.Fields)
    {
        CreateEventField(provider, e, name, datatype, builder, ref offset);
    }

    return builder.ToString();
}

string CreateProviderEvents(Provider provider, ref int eventId)
{
    if (provider.Events == null || provider.Events.Count == 0)
    {
        return string.Empty;
    }

    var builder = new StringBuilder();

    foreach (var (name, e) in provider.Events)
    {
        var processIdEvent = e.Fields.Any(f => f.Key == "ProcessId")
            ? string.Empty
            : @"

            /// <summary>
            /// The process the event was recorded in.
            /// </summary>
            public uint ProcessId => _etwEvent.ProcessId;";

        var threadIdEvent = e.Fields.Any(f => f.Key == "ThreadId")
            ? string.Empty
            : @"

            /// <summary>
            /// The thread the event was recorded on.
            /// </summary>
            public uint ThreadId => _etwEvent.ThreadId;";

        var timestampEvent = e.Fields.Any(f => f.Key == "Timestamp")
            ? string.Empty
            : @"

            /// <summary>
            /// The timestamp of the event.
            /// </summary>
            public long Timestamp => _etwEvent.Timestamp;";

        _ = builder.Append($@"

        /// <summary>
        /// An event wrapper for a {name} event.
        /// </summary>
        public readonly ref struct {name}Event
        {{
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event ID.
            /// </summary>
            public const int Id = {eventId++};

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = ""{name}"";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = new(""{provider.Id}"");

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor {{ get; }} = new EtwEventDescriptor {{ Id = {e.Descriptor.Id}, Version = {e.Descriptor.Version}, Channel = {e.Descriptor.Channel}, Level = {(e.Descriptor.Level == 0 ? string.Empty : "(EtwTraceLevel)")}{e.Descriptor.Level}, Opcode = (EtwEventType){e.Descriptor.Opcode}, Task = {e.Descriptor.Task}, Keyword = 0x{e.Descriptor.Keyword:X16} }};{processIdEvent}{threadIdEvent}{timestampEvent}

            /// <summary>
            /// Timing information for the event.
            /// </summary>
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;

            /// <summary>
            /// The processor number the event was recorded on.
            /// </summary>
            public byte ProcessorNumber => _etwEvent.ProcessorNumber;{CreateEventFields(provider, e)}

            /// <summary>
            /// Creates a new {name}Event.
            /// </summary>
            /// <param name=""etwEvent"">The event.</param>
            public {name}Event(EtwEvent etwEvent)
            {{
                _etwEvent = etwEvent;
            }}
        }}");
    }

    return builder.ToString();
}

void CreateProvider(Provider provider, ref int eventId)
{
    var providerClassFullName = ProviderFullName(provider);
    var lastDot = providerClassFullName.LastIndexOf('.');
    var providerNamespace = providerClassFullName[0..lastDot];
    var providerClassName = providerClassFullName[(lastDot + 1)..];

    var builder = new StringBuilder(@$"using System;

namespace EtwTools.{providerNamespace}
{{
    /// <summary>
    /// Provider for {provider.Name} ({provider.Id})
    /// </summary>
    public sealed class {providerClassName}
    {{
        /// <summary>
        /// Provider ID.
        /// </summary>
        public static readonly Guid Id = new(""{provider.Id}"");

        /// <summary>
        /// Provider name.
        /// </summary>
        public const string Name = ""{provider.Name}"";{CreateProviderEvents(provider, ref eventId)}
    }}
}}
");

    File.WriteAllText(Path.Combine(providersDirectory, $"{provider.Name.Replace('-', '_').Replace('.', '_')}.cs"), builder.ToString());
}

void CreateProviders()
{
    if (!Directory.Exists(providersDirectory))
    {
        _ = Directory.CreateDirectory(providersDirectory);
    }

    var eventId = 1;
    foreach (var provider in providers)
    {
        CreateProvider(provider, ref eventId);
    }
}

string ProviderEventMap(Provider provider)
{
    if (provider.Events == null || provider.Events.Count == 0)
    {
        return string.Empty;
    }

    var builder = new StringBuilder($", Events = new Dictionary<EtwEventDescriptor, KnownEvent> {{");
    var first = true;

    foreach (var (name, e) in provider.Events)
    {
        if (!first)
        {
            _ = builder.Append(',');
        }
        else
        {
            first = false;
        }

        var eventFullName = $"{ProviderFullName(provider)}.{name}Event";
        _ = builder.Append($" {{ {eventFullName}.Descriptor, new KnownEvent {{ Id = {eventFullName}.Id, Name = {eventFullName}.Name }} }}");
    }

    _ = builder.Append(" }");

    return builder.ToString();
}

void CreateMaps()
{
    var builder = new StringBuilder(@"using System;
using System.Collections.Generic;

namespace EtwTools
{
    public partial class EtwProvider
    {
        internal static readonly Dictionary<Guid, KnownProvider> s_knownProviders = new()
        {
");

    foreach (var provider in providers)
    {
        var providerClassFullName = ProviderFullName(provider);
        _ = builder.AppendLine($"            {{ {providerClassFullName}.Id, new KnownProvider {{ Name = {providerClassFullName}.Name{ProviderEventMap(provider)} }} }},");
    }

    _ = builder.Append(@"        };
    }
}");

    File.WriteAllText(Path.Combine(args[1], "EtwProvider.generated.cs"), builder.ToString());
}

CreateProviders();
CreateMaps();

return 0;

internal sealed class Provider
{
    public string Name { get; set; }
    public Guid Id { get; set; }
    public IReadOnlyDictionary<string, Event> Events { get; set; }
}

internal sealed class Event
{
    public EventDescriptor Descriptor { get; set; }
    public IReadOnlyDictionary<string, string> Fields { get; set; }
}

internal sealed class EventDescriptor
{
    public ushort Id { get; set; }
    public uint Version { get; set; }
    public byte Channel { get; set; }
    public byte Level { get; set; }
    public byte Opcode { get; set; }
    public ushort Task { get; set; }
    public ulong Keyword { get; set; }
}
