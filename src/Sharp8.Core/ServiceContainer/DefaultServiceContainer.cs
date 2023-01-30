using Microsoft.Extensions.DependencyInjection;
using Sharp8.Core.RomReader;

namespace Sharp8.Core.ServiceContainer;

public static class DefaultServiceContainer
{
    public static ServiceProvider Start()
    {
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddSingleton<IChip8>();
        serviceCollection.AddSingleton<Chip8RomReader>();
        serviceCollection.AddSingleton<Chip8Memory>();

        return serviceCollection.BuildServiceProvider();
    }
}
