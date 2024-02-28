// lv1-num1 changed2
using System;

public struct Players
{
    private string lastname, club;
    private double result1, result2, summ;

    public Players(string ln, string _club, double res1, double res2)
    {
        lastname = ln;
        club = _club;
        result1 = res1;
        result2 = res2;
        summ = result1 + result2;
    }
    public string Name
    {
        get { return lastname; }
    }
    public string Club
    {
        get { return club; }
    }
    public double Summ
    {
        get { return summ; }
    }
    public void PrintTable()
    {
        Console.Write("Фамилия   Общество    Сумма");
        Console.WriteLine($"{Name,-9} {Club,-12} {Summ,-5}");
    }
}

class Program
{
    private static void SortArray(Players[] players)
    {
        for (int i = 0; i < players.Length; i++)
        {
            for (int j = 0; j < players.Length - i - 1; j++)
            {
                if (players[j].Summ < players[j + 1].Summ)
                {
                    Players temp = players[j];
                    players[j] = players[j + 1];
                    players[j + 1] = temp;
                }
            }
        }
    }


    static void Main()
    {
        Players[] players = {
            new Players("Иванов", "Клуб1", 7.2, 7.4),
            new Players("Петров", "Клуб2", 7.8, 7.5),
            new Players("Сидоров", "Клуб3", 7.5, 7.3),
            new Players("Евелькин", "Клуб52", 6.9, 8.0),
            new Players("Носыч", "Спартак", 7.0, 9.1)
        };
        SortArray(players);
        foreach (var player in players)
        {
            player.PrintTable();
        }
    }
}
