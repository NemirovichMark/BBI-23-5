using System;
using System.Collections.Generic;

namespace PersonManagement
{
    abstract class Person
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public abstract void DisplayInfo();
    }

    class Employee : Person
    {
        public int Salary { get; set; }
        public string EmploymentDate { get; set; }

        public override void DisplayInfo()
        {
            Console.WriteLine($"{LastName} {FirstName}, Salary: {Salary}, Employment Date: {EmploymentDate}");
        }
    }

    class Counteragent : Person
    {
        public int ContractCost { get; set; }
        public int ContractDuration { get; set; }

        public override void DisplayInfo()
        {
            Console.WriteLine($"{LastName} {FirstName}, Contract Cost: {ContractCost}, Contract Duration: {ContractDuration} days");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Person> employees = new List<Person>();
            List<Person> counteragents = new List<Person>();

            employees.Add(new Employee { LastName = "Карлович", FirstName = "Иван", Salary = 50000, EmploymentDate = "01.01.2010" });
            employees.Add(new Employee { LastName = "Иванова", FirstName = "Мария", Salary = 60000, EmploymentDate = "12.05.2015" });
            employees.Add(new Employee { LastName = "Смирнов", FirstName = "Алексей", Salary = 45000, EmploymentDate = "07.09.2018" });
            employees.Add(new Employee { LastName = "Петров", FirstName = "Андрей", Salary = 55000, EmploymentDate = "03.03.2017" });
            employees.Add(new Employee { LastName = "Соколова", FirstName = "Елена", Salary = 70000, EmploymentDate = "11.11.2012" });

            counteragents.Add(new Counteragent { LastName = "Козлов", FirstName = "Артем", ContractCost = 1000000, ContractDuration = 365 });
            counteragents.Add(new Counteragent { LastName = "Павлов", FirstName = "Александр", ContractCost = 500000, ContractDuration = 182 });
            counteragents.Add(new Counteragent { LastName = "Михайлова", FirstName = "Ольга", ContractCost = 800000, ContractDuration = 270 });
            counteragents.Add(new Counteragent { LastName = "Сидоров", FirstName = "Владимир", ContractCost = 300000, ContractDuration = 90 });
            counteragents.Add(new Counteragent { LastName = "Игнатова", FirstName = "Анна", ContractCost = 600000, ContractDuration = 365 });

            employees.Sort((p1, p2) =>
            {
                int compareLastNames = p1.LastName.CompareTo(p2.LastName);
                if (compareLastNames == 0)
                {
                    return p1.FirstName.CompareTo(p2.FirstName);
                }
                return compareLastNames;
            });

            counteragents.Sort((p1, p2) =>
            {
                int compareLastNames = p1.LastName.CompareTo(p2.LastName);
                if (compareLastNames == 0)
                {
                    return p1.FirstName.CompareTo(p2.FirstName);
                }
                return compareLastNames;
            });

            Console.WriteLine("Table of Employees:");
            DisplayTable(employees);

            Console.WriteLine("\nTable of Counteragents:");
            DisplayTable(counteragents);

            List<Person> allPeople = new List<Person>();
            allPeople.AddRange(employees);
            allPeople.AddRange(counteragents);

            allPeople.Sort((p1, p2) =>
            {
                int
    compareLastNames = p1.LastName.CompareTo(p2.LastName);
                if (compareLastNames == 0)
                {
                    return p1.FirstName.CompareTo(p2.FirstName);
                }



                return compareLastNames;
            });

            Console.WriteLine("\nTable of Employees and Counteragents:");
            DisplayTable(allPeople);
        }

        static void DisplayTable(List<Person> people)
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine($"|{"Last Name",-15}|{"First Name",-15}|{"Additional Info",-30}|");

            Console.WriteLine("-----------------------------------------");

            foreach (var person in people)
            {
                person.DisplayInfo();
            }

            Console.WriteLine("-----------------------------------------");
        }
    }
}