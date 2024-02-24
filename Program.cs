//задача 3лвл
struct Group
{
    private string _name;
    private double[] _results = new double[6];
    private int _count = 0;
    private int _bestgroup = 0;
    public Group(string name, double[] results)
    {
        _name = name;
        _results = results;
        for (int i = 0; i < _results.Length; i++)
        {
            for (int j = 1; j <= 5; j++)
            {
                if (results[i] == j)
                {
                    _count += 6 - j;
                }
            }
            if (results[i] == 1)
            {
                _bestgroup = 1;
            }
        }
    }
    public int bestcomand { get { return _bestgroup; } }
    public int count { get { return _count; } }
    public void Print(string text = "Неправда")
    {
        if (_name != null)
        {
            text = _name + " " + _count;
        }
        Console.WriteLine(text);
    }
}
class Program
{
    static void Main()
    {
        Group[] group = new Group[3];
        double[] results = new double[6];
        string name;
        for (int i = 0; i < group.Length; i++)
        {
            Console.WriteLine("Команда:");
            name = Console.ReadLine();
            Console.WriteLine("Места участников команды:");
            for (int j = 0; j < 6; j++)
            {
                results[j] = double.Parse(Console.ReadLine());
            }
            group[i] = new Group(name, results);
        }
        static void FindTopCandidates(Group[] group)
        {
            {
                int d = group.Length / 2;
                Group temp;
                while (d >= 1)
                {
                    for (int i = d; i < group.Length; i++)
                    {
                        int j = i;
                        while (j >= d && group[j - d].bestcomand < group[j].bestcomand)
                        {
                            temp = group[j];
                            group[j] = group[j - d];
                            group[j - d] = temp;
                            j = j - d;
                        }
                    }
                    d = d / 2;
                }
            }
        }

        Console.Write("Результаты:");
        for (int i = 0; i < 3; i++)
        {
            group[i].Print();
        }
    }
}