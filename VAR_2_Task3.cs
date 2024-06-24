using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Variant_2
{
    public class Task3
    {
        public class Grep
        {
            public string Input { get; }
            public string Output { get; }

            public Grep(string input)
            {
                Input = input;
                Output = ProcessInput(input);
            }

            private string ProcessInput(string input)
            {
                
                char mostFrequentChar = ' ';
                int maxCount = 0;
                foreach (char c in input)
                {
                    int count = 0;
                    foreach (char ch in input)
                    {
                        if (ch == c)
                        {
                            count++;
                        }
                    }
                    if (count > maxCount)
                    {
                        mostFrequentChar = c;
                        maxCount = count;
                    }
                }
                
                return input.Replace(mostFrequentChar.ToString(), "").Trim();
            }

            public override string ToString()
            {
                return Output;
            }
        }
    }


        
}
