using Sharp8Core;

namespace Sharp8CoreUnitTests;

public class HexInstructionsTest
{
    [Fact]
    public void WithGivenHexString_ShouldStoreCorrectly()
    {
        string instructions = "00-01-02-03";
        var expected = new List<string> { "0001", "0203" };
        var hexInstructions = new HexInstructions();

        hexInstructions.LoadInstructions(instructions);

        Assert.Equal(expected, hexInstructions.Instructions);
    }
}
