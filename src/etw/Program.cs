using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Newtonsoft.Json;

using Spectre.Console;

using EtwTools;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Text;

var rootCommand = new RootCommand("Controls Event Tracing for Windows (ETW).");

var defaultJsonSettings = new JsonSerializerSettings
{
    Formatting = Formatting.Indented,
    Converters = new[] { new StringEnumConverter() },
    ContractResolver = new DefaultContractResolver
    {
        NamingStrategy = new CamelCaseNamingStrategy()
    }
};

void AddSessionCommands(Command sessionCommand)
{
    var listCommand = new Command("list", "List all active ETW sessions.")
    {
        new Option<bool>(new[] { "--json" }, "Output in JSON format.")
    };
    listCommand.Handler = CommandHandler.Create<bool>(ListSessions);
    sessionCommand.Add(listCommand);

    var propertiesCommand = new Command("properties", "List properties of an ETW session.")
    {
        new Argument<string>("session", "Name of session to fetch properties of."),
        new Option<bool>(new[] { "--json" }, "Output in JSON format.")
    };
    propertiesCommand.Handler = CommandHandler.Create<string, bool>(GetSessionProperties);
    sessionCommand.Add(propertiesCommand);

    var statisticsCommand = new Command("statistics", "Statistics of an ETW session.")
    {
        new Argument<string>("session", "Name of session to fetch statistics of."),
        new Option<bool>(new[] { "--json" }, "Output in JSON format.")
    };
    statisticsCommand.Handler = CommandHandler.Create<string, bool>(GetSessionStatistics);
    sessionCommand.Add(statisticsCommand);

    var watchCommand = new Command("watch", "Watch an ETW session.")
    {
        new Argument<string>("session", "Name of session to watch."),
        new Option<bool>(new[] { "--json" }, "Output in JSON format.")
    };
    watchCommand.Handler = CommandHandler.Create<string, bool>(WatchSessionAsync);
    sessionCommand.Add(watchCommand);

    var startCommand = new Command("start", "Start a tracing session.")
    {
        new Argument<string>("session", "Name of session to start."),
        new Option<string>(new[] { "--spec", "-s" }, "The trace specification.") { IsRequired = true },
        new Option<string>(new[] { "--output", "-o" }, "The output path and file name."),
        new Option<bool>(new[] { "--wait", "-w" }, "Wait while trace runs and end trace when program ends."),
        new Option<bool>(new[] { "--watch" }, "Wait and watch trace while it runs (implies --wait).")
    };
    startCommand.Handler = CommandHandler.Create<string, string, string, bool, bool>(StartSessionAsync);
    sessionCommand.Add(startCommand);

    var stopCommand = new Command("stop", "Stop a tracing session.")
    {
        new Argument<string>("session", "Name of session to stop."),
    };
    stopCommand.Handler = CommandHandler.Create<string>(StopSession);
    sessionCommand.Add(stopCommand);
}

var sessionCommand = new Command("session", "Commands that work on individual sessions.");
rootCommand.Add(sessionCommand);
AddSessionCommands(sessionCommand);

void AddProvidersCommands(Command providersCommand)
{
    var listCommand = new Command("list", "List all providers published on the system.")
    {
        new Option<PublishedSort>(new[] { "--sort", "-s" }, () => PublishedSort.Name, "Sort providers."),
        new Option<bool>(new[] { "--json" }, "Output in JSON format."),
        new Option<bool>(new[] { "--unknown", "-u" }, "Only list unknown providers."),
    };
    listCommand.Handler = CommandHandler.Create<PublishedSort, bool, bool>(ListPublishedProviders);
    providersCommand.AddCommand(listCommand);

    var processCommand = new Command("process", "List all providers registered in a process.")
    {
        new Argument<uint>("pid", "Process to list."),
        new Option<bool>(new[] { "--json" }, "Output in JSON format.")
    };
    processCommand.Handler = CommandHandler.Create<uint, bool>(ListRegisteredProvidersInProcess);
    providersCommand.AddCommand(processCommand);

    var infoCommand = new Command("info", "Saves provider information.")
    {
        new Argument<string>("provider", "The provider ID.")
    };
    infoCommand.Handler = CommandHandler.Create<string>(SaveProvider);
    providersCommand.AddCommand(infoCommand);

    var manifestCommand = new Command("manifest", "Saves provider information from a manifest.")
    {
        new Argument<string>("manifest", "The manifest path (can contain wildcards).")
    };
    manifestCommand.Handler = CommandHandler.Create<string>(SaveManifestProvider);
    providersCommand.AddCommand(manifestCommand);

    var generateCommand = new Command("generate", "Generates a provider class from provider information.")
    {
        new Argument<string>("provider", "The provider information file (can contain wildcards).")
    };
    generateCommand.Handler = CommandHandler.Create<string>(GenerateProvider);
    providersCommand.AddCommand(generateCommand);
}

var providersCommand = new Command("providers", "Commands that work on event providers.");
rootCommand.Add(providersCommand);
AddProvidersCommands(providersCommand);

void AddTraceCommands(Command traceCommand)
{
    var infoCommand = new Command("info", "List information about a trace.")
    {
        new Argument<string>("trace", "The trace file."),
        new Option<bool>(new[] { "--json" }, "Output in JSON format.")
    };
    infoCommand.Handler = CommandHandler.Create<string, bool>(GetTraceInfo);
    traceCommand.AddCommand(infoCommand);

    var traceLoggingCommand = new Command("tracelogging", "Saves TraceLogging provider information stored in a trace.")
    {
        new Argument<string>("trace", "The trace file.")
    };
    traceLoggingCommand.Handler = CommandHandler.Create<string>(SaveTraceLoggingProviders);
    traceCommand.AddCommand(traceLoggingCommand);

    var eventSourceCommand = new Command("eventsource", "Saves System.Diagnostics.Tracing.EventSource provider manifests stored in a trace.")
    {
        new Argument<string>("trace", "The trace file."),
        new Option<bool>(new[] { "-a", "--all" }, "Save all manifests, not just the longest one.")
    };
    eventSourceCommand.Handler = CommandHandler.Create<string, bool>(SaveEventSourceProviders);
    traceCommand.AddCommand(eventSourceCommand);
}

var traceCommand = new Command("trace", "Commands that work on traces.");
rootCommand.Add(traceCommand);
AddTraceCommands(traceCommand);

void ListSessions(bool json)
{
    var sessions = EtwSession.GetAllSessions();

    if (!json)
    {
        var table = new Table().AddColumn("Name").AddColumn("ID").AddColumn("Clock");

        foreach (var session in sessions.OrderBy(s => s.Name))
        {
            _ = table.AddRow(session.Name, session.Id.ToString(), session.ClockResolution.ToString());
        }

        AnsiConsole.Render(table);
    }
    else
    {
        AnsiConsole.WriteLine(JsonConvert.SerializeObject(sessions, defaultJsonSettings));
        AnsiConsole.WriteLine();
    }
}

void GetSessionProperties(string session, bool json)
{
    var etwSession = EtwSession.GetSession(session);

    if (etwSession == null)
    {
        AnsiConsole.WriteLine();
        AnsiConsole.WriteLine("No session found by that name.");
        AnsiConsole.WriteLine();
        return;
    }

    var properties = etwSession.GetProperties();

    if (!json)
    {
        AnsiConsole.WriteLine();
        AnsiConsole.WriteLine($"{etwSession.Name} ({etwSession.Id})");
        AnsiConsole.WriteLine();
        AnsiConsole.WriteLine($"Clock resolution = {etwSession.ClockResolution}");

        AnsiConsole.WriteLine($"Buffer size = {properties.BufferSize}kb");
        AnsiConsole.WriteLine($"Minimum buffers = {properties.MinimumBuffers}");
        AnsiConsole.WriteLine($"Maximum buffers = {properties.MaximumBuffers}");
        AnsiConsole.WriteLine($"Maximum file size = {properties.MaximumFileSize}mb");
        AnsiConsole.WriteLine($"Log file mode = {properties.LogFileMode}");
        AnsiConsole.WriteLine($"Flush timer = {properties.FlushTimer}");
        AnsiConsole.WriteLine($"System trace providers = {properties.SystemTraceProvidersEnabled}");
        AnsiConsole.WriteLine($"Log file name = {properties.LogFileName}");
        AnsiConsole.WriteLine();
    }
    else
    {
        AnsiConsole.WriteLine(JsonConvert.SerializeObject(properties, defaultJsonSettings));
    }
}

void GetSessionStatistics(string session, bool json)
{
    var etwSession = EtwSession.GetSession(session);

    if (etwSession == null)
    {
        AnsiConsole.WriteLine();
        AnsiConsole.WriteLine("No session found by that name.");
        AnsiConsole.WriteLine();
        return;
    }

    var statistics = etwSession.GetStatistics();

    if (!json)
    {
        AnsiConsole.WriteLine();
        AnsiConsole.WriteLine($"{etwSession.Name} ({etwSession.Id})");
        AnsiConsole.WriteLine();

        AnsiConsole.WriteLine($"Number of buffers = {statistics.NumberOfBuffers}");
        AnsiConsole.WriteLine($"Free buffers = {statistics.FreeBuffers}");
        AnsiConsole.WriteLine($"Events lost = {statistics.EventsLost}");
        AnsiConsole.WriteLine($"Buffers written = {statistics.BuffersWritten}");
        AnsiConsole.WriteLine($"Log buffers lost = {statistics.LogBuffersLost}");
        AnsiConsole.WriteLine($"Real time buffers lost = {statistics.RealTimeBuffersLost}");
        AnsiConsole.WriteLine();
    }
    else
    {
        AnsiConsole.WriteLine(JsonConvert.SerializeObject(statistics, defaultJsonSettings));
    }
}

async Task WatchSessionAsync(string session, bool json)
{
    EtwSession etwSession = default;

    var printedHeader = false;
    var waiting = false;
    var stop = false;
    Console.CancelKeyPress += (s, e) =>
    {
        e.Cancel = true;
        stop = true;
    };

    while (!stop)
    {
        etwSession = EtwSession.GetSession(session);

        if (etwSession == null)
        {
            if (!waiting)
            {
                AnsiConsole.WriteLine();
                AnsiConsole.WriteLine("No session found by that name, waiting...");
            }
            waiting = true;
        }
        else if (!json)
        {
            if (!printedHeader)
            {
                AnsiConsole.WriteLine();
                AnsiConsole.WriteLine("Total Buffers\tFree Buffers\tEvents Lost\tBuffers Written\tBuffers Lost\tReal-time Lost");
                printedHeader = true;
            }
            waiting = false;
            var statistics = etwSession.GetStatistics();

            AnsiConsole.WriteLine($"{statistics.NumberOfBuffers}\t\t{statistics.FreeBuffers}\t\t{statistics.EventsLost}\t\t{statistics.BuffersWritten}\t\t{statistics.LogBuffersLost}\t\t{statistics.RealTimeBuffersLost}");
        }
        else
        {
            var statistics = etwSession.GetStatistics();
            AnsiConsole.WriteLine(JsonConvert.SerializeObject(statistics, defaultJsonSettings));
        }

        await Task.Delay(1000);
    }
}

static unsafe bool IsElevated()
{
    var process = System.Diagnostics.Process.GetCurrentProcess();
    if (!Native.OpenProcessToken(process.SafeHandle, Native.AccessRights.Query, out var tokenHandle))
    {
        return false;
    }

    bool isElevated;
    var success = Native.GetTokenInformation(tokenHandle, Native.TokenInformationClass.Elevation, &isElevated, sizeof(int), out var retSize);
    tokenHandle.Dispose();

    return success && isElevated;
}

async Task StartSessionAsync(string session, string spec, string output, bool wait, bool watch)
{
    if (!IsElevated())
    {
        AnsiConsole.WriteLine();
        AnsiConsole.WriteLine("Tracing commands require elevation.");
        AnsiConsole.WriteLine();
        return;
    }

    if (!File.Exists(spec))
    {
        AnsiConsole.WriteLine();
        AnsiConsole.WriteLine("Cannot find trace specification.");
        AnsiConsole.WriteLine();
        return;
    }

    var specObject = JsonConvert.DeserializeObject<TraceSpecification>(File.ReadAllText(spec));
    var systemTraceProvidersEnabled = specObject.Kernel == null || specObject.Kernel.Providers == null
        ? EtwSystemTraceProvider.None
        : specObject.Kernel.Providers.Where(kvp => kvp.Value != TraceState.Off).Aggregate(EtwSystemTraceProvider.None, (v, kvp) => v | kvp.Key);

    var properties = new EtwSession.Properties
    {
        LogFileMode =
            EtwLogFileMode.IndependentSession
            | (systemTraceProvidersEnabled != EtwSystemTraceProvider.None ? EtwLogFileMode.SystemLogger : EtwLogFileMode.None),
        SystemTraceProvidersEnabled = systemTraceProvidersEnabled,
        LogFileName = $"{(string.IsNullOrEmpty(output) ? session : output)}.etl"
    };

    var etwSession = EtwSession.CreateSession(session, properties);

    if (!wait && !watch)
    {
        return;
    }

    await WatchSessionAsync(session, false);

    AnsiConsole.WriteLine();
    AnsiConsole.WriteLine("Stopping session.");
    etwSession.Stop();
}

static void StopSession(string name)
{
    if (!IsElevated())
    {
        AnsiConsole.WriteLine();
        AnsiConsole.WriteLine("Tracing commands require elevation.");
        AnsiConsole.WriteLine();
        return;
    }

    var session = EtwSession.GetSession(name);

    if (session == null)
    {
        AnsiConsole.WriteLine();
        AnsiConsole.WriteLine("Unable to find session.");
        AnsiConsole.WriteLine();
        return;
    }

    // TODO
    session.Stop();
}

void ListPublishedProviders(PublishedSort sort, bool json, bool unknown)
{
    var providers = (IEnumerable<(string Name, EtwProvider Provider)>)EtwProvider.GetPublishedProviders();

    if (unknown)
    {
        providers = providers.Where(p => !p.Provider.IsKnown);
    }

    var sortedProviders = sort switch
    {
        PublishedSort.Name => providers.OrderBy(s => s.Name).ThenBy(s => s.Provider.Id),
        PublishedSort.Id => providers.OrderBy(s => s.Provider.Id).ThenBy(s => s.Name),
        _ => providers,
    };

    if (!json)
    {
        var table = new Table().AddColumn("Name").AddColumn("ID");

        foreach (var (name, provider) in sortedProviders)
        {
            _ = table.AddRow(name, provider.Id.ToString());
        }

        AnsiConsole.WriteLine();
        AnsiConsole.Render(table);
        AnsiConsole.WriteLine();
    }
    else
    {
        AnsiConsole.WriteLine(JsonConvert.SerializeObject(sortedProviders.Select(t => new { t.Name, t.Provider.Id }), defaultJsonSettings));
        AnsiConsole.WriteLine();
    }
}

void ListRegisteredProvidersInProcess(uint pid, bool json)
{
    var processProviders = EtwProvider
        .GetRegisteredProviders()
        .Select(p => (p.Id, p.GetInstanceInfos().Where(i => i.ProcessId == pid)))
        .Where(t => t.Item2.Any())
        .ToDictionary(t => t.Id, t => t.Item2);

    if (!json)
    {
        foreach (var (providerId, instanceInfos) in processProviders)
        {
            Tree providerNode = default;

            foreach (var instance in instanceInfos)
            {
                TreeNode instanceNode = default;
                TreeNode enabledNode = default;

                foreach (var enable in instance.EnableInfos)
                {
                    if (instanceNode == null)
                    {
                        if (providerNode == null)
                        {
                            var provider = new EtwProvider(providerId);
                            providerNode = new Tree(provider.Name ?? provider.Id.ToString());
                        }

                        instanceNode = providerNode.AddNode($"Properties: {instance.Properties}");
                    }

                    enabledNode = instanceNode.AddNode("Enable parameters");
                    _ = enabledNode.AddNode($"Level: {enable.Level}");
                    _ = enabledNode.AddNode($"Properties: {enable.EnableProperty & EtwTraceProperties.All}");
                    _ = enabledNode.AddNode($"Match any: 0x{enable.MatchAnyKeyword:X16}");
                    _ = enabledNode.AddNode($"Match all: 0x{enable.MatchAllKeyword:X16}");
                }
            }

            if (providerNode != null)
            {
                AnsiConsole.WriteLine();
                AnsiConsole.Render(providerNode);
            }
        }

        AnsiConsole.WriteLine();
    }
    else
    {
        AnsiConsole.WriteLine(JsonConvert.SerializeObject(processProviders, defaultJsonSettings));
        AnsiConsole.WriteLine();
    }
}

static void SaveProvider(string provider)
{
    EtwProvider etwProvider = null;
    string name = null;

    if (Guid.TryParse(provider, out var providerGuid))
    {
        etwProvider = new EtwProvider(providerGuid);
        name = EtwProvider.GetPublishedProviders().SingleOrDefault(p => p.Provider.Id == providerGuid).Name;
    }
    else
    {
        etwProvider = EtwProvider.GetPublishedProviders().SingleOrDefault(p => p.Name == provider).Provider;
        name = provider;
    }

    if (etwProvider == null)
    {
        AnsiConsole.WriteLine();
        AnsiConsole.WriteLine("Cannot find provider.");
        AnsiConsole.WriteLine();
        return;
    }

    var eventInfos = etwProvider.GetEventInfos();
    Dictionary<string, EtwPropertyMapInfo> maps = new();

    static void GatherMaps(Dictionary<string, EtwPropertyMapInfo> maps, EtwProvider etwProvider, EtwEventInfo e, EtwPropertyInfo property)
    {
        if (property.MapName != null && !maps.TryGetValue(property.MapName, out var _))
        {
            maps[property.MapName] = etwProvider.GetPropertyMap(property.MapName);
        }
    }

    foreach (var e in eventInfos)
    {
        foreach (var p in e.Properties)
        {
            GatherMaps(maps, etwProvider, e, p);
        }
    }

    File.WriteAllText($"{name ?? etwProvider.Id.ToString()}.provider.json",
        JsonConvert.SerializeObject(new ProviderInformation
        {
            Id = etwProvider.Id,
            Name = name,
            Levels = etwProvider.GetLevelInfos(),
            Channels = etwProvider.GetChannelInfos(),
            Keywords = etwProvider.GetKeywordInfos(),
            Events = eventInfos,
            Maps = maps.Values

        },
        new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
            Converters = new[] { new StringEnumConverter() },
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            }
        }));
}

static void SaveManifestProvider(string manifest)
{
    var path = Path.GetDirectoryName(manifest);
    foreach (var file in Directory.GetFiles(string.IsNullOrEmpty(path) ? "." : path, Path.GetFileName(manifest)))
    {
        var etwManifest = EtwManifest.Parse(File.ReadAllText(file));
        var taskMap = etwManifest.Tasks.ToDictionary(t => t.Name, t => t.Value);
        var keywordMap = etwManifest.Keywords.ToDictionary(t => t.Name, t => t.Value);

        File.WriteAllText($"{etwManifest.Name ?? etwManifest.Id.ToString()}.provider.json.",
            JsonConvert.SerializeObject(new ProviderInformation
            {
                Id = Guid.Parse(etwManifest.Id),
                Name = etwManifest.Name,
                /* no levels */
                /* no channels */
                Tasks = etwManifest.Tasks,
                Keywords = etwManifest.Keywords,
                Opcodes = etwManifest.Opcodes.Select(kvp => new EtwProviderFieldInfo { Name = kvp.Key, Value = kvp.Value }),
                Events = etwManifest.Events.Select(kvp => new EtwEventInfo()
                {
                    ProviderId = new Guid(etwManifest.Id),
                    ProviderName = etwManifest.Name,
                    EventId = new Guid(),
                    Descriptor = new EtwEventDescriptor
                    {
                        Id = kvp.Value.Descriptor.Id,
                        Version = kvp.Value.Descriptor.Version,
                        Channel = kvp.Value.Descriptor.Channel,
                        Level = kvp.Value.Descriptor.Level != null ? kvp.Value.Descriptor.Level switch
                        {
                            "win:LogAlways" => EtwTraceLevel.None,
                            "win:Critical" => EtwTraceLevel.Critical,
                            "win:Error" => EtwTraceLevel.Error,
                            "win:Warning" => EtwTraceLevel.Warning,
                            "win:Informational" => EtwTraceLevel.Information,
                            "win:Verbose" => EtwTraceLevel.Verbose,
                            _ => throw new InvalidOperationException()
                        } : 0,
                        Opcode = kvp.Value.Descriptor.Opcode != null ? kvp.Value.Descriptor.Opcode switch
                        {
                            "win:Info" => EtwEventOpcode.Info,
                            "win:Start" => EtwEventOpcode.Start,
                            "win:End" => EtwEventOpcode.End,
                            "win:Stop" => EtwEventOpcode.Stop,
                            "win:Send" => EtwEventOpcode.Send,
                            "win:Receive" => EtwEventOpcode.Recieve,
                            _ => kvp.Value.Descriptor.Opcode.StartsWith("win:", StringComparison.Ordinal)
                                ? throw new InvalidOperationException()
                                : (EtwEventOpcode)etwManifest.Opcodes[kvp.Value.Descriptor.Opcode]
                        } : 0,
                        Task = kvp.Value.Descriptor.Task != null ? (ushort)taskMap[kvp.Value.Descriptor.Task] : (ushort)0,
                        Keyword = kvp.Value.Descriptor.Keyword != null
                            ? kvp.Value.Descriptor.Keyword.Split(" ").Aggregate((ulong)0, (s, k) => s + keywordMap[k])
                            : 0
                    },
                    LevelName = kvp.Value.Descriptor.Level,
                    OpcodeName = kvp.Value.Descriptor.Opcode,
                    TaskName = kvp.Value.Descriptor.Task,
                    KeywordName = kvp.Value.Descriptor.Keyword,
                    Name = kvp.Key,
                    Properties = kvp.Value.Template != null ? etwManifest.Templates[kvp.Value.Template].Fields.Select(t => new EtwPropertyInfo
                    {
                        Name = t.Name,
                        InputType = t.Datatype,
                        MapName = t.Map,
                        Count = new EtwPropertyInfo.PropertySize { Kind = EtwPropertyInfo.PropertySizeKind.Regular, Size = 1 },
                        Length = new EtwPropertyInfo.PropertySize { Kind = EtwPropertyInfo.PropertySizeKind.Regular, Size = Size(t.Datatype) == -1 ? (uint)0 : (uint)Size(t.Datatype) }
                    }).ToArray() : null
                }),
                Maps = etwManifest.Maps.Select(kvp => new EtwPropertyMapInfo { Name = kvp.Key, Flags = kvp.Value.Flags, Values = kvp.Value.Values })
            },
            new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                Converters = new[] { new StringEnumConverter() },
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            }));
    }
}

static string CreateProviderTasks(ProviderInformation provider)
{
    if (provider.Tasks == null || !provider.Tasks.Any())
    {
        return string.Empty;
    }

    StringBuilder builder = new();

    _ = builder.Append($@"

        /// <summary>
        /// Tasks supported by {provider.Name}.
        /// </summary>
        public enum Tasks : ushort
        {{");

    foreach (var task in provider.Tasks.OrderBy(t => t.Value))
    {
        _ = builder.Append($@"
            /// <summary>
            /// '{task.Description ?? task.Name}' task.
            /// </summary>
            {task.Name} = {task.Value},");
    }

    _ = builder.Append(@"
        }");

    return builder.ToString();
}

static string CreateProviderOpcodes(ProviderInformation provider)
{
    if (provider.Opcodes == null || !provider.Opcodes.Any())
    {
        return string.Empty;
    }

    StringBuilder builder = new();

    _ = builder.Append($@"

        /// <summary>
        /// Opcodes supported by {provider.Name}.
        /// </summary>
        public enum Opcodes
        {{");

    foreach (var opcode in provider.Opcodes.OrderBy(o => o.Value))
    {
        _ = builder.Append($@"
            /// <summary>
            /// '{opcode.Description ?? opcode.Name}' opcode.
            /// </summary>
            {opcode.Name} = {opcode.Value},");
    }

    _ = builder.Append(@"
        }");

    return builder.ToString();
}

static string CreateProviderKeywords(ProviderInformation provider)
{
    if (provider.Keywords == null || !provider.Keywords.Any())
    {
        return string.Empty;
    }

    StringBuilder builder = new();

    _ = builder.Append($@"

        /// <summary>
        /// Keywords supported by {provider.Name}.
        /// </summary>
        [Flags]
        public enum Keywords : ulong
        {{");

    foreach (var keyword in provider.Keywords.OrderBy(k => k.Value))
    {
        _ = builder.Append($@"
            /// <summary>
            /// '{keyword.Description ?? keyword.Name}' keyword.
            /// </summary>
            {keyword.Name} = 0x{keyword.Value:X16},");
    }

    _ = builder.Append(@"
        }");

    return builder.ToString();
}

static string CreateProviderMaps(ProviderInformation provider)
{
    if (provider.Maps == null || !provider.Maps.Any())
    {
        return string.Empty;
    }

    StringBuilder builder = new();

    foreach (var map in provider.Maps)
    {
        _ = builder.Append($@"

        /// <summary>
        /// {map.Name}.
        /// </summary>");
        if (map.Flags)
        {
            _ = builder.Append(@"
        [Flags]");
        }

        _ = builder.Append($@"
        public enum {map.Name}
        {{");

        foreach (var (enumValue, enumName) in map.Values)
        {
            _ = !map.Flags
                ? builder.Append($@"
            /// <summary>
            /// {enumName}.
            /// </summary>
            {enumName} = {(short)enumValue},")
                : builder.Append($@"
            /// <summary>
            /// {enumName}.
            /// </summary>
            {enumName} = 0x{(short)enumValue:X16},");
        }

        _ = builder.Append(@"
        }");
    }

    return builder.ToString();
}

static string CreateProviderStructs(ProviderInformation provider)
{
    if (provider.Events == null)
    {
        return string.Empty;
    }

    var structs = provider.Events.Where(e => e.Properties != null).SelectMany(e => e.Properties).Where(p => p.Properties != null);

    return !structs.Any() ? string.Empty : throw new NotImplementedException();
}

static string ConverterMethod(EtwPropertyInfo f, string location) =>
    @$"{(f.MapName == null ? string.Empty : $"({f.MapName})")}{f.InputType switch
    {
        EtwInputType.Uint8 => location,
        EtwInputType.Int8 => $"(sbyte){location}",
        EtwInputType.Boolean => $"{location} != 0",
        EtwInputType.Uint16 => $"BitConverter.ToUInt16({location})",
        EtwInputType.Int16 => $"BitConverter.ToInt16({location})",
        EtwInputType.Uint32 => $"BitConverter.ToUInt32({location})",
        EtwInputType.Int32 => $"BitConverter.ToInt32({location})",
        EtwInputType.Uint64 => $"BitConverter.ToUInt64({location})",
        EtwInputType.Int64 => $"BitConverter.ToInt64({location})",
        EtwInputType.UnicodeString => $"System.Text.Encoding.Unicode.GetString({location})",
        EtwInputType.AnsiString => $"System.Text.Encoding.ASCII.GetString({location})",
        EtwInputType.Pointer => $"_etwEvent.AddressSize == 4 ? BitConverter.ToUInt32({location}) : BitConverter.ToUInt64({location})",
        EtwInputType.Guid => $"new({location})",
        _ => "unknown"
    }}";

static string ReturnType(EtwPropertyInfo f) =>
    f.MapName ?? f.InputType switch
    {
        EtwInputType.Boolean => "bool",
        EtwInputType.Uint8 => "byte",
        EtwInputType.Int8 => "sbyte",
        EtwInputType.Uint16 => "ushort",
        EtwInputType.Int16 => "short",
        EtwInputType.Uint32 => "uint",
        EtwInputType.Int32 => "int",
        EtwInputType.Uint64 => "ulong",
        EtwInputType.Int64 => "long",
        EtwInputType.UnicodeString or EtwInputType.AnsiString => "string",
        EtwInputType.Guid => "Guid",
        EtwInputType.Pointer => "ulong",
        _ => "unknown"
    };

static string VariableSize(EtwInputType datatype, string offset) =>
    datatype switch
    {
        EtwInputType.Pointer => "etwEvent.AddressSize",
        EtwInputType.AnsiString => $"EtwEvent.AnsiStringEnumerable.AnsiStringEnumerator.StringLength(etwEvent.Data, {offset})",
        EtwInputType.UnicodeString => $"EtwEvent.UnicodeStringEnumerable.UnicodeStringEnumerator.StringLength(etwEvent.Data, {offset})",
        _ => "unknown"
    };

static int Size(EtwInputType datatype) =>
    datatype switch
    {
        EtwInputType.Boolean => 1,
        EtwInputType.Uint8 => 1,
        EtwInputType.Int8 => 1,
        EtwInputType.Uint16 => 2,
        EtwInputType.Int16 => 2,
        EtwInputType.Uint32 => 4,
        EtwInputType.Int32 => 4,
        EtwInputType.Uint64 => 8,
        EtwInputType.Int64 => 8,
        EtwInputType.Guid => 16,
        _ => -1
    };

static void CreateEventField(IReadOnlyList<EtwPropertyInfo> fields, int i, StringBuilder builder, Dictionary<EtwPropertyInfo, string> fieldOffsets)
{
    var field = fields[i];
    var name = field.Name;
    if (name.StartsWith('_'))
    {
        return;
    }

    var datatype = field.InputType;
    //var openBrace = datatype.IndexOf('[');
    var count = string.Empty;

    if (field.Length.Kind != EtwPropertyInfo.PropertySizeKind.Regular || field.Count.Kind != EtwPropertyInfo.PropertySizeKind.Regular)
    {
        throw new InvalidOperationException();
    }

    //if (openBrace != -1)
    //{
    //    count = datatype[(openBrace + 1)..^1];
    //    datatype = datatype[..openBrace];

    //    var location = $"_etwEvent.Data[{fieldOffsets[field]}..{(i + 1 < t.Fields.Count ? fieldOffsets[t.Fields[i + 1]] : string.Empty)}]";

    //    _ = builder.Append(datatype switch
    //    {
    //        EtwInputType.Pointer => $@"

    //            /// <summary>
    //            /// Retrieves the {name} field.
    //            /// </summary>
    //            public EtwEvent.AddressEnumerable {name} => new({location}, _etwEvent.AddressSize{(count == "..." ? string.Empty : $", {count}")});",
    //        EtwInputType.UnicodeString => $@"

    //            /// <summary>
    //            /// Retrieves the {name} field.
    //            /// </summary>
    //            public EtwEvent.UnicodeStringEnumerable {name} => new({location}{(count == "..." ? string.Empty : $", {count}")});",
    //        _ => $@"

    //            /// <summary>
    //            /// Retrieves the {name} field.
    //            /// </summary>
    //            public EtwEvent.StructEnumerable<{datatype}> {name} => new({location}{(count == "..." ? string.Empty : $", {count}")});"
    //    });
    //}
    //else
    {
        var location = $"_etwEvent.Data[{fieldOffsets[field]}{(Size(datatype) == 1 ? string.Empty : $"..{(i + 1 < fields.Count ? fieldOffsets[fields[i + 1]] : string.Empty)}")}]";
        _ = builder.Append($@"

                /// <summary>
                /// Retrieves the {name} field.
                /// </summary>
                public {ReturnType(field)} {name} => {ConverterMethod(field, location)};");
    }
}

static string CreateEventFields(IReadOnlyList<EtwPropertyInfo> fields, Dictionary<EtwPropertyInfo, string> fieldOffsets)
{
    if (fields == null || !fields.Any())
    {
        return string.Empty;
    }

    var builder = new StringBuilder();

    for (var i = 0; i < fields.Count; i++)
    {
        CreateEventField(fields, i, builder, fieldOffsets);
    }

    return builder.ToString();
}

static string CreateEventFieldOffsetInitializers(IReadOnlyList<EtwPropertyInfo> fields, Dictionary<EtwPropertyInfo, string> fieldOffsets)
{
    if (fields == null || !fields.Any())
    {
        return string.Empty;
    }

    var builder = new StringBuilder();
    var previousField = string.Empty;
    var previousSize = string.Empty;

    foreach (var f in fields)
    {
        var fieldName = fieldOffsets[f];

        if (fieldName.StartsWith('_'))
        {
            _ = builder.Append($@"
                    {fieldName} = {previousField} + {previousSize};");
        }

        var size = Size(f.InputType);
        previousSize = size == -1 ? VariableSize(f.InputType, fieldName) : size.ToString(CultureInfo.InvariantCulture);
        previousField = fieldName;
    }

    return builder.ToString();
}

static string CreateEventFieldOffsets(IReadOnlyList<EtwPropertyInfo> fields, Dictionary<EtwPropertyInfo, string> fieldOffsets)
{
    if (fields == null || !fields.Any())
    {
        return string.Empty;
    }

    var builder = new StringBuilder();
    var foundVariableField = false;
    var offset = 0;

    _ = builder.AppendLine();

    foreach (var f in fields)
    {
        if (!foundVariableField)
        {
            var fieldName = $"Offset_{f.Name}";
            fieldOffsets[f] = fieldName;

            _ = builder.Append(@$"
                private const int {fieldName} = {offset};");

            var size = Size(f.InputType);

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

static string CreateProviderEvents(ProviderInformation provider)
{
    if (provider.Events == null || !provider.Events.Any())
    {
        return string.Empty;
    }

    var builder = new StringBuilder();

    foreach (var e in provider.Events)
    {
        Dictionary<EtwPropertyInfo, string> fieldOffsets = new();

        _ = builder.Append($@"

        /// <summary>
        /// An event wrapper for a {e.Name} event.
        /// </summary>
        public readonly ref struct {e.Name}Event
        {{
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = ""{e.Name}"";

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
                Level = EtwTraceLevel.{e.Descriptor.Level},
                Opcode = {(Enum.IsDefined(typeof(EtwEventOpcode), e.Descriptor.Opcode) ? $"EtwEventOpcode.{e.Descriptor.Opcode}" : $"(EtwEventOpcode)Opcodes.{e.OpcodeName}")},
                Task = {(e.TaskName == null ? e.Descriptor.Task.ToString(CultureInfo.InvariantCulture) : $"(ushort)Tasks.{e.TaskName}")},
                Keyword = {(e.KeywordName == null ? e.Descriptor.Keyword.ToString(CultureInfo.InvariantCulture) : $"(ulong){(e.KeywordName.Contains(" ") ? "(" : string.Empty)}{e.KeywordName.Split(" ").Aggregate(string.Empty, (s, k) => $"{s}{(string.IsNullOrEmpty(s) ? string.Empty : " | ")}Keywords.{k}")}{(e.KeywordName.Contains(" ") ? ")" : string.Empty)}")}
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
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;{(e.Properties == null || e.Properties.Count == 0 ? string.Empty : $@"

            /// <summary>
            /// Data for the event.
            /// </summary>
            public {e.Name}Data Data => new(_etwEvent);")}

            /// <summary>
            /// Creates a new {e.Name}Event.
            /// </summary>
            /// <param name=""etwEvent"">The event.</param>
            public {e.Name}Event(EtwEvent etwEvent)
            {{
                _etwEvent = etwEvent;
            }}{(e.Properties == null || e.Properties.Count == 0 ? string.Empty : $@"

            /// <summary>
            /// A data wrapper for a {e.Name} event.
            /// </summary>
            public readonly ref struct {e.Name}Data
            {{
                private readonly EtwEvent _etwEvent;{CreateEventFieldOffsets(e.Properties, fieldOffsets)}{CreateEventFields(e.Properties, fieldOffsets)}

                /// <summary>
                /// Creates a new {e.Name}Data.
                /// </summary>
                /// <param name=""etwEvent"">The event.</param>
                public {e.Name}Data(EtwEvent etwEvent)
                {{
                    _etwEvent = etwEvent;{CreateEventFieldOffsetInitializers(e.Properties, fieldOffsets)}
                }}
            }}
")}
        }}");
    }

    return builder.ToString();
}

static void CreateProvider(ProviderInformation provider)
{
    var builder = new StringBuilder(@$"using System;

#pragma warning disable CA1707 // Identifiers should not contain underscores
#pragma warning disable CA1720 // Identifier contains type name

namespace EtwTools
{{
    /// <summary>
    /// Provider for {provider.Name} ({provider.Id})
    /// </summary>
    public sealed class {provider.ClassName}Provider
    {{
        /// <summary>s
        /// Provider ID.
        /// </summary>
        public static readonly Guid Id = new(""{provider.Id}"");

        /// <summary>
        /// Provider name.
        /// </summary>
        public const string Name = ""{provider.Name}"";{CreateProviderTasks(provider)}{CreateProviderOpcodes(provider)}{CreateProviderKeywords(provider)}{CreateProviderEvents(provider)}{CreateProviderMaps(provider)}{CreateProviderStructs(provider)}
    }}
}}
");

    File.WriteAllText($"{provider.ClassName}.cs", builder.ToString());
}

static void CreateMap(List<ProviderInformation> providers)
{
    var builder = new StringBuilder(@"using System;
using System.Collections.Generic;
namespace EtwTools
{
    public partial class EtwProvider
    {
        internal static readonly Dictionary<Guid, (string Name, Dictionary<EtwEventDescriptor, string> Events)> s_knownProviders = new()
        {");
    foreach (var provider in providers)
    {
        _ = builder.AppendLine(@$"
            {{ 
                {provider.ClassName}Provider.Id,
                (
                    {provider.ClassName}Provider.Name, new Dictionary<EtwEventDescriptor, string>
                    {{{provider.Events.Aggregate(new StringBuilder(), (s, e) => s.Append($@"
                        {{ {provider.ClassName}Provider.{e.Name}Event.Descriptor, {provider.ClassName}Provider.{e.Name}Event.Name }},"))}
                    }}
                )
            }},");
    }
    _ = builder.Append(@"        };
    }
}");
    File.WriteAllText("EtwProvider.generated.cs", builder.ToString());
}

static void GenerateProvider(string provider)
{
    List<ProviderInformation> providers = new();
    var path = Path.GetDirectoryName(provider);

    foreach (var file in Directory.GetFiles(string.IsNullOrEmpty(path) ? "." : path, Path.GetFileName(provider)))
    {
        var providerInformation = JsonConvert.DeserializeObject<ProviderInformation>(File.ReadAllText(file));
        CreateProvider(providerInformation);
        providers.Add(providerInformation);
    }

    CreateMap(providers);
}

void GetTraceInfo(string trace, bool json)
{
    using var logFile = new EtwTrace(trace);

    var totalEventCount = 0;
    Dictionary<(Guid, EtwEventDescriptor), (int Count, int Size)> eventCount = new();
    var stats = logFile.Open(null, e =>
    {
        totalEventCount++;
        _ = eventCount.TryGetValue((e.Provider, e.Descriptor), out var countSize);
        eventCount[(e.Provider, e.Descriptor)] = (countSize.Count + 1, countSize.Size + e.Data.Length);
    });

    logFile.Process();

    if (!json)
    {
        AnsiConsole.WriteLine();
        AnsiConsole.WriteLine($"OS Version: {stats.OsVersion}");
        AnsiConsole.WriteLine($"Architecture: {(stats.PointerSize == 4 ? "x86" : "x64")}");
        AnsiConsole.WriteLine($"Processor Count: {stats.ProcessorCount}");
        AnsiConsole.WriteLine($"CPU Speed: {stats.CpuSpeed}");
        AnsiConsole.WriteLine($"Boot Time: {stats.BootTime}");
        AnsiConsole.WriteLine($"Start Time: {stats.StartTime}");
        AnsiConsole.WriteLine($"End Time: {stats.EndTime}");
        AnsiConsole.WriteLine($"Maximum File Size: {stats.MaximumFileSize}");
        AnsiConsole.WriteLine($"Log File Mode: {stats.LogFileMode & EtwLogFileMode.All}{((stats.LogFileMode & ~EtwLogFileMode.All) != 0 ? $" | 0x{stats.LogFileMode & ~EtwLogFileMode.All}" : string.Empty)}");
        AnsiConsole.WriteLine($"Buffer Size: 0x{stats.BufferSize:X8}");
        AnsiConsole.WriteLine($"Buffers Written: {stats.BuffersWritten}");
        AnsiConsole.WriteLine($"Events Lost: {stats.EventsLost}");
        AnsiConsole.WriteLine($"Buffers Lost: {stats.BuffersLost}");
        AnsiConsole.WriteLine($"Timer Resolution: 0x{stats.TimerResolution:X8}");
        AnsiConsole.WriteLine($"Performance Counter Frequency: 0x{stats.PerfFrequency:X16}");
        AnsiConsole.WriteLine($"Clock Resolution: {stats.ClockResolution}");
        AnsiConsole.WriteLine($"Kernel Trace: {(stats.IsKernelTrace ? "yes" : "no")}");
        AnsiConsole.WriteLine();
        AnsiConsole.WriteLine($"Event Count: {totalEventCount}");

        var table = new Table().AddColumn("ID").AddColumn("Event").AddColumn("Count").AddColumn("Size");

        foreach (var kvp in eventCount.OrderByDescending(kvp => kvp.Value))
        {
            var provider = new EtwProvider(kvp.Key.Item1);

            _ = table.AddRow(
                provider.Name ?? provider.Id.ToString(),
                EtwEvent.GetKnownEventName(kvp.Key.Item1, kvp.Key.Item2) ?? kvp.Key.Item2.ToString(),
                kvp.Value.Count.ToString(CultureInfo.InvariantCulture),
                kvp.Value.Size.ToString(CultureInfo.InvariantCulture));
        }

        AnsiConsole.Render(table);
    }
    else
    {
        AnsiConsole.WriteLine(JsonConvert.SerializeObject(new
        {
            Stats = stats,
            EventCount = totalEventCount,
            Events = eventCount.OrderByDescending(kvp => kvp.Value).Select(kvp =>
            {
                var provider = new EtwProvider(kvp.Key.Item1);
                return new { provider.Name, provider.Id, Event = kvp.Key.Item2, Count = kvp.Value };
            })
        }, defaultJsonSettings));
        AnsiConsole.WriteLine();

    }
}

static void SaveTraceLoggingProviders(string trace)
{
    using var logFile = new EtwTrace(trace);

    Dictionary<Guid, Dictionary<EtwEventDescriptor, EtwEventInfo>> events = new();
    var stats = logFile.Open(null, e =>
    {
        if (!e.HasTraceLoggingEventSchema())
        {
            return;
        }

        if (!events.TryGetValue(e.Provider, out var providerEvents))
        {
            events[e.Provider] = providerEvents = new();
        }

        if (providerEvents.TryGetValue(e.Descriptor, out var eventInfo))
        {
            return;
        }

        if (!e.TryGetEventInfo(out eventInfo))
        {
            return;
        }

        providerEvents[e.Descriptor] = eventInfo;
    });

    logFile.Process();

    foreach (var (provider, providerEvents) in events)
    {
        File.WriteAllText($"{provider}.provider.json",
            JsonConvert.SerializeObject(new ProviderInformation
            {
                Id = provider,
                Events = providerEvents.Values

            },
            new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                Converters = new[] { new StringEnumConverter() },
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            }));
    }
}

static void SaveEventSourceProviders(string trace, bool all)
{
    using var logFile = new EtwTrace(trace);

    EtwEventSourceManifestCollector collector = new();
    var stats = logFile.Open(null, e =>
    {
        if (EtwEventSourceManifestCollector.IsEventSourceManifestEvent(ref e))
        {
            _ = collector.ProcessEventSourceManifestEvent(ref e);
        }
    });
    logFile.Process();

    if (all)
    {
        foreach (var (provider, pid, tid, manifest) in collector.GetCompletedManifests())
        {
            File.WriteAllText($"{provider}.{pid}.{tid}.xml", manifest);
        }
    }
    else
    {
        Dictionary<Guid, string> manifests = new();
        foreach (var (provider, pid, tid, manifest) in collector.GetCompletedManifests())
        {
            if (manifests.TryGetValue(provider, out var currentManifest) &&
                currentManifest.Length >= manifest.Length)
            {
                continue;
            }

            manifests[provider] = manifest;
        }

        foreach (var kvp in manifests)
        {
            File.WriteAllText($"{kvp.Key}.xml", kvp.Value);
        }
    }
}

return await rootCommand.InvokeAsync(args);

internal enum PublishedSort
{
    Name,
    Id
}

internal enum RegisteredSort
{
    Id,
    Count
}

internal readonly struct EventInformation
{
    public IReadOnlyList<EtwEventInfo> Events { get; init; }
    public IReadOnlyDictionary<string, EtwPropertyMapInfo> Maps { get; init; }
}

internal sealed record ProviderInformation
{
    public Guid Id { get; init; }

    public string Name { get; init; }

    public string ClassName { get; init; }

    public IEnumerable<EtwProviderFieldInfo> Levels { get; init; }

    public IEnumerable<EtwProviderFieldInfo> Channels { get; init; }

    public IEnumerable<EtwProviderFieldInfo> Keywords { get; init; }

    public IEnumerable<EtwProviderFieldInfo> Tasks { get; init; }

    public IEnumerable<EtwProviderFieldInfo> Opcodes { get; init; }

    public IEnumerable<EtwEventInfo> Events { get; init; }

    public IEnumerable<EtwPropertyMapInfo> Maps { get; init; }
}
