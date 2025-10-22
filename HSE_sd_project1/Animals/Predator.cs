namespace Zoo.Animals;

/// <summary>
/// Класс хищника
/// </summary>
public abstract class Predator : Animal
{
    protected Predator(string name, int number, int food, bool isHealthy) : base(name, number, food, isHealthy)
    {
    }
}