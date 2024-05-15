
class Program
{

    abstract class StringTask
    {
        protected string text;

        protected StringTask(string text)
        {
            this.text = text;
        }

        protected IEnumerable<string> getWords()   
        {
            var punctuation = text.Where(Char.IsPunctuation).Distinct().ToArray();
            var words = text.Split().Select(x => x.Trim(punctuation));
            return words;
        }
    }
    struct LetterFrequency 
    {
        public char Letter { get; set; } 
        public int Count { get; set; }

        public LetterFrequency(char letter) 
        {
            Letter = letter;
            Count = 0;
        }
         
        public void IncrementCount()
        {
            Count++;
        }
    }
    class Task_1 : StringTask
    {
        private LetterFrequency[] letterFrequencies = new LetterFrequency['я' - 'а' + 1]; 

        public Task_1(string text) : base(text)
        {
            foreach (char c in text.ToLower())
            {
                if (IsRussianLetter(c))
                {
                    IncrementFrequency(c);
                }
            }

            Sort(letterFrequencies);
        }
        private void IncrementFrequency(char letter) 
        {
            letterFrequencies[letter - 'а'].IncrementCount();
        }

        private void Sort(LetterFrequency[] array)
        {
            int n = array.Length;
            int i, j;
            for (i = 1; i < n; ++i)
            {
                LetterFrequency key = array[i];
                j = i - 1;

                while (j >= 0 && array[j].Count < key.Count)
                {
                    array[j + 1] = array[j];
                    j = j - 1;
                }
                array[j + 1] = key;
            }
        }
        


        private bool IsRussianLetter(char c)
        {
            return c >= 'а' && c <= 'я';
        }

        public override string ToString()
        {
            string result = "Частотный анализ букв русского алфавита:\n";
            int totalLetters = letterFrequencies.Sum(x => x.Count);
            foreach (var frequency in letterFrequencies)
            {
                result += $"{frequency.Letter}: {frequency.Count} раз(а) - {(float)frequency.Count / totalLetters * 100}%\n";
            }
            return result;
        }
    }

    class Task_3 : StringTask
    {
        private string res;
        public Task_3(string text) : base(text)
        {
            res = "";
            var words = getWords();

            int free_space = 50;
            int row_i = 0;
            bool is_new_row = true; 
            foreach (string word in words)
            {
                if (!is_new_row) 
                {
                    if (free_space - word.Length - 1 >= 0)
                    {
                        res += " " + word;
                        free_space -= word.Length - 1;
                    }
                    else
                    {
                        res += "\n" + word;
                        free_space = 50 - word.Length;
                    }
                }
                else
                {
                    res = word;
                    free_space -= word.Length;
                    is_new_row = false;
                }
            }

        }

        public override string ToString()
        {
            return res;
        }
    }

    class Task_5 : StringTask
    {
        private int[] data;
        public Task_5(string text) : base(text)
        {
            data = new int[5000];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = 0;
            }
            var words = getWords();
            foreach (string word in words) 
            {
                if (word.Length == 0)
                {
                    continue;
                }
                data[(int)word[0]]++;
            }
        }

        public override string ToString()
        {
            string res = "Частотный анализ:\n";
            string used = "";
            int max_val = 0;
            char max_c = ' ';

            var words = getWords();

            while (max_val != -1) 
            {
                max_val = -1;
                max_c = ' ';
                foreach (string word in words)
                {
                    if (word.Length == 0)
                    {
                        continue;
                    }
                    char symbol = word[0];
                    if ((!used.Contains(symbol)) && (max_val < data[(int)symbol]))
                    {
                        max_val = data[(int)symbol];
                        max_c = symbol; 
                    }
                }
                if (max_val != -1)
                {
                    used += max_c;
                    res += $"-> {max_c} - {max_val} раз(а)\n";
                }
            }
            return res;
        }

    }

    class Task_7 : StringTask
    {
        private string res;

        public Task_7(string text) : base(text)
        {
        }

        public Task_7(string text, string sub) : base(text)
        {
            res = "";
            var words = getWords();
            foreach (var word in words)
            {
                if (words.Contains(sub)) 
                {
                    res += " " + word;
                }
            }
        }
        public override string ToString()
        {
            return res;
        }
    }

    class Task_11 : StringTask
    {
        private IEnumerable<string> words; 
        public Task_11(string text) : base(text)
        {
            words = getWords();
        }
        public override string ToString()
        {
            string res = "Фамилии:\n";
            foreach (var surname in words.OrderBy(x => x)) 
            {
                res += $"{surname}, ";
            }
            return res;
        }
    }

    class Task_14 : StringTask
    {
        private int cnt; 
        public Task_14(string text) : base(text)
        {
            var words = getWords();
            foreach (var word in words)
            {
                int n;
                bool isNumeric = int.TryParse(word, out n);
                if (isNumeric)
                {
                    cnt += n;
                }
            }
        }
        public override string ToString()
        {
            string res = "Сумма чисел: " + cnt.ToString();
            return res;
        }
    }

    static void Main(string[] args)
    {
        string s = "После многолетних исследований ученые обнаружили тревожную тенденцию в вырубке лесов Амазонии. Анализ данных показал, что основной участник разрушения лесного покрова – человеческая деятельность. За последние десятилетия рост объема вырубки достиг критических показателей. Главными факторами, способствующими этому, являются промышленные рубки, производство древесины, расширение сельскохозяйственных угодий и незаконная добыча древесины. Это приводит к серьезным экологическим последствиям, таким как потеря биоразнообразия, ухудшение климата и угроза вымирания многих видов животных и растений.!";
        string surnames = "Иванов\nПетров\nСмирнов\nСоколов\nКузнецов\nПопов\nЛебедев\nВолков\nКозлов\nНовиков\nИванова\nПетрова\nСмирнова";

        Task_1 stat = new Task_1(s);
        Console.WriteLine(stat.ToString());

        Task_3 nt = new Task_3(s);
        Console.WriteLine(nt.ToString());

        Task_5 n = new Task_5(s);
        Console.WriteLine(n.ToString());

        Task_7 ny = new Task_7(s);
        Console.WriteLine(ny.ToString());

        Task_11 sp = new Task_11(surnames);
        Console.WriteLine(sp.ToString());

        Task_14 ntt = new Task_14(s);
        Console.WriteLine(ntt.ToString());
    }
}
