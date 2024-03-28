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
        Team[] teams = new Team[]
        {
            new MenTeam(new int[] {7, 2, 3, 14, 6, 4}),
            new WomenTeam(new int[] {5, 8, 9, 10, 17, 12}),
            new WomenTeam(new int[] {13, 15, 1, 16, 11, 18})
        };

        int winnerIndex = 0;
        int maxPoints = 0;
        for (int i = 0; i < teams.Length; i++)
        {
            int points = teams[i].CalculatePoints();
            Console.WriteLine($"{teams[i].Gender} {i + 1}: набрала {points} баллов");
            if (points > maxPoints)
            {
                maxPoints = points;
                winnerIndex = i;
            }
        }
        Console.WriteLine($"Команда победитель: {teams[winnerIndex].Gender} {winnerIndex + 1}, набравшая {maxPoints} баллов.");
    }
}
