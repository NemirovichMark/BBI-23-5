using System;

namespace Level1
{
    struct Student
    {
        string _name;
        int _mark;
        int _missed;
        public int Mark { get { return _mark; } }
        public int Missed { get { return _missed; } }
        public Student(string name, int mark, int missed)
        {
            _name = name;
            _mark = mark;
            _missed = missed;
        }
        public void Print()
        {
            Console.WriteLine($"{_name} - оценка: {_mark}, пропущенных занятий: {_missed}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Student[] students = {new Student("Иванов", 5, 3), new Student("Петров", 2, 17), new Student("Сидоров", 3, 6),
            new Student("Александров", 2, 9), new Student("Петров", 2, 8), new Student("Романов", 0, 30)};
            ShellSort(students);
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i].Mark == 2)
                {
                    students[i].Print();
                }
            }
        }

        static void ShellSort(Student[] arr)
        {
            int n = arr.Length;
            int gap = n / 2;
            while (gap > 0)
            {
                for (int i = gap; i < n; i++)
                {
                    Student temp = arr[i];
                    int j = i;
                    while (j >= gap && arr[j - gap].Miss < temp.Miss)
                    {
                        arr[j] = arr[j - gap];
                        j -= gap;
                    }
                    arr[j] = temp;
                }
                gap /= 2;
            }
        }
    }
}

