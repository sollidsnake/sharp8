namespace Sharp8.Core.Instructions;

/// <sumary>
/// FX15 Set the delay timer to the value of register VX
/// </sumary>
public class InstructionSetDelayTimer : IInstruction
{
    public bool Execute(IChip8 chip8, int instructionCode)
    {
        var register = ((instructionCode & 0x0F00) >> 8);

        chip8.DelayTimer = (byte) chip8.Registers[register];

        return true;
    }
}
