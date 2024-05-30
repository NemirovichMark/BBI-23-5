using System;
using System.Collections.Generic;

abstract class Contact
{
    public int Id { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public string PhoneNumber { get; }
    public string Email { get; }
    private static int nextId = 1;

    public Contact(string firstName, string lastName, string phoneNumber, string email)
    {
        Id = nextId++;
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        Email = email;
    }

    public abstract void DisplayInfo();
}

class Employee : Contact
{
    public double Salary { get; }
    public DateTime EmploymentDate { get; }

    public Employee(string firstName, string lastName, string phoneNumber, string email, double salary, DateTime employmentDate)
        : base(firstName, lastName, phoneNumber, email)
    {
        Salary = salary;
        EmploymentDate = employmentDate;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Имя: {LastName} {FirstName}\tН/Т: {PhoneNumber}\tПочта: {Email}\tЗарплата: {Salary}\tДата трудоустройства: {EmploymentDate.ToShortDateString()}");
    }
}

class Counteragent : Contact
{
    public double ContractValue { get; }
    public int ContractDuration { get; }

    public Counteragent(string firstName, string lastName, string phoneNumber, string email, double contractValue, int contractDuration)
        : base(firstName, lastName, phoneNumber, email)
    {
        ContractValue = contractValue;
        ContractDuration = contractDuration;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Имя: {LastName} {FirstName}\tН/Т: {PhoneNumber}\t Почта: {Email}\t Стоимость договора: {ContractValue}\t Срок договора: {ContractDuration} дней");
    }
}

class Program
{
    static void Main()
    {
        Employee[] employees = new Employee[5];
        {
            employees[0] = new Employee("Георгий", "Макаров", "89020340612", "m228844@edu.misis.ru", 150000, new DateTime(2020, 1, 10));
            employees[1] = new Employee("Екатерина", "Мартынова", "87838643756", "m200995@edu.misis.ru", 160000, new DateTime(2019, 5, 15));
            employees[2] = new Employee("Елизавета", "Белова", "89023873684", "m234678@edu.misis.ru", 155000, new DateTime(2021, 3, 20));
            employees[3] = new Employee("Алексей", "Киркоров", "89032725642", "m230175@edu.misis.ru", 145000, new DateTime(2018, 7, 22));
            employees[4] = new Employee("Николай", "Басков", "85464693211", "m222222@edu.misis.ru", 148000, new DateTime(2022, 9, 30));
        };
        for (int i = 0; i < employees.Length - 1; i++)
        {
            for (int j = 0; j < employees.Length - i - 1; j++)
            {
                if (CompareEmployees(employees[j], employees[j + 1]) > 0)
                {
                    var temp = employees[j];
                    employees[j] = employees[j + 1];
                    employees[j + 1] = temp;
                }
            }

        }
        Counteragent[] counteragents = new Counteragent[5];
        {
            counteragents[0] = new Counteragent("Анна", "Иванова", "88005553535", "m230020@edu.misis.ru", 100000, 365);
            counteragents[1] = new Counteragent("Евгений", "Антонов", "89038752496", "m230006@edu.misis.ru", 150000, 180);
            counteragents[2] = new Counteragent("Алиса", "Ермакова", "89192226386", "m230034@edu.misis.ru", 200000, 90);
            counteragents[3] = new Counteragent("Федор", "Марков", "89020340612", "m230175@edu.misis.ru", 175000, 120);
            counteragents[4] = new Counteragent("Александр", "Сергеев", "89054321987", "m230001@edu.misis.ru", 160000, 240);
        };

        for (int i = 0; i < counteragents.Length - 1; i++)
        {
            for (int j = 0; j < counteragents.Length - i - 1; j++)
            {
                if (CompareCounteragents(counteragents[j], counteragents[j + 1]) > 0)
                {
                    var temp = counteragents[j];
                    counteragents[j] = counteragents[j + 1];
                    counteragents[j + 1] = temp;
                }
            }
        }

        Console.WriteLine("Отсортированные Employees:");
        Console.WriteLine("--------------------------------------------------------------------------------------------");
        foreach (var employee in employees)
        {
            employee.DisplayInfo();
        }

        Console.WriteLine("Отсортированные Counteragents:");
        Console.WriteLine("--------------------------------------------------------------------------------------------");
        foreach (var counteragent in counteragents)
        {
            counteragent.DisplayInfo();
        }


            List<Contact> allContacts = new List<Contact>();
            allContacts.AddRange(employees);
            allContacts.AddRange(counteragents);

            var sortedAllContacts = allContacts.OrderBy(c => c.LastName).ThenBy(c => c.FirstName).ToList();

            Console.WriteLine("Соединение двух массивов:");
            Console.WriteLine("--------------------------------------------------------------------------------------------");
            foreach (var contact in sortedAllContacts)
            {
                contact.DisplayInfo();
            }
        }
   
private static int CompareCounteragents(Contact x, Contact y)
    {
        int lastNameComparison = string.Compare(x.LastName, y.LastName);
        if (lastNameComparison == 0)
        {
            return string.Compare(x.FirstName, y.FirstName);
        }
        return lastNameComparison;
    }
    private static int CompareEmployees(Contact x, Contact y)
    {
        int lastNameComparison = string.Compare(x.LastName, y.LastName);
        if (lastNameComparison == 0)
        {
            return string.Compare(x.FirstName, y.FirstName);
        }
        return lastNameComparison;
    }
}