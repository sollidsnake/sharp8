namespace Sharp8Core.Instructions;

public class InstructionWriteMemoryToRegister : IInstruction
{
    public bool Execute(IChip8 chip8, int instructionCode)
    {
        var register = (instructionCode & 0x0F00) >> 8;
        var iRegister = chip8.Registers.I;

        for (int i = 0; i <= register; i++)
        {
            chip8.Registers.SetVIndex(i, chip8.Memory[iRegister + i]);
        }

        chip8.Registers.I += register + 1;

        return true;
    }
}
