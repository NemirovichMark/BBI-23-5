namespace _5_задание__3_уровень__7_лаба;

public class football_team
{
    public string name { get; set; }
    public int goals { get; set; }
    public int missed { get; set; }
    public int points { get; set; }
    public football_team(string name, int goals, int missed)
    {
        this.name = name;
        this.goals = goals;
        this.missed = missed;
        points = 0;
    }
    public void counting()
    {
       if (goals > missed)
        {
            points = 3;
        }
        else if(goals == missed)
        {
            points = 1;
        }
    }
}
class men_team : football_team
{
    public men_team(string name, int goals, int missed) : base(name, goals, missed)
    {

    }
}

class women_team : football_team
{
    public women_team(string name, int goals, int missed) : base(name, goals, missed)
    {

    }
}

class Program
{
    public static void gnom(football_team[] structures)
    {
        int i = 0;
        while (i < structures.Length)
        {
            if (i == 0)
            {
                i++;
            }
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
        football_team[] a = {new men_team ("pion", 2, 1),
            new women_team ( "paper" , 8, 3),
            new women_team ("parrot", 4, 7  ),
            new men_team ( "chiken" , 5, 12),
            new men_team ("mango", 9,  9 )
        };
       for (int i = 0; i < a.Length; i++)
        {
            a[i].counting();
        }
        gnom(a);
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] is women_team )
            {
                Console.WriteLine("Женская команда: " + a[i].name + " " + a[i].points);
            }
            else if (a[i] is men_team)
            {
                Console.WriteLine("Мужская команда: " + a[i].name + " " + a[i].points);
            }
        }
    }
}
