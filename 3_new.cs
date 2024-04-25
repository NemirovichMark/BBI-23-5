
class Football
{
    private string famile;
    private int pos_goal;
    private int con_goal;
    private int score;

    public Football(string famile)
    {
        this.famile = famile;
    }

    public string Famile { get { return famile; } }

    public void Result(int scored, int conceded)
    {
        this.pos_goal += scored;
        this.con_goal += conceded;
        if (scored > conceded)
            score += 3;
        else if (scored == conceded)
            score += 1;
    }

    public int Score { get { return score; } }

    public int Minus { get { return pos_goal - con_goal; } }

    public void Get_Inf()
    {
        Console.WriteLine(famile + " " + score);
    }
}

class WomenFootball : Football
{
    public WomenFootball(string famile) : base(famile)
    {
    }
}

class ManFootball : Football
{
    public ManFootball(string name) : base(name)
    {
    }
}

class Program
{
    static void Main(string[] args)
    {
        Football[] football_women = new Football[]
        {
            new WomenFootball("Динамо Женщины"),
            new WomenFootball("Краснодар Женщины"),
            new WomenFootball("Металлург Женщины"),
        };


        Match(ref football_women[0], ref football_women[1]);
        Match(ref football_women[0], ref football_women[2]);
        Match(ref football_women[1], ref football_women[2]);

        Football[] football_men = new Football[]
        {
            new ManFootball("Динамо Мужчины"),
            new ManFootball("Краснодар Мужчины"),
            new ManFootball("Металлург Мужчины"),
        };

        Match(ref football_men[0], ref football_men[1]);
        Match(ref football_men[0], ref football_men[2]);
        Match(ref football_men[1], ref football_men[2]);

        Football[] all = Combine(football_women, football_men);

        Sort(all);

        for (int i = 0; i < all.Length; i++)
        {
            all[i].Get_Inf();
        }
    }

    static void Match(ref Football football1, ref Football football2)
    {
        Random random = new Random();
        int scored = random.Next(0, 5);
        int conceded = random.Next(0, 5);
        football1.Result(scored, conceded);
        football2.Result(conceded, scored);
    }

    static Football[] Combine(Football[] f1, Football[] f2)
    {
        Football[] combo = new Football[f1.Length + f2.Length];
        int index = 0;
        foreach (Football team in f1)
        {
            combo[index] = team;
            index++;
        }
        foreach (Football team in f2)
        {
            combo[index] = team;
            index++;
        }
        return combo;
    }

    static void Sort(Football[] teams)
    {
        for (int i = 0; i < teams.Length - 1; i++)
        {
            for (int j = 0; j < teams.Length - 1; j++)
            {
                if (teams[j].Score < teams[j + 1].Score ||
                   (teams[j].Score == teams[j + 1].Score && teams[j].Minus < teams[j + 1].Minus))
                {
                    Football temp = teams[j];
                    teams[j] = teams[j + 1];
                    teams[j + 1] = temp;
                }
            }
        }
    }
}