using System;

class Program
{
    struct Students
    {
        private string _famile;
        private double[] _subjects;
        private double _sred;
        public double[] Subjects => _subjects;
        public double Sred => _sred;
        public Students(string famile, double[] subjects)
        {
            _famile = famile;
            _subjects = subjects;
            _sred = 0;
            for (int i = 0; i < 3; i++)
            {
                _sred += subjects[i];
            }
            _sred = _sred / 3;
        }
        public void Print()
        {
            Console.WriteLine("Фамилия   {0}\t Средний балл {1:f2}\t",
                            _famile, _sred);
        }
    }
    static void Main()
    {
        Students[] c1 = new Students[5];
        c1[0] = new Students("Иванов", new double[] { 3, 3, 3 });
        c1[1] = new Students("Петров", new double[] { 5, 5, 5 });
        c1[2] = new Students("Купцов", new double[] { 3, 4, 2 });
        c1[3] = new Students("Аксенова", new double[] { 3, 4, 3 });
        c1[4] = new Students("Кузнецов", new double[] { 2, 2, 2 });
        foreach (Students student in c1)
        {
            student.Print();
        }
        Sorted(c1);
    }
        static void Sorted(Students[]c1)
        {
            for (int i = 0; i < c1.Length - 1; i++)
            {
                double amax = c1[i].Sred;
                int imax = i;
                for (int j = i + 1; j < c1.Length; j++)
                {
                    if (c1[j].Sred > amax)
                    {
                        amax = c1[j].Sred;
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
                if ((c1[i].Subjects[0] != 2) & (c1[i].Subjects[1] != 2) & (c1[i].Subjects[2] != 2))
                {
                    c1[i].Print();
                }
            }
        }
           
}