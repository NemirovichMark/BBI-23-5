struct FootballTeam
{
    private string name;
    private int goalsScored;
    private int goalsConceded;
    private int points;

    public FootballTeam(string name)
    {
        this.name = name;
        this.goalsScored = 0;
        this.goalsConceded = 0;
        this.points = 0;
    }

    public string Name
    {
        get { return name; }
    }

    public void Result(int scored, int conceded)
    {
        goalsScored += scored;
        goalsConceded += conceded;

        if (scored > conceded)
            points += 3;
        else if (scored == conceded)
            points += 1;
    }

    public int Points
    {
        get { return points; }
    }

    public int RAZNICA
    {
        get { return goalsScored - goalsConceded; }
    }
}

class Program
{
    static void Main(string[] args)
    {
        FootballTeam[] teams = new FootballTeam[]
        {
            new FootballTeam("ЦСКА"),
            new FootballTeam("Динама"),
            new FootballTeam("Спартак"),
            new FootballTeam("Монгол")
        };

        Match(ref teams[0], ref teams[1]);
        Match(ref teams[0], ref teams[2]);
        Match(ref teams[0], ref teams[3]);

        Match(ref teams[1], ref teams[0]);
        Match(ref teams[1], ref teams[2]);
        Match(ref teams[1], ref teams[3]);

        SORT(teams);

        Console.WriteLine("Место | Команда | Очки");
        Console.WriteLine("-------------------------");
        for (int i = 0; i < teams.Length; i++)
        {
            Console.WriteLine("{0,5} | {1,-7} | {2}", i + 1, teams[i].Name, teams[i].Points);
        }
    }

    static void Match(ref FootballTeam team1, ref FootballTeam team2)
    {
        Random random = new Random();
        int scored = random.Next(0, 5);
        int conceded = random.Next(0, 5);
        team1.Result(scored, conceded);
        team2.Result(conceded, scored);
    }

    static void SORT(FootballTeam[] teams)
    {
        int n = teams.Length;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n - 1; j++)
            {
                if (teams[j].Points < teams[j + 1].Points ||
                    (teams[j].Points == teams[j + 1].Points && teams[j].RAZNICA < teams[j + 1].RAZNICA))
                {
                    FootballTeam temp = teams[j];
                    teams[j] = teams[j + 1];
                    teams[j + 1] = temp;
                }
            }
        }
    }
}