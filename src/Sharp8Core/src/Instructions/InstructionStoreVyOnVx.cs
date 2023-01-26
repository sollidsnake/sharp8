namespace Sharp8Core.Instructions;

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
        var vyValue = chip8.Registers[vy];

        chip8.Registers.SetVIndex(vx, vyValue);

        return true;
    }
}
