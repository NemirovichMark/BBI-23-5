//Составить программу для обработки результатов кросса на
//500 м для женщин. Для каждой участницы ввести фамилию, группу,
//фамилию преподавателя, результат. Получить результирующую та-
//блицу, упорядоченную по результатам, в которой содержится также
//информация о выполнении норматива. Определить суммарное коли-
//чество участниц, выполнивших норматив.

struct Sportsmen
{
    private string familiya;
    private int group;
    private string fam_prepod;
    private double rez;

    public Sportsmen(string s, int g, string h, double r)
    {
        familiya = s;
        group = g;
        fam_prepod = h;
        rez = r;
    }
    public double Rez
    {
        get { return rez; }

    }
    public void Print()
    {
        Console.WriteLine("Фамилия {0} \t Группа {1,4:d} \t Фамилия преподавателя: {2} \t Результат {3,4:f2}", familiya, group, fam_prepod, Rez);
    }
}



class Program
{
    static void Main(string[] arg)
    {
        Sportsmen[] sp = new Sportsmen[5];
        sp[0] = new Sportsmen("Иванова", 2, "Яворский", 565);
        sp[1] = new Sportsmen("Петрова", 1, "Аругнов", 453);
        sp[2] = new Sportsmen("Макарова", 3, "Сацик", 530);
        sp[3] = new Sportsmen("Семенова", 2, "Дидаев", 488);
        sp[4] = new Sportsmen("Смирнова", 2, "Федунь", 499);

        for (int i = 0; i < sp.Length; i++)
        {
            sp[i].Print();
        }
        Console.WriteLine();
        Sort(sp);
        for (int i = 0; i < sp.Length; i++)
        {
            sp[i].Print();
        }
    }
    static void Sort(Sportsmen[] uwu)
    {
        int index = 1;
        int indexNext = index + 1;
        while (index<uwu.Length)
        {
            if (uwu[index - 1].Rez < uwu[index].Rez)
            {
                index = indexNext;
                indexNext++;
            }
            else
            {
                Sportsmen temp = uwu[index - 1];
                uwu[index - 1] = uwu[index];
                uwu[index]=temp;
                index--;
                if (index == 0)
                {
                    index = indexNext;
                    indexNext++;
                }

            }
        }
    }
}