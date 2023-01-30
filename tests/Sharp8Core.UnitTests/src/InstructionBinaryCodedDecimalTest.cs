using Sharp8Core.Instructions;

namespace Sharp8Core.UnitTests;

public class InstructionBinaryCodedDecimalTest
{
    // [Theory]
    // [InlineData(0xF033, 0, 0, 123, 1, 2, 3)]
    // [InlineData(0xF233, 1, 2, 835, 8, 3, 5)]
    public void WithExecute_ShouldSetTheRegistersCorrectly(
        int instructionCode,
        int iRegisterAddress,
        int vx,
        int vxValue,
        int firstDigit,
        int secondDigit,
        int thirdDigit
    )
    {
        var memory = new Chip8Memory();
        var mockChip8Stack = new Moq.Mock<IChip8Stack>();
        var mockChip8 = new Moq.Mock<IChip8>();
        var registers = new Chip8Registers();
        registers.SetVIndex(vx, vxValue);
        mockChip8.SetupGet(x => x.Registers.I).Returns(iRegisterAddress);
        mockChip8.SetupGet(x => x.Memory).Returns(memory);
        mockChip8.SetupGet(x => x.Registers).Returns(registers);
        var instruction = new InstructionBinaryCodedDecimal();

        instruction.Execute(mockChip8.Object, instructionCode);

        Assert.Equal(firstDigit, memory[iRegisterAddress]);
        Assert.Equal(secondDigit, memory[iRegisterAddress + 1]);
        Assert.Equal(thirdDigit, memory[iRegisterAddress + 2]);
        mockChip8.VerifySet(
            x => x.Registers.I = iRegisterAddress + 3,
            Moq.Times.Once
        );
    }
}
