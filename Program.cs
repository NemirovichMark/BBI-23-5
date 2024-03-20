// n1 / 1

//using System.Xml;

//struct Answer
//{
//    private string name;
//    private double count;
//    private double all;
//    private double percent;
//    public Answer(string name, double count, double all)
//    {
//        this.name = name;
//        this.count = count;
//        this.all = all;
//        percent = count * 100 / all;
//    }

//    public string Name { get { return name; } set { name = value; } }
//    public double Count { get { return count; } set { count = value; } }
//    public double All { get { return all; } set { all = value; } }

//    public double Percent { get { return percent; } }
//    public void Show()
//    {
//        Console.WriteLine();
//    }
//   }

//class Program
//{
//    static void Main(string[] args)
//    {
//        Answer[] cl = new Answer[6];
//        cl[0] = new Answer("James", 10, 61);
//        cl[1] = new Answer("Pedro", 9, 61);
//        cl[2] = new Answer("Bogdan", 2, 61);
//        cl[3] = new Answer("Alex", 4, 61);
//        cl[4] = new Answer("Mark", 13, 61);
//        cl[5] = new Answer("Alexandra", 23, 61);
//        for (int i = 0; i < cl.Length; i++)
//        {
//            Console.WriteLine(cl[i].Name + ": " + cl[i].Percent);
//        }
//        for (int i = 0; i < cl.Length - 1; i++)
//        {
//            double amax = cl[i].Count;
//            int imax = i;
//            for (int j = i + 1; j < cl.Length; j++)
//            {
//                if (amax < cl[j].Count)
//                {
//                    amax = cl[j].Count;
//                    imax = j;
//                }
//            }
//            Answer temp;
//            temp = cl[imax];
//            cl[imax] = cl[i];
//            cl[i] = temp;
//        }
//        Console.WriteLine();
//        for (int i = 0; i < cl.Length; i++)
//        {
//            if (i == 5)
//            {
//                break;
//            }
//            else
//            {
//                Console.WriteLine(cl[i].Name + ": " + cl[i].Percent);
//            }
//        }
//        }
//    }

// n1 / Main

//struct Answer
//{
//    public string famile;
//    public double count;
//    public Answer(string famile, double count)
//    {
//        this.famile = famile;
//        this.count = count;
//    }
//    public string Famile { get { return famile; } set { famile = value; } }
//    public double Count { get { return count; } set { count = value; } }
//}

//class Program
//{
//    static void Main(string[] args)
//    {
//        Answer[] cl = new Answer[6];
//        cl[0] = new Answer("James", 10);
//        cl[1] = new Answer("Pedro", 9);
//        cl[2] = new Answer("Bogdan", 2);
//        cl[3] = new Answer("Alex", 4);
//        cl[4] = new Answer("Mark", 13);
//        cl[5] = new Answer("Alexandra", 23);
//        double sum = 0;
//        for (int i = 0; i < cl.Length; i++)
//        {
//            sum += cl[i].Count;
//        }
//        for (int i = 0; i < cl.Length - 1; i++)
//        {
//            double amax = cl[i].Count;
//            int imax = i;
//            for (int j = i + 1; j < cl.Length; j++)
//            {
//                if (amax < cl[j].Count)
//                {
//                    amax = cl[j].Count;
//                    imax = j;
//                }
//            }
//            Answer temp;
//            temp = cl[imax];
//            cl[imax] = cl[i];
//            cl[i] = temp;
//        }
//        double percent = 0;
//        for (int i = 0; i < cl.Length; i++)
//        {
//            percent = cl[i].Count / sum * 100;
//            Console.WriteLine(cl[i].Famile + " " + percent);
//        }
//    }
//}


// n2


//struct Jump
//{
//    public string famile;
//    private double[] estimate1;
//    private double[] estimate2;
//    private double summ_estimate1;
//    private double summ_estimate2;
//    private double sredn;


//    public Jump(string famile, double[] estimate1, double[] estimate2)
//    {
//        this.famile = famile;
//        this.estimate1 = estimate1;
//        this.estimate2 = estimate2;
//        summ_estimate1 = 0;
//        summ_estimate2 = 0;
//        sredn = 0;
//        for (int i = 0; i < estimate1.Length; i++)
//        {
//            summ_estimate1 += estimate1[i];
//        }
//        for (int j = 0; j < estimate2.Length; j++)
//        {
//            summ_estimate2 += estimate2[j];
//        }
//        sredn = (summ_estimate1 + summ_estimate2) / 10;
//    }
//    public string Famile { get { return famile; } }
//    public double Sredn { get { return sredn; } set { sredn = value; } }
//}

//class Program
//{
//    static void Main(string[] args)
//    {
//        Jump[] jump = new Jump[5];
//        jump[0] = new Jump("John", new double[5] { 10.0, 20.0, 10.0, 20.0, 10.0 },
//            new double[5] { 10.0, 20.0, 10.0, 20.0, 10.0 });
//        jump[1] = new Jump("Stiven", new double[5] { 15.0, 25.0, 20.0, 10.0, 10.0 },
//            new double[5] { 15.0, 25.0, 12.0, 6.0, 10.0 });
//        jump[2] = new Jump("Tomas", new double[5] { 12.0, 22.0, 16.0, 27.0, 13.0 },
//            new double[5] { 34.0, 21.0, 10.0, 11.0, 12.0 });
//        jump[3] = new Jump("Alexander", new double[5] { 16.0, 26.0, 17.0, 28.0, 19.0 },
//            new double[5] { 19.0, 28.0, 17.0, 6.0, 14.0 });
//        jump[4] = new Jump("Vaska", new double[5] { 19.0, 21.0, 16.0, 20.0, 20.0 },
//            new double[5] { 10.0, 20.0, 10.0, 20.0, 10.0 });
//        for (int i = 0; i < jump.Length - 1; i++)
//        {
//            double amax = jump[i].Sredn;
//            int imax = i;
//            for (int j = i + 1; j < jump.Length; j++)
//            {
//                if (amax < jump[j].Sredn)
//                {
//                    amax = jump[j].Sredn;
//                    imax = j;
//                }
//            }
//            Jump temp;
//            temp = jump[imax];
//            jump[imax] = jump[i];
//            jump[i] = temp;
//        }

//        for (int i = 0; i < jump.Length; i++)
//        {
//            Console.WriteLine(jump[i].famile + ": " + jump[i].Sredn);
//        }

//    }
//}

// n3

using System.Runtime.ExceptionServices;
using System.Xml.Linq;

//struct Jump
//{
//    private string famile;
//    private double[] estimate;
//    private int distance;
//    public Jump(string famile, double[] estimate, int distance)
//    {
//        this.famile = famile;
//        this.estimate = estimate;
//        this.distance = distance;
//    }
//    public string Famile { get { return famile; } }
//    public double[] Estimate { get { return estimate; }   set { estimate = value; } }
//    public int Distance { get { return distance; } }
//}

//class Program
//{
//    static void Main(string[] args)
//    {
//        double rez = 0;
//        double amax = 0;
//        int imax = 0;
//        Jump[] jump = new Jump[5];
//        jump[0] = new Jump("John", new double[5] { 10.0, 20.0, 10.0, 20.0, 10.0 }, 122);
//        jump[1] = new Jump("Stiven", new double[5] { 15.0, 25.0, 20.0, 10.0, 10.0 }, 130);
//        jump[2] = new Jump("Tomas", new double[5] { 12.0, 22.0, 16.0, 27.0, 13.0 }, 119);
//        jump[3] = new Jump("Alexander", new double[5] { 16.0, 26.0, 17.0, 28.0, 19.0 }, 90);
//        jump[4] = new Jump("Vaska", new double[5] { 19.0, 21.0, 16.0, 20.0, 20.0 }, 105);
//        for (int b = 0; b < jump.Length; b++)
//        {
//            for (int i = 0; i < jump[b].Estimate.Length - 1; i++)
//            {
//                amax = jump[b].Estimate[i];
//                imax = i;
//                for (int j = i + 1; j < jump[b].Estimate.Length; j++)
//                {
//                    if (amax < jump[b].Estimate[j])
//                    {
//                        amax = jump[b].Estimate[j];
//                        imax = j;
//                    }
//                }
//                double temp;
//                temp = jump[b].Estimate[imax];
//                jump[b].Estimate[imax] = jump[b].Estimate[i];
//                jump[b].Estimate[i] = temp;
//            }
//        }
//        for (int b = 0; b < jump.Length; b++)
//        {
//            for (int i = 0; i < jump[b].Estimate.Length; i++)
//            {
//                rez += jump[b].Estimate[i];
//            }
//            rez -= (jump[b].Estimate[imax]);
//        }

//        for (int b = 0; b < jump.Length; b++)
//        {
//            for (int i = 0; i < jump[b].Estimate.Length; i++)
//            {
//                Console.WriteLine(rez);
//            }
//        }
//    }
//}


// n2 / Main
//struct Jump
//{
//    private string famile;
//    private double[] estimate;
//    private int distance;
//    private double rez;
//    private double amax;
//    private int imax;
//    public Jump(string famile, double[] estimate, int distance)
//    {
//        this.famile = famile;
//        this.estimate = estimate;
//        this.distance = distance;
//        rez = 0;
//        amax = imax = 0;
//        for (int i = 0; i < estimate.Length-1; i++)
//        {
//            amax = estimate[i];
//            imax = i;
//            for (int j = i + 1; j < estimate.Length; j++)
//            {
//                if (amax < estimate[j])
//                {
//                    amax = estimate[j];
//                    imax = j;
//                }
//            }
//            double temp;
//            temp = estimate[imax];
//            estimate[imax] = estimate[i];
//            estimate[i] = temp;
//        }
//        for (int i = 0; i < estimate.Length; i++)
//        {
//            rez += estimate[i];
//        }
//        rez -= (estimate[0] + estimate[4]);
//        if (distance >= 120)
//        {
//            rez += (distance - 120) * 2;
//        }
//        else if (distance < 120)
//        {
//            rez -= (120 - distance) * 2;
//        }
//    }
//    public string Famile { get { return famile; } }
//    public double[] Estimate { get { return estimate; } set { estimate = value; } }
//    public int Distance { get { return distance; } }

//    public double Rez { get { return rez; } }
//}

//class Program
//{
//    static void Main(string[] args)
//    {
//        Jump[] jump = new Jump[5];
//        jump[0] = new Jump("John", new double[5] { 10.0, 20.0, 10.0, 20.0, 10.0 }, 122);
//        jump[1] = new Jump("Stiven", new double[5] { 15.0, 25.0, 20.0, 10.0, 10.0 }, 130);
//        jump[2] = new Jump("Tomas", new double[5] { 12.0, 22.0, 16.0, 27.0, 13.0 }, 119);
//        jump[3] = new Jump("Alexander", new double[5] { 16.0, 26.0, 17.0, 28.0, 19.0 }, 90);
//        jump[4] = new Jump("Vaska", new double[5] { 19.0, 21.0, 16.0, 20.0, 20.0 }, 105);
//        for (int i = 0; i < jump.Length - 1; i++)
//        {
//            double amax = jump[i].Rez;
//            int imax = i;
//            for (int j = i + 1; j < jump.Length; j++)
//            {
//                if (amax < jump[j].Rez)
//                {
//                    amax = jump[j].Rez;
//                    imax = j;
//                } 
//            }
//            Jump temp;
//            temp = jump[imax];
//            jump[imax] = jump[i];
//            jump[i] = temp;
//        }


//        for (int i = 0; i < jump.Length; i++)
//        {
//            Console.WriteLine(jump[i].Famile + " " + jump[i].Rez);
//        }
//    }
//}

// n3 / 1
//Обработать результаты первенства по футболу. Результаты каждой игры заданы в виде названий команд и счета (количество забитых
//и пропущенных мячей). Сформировать таблицу очков (выигрыш – 3, //ничья – 1, проигрыш – 0) и упорядочить результаты в соответствии с
//занятым местом. Если сумма очков у двух команд одинакова, то сравниваются разности забитых и пропущенных мячей. Вывести результирующую таблицу, содержащую место, название команды,
//количество очков.

//class FootballTeam
//{
//    private string name;
//    private int goalsScored;
//    private int goalsConceded;
//    private int points;

//    public FootballTeam(string name)
//    {
//        this.name = name;
//    }

//    public string Name
//    {
//        get { return name; }
//        set { name = value; }
//    }

//    public void Result(int scored, int conceded)
//    {
//        goalsScored += scored;
//        goalsConceded += conceded;

//        if (scored > conceded)
//            points += 3;
//        else if (scored == conceded)
//            points += 1;
//    }


//    public int Points
//    {
//        get { return points; }
//    }

//    public int RAZNICA
//    {
//        get { return goalsScored - goalsConceded; }
//    }
//}


//class Program
//{
//    static void Main(string[] args)
//    {

//        FootballTeam[] teams = new FootballTeam[]
//        {
//        new FootballTeam("ЦСКА"),
//        new FootballTeam("Динама"),
//        new FootballTeam("Спартак"),
//        new FootballTeam("Монгол")
//        };

//        Match(teams[0], teams[1]);
//        Match(teams[0], teams[2]);
//        Match(teams[0], teams[3]);


//        Match(teams[1], teams[0]);
//        Match(teams[1], teams[2]);
//        Match(teams[1], teams[3]);

//        SORT(teams);

//        Console.WriteLine("Место | Команда | Очки");
//        Console.WriteLine("-------------------------");
//        for (int i = 0; i < teams.Length; i++)
//        {
//            Console.WriteLine("{0,5} | {1,-7} | {2}", i + 1, teams[i].Name, teams[i].Points);
//        }
//    }

//    static void Match(FootballTeam team1, FootballTeam team2)
//    {
//        Random random = new Random();
//        int scored = random.Next(0, 5);
//        int conceded = random.Next(0, 5);
//        team1.Result(scored, conceded);
//        team2.Result(conceded, scored);
//    }

//    static void SORT(FootballTeam[] teams)
//    {
//        int n = teams.Length;
//        for (int i = 0; i < n - 1; i++)
//        {
//            for (int j = 0; j < n - i - 1; j++)
//            {
//                if (teams[j].Points < teams[j + 1].Points ||
//                    (teams[j].Points == teams[j + 1].Points && teams[j].RAZNICA < teams[j + 1].RAZNICA))
//                {

//                    FootballTeam temp = teams[j];
//                    teams[j] = teams[j + 1];
//                    teams[j + 1] = temp;
//                }
//            }
//        }
//    }
//}


class Football
{
    private string famile;
    private int pos_goal;
    private int con_goal;
    private int score;
    public Football(string famile)
    {
        this.famile = famile;
    }

    public string Famile { get { return famile; } }

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
}

class Program
{
    static void Main(string[] args)
    {
        Football[] football = new Football[4];
        football[0] = new Football("Динамо");
        football[1] = new Football("Краснодар");
        football[2] = new Football("Металлург");
        football[3] = new Football("Сочи");

        static void Match(Football football1, Football football2)
        {
            Random random = new Random();
            int scored = random.Next(0, 5);
            int conceded = random.Next(0, 5);
            football1.Result(scored, conceded);
            football2.Result(conceded, scored);
        }

        static void Sort(Football[] footbals)
        {
            for (int i = 0; i < footbals.Length - 1; i++)
            {
                for (int j = 0; j < footbals.Length - i - 1; j++)
                {
                    if (footbals[j].Score < footbals[j + 1].Score ||
                        (footbals[j].Score == footbals[j + 1].Score && footbals[j].Minus < footbals[j + 1].Minus))
                    {

                        Football temp = footbals[j];
                        footbals[j] = footbals[j + 1];
                        footbals[j + 1] = temp;
                    }
                }
            }
        }

        for (int i = 1; i < 4; i++)
        {
            Match(football[0], football[i]);
        }

        Match(football[1], football[0]);
        Match(football[1], football[2]);
        Match(football[1], football[3]);

        Sort(football);

        for (int i = 0; i < football.Length; i++)
        {
            Console.WriteLine(football[i].Famile + " " + football[i].Score);
        }
    }
}
