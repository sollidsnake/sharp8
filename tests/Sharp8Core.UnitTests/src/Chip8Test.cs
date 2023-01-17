using Sharp8Core.RomReader;
using Moq;
using System.IO.Abstractions;

namespace Sharp8Core.UnitTests;

public class Chip8Test
{
    [Fact]
    public void WithGiveInstructions_ShouldExecuteAndReturnTheNextOne()
    {
        string instructions = "00-E0-1N-NN";
        var hexInstructions = new HexInstructions();
        var memory = new Chip8Memory(
            hexInstructions.LoadInstructions(instructions)
        );
        var chip8 = new Chip8(memory);

        Assert.Equal("00E0", chip8.ReadInstruction().Item1);
        Assert.Equal("1NNN", chip8.ReadInstruction().Item1);
    }
}
