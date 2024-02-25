using System;
//Результаты сессии содержат оценки 5 экзаменов по каждой группе.
//Определить средний балл для трех групп студентов одного потока и выдать список групп в порядке убывания среднего балла.
//Результаты вывести в виде таблицы с заголовком. 


struct StudentGroup
{
    private string _GroupName;
    public string GroupName1 => _GroupName;
    private double[] _ExamResults;
    private double _SrRez;
    public double SrRez1 => _SrRez;

    // Конструктор с вычислением среднего балла сразу
    public StudentGroup(string groupName, double[] examResults)
    {
        _GroupName = groupName;
        _ExamResults = examResults;
        _SrRez = 0;
        for (int i = 0; i < 5; i++)
        {
            _SrRez += _ExamResults[i];

        }
        _SrRez /= 5;
        _SrRez = Math.Round(_SrRez, 2);
    }
    public void Print()
    {
        Console.WriteLine(_GroupName + "| " + _SrRez);
    }

}

class Program
{
    static void Main()
    {
        //сортировка выбором
        static void SelectionSort(StudentGroup[] Array)
        {
            for (int i = 0; i < Array.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < Array.Length; j++)
                {
                    if (Array[j].SrRez1 > Array[min].SrRez1)
                    {
                        min = j;
                    }
                }
                StudentGroup m = Array[i];
                Array[i] = Array[min];
                Array[min] = m;
                min = i;
            }
        }

        StudentGroup[] groups = new StudentGroup[]
        {
            new StudentGroup("1 group", new double[] { 4, 5, 4, 3, 5 }),
            new StudentGroup("2 group", new double[] { 4, 3, 5, 4, 4 }),
            new StudentGroup("3 group", new double[] { 5, 4, 4, 3, 3 })
        };

        SelectionSort(groups);
        Console.WriteLine("Результаты сессии:");
        Console.WriteLine("-----------------------");
        Console.WriteLine("Группа" + "  " + "Средний балл");
        Console.WriteLine("-----------------------");
        foreach (StudentGroup gr in groups)
        {
            gr.Print();
        }

    }
}


