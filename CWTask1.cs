using System;
using System.Diagnostics;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Xml.Linq;

struct Car
{
    private string brand;
    private string model;
    private Guid vim;
    private int year;
    public int mileage;//пробег
    private string characteristics;

    public Car(string Brand, string Model, Guid VIM, int Year, int Mileage, string Characteristics)
    {
        brand = Brand;
        model = Model;
        year = Year;
        vim = VIM;
        mileage = Mileage;
        characteristics = Characteristics;
    }
    public string Brand
    {
        get { return brand; }
    }
    public string Model
    {
        get { return model; }
    }
    public string Characteristics
    {
        get { return characteristics; }
    }
    public Guid VIM
    {
        get { return vim; }
    }
    public int Year
    {
        get { return year; }
    }
    public int Mileage
    {
        get { return mileage; }
    }
    public void Print()
    {
        Console.WriteLine($"| {Brand,-10} | {Model,-10} | {VIM,-10} | {Year,-10} | {Mileage,-10} | {Characteristics,-10} ");
    }
    public static string Characteristic(int ThisMileage)
    {
        if (ThisMileage > 500)
        {
            return "Рабочая";
        }
        else if (ThisMileage >= 100 && ThisMileage <= 500)
        {
            return "Праздничная";
        }
        else
        {
            return "Простаивающая";
        }
    }
}

class Program
{
    static void Main()
    {
        Car[] cars = new Car[5];

        cars[0] = new Car("Brand1", "Model1", Guid.NewGuid(), 2006, 650, Car.Characteristic(cars[0].mileage));
        cars[1] = new Car("Brand2", "Model2", Guid.NewGuid(), 2023, 90, Car.Characteristic(cars[1].Mileage));
        cars[2] = new Car("Brand3", "Model3", Guid.NewGuid(), 1989, 200, Car.Characteristic(cars[2].mileage));
        cars[3] = new Car("Brand4", "Model4", Guid.NewGuid(), 2000, 340, Car.Characteristic(cars[3].mileage));
        cars[4] = new Car("Brand5", "Model5", Guid.NewGuid(), 2011, 499, Car.Characteristic(cars[4].mileage));

        Sort(cars);
        foreach (Car car in cars)
        {
            car.Print();
            Console.WriteLine();
        }
    }
    public static void Sort(Car[] cars)
    {
        int i = 1;
        int j = 2;
        while (i < cars.Length)
        {
            if (cars[i - 1].Mileage <= cars[i].Mileage)
            {
                i = j;
                j++;
            }
            else
            {
                Car temp = cars[i - 1];
                cars[i - 1] = cars[i];
                cars[i] = temp;
                i--;
                if (i == 0)
                {
                    i = j;
                    j++;
                }
            }
        }

    }

}

