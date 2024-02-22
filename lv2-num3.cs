//lv2 num 3

using System;
using System.Xml.Linq;

struct Sportsmens
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

class Program
{
    static void Main()
    {

        Sportsmens[] sportsmens = {
        new Sportsmens("Евелькин", 4.9, 5.9, 6.0),
        new Sportsmens("Smith", 5.6, 5.8, 5.7),
        new Sportsmens("Johnson", 5.5, 5.9, 6.1),
        new Sportsmens("Носыч", 4.8, 7.1, 7.0),
        new Sportsmens("Мбапе", 4.9,5.9,6.1)
    };

        Console.WriteLine("Final Results:");
        for (int i = 0; i < sportsmens.Length; i++)
        {
            sportsmens[i].Print();
        }

    }
}


