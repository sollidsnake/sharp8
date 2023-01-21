using System.IO.Abstractions;
using Sharp8Core.Instructions;
using Sharp8Core.RomReader;

namespace Sharp8Core.UnitTests;

public class InstructionDrawSpriteTest
{
    [Fact]
    public void WithExecute_ShouldDrawPixelsOnExpectedPositions()
    {
        IScreen screen = new Chip8Screen();
        var memory = new Chip8Memory(new Chip8Registers());
        var mockFileSystem = new Moq.Mock<IFileSystem>();
        var romReader = new Chip8RomReader(mockFileSystem.Object);
        var chip8 = new Chip8(screen, memory, romReader);
        memory.LoadRom(new byte[] { 0xff, 0x00, 0xff });
        memory.IRegisterAddress = 0x200;

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
}
