
using System;

abstract class FootballTeam
{
    protected string name;
    protected string _s;
    protected int _wins;
    protected int _loses;
    public int wins => _wins;
    public FootballTeam(string names, string s, int q, int e)
    {
        name = names; _s = s; _wins = q; _loses = e;
    }
    public void Print()
    {
        Console.WriteLine("Название команды    {0}\t {1}\t  Победы {2:f2}",
            name, _s, _wins);
    }

    public static void MergeSort(FootballTeam[] arr)
    {
        if (arr.Length <= 1)
            return;

        int mid = arr.Length / 2;
        FootballTeam[] left = new FootballTeam[mid];
        FootballTeam[] right = new FootballTeam[arr.Length - mid];

        for (int i = 0; i < mid; i++)
            left[i] = arr[i];

        for (int i = mid; i < arr.Length; i++)
            right[i - mid] = arr[i];

        MergeSort(left);
        MergeSort(right);
        Merge(left, right, arr);
    }

    private static void Merge(FootballTeam[] left, FootballTeam[] right, FootballTeam[] arr)
    {
        int i = 0, j = 0, k = 0;

        while (i < left.Length && j < right.Length)
        {
            if (left[i]._wins > right[j]._wins)
                arr[k++] = left[i++];
            else
                arr[k++] = right[j++];
        }

        while (i < left.Length)
            arr[k++] = left[i++];

        while (j < right.Length)
            arr[k++] = right[j++];
    }
}

class Fteam : FootballTeam
{
    public Fteam(string n, string h, int y, int x) : base(n, h, y, x) { }
}

class MTeam : FootballTeam
{
    public MTeam(string t, string w, int r, int e) : base(t, w, r, e) { }
}

internal class Program
{
    static void Main(string[] args)
    {
        Fteam[] d = new Fteam[]
        {
            new Fteam("Панды", "женская команда", 7, 5),
            new Fteam("Звёзды", "женская команда", 8, 4),
            new Fteam("Ягуары", "женская команда", 2, 10),
            new Fteam("Молния", "женская команда", 3, 9),
            new Fteam("Волки", "женская команда", 3, 9),
            new Fteam("Тигры", "женская команда", 7, 5),
            new Fteam("Ястребы", "женская команда", 5, 7),
            new Fteam("Драконы", "женская команда", 4, 8),
            new Fteam("Друзья", "женская команда", 6, 6),
            new Fteam("Медведи", "женская команда", 5, 7),
            new Fteam("Орлы", "женская команда", 7, 5),
            new Fteam("Котики", "женская команда", 8, 4)
        };

        MTeam[] m = new MTeam[]
        {
            new MTeam("Львы", "мужская команда", 6, 6),
            new MTeam("Смельчаки","мужская команда", 4, 8),
            new MTeam("Ветер", "мужская команда", 7, 5),
            new MTeam("Лисы", "мужская команда", 2, 10),
            new MTeam("Банда","мужская команда", 5, 7),
            new MTeam("Ночь", "мужская команда", 8, 4),
            new MTeam("Воля", "мужская команда", 6, 6),
            new MTeam("Сокол", "мужская команда", 9, 3),
            new MTeam("Стужа","мужская команда", 8, 4),
            new MTeam("Шторм", "мужская команда", 10, 2),
            new MTeam("Комета", "мужская команда", 7, 5),
            new MTeam("Феникс", "мужская команда", 2, 10)
        };

        FootballTeam.MergeSort(d);
        FootballTeam.MergeSort(m);

        FootballTeam[] c = new FootballTeam[12];
        int a, r, f;
        a = r = 0;
        for (f = 0; f < c.Length; f++)
        {
            if (a >= d.Length / 2)
            {
                c[f] = m[r];
                r++;
            }
            else if (r >= m.Length / 2)
            {
                c[f] = d[a];
                a++;
            }
            else if (d[a].wins > m[r].wins)
            {
                c[f] = m[r];
                r++;
            }
            else
            {
                c[f] = d[a];
                a++;
            }
        }

       FootballTeam.MergeSort(c);

        Console.WriteLine("Список лучших команд");
        Console.WriteLine();
        foreach (var sportsmen in c)
        {
            sportsmen.Print();
        }
    }
}