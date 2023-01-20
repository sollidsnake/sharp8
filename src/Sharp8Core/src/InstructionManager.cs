namespace Sharp8Core.Instructions;

public enum InstructionEnum
{
    ClearScreen,
    Jump,
    SetRegister,
    AddValueToRegister,
    SetIndexRegister,
    Draw,
}

public class InstructionManager
{
    public IInstruction Action { get; init; } = default!;
    public int Code { get; init; } = default!;

    private InstructionManager() { }

    public static InstructionManager FromCode(int instruction)
    {
        return instruction switch
        {
            0x00E0 => Factory(instruction, new InstructionClearScreen()),
            int x when x >= 0xA000 && x <= 0xAFFF
                => Factory(instruction, new InstructionJump()),
            int x when x >= 0x6000 && x <= 0x6FFF
                => Factory(instruction, new InstructionSetRegister()),
            _ => throw new Exception("Invalid instruction"),
        };
    }

    private static InstructionManager Factory(int code, IInstruction type)
    {
        return new InstructionManager { Action = (IInstruction)type, Code = code, };
    }
}
