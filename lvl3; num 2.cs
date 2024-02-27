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
        Football[] komandi = new Football[]
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
        Console.WriteLine("Список команд и количество набранных очков");
        foreach (Football rezultati in komandi)
        {
            rezultati.Print();
        }
        Sort(komandi);
        Console.WriteLine(" ");
        Console.WriteLine("Остортированные списки");
        foreach (Football rezultati in komandi)
        {
            rezultati.Print();
        }
        Console.WriteLine(" ");
        Console.WriteLine("Топ 6 команд прошедших в следующий тур:");
        for (int i = 0; i < 6; i++)
        {
            komandi[i].Print();
        }
    }
    static void Sort(Football[] komandi)
    {
        int i = 0;
        int j = 1;
        while(j < komandi.Length - 1)
        {
            if(i < 0 || komandi[i].Score >= komandi[i + 1].Score)
            {
                i = j;
                j++;
            }
            while(i >= 0 && komandi[i].Score < komandi[i + 1].Score)
            {
                Football temp = komandi[i];
                komandi[i] = komandi[i+1];
                komandi[i+1] = temp;
                i--;
            }
        }
    }
}