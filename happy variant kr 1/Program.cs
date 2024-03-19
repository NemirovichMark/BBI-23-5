struct Book
{
    private string _name;
    private int _ISBN;
    private string _author;
    private int _year;
    public int Year => _year;
    public string Author => _author;
    public Book(string name, int ISBN, string author, int year)
    {
        _name = name;
        _ISBN = ISBN;
        _author = author;
        _year = year;
    }
    public void Print()
    {
        Console.WriteLine("Автор   {0}\t Книга {1}\t ISBN {2}\t Год издания {3}\t",
                        _author, _name, _ISBN, _year);
    }
}
class Program
{
    static void Main()
    {
        Book[] books = new Book[]
        {
            new Book("Война и мир",12546, "Толстой", 1889),
            new Book("Геометрия",54782, "Мерзляк", 2015),
            new Book("Айболит",32456, "Чуковский", 1984),
            new Book("Пишисокращай",43567, "Иванов", 2019),
            new Book("1984",21332, "Оруэлл", 1949),
            new Book("Обломов",13546, "Гончаров", 1931),
            new Book("Физика",12346, "Перышкин", 2000),
            new Book("Золотой луг",25346, "Пришвин", 1934),
            new Book("Гарри Поттер",56314, "Роулинг", 1997),
            new Book("Три товарища",44546, "Ремарк", 1936)

        };
        foreach (var book in books)
        {
            book.Print();
        }
        Author(books);
        Century(books);

    }
    static void Author(Book[] books)
    {
        Console.WriteLine("Введите фамилию автора для поиска книг: ");
        string AuthorInput = "Пришвин";
        Console.WriteLine("Книги автора {0}:", AuthorInput);
        bool found = false;
        foreach (var book in books)
        {
            if (book.Author == AuthorInput)
            {
                book.Print();
                found = true;
            }
        }
        if (!found)
        {
            Console.WriteLine("Книг этого автора не найдено");
        }
    }
    static void Century(Book[] books)
    {
        Console.WriteLine("Введите век для поиска книг: ");
        int centuryInput = 21;
        int startYear = centuryInput * 100 - 100;
        int endYear = centuryInput * 100 - 1;

        Console.WriteLine("Книги, написанные в {0} веке:", centuryInput);
        bool found = false;
        foreach (var book in books)
        {
            if (book.Year >= startYear && book.Year <= endYear)
            {
                book.Print();
                found = true;
            }
        }
        if (!found)
        {
            Console.WriteLine("Книг этого века не найдено");
        }
    }
}