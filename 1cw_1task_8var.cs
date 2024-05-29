public class Program
{
    public struct Goods
    {
        private static int art;
        private int articul;
        private string name;
        private string description;
        private int cost;
        public int Cost { get { return cost; } }
        public void ChangeDesc(string desc)
        {
            if (desc.Length < 201 &&  desc.Length > 19)
            {
                description = desc;
            }
            else { description = $"Для товара {name} описание не задано"; }
        }
        public void Show()
        {
            Console.WriteLine($"Product {name}: {description}; cost: {cost}; articul: {articul}");
        }
        public Goods(string n, int c)
        {
            name = n;
            articul = art;
            art++;
            cost = c;
            ChangeDesc(" ");
        }
    }
    
    static void Main()
    {
        void Sortt(Goods[] f)
        {
            for (int i = 0; i < f.Length; i++)
            {
                for (int j = 1; j < f.Length; j++)
                {
                    if (f[j - 1].Cost > f[j].Cost)
                    {
                        Goods a = f[j];
                        f[j] = f[j - 1];
                        f[j - 1] = a;
                    }
                }
            }
        }
        Goods[] f = { new Goods("Salt", 2), new Goods("Pepper", 1), new Goods("Cabbage", 3), new Goods("Yumm", 4), new Goods("Gold", 5) };
        f[0].ChangeDesc("Good thing");
        f[1].ChangeDesc("Very good to add in some salads");
        string h = "r";
        for(int i = 0; i < 200;i++) { h += "r"; }
        f[2].ChangeDesc(h);
        Sortt(f);
        foreach(Goods a in f) { a.Show(); }
    }
}
