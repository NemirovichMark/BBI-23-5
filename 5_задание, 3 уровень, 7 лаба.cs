namespace _5_задание__3_уровень__7_лаба;

public class football_team
{
    public string name { get; private set; }
    public int goals { get; private set; }
    public int missed { get; private set; }
    public int points { get; private set; }
    public football_team(string name, int goals, int missed)
    {
        this.name = name;
        this.goals = goals;
        this.missed = missed;
        points = 0;
    }
    public void counting(football_team[]b)
    {
        for (int i = 0; i < b.Length; i++)
        {
            if (b[i].goals > b[i].missed)
            {
                b[i].points = 3;
            }
            else if (b[i].goals == b[i].missed)
            {
                b[i].points = 1;
            }
            else
            {
                b[i].points = 0;
            }
        }
        
    }

}

class men_team : football_team
{

    public men_team(string name, int goals, int missed) : base(name, goals, missed)
    {

    }
    public void print()
    {
        Console.WriteLine("Мужская команда " + name + " " + points);
    }
}

class women_team : football_team
{

    public women_team(string name, int goals, int missed) : base(name, goals, missed)
    {

    }
    public void print()
    {
        Console.WriteLine("Женская команда " + name + " " + points);
    }
}

class Program
{
    public static void gnom(football_team[] structures)
    {
        int i = 1;
        while (i < structures.Length)
        {
            if (structures[i].points <= structures[i - 1].points)
            {
                i++;
            }
            else
            {
                football_team box = structures[i];
                structures[i] = structures[i - 1];
                structures[i - 1] = box;
                if (i > 1)
                {
                    i--;
                }
                else
                {
                    i++;
                }
            }
        }
    }

    static void Main(string[] args)
    {
        women_team[] women = {
            new women_team("pion", 2, 1),
            new women_team("paper", 8, 3),
            new women_team("parrot", 4, 7),
            new women_team("chicken", 5, 12),
            new women_team("mango", 9, 9)
        };

        foreach (var woman in women)
        {
            woman.counting(women);
        }

        men_team[] men = {
            new men_team("apple", 12, 1),
            new men_team("papers", 8, 23),
            new men_team("pets", 4, 4),
            new men_team("chicks", 5, 7),
            new men_team("milk", 6, 9)
        };

        foreach (var man in men)
        {
            man.counting(men);
        }

        football_team[] together = new football_team[men.Length + women.Length];
        for (int i = 0; i < men.Length; i++)
        {
            together[i] = men[i];
        }

        for (int i = men.Length; i < men.Length + women.Length; i++)
        {
            together[i] = women[i - men.Length];
        }

        gnom(together);

        foreach (var team in together)
        {
            if (team is men_team men_Team)
            {
                men_Team.print();
            }
            if (team is women_team women_Team)
            {
                women_Team.print();
            }
        }
    }
}