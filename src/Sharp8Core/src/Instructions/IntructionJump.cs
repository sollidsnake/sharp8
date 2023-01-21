namespace Sharp8Core.Instructions;

public class InstructionSetIRegister : IInstruction
{
    public void Execute(Chip8 chip8, int code)
    {
        chip8.Memory.IRegisterAddress =  code - 0xA000;
    }
}
