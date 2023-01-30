namespace Sharp8Core.Instructions;

/**
 * 0xFX29
 * Set I to the memory address of the sprite data corresponding to the
 * hexadecimal digit stored in register VX
 */
public class InstructionSetIToVx : IInstruction
{
    public bool Execute(IChip8 chip8, int instructionCode)
    {
        var register = (instructionCode & 0x0F00) >> 8;
        chip8.Registers.I = chip8.Registers.GetValue(register) * 5;

        return true;
    }
}
