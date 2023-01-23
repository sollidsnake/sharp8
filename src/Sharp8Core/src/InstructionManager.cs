namespace Sharp8Core.Instructions;

public class InstructionManager
{
    public IInstruction Action { get; init; } = default!;
    public int Code { get; init; } = default!;
    protected static Dictionary<int, IInstruction> Instructions;

    static InstructionManager()
    {
        Instructions = new Dictionary<int, IInstruction>();

        Instructions.Add(0x00E0, new InstructionClearScreen());
        Instructions.Add(0xA000, new InstructionSetIRegister());
        Instructions.Add(0x6000, new InstructionSetRegister());
        Instructions.Add(0xd000, new InstructionDrawSprite());
        Instructions.Add(0x7000, new InstructionAddToRegisterValue());
        Instructions.Add(0x8000, new InstructionVxXorVy());
        Instructions.Add(0x2000, new InstructionPushToStack());
        Instructions.Add(0x1000, new InstructionJumpToAddress());
        Instructions.Add(0xF033, new InstructionBinaryCodedDecimal());
    }

    private InstructionManager() { }

    public static InstructionManager FromCode(int instruction)
    {
        return instruction switch
        {
            0x00E0 => Factory(instruction, Instructions[0x00E0]),
            int x when x >= 0xA000 && x <= 0xAFFF
                => Factory(instruction, Instructions[0xA000]),
            int x when x >= 0x6000 && x <= 0x6FFF
                => Factory(instruction, Instructions[0x6000]),
            int x when x >= 0xd000 && x <= 0xdFFF
                => Factory(instruction, Instructions[0xd000]),
            int x when x >= 0x7000 && x <= 0x7FFF
                => Factory(instruction, Instructions[0x7000]),
            int x when x >= 0x8000 && x <= 0x8FFF
                => Factory(instruction, Instructions[0x8000]),
            int x when x >= 0x2000 && x <= 0x2FFF
                => Factory(instruction, Instructions[0x2000]),
            int x when x >= 0x1000 && x <= 0x1FFF
                => Factory(instruction, Instructions[0x1000]),
            int x when (x & 0xF0FF) == 0xF033
                => Factory(instruction, Instructions[0xF033]),
            _
                => throw new Exception(
                    $"Unimplemented instruction {instruction:X4}"
                ),
        };
    }

    private static InstructionManager Factory(int code, IInstruction type)
    {
        return new InstructionManager
        {
            Action = (IInstruction)type,
            Code = code,
        };
    }
}
