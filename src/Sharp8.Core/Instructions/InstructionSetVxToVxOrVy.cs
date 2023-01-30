namespace Sharp8.Core.Instructions;

/// <summary>
/// 8XY1
///
/// Set VX to VX OR VY
/// </summary>
public class InstructionSetVxToVxOrVy : IInstruction
{
    public bool Execute(IChip8 chip8, int instructionCode)
    {
        var x = (instructionCode & 0x0F00) >> 8;
        var y = (instructionCode & 0x00F0) >> 4;

        chip8.Registers[x] = chip8.Registers[x] | chip8.Registers[y];

        return true;
    }
}
