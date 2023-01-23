namespace Sharp8Core.Instructions;

public class InstructionVxXorVy : IInstruction
{
    public bool Execute(IChip8 chip8, int instructionCode)
    {
        var vx = (instructionCode >> 8) &0x000f;
        var vy = (instructionCode >> 4) &0x000f;

        var valueX = chip8.Registers.GetValue(vx);
        var valueY = chip8.Registers.GetValue(vy);

        chip8.Registers.setVIndex(vx, valueX ^ valueY);

        return true;
    }
}
