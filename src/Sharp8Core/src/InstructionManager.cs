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
        Instructions.Add(0x00EE, new InstructionStackPop());
        Instructions.Add(0x1000, new InstructionJumpToAddress());
        Instructions.Add(0x2000, new InstructionPushToStack());
        Instructions.Add(0x3000, new InstructionSkipIfVxEqNN());
        Instructions.Add(0x4000, new InstructionSkipIfVxIsNotEqualToNN());
        Instructions.Add(0x6000, new InstructionSetRegister());
        Instructions.Add(0x7000, new InstructionAddToRegisterValue());
        Instructions.Add(0x8000, new InstructionStoreVyOnVx());
        Instructions.Add(0x8002, new InstructionSetVxToVxAndVy());
        Instructions.Add(0x8003, new InstructionVxXorVy());
        Instructions.Add(0x8004, new InstructionAddVyToVx());
        Instructions.Add(0x8005, new InstructionSubtractVyToVx());
        Instructions.Add(0xA000, new InstructionSetIRegister());
        Instructions.Add(0xC000, new InstructionSetVxToRandomNumber());
        Instructions.Add(0xD000, new InstructionDrawSprite());
        Instructions.Add(0xE0A1, new InstructionSkipIfKeyNotPressed());
        Instructions.Add(0xF007, new InstructionStoreDelayOnVx());
        Instructions.Add(0xF015, new InstructionSetDelayTimer());
        Instructions.Add(0xF018, new InstructionSetSoundTimer());
        Instructions.Add(0xF029, new InstructionSetIToVx());
        Instructions.Add(0xF033, new InstructionBinaryCodedDecimal());
        Instructions.Add(0xF065, new InstructionWriteMemoryToRegister());
    }

    private InstructionManager() { }

    public static InstructionManager FromCode(int instruction)
    {
        return instruction switch
        {
            0x00E0 => Factory(instruction, Instructions[0x00E0]),
            0x00EE => Factory(instruction, Instructions[0x00EE]),
            int x when x >= 0xA000 && x <= 0xAFFF
                => Factory(instruction, Instructions[0xA000]),
            int x when x >= 0x6000 && x <= 0x6FFF
                => Factory(instruction, Instructions[0x6000]),
            int x when x >= 0xC000 && x <= 0xCFFF
                => Factory(instruction, Instructions[0xC000]),
            int x when x >= 0xd000 && x <= 0xdFFF
                => Factory(instruction, Instructions[0xD000]),
            int x when x >= 0x3000 && x <= 0x3FFF
                => Factory(instruction, Instructions[0x3000]),
            int x when x >= 0x7000 && x <= 0x7FFF
                => Factory(instruction, Instructions[0x7000]),
            int x when (x & 0xF00F) == 0x8003
                => Factory(instruction, Instructions[0x8003]),
            int x when (x & 0xF00F) == 0x8000
                => Factory(instruction, Instructions[0x8000]),
            int x when (x & 0xF00F) == 0x8002
                => Factory(instruction, Instructions[0x8002]),
            int x when (x & 0xF00F) == 0x8004
                => Factory(instruction, Instructions[0x8004]),
            int x when (x & 0xF00F) == 0x8005
                => Factory(instruction, Instructions[0x8005]),
            int x when x >= 0x2000 && x <= 0x2FFF
                => Factory(instruction, Instructions[0x2000]),
            int x when x >= 0x4000 && x <= 0x4FFF
                => Factory(instruction, Instructions[0x4000]),
            int x when x >= 0x1000 && x <= 0x1FFF
                => Factory(instruction, Instructions[0x1000]),
            int x when (x & 0xF0FF) == 0xF065
                => Factory(instruction, Instructions[0xF065]),
            int x when (x & 0xF0FF) == 0xF033
                => Factory(instruction, Instructions[0xF033]),
            int x when (x & 0xF0FF) == 0xF015
                => Factory(instruction, Instructions[0xF015]),
            int x when (x & 0xF0FF) == 0xF018
                => Factory(instruction, Instructions[0xF018]),
            int x when (x & 0xF0FF) == 0xF029
                => Factory(instruction, Instructions[0xF029]),
            int x when (x & 0xF0FF) == 0xE0A1
                => Factory(instruction, Instructions[0xE0A1]),
            int x when (x & 0xF0FF) == 0xF007
                => Factory(instruction, Instructions[0xF007]),
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
