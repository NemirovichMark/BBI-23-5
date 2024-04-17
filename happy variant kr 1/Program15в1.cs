using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        public struct Series
        {
            private string _name;
            private double _avg_dur;
            private string _description;
            private bool _watched;
            public int NameLength => _name.Length;

            public void Check()
            {
                _watched = true;
            }
            public void SetDescription(string description)
            {
                if (description.Length >= 20 && description.Length <= 200) { _description = description; }
                else { Console.WriteLine("Описание должно быть не короче 20 символов и не длиннее 200"); }
            }
            public Series(string name, double avg_dur)
            {
                _name = name;
                _avg_dur = avg_dur;
                _description = $"Для сериала {_name} описание не задано";
                _watched = false;
            }
            public void Display()
            {
                string s;
                if (_watched)
                {
                    s = "Просмотрено";
                }
                else { s = "Не просмотрено"; }
                Console.WriteLine($"Название: {_name}\nСредняя продолжительность: {_avg_dur} минут\nОписание: {_description}\nСостояние: {s}\n--------------------------");
            }
        }
        static void Main(string[] args)
        {
            Series[] series =
            {
                new Series("Ранетки", 100),
                new Series("Кухня", 40),
                new Series("Бесстыжие", 150),
                new Series("Тьма", 40),
                new Series("Черное зеркало",50)
            };
            ShellSort(series);
            for (int i = 0; i < series.Length; i++)
            {
                series[i].Display();
            }
            series[0].SetDescription("Максим Лавров переезжает в Москву и встречает любовь всей своей жизни Викторию Сергеевну");
            series[0].Check();
            for (int i = 0; i < series.Length; i++)
            {
                series[i].Display();
            }
        }
        public static void ShellSort(Series[] arr)
        {
            int step = arr.Length / 2;
            while (step >= 1)
            {
                for (int i = step; i < arr.Length; i++)
                {
                    Series temp = arr[i];
                    int j = i;
                    while ((j >= step) && (arr[j - step].NameLength < temp.NameLength))
                    {
                        arr[j] = arr[j - step];
                        j -= step;
                    }
                    arr[j] = temp;
                }
                step /= 2;
            }
        }

    }
}


//public static bool operator >(Series x, Series y)
//{
//    string a = x._name;
//    string b = y._name;
//    for (int i = 0; i < Math.Min(a.Length, b.Length); i++)
//    {
//        if (a[i] > b[i])
//        {
//            return true;
//        }
//        else if (a[i] < b[i]) { return false; }
//    }
//    if (a.Length < b.Length)
//    {
//        return false;
//    }
//    else if (a.Length > b.Length)
//    {
//        return true;
//    }
//    else
//    {
//        return false;
//    }
//}
//public static bool operator <(Series x, Series y)
//{
//    string a = x._name;
//    string b = y._name;
//    for (int i = 0; i < Math.Min(a.Length, b.Length); i++)
//    {
//        if (a[i] < b[i])
//        {
//            return true;
//        }
//        else if (a[i] > b[i]) { return false; }
//    }
//    if (a.Length > b.Length)
//    {
//        return false;
//    }
//    else if (a.Length < b.Length)
//    {
//        return true;
//    }
//    else
//    {
//        return false;
//    }
//}