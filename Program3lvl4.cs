using System;
abstract class Player
{
    protected string _famile;
    protected double _result;
    public double Result => _result;
    public Player(string famile, double result)
    {
        _famile = famile;
        _result = result;
    }
    public virtual void Print()
    {
        Console.WriteLine("Фамилия   {0}\t Результат {1:f2}\t ",
                        _famile, _result);
    }
}
class FemaleSkier : Player
{
    public FemaleSkier(string famile, double result) : base(famile, result)
    {

    }
    public override void Print()
    {
        Console.WriteLine("Фамилия   {0}\t Женщина Результат {1:f2}\t",
                        _famile, _result);
    }
}
class Skier : Player
{
    public Skier(string famile, double result) : base(famile, result)
    {
    }
    public override void Print()
    {
        Console.WriteLine("Фамилия   {0}\t Мужчина Результат {1:f2}\t ",
                        _famile, _result );
    }
}
class Program
{
    static void Main()
    {
        Player[] c1 = new Player[10];
        FemaleSkier[] woman = new FemaleSkier[5];
        woman[0] = new FemaleSkier("Иванова", 15.38);
        woman[1] = new FemaleSkier("Петрова", 16.54);
        woman[2] = new FemaleSkier("Купцова", 13.51);
        woman[3] = new FemaleSkier("Аксенова", 11.22);
        woman[4] = new FemaleSkier("Кузинина", 18.24);

        Skier[] man = new Skier[5];
        man[0] = new Skier("Кравцов", 19.41);
        man[1] = new Skier("Павленко", 15.38);
        man[2] = new Skier("Еремин", 15.11);
        man[3] = new Skier("Никонов", 14.26);
        man[4] = new Skier("Сидоровов", 12.41);
        //Упорядочение по результатам
        Sorting(woman);
        Sorting(man);
        Console.WriteLine("Лыжницы");
        foreach (var player in woman)
        {
            player.Print();
        }
        Console.WriteLine("Лыжники");
        foreach (var player in man)
        {
            player.Print();
        }
        for (int i = 0; i < woman.Length; i++)
        {
            c1[i] = woman[i];
        }
        for (int i = 0; i < man.Length; i++)
        {
            c1[i + woman.Length] = man[i];
        }
        Console.WriteLine();
        Sorting(c1);
        Console.WriteLine();
        Console.WriteLine("Общий рейтинг");
        foreach (var player in c1)
        {
            player.Print();
        }
    }
    static void Sorting(Player[] s)
    {
        int n = s.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (s[j].Result > s[j + 1].Result)
                {
                    Player temp = s[j];
                    s[j] = s[j + 1];
                    s[j + 1] = temp;
                }
            }
        }
    }
}
