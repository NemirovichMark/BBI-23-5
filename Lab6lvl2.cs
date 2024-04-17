using System;

namespace Level2
{
    internal class Program
    {
        struct Student
        {
            string _name;
            double[] _results;
            double _average;
            public Student(string name, double[] results)
            {
                _name = name;
                _results = results;
                _average = 0;
                _average = CalculateAverage();
            }
            public double Average
            {
                get { return _average; }
            }

            private double CalculateAverage()
            {
                double sum = 0;
                foreach (double result in _results)
                {
                    sum += result;
                }
                return sum / _results.Length;
            }

            public void Print()
            {
                Console.WriteLine($"{_name}: {_average}");
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
                if (students[i].Average >= 4)
                {
                    students[i].Print();
                }
            }
        }
        static void Sort(Student[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[j].Average > arr[j + 1].Average)
                    {
                        Student temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }
    }
}
