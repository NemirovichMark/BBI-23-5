using System;

public struct Student
{
    public int Group { get; private set; }
    private double[] examScores;

    public Student(int group)
    {
        Group = group;
        examScores = new double[4];

        Console.WriteLine($"Введите оценки для группы {Group}:");

        for (int i = 0; i < examScores.Length; i++)
        {
            Console.Write($"Оценка {i + 1}: ");
            examScores[i] = Convert.ToDouble(Console.ReadLine());
        }
    }

    public double AverageScore
    {
        get
        {
            double sum = 0;
            foreach (var score in examScores)
            {
                sum += score;
            }
            return sum / examScores.Length;
        }
    }

    public void DisplayStudentInfo()
    {
        Console.WriteLine($"{Group}\t{AverageScore}");
    }
}

class Program
{
    static void Main()
    {
        const int groupSize = 3; // Укажите нужный размер группы

        Student[] students = new Student[groupSize];

        for (int i = 0; i < groupSize; i++)
        {



            int group = i + 1;

            students[i] = new Student(group);
        }

        BubbleSort(ref students);

        Console.WriteLine("\nГруппа\tСредний балл");
        foreach (var student in students)
        {
            student.DisplayStudentInfo();
        }
    }

    static void BubbleSort(ref Student[] array)
    {
        int n = array.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (array[j].AverageScore < array[j + 1].AverageScore)
                {
                    // Обмен элементов массива, если текущий элемент меньше следующего
                    Student temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
    }
}
