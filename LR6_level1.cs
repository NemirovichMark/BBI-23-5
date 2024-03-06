//Радиокомпания провела опрос слушателей по вопросу: «Кого вы считаете человеком года?».
//Определить пять наиболее часто встречающихся ответов и их долей (в процентах от общего количества ответов). 
using System;

class Programm
{
    struct Answer
    {
        private string _name;
        public string Name => _name;
        private int _count;
        public int Count => _count;
        private static int _persentCounter = 0;
        //public static int PersentCounter = 0;



        public Answer(string name)
        {
            _name = name;
            _count = 1;
            _persentCounter++;
        }
        public void ResponsesCounter()
        {
            _count++;
            _persentCounter++;
        }
        public void Print(int place)
        {
                Console.WriteLine($"На {place} месте: {Name} - {Count * 100 / _persentCounter}%");

        }
    }
    static void Main()
    {
        Answer[] answ = new Answer[] { }; //массив, через добавление в который будем считать ответы
        //int PersentCounter = 0; 
        string[] Responses = new[]{ "Эмма Уотсон", "Анастатися Ивлеева", //все ответы
            "Джон Смит", "Константин Ивлев", "Константин Ивлев",
            "Константин Ивлев","Эмма Уотсон","Эмма Уотсон","Эмма Уотсон",
            "Эмма Уотсон","Джон Смит","Мария Иванова","Анастатися Ивлеева",
            "Константин Ивлев","Александр Петров","Мария Иванова",
            "Эмма Уотсон","Анастатися Ивлеева","Джон Смит","Мария Иванова",
            "Эмма Уотсон","Константин Ивлев","Анастатися Ивлеева"};
        for (int i = 0; i < Responses.Length; i++)
        {
            string[] names = answ.Select(x => x.Name).ToArray();
            if (names.Contains(Responses[i]))
                answ[Array.IndexOf(names, Responses[i])].ResponsesCounter();
            else
                answ = answ.Append(new Answer(Responses[i])).ToArray();
            //Answer.PersentCounter++;
        }

        //static void SelectionSort(Answer[] Array)
        //{
        //    for (int i = 0; i < Array.Length - 1; i++)
        //    {
        //        int min = i;
        //        for (int j = i + 1; j < Array.Length; j++)
        //        {
        //            if (Array[j].Count > Array[min].Count)
        //            {
        //                min = j;
        //            }
        //        }
        //        Answer dummy = Array[i];
        //        Array[i] = Array[min];
        //        Array[min] = dummy;
        //        min = i;
        //    }
        //}
        //SelectionSort(answ);
        static void InsertionSort(Answer[] Array)
        {
            for (int i = 1; i < Array.Length; i++)
            {
                Answer k = Array[i];
                int j = i - 1;
                while (j >= 0 && Array[j].Count < k.Count)
                {
                    Array[j + 1] = Array[j];
                    j--;
                }
                Array[j + 1] = k;
            }
        }
        InsertionSort(answ);
        int place = 1;
        foreach (Answer a in answ)
        {
            if (place >= 6)
                break;
            a.Print(place);
            place++;
        }

    }
}