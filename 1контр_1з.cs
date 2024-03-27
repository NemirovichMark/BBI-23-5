struct Contact
{
    private static int id;
    private int thisid;
    private string name;
    private string secondname;
    private long phoneNumber;
    private string email;
    public string Name { get { return name; } }
    public string Secondname { get { return secondname; } }
    public Contact(string secondname, string name, long phoneNumber, string email)
    {
        thisid = id;
        id++;
        this.name = name;
        this.phoneNumber = phoneNumber;
        this.email = email;
        this.secondname = secondname;
    }


    public void PrintInfo()
    {
        Console.WriteLine($"ID: {id}\tФамилия: {name}\tИмя: {secondname}\tНомер телефона: {phoneNumber}\tEmail: {email}");
    }

    public static void PrintTableHeader()
    {
        Console.WriteLine($"{"ID",10} {"Фамилия",10} {"Имя",10} {"Номер",10} {"Email",10}");
    }

    public void PrintTableRow()
    {
        Console.WriteLine($"{thisid,10} {secondname,10} {name,10} {phoneNumber,10} {email,10}");
    }

}




partial class Program
{
    static void Main(string[] args)
    {
        Contact[] contacts = new Contact[]
        {
            new Contact("Алейникова", "Варвара", 89854626700, "var@mail.ru"),
            new Contact("Сацик", "Анастасия", 89854626710, "var1@mail.ru"),
            new Contact("Крюков", "Павел", 89854626720, "var2@mail.ru"),
            new Contact("Мамадалиев", "Бек", 89854626730, "var3@mail.ru"),
            new Contact("Бронте", "Эмили", 89854626740, "var4@mail.ru")
        };

        SortByName(contacts);
        Contact.PrintTableHeader();
        for (int i = 0; i < contacts.Length; i++)
        {
            contacts[i].PrintTableRow();
        }
    }
    static void SortByName(Contact[] contact)
    {
        for (int i = 1; i < contact.Length; i++)
        {
            for (int j = 0; j < contact.Length - i; j++)
            {
                if (contact[j].Secondname.CompareTo(contact[j + 1].Secondname) > 0)
                {
                    Swap(ref contact[j], ref contact[j + 1]);
                }
                else if (contact[j].Secondname.CompareTo(contact[j + 1].Secondname) == 0)
                {
                    if (contact[j].Name.CompareTo(contact[j + 1].Name) > 0)
                    {
                        Swap(ref contact[j], ref contact[j + 1]);
                    }
                }
            }
        }
    }

    static void Swap(ref Contact a, ref Contact b)
    {
        Contact temp = a;
        a = b;
        b = temp;
    }
}