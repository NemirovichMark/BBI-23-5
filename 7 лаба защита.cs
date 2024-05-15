//1 уровень 4 задание (7 лабораторная) 
using System;

namespace HighJumpCompetition
{
    abstract class Participant
    {
        public string Name { get; private set; }
        public double BestAttempt { get; private set; }
        public bool Disqualified { get; private set; }

        public Participant(string name, double bestAttempt)
        {
            this.Name = name;
            this.BestAttempt = bestAttempt;
            this.Disqualified = false;
        }

        public void Disqualify()
        {
            this.Disqualified = true;
        }

        public abstract string GetSport();

        public override string ToString()
        {
            return string.Format(
                "{0} - {1} м",
                this.Name,
                this.BestAttempt
            );
        }
    }

    class HighJumpParticipant : Participant
    {
        public HighJumpParticipant(string name, double bestAttempt) : base(name, bestAttempt) { }

        public override string GetSport()
        {
            return "HighJump";
        }
    }

    class Program
    {
        static void QuickSort(Participant[] arr, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(arr, low, high);

                QuickSort(arr, low, pi - 1);
                QuickSort(arr, pi + 1, high);
            }
        }

        static int Partition(Participant[] arr, int low, int high)
        {
            Participant pivot = arr[high];
            int i = (low - 1);

            for (int j = low; j < high; j++)
            {
                if (arr[j].BestAttempt >= pivot.BestAttempt) 
                {
                    i++;
                    Participant temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            Participant temp1 = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temp1;

            return i + 1;
        }

        static void Main(string[] args)
        {
            Participant[] participants = new Participant[5];
            participants[0] = new HighJumpParticipant("Anna", 1.75);
            participants[1] = new HighJumpParticipant("Bob", 1.80);
            participants[2] = new HighJumpParticipant("Sveta", 1.70);
            participants[3] = new HighJumpParticipant("David", 1.85);
            participants[4] = new HighJumpParticipant("Eva", 1.90);

            participants[2].Disqualify();

            QuickSort(participants, 0, participants.Length - 1);

            Console.WriteLine("High Jump Competition Results:");
            for (int i = 0; i < participants.Length; i++)
            {
                if (!participants[i].Disqualified)
                {
                    Console.WriteLine("{0}. {1}", i + 1, participants[i]);
                }
            }
        }
    }
}
