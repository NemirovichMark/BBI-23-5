//Cоздайте абстрактный класс Profession. В ней создайте поля название, надбавка за стаж и метод для расчета зарабатной платы. От него создайте 3 класса:
//Fireman с доп. полем надбавка за опасность, Engineer с доп полем категория, Scientist с доп полем степень. Переопределите метод для расчета зарплаты
//в каждом классе в зависимости от дополнительных свойств. Все поля заполнять через коонструктор из основной программы. В основной программе создайте массив
//из 5 работников каждой профессии. Отсортируйте их по убыванию зарплаты и выведите 3 таблицы. Соедините всех работников в один массив, отсортируйте по убыванию
//зарплаты и выведите их в виде таблицы.
using System;









class Fireman : Profession
{
    private double dangerBonus;

    public Fireman(string name, double experienceBonus, double dangerBonus) : base(name, experienceBonus)
    {
        this.dangerBonus = dangerBonus;
    }

    public override double CalculateSalary()
    {
        return 1000 + experienceBonus + dangerBonus;
    }
}


class Engineer : Profession
{
    private int category;

    public Engineer(string name, double experienceBonus, int category) : base(name, experienceBonus)
    {
        this.category = category;
    }

    public override double CalculateSalary()
    {
        return 1500 + experienceBonus + category * 100;
    }
}


class Scientist : Profession
{
    private string degree;

    public Scientist(string name, double experienceBonus, string degree) : base(name, experienceBonus)
    {
        this.degree = degree;
    }

    public override double CalculateSalary()
    {
        return 2000 + experienceBonus + (degree == "Доктор" ? 500 : 0);
    }
}
abstract class Profession
{
    protected string name;
    protected double experienceBonus;

    public Profession(string name, double experienceBonus)
    {
        this.name = name;
        this.experienceBonus = experienceBonus;
    }

    public abstract double CalculateSalary();

    class Program
    {
        static void Main()
        {

            Profession[] firemen = new Profession[]
            {
            new Fireman("Макс", 100, 50),
            new Fireman("Стас", 150, 60),
            new Fireman("Семен", 120, 55),
            new Fireman("Саша", 90, 45),
            new Fireman("Алексей", 110, 52)
            };

            Profession[] engineers = new Profession[]
            {
            new Engineer("Катя", 200, 1),
            new Engineer("Антон", 180, 2),
            new Engineer("Матвей", 220, 3),
            new Engineer("Саша", 190, 2),
            new Engineer("Глеб", 210, 3)
            };

            Profession[] scientists = new Profession[]
            {
            new Scientist("Олег", 250, "Доктор"),
            new Scientist("Алексей", 230, "Доцент"),
            new Scientist("Глеб", 270, "Доктор"),
            new Scientist("Богдан", 240, "Доцент"),
            new Scientist("Глеб", 260, "Доктор")
            };


            Profession[] allWorkers = new Profession[firemen.Length + engineers.Length + scientists.Length];
            Array.Copy(firemen, 0, allWorkers, 0, firemen.Length);
            Array.Copy(engineers, 0, allWorkers, firemen.Length, engineers.Length);
            Array.Copy(scientists, 0, allWorkers, firemen.Length + engineers.Length, scientists.Length);


            for (int i = 0; i < allWorkers.Length - 1; i++)
            {
                for (int j = i + 1; j < allWorkers.Length; j++)
                {
                    if (allWorkers[j].CalculateSalary() > allWorkers[i].CalculateSalary())
                    {
                        var temp = allWorkers[i];
                        allWorkers[i] = allWorkers[j];
                        allWorkers[j] = temp;
                    }
                }
            }


            Console.WriteLine("Firemen:");
            PrintTable(firemen);

            Console.WriteLine("\nEngineers:");
            PrintTable(engineers);

            Console.WriteLine("\nScientists:");
            PrintTable(scientists);


            Console.WriteLine("\nAll Workers:");
            PrintTable(allWorkers);
        }

        static void PrintTable(Profession[] workers)
        {
            Console.WriteLine("Name\tSalary");
            Console.WriteLine("--------------------");
            foreach (var worker in workers)
            {
                Console.WriteLine($"{worker.name}\t{worker.CalculateSalary()}");
            }
        }
    }
}