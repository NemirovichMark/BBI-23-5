//3 уровень 4 задание 
using System;


struct RaceParticipant
{
    private string lastName;
    public float result { get; private set; }

    public RaceParticipant(string lastName, float result)
    {
        this.lastName = lastName;
        this.result = result;
    }

    public override string ToString()
    {
        return string.Format(
          $"{this.lastName,-10}\t\t{this.result}"
        );
    }
}

class Program
{
    static void Main(string[] args)
    {
        RaceParticipant[] group1 = new RaceParticipant[5];
        RaceParticipant[] group2 = new RaceParticipant[5];

        group1[0] = new RaceParticipant("Сидоров", 15.7f);
        group1[1] = new RaceParticipant("Петров", 15.5f);
        group1[2] = new RaceParticipant("Козлов", 15.3f);
        group1[3] = new RaceParticipant("Иванов", 15.2f);
        group1[4] = new RaceParticipant("Смирнов", 15.1f);

        group2[0] = new RaceParticipant("Борисов", 14.9f);
        group2[1] = new RaceParticipant("Алексеев", 14.8f);
        group2[2] = new RaceParticipant("Григорьев", 14.7f);
        group2[3] = new RaceParticipant("Дмитриев", 14.6f);
        group2[4] = new RaceParticipant("Егоров", 14.5f);

        RaceParticipant[] allParticipants = new RaceParticipant[group1.Length + group2.Length];

        int i, j, c;
        i = j = c = 0;

        while (i < group1.Length && j < group2.Length)
        {
            if (group1[i].result >= group2[j].result)
            {
                allParticipants[c++] = group1[i++];
            }
            else
            {
                allParticipants[c++] = group2[j++];
            }
        }

        while (i < group1.Length)
        {
            allParticipants[c++] = group1[i++];
        }

        while (j < group2.Length)
        {
            allParticipants[c++] = group2[j++];
        }

        Console.WriteLine("Участник\t\tРезультат");
        Console.WriteLine("---------------------------------");

        foreach (var participant in allParticipants)
        {
            Console.WriteLine(participant);
        }

    }
}
