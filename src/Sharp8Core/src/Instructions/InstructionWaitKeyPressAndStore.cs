namespace Sharp8Core.Instructions;

/// <summary>
/// FX0A
///
/// Wait for a keypress and store the result in register VX
///
/// </summary>
public class InstructionWaitKeyPressAndStore : IInstruction
{
    public bool Execute(IChip8 chip8, int instructionCode)
    {
        var vx = (instructionCode & 0x0F00) >> 8;
        chip8.WaitingForKeyPressOnRegister = (byte)vx;

        return true;
    }
}
