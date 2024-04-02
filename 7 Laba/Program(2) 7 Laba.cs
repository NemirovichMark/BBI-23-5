using System;

abstract class Diving
{
    protected string disciplineName;
    protected Sportsman[] sportsmen;

    public Diving(string disciplineName, Sportsman[] sportsmen)
    {
        this.disciplineName = disciplineName;
        this.sportsmen = sportsmen;
    }

    public abstract string GetDisciplineName();
    public abstract void DisplayParticipants();
}

class Diving3m : Diving
{
    public Diving3m(string disciplineName, Sportsman[] sportsmen) : base(disciplineName, sportsmen) { }

    public override string GetDisciplineName()
    {
        return "Дисциплина 3м: " + disciplineName;
    }

    public override void DisplayParticipants()
    {
        Console.WriteLine("Участники в дисциплине 3м:");
        foreach (var sportsman in sportsmen)
        {
            Console.WriteLine(sportsman);
        }
    }
}

class Diving5m : Diving
{
    public Diving5m(string disciplineName, Sportsman[] sportsmen) : base(disciplineName, sportsmen) { }

    public override string GetDisciplineName()
    {
        return "Дисциплина 5м: " + disciplineName;
    }

    public override void DisplayParticipants()
    {
        Console.WriteLine("Участники в дисциплине 5м:");
        foreach (var sportsman in sportsmen)
        {
            Console.WriteLine(sportsman);
        }
    }
}

class Sportsman
{
    private string lastName;
    private float[] jumpDifficulties;
    private float[] jumpScores;
    public float totalScore { get; private set; }

    public Sportsman(string lastName, float[] jumpDifficulties, float[] jumpScores)
    {
        this.lastName = lastName;
        this.jumpDifficulties = jumpDifficulties;
        this.jumpScores = jumpScores;
        this.totalScore = 0;

        for (int j = 1; j < this.jumpScores.Length - 1; j++)
        {
            for (int k = j + 1; k < this.jumpScores.Length; k++)
            {
                if (this.jumpScores[j] < this.jumpScores[k])
                {
                    float temp = this.jumpScores[j];
                    this.jumpScores[j] = this.jumpScores[k];
                    this.jumpScores[k] = temp;
                }
            }
        }

        for (int j = 1; j < this.jumpScores.Length - 1; j++)
        {
            this.totalScore += this.jumpScores[j];
        }

        this.totalScore *= this.jumpDifficulties[0];
    }

    public override string ToString()
    {
        return string.Format("Спортсмен - {0}: итоговая оценка - {1}", this.lastName, this.totalScore);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Sportsman[] sportsmen = new Sportsman[5];

        sportsmen[0] = new Sportsman("Иванов", new float[] { 3.0f, 2.5f, 3.5f, 3.0f }, new float[] { 5.0f, 5.5f, 6.0f, 4.5f });
        sportsmen[1] = new Sportsman("Петров", new float[] { 2.5f, 3.0f, 2.5f, 3.0f }, new float[] { 6.0f, 5.5f, 6.5f, 5.0f });
        sportsmen[2] = new Sportsman("Сидоров", new float[] { 3.5f, 3.0f, 3.0f, 3.5f }, new float[] { 5.5f, 6.0f, 5.5f, 6.0f });
        sportsmen[3] = new Sportsman("Козлов", new float[] { 2.5f, 2.5f, 3.0f, 2.5f }, new float[] { 5.0f, 5.0f, 5.0f, 5.0f });
        sportsmen[4] = new Sportsman("Смирнов", new float[] { 3.0f, 2.5f, 2.5f, 3.5f }, new float[] { 4.5f, 4.5f, 5.0f, 4.5f });

        Diving diving3m = new Diving3m("Прыжки с трамплина", sportsmen);
        Diving diving5m = new Diving5m("Прыжки с вышки", sportsmen);

        Console.WriteLine(diving3m.GetDisciplineName());
        diving3m.DisplayParticipants();

        Console.WriteLine();

        Console.WriteLine(diving5m.GetDisciplineName());
        diving5m.DisplayParticipants();
    }
}
