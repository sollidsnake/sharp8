using System.IO.Abstractions;
using Sharp8.Core.RomReader;

namespace Sharp8.Core.IntegrationTests;

public class IbmRomTest
{
    private static readonly string IbmLogoPath = Path.Combine(
        AppDomain.CurrentDomain.BaseDirectory,
        "..",
        "..",
        "..",
        "..",
        "..",
        "roms",
        "ibmlogo.ch8"
    );

    [Fact]
    public void GivenIBMLogoFile_ShouldReadItsContents()
    {
        var filepath = IbmLogoPath;

        var romReader = new Chip8RomReader(new FileSystem());
        var memory = new Chip8Memory();
        var screen = new Chip8Screen();
        var chip8 = new Chip8(screen, memory, new Chip8StackList());
        chip8.LoadRom(File.ReadAllBytes(filepath));

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
        var memory = new Chip8Memory();
        var screen = new Chip8Screen();
        var chip8 = new Chip8(screen, memory, new Chip8StackList());
        chip8.LoadRom(File.ReadAllBytes(filepath));

        Assert.Equal(0x00E0, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0xA22A, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0x22A, chip8.Registers.I);
        Assert.Equal(0xff, chip8.IRegisterValue);
        Assert.Equal(0x600C, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0x0C, chip8.Registers.GetValue(0));
        Assert.Equal(0x6108, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0x08, chip8.Registers.GetValue(1));
        Assert.Equal(0xd01f, chip8.ExecuteNextInstruction().Code);

        Assert.Equal(0x7009, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(21, chip8.Registers.GetValue(0));
        Assert.Equal(8, chip8.Registers.GetValue(1));
        Assert.Equal(0xa239, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0x239, chip8.Registers.I);
        Assert.Equal(0xff, chip8.IRegisterValue);
        Assert.Equal(0xd01f, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0xa248, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0x7008, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0xD01F, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0x7004, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0xa257, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0xD01F, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0x7008, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0xA266, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0xd01f, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0x7008, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0xa275, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0xd01f, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0x1228, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0x228, chip8.ProgramCounter);
        Assert.Equal(0x1228, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0x1228, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0x1228, chip8.ExecuteNextInstruction().Code);
    }
}
