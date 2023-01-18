using Sharp8Core.Instructions;

namespace Sharp8Core;

public class Chip8Memory
{
    private const int MemorySize = 4096;
    protected byte[] Memory;
    private HexInstructions _instructions;

    public Chip8Memory(HexInstructions instructions)
    {
        _instructions = instructions;
        Memory = new byte[MemorySize];
    }

    public void LoadInstructions(string instructions)
    {
        _instructions.LoadInstructions(instructions);
    }

    public (string, Instruction) InstructionAtPoint(int point)
    {
        var instruction = _instructions!.Instructions![point];
        return (instruction, InstructionDictionary.GetInstruction(instruction));
    }
}
