namespace Sharp8Core.Instructions;

public class InstructionClearScreen : IInstruction
{
    public InstructionType Target => InstructionType.Screen;

    public void Execute(Chip8Memory memory, int instructionCode)
    {
    }
}
