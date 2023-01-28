using TestUtils;
using Microsoft.Extensions.DependencyInjection;

namespace Sharp8Core.IntegrationTests;

public class PongRomTest
{
    [Fact]
    public void WithPongRom_ShouldReadAndExecuteItsInstructions()
    {
        var romBytes = File.ReadAllBytes(
            "../../../../../roms/Pong (1 player).ch8"
        );
        var serviceProvider = TestServiceContainer.GetServiceProvider();
        var chip8 = serviceProvider.GetService<IChip8>()!;
        chip8.LoadRom(romBytes);

        Assert.Equal(0x6a02, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0x6b0c, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0x6c3f, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0x6d0c, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0xa2ea, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0xdab6, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0xdcd6, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0x6e00, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0x22d4, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0xa2f2, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0xfe33, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0xf265, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0xf129, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0x6414, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0x6500, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0xd455, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0x7415, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0xf229, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0xd455, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0x00ee, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0x6603, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0x6802, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0x6060, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0xf015, chip8.ExecuteNextInstruction().Code);
        for (var i = 0; i <= 0x60; i++)
        {
            Assert.Equal(0xf007, chip8.ExecuteNextInstruction().Code);
            Assert.Equal(0x3000, chip8.ExecuteNextInstruction().Code);
            if (i < 0x60)
            {
                Assert.Equal(0x121a, chip8.ExecuteNextInstruction().Code);
            }
            chip8.TickTimers();
        }

        Assert.Equal(0xC717, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0x7708, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0x69ff, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0xa2f0, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0xd671, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0xa2ea, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0xdab6, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0xdcd6, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0x6001, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0xe0a1, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0x6004, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0xe0a1, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0x601f, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0x8b02, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0xdab6, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0x8d70, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0xc00a, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0x7dfe, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0x4000, chip8.ExecuteNextInstruction().Code);

        // Assert.Equal(0x7708, chip8.ExecuteNextInstruction().Code);
    }

    [Fact]
    public void WithVyOn0_ShouldSwitchDirection()
    {
        var romBytes = File.ReadAllBytes(
            "../../../../../roms/Pong (1 player).ch8"
        );
        var serviceProvider = TestServiceContainer.GetServiceProvider();
        var chip8 = serviceProvider.GetService<IChip8>()!;
        chip8.LoadRom(romBytes);
        chip8.ProgramCounter = 0x25A;
        chip8.Registers.SetVIndex(0x7, 0x00);
        chip8.Registers.SetVIndex(0x9, 0x01);

        Assert.Equal(0x8794, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(1, chip8.Registers[0x7]);
    }
}
