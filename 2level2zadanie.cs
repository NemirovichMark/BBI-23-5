using System;

class Program
{
    struct Students
    {
        private string _lastName;
        private double[] _subjects;
        private double _average;
        public double[] Subjects => _subjects;
        public double Average => _average;
        public Students(string lastName, double[] subjects)
        {
            _lastName = lastName;
            _subjects = subjects;
            _average = 0;
            for (int i = 0; i < 3; i++)
            {
                _average += subjects[i];
            }
            _average = _average / 3;
        }
        public void Print()
        {
            Console.WriteLine("фамилия   {0}\t ср балл {1:f2}\t",
                            _lastName, _average);
        }
    }
    static void Main()
    {
        Students[] studentsArray = new Students[5];
        studentsArray[0] = new Students("макаров", new double[] { 3, 3, 3 });
        studentsArray[1] = new Students("кузнецов", new double[] { 5, 5, 5 });
        studentsArray[2] = new Students("иванов", new double[] { 3, 4, 2 });
        studentsArray[3] = new Students("петров", new double[] { 3, 4, 3 });
        studentsArray[4] = new Students("дмитриади", new double[] { 2, 2, 2 });
        foreach (Students student in studentsArray)
        {
            student.Print();
        }
        Sorted(studentsArray);
    }
    static void Sorted(Students[] studentsArray)
    {
        for (int i = 0; i < studentsArray.Length - 1; i++)
        {
            double maxAverage = studentsArray[i].Average;
            int maxIndex = i;
            for (int j = i + 1; j < studentsArray.Length; j++)
            {
                if (studentsArray[j].Average > maxAverage)
                {
                    maxAverage = studentsArray[j].Average;
                    maxIndex = j;
                }
            }
            Students temp;
            temp = studentsArray[maxIndex];
            studentsArray[maxIndex] = studentsArray[i];
            studentsArray[i] = temp;
        }
        Console.WriteLine();
        Console.WriteLine("умные");
        Console.WriteLine();
        for (int i = 0; i < studentsArray.Length; i++)
        {
            if ((studentsArray[i].Subjects[0] != 2) & (studentsArray[i].Subjects[1] != 2) & (studentsArray[i].Subjects[2] != 2))
            {
                studentsArray[i].Print();
            }
        }
    }

}
