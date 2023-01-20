using Sharp8Core.Instructions;

namespace Sharp8Core.UnitTests;

public class InstructionManagerTest
{
    [Fact]
    public void WithClearScreen_ShouldReturnCorrectInstruction()
    {
        var instructionCode = 0x00E0;
        var instruction = InstructionManager.FromCode(instructionCode);

        Assert.Equal(0x00E0, instruction.Code);
        Assert.Equal(
            typeof(InstructionClearScreen),
            instruction.Action.GetType()
        );
    }

    [Theory]
    [InlineData(0x600C)]
    [InlineData(0x6000)]
    [InlineData(0x6FFF)]
    public void FromCode_ShouldReturnSetRegisterInstruction(int instructionCode)
    {
        var instruction = InstructionManager.FromCode(instructionCode);
        Assert.IsType<InstructionSetRegister>(instruction.Action);
    }

    [Theory]
    [InlineData(0xA000)]
    [InlineData(0xAA22)]
    [InlineData(0xAFFF)]
    public void FromCode_ShouldReturnInstructionJump(int instructionCode)
    {
        var instruction = InstructionManager.FromCode(instructionCode);
        Assert.IsType<InstructionJump>(instruction.Action);
    }

    [Fact]
    public void WithJump_ShouldReturnCorrectInstruction()
    {
        var instructionCode = 0x00E0;
        var instruction = InstructionManager.FromCode(instructionCode);

        Assert.Equal(instructionCode, instruction.Code);
        Assert.Equal(
            typeof(InstructionClearScreen),
            instruction.Action.GetType()
        );
    }
}
