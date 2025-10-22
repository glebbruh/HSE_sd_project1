namespace Zoo.Animals;

/// <summary>
/// Класс обезьяна
/// </summary>
public class Monkey : Herbo
{
    public Monkey(string name, int number, int food, bool isHealthy, int kindness)
        : base(name, number, food, isHealthy, kindness)
    {
    }
}