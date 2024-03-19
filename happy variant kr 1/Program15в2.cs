using System.Xml.Linq;
using static System.Reflection.Metadata.BlobBuilder;

abstract class Watching
{
    protected string _name;
    protected string _discription;
    protected string _sost;
    protected int _year;
    public int NameLenght => _name.Length;
    public bool Watched => _watched;
    protected int _cost;
    protected bool _watched;
    public Watching(string name)
    {
        _name = name;
        _discription = $"Описание для {_name} не задано";
        _sost = "Не просмотрено";
        _watched = false;
    }

    public void SetDescription(string description)
    {
        if (description.Length >= 20 & description.Length <= 200)
        {
            _discription = description;
            _watched = true;
            _sost = "Просмотрено";
        }
        else { Console.WriteLine("Описание должно быть не короче 20 символов и не длиннее 200"); }
    }
    public virtual void Print()
    {
        Console.WriteLine("Фильм   {0}\n Описание {1}\n Состояние",
                         _name, _discription, _sost);
    }

}
class Movie : Watching
{
    private string _AgeRating;
    private int _Dlit;
    public Movie(string name, string agerating, int dlit) : base (name)
    {
        _AgeRating = agerating;
        _Dlit = dlit;
    }
    public override void Print()
    {
        base.Print();
        Console.WriteLine($"Возрастной рейтинг: {_AgeRating}\nДлительность: {_Dlit} минут\n");
    }
}
class Program
{
    static void Main()
    {
        Movie[] movies = new Movie[]
        {
            new Movie("Вода", "18+", 120 ),
            new Movie("Земля", "18+", 150 ),
            new Movie("Граф", "16+", 50 ),
            new Movie("Мечта","12+", 130 ),
            new Movie("Природа","18+", 125 ),
        };
        Movie[] series = new Movie[]
       {
            new Movie("Огонь", "12+", 40),
            new Movie("Свадьба", "18+", 150),
            new Movie("Преданность", "16+", 60),
            new Movie("Звезда", "16+", 100),
            new Movie("Одиночество", "18+", 10)
       };
        series[0].SetDescription("Сериал об интересном и прекрасном");
        series[1].SetDescription("Сериал об ужасном и страшном");
        movies[0].SetDescription("Фильм о милом и добром"); ;
        movies[1].SetDescription("Фильм о людях и природе");
        movies[2].SetDescription("Фильм об интересном приключении");


        static void Sorting(Watching[] c1)
        {
            int n = c1.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (c1[j].NameLenght < c1[j + 1].NameLenght)
                    {
                        Watching temp = c1[j];
                        c1[j] = c1[j + 1];
                        c1[j + 1] = temp;
                    }
                }
            }

        }
        Watching[] allFilms = new Watching[series.Length + movies.Length];
        obedinenie(allFilms, series, movies);
        foreach (var book in allFilms)
        {
            book.Print();
        }
        Console.WriteLine("---------------");
        Sorting(allFilms);
        Console.WriteLine("Все фильмы по убыванию:");
        foreach (var book in allFilms)
        {
            if (book.Watched == true)
            { book.Print(); }
            
        }
        static void obedinenie(Watching[] allFilms, Watching[] movies, Watching[] series)
        {
            int index = 0;
            foreach (Watching books in movies)
            {
                allFilms[index++] = books;
            }
            foreach (Watching books in series)
            {
                allFilms[index++] = books;
            }

        }
    }
}


