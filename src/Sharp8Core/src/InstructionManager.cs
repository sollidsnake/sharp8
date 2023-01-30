using Sharp8Core.Instructions.Exceptions;

namespace Sharp8Core.Instructions;

public class InstructionManager
{
    public IInstruction Action { get; init; } = default!;
    public int Code { get; init; } = default!;
    protected static Dictionary<int, IInstruction> Instructions { get; set; }

    static InstructionManager()
    {
        Instructions = new Dictionary<int, IInstruction>
        {
            { 0x00E0, new InstructionClearScreen() },
            { 0x00EE, new InstructionStackPop() },
            { 0x1000, new InstructionJumpToAddress() },
            { 0x2000, new InstructionPushToStack() },
            { 0x3000, new InstructionSkipIfVxEqNN() },
            { 0x4000, new InstructionSkipIfVxIsNotEqualToNN() },
            { 0x5000, new InstructionSkipIfVxEqualsVy() },
            { 0x6000, new InstructionSetRegister() },
            { 0x7000, new InstructionAddToRegisterValue() },
            { 0x8000, new InstructionStoreVyOnVx() },
            { 0x8001, new InstructionSetVxToVxOrVy() },
            { 0x8002, new InstructionSetVxToVxAndVy() },
            { 0x8003, new InstructionVxXorVy() },
            { 0x8004, new InstructionAddVyToVx() },
            { 0x8005, new InstructionSubtractVyToVx() },
            { 0x8006, new InstructionStoreRightShiftedVyOnVx() },
            { 0x800E, new InstructionStoreLeftShiftedVyOnVx() },
            { 0x9000, new InstructionSkipIfVxIsNotEqualToVy() },
            { 0xA000, new InstructionSetIRegister() },
            { 0xB000, new InstructionJumpToAddressNNNPlusV0() },
            { 0xC000, new InstructionSetVxToRandomNumber() },
            { 0xD000, new InstructionDrawSprite() },
            { 0xE09E, new InstructionSkipIfKeyIsStoredInVx() },
            { 0xE0A1, new InstructionSkipIfKeyNotPressed() },
            { 0xF007, new InstructionStoreDelayOnVx() },
            { 0xF00A, new InstructionWaitKeyPressAndStore() },
            { 0xF015, new InstructionSetDelayTimer() },
            { 0xF018, new InstructionSetSoundTimer() },
            { 0xF01E, new InstructionAddVxToI() },
            { 0xF029, new InstructionSetIToVx() },
            { 0xF033, new InstructionBinaryCodedDecimal() },
            { 0xF055, new InstructionStoreV0ToVxOnMemory() },
            { 0xF065, new InstructionWriteMemoryToRegister() },
        };
    }

    private InstructionManager() { }

    public static InstructionManager FromCode(int instruction)
    {
        return instruction switch
        {
            0x00E0 => Factory(instruction, Instructions[0x00E0]),
            0x00EE => Factory(instruction, Instructions[0x00EE]),
            int x when x is >= 0xA000 and <= 0xAFFF
                => Factory(instruction, Instructions[0xA000]),
            int x when x is >= 0xB000 and <= 0xBFFF
                => Factory(instruction, Instructions[0xB000]),
            int x when x is >= 0x6000 and <= 0x6FFF
                => Factory(instruction, Instructions[0x6000]),
            int x when x is >= 0xC000 and <= 0xCFFF
                => Factory(instruction, Instructions[0xC000]),
            int x when x is >= 0xd000 and <= 0xdFFF
                => Factory(instruction, Instructions[0xD000]),
            int x when x is >= 0x3000 and <= 0x3FFF
                => Factory(instruction, Instructions[0x3000]),
            int x when x is >= 0x7000 and <= 0x7FFF
                => Factory(instruction, Instructions[0x7000]),
            int x when (x & 0xF00F) == 0x8003
                => Factory(instruction, Instructions[0x8003]),
            int x when (x & 0xF00F) == 0x8000
                => Factory(instruction, Instructions[0x8000]),
            int x when (x & 0xF00F) == 0x8001
                => Factory(instruction, Instructions[0x8001]),
            int x when (x & 0xF00F) == 0x8002
                => Factory(instruction, Instructions[0x8002]),
            int x when (x & 0xF00F) == 0x8004
                => Factory(instruction, Instructions[0x8004]),
            int x when (x & 0xF00F) == 0x8005
                => Factory(instruction, Instructions[0x8005]),
            int x when (x & 0xF00F) == 0x8006
                => Factory(instruction, Instructions[0x8006]),
            int x when (x & 0xF00F) == 0x800E
                => Factory(instruction, Instructions[0x800E]),
            int x when (x & 0xF00F) == 0x9000
                => Factory(instruction, Instructions[0x9000]),
            int x when x is >= 0x2000 and <= 0x2FFF
                => Factory(instruction, Instructions[0x2000]),
            int x when x is >= 0x4000 and <= 0x4FFF
                => Factory(instruction, Instructions[0x4000]),
            int x when x is >= 0x1000 and <= 0x1FFF
                => Factory(instruction, Instructions[0x1000]),
            int x when (x & 0xF00F) == 0X5000
                => Factory(instruction, Instructions[0x5000]),
            int x when (x & 0xF0FF) == 0xF055
                => Factory(instruction, Instructions[0xF055]),
            int x when (x & 0xF0FF) == 0xF065
                => Factory(instruction, Instructions[0xF065]),
            int x when (x & 0xF0FF) == 0xF033
                => Factory(instruction, Instructions[0xF033]),
            int x when (x & 0xF0FF) == 0xF015
                => Factory(instruction, Instructions[0xF015]),
            int x when (x & 0xF0FF) == 0xF018
                => Factory(instruction, Instructions[0xF018]),
            int x when (x & 0xF0FF) == 0xF01E
                => Factory(instruction, Instructions[0xF01E]),
            int x when (x & 0xF0FF) == 0xF029
                => Factory(instruction, Instructions[0xF029]),
            int x when (x & 0xF0FF) == 0xE09E
                => Factory(instruction, Instructions[0xE09E]),
            int x when (x & 0xF0FF) == 0xE0A1
                => Factory(instruction, Instructions[0xE0A1]),
            int x when (x & 0xF0FF) == 0xF007
                => Factory(instruction, Instructions[0xF007]),
            int x when (x & 0xF0FF) == 0xF00A
                => Factory(instruction, Instructions[0xF00A]),
            _
                => throw new UnimplementedInstructionException(
                    $"Unimplemented instruction {instruction:X4}"
                ),
        };
    }

    private static InstructionManager Factory(int code, IInstruction type)
    {
        return new InstructionManager { Action = type, Code = code, };
    }
}
