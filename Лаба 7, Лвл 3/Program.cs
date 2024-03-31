using System;

class Football
{
    protected string _teams;
    protected int _score;

    public int Score
    {
        get { return _score; }
        private set { _score = value; }
    }
    public Football(string tm, int sc)
    {
        _teams = tm;
        _score = sc;
    }
    public virtual void Print()
    {
        Console.WriteLine("Мужская " + _teams + ": " + _score);
    }
}
class FootballZhen : Football
{
    public FootballZhen(string tm, int sc) : base(tm, sc) { }
    public override void Print()
    {
        Console.WriteLine("Женская " + _teams + ": " + _score);
    }
}
class FootballMuzh : Football
{
    public FootballMuzh(string tm, int sc) : base(tm, sc) { }
}

class Program
{
    static void Main()
    {
        Football Tims = new Football("Команда0", 4);
        FootballZhen[] komandi1 = new FootballZhen[]
        {
            new FootballZhen("Команда1", 3),
            new FootballZhen("Команда2", 4),
            new FootballZhen("Команда3", 7),
            new FootballZhen("Команда4", 2),
            new FootballZhen("Команда5", 9),
            new FootballZhen("Команда6", 13),
            new FootballZhen("Команда7", 5),
            new FootballZhen("Команда8", 4),
            new FootballZhen("Команда9", 3),
            new FootballZhen("Команда10", 700),
            new FootballZhen("Команда11", 25),
            new FootballZhen("Команда12", 3),
        };

        FootballZhen[] komandi2 = new FootballZhen[]
        {
            new FootballZhen("Команда13", 8),
            new FootballZhen("Команда14", 11),
            new FootballZhen("Команда15", 6),
            new FootballZhen("Команда16", 15),
            new FootballZhen("Команда17", 10),
            new FootballZhen("Команда18", 12),
            new FootballZhen("Команда19", 14),
            new FootballZhen("Команда20", 16),
            new FootballZhen("Команда21", 18),
            new FootballZhen("Команда22", 17),
            new FootballZhen("Команда23", 20),
            new FootballZhen("Команда24", 19),
        };
        FootballMuzh[] komandi3 = new FootballMuzh[]
        {
            new FootballMuzh("Команда1", 35),
            new FootballMuzh("Команда2", 44),
            new FootballMuzh("Команда3", 72),
            new FootballMuzh("Команда4", 28),
            new FootballMuzh("Команда5", 96),
            new FootballMuzh("Команда6", 143),
            new FootballMuzh("Команда7", 53),
            new FootballMuzh("Команда8", 48),
            new FootballMuzh("Команда9", 39),
            new FootballMuzh("Команда10", 97),
            new FootballMuzh("Команда11", 265),
            new FootballMuzh("Команда12", 35),
        };

        FootballMuzh[] komandi4 = new FootballMuzh[]
        {
            new FootballMuzh("Команда13", 8),
            new FootballMuzh("Команда14", 11),
            new FootballMuzh("Команда15", 6),
            new FootballMuzh("Команда16", 15),
            new FootballMuzh("Команда17", 10),
            new FootballMuzh("Команда18", 12),
            new FootballMuzh("Команда19", 14),
            new FootballMuzh("Команда20", 16),
            new FootballMuzh("Команда21", 18),
            new FootballMuzh("Команда22", 17),
            new FootballMuzh("Команда23", 20),
            new FootballMuzh("Команда24", 19),
        };
        Console.WriteLine("ЖЕНСКАЯ:");
        Console.WriteLine("Список команд и количество набранных очков для первого массива:");
        foreach (FootballZhen rezultati in komandi1)
        {
            rezultati.Print();
        }

        Sort(komandi1, komandi1.Length);
        Console.WriteLine(" ");
        Console.WriteLine("Остортированные списки для первого массива:");
        foreach (FootballZhen rezultati in komandi1)
        {
            rezultati.Print();
        }

        Console.WriteLine(" ");
        Console.WriteLine("Топ 6 команд прошедших в следующий тур для первого массива:");
        Football[] top6_1 = TopTims(komandi1, 6);
        foreach (FootballZhen rezultati in top6_1)
        {
            rezultati.Print();
        }
        Console.WriteLine("\nСписок команд и количество набранных очков для второго массива:");
        foreach (FootballZhen rezultati in komandi2)
        {
            rezultati.Print();
        }

        Sort(komandi2, komandi2.Length);
        Console.WriteLine(" ");
        Console.WriteLine("Остортированные списки для второго массива:");
        foreach (FootballZhen rezultati in komandi2)
        {
            rezultati.Print();
        }

        Console.WriteLine(" ");
        Console.WriteLine("Топ 6 команд прошедших в следующий тур для второго массива:");
        Football[] top6_2 = TopTims(komandi2, 6);
        foreach (FootballZhen rezultati in top6_2)
        {
            rezultati.Print();
        }
        Console.WriteLine("Мужская:");
        Console.WriteLine("Список команд и количество набранных очков для первого массива:");
        foreach (FootballMuzh rezultati in komandi3)
        {
            rezultati.Print();
        }

        Sort(komandi3, komandi3.Length);
        Console.WriteLine(" ");
        Console.WriteLine("Остортированные списки для первого массива:");
        foreach (FootballMuzh rezultati in komandi3)
        {
            rezultati.Print();
        }

        Console.WriteLine(" ");
        Console.WriteLine("Топ 6 команд прошедших в следующий тур для первого массива:");
        Football[] top6_3 = TopTims(komandi3, 6);
        foreach (FootballMuzh rezultati in top6_3)
        {
            rezultati.Print();
        }

        Console.WriteLine("\nСписок команд и количество набранных очков для второго массива:");
        foreach (FootballMuzh rezultati in komandi4)
        {
            rezultati.Print();
        }

        Sort(komandi4, komandi4.Length);
        Console.WriteLine(" ");
        Console.WriteLine("Остортированные списки для второго массива:");
        foreach (FootballMuzh rezultati in komandi4)
        {
            rezultati.Print();
        }

        Console.WriteLine(" ");
        Console.WriteLine("Топ 6 команд прошедших в следующий тур для второго массива:");
        Football[] top6_4 = TopTims(komandi4, 6);
        foreach (FootballMuzh rezultati in top6_4)
        {
            rezultati.Print();
        }

        Console.WriteLine(" Общий топ 6 команд:");
        Football[] Foundtop6 = NaidenoTop6(top6_1, top6_2, top6_3, top6_4);
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

    static Football[] NaidenoTop6(Football[] top1, Football[] top2, Football[] top3, Football[] top4)
    {
        Football[] ObshiyTop = new Football[top1.Length + top2.Length + top3.Length + top4.Length];
        Array.Copy(top1, 0, ObshiyTop, 0, top1.Length);
        Array.Copy(top2, 0, ObshiyTop, top1.Length, top2.Length);
        Array.Copy(top3, 0, ObshiyTop, top1.Length + top2.Length, top3.Length);
        Array.Copy(top4, 0, ObshiyTop, top1.Length + top2.Length + top3.Length, top4.Length);
        Sort(ObshiyTop, ObshiyTop.Length);
        return TopTims(ObshiyTop, 6);
    }
}