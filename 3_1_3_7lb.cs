abstract class NomineeOfYear
{
    protected static int TotalVotes;

    protected string _name;
    protected int _votes;

    public string Name => _name;
    public int Votes => _votes;

    public NomineeOfYear(string name, int votes)
    {
        _name = name;
        _votes = votes;
        TotalVotes += votes;
    }

    public abstract void Print();
}

class PersonOfYear : NomineeOfYear
{
    public PersonOfYear(string name, int votes) : base(name, votes)
    {
    }

    public override void Print()
    {
        Console.WriteLine("Кандидат: {0}\tКол-во голосов: {1}\t", Name, Votes);
    }

    public static double GetPerVotes(int votes)
    {
        return (double)votes / TotalVotes * 100;
    }
}

class DiscoveryOfYear : NomineeOfYear
{
    public DiscoveryOfYear(string name, int votes) : base(name, votes)
    {
    }

    public override void Print()
    {
        Console.WriteLine("Открытие: {0}\tКол-во голосов: {1}\t", Name, Votes);
    }

    public static double GetPerVotes(int votes)
    {
        return (double)votes / TotalVotes * 100;
    }
}

class Program
{
    static void Main()
    {
        NomineeOfYear[] candidates = new NomineeOfYear[]
        {
            new PersonOfYear("Бодя Федунь", 350),
            new PersonOfYear("Федя Кунгур", 200),
            new PersonOfYear("Армен Гогач", 500),
            new PersonOfYear("Сацик Насик", 400),
            new PersonOfYear("Немир Марков", 150),
            new PersonOfYear("Марк Немиров", 589),
            new PersonOfYear("Шорти Милан", 100)
        };

        Console.WriteLine("Кандидаты на человека/открытие года:");
        foreach (var candidate in candidates)
        {
            candidate.Print();
        }

        FindTopCandidates(candidates);

        Console.WriteLine("Топ кандидатов на человека/открытие года:");
        for (int i = 0; i < 5 && i < candidates.Length; i++)
        {
            candidates[i].Print();
        }

        Console.WriteLine("\nДоли кандидатов в процентах от общего числа голосов:");
        for (int i = 0; i < 5 && i < candidates.Length; i++)
        {
            double percentage = PersonOfYear.GetPerVotes(candidates[i].Votes);
            Console.WriteLine($"{candidates[i].Name}: {percentage:f2}%");
        }
    }

    static void FindTopCandidates(NomineeOfYear[] candidates)
    {
        int d = candidates.Length / 2;
        NomineeOfYear temp;
        while (d >= 1)
        {
            for (int i = d; i < candidates.Length; i++)
            {
                int j = i;
                temp = candidates[j];
                while (j >= d && candidates[j - d].Votes < candidates[j].Votes)
                {
                    candidates[j] = candidates[j - d];
                    candidates[j - d] = temp;
                    j = j - d;
                }
            }
            d = d / 2;
        }
    }
}