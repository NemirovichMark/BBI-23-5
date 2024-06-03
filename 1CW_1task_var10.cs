using System;

namespace ContactManager
{
    struct Contact
    {
        private int id;
        private string firstName;
        private string lastName;
        private string phoneNumber;
        private string emailAddress;

        public Contact(int id, string firstName, string lastName, string phoneNumber, string emailAddress)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.phoneNumber = phoneNumber;
            this.emailAddress = emailAddress;
        }

        public void DisplayInfo()
        {
            Console.WriteLine("|{0, -5}|{1, -10}|{2, -10}|{3, -15}|{4, -20}|", id, firstName, lastName, phoneNumber, emailAddress);
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Contact[] contacts = new Contact[5];
            contacts[0] = new Contact(1, "Иван", "Смирнов", "+123456789", "ivan@example.com");
            contacts[1] = new Contact(2, "Александр", "Иванов", "+987654321", "alexander@example.com");
            contacts[2] = new Contact(3, "Дмитрий", "Кузнецов", "+555555555", "dmitry@example.com");
            contacts[3] = new Contact(4, "Алексей", "Петров", "+111111111", "alexey@example.com");
            contacts[4] = new Contact(5, "Андрей", "Смирнов", "+999999999", "andrey@example.com");

            SortContactsByLastNameAndFirstName(contacts);

            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("|ID   |Имя       |Фамилия   |Номер телефона |Адрес электронной почты|");
            Console.WriteLine("--------------------------------------------");

            foreach (var contact in contacts)
            {
                contact.DisplayInfo();
            }

            Console.WriteLine("--------------------------------------------");
        }

        static void SortContactsByLastNameAndFirstName(Contact[] contacts)
        {
            for (int i = 0; i < contacts.Length - 1; i++)
            {
                for (int j = 0; j < contacts.Length - i - 1; j++)
                {
                    if (string.Compare(contacts[j].LastName, contacts[j + 1].LastName) > 0)
                    {
                        SwapContacts(ref contacts[j], ref contacts[j + 1]);
                    }
                    else if (string.Compare(contacts[j].LastName, contacts[j + 1].LastName) == 0)
                    {
                        if (string.Compare(contacts[j].FirstName, contacts[j + 1].FirstName) > 0)
                        {
                            SwapContacts(ref contacts[j], ref contacts[j + 1]);
                        }
                    }
                }
            }
        }

        static void SwapContacts(ref Contact contact1, ref Contact contact2)
        {
            Contact temp = contact1;
            contact1 = contact2;
            contact2 = temp;
        }
    }
}








