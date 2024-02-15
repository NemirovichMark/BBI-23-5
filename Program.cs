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
        c1[0] = new Player("Иванов", 15.38, 1);
        c1[1] = new Player("Петров", 16.54, 2);
        c1[2] = new Player("Купцов", 13.51, 1);
        c1[3] = new Player("Аксенова", 11.22, 1);
        c1[4] = new Player("Кузнецов", 18.24, 2);
        c1[5] = new Player("Кравцов", 19.41, 1);
        c1[6] = new Player("Павленко", 15.31, 2);
        c1[7] = new Player("Еремина", 15.11, 1);
        c1[8] = new Player("Никонов", 14.26, 2);
        c1[9] = new Player("Сидорова", 12.41, 2);
        //Упорядочение по результатам
        Sort(c1);
    }
    static void Sort(Player[] c1)
    {
        for (int i = 0; i < c1.Length - 1; i++)
        {
            double amax = c1[i].Result;
            int imax = i;
            for (int j = i + 1; j < c1.Length; j++)
            {
                if (c1[j].Result < amax)
                {
                    amax = c1[j].Result;
                    imax = j;
                }
            }
            Player temp;
            temp = c1[imax];
            c1[imax] = c1[i];
            c1[i] = temp;
        }
        Console.WriteLine();
        Console.WriteLine("Результаты группы 1");
        int mesto = 1;
        for (int i = 0; i < c1.Length; i++)
        {
            if (c1[i].Id == 1)
            {
                Console.Write("Место " + mesto + " ");
                c1[i].Print();
                mesto++;
            }
        }

        Console.WriteLine();
        Console.WriteLine("Результаты группы 2");
        mesto = 1;
        for (int i = 0; i < c1.Length; i++)
        {
            if (c1[i].Id == 2)
            {
                Console.Write("Место " + mesto + " ");
                c1[i].Print();
                mesto++;
            }
        }
        Console.WriteLine();
        Console.WriteLine("Общий рейтинг");
        mesto = 1;
        for (int i = 0; i < c1.Length; i++)
        {
            Console.Write("Место " + mesto + " ");
            c1[i].Print();
            mesto++;
        }
    }
}