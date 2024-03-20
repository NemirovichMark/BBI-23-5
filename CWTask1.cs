using System;
using System.ComponentModel.Design;
using System.Xml.Linq;

struct Discipline
{
    private string name;
    private int age;
    private int[] grades;
    private double avergemark;
    private bool status;
    private string averagemark;

    public Discipline(string Name,int Age,int[] grades)
    {
        name= Name;
        age= Age;
        this.grades = grades;
        avergemark = CalculateAverage();
        status = StatusStudent();

    }

    public double CalculateAverage()
    {
        double total = 0;
        int count = 0;
        for (int i = 0; i < grades.Length; i++)
        {
            total += grades[i];
            count++;
        }
        return count == 0 ? 0 : total / count;
    }

    public string Name { get { return name; } }
    public int Age { get { return age;} }


    public bool StatusStudent()
    {
        return avergemark > 4.5;
    }

    public void Print()
    {
        Console.WriteLine("Имя: " + name);
        Console.WriteLine("Возраст: " + age);
        Console.WriteLine("Средний балл: " + averagemark);
        Console.WriteLine("Статус краснодипломника: " + (StatusStudent() ? "Да" : "Нет"));
    }
}

class Program
{
    static void Main()
    {
        int[,] grades = { {4, 5, 5}, { 3, 4, 5 } };
        int[,] grades2 = { { 5, 5, 5 }, { 4, 4, 3 } };
        int[,] grades3 = { { 5, 5, 5 }, { 5, 5, 5 } };
        int[,] grades4 = { { 3, 4, 4 }, { 4, 5, 4 } };
        int[,] grades5 = { { 5,4,5}, { 4,5,5} };


        Discipline[] students = {
            new Discipline("Александр", 20, grades),
            new Discipline("Мария", 19, grades2),
            new Discipline("Иван", 21, grades3),
            new Discipline("Екатерина", 22, grades4),
            new Discipline("Дмитрий", 20, grades5)
        };
        Sort(students);
        foreach(Discipline discipline in students)
        {
            discipline.Print();
        }
    }
    public void Sort(Discipline [] students)
    {
        int i = 1;
        int j = 2;
        while(i < students.Length)
        {
            int v = i - 1;
            if (students[i].Name <= students[i].Name)
            {
                i = j;
                j++;
            }
            else
            {
                Discipline temp = students[i - 1];
                students[i - 1] = students[i];
                students[i] = temp;
                i--;

                if(i==0)
                {
                    i = j;
                    j++;
                }
            }
        }
    }
}







































