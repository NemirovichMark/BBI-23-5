using System;
using System.Text.Json;
using System.Text.Json.Serialization;

abstract class MainStr
{
    protected string text;

    public string Text
    {
        get => text;
        protected set => text = value;
    }
    public MainStr(string text)
    {
        this.text = text;
    }
}



class Task1 : MainStr
{

    protected string NewStr;
    [JsonConstructor]
    public Task1(string text) : base(text) { }


    public override string ToString()
    {
        for (int i = 0; i < text.Length; i++)
        {
            char cur = text[i];
            bool isRepeated = false;
            for (int j = 0; j < text.Length; j++)
            {
                if (i != j && cur == text[j])
                {
                    isRepeated = true;
                    break;
                }
            }
            if (!isRepeated)
            {
                NewStr += cur + " ";
            }
        }
        return NewStr;
    }
}



class Task2 : MainStr
{

    protected string result;
    protected string reversed;

    [JsonConstructor]
    public Task2(string text) : base(text) { }

    public override string ToString()
    {
        result = "";
        reversed = "";

        foreach (char c in text)
        {
            if (Char.IsLetter(c))
            {
                reversed = c + reversed;
            }
            else
            {
                result += reversed + c;
                reversed = "";
            }
        }

        result += reversed;

        return result;
    }
}


class JsonMode
{
    public static void Write<T>(T obj, string filePath)
    {
        using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
        {
            JsonSerializer.Serialize(fs, obj);
        }
    }
    public static T Read<T>(string filePath)
    {
        using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
        {
            return JsonSerializer.Deserialize<T>(fs);
        }
        return default(T);
    }
}

class Program
{
    static void Main()
    {

        MainStr[] tasks = {
            new Task1("Бертран (фр. Bertrand de Toulouse, 1065 — 21 апреля 1112 года) — граф Тулузы, маркиз Прованса и герцог Нарбонны с 1105 года, граф Триполи с 1108 года. Старший сын одного из руководителей 1-го крестового похода Раймунда Тулузского. Бертран правил в Тулузе с отбытия Раймунда в крестовый поход и до собственного отъезда в Святую Землю, за исключением двух лет, когда город был занят герцогом Аквитанским Гийомом IX, женатым на двоюродной сестре Бертрана Филиппе. В 1108 году Бертран уехал с женой и сыном в крестовый поход. На Святой Земле он правил Триполи и как вассал иерусалимского короля участвовал в военных кампаниях последнего. В 1112 году он умер, ему наследовал сын Понс."),
            new Task2("Бертран (фр. Bertrand de Toulouse, 1065 — 21 апреля 1112 года) — граф Тулузы, маркиз Прованса и герцог Нарбонны с 1105 года, граф Триполи с 1108 года. Старший сын одного из руководителей 1-го крестового похода Раймунда Тулузского. Бертран правил в Тулузе с отбытия Раймунда в крестовый поход и до собственного отъезда в Святую Землю, за исключением двух лет, когда город был занят герцогом Аквитанским Гийомом IX, женатым на двоюродной сестре Бертрана Филиппе. В 1108 году Бертран уехал с женой и сыном в крестовый поход. На Святой Земле он правил Триполи и как вассал иерусалимского короля участвовал в военных кампаниях последнего. В 1112 году он умер, ему наследовал сын Понс.")
        };
        Console.WriteLine(tasks[0].ToString());
        Console.WriteLine(tasks[1].ToString());

        // 3 задание
        string path = @"C:\Users\m2311003\Downloads";
        string folder = "Test"; 
        path = Path.Combine(path, folder);
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        string file1 = "task_1.json";
        string file2 = "task_2.json";

        file1 = Path.Combine(path, file1);
        file2 = Path.Combine(path, file2);

        // 4 задание
        if (!File.Exists(file2))
        {
            JsonMode.Write<Task1>(tasks[0] as Task1, file1);
            JsonMode.Write<Task2>(tasks[1] as Task2, file2);
        }
        else
        {
            var peremenaya1 = JsonMode.Read<Task1>(file1);
            var peremenaya2 = JsonMode.Read<Task2>(file2);
            Console.WriteLine(peremenaya1);
            Console.WriteLine(peremenaya2);
        }
    }
}











