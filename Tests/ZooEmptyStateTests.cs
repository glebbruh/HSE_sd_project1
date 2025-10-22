using Xunit;
using Zoo;

public class ZooEmptyStateTests
{
    [Fact]
    public void NewZoo_HasNoAnimals_AndZeroFood()
    {
        var zoo = new ZooService(new VetClinic());
        Assert.Empty(zoo.GetAnimals());
        Assert.Equal(0, zoo.GetTotalFoodPerDay());
        Assert.Empty(zoo.GetInventory());
    }
}