namespace Sharp8.Core.Instructions;

/// <summary>
/// 00EE Return from a subroutine
/// </summary>
public class InstructionStackPop : IInstruction
{
    public bool Execute(IChip8 chip8, int instructionCode)
    {
        chip8.PopFromStack();

        return false;
    }
}
