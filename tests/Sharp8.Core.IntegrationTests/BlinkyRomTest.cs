using TestUtils;
using Microsoft.Extensions.DependencyInjection;

namespace Sharp8.Core.IntegrationTests;

public class BlinkyRomTest
{
    [Fact]
    public void WithBlinkyRom_ShouldReadAndExecuteItsInstructions()
    {
        var romBytes = File.ReadAllBytes(
            "../../../../../roms/Blinky [Hans Christian Egeberg, 1991].ch8"
        );

        var serviceProvider = TestServiceContainer.GetServiceProvider();

        var chip8 = serviceProvider.GetService<IChip8>()!;

        chip8.LoadRom(romBytes);
        Assert.Equal(0x121a, chip8.ExecuteNextInstruction().Code);
        Assert.Equal(0x8003, chip8.ExecuteNextInstruction().Code);
    }
}
