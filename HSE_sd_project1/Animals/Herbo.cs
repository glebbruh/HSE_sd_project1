namespace Zoo.Animals;

/// <summary>
/// Класс травоядных
/// </summary>
public abstract class Herbo : Animal
{
    protected Herbo(string name, int number, int food, bool isHealthy, int kindness) : base(name, number, food, isHealthy)
    {
        if (kindness <= 0 || kindness > 10)
        {
            throw new ArgumentOutOfRangeException(nameof(kindness));
        }
        Kindness = kindness;
    }

    public int Kindness { get; }
}