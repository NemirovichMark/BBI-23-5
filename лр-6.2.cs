////задание 1.4
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
//    private double bestrez;
//    public Sportsman(string name, double rez1, double rez2)
//    {
//        this.name = name;
//        this.rez1 = rez1;
//        this.rez2 = rez2;
//        this.bestrez = CalculateBestResult();
//    }
//    private double CalculateBestResult()
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
//    public double GetBestResult()
//    {
//        return bestrez;
//    }
//    public void DisplayResult()
//    {
//        Console.WriteLine("Имя: {0} Лучший результат: {1:f2}", name, bestrez);
//    }

//    public static void DisplayResults(Sportsman[] sportsmen)
//    {
//        Console.WriteLine("Results:");
//        foreach (var sportsman in sportsmen)
//        {
//            sportsman.DisplayResult();
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
//                if (sp[j].GetBestResult() < sp[j + 1].GetBestResult())
//                {
//                    Sportsman temp = sp[j];
//                    sp[j] = sp[j + 1];
//                    sp[j + 1] = temp;
//                }
//            }
//        }
//        Sportsman.DisplayResults(sp);
//    }
//}



//задание 2.9

using System;
class Program
{
    public struct Skater
    {
        private string _surname;
        private int[] _scores;

        public Skater(string surname, int[] score)
        {
            _surname = surname;
            _scores = score;
        }
        public string GetName()
        {
            return _surname;
        }
        public int GetScore(int judge)
        {
            return _scores[judge];
        }
        public int TotalPlace = 1;
    }

    public struct Competition
    {
        private Skater[] _skaters;

        public Competition(Skater[] skaters)
        {
            _skaters = skaters;
        }
        public void InsertSort()
        {
            for (int judge = 0; judge < 7; judge++)
            {
                for (int i = 1; i < _skaters.Length; i++)
                {
                    var key = _skaters[i];//сохраняет текущего спортсмена в переменной key;
                    int j = i - 1;//начинаем сравнение с предыдущего спортсмена;

                    while (j >= 0 && _skaters[j].GetScore(judge) < key.GetScore(judge))//Пока мы не достигли начала массива и результат предыдущего спортсмена меньше текущего
                    {
                        _skaters[j + 1] = _skaters[j];//сдвигаем элемент
                        j = j - 1;
                    }

                    _skaters[j + 1] = key;//устанавливаем элемент на нужное место
                }
            }

            for (int i = 0; i < _skaters.Length; i++)
            {
                _skaters[i].TotalPlace += i + 1;
            }

            for (int i = 1; i < _skaters.Length; i++)
            {
                var key = _skaters[i];
                int j = i - 1;
                
                while (j >= 0 && _skaters[j].TotalPlace > key.TotalPlace)
                {
                    _skaters[j + 1] = _skaters[j];
                    j = j - 1;
                }

                _skaters[j + 1] = key;
            }
        }
        public void DisplayResults()
        {
            Console.WriteLine("Результаты соревнования:");
            foreach (var skater in _skaters)
            {
                Console.WriteLine($"{skater.GetName()}: место - {skater.TotalPlace}");
            }
        }
    }
    static void Main()
    {
        Skater[] sk = new Skater[5];
        sk[0] = new Skater("Иванов", new int[] { 1, 5, 3, 4, 2, 2, 6 });
        sk[1] = new Skater("Петров", new int[] { 2, 3, 4, 5, 6, 0, 1 });
        sk[2] = new Skater("Сидоров", new int[] { 3, 4, 5, 6, 5, 1, 2 });
        sk[3] = new Skater("Вербин", new int[] { 0, 0, 0, 2, 3, 5, 0 });
        sk[4] = new Skater("Кузьмин", new int[] { 5, 1, 2, 0, 4, 6, 3 });


        Competition competition = new Competition(sk);
        competition.InsertSort();
        competition.DisplayResults();
    }
}
