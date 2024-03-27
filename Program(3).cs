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

class SkierMan : Sportsman
{
    public SkierMan(string lastName, float result) : base(lastName, result) { }
}

class SkierWoman : Sportsman
{
    public SkierWoman(string lastName, float result) : base(lastName, result) { }
}

class Program
{
    static void Main(string[] args)
    {
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

        List<Sportsman> allParticipants = new List<Sportsman>();
        allParticipants.AddRange(group1Men);
        allParticipants.AddRange(group2Men);
        allParticipants.AddRange(group1Women);
        allParticipants.AddRange(group2Women);

        Console.WriteLine("Участник\t\tРезультат");
        Console.WriteLine("---------------------------------");

        foreach (var participant in allParticipants)
        {
            Console.WriteLine(participant);
        }
    }
}
