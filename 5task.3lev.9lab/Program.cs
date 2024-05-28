using Newtonsoft.Json;
namespace _5task._3lev._9lab;

public class football_team
{
    public string name { get; private set; }
    public int goals { get; private set; }
    public int missed { get; private set; }
    public int points { get; private set; }
    public string type { get; private set; }
    public football_team(string name, int goals, int missed, string type, int points)
    {
        this.name = name;
        this.goals = goals;
        this.missed = missed;
        this.type = type;
        this.points = points;
    }
    public void counting(List<football_team> b)
    {
        for (int i = 0; i < b.Count; i++)
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

    public men_team(string name, int goals, int missed, string type, int points) : base(name, goals, missed, type, points)
    {

    }
    public void print()
    {
        Console.WriteLine("Мужская команда " + name + " " + points);
    }
}

class women_team : football_team
{

    public women_team(string name, int goals, int missed, string type, int points) : base(name, goals, missed, type, points)
    {

    }
    public void print()
    {
        Console.WriteLine("Женская команда " + name + " " + points);
    }
}

class Program
{
    public static void gnom(List<football_team> structures)
    {
        int i = 1;
        while (i < structures.Count)
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
        List<football_team> team = new List<football_team>();
        team.Add(new women_team("pion", 2, 1, "Женская команда", 0));
        team.Add(new women_team("paper", 8, 3, "Женская команда", 0));
        team.Add(new women_team("parrot", 4, 7, "Женская команда", 0));
        team.Add(new women_team("chicken", 5, 12, "Женская команда", 0));
        team.Add(new women_team("mango", 9, 9, "Женская команда", 0));
        team.Add(new men_team("apple", 12, 1, "Мужская команда", 0));
        team.Add(new men_team("papers", 8, 23, "Мужская команда", 0));
        team.Add(new men_team("pets", 4, 4, "Мужская команда", 0));
        team.Add(new men_team("chicks", 5, 7, "Мужская команда", 0));
        team.Add(new men_team("milk", 6, 9, "Мужская команда", 0));

        foreach (var i in team)
        {
            i.counting(team);
        }

        gnom(team);
        string path_file = "footballers.json";
        if (File.Exists(path_file))
        {
            File.Delete(path_file);
        }
        json_serialisation.serilase_to_json(team, path_file);
        var footbalist = json_serialisation.deserilase_to_json<football_team>(path_file);
        string json = File.ReadAllText(path_file);
        var footballists = JsonConvert.DeserializeObject<List<football_team>>(json);
        foreach (var i in footballists)
        {
            Console.WriteLine(i.type + " " + i.name + " " + i.points);
        }
    }
}