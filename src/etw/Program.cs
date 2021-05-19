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

void AddProviderCommands(Command providersCommand)
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

    var publishedCommand = new Command("published", "Gets information about a registered provider.")
    {
        new Argument<string>("provider", "The provider ID."),
        new Option<string>(new[] { "-a", "--add" }, "Add to a provider directory.")
    };
    publishedCommand.Handler = CommandHandler.Create<string, string>(GetPublishedProvider);
    providersCommand.AddCommand(publishedCommand);

    var manifestCommand = new Command("manifest", "Gets provider information from a manifest.")
    {
        new Argument<string>("manifest", "The manifest path."),
        new Option<string>(new[] { "-a", "--add" }, "Add to a provider directory.")
    };
    manifestCommand.Handler = CommandHandler.Create<string, string>(GetManifestProvider);
    providersCommand.AddCommand(manifestCommand);

    var generateCommand = new Command("generate", "Generates provider classes from a provider directory.")
    {
        new Argument<string>("providers", "The provider directory.")
    };
    generateCommand.Handler = CommandHandler.Create<string>(GenerateProviders);
    providersCommand.AddCommand(generateCommand);
}

var providerCommand = new Command("provider", "Commands that work on event providers.");
rootCommand.Add(providerCommand);
AddProviderCommands(providerCommand);

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
        new Argument<string>("trace", "The trace file."),
        new Option<string>(new[] { "-a", "--add" }, "Add to a provider directory.")
    };
    traceLoggingCommand.Handler = CommandHandler.Create<string, string>(SaveTraceLoggingProviders);
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

string GetDatatype(EtwPropertyInfo p, Dictionary<string, Struct> providerStructs, ref int structId)
{
    var datatype = p.InputType switch
    {
        EtwInputType.Boolean => "bool",
        EtwInputType.Uint8 or EtwInputType.Binary => "byte",
        EtwInputType.Int8 => "sbyte",
        EtwInputType.Uint16 => "ushort",
        EtwInputType.Int16 => "short",
        EtwInputType.Uint32 => "uint",
        EtwInputType.Int32 => "int",
        EtwInputType.Uint64 => "ulong",
        EtwInputType.Int64 => "long",
        EtwInputType.Double => "double",
        EtwInputType.UnicodeString => "string",
        EtwInputType.AnsiString => "ansistring",
        EtwInputType.UnicodeChar => "char",
        EtwInputType.Guid => "guid",
        EtwInputType.Pointer => "pointer",
        EtwInputType.SizeT => "pointer",
        _ => "unknown"
    };

    if (p.Properties != null)
    {
        if (datatype is not "unknown")
        {
            throw new InvalidOperationException();
        }

        var name = $"Struct{structId++}";
        var fields = new List<Field>();

        foreach (var inner in p.Properties)
        {
            fields.Add(new Field { Name = inner.Name, Datatype = GetDatatype(inner, providerStructs, ref structId), Map = inner.MapName });
        }

        providerStructs[name] = new Struct { Name = name, Fields = fields };
        datatype = name;
    }
    else if (datatype is "unknown")
    {
        throw new InvalidOperationException();
    }

    string count = null;

    if (p.Length is string propertyLength)
    {
        count = propertyLength;
    }

    switch (p.Count)
    {
        case int actualCount:
            if (actualCount != 1)
            {
                throw new InvalidOperationException();
            }
            break;

        case string propertyCount:
            count = propertyCount;
            break;
    }

    return $"{datatype}{(count != null ? $"[{count}]" : string.Empty)}";
}

void AddProvider(string directory, Guid id, string name, bool isPublished, IEnumerable<EtwProviderFieldInfo> levels, IEnumerable<EtwProviderFieldInfo> channels, IEnumerable<EtwProviderFieldInfo> tasks, IEnumerable<EtwProviderFieldInfo> keywords, IEnumerable<EtwProviderFieldInfo> opcodes, IEnumerable<EtwEventInfo> events, IEnumerable<EtwPropertyMapInfo> maps)
{
    var filename = Path.Combine(directory, $"{id}.provider.json");
    var structId = 0;

    string displayName;
    Dictionary<EtwEventDescriptor, Event> providerEvents;
    Dictionary<ulong, string> providerTasks;
    Dictionary<ulong, string> providerOpcodes;
    Dictionary<ulong, string> providerKeywords;
    Dictionary<string, Map> providerMaps;
    Dictionary<string, Struct> providerStructs;

    if (File.Exists(filename))
    {
        var provider = JsonConvert.DeserializeObject<Provider>(File.ReadAllText(filename));

        name = provider.Name;
        displayName = provider.DisplayName;
        providerEvents = provider.Events.ToDictionary(e => e.Descriptor, e => e);
        providerTasks = new(provider.Tasks);
        providerOpcodes = new(provider.Opcodes);
        providerKeywords = new(provider.Keywords);
        providerMaps = provider.Maps.ToDictionary(m => m.Name, m => m);
        providerStructs = provider.Structs.ToDictionary(s => s.Name, s => s);
    }
    else
    {
        displayName = name;
        providerEvents = new();
        providerTasks = new();
        providerOpcodes = new();
        providerKeywords = new();
        providerMaps = new();
        providerStructs = new();
    }

    foreach (var e in events)
    {
        if (providerEvents.ContainsKey(e.Descriptor))
        {
            continue;
        }

        //if (e.Descriptor.Version > 0)
        //{
        //    var found = false;
        //    for (var i = e.Descriptor.Version; i < 0xFF; i--)
        //    {
        //        if (providerEvents.ContainsKey(new EtwEventDescriptor
        //        {
        //            Id = e.Descriptor.Id,
        //            Version = i,
        //            Channel = e.Descriptor.Channel,
        //            Level = e.Descriptor.Level,
        //            Opcode = e.Descriptor.Opcode,
        //            Task = e.Descriptor.Task,
        //            Keyword = e.Descriptor.Keyword
        //        }))
        //        {
        //            found = true;
        //        }
        //    }

        //    if (found)
        //    {
        //        break;
        //    }
        //}

        var opcodeName = e.OpcodeName == null ? null : (e.OpcodeName.StartsWith("win:", StringComparison.Ordinal) ? e.OpcodeName[4..] : e.OpcodeName);
        var eventName = (!isPublished && e.Name != null) ? e.Name : $"{e.TaskName ?? string.Empty}{(e.TaskName != null && e.TaskName.EndsWith(opcodeName, StringComparison.Ordinal) ? string.Empty : opcodeName)}";

        providerEvents[e.Descriptor] = new Event
        {
            Name = eventName,
            DisplayName = eventName,
            Descriptor = e.Descriptor,
            Fields = e.Properties?.Select(p => new Field { Name = p.Name, Datatype = GetDatatype(p, providerStructs, ref structId), Map = p.MapName }),
        };
    }

    if (tasks != null)
    {
        foreach (var t in tasks)
        {
            if (providerTasks.ContainsKey(t.Value))
            {
                continue;
            }

            providerTasks[t.Value] = t.Name;
        }
    }

    if (opcodes != null)
    {
        foreach (var o in opcodes)
        {
            if (providerOpcodes.ContainsKey(o.Value))
            {
                continue;
            }

            providerOpcodes[o.Value] = o.Name;
        }
    }

    if (keywords != null)
    {
        foreach (var k in keywords)
        {
            if (providerKeywords.ContainsKey(k.Value))
            {
                continue;
            }

            providerKeywords[k.Value] = k.Name;
        }
    }

    if (maps != null)
    {
        foreach (var m in maps)
        {
            if (providerMaps.ContainsKey(m.Name))
            {
                continue;
            }

            providerMaps[m.Name] = new Map { Name = m.Name, Flags = m.Flags, Values = m.Values.ToDictionary(kvp => kvp.Key, kvp => kvp.Value) };
        }
    }

    File.WriteAllText(filename, JsonConvert.SerializeObject(new Provider
    {
        Name = name,
        DisplayName = displayName,
        Id = id,
        Events = providerEvents.Values,
        Tasks = providerTasks,
        Opcodes = providerOpcodes,
        Keywords = providerKeywords,
        Maps = providerMaps.Values,
        Structs = providerStructs.Values
    }, defaultJsonSettings));
}

void GetPublishedProvider(string provider, string add)
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
    Dictionary<string, EtwPropertyMapInfo> mapsMap = new();
    Dictionary<ulong, EtwProviderFieldInfo> opcodesMap = new();
    Dictionary<ulong, EtwProviderFieldInfo> tasksMap = new();

    static void GatherMaps(Dictionary<string, EtwPropertyMapInfo> maps, EtwProvider etwProvider, EtwEventInfo e, EtwPropertyInfo property)
    {
        if (property.MapName != null && !maps.TryGetValue(property.MapName, out var _))
        {
            maps[property.MapName] = etwProvider.GetPropertyMap(property.MapName);
        }

        if (property.Properties != null)
        {
            foreach (var innerProperty in property.Properties)
            {
                GatherMaps(maps, etwProvider, e, innerProperty);
            }
        }
    }

    foreach (var e in eventInfos)
    {
        if (!Enum.IsDefined(e.Descriptor.Opcode) && !string.IsNullOrEmpty(e.OpcodeName) && !opcodesMap.ContainsKey((ulong)e.Descriptor.Opcode))
        {
            opcodesMap[(ulong)e.Descriptor.Opcode] = new EtwProviderFieldInfo { Name = e.OpcodeName, Value = (ulong)e.Descriptor.Opcode };
        }

        if (!string.IsNullOrEmpty(e.TaskName) && !tasksMap.ContainsKey(e.Descriptor.Task))
        {
            tasksMap[e.Descriptor.Task] = new EtwProviderFieldInfo { Name = e.TaskName, Value = e.Descriptor.Task };
        }

        foreach (var p in e.Properties)
        {
            GatherMaps(mapsMap, etwProvider, e, p);
        }
    }

    var maps = mapsMap.Values.OrderBy(m => m.Name);
    var opcodes = opcodesMap.Values.OrderBy(o => o.Value);
    var tasks = tasksMap.Values.OrderBy(t => t.Value);

    if (add != null)
    {
        AddProvider(add, etwProvider.Id, name, true, etwProvider.GetLevelInfos(), etwProvider.GetChannelInfos(), tasks, etwProvider.GetKeywordInfos(), opcodes, eventInfos, maps);
    }
    else
    {
        Console.WriteLine(JsonConvert.SerializeObject(new
        {
            etwProvider.Id,
            Name = name,
            Levels = etwProvider.GetLevelInfos(),
            Channels = etwProvider.GetChannelInfos(),
            Keywords = etwProvider.GetKeywordInfos(),
            Opcodes = opcodes,
            Tasks = tasks,
            Events = eventInfos,
            Maps = maps

        }, defaultJsonSettings));
    }
}

void GetManifestProvider(string manifest, string add)
{
    var etwManifest = EtwManifest.Parse(File.ReadAllText(manifest));
    var taskMap = etwManifest.Tasks.ToDictionary(t => t.Name, t => t.Value);
    var keywordMap = etwManifest.Keywords.ToDictionary(t => t.Name, t => t.Value);

    var id = Guid.Parse(etwManifest.Id);
    var opcodes = etwManifest.Opcodes.Select(kvp => new EtwProviderFieldInfo { Name = kvp.Key, Value = kvp.Value });

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

    var events = etwManifest.Events.Select(kvp => new EtwEventInfo()
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
            Count = 1,
            Length = Size(t.Datatype) == -1 ? 0 : (uint)Size(t.Datatype)
        }).ToArray() : null
    });
    var maps = etwManifest.Maps.Select(kvp => new EtwPropertyMapInfo { Name = kvp.Key, Flags = kvp.Value.Flags, Values = kvp.Value.Values });

    if (add != null)
    {
        AddProvider(add, id, etwManifest.Name, false, null, null, etwManifest.Tasks, etwManifest.Keywords, opcodes, events, maps);
    }
    else
    {
        Console.WriteLine(JsonConvert.SerializeObject(new
        {
            Id = id,
            etwManifest.Name,
            /* no levels */
            /* no channels */
            etwManifest.Tasks,
            etwManifest.Keywords,
            Opcodes = opcodes,
            Events = events,
            Maps = maps
        }, defaultJsonSettings));
    }
}

static string CreateProviderTasks(Provider provider)
{
    if (provider.Tasks == null || !provider.Tasks.Any())
    {
        return string.Empty;
    }

    StringBuilder builder = new();

    _ = builder.Append($@"

        /// <summary>
        /// Tasks supported by {provider.DisplayName}.
        /// </summary>
        public enum Tasks : ushort
        {{");

    foreach (var task in provider.Tasks.OrderBy(t => t.Key))
    {
        _ = builder.Append($@"
            /// <summary>
            /// '{task.Value}' task.
            /// </summary>
            {task.Value} = {task.Key},");
    }

    _ = builder.Append(@"
        }");

    return builder.ToString();
}

static string CreateProviderOpcodes(Provider provider)
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

    foreach (var opcode in provider.Opcodes.OrderBy(o => o.Key))
    {
        _ = builder.Append($@"
            /// <summary>
            /// '{opcode.Value}' opcode.
            /// </summary>
            {opcode.Value} = {opcode.Key},");
    }

    _ = builder.Append(@"
        }");

    return builder.ToString();
}

static string CreateProviderKeywords(Provider provider)
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

    foreach (var keyword in provider.Keywords.OrderBy(k => k.Key))
    {
        _ = builder.Append($@"
            /// <summary>
            /// '{keyword.Value}' keyword.
            /// </summary>
            {keyword.Value} = 0x{keyword.Key:X16},");
    }

    _ = builder.Append(@"
        }");

    return builder.ToString();
}

static string CreateProviderMaps(Provider provider)
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
        public enum {map.Name} : ulong
        {{");

        foreach (var (enumValue, enumName) in map.Values)
        {
            _ = !map.Flags
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

static string CreateProviderStructs(Provider provider, Dictionary<string, Struct> structs)
{
    if (provider.Structs == null || !provider.Structs.Any())
    {
        return string.Empty;
    }

    var builder = new StringBuilder();

    foreach (var s in provider.Structs)
    {
        var fields = s.Fields.ToList();
        _ = builder.Append($@"

        /// <summary>
        /// A data wrapper for a {s.Name} structure.
        /// </summary>
        public ref struct {s.Name}
        {{
            private readonly EtwEvent _etwEvent;
            private readonly int _offset;{CreateEventPropertyOffsetFields(3, true, s.Fields, structs)}{CreateEventPropertyOffsetProperties(3, true, fields, structs)}{CreateEventFields(3, fields, structs)}

            /// <summary>
            /// Creates a new {s.Name}.
            /// </summary>
            public {s.Name}(EtwEvent e, int offset)
            {{
                _etwEvent = e;
                _offset = offset;{CreateEventFieldOffsetInitializers(3, true, fields, structs)}
            }}
        }}

        /// <summary>
        /// A structure that can enumerate {s.Name} structures.
        /// </summary>
        public ref struct {s.Name}Enumerable
        {{
            private readonly EtwEvent _etwEvent;
            private readonly int _offset;
            private readonly uint _count;

            internal {s.Name}Enumerable(EtwEvent e, int offset) :
                this(e, offset, uint.MaxValue)
            {{
            }}

            internal {s.Name}Enumerable(EtwEvent e, int offset, uint count)
            {{
                _etwEvent = e;
                _offset = offset;
                _count = count;
            }}

            /// <summary>
            /// Gets an enumerator.
            /// </summary>
            /// <returns>The enumerator.</returns>
            public {s.Name}Enumerator GetEnumerator() => new(this);

            /// <summary>
            /// A structure that enumerates over an {s.Name} collection.
            /// </summary>
            public ref struct {s.Name}Enumerator
            {{
                private readonly {s.Name}Enumerable _enumerable;
                private int _offset;
                private int _index;

                /// <summary>
                /// The current value, if any.
                /// </summary>
                public {s.Name} Current => ((_offset < _enumerable._etwEvent.Data.Length) && (_index <= _enumerable._count))
                    ? new(_enumerable._etwEvent, _offset)
                    : throw new InvalidOperationException();

                internal {s.Name}Enumerator({s.Name}Enumerable enumerable)
                {{
                    _enumerable = enumerable;
                    _offset = int.MaxValue;
                    _index = 0;
                }}

                /// <summary>
                /// Moves to the next address.
                /// </summary>
                /// <returns>Whether there is another address.</returns>
                public bool MoveNext()
                {{
                    if (_offset == int.MaxValue)
                    {{
                        _offset = _enumerable._offset;
                        _index = 1;
                        return true;
                    }}

                    _offset += Current.StructSize;
                    _index++;
                    return (_offset < _enumerable._etwEvent.Data.Length) && (_index <= _enumerable._count);
                }}
            }}
        }}
");
    }

    return builder.ToString();
}

static string ConverterMethod(Field f, string location, Dictionary<string, Struct> structs) =>
    $@"{(f.Map == null ? string.Empty : $"({f.Map})")}{f.Datatype switch
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
        "char" => $"BitConverter.ToChar({location})",
        "double" => $"BitConverter.ToDouble({location})",
        "string" => $"System.Text.Encoding.Unicode.GetString({location})",
        "ansistring" => $"System.Text.Encoding.ASCII.GetString({location})",
        "pointer" => $"_etwEvent.AddressSize == 4 ? BitConverter.ToUInt32({location}) : BitConverter.ToUInt64({location})",
        "guid" => $"new({location})",
        _ => "unknown",
    }}";

static string ReturnType(Field f) =>
    f.Map ?? f.Datatype switch
    {
        "bool" or "byte" or "sbyte" or "ushort" or "short" or "uint" or "int" or "ulong" or "long" or "char" => f.Datatype,
        "string" or "ansistring" => "string",
        "guid" => "Guid",
        "pointer" => "ulong",
        _ => f.Datatype
    };

static string VariableSize(string type, string offset, Dictionary<string, Struct> structs)
{
    string count = null;
    var leftBracket = type.IndexOf('[', StringComparison.Ordinal);

    if (leftBracket != -1)
    {
        count = type[(leftBracket + 1)..(type.Length - 1)];
        type = type[..leftBracket];
    }

    if (count != null)
    {
        var size = Size(type, structs);
        return size != -1 ? $"({size} * (int){count})" : "unknown";
    }
    else
    {
        return type switch
        {
            "pointer" => "_etwEvent.AddressSize",
            "ansistring" => $"EtwEvent.AnsiStringEnumerable.AnsiStringEnumerator.StringLength(_etwEvent.Data, {offset})",
            "string" => $"EtwEvent.UnicodeStringEnumerable.UnicodeStringEnumerator.StringLength(_etwEvent.Data, {offset})",
            _ => "unknown"
        };
    }
}

static int Size(string type, Dictionary<string, Struct> structs)
{
    if (type.IndexOf('[', StringComparison.Ordinal) != -1)
    {
        return -1;
    }

    switch (type)
    {
        case "bool" or "byte" or "sbyte":
            return 1;

        case "ushort" or "short" or "char":
            return 2;

        case "uint" or "int":
            return 4;

        case "ulong" or "long" or "double":
            return 8;

        case "guid":
            return 16;
    }

    if (structs.TryGetValue(type, out var s))
    {
        var size = 0;
        foreach (var f in s.Fields)
        {
            var fieldSize = Size(f.Datatype, structs);

            if (fieldSize != -1)
            {
                size += fieldSize;
            }
            else
            {
                return -1;
            }
        }

        return size;
    }

    return -1;
}

static void CreateEventField(int indent, IReadOnlyList<Field> fields, int i, StringBuilder builder, Dictionary<string, Struct> structs)
{
    var field = fields[i];
    var nextField = i + 1 < fields.Count ? fields[i + 1] : null;
    var indentString = new string(' ', indent * 4);
    var name = field.Name;
    if (name.StartsWith('_'))
    {
        return;
    }

    var type = field.Datatype;
    string count = null;
    var leftBracket = type.IndexOf('[', StringComparison.Ordinal);

    if (leftBracket != -1)
    {
        count = type[(leftBracket + 1)..(type.Length - 1)];
        type = type[..leftBracket];
    }

    var fieldOffsetName = $"Offset_{field.Name}";

    if (count != null)
    {
        _ = builder.Append(type switch
        {
            "pointer" => $@"

{indentString}/// <summary>
{indentString}/// Retrieves the {name} field.
{indentString}/// </summary>
{indentString}public EtwEvent.AddressEnumerable {name} => new(_etwEvent, {fieldOffsetName}{(count == "..." ? string.Empty : $", {count}")});",
            "string" => $@"

{indentString}/// <summary>
{indentString}/// Retrieves the {name} field.
{indentString}/// </summary>
{indentString}public EtwEvent.UnicodeStringEnumerable {name} => new(_etwEvent, {fieldOffsetName}{(count == "..." ? string.Empty : $", {count}")});",
            "bool" or "byte" or "sbyte" or "ushort" or "short" or "char" or "uint" or "int" or "ulong" or "long" or "double" or "guid" => $@"

{indentString}/// <summary>
{indentString}/// Retrieves the {name} field.
{indentString}/// </summary>
{indentString}public EtwEvent.StructEnumerable<{type}> {name} => new(_etwEvent, {fieldOffsetName}{(count == "..." ? string.Empty : $", {count}")});",
            _ => $@"

{indentString}/// <summary>
{indentString}/// Retrieves the {name} field.
{indentString}/// </summary>
{indentString}public {type}Enumerable {name} => new(_etwEvent, {fieldOffsetName}{(count == "..." ? string.Empty : $", {count}")});"
        });
    }
    else
    {
        var location = $"_etwEvent.Data[{fieldOffsetName}{(Size(type, structs) == 1 ? string.Empty : $"..")}]";
        _ = builder.Append($@"

{indentString}/// <summary>
{indentString}/// Retrieves the {name} field.
{indentString}/// </summary>
{indentString}public {ReturnType(field)} {name} => {ConverterMethod(field, location, structs)};");
    }
}

static string CreateEventFields(int indent, IReadOnlyList<Field> fields, Dictionary<string, Struct> structs)
{
    if (fields == null || !fields.Any())
    {
        return string.Empty;
    }

    var builder = new StringBuilder();

    for (var i = 0; i < fields.Count; i++)
    {
        CreateEventField(indent, fields, i, builder, structs);
    }

    return builder.ToString();
}

static string CreateEventFieldOffsetInitializers(int indent, bool isStruct, IReadOnlyList<Field> fields, Dictionary<string, Struct> structs)
{
    if (fields == null || !fields.Any())
    {
        return string.Empty;
    }

    var builder = new StringBuilder();
    var indentString = new string(' ', indent * 4);

    foreach (var f in fields)
    {
        _ = builder.Append($@"
{indentString}    _offset_{f.Name} = -1;");
    }

    if (isStruct)
    {
        _ = builder.Append($@"
{indentString}    _structSize = -1;");
    }

    return builder.ToString();
}

static string CreateEventPropertyOffsetProperties(int indent, bool isStruct, IReadOnlyList<Field> fields, Dictionary<string, Struct> structs)
{
    if (fields == null || !fields.Any())
    {
        return string.Empty;
    }

    var builder = new StringBuilder();
    var previousFieldOffset = isStruct ? "_offset" : null;
    string previousFieldSize = null;
    var indentString = new string(' ', indent * 4);

    foreach (var f in fields)
    {
        _ = builder.Append($@"

{indentString}private int Offset_{f.Name}
{indentString}{{
{indentString}    get
{indentString}    {{
{indentString}        if (_offset_{f.Name} == -1)
{indentString}        {{
{indentString}            _offset_{f.Name} = {(previousFieldOffset == null ? string.Empty : $"{previousFieldOffset} + ")}{previousFieldSize ?? "0"};
{indentString}        }}

{indentString}        return _offset_{f.Name};
{indentString}    }}
{indentString}}}");

        var size = Size(f.Datatype, structs);
        previousFieldOffset = $"Offset_{f.Name}";
        previousFieldSize = size == -1 ? VariableSize(f.Datatype, previousFieldOffset, structs) : size.ToString(CultureInfo.InvariantCulture);
    }

    if (isStruct)
    {
        _ = builder.Append($@"

{indentString}/// <summary>
{indentString}/// Size of the structure.
{indentString}/// </summary>
{indentString}public int StructSize
{indentString}{{
{indentString}    get
{indentString}    {{
{indentString}        if (_structSize == -1)
{indentString}        {{
{indentString}            _structSize = {(previousFieldOffset == null ? string.Empty : $"{previousFieldOffset} + ")}{previousFieldSize ?? "0"};
{indentString}        }}

{indentString}        return _structSize;
{indentString}    }}
{indentString}}}");
    }

    return builder.ToString();
}

static string CreateEventPropertyOffsetFields(int indent, bool isStruct, IEnumerable<Field> fields, Dictionary<string, Struct> structs)
{
    var builder = new StringBuilder();
    var indentString = new string(' ', indent * 4);

    _ = builder.AppendLine();

    foreach (var f in fields)
    {
        _ = builder.Append($@"
{indentString}private int _offset_{f.Name};");
    }

    if (isStruct)
    {
        _ = builder.Append($@"
{indentString}private int _structSize;");
    }

    return builder.ToString();
}

static string EventName(Event e) => $"{e.Name}Event{(e.Descriptor.Version > 0 ? $"V{e.Descriptor.Version}" : string.Empty)}";

static string CreateProviderEvents(Provider provider, Dictionary<string, Struct> structs)
{
    if (provider.Events == null || !provider.Events.Any())
    {
        return string.Empty;
    }

    var builder = new StringBuilder();

    foreach (var e in provider.Events)
    {
        var fields = e.Fields?.ToList();

        _ = builder.Append($@"

        /// <summary>
        /// An event wrapper for a {e.DisplayName} event.
        /// </summary>
        public readonly ref struct {EventName(e)}
        {{
            private readonly EtwEvent _etwEvent;

            /// <summary>
            /// Event name.
            /// </summary>
            public const string Name = ""{e.DisplayName}"";

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
                Opcode = {(provider.Opcodes.TryGetValue((ulong)e.Descriptor.Opcode, out var opcodeName) ? $"(EtwEventOpcode)Opcodes.{opcodeName}" : $"EtwEventOpcode.{e.Descriptor.Opcode}")},
                Task = {(provider.Tasks.TryGetValue(e.Descriptor.Task, out var taskName) ? $"(ushort)Tasks.{taskName}" : e.Descriptor.Task.ToString(CultureInfo.InvariantCulture))},
                Keyword = {(e.Descriptor.Keyword == 0
                    ? "0"
                    : Enumerable.Range(0, 63).Aggregate(string.Empty, (v, k) => (e.Descriptor.Keyword & (1ul << k)) == 0 ? v : $"{(string.IsNullOrEmpty(v) ? v : $"{v} | ")}{(provider.Keywords.TryGetValue(1ul << k, out var keywordName) ? $"(ulong)Keywords.{keywordName}" : $"(ulong)0x{2ul << k:X}")}"))}
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
            public (ulong? KernelTime, ulong? UserTime, ulong? ProcessorTime) Time => _etwEvent.Time;{(e.Fields == null || !e.Fields.Any() ? string.Empty : $@"

            /// <summary>
            /// Data for the event.
            /// </summary>
            public {e.Name}Data Data => new(_etwEvent);")}

            /// <summary>
            /// Creates a new {EventName(e)}.
            /// </summary>
            /// <param name=""etwEvent"">The event.</param>
            public {EventName(e)}(EtwEvent etwEvent)
            {{
                _etwEvent = etwEvent;
            }}{(e.Fields == null || !e.Fields.Any() ? string.Empty : $@"

            /// <summary>
            /// A data wrapper for a {e.Name} event.
            /// </summary>
            public ref struct {e.Name}Data
            {{
                private readonly EtwEvent _etwEvent;{CreateEventPropertyOffsetFields(4, false, fields, structs)}{CreateEventPropertyOffsetProperties(4, false, fields, structs)}{CreateEventFields(4, fields, structs)}

                /// <summary>
                /// Creates a new {e.Name}Data.
                /// </summary>
                /// <param name=""etwEvent"">The event.</param>
                public {e.Name}Data(EtwEvent etwEvent)
                {{
                    _etwEvent = etwEvent;{CreateEventFieldOffsetInitializers(4, false, fields, structs)}
                }}
            }}
")}
        }}");
    }

    return builder.ToString();
}

static void CreateProvider(Provider provider)
{
    var structs = provider.Structs.ToDictionary(s => s.Name, s => s);

    var builder = new StringBuilder(@$"using System;

#pragma warning disable IDE0004 // Remove Unnecessary Cast
#pragma warning disable CA1707 // Identifiers should not contain underscores
#pragma warning disable CA1720 // Identifier contains type name

namespace EtwTools
{{
    /// <summary>
    /// Provider for {provider.DisplayName} ({provider.Id})
    /// </summary>
    public sealed class {provider.Name}Provider
    {{
        /// <summary>s
        /// Provider ID.
        /// </summary>
        public static readonly Guid Id = new(""{provider.Id}"");

        /// <summary>
        /// Provider name.
        /// </summary>
        public const string Name = ""{provider.DisplayName}"";{CreateProviderTasks(provider)}{CreateProviderOpcodes(provider)}{CreateProviderKeywords(provider)}{CreateProviderEvents(provider, structs)}{CreateProviderMaps(provider)}{CreateProviderStructs(provider, structs)}
    }}
}}
");

    File.WriteAllText($"{provider.Name}.cs", builder.ToString());
}

static void CreateMap(List<Provider> providers)
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
                {provider.Name}Provider.Id,
                (
                    {provider.Name}Provider.Name, new Dictionary<EtwEventDescriptor, string>
                    {{{provider.Events.Aggregate(new StringBuilder(), (s, e) => s.Append($@"
                        {{ {provider.Name}Provider.{EventName(e)}.Descriptor, {provider.Name}Provider.{EventName(e)}.Name }},"))}
                    }}
                )
            }},");
    }
    _ = builder.Append(@"        };
    }
}");
    File.WriteAllText("EtwProvider.generated.cs", builder.ToString());
}

static void GenerateProviders(string providers)
{
    List<Provider> providerList = new();

    foreach (var file in Directory.GetFiles(providers))
    {
        AnsiConsole.WriteLine($"Processing provider '{file}'.");
        var provider = JsonConvert.DeserializeObject<Provider>(File.ReadAllText(file));
        CreateProvider(provider);
        providerList.Add(provider);
    }

    CreateMap(providerList);
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
            var eventName = EtwEvent.GetKnownEventName(kvp.Key.Item1, kvp.Key.Item2);

            _ = table.AddRow(
                provider.Name ?? provider.Id.ToString(),
                eventName != null ? $"{eventName} (v{kvp.Key.Item2.Version})" : kvp.Key.Item2.ToString(),
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

void SaveTraceLoggingProviders(string trace, string add)
{
    using var logFile = new EtwTrace(trace);

    Dictionary<Guid, string> providers = new();
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

        providers[e.Provider] = eventInfo.ProviderName;
        providerEvents[e.Descriptor] = eventInfo;
    });

    logFile.Process();

    foreach (var (provider, providerEvents) in events)
    {
        if (add != null)
        {
            AddProvider(add, provider, providers[provider], false, null, null, null, null, null, providerEvents.Values, null);
        }
        else
        {
            File.WriteAllText($"{provider}.provider.json",
                JsonConvert.SerializeObject(new
                {
                    Id = provider,
                    Events = providerEvents.Values
                }, defaultJsonSettings));
        }
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

internal sealed record Provider
{
    public string Name { get; init; }
    public string DisplayName { get; init; }
    public Guid Id { get; init; }
    public IEnumerable<Event> Events { get; init; }
    public IReadOnlyDictionary<ulong, string> Tasks { get; init; }
    public IReadOnlyDictionary<ulong, string> Opcodes { get; init; }
    public IReadOnlyDictionary<ulong, string> Keywords { get; init; }
    public IEnumerable<Map> Maps { get; init; }
    public IEnumerable<Struct> Structs { get; init; }
}

internal sealed record Event
{
    public string Name { get; init; }
    public string DisplayName { get; init; }
    public EtwEventDescriptor Descriptor { get; init; }
    public IEnumerable<Field> Fields { get; init; }
}

internal sealed record Field
{
    public string Name { get; init; }
    public string Datatype { get; init; }
    public string Map { get; init; }
}

internal sealed record Struct
{
    public string Name { get; init; }
    public IEnumerable<Field> Fields { get; init; }
}

internal sealed record Map
{
    public string Name { get; init; }
    public bool Flags { get; init; }
    public IReadOnlyDictionary<ulong, string> Values { get; init; }
}

internal enum PublishedSort
{
    Name,
    Id
}
