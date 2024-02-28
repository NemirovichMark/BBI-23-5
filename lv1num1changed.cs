using System;

public struct Players
{
    public string lastname, club;
    public double result1, result2, summ;

    public Players(string ln, string _club, double res1, double res2)
    {
        lastname = ln;
        club = _club;
        result1 = res1;
        result2 = res2;
        summ = res1 + res2;
    }
}

class Program
{
    static void SortArray(Players[] players)
    {
        for (int i = 0; i < players.Length; i++)
        {
            for (int j = 0; j < players.Length - i - 1; j++)
            {
                if (players[j].summ < players[j + 1].summ)
                {
                    Players temp = players[j];
                    players[j] = players[j + 1];
                    players[j + 1] = temp;
                }
            }
        }
    }

    static void PrintTable(Players[] players)
    {
        Console.WriteLine("Фамилия   Общество    Первая попытка    Вторая попытка    Сумма");
        for (int i = 0; i < players.Length; i++)
        {
            Console.WriteLine($"{players[i].lastname,-9} {players[i].club,-12} {players[i].result1,-16} {players[i].result2,-16} {players[i].summ,-5}");
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
        PrintTable(players);
    }
}