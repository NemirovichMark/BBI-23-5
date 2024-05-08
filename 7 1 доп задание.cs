using System;

public class Players
{
    private string lastname, club;
    private double result1, result2, summ;
    private bool IsDisqualified;

    public Players(string ln, string _club, double res1, double res2)
    {
        lastname = ln;
        club = _club;
        result1 = res1;
        result2 = res2;
        summ = result1 + result2;
        IsDisqualified = false;
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
        if (summ < 14.0)
        {
            IsDisqualified = true;
        }
    }

    public static void SortFast(Players[] players, int left, int right)
    {
        if (left < right) 
        {
            int pivot = Partition(players, left, right);//рекур
            SortFast(players, left, pivot - 1); //рекурсивный вывод метода для левой
            SortFast(players, pivot + 1, right);// для правой
        }
    }

    private static int Partition(Players[] players, int left, int right)
    {
        double pivot = players[right].Summ;//выбирает опорный элемент и записывает его
        int i = left - 1; //раздел массив на две части, часть где все эл меньш опорного
        for (int j = left; j < right; j++)
        {
            if (players[j].Summ < pivot) //сум рез меньше опорного - перемещ в лев часть
            {
                i++; 
                Swap(players, i, j);//обмен мест тек эл j на нов позицию i
            }
        }
        Swap(players, i + 1, right);//заменяю + сохр
        return i + 1;
    }

    private static void Swap(Players[] players, int left, int right)
    {
        Players temp = players[left];
        players[left] = players[right]; //просто меняю местами 2 эл
        players[right] = temp;
    }
}

class Program
{
    static void Main()
    {
        Players[] players = {
            new Players("Иванов", "Клуб1", 7.2, 7.4),
            new Players("Петров", "Клуб2", 7.8, 7.5),
            new Players("Сидоров", "Клуб3", 7.5, 7.3),
            new Players("Евелькин", "Клуб52", 6.9, 6.0),
            new Players("Носыч", "Спартак", 7.0, 9.1)
        };

        foreach (var player in players)
        {
            player.Disqual();
        }

        Players.SortFast(players, 0, players.Length - 1);

        Console.WriteLine("Фамилия   Общество    Сумма");
        foreach (var player in players)
        {
            player.PrintTable();
        }
    }
}
