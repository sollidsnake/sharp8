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
        Console.WriteLine(chip8.Screen.GenGridTableWithBorders());
    }
}
