class FootballTeam
{
    private string name; 
    private int scored;
    private int conceded; 
    private int points;
    public FootballTeam(string name)
    {
        this.name = name;
        scored = 0; 
        conceded = 0;
        points = 0;
    }
    public string Name { get { return name; } }
    public void Result(int scored, int conceded)
    {
        this.scored += scored;
        this.conceded += conceded; 
        if (scored > conceded)
            points += 3;
        else if (scored == conceded)
            points += 1;
    }
    public int Points { get { return points; } }
    public int RAZNICA { get { return scored - conceded; } }
    public static void Print(FootballTeam[] teams)
    {
        Console.WriteLine($"{"Место",-7}  {"Команда",-25}  {"Очки",-25}");
        for (int i = 0; i < teams.Length; i++)
        {

            Console.WriteLine($"{i + 1,-5} | {teams[i].Name,-23} | {teams[i].Points,-25}");
            Console.WriteLine("--------------------------------------------");
        }
    }
}
class WomanFootBall : FootballTeam
{
    public WomanFootBall(string name) : base(name)
    {
    
    }
}
class ManFootBall : FootballTeam
{
    public ManFootBall(string name) : base(name)
    {
   
    }
}
class Program
{
    static void Main(string[] args)
    {
        FootballTeam[] teams = new FootballTeam[]
        {
            new WomanFootBall("ЦСКА Женская сборная"),
            new WomanFootBall("Динамо Женская сборная"),
            new WomanFootBall("Спартак Женская сборная"),

            new ManFootBall("ЦСКА Мужская сборная"),
            new ManFootBall("Динамо Мужская сборная"),
            new ManFootBall("Спартак Мужская сборная"),
        };
        // матч девушек
        Match(ref teams[0], ref teams[1]);
        Match(ref teams[0], ref teams[2]);
        Match(ref teams[1], ref teams[2]);
        // матч парней
        Match(ref teams[3], ref teams[4]);
        Match(ref teams[3], ref teams[5]);
        Match(ref teams[4], ref teams[5]);

        Sort(teams); 

        FootballTeam.Print(teams);
    }
    static void Match(ref FootballTeam team1, ref FootballTeam team2)
    {
        Random random = new Random();
        int scored = random.Next(0, 5);
        int conceded = random.Next(0, 5);
        team1.Result(scored, conceded);
        team2.Result(conceded, scored);
    }
    static void Sort(FootballTeam[] teams)
    {
        for (int i = 0; i < teams.Length - 1; i++)
        {
            for (int j = 0; j < teams.Length - 1; j++)
            {
                if (teams[j].Points < teams[j + 1].Points ||
                   (teams[j].Points == teams[j + 1].Points && teams[j].RAZNICA < teams[j + 1].RAZNICA))
                {
                    FootballTeam temp = teams[j]; teams[j] = teams[j + 1];
                    teams[j + 1] = temp;
                }
            }
        }
    }
}