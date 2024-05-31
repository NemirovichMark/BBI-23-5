using static System.Net.Mime.MediaTypeNames;

class Program
{
    class Task
    {
        protected string text;
        public Task(string t)
        {
            text = t;
        }
    }

    class Number1 : Task
    {
        public Number1(string t) : base(t) { }
        public override string ToString()
        {
            List<char> letters = new List<char>();
            List<int> counters = new List<int>();
            int count = 0;
            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    count++;
                    if (!letters.Contains(c))
                    {
                        letters.Add(c);
                        counters.Add(1);
                    }
                    else
                    {
                        for (int i = 0; i < counters.Count; i++)
                        {
                            if (letters[i] == c) { counters[i]++; }
                        }
                    }
                }
            }
            string h = "";
            for (int i = 0; i < counters.Count; i++)
            {
                h += letters[i].ToString() + " - " + (counters[i] / (float)count).ToString() + "\n";
            }
            return h;
        }
    }
    class Number3 : Task
    {
        public Number3(string t) : base(t) { }
        public override string ToString()
        {
            string[] words = text.Split(' ');
            List<string> wordsInLine = new List<string>();
            List<string> result = new List<string>();
            int counter = 0;
            foreach (string c in words)
            {
                if (counter + c.Length <= 50)
                {
                    wordsInLine.Add(c);
                    counter += c.Length + 1;
                }
                else
                {
                    result.Add(string.Join(' ', wordsInLine));
                    counter = c.Length + 1;
                    wordsInLine.Clear();
                    wordsInLine.Add(c);
                }
            }
            result.Add(string.Join(' ', wordsInLine));
            return string.Join("\n", result.ToArray());
        }
    }
    class Number6 : Task
    {
        public Number6(string t) : base(t) { }
        public override string ToString()
        {
            char[] letters = { 'у', 'е', 'ё', 'ы', 'а', 'о', 'э', 'я', 'и', 'ю' };
            string[] words = text.Split(" ");
            List<int> amounts = new List<int>();
            List<int> counters = new List<int>();
            foreach (string c in words)
            {
                int syllables = 0;
                foreach (char e in c)
                {
                    if (letters.Contains(e))
                    {
                        syllables++;
                    }
                }
                if (!amounts.Contains(syllables))
                {
                    amounts.Add(syllables);
                    counters.Add(1);
                }
                else
                {
                    for (int i = 0; i < counters.Count; i++)
                    {
                        if (amounts[i] == syllables) { counters[i]++; }
                    }
                }
            }
            string h = "";
            for (int i = 0; i < counters.Count; i++)
            {
                h += $"количество слогов - {amounts[i]}; количество таких слов - {counters[i]}\n";
            }
            return h;
        }
    }
    class Number12 : Task
    {
        private string[] words = { "фьорды", "и", "в" };
        private string[] codes = { "Alpha", "Betta", "Gamma" };
        public Number12(string t) : base(t) { }
        public override string ToString()
        {
            string[] word = text.Split(' ');
            string h = "";
            foreach (string c in word)
            {
                string intro = "";
                string outro = "";
                bool f = false;
                string u = "";
                for (int i = 0; i < c.Length; i++)
                {
                    if (char.IsPunctuation(c[i]))
                    {
                        if (f)
                        {
                            outro += c[i];
                        }
                        else { intro += c[i]; }
                    }
                    else
                    {
                        f = true;
                        u += c[i];
                    }
                }
                f = false;
                int id = 0;
                for (int j = 0; j < words.Length; j++)
                {
                    if (words[j] == u) { f = true; id = j; break; }
                }
                if (f)
                {
                    h += intro + codes[id] + outro + " ";
                }
                else { h += c + " "; }
            }
            return h;
        }
    }
    class Number13 : Task
    {
        public Number13(string t) : base(t) { }
        public override string ToString()
        {
            List<char> letters = new List<char>();
            List<int> counters = new List<int>();
            string[] words = text.Split(' ');
            foreach (string c in words)
            {
                foreach (char g in c)
                {
                    if (char.IsLetter(g))
                    {
                        for (int i = 0; i < counters.Count; i++)
                        {
                            if (letters[i] == g) { counters[i]++; break; }
                        }
                        letters.Add(g);
                        counters.Add(1);
                        break;
                    }
                }
            }
            string h = "";
            for (int i = 0; i < counters.Count; i++)
            {
                h += letters[i].ToString() + " - " + (counters[i] / (float)words.Length).ToString() + "%\n";
            }
            return h;
        }
    }
    class Number15 : Task
    {
        public Number15(string t) : base(t) { }
        public override string ToString()
        {
            int result = 0;
            int actualNumber = 0;
            bool f = false;
            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsDigit(text[i]))
                {
                    if (f)
                    {
                        actualNumber *= 10;
                    }
                    actualNumber += int.Parse(text[i].ToString());
                }
                else
                {
                    result += actualNumber;
                    actualNumber = 0;
                }
            }
            return result.ToString();
        }
    }
    static void Main()
    {
        string text = "Фьорды – это ущелья, формирующиеся ледниками и заполняющиеся морской водой. Название происходит от древнескандинавского слова \"fjǫrðr\". Эти глубокие заливы, окруженные высокими горами, представляют захватывающие виды и природную красоту. Они популярны среди туристов и известны под разными названиями: в Норвегии – \"фьорды\", в Шотландии – \"фьордс\", в Исландии – \"фьордар\". Фьорды играют важную роль в культуре и туризме региона, продолжая вдохновлять людей со всего мира.";
        Number1 number1 = new Number1(text);
        Console.WriteLine(number1);
        Number3 number3 = new Number3(text);
        Console.WriteLine(number3);
        Number6 number6 = new Number6(text);
        Console.WriteLine(number6);
        Number12 number12 = new Number12(text);
        Console.WriteLine(number12);
        Number13 number13 = new Number13(text);
        Console.Write(number13);
        Number15 number15 = new Number15(text);
    }
}