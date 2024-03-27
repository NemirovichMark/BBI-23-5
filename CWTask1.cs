struct Contact
{
    public int _number { get; private set; }
    private string _lastname;
    private string _name;
    private string _email;
    private string _phone;

    public Contact(int number, string lastname, string name, string email, string phone)
    {
        _number = number; _lastname = lastname; _name = name; _email = email; _phone = phone;
    }

    public void Print()
    {
        Console.WriteLine($"Номер {_number}\t Фамилия {_lastname}\t Имя {_name}\t  Почта {_email}\t Телефон {_phone}");
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

class Program
{
    static void Main()
    {
        Contact[] c =
        {
            new Contact(1, "Зайцева", "Анна", "z@mail", "234"),
            new Contact(2, "Арбузкин", "Артем", "a@mail", "123"),
            new Contact(3, "Давидов", "Матвей", "d@mail", "456"),
            new Contact(4, "Мишкина", "Алина", "m@mail", "365"),
            new Contact(5, "Паровозов", "Павел", "p@mail", "675")
        };



        foreach (var cont in c) { cont.Sort(c); }
        foreach (var cont in c) { cont.Print(); }
        Console.WriteLine();
        foreach (var cont in c) { cont.Sort2(c); }
        foreach (var cont in c) { cont.Print(); }

    }
}