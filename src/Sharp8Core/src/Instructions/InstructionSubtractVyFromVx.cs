using Sharp8Core.Instructions.Helpers;

namespace Sharp8Core.Instructions;

/// <summary>
/// 8XY5 Subtract the value of register VY from register VX
/// Set VF to 00 if a borrow occurs
/// Set VF to 01 if a borrow does not occur
/// </summary>
public class InstructionSubtractVyToVx : IInstruction
{
    public bool Execute(IChip8 chip8, int instructionCode)
    {
        var vx = (instructionCode & 0x0f00) >> 8;
        var vy = (instructionCode & 0x00f0) >> 4;
        var vxValue = chip8.Registers[vx];
        var vyValue = chip8.Registers[vy];

        (int newValue, bool carry) = InstructionHelper.SubAndCheckBorrow(
            vxValue,
            vyValue
        );

        chip8.Registers.SetVIndex(vx, newValue);
        chip8.Registers.SetVIndex(0xf, carry);

        return true;
    }
}
