namespace Sharp8Core.Instructions;

public class InstructionPushToStack : IInstruction
{
    public bool Execute(IChip8 chip8, int instructionCode)
    {
        var address = instructionCode & 0x0fff;
        chip8.PushToStack(address);
        return false;
    }
}
