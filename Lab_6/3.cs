using System;

namespace Level3
{
    struct Participant
    {
        string _name;
        int _result;
        public int Result { get { return _result; } }
        public Participant(string name, int result)
        {
            _name = name;
            _result = result;
        }
        public void Print()
        {
            Console.WriteLine($"{_name}: {_result}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Participant[] groupA = { new Participant("Иванов", 9), new Participant("Петров", 4), new Participant("Сидоров", 7), new Participant("Романов", 10) };
            Participant[] groupB = { new Participant("Егоров", 6), new Participant("Бурунов", 5), new Participant("Грязнов", 8), new Participant("Глушаков", 9) };
            Sort(groupA);
            Sort(groupB);
            Participant[] res = Merge(groupA, groupB);
            for (int i = 0; i < res.Length; i++)
            {
                res[i].Print();
            }
        }
        static void Sort(Participant[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                for (int j = 1; j < arr.Length; j++)
                {
                    if (arr[j].Result > arr[j - 1].Result)
                    {
                        Participant temp = arr[j];
                        arr[j] = arr[j - 1];
                        arr[j - 1] = temp;
                    }
                }
            }
        }
        static Participant[] Merge(Participant[] arr1, Participant[] arr2)
        {
            Participant[] result = new Participant[arr1.Length + arr2.Length];
            int i, j;
            i = j = 0;
            for (int k = 0; k < result.Length; k++)
            {
                if (i >= arr1.Length)
                {
                    result[k] = arr2[j];
                    j++;
                }
                else if (j >= arr2.Length)
                {
                    result[k] = arr1[i];
                    i++;
                }
                else if (arr1[i].Result < arr2[j].Result)
                {
                    result[k] = arr2[j];
                    j++;
                }
                else
                {
                    result[k] = arr1[i];
                    i++;
                }
            }
            return result;
        }
    }
}
