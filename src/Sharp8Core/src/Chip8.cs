using Sharp8Core.Instructions;
using Sharp8Core.RomReader;

namespace Sharp8Core;

public class Chip8
{
    public IScreen Screen { get; }
    public Chip8Memory Memory { get; }
    private int _currentInstruction = 0;
    private int _pc = 0;
    private Chip8RomReader _romReader;

    public Chip8(
        IScreen screen,
        Chip8Memory memory,
        Chip8RomReader romReader
    )
    {
        Screen = screen;
        Memory = memory;
        _romReader = romReader;
    }

    public void LoadRom(string path)
    {
        Memory.LoadRom(_romReader.Read(path));
    }

    public void LoadRom(byte[] rom)
    {
        Memory.LoadRom(rom);
    }

    public InstructionManager ExecuteNextInstruction()
    {
        var currentInstruction = Memory.CurrentInstruction();
        var instruction = InstructionManager.FromCode(currentInstruction);

        instruction.Action.Execute(this, instruction.Code);
        Memory.NextInstruction();
        return instruction;
    }
}
