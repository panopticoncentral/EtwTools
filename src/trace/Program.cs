
using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Linq;
using System.Threading.Tasks;

using EventTracing;

using Spectre.Console;

var rootCommand = new RootCommand("Controls Event Tracing for Windows (ETW).");

// List

var listCommand = new Command("list", "List all active ETW sessions.");
listCommand.Handler = CommandHandler.Create(ListSessions);
rootCommand.Add(listCommand);

// Properties

var propertiesCommand = new Command("properties", "List properties of an ETW session.")
{
    new Option<string>(new[] { "--name", "-n" }, "Name of session to fetch properties of.") { IsRequired = true }
};
propertiesCommand.Handler = CommandHandler.Create<string>(GetSessionProperties);
rootCommand.Add(propertiesCommand);

// Statistics

var statisticsCommand = new Command("statistics", "Statistics of an ETW session.")
{
    new Option<string>(new[] { "--name", "-n" }, "Name of session to fetch statistics of.") { IsRequired = true }
};
statisticsCommand.Handler = CommandHandler.Create<string>(GetSessionStatistics);
rootCommand.Add(statisticsCommand);

// Watch

var watchCommand = new Command("watch", "Watch an ETW session.")
{
    new Option<string>(new[] { "--name", "-n" }, "Name of session to fetch statistics of.") { IsRequired = true }
};
watchCommand.Handler = CommandHandler.Create<string>(WatchSession);
rootCommand.Add(watchCommand);

// Providers

var providersCommand = new Command("providers", "Commands that work on event providers.");
rootCommand.Add(providersCommand);

var publishedCommand = new Command("published", "List all providers published on the system.")
{
    new Option<PublishedSort>(new[] { "--sort", "-s" }, () => PublishedSort.Name, "Sort providers.")
};
publishedCommand.Handler = CommandHandler.Create<PublishedSort>(PublishedProviders);
providersCommand.AddCommand(publishedCommand);

var registeredCommand = new Command("registered", "List all providers registered across all processes.")
{
    new Option<RegisteredSort>(new[] { "--sort", "-s" }, () => RegisteredSort.Name, "Sort providers.")
};
registeredCommand.Handler = CommandHandler.Create<RegisteredSort>(RegisteredProviders);
providersCommand.AddCommand(registeredCommand);

var processCommand = new Command("process", "List all providers registered in a process.")
{
    new Option<uint>(new[] { "--pid", "-p" }, "Process to list.") { IsRequired = true },
    new Option<ProcessRegisteredSort>(new[] { "--sort", "-s" }, () => ProcessRegisteredSort.Name, "Sort providers.")
};
processCommand.Handler = CommandHandler.Create<uint, ProcessRegisteredSort>(ProcessRegisteredProviders);
providersCommand.AddCommand(processCommand);

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

static async Task WatchSession(string name)
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

static void PublishedProviders(PublishedSort sort)
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

static void RegisteredProviders(RegisteredSort sort)
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
        _ = table.AddRow(name ?? string.Empty, id.ToString(), count.ToString());
    }

    AnsiConsole.WriteLine();
    AnsiConsole.Render(table);
    AnsiConsole.WriteLine();
}

static void ProcessRegisteredProviders(uint pid, ProcessRegisteredSort sort)
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
