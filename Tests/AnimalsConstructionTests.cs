using System;
using Xunit;
using Zoo.Animals;

public class AnimalsConstructionTests
{
    [Fact]
    public void Herbo_Kindness_MustBe_1to10()
    {
        // корректное создание
        var ok = new Rabbit("R", 10, 1, true, 6);
        Assert.Equal(6, ok.Kindness);

        // значения вне диапазона — ожидаем исключение из конструктора
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            new Rabbit("R", 11, 1, true, 0));

        Assert.Throws<ArgumentOutOfRangeException>(() =>
            new Rabbit("R", 12, 1, true, 11));
    }

    [Fact]
    public void Animal_Number_MustBe_Positive_And_Food_NonNegative()
    {
        // ок
        var wolf = new Wolf("W", 20, 5, true);
        Assert.Equal(20, wolf.Number);
        Assert.Equal(5, wolf.Food);

        // Number <= 0 — ожидаем исключение (если у тебя минималка без проверок — можно удалить тест)
        // Ниже тесты предполагают, что в Animal есть валидация. Если у тебя "минималка без валидации",
        // просто удали эти три Assert.Throws.
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            new Tiger("T", 0, 5, true));

        Assert.Throws<ArgumentOutOfRangeException>(() =>
            new Tiger("T", -1, 5, true));

        // Food < 0 — ожидаем исключение
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            new Tiger("T", 21, -1, true));
    }
}