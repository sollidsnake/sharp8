using Sharp8Core.Instructions.Helpers;

namespace Sharp8Core.Instructions;

/// <summary>
/// FX18 Set the sound timer to the value of register VX
/// </summary>
public class InstructionSetSoundTimer : IInstruction
{
    public bool Execute(IChip8 chip8, int instructionCode)
    {
        // TODO: implement sound

        return true;
    }
}
