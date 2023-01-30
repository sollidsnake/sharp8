namespace Sharp8.Core.Instructions;

/// <sumary>
/// EXA1 Skip the following instruction if the key corresponding to the hex
/// value currently stored in register VX is not pressed
/// </sumary>
public class InstructionSkipIfKeyNotPressed : IInstruction
{
    public bool Execute(IChip8 chip8, int instructionCode)
    {
        byte vx = (byte)((instructionCode & 0x0f00) >> 8);
        var keyHex = chip8.Registers[vx];

        if (!chip8.Input[keyHex])
        {
            chip8.ProgramCounter += 2;
        }

        return true;
    }
}
