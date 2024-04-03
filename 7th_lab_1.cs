using System.Xml.Linq;

abstract class Answer
{
    protected string famile;
    protected double count;
    protected double percent;
    protected double summ;
    public Answer(string famile, double count, double summ)
    {
        this.famile = famile;
        this.count = count;
        this.summ = summ;
        percent = (count / summ) * 100;
    }

    public double Count { get { return count; } }

    public abstract void Get_Percent();
}

class PersonYear : Answer
{
    public PersonYear(string famile, double count, double summ) : base(famile, count, summ)
    {

    }
    public override void Get_Percent()
    {
        Console.WriteLine($"Личность: {famile}, Процент: {percent}");
    }
}

class DiscoveryYear : Answer
{
    public DiscoveryYear(string famile, double count, double summ) : base(famile, count, summ)
    {

    }

    public override void Get_Percent()
    {
        Console.WriteLine($"Открытие года : {famile}, Процент: {percent}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        PersonYear[] persons = new PersonYear[3];
        persons[0] = new PersonYear("James", 10, 61);
        persons[1] = new PersonYear("Pedro", 9, 61);
        persons[2] = new PersonYear("Bogdan", 2, 61);

        DiscoveryYear[] discoveries = new DiscoveryYear[]
{
                    new DiscoveryYear("Квантовые технологии", 15, 30),
                    new DiscoveryYear("Атом", 5, 30),
                    new DiscoveryYear("Плазменный телевизор", 10, 30)
};


        for (int i = 0; i < persons.Length - 1; i++)
        {
            double amax = persons[i].Count;
            int imax = i;
            for (int j = i + 1; j < persons.Length; j++)
            {
                if (amax < persons[j].Count)
                {
                    amax = persons[j].Count;
                    imax = j;
                }
            }
            PersonYear temp;
            temp = persons[imax];
            persons[imax] = persons[i];
            persons[i] = temp;
        }
        for (int i = 0; i < persons.Length; i++)
        {
            Console.WriteLine("Таблица Людей Года:");
            persons[i].Get_Percent();
        }


        for (int i = 0; i < discoveries.Length; i++)
        {
            double amax = discoveries[i].Count;
            int imax = i;
            for (int j = i + 1; j < discoveries.Length; j++)
            {
                if (amax < discoveries[j].Count)
                {
                    amax = discoveries[j].Count;
                    imax = j;
                }
            }
            DiscoveryYear temp = discoveries[imax];
            discoveries[imax] = discoveries[i];
            discoveries[i] = temp;
        }

        for (int i = 0; i < discoveries.Length; i++)
        {
            Console.WriteLine("\nТаблица Открытий Года:");
            discoveries[i].Get_Percent();
        }
    }
}
