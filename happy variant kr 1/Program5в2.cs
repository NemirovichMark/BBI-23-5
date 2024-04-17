using System.Xml.Linq;
using static System.Reflection.Metadata.BlobBuilder;

abstract class Book
{
    protected string _name;
    protected int _ISBN;
    protected string _author;
    protected int _year;
    public int Cost => _cost;
    protected int _cost;
    public string Author => _author;
    public Book(string name, int ISBN, string author, int year, int cost)
    {
        _name = name;
        _ISBN = ISBN;
        _author = author;
        _year = year;
        _cost = cost;
    }
    public virtual void Print()
    {
        Console.WriteLine("Автор   {0}\t Книга {1}\t ISBN {2}\t Год издания {3}\t Цена {4}\t",
                        _author, _name, _ISBN, _year, _cost);
    }
    protected virtual double GetCost()
    {
        return _cost;
    }
}
class PaperBook : Book
{
    private string _Pereplet;
    public PaperBook(string name, int ISBN, string author, int year, int cost, string pereplet) : base(name, ISBN, author, year, cost)
    {
        _Pereplet = pereplet;
    }
    protected override double GetCost()
    {
        double ExtraCost = 1;
        if (_Pereplet == "Твердый переплет")
        {
            ExtraCost *= 5;
        }
        return _cost + ExtraCost;
    }
    public override void Print()
    {
        double cost = GetCost();
        Console.WriteLine("Автор   {0}\t Книга {1}\t ISBN {2}\t Год издания {3}\t Переплет {4}\t Цена {5}\t",
                        _author, _name, _ISBN, _year, _Pereplet, cost);
    }
}
class ElectronicBook : Book
{
    private string _Format;
    public ElectronicBook(string name, int ISBN, string author, int year, int cost, string Format) : base(name, ISBN, author, year, cost)
    {
        _Format = Format;
    }
    protected override double GetCost()
    {
        double ExtraCost = 1;
        if (_Format == "PDF")
        {
            ExtraCost *= 3;
        }
        else if(_Format == "FB2")
        {
            ExtraCost *= 4;
        }
        else if (_Format == "EPUB")
        {
            ExtraCost *= 2;
        }
        return _cost + ExtraCost;
    }
    public override void Print()
    {
        double cost = GetCost();
        Console.WriteLine("Автор   {0}\t Книга {1}\t ISBN {2}\t Год издания {3}\t Формат {4}\t Цена {5}\t",
                        _author, _name, _ISBN, _year, _Format, cost);
    }

}
class AudioBook : Book
{
    private string _Zapic;
    public AudioBook(string name, int ISBN, string author, int year,int cost,string Zapic) : base(name, ISBN, author, year,cost)
    {
        _Zapic = Zapic;
    }
    protected override double GetCost()
    {
        double ExtraCost = 1;
        if (_Zapic == "Студия")
        {
            ExtraCost *= 10;
        }
        else if (_Zapic == "Любительская")
        {
            ExtraCost *= 5;
        }
        return _cost + ExtraCost;
    }
    public override void Print()
    {
        double cost = GetCost();
        Console.WriteLine("Автор   {0}\t Книга {1}\t ISBN {2}\t Год издания {3}\t Запись {4}\t Цена {5}\t",
                        _author, _name, _ISBN, _year, _Zapic, cost);
    }
    class Program
    {
        static void Main()
        {
            Book[] paperbooks = new Book[]
            {
            new PaperBook("Война и мир",12546, "Толстой", 1889, 2100,"Твердый переплет"),
            new PaperBook("Геометрия",54782, "Мерзляк", 2015,150, "Твердый переплет"),
            new PaperBook("Искра жизни ",32456, "Ремарк", 1984,322, "Твердый переплет"),
            new PaperBook("Пишисокращай",43567, "Иванов", 2019,1464, "Твердый переплет"),
            new PaperBook("1984 год  ",21332, "Оруэлл", 1949,800, "Твердый переплет")
            };
            Book[] electronicbooks = new Book[]
            {
            new ElectronicBook("Война и мир",12546, "Толстой", 1889,2100, "EPUB"),
            new ElectronicBook("Геометрия",54782, "Мерзляк", 2015,150, "FB2"),
            new ElectronicBook("Искра жизни ",32456, "Ремарк", 1984,322, "PDF"),
            new ElectronicBook("Пишисокращай",43567, "Иванов", 2019,1464, "EPUB"),
            new ElectronicBook("1984 год  ",21332, "Оруэлл", 1949,800, "PDF")
            };
            Book[] audiobooks = new Book[]
            {
            new AudioBook("Война и мир",12546, "Толстой", 1889, 2100, "Студия"),
            new AudioBook("Геометрия",54782, "Мерзляк", 2015,150, "Любительская"),
            new AudioBook("Искра жизни",32456, "Ремарк", 1984,322,"Любительская"),
            new AudioBook("Пишисокращай",43567, "Иванов", 2019,1464, "Студия"),
            new AudioBook("1984 год  ",21332, "Оруэлл", 1949, 800,"Любительская")
            };
            Sorting(paperbooks);
            Sorting(electronicbooks);
            Sorting(audiobooks);
            Console.WriteLine("Бумажные книги:");
            foreach (var book in paperbooks)
            {
                book.Print();
            }
            Console.WriteLine("Электронные книги:");
            foreach (var book in electronicbooks)
            {
                book.Print();
            }
            Console.WriteLine("Аудиокниги:");
            foreach (var book in audiobooks)
            {
                book.Print();
            }
            static void Sorting(Book[] c1)
            {
                int n = c1.Length;
                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = 0; j < n - i - 1; j++)
                    {
                        if (c1[j].Cost < c1[j + 1].Cost)
                        {
                            Book temp = c1[j];
                            c1[j] = c1[j + 1];
                            c1[j + 1] = temp;
                        }
                    }
                }

            }
            Book[] allBooks = new Book[paperbooks.Length + electronicbooks.Length + audiobooks.Length];
            obedinenie(allBooks, paperbooks, electronicbooks, audiobooks);
            Sorting(allBooks);
            Console.WriteLine("Все книги по убыванию цены:");
            foreach (var book in allBooks)
            {
                book.Print();
            }
            static void obedinenie(Book[] allBooks, Book[] paperbooks, Book[] electronicbooks, Book[] audiobooks)
            {
                int index = 0;
                foreach (Book books in paperbooks)
                {
                    allBooks[index++] = books;
                }
                foreach (Book books in electronicbooks)
                {
                    allBooks[index++] = books;
                }
                foreach (Book books in audiobooks)
                {
                    allBooks[index++] = books;
                }
            }
        }
    }
}
            
        