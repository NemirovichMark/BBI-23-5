public class Program
{
    public abstract class Goods
    {
        protected static int art;
        protected int articul;
        protected string name;
        protected string description;
        protected float cost;
        public float Cost { get { return cost; } }
        public void ChangeDesc(string desc)
        {
            if (desc.Length < 201 && desc.Length > 19)
            {
                description = desc;
            }
            else { description = $"Для товара {name} описание не задано"; }
        }
        public void Show()
        {
            Console.WriteLine($"Product {name}: {description}; cost: {cost}");
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

    class Beverage : Goods
    {
        private int sugar;
        public Beverage(string n, int c, int sug) : base(n, c)
        {
            sugar = sug;
            if (sugar > 5) { cost *= 1.1f; }
        }
    }
    class Food : Goods
    {
        private int days;
        public Food(string n, int c, int da) : base(n, c)
        {
            days = da;
            if (days < 31) { cost *= 1.05f; }
            else if (days > 365) { cost *= 0.95f; }
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
        Food[] f = { new Food("Salt", 20, 10), new Food("Pepper", 10, 32), new Food("Cabbage", 30, 400), new Food("Yumm", 40, 500), new Food("Gold", 50, 9999) };
        f[0].ChangeDesc("Good thing");
        f[1].ChangeDesc("Very good to add in some salads");
        string h = "r";
        for (int i = 0; i < 200; i++) { h += "r"; }
        f[2].ChangeDesc(h);
        Beverage[] b = { new Beverage("Lemonade", 20, 2), new Beverage("Cola", 10, 20), new Beverage("Pinacolada", 30, 6), new Beverage("Milk", 40, 0), new Beverage("Kumis", 50, 1) };
        Sortt(f);
        Sortt(b);
        foreach (Food a in f) { a.Show(); }
        foreach (Beverage a in b) { a.Show(); }
    }
}
