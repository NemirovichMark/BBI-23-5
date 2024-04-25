using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

abstract class Task
{
    protected string text = "";
    public string Text
    {
        get => text; protected set => text = value;
    }
    public virtual void Solution() { }
    public Task(string text) { this.text = text; }
}

class Task1 : Task 
{
    private double answer;
    public double Answer
    { get => answer; protected set => answer = value; }
    [JsonConstructor]
    public Task1(string text) : base(text)
    {
        
    }
    double k = 0.0;
    public override void Solution()
    {

            string[] words = text.Split(new char[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

            int syllablesCount = 0;
            int wordsCount = 0;

            foreach (string word in words)
            {
                syllablesCount += CountSyllables(word);
                wordsCount++;
            }
            k = (double)syllablesCount / wordsCount;



        static int CountSyllables(string word)
        {
            word = word.ToLower();

            int syllablesCount = 0;
            bool lastIsVowel = false;

            foreach (char c in word)
            {
                if (c == 'а' || c == 'о' || c == 'у' || c == 'ы' || c == 'и' || c == 'э' || c == 'я' || c == 'ю' || c == 'е' || c == 'ё')
                {
                    if (!lastIsVowel)
                    {
                        syllablesCount++;
                    }
                    lastIsVowel = true;
                }
                else
                {
                    lastIsVowel = false;
                }
            }

            return Math.Max(syllablesCount, 1); 
        }
        
        
    }
    public override string ToString()
    {
        Solution();
        return k.ToString();
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
        string[] words = text.Split(" ,-!.:;".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

        bool capitalize = true;
        foreach (var c in text)
        {
            if (char.IsLetter(c))
            {
                if (capitalize)
                {
                    foreach (var word in words) 
                    {
                        char.ToUpper(c);
                        capitalize = false;
                    }
                }
               
            }
             if (c == '.' || c == '!' || c == '?')
            {
                for (int i = 0; i < words.Length; i++)
                {
                    capitalize = true;
                    char.ToUpper(c);
                }
            }
            
        }
        
        foreach (var word in words)
        {

            answer.Add(word);
        }
        return;
    }

        
        public override string ToString()
    {
        Solution();
        if (answer == null) return "";
        return string.Join(" ", answer.ToArray());
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
        return default(T);
    }
}


class Program
{
    static void Main()
    {
        string text = " Вот текст для проверки. Он не очень большой. Но всё же имеет место быть. Конечно, счастье важно для нас не меньше веселья. ";
        Task[] tasks =
        {
            new Task1(text),
            new Task2(text),
            };
        Console.WriteLine(tasks[0]);
        Console.WriteLine(tasks[1]);

        string path = @"C:\Users\user\Documents";
        string folderName = "Test";
        path = Path.Combine(path, folderName);
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        string fileName1 = "task_1.json";
        string fileName2 = "task_2.json";

        fileName1 = Path.Combine(path, fileName1);
        fileName2 = Path.Combine(path, fileName2);

        if (!File.Exists(fileName1))
        {
            JsonIO.Write<Task1>(tasks[0] as Task1, fileName1);
        }
        else
        {
            var t1 = JsonIO.Read<Task2>(fileName1);
            Console.WriteLine(t1);
        }
        if (!File.Exists(fileName2))
        {
            JsonIO.Write(tasks[1] as Task2, fileName2);
        }
        else
        {
            var t2 = JsonIO.Read<Task2>(fileName2);
            Console.WriteLine(t2);
        }
    }
}