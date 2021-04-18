using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

using Newtonsoft.Json;

const string EventsNamespace = "http://schemas.microsoft.com/win/2004/08/events";

static XElement GetOneChild(XContainer element, string name)
{
    if (element.Elements().Count() != 1)
    {
        throw new InvalidOperationException();
    }

    var childElement = element.Elements().Single();

    return childElement.Name != XName.Get(name, EventsNamespace) ? throw new InvalidOperationException() : childElement;
}

static (XElement, XElement) GetTwoChildren(XContainer element, string firstName, string secondName)
{
    if (element.Elements().Count() != 2)
    {
        throw new InvalidOperationException();
    }

    var firstElement = element.Elements().First();
    var secondElement = element.Elements().Last();

    return firstElement.Name != XName.Get(firstName, EventsNamespace)
        || (secondElement.Name != XName.Get(secondName, EventsNamespace))
        ? throw new InvalidOperationException()
        : (firstElement, secondElement);
}

static Dictionary<string, XElement> GetOptionalChildren(XContainer element, params string[] names)
{
    if (element.Elements().Count() > names.Length)
    {
        throw new InvalidOperationException();
    }

    Dictionary<string, XElement> result = new();
    HashSet<string> nameHash = new(names);

    foreach (var e in element.Elements())
    {
        if (!nameHash.Contains(e.Name.LocalName)
            || (e.Name.Namespace != EventsNamespace)
            || result.ContainsKey(e.Name.LocalName))
        {
            throw new InvalidOperationException();
        }

        result[e.Name.LocalName] = e;
    }

    return result;
}

static void EnsureOneAttribute(XElement element, (string Name, string Value) attribute)
{
    if (element.Attributes().Count() != 1)
    {
        throw new InvalidOperationException();
    }

    var firstAttribute = element.Attributes().Single();

    if (firstAttribute.Name != attribute.Name || firstAttribute.Value != attribute.Value)
    {
        throw new InvalidOperationException();
    }
}

static void EnsureNoElements(XElement element)
{
    if (element.Elements().Any())
    {
        throw new InvalidOperationException();
    }
}

static (string, string) GetTwoAttributes(XElement element, string firstName, string secondName)
{
    if (element.Attributes().Count() != 2)
    {
        throw new InvalidOperationException();
    }

    var firstAttribute = element.Attributes().First();
    var secondAttribute = element.Attributes().Last();

    return firstAttribute.Name != XName.Get(firstName)
        || (secondAttribute.Name != XName.Get(secondName))
        ? throw new InvalidOperationException()
        : (firstAttribute.Value, secondAttribute.Value);
}

static string GetOneAttribute(XElement element, string name)
{
    if (element.Attributes().Count() != 1)
    {
        throw new InvalidOperationException();
    }

    var attribute = element.Attributes().First();

    return attribute.Name != XName.Get(name)
        ? throw new InvalidOperationException()
        : attribute.Value;
}

static (string, string, string) GetThreeAttributes(XElement element, string firstName, string secondName, string thirdName)
{
    if (element.Attributes().Count() != 3)
    {
        throw new InvalidOperationException();
    }

    var firstAttribute = element.Attributes().First();
    var secondAttribute = element.Attributes().Skip(1).First();
    var thirdAttribute = element.Attributes().Skip(2).First();

    return firstAttribute.Name != XName.Get(firstName)
        || (secondAttribute.Name != XName.Get(secondName))
        || (thirdAttribute.Name != XName.Get(thirdName))
        ? throw new InvalidOperationException()
        : (firstAttribute.Value, secondAttribute.Value, thirdAttribute.Value);
}

static (string, string, string, string, string) GetFiveAttributes(XElement element, string firstName, string secondName, string thirdName, string fourthName, string fifthName)
{
    if (element.Attributes().Count() != 5)
    {
        throw new InvalidOperationException();
    }

    var firstAttribute = element.Attributes().First();
    var secondAttribute = element.Attributes().Skip(1).First();
    var thirdAttribute = element.Attributes().Skip(2).First();
    var fourthAttribute = element.Attributes().Skip(3).First();
    var fifthAttribute = element.Attributes().Skip(4).First();

    return firstAttribute.Name != XName.Get(firstName)
        || (secondAttribute.Name != XName.Get(secondName))
        || (thirdAttribute.Name != XName.Get(thirdName))
        || (fourthAttribute.Name != XName.Get(fourthName))
        || (fifthAttribute.Name != XName.Get(fifthName))
        ? throw new InvalidOperationException()
        : (firstAttribute.Value, secondAttribute.Value, thirdAttribute.Value, fourthAttribute.Value, fifthAttribute.Value);
}

static void CollectElements<T>(XElement element, T collection, string name, Action<XElement, T> collector)
{
    foreach (var collectionElement in element.Elements())
    {
        if (collectionElement.Name != XName.Get(name, EventsNamespace))
        {
            throw new InvalidOperationException();
        }

        collector(collectionElement, collection);
    }
}

static void CollectElementsChoice<T>(XElement element, T collection, IDictionary<string, Action<XElement, T>> choices)
{
    foreach (var collectionElement in element.Elements())
    {
        if (!choices.TryGetValue(collectionElement.Name.LocalName, out var choice))
        {
            throw new InvalidOperationException();
        }

        if (collectionElement.Name.Namespace != EventsNamespace)
        {
            throw new InvalidOperationException();
        }

        choice(collectionElement, collection);
    }
}

static string LookupString(Dictionary<string, string> stringTable, string index)
{
    if (!index.StartsWith("$(string.", StringComparison.Ordinal) || !index.EndsWith(")", StringComparison.Ordinal))
    {
        throw new InvalidOperationException();
    }

    index = index[9..^1];
    return stringTable[index];
}

static Manifest ReadManifest(string path)
{
    var document = XDocument.Load(path);
    var instrumentationManifestElement = GetOneChild(document, "instrumentationManifest");
    var (instrumentationElement, localizationElement) = GetTwoChildren(instrumentationManifestElement, "instrumentation", "localization");
    var resourcesElement = GetOneChild(localizationElement, "resources");
    EnsureOneAttribute(resourcesElement, ("culture", "en-US"));
    var stringtableElement = GetOneChild(resourcesElement, "stringTable");

    Dictionary<string, string> stringTable = new();
    CollectElements(stringtableElement, stringTable, "string", (element, stringTable) =>
    {
        EnsureNoElements(element);
        var (idAttribute, valueAttribute) = GetTwoAttributes(element, "id", "value");
        stringTable[idAttribute] = valueAttribute;
    });

    var eventsElement = GetOneChild(instrumentationElement, "events");
    var providerElement = GetOneChild(eventsElement, "provider");

    var (nameAttribute, guidAttribute, resourceFileNameAttribute, messageFileNameAttribute, symbolAttribute) = GetFiveAttributes(providerElement, "name", "guid", "resourceFileName", "messageFileName", "symbol");
    var componentElements = GetOptionalChildren(providerElement, "tasks", "maps", "opcodes", "keywords", "events", "templates");

    Dictionary<string, uint> tasks = new();
    if (componentElements.TryGetValue("tasks", out var tasksElement))
    {
        CollectElements(tasksElement, tasks, "task", (element, tasks) =>
        {
            EnsureNoElements(element);
            var (nameAttribute, messageAttribute, valueAttribute) = GetThreeAttributes(element, "name", "message", "value");
            tasks[LookupString(stringTable, messageAttribute)] = Convert.ToUInt32(valueAttribute, CultureInfo.InvariantCulture);
        });
    }

    Dictionary<string, ulong> keywords = new();
    if (componentElements.TryGetValue("keywords", out var keywordsElement))
    {
        CollectElements(keywordsElement, keywords, "keyword", (element, keywords) =>
        {
            EnsureNoElements(element);
            var (nameAttribute, messageAttribute, maskAttribute) = GetThreeAttributes(element, "name", "message", "mask");
            keywords[LookupString(stringTable, messageAttribute)] = Convert.ToUInt64(maskAttribute, 16);
        });
    }

    Dictionary<string, ulong> opcodes = new();
    if (componentElements.TryGetValue("opcodes", out var opcodesElement))
    {
        CollectElements(opcodesElement, opcodes, "opcode", (element, opcodes) =>
        {
            EnsureNoElements(element);
            var (nameAttribute, messageAttribute, valueAttribute) = GetThreeAttributes(element, "name", "message", "value");
            opcodes[LookupString(stringTable, messageAttribute)] = Convert.ToUInt32(valueAttribute, CultureInfo.InvariantCulture);
        });
    }

    Dictionary<string, (bool, Dictionary<long, string>)> maps = new();
    if (componentElements.TryGetValue("maps", out var mapsElement))
    {
        CollectElementsChoice(mapsElement, maps, new Dictionary<string, Action<XElement, Dictionary<string, (bool, Dictionary<long, string>)>>> {
            { "valueMap", (element, maps) =>
                {
                    var nameAttribute = GetOneAttribute(element, "name");

                    Dictionary<long, string> values = new();
                    CollectElements(element, values, "map", (element, values) =>
                    {
                        EnsureNoElements(element);
                        var (valueAttribute, messageAttribute) = GetTwoAttributes(element, "value", "message");
                        values[(long)Convert.ToUInt64(valueAttribute, 16)] = LookupString(stringTable, messageAttribute);
                    });
                    maps[nameAttribute] = (false, values);
                }
            },
            { "bitMap", (element, maps) =>
                {
                    var nameAttribute = GetOneAttribute(element, "name");

                    Dictionary<long, string> values = new();
                    CollectElements(element, values, "map", (element, values) =>
                    {
                        EnsureNoElements(element);
                        var (valueAttribute, messageAttribute) = GetTwoAttributes(element, "value", "message");
                        values[(long)Convert.ToUInt64(valueAttribute, 16)] = LookupString(stringTable, messageAttribute);
                    });
                    maps[nameAttribute] = (true, values);
                }
            }
        });
    }

    return new Manifest();
}

if (args.Length != 2)
{
    return -1;
}

foreach (var file in Directory.GetFiles(args[0]))
{
    Console.WriteLine($"Processing manifest '{Path.GetFileNameWithoutExtension(file)}'.");
    var manifest = ReadManifest(file);

    if (manifest == null)
    {
        Console.WriteLine("Bad manifest.");
        continue;
    }
}

return 0;

//var providers = JsonConvert.DeserializeObject<Provider[]>(File.ReadAllText(args[0]));

//var idToProvider = new Dictionary<Guid, Provider>();

//foreach (var provider in providers)
//{
//    if (idToProvider.TryGetValue(provider.Id, out var _))
//    {
//        Console.WriteLine($"Found duplicate provider ID {provider.Id}.");
//        continue;
//    }

//    idToProvider.Add(provider.Id, provider);
//}

//var providersDirectory = Path.Combine(args[1], "Providers");

//string ProviderFullName(Provider provider) => $"Providers.{provider.Name.Replace('-', '.')}Provider";

//string ConverterMethod(string datatype, string location) =>
//    datatype switch
//    {
//        "byte" => location,
//        "sbyte" => $"(sbyte){location}",
//        "bool" => $"{location} != 0",
//        "ushort" => $"BitConverter.ToUInt16({location})",
//        "short" => $"BitConverter.ToInt16({location})",
//        "uint" => $"BitConverter.ToUInt32({location})",
//        "int" => $"BitConverter.ToInt32({location})",
//        "ulong" => $"BitConverter.ToUInt64({location})",
//        "long" => $"BitConverter.ToInt64({location})",
//        "string" => $"global::System.Text.Encoding.Unicode.GetString({location})",
//        "address" => $"_etwEvent.AddressSize == 4 ? BitConverter.ToUInt32({location}) : BitConverter.ToUInt64({location})",
//        _ => "unknown"
//    };

//string ReturnType(string datatype) =>
//    datatype switch
//    {
//        "byte" or "sbyte" or "bool" or "ushort" or "short" or "uint" or "int" or "ulong" or "long" or "string" => datatype,
//        "address" => "ulong",
//        _ => "unknown"
//    };

//string VariableSize(string datatype, string offset) =>
//    datatype switch
//    {
//        "address" => "etwEvent.AddressSize",
//        "string" => $"EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, {offset})",
//        _ => "unknown"
//    };

//int Size(string datatype) =>
//    datatype switch
//    {
//        "bool" => 1,
//        "byte" => 1,
//        "sbyte" => 1,
//        "ushort" => 2,
//        "short" => 2,
//        "uint" => 4,
//        "int" => 4,
//        "ulong" => 8,
//        "long" => 8,
//        _ => -1
//    };

//void CreateEventField(Provider provider, Event e, int i, StringBuilder builder, Dictionary<Field, string> fieldOffsets)
//{
//    var name = e.Fields[i].Name;
//    if (name.StartsWith('_'))
//    {
//        return;
//    }

//    var datatype = e.Fields[i].Datatype;
//    var openBrace = datatype.IndexOf('[');
//    var count = string.Empty;

//    if (openBrace != -1)
//    {
//        count = datatype[(openBrace + 1)..^1];
//        datatype = datatype[..openBrace];

//        var location = $"_etwEvent.Data[{fieldOffsets[e.Fields[i]]}..{(i + 1 < e.Fields.Count ? fieldOffsets[e.Fields[i + 1]] : string.Empty)}]";

//        _ = builder.Append(datatype switch
//        {
//            "address" => $@"

//            /// <summary>
//            /// Retrieves the {name} field.
//            /// </summary>
//            public EtwEvent.AddressEnumerable {name} => new({location}, _etwEvent.AddressSize{(count == "..." ? string.Empty : $", {count}")});",
//            "string" => $@"

//            /// <summary>
//            /// Retrieves the {name} field.
//            /// </summary>
//            public EtwEvent.StringEnumerable {name} => new({location}{(count == "..." ? string.Empty : $", {count}")});",
//            _ => $@"

//            /// <summary>
//            /// Retrieves the {name} field.
//            /// </summary>
//            public EtwEvent.StructEnumerable<{datatype}> {name} => new({location}{(count == "..." ? string.Empty : $", {count}")});"
//        });
//    }
//    else
//    {
//        var location = $"_etwEvent.Data[{fieldOffsets[e.Fields[i]]}{(Size(datatype) == 1 ? string.Empty : $"..{(i + 1 < e.Fields.Count ? fieldOffsets[e.Fields[i + 1]] : string.Empty)}")}]";
//        _ = builder.Append($@"

//            /// <summary>
//            /// Retrieves the {name} field.
//            /// </summary>
//            public {ReturnType(datatype)} {name} => {ConverterMethod(datatype, location)};");
//    }
//}

//string CreateEventFields(Provider provider, Event e, Dictionary<Field, string> fieldOffsets)
//{
//    if (!e.Fields.Any())
//    {
//        return string.Empty;
//    }

//    var builder = new StringBuilder();

//    for (var i = 0; i < e.Fields.Count; i++)
//    {
//        CreateEventField(provider, e, i, builder, fieldOffsets);
//    }

//    return builder.ToString();
//}

//string CreateEventFieldOffsetInitializers(Provider provider, Event e, Dictionary<Field, string> fieldOffsets)
//{
//    if (!e.Fields.Any())
//    {
//        return string.Empty;
//    }

//    var builder = new StringBuilder();
//    var previousField = string.Empty;
//    var previousSize = string.Empty;

//    foreach (var f in e.Fields)
//    {
//        var fieldName = fieldOffsets[f];

//        if (fieldName.StartsWith('_'))
//        {
//            _ = builder.Append($@"
//                {fieldName} = {previousField} + {previousSize};");
//        }

//        var size = Size(f.Datatype);
//        previousSize = size == -1 ? VariableSize(f.Datatype, fieldName) : size.ToString(CultureInfo.InvariantCulture);
//        previousField = fieldName;
//    }

//    return builder.ToString();
//}

//string CreateEventFieldOffsets(Provider provider, Event e, Dictionary<Field, string> fieldOffsets)
//{
//    if (!e.Fields.Any())
//    {
//        return string.Empty;
//    }

//    var builder = new StringBuilder();
//    var foundVariableField = false;
//    var offset = 0;

//    _ = builder.AppendLine();

//    foreach (var f in e.Fields)
//    {
//        if (!foundVariableField)
//        {
//            var fieldName = $"Offset_{f.Name}";
//            fieldOffsets[f] = fieldName;

//            _ = builder.Append(@$"
//            private const int {fieldName} = {offset};");

//            var size = Size(f.Datatype);

//            if (size == -1)
//            {
//                foundVariableField = true;
//            }
//            else
//            {
//                offset += size;
//            }
//        }
//        else
//        {
//            var fieldName = $"_offset_{f.Name}";
//            fieldOffsets[f] = fieldName;
//            _ = builder.Append($@"
//            private readonly int {fieldName};");
//        }
//    }

//    return builder.ToString();
//}

//string CreateProviderEvents(Provider provider, string providerClassName, ref int eventId)
//{
//    if (provider.Events == null || provider.Events.Count == 0)
//    {
//        return string.Empty;
//    }

//    var builder = new StringBuilder();

//    foreach (var (name, e) in provider.Events)
//    {
//        Dictionary<Field, string> fieldOffsets = new();
//        var processIdEvent = e.Fields.Any(f => f.Name == "ProcessId")
//            ? string.Empty
//            : @"

//            /// <summary>
//            /// The process the event was recorded in.
//            /// </summary>
//            public uint ProcessId => _etwEvent.ProcessId;";

//        var threadIdEvent = e.Fields.Any(f => f.Name == "ThreadId")
//            ? string.Empty
//            : @"

//            /// <summary>
//            /// The thread the event was recorded on.
//            /// </summary>
//            public uint ThreadId => _etwEvent.ThreadId;";

//        var timestampEvent = e.Fields.Any(f => f.Name == "Timestamp")
//            ? string.Empty
//            : @"

//            /// <summary>
//            /// The timestamp of the event.
//            /// </summary>
//            public long Timestamp => _etwEvent.Timestamp;";

//        var processorNumberEvent = e.Fields.Any(f => f.Name == "ProcessorNumber")
//            ? string.Empty
//            : @"

//            /// <summary>
//            /// The processor number the event was recorded on.
//            /// </summary>
//            public byte ProcessorNumber => _etwEvent.ProcessorNumber;";

//        _ = builder.Append($@"

//        /// <summary>
//        /// An event wrapper for a {name} event.
//        /// </summary>
//        public readonly ref struct {name}Event
//        {{
//            private readonly EtwEvent _etwEvent;{CreateEventFieldOffsets(provider, e, fieldOffsets)}

//            /// <summary>
//            /// Event ID.
//            /// </summary>
//            public const int Id = {eventId++};

//            /// <summary>
//            /// Event name.
//            /// </summary>
//            public const string Name = ""{name}"";

//            /// <summary>
//            /// The event provider.
//            /// </summary>
//            public static readonly Guid Provider = {providerClassName}.Id;

//            /// <summary>
//            /// Event descriptor.
//            /// </summary>
//            public static EtwEventDescriptor Descriptor {{ get; }} = new EtwEventDescriptor {{ Id = {e.Descriptor.Id}, Version = {e.Descriptor.Version}, Channel = {e.Descriptor.Channel}, Level = {(e.Descriptor.Level == 0 ? string.Empty : "(EtwTraceLevel)")}{e.Descriptor.Level}, Opcode = {(e.Descriptor.Opcode == 0 ? string.Empty : "(EtwEventType)")}{e.Descriptor.Opcode}, Task = {e.Descriptor.Task}, Keyword = 0x{e.Descriptor.Keyword:X16} }};{processIdEvent}{threadIdEvent}{timestampEvent}{processorNumberEvent}

//            /// <summary>
//            /// Timing information for the event.
//            /// </summary>
//            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;{CreateEventFields(provider, e, fieldOffsets)}

//            /// <summary>
//            /// Creates a new {name}Event.
//            /// </summary>
//            /// <param name=""etwEvent"">The event.</param>
//            public {name}Event(EtwEvent etwEvent)
//            {{
//                _etwEvent = etwEvent;{CreateEventFieldOffsetInitializers(provider, e, fieldOffsets)}
//            }}
//        }}");
//    }

//    return builder.ToString();
//}

//string CreateStructFields(Provider provider, IReadOnlyList<Field> fields)
//{
//    if (!fields.Any())
//    {
//        return string.Empty;
//    }

//    var builder = new StringBuilder();

//    foreach (var f in fields)
//    {
//        _ = builder.Append($@"

//            /// <summary>
//            /// Retrieves the {f.Name} field.
//            /// </summary>
//            public {f.Datatype} {f.Name} {{ get; init; }}");
//    }

//    return builder.ToString();
//}

//string CreateProviderStructs(Provider provider, string providerClassName)
//{
//    if (provider.Structs == null || provider.Structs.Count == 0)
//    {
//        return string.Empty;
//    }

//    var builder = new StringBuilder();

//    foreach (var (name, fields) in provider.Structs)
//    {
//        _ = builder.Append($@"

//        /// <summary>
//        /// A {name} structure.
//        /// </summary>
//        public readonly struct {name}
//        {{{CreateStructFields(provider, fields)}
//        }}");
//    }

//    return builder.ToString();
//}

//void CreateProvider(Provider provider, ref int eventId)
//{
//    var providerClassFullName = ProviderFullName(provider);
//    var lastDot = providerClassFullName.LastIndexOf('.');
//    var providerNamespace = providerClassFullName[0..lastDot];
//    var providerClassName = providerClassFullName[(lastDot + 1)..];

//    var builder = new StringBuilder(@$"using System;

//namespace EtwTools.{providerNamespace}
//{{
//    /// <summary>
//    /// Provider for {provider.Name} ({provider.Id})
//    /// </summary>
//    public sealed class {providerClassName}
//    {{
//        /// <summary>
//        /// Provider ID.
//        /// </summary>
//        public static readonly Guid Id = new(""{provider.Id}"");

//        /// <summary>
//        /// Provider name.
//        /// </summary>
//        public const string Name = ""{provider.Name}"";{CreateProviderEvents(provider, providerClassName, ref eventId)}{CreateProviderStructs(provider, providerClassName)}
//    }}
//}}
//");

//    File.WriteAllText(Path.Combine(providersDirectory, $"{provider.Name.Replace('-', '_').Replace('.', '_')}.cs"), builder.ToString());
//}

//void CreateProviders()
//{
//    if (!Directory.Exists(providersDirectory))
//    {
//        _ = Directory.CreateDirectory(providersDirectory);
//    }

//    var eventId = 1;
//    foreach (var provider in providers)
//    {
//        CreateProvider(provider, ref eventId);
//    }
//}

//string ProviderEventMap(Provider provider)
//{
//    if (provider.Events == null || provider.Events.Count == 0)
//    {
//        return string.Empty;
//    }

//    var builder = new StringBuilder($", Events = new Dictionary<EtwEventDescriptor, KnownEvent> {{");
//    var first = true;

//    foreach (var (name, e) in provider.Events)
//    {
//        if (!first)
//        {
//            _ = builder.Append(',');
//        }
//        else
//        {
//            first = false;
//        }

//        var eventFullName = $"{ProviderFullName(provider)}.{name}Event";
//        _ = builder.Append($" {{ {eventFullName}.Descriptor, new KnownEvent {{ Id = {eventFullName}.Id, Name = {eventFullName}.Name }} }}");
//    }

//    _ = builder.Append(" }");

//    return builder.ToString();
//}

//void CreateMaps()
//{
//    var builder = new StringBuilder(@"using System;
//using System.Collections.Generic;

//namespace EtwTools
//{
//    public partial class EtwProvider
//    {
//        internal static readonly Dictionary<Guid, KnownProvider> s_knownProviders = new()
//        {
//");

//    foreach (var provider in providers)
//    {
//        var providerClassFullName = ProviderFullName(provider);
//        _ = builder.AppendLine($"            {{ {providerClassFullName}.Id, new KnownProvider {{ Name = {providerClassFullName}.Name{ProviderEventMap(provider)} }} }},");
//    }

//    _ = builder.Append(@"        };
//    }
//}");

//    File.WriteAllText(Path.Combine(args[1], "EtwProvider.generated.cs"), builder.ToString());
//}

//CreateProviders();
//CreateMaps();

//return 0;

//[DebuggerDisplay("{Name} ({Id})")]
//internal sealed class Provider
//{
//    public string Name { get; set; }
//    public Guid Id { get; set; }
//    public IReadOnlyDictionary<string, Event> Events { get; set; }
//    public IReadOnlyDictionary<string, IReadOnlyList<Field>> Structs { get; set; }
//}

//internal sealed class Event
//{
//    public EventDescriptor Descriptor { get; set; }
//    public IReadOnlyList<Field> Fields { get; set; }
//}

//internal sealed class Field
//{
//    public string Name { get; set; }
//    public string Datatype { get; set; }
//}

//internal sealed class EventDescriptor
//{
//    public ushort Id { get; set; }
//    public uint Version { get; set; }
//    public byte Channel { get; set; }
//    public byte Level { get; set; }
//    public byte Opcode { get; set; }
//    public ushort Task { get; set; }
//    public ulong Keyword { get; set; }
//}

internal record Manifest
{

}
