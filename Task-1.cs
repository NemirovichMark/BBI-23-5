namespace task;

struct Student 
{
    private string surname;
    private int mark;
    private int misses;
    public Student(string surname, int mark, int misses)
    {
        this.surname = surname;
        this.mark = mark;
        this.misses = misses;
    }
    public int Mark { get { return mark; } } 
    public int Misses { get { return misses; } } 
    public void Print() 
    {
        Console.WriteLine(surname + ", пропусков: " + misses);
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите количество студентов:");
        int n = int.Parse(Console.ReadLine());
        Student[] students = new Student[n]; 
        Console.WriteLine();
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Фамилия:");
            string surname = Console.ReadLine();
            Console.WriteLine("Оценка:");
            int mark = int.Parse(Console.ReadLine());
            Console.WriteLine("Количество пропущенных занятий:");
            int misses = int.Parse(Console.ReadLine());
            students[i] = new Student(surname, mark, misses); 
            Console.WriteLine();
        }

        // сортировка массива студентов по количеству пропусков
        for (int i = 1; i < n; i++)
        {
            Student k = students[i];
            int j = i - 1;
            while (j >= 0 && students[j].Misses < k.Misses)
            {
                students[j + 1] = students[j];
                j = j - 1;
            }
            students[j + 1] = k;
        }

        Console.WriteLine();
        Console.WriteLine("Неуспевающие студенты:");
        for (int i = 0; i < n; i++)
        {
            if (students[i].Mark == 2)
            {
                students[i].Print();
            }
        }
    }
}