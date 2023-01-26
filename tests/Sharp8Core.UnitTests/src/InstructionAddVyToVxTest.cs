using Moq;
using Sharp8Core.Instructions;

namespace Sharp8Core.UnitTests;

public class InstructionAddVyToVxTest
{
    [Fact]
    public void WithExecute_ShouldAddVyToVx()
    {
        var instructionCode = 0x8684;
        var vx = 0x6;
        var vy = 0x8;
        var vxValue = 10;
        var vyValue = 15;
        var mockChip8 = new Mock<IChip8>();
        var instruction = new InstructionAddVyToVx();
        var registers = new Chip8Registers();
        mockChip8.Setup(x => x.Registers).Returns(registers);
        registers.SetVIndex(vx, vxValue);
        registers.SetVIndex(vy, vyValue);

        instruction.Execute(mockChip8.Object, instructionCode);

        Assert.Equal(vxValue + vyValue, registers[vx]);
    }
}
