namespace Zoo.Animals;

/// <summary>
/// Класс кролика
/// </summary>
public class Rabbit : Herbo
{
    public Rabbit(string name, int number, int food, bool isHealthy, int kindness)
        : base(name, number, food, isHealthy, kindness)
    {
    }
}