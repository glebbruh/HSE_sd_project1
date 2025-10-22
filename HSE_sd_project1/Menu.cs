using Zoo.Interfaces;
using Zoo.Animals;
using Zoo.Inventory;

namespace Zoo;

/// <summary>
/// Меню
/// </summary>
public class Menu
{
    private readonly IZooService _zoo;

    public Menu(IZooService zoo)
    {
        _zoo = zoo;
    }

    public void Run()
    {
        while (true)
        {
            // Выбор опции
            PrintHeader();
            Console.WriteLine("1 - Добавить животное");
            Console.WriteLine("2 - Добавить вещь");
            Console.WriteLine("3 - Показать всех животных");
            Console.WriteLine("4 - Суммарно еды (кг/сутки)");
            Console.WriteLine("5 - Контактный зоопарк (Herbo с добротой > 5)");
            Console.WriteLine("6 - Показать инвентарь (вещи и животные)");
            Console.WriteLine("0 - Выход");
            Console.Write("Выберите пункт: ");
            var key = Console.ReadLine()?.Trim();

            switch (key)
            {
                case "1": AddAnimal(); break;
                case "2": AddThing(); break;
                case "3": ShowAnimals(); break;
                case "4": ShowTotalFood(); break;
                case "5": ShowPettingAnimals(); break;
                case "6": ShowInventory(); break;
                case "0": return;
                default:
                    Console.WriteLine("Неверный пункт. Нажмите Enter...");
                    Console.ReadLine();
                    break;
            }
        }
    }

    /// <summary>
    /// Вывод заголовка
    /// </summary>
    private static void PrintHeader()
    {
        Console.Clear();
        Console.WriteLine("=== Московский зоопарк — учёт ===");
        Console.WriteLine();
    }

    /// <summary>
    /// Добовление животного в зоопарк
    /// </summary>
    /// <exception cref="Exception">исключение при выполнении (неправильный аргумент)</exception>
    private void AddAnimal()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Добавление животного");
            Console.WriteLine("1 - Rabbit (травоядное)");
            Console.WriteLine("2 - Monkey (травоядное)");
            Console.WriteLine("3 - Tiger (хищник)");
            Console.WriteLine("4 - Wolf  (хищник)");
            Console.Write("Тип: ");
            var t = Console.ReadLine()?.Trim();

            try
            {
                Console.Write("Название: ");
                var name = (Console.ReadLine() ?? "Животное").Trim();

                Console.Write("Инвентарный номер (целое > 0): ");
                var number = int.Parse(Console.ReadLine()!);

                Console.Write("Еда (кг/сутки, целое >= 0): ");
                var food = int.Parse(Console.ReadLine()!);

                Console.Write("Здоров? (y/n): ");
                var yn = (Console.ReadLine() ?? "").Trim().ToLowerInvariant();
                bool isHealthy = yn is "y" ? true : yn is "n" ? false
                        : throw new Exception("Введите y или n.");

                int kindness = 0;
                if (t == "1" || t == "2")
                {
                    Console.Write("Доброта (от 1 до 10): ");
                    kindness = int.Parse(Console.ReadLine()!);
                }

                Animal animal = t switch
                {
                    "1" => new Rabbit(name, number, food, isHealthy, kindness),
                    "2" => new Monkey(name, number, food, isHealthy, kindness),
                    "3" => new Tiger(name, number, food, isHealthy),
                    "4" => new Wolf(name, number, food, isHealthy),
                    _ => throw new Exception("Неизвестный тип животного.")
                };

                var accepted = _zoo.TryAcceptAnimal(animal);
                Console.WriteLine(accepted
                    ? "Животное принято в зоопарк."
                    : "Животное НЕ принято (не прошло проверку здоровья).");
                Console.WriteLine("Нажмите Enter...");
                Console.ReadLine();
                return; // успех → выходим из метода
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.WriteLine("Попробуйте ещё раз. Нажмите Enter...");
                Console.ReadLine();
                // цикл повторится
            }
        }
    }

    /// <summary>
    /// Добавление вещей
    /// </summary>
    /// <exception cref="Exception">неправильный аргумент</exception>
    private void AddThing()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Добавление вещи");
            Console.WriteLine("1 - Table");
            Console.WriteLine("2 - Computer");
            Console.Write("Тип: ");
            var t = Console.ReadLine()?.Trim();

            try
            {
                Console.Write("Наименование: ");
                var name = (Console.ReadLine() ?? "").Trim();

                Console.Write("Инвентарный номер (целое > 0): ");
                var number = int.Parse(Console.ReadLine()!);

                switch (t)
                {
                    case "1":
                        _zoo.AddThing(new Table(number, name));
                        Console.WriteLine("Стол добавлен.");
                        break;
                    case "2":
                        _zoo.AddThing(new Computer(number, name));
                        Console.WriteLine("Компьютер добавлен.");
                        break;
                    default:
                        throw new Exception("Неизвестный тип вещи.");
                }

                Console.WriteLine("Нажмите Enter...");
                Console.ReadLine();
                return; // успех
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.WriteLine("Попробуйте ещё раз. Нажмите Enter...");
                Console.ReadLine();
                // цикл повторится
            }
        }
    }

    /// <summary>
    /// Показать всех животных
    /// </summary>
    private void ShowAnimals()
    {
        Console.Clear();
        Console.WriteLine("Все животные:");
        var any = false;
        foreach (var a in _zoo.GetAnimals())
        {
            any = true;
            Console.WriteLine(
                $"- {a.GetType().Name} #{a.Number} \"{a.Name}\", еда: {a.Food} кг/сут, здоров: {a.IsHealthy}");
        }

        if (!any) Console.WriteLine("(пока нет животных)");
        Console.WriteLine("\nНажмите Enter...");
        Console.ReadLine();
    }

    /// <summary>
    /// Показать, сколько всего еды нужно всем животным зоопарка
    /// </summary>
    private void ShowTotalFood()
    {
        Console.Clear();
        var total = _zoo.GetTotalFoodPerDay();
        Console.WriteLine($"Суммарно требуется еды: {total} кг/сут.");
        Console.WriteLine("\nНажмите Enter...");
        Console.ReadLine();
    }

    /// <summary>
    /// Животные, которых можно отправить в контактный зоопарк
    /// </summary>
    private void ShowPettingAnimals()
    {
        Console.Clear();
        Console.WriteLine("Контактный зоопарк:");
        var any = false;
        foreach (var h in _zoo.GetPettingAnimals())
        {
            any = true;
            Console.WriteLine($"- {h.GetType().Name} #{h.Number} \"{h.Name}\", Kindness: {h.Kindness}");
        }

        if (!any) Console.WriteLine("(подходящих нет)");
        Console.WriteLine("\nНажмите Enter...");
        Console.ReadLine();
    }

    /// <summary>
    /// Все предметы зоопарка
    /// </summary>
    private void ShowInventory()
    {
        Console.Clear();
        Console.WriteLine("Инвентарь (вещи и животные):");
        var any = false;
        foreach (var i in _zoo.GetInventory())
        {
            any = true;
            var nameProp = i.GetType().GetProperty("Name");
            var nameVal = nameProp != null ? nameProp.GetValue(i) as string : null;
            if (!string.IsNullOrWhiteSpace(nameVal))
            {
                Console.WriteLine($"- #{i.Number} {i.GetType().Name}: \"{nameVal}\"");
            }
            else
            {
                Console.WriteLine($"- #{i.Number} {i.GetType().Name}");
            }
        }

        if (!any) Console.WriteLine("(инвентарь пуст)");
        Console.WriteLine("\nНажмите Enter...");
        Console.ReadLine();
    }
}