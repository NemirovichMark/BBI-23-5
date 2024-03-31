
struct Lizhniki
{
    public string surname;
    public int time;
}

class Program
{
    static void Main()
    {
        Lizhniki[] group1 = {
            new Lizhniki { surname = "Иванов", time = 30 },
            new Lizhniki { surname = "Петров", time = 25 },
            new Lizhniki { surname = "Сидоров", time = 28 }
        };

        Lizhniki[] group2 = {
            new Lizhniki { surname = "Смирнов", time = 27 },
            new Lizhniki { surname = "Козлов", time = 26 },
            new Lizhniki { surname = "Морозов", time = 29 }
        };

        SortResults(group1);
        SortResults(group2);

        Console.WriteLine("Группа 1:");
        PrintResults(group1);

        Console.WriteLine("Группа 2:");
        PrintResults(group2);

        Lizhniki[] combinedResults = CombineResults(group1, group2);

        Console.WriteLine("Объединенные результаты:");
        PrintResults(combinedResults);
    }

    static void SortResults(Lizhniki[] results)
    {
        for (int i = 0; i < results.Length - 1; i++)
        {
            for (int j = 0; j < results.Length - 1 - i; j++)
            {
                if (results[j].time > results[j + 1].time)
                {
                    Lizhniki temp = results[j];
                    results[j] = results[j + 1];
                    results[j + 1] = temp;
                }
            }
        }
    }

    static void PrintResults(Lizhniki[] results)
    {
        Console.WriteLine("Фамилия\t\tВремя");
        foreach (var Lizhniki in results)
        {
            Console.WriteLine($"{Lizhniki.surname}\t\t{Lizhniki.time}");
        }
    }

    static Lizhniki[] CombineResults(Lizhniki[] group1, Lizhniki[] group2)
    {
        Lizhniki[] combinedResults = new Lizhniki[group1.Length + group2.Length];
        Array.Copy(group1, combinedResults, group1.Length);
        Array.Copy(group2, 0, combinedResults, group1.Length, group2.Length);

        SortResults(combinedResults);

        return combinedResults;
    }
}