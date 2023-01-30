using Moq;
using Sharp8.Core.Instructions;

namespace Sharp8.Core.UnitTests;

public class InstructionSkipIfVxIsNotEqualToNNTest
{
    [Fact]
    public void WithTrueCondition_ShouldNotSkipNextInstruction()
    {
        var opcode = 0x4700;
        var chip8 = new Mock<IChip8>();
        var registers = new Chip8Registers();
        registers.SetVIndex(7, 0x00);
        chip8.SetupGet(x => x.Registers).Returns(registers);
        chip8.Setup(x => x.ProgramCounter).Returns(0x200);

        var increasePC = new InstructionSkipIfVxIsNotEqualToNN().Execute(
            chip8.Object,
            opcode
        );

        chip8.VerifySet(x => x.ProgramCounter = It.IsAny<int>(), Times.Never);
        Assert.True(increasePC);
    }
}
