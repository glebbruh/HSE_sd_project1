using Zoo.Animals;
using Zoo.Interfaces;

namespace Zoo;

/// <summary>
/// Класс вет клиники
/// </summary>
public class VetClinic : IHealthCheckService
{
    public bool IsHealthy(Animal animal) => animal.IsHealthy;
}