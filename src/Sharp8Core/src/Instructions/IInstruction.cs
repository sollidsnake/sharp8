namespace Sharp8Core.Instructions;

public enum InstructionType
{
    Core,
    Screen
}

public interface IInstruction
{
    /*
     * returns true if cpu should increase pc
     */
    public bool Execute(Chip8 chip8, int instructionCode);
}
