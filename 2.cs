struct JumpData
{
    private string surname;
    private double[] results;
    private double level; // коэффициент
    public double total { get; set; }

    public JumpData(string _surname, double _level = 2.5)
    {
        surname = _surname;
        level = _level;
        Random rand = new Random();
        results = new double[7]; //  количество результатов  7 (результаты судей)
        for (int i = 0; i < 7; i++)
        {
            results[i] = rand.NextDouble() * 4 + 1; // Здесь генерируем рандомные оценки от 1 до 5
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
        Console.WriteLine("Sportsman {0, 10}: {1, 2:f0}", surname, this.getTotalResult());
        Console.Write("-> Jumps: ");
        for (int i = 0; i < 7; i++)
        {
            Console.Write("{0, 2:f1} ", results[i]);
        }
        Console.WriteLine("\n");
    }

}

class Program
{
    static void Sort(JumpData[] results, int n) // измененная сортировка
    {
        int i = 0, j = 1;
        while (i < n)
        {
            if (i == 0 || results[i].total >= results[i - 1].total)
            {
                i = j;
                i++;
            }
            else
            {
                JumpData temp = results[i];
                results[i] = results[i - 1];
                results[i - 1] = temp;
                i--;
            }
        }
    }
    static void Main(string[] args)
    {
        int N = 5;

        string[] surnames =
        {
            "Ivanova",
            "Petrova",
            "Rudenko",
            "Klochay",
            "Vasnecova"
        };

        JumpData[] results = new JumpData[N];
        Random rand = new Random();

        for (int i = 0; i < N; i++)
        {
            int surnameIndex = rand.Next(surnames.Length);
            double level = 2.5 + rand.NextDouble();
            JumpData jumpData = new JumpData(surnames[surnameIndex], level);
            results[i] = jumpData;
        }

        Sort(results, N);

        foreach (JumpData data in results)
        {
            data.Print();
        }
    }
}
