using System;

//Создать класс «Группа» с набором общих для всех групп-наследников предметов (3-4) и от него 3 наследника (названия групп)
//с дополнительными 2 различными предметами. В наследниках переопределить метод расчета среднего балла за сессию.
//Вывести студентов всех групп единым списком. Использовать динамическую связку: преобразование классов.


//Абстрактный класс группы
public abstract class Group
{
    protected string _name { get; set; }
    protected double _averagemark;
    public double AverageMark;
    private Subject[] _subjects;
    public Subject[] Subjects => _subjects;
    protected Student[] _students;
    public Student[] Students => _students;

    //метод для наполнения базовых предметов
    public void SetMainSubjects()
    {
        _subjects = new Subject[5]
        {
            new Subject("Русский язык"),
            new Subject("Математика"),
            new Subject("Физика"),
            new Subject("Английский язык"),
            new Subject("История")
        };
    }

    public abstract void CalibrateSubjects();

    public abstract void ShowReport();
}

public class GroupA : Group
{
    //Доп. предметы
    private Subject AdditionalSubjectAA { get; set; }
    private Subject AdditionalSubjectAB { get; set; }

    public GroupA(string name, Student[] students)
    {
        _name = name;
        _students = students;
        SetMainSubjects();
        AdditionalSubjectAA = new Subject("Химия");
        AdditionalSubjectAB = new Subject("Органическая химия");
    }
    //Вычисление среднего балла
    public override void CalibrateSubjects()
    {
        double summOfScore = 0;

        foreach (var subject in Subjects)
            summOfScore += subject.Score;

        summOfScore += AdditionalSubjectAA.Score;
        summOfScore += AdditionalSubjectAB.Score;

        _averagemark = summOfScore / (Subjects.Length + 2);
    }

    public override void ShowReport()
    {
        Console.WriteLine($"====== Группа {_name} ======");
        Console.WriteLine($"Средний балл: {_averagemark}");

        foreach (var subject in Subjects)
        {
            Console.WriteLine($"{subject.Name} Оценка: {subject.Score}");
        }

        Console.WriteLine($"{AdditionalSubjectAA.Name} Оценка: {AdditionalSubjectAA.Score}");
        Console.WriteLine($"{AdditionalSubjectAB.Name} Оценка: {AdditionalSubjectAB.Score}");


        Console.WriteLine($"===========================");
    }
}
public class GroupB : Group
{
    //Доп. предметы
    private Subject AdditionalSubjectBA { get; set; }
    private Subject AdditionalSubjectBB { get; set; }

    public GroupB(string name, Student[] students)
    {
        _name = name;
        _students = students;
        SetMainSubjects();
        AdditionalSubjectBA = new Subject("Экономика");
        AdditionalSubjectBB = new Subject("Маркетинг");
    }
    //Вычисление среднего балла
    public override void CalibrateSubjects()
    {
        double summOfScore = 0;

        foreach (var subject in Subjects)
            summOfScore += subject.Score;

        summOfScore += AdditionalSubjectBA.Score;
        summOfScore += AdditionalSubjectBB.Score;

        AverageMark = summOfScore / (Subjects.Length + 2);
    }

    public override void ShowReport()
    {
        Console.WriteLine($"====== Группа {_name} ======");
        Console.WriteLine($"Средний балл: {AverageMark}");

        foreach (var subject in Subjects)
        {
            Console.WriteLine($"{subject.Name} Оценка: {subject.Score}");
        }

        Console.WriteLine($"{AdditionalSubjectBA.Name} Оценка: {AdditionalSubjectBA.Score}");
        Console.WriteLine($"{AdditionalSubjectBB.Name} Оценка: {AdditionalSubjectBB.Score}");


        Console.WriteLine($"===========================");
    }
}

public class GroupC : Group
{
    //Доп. предметы
    private Subject AdditionalSubjectCA { get; set; }
    private Subject AdditionalSubjectCB { get; set; }

    public GroupC(string name, Student[] students)
    {
        _name = name;
        _students = students;
        SetMainSubjects();
        AdditionalSubjectCA = new Subject("Дискретная математика");
        AdditionalSubjectCB = new Subject("Алгоритмизация");
    }
    //вычисление среднего балла
    public override void CalibrateSubjects()
    {
        double summOfScore = 0;

        foreach (var subject in Subjects)
            summOfScore += subject.Score;

        summOfScore += AdditionalSubjectCA.Score;
        summOfScore += AdditionalSubjectCB.Score;

        AverageMark = summOfScore / (Subjects.Length + 2);
    }
    //Отображение отчёта по группе
    public override void ShowReport()
    {
        Console.WriteLine($"====== Группа {_name} ======");
        Console.WriteLine($"Средний балл: {AverageMark}");

        foreach (var subject in Subjects)
        {
            Console.WriteLine($"{subject.Name} Оценка: {subject.Score}");
        }

        Console.WriteLine($"{AdditionalSubjectCA.Name} Оценка: {AdditionalSubjectCA.Score}");
        Console.WriteLine($"{AdditionalSubjectCB.Name} Оценка: {AdditionalSubjectCB.Score}");


        Console.WriteLine($"===========================");
    }
}

//Поток
public class Stream
{
    private Group[] Groupes;

    public Stream(Group[] groupes)
    {
        Groupes = groupes;
    }

    //Метод, который нужен для отображения отчёта
    public void ShowReport()
    {
        foreach (var groupe in Groupes)
        {
            groupe.CalibrateSubjects();
        }

        _selectionSort();

        foreach (var groupe in Groupes)
        {
            groupe.ShowReport();
        }

        Console.WriteLine("===== Студенты потока =====");
        foreach (var groupe in Groupes)
        {
            foreach (var student in groupe.Students)
            {
                Console.WriteLine(student.Name + " " + student.Surname);
            }
        }

        Console.WriteLine("===========================");
    }

    private void _selectionSort()
    {
        for (int i = 0; i < Groupes.Length - 1; i++)
        {
            int min = i;
            for (int j = i + 1; j < Groupes.Length; j++)
            {
                if (Groupes[j].AverageMark > Groupes[min].AverageMark)
                {
                    min = j;
                }
            }
            Group m = Groupes[i];
            Groupes[i] = Groupes[min];
            Groupes[min] = m;
            min = i;
        }
    }
}
public class Student
{
    private string _name;
    public string Name => _name;
    private string _surname;
    public string Surname => _surname;

    public Student(string name, string surname)
    {
        _name = name;
        _surname = surname;
    }
}
//Предмет
public class Subject
{
    private string _name;
    public string Name => _name;
    private int _score;
    public int Score => _score;

    public Subject(string name)
    {
        _name = name;
        _score = new Random().Next(1, 6);
    }
    public Subject(string name, int score)
    {
        _name = name;
        _score = score;
    }
}
class Program
{
    static void Main()
    {
        var Groupes = new Group[]
        {
            new GroupA("Группа А", new Student[]
            {
                new Student("Виктория", "Ульянова"),
                new Student("Марк", "Богатырёв"),
                new Student("Олег", "Романов")
            }),
            new GroupB("Группа В", new Student[]
            {
                new Student("Мария", "Илонова"),
                new Student("Глеб", "Останкин"),
                new Student("Павел", "Васильев")
            }),
            new GroupC("Группа С", new Student[]
            {
                new Student("Анастасия", "Милова"),
                new Student("Марк", "Богатырёв"),
                new Student("Нина", "Светова")
            })
        };

        var Stream = new Stream(Groupes);
        Stream.ShowReport();


    }
}


