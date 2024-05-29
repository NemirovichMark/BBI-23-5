using System;

struct Disciple
{
    private string name;
    private int age;
    private int[] grades;
    private double averageGrade;
    private bool isHonour;

    public Disciple(string name, int age, int[] grades)
    {
        this.name = name;
        this.age = age;
        this.grades = grades;
        this.averageGrade = 0;
        this.isHonour = true;
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

    public string Name { get { return name;  }}

    public int Age { get { return age; } }

}

class Program
{
    static void Main()
    {
        int[][] allGrades = new int[][]
        {
            new int[] {5, 4, 3, 5, 5},
            new int[] {4, 5, 4, 4, 5},
            new int[] {3, 4, 5, 3, 4},
            new int[] {5, 5, 5, 5, 5},
            new int[] {4, 3, 5, 4, 4}
        };

        Disciple[] disciples = new Disciple[5];

        disciples[0] = new Disciple("Сидоров", 20, allGrades[0]);
        disciples[1] = new Disciple("Олещенко", 21, allGrades[1]);
        disciples[2] = new Disciple("Петрова", 19, allGrades[2]);
        disciples[3] = new Disciple("Громозда", 22, allGrades[3]);
        disciples[4] = new Disciple("Яворский", 19, allGrades[4]);

        for (int i = 0; i < disciples.Length - 1; i++)
        {
            for (int j = i + 1; j < disciples.Length; j++)
            {
                if (string.Compare(disciples[i].Name, disciples[j].Name) > 0)
                {
                    var temp = disciples[i];
                    disciples[i] = disciples[j];
                    disciples[j] = temp;
                }
            }
        }


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
