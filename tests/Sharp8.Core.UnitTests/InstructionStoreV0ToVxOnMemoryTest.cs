using Moq;
using Sharp8.Core.Instructions;

namespace Sharp8.Core.UnitTests;

public class InstructionStoreV0ToVxOnMemoryTest
{
    [Fact]
    public void WithExecute_ShouldStoreRegistersOnMemory()
    {
        var instructionCode = 0xF255;
        var finalRegister = (instructionCode & 0x0F00) >> 8;

        var memory = new Mock<IChip8Memory>();
        var chip8 = new Mock<IChip8>();
        var registers = new Chip8Registers();
        chip8.SetupGet(c => c.Memory).Returns(memory.Object);
        chip8.SetupGet(x => x.Registers).Returns(registers);
        var registerIStart = registers.I;

        new InstructionStoreV0ToVxOnMemory().Execute(
            chip8.Object,
            instructionCode
        );

        for (var i = 0; i <= finalRegister; i++)
        {
            memory.Verify(
                x =>
                    x.SetByteAtAddress(
                        It.Is<int>(y => y == registerIStart + i),
                        It.Is<byte>(y => y == (byte)registers.GetValue(i))
                    ),
                Times.Once()
            );
        }

        Assert.Equal(registerIStart + finalRegister + 1, registers.I);
    }
}
