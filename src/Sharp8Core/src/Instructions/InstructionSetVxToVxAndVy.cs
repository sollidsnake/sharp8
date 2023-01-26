namespace Sharp8Core.Instructions;

/// <summary>
/// 8xy2 - AND Vx, Vy
/// Set Vx = Vx AND Vy.
/// </summary>
public class InstructionSetVxToVxAndVy : IInstruction
{
    public bool Execute(IChip8 chip8, int instructionCode)
    {
        var vx = (instructionCode & 0x0f00) >> 8;
        var vy = (instructionCode & 0x00f0) >> 4;
        var vxValue = chip8.Registers[vx];
        var vyValue = chip8.Registers[vy];

        chip8.Registers.SetVIndex(vx, vxValue & vyValue);

        return true;
    }
}
