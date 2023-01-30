namespace Sharp8Core.Instructions;

public class InstructionBinaryCodedDecimal : IInstruction
{
    public bool Execute(IChip8 chip8, int instructionCode)
    {
        var vx = (instructionCode & 0x0f00) >> 8;

        var value = chip8.Registers.GetValue(vx);

        var firstDigit = (byte)(value / 100);
        var secondDigit = (byte)(value / 10 % 10);
        var thirdDigit = (byte)(value % 10);
        var iRegister = chip8.Registers.I;

        chip8.Memory.SetByteAtAddress(iRegister++, firstDigit);
        chip8.Memory.SetByteAtAddress(iRegister++, secondDigit);
        chip8.Memory.SetByteAtAddress(iRegister++, thirdDigit);

        return true;
    }
}
