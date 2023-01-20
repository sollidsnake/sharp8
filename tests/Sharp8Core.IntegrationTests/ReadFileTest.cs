using System.IO.Abstractions;
using Sharp8Core.RomReader;

namespace Sharp8Core.IntegrationTests;

public class ReadFileTest
{
    private static readonly string IbmLogoPath = Path.Combine(
        AppDomain.CurrentDomain.BaseDirectory,
        "..",
        "..",
        "..",
        "..",
        "..",
        "tests",
        "assets",
        "ibmlogo.ch8"
    );

    [Fact]
    public void GivenIBMLogoFile_ShouldReadItsContents()
    {
        var filepath = IbmLogoPath;

        var romReader = new Chip8RomReader(new FileSystem());
        var memory = new Chip8Memory(new Chip8Registers());
        var chip8 = new Chip8(memory, romReader);

        chip8.LoadRom(filepath);

        Assert.Equal(0x00, chip8.Memory.GetByteAtAddress(0x200));
        Assert.Equal(0xE0, chip8.Memory.GetByteAtAddress(0x200 + 1));
        Assert.Equal(0xA2, chip8.Memory.GetByteAtAddress(0x200 + 2));
        Assert.Equal(0x2A, chip8.Memory.GetByteAtAddress(0x200 + 3));
        Assert.Equal(0x60, chip8.Memory.GetByteAtAddress(0x200 + 4));
        Assert.Equal(0x0C, chip8.Memory.GetByteAtAddress(0x200 + 5));
        Assert.Equal(0xE0, chip8.Memory.GetByteAtAddress(0x200 + 82));
        Assert.Equal(0x00, chip8.Memory.GetByteAtAddress(0x200 + 83));
    }

    [Fact]
    public void GivenIBMLogoFile_ShouldReadItsInstructions()
    {
        var filepath = IbmLogoPath;
        var romReader = new Chip8RomReader(new FileSystem());
        var memory = new Chip8Memory(new Chip8Registers());
        var chip8 = new Chip8(memory, romReader);
        chip8.LoadRom(filepath);

        Assert.Equal(0x00E0, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0xA22A, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0x22A, chip8.Memory.PointingAddress);
        Assert.Equal(0x600C, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0x0C, chip8.Memory.Registers.GetRegisterValue(0));
    }
}
