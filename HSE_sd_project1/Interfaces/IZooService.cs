namespace Zoo.Interfaces;

using Zoo.Animals;

/// <summary>
/// Интерфейс зоопарков
/// </summary>
public interface IZooService
{
    bool TryAcceptAnimal(Animal animal);               
    void AddThing(IInventory thing);   
    public int GetTotalFoodPerDay();
    IEnumerable<Animal> GetAnimals();                 
    IEnumerable<Herbo> GetPettingAnimals();
    IEnumerable<IInventory> GetInventory();     
}