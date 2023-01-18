// See https://aka.ms/new-console-template for more information

using System.IO.Abstractions;
using Sharp8Core;
using Sharp8Core.RomReader;
using Sharp8Screen;

public class Program
{
    public static readonly float FPS = 1000f / 60;

    public static void Main(string[] args)
    {
        var memory = new Chip8Memory(new HexInstructions());
        var chip8 = new Chip8(memory);
        var romReader = new Chip8RomReader(
            new FileSystem()
        );

        Screen screen = new Screen(chip8, memory, romReader);
        if (args.Length == 2)
        {
            LoadRomFile(screen, args[1]);
            return;
        }

        screen.RunRomFile("../../tests/assets/ibmlogo.ch8");
    }

    private static void LoadRomFile(Screen screen, string filename)
    {
        Console.WriteLine(filename);
        screen.RunRomFile(filename);
    }
}
