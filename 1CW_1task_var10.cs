using System;

struct Contact
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

    public void DisplayInfo()
    {
        Console.WriteLine($"Name: {FirstName} {LastName}\tPhone: {PhoneNumber}\tEmail: {Email}");
    }
}

class Program
{
    static void Main()
    {
        Contact[] contacts = new Contact[5];
        contacts[0] = new Contact("Анна", "Иванова", "88005553535", "m230020@edu.misis.ru");
        contacts[1] = new Contact("Евгений", "Антонов", "89038752496", "m230006@edu.misis.ru");
        contacts[2] = new Contact("Алиса", "Ермакова", "89192226386", "m230034@edu.misis.ru");
        contacts[3] = new Contact("Федор", "Марков", "89020340612", "m230175@edu.misis.ru");
        contacts[4] = new Contact("Александр", "Сергеев", "89054321987", "m230001@edu.misis.ru");

        for (int i = 0; i < contacts.Length - 1; i++)
        {
            for (int j = 0; j < contacts.Length - i - 1; j++)
            {
                if (CompareContacts(contacts[j], contacts[j + 1]) > 0)
                {
                    var temp = contacts[j];
                    contacts[j] = contacts[j + 1];
                    contacts[j + 1] = temp;
                }
            }
        }

        Console.WriteLine("Отсортированный массив Contacts:");
        Console.WriteLine("Имя\t\tН/Т\t\tПочта");
        foreach (var contact in contacts)
        {
            Console.WriteLine($"{contact.FirstName} {contact.LastName}\t{contact.PhoneNumber}\t{contact.Email}");
        }
    }

    private static int CompareContacts(Contact x, Contact y)
    {
        int lastNameComparison = string.Compare(x.LastName, y.LastName);
        if (lastNameComparison == 0)
        {
            return string.Compare(x.FirstName, y.FirstName);
        }
        return lastNameComparison;
    }
}


