//задание 1.4
//using System;
//struct Sportsman
//{
//    private string name;
//    public string Name
//    {
//        get { return name; }
//    }
//    private double rez1;
//    private double rez2;
//    public Sportsman(string name, double rez1, double rez2)
//    {
//        this.name = name;
//        this.rez1 = rez1;
//        this.rez2 = rez2;
//    }

//    public double bestrez()
//    {
//        if (rez1 < rez2)
//        {
//            return rez2;
//        }
//        else
//        {
//            return rez1;
//        }
//    }
//}
//class program
//{
//    static void Main(string[] args)
//    {
//        Sportsman[] sp = new Sportsman[5];
//        sp[0] = new Sportsman("Nick", 1.50, 3.40);
//        sp[1] = new Sportsman("Vlad", 2.50, 3.10);
//        sp[2] = new Sportsman("Jake", 1.24, 1.40);
//        sp[3] = new Sportsman("Dave", 4.50, 2.40);
//        sp[4] = new Sportsman("Ivan", 2.64, 2.75);

//        for (int i = 0; i < sp.Length - 1; i++)
//        {
//            for (int j = 0; j < sp.Length - 1 - i; j++)
//            {
//                if (sp[j].bestrez() < sp[j + 1].bestrez())
//                {
//                    Sportsman temp = sp[j];
//                    sp[j] = sp[j + 1];
//                    sp[j + 1] = temp;
//                }
//            }
//        }

//        Console.WriteLine("Results:");
//        for (int i = 0; i < sp.Length; i++)
//        {
//           Console.WriteLine("Имя: {0} Лучший результат: {1:f2}", sp[i].Name, sp[i].bestrez());
//        }
//    }
//}



//задание 2.9

//using System;
//class Program
//{
//    public struct Skater
//    {
//        private string _surname;
//        private int[] _scores;

//        public Skater(string surname, int[] score)
//        {
//            _surname = surname;
//            _scores = score;
//        }
//        public string GetName()
//        {
//            return _surname;

//        }
//        public int GetScore(int judge)
//        {
//            return _scores[judge];
//        }
//        public int TotalPlace = 0;
//    }

//    public struct Competition
//    {
//        private Skater[] _skaters;

//        public Competition(Skater[] skaters)
//        {
//            _skaters = skaters;

//        }
//        public void DisplayResults()
//        {
//            for (int judge = 0; judge < 7; judge++)
//            {
//                for (int i = 0; i < _skaters.Length - 1; i++)
//                {
//                    for (int j = 0; j < _skaters.Length - 1 - i; j++)
//                    {

//                        if (_skaters[j].GetScore(judge) < _skaters[j + 1].GetScore(judge))
//                        {
//                            Skater temp = _skaters[j];
//                            _skaters[j] = _skaters[j + 1];
//                            _skaters[j + 1] = temp;
//                        }
//                    }
//                }
//                for (int i = 0; i < _skaters.Length; i++)
//                {
//                    _skaters[i].TotalPlace += i + 1;
//                }
//            }

//            for (int i = 0; i < _skaters.Length - 1; i++)
//            {
//                for (int j = 0; j < _skaters.Length - 1 - i; j++)
//                {

//                    if (_skaters[j].TotalPlace > _skaters[j + 1].TotalPlace)
//                    {
//                        Skater temp = _skaters[j];
//                        _skaters[j] = _skaters[j + 1];
//                        _skaters[j + 1] = temp;
//                    }
//                }
//            }
//            Console.WriteLine("Результаты соревнования:");
//            foreach (var skater in _skaters)
//            {
//                Console.WriteLine($"{skater.GetName()}: место - {skater.TotalPlace}");
//            }
//        }
//    }
//    static void Main()
//    {
//        Skater[] sk = new Skater[5];
//        sk[0] = new Skater("Иванов", new int[] { 1, 5, 3, 4, 2, 2, 6 });
//        sk[1] = new Skater("Петров", new int[] { 2, 3, 4, 5, 6, 0, 1 });
//        sk[2] = new Skater("Сидоров", new int[] { 3, 4, 5, 6, 5, 1, 2 });
//        sk[3] = new Skater("Вербин", new int[] { 0, 0, 0, 2, 3, 5, 0 });
//        sk[4] = new Skater("Кузьмин", new int[] { 5, 1, 2, 0, 4, 6, 3 });


//        Competition competition = new Competition(sk);
//        competition.DisplayResults();
//    }
//}


//задание 3.3
using System;

struct Team
{
    private int[] places;

    public Team(int[] places)
    {
        this.places = places;
    }

    public int CalculatePoints()
    {
        int points = 0;
        for (int i = 0; i < places.Length; i++)
        {
            points += 6 - places[i];
        }
        return points;
    }
}
class Program
{
    static void Main()
    {
        int[] placesTeam1 = { 1, 2, 6, 8, 10, 12 };
        int[] placesTeam2 = { 3, 4, 5, 9, 11, 15 };
        int[] placesTeam3 = { 7, 13, 14, 16, 17, 18 };

        Team team1 = new Team(placesTeam1);
        Team team2 = new Team(placesTeam2);
        Team team3 = new Team(placesTeam3);

        int pointsTeam1 = team1.CalculatePoints();
        int pointsTeam2 = team2.CalculatePoints();
        int pointsTeam3 = team3.CalculatePoints();

        if (pointsTeam1 > pointsTeam2 && pointsTeam1 > pointsTeam3)
        {
            Console.WriteLine("Команда 1 - победитель!");
        }
        else if (pointsTeam2 > pointsTeam1 && pointsTeam2 > pointsTeam3)
        {
            Console.WriteLine("Команда 2 - победитель!");
        }
        else if (pointsTeam3 > pointsTeam1 && pointsTeam3 > pointsTeam2)
        {
            Console.WriteLine("Команда 3 - победитель!");
        }
        else if (placesTeam1[0] == placesTeam2[0] && placesTeam1[0] == placesTeam3[0])
        {
            Console.WriteLine("Победила команда 1, так как участник с 1 места выступает за нее.");
        }
    }
}