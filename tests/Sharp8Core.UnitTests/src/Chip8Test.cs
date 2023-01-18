namespace Sharp8Core.UnitTests;

public class Chip8Test
{
    [Fact]
    public void WithGiveInstructions_ShouldExecuteAndReturnTheNextOne()
    {
        string instructions = "00-E0-1N-NN";
        var memory = new Chip8Memory(new HexInstructions());
        memory.LoadInstructions(instructions);
        var chip8 = new Chip8(memory);

        Assert.Equal("00E0", chip8.ReadInstruction().Item1);
        Assert.Equal("1NNN", chip8.ReadInstruction().Item1);
    }
}
