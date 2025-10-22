namespace Zoo.Animals;

/// <summary>
/// Класс волк
/// </summary>
public class Wolf : Predator
{
    public Wolf(string name, int number, int food, bool isHealthy)
        : base(name, number, food, isHealthy)
    {
    }
}