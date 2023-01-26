namespace Sharp8Core.Instructions;

/// <sumary>
/// 2NNN
/// Class <c>InstructionPushToStack</c> Executes subroutine starting at address
/// </sumary>
public class InstructionPushToStack : IInstruction
{
    public bool Execute(IChip8 chip8, int instructionCode)
    {
        var address = instructionCode & 0x0fff;
        chip8.PushToStack(address);

        return false;
    }
}
