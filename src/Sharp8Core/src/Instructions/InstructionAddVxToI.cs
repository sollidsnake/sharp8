namespace Sharp8Core.Instructions;

/// <summary>
/// FX1E
/// Add the value stored in register VX to register I
/// </summary>
public class InstructionAddVxToI : IInstruction
{
    public bool Execute(IChip8 chip8, int instructionCode)
    {
        var vx = (instructionCode & 0x0F00) >> 8;
        chip8.Registers.I += chip8.Registers[vx];

        return true;
    }
}
