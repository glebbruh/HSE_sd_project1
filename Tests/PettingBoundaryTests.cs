using System.Linq;
using Xunit;
using Zoo;
using Zoo.Animals;

public class PettingBoundaryTests
{
    [Fact]
    public void Kindness_Equal5_IsNotIncluded_But6_IsIncluded()
    {
        var zoo = new ZooService(new VetClinic());
        _ = zoo.TryAcceptAnimal(new Rabbit("R5", 501, 1, true, 5)); // не должен попасть
        _ = zoo.TryAcceptAnimal(new Rabbit("R6", 502, 1, true, 6)); // должен попасть

        var petting = zoo.GetPettingAnimals().ToList();
        Assert.Single(petting);
        Assert.Equal(502, petting[0].Number);
    }
}