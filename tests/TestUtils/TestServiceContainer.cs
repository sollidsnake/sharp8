using Microsoft.Extensions.DependencyInjection;
using Sharp8Core;
using Sharp8Core.RomReader;

namespace TestUtils;

public class TestServiceContainer
{
    public static IServiceProvider GetServiceProvider()
    {
        var services = new ServiceCollection();

        services.AddScoped<IChip8, Chip8>();
        services.AddScoped<Chip8Registers>();
        services.AddScoped<IScreen, Chip8Screen>();
        services.AddScoped<Chip8Memory>();
        services.AddScoped<Chip8RomReader>();

        return services.BuildServiceProvider();
    }
}
