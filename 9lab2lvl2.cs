using System;
using System.Xml.Linq;
using System.Security.Cryptography.X509Certificates;
using _6_лаб_ур_2_зад_2.Serializers;

[ProtoBuf.ProtoContract()]
[ProtoBuf.ProtoInclude(1, typeof(Student))]
public abstract class Human
{
    protected string _famile;
    private double[] _subjects;
    protected double _sred;
    [ProtoBuf.ProtoMember(2)]
    public bool Otchicl;
    [ProtoBuf.ProtoMember(3)]
    public double Sred
    {
        get => _sred; // чтение
        set => _sred = value; // запись
    }
    [ProtoBuf.ProtoMember(4)]
    public string Famile
    {
        get => _famile; // чтение
        set => _famile = value ?? string.Empty; // запись
    }
    public Human() { }
    public Human(string famile, double[] subjects)
    {
        _famile = famile;
        _subjects = subjects;
        _sred = 0;
        Otchicl = false;
        for (int i = 0; i < 3; i++)
        {
            _sred += subjects[i];
            if (subjects[i] == 2)
            {
                Otchicl = true;
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
[ProtoBuf.ProtoContract()]
public class Student : Human
{
    private static int _id;
    public readonly int ID;
    public Student() : base() { }
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
        MergeSort(c1, 0, c1.Length - 1);
        Console.WriteLine();
        for (int i = 0; i < c1.Length; i++)
        {
            if (c1[i].Otchicl == false)
            {
                c1[i].Print();
            }
        }
        Serial[] serializers = new Serial[3]
            {
            new JsonManager(),
            new XmlManager(),
            new BinManager()
            };
        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        path = Path.Combine(path, "Task2");
        if (!Directory.Exists(path)) Directory.CreateDirectory(path);
        string[] files = new string[3]
        {
            "student.json",
            "student.xml",
            "student.bin"
        };
        for (int i = 0; i < files.Length; i++)
        {
            serializers[i].Write(c1, Path.Combine(path, files[i]));
        }

        for (int i = 0; i < files.Length; i++)
        {
            c1 = serializers[i].Read<Student[]>(Path.Combine(path, files[i]));
            foreach (Student student in c1)
            {
                student.Print();
            }
        }

    }
    static void Merge(Student[] arr, int l, int m, int r)
    {
        int n1 = m - l + 1;
        int n2 = r - m;

        Student[] L = new Student[n1];
        Student[] R = new Student[n2];
        int i, j;

        for (i = 0; i < n1; ++i)
            L[i] = arr[l + i];
        for (j = 0; j < n2; ++j)
            R[j] = arr[m + 1 + j];

        i = 0;
        j = 0;
        int k = l;
        while (i < n1 && j < n2)
        {
            if (L[i].Sred >= R[j].Sred)
            {
                arr[k] = L[i];
                i++;
            }
            else
            {
                arr[k] = R[j];
                j++;
            }
            k++;
        }

        while (i < n1)
        {
            arr[k] = L[i];
            i++;
            k++;
        }

        while (j < n2)
        {
            arr[k] = R[j];
            j++;
            k++;
        }
    }

    static void MergeSort(Student[] arr, int l, int r)
    {
        if (l < r) // рекурсия завершится когда l=r
        {
            int m = l + (r - l) / 2; 
            MergeSort(arr, l, m); // Эти вызовы рекурсивно сортируют эти подмассивы - пока каждая часть массива не будет содержать только один элемент.
            MergeSort(arr, m + 1, r);
            Merge(arr, l, m, r);
        }
    }

}

