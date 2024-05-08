using System;
using System.Collections.Generic;
using System.Linq;

abstract class Sportsman
{
    public string Name { get; private protected set; }
    public int Result { get; private protected set; }

    public Sportsman(string name, int result)
    {
        Name = name;
        Result = result;
    }

    public abstract void Display();

    public static List<Sportsman> MergeGroups(List<Sportsman> group1, List<Sportsman> group2)
    {
        List<Sportsman> mergedGroup = [.. group1, .. group2];
        return mergedGroup;
    }

    public static void QuickSort(List<Sportsman> list, int minIndex, int maxIndex)
    {
        if (minIndex < maxIndex)
        {
            int pivotIndex = Partition(list, minIndex, maxIndex);
            QuickSort(list, minIndex, pivotIndex - 1);
            QuickSort(list, pivotIndex + 1, maxIndex);
        }
    }

    private static int Partition(List<Sportsman> list, int minIndex, int maxIndex)
    {
        Sportsman pivot = list[maxIndex];
        int i = minIndex - 1;
        for (int j = minIndex; j < maxIndex; j++)
        {
            if (list[j].Result <= pivot.Result)
            {
                i++;
                Swap(list, i, j);
            }
        }
        Swap(list, i + 1, maxIndex);
        return i + 1;
    }

    private static void Swap(List<Sportsman> list, int i, int j)
    {
        Sportsman temp = list[i];
        list[i] = list[j];
        list[j] = temp;
    }
}

class SkierGirl : Sportsman
{
    public SkierGirl(string name, int result) : base(name, result) { }

    public override void Display()
    {
        Console.WriteLine($"Гонщица {Name} проехала трассу за {Result} минут");
    }
}

class SkierBoy : Sportsman
{
    public SkierBoy(string name, int result) : base(name, result) { }

    public override void Display()
    {
        Console.WriteLine($"Гонщик {Name} проехал трассу за {Result} минут");
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Sportsman> skierGirlsGroup1 = new List<Sportsman>
        {
            new SkierGirl("Анна", 20),
            new SkierGirl("Мария", 18),
            new SkierGirl("Елена", 19)
        };

        List<Sportsman> skierGirlsGroup2 = new List<Sportsman>
        {
            new SkierGirl("Ольга", 22),
            new SkierGirl("Ирина", 23),
            new SkierGirl("Татьяна", 17)
        };

        List<Sportsman> skierBoysGroup1 = new List<Sportsman>
        {
            new SkierBoy("Сергей", 15),
            new SkierBoy("Иван", 17),
            new SkierBoy("Петр", 13)
        };

        List<Sportsman> skierBoysGroup2 = new List<Sportsman>
        {
            new SkierBoy("Алексей", 16),
            new SkierBoy("Дмитрий", 14),
            new SkierBoy("Николай", 21)
        };

        List<Sportsman> allParticipants =
        [
            .. Sportsman.MergeGroups(skierGirlsGroup1, skierGirlsGroup2),
            .. Sportsman.MergeGroups(skierBoysGroup1, skierBoysGroup2),
        ];

        Console.WriteLine("Соревнования среди лыжниц - объединенная группа:");
        List<Sportsman> mergedGirlsGroup = Sportsman.MergeGroups(skierGirlsGroup1, skierGirlsGroup2);
        Sportsman.QuickSort(mergedGirlsGroup, 0, mergedGirlsGroup.Count - 1);
        foreach (var skierGirl in mergedGirlsGroup)
        {
            skierGirl.Display();
        }

        Console.WriteLine("\nСоревнования среди лыжников - объединенная группа:");
        List<Sportsman> mergedBoysGroup = Sportsman.MergeGroups(skierBoysGroup1, skierBoysGroup2);
        Sportsman.QuickSort(mergedBoysGroup, 0, mergedBoysGroup.Count - 1);
        foreach (var skierBoy in mergedBoysGroup)
        {
            skierBoy.Display();
        }

        Console.WriteLine("\nОбщие результаты:");
        Sportsman.QuickSort(allParticipants, 0, allParticipants.Count - 1);
        foreach (var participant in allParticipants)
        {
            participant.Display();
        }
    }
}