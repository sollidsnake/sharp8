using Sharp8Core.Instructions;
using Sharp8Core.RomReader;

namespace Sharp8Core;

public class Chip8
{
    public IScreen Screen { get; }
    public Chip8Memory Memory { get; }
    private Chip8RomReader _romReader;

    public Chip8(IScreen screen, Chip8Memory memory, Chip8RomReader romReader)
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

        if (instruction.Action.Execute(this, instruction.Code))
        {
            Memory.NextInstruction();
        }

        return instruction;
    }

    public void PrintDebug(InstructionManager instruction)
    {
        Console.WriteLine(
            $"PC: {Memory.ProgramCounter:X4} - Instruction: {instruction.Code:X4} {instruction.Action.GetType().Name}"
        );
        for (int i = 0; i < 3; i++)
        {
            Console.Write($"v{i}:{Memory.Registers.GetValue(i):X2} ");
        }
        Console.WriteLine(
            $"Instruction: {instruction.Code:X4} - {instruction.Action.GetType().Name}"
        );
    }
}
