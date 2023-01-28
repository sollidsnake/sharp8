using Sharp8Core.Instructions;

namespace Sharp8Core.UnitTests;

public class InstructionDrawSpriteTest
{
    [Fact]
    public void WithExecute_ShouldDrawPixelsOnExpectedPositions()
    {
        IScreen screen = new Chip8Screen();
        var memory = new Chip8Memory();
        var chip8 = new Chip8(screen, memory, new Chip8Stack());
        memory.LoadRom(new byte[] { 0xff, 0x00, 0xff });
        chip8.IRegister = 0x200;

        var instruction = new InstructionDrawSprite();
        instruction.Execute(chip8, 0xd004);

        for (int i = 0; i < 64; i++)
        {
            if (i < 8)
            {
                Assert.True(screen.GetPixel(i, 0));
                continue;
            }
            Assert.False(screen.GetPixel(i, 0));
        }
        for (int i = 0; i < 64; i++)
        {
            Assert.False(screen.GetPixel(i, 1));
        }
        for (int i = 0; i < 64; i++)
        {
            if (i < 8)
            {
                Assert.True(screen.GetPixel(i, 2));
                continue;
            }
            Assert.False(screen.GetPixel(i, 2));
        }
    }

    [Fact]
    public void WithExecute_ShouldSetVfTo01IfPixelsAreFlipped()
    {
        IScreen screen = new Chip8Screen();
        var memory = new Chip8Memory();
        var chip8 = new Chip8(screen, memory, new Chip8Stack());
        memory.LoadRom(new byte[] { 0xff, 0x00, 0xff });
        chip8.IRegister = 0x200;
        screen.DrawSpriteLine(0, 0, 0xf);

        new InstructionDrawSprite().Execute(chip8, 0xd004);

        Assert.Equal(1, chip8.Registers.GetValue(0xf));
    }
}
