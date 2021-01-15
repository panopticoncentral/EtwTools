
using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Linq;
using System.Threading.Tasks;

using EventTracing;

using Spectre.Console;

var rootCommand = new RootCommand("Controls Event Tracing for Windows (ETW).");

var listCommand = new Command("list", "List all active ETW sessions.");
listCommand.Handler = CommandHandler.Create(ListSessions);
rootCommand.Add(listCommand);

var propertiesCommand = new Command("properties", "List properties of an ETW session.")
{
    new Option<string>(new[] { "--name", "-n" }, "Name of session to fetch properties of.") { IsRequired = true }
};
propertiesCommand.Handler = CommandHandler.Create<string>(GetSessionProperties);
rootCommand.Add(propertiesCommand);

var statisticsCommand = new Command("statistics", "Statistics of an ETW session.")
{
    new Option<string>(new[] { "--name", "-n" }, "Name of session to fetch statistics of.") { IsRequired = true }
};
statisticsCommand.Handler = CommandHandler.Create<string>(GetSessionStatistics);
rootCommand.Add(statisticsCommand);

var watchCommand = new Command("watch", "Watch an ETW session.")
{
    new Option<string>(new[] { "--name", "-n" }, "Name of session to fetch statistics of.") { IsRequired = true }
};
watchCommand.Handler = CommandHandler.Create<string>(WatchSession);
rootCommand.Add(watchCommand);

static void ListSessions()
{
    var sessions = EtwSession.GetAllSessions();

    var table = new Table().AddColumn("Name").AddColumn("Id");

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

return await rootCommand.InvokeAsync(args);
