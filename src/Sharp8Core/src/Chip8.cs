using Sharp8Core.Instructions;
using Sharp8Core.RomReader;

namespace Sharp8Core;

public class Chip8
{
    public Chip8Memory Memory { get; }
    private int _currentInstruction = 0;

    public Chip8(Chip8Memory memory)
    {
        Memory = memory;
    }

    public (string, InstructionTable) ReadInstruction()
    {
        return Memory.InstructionAtPoint(_currentInstruction++);
    }
}
