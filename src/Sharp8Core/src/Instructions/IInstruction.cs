namespace Sharp8Core.Instructions;

public enum InstructionType
{
    Core,
    Screen
}

public interface IInstruction
{
    public void Execute(Chip8 chip8, int instructionCode);
}
