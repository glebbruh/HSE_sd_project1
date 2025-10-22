using System.Linq;
using Xunit;
using Zoo;
using Zoo.Animals;
using Zoo.Interfaces;
using Zoo.Inventory;

public class ZooServiceTests
{
    private static IZooService CreateZoo() => new ZooService(new VetClinic());

    [Fact]
    public void TryAcceptAnimal_Accepts_OnlyHealthy()
    {
        var zoo = CreateZoo();
        var rabbitHealthy = new Rabbit("Кроха", 101, 2, true, 7);
        var rabbitSick    = new Rabbit("Боб",   102, 3, false, 8);

        var ok1 = zoo.TryAcceptAnimal(rabbitHealthy);
        var ok2 = zoo.TryAcceptAnimal(rabbitSick);

        Assert.True(ok1);
        Assert.False(ok2);

        var animals = zoo.GetAnimals().ToList();
        Assert.Single(animals);
        Assert.Equal(101, animals[0].Number);
    }

    [Fact]
    public void GetTotalFoodPerDay_SumsFood_OfAcceptedAnimalsOnly()
    {
        var zoo = CreateZoo();
        _ = zoo.TryAcceptAnimal(new Rabbit("R1", 201, 2,  true, 6)); // учитывается
        _ = zoo.TryAcceptAnimal(new Tiger ("T1", 202, 10, true));     // учитывается
        _ = zoo.TryAcceptAnimal(new Monkey("M1", 203, 3,  false, 8)); // НЕ учитывается (не принят)

        var total = zoo.GetTotalFoodPerDay();
        Assert.Equal(12, total);
    }

    [Fact]
    public void GetPettingAnimals_Returns_OnlyHealthyHerbo_WithKindnessGreaterThan5()
    {
        var zoo = CreateZoo();
        _ = zoo.TryAcceptAnimal(new Rabbit("R1", 301, 2, true, 6));  // да
        _ = zoo.TryAcceptAnimal(new Rabbit("R2", 302, 2, true, 5));  // нет (<=5)
        _ = zoo.TryAcceptAnimal(new Monkey("M1", 303, 3, false, 9)); // не принят
        _ = zoo.TryAcceptAnimal(new Tiger ("T1", 304,10, true));     // хищник — не Herbo

        var petting = zoo.GetPettingAnimals().ToList();

        Assert.Single(petting);
        Assert.Equal(301, petting[0].Number);
    }

    [Fact]
    public void Inventory_Includes_Things_And_AcceptedAnimals()
    {
        var zoo = CreateZoo();

        // вещи
        zoo.AddThing(new Table(401, "Стол"));
        zoo.AddThing(new Computer(402, "ПК"));

        // животные
        _ = zoo.TryAcceptAnimal(new Rabbit("R1", 403, 2, true, 7));   // будет в инвентаре
        _ = zoo.TryAcceptAnimal(new Monkey("M1", 404, 3, false, 8));  // не принят → не в инвентаре

        var inv = zoo.GetInventory().OrderBy(x => x.Number).ToList();
        Assert.Equal(3, inv.Count);
        Assert.Equal(new[] { 401, 402, 403 }, inv.Select(i => i.Number).ToArray());
    }
}