using System;
using System.Xml.Linq;
class Participant
{
    public string Surname {get; private set;}
    public string Group { get; private set; }
    public string Surname_teacher { get; private set; }
    public double Result { get; private set; }

    public Participant (string surname, string group, string surname_teacher, double result)
    {
        Surname = surname;
        Group = group;
        Surname_teacher = surname_teacher;
        Result = result;
    }

    public bool Normative()
    {
        return Result < 50;
    }
        public void Print()
    {

        Console.WriteLine(Surname + " , " + Group + " , " + Surname_teacher + " , " + Result);
    }
}
class Program
{
    static void Main()
    {
        Console.WriteLine("Введите данные кросса на 500 метров для женщин: ");

        Console.Write("Введите количество участниц: ");
        int count_participant = int.Parse(Console.ReadLine());

        Participant[] cross = new Participant[count_participant];

        for (int i = 0; i < count_participant; i++)
        {
            Console.Write($"Фамилия {i+1}-ой участницы: ");
            string surname = Console.ReadLine();

            Console.Write($"Группа {i+1}-ой участниц: ");
            string group = Console.ReadLine();

            Console.Write($"Фамилия учителя {i+1}-ой участниц: ");
            string surname_teacher = Console.ReadLine();

            Console.Write($"Результат {i+1}-ой участниц: ");
            double result = double.Parse(Console.ReadLine());

            cross[i] = new Participant(surname, group, surname_teacher, result);
        }
        Sort(cross);
        int normative_count = 0;
        foreach (Participant runner in cross )
        {
            runner.Print();
            
            if(runner.Normative())
            {
                normative_count++;
            }

        }
        Console.WriteLine($"Суммарное количество участниц, выполнивших норматив: {normative_count}");



    }
    static void Sort(Participant[] cross)
    {
        int i = 0, j = 1;
        while (j < cross.Length - 1)
        {
            if (i < 0 || cross[i].Result >= cross[i + 1].Result)
            {
                i = j;
                j++;
            }
            while (i >= 0 && cross[i].Result > cross[i + 1].Result)
            {
                Participant temp = cross[i];
                cross[i] = cross[i + 1];
                cross[i + 1] = temp;
                i--;
                
            }
        }
    }
}

