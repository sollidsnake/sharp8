namespace Sharp8.Core.Instructions;

/// <summary>
/// 8XY6
/// Store the value of register VY shifted right one bit in register VX
///
/// Set register VF to the least significant bit prior to the shift
///
/// VY is unchanged
/// </summary>
public class InstructionStoreRightShiftedVyOnVx : IInstruction
{
    public bool Execute(IChip8 chip8, int instructionCode)
    {
        var vx = (instructionCode & 0x0F00) >> 8;
        var vy = (instructionCode & 0x00F0) >> 4;

        chip8.Registers[vx] = (byte)(chip8.Registers[vy] >> 1);
        chip8.Registers[0xF] = (byte)(chip8.Registers[vy] & 0x1);

        return true;
    }
}
