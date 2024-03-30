using System;

class Team
{
    private string _name;
    private double[] _results = new double[6];
    private int _count = 0;
    private int _bestTeam = 0;

    public Team(string name, double[] results)
    {
        _name = name;
        _results = results;
        for (int i = 0; i < _results.Length; i++)
        {
            for (int j = 1; j <= 5; j++)
            {
                if (results[i] == j)
                {
                    _count += 6 - j;
                }
            }
            if (results[i] == 1)
            {
                _bestTeam = 1;
            }
        }
    }

    public int BestTeam => _bestTeam;
    public int Count => _count;
    public string Name => _name;

    public void Print()
    {
        Console.WriteLine($"{_name} {_count}");
    }
}

class WomenTeam : Team
{
    public WomenTeam(string name, double[] results) : base(name, results)
    {
    }
}

class MenTeam : Team
{
    public MenTeam(string name, double[] results) : base(name, results)
    {
    }
}

class Program
{
    static void Main()
    {
        Team[] womenTeams = new WomenTeam[3];
        Team[] menTeams = new MenTeam[3];

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("Женская команда:");
            string name = Console.ReadLine();
            Console.WriteLine("Места участников команды:");
            double[] results = new double[6];
            for (int j = 0; j < 6; j++)
            {
                results[j] = double.Parse(Console.ReadLine());
            }
            womenTeams[i] = new WomenTeam(name, results);
        }

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("Мужская команда:");
            string name = Console.ReadLine();
            Console.WriteLine("Места участников команды:");
            double[] results = new double[6];
            for (int j = 0; j < 6; j++)
            {
                results[j] = double.Parse(Console.ReadLine());
            }
            menTeams[i] = new MenTeam(name, results);
        }

        FindTopTeam(womenTeams);
        FindTopTeam(menTeams);

        Team winnerWomen = GetWinner(womenTeams);
        Team winnerMen = GetWinner(menTeams);

        Console.WriteLine("Победители:");
        winnerWomen.Print();
        winnerMen.Print();
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
                while (j >= d && teams[j - d].BestTeam < teams[j].BestTeam)
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
        Team winner = teams[0];
        foreach (Team team in teams)
        {
            if (team.Count > winner.Count)
            {
                winner = team;
            }
        }
        return winner;
    }
}
