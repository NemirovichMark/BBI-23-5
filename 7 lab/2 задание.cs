using System;
using System.Collections.Generic;

class Person
{
    public string Name { get; private set; }

    public Person(string name)
    {
        Name = name;
    }
}

class Student : Person
{
    private static int nextStudentId = 1001;
    public int StudentId { get; private set; }
    private int[] examScores;

    public Student(string name, int[] scores) : base(name)
    {
        StudentId = nextStudentId++;
        examScores = scores;
    }

    public double CalculateAverage()
    {
        double sum = 0;
        foreach (int score in examScores)
        {
            sum += score;
        }
        return sum / examScores.Length;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"{Name,-15} {StudentId,-12} {examScores[0],-12} {examScores[1],-12} {examScores[2],-12} {examScores[3],-12}");
    }
}

class Program
{
    static void Main()
    {
        List<Student> students = new List<Student>();

        Console.WriteLine("Известные результаты экзаменов для 5 учеников:");

        string[] names = { "Иванов", "Петров", "Сидоров", "Козлов", "Васильев" };
        int[][] knownScores = {
            new int[] { 4, 5, 3, 4 },
            new int[] { 5, 5, 4, 4 },
            new int[] { 3, 4, 3, 3 },
            new int[] { 5, 5, 5, 5 },
            new int[] { 4, 4, 4, 4 }
        };

        for (int i = 0; i < 5; i++)
        {
            Student student = new Student(names[i], knownScores[i]);
            students.Add(student);
        }

        Sort(students);

        Console.WriteLine($"{"Name",-15} {"Student ID",-12} {"Subject 1",-12} {"Subject 2",-12} {"Subject 3",-12} {"Subject 4",-12}");
        Console.WriteLine(new string('-', 75));

        foreach (var student in students)
        {
            if (student.CalculateAverage() >= 4)
            {
                student.DisplayInfo();
            }
        }
    }

    static void Sort(List<Student> students)
    {
        int n = students.Count;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (students[j].CalculateAverage() < students[j + 1].CalculateAverage())
                {
                    Student temp = students[j];
                    students[j] = students[j + 1];
                    students[j + 1] = temp;
                }
            }
        }
    }
}
