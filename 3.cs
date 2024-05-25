using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

/* 3 вар
 * 1) На вход строка на вых- строка. удалить знаки преп
 2 На вход подается строка, на выход - строка, найти самую часто встречающуюся букву в тексте (регистр не имеет значение) удалить слова с этой буквой
 3 создать в  папке раб столе папку Control work в ней созд два файла 
4 заккоментируйте создание файлов Вместо сохраняйте в файлы входные и выходные заданий 1 2 в форм json 

 */
namespace _3var
{
    abstract class Task
    {
        protected int amount = 0;
        protected string text;
        
        public string Text
        {
            get => text;
            protected set => text = value;
        }
        public Task(string text)
        {
            this.text = text;
        }
        public abstract void ParseText();

    }
    class Task1 : Task
    {
        [JsonConstructor]
        public Task1(string text) : base(text)
        { }
        public override void ParseText()
        {
            string[] punctuation = { ".", ",", "?", "!" };
            foreach (var n in punctuation)
            {
                text = text.Replace(n, "");
            }
        }

        public override string ToString()
        {
            return text;
        }
    }
    class Task2 : Task
    {
        private int[] mChars = new int[1200];
        [JsonConstructor]
        public Task2(string text) : base(text)
        {

        }
        public override void ParseText()
        {
            for (int i = 0; i < mChars.Length; i++) mChars[i] = 0;
            string textTMP = text;
            textTMP = textTMP.ToUpper();
            for (int i = 0; i < textTMP.Length; i++)
            {
                char ch2 = textTMP[i];
                int j = ch2;
                mChars[j]++;
            }
            int imax = 1040;
            for (int i = 1041; i < 1072; i++)
                if (mChars[i] > mChars[imax]) imax = i;
            string st1;
            char ch = (char)imax;
            st1 = ch.ToString();

            string[] str = text.Split(new char[] { ' ', ',', '.', '?', '!' });
           
          
        }
        public override string ToString()
        {
            return text;
        }

    }
    class JsonIO
    {
        public static void Write<T>(T obj, string filePath)
        {
            Console.WriteLine($"/p Сохранение в {filePath}");
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize(fs, obj);
            }
        }
        public static T Read<T>(string filePath)
        {
            Console.WriteLine($"/p Чтение из {filePath}");
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                return JsonSerializer.Deserialize<T>(fs);
            }
            return default(T);
        }
      
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            desktopPath += @"\Control work\";
            if (!Directory.Exists(desktopPath))
            {
                Directory.CreateDirectory(desktopPath);
            }
            string[] filename = new string[2];
            for (int i = 0; i < filename.Length; i++)
            {
                filename[i] = desktopPath + "Task_" + i.ToString() + ".json";
            }
            Task[] tasks =
        {
                new Task1("В этом тексте, вот прямо здесь, надо ."),
                new Task2("Ежик крутился, ежик вертелся"),
              
            };
            for (int i = 0; i < tasks.Length; i++)
            {
                Console.WriteLine(tasks[i].Text);
                tasks[i].ParseText();
                Console.WriteLine(tasks[i]);
            }
            if (!File.Exists(filename[0])) 
            {
                JsonIO.Write<Task1>(tasks[0] as Task1, filename[0]);  
                JsonIO.Write<Task2>(tasks[1] as Task2, filename[1]);   
            }
            else 
            {
                var t1 = JsonIO.Read<Task1>(filename[0]);
                Console.WriteLine(t1.Text);
                t1.ParseText();
                Console.WriteLine(t1);

                var t2 = JsonIO.Read<Task2>(filename[1]);
                Console.WriteLine(t2.Text);
                t2.ParseText();
                Console.WriteLine(t2);
            }
        }
    }
}
