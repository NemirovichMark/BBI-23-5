using System;
using System.Runtime.InteropServices;

struct Book
{
    private string _name;
    public string Name => _name;
    private int _uISBN;
    public int UISBN => _uISBN;
    private string _author;
    public string Author => _author;
    private int _year;
    public int Year => _year;

    public Book(string n,  int u, string a, int y)
    {
        _name = n;
        _uISBN = u;
        _author = a;
        _year = y;
    }

    public void ToString()
    {
        Console.WriteLine($"Название: {_name}, Код: {_uISBN}, Автор: {_author}, Год издания: {_year}");
    }

    public void ToStringsByAuthor(string author)
    {
        if (_author == author)
        {
            ToString();
        }

    }
    public void ToStringsByCentury(int century)
    {
        if ((_year - 1) / 100 + 1 == century)
            {
               ToString();
            }
    }
}
class Program
{
    static void Main()
    {
        Book[] books = new Book[]
        {
            new Book("Книга Раз", 123456, "Гай Юлий", 1999),
            new Book("Книжечка двас", 123457, "Иван Иванов", 1890),
            new Book("Книжулечка трис", 123458, "Петр Петров", 2001),
            new Book("Закончились описания книги", 123459, "Игорь Икраткий", 1750),
            new Book("Веселые приключения бумаги", 123460, "Иванка Ивановна", 1805),
            new Book("Еще веселее, но уже мои", 123461, "Алена Петровна", 1984),
            new Book("Отсутствие фантазии в книгах", 123462, "Андрей Андрей", 1900),
            new Book("Цветочки", 123463, "Иванов Игорь", 2003),
            new Book("Леписточки", 123464, "Анна Сергеевна", 2010),
            new Book("Книга 2654637", 123465, "Автор финальный", 1700)
        };
        Console.WriteLine("Все книги :");
        foreach (Book b in books)
        {
            b.ToString();
        }

        Console.WriteLine();
        Console.WriteLine("Книги автора Петр Петров:");
        foreach(Book b in books)
        {
            b.ToStringsByAuthor("Петр Петров");
        }

        Console.WriteLine();
        Console.WriteLine("Книги в 19-м веке:");
        foreach (Book b in books)
        {
            b.ToStringsByCentury(19);
        }
    }
}

