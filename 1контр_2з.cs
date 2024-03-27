abstract class Person
{
    private static int id;
    protected int thisid;
    protected string name;
    protected string secondname;
    protected long phoneNumber;
    protected string email;

    public string Name { get { return name; } }
    public string Secondname { get { return secondname; } }

    public Person(string secondname, string name, long phoneNumber, string email)
    {
        thisid = id;
        id++;
        this.name = name;
        this.phoneNumber = phoneNumber;
        this.email = email;
        this.secondname = secondname;
    }

    public abstract void PrintInfo();

    public static void PrintTableHeader()
    {
        Console.WriteLine($"{"ID",10} {"Фамилия",10} {"Имя",10} {"Номер",10} {"Email",10}");
    }

    public void PrintTableRow()
    {
        Console.WriteLine($"{thisid,10} {secondname,10} {name,10} {phoneNumber,10} {email,10}");
    }
}

class Employee : Person
{
    private decimal salary;
    private DateTime employmentDate;

    public Employee(string secondname, string name, long phoneNumber, string email, decimal salary, DateTime employmentDate)
        : base(secondname, name, phoneNumber, email)
    {
        this.salary = salary;
        this.employmentDate = employmentDate;
    }

    public override void PrintInfo()
    {
        Console.WriteLine($"ID: {thisid}\tФамилия: {name}\tИмя: {secondname}\tНомер телефона: {phoneNumber}\tEmail: {email}\tЗарплата: {salary}\tДата трудоустройства: {employmentDate}");
    }
}

class Counteragent : Person
{
    private decimal contractCost;
    private int contractDurationDays;

    public Counteragent(string secondname, string name, long phoneNumber, string email, decimal contractCost, int contractDurationDays)
        : base(secondname, name, phoneNumber, email)
    {
        this.contractCost = contractCost;
        this.contractDurationDays = contractDurationDays;
    }

    public override void PrintInfo()
    {
        Console.WriteLine($"ID: {thisid}\tФамилия: {name}\tИмя: {secondname}\tНомер телефона: {phoneNumber}\tEmail: {email}\tСтоимость договора: {contractCost}\tСрок договора (дни): {contractDurationDays}");
    }
}

partial class Program
{
    static void Main(string[] args)
    {
        Person[] persons = new Person[]
        {
            new Employee("Алейникова", "Варвара", 89854626700, "var@mail.ru", 50000, new DateTime(2022, 1, 15)),
            new Counteragent("Сацик", "Анастасия", 89854626710, "var1@mail.ru", 100000, 30),
            new Employee("Крюков", "Павел", 89854626720, "var2@mail.ru", 60000, new DateTime(2021, 5, 10)),
            new Counteragent("Мамадалиев", "Бек", 89854626730, "var3@mail.ru", 75000, 45),
            new Employee("Бронте", "Эмили", 89854626740, "var4@mail.ru", 55000, new DateTime(2023, 8, 20))
        };

        SortByName(persons);
        Person.PrintTableHeader();
        foreach (var person in persons)
        {
            person.PrintTableRow();
        }
    }

    static void SortByName(Person[] persons)
    {
        for (int i = 1; i < persons.Length; i++)
        {
            for (int j = 0; j < persons.Length - i; j++)
            {
                if (persons[j].Secondname.CompareTo(persons[j + 1].Secondname) > 0)
                {
                    Swap(ref persons[j], ref persons[j + 1]);
                }
                else if (persons[j].Secondname.CompareTo(persons[j + 1].Secondname) == 0)
                {
                    if (persons[j].Name.CompareTo(persons[j + 1].Name) > 0)
                    {
                        Swap(ref persons[j], ref persons[j + 1]);
                    }
                }
            }
        }
    }

    static void Swap(ref Person a, ref Person b)
    {
        Person temp = a;
        a = b;
        b = temp;
    }
}