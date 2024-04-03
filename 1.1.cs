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
        static void GnomeSort(Participant[] arr)
        {
            int n = arr.Length;
            int i = 1;
            int j = 2;

            while (i < n)
            {
                if (arr[i - 1].BestAttempt <= arr[i].BestAttempt)
                {
                    i = j;
                    j++;
                }
                else
                {
                    Participant temp = arr[i - 1];
                    arr[i - 1] = arr[i];
                    arr[i] = temp;
                    if (i > 1)
                    {
                        i--;
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

            GnomeSort(participants);

            for (int i = 0; i < participants.Length; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, participants[i]);
            }
        }
    }
}