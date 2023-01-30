namespace Sharp8Core.Instructions;

/// <summary>
/// 9XY0
///
/// Skip the following instruction if the value of register VX is not equal to
/// the value of register VY
///
/// </summary>
public class InstructionSkipIfVxIsNotEqualToVy : IInstruction
{
    public bool Execute(IChip8 chip8, int instructionCode)
    {
        var x = (instructionCode & 0x0F00) >> 8;
        var y = (instructionCode & 0x00F0) >> 4;

        if (chip8.Registers[x] != chip8.Registers[y])
        {
            chip8.ProgramCounter += 2;
        }

        return true;
    }
}
