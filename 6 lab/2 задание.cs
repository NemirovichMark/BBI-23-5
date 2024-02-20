using System;
using System.Text;

struct Student
{
    public string Name { get; private set; }
    private int[] examScores;

    public Student(string name, int score1, int score2, int score3, int score4)
    {
        Name = name;
        examScores = new int[] { score1, score2, score3, score4 };
    }

    public double CalculateAverage()
    {
        return (examScores[0] + examScores[1] + examScores[2] + examScores[3]) / 4.0;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"{Name,-15} {examScores[0],-12} {examScores[1],-12} {examScores[2],-12} {examScores[3],-12}");
    }
}

class Program
{
    static void Main()
    {
        List<Student> students = new List<Student>();

        Console.WriteLine("Введите результаты экзаменов для студентов:");

        // Ввод результатов экзаменов для каждого студента
        while (true)
        {


            Console.Write("Введите имя студента (для прекращения ввода оставьте поле пустым): ");

            string name = Console.ReadLine();

            if (string.IsNullOrEmpty(name))
                break;

            Console.Write("Оценка за Предмет 1: ");
            int score1 = int.Parse(Console.ReadLine());

            Console.Write("Оценка за Предмет 2: ");
            int score2 = int.Parse(Console.ReadLine());

            Console.Write("Оценка за Предмет 3: ");
            int score3 = int.Parse(Console.ReadLine());

            Console.Write("Оценка за Предмет 4: ");
            int score4 = int.Parse(Console.ReadLine());

            Student student = new Student(name, score1, score2, score3, score4);
            students.Add(student);
        }


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

        Console.WriteLine($"{"Name",-15} {"Subject 1",-12} {"Subject 2",-12} {"Subject 3",-12} {"Subject 4",-12}");
        Console.WriteLine(new string('-', 65));

        foreach (var student in students)
        {
            if (student.CalculateAverage() >= 4)
            {
                student.DisplayInfo();
            }
        }
    }

}