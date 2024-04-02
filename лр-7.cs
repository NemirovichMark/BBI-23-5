//задание 1.4
//using System;
//abstract class Participant
//{
//    protected string name;
//    public string Name
//    {
//        get { return name; }
//    }
//    protected double rez1;
//    protected double rez2;

//    private bool disqualified;
//    public Participant(string name, double rez1, double rez2)
//    {
//        this.name = name;
//        this.rez1 = rez1;
//        this.rez2 = rez2;
//        disqualified = false;
//    }

//    public abstract double bestrez();

//    public bool Disqualified
//    {
//        get { return disqualified; }
//        set
//        {
//            if (value == true)  // Участник может быть только дисквалифицирован
//            {
//                disqualified = true;
//            }
//        }
//    }
//}

//class Sportsman : Participant
//{
//    public Sportsman(string name, double rez1, double rez2) : base(name, rez1, rez2)
//    {
//    }
//    public override double bestrez()
//    {

//        if (this.Disqualified)
//        {
//            return 0;
//        }
//        else
//        {
//            if (base.rez1 < base.rez2)
//            { return base.rez2; }
//            else
//            { return base.rez1; }
//        }

//    }
//}
//class Program
//{
//    static void Main(string[] args)
//    {
//        Sportsman[] sp = new Sportsman[5];
//        sp[0] = new Sportsman("Nick", 1.50, 3.40);
//        sp[1] = new Sportsman("Vlad", 2.50, 3.10);
//        sp[2] = new Sportsman("Jake", 1.24, 1.40);
//        sp[3] = new Sportsman("Dave", 4.50, 2.40);
//        sp[4] = new Sportsman("Ivan", 2.64, 2.75);

//        sp[2].Disqualified = true; // Дисквалифицируем участника по индексу 2

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
//        for (int i = 0; i < sp.Length - 1; i++) 
//        {
//            Console.WriteLine("Имя: {0} Лучший результат: {1:f2}", sp[i].Name, sp[i].bestrez());
//        }
//    }
//}



//задание 2.9

//using System;

//abstract class WinterSport
//{
//    protected string disciplineName;
//    public WinterSport(string name)
//    {
//        disciplineName = name;
//    }
//    public abstract void DisplayDisciplineName();
//}
//class Figureskating : WinterSport
//{
//    public Figureskating(string name) : base(name)
//    {
//    }
//    public override void DisplayDisciplineName()
//    {
//        Console.WriteLine($"Название дисциплины Фигурное катание: {disciplineName}");
//    }
//}

//class Speedskating : WinterSport
//{
//    public Speedskating(string name) : base(name)
//    {
//    }
//    public override void DisplayDisciplineName()
//    {
//        Console.WriteLine($"Название дисциплины Конькобежный спорт: {disciplineName}");
//    }
//}
//class Program
//{
//    public class Skater
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

//    public class Competition
//    {
//        private Skater[] _skaters;
//        private WinterSport _sport;

//        public Competition(Skater[] skaters, WinterSport sport)
//        {
//            _skaters = skaters;
//            _sport = sport;
//        }
//        public void DisplayResults()
//        {
//            Console.WriteLine($"Участвующие в соревнованиях по: ");
//            _sport.DisplayDisciplineName();
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

//        Figureskating figureskating = new Figureskating("single skating");
//        Competition competitionFigure = new Competition(sk, figureskating);
//        competitionFigure.DisplayResults();

//        Speedskating speedskating = new Speedskating("short track");
//        Competition competitionSpeed = new Competition(sk, speedskating);
//        competitionSpeed.DisplayResults();
//    }
//}



//задание 3.3
using System;

abstract class Team
{
    protected int[] places;

    public Team(int[] places)
    {
        this.places = places;
    }

    public abstract int CalculatePoints();
}
class WomenTeam : Team
{
    public WomenTeam(int[] places) : base(places) { }
    public override int CalculatePoints()
    {
        int points = 0;
        for (int i = 0; i < places.Length; i++)
        {
            points += 6 - places[i];
        }
        return points;
    }
}
class MenTeam : Team
{
    public MenTeam(int[] places) : base(places) { }
    public override int CalculatePoints()
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
        int[] placesWomenTeam1 = { 1, 2, 6, 8, 10, 12 };
        int[] placesWomenTeam2 = { 3, 4, 5, 9, 11, 15 };
        int[] placesWomenTeam3 = { 7, 13, 14, 16, 17, 18 };

        int[] placesMenTeam1 = { 1, 3, 5, 7, 9, 11 };
        int[] placesMenTeam2 = { 2, 4, 6, 8, 10, 12 };
        int[] placesMenTeam3 = { 13, 14, 15, 16, 17, 18 };

        Team[] womenTeams = new Team[3];
        womenTeams[0] = new WomenTeam(placesWomenTeam1);
        womenTeams[1] = new WomenTeam(placesWomenTeam2);
        womenTeams[2] = new WomenTeam(placesWomenTeam3);

        Team[] menTeams = new Team[3];
        menTeams[0] = new MenTeam(placesMenTeam1);
        menTeams[1] = new MenTeam(placesMenTeam2);
        menTeams[2] = new MenTeam(placesMenTeam3);

        Team maxWomenTeam = womenTeams[0];
        Team maxMenTeam = menTeams[0];

        foreach (var team in womenTeams)
        {
            if (team.CalculatePoints() > maxWomenTeam.CalculatePoints())
            {
                maxWomenTeam = team;
            }
        }

        foreach (var team in menTeams)
        {
            if (team.CalculatePoints() > maxMenTeam.CalculatePoints())
            {
                maxMenTeam = team;
            }
        }

        if (maxWomenTeam.CalculatePoints() > maxMenTeam.CalculatePoints())
        {
            Console.WriteLine("Победила женская команда!");
        }
        else
        {
            Console.WriteLine("Победила мужская команда!");
        }
    }
}