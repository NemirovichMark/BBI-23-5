Console.WriteLine("\nСписок команд и количество набранных очков для второго массива:");
foreach (FootballZhen rezultati in komandi2)
{
    rezultati.Print();
}

Sort(komandi2, komandi2.Length);
Console.WriteLine(" ");
Console.WriteLine("Остортированные списки для второго массива:");
foreach (FootballZhen rezultati in komandi2)
{
    rezultati.Print();
}

Console.WriteLine(" ");
Console.WriteLine("Топ 6 команд прошедших в следующий тур для второго массива:");
Football[] top6_2 = TopTims(komandi2, 6);
foreach (FootballZhen rezultati in top6_2)
{
    rezultati.Print();
}
Console.WriteLine("Мужская:");
Console.WriteLine("Список команд и количество набранных очков для первого массива:");
foreach (FootballMuzh rezultati in komandi3)
{
    rezultati.Print();
}

Sort(komandi3, komandi3.Length);
Console.WriteLine(" ");
Console.WriteLine("Остортированные списки для первого массива:");
foreach (FootballMuzh rezultati in komandi3)
{
    rezultati.Print();
}

Console.WriteLine(" ");
Console.WriteLine("Топ 6 команд прошедших в следующий тур для первого массива:");
Football[] top6_3 = TopTims(komandi3, 6);
foreach (FootballMuzh rezultati in top6_3)
{
    rezultati.Print();
}

Console.WriteLine("\nСписок команд и количество набранных очков для второго массива:");
foreach (FootballMuzh rezultati in komandi4)
{
    rezultati.Print();
}

Sort(komandi4, komandi4.Length);
Console.WriteLine(" ");
Console.WriteLine("Остортированные списки для второго массива:");
foreach (FootballMuzh rezultati in komandi4)
{
    rezultati.Print();
}

Console.WriteLine(" ");
Console.WriteLine("Топ 6 команд прошедших в следующий тур для второго массива:");
Football[] top6_4 = TopTims(komandi4, 6);
foreach (FootballMuzh rezultati in top6_4)
{
    rezultati.Print();
}

Console.WriteLine(" Общий топ 6 команд:");
Football[] Foundtop6 = NaidenoTop6(top6_1, top6_2, top6_3, top6_4);
foreach (Football rezultati in Foundtop6)
{
    rezultati.Print();
}
    }

    static void Sort(Football[] komandi, int count)
{
    for (int i = 1; i < count; i++)
    {
        int j = i;
        while (j > 0 && komandi[j - 1].Score < komandi[j].Score)
        {
            Football temp = komandi[j];
            komandi[j] = komandi[j - 1];
            komandi[j - 1] = temp;
            j--;
        }
    }
}

static Football[] TopTims(Football[] komandi, int count)
{
    Football[] topTeams = new Football[count];
    Array.Copy(komandi, topTeams, count);
    return topTeams;
}

static Football[] NaidenoTop6(Football[] top1, Football[] top2, Football[] top3, Football[] top4)
{
    Football[] ObshiyTop = new Football[top1.Length + top2.Length + top3.Length + top4.Length];
    Array.Copy(top1, 0, ObshiyTop, 0, top1.Length);
    Array.Copy(top2, 0, ObshiyTop, top1.Length, top2.Length);
    Array.Copy(top3, 0, ObshiyTop, top1.Length + top2.Length, top3.Length);
    Array.Copy(top4, 0, ObshiyTop, top1.Length + top2.Length + top3.Length, top4.Length);
    Sort(ObshiyTop, ObshiyTop.Length);
    return TopTims(ObshiyTop, 6);
}
}