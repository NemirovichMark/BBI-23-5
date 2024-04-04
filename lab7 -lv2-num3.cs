//lv2 num 3 лаба 7

using System;
using System.Xml.Linq;

class Sportsmens
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
    private string _lastname;
    private double result1;
    private double result2;
    private double result3;
    public Discipline(string lastname, double res1, double res2, double res3)
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
        Console.WriteLine($"Discipline: {DisciplineName}");
        Console.WriteLine($"Sportsmens: {Lastname()}");
        Console.WriteLine($"Best result: {Bestresult()}");
        Console.WriteLine();
    }
}
public class LongJump : Discipline
{
    public override string DisciplineName => "прыжки в длину";
    public LongJump(string lastname, double res1, double res2, double res3) : base(lastname, res1, res2, res3)
    {

    }

}
public class HightJump : Discipline
{
    public override string DisciplineName => "прыжки в высоту";
    public HightJump(string lastname, double res1, double res2, double res3) : base(lastname, res1, res2, res3)
    {

    }
}


class Program
{
    static void Main()
    {

        Discipline[] sportsmens = {
        new HightJump("Евелькин", 4.9, 5.9, 6.0),
        new LongJump("Smith", 5.6, 5.8, 5.7),
        new LongJump("Johnson", 5.5, 5.9, 6.1),
        new LongJump("Носыч", 4.8, 7.1, 7.0),
        new HightJump("Мбапе", 4.9,5.9,6.1)
    };

        Console.WriteLine("Final Results:");
        for (int i = 0; i < sportsmens.Length; i++)
        {
            sportsmens[i].Print();
        }

    }
}