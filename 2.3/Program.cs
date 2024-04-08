//На основании результатов соревнований по прыжкам в длину
//(фамилии и результаты трех попыток) составить итоговый протокол
//соревнований, считая, что в зачет идет лучший результат.

struct Sportsmen
{
    private string familiya;
    private double try1;
    private double try2;
    private double try3;

    public Sportsmen(string f, double t1, double t2, double t3)
    {
        familiya = f;
        try1 = t1;
        try2 = t2;
        try3 = t3;
    }

    public double TheBestTry()
    {
        double max = try1;
        if (try2 > max)
        {
            max = try2;
        }
        if (try3 > max)
        {
            max = try3;
        }
        return max;
    }

    public void Print()
    {
        Console.WriteLine("Фамилия {0} \t Попытка №1 {1,3:f1} \t Попытка №2 {2,3:f1}\t Попытка №3 {3,3:f1}", familiya, try1, try2, try3);
        Console.WriteLine("Лучший результат: {0:f1}", TheBestTry());
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Sportsmen[] sp = new Sportsmen[5];
        sp[0] = new Sportsmen("Иванов", 2.3, 2.1, 2.4);
        sp[1] = new Sportsmen("Сидоров", 1.4, 2.6, 1.5);
        sp[2] = new Sportsmen("Петров", 3.2, 2, 1.3);
        sp[3] = new Sportsmen("Кравченко", 2.7, 2.4, 1.9);
        sp[4] = new Sportsmen("Макаров", 3.1, 2.8, 2.9);

        double[] bestTries = new double[sp.Length];
        for (int i = 0; i < sp.Length; i++)
        {
            bestTries[i] = sp[i].TheBestTry();
        }

        Sort(bestTries);


        Sportsmen[] SortSportsmen = new Sportsmen[sp.Length];
        for (int i = 0; i < sp.Length; i++)
        {
            foreach (var sportsman in sp)
            {
                if (sportsman.TheBestTry() == bestTries[i])
                {
                    SortSportsmen[i] = sportsman;
                    break;
                }
            }
        }

        foreach (var sportsman in SortSportsmen)
        {
            sportsman.Print();
        }
    }

    static void Sort(double[] array)
    {
        int n = array.Length;
        for (int i = 1; i < n; ++i)
        {
            double k = array[i];
            int j = i - 1;

            while (j >= 0 && array[j] > k)
            {
                array[j + 1] = array[j];
                j = j - 1;
            }
            array[j + 1] = k;
        }
    }
}
