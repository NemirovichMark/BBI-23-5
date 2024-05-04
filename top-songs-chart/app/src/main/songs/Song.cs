
namespace app.main.songs;

[Serializable]
public abstract class Song
{
    private string title;
    private string artist;
    private int year;

    protected Song()
    {
        
    }
    
    protected Song(string title, string artist, int year)
    {
        this.title = title;
        this.artist = artist;
        this.year = year;
    }

    public int Year
    {
        get => year;
        set => year = value;
    }

    public string Artist
    {
        get => artist;
        set => artist = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Title
    {
        get => title;
        set => title = value ?? throw new ArgumentNullException(nameof(value));
    }

    public override string ToString()
    {
        return $"{title}, {artist}, {year},";
    }
}