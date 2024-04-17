namespace _7_задание__7_лаба;

public abstract class person
{
    public string fio { get; set; }
    public double scord { get; set; }
    public person(string fio, double scord)
    {
        this.fio = fio;
        this.scord = scord;
    }
}

public class sportsman : person
{
    public int id { get; set; }

    public sportsman(string fio, double scord, int id) : base (fio, scord)
    {
        this.id = id;
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
        person[] list = { new sportsman("Сидоров", 1, 1), new sportsman("Арбузов", 0, 2), new sportsman("Зайцев", 1.5, 3), new sportsman("Иванов", 0, 4) };


        shell(list);
        foreach (var i in list)
        {
            if (i is sportsman sportsman)
            Console.WriteLine($"ФИО: {sportsman.fio}, Результат: {sportsman.scord}, ИД: {sportsman.id} ");

        }
    }
}