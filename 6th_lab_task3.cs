struct Football
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

    public string Famile { get { return famile; } }

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
}

class Program
{
    static void Main(string[] args)
    {
        Football[] football = new Football[4];
        football[0] = new Football("Динамо");
        football[1] = new Football("Краснодар");
        football[2] = new Football("Металлург");
        football[3] = new Football("Сочи");

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

        for (int i = 1; i < 4; i++)
        {
            Match(ref football[0], ref football[i]);
        }

        Match(ref football[1], ref football[0]);
        Match(ref football[1], ref football[2]);
        Match(ref football[1], ref football[3]);

        Sort(ref football);

        for (int i = 0; i < football.Length; i++)
        {
            Console.WriteLine(football[i].Famile + " " + football[i].Score);
        }
    }
}
