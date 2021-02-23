using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using EventTracing;

using Newtonsoft.Json;

using Spectre.Console;

using Trace;

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
}

var providersCommand = new Command("providers", "Commands that work on event providers.");
rootCommand.Add(providersCommand);
AddProvidersCommands(providersCommand);

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

    var waiting = false;
    var stop = false;
    Console.CancelKeyPress += (s, e) => stop = true;

    while (!stop)
    {
        session = EtwSession.GetSession(name);

        if (session == null)
        {
            if (!waiting)
            {
                AnsiConsole.WriteLine();
                AnsiConsole.WriteLine("No session found by that name, waiting...");
                AnsiConsole.WriteLine();
            }
            waiting = true;
        }
        else
        {
            if (waiting)
            {
                AnsiConsole.WriteLine();
                AnsiConsole.WriteLine("Total Buffers\tFree Buffers\tEvents Lost\tBuffers Written\tBuffers Lost\tReal-time Lost");
            }
            waiting = false;
            var statistics = session.GetStatistics();
            AnsiConsole.WriteLine($"{statistics.NumberOfBuffers}\t\t{statistics.FreeBuffers}\t\t{statistics.EventsLost}\t\t{statistics.BuffersWritten}\t\t{statistics.LogBuffersLost}\t\t{statistics.RealTimeBuffersLost}");
        }
        await Task.Delay(1000);
    }

    AnsiConsole.WriteLine();
}

static void ListPublishedProviders(PublishedSort sort)
{
    var providers = EtwProvider.GetPublishedProviders();

    var table = new Table().AddColumn("Name").AddColumn("ID");

    IEnumerable<EtwProvider> sortedProviders = sort switch
    {
        PublishedSort.Name => providers.OrderBy(s => s.Name).ThenBy(s => s.Id),
        PublishedSort.Id => providers.OrderBy(s => s.Id).ThenBy(s => s.Name),
        _ => providers,
    };

    foreach (var provider in sortedProviders)
    {
        _ = table.AddRow(provider.Name, provider.Id.ToString());
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
    AnsiConsole.WriteLine();
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
