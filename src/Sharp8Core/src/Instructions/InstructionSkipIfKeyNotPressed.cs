namespace Sharp8Core.Instructions;

/// <sumary>
/// EXA1 Skip the following instruction if the key corresponding to the hex
/// value currently stored in register VX is not pressed
/// </sumary>
public class InstructionSkipIfKeyNotPressed : IInstruction
{
    public bool Execute(IChip8 chip8, int instructionCode)
    {
        chip8.ProgramCounter += 2;
        return true;
    }
}
