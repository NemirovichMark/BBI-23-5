abstract class Human
{
    public string FullName { get; set; }
    public double Score { get; set; }

    public Human(string fullName, double score)
    {
        FullName = fullName;
        Score = score;
    }
}

class Sportsman : Human
{
    public int Id { get; set; }

    public Sportsman(string fullName, double score, int id) : base(fullName, score)
    {
        Id = id;
    }

    public void GetInfo()
    {
        Console.WriteLine($"Sportsman {FullName} has id {Id} and score {Score}");
    }
}

class Program
{
    static void Main()
    {
        Sportsman[] sportsman = new Sportsman[5];
        {
            new Sportsman("Karyakin", 2.5, 1);
            new Sportsman("Nepo", 3, 2);
            new Sportsman("Karlsen", 4.5, 3);
            new Sportsman("Botvink", 0.5, 4);
            new Sportsman("Dubov", 4, 5);
        }

       
        InsertionSort(sportsman);
        Console.WriteLine();
        foreach (Sportsman sportsmans in sportsman)
        {
            sportsmans.GetInfo();
        }
    }

    static void InsertionSort(Sportsman[] sportsman)
    {
        for (int i = 1; i < sportsman.Length; i++)
        {
            Sportsman key = sportsman[i];
            int j = i - 1;

            while (j >= 0 && sportsman[j].Score < key.Score)
            {
                sportsman[j + 1] = sportsman[j];
                j--;
            }
            sportsman[j + 1] = key;
        }
    }
}