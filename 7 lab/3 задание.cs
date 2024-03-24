using System;

public class Group
{
    protected string[] coreSubjects = { "Математика", "Русский", "Физкультура" };
    protected double[,] examScores; // Массив оценок для каждого ученика и предмета
    protected string[] Subjects;

    public Group(int numStudents, int numSubjects)
    {

        examScores = new double[numStudents, numSubjects];
    }

    public virtual void DisplayGroupInfo()
    {
        for (int i = 0; i < examScores.GetLength(0); i++)
        {
            Console.WriteLine($"\nСтудент {i + 1}, {GetType().Name}:");
            for (int j = 0; j < examScores.GetLength(1); j++)
            {
                Console.WriteLine($"Предмет: {Subjects[j]}, Оценка: {examScores[i, j]}");
            }
        }

        Console.WriteLine($"\nСредний балл по предметам в группе {GetType().Name}:");
        for (int i = 0; i < Subjects.Length; i++)
        {
            double subjectSum = 0;
            for (int j = 0; j < examScores.GetLength(0); j++)
            {
                subjectSum += examScores[j, i];
            }
            double subjectAverage = subjectSum / examScores.GetLength(0);
            Console.WriteLine($"Предмет: {Subjects[i]}, Средний балл: {subjectAverage}");
        }
    }

    public double CalculateGroupAverage()
    {
        double groupSum = 0;
        for (int i = 0; i < Subjects.Length; i++)
        {
            double subjectSum = 0;
            for (int j = 0; j < examScores.GetLength(0); j++)
            {
                subjectSum += examScores[j, i];
            }
            double subjectAverage = subjectSum / examScores.GetLength(0);
            groupSum += subjectAverage;
        }
        return groupSum / Subjects.Length;
    }

    public void InitializeSubjects(string[] additionalSubjects)
    {
        Subjects = new string[coreSubjects.Length + additionalSubjects.Length];

        for (int i = 0; i < coreSubjects.Length; i++)
        {
            Subjects[i] = coreSubjects[i];
        }

        for (int i = 0; i < additionalSubjects.Length; i++)
        {
            Subjects[i + coreSubjects.Length] = additionalSubjects[i];
        }
    }

}

public class PhysMathGroup : Group
{
    public PhysMathGroup() : base(5, 5) // Физмат добавляет 2 дополнительных предмета
    {
        string[] additionalSubjects = { "Черчение", "Геометрия" };
        InitializeSubjects(additionalSubjects);


        for (int i = 0; i < examScores.GetLength(0); i++)
        {
            Console.WriteLine($"\nВведите оценки для студента {i + 1} группы Физмат:");
            for (int j = 0; j < examScores.GetLength(1); j++)
            {
                Console.Write($"Оценка {Subjects[j]}: ");

                examScores[i, j] = Convert.ToDouble(Console.ReadLine());
            }
        }
    }
}

public class ChemBioGroup : Group
{
    public ChemBioGroup() : base(5, 5) // Химбио добавляет 2 дополнительных предмета
    {
        string[] additionalSubjects = { "Биология", "Экология" };

        InitializeSubjects(additionalSubjects);


        for (int i = 0; i < examScores.GetLength(0); i++)
        {
            Console.WriteLine($"\nВведите оценки для студента {i + 1} группы Химбио:");
            for (int j = 0; j < examScores.GetLength(1); j++)
            {
                Console.Write($"Оценка {Subjects[j]}: ");
                examScores[i, j] = Convert.ToDouble(Console.ReadLine());
            }
        }
    }
}

public class HumanitiesGroup : Group
{
    public HumanitiesGroup() : base(5, 5) // Гуманитарии добавляют 2 дополнительных предмета
    {
        string[] additionalSubjects = { "Литература", "Чтение" };

        InitializeSubjects(additionalSubjects);


        for (int i = 0; i < examScores.GetLength(0); i++)
        {
            Console.WriteLine($"\nВведите оценки для студента {i + 1} группы Гуманитарий:");
            for (int j = 0; j < examScores.GetLength(1); j++)
            {
                Console.Write($"Оценка {Subjects[j]}: ");
                examScores[i, j] = Convert.ToDouble(Console.ReadLine());
            }
        }
    }
}


class Program
{
    static void Main()
    {
        const int groupSize = 3;

        Group[] groups = new Group[groupSize];
        groups[0] = new PhysMathGroup();
        groups[1] = new ChemBioGroup();
        groups[2] = new HumanitiesGroup();

        // Вычисляем и выводим средний балл по каждой группе
        Console.WriteLine("\nСредний балл по группам:");
        double[] groupAverages = new double[groupSize];
        // Создаем массив пар (средний балл, индекс группы)
        var averageIndexPairs = new (double, int)[groupSize];

        for (int i = 0; i < groupSize; i++)
        {
            groupAverages[i] = groups[i].CalculateGroupAverage();
            // Заполняем массив пар
            averageIndexPairs[i] = (groupAverages[i], i);
        }

        // Сортировка массива пар методом пузырька
        for (int i = 0; i < groupSize - 1; i++)
        {
            for (int j = 0; j < groupSize - 1 - i; j++)
            {
                if (averageIndexPairs[j].Item1 < averageIndexPairs[j + 1].Item1)
                {
                    // Перестановка элементов
                    var temp = averageIndexPairs[j];
                    averageIndexPairs[j] = averageIndexPairs[j + 1];
                    averageIndexPairs[j + 1] = temp;
                }
            }
        }

        // Выводим средний балл группы в порядке убывания
        foreach (var pair in averageIndexPairs)
        {
            Console.WriteLine($"Средний балл группы {groups[pair.Item2].GetType().Name}: {pair.Item1}");
        }



        // Вывод информации о группах и среднем балле
        Console.WriteLine("\nИнформация о группах и средний балл по предметам:");
        foreach (var group in groups)
        {
            group.DisplayGroupInfo();
        }
    }
}
