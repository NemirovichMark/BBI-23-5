//1 уровень 4 задание 
using System;

namespace HighJumpCompetition
{
    class Program
    {
        class Participant
        {
            public string Name { get; set; }
            public double BestAttempt { get; set; }
        }

        static void BubbleSort(Participant[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j].BestAttempt < arr[j + 1].BestAttempt)
                    {
                        Participant temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Participant[] participants = new Participant[5];
            participants[0] = new Participant { Name = "Anna", BestAttempt = 1.75 };
            participants[1] = new Participant { Name = "Bob", BestAttempt = 1.80 };
            participants[2] = new Participant { Name = "Sveta", BestAttempt = 1.70 };
            participants[3] = new Participant { Name = "David", BestAttempt = 1.85 };
            participants[4] = new Participant { Name = "Eva", BestAttempt = 1.90 };

            BubbleSort(participants);

            for (int i = 0; i < participants.Length; i++)
            {
                Console.WriteLine("{0}. {1} - {2} м", i + 1, participants[i].Name, participants[i].BestAttempt);
            }
        }
    }
}