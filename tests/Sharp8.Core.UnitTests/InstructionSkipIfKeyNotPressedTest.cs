using Moq;
using Sharp8.Core.Instructions;

namespace Sharp8.Core.UnitTests;

public class InstructionSkipIfKeyNotPressedTest
{
    [Fact]
    public void WithExecute_ShouldNotSkipInstructionIfKeyIsPressed()
    {
        var instructionCode = 0xE0A1;
        var keyHex = 0xA;
        var vx = (instructionCode & 0x0F00) >> 8;
        var chip8 = new Mock<IChip8>();
        var registers = new Chip8Registers();
        var input = new Chip8Input();
        input[keyHex] = true;
        chip8.SetupGet(x => x.Registers).Returns(registers);
        chip8.SetupGet(x => x.ProgramCounter).Returns(0);
        chip8.SetupGet(x => x.Input).Returns(input);
        registers.SetVIndex(vx, keyHex);

        new InstructionSkipIfKeyNotPressed().Execute(
            chip8.Object,
            instructionCode
        );

        chip8.VerifySet(x => x.ProgramCounter = 2, Times.Never);
    }
}
