

using System;

namespace level2
{
    internal class Program
    {
        abstract class Human
        {
            protected string _name;

            public Human(string name)
            {
                _name = name;
            }

            protected string GetName()
            {
                return _name;
            }
        }

        class Student : Human
        {
            private int _studentId;
            private double[] _results;

            public Student(string name, double[] results, int studentId) : base(name)
            {
                _results = results;
                _studentId = studentId;
            }

            public virtual double CalculateAverage()
            {
                return (_results[0] + _results[1] + _results[2] + _results[3]) / 4;
            }

            public void Print()
            {
                Console.WriteLine($"{GetName()}: {_studentId} - {CalculateAverage()}");
            }

            public static void Sort(Student[] arr)
            {
                if (arr.Length <= 1)
                    return;

                int middle = arr.Length / 2;
                Student[] left = new Student[middle];
                Student[] right = new Student[arr.Length - middle];

                for (int i = 0; i < middle; i++)
                {
                    left[i] = arr[i];
                }
                for (int i = middle; i < arr.Length; i++)
                {
                    right[i - middle] = arr[i];
                }

                Sort(left);
                Sort(right);
                Merge(arr, left, right);
            }

            private static void Merge(Student[] arr, Student[] left, Student[] right)
            {
                int leftIndex = 0;
                int rightIndex = 0;
                int mergedIndex = 0;

                while (leftIndex < left.Length && rightIndex < right.Length)
                {
                    if (left[leftIndex].CalculateAverage() > right[rightIndex].CalculateAverage())
                    {
                        arr[mergedIndex] = left[leftIndex];
                        leftIndex++;
                    }
                    else
                    {
                        arr[mergedIndex] = right[rightIndex];
                        rightIndex++;
                    }
                    mergedIndex++;
                }

                while (leftIndex < left.Length)
                {
                    arr[mergedIndex] = left[leftIndex];
                    leftIndex++;
                    mergedIndex++;
                }

                while (rightIndex < right.Length)
                {
                    arr[mergedIndex] = right[rightIndex];
                    rightIndex++;
                    mergedIndex++;
                }
            }
        }

        static void Main(string[] args)
        {
            Student[] students = {
                new Student("иванов", new double[] { 3, 5, 5, 4 }, 1234),
                new Student("петров", new double[] { 3, 5, 4, 4 }, 2345),
                new Student("сидоров", new double[] { 5, 4, 5, 5 }, 3456),
                new Student("ермаков", new double[] { 3, 3, 3, 4 }, 4567),
                new Student("романов", new double[] { 3, 4, 3, 3 }, 5678),
                new Student("александров", new double[] { 3, 4, 5, 5 }, 6789)
            };

            Student.Sort(students);
            Console.WriteLine("фио: № студ. билета - оценка");
            foreach (var student in students)
            {
                if (student.CalculateAverage() >= 4)
                {
                    student.Print();
                }
            }
        }
    }
}
