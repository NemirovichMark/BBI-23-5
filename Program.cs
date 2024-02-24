//задача 2лвл
class Program
{
    struct Athlete
    {
        private string _lastName;
        private double[] _attempts;
        private double _bestResult;
        public double BestResult => _bestResult;

        public Athlete(string lastName, double[] attempts)
        {
            _lastName = lastName;
            _attempts = attempts;
            _bestResult = FindBestResult(attempts);
        }

        private double FindBestResult(double[] attempts)
        {
            double best = attempts[0];
            for (int i = 1; i < attempts.Length; i++)
            {
                if (attempts[i] > best)
                {
                    best = attempts[i];
                }
            }
            return best;
        }

        public void Print()
        {
            Console.WriteLine($"{_lastName}\t Лучший результат {_bestResult}");
        }
    }

    static void Main()
    {
        Athlete[] athletes = new Athlete[5];
        athletes[0] = new Athlete("Иванов", new double[] { 238, 230, 240 });
        athletes[1] = new Athlete("Федунь", new double[] { 200, 210, 200 });
        athletes[2] = new Athlete("Сацик", new double[] { 190, 180, 185 });
        athletes[3] = new Athlete("Алейник", new double[] { 200, 198, 199 });
        athletes[4] = new Athlete("Кунгур", new double[] { 213, 213, 203 });

        Console.WriteLine("Протокол соревнований:");
        foreach (Athlete athlete in athletes)
        {
            athlete.Print();
        }

        Console.WriteLine("\nИтоговый протокол соревнований (учитывая лучший результат):");
        BestResult(athletes);
    }

    static void BestResult(Athlete[] athletes)
    {
        {
            int d = athletes.Length / 2;
            Athlete temp;
            while (d >= 1)
            {
                for (int i = d; i < athletes.Length; i++)
                {
                    int j = i;
                    while (j >= d && athletes[j - d].BestResult < athletes[j].BestResult)
                    {
                        temp = athletes[j];
                        athletes[j] = athletes[j - d];
                        athletes[j - d] = temp;
                        j = j - d;
                    }
                }
                d = d / 2;
            }
        }
        foreach (Athlete athlete in athletes)
        {
            athlete.Print();
        }
    }

}