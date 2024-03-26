using System;
using System.Collections.Generic;
using System.Text;

abstract class CrossRace
{
    protected string _surname;
    protected string _group;
    protected string _teacherLastName;
    protected double _result;
    protected double _norm;

    public string Surname => _surname;
    public string Group => _group;
    public string TeacherLastName => _teacherLastName;
    public double Result => _result;
    public double Norm => _norm;

    public CrossRace(string surname, string group, string teacherLastName, double result, double norm)
    {
        _surname = surname;
        _group = group;
        _teacherLastName = teacherLastName;
        _result = result;
        _norm = norm;
    }

    public void DisplayHeader()
    {
        Console.WriteLine($"{"Фамилия",-15}{"Группа",-10}{"Преподаватель",-20}{"Результат",-15}");
    }

    public virtual void Display()
    {
        Console.WriteLine($"{Surname,-15}{Group,-10}{TeacherLastName,-20}{Result,-15}");
    }

    public static int CountNorm(List<CrossRace> runners)
    {
        int count = 0;
        foreach (CrossRace runner in runners)
        {
            if (runner.Result <= runner.Norm)
            {
                count++;
            }
        }
        return count;
    }
}

class Sprinter100m : CrossRace
{
    public Sprinter100m(string surname, string group, string teacherLastName, double result, double norm)
        : base(surname, group, teacherLastName, result, norm) { }
}

class Sprinter500m : CrossRace
{
    public Sprinter500m(string surname, string group, string teacherLastName, double result, double norm)
        : base(surname, group, teacherLastName, result, norm) { }
}

class Program
{
    static void Main()
    {
        List<CrossRace> runners100m = new List<CrossRace>();
        List<CrossRace> runners500m = new List<CrossRace>();

        Console.Write("Введите норматив для забега на 100 метров (сек.): ");
        double norm100m = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите норматив для забега на 500 метров (сек.): ");
        double norm500m = Convert.ToDouble(Console.ReadLine());

        while (true)
        {
            Console.Write("Введите фамилию (или 'exit' для завершения): ");
            string surname = Console.ReadLine();

            if (surname.ToLower() == "exit")
                break;

            Console.Write("Введите группу: ");
            string group = Console.ReadLine();
            Console.Write("Введите фамилию преподавателя: ");
            string teacherLastName = Console.ReadLine();

            Console.Write("Введите результат забега 100м (сек.): ");
            double result100 = Convert.ToDouble(Console.ReadLine());
            runners100m.Add(new Sprinter100m(surname, group, teacherLastName, result100, norm100m));

            Console.Write("Введите результат забега 500м (сек.): ");
            double result500 = Convert.ToDouble(Console.ReadLine());
            runners500m.Add(new Sprinter500m(surname, group, teacherLastName, result500, norm500m));
        }
        //забег на 500м
        GnomeSort(runners500m);
        Console.WriteLine("\nТаблица забега на 500 метров:");
        runners500m[0].DisplayHeader();
        foreach (CrossRace runner in runners500m)
        {
            runner.Display();
        }
        Console.WriteLine($"\nУчастниц, выполнивших норматив: {CrossRace.CountNorm(runners500m)}");

        //забег на 100м
        GnomeSort(runners100m);
        Console.WriteLine("\nТаблица забега на 100 метров:");
        runners100m[0].DisplayHeader();
        foreach (CrossRace runner in runners100m)
        {
            runner.Display();
        }
        Console.WriteLine($"\nУчастниц, выполнивших норматив: {CrossRace.CountNorm(runners100m)}");



    }

    static void GnomeSort(List<CrossRace> runners)
    {
        int i = 0, j = 1;
        while (j < runners.Count - 1)
        {
            if (i < 0 || runners[i].Result >= runners[i + 1].Result)
            {
                i = j;
                j++;
            }
            while (i >= 0 && runners[i].Result < runners[i + 1].Result)
            {
                CrossRace temp = runners[i];
                runners[i] = runners[i + 1];
                runners[i + 1] = temp;
                i--;
            }
        }
    }
}
