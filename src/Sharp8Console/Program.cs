// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using System.IO.Abstractions;
using Sharp8Core;
using Sharp8Core.RomReader;

if (args.Length == 0)
{
    Console.WriteLine("No arguments");
    return;
}

IScreen screen = new Chip8Screen();
var memory = new Chip8Memory(new Chip8Registers());
var romReader = new Chip8RomReader(new FileSystem());
Chip8 chip8 = new Chip8(screen, memory, romReader);
chip8.LoadRom(args[0]);

for (int i=0; i<1000; i++)
{
    chip8.ExecuteNextInstruction();
}

Console.WriteLine(screen.GenGridTableWithBorders());
