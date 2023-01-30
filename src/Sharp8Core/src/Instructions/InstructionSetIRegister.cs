namespace Sharp8Core.Instructions;

/// <summary>
/// ANNN
/// Store memory address NNN in register I
/// </summary>
public class InstructionSetIRegister : IInstruction
{
    public bool Execute(IChip8 chip8, int code)
    {
        chip8.Registers.I =  code & 0x0FFF;

        return true;
    }
}
