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
        Screen screen = new Screen(
            new Chip8RomReader(new HexInstructions(), new FileSystem())
        );
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
