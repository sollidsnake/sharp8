namespace Sharp8Core.Instructions;

/**
 *
 * instruction 0xDXYZ
 * draws on coordinates XY a sprite of height Z
 */

public class InstructionAddToRegisterValue : IInstruction
{
    public bool Execute(IChip8 chip8, int instructionCode)
    {
        var register = (instructionCode >> 8) & 0x000f;
        var value = instructionCode & 0x00ff;

        var currentValue = chip8.Registers.GetValue(register);
        chip8.Registers.SetVIndex(register, value + currentValue);

        return true;
    }
}
