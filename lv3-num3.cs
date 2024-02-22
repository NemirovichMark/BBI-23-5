//lv 3 num 3
using System;
using System.Runtime.InteropServices;

struct TeamResult
{
    private int[] places;
    public TeamResult(int[] places)
    {
        this.places = places; 
    }
    public int[] Places
    {
        get { return places; }
        private set { places = value; }
    }
    public int CalculatePoints()
    {
        int totalpoints = 0;
        for (int i = 0; i < places.Length; i++)
        {
            int place = places[i];
            switch (place)
            {
                case 1:
                    totalpoints += 5;
                    break;
                case 2:
                    totalpoints += 4;
                    break;
                case 3:
                    totalpoints += 3;
                    break;
                case 4:
                    totalpoints += 2;
                    break;
                case 5:
                    totalpoints += 1;
                    break;
                default:
                    break;

            }
        }
        return totalpoints;
    }
}
class Programm
{
    static void Main()
    {
        TeamResult[] team = new TeamResult[]
        {
            new TeamResult ( new int[] {7, 2, 3, 14, 6, 4} ),
            new TeamResult (  new int[] {5, 8, 9, 10, 17, 12} ),
            new TeamResult (  new int[] {13, 15, 1, 16, 11, 18} )
        };
        for (int i = 0; i < team.Length; i++)
        {
            int totalpoints = team[i].CalculatePoints();
            Console.WriteLine($"Команда-{i + 1}: набрала {totalpoints} баллов ");
        }
        int winnerindex = 0;
        int maxpoint = team[0].CalculatePoints(); 
        for (int i = 1; i < team.Length; i++)
        {
            int currentpoints = team[i].CalculatePoints();
            if (currentpoints > maxpoint)  
            {
                maxpoint = currentpoints; 
                winnerindex = i;
            }
        }
        Console.WriteLine($"Команда {winnerindex + 1}: является победителем");
    }
}
