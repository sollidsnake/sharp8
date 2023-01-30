
namespace Sharp8.Core.UnitTests;

public class Chip8ScreenTest
{
    [Theory]
    [InlineData(
        56,
        new bool[] { false, false, true, true, true, false, false, false }
    )]
    [InlineData(
        255,
        new bool[] { true, true, true, true, true, true, true, true }
    )]
    public void DrawSpriteLine_ShouldExtractCorrectlyFromBinary(
        int sprite,
        bool[] expected
    )
    {
        var screen = new Chip8Screen();

        screen.DrawSpriteLine(0, 0, sprite);

        for (int i = 0; i < expected.Length; i++)
        {
            Assert.True(
                expected[i] == screen.GetPixel(i, 0),
                $"Pixel {i} should be {expected[i]} for number {sprite}"
            );
        }
    }

    [Fact]
    public void DrawSpriteLine_ShouldReturnTrueIfPixelIsFlipped()
    {
        IScreen screen = new Chip8Screen();

        screen.DrawSpriteLine(0, 0, 0b11111111);
        Assert.True(screen.DrawSpriteLine(0, 0, 0b10000000));
        Assert.False(screen.GetPixel(0, 0));
    }
}
