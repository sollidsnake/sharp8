using Sharp8Core.Instructions;
using TestUtils;

namespace Sharp8Core.UnitTests;

public class InstructionVxXorVyTest
{
    [Theory]
    [InlineData(0x8013, 0, 1, 2, 4)]
    [InlineData(0x8133, 1, 3, 2, 4)]
    public void Execute_ShouldStoreRegisterValueInMemory(
        int instructionCode,
        int registerX,
        int registerY,
        int initialVx,
        int initialVy
    )
    {
        var serviceContainer = TestServiceContainer.GetServiceProvider();
        var registers = new Chip8Registers();
        registers.SetVIndex(registerX, initialVx);
        registers.SetVIndex(registerY, initialVy);
        var memory = new Moq.Mock<IChip8Memory>();
        var instruction = new InstructionVxXorVy();
        var screen = new Moq.Mock<IScreen>();
        var chip8 = new Moq.Mock<IChip8>();
        chip8.Setup(c => c.Memory).Returns(memory.Object);
        chip8.Setup(m => m.Registers).Returns(registers);

        instruction.Execute(chip8.Object, instructionCode);

        Assert.Equal(initialVx ^ initialVy, registers.GetValue(registerX));
    }
}
