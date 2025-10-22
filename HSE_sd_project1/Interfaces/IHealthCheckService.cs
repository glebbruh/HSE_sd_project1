using Zoo.Animals;

namespace Zoo.Interfaces;

/// <summary>
/// Интерфейс орагнизаций, проверяющих здоровье
/// </summary>
public interface IHealthCheckService
{
    bool IsHealthy(Animal animal);
}