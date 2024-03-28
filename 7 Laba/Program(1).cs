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
            participants[0] = new HighJumpParticipant("Anna", 1.75);
            participants[1] = new HighJumpParticipant("Bob", 1.80);
            participants[2] = new HighJumpParticipant("Sveta", 1.70);
            participants[3] = new HighJumpParticipant("David", 1.85);
            participants[4] = new HighJumpParticipant("Eva", 1.90);

            participants[2].Disqualify(); 

            BubbleSort(participants);

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
