using Zoo.Interfaces;

namespace Zoo.Animals;

/// <summary>
/// Класс животных
/// </summary>
public abstract class Animal : IAlive, IInventory
{
    protected Animal(string name, int number, int food, bool isHealthy)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Empty name");
        }

        if (number <= 0)
        {
            throw new ArgumentOutOfRangeException();
        }

        if (food < 0)
        {
            throw new ArgumentOutOfRangeException();
        }
        Name = name;
        Number = number;
        Food = food;
        IsHealthy = isHealthy;
    }
    
    public string Name { get; }
    public int Number { get; }
    public int Food { get; }
    public bool IsHealthy { get; }
}