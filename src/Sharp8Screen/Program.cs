// See https://aka.ms/new-console-template for more information
using System.CommandLine;

using Sharp8Screen;

public class Program
{
    public static readonly float FPS = 1000f / 60;

    public static int Main(string[] args)
    {
        // TestDebug();
        // return 0;
        return CreateArgumentParser().Invoke(args);
    }

    private static RootCommand CreateArgumentParser()
    {
        var game = new Game();
        var rootCommand = new RootCommand(
            "Sharp 8 - A CHIP-8 emulator written in C#"
        );

        var romArg = new Argument<string>("rom", "The ROM to load");
        rootCommand.AddArgument(romArg);

        var debugOpt = new Option<string[]>(
            new[] { "--debug-at-addresses", "-d" },
            "Make the emulation stop at the specified addresses"
        );

        rootCommand.AddOption(debugOpt);

        rootCommand.SetHandler(
            (arg) =>
            {
                var romFile = arg.ParseResult.CommandResult.GetValueForArgument(romArg);
                var debugPoints = arg.ParseResult.CommandResult.GetValueForOption(debugOpt);

                game.DebugPoints = debugPoints ?? Array.Empty<string>();
                game.Run(romFile);
                // stop execution
                Environment.Exit(0);
            }
        );

        return rootCommand;
    }

    public static void TestDebug()
    {
        var game = new Game { DebugPoints = new string[] { "0202" } };
        Console.WriteLine("Debuggingt at " + game.DebugPoints[0]);

        game.Run("/home/jesse/code/learn/sharp-8/roms/ibmlogo.ch8");
    }
}
