using System;

struct Students
{
    private string _famile;
    private int _mark;
    private int _kolpropusk;
    public int Mark => _mark;
    public int Kolpropusk => _kolpropusk;

    public Students(string famile, int mark, int kolpropusk)
    {
        _famile = famile;
        _mark = mark;
        _kolpropusk = kolpropusk;
    }
    public void Print()
    {
        Console.WriteLine("Фамилия   {0}\t Оценка {1}\t Пропуски {2}",
                        _famile, _mark, _kolpropusk);
    }
    class Program
    {
        static void Main()
        {
            Students[] c1 = new Students[]
            {
            new Students("Иванов", 2, 10),
            new Students("Петров", 3, 2),
            new Students("Кузнецов", 2, 13),
            new Students("Аксенова", 5, 0),
            new Students("Кузнецова", 2, 9)
            };
            foreach (Students student in c1)
            {
                student.Print();
            }
            FindProgul(c1);
        }
        //Упорядочение по результатам
        static void FindProgul(Students[] c1)
        {
            for (int i = 0; i < c1.Length - 1; i++)
            {
                double amax = c1[i].Kolpropusk;
                int imax = i;
                for (int j = i + 1; j < c1.Length; j++)
                {
                    if (c1[j].Kolpropusk > amax)
                    {
                        amax = c1[j].Kolpropusk;
                        imax = j;
                    }
                }
                Students temp;
                temp = c1[imax];
                c1[imax] = c1[i];
                c1[i] = temp;
            }
            Console.WriteLine();
            for (int i = 0; i < c1.Length; i++)
            {
                if (c1[i].Mark == 2)
                    c1[i].Print();
            }
        }
    }

}
