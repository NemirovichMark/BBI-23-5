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
            Sort(students);
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i].Mark == 2)
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
                    if (arr[j].Missed > arr[j - 1].Missed)
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
