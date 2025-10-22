using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Zoo;
using Zoo.Interfaces;

public class DITests
{
    [Fact]
    public void CanResolve_ZooService_And_Menu_FromContainer()
    {
        var services = new ServiceCollection();
        services.AddTransient<IHealthCheckService, VetClinic>();
        services.AddSingleton<IZooService, ZooService>();
        services.AddTransient<Menu>();

        using var provider = services.BuildServiceProvider();
        Assert.NotNull(provider.GetRequiredService<IZooService>());
        Assert.NotNull(provider.GetRequiredService<Menu>());
    }
}