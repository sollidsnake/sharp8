namespace Sharp8Core;

using Microsoft.Extensions.DependencyInjection;

public static class Startup
{
    public static IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        return services.BuildServiceProvider();
    }
}
