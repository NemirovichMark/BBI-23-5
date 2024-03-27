
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
        Console.WriteLine();
        Console.WriteLine($"{Name,-9} {Club,-12} {Summ,-5}");
    }
}

class Program
{
    /*private static void SortArray(Players[] players)
    {
        for (int i = 0; i < players.Length; i++) 
        {
            for (int j = 0; j < players.Length - i - 1; j++) //сравниваем значения по парам и меняем местами через условие
                //i - тек; j-следующая
            {
                if (players[j].Summ < players[j + 1].Summ)  //шелла
                {
                    Players temp = players[j]; 
                    players[j] = players[j + 1];
                    players[j + 1] = temp;
                }
            }
        }
    }*/
    public static void ShellaSort(Players[] players)
    {

        int n = players.Length;
        for (int gap = n / 2; gap > 0; gap /= 2)
        {
            for (int i = gap; i < n; i++)
            {
                Players temp = players[i];
                int j;
                for (j = i; j >= gap && players[j - gap].Summ > temp.Summ; j -= gap) //compare currrent with left, 
                {
                    players[j] = players[j - gap];

                }
                players[j] = temp; //updating
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
        ShellaSort(players);
        foreach (var player in players)
        {
            player.PrintTable();
        }
    }
}
