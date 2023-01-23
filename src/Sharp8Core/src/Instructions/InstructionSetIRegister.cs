namespace Sharp8Core.Instructions;

public class InstructionSetIRegister : IInstruction
{
    public bool Execute(IChip8 chip8, int code)
    {
        chip8.IRegister =  code - 0xA000;

        return true;
    }
}
