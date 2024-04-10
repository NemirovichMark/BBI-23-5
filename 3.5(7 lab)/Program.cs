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
    public void Result(int scored, int conceded)
    {
        this.scored += scored;
        this.conceded += conceded;
        if (scored > conceded)
            points += 3;
        else if (scored == conceded)
            points += 1;
    }

    private int RAZNICA { get { return scored - conceded; } }


    public static void Print(FootballTeam[] teams)
    {
        Console.WriteLine($"{"Место",-7}  {"Команда",-25}  {"Очки",-25}");
        for (int i = 0; i < teams.Length; i++)
        {
            Console.WriteLine($"{i + 1,-5} | {teams[i].name,-23} | {teams[i].points,-25}");
            Console.WriteLine("--------------------------------------------");
        }
    }

    public static FootballTeam[] CombineArrays(FootballTeam[] t1, FootballTeam[] t2)
    {
        FootballTeam[] comboteam = new FootballTeam[t1.Length + t2.Length];
        int index = 0;
        foreach (FootballTeam team in t1)
        {
            comboteam[index] = team;
            index++;
        }
        foreach (FootballTeam team in t2)
        {
            comboteam[index] = team;
            index++;
        }
        return comboteam;
    }

    public static void Match(ref FootballTeam team1, ref FootballTeam team2)
    {
        Random random = new Random();
        int scored = random.Next(0, 5);
        int conceded = random.Next(0, 5);
        team1.Result(scored, conceded);
        team2.Result(conceded, scored);
    }
    public static void BubbleSort(FootballTeam[] teams)
    {
        for (int i = 0; i < teams.Length - 1; i++)
        {
            for (int j = 0; j < teams.Length - 1; j++)
            {
                if (teams[j].points < teams[j + 1].points ||
                   (teams[j].points == teams[j + 1].points && teams[j].RAZNICA < teams[j + 1].RAZNICA))
                {
                    FootballTeam temp = teams[j];
                    teams[j] = teams[j + 1];
                    teams[j + 1] = temp;
                }
            }
        }
    }
    static void Merge(FootballTeam[] targetarray, FootballTeam[] array1, FootballTeam[] array2)
    {
        int arrayMinIndex1 = 0;
        int arrayMinIndex2 = 0;
        int targetMinIndex = 0;
        int i = 0, j = 0, k = 0;
        //if (array1[arrayMinIndex1]<= array2[arrayMinIndex2])
        for (; i< array1.Length && j < array2.Length; k++) {
            if (array1[i].points > array2[j].points || (array1[i].points == array2[j].points && array1[i].RAZNICA > array2[j].RAZNICA))
            {
                targetarray[k] = array1[i];
                i++;
            }
            else
            {

                targetarray[k] = array2[j];
                j++;
            }
        }
    }
    static void MergeSort(FootballTeam[] array)
    {
        if (array.Length < 2)
        {
            return;
        }
        int mid = array.Length / 2;
        FootballTeam[] left = new FootballTeam[mid];
        FootballTeam[] right = new FootballTeam[array.Length - mid];
        for (int i = 0; i < mid; i++)
        {
            left[i] = array[i];

        }
        for (int i = mid; i < array.Length; i++)
        {
            right[i] = array[i];

        }
        MergeSort(left);
        MergeSort(right);
        
        


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
        };

        FootballTeam.Match(ref teams[0], ref teams[1]);
        FootballTeam.Match(ref teams[0], ref teams[2]);
        FootballTeam.Match(ref teams[1], ref teams[2]);

        FootballTeam[] Teams = new FootballTeam[]
        {
            new ManFootBall("ЦСКА Мужская сборная"),
            new ManFootBall("Динамо Мужская сборная"),
            new ManFootBall("Спартак Мужская сборная"),
        };

        FootballTeam.Match(ref Teams[0], ref Teams[1]);
        FootballTeam.Match(ref Teams[0], ref Teams[2]);
        FootballTeam.Match(ref Teams[1], ref Teams[2]);

        FootballTeam[] allTeams = FootballTeam.CombineArrays(teams, Teams);
        FootballTeam.BubbleSort(allTeams);
        FootballTeam.Print(allTeams);
    }

}
