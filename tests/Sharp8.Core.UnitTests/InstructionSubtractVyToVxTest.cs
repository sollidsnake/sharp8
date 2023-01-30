using Moq;
using Sharp8.Core.Instructions;

namespace Sharp8.Core.UnitTests;

public class InstructionSubtractVytoVxTest
{
    [Fact]
    public void WithExecute_ShouldSubtractVyFromVx()
    {
        // Arrange
        var opcode = 0x80D5;
        var chip8 = new Mock<IChip8>();
        var registers = new Chip8Registers();
        var vx = 0;
        var vy = 0xd;
        var vxInitialValue = 0x01;
        var vyInitialValue = 0x02;
        var expected = 0xFF;
        registers.SetVIndex(vx, vxInitialValue);
        registers.SetVIndex(vy, vyInitialValue);
        chip8.SetupGet(x => x.Registers).Returns(registers);

        // Act
        new InstructionSubtractVyToVx().Execute(chip8.Object, opcode);

        // Assert
        Assert.Equal(expected, registers.GetValue(vx));
        Assert.True(registers[0xF] == 0);
    }
}
