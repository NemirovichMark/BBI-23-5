abstract class Contact
{
    public int _number { get; private set; }
    protected string _lastname;
    protected string _name;
    protected string _email;
    protected string _phone;
    protected string _costd;
    protected string _days;
    protected string _salary;
    protected string _date;

    public Contact(int number, string lastname, string name, string email, string phone)
    {
        _number = number; _lastname = lastname; _name = name; _email = email; _phone = phone; _costd = string.Empty; _days = string.Empty; _salary = string.Empty; _date = string.Empty;
    }

    public virtual void Print()
    {
        Console.WriteLine($"Номер {_number} \t Фамилия {_lastname} \t Имя {_name}\t  Почта {_email}\t Телефон {_phone}");
    }

    public void Sort(Contact[] a)
    {
        int imin;
        for (int i = 0; i < a.Length - 1; i++)
        {
            imin = i;
            for (int j = i + 1; j < a.Length; j++)
            {
                if (a[j]._lastname.CompareTo(a[imin]._lastname) < 0)
                {
                    imin = j;
                }

            }
            Contact Temp = a[i];
            a[i] = a[imin];
            a[imin] = Temp;

        }

    }

    public void Sort2(Contact[] a)
    {
        int imin;
        for (int i = 0; i < a.Length - 1; i++)
        {
            imin = i;
            for (int j = i + 1; j < a.Length; j++)
            {
                if (a[j]._name.CompareTo(a[imin]._name) < 0)
                {
                    imin = j;
                }

            }
            Contact Temp = a[i];
            a[i] = a[imin];
            a[imin] = Temp;

        }

    }
}

class Employee : Contact
{

    public Employee(string salary, string date, int number, string lastname, string name, string email, string phone) : base(number, lastname, name, email, phone)
    {
        _salary = salary;
        _date = date;
    }

}

class Counteragent : Contact
{
    public Counteragent(string costd, string days, int number, string lastname, string name, string email, string phone) : base(number, lastname, name, email, phone)
    {
        _costd = costd;
        _days = days;
    }

}



class Program
{
    static void Main()
    {
        Employee[] e =
        {
            new Employee("200$", "13.09", 1, "Зайцева", "Анна", "z@mail", "234"),
            new Employee("432$", "23.06", 2, "Арбузкин", "Артем", "a@mail", "123"),
            new Employee("123$", "14.10", 3, "Давидов", "Матвей", "d@mail", "456"),
            new Employee("256$", "01.03", 4, "Мишкина", "Алина", "m@mail", "365"),
            new Employee("150$", "18.08", 5, "Паровозов", "Павел", "p@mail", "675")
        };

        Counteragent[] c =
        {
            new Counteragent("14$", "5 дней", 6, "Синицина", "Олеся", "s@mail", "432"),
            new Counteragent("45$", "16 дней", 7, "Пикников", "Павел", "p@mail", "783"),
            new Counteragent("11$", "6 дней", 8, "Симонов", "Саша", "c@mail", "192"),
            new Counteragent("28$", "9 дней", 9, "Улыбкина", "Марина", "y@mail", "982"),
            new Counteragent("50$", "13 дней", 10, "Дудкин", "Семен", "d@mail", "345")
        };

        Console.WriteLine("отдельные таблицы для сортировки фамилии и имени");



        foreach (var cont in e) { cont.Sort(e); }
        foreach (var cont in e) { cont.Print(); }
        Console.WriteLine();
        foreach (var cont in e) { cont.Sort2(e); }
        foreach (var cont in e) { cont.Print(); }

        Console.WriteLine();

        foreach (var cont in c) { cont.Sort(c); }
        foreach (var cont in c) { cont.Print(); }
        Console.WriteLine();
        foreach (var cont in c) { cont.Sort2(c); }
        foreach (var cont in c) { cont.Print(); }

        Console.WriteLine();

        Contact[] total = new Contact[e.Length + c.Length];
        {
            for (int i = 0; i < e.Length; i++)
                total[i] = e[i];
            for (int j = 0; j < c.Length; j++)
                total[e.Length + j] = c[j];
        }
        Console.WriteLine("таблицы для сортировки общего массива по фамилии и имени");

        foreach (var cont in total) { cont.Sort(total); }
        foreach (var cont in total) { cont.Print(); }
        Console.WriteLine();
        foreach (var cont in total) { cont.Sort2(total); }
        foreach (var cont in total) { cont.Print(); }
    }
}
