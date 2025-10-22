namespace Zoo.Animals;

/// <summary>
/// Класс тигра
/// </summary>
public class Tiger : Predator
{
    public Tiger(string name, int number, int food, bool isHealthy)
        : base(name, number, food, isHealthy)
    {
    }
}