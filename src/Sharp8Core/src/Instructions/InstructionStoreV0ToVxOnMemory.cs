namespace Sharp8Core.Instructions;

/// <sumary>
/// FX55
/// Store the values of registers V0 to VX inclusive in memory starting at
/// address I.
/// I is set to I + X + 1 after operation
/// </sumary>
public class InstructionStoreV0ToVxOnMemory : IInstruction
{
    public bool Execute(IChip8 chip8, int instructionCode)
    {
        var vx = (instructionCode & 0x0F00) >> 8;

        for (int i = 0; i <= vx; i++)
        {
            chip8.Memory.SetByteAtAddress(
                chip8.Registers.I,
                (byte)chip8.Registers.GetValue(i)
            );

            chip8.Registers.I += 1;
        }

        return true;
    }
}
