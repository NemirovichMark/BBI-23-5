
using System;

struct Lizhniki
{
    private string surname;
    private int result;

    public Lizhniki(string n, int r)
    {
        surname = n;
        result = r;
    }

    public static void SortByResult(Lizhniki[] lizhniki)
    {
        int n = lizhniki.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (lizhniki[j].result > lizhniki[j + 1].result)
                {
                    Lizhniki temp = lizhniki[j];
                    lizhniki[j] = lizhniki[j + 1];
                    lizhniki[j + 1] = temp;
                }
            }
        }
    }

    public static void PrintResults(Lizhniki[] lizhniki)
    {
        Console.WriteLine("surname\tResult");
        foreach (var l in lizhniki)
        {
            Console.WriteLine($"{l.surname}\t{l.result}");
        }
    }
}

class Program
{
    static void Main()
    {
        Lizhniki[] group1 = {
            new Lizhniki("Иванов", 30),
            new Lizhniki("Петров", 25),
            new Lizhniki("Сидоров", 28)
        };

        Lizhniki[] group2 = {
            new Lizhniki("Смирнов", 27),
            new Lizhniki("Козлов", 26),
            new Lizhniki("Морозов", 29)
        };

        Lizhniki.SortByResult(group1);
        Lizhniki.SortByResult(group2);

        Console.WriteLine("Группа 1:");
        Lizhniki.PrintResults(group1);

        Console.WriteLine("\nГруппа 2:");
        Lizhniki.PrintResults(group2);

        Console.WriteLine("\nОбщий результат:");
        Lizhniki[] allResults = new Lizhniki[group1.Length + group2.Length];
        Array.Copy(group1, allResults, group1.Length);
        Array.Copy(group2, 0, allResults, group1.Length, group2.Length);
        Lizhniki.SortByResult(allResults);
        Lizhniki.PrintResults(allResults);
    }
}