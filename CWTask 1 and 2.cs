
/*вариант 5*/




/*  
 *  using System;
using System.Collections.Generic;
using System.Linq;

struct Employee
{
    public static int totalEmployeesAfter2020 = 0;

    public string name;
    public int empId;
    public int age;
    public int hireYear;
    public double зп;

    public Employee(string name, int age, int hireYear, double зп)
    {
        this.name = name;
        this.empId = totalEmployeesAfter2020 + 1;
        this.age = age;
        this.hireYear = hireYear;
        this.зп = зп;

        if (this.hireYear > 2020)
        {
            totalEmployeesAfter2020++;
        }
    }

    public void DisplayInfo()
    {
        Console.WriteLine("Employee ID: " + empId);
        Console.WriteLine("Name: " + name);
        Console.WriteLine("Age: " + age);
        Console.WriteLine("Year of Hiring: " + hireYear);
        Console.WriteLine("зп: " + зп);
        Console.WriteLine("-----------------------");
    }
}

class Program
{
    static void Main()
    {
        Employee[] employees =
        {
            new Employee("максим макс", 30, 2021, 50000),
            new Employee( "алиса лис", 25, 2019, 45000),
            new Employee("дин динаа", 35, 2022, 60000),
            new Employee("лиза лиззз", 28, 2020, 48000),
            new Employee("бил биллл", 32, 2021, 52000)
        };

        Array.Sort(employees, (x, y) => x.name.Split()[1].CompareTo(y.name.Split()[1]));

        foreach (Employee employee in employees)
        {
            employee.DisplayInfo();
        }

        Console.WriteLine("Total employees hired after 2020: " + Employee.totalEmployeesAfter2020);
    }
}

*/








using System;
using System.Linq;

interface IEmployee
{
    string Name { get; }
    int Age { get; }
    int YearHired { get; }
    double Salary { get; }
}

class Employee : IEmployee
{
    public string Name { get; }
    public int Age { get; }
    public int YearHired { get; }
    public double Salary { get; }

    public Employee(string name, int age, int yearHired, double salary)
    {
        Name = name;
        Age = age;
        YearHired = yearHired;
        Salary = salary;
    }
}

class Company
{
    private string companyName;
    private IEmployee[] employees;

    public Company(string companyName, IEmployee[] employees)
    {
        this.companyName = companyName;
        this.employees = employees;
    }

    public double CalculateAverageSalary()
    {
        return employees.Average(emp => emp.Salary);
    }

    public void DisplayInfo()
    {
        Console.WriteLine("Company: " + companyName);
        Console.WriteLine("Average Salary: " + CalculateAverageSalary());
        Console.WriteLine("----------------------------------");
    }
}

class Program
{
    static void Main()
    {
        IEmployee[] itEmployees =
        {
            new Employee("Максим Макс", 30, 2021, 50000),
            new Employee("Алиса Лис", 25, 2019, 45000),
            new Employee("Дин Динаа", 35, 2022, 60000),
            new Employee("Лиза Лиззз", 28, 2020, 48000),
            new Employee("Бил Биллл", 32, 2021, 52000)
        };

        IEmployee[] industrialEmployees =
        {
            new Employee("Петр Пер", 40, 2018, 55000),
            new Employee("Виктор Вик", 45, 2017, 60000),
            new Employee("Олег Олегов", 38, 2021, 58000),
            new Employee("Сергей Сергеев", 36, 2019, 52000),
            new Employee("Иван Иванов", 42, 2022, 62000)
        };

        Company itCompany = new Company("ITCompany", itEmployees);
        Company industrialCompany = new Company("IndustrialCompany", industrialEmployees);

        Company[] companies = new Company[] { itCompany, industrialCompany };

        Array.Sort(companies, (x, y) => y.CalculateAverageSalary().CompareTo(x.CalculateAverageSalary()));

        foreach (Company company in companies)
        {
            company.DisplayInfo();
        }

        // Для ввода данных при отладке
        Console.WriteLine("Введите информацию о новом сотруднике:");
        Console.Write("Имя: ");
        string name = Console.ReadLine();
        Console.Write("Возраст: ");
        int age = int.Parse(Console.ReadLine());
        Console.Write("Год принятия на работу: ");
        int yearHired = int.Parse(Console.ReadLine());
        Console.Write("Заработная плата: ");
        double salary = double.Parse(Console.ReadLine());

        IEmployee newEmployee = new Employee(name, age, yearHired, salary);
        itEmployees = itEmployees.Append(newEmployee).ToArray();

        Company newItCompany = new Company("ITCompany", itEmployees);

        Console.WriteLine("Информация о новом сотруднике добавлена:");
        newItCompany.DisplayInfo();
    }
}