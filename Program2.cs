struct JumpData
{
    private string surname;
    private double[] results;
    private double level;
    public double total { get; set; }

    public JumpData(string _surname, double _level = 2.5)
    {
        surname = _surname;
        level = _level;
        Random rand = new Random();
        double avg = rand.NextDouble() * 4 + 1;
        results = new double[4];
        for (int i = 0; i < 4; i++)
        {
            results[i] = avg + (rand.NextDouble() * 3 - 1.5);
            results[i] = Math.Min(Math.Max(results[i], 0), 6); // Чтобы не перешёл за границы 0..6
        }
        total = this.getTotalResult();
    }

    public double getTotalResult()
    {
        double sum = results.Sum() - results.Max() - results.Min();
        sum *= level;
        return sum;
    }

    public void Print()
    {
        Console.WriteLine("Спортсмен {0, 10}: {1, 2:f0}", surname, this.getTotalResult());
        Console.Write("-> Прыжки: ");
        for (int i = 0; i < 4; i++)
        {
            Console.Write("{0, 2:f1} ", results[i]);
        }
        Console.WriteLine("\n");
    }

}
class Program
{
    static void Main(string[] args)
    {
        int N = 5;
        Random rand = new Random();
        string[] surnames =
        {
            "Васильев",
            "Кунгуров",
            "Сербов",
            "Калошин",
            "Букин",
            "Олейник",
            "Дидаев",
            "Сацик",
            "Алейникова",
        };
        JumpData[] results = new JumpData[N];
        for (int i = 0; i < N; i++)
        {
            int surnameIndex = rand.Next(surnames.Length);
            double level = 2.5 + rand.NextDouble();
            JumpData jumpData = new JumpData(surnames[surnameIndex], level);
            results[i] = jumpData;
        }
        static void Sort(JumpData[] results, int n)
        {
            int i = 0;
            while (i < n)
            {
                if (i == 0)
                    i++;
                if (results[i].total <= results[i - 1].total)
                    i++;
                else
                {
                    JumpData temp = results[i];
                    results[i] = results[i - 1];
                    results[i - 1] = temp;
                    i--;
                }


            }
        }
        Sort(results, N);
        foreach (JumpData data in results)
        {
            data.Print();
        }
    }
}