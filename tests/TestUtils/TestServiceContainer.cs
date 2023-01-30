using Microsoft.Extensions.DependencyInjection;
using Sharp8.Core;
using Sharp8.Core.RomReader;

namespace TestUtils;

public class TestServiceContainer
{
    public static IServiceProvider GetServiceProvider()
    {
        var services = new ServiceCollection();

        services.AddScoped<IChip8, Chip8>();
        services.AddScoped<Chip8Registers>();
        services.AddScoped<IScreen, Chip8Screen>();
        services.AddScoped<IChip8Memory, Chip8Memory>();
        services.AddScoped<IChip8StackList, Chip8StackList>();
        services.AddScoped<Chip8RomReader>();

        return services.BuildServiceProvider();
    }
}
