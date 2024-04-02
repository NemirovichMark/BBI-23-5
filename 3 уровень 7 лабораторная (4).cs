// 4 задание 3 уровень 
using System;
using System.Collections.Generic;

class Sportsman
{
    protected string lastName;
    public float Result { get; protected set; }

    public Sportsman(string lastName, float result)
    {
        this.lastName = lastName;
        this.Result = result;
    }

    public override string ToString()
    {
        return string.Format(
            $"{this.lastName,-10}\t\t{this.Result}"
        );
    }
}

class Skier : Sportsman
{
    public Skier(string lastName, float result) : base(lastName, result) { }
}

class SkierWoman : Skier
{
    public SkierWoman(string lastName, float result) : base(lastName, result) { }
}

class SkierMan : Skier
{
    public SkierMan(string lastName, float result) : base(lastName, result) { }
}

class Program
{
    static void PrintGroupTable(List<Sportsman> group, string groupName)
    {
        group.Sort((x, y) => y.Result.CompareTo(x.Result));

        Console.WriteLine($"{groupName}");
        Console.WriteLine("---------------------------------");

        foreach (var participant in group)
        {
            Console.WriteLine(participant);
        }

        Console.WriteLine();
        
    }

    static void Main(string[] args)
    {
        List<Sportsman> group1Women = new List<Sportsman>
        {
            new SkierWoman("Иванова", 16.1f),
            new SkierWoman("Петрова", 15.9f),
            new SkierWoman("Сидорова", 15.8f),
            new SkierWoman("Козлова", 15.7f),
            new SkierWoman("Смирнова", 15.6f)
        };

        List<Sportsman> group2Women = new List<Sportsman>
        {
            new SkierWoman("Григорьева", 15.4f),
            new SkierWoman("Борисова", 15.3f),
            new SkierWoman("Егорова", 15.2f),
            new SkierWoman("Дмитриева", 15.1f),
            new SkierWoman("Алексеева", 14.9f)
        };

        List<Sportsman> group1Men = new List<Sportsman>
        {
            new SkierMan("Сидоров", 15.7f),
            new SkierMan("Петров", 15.5f),
            new SkierMan("Козлов", 15.3f),
            new SkierMan("Иванов", 15.2f),
            new SkierMan("Смирнов", 15.1f)
        };

        List<Sportsman> group2Men = new List<Sportsman>
        {
            new SkierMan("Борисов", 14.9f),
            new SkierMan("Алексеев", 14.8f),
            new SkierMan("Григорьев", 14.7f),
            new SkierMan("Дмитриев", 14.6f),
            new SkierMan("Егоров", 14.5f)
        };

        List<Sportsman> allParticipants = new List<Sportsman>();
        allParticipants.AddRange(group1Women);
        allParticipants.AddRange(group2Women);
        allParticipants.AddRange(group1Men);
        allParticipants.AddRange(group2Men);

        PrintGroupTable(group1Women, "Женщины-1");
        PrintGroupTable(group2Women, "Женщины-2");
        PrintGroupTable(group1Men, "Мужчины-1");
        PrintGroupTable(group2Men, "Мужчины-2");

        List<Sportsman> allWomen = new List<Sportsman>();
        allWomen.AddRange(group1Women);
        allWomen.AddRange(group2Women);

        List<Sportsman> allMen = new List<Sportsman>();
        allMen.AddRange(group1Men);
        allMen.AddRange(group2Men);

        PrintGroupTable(allWomen, "Общая таблица для женщин");
        PrintGroupTable(allMen, "Общая таблица для мужчин");
        PrintGroupTable(allParticipants, "Общая таблица для всех участников");
    }
}
