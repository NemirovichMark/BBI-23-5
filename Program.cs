//Соревнования по прыжкам в воду оценивают 7 судей.Каждый спортсмен выполняет 4 прыжка
//Каждый прыжок имеет одну из шести категорий сложности, оцениваемую коэффициентом (от 2,5 до 3,5)
//Качество прыжка оценивается судьями по 6-балльной шкале. Далее лучшая и худшая оценки отбрасываются,
//остальные складываются, и сумма умножается на коэффициент сложности.
//Получить итоговую таблицу, содержащую фамилии спортсменов, и итоговую оценку (сумму оценок по 4 прыжкам) в порядке занятых мест. 
using System;

struct Diver
{

    private string _LastName;
    public string LastName => _LastName;


    private double[] _DiveDifficultyCoefficients;
    public double[] DiveDifficultyCoefficients => _DiveDifficultyCoefficients;

    private double _FinalScore;
    public double FinalScore => _FinalScore;


    public Diver(string lastName, double[] diveDifficultyCoefficients)
    {
        _LastName = lastName;
        _DiveDifficultyCoefficients = diveDifficultyCoefficients;
        CalculateTotalScore(); // Вызов метода для расчета итоговой оценки при создании объекта
    }

    private static void ShellSort(double[] array)
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

    // Вот этот метод для вычисления итоговой оценки спортсмена
    private void CalculateTotalScore()
    {
        double totalScore = 0;
        Random rnd = new Random();

        for (int j = 0; j < DiveDifficultyCoefficients.Length; j++)
        {
            double[] judgeScores = new double[7];
            for (int i = 0; i < 7; i++)
            {
                judgeScores[i] = rnd.NextDouble() * 5.0 + 1.0; //оценки судей я не вводила, они просто сгенерируются от 1 до 6
            }
            ShellSort(judgeScores);
            double jumpScore = 0;
            for (int i = 1; i < 6; i++)
            {
                jumpScore += judgeScores[i];
            }

            totalScore += jumpScore * DiveDifficultyCoefficients[j];
        }

        _FinalScore = Math.Round(totalScore, 2); 
    }
}

class Program
{
    static void Main()
    {
        //сортировка выбором
        static void SelectionSort(Diver[] Array)
        {
            for (int i = 0; i < Array.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < Array.Length; j++)
                {
                    if (Array[j].FinalScore > Array[min].FinalScore)
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

        Diver[] divers = new Diver[]
        {
            new Diver("Иванов",new double []{2.5, 2.7, 2.5, 3.0}),
            new Diver("Петров",new double []{3.4, 2.7, 3.2, 3.5}),
            new Diver("Ткачук",new double []{2.5, 2.5, 3.2, 3.2}),
            new Diver("Фролов",new double []{2.5, 2.7, 2.5, 3.0}),
            new Diver("Семенов",new double []{2.5, 2.7, 3.5, 3.2}),
            new Diver("Белых",new double []{3.4, 3.2, 3.2, 3.5}),
            new Diver("Жучков",new double []{2.5, 2.5, 2.5, 3.0}),
            new Diver("Громких",new double []{3.4, 3.0, 3.0, 3.5}),
            new Diver("Игнатьев",new double []{2.5, 2.7, 3.2, 3.2})
        };
        SelectionSort(divers);


        Console.WriteLine("Место\tФамилия спортсмена\tИтоговая оценка");
        int place = 1;
        foreach (var diver in divers)
        {
            Console.WriteLine($"{place}\t{diver.LastName}\t\t\t{diver.FinalScore}");
            place++;
        }
    }
}
