using Sharp8Core.Instructions.Helpers;

namespace Sharp8Core.Instructions;

/// <summary>
/// ADD Vx, Vy
/// Set Vx = Vx + Vy, set VF = carry.
/// </summary>
public class InstructionAddToRegisterValue : IInstruction
{
    public bool Execute(IChip8 chip8, int instructionCode)
    {
        var register = (instructionCode >> 8) & 0x000f;
        var value = instructionCode & 0x00ff;

        var currentValue = chip8.Registers.GetValue(register);

        var (result, carry) = InstructionHelper.SumAndCheckCarry(
            currentValue,
            value
        );
        chip8.Registers.SetVIndex(register, result);
        chip8.Registers.SetVIndex(0xf, carry);

        return true;
    }
}
