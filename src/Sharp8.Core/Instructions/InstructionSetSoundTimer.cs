using Sharp8.Core.Instructions.Helpers;

namespace Sharp8.Core.Instructions;

/// <summary>
/// FX18 Set the sound timer to the value of register VX
/// </summary>
public class InstructionSetSoundTimer : IInstruction
{
    public bool Execute(IChip8 chip8, int instructionCode)
    {
        var vx = (instructionCode & 0x0F00) >> 8;
        chip8.SoundTimer = (byte)chip8.Registers[vx];

        return true;
    }
}
