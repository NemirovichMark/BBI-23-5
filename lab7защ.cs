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

    protected static void Merge(NomineeOfYear[] arr, int left, int mid, int right)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;

        NomineeOfYear[] L = new NomineeOfYear[n1];
        NomineeOfYear[] R = new NomineeOfYear[n2];

        Array.Copy(arr, left, L, 0, n1);
        Array.Copy(arr, mid + 1, R, 0, n2);

        int i = 0, j = 0;

        int k = left;
        while (i < n1 && j < n2)
        {
            if (L[i].Votes >= R[j].Votes)
            {
                arr[k] = L[i];
                i++;
            }
            else
            {
                arr[k] = R[j];
                j++;
            }
            k++;
        }

        while (i < n1)
        {
            arr[k] = L[i];
            i++;
            k++;
        }

        while (j < n2)
        {
            arr[k] = R[j];
            j++;
            k++;
        }
    }

    protected static void MergeSort(NomineeOfYear[] arr, int left, int right)
    {
        if (left < right)
        {
            int mid = left + (right - left) / 2;

            MergeSort(arr, left, mid);
            MergeSort(arr, mid + 1, right);

            Merge(arr, left, mid, right);
        }
    }

    public static void SortCandidates(NomineeOfYear[] candidates)
    {
        MergeSort(candidates, 0, candidates.Length - 1);
    }
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

    protected static double GetPerVotes(int votes)
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

        NomineeOfYear.SortCandidates(candidates);

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
}
