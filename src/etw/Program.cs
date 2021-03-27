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
    var publishedCommand = new Command("published", "List all providers published on the system.")
    {
        new Option<PublishedSort>(new[] { "--sort", "-s" }, () => PublishedSort.Name, "Sort providers."),
        new Option<bool>(new[] { "--json" }, "Output in JSON format.")
    };
    publishedCommand.Handler = CommandHandler.Create<PublishedSort, bool>(ListPublishedProviders);
    providersCommand.AddCommand(publishedCommand);

    var processCommand = new Command("process", "List all providers registered in a process.")
    {
        new Argument<uint>("pid", "Process to list."),
        new Option<bool>(new[] { "--json" }, "Output in JSON format.")
    };
    processCommand.Handler = CommandHandler.Create<uint, bool>(ListRegisteredProvidersInProcess);
    providersCommand.AddCommand(processCommand);

    var eventsCommand = new Command("events", "Events raised by a provider.")
    {
        new Option<string>(new[] { "--id" }, "Provider ID.") { IsRequired = true }
    };
    eventsCommand.Handler = CommandHandler.Create<string>(GetEvents);
    providersCommand.AddCommand(eventsCommand);
}

var providersCommand = new Command("providers", "Commands that work on event providers.");
rootCommand.Add(providersCommand);
AddProvidersCommands(providersCommand);

static void AddTraceCommands(Command traceCommand)
{
    var infoCommand = new Command("info", "List information about a trace.")
    {
        new Option<string>(new[] { "--file", "-f" }, "The trace file.") { IsRequired = true }
    };
    infoCommand.Handler = CommandHandler.Create<string>(GetTraceInfo);
    traceCommand.AddCommand(infoCommand);
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

void ListPublishedProviders(PublishedSort sort, bool json)
{
    var providers = EtwProvider.GetPublishedProviders();

    IEnumerable<(string Name, EtwProvider Provider)> sortedProviders = sort switch
    {
        PublishedSort.Name => providers.OrderBy(s => s.Name).ThenBy(s => s.Provider.Id),
        PublishedSort.Id => providers.OrderBy(s => s.Provider.Id).ThenBy(s => s.Name),
        _ => providers,
    };

    if (!json)
    {
        var table = new Table().AddColumn("Name").AddColumn("ID").AddColumn("Manifest");

        foreach (var (name, provider) in sortedProviders)
        {
            _ = table.AddRow(name, provider.Id.ToString(), provider.GetEventDescriptors() != null ? "Yes" : "No");
        }

        AnsiConsole.WriteLine();
        AnsiConsole.Render(table);
        AnsiConsole.WriteLine();
    }
    else
    {
        AnsiConsole.WriteLine(JsonConvert.SerializeObject(providers, defaultJsonSettings));
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
                            providerNode = new Tree(providerId.ToString());
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

static void GetEvents(string id)
{
    var (name, provider) = Guid.TryParse(id, out var providerGuid)
        ? EtwProvider.GetPublishedProviders().SingleOrDefault(p => p.Provider.Id == providerGuid)
        : EtwProvider.GetPublishedProviders().SingleOrDefault(p => p.Name == id);
    AnsiConsole.WriteLine();

    if (provider == null)
    {
        AnsiConsole.WriteLine("Cannot find provider.");
        AnsiConsole.WriteLine();
        return;
    }

    var eventDescriptors = provider.GetEventDescriptors();

    if (eventDescriptors == null)
    {
        AnsiConsole.WriteLine("No event manifest found.");
        AnsiConsole.WriteLine();

        return;
    }

    Dictionary<string, EtwPropertyMapInfo> maps = new();

    foreach (var e in eventDescriptors)
    {
        foreach (var p in e.Properties)
        {
            void GatherMaps(Dictionary<string, EtwPropertyMapInfo> maps, EtwPropertyInfo property)
            {
                if (property is EtwSimplePropertyInfo simpleProperty && simpleProperty.MapName != null && !maps.TryGetValue(simpleProperty.MapName, out var _))
                {
                    maps[simpleProperty.Name] = provider.GetPropertyMap(simpleProperty.MapName, e.Descriptor.Version);
                }
            }

            GatherMaps(maps, p);
        }
    }

    AnsiConsole.WriteLine(JsonConvert.SerializeObject(new EventInformation { Events = eventDescriptors, Maps = maps },
        new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
            Converters = new[] { new StringEnumConverter() },
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            }
        }));
    AnsiConsole.WriteLine();
}

static void GetTraceInfo(string file)
{
    using var logFile = new EtwTrace(file);

    var totalEventCount = 0;
    Dictionary<(Guid, EtwEventDescriptor), int> eventCount = new();
    var stats = logFile.Open(null, e =>
    {
        totalEventCount++;
        _ = eventCount.TryGetValue((e.Provider, e.Descriptor), out var count);
        eventCount[(e.Provider, e.Descriptor)] = count + 1;
    });

    logFile.Process();

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

    var publishedProviders = EtwProvider.GetPublishedProviders();
    Dictionary<Guid, string> providerIdMap = new();

    // There may be duplicates, but this is just a best guess...
    foreach (var (name, provider) in publishedProviders.Where(p => !string.IsNullOrEmpty(p.Name)))
    {
        providerIdMap[provider.Id] = name;
    }

    var table = new Table().AddColumn("Name").AddColumn("ID").AddColumn("Event").AddColumn("Count");

    foreach (var kvp in eventCount.OrderByDescending(kvp => kvp.Value))
    {
        _ = table.AddRow(
            providerIdMap.TryGetValue(kvp.Key.Item1, out var provider) ? provider : string.Empty,
            kvp.Key.Item1.ToString(),
            kvp.Key.Item2.ToString(),
            kvp.Value.ToString(CultureInfo.InvariantCulture));
    }

    AnsiConsole.Render(table);
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

