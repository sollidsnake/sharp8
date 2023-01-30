namespace Sharp8.Core.Instructions;

/// <summary>
/// 8XYE
/// Store the value of register VY shifted left one bit in register VX¹
///
/// Set register VF to the most significant bit prior to the shift
///
/// VY is unchanged
/// </summary>
public class InstructionStoreLeftShiftedVyOnVx : IInstruction
{
    public bool Execute(IChip8 chip8, int instructionCode)
    {
        var vx = (instructionCode & 0x0F00) >> 8;
        var vy = (instructionCode & 0x00F0) >> 4;

        var value = chip8.Registers[vy];

        chip8.Registers[0xF] = (byte)((value & 0x80) >> 7);
        chip8.Registers[vx] = (byte)(value << 1);

        return true;
    }
}
