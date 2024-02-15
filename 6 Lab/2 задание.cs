using System;
using System.Collections.Generic;

public class Program
{
    public struct Student
    {
        public string Name;
        public double[] Grades;
        public double AverageGrade;
    }

    static void Main(string[] args)
    {
        List<Student> students = new List<Student>();

        Console.WriteLine("Введите результаты экзаменов для студентов:");

        // Ввод результатов экзаменов для каждого студента
        while (true)
        {
            Student student = new Student();

            Console.Write("Введите имя студента (для прекращения ввода оставьте поле пустым): ");
            student.Name = Console.ReadLine();

            if (string.IsNullOrEmpty(student.Name))
                break;

            student.Grades = new double[4];
            double sum = 0;

            Console.WriteLine("Введите оценки для каждого из 4 предметов:");

            for (int i = 0; i < 4; i++)
            {
                Console.Write("Оценка для предмета " + (i + 1) + ": ");
                student.Grades[i] = double.Parse(Console.ReadLine());
                sum += student.Grades[i];
            }

            student.AverageGrade = sum / 4;
            students.Add(student);
        }

        Console.WriteLine("Результаты студентов с средним баллом не менее 4:");

        // Фильтрация и сортировка студентов
        List<Student> filteredStudents = FilterStudents(students);
        SortStudents(filteredStudents);

        // Вывод таблицы результатов
        PrintTable(filteredStudents);
    }

    static List<Student> FilterStudents(List<Student> students)
    {
        List<Student> filteredStudents = new List<Student>();

        foreach (var student in students)
        {
            if (student.AverageGrade >= 4)
                filteredStudents.Add(student);
        }

        return filteredStudents;
    }

    static void SortStudents(List<Student> students)
    {
        for (int i = 0; i < students.Count - 1; i++)
        {
            for (int j = 0; j < students.Count - i - 1; j++)
            {
                if (students[j].AverageGrade < students[j + 1].AverageGrade)
                {
                    var temp = students[j];
                    students[j] = students[j + 1];
                    students[j + 1] = temp;
                }
            }
        }
    }

    static void PrintTable(List<Student> students)
    {
        Console.WriteLine("------------------------------------------------------------------------");
        Console.WriteLine("|   Имя студента   |   Предмет 1  |  Предмет 2  |  Предмет 3  |  Предмет 4  |");
        Console.WriteLine("------------------------------------------------------------------------");

        foreach (var student in students)
        {
            Console.WriteLine($"|   {student.Name,-15} |   {student.Grades[0],-10} |  {student.Grades[1],-10} |  {student.Grades[2],-10} |  {student.Grades[3],-10} |");
        }

        Console.WriteLine("------------------------------------------------------------------------");
    }
}