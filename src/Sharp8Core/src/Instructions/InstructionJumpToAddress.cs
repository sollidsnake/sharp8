namespace Sharp8Core.Instructions;

/**
 *
 * 0x1FFF: jumps to address FFF
 */

public class InstructionJumpToAddress : IInstruction
{
    public bool Execute(Chip8 chip8, int instructionCode)
    {
        var address = instructionCode & 0x0FFF;
        chip8.Memory.GoToAddress(address);

        return false;
    }
}
