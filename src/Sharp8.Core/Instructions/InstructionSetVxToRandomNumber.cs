using System.Security.Cryptography;

namespace Sharp8.Core.Instructions;

/// <sumary>
/// CXNN Set VX to a random number with a mask of NN
/// </sumary>
public class InstructionSetVxToRandomNumber : IInstruction
{
    public bool Execute(IChip8 chip8, int instructionCode)
    {
        var register = (instructionCode & 0x0F00) >> 8;
        var value = instructionCode & 0x00FF;

        var random = (byte)RandomNumberGenerator.GetInt32(256);
        chip8.Registers[register] = random & value;

        return true;
    }
}
