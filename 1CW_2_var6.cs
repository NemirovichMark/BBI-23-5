using System;
using System.Runtime.InteropServices;

public abstract class Book
{
    private string _name;
    public string Name => _name;
    private int _uISBN;
    public int UISBN => _uISBN;
    private string _author;
    public string Author => _author;
    private int _year;
    public int Year => _year;

    public double price {get; protected set; }
    //private int _price;
    //public int Price => _price;

    public Book(string n, int u, string a, int y, int p)
    {
        _name = n;
        _uISBN = u;
        _author = a;
        _year = y;
        price = p;
    }
    public abstract void CalculatePrice();
    public virtual void ToString()
    {
        Console.WriteLine($"Название: {_name}, Код: {_uISBN}, Автор: {_author}, Год издания: {_year}, Стоимость: {price}");
    }

    public void ToStringsByAuthor(string author)
    {
        if (_author == author)
        {
            Console.WriteLine($"Название: {_name}, Код: {_uISBN}, Автор: {_author}, Год издания: {_year}");
        }

    }
    public void ToStringsByCentury(int century)
    {
        if ((_year - 1) / 100 + 1 == century)
        {
            Console.WriteLine($"Название: {_name}, Код: {_uISBN}, Автор: {_author}, Год издания: {_year}");
        }
    }
}

public class PaperBook : Book
{
    private bool _isHardcover;
    public bool IsHardCover => _isHardcover;

    public PaperBook(string n, int u, string a, int y, int p, bool isHardcover)
        : base(n, u, a, y, p)
    {
        _isHardcover = isHardcover;
        CalculatePrice();
    }

    public override void CalculatePrice()
    {
        if (_isHardcover)
        {
            price *= 1.2;
        }
    }

    public override void ToString()
    {
        base.ToString();
        Console.WriteLine($"Твердая обложка: {_isHardcover}");
    }
}

public class ElectronicBook : Book
{
    private string _format;
    public string Format => _format;

    public ElectronicBook(string n, int u, string a, int y, int p, string format)
        : base(n, u, a, y, p)
    {
        _format = format;
        CalculatePrice();
    }

    public override void CalculatePrice()
    {
        if (Format == "pdf")
        {
            price *= 1.1;
        }
    }

    public override void ToString()
    {
        base.ToString();
        Console.WriteLine($"Формат: {_format}");
    }
}

public class AudioBook : Book
{
    private bool _isStudioRecorded;
    public bool IsStudioRecorded => _isStudioRecorded;

    public AudioBook(string n, int u, string a, int y, int p, bool isStudioRecorded)
        : base(n, u, a, y, p)
    {
        _isStudioRecorded = isStudioRecorded;
        CalculatePrice();
    }

    public override void CalculatePrice()
    {
        if (IsStudioRecorded)
        {
            price *= 1.3;
        }
    }

    public override void ToString()
    {
        base.ToString();
        Console.WriteLine($"Было ли записано на студии: {IsStudioRecorded}");
    }
}

class Program
{
    static void Main()
    {
        PaperBook[] paperBooks = new PaperBook[]
    {
            new PaperBook("Название не придумала 1", 123456, "Автор 1", 1999, 200, true),
            new PaperBook("Название не придумала 2", 123457, "Автор номер 2", 1985, 1500, false),
            new PaperBook("Название не придумала 3", 123458, "Автор под номером 3", 2001, 640, true),
            new PaperBook("Название не придумала 4", 123459, "Автор с номером 4", 1970, 800, false),
            new PaperBook("Название не придумала 5", 123460, "У автора номер 5", 2010, 912, true),
    };
        ElectronicBook[] electronicBooks = new ElectronicBook[]
    {
            new ElectronicBook("Придумаю навзание 1", 223456, "Автор праоа", 2005, 170, "pdf"),
            new ElectronicBook("Придумаю навзание 2", 223457, "Автор апраоп", 2015, 340, "epub"),
            new ElectronicBook("Придумаю навзание 3", 223458, "Автор апапра", 2010, 290, "pdf"),
            new ElectronicBook("Придумаю навзание 4", 223459, "Автор ыпвпа", 2000, 700, "fb2"),
            new ElectronicBook("Придумаю навзание 5", 223460, "Автор", 2020, 300, "epub"),
    };
        AudioBook[] audioBooks = new AudioBook[]
    {
            new AudioBook("Или не придумаю название 1", 323456, "Автору", 1995, 300, true),
            new AudioBook("Или не придумаю название 2", 323457, "Автора", 2005, 600, false),
            new AudioBook("Или не придумаю название 3", 323458, "Автором", 2015, 350, true),
            new AudioBook("Или не придумаю название 4", 323459, "Авторы", 2010, 190, false),
            new AudioBook("Или не придумаю название 5", 323460, "Аторка", 2022, 270, true),
    };
        SortBooksByPrice(paperBooks);
        Console.WriteLine("Бумажные книги:");
        PrintBooks(paperBooks);

        SortBooksByPrice(electronicBooks);
        Console.WriteLine();
        Console.WriteLine("Электронные книги:");
        PrintBooks(electronicBooks);

        SortBooksByPrice(audioBooks);
        Console.WriteLine();
        Console.WriteLine("Аудио книги:");
        PrintBooks(audioBooks);

        static void PrintBooks(Book[] books)
        {
            foreach (var book in books)
            {
                book.ToString();
                Console.WriteLine();
            }
        }
        static void SortBooksByPrice(Book[] books)
        {
            for (int i = 0; i < books.Length - 1; i++)
            {
                for (int j = 0; j < books.Length - i - 1; j++)
                {
                    if (books[j].price < books[j + 1].price)
                    {
                        var temp = books[j];
                        books[j] = books[j + 1];
                        books[j + 1] = temp;
                    }
                }
            }
        }

    }
};




