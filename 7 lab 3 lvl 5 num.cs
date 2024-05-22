class Football
{
    private string famile;
    private int pos_goal;
    private int con_goal;
    private int score;
    public Football(string famile)
    {
        this.famile = famile;
        this.pos_goal = 0;
        this.con_goal = 0;
        this.score = 0;
    }

    public void Result(int scored, int conceded)
    {
        pos_goal += scored;
        con_goal += conceded;
        if (scored > conceded)
        {
            score += 3;
        }
        else if (scored < conceded)
        {
            score += 1;
        }
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

class MenFootball : Football
{
    public MenFootball(string famile) : base(famile)
    {

    }
}


class Program
{
    static void Main(string[] args)
    {
        Football[] football = new Football[]
        {
            new WomenFootball("Динамо Женщины"),
            new WomenFootball("Краснодар Женщины"),
            new WomenFootball("ЦСКА Женщины"),

            new MenFootball("Динамо Мужчины"),
            new MenFootball("Краснодар Мужчины"),
            new MenFootball("ЦСКА Мужчины"),
        };
        static void Match(ref Football football1, ref Football football2)
        {
            Random random = new Random();
            int scored = random.Next(0, 5);
            int conceded = random.Next(0, 5);
            football1.Result(scored, conceded);
            football2.Result(conceded, scored);
        }

        static void Sort(ref Football[] footbals)
        {
            for (int i = 0; i < footbals.Length - 1; i++)
            {
                for (int j = 0; j < footbals.Length - i - 1; j++)
                {
                    if (footbals[j].Score < footbals[j + 1].Score ||
                        (footbals[j].Score == footbals[j + 1].Score && footbals[j].Minus < footbals[j + 1].Minus))
                    {

                        Football temp = footbals[j];
                        footbals[j] = footbals[j + 1];
                        footbals[j + 1] = temp;
                    }
                }
            }
        }

        Match(ref football[0], ref football[1]);
        Match(ref football[0], ref football[2]);
        Match(ref football[1], ref football[2]);
        // мужские команды
        Match(ref football[3], ref football[4]);
        Match(ref football[3], ref football[5]);
        Match(ref football[4], ref football[5]);


        Sort(ref football);

        for (int i = 0; i < football.Length; i++)
        {
            football[i].Get_Inf();
        }
    }
}