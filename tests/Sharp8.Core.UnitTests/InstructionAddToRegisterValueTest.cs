using Moq;
using Sharp8.Core.Instructions;

namespace Sharp8.Core.UnitTests;

public class InstructionAddToRegisterValueTest
{
    [Theory]
    [InlineData(0x76FE, 6, 0x40, 0x3E, true)]
    public void WithExecute_ShouldSumValueCorrectly(
        int opcode,
        ushort register,
        int registerInitialValue,
        int expected,
        bool carry
    )
    {
        var chip8 = new Mock<IChip8>();
        var registers = new Chip8Registers();
        registers.SetVIndex(register, registerInitialValue);
        chip8.SetupGet(x => x.Registers).Returns(registers);

        new InstructionAddToRegisterValue().Execute(chip8.Object, opcode);

        Assert.Equal(expected, registers.GetValue(register));
        Assert.Equal(carry, registers.GetValue(0xF) == 1);
    }
}
