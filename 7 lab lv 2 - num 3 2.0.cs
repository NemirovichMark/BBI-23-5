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
    private Sportsmens _sportsmens;
    
    public Discipline(Sportsmens sportsmens)
    {
        _sportsmens = sportsmens;
    }

    public void Print()
    {
        Console.WriteLine($"Discipline: {DisciplineName}");
        _sportsmens.Print();
        Console.WriteLine();
    }
}
public class LongJump : Discipline
{
    public override string DisciplineName => "прыжки в длину";
    public LongJump(Sportsmens sportsmens) : base(sportsmens)
    {

    }

}
public class HightJump : Discipline
{
    public override string DisciplineName => "прыжки в высоту";
    public HightJump(Sportsmens sportsmens) : base(sportsmens)
    {

    }
}


class Program
{
    static void Main()
    {
        Sportsmens[] sportsmens =
        {
            new Sportsmens("Евелькин", 4.9, 5.9, 6.0),
            new Sportsmens("Smith", 5.6, 5.8, 5.7),
            new Sportsmens("Johnson", 5.5, 5.9, 6.1),
            new Sportsmens("Носыч", 4.8, 7.1, 7.0),
            new Sportsmens("Мбапе", 4.9,5.9,6.1)
        };
        Discipline[] discipline =
        {
            new HightJump(sportsmens[0]),
            new LongJump(sportsmens[1]),
            new LongJump(sportsmens[2]),
            new LongJump(sportsmens[3]),
            new HightJump(sportsmens[4])
        };

        Console.WriteLine("Final Results:");
        for (int i = 0; i < discipline.Length; i++)
        {
            discipline[i].Print();
        }

    }
}
