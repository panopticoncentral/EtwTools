
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Linq;

using EventTracing;

using Spectre.Console;

var rootCommand = new RootCommand("Controls Event Tracing for Windows (ETW).");
var listCommand = new Command("list", "List all active ETW sessions.");

rootCommand.Add(listCommand);
listCommand.Handler = CommandHandler.Create(ListSessions);

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

return await rootCommand.InvokeAsync(args);
