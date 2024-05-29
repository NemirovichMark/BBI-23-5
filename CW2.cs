using System;

abstract class Disciple
{
    protected string name;
    protected int age;
    protected int[] grades;
    protected double averageGrade;
    protected bool isHonour;

    public Disciple(string name, int age, int[] grades)
    {
        this.name = name;
        this.age = age;
        this.grades = grades;
    }

    public void PrintAllDisciples(Disciple[] disciples)
    {
        foreach (var disciple in disciples)
        {
            Console.WriteLine(disciple.name);
        }
    }

    public void PrintGrades(Disciple disciple)
    {
        Console.WriteLine("Оценка по" + disciple.name + ":");
        foreach (var grade in disciple.grades)
        {
            Console.Write(grade + " ");
        }
        Console.WriteLine();
    }

    public bool CheckHonorStudent()
    {
        return averageGrade > 4.5;
    }

    public void PrintDisciple(Disciple disciple)
    {
        Console.WriteLine("Имя: " + disciple.name);
        Console.WriteLine("Возраст: " + disciple.age);
        Console.WriteLine("Средний балл: " + disciple.averageGrade);
        if (disciple.isHonour)
        {
            Console.WriteLine("Краснодипломник");
        }
    }

    public double CalculateAverageGrade()
    {
        double sum = 0;
        foreach (var grade in grades)
        {
            sum += grade;
        }
        return sum / grades.Length;
    }

    public string Name { get { return name; } }

    public int Age { get { return age; } }

}

class Pupil : Disciple
{
    protected int number_class;
    protected string specialization;

    public Pupil(string name, int age, int[] grades, int number_class, string specialization) : base(name, age, grades)
    {
        this.number_class = number_class;
        this.specialization = specialization;
    }


class Student : Disciple
    {
        protected int group;
        protected string loser;
        protected static int numberOfPaper;

        public Student(string name, int age, int[] grades, int group, int numberOfPaper) : base(name, age, grades)
        {
            this.group = group;
        }

        public void PrintInfoOfLoser()
        {
            foreach(int grade in grades)
            {
                if (grade == 2)
                {
                    Console.WriteLine("You are loser! Ты должник!");
                }
            }
        }
    }


class Program
{
    static void Main()
    {
        int[][] allGrades_Pupil = new int[][]
        {
            new int[] {5, 4, 3, 5, 5},
            new int[] {4, 5, 4, 4, 5},
            new int[] {3, 4, 5, 3, 4},
        };

        int[][] allGrades_Student = new int[][]
        {
            new int[] {5, 4, 3, 5, 5},
            new int[] {4, 5, 4, 4, 5},
        };

        Disciple[] disciples = new Pupil[3];

        disciples[0] = new Pupil("Сидоров", 20, allGrades_Pupil[0], 10, "Math");
        disciples[1] = new Pupil("Олещенко", 21, allGrades_Pupil[1], 9, "Chemistry");
        disciples[2] = new Pupil("Петрова", 19, allGrades_Pupil[2], 10, "Informatic");

        Disciple[] disciples_ = new Student[2];
        disciples_[3] = new Student("Громозда", 22, allGrades_Student[0], 235, 908);
        disciples_[4] = new Student("Яворский", 19, allGrades_Student[1], 235, 909);
            
           


        Console.WriteLine("Имя\t\tВозраст\tСредний балл\tКраснодипломник");
        foreach (var disciple in disciples)
        {
            Console.Write(disciple.Name + "\t\t");
            Console.Write(disciple.Age + "\t");
            Console.Write(disciple.CalculateAverageGrade() + "\t\t");
            Console.Write(disciple.CheckHonorStudent() ? "Yes" : "No");
            Console.WriteLine();
        }
    }
}
