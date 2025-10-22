using Zoo.Interfaces;
using Zoo.Animals;

namespace Zoo;

/// <summary>
/// Класс зоопарка
/// </summary>
public class ZooService : IZooService
{
    private readonly IHealthCheckService _health;
    private readonly List<Animal> _animals = new();
    private readonly List<IInventory> _inventory = new();

    public ZooService(IHealthCheckService health)
    {
        _health = health;
    }

    public bool TryAcceptAnimal(Animal animal)
    {
        // проверка ветклиникой
        if (!_health.IsHealthy(animal))
            return false;

        _animals.Add(animal);
        _inventory.Add(animal);

        return true;
    }

    public void AddThing(IInventory thing)
    {
        _inventory.Add(thing);
    }

    public int GetTotalFoodPerDay() => _animals.Sum(a => a.Food);
    public IEnumerable<Animal> GetAnimals() => _animals;

    public IEnumerable<Herbo> GetPettingAnimals()
        => _animals.OfType<Herbo>().Where(h => h.Kindness > 5);

    public IEnumerable<IInventory> GetInventory() => _inventory;
}