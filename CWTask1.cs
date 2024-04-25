struct Book
{
    private string name;
    private string author;
    private int year;
    private int ISBN;
    public Book(string _name, int _ISBN, string _author, int _year)
    {
        name = _name;
        ISBN = _ISBN;
        author = _author;
        year = _year;
    }

    public void Get_Info()
    {
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Author: {author}");
        Console.WriteLine($"Year: {year}");
        Console.WriteLine($"ISBN: {ISBN}");
        Console.WriteLine();
    }

    public static void Get_Info_Author(Book[] books, string author)
    {
        Console.WriteLine($"Книга написана {author}:");
        foreach (var book in books)
        {
            if (book.author == author)
            {
                book.Get_Info();
            }
        }
    }

    public static void Get_Info_Century(Book[] books, int century)
    {
        int beg_year = century * 100 - 100;
        int end_year = century * 100;

        Console.WriteLine($"Books written in {century} century:");
        foreach (var book in books)
        {
            if (book.year >= beg_year && book.year <= end_year)
            {
                book.Get_Info();
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Book[] books = new Book[10];
        books[0] = new Book("Book1", 23456, "Author1", 1991 );
        books[1] = new Book("Book2",  34567, "Author2",  2005 );
        books[2] = new Book("Book3",  45678, "Author3", 1875 );
        books[3] = new Book("Book4",  5786789, "Author1", 2010 );
        books[4] = new Book("Book5",  67890, "Author2", 1895 );
        books[5] = new Book("Book6",  78901,  "Author3", 1889 );
        books[6] = new Book("Book7",  789012,  "Author1",  1982 );
        books[7] = new Book("Book8",  90123, "Author2",  2018 );
        books[8] = new Book("Book9",  01234,  "Author3", 1888 );
        books[9] = new Book("Book10",  234567,  "Author1", 2005 );

        for (int i = 0; i < books.Length; i++)
        {
            books[i].Get_Info();       
        }

        string authorToSearch = "Author1";
        Book.Get_Info_Author(books, authorToSearch);

        int centuryToSearch = 20;
        Book.Get_Info_Century(books, centuryToSearch);
    }
}





































