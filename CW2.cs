using System.Text.Json;
using System.Text.Json.Serialization;

abstract class Task
{
    protected string text = "";
    public string Text
    {
        get => text;
        protected set => text = value;
    }

    public virtual void Solution() { }
    public Task(string text)
    {
        this.text = text;
    }
}
class Task1 : Task
{
    private int answer;
    public int Answer
    {
        get => answer;
        protected set => answer = value;
    }
    [JsonConstructor]
    public Task1(string text) : base(text)
    {
        answer = 0;

    }
    public override void Solution()
    {
        string[] numbers = text.Split(" ,-!.:;".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        foreach (var number in numbers)
        {
            if (number.Length == 1 && "".Contains(number))
            {
                answer++;
            }
        }
    }

    public override string ToString()
    {
        Solution();
        return answer.ToString();
    }
}
class Task2 : Task
{
    private List<string> answer;
    public List<string> Answer
    {
        get => answer;
    }
    [JsonConstructor]
    public Task2(string text) : base(text)
    {
        answer = new List<string>();

    }
    public override void Solution()
    {
        int[] counter = new int[33];
        string checker = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        foreach (char i in text)
        {
            if (checker.Contains(i))
            {
                counter[i - 'А']++;
            }
        }
        char maxChar = ' ';
        int tmpMax = 0;
        for (int i = 0; i < 33; ++i)
        {
            if (counter[i] > tmpMax)
            {
                tmpMax = counter[i];
                maxChar = Convert.ToChar('А' + i);
            }
        }
        string[] words = text.Split(" ,-!.:;".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        foreach (var word in words)
        {
            if (word[0] == maxChar)
            {
                answer.Add(word);
            }
        }
    }
    public override string ToString()
    {
        Solution();
        if (answer == null) return "";
        return string.Join(",", answer.ToArray()); ;
    }
}
class JsonIO
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

    }
}
class Programm
{
    static void Main()
    {
        string text = "Меня зовут Кира Йошикагэ. Мне 33 года. Мой дом находится в северо-восточной части Морио, в районе поместий. Работаю в офисе сети магазинов Kame Yu и домой возвращаюсь, самое позднее, в восемь вечера. Не курю, выпиваю изредка. Ложусь спать в 11 вечера и убеждаюсь, что получаю ровно восемь часов сна, несмотря ни на что. Перед сном я пью тёплое молоко, а также минут двадцать уделяю разминке, поэтому до утра сплю без особых проблем. Утром я просыпаюсь, не чувствуя ни усталости, ни стресса, словно младенец. На медосмотре мне сказали, что никаких проблем нет. Я пытаюсь донести, что я обычный человек, который хочет жить спокойной жизнью. Я не забиваю себе голову проблемами вроде побед или поражений, и не обзавожусь врагами, из-за которых не мог бы уснуть. Я знаю наверняка: в таком способе взаимодействия с обществом и кроется счастье. Хотя, если бы мне пришлось сражаться, я бы никому не проиграл.";
        Task[] tasks = {
            new Task1(text),
            new Task2(text)
        };
        Console.WriteLine(tasks[0]);
        Console.WriteLine(tasks[1]);
        string path = @"C:\Desktop";
        string folderName = "Solution";
        path = Path.Combine(path, folderName);
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        string fileName1 = "cw2_1.json";
        string fileName2 = "cw2_2.json";

        fileName1 = Path.Combine(path, fileName1);
        fileName2 = Path.Combine(path, fileName2);
        if (!File.Exists(fileName1))
        {
            JsonIO.Write<Task1>(tasks[0] as Task1, fileName1);
        }
        else
        {
            var task1 = JsonIO.Read<Task2>(fileName1);
            Console.WriteLine(task1);
        }

        if (!File.Exists(fileName2))
        {
            JsonIO.Write<Task2>(tasks[1] as Task2, fileName2);
        }
        else
        {
            var task2 = JsonIO.Read<Task2>(fileName2);
            Console.WriteLine(task2);
        }

    }
}

