namespace Sharp8.Core.Instructions;

/// <summary>
/// EX9E
///
/// Skip the following instruction if the key corresponding to the hex value currently stored in register VX is pressed
///
/// </summary>
public class InstructionSkipIfKeyIsStoredInVx : IInstruction
{
    public bool Execute(IChip8 chip8, int instructionCode)
    {
        var x = (instructionCode & 0x0F00) >> 8;

        var key = chip8.Registers[x];

        if (chip8.Input[key])
        {
            chip8.ProgramCounter += 2;
        }

        chip8.WaitingForKeyPressOnRegister = null;

        return true;
    }
}
