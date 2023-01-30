using Sharp8.Core.Instructions.Helpers;

namespace Sharp8.Core.Instructions;

/// <summary>
/// 8xy4 - ADD Vx, Vy
/// Set Vx = Vx + Vy, set VF = carry.
/// Set VF to 00 if a carry does not occur
/// </summary>
public class InstructionAddVyToVx : IInstruction
{
    public bool Execute(IChip8 chip8, int instructionCode)
    {
        var vx = (instructionCode & 0x0f00) >> 8;
        var vy = (instructionCode & 0x00f0) >> 4;
        var vxValue = chip8.Registers[vx];
        var vyValue = chip8.Registers[vy];

        (int newValue, bool carry) = InstructionHelper.SumAndCheckCarry(
            vxValue,
            vyValue
        );

        chip8.Registers.SetVIndex(vx, newValue);
        chip8.Registers.SetVIndex(0xf, carry);

        return true;
    }
}
