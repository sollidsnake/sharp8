namespace Sharp8Core.Instructions;

public class InstructionWriteMemoryToRegister : IInstruction
{
    public bool Execute(IChip8 chip8, int instructionCode)
    {
        var register = (instructionCode & 0x0F00) >> 8;

        chip8.Memory

        return true;
    }
}
