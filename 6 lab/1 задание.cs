using System;
using System.Collections.Generic;

public struct Runner
{
    public string LastName { get; private set; }
    public string Group { get; private set; }
    public string Teacher { get; private set; }
    public double Result { get; private set; }

    public Runner(string lastName, string group, string teacher, double result)
    {
        LastName = lastName;
        Group = group;
        Teacher = teacher;
        Result = result;
    }

    public void DisplayHeader()
    {
        Console.WriteLine($"{"Фамилия",-15}{"Группа",-10}{"Преподаватель",-20}{"Результат",-15}");
    }

    public void Display()
    {
        Console.WriteLine($"{LastName,-15}{Group,-10}{Teacher,-20}{Result,-15}");
    }

    public static int CountRunners(List<Runner> runners, double normative)
    {
        int count = 0;
        foreach (var runner in runners)
        {
            if (runner.Result <= normative)
                count++;
        }
        return count;
    }
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

            Runner runner = new Runner(lastName, group, teacher, result);
            runners.Add(runner);
        }

        Console.Write("\nВведите условие для норматива: ");
        double normative = double.Parse(Console.ReadLine());

        // Сортировка пузырьком
        for (int i = 0; i < runners.Count - 1; i++)
        {
            for (int j = 0; j < runners.Count - 1 - i; j++)
            {
                if (runners[j].Result > runners[j + 1].Result)
                {
                    Runner temp = runners[j];
                    runners[j] = runners[j + 1];
                    runners[j + 1] = temp;
                }
            }
        }

        Console.WriteLine("\nРезультирующая таблица:");
        runners[0].DisplayHeader();
        foreach (Runner runner in runners)
        {
            runner.Display();
        }

        int qualifiedCount = Runner.CountRunners(runners, normative);
        Console.WriteLine($"\nКоличество участниц, выполнивших норматив: {qualifiedCount}");
    }
}