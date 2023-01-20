namespace Sharp8Core.Instructions;

public class InstructionJump : IInstruction
{
    public InstructionType Target { get; } = InstructionType.Core;

    public void Execute(Chip8Memory memory, int code)
    {
        memory.PointingAddress =  code - 0xA000;
    }
}
