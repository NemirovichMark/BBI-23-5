//задача 1лвл
struct PersonOfYear
{
    private string _name;
    private int _votes;
    public string Name => _name;
    public int Votes => _votes;

    public PersonOfYear(string name, int votes)
    {
        _name = name;
        _votes = votes;
    }
    public void Print()
    {
        Console.WriteLine("Кандидат   {0}\t" + "Кол-во голосов {1}\t", _name, _votes);
    }
}

class Program
{
    static void Main()
    {
        PersonOfYear[] candidates = new PersonOfYear[]
        {
            new PersonOfYear("Бодя Федунь", 350),
            new PersonOfYear("Федя Кунгур", 200),
            new PersonOfYear("Дима Коил", 500),
            new PersonOfYear("Сацик Насик", 400),
            new PersonOfYear("Немир Марков", 150),
            new PersonOfYear("Марк Немиров", 589),
            new PersonOfYear("Шорти Милан", 100)
        };
        Console.WriteLine("Кандидаты на человека года:");
        int TotalVotes = 0;
        foreach (var candidate in candidates)
        {
            TotalVotes += candidate.Votes;
            candidate.Print();
        }
        FindTopCandidates(candidates);

        static void FindTopCandidates(PersonOfYear[] candidates)
        {
            {
                int d = candidates.Length / 2;
                PersonOfYear temp;
                while (d >= 1)
                {
                    for (int i = d; i < candidates.Length; i++)
                    {
                        int j = i;
                        while (j >= d && candidates[j - d].Votes < candidates[j].Votes)
                        {
                            temp = candidates[j];
                            candidates[j] = candidates[j - d];
                            candidates[j - d] = temp;
                            j = j - d;
                        }
                    }
                    d = d / 2;
                }
            }
        }

        Console.WriteLine("Топ кандидатов на человека года:");
        for (int i = 0; i < 5 && i < candidates.Length; i++)
        {
            candidates[i].Print();
        }
        Console.WriteLine("\nДоли кандидатов в процентах от общего числа голосов:");
        for (int i = 0; i < 5 && i < candidates.Length; i++)
        {
            double prosent = (double)candidates[i].Votes / TotalVotes * 100;
            Console.WriteLine($"{candidates[i].Name}: {prosent:f2}%");
        }
    }
}
