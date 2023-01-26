namespace Sharp8Core.Instructions;

/// <sumary>
/// 3XNN Skip the following instruction if the value of register VX equals NN
/// </sumary>
public class InstructionSkipIfVxEqNN : IInstruction
{
    public bool Execute(IChip8 chip8, int instructionCode)
    {
        var register = (instructionCode & 0x0F00) >> 8;
        var value = instructionCode & 0x00FF;

        if (chip8.Registers[register] == value) {
            chip8.ProgramCounter += 2;
        }

        return true;
    }
}
