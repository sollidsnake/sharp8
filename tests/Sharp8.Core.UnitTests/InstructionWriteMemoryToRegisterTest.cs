using Sharp8.Core.Instructions;

namespace Sharp8.Core.UnitTests;

public class InstructionWriteMemoryToRegisterTest
{
    [Fact]
    public void WithExecute_RegistersShouldReceiveValuesFromMemory()
    {
        var instructionCode = 0xF265;
        var mockChip8 = new Moq.Mock<IChip8>();
        var memory = new Chip8Memory();
        var registers = new Chip8Registers();
        mockChip8.SetupGet(x => x.Memory).Returns(memory);
        mockChip8.SetupGet(x => x.Registers).Returns(registers);
        registers.I = 0x200;
        memory.SetByteAtAddress(0x200, 0x10);
        memory.SetByteAtAddress(0x201, 0x15);
        memory.SetByteAtAddress(0x202, 0x19);

        var instruction = new InstructionWriteMemoryToRegister();

        instruction.Execute(mockChip8.Object, instructionCode);

        Assert.Equal(memory[0x200], registers.GetValue(0x0));
        Assert.Equal(memory[0x201], registers.GetValue(0x1));
        Assert.Equal(memory[0x202], registers.GetValue(0x2));
        Assert.Equal(0x203, registers.I);
    }
}
