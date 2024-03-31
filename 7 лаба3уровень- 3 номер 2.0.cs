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
        foreach (int place in places)
        {
            switch (place)
            {
                case 1:
                    totalPoints += 5;
                    break;
                case 2:
                    totalPoints += 4;
                    break;
                case 3:
                    totalPoints += 3;
                    break;
                case 4:
                    totalPoints += 2;
                    break;
                case 5:
                    totalPoints += 1;
                    break;
                default:
                    break;
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
        int maxPoints = 0;
        string winnerGender = "";
        for (int i = 0; i < womenteam.Length; i++)
        {
            int points = womenteam[i].CalculatePoints();
            Console.WriteLine($"{womenteam[i].Gender} {i + 1}: набрала {points} баллов");
            if (points > maxPoints)
            {
                maxPoints = points;
                winnerIndex = i;
                winnerGender = womenteam[i].Gender;
            }
        }

        for (int i = 0; i < menteam.Length; i++)
        {
            int points = menteam[i].CalculatePoints();
            Console.WriteLine($"{menteam[i].Gender} {i + 1}: набрала {points} баллов");
            if (points > maxPoints)
            {
                maxPoints = points;
                winnerIndex = i + womenteam.Length;
                winnerGender = menteam[i].Gender;
            }
        }
        if(winnerGender == "Женская команда")
        {
            Console.WriteLine($"Команда победитель: {winnerGender} ,{winnerIndex + 1} набравшая {maxPoints} баллов.");
        }
        else
        {
            Console.WriteLine($"Команда победитель: {winnerGender} ,{winnerIndex + womenteam.Length +1} набравшая {maxPoints} баллов.");
        }
 
    }
}
