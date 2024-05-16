using System;
using System;
using System.Xml.Linq;
using System.Numerics;
using Microsoft.VisualBasic;
using _6_лаб_уровень_3_зад_4.Serializers;
using System.Security.Cryptography.X509Certificates;
[ProtoBuf.ProtoContract()]
[ProtoBuf.ProtoInclude(1, typeof(FemaleSkier))]
[ProtoBuf.ProtoInclude(2, typeof(Skier))]
public abstract class Player
{
    [ProtoBuf.ProtoMember(3)]
    public string _famile;
    public double _result;
    [ProtoBuf.ProtoMember(4)]
    public double Result
    {
        get => _result; // чтение
        set => _result = value; // запись
    }
    public Player() { }
    public Player(string famile, double result)
    {
        _famile = famile;
        _result = result;
    }
    public virtual void Print()
    {
        Console.WriteLine("Фамилия   {0}\t Результат {1:f2}\t ",
                        _famile, _result);
    }
}
[ProtoBuf.ProtoContract()]
public class FemaleSkier : Player
{
    public FemaleSkier() : base() { }
    public FemaleSkier(string famile, double result) : base(famile, result)
    {

    }
    public override void Print()
    {
        Console.WriteLine("Фамилия   {0}\t Женщина Результат {1:f2}\t",
                        _famile, Result);
    }
}
[ProtoBuf.ProtoContract()]
public class Skier : Player
{
    public Skier() : base() { }
    public Skier(string famile, double result) : base(famile, result)
    {
    }
    public override void Print()
    {
        Console.WriteLine("Фамилия   {0}\t Мужчина Результат {1:f2}\t ",
                        _famile, _result);
    }
}
class Program
{
    static void Main()
    {
        Player[] c1 = new Player[10];
        FemaleSkier[] woman = new FemaleSkier[5];
        woman[0] = new FemaleSkier("Иванова", 15.38);
        woman[1] = new FemaleSkier("Петрова", 16.54);
        woman[2] = new FemaleSkier("Купцова", 13.51);
        woman[3] = new FemaleSkier("Аксенова", 11.22);
        woman[4] = new FemaleSkier("Кузинина", 18.24);

        Skier[] man = new Skier[5];
        man[0] = new Skier("Кравцов", 19.41);
        man[1] = new Skier("Павленко", 15.38);
        man[2] = new Skier("Еремин", 15.11);
        man[3] = new Skier("Никонов", 14.26);
        man[4] = new Skier("Сидоровов", 12.41);
        //Упорядочение по результатам
        Sorting(woman);
        Sorting(man);
        Console.WriteLine("Лыжницы");
        foreach (var player in woman)
        {
            player.Print();
        }
        Console.WriteLine("Лыжники");
        foreach (var player in man)
        {
            player.Print();
        }
        //for (int i = 0; i < woman.Length; i++)
        //{
        //    c1[i] = woman[i];
        //}
        //for (int i = 0; i < man.Length; i++)
        //{
        //    c1[i + woman.Length] = man[i];
        //}
        Console.WriteLine();
        //Sorting(c1);
        Console.WriteLine();
        Console.WriteLine("Общий рейтинг");

        Player[] players = Merge(woman, man);
        Sorting(players);
        foreach (var player in players)
        {
            player.Print();
        }
        Serial[] serializers = new Serial[3]
            {
            new JsonManager(),
            new BinManager(),
            new XmlManager()
            };
        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        path = Path.Combine(path, "Task3");
        if (!Directory.Exists(path)) Directory.CreateDirectory(path);
        string[] files = new string[3]
        {
            "woman.json",
            "woman.bin",
            "woman.xml",

        };

        for (int i = 0; i < files.Length; i++)
        {
            serializers[i].Write(woman, Path.Combine(path, files[i]));
        }

        for (int i = 0; i < files.Length; i++)
        {
            woman = serializers[i].Read<FemaleSkier[]>(Path.Combine(path, files[i]));
            foreach (FemaleSkier woman0 in woman)
            {
                woman0.Print();
            }
        }
        string[] filess = new string[3]
            {
            "man.json",
            "man.bin",
            "man.xml",
            };

        for (int i = 0; i < filess.Length; i++)
        {
            serializers[i].Write(man, Path.Combine(path, filess[i]));
        }
        for (int i = 0; i < filess.Length; i++)
        {
            man = serializers[i].Read<Skier[]>(Path.Combine(path, filess[i]));
            foreach (Skier man0 in man)
            {
                man0.Print();
            }
        }
    }
    static Player[] Merge(Player[] arr1, Player[] arr2)
    {
        Player[] merged = new Player[arr1.Length + arr2.Length];
        int i = 0, j = 0, k = 0;

        while (i < arr1.Length && j < arr2.Length)
        {
            if (arr1[i].Result <= arr2[j].Result)
            {
                merged[k] = arr1[i];
                i++;
            }
            else
            {
                merged[k] = arr2[j];
                j++;
            }
            k++;
        }

        while (i < arr1.Length)
        {
            merged[k] = arr1[i];
            i++;
            k++;
        }

        while (j < arr2.Length)
        {
            merged[k] = arr2[j];
            j++;
            k++;
        }

        return merged;
    }

    static void Sorting(Player[] s)
    {
        int n = s.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (s[j].Result > s[j + 1].Result)
                {
                    Player temp = s[j];
                    s[j] = s[j + 1];
                    s[j + 1] = temp;
                }
            }
        }
    }
}