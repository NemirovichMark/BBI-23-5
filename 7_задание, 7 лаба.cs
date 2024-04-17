namespace _7_задание__7_лаба;

public abstract class person
{
    public string fio { get; private set; }
    public double scord { get; private set; }
    public person(string fio, double scord)
    {
        this.fio = fio;
        this.scord = scord;
    }
    public void person_info()
    {
        Console.WriteLine(fio + " " + scord);
    }
}

public class sportsman : person
{
    public int id { get; }
    private static Random random = new Random();
    private static int[] usedIds = new int[1];

    public sportsman(string fio, double score) : base(fio, score)
    {
        int newId;
        do
        {
            newId = random.Next(1, 100);
        }
        while (usedIds.Contains(newId));

        for (int i = 0; i < usedIds.Length; i++)
        {
            if (id != usedIds[i])
            {
                id = newId;
            }
            usedIds[i] = newId;
        }
    }
    public void sportsman_info()
    {
        Console.WriteLine(fio + " " + scord + " " + id);
    }
}

class Program
{
    public static void shell(person[] a)
    {
        int size = a.Length;
        for (int i = size / 2; i > 0; i /= 2)
        {
            for (int g = i; g < size; g++)
            {
                person box = a[g]; //создание дополнительной переменная для перемещения новых элекментов массива
                int h;
                for (h = g; h >= i && a[h - i].scord < box.scord; h -= i)
                {
                    a[h] = a[h - i];
                }
                a[h] = box;

            }
        }
    }
    static void Main(string[] args)
    {
        person[] list = { new sportsman("Сидоров", 1), new sportsman("Арбузов", 0), new sportsman("Зайцев", 1.5), new sportsman("Иванов", 0) };


        shell(list);
        list[0].person_info();
        foreach (var i in list)
        {
            if (i is sportsman sportsman)
            {
                sportsman.sportsman_info();
            }

        }
    }
}
