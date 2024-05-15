using System;

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
        football[0] = new Football("барселона");
        football[1] = new Football("краснодар");
        football[2] = new Football("манчестер");
        football[3] = new Football("китай");

        static void Match(ref Football football1, ref Football football2)
        {
            Random random = new Random();
            int scored = random.Next(0, 5);
            int conceded = random.Next(0, 5);
            football1.Result(scored, conceded);
            football2.Result(conceded, scored);
        }

        static void GnomeSort(ref Football[] footbals)
        {
            int i = 1;
            int j = 2;

            while (i < footbals.Length)
            {
                if (i == 0 || footbals[i - 1].Score > footbals[i].Score ||
                    (footbals[i - 1].Score == footbals[i].Score && footbals[i - 1].Minus > footbals[i].Minus))
                {
                    i = j;
                    j++;
                }
                else
                {
                    Football temp = footbals[i];
                    footbals[i] = footbals[i - 1];
                    footbals[i - 1] = temp;

                    i--;
                    if (i == 0)
                    {
                        i = j;
                        j++;
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

        GnomeSort(ref football);

        for (int i = 0; i < football.Length; i++)
        {
            Console.WriteLine(football[i].Famile + " " + football[i].Score);
        }
    }
}
