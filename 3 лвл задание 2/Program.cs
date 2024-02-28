using System;
struct Football
{
    private string _teams;
    private int _score;

    public int Score
    {
        get { return _score; }
        set { _score = value; }
    }
    public Football(string tm, int sc)
    {
        _teams = tm;
        _score = sc;
    }
    public void Print()
    {
        Console.WriteLine(_teams + ": " + _score);
    }
}

class Program
{
    static void Main()
    {
        Football Tims = new Football("Команда0", 4);
        Football[] komandi1 = new Football[]
        {
            new Football("Команда1", 3),
            new Football("Команда2", 4),
            new Football("Команда3", 7),
            new Football("Команда4", 2),
            new Football("Команда5", 9),
            new Football("Команда6", 13),
            new Football("Команда7", 5),
            new Football("Команда8", 4),
            new Football("Команда9", 3),
            new Football("Команда10", 7),
            new Football("Команда11", 25),
            new Football("Команда12", 3),
        };

        Football[] komandi2 = new Football[]
        {
            new Football("Команда13", 8),
            new Football("Команда14", 11),
            new Football("Команда15", 6),
            new Football("Команда16", 15),
            new Football("Команда17", 10),
            new Football("Команда18", 12),
            new Football("Команда19", 14),
            new Football("Команда20", 16),
            new Football("Команда21", 18),
            new Football("Команда22", 17),
            new Football("Команда23", 20),
            new Football("Команда24", 19),
        };

        Console.WriteLine("Список команд и количество набранных очков для первого массива:");
        foreach (Football rezultati in komandi1)
        {
            rezultati.Print();
        }

        Sort(komandi1, komandi1.Length);
        Console.WriteLine(" ");
        Console.WriteLine("Остортированные списки для первого массива:");
        foreach (Football rezultati in komandi1)
        {
            rezultati.Print();
        }

        Console.WriteLine(" ");
        Console.WriteLine("Топ 6 команд прошедших в следующий тур для первого массива:");
        Football[] top6_1 = TopTims(komandi1, 6);
        foreach (Football rezultati in top6_1)
        {
            rezultati.Print();
        }

        Console.WriteLine("\nСписок команд и количество набранных очков для второго массива:");
        foreach (Football rezultati in komandi2)
        {
            rezultati.Print();
        }

        Sort(komandi2, komandi2.Length);
        Console.WriteLine(" ");
        Console.WriteLine("Остортированные списки для второго массива:");
        foreach (Football rezultati in komandi2)
        {
            rezultati.Print();
        }

        Console.WriteLine(" ");
        Console.WriteLine("Топ 6 команд прошедших в следующий тур для второго массива:");
        Football[] top6_2 = TopTims(komandi2, 6);
        foreach (Football rezultati in top6_2)
        {
            rezultati.Print();
        }

        Console.WriteLine(" Общий топ 6 команд:");
        Football[] Foundtop6 = NaidenoTop6(top6_1, top6_2);
        foreach (Football rezultati in Foundtop6)
        {
            rezultati.Print();
        }
    }

    static void Sort(Football[] komandi, int count)
    {
        for (int i = 1; i < count; i++)
        {
            int j = i;
            while (j > 0 && komandi[j - 1].Score < komandi[j].Score)
            {
                Football temp = komandi[j];
                komandi[j] = komandi[j - 1];
                komandi[j - 1] = temp;
                j--;
            }
        }
    }

    static Football[] TopTims(Football[] komandi, int count)
    {
        Football[] topTeams = new Football[count];
        Array.Copy(komandi, topTeams, count);
        return topTeams;
    }

    static Football[] NaidenoTop6(Football[] top1, Football[] top2)
    {
        Football[] ObshiyTop = new Football[top1.Length + top2.Length];
        Array.Copy(top1, 0, ObshiyTop, 0, top1.Length);
        Array.Copy(top2, 0, ObshiyTop, top1.Length, top2.Length);
        Sort(ObshiyTop, ObshiyTop.Length);
        return TopTims(ObshiyTop, 6);
    }
}

