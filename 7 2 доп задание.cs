using System;

using System;

abstract class Team
{
    private int[] places;
    public Team(int[] places)
    {
        this.places = places;
    }
    public int[] Places
    {
        get { return places; }
    }
    public abstract string Gender { get; }
    public int CalculatePoints()
    {
        int totalPoints = 0;

        int[] pointsArray = new int[] { 0, 5, 4, 3, 2, 1 }; //массив  содерж значения очков для кажд места

        foreach (int place in places)
        {
            if (place >= 1 && place < pointsArray.Length) //в пределах массивов
            {
                totalPoints += pointsArray[place]; //двиг по мас
            }
        }

        return totalPoints;
    }
}


class WomenTeam : Team
{
    public WomenTeam(int[] places) : base(places) { }
    public override string Gender => "Женская команда";
}

class MenTeam : Team
{
    public MenTeam(int[] places) : base(places) { }
    public override string Gender => "Мужская команда";
}

class Program
{
    static void Main()
    {

        Team[] womenteam = new WomenTeam[]
        {
            new WomenTeam(new int[] {27,37,36,26,28,29}),
            new WomenTeam(new int[] {5, 8, 9, 10, 17, 12}),
            new WomenTeam(new int[] {13, 15, 1, 16, 11, 18})
        };
        Team[] menteam = new MenTeam[]
        {
            new MenTeam(new int[] {7, 2, 3, 14, 6, 4}),
            new MenTeam( new int [] {19,23,25,20,30,35}),
            new MenTeam(new int[] {21,24,33,34,31,22})
        };

        int winnerIndex = 0;
        Team winner = null; //обращаюсь к массивам - задаю нулевоке значение, чтобы не был объяв поб
        int maxpoints = 0;
        foreach (var team in womenteam)
        {
            int points = team.CalculatePoints();
            Console.WriteLine($"{team.Gender} набрала {points} баллов");
            if (points > maxpoints)
            {
                maxpoints = points;
                winner = team; //сохр победителя - команда
            }
        }
        foreach (var team in menteam)
        {
            int points = team.CalculatePoints();
            Console.WriteLine($"{team.Gender} набрала {points} баллов");
            if (points > maxpoints)
            {
                maxpoints = points;
                winner = team;
            }
        }
        if (winner != null) //если победитель!= пустой строке, тогда вывод
        {
            Console.WriteLine($"Победитель {winner.Gender} набравшая {maxpoints} баллов");
        }
    }
}
