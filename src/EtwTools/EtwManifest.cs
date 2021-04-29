using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;

namespace EtwTools
{
    /// <summary>
    /// A ETW provider's manifest.
    /// </summary>
    public sealed class EtwManifest
    {
        private const string EventsNamespace = "http://schemas.microsoft.com/win/2004/08/events";

        /// <summary>
        /// The name of the provider.
        /// </summary>
        public string Name { get; init; }

        /// <summary>
        /// The symbol of the provider.
        /// </summary>
        public string Symbol { get; init; }

        /// <summary>
        /// The GUID of the provider.
        /// </summary>
        public string Id { get; init; }

        /// <summary>
        /// The tasks of the provider.
        /// </summary>
        public IReadOnlyList<EtwProviderFieldInfo> Tasks { get; init; }

        /// <summary>
        /// The keywords of the provider.
        /// </summary>
        public IReadOnlyList<EtwProviderFieldInfo> Keywords { get; init; }

        /// <summary>
        /// The opcodes of the provider.
        /// </summary>
        public IReadOnlyDictionary<string, byte> Opcodes { get; init; }

        /// <summary>
        /// The maps of the provider.
        /// </summary>
        public IReadOnlyDictionary<string, Map> Maps { get; init; }

        /// <summary>
        /// The events of the provider.
        /// </summary>
        public IReadOnlyDictionary<string, ProviderEvent> Events { get; init; }

        /// <summary>
        /// The templates of the provider.
        /// </summary>
        public IReadOnlyDictionary<string, Template> Templates { get; init; }

        private static XElement GetOneChild(XContainer element, string name) => GetChildren(element, name)[name];

        private static (XElement, XElement) GetTwoChildren(XContainer element, string firstName, string secondName)
        {
            var children = GetChildren(element, firstName, secondName);
            return (children[firstName], children[secondName]);
        }

        private static Dictionary<string, XElement> GetChildren(XContainer element, params string[] names)
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

        private static void EnsureNoElements(XElement element)
        {
            if (element.Elements().Any())
            {
                throw new InvalidOperationException();
            }
        }

        private static Dictionary<string, string> GetAttributes(XElement element, params string[] names)
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

        private static string GetOneAttribute(XElement element, string name) => GetAttributes(element, name)[name];

        private static (string, string) GetTwoAttributes(XElement element, string firstName, string secondName)
        {
            var attributes = GetAttributes(element, firstName, secondName);
            return (attributes[firstName], attributes[secondName]);
        }

        private static (string, string, string) GetThreeAttributes(XElement element, string firstName, string secondName, string thirdName)
        {
            var attributes = GetAttributes(element, firstName, secondName, thirdName);
            return (attributes[firstName], attributes[secondName], attributes[thirdName]);
        }

        private static (string, string, string, string, string) GetFiveAttributes(XElement element, string firstName, string secondName, string thirdName, string fourthName, string fifthName)
        {
            var attributes = GetAttributes(element, firstName, secondName, thirdName, fourthName, fifthName);
            return (attributes[firstName], attributes[secondName], attributes[thirdName], attributes[fourthName], attributes[fifthName]);
        }

        private static void CollectElements<T>(XElement element, T collection, string name, Action<XElement, T> collector)
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

        private static void CollectElementsChoice<T>(XElement element, T collection, IDictionary<string, Action<XElement, T>> choices)
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

        private static string LookupString(Dictionary<string, string> stringTable, string index)
        {
            if (!index.StartsWith("$(string.", StringComparison.Ordinal) || !index.EndsWith(")", StringComparison.Ordinal))
            {
                throw new InvalidOperationException();
            }

            index = index[9..^1];
            return stringTable[index];
        }

        /// <summary>
        /// Parses an XML manifest.
        /// </summary>
        /// <param name="xml">The manifest's XML.</param>
        /// <returns>The manifest.</returns>
        public static EtwManifest Parse(string xml)
        {
            var document = XDocument.Parse(xml);
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

            List<EtwProviderFieldInfo> tasks = new();
            if (componentElements.TryGetValue("tasks", out var tasksElement))
            {
                CollectElements(tasksElement, tasks, "task", (element, tasks) =>
                {
                    EnsureNoElements(element);
                    var (nameAttribute, messageAttribute, valueAttribute) = GetThreeAttributes(element, "name", "message", "value");
                    tasks.Add(new EtwProviderFieldInfo { Name = nameAttribute, Description = LookupString(stringTable, messageAttribute), Value = Convert.ToUInt16(valueAttribute, CultureInfo.InvariantCulture) });
                });
            }

            List<EtwProviderFieldInfo> keywords = new();
            if (componentElements.TryGetValue("keywords", out var keywordsElement))
            {
                CollectElements(keywordsElement, keywords, "keyword", (element, keywords) =>
                {
                    EnsureNoElements(element);
                    var (nameAttribute, messageAttribute, maskAttribute) = GetThreeAttributes(element, "name", "message", "mask");
                    keywords.Add(new EtwProviderFieldInfo { Name = nameAttribute, Description = LookupString(stringTable, messageAttribute), Value = Convert.ToUInt64(maskAttribute, 16) });
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

            Dictionary<string, Map> maps = new();
            if (componentElements.TryGetValue("maps", out var mapsElement))
            {
                CollectElementsChoice(mapsElement, maps, new Dictionary<string, Action<XElement, Dictionary<string, Map>>> {
                    { "valueMap", (element, maps) =>
                        {
                            var nameAttribute = GetOneAttribute(element, "name");

                            Dictionary<ulong, string> values = new();
                            CollectElements(element, values, "map", (element, values) =>
                            {
                                EnsureNoElements(element);
                                var (valueAttribute, messageAttribute) = GetTwoAttributes(element, "value", "message");
                                values[Convert.ToUInt64(valueAttribute, 16)] = LookupString(stringTable, messageAttribute);
                            });
                            maps[nameAttribute] = new Map { Flags = false, Values = values };
                        }
                    },
                    { "bitMap", (element, maps) =>
                        {
                            var nameAttribute = GetOneAttribute(element, "name");

                            Dictionary<ulong, string> values = new();
                            CollectElements(element, values, "map", (element, values) =>
                            {
                                EnsureNoElements(element);
                                var (valueAttribute, messageAttribute) = GetTwoAttributes(element, "value", "message");
                                values[Convert.ToUInt64(valueAttribute, 16)] = LookupString(stringTable, messageAttribute);
                            });
                            maps[nameAttribute] = new Map { Flags = true, Values = values };
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
                            "win:UnicodeString" => EtwInputType.UnicodeString,
                            "win:AnsiString" => EtwInputType.AnsiString,
                            "win:Int32" => EtwInputType.Int32,
                            "win:UInt32" => EtwInputType.Uint32,
                            "win:Int64" => EtwInputType.Int64,
                            "win:UInt64" => EtwInputType.Uint64,
                            "win:Boolean" => EtwInputType.Boolean,
                            "win:GUID" => EtwInputType.Guid,
                            _ => throw new InvalidOperationException()
                        };
                        _ = attributes.TryGetValue("map", out var map);
                        fields.Add(new Field { Name = name, Datatype = datatype, Map = map });
                    });
                    templates[templateName] = new Template { Fields = fields };
                });
            }

            Dictionary<string, ProviderEvent> events = new();
            if (componentElements.TryGetValue("events", out var componentEventsElement))
            {
                CollectElements(componentEventsElement, events, "event", (element, events) =>
                {
                    var attributes = GetAttributes(element, "value", "version", "level", "symbol", "opcode", "task", "template", "message", "keywords");
                    var descriptor = new EventDescriptor
                    {
                        Id = attributes.TryGetValue("value", out var value) ? Convert.ToUInt16(value, CultureInfo.InvariantCulture) : (ushort)0,
                        Version = attributes.TryGetValue("version", out var version) ? Convert.ToByte(version, CultureInfo.InvariantCulture) : (byte)0,
                        Level = attributes.TryGetValue("level", out var level) ? level : null,
                        Opcode = attributes.TryGetValue("opcode", out var opcode) ? opcode : null,
                        Task = attributes.TryGetValue("task", out var task) ? task : null,
                        Keyword = attributes.TryGetValue("keywords", out var eventKeywords) ? eventKeywords : null
                    };
                    events[attributes["symbol"]] = new ProviderEvent
                    {
                        Descriptor = descriptor,
                        Template = attributes.TryGetValue("template", out var eventTemplate) ? eventTemplate : null
                    };
                });
            }

            return new EtwManifest { Name = nameAttribute, Symbol = symbolAttribute, Id = guidAttribute, Tasks = tasks, Keywords = keywords, Opcodes = opcodes, Maps = maps, Events = events, Templates = templates };
        }

        /// <summary>
        /// A provider event.
        /// </summary>
        public sealed class ProviderEvent
        {
            /// <summary>
            /// The event descriptor.
            /// </summary>
            public EventDescriptor Descriptor { get; init; }

            /// <summary>
            /// The event template.
            /// </summary>
            public string Template { get; init; }
        }

        /// <summary>
        /// An event descriptor.
        /// </summary>
        public sealed class EventDescriptor
        {
            /// <summary>
            /// The event ID.
            /// </summary>
            public ushort Id { get; set; }

            /// <summary>
            /// The event version.
            /// </summary>
            public byte Version { get; set; }

            /// <summary>
            /// The event channel.
            /// </summary>
            public byte Channel { get; set; }

            /// <summary>
            /// The event level.
            /// </summary>
            public string Level { get; set; }

            /// <summary>
            /// The event opcode.
            /// </summary>
            public string Opcode { get; set; }

            /// <summary>
            /// The event task.
            /// </summary>
            public string Task { get; set; }

            /// <summary>
            /// The event keyword.
            /// </summary>
            public string Keyword { get; set; }
        }

        /// <summary>
        /// An event field.
        /// </summary>
        public sealed class Field
        {
            /// <summary>
            /// The name of the field.
            /// </summary>
            public string Name { get; init; }

            /// <summary>
            /// The datatype of the field.
            /// </summary>
            public EtwInputType Datatype { get; init; }

            /// <summary>
            /// The field's map (if any).
            /// </summary>
            public string Map { get; init; }
        }

        /// <summary>
        /// A value map.
        /// </summary>
        public sealed class Map
        {
            /// <summary>
            /// Whether the values are flags.
            /// </summary>
            public bool Flags { get; init; }

            /// <summary>
            /// The values in the map.
            /// </summary>
            public IReadOnlyDictionary<ulong, string> Values { get; init; }
        }

        /// <summary>
        /// An event template.
        /// </summary>
        public sealed class Template
        {
            /// <summary>
            /// The fields in the template.
            /// </summary>
            public IReadOnlyList<Field> Fields { get; set; }
        }
    }
}
