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

var rootCommand = new RootCommand("Controls Event Tracing for Windows (ETW).");

static void AddSessionCommands(Command sessionCommand)
{
    var listCommand = new Command("list", "List all active ETW sessions.")
    {
        Handler = CommandHandler.Create(ListSessions)
    };
    sessionCommand.Add(listCommand);

    var propertiesCommand = new Command("properties", "List properties of an ETW session.")
    {
        new Option<string>(new[] { "--name", "-n" }, "Name of session to fetch properties of.") { IsRequired = true }
    };
    propertiesCommand.Handler = CommandHandler.Create<string>(GetSessionProperties);
    sessionCommand.Add(propertiesCommand);

    var statisticsCommand = new Command("statistics", "Statistics of an ETW session.")
    {
        new Option<string>(new[] { "--name", "-n" }, "Name of session to fetch statistics of.") { IsRequired = true }
    };
    statisticsCommand.Handler = CommandHandler.Create<string>(GetSessionStatistics);
    sessionCommand.Add(statisticsCommand);


    var watchCommand = new Command("watch", "Watch an ETW session.")
    {
        new Option<string>(new[] { "--name", "-n" }, "Name of session to fetch statistics of.") { IsRequired = true }
    };
    watchCommand.Handler = CommandHandler.Create<string>(WatchSessionAsync);
    sessionCommand.Add(watchCommand);

    var startCommand = new Command("start", "Start a tracing session.")
    {
        new Option<string>(new[] { "--name", "-n" }, "The session name.") { IsRequired = true },
        new Option<string>(new[] { "--spec", "-s" }, "The trace specification.") { IsRequired = true },
        new Option<string>(new[] { "--output", "-o" }, "The output path and file name."),
        new Option<bool>(new[] { "--wait", "-w" }, "Wait while trace runs and end trace when program ends."),
        new Option<bool>(new[] { "--watch" }, "Wait and watch trace while it runs (implies --wait).")
    };
    startCommand.Handler = CommandHandler.Create<string, string, string, bool, bool>(StartSessionAsync);
    sessionCommand.Add(startCommand);

    var stopCommand = new Command("stop", "Stop a tracing session.")
    {
        new Option<string>(new[] { "--name", "-n" }, "The session name to stop.") { IsRequired = true },
    };
    stopCommand.Handler = CommandHandler.Create<string>(StopSession);
    sessionCommand.Add(stopCommand);
}

var sessionCommand = new Command("session", "Commands that work on individual sessions.");
rootCommand.Add(sessionCommand);
AddSessionCommands(sessionCommand);

static void AddProvidersCommands(Command providersCommand)
{
    var publishedCommand = new Command("published", "List all providers published on the system.")
    {
        new Option<PublishedSort>(new[] { "--sort", "-s" }, () => PublishedSort.Name, "Sort providers.")
    };
    publishedCommand.Handler = CommandHandler.Create<PublishedSort>(ListPublishedProviders);
    providersCommand.AddCommand(publishedCommand);

    var registeredCommand = new Command("registered", "List all providers registered across all processes.")
    {
        new Option<RegisteredSort>(new[] { "--sort", "-s" }, () => RegisteredSort.Name, "Sort providers.")
    };
    registeredCommand.Handler = CommandHandler.Create<RegisteredSort>(ListRegisteredProviders);
    providersCommand.AddCommand(registeredCommand);

    var processCommand = new Command("process", "List all providers registered in a process.")
    {
        new Option<uint>(new[] { "--pid", "-p" }, "Process to list.") { IsRequired = true },
        new Option<ProcessRegisteredSort>(new[] { "--sort", "-s" }, () => ProcessRegisteredSort.Name, "Sort providers.")
    };
    processCommand.Handler = CommandHandler.Create<uint, ProcessRegisteredSort>(ListRegisteredProvidersInProcess);
    providersCommand.AddCommand(processCommand);

    var infoCommand = new Command("info", "Information about a provider.")
    {
        new Option<string>(new[] { "--provider", "-p" }, "Provider.") { IsRequired = true }
    };
    infoCommand.Handler = CommandHandler.Create<string>(GetProviderInfo);
    providersCommand.AddCommand(infoCommand);
}

var providersCommand = new Command("providers", "Commands that work on event providers.");
rootCommand.Add(providersCommand);
AddProvidersCommands(providersCommand);

static void AddTraceCommands(Command traceCommand)
{
    var infoCommand = new Command("info", "List information about a trace.")
    {
        new Option<string>(new[] { "--file", "-f" }, "The trace file.")
    };
    infoCommand.Handler = CommandHandler.Create<string>(GetTraceInfo);
    traceCommand.AddCommand(infoCommand);
}

var traceCommand = new Command("trace", "Commands that work on traces.");
rootCommand.Add(traceCommand);
AddTraceCommands(traceCommand);

static void ListSessions()
{
    var sessions = EtwSession.GetAllSessions();

    var table = new Table().AddColumn("Name").AddColumn("ID");

    foreach (var session in sessions.OrderBy(s => s.Name))
    {
        _ = table.AddRow(session.Name, session.Id.ToString());
    }

    AnsiConsole.Render(table);
}

static void GetSessionProperties(string name)
{
    var session = EtwSession.GetSession(name);

    if (session == null)
    {
        AnsiConsole.WriteLine();
        AnsiConsole.WriteLine("No session found by that name.");
        AnsiConsole.WriteLine();
        return;
    }

    AnsiConsole.WriteLine();
    AnsiConsole.WriteLine($"{session.Name} ({session.Id})");
    AnsiConsole.WriteLine();
    AnsiConsole.WriteLine($"Clock resolution = {session.ClockResolution}");

    var properties = session.GetProperties();

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

static void GetSessionStatistics(string name)
{
    var session = EtwSession.GetSession(name);

    if (session == null)
    {
        AnsiConsole.WriteLine();
        AnsiConsole.WriteLine("No session found by that name.");
        AnsiConsole.WriteLine();
        return;
    }

    AnsiConsole.WriteLine();
    AnsiConsole.WriteLine($"{session.Name} ({session.Id})");
    AnsiConsole.WriteLine();

    var statistics = session.GetStatistics();

    AnsiConsole.WriteLine($"Number of buffers = {statistics.NumberOfBuffers}");
    AnsiConsole.WriteLine($"Free buffers = {statistics.FreeBuffers}");
    AnsiConsole.WriteLine($"Events lost = {statistics.EventsLost}");
    AnsiConsole.WriteLine($"Buffers written = {statistics.BuffersWritten}");
    AnsiConsole.WriteLine($"Log buffers lost = {statistics.LogBuffersLost}");
    AnsiConsole.WriteLine($"Real time buffers lost = {statistics.RealTimeBuffersLost}");
    AnsiConsole.WriteLine();
}

static async Task WatchSessionAsync(string name)
{
    EtwSession session = default;

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
        session = EtwSession.GetSession(name);

        if (session == null)
        {
            if (!waiting)
            {
                AnsiConsole.WriteLine();
                AnsiConsole.WriteLine("No session found by that name, waiting...");
            }
            waiting = true;
        }
        else
        {
            if (!printedHeader)
            {
                AnsiConsole.WriteLine();
                AnsiConsole.WriteLine("Total Buffers\tFree Buffers\tEvents Lost\tBuffers Written\tBuffers Lost\tReal-time Lost");
                printedHeader = true;
            }
            waiting = false;
            var statistics = session.GetStatistics();
            AnsiConsole.WriteLine($"{statistics.NumberOfBuffers}\t\t{statistics.FreeBuffers}\t\t{statistics.EventsLost}\t\t{statistics.BuffersWritten}\t\t{statistics.LogBuffersLost}\t\t{statistics.RealTimeBuffersLost}");
        }
        await Task.Delay(1000);
    }
}

static void ListPublishedProviders(PublishedSort sort)
{
    var providers = EtwProvider.GetPublishedProviders();

    var table = new Table().AddColumn("Name").AddColumn("ID").AddColumn("Manifest");

    IEnumerable<EtwProvider> sortedProviders = sort switch
    {
        PublishedSort.Name => providers.OrderBy(s => s.Name).ThenBy(s => s.Id),
        PublishedSort.Id => providers.OrderBy(s => s.Id).ThenBy(s => s.Name),
        _ => providers,
    };

    foreach (var provider in sortedProviders)
    {
        _ = table.AddRow(provider.Name, provider.Id.ToString(), provider.GetEventDescriptors() != null ? "Yes" : "No");
    }

    AnsiConsole.WriteLine();
    AnsiConsole.Render(table);
    AnsiConsole.WriteLine();
}

static void ListRegisteredProviders(RegisteredSort sort)
{
    var providers = EtwProvider.GetRegisteredProviders().Select(p => (p.Name, p.Id, p.GetInstanceInfos().Count));

    var table = new Table().AddColumn("Name").AddColumn("ID").AddColumn("Count");

    var sortedProviders = sort switch
    {
        RegisteredSort.Name => providers.OrderBy(s => s.Name).ThenBy(s => s.Id),
        RegisteredSort.Id => providers.OrderBy(s => s.Id).ThenBy(s => s.Name),
        RegisteredSort.Count => providers.OrderByDescending(s => s.Count).ThenBy(s => s.Id).ThenBy(s => s.Name),
        _ => providers,
    };

    foreach (var (name, id, count) in sortedProviders)
    {
        _ = table.AddRow(name ?? string.Empty, id.ToString(), count.ToString(CultureInfo.InvariantCulture));
    }

    AnsiConsole.WriteLine();
    AnsiConsole.Render(table);
    AnsiConsole.WriteLine();
}

static void ListRegisteredProvidersInProcess(uint pid, ProcessRegisteredSort sort)
{
    var providers = EtwProvider.GetRegisteredProviders();

    var sortedProviders = sort switch
    {
        ProcessRegisteredSort.Name => providers.OrderBy(s => s.Name).ThenBy(s => s.Id),
        ProcessRegisteredSort.Id => providers.OrderBy(s => s.Id).ThenBy(s => s.Name),
        _ => (IEnumerable<EtwProvider>)providers,
    };

    foreach (var provider in sortedProviders)
    {
        Tree providerNode = default;

        foreach (var instance in provider.GetInstanceInfos().Where(i => i.ProcessId == pid))
        {
            TreeNode instanceNode = default;
            TreeNode enabledNode = default;

            foreach (var enable in instance.EnableInfos)
            {
                if (instanceNode == null)
                {
                    if (providerNode == null)
                    {
                        providerNode = new Tree($"{provider.Name ?? provider.Id.ToString()} ({provider.Id})");
                    }

                    instanceNode = providerNode.AddNode($"Properties: {instance.Properties}");
                }

                enabledNode = instanceNode.AddNode("Enable parameters");
                _ = enabledNode.AddNode($"Level: {enable.Level}");
                _ = enabledNode.AddNode($"Properties: {enable.EnableProperty & TraceProperties.All}");
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

static void GetProviderInfo(string provider)
{
    var providerGuid = Guid.Parse(provider);
    var etwProvider = EtwProvider.GetPublishedProviders().SingleOrDefault(p => p.Id == providerGuid);

    AnsiConsole.WriteLine();

    if (etwProvider == null)
    {
        AnsiConsole.WriteLine("Cannot find provider.");
        AnsiConsole.WriteLine();
        return;
    }

    AnsiConsole.WriteLine($"Name: {etwProvider.Name}");

    var eventDescriptors = etwProvider.GetEventDescriptors();

    if (eventDescriptors == null)
    {
        AnsiConsole.WriteLine("No event manifest found.");
    }
    else
    {
        AnsiConsole.WriteLine("Events:");
        foreach (var e in eventDescriptors)
        {
            AnsiConsole.WriteLine($"ID = {e.Id}, Version = {e.Version}, Channel = {e.Channel}, Level = {e.Level}, Opcode = {e.Opcode}, Task = {e.Task}, Keyword = {e.Keyword:X16}");
        }
    }

    AnsiConsole.WriteLine();
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

static async Task StartSessionAsync(string name, string spec, string output, bool wait, bool watch)
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
        ? SystemTraceProvider.None
        : specObject.Kernel.Providers.Where(kvp => kvp.Value != TraceState.Off).Aggregate(SystemTraceProvider.None, (v, kvp) => v | kvp.Key);

    var properties = new EtwSession.Properties
    {
        LogFileMode =
            LogFileMode.IndependentSessionMode
            | (systemTraceProvidersEnabled != SystemTraceProvider.None ? LogFileMode.SystemLoggerMode : LogFileMode.FileModeNone),
        SystemTraceProvidersEnabled = systemTraceProvidersEnabled,
        LogFileName = $"{(string.IsNullOrEmpty(output) ? name : output)}.etl"
    };

    var session = EtwSession.CreateSession(name, properties);

    if (!wait && !watch)
    {
        return;
    }

    await WatchSessionAsync(name);

    AnsiConsole.WriteLine();
    AnsiConsole.WriteLine("Stopping session.");
    session.Stop();
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

static void GetTraceInfo(string file)
{
    using var logFile = new EtwTrace(file);

    var eventCount = 0;
    Dictionary<Guid, int> providerCount = new();
    var stats = logFile.Open(null, e =>
    {
        eventCount++;
        _ = providerCount.TryGetValue(e.Provider, out var count);
        providerCount[e.Provider] = count + 1;
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
    AnsiConsole.WriteLine($"Log File Mode: {stats.LogFileMode & LogFileMode.All}{((stats.LogFileMode & ~LogFileMode.All) != 0 ? $" | 0x{stats.LogFileMode & ~LogFileMode.All}" : string.Empty)}");
    AnsiConsole.WriteLine($"Buffer Size: 0x{stats.BufferSize:X8}");
    AnsiConsole.WriteLine($"Buffers Written: {stats.BuffersWritten}");
    AnsiConsole.WriteLine($"Events Lost: {stats.EventsLost}");
    AnsiConsole.WriteLine($"Buffers Lost: {stats.BuffersLost}");
    AnsiConsole.WriteLine($"Timer Resolution: 0x{stats.TimerResolution:X8}");
    AnsiConsole.WriteLine($"Performance Counter Frequency: 0x{stats.PerfFrequency:X16}");
    AnsiConsole.WriteLine($"Clock Resolution: {stats.ClockResolution}");
    AnsiConsole.WriteLine($"Kernel Trace: {(stats.IsKernelTrace ? "yes" : "no")}");
    AnsiConsole.WriteLine();
    AnsiConsole.WriteLine($"Event Count: {eventCount}");

    var table = new Table().AddColumn("ID").AddColumn("Count");

    foreach (var kvp in providerCount.OrderByDescending(kvp => kvp.Value))
    {
        _ = table.AddRow(kvp.Key.ToString(), kvp.Value.ToString(CultureInfo.InvariantCulture));
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
    Name,
    Id,
    Count
}

internal enum ProcessRegisteredSort
{
    Name,
    Id
}
