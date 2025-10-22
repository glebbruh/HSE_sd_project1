using Zoo.Interfaces;

namespace Zoo.Inventory;

/// <summary>
/// Класс вещей
/// </summary>
public abstract class Thing : IInventory
{
    public Thing(int number, string name)
    {
        Number = number;
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException(nameof(name));
        }
        Name = name;
    }
    public string Name { get; }
    public int Number { get; }
}