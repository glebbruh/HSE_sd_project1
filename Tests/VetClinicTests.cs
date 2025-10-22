using Xunit;
using Zoo;
using Zoo.Animals;

public class VetClinicTests
{
    [Fact]
    public void VetClinic_Uses_Animal_IsHealthy_Flag()
    {
        var vet = new VetClinic();
        var r1 = new Rabbit("A", 1, 2, true, 7);
        var r2 = new Rabbit("B", 2, 3, false, 8);

        Assert.True(vet.IsHealthy(r1));
        Assert.False(vet.IsHealthy(r2));
    }
}