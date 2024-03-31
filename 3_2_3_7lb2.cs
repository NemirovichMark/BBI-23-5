using System;

abstract class Discipline
{
    protected string _disciplineName;
    protected Athlete[] _athletes;

    public Discipline(string disciplineName, Athlete[] athletes)
    {
        _disciplineName = disciplineName;
        _athletes = athletes;
    }

    public abstract void Print();
    protected void SortAthletesByBestResult()
    {
        int n = _athletes.Length;
        int gap = n / 2;
        while (gap > 0)
        {
            for (int i = gap; i < n; i++)
            {
                Athlete temp = _athletes[i];
                int j = i;
                while (j >= gap && _athletes[j - gap].BestResult < temp.BestResult)
                {
                    _athletes[j] = _athletes[j - gap];
                    j -= gap;
                }
                _athletes[j] = temp;
            }
            gap /= 2;
        }
    }
}

class LongJump : Discipline
{
    public LongJump(string disciplineName, Athlete[] athletes) : base(disciplineName, athletes)
    {
    }

    public override void Print()
    {
        Console.WriteLine($"Дисциплина: {_disciplineName}");
        SortAthletesByBestResult();
        foreach (Athlete athlete in _athletes)
        {
            athlete.Print();
        }
    }
}

class HighJump : Discipline
{
    public HighJump(string disciplineName, Athlete[] athletes) : base(disciplineName, athletes)
    {
    }

    public override void Print()
    {
        Console.WriteLine($"Дисциплина: {_disciplineName}");
        SortAthletesByBestResult();
        foreach (Athlete athlete in _athletes)
        {
            athlete.Print();
        }
    }
}

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
        _bestResult = 0;
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

class Program
{
    static void Main()
    {
        Athlete[] longJumpAthletes = new Athlete[]
        {
            new Athlete("Гогчан", new double[] { 238, 230, 240 }),
            new Athlete("Федунь", new double[] { 200, 210, 200 }),
            new Athlete("Сацик", new double[] { 190, 180, 185 }),
            new Athlete("Алейник", new double[] { 200, 198, 199 }),
            new Athlete("Кунгур", new double[] { 213, 213, 203 })
        };

        Athlete[] highJumpAthletes = new Athlete[]
        {
            new Athlete("Гогчан", new double[] { 180, 185, 175 }),
            new Athlete("Федунь", new double[] { 190, 195, 192 }),
            new Athlete("Сацик", new double[] { 170, 175, 180 }),
            new Athlete("Алейник", new double[] { 185, 190, 195 }),
            new Athlete("Кунгур", new double[] { 175, 180, 185 })
        };

        Discipline longJump = new LongJump("Прыжки в длину", longJumpAthletes);
        Discipline highJump = new HighJump("Прыжки в высоту", highJumpAthletes);

        Console.WriteLine("Протокол соревнований:");
        longJump.Print();

        Console.WriteLine("\nИтоговый протокол соревнований (учитывая лучший результат):");
        highJump.Print();
    }
}
