using System;
using System.Collections.Generic;

public struct Runner
{
    public string LastName { get; set; }
    public string Group { get; set; }
    public string Teacher { get; set; }
    public double Result { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        List<Runner> runners = new List<Runner>();

        Console.WriteLine("Введите результаты кросса:");

        while (true)
        {
            Console.Write("Фамилия участницы (для прекращения ввода оставьте поле пустым): ");
            string lastName = Console.ReadLine();

            if (string.IsNullOrEmpty(lastName))
                break;

            Console.Write("Группа: ");
            string group = Console.ReadLine();

            Console.Write("Фамилия преподавателя: ");
            string teacher = Console.ReadLine();

            Console.Write("Результат: ");
            double result = double.Parse(Console.ReadLine());

            runners.Add(new Runner
            {
                LastName = lastName,
                Group = group,
                Teacher = teacher,
                Result = result
            });
        }

        Console.Write("Введите норматив: ");
        double norm = double.Parse(Console.ReadLine());

        Console.WriteLine("Результирующая таблица:");

        // Сортировка результатов
        runners = SortResults(runners);

        // Вывод таблицы
        Console.WriteLine("{0,-15} {1,-10} {2,-15} {3,-10}", "Фамилия", "Группа", "Преподаватель", "Результат");
        foreach (Runner runner in runners)
        {
            Console.WriteLine("{0,-15} {1,-10} {2,-15} {3,-10}", runner.LastName, runner.Group, runner.Teacher, runner.Result);
        }

        // Подсчет количества участниц, выполнивших норматив
        int count = CountParticipantsWithNorm(runners, norm);
        Console.WriteLine("Количество участниц, выполнивших норматив: " + count);
    }

    static List<Runner> SortResults(List<Runner> runners)
    {
        for (int i = 0; i < runners.Count - 1; i++)
        {
            for (int j = 0; j < runners.Count - i - 1; j++)
            {
                if (runners[j].Result > runners[j + 1].Result)
                {
                    Runner temp = runners[j];
                    runners[j] = runners[j + 1];
                    runners[j + 1] = temp;
                }
            }
        }

        return runners;
    }

    static int CountParticipantsWithNorm(List<Runner> runners, double norm)
    {
        int count = 0;
        foreach (Runner runner in runners)
        {
            if (runner.Result <= norm)
            {
                count++;
            }
        }
        return count;
    }
}