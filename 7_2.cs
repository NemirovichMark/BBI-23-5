//Сделать абстрактный класс «Прыжки в воду» с обязательным полем «Название дисциплины», и от него наследников: «с 3м» и «с 5м».
//В каждом из классов переопределить название дисциплины (и выводить в начале таблицы).
public class Diver
{
    private string _lastname;
    public string LastName => _lastname;

    private Jump[] _jumps;
    public Jump[] Jumps => _jumps;

    private double _totalscore;
    public double TotalScore => _totalscore;

    public Diver(string lastName, Jump[] jumps)
    {
        _lastname = lastName;
        _jumps = jumps;

        //Сразу же делаем так, что бы спортсмен при создании прыгал несколько раз
        foreach (var jump in Jumps)
            jump.Evaluate();

        CalculateTotalScore();
    }

    public double CalculateTotalScore()
    {
        foreach (var jump in Jumps)
            _totalscore += jump.TotalScore;

        _totalscore = Math.Round(TotalScore, 2);

        return TotalScore;
    }
}
public class Jump
{
    private double _rate;
    public double Rate => _rate;

    private double[] Scores = new double[7];

    private double _totalscore;
    public double TotalScore => _totalscore;

    //Конструктор, который создаёт прыжок и автоматически назначает ему коэф.
    public Jump()
    {
        var random = new Random().Next(25, 36);
        _rate = (double)random / (double)10;
    }

    //Конструктор, который создаёт прыжок и куда подаётся коэф.
    public Jump(double rate)
    {
        _rate = rate;
    }

    //Результаты прыжка
    public void Evaluate()
    {
        for (int i = 0; i < 7; i++)
        {
            Scores[i] = new Random().Next(100, 601) / 100;
        }


        _shellSort(Scores);

        //Обнуление самой лучшей и худшей оценки
        Scores[0] = 0;
        Scores[6] = 0;

        double tempScore = 0;

        foreach (double score in Scores)
        {
            tempScore += score;
        }

        _totalscore = tempScore * Rate;

    }

    private static void _shellSort(double[] array)
    {
        int n = array.Length;
        int gap = n / 2;

        while (gap > 0)
        {
            for (int i = gap; i < n; i++)
            {
                double temp = array[i];
                int j;
                for (j = i; j >= gap && array[j - gap] < temp; j -= gap)
                {
                    array[j] = array[j - gap];
                }
                array[j] = temp;
            }
            gap /= 2;
        }
    }
}
public abstract class WaterJumps
{
    public abstract string DisciplineName { get; set; }

    protected Diver[] Divers;

    public void Start()
    {
        _selectionSort(Divers);

        Console.WriteLine("Тип: " + DisciplineName);
        Console.WriteLine("Место\tФамилия спортсмена\tИтоговая оценка");
        int place = 1;
        foreach (var diver in Divers)
        {
            Console.WriteLine($"{place}\t{diver.LastName}\t\t\t{diver.TotalScore}");
            place++;
        }
    }


    private void _selectionSort(Diver[] Array)
    {
        for (int i = 0; i < Array.Length - 1; i++)
        {
            int min = i;
            for (int j = i + 1; j < Array.Length; j++)
            {
                if (Array[j].TotalScore > Array[min].TotalScore)
                {
                    min = j;
                }
            }
            Diver d = Array[i];
            Array[i] = Array[min];
            Array[min] = d;
            min = i;
        }
    }
}
internal class WaterJumps3m : WaterJumps
{
    public override string DisciplineName { get; set; }

    public WaterJumps3m(Diver[] divers)
    {
        DisciplineName = "Прыжки 3 метра";
        Divers = divers;
    }
}
internal class WaterJumps5m : WaterJumps
{
    public override string DisciplineName { get; set; }

    public WaterJumps5m(Diver[] divers)
    {
        DisciplineName = "Прыжки 5 метров";
        Divers = divers;
    }
}
class Program
{
    static void Main()
    {
        Diver[] divers = new Diver[]
        {
            new Diver("Иванов", new Jump[]{new Jump(), new Jump(), new Jump(), new Jump()}),
            new Diver("Петров", new Jump[]{new Jump(), new Jump(), new Jump(), new Jump()}),
            new Diver("Ткачук", new Jump[]{new Jump(), new Jump(), new Jump(), new Jump()}),
            new Diver("Фролов", new Jump[]{new Jump(), new Jump(), new Jump(), new Jump()}),
            new Diver("Семенов", new Jump[]{new Jump(), new Jump(), new Jump(), new Jump()}),
            new Diver("Белых", new Jump[]{new Jump(), new Jump(), new Jump(), new Jump()}),
            new Diver("Жучков", new Jump[]{new Jump(), new Jump(), new Jump(), new Jump()}),
            new Diver("Громких", new Jump[]{new Jump(), new Jump(), new Jump(), new Jump()}),
            new Diver("Игнатьев", new Jump[]{new Jump(), new Jump(), new Jump(), new Jump()})
        };

        //Демонстрация работы класса 3 метровых прыжков
        WaterJumps WaterJumps3m = new WaterJumps3m(divers);
        WaterJumps3m.Start();

        Diver[] divers2 = new Diver[]
{
            new Diver("Иванов", new Jump[]{new Jump(), new Jump(), new Jump(), new Jump()}),
            new Diver("Петров", new Jump[]{new Jump(), new Jump(), new Jump(), new Jump()}),
            new Diver("Ткачук", new Jump[]{new Jump(), new Jump(), new Jump(), new Jump()}),
            new Diver("Фролов", new Jump[]{new Jump(), new Jump(), new Jump(), new Jump()}),
            new Diver("Семенов", new Jump[]{new Jump(), new Jump(), new Jump(), new Jump()}),
            new Diver("Белых", new Jump[]{new Jump(), new Jump(), new Jump(), new Jump()}),
            new Diver("Жучков", new Jump[]{new Jump(), new Jump(), new Jump(), new Jump()}),
            new Diver("Громких", new Jump[]{new Jump(), new Jump(), new Jump(), new Jump()}),
            new Diver("Игнатьев", new Jump[]{new Jump(), new Jump(), new Jump(), new Jump()})
};

        //Демонстрация работы класса 5 метровых прыжков
        WaterJumps WaterJumps5m = new WaterJumps5m(divers2);
        WaterJumps5m.Start();
    }
}