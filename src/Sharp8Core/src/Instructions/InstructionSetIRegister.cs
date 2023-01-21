namespace Sharp8Core.Instructions;

public class InstructionSetIRegister : IInstruction
{
    public bool Execute(Chip8 chip8, int code)
    {
        chip8.Memory.IRegisterAddress =  code - 0xA000;

        return true;
    }
}
