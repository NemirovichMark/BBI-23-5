using System;
using System.Collections.Generic;
using System.Linq;

abstract class Sportsman
{
    public string Name { get; set; }
    public int Result { get; set; }

    public Sportsman(string name, int result)
    {
        Name = name;
        Result = result;
    }

    public abstract void Display();
}

class SkierGirl : Sportsman
{
    public SkierGirl(string name, int result) : base(name, result) { }

    public override void Display()
    {
        Console.WriteLine($"Гонщица {Name} заняла {Result} место");
    }
}

class SkierBoy : Sportsman
{
    public SkierBoy(string name, int result) : base(name, result) { }

    public override void Display()
    {
        Console.WriteLine($"Гонщик {Name} занял {Result} место");
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Sportsman> skierGirlsGroup1 = new List<Sportsman>
        {
            new SkierGirl("Анна", 2),
            new SkierGirl("Мария", 1),
            new SkierGirl("Елена", 3)
        };

        List<Sportsman> skierGirlsGroup2 = new List<Sportsman>
        {
            new SkierGirl("Ольга", 1),
            new SkierGirl("Ирина", 2),
            new SkierGirl("Татьяна", 3)
        };

        List<Sportsman> skierBoysGroup1 = new List<Sportsman>
        {
            new SkierBoy("Сергей", 3),
            new SkierBoy("Иван", 2),
            new SkierBoy("Петр", 1)
        };

        List<Sportsman> skierBoysGroup2 = new List<Sportsman>
        {
            new SkierBoy("Алексей", 1),
            new SkierBoy("Дмитрий", 2),
            new SkierBoy("Николай", 3)
        };

        List<Sportsman> allParticipants = new List<Sportsman>();
        allParticipants.AddRange(skierGirlsGroup1);
        allParticipants.AddRange(skierGirlsGroup2);
        allParticipants.AddRange(skierBoysGroup1);
        allParticipants.AddRange(skierBoysGroup2);

        Console.WriteLine("Соревнования среди лыжниц - группа 1:");
        foreach (var skierGirl in skierGirlsGroup1)
        {
            skierGirl.Display();
        }

        Console.WriteLine("\nСоревнования среди лыжниц - группа 2:");
        foreach (var skierGirl in skierGirlsGroup2)
        {
            skierGirl.Display();
        }

        Console.WriteLine("\nСоревнования среди лыжников - группа 1:");
        foreach (var skierBoy in skierBoysGroup1)
        {
            skierBoy.Display();
        }

        Console.WriteLine("\nСоревнования среди лыжников - группа 2:");
        foreach (var skierBoy in skierBoysGroup2)
        {
            skierBoy.Display();
        }

        Console.WriteLine("\nОбщие результаты:");
        allParticipants.Sort((x, y) => x.Result.CompareTo(y.Result));
        foreach (var participant in allParticipants)
        {
            participant.Display();
        }
    }
}