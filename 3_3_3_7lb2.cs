class Team
{
    protected string _name;
    protected int _totalPoints;
        
    public Team(string name, double[] results)
    {
        _name = name;
        TotalPointss(results);
    }

    public int TotalPoints => _totalPoints;
    public string Name => _name;

    protected virtual void TotalPointss(double[] results)
    {
        foreach (var result in results)
        {
            for (int j = 1; j <= 5; j++)
            {
                if (result == j)
                {
                    _totalPoints += 6 - j;
                }
            }
        }
    }

    public virtual void Print()
    {
        Console.WriteLine($"{_name}: {_totalPoints} баллы");
    }
}

class WomenTeam : Team
{
    public WomenTeam(string name, double[] results) : base(name, results)
    {
    }

    protected override void TotalPointss(double[] results)
    {
        base.TotalPointss(results);
        foreach (var result in results)
        {
            if (result == 1)
            {
                _totalPoints += 1;
                break;
            }
        }
    }

    public override void Print()
    {
        Console.WriteLine($"Женская команда: {_name}, {_totalPoints} балла/ов");
    }
}

class MenTeam : Team
{
    public MenTeam(string name, double[] results) : base(name, results)
    {
    }

    protected override void TotalPointss(double[] results)
    {
        base.TotalPointss(results);
        foreach (var result in results)
        {
            if (result == 1)
            {
                _totalPoints += 1;
                break;
            }
        }
    }

    public override void Print()
    {
        Console.WriteLine($"Мужская команда: {_name}, {_totalPoints} балла/ов");
    }
}

class Program
{
    static void Main()
    {
        Team[] teams = new Team[6];

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("Женская команда название:");
            string name = Console.ReadLine();
            Console.WriteLine("Места участников:");
            double[] results = new double[6];
            for (int j = 0; j < 6; j++)
            {
                results[j] = double.Parse(Console.ReadLine());
            }
            teams[i] = new WomenTeam(name, results);
        }

        for (int i = 3; i < 6; i++)
        {
            Console.WriteLine("Мужская команда название:");
            string name = Console.ReadLine();
            Console.WriteLine("Места участников:");
            double[] results = new double[6];
            for (int j = 0; j < 6; j++)
            {
                results[j] = double.Parse(Console.ReadLine());
            }
            teams[i] = new MenTeam(name, results);
        }

        FindTopTeam(teams);

        Team winner = GetWinner(teams);

        Console.WriteLine("Победитель:");
        winner.Print();
    }

    static void FindTopTeam(Team[] teams)
    {
        int d = teams.Length / 2;
        Team temp;
        while (d >= 1)
        {
            for (int i = d; i < teams.Length; i++)
            {
                int j = i;
                while (j >= d && teams[j - d].TotalPoints < teams[j].TotalPoints)
                {
                    temp = teams[j];
                    teams[j] = teams[j - d];
                    teams[j - d] = temp;
                    j = j - d;
                }
            }
            d = d / 2;
        }
    }

    static Team GetWinner(Team[] teams)
    {
        return teams[0];
    }
}
