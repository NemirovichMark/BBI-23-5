abstract class Discipline
{
    protected string _disciplineName;

    public Discipline(string disciplineName)
    {
        _disciplineName = disciplineName;
    }

    public abstract void Print();
}

class LongJump : Discipline
{
    public LongJump(string disciplineName) : base(disciplineName)
    {
    }

    public override void Print()
    {
        Console.WriteLine($"Дисциплина: {_disciplineName}");
    }
}

class HighJump : Discipline
{
    public HighJump(string disciplineName) : base(disciplineName)
    {
    }

    public override void Print()
    {
        Console.WriteLine($"Дисциплина: {_disciplineName}");
    }
}

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
        Discipline longJump = new LongJump("Прыжки в длину");
        Discipline highJump = new HighJump("Прыжки в высоту");

        Athlete[] athletes = new Athlete[5];
        athletes[0] = new Athlete("Гогчан", new double[] { 238, 230, 240 });
        athletes[1] = new Athlete("Федунь", new double[] { 200, 210, 200 });
        athletes[2] = new Athlete("Сацик", new double[] { 190, 180, 185 });
        athletes[3] = new Athlete("Алейник", new double[] { 200, 198, 199 });
        athletes[4] = new Athlete("Кунгур", new double[] { 213, 213, 203 });

        Console.WriteLine("Протокол соревнований:");

        longJump.Print();
        foreach (Athlete athlete in athletes)
        {
            athlete.Print();
        }

        Console.WriteLine("\nИтоговый протокол соревнований (учитывая лучший результат):");

        highJump.Print();
        BestResult(athletes);
    }

    static void BestResult(Athlete[] athletes)
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

        foreach (Athlete athlete in athletes)
        {
            athlete.Print();
        }
    }
}