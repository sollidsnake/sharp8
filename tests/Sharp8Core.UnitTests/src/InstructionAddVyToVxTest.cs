using Moq;
using Sharp8Core.Instructions;

namespace Sharp8Core.UnitTests;

public class InstructionAddVyToVxTest
{
    [Theory]
    [InlineData(0x8794, 1, 0xff, 0, true)]
    public void WithExecute_ShouldAddVyToVx(
        int instructionCode,
        byte vxValue,
        byte vyValue,
        byte expected,
        bool vf
    )
    {
        var vx = (byte)((instructionCode & 0x0f00) >> 8);
        var vy = (byte)((instructionCode & 0x00f0) >> 4);
        var mockChip8 = new Mock<IChip8>();
        var instruction = new InstructionAddVyToVx();
        var registers = new Chip8Registers();
        mockChip8.Setup(x => x.Registers).Returns(registers);
        registers.SetVIndex(vx, vxValue);
        registers.SetVIndex(vy, vyValue);

        instruction.Execute(mockChip8.Object, instructionCode);

        Console.WriteLine(expected);
        Console.WriteLine(registers[vx]);
        Assert.Equal(expected, registers[vx]);
        Assert.Equal(vf ? 1 : 0, registers[0xf]);
    }
}
