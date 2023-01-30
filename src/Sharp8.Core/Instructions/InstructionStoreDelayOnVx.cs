namespace Sharp8.Core.Instructions;

/// <sumary>
/// FX07 Store the current value of the delay timer in register VX
/// </sumary>
public class InstructionStoreDelayOnVx : IInstruction
{
    public bool Execute(IChip8 chip8, int instructionCode)
    {
        var register = ((instructionCode & 0x0F00) >> 8);

        chip8.Registers[register] = chip8.DelayTimer;

        return true;
    }
}
