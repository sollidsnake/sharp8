namespace Sharp8.Core.Instructions;

/// <summary>
/// Store Vy on Vx
/// 0x8xy0
/// </summary>
public class InstructionStoreVyOnVx : IInstruction
{
    public bool Execute(IChip8 chip8, int instructionCode)
    {
        var vx = (instructionCode & 0x0f00) >> 8;
        var vy = (instructionCode & 0x00f0) >> 4;

        chip8.Registers[vx] = chip8.Registers[vy];

        return true;
    }
}
