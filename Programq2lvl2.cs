using System;
using System.Xml.Linq;

abstract class Human
{
    protected string _famile;
    private double[] _subjects;
    protected double _sred;
    private bool _otchicl;
    public double Sred => _sred;
    public bool Otchicl => _otchicl;
    public Human(string famile, double[] subjects)
    {
        _famile = famile;
        _subjects = subjects;
        _sred = 0;
        _otchicl = false;
        for (int i = 0; i < 3; i++)
        {
            _sred += subjects[i];
            if (subjects[i] == 2)
            {
                _otchicl = true;
            }
        }
        _sred = _sred / 3;
    }
    public virtual void Print()
    {
        Console.WriteLine("Фамилия   {0}\t Средний балл {1:f2}\t",
                        _famile, _sred);
    }
}
class Student : Human
{
    private static int _id;
    public readonly int ID;
    public Student(string famile, double[] sred) : base(famile, sred)
    {
        _id++;
        ID = _id;
    }
    public override void Print() // изменение логики выполенния базового метода 
    {
        Console.WriteLine(ID + ": " + _famile + ": " + _sred);
    }
}
class Program
{
    static void Main()
    {
        Student[] c1 = new Student[5];
        c1[0] = new Student("Иванов", new double[] { 3, 3, 3 });
        c1[1] = new Student("Петров", new double[] { 5, 5, 5 });
        c1[2] = new Student("Купцов", new double[] { 3, 4, 2 });
        c1[3] = new Student("Аксенова", new double[] { 3, 4, 3 });
        c1[4] = new Student("Кузнецов", new double[] { 2, 2, 2 });
        foreach (Student student in c1)
        {
            student.Print();
        }
        Sorted(c1);
        Console.WriteLine();
        for (int i = 0; i < c1.Length; i++)
        {
            if (c1[i].Otchicl == false)
            {
                c1[i].Print();
            }
        }
    }
    static void Sorted(Student[] c1)
    {
        for (int i = 0; i < c1.Length - 1; i++)
        {
            double amax = c1[i].Sred;
            int imax = i;
            for (int j = i + 1; j < c1.Length; j++)
            {
                if (c1[j].Sred > amax)
                {
                    amax = c1[j].Sred;
                    imax = j;
                }
            }
            Student temp;
            temp = c1[imax];
            c1[imax] = c1[i];
            c1[i] = temp;
        }
    }
}