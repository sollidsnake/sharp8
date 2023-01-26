namespace Sharp8Core.Instructions;

/// <summary>
/// 4XNN Skip the following instruction if the value of register VX is not equal
/// to NN
/// </summary>
public class InstructionSkipIfVxIsNotEqualToNN : IInstruction
{
    public bool Execute(IChip8 chip8, int instructionCode)
    {
        var register = (instructionCode & 0x0F00) >> 8;
        var value = chip8.Registers.IRegister;
        var registerValue = chip8.Registers[register];

        if (value != registerValue)
        {
            chip8.ProgramCounter += 2;
        }

        return true;
    }
}
