using System;
using System.Numerics;
using Microsoft.VisualBasic;

abstract class Students
{
    protected string _famile;
    protected int _mark;
    protected int _kolpropusk;
    public int Mark => _mark;
    public int Kolpropusk => _kolpropusk;
    public Students(string famile, int mark, int kolpropusk)
    {
        _famile = famile;
        _mark = mark;
        _kolpropusk = kolpropusk;
    }
    public virtual void Print()
    {
        Console.WriteLine("Фамилия   {0}\t Оценка {1}\t Пропуски {2}",
                        _famile, _mark, _kolpropusk);
    }
}
class Mathematics : Students
{
    // вызов конструктора родительского класса
    public Mathematics(string famile, int mark, int kolpropusk) : base(famile, mark, kolpropusk)
    {
    }
    public override void Print()
    {
        Console.WriteLine("Математика: Фамилия   {0}\t Оценка {1}\t Пропуски {2}",
                        _famile, _mark, _kolpropusk);
    }
}
class Informatics : Students
{
    // вызов конструктора родительского класса
    public Informatics(string famile, int mark, int kolpropusk) : base(famile, mark, kolpropusk)
    {
    }

    public override void Print()
    {
        Console.WriteLine("Информатика: Фамилия   {0}\t Оценка {1}\t Пропуски {2}",
                        _famile, _mark, _kolpropusk);
    }
}
class Program
{
    static void Main()
    {
        Students[] math = new Students[]
        {
            new Mathematics("Иванов", 2, 10),
            new Mathematics("Петров", 3, 2),
            new Mathematics("Кузнецов", 2, 13),
            new Mathematics("Аксенова", 5, 0),
            new Mathematics("Кузин", 2, 9)
        };
        Students[] info = new Students[]
        {
            new Informatics("Иванов", 3, 4),
            new Informatics("Петров", 5, 2),
            new Informatics("Кузнецов", 4, 3),
            new Informatics("Аксенова", 5, 0),
            new Informatics("Кузин", 2, 10)
        };
        Console.WriteLine("Список математика:");
        foreach (Students student in math)
        {
            student.Print();
        }
        Console.WriteLine("Список информатика:");
        foreach (Students student in info)
        {
            student.Print();
        }
        FindProgul(math);
        FindProgul(info);
        //Упорядочение по результатам
        static void FindProgul(Students[] c1)
        {
            int d = c1.Length / 2;
            Students temp;
            while (d >= 1)
            {
                for (int i = d; i < c1.Length; i++)
                {
                    int j = i;
                    while (j >= d && c1[j - d].Kolpropusk > c1[j].Kolpropusk)
                    {
                        temp = c1[j];
                        c1[j] = c1[j - d];
                        c1[j - d] = temp;
                        j = j - d;
                    }
                }
                d = d / 2;
            }
            Console.WriteLine();
            for (int i = 0; i < c1.Length; i++)
            {
                if (c1[i].Mark == 2)
                    c1[i].Print();
            }
        }
    }
}
