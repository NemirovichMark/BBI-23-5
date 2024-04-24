using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
abstract class Task
{ 
    protected string text = " ";
    public string Text
    { 
        get => text; protected set => text = value;
    } 
    public Task(string text) 
    {
        this.text = text; 
    } 
}
class Task1 : Task
{
    [JsonConstructor]
    public Task1(string text) : base(text) { }

    public override string ToString()
    {
        string inputText = Text;
        double average = AVG(inputText);
        return $"Среднее арифметическое слогов: {average:F4}";
    }

    private double AVG(string text)
    {
        string[] words = Regex.Split(text, @"\W+");

        int totalSlog = words.Sum(word => Kslogs(word));

        int wordC = words.Length;

        double average = (double)totalSlog / wordC;

        return average;
    }

    private int Kslogs(string word)
    {
        string pattern = @"[аеёиоуыэюяАЕЁИОУЫЭЮЯ]+";

        int SlogCount = Regex.Matches(word, pattern).Count;

        return SlogCount;
    }
}
class Task2 : Task
{
    public Task2(string text) : base(text) { }

    public override string ToString() 
    {
        string inputText = Text;

        string resultText = UpFirstWord(inputText);

        return resultText;
    }

    private string UpFirstWord(string text)
    {
        string[] predloghenie = text.Split(new char[] { '.', '!', '?' });

        for (int i = 0; i < predloghenie.Length; i++)
        {
            if (!string.IsNullOrWhiteSpace(predloghenie[i])) 
            {
                string[] words = predloghenie[i].Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                foreach (var word in words)
                {
                    if (RusWord(word)) 
                    {
                        predloghenie[i] = predloghenie[i].Replace(word, word.ToUpper()); 
                        break;
                    }
                }
            }
        }

        string resultText = string.Join(".", predloghenie);
        return resultText;
    }

 
    private bool RusWord(string word)
    {
        foreach (char c in word)
        {
            if (Rus(c)) 
                return true;
        }
        return false;
    }


    private bool Rus(char c)
    {

        return c >= 'а' && c <= 'я' || c >= 'А' && c <= 'Я';
    }
}

class JsonIO 
{
    public static void Write<T>(T obj, string filePath) 
    { 
        using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
        { 
            JsonSerializer.Serialize(fs, obj);
            Console.WriteLine($"Данные успешно записаны в файл: {filePath}");

        }  
    } 
    public static T Read<T>(string filePath) 
    {
        if (!File.Exists(filePath)) 
        {
            Console.WriteLine($"Файл {filePath} не найден.");
            return default(T);
        } 
        using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
        { 
            T obj = JsonSerializer.Deserialize<T>(fs);
            Console.WriteLine($"Данные успешно прочитаны: {filePath}"); 
            return obj;
        }
    } 
}
class Program
{
    static void Main(string[] args)
    {
        Task[] tasks = {
            new Task1("Равным образом, высококачественный прототип будущего проекта играет важную роль в формировании соответствующих условий активизации. В частности, постоянный количественный рост и сфера нашей активности требует определения и уточнения стандартных подходов. "),
            new Task2("Также как социально-экономическое развитие однозначно фиксирует необходимость кластеризации усилий. Идейные соображения высшего порядка, а также консультация с широким активом требует определения и уточнения существующих финансовых и административных условий.")
        };
        Console.WriteLine(tasks[0]);
        Console.WriteLine();
        Console.WriteLine(tasks[1]);
        Console.WriteLine();
        string path = @"C:\Users\m2304781\Desktop\";
        string folderName = "Control work";
        path = Path.Combine(path, folderName);
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        string fileName1 = "task_1.json";
        string fileName2 = "task_2.json";
        fileName1 = Path.Combine(path, fileName1);
        fileName2 = Path.Combine(path, fileName2);

        if (!File.Exists(fileName2))
        {
            JsonIO.Write<Task1>((Task1)tasks[0], fileName1);
            JsonIO.Write<Task2>((Task2)tasks[1], fileName2);


        }
        else
        {
            Task1 ReadTask1 = JsonIO.Read<Task1>(fileName1);
            Task2 ReadTask2 = JsonIO.Read<Task2>(fileName2);
            

            if (ReadTask1 != null)
            {
                Console.WriteLine(ReadTask1);
                Console.WriteLine();
            }
            if (ReadTask2 != null)
            {
                Console.WriteLine(ReadTask2);
                Console.WriteLine();
            }
        }
    }
}
