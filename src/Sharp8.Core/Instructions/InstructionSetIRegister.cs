namespace Sharp8.Core.Instructions;

/// <summary>
/// ANNN
/// Store memory address NNN in register I
/// </summary>
public class InstructionSetIRegister : IInstruction
{
    public bool Execute(IChip8 chip8, int instructionCode)
    {
        chip8.Registers.I = instructionCode & 0x0FFF;

        return true;
    }
}
