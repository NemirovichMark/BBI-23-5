using ProtoBuf;
using System.Xml.Serialization;
using Newtonsoft.Json;

[ProtoContract]
public abstract class Sportsmen
{
    [ProtoMember(1)]
    public string Familiya { get; set; }
    [ProtoMember(2)]
    public int Group { get; set; }
    [ProtoMember(3)]
    public string Fam_prepod { get; set; }
    [ProtoMember(4)]
    public double Rez { get; set; }

    protected Sportsmen() { }

    public Sportsmen(string Familiya, int Group, string Fam_prepod, double Rez)
    {
        this.Familiya = Familiya;
        this.Group = Group;
        this.Fam_prepod = Fam_prepod;
        this.Rez = Rez;
    }

    public static void PrintTabl()
    {
        Console.WriteLine($"{"Фамилия",-20} {"Группа",-10} {"Фамилия преподователя",-20} {"Результат",-20}");
    }

    public virtual void Print()
    {
        Console.WriteLine($"{Familiya,-20} {Group,-10} {Fam_prepod,-25} {Rez,-20}");
    }
    public static void ShellSort(Sportsmen[] runs)
    {
        int n = runs.Length;
        int step = n / 2;
        while (step > 0)
        {
            for (int i = step; i < n; i++)
            {
                Sportsmen temp = runs[i];
                int j = i;
                while (j >= step && runs[j - step].Rez < temp.Rez)
                {
                    runs[j] = runs[j - step];
                    j -= step;
                }
                runs[j] = temp;
            }
            step /= 2;
        }
    }
}

[ProtoContract]
public class Run500 : Sportsmen
{
    public Run500() : base("", 0, "", 0.0) { }

    public Run500(string Familiya, int Group, string Fam_prepod, double Rez) : base(Familiya, Group, Fam_prepod, Rez) { }

    public override void Print()
    {
        Console.WriteLine();
        Console.WriteLine("Забег на 500 метров:");
        base.Print();
    }
}
public abstract class SerializerHelper
{
    public abstract void SerializeTo<T>(T obj, string filePath);
    public abstract T DeserializeFrom<T>(string filePath);
}
public class JsonSerializerHelper : SerializerHelper
{
    public override void SerializeTo<T>(T obj, string filePath)
    {
        string json = JsonConvert.SerializeObject(obj);
        File.WriteAllText(filePath, json);
    }

    public override T DeserializeFrom<T>(string filePath)
    {
        string json = File.ReadAllText(filePath);
        return JsonConvert.DeserializeObject<T>(json);
    }
}
public class XmlSerializerHelper : SerializerHelper
{
    public override void SerializeTo<T>(T obj, string filePath)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(T));

        using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
        {
            serializer.Serialize(fileStream, obj);
        }
    }

    public override T DeserializeFrom<T>(string filePath)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(T));

        using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
        {
            return (T)serializer.Deserialize(fileStream);
        }
    }
}

public class ProtobufSerializerHelper : SerializerHelper
{
    public override void SerializeTo<T>(T obj, string filePath)
    {
        using (var file = File.Create(filePath))
        {
            Serializer.Serialize(file, obj);
        }
    }

    public override T DeserializeFrom<T>(string filePath)
    {
        using (var file = File.OpenRead(filePath))
        {
            return Serializer.Deserialize<T>(file);
        }
    }
}
class Program
{
    static void Main()
    {
        Run500[] run500s =
        [
            new Run500("Runner 1.1", 5, "A", 41.2),
            new Run500("Runner 2.1", 3, "B", 40.6),
            new Run500("Runner 3.1", 2, "C", 45.0),
            new Run500("Runner 4.1", 6, "D", 28.89),
            new Run500("Runner 5.1", 1, "F", 34.1),
        ];
        ShellSort(run500s);
        string jsonFilePath = "run500.json";
        var jsoner = new JsonSerializerHelper();
        jsoner.SerializeTo(run500s, jsonFilePath);
        Console.WriteLine($"Объект успешно сериализован в JSON файл: {jsonFilePath}");
        Run500[] deserializedRunner = jsoner.DeserializeFrom<Run500[]>(jsonFilePath);
        if (deserializedRunner != null)
        {
            Console.WriteLine("Забег на 500 метров (бинарный формат):");
            Sportsmen.PrintTabl();
            foreach (var runner in run500s)
            {
                runner.Print();
            }
        }
        else
        {
            Console.WriteLine("Ошибка десериализации.");
        }

        Console.WriteLine("\n\\\\\\\\\n");

        string xmlFilePath = "run500.xml";
        var xmler = new XmlSerializerHelper();
        xmler.SerializeTo(run500s, xmlFilePath);
        Console.WriteLine($"Объект успешно сериализован в XML файл: {xmlFilePath}");
        deserializedRunner = xmler.DeserializeFrom<Run500[]>(xmlFilePath);
        if (deserializedRunner != null)
        {
            Console.WriteLine($"Десериализованный объект:");
            foreach (var runner in run500s)
            {
                runner.Print();
            }
        }
        else
        {
            Console.WriteLine("Ошибка десериализации.");
        }

        Console.WriteLine("\n\\\\\\\\\n");

        string filePath = "run500.bin";
        var biner = new ProtobufSerializerHelper();

        biner.SerializeTo(run500s, filePath);
        Console.WriteLine($"Объект успешно сериализован в файл: {filePath}");

        deserializedRunner = biner.DeserializeFrom<Run500[]>(filePath);
        if (deserializedRunner != null)
        {
            Console.WriteLine($"Десериализованный объект:");
            foreach (var runner in run500s)
            {
                runner.Print();
            }
        }
    }
    static void ShellSort(Sportsmen[] runs)
    {
        int n = runs.Length;
        int step = n / 2;
        while (step > 0)
        {
            for (int i = step; i < n; i++)
            {
                Sportsmen temp = runs[i];
                int j = i;
                while (j >= step && runs[j - step].Rez < temp.Rez)
                {
                    runs[j] = runs[j - step];
                    j -= step;
                }
                runs[j] = temp;
            }
            step /= 2;
        }
    }
}

