using System;

class Group
{
    private int id;
    public double[] examScores;

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    public double[] ExamScores
    {
        get { return examScores; }
        set { examScores = value; }
    }

    public double CalculateAverageScore()
    {
        double sum = 0;
        for (int i = 0; i < examScores.Length; i++)
        {
            sum += examScores[i];
        }
        return sum / examScores.Length;
    }
}

class Program
{
    static void SortGroupsByAverageScore(Group[] groups)
    {
        for (int i = 0; i < groups.Length - 1; i++)
        {
            for (int j = i + 1; j < groups.Length; j++)
            {
                if (groups[i].CalculateAverageScore() < groups[j].CalculateAverageScore())
                {
                    Group temp = groups[i];
                    groups[i] = groups[j];
                    groups[j] = temp;
                }
            }
        }
    }

    static void Main(string[] args)
    {
        const int GroupCount = 3;
        const int ExamCount = 5;

        Group[] groups = new Group[GroupCount];

        for (int i = 0; i < GroupCount; i++)
        {
            Console.WriteLine($"Введите оценки {ExamCount} экзаменов для группы {i + 1}:");

            groups[i] = new Group();
            groups[i].Id = i + 1;
            groups[i].ExamScores = new double[ExamCount];

            for (int j = 0; j < ExamCount; j++)
            {
                Console.Write($"Оценка {j + 1}: ");
                groups[i].ExamScores[j] = double.Parse(Console.ReadLine());
            }
        }

        SortGroupsByAverageScore(groups);

        Console.WriteLine("Группы в порядке убывания среднего балла:");
        Console.WriteLine("-------------------------");
        Console.WriteLine("|    Группа    |  Средний балл  |");
        Console.WriteLine("-------------------------");

        foreach (Group group in groups)
        {
            Console.WriteLine($"|      {group.Id}       |     {group.CalculateAverageScore()}    |");
        }
        Console.WriteLine("-------------------------");
    }
}