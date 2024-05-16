using System;
using System;
using System.Xml.Linq;
using System.Numerics;
using Microsoft.VisualBasic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using лаб_6_уровень_1_зад_5.Serializers;

[ProtoBuf.ProtoContract()]
[ProtoBuf.ProtoInclude(1,typeof(Mathematics))]
[ProtoBuf.ProtoInclude(2, typeof(Informatics))]
public abstract class Students
{
    [ProtoBuf.ProtoMember(3)]
    public string _famile;
    public int _mark;
    public int _kolpropusk;
    [ProtoBuf.ProtoMember(4)]
    public int Mark
    {
        get => _mark;
        set => _mark = value;
    }
    [ProtoBuf.ProtoMember(5)]
    public int Kolpropusk
    {
        get => _kolpropusk;
        set => _kolpropusk = value;
    }
    public Students() { }
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

[ProtoBuf.ProtoContract()]
public class Mathematics : Students
{
    // вызов конструктора родительского класса
    public Mathematics() : base() { }
    public Mathematics(string famile, int mark, int kolpropusk) : base(famile, mark, kolpropusk)
    {
    }
    public override void Print()
    {
        Console.WriteLine("Математика: Фамилия   {0}\t Оценка {1}\t Пропуски {2}",
                        _famile, _mark, _kolpropusk);
    }
}
[ProtoBuf.ProtoContract()]
public class Informatics : Students
{
    public Informatics() : base() { }
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
        Mathematics[] math = new Mathematics[]
        {
            new Mathematics("Иванов", 2, 10),
            new Mathematics("Петров", 3, 2),
            new Mathematics("Кузнецов", 2, 13),
            new Mathematics("Аксенова", 5, 0),
            new Mathematics("Кузин", 2, 9)
        };
        Informatics[] info = new Informatics[]
        {
            new Informatics("Иванов", 3, 4),
            new Informatics("Петров", 5, 2),
            new Informatics("Кузнецов", 4, 3),
            new Informatics("Аксенова", 5, 0),
            new Informatics("Кузин", 2, 10)
        };
        //FindProgul(math);
        //FindProgul(info);
        Serial[] serializers = new Serial[3]
        {
            new JsonManager(),
            new BinManager(),
            new XmlManager()

        };
        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        path = Path.Combine(path, "Sample");
        if (!Directory.Exists(path)) Directory.CreateDirectory(path);
        string[] files = new string[3]
        {
            "math.json",
            "math.bin",
            "math.xml",

        };
        for (int i = 0; i < files.Length; i++)
        {
            serializers[i].Write(math, Path.Combine(path, files[i]));

        }
        for (int i = 0; i < files.Length; i++)
        {
            math = serializers[i].Read<Mathematics[]>(Path.Combine(path, files[i]));
            foreach (Mathematics student in math)
            {
                student.Print();
            }
        }
        string[] filess = new string[3]
        {
            "info.json",
            "info.bin",
            "info.xml",

        };
        for (int i = 0; i < filess.Length; i++)
        {
            serializers[i].Write(info, Path.Combine(path, filess[i]));

        }
        for (int i = 0; i < filess.Length; i++)
        {
            info = serializers[i].Read<Informatics[]>(Path.Combine(path, filess[i]));
            foreach (Informatics student in info)
            {
                student.Print();
            }
        }
    }
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