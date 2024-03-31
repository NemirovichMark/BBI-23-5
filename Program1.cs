using System;
struct Player
{
    private string _famile;
    private double _result;
    private int _id;
    public double Result => _result;
    public int Id => _id;
    public Player(string famile, double result, int id)
    {
        _famile = famile;
        _result = result;
        _id = id;
    }
    public void Print()
    {
        Console.WriteLine("Фамилия   {0}\t Результат {1:f2}\t ",
                        _famile, _result);
    }
}
class Program
{
    static void Main()
    {
        Player[] c1 = new Player[10];
        c1[0] = new Player("Кардаш", 15.38, 1);
        c1[1] = new Player("Петров", 16.54, 2);
        c1[2] = new Player("Кунгуров", 13.51, 1);
        c1[3] = new Player("Аксенова", 11.22, 1);
        c1[4] = new Player("Зубарев", 18.24, 2);
        c1[5] = new Player("Сербов", 19.41, 1);
        c1[6] = new Player("Калошин", 15.38, 2);
        c1[7] = new Player("Олейник", 15.11, 1);
        c1[8] = new Player("Васильев", 14.26, 2);
        c1[9] = new Player("Букин", 12.41, 2);
        //Упорядочение по результатам
        Player[] a = new Player[5];
        Player[] b = new Player[5];
        Groups(c1, ref a, ref b);
        Sorting(a);
        Sorting(b);
        Console.WriteLine("Группа 1");
        foreach (var player in a)
        {
            player.Print();
        }
        Console.WriteLine("Группа 2");
        foreach (var player in b)
        {
            player.Print();
        }
        Merge(a, b, c1);
        Console.WriteLine();
        Console.WriteLine("Общий рейтинг");
        foreach (var player in c1)
        {
            player.Print();
        }
    }
    static void Sorting(Player[] s)
    {
        for (int i = 0; i < s.Length; i++)
        {
            for (int j = i + 1; j < s.Length; j++)
            {
                if (s[j].Result < s[i].Result)
                {
                    Player copy = s[i];
                    s[i] = s[j];
                    s[j] = copy;
                }
            }
        }
    }

    static void Groups(Player[] c1, ref Player[] a, ref Player[] b)
    {
        int k = 0;
        int k1 = 0;
        for (int i = 0; i < c1.Length; i++)
        {
            if (c1[i].Id == 1)
            {
                a[k] = c1[i];
                k++;
            }
            else
            {
                b[k1] = c1[i];
                k1++;
            }
        }
    }
    static void Merge(Player[] a, Player[] b, Player[] c1)
    {
        int i = 0;
        int j = 0;
        int k = 0;
        while (i < a.Length && j < b.Length)
        {
            if (a[i].Result < b[j].Result)
            {
                c1[k] = a[i];
                i++;
            }
            else
            {
                c1[k] = b[j];
                j++;
            }
            k++;
        }
        while (i < a.Length)
        {
            c1[k] = a[i];
            i++;
            k++;
        }

        while (j < b.Length)
        {
            c1[k] = b[j];
            j++;
            k++;
        }
    }
}