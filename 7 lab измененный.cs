using System;

class Football
{
    private string famile;
    private int pos_goal;
    private int con_goal;
    private int score;

    public Football(string famile)
    {
        this.famile = famile;
        this.pos_goal = 0;
        this.con_goal = 0;
        this.score = 0;
    }

    public void Result(int scored, int conceded)
    {
        pos_goal += scored;
        con_goal += conceded;
        if (scored > conceded)
        {
            score += 3;
        }
        else if (scored < conceded)
        {
            score += 1;
        }
    }

    public int Score { get { return score; } }

    public int Minus { get { return pos_goal - con_goal; } }

    public void Get_Inf()
    {
        Console.WriteLine(famile + " " + score);
    }

    public void MergeSort(Football[] array)
    {
        if (array.Length <= 1)
        {
            return;
        }

        int mid = array.Length / 2;
        Football[] leftArray = new Football[mid];
        Football[] rightArray = new Football[array.Length - mid];

        for (int i = 0; i < mid; i++)
        {
            leftArray[i] = array[i];
        }

        for (int i = mid; i < array.Length; i++)
        {
            rightArray[i - mid] = array[i];
        }

        MergeSort(leftArray);
        MergeSort(rightArray);
        Merge(leftArray, rightArray, array);
    }

    public void Merge(Football[] left, Football[] right, Football[] original)
    {
        int leftIndex = 0;
        int rightIndex = 0;
        int originalIndex = 0;
        while (leftIndex < left.Length && rightIndex < right.Length)
        {
            if (left[leftIndex].Score > right[rightIndex].Score ||
                (left[leftIndex].Score == right[rightIndex].Score && left[leftIndex].Minus < right[rightIndex].Minus))
            {
                original[originalIndex++] = left[leftIndex++];
            }
            else
            {
                original[originalIndex++] = right[rightIndex++];
            }
        }
        while (leftIndex < left.Length)
        {
            original[originalIndex++] = left[leftIndex++];
        }
        while (rightIndex < right.Length)
        {
            original[originalIndex++] = right[rightIndex++];
        }
    }
}

class WomenFootball : Football
{
    public WomenFootball(string famile) : base(famile)
    {

    }
}

class MenFootball : Football
{
    public MenFootball(string famile) : base(famile)
    {

    }
}

class Program
{
    static void Main(string[] args)
    {
        Football[] womenFootball = new Football[]
        {
            new WomenFootball("Динамо Женщины"),
            new WomenFootball("Краснодар Женщины"),
            new WomenFootball("ЦСКА Женщины"),
        };

        Football[] menFootball = new Football[]
        {
            new MenFootball("Динамо Мужчины"),
            new MenFootball("Краснодар Мужчины"),
            new MenFootball("ЦСКА Мужчины"),
        };

        void Match(ref Football football1, ref Football football2)
        {
            Random random = new Random();
            int scored = random.Next(0, 5);
            int conceded = random.Next(0, 5);
            football1.Result(scored, conceded);
            football2.Result(conceded, scored);
        }

        Match(ref womenFootball[0], ref womenFootball[1]);
        Match(ref womenFootball[0], ref womenFootball[2]);
        Match(ref womenFootball[1], ref womenFootball[2]);

        Match(ref menFootball[0], ref menFootball[1]);
        Match(ref menFootball[0], ref menFootball[2]);
        Match(ref menFootball[1], ref menFootball[2]);

        womenFootball[0].MergeSort(womenFootball);
        menFootball[0].MergeSort(menFootball);

        for (int i = 0; i < 3; i++)
        {
            womenFootball[i].Get_Inf();
        }

        Console.WriteLine("");

        for (int i = 0; i < 3; i++)
        {
            menFootball[i].Get_Inf();
        }

    }
}

//static void Sort(ref Football[] footbals)
//{
//    for (int i = 0; i < footbals.Length - 1; i++)
//    {
//        for (int j = 0; j < footbals.Length - i - 1; j++)
//        {
//            if (footbals[j].Score < footbals[j + 1].Score ||
//                (footbals[j].Score == footbals[j + 1].Score && footbals[j].Minus < footbals[j + 1].Minus))
//            {
//                Football temp = footbals[j];
//                footbals[j] = footbals[j + 1];
//                footbals[j + 1] = temp;
//            }
//        }
//    }