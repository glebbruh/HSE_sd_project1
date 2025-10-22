using System;
using Zoo.Animals;
using Zoo.Interfaces;
using Zoo.Inventory;
using Microsoft.Extensions.DependencyInjection;

namespace Zoo;

/// <summary>
/// Основная программа
/// </summary>
internal class Program
{
    public static void Main()
    {
        var services = new ServiceCollection();
        services.AddSingleton<IHealthCheckService, VetClinic>();
        services.AddSingleton<IZooService, ZooService>();
        services.AddTransient<Menu>();
        
        
        var provider = services.BuildServiceProvider();
        var menu = provider.GetRequiredService<Menu>();
        menu.Run(); // Запуск меню
    }
}