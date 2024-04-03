using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public bool IsStudent { get; set; }
    public Address Address { get; set; }
    public string[] Hobbies { get; set; }
}

class Address
{
    public string Street { get; set; }
    public string City { get; set; }
}

class Program
{
    static void Main()
    {
        // Создание объекта для сериализации
        var person = new Person
        {
            Name = "John Doe",
            Age = 30,
            IsStudent = false,
            Address = new Address { Street = "123 Main St", City = "Anytown" },
            Hobbies = new[] { "reading", "hiking", "photography" }
        };

        // Создаем объект XmlSerializer для класса Person
        XmlSerializer serializer = new XmlSerializer(typeof(Person));

        // Создаем поток для записи XML
        using (StringWriter writer = new StringWriter())
        {
            // Сериализация объекта в XML
            serializer.Serialize(writer, person);

            // Получаем XML строку из StringWriter
            string xmlString = writer.ToString();
            Console.WriteLine(xmlString);
        }
    }
}
