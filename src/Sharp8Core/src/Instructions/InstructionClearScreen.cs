namespace Sharp8Core.Instructions;

public class InstructionClearScreen : IInstruction
{
    public void Execute(Chip8 chip8, int instructionCode)
    {
        chip8.Screen.Clear();
    }
}
