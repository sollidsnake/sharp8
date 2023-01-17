using Sharp8Core;

namespace Sharp8CoreIntegrationTests;

public abstract class TestBase
{
    public TestBase()
    {
        Startup.ConfigureServices();
    }
}
