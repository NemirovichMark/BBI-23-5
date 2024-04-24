using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


abstract class Task
{
    protected string text = "";

    public Task(string text)
    {
        this.text = text;
    }
    public string Text
    {
        get => text;
        protected set => text = value;
    }

}

class Task_1 : Task
{
    [JsonConstructor]
    public Task_1(string text) : base(text)
    {

    }
    public override string ToString()
    {
        return text;
    }

    public static string[] GetShortWords(Task_1 text)
    {
        text.Text = text.Text.Replace(",", "")
                             .Replace(".", "")
                             .Replace("!", "")
                             .Replace("-", "")
                             .Replace("?", "")
                             .Replace(":", "")
                             .Replace("/", "")
                             .Replace("(", "")
                             .Replace(")", "")
                             .Replace("\"", "")
                             .Replace("1", "")
                             .Replace("2", "")
                             .Replace("3", "")
                             .Replace("4", "")
                             .Replace("5", "")
                             .Replace("6", "")
                             .Replace("7", "")
                             .Replace("8", "")
                             .Replace("9", "")
                             .Replace("0", "");

        string[] allWords = text.Text.Split(new char[] { ' ' });
        string[] shortWords = new string[allWords.Length];
        int count = 0;

        foreach (string word in allWords)
        {
            if (word.Length <= 5)
            {
                shortWords[count++] = word;
            }
        }

        Array.Resize(ref shortWords, count);
        return shortWords;

    }
}
class Task_2 : Task
{
    public int Amount { get; private set; }

    [JsonConstructor]
    public Task_2(string text, int amount = 0) : base(text)
    {
        Amount = amount;
    }
    
    public override string ToString()
    {
        return text;
    }

    
}
class JsonIO
{
    public static void Write<T>(T obj, string filePath) where T : Task
    {
        using (FileStream fs = new FileStream(filePath, FileMode.Create))
        {
            JsonSerializer.Serialize(fs, obj);
        }
    }

    public static T Read<T>(string filePath) where T : Task
    {
        if (File.Exists(filePath))
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                return JsonSerializer.Deserialize<T>(fs);
            }
        }
        else
        {
            return null;
        }
    }

    public static void CreateDirectory(string directoryPath)
    {
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }
    }

    public static void CreateFiles(string directoryPath, string[] fileNames)
    {
        foreach (string fileName in fileNames)
        {
            string filePath = Path.Combine(directoryPath, fileName);
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
        }
    }
}

class Programm
{
    static void Main(string[] args)
    {
        Task_1 inputText = new Task_1("«Если опираться на прежние данные, то большая часть воды поступала в Атыраускую область в середине мая. Однако, в этом году большой объем воды, поступающей с територии России, раннее начало весеннего паводка изменили ситуацию. Вода, идущая с пределов Западно-Казахстанской области вниз по течению, достигает Атырау примерно за 6-7 дней. 2-3 мая ожидается наполнение русла реки Урал», - рассказал представитель рабочей группы ученых-исследователей при областном оперативном штабе Арман Жумагазиев.  \r\n\r\nПо данным на 8.00 часов 24 апреля, уровень воды реки Урал на гидропосту Атырау достиг отметки 422 см. Опасный уровень – 550 см.");

        string[] words = Task_1.GetShortWords(inputText);

        Console.WriteLine("Слова длиной не более 5 букв:");
        foreach (string word in words)
        {
            Console.WriteLine(word);
        }
        {
            Task[] tasks = {
            new Task_1("Если опираться на прежние данные, то большая часть воды поступала в Атыраускую область в середине мая."),
            new Task_2("Если опираться на прежние данные, то большая часть воды поступала в Атыраускую область в середине мая. 1234/ 567", 25)
        };

            Console.WriteLine("Results of the first two tasks:");

            foreach (Task task in tasks)
            {
                Console.WriteLine(task);
                Console.WriteLine("Task execution result:");
                if (task is Task_1)
                {
                    Task_1 task1 = (Task_1)task;
                    string[] shortWords = task1.GetShortWords(task);
                    Console.WriteLine("Short words:");
                    foreach (string word in shortWords)
                    {
                        Console.WriteLine(word);
                    }
                }
                else if (task is Task_2)
                {
                    Task_2 task2 = (Task_2)task;
                    
                }
                Console.WriteLine();
            }

            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string answerFolderPath = Path.Combine(documentsPath, "Answer");
            string[] fileNames = { "task1.json", "task2.json" };

            JsonIO.CreateDirectory(answerFolderPath);
            JsonIO.CreateFiles(answerFolderPath, fileNames);

            Console.WriteLine("Результаты заданий 3 и 4:");

            foreach (Task task in tasks)
            {
                string fileName = Path.Combine(answerFolderPath, task.GetType().Name.ToLower() + ".json");
                if (task is Task_1)
                {
                    Task_1 task1 = (Task_1)task;
                    JsonIO.Write(task1, fileName);
                    Console.WriteLine($"Task 1 результат записан {fileName}");
                }
                else if (task is Task_2)
                {
                    Task_2 task2 = (Task_2)task;
                    JsonIO.Write(task2, fileName);
                    Console.WriteLine($"Task 2 результат записан {fileName}");
                }
            }

            Console.WriteLine("Чтение файла:");

            foreach (string fileName in fileNames)
            {
                string filePath = Path.Combine(answerFolderPath, fileName);
                if (File.Exists(filePath))
                {
                    if (fileName == "task1.json")
                    {
                        Task_1 task1 = JsonIO.Read<Task_1>(filePath);
                        Console.WriteLine($"Task 1 резульаты {fileName}: {task1}");
                    }
                    else if (fileName == "task2.json")
                    {
                        Task_2 task2 = JsonIO.Read<Task_2>(filePath);
                        Console.WriteLine($"Task 2 результаты {fileName}: {task2}");
                    }
                }
                else
                {
                    Console.WriteLine($"Файл {fileName} не найден.");
                }
            }
        }
    }
}
