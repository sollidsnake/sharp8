using System.CommandLine;

namespace Sharp8.UI;

public class Program
{
    public static readonly float FPS = 1000f / 60;

    public static int Main(string[] args)
    {
        CreateArgumentParser().Invoke(args);

        return 0;
    }

    private static RootCommand CreateArgumentParser()
    {
        var rootCommand = new RootCommand(
            "Sharp 8 - A CHIP-8 emulator written in C#"
        );

        var romArg = new Argument<string>("rom", "The ROM to load");
        rootCommand.AddArgument(romArg);

        var debugOpt = new Option<string[]>(
            new[] { "--debug-at-address", "-d" },
            "Make the emulation stop at the specified addresses"
        );
        var instructionsPerSeccond = new Option<uint>(
            new[] { "--instructions-per-second", "--ips", "-i" },
            "The number of instructions to execute per second (default 60)"
        );
        var verboseOpt = new Option<bool>(
            new[] { "--verbose", "-v" },
            "Enable verbose logging"
        );

        rootCommand.AddOption(debugOpt);
        rootCommand.AddOption(verboseOpt);
        rootCommand.AddOption(instructionsPerSeccond);

        rootCommand.SetHandler(
            (arg) =>
            {
                var game = new Game();
                var romFile = arg.ParseResult.CommandResult.GetValueForArgument(
                    romArg
                );
                var debugPoints =
                    arg.ParseResult.CommandResult.GetValueForOption(debugOpt);
                var verbose = arg.ParseResult.CommandResult.GetValueForOption(
                    verboseOpt
                );
                var ips = arg.ParseResult.CommandResult.GetValueForOption(
                    instructionsPerSeccond
                );

                game.InstructionsPerSeccond = ips > 0 ? ips : 10;
                game.DebugPoints = debugPoints ?? Array.Empty<string>();
                if (verbose)
                {
                    game.PrintDebug = true;
                }

                game.Run(romFile);
                Environment.Exit(0);
            }
        );

        return rootCommand;
    }
}
