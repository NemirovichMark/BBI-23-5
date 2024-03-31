
// lv1-num1 changed2
using System;

public class Players
{
    private string lastname, club;
    private double result1, result2, summ;
    private bool IsDisqualified 

    public Players(string ln, string _club, double res1, double res2, bool isDisqualified)
    {
        lastname = ln;
        club = _club;
        result1 = res1;
        result2 = res2;
        summ = result1 + result2;
        IsDisqualified = isDisqualified;
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
        if (IsDisqualified != true)
            Console.WriteLine($"{Name,-9} {Club,-12} {Summ,-5}");
        else
            Console.WriteLine($"Участник {lastname} дисквалифицирован");
    }
    public void Disqual()
    {
        if(summ<14.0)
        {
            IsDisqualified = true;
        }

      
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
            new Players("Иванов", "Клуб1", 7.2, 7.4, false),
            new Players("Петров", "Клуб2", 7.8, 7.5, false),
            new Players("Сидоров", "Клуб3", 7.5, 7.3,false),
            new Players("Евелькин", "Клуб52", 6.9, 6.0,false),
            new Players("Носыч", "Спартак", 7.0, 9.1,false)
        };
        foreach(var player in players)
        {
            player.Disqual();
        }

        SortArray(players);
        Console.WriteLine("Фамилия   Общество    Сумма");
        foreach (var player in players)
        {
            player.PrintTable();
        }
    }
}