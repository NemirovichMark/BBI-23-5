namespace _7task._9lab;

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
    public int id { get; private set; }
    private static Random random = new Random();
    private static List<int>usedIds = new List<int>();

    public sportsman(string fio, double scord) : base(fio, scord)
    {
        int newId;
        do
        {
            newId = random.Next(1, 100);
        }
        while (usedIds.Contains(newId));
        id = newId;
        usedIds.Add(newId);
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
        string path_file = "Chessplayers.json";
        if (File.Exists(path_file))
        {
            File.Delete(path_file);
        }
        json_serialisation.serilase_to_json(list, path_file);
        List<sportsman> chessplayers = json_serialisation.deserilase_to_json<sportsman>(path_file);
        foreach (var i in chessplayers)
        {
            i.sportsman_info();
        }
    }
}
