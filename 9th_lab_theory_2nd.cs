﻿using System;
using System.Text.Json;
using System.Text.Json.Serialization;

class Person
{
    public string Name { get; private set; }
    public int Age { get; private set; }
    public bool IsStudent { get; private set; }
    public Address Address { get; private set; }
    public string[] Hobbies { get; private set; }

    [JsonConstructor]
    public Person(string name, int age, bool isStudent, Address address, string[] hobbies)
    {
        Name = name;
        Age = age;
        IsStudent = isStudent;
        Address = address;
        Hobbies = hobbies;
    }
}

class Address
{
    public string Street { get; private set; }
    public string City { get; private set; }

    [JsonConstructor]
    public Address(string street, string city)
    {
        Street = street;
        City = city;
    }
}

class Program
{
    static void Main()
    {
        // Создание объекта для сериализации
        var person = new Person(
            "John Doe",
            30,
            false,
            new Address("123 Main St", "Anytown"),
            new[] { "reading", "hiking", "photography" }
        );

        // Сериализация объекта в JSON строку
        string json = JsonSerializer.Serialize(person);
        Console.WriteLine(json);

        // Десериализация JSON строки в объект
        Person deserializedPerson = JsonSerializer.Deserialize<Person>(json);
        Console.WriteLine($"Name: {deserializedPerson.Name}, Age: {deserializedPerson.Age}");
    }
}
