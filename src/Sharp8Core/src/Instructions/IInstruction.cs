namespace Sharp8Core.Instructions;

public enum InstructionType
{
    Core,
    Screen
}

public interface IInstruction
{
    InstructionType Target { get; }

    public void Execute(Chip8Memory memory, int instructionCode);
}
