namespace Sharp8Core.Instructions;

/// <sumary>
/// CXNN Set VX to a random number with a mask of NN
/// </sumary>
public class InstructionSetVxToRandomNumber : IInstruction
{
    private Random _random;

    public InstructionSetVxToRandomNumber()
    {
        _random = new Random();
    }

    public bool Execute(IChip8 chip8, int instructionCode)
    {
        var register = (instructionCode & 0x0F00) >> 8;
        var value = instructionCode & 0x00FF;

        var random = (byte)_random.Next(0, 256);
        chip8.Registers[register] = random & value;

        return true;
    }
}
