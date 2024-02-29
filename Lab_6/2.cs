using System;

namespace Level2
{
    internal class Program
    {
        struct Student
        {
            string _name;
            double[] _results;
            public Student(string name, double[] results)
            {
                _name = name;
                _results = results;
            }
            public double avg()
            {
                return (_results[0] + _results[1] + _results[2] + _results[3])/4;
            }
            public void Print()
            {
                Console.WriteLine($"{_name}: {avg()}");
            }
        }
        static void Main(string[] args)
        {
            Student[] students = { new Student("Иванов", new double[] { 3, 5, 5, 4 }), new Student("Петров", new double[] { 3, 5, 4, 4 }),
            new Student("Сидоров", new double[] { 5, 4, 5, 5 }), new Student("Ермаков", new double[] { 3, 3, 3, 4 }),
            new Student("Романов", new double[] { 3, 4, 3, 3 }), new Student("Александров", new double[] { 3, 4, 5, 5 })};
            Sort(students);
            Console.WriteLine("Фамилия: оценка");
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i].avg() >= 4)
                {
                    students[i].Print();
                }
            }
        }
        static void Sort(Student[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                for (int j = 1; j < arr.Length; j++)
                {
                    if (arr[j].avg() > arr[j - 1].avg())
                    {
                        Student temp = arr[j];
                        arr[j] = arr[j - 1];
                        arr[j - 1] = temp;
                    }
                }
            }
        }
    }
}
