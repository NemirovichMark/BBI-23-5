using System;
namespace Variant_2
{
    public class Task3
    {
        public class Grep
        {
            private string input;
            private string output;
            public string Input
            {
                get { return input; }
            }

            public string Output
            {
                get { return output; }
            }

            public Grep(string text)
            {
                input = text;
                output = ProcessText(input);
            }
            private string ProcessText(string text)
            {
                if (string.IsNullOrEmpty(text))
                {
                    return string.Empty;
                }
                char mostFrequentChar = FindMostFrequentChar(text);
                string[] words = text.Split(' ');
                string result = string.Empty;

                foreach (var word in words)
                {
                    result += word + " ";
                }

                return result.Trim();
            }

            private char FindMostFrequentChar(string text)
            {
                int[] charCounts = new int[256];

                foreach (char c in text)
                {
                    if (char.IsLetter(c))
                    {
                        charCounts[char.ToLower(c)]++;
                    }
                }

                int maxCount = 0;
                char mostFrequentChar = ' ';

                for (int i = 0; i < charCounts.Length; i++)
                {
                    if (charCounts[i] > maxCount)
                    {
                        maxCount = charCounts[i];
                        mostFrequentChar = (char)i;
                    }
                }

                return mostFrequentChar;
            }

            public override string ToString()
            {
                return output;
            }

            static void Main(string[] args)
            {
                string text = "Это текст для проверки кода на экзамене по объектно-ориентированному программированию.";
                Grep grep = new Grep(text);

                Console.WriteLine("Input Text:");
                Console.WriteLine(grep.Input);

                Console.WriteLine("\nOutput Text:");
                Console.WriteLine(grep.Output);
            }
        }
    }
}