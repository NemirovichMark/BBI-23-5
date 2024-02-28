////3 уровень 4 задание 
//using System;


//struct RaceParticipant
//{
//    public string lastName;
//    public float result;
//}

//class Program
//{
//    static void Main(string[] args)
//    {
        
//        RaceParticipant[] group1 = new RaceParticipant[5];
//        RaceParticipant[] group2 = new RaceParticipant[5];

        
//        group1[0].lastName = "Иванов";
//        group1[0].result = 15.2f;

//        group1[1].lastName = "Петров";
//        group1[1].result = 15.5f;

//        group1[2].lastName = "Сидоров";
//        group1[2].result = 15.7f;

//        group1[3].lastName = "Козлов";
//        group1[3].result = 15.3f;

//        group1[4].lastName = "Смирнов";
//        group1[4].result = 15.1f;

        
//        group2[0].lastName = "Алексеев";
//        group2[0].result = 14.8f;

//        group2[1].lastName = "Борисов";
//        group2[1].result = 14.9f;

//        group2[2].lastName = "Григорьев";
//        group2[2].result = 14.7f;

//        group2[3].lastName = "Дмитриев";
//        group2[3].result = 14.6f;

//        group2[4].lastName = "Егоров";
//        group2[4].result = 14.5f;

        
//        RaceParticipant[] allParticipants = new RaceParticipant[group1.Length + group2.Length];

//        for (int i = 0; i < group1.Length; i++)
//        {
//            allParticipants[i] = group1[i];
//        }

//        for (int i = 0; i < group2.Length; i++)
//        {
//            allParticipants[group1.Length + i] = group2[i];
//        }

        
//        for (int i = 0; i < allParticipants.Length - 1; i++)
//        {
//            for (int j = i + 1; j < allParticipants.Length; j++)
//            {
//                if (allParticipants[i].result > allParticipants[j].result)
//                {
//                    RaceParticipant temp = allParticipants[i];
//                    allParticipants[i] = allParticipants[j];
//                    allParticipants[j] = temp;
//                }
//            }
//        }

        
//        Console.WriteLine("Участник\t\tРезультат");
//        Console.WriteLine("---------------------------------");

//        foreach (var participant in allParticipants)
//        {
//            Console.WriteLine($"{participant.lastName,-10}\t\t{participant.result}");
//        }

//    }
//}
