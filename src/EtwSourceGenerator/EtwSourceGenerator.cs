using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

const string EventsNamespace = "http://schemas.microsoft.com/win/2004/08/events";

static XElement GetOneChild(XContainer element, string name) => GetChildren(element, name)[name];

static (XElement, XElement) GetTwoChildren(XContainer element, string firstName, string secondName)
{
    var children = GetChildren(element, firstName, secondName);
    return (children[firstName], children[secondName]);
}

static Dictionary<string, XElement> GetChildren(XContainer element, params string[] names)
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

static void EnsureNoElements(XElement element)
{
    if (element.Elements().Any())
    {
        throw new InvalidOperationException();
    }
}

static Dictionary<string, string> GetAttributes(XElement element, params string[] names)
{
    if (element.Attributes().Count() > names.Length)
    {
        throw new InvalidOperationException();
    }

    Dictionary<string, string> result = new();
    HashSet<string> nameHash = new(names);

    foreach (var e in element.Attributes())
    {
        if (!nameHash.Contains(e.Name.LocalName) || result.ContainsKey(e.Name.LocalName))
        {
            throw new InvalidOperationException();
        }

        result[e.Name.LocalName] = e.Value;
    }

    return result;
}

static string GetOneAttribute(XElement element, string name) => GetAttributes(element, name)[name];

static (string, string) GetTwoAttributes(XElement element, string firstName, string secondName)
{
    var attributes = GetAttributes(element, firstName, secondName);
    return (attributes[firstName], attributes[secondName]);
}

static (string, string, string) GetThreeAttributes(XElement element, string firstName, string secondName, string thirdName)
{
    var attributes = GetAttributes(element, firstName, secondName, thirdName);
    return (attributes[firstName], attributes[secondName], attributes[thirdName]);
}

static (string, string, string, string, string) GetFiveAttributes(XElement element, string firstName, string secondName, string thirdName, string fourthName, string fifthName)
{
    var attributes = GetAttributes(element, firstName, secondName, thirdName, fourthName, fifthName);
    return (attributes[firstName], attributes[secondName], attributes[thirdName], attributes[fourthName], attributes[fifthName]);
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
    if (GetOneAttribute(resourcesElement, "culture") != "en-US")
    {
        throw new InvalidOperationException();
    }
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
    var componentElements = GetChildren(providerElement, "tasks", "maps", "opcodes", "keywords", "events", "templates");

    Dictionary<string, ushort> tasks = new();
    if (componentElements.TryGetValue("tasks", out var tasksElement))
    {
        CollectElements(tasksElement, tasks, "task", (element, tasks) =>
        {
            EnsureNoElements(element);
            var (nameAttribute, messageAttribute, valueAttribute) = GetThreeAttributes(element, "name", "message", "value");
            tasks[LookupString(stringTable, messageAttribute)] = Convert.ToUInt16(valueAttribute, CultureInfo.InvariantCulture);
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

    Dictionary<string, byte> opcodes = new();
    if (componentElements.TryGetValue("opcodes", out var opcodesElement))
    {
        CollectElements(opcodesElement, opcodes, "opcode", (element, opcodes) =>
        {
            EnsureNoElements(element);
            var (nameAttribute, messageAttribute, valueAttribute) = GetThreeAttributes(element, "name", "message", "value");
            opcodes[LookupString(stringTable, messageAttribute)] = Convert.ToByte(valueAttribute, CultureInfo.InvariantCulture);
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

    Dictionary<string, Template> templates = new();
    if (componentElements.TryGetValue("templates", out var templatesElement))
    {
        CollectElements(templatesElement, templates, "template", (element, templates) =>
        {
            var templateName = GetOneAttribute(element, "tid");
            List<Field> fields = new();
            CollectElements(element, fields, "data", (fieldElement, fields) =>
            {
                var attributes = GetAttributes(fieldElement, "name", "inType", "map");
                var name = attributes["name"];
                name = $"{char.ToUpperInvariant(name[0])}{name[1..]}";
                var datatype = attributes["inType"] switch
                {
                    "win:UnicodeString" => "string",
                    "win:Int32" => "int",
                    "win:UInt32" => "uint",
                    "win:Int64" => "long",
                    "win:UInt64" => "ulong",
                    "win:Boolean" => "bool",
                    "win:GUID" => "Guid",
                    _ => throw new InvalidOperationException()
                };
                _ = attributes.TryGetValue("map", out var map);
                fields.Add(new Field { Name = name, Datatype = datatype, Map = map });
            });
            templates[templateName] = new Template { Fields = fields };
        });
    }

    Dictionary<string, Event> events = new();
    if (componentElements.TryGetValue("events", out var componentEventsElement))
    {
        CollectElements(componentEventsElement, events, "event", (element, events) =>
        {
            var attributes = GetAttributes(element, "value", "version", "level", "symbol", "opcode", "task", "template", "message", "keywords");
            var descriptor = new EventDescriptor
            {
                Id = attributes.TryGetValue("value", out var value) ? Convert.ToUInt16(value, CultureInfo.InvariantCulture) : (ushort)0,
                Version = attributes.TryGetValue("version", out var version) ? Convert.ToUInt32(version, CultureInfo.InvariantCulture) : (uint)0,
                Level = attributes.TryGetValue("level", out var level) ? level : null,
                Opcode = attributes.TryGetValue("opcode", out var opcode) ? opcode : null,
                Task = attributes.TryGetValue("task", out var task) ? task : null,
                Keyword = attributes.TryGetValue("keywords", out var eventKeywords) ? eventKeywords : null
            };
            events[attributes["symbol"]] = new Event
            {
                Descriptor = descriptor,
                Fields = attributes.TryGetValue("template", out var eventTemplate)
                    ? (templates.TryGetValue(eventTemplate, out var template) ? template.Fields : throw new InvalidOperationException())
                    : null
            };
        });
    }

    return new Manifest { Path = path, Name = nameAttribute, Symbol = symbolAttribute, Guid = guidAttribute, Tasks = tasks, Keywords = keywords, Opcodes = opcodes, Maps = maps, Events = events };
}

static string ConverterMethod(Field f, string location) =>
    @$"{(f.Map == null ? string.Empty : $"({f.Map})")}{f.Datatype switch
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
        "string" => $"System.Text.Encoding.Unicode.GetString({location})",
        "address" => $"_etwEvent.AddressSize == 4 ? BitConverter.ToUInt32({location}) : BitConverter.ToUInt64({location})",
        "Guid" => $"new({location})",
        _ => "unknown"
    }}";

static string ReturnType(Field f) =>
    f.Map ?? f.Datatype switch
    {
        "byte" or "sbyte" or "bool" or "ushort" or "short" or "uint" or "int" or "ulong" or "long" or "string" or "Guid" => f.Datatype,
        "address" => "ulong",
        _ => "unknown"
    };

static string VariableSize(string datatype, string offset) =>
    datatype switch
    {
        "address" => "etwEvent.AddressSize",
        "string" => $"EtwEvent.StringEnumerable.StringEnumerator.StringLength(etwEvent.Data, {offset})",
        _ => "unknown"
    };

static int Size(string datatype) =>
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
        "Guid" => 16,
        _ => -1
    };

static void CreateEventField(Event e, int i, StringBuilder builder, Dictionary<Field, string> fieldOffsets)
{
    var field = e.Fields[i];
    var name = field.Name;
    if (name.StartsWith('_'))
    {
        return;
    }

    var datatype = field.Datatype;
    var openBrace = datatype.IndexOf('[');
    var count = string.Empty;

    if (openBrace != -1)
    {
        count = datatype[(openBrace + 1)..^1];
        datatype = datatype[..openBrace];

        var location = $"_etwEvent.Data[{fieldOffsets[field]}..{(i + 1 < e.Fields.Count ? fieldOffsets[e.Fields[i + 1]] : string.Empty)}]";

        _ = builder.Append(datatype switch
        {
            "address" => $@"

                /// <summary>
                /// Retrieves the {name} field.
                /// </summary>
                public EtwEvent.AddressEnumerable {name} => new({location}, _etwEvent.AddressSize{(count == "..." ? string.Empty : $", {count}")});",
            "string" => $@"

                /// <summary>
                /// Retrieves the {name} field.
                /// </summary>
                public EtwEvent.StringEnumerable {name} => new({location}{(count == "..." ? string.Empty : $", {count}")});",
            _ => $@"

                /// <summary>
                /// Retrieves the {name} field.
                /// </summary>
                public EtwEvent.StructEnumerable<{datatype}> {name} => new({location}{(count == "..." ? string.Empty : $", {count}")});"
        });
    }
    else
    {
        var location = $"_etwEvent.Data[{fieldOffsets[field]}{(Size(datatype) == 1 ? string.Empty : $"..{(i + 1 < e.Fields.Count ? fieldOffsets[e.Fields[i + 1]] : string.Empty)}")}]";
        _ = builder.Append($@"

                /// <summary>
                /// Retrieves the {name} field.
                /// </summary>
                public {ReturnType(field)} {name} => {ConverterMethod(field, location)};");
    }
}

static string CreateEventFields(Event e, Dictionary<Field, string> fieldOffsets)
{
    if (e.Fields == null || !e.Fields.Any())
    {
        return string.Empty;
    }

    var builder = new StringBuilder();

    for (var i = 0; i < e.Fields.Count; i++)
    {
        CreateEventField(e, i, builder, fieldOffsets);
    }

    return builder.ToString();
}

static string CreateEventFieldOffsetInitializers(Event e, Dictionary<Field, string> fieldOffsets)
{
    if (e.Fields == null || !e.Fields.Any())
    {
        return string.Empty;
    }

    var builder = new StringBuilder();
    var previousField = string.Empty;
    var previousSize = string.Empty;

    foreach (var f in e.Fields)
    {
        var fieldName = fieldOffsets[f];

        if (fieldName.StartsWith('_'))
        {
            _ = builder.Append($@"
                    {fieldName} = {previousField} + {previousSize};");
        }

        var size = Size(f.Datatype);
        previousSize = size == -1 ? VariableSize(f.Datatype, fieldName) : size.ToString(CultureInfo.InvariantCulture);
        previousField = fieldName;
    }

    return builder.ToString();
}

static string CreateEventFieldOffsets(Manifest manifest, Event e, Dictionary<Field, string> fieldOffsets)
{
    if (e.Fields == null || !e.Fields.Any())
    {
        return string.Empty;
    }

    var builder = new StringBuilder();
    var foundVariableField = false;
    var offset = 0;

    _ = builder.AppendLine();

    foreach (var f in e.Fields)
    {
        if (!foundVariableField)
        {
            var fieldName = $"Offset_{f.Name}";
            fieldOffsets[f] = fieldName;

            _ = builder.Append(@$"
                private const int {fieldName} = {offset};");

            var size = Size(f.Datatype);

            if (size == -1)
            {
                foundVariableField = true;
            }
            else
            {
                offset += size;
            }
        }
        else
        {
            var fieldName = $"_offset_{f.Name}";
            fieldOffsets[f] = fieldName;
            _ = builder.Append($@"
                private readonly int {fieldName};");
        }
    }

    return builder.ToString();
}

static string CreateProviderEvents(Manifest manifest)
{
    if (manifest.Events == null || manifest.Events.Count == 0)
    {
        return string.Empty;
    }

    var builder = new StringBuilder();

    foreach (var (name, e) in manifest.Events)
    {
        Dictionary<Field, string> fieldOffsets = new();

        _ = builder.Append($@"

        /// <summary>
        /// An event wrapper for a {name} event.
        /// </summary>
        public readonly ref struct {name}Event
        {{
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = ""{name}"";

            /// <summary>
            /// The event provider.
            /// </summary>
            public static readonly Guid Provider = Id;

            /// <summary>
            /// Event descriptor.
            /// </summary>
            public static EtwEventDescriptor Descriptor {{ get; }} = new EtwEventDescriptor
            {{
                Id = {e.Descriptor.Id},
                Version = {e.Descriptor.Version},
                Channel = {e.Descriptor.Channel},
                Level = {(e.Descriptor.Level ?? "win:LogAlways") switch
        {
            "win:LogAlways" => "EtwTraceLevel.None",
            "win:Critical" => "EtwTraceLevel.Critical",
            "win:Error" => "EtwTraceLevel.Error",
            "win:Warning" => "EtwTraceLevel.Warning",
            "win:Informational" => "EtwTraceLevel.Information",
            "win:Verbose" => "EtwTraceLevel.Verbose",
            _ => throw new InvalidOperationException()
        }},
                Opcode = {((e.Descriptor.Opcode ?? "win:Info") switch
        {
            "win:Info" => "EtwEventType.Info",
            "win:Start" => "EtwEventType.Start",
            "win:End" => "EtwEventType.End",
            "win:Stop" => "EtwEventType.Stop",
            "win:Send" => "EtwEventType.End",
            "win:Receive" => "EtwEventType.Recieve",
            _ => e.Descriptor.Opcode.StartsWith("win:", StringComparison.Ordinal) ? throw new InvalidOperationException() : $"(EtwEventType)Opcodes.{e.Descriptor.Opcode}"
        })},
                Task = {(e.Descriptor.Task != null ? $"(ushort)Tasks.{e.Descriptor.Task}" : "0")},
                Keyword = {(e.Descriptor.Keyword == null
                    ? "0"
                    : !e.Descriptor.Keyword.Contains(" ", StringComparison.InvariantCulture)
                        ? $"(ulong)Keywords.{e.Descriptor.Keyword}"
                        : $"(ulong)({e.Descriptor.Keyword?.Split(" ").Aggregate(string.Empty, (s, k) => $"{s}{(string.IsNullOrEmpty(s) ? string.Empty : " | ")}Keywords.{k}")})")}
            }};

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
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;{(e.Fields == null || e.Fields.Count == 0 ? string.Empty : $@"

            /// <summary>
            /// Data for the event.
            /// </summary>
            public {name}Data Data => new(_etwEvent);")}

            /// <summary>
            /// Creates a new {name}Event.
            /// </summary>
            /// <param name=""etwEvent"">The event.</param>
            public {name}Event(EtwEvent etwEvent)
            {{
                _etwEvent = etwEvent;
            }}{(e.Fields == null || e.Fields.Count == 0 ? string.Empty : $@"

            /// <summary>
            /// A data wrapper for a {name} event.
            /// </summary>
            public readonly ref struct {name}Data
            {{
                private readonly EtwEvent _etwEvent;{CreateEventFieldOffsets(manifest, e, fieldOffsets)}{CreateEventFields(e, fieldOffsets)}

                /// <summary>
                /// Creates a new {name}Data.
                /// </summary>
                /// <param name=""etwEvent"">The event.</param>
                public {name}Data(EtwEvent etwEvent)
                {{
                    _etwEvent = etwEvent;{CreateEventFieldOffsetInitializers(e, fieldOffsets)}
                }}
            }}
")}
        }}");
    }

    return builder.ToString();
}

static string CreateProviderTasks(Manifest manifest)
{
    if (manifest.Tasks == null || manifest.Tasks.Count == 0)
    {
        return string.Empty;
    }

    StringBuilder builder = new();

    _ = builder.Append($@"

        /// <summary>
        /// Tasks supported by {manifest.Name}.
        /// </summary>
        public enum Tasks : ushort
        {{");

    foreach (var (name, value) in manifest.Tasks.OrderBy(kvp => kvp.Value))
    {
        _ = builder.Append($@"
            /// <summary>
            /// '{name}' task.
            /// </summary>
            {name} = {value},");
    }

    _ = builder.Append(@"
        }");

    return builder.ToString();
}

static string CreateProviderOpcodes(Manifest manifest)
{
    if (manifest.Opcodes == null || manifest.Opcodes.Count == 0)
    {
        return string.Empty;
    }

    StringBuilder builder = new();

    _ = builder.Append($@"

        /// <summary>
        /// Opcodes supported by {manifest.Name}.
        /// </summary>
        public enum Opcodes
        {{");

    foreach (var (name, value) in manifest.Opcodes.OrderBy(kvp => kvp.Value))
    {
        _ = builder.Append($@"
            /// <summary>
            /// '{name}' opcode.
            /// </summary>
            {name} = {value},");
    }

    _ = builder.Append(@"
        }");

    return builder.ToString();
}

static string CreateProviderKeywords(Manifest manifest)
{
    if (manifest.Keywords == null || manifest.Keywords.Count == 0)
    {
        return string.Empty;
    }

    StringBuilder builder = new();

    _ = builder.Append($@"

        /// <summary>
        /// Keywords supported by {manifest.Name}.
        /// </summary>
        [Flags]
        public enum Keywords : ulong
        {{");

    foreach (var (name, value) in manifest.Keywords.OrderBy(kvp => kvp.Value))
    {
        _ = builder.Append($@"
            /// <summary>
            /// '{name}' keyword.
            /// </summary>
            {name} = 0x{value:X16},");
    }

    _ = builder.Append(@"
        }");

    return builder.ToString();
}

static string CreateProviderMaps(Manifest manifest)
{
    if (manifest.Maps == null || manifest.Maps.Count == 0)
    {
        return string.Empty;
    }

    StringBuilder builder = new();

    foreach (var (name, value) in manifest.Maps)
    {
        _ = builder.Append($@"

        /// <summary>
        /// {name}.
        /// </summary>");
        if (value.Item1)
        {
            _ = builder.Append(@"
        [Flags]
");
        }

        _ = builder.Append($@"
        public enum {name}
        {{");

        foreach (var (enumValue, enumName) in value.Item2)
        {
            _ = !value.Item1
                ? builder.Append($@"
            /// <summary>
            /// {enumName}.
            /// </summary>
            {enumName} = {enumValue},")
                : builder.Append($@"
            /// <summary>
            /// {enumName}.
            /// </summary>
            {enumName} = 0x{enumValue:X16},");
        }

        _ = builder.Append(@"
        }");
    }

    return builder.ToString();
}

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

static void CreateProvider(string providersDirectory, Manifest manifest)
{
    var builder = new StringBuilder(@$"using System;

#pragma warning disable CA1707 // Identifiers should not contain underscores
#pragma warning disable CA1720 // Identifier contains type name

namespace EtwTools
{{
    /// <summary>
    /// Provider for {manifest.Name} ({manifest.Guid})
    /// </summary>
    public sealed class {manifest.Symbol}Provider
    {{
        /// <summary>
        /// Provider ID.
        /// </summary>
        public static readonly Guid Id = new(""{manifest.Guid}"");

        /// <summary>
        /// Provider name.
        /// </summary>
        public const string Name = ""{manifest.Name}"";{CreateProviderEvents(manifest)}{CreateProviderTasks(manifest)}{CreateProviderOpcodes(manifest)}{CreateProviderKeywords(manifest)}{CreateProviderMaps(manifest)}{/*CreateProviderStructs(provider, providerClassName)*/""}
    }}
}}
");

    File.WriteAllText(Path.Combine(providersDirectory, $"{Path.GetFileNameWithoutExtension(manifest.Path)}.cs"), builder.ToString());
}

static void CreateMap(string providersDirectory, IReadOnlyList<Manifest> manifests)
{
    var builder = new StringBuilder(@"using System;
using System.Collections.Generic;
namespace EtwTools
{
    public partial class EtwProvider
    {
        internal static readonly Dictionary<Guid, (string Name, Dictionary<EtwEventDescriptor, string> Events)> s_knownProviders = new()
        {
");
    foreach (var manifest in manifests)
    {
        _ = builder.AppendLine(@$"
            {{ 
                {manifest.Symbol}Provider.Id,
                (
                    {manifest.Symbol}Provider.Name, new Dictionary<EtwEventDescriptor, string>
                    {{{manifest.Events.Aggregate(new StringBuilder(), (s, e) => s.Append($@"
                        {{ {manifest.Symbol}Provider.{e.Key}Event.Descriptor, {manifest.Symbol}Provider.{e.Key}Event.Name }},"))}
                    }}
                )
            }},");
    }
    _ = builder.Append(@"        };
    }
}");
    File.WriteAllText(Path.Combine(providersDirectory, "EtwProvider.generated.cs"), builder.ToString());
}

if (args.Length != 2)
{
    return -1;
}

var providersDirectory = args[1];

if (!Directory.Exists(providersDirectory))
{
    _ = Directory.CreateDirectory(providersDirectory);
}

List<Manifest> manifests = new();

foreach (var file in Directory.GetFiles(args[0]))
{
    Console.WriteLine($"Processing manifest '{Path.GetFileNameWithoutExtension(file)}'.");
    var manifest = ReadManifest(file);

    if (manifest == null)
    {
        Console.WriteLine("Bad manifest.");
        continue;
    }

    CreateProvider(providersDirectory, manifest);
    manifests.Add(manifest);
}

CreateMap(providersDirectory, manifests);

return 0;

internal record Event
{
    public EventDescriptor Descriptor { get; set; }
    public IReadOnlyList<Field> Fields { get; set; }
}

internal record EventDescriptor
{
    public ushort Id { get; set; }
    public uint Version { get; set; }
    public byte Channel { get; set; }
    public string Level { get; set; }
    public string Opcode { get; set; }
    public string Task { get; set; }
    public string Keyword { get; set; }
}

internal record Template
{
    public IReadOnlyList<Field> Fields { get; set; }
}

internal record Field
{
    public string Name { get; set; }
    public string Datatype { get; set; }
    public string Map { get; set; }
}

internal record Manifest
{
    public string Path { get; set; }
    public string Name { get; set; }
    public string Symbol { get; set; }
    public string Guid { get; set; }
    public Dictionary<string, ushort> Tasks { get; set; }
    public Dictionary<string, ulong> Keywords { get; set; }
    public Dictionary<string, byte> Opcodes { get; set; }
    public Dictionary<string, (bool, Dictionary<long, string>)> Maps { get; set; }
    public Dictionary<string, Event> Events { get; set; }
}
