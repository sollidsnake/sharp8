using Sharp8Core.Instructions;

namespace Sharp8Core;

public class Chip8
{
    public Chip8Memory Memory { get; }
    private int _currentInstruction = 0;

    public Chip8(Chip8Memory memory)
    {
        Memory = memory;
    }

    public void LoadInstructions(string instructions)
    {
        Memory.LoadInstructions(instructions);
    }

    public (string, Instruction) ReadInstruction()
    {
        return Memory.InstructionAtPoint(_currentInstruction++);
    }
}
