namespace Sharp8.Core.Instructions;

public class InstructionClearScreen : IInstruction
{
    public bool Execute(IChip8 chip8, int instructionCode)
    {
        chip8.Screen.Clear();

        return true;
    }
}
