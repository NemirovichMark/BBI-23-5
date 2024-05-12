using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
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
    // посчитать отдельно  количество букв цифр пробелов в тексте
    class Task1 : Task
    {
        public Task1(string text) : base(text)
        { }
        public override void ParseText()
        {

            string[] str = text.Split(new char[] { ' ', ',', '.', '?', '!' });
            for (int i = 0; i < str.Length; i++)
            {
                amount++;
            }
        }
        public override string ToString()
        {

            return amount.ToString();
        }
    }
    //оставить только свободные слова
    class Task2 : Task
    {
        public Task2(string text) : base(text)
        { }
        public override void ParseText()
        {

            string[] str = text.Split(new char[] { ',', '.', '?', '!' });
            text = str[];
        }
        public override string ToString()
        {

            return text;
        }
    }
    internal class Program
    {
        static void Main()
        {
            Task[] tasks =
            {
                new Task1("В этом тексте надо подсчитать число букв, цифр, пункт. пробеллов. Перед вами сидит хомяк с большими грустными глазами, а на фоне играет скрипочка"),
                new Task2("А в лесу раздался топот коня, я огляделся, насторожился."),
                
            };
            for (int i = 0; i < tasks.Length; i++)
            {
                Console.WriteLine(tasks[i].Text);
                tasks[i].ParseText();
                Console.WriteLine(tasks[i]);
            }
        }
    }
}
