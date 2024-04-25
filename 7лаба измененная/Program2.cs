abstract class Human
{
    public string FullName { get; private protected set; }
    public double Score { get; private protected set; }

    public Human(string fullName, double score)
    {
        FullName = fullName;
        Score = score;
    }
}

class Sportsman : Human
{
    private static int counter = 1;
    public int Id { get; private set; }

    public Sportsman(string fullName, double score) : base(fullName, score)
    {
        Id = counter++;
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
        Sportsman[] sportsman =
        [
            new Sportsman("Karyakin", 2.5),
            new Sportsman("Nepo", 3),
            new Sportsman("Karlsen", 4.5),
            new Sportsman("Botvink", 0.5),
            new Sportsman("Dubov", 4),
        ];
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