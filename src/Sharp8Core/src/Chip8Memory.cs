using Sharp8Core.Instructions;

namespace Sharp8Core;

public class Chip8Memory
{
    private const int MemorySize = 4096;
    protected byte[] Memory;
    private HexInstructions _instructions;

    public Chip8Memory(HexInstructions instructions)
    {
        Memory = new byte[MemorySize];
        _instructions = instructions;
    }

    public (string, InstructionTable) InstructionAtPoint(int point)
    {
        var instruction = _instructions.Instructions![point];
        return (instruction, InstructionDictionary.GetInstruction(instruction));
    }
}
