//1 уровень 4 задание 
using System;

namespace HighJumpCompetition
{
    class Program
    {
        class Participant
        {
            public string Name { get; private set; }
            public double BestAttempt { get; private set; }

            public Participant(string name, double bestAttempt)
            {
                this.Name = name;
                this.BestAttempt = bestAttempt;
            }

            public override string ToString()
            {
                return string.Format(
                    "{0} - {1} м",
                    this.Name,
                    this.BestAttempt
                );
            }
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
            participants[0] = new Participant("Anna", 1.75);
            participants[1] = new Participant("Bob", 1.80);
            participants[2] = new Participant("Sveta", 1.70);
            participants[3] = new Participant("David", 1.85);
            participants[4] = new Participant("Eva", 1.90);

            BubbleSort(participants);

            for (int i = 0; i < participants.Length; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, participants[i]);
            }
        }
    }
}