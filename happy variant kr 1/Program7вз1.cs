struct Goods
{
    private string _name;
    private string _artic;
    private int _cost;
    public int Cost => _cost;
    private int _kolvo;
    public Goods(string name, string artic, int cost, int kolvo)
    {
        _name = name;
        _artic = artic;
        _cost = cost;
        _kolvo = kolvo;
    }
    public void Print()
    {
        Console.WriteLine("Товар   {0}\t Количество {1}\t Информация {2}\t",
                        _name, _kolvo, _artic);
    }
}
class Program
{
    static void Main()
    {
        Goods[] c1 = new Goods[]
        {
            new Goods("мыло","хозяйственное",100,5),
            new Goods("вода","минеральная",25,100),
            new Goods("каша","перловая",38,145),
            new Goods("крем","для рук",300,4),
            new Goods("лампа","настольная",1500,10)
        };
        Sorting(c1);
        Console.WriteLine();
        foreach (Goods good in c1)
        {
            good.Print();
        }
        static void Sorting(Goods[] c1)
        {
            int n = c1.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (c1[j].Cost > c1[j + 1].Cost)
                    {
                        Goods temp = c1[j];
                        c1[j] = c1[j + 1];
                        c1[j + 1] = temp;
                    }
                }
            }
        }

    }  
}