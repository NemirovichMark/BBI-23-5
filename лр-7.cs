//задание 1.4
//using System;
// abstract class Participant
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
//        set { disqualified = value; }
//    }
//}

//class Sportsman : Participant
//{
//    public int dis = 0;
//    public Sportsman(string name, double rez1, double rez2) : base(name, rez1, rez2)
//    {
//    }
//    public override double bestrez()
//    {

//        if (this.Disqualified)
//        {
//            return 0;
//            dis++;
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

//        sp[2].Disqualified = true;

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
//        for (int i = 0; i < sp.Length - 1; i++) //исправить длину (я хз как)
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

//    public class CompetitionFigure
//    {
//        private Skater[] _skaters;

//        public CompetitionFigure(Skater[] skaters)
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

//        Figureskating figureskating = new Figureskating("single skating");
//        figureskating.DisplayDisciplineName();

//        CompetitionFigure competition = new CompetitionFigure(sk);
//        competition.DisplayResults();

//        Speedskating speedskating = new Speedskating("short track");
//        speedskating.DisplayDisciplineName();
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
    public MenTeam (int[] places) : base (places) { }
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
        int[] placesWomenTeam = { 1, 2, 6, 8, 10, 12 };
        int[] placesMenTeam1 = { 3, 4, 5, 9, 11, 15 };
        int[] placesMenTeam2 = { 7, 13, 14, 16, 17, 18 };

        Team menteam1 = new MenTeam(placesMenTeam1);
        Team menteam2 = new MenTeam(placesMenTeam2);
        Team womenteam = new WomenTeam(placesWomenTeam);

        int pointsMenTeam1 = menteam1.CalculatePoints();
        int pointsMenTeam2 = menteam2.CalculatePoints();
        int pointsWomenTeam = womenteam.CalculatePoints();

        if (pointsMenTeam1 > pointsMenTeam2 && pointsMenTeam1 > pointsWomenTeam)
        {
            Console.WriteLine("Команда мужчин 1 - победитель!");
        }
        else if (pointsMenTeam2 > pointsMenTeam1 && pointsMenTeam2 > pointsWomenTeam)
        {
            Console.WriteLine("Команда мужчин 2 - победитель!");
        }
        else if (pointsWomenTeam > pointsMenTeam1 && pointsWomenTeam > pointsMenTeam2)
        {
            Console.WriteLine("Команда женщин - победитель!");
        }
        else if (placesMenTeam1[0] == placesMenTeam2[0] && placesMenTeam1[0] == placesWomenTeam[0])
        {
            Console.WriteLine("Победила команда 1, так как участник с 1 места выступает за нее.");
        }
    }
}