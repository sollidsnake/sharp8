namespace Sharp8Core.Instructions;

// instruction 0x6NXX
// Store number NN in register VX
/*
 * 0x600c 00000110 00000000 00000000 00001100
 *
 */
public class InstructionSetRegister : IInstruction
{
    public InstructionType Target => InstructionType.Screen;

    public void Execute(Chip8Memory memory, int instructionCode)
    {
        var lastTwoHex = instructionCode & 0x00FF;
        var secondHex = instructionCode >> 8 & 0xf;

        memory.Registers.setVIndex(secondHex, lastTwoHex);
    }
}
