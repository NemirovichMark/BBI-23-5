//lv2 num 3 лаба 7

using System;

public class  Sportsmens
{
    private string _lastname;
    private double result1;
    private double result2;
    private double result3;
    public Sportsmens(string lastname, double res1, double res2, double res3)
    {
        _lastname = lastname;
        result1 = res1;
        result2 = res2;
        result3 = res3;
    }
    public string Lastname()
    {
        return _lastname;
    }

    public double Bestresult()
    {
        return Math.Max(result1, Math.Max(result2, result3));
    }
    public void Print()
    {
        Console.WriteLine($"Sportsmens: {Lastname()}");
        Console.WriteLine($"Best result: {Bestresult()}");
        Console.WriteLine();
    }
}
public abstract class Discipline
{
    public abstract string DisciplineName { get; }
    private Sportsmens[] _sportsmens;
    
    public Discipline(Sportsmens[] sportsmens)
    {
        _sportsmens = sportsmens;

    }

    public void Print()
    {
       
        Console.WriteLine($"Discipline: {DisciplineName}");
        foreach(var sportsmen in _sportsmens)
        {
            sportsmen.Print();
        }
        Console.WriteLine();

    }
}
public class LongJump : Discipline
{
    public override string DisciplineName => "прыжки в длину";
    public LongJump(Sportsmens [] sportsmens) : base(sportsmens)
    {

    }

}
public class HightJump : Discipline
{
    public override string DisciplineName => "прыжки в высоту";
    public HightJump(Sportsmens[] sportsmens) : base(sportsmens)
    {

    }
}


class Program
{
    static void Main()
    {
        Sportsmens[] longJump =
        {
            new Sportsmens("Евелькин", 4.9, 5.9, 6.0),
            new Sportsmens("Smith", 5.6, 5.8, 5.7),
            new Sportsmens("Johnson", 5.5, 5.9, 6.1),
            new Sportsmens("Носыч", 4.8, 7.1, 7.0),
            new Sportsmens("Мбапе", 4.9,5.9,6.1)
        };
        Sportsmens[] hightJump =
        {
            new Sportsmens("Олег", 1.5, 1.1, 1.0),
            new Sportsmens("Богдан Федунь", 2.0, 0.8, 2.0),
            new Sportsmens("Кунгуров", 1.5, 0.9, 2.1),
            new Sportsmens("Сацик", 1.8, 1.1, 2.0),
            new Sportsmens("Месси", 1.9,1.9,2.1)
        };
        Discipline[] disciplines =
        {
            new HightJump(hightJump),
            new LongJump(longJump)
        };

        Console.WriteLine("Final Results:");
        for (int i = 0; i < disciplines.Length; i++)
        {
            disciplines[i].Print();
        }

    }
}
