using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using ProtoBuf;

[JsonDerivedType(typeof(SingleGame), typeDiscriminator: "Single Game")]
[JsonDerivedType(typeof(MultiplayerGame), typeDiscriminator: "Multiplayer Game")]
[JsonDerivedType(typeof(OnlineGame), typeDiscriminator: "Online Game")]

[XmlInclude(typeof(SingleGame))]
[XmlInclude(typeof(MultiplayerGame))]
[XmlInclude(typeof(OnlineGame))]
[ProtoInclude(7, typeof(SingleGame))]
[ProtoInclude(8, typeof(MultiplayerGame))]
[ProtoInclude(9, typeof(OnlineGame))]
[ProtoContract]
public abstract class Game 
{
    protected string title;
    private string genre;
    private int releaseYear;
    [ProtoMember(10)]
    public string Title
    {
        get { return title; }
        set { title = value ?? string.Empty; }
    }
    [ProtoMember(11)]
    public string Genre
    {
        get { return genre; }
        set { genre = value ?? string.Empty; }
    }
    [ProtoMember(12)]
    public int ReleaseYear
    {
        get { return releaseYear; }
        set { releaseYear = value; }
    }
    public Game(string title, string genre, int releaseYear)
    {
        this.title = title;
        this.genre = genre;
        this.releaseYear = releaseYear;
    }
    public Game() { }
    public override string ToString()
    {
        return $"Title: {title}, Genre: {genre}, Release Year: {releaseYear}";
    }
    public static bool operator >(Game a, Game b)
    {
        if (a.Title.CompareTo(b.Title) > 0) return true;
        else return false;
    }
    public static bool operator <(Game a, Game b)
    {
        if (a.Title.CompareTo(b.Title) < 0) return true;
        else return false;
    }
    public static bool operator ==(Game a, Game b)
    {
        if (a.Title.CompareTo(b.Title) == 0) return true;
        else return false;
    }
    public static bool operator !=(Game a, Game b)
    {
        if (a.Title.CompareTo(b.Title) == 0) return false;
        else return true;
    }
}
[ProtoContract]
[ProtoInclude(4, typeof(IConsoleable))]
[ProtoInclude(5, typeof(IComputerable))]
[ProtoInclude(6, typeof(IMobile))]
interface IPlatform
{
    public static string platform;
    public static string gameMode;
}
[ProtoContract]

interface IConsoleable : IPlatform
{
    void PlayOnConsole();
}
[ProtoContract]

interface IComputerable : IPlatform
{
    void PlayOnComputer();
}
[ProtoContract]

interface IMobile : IPlatform
{
    void PlayOnMobile();
}
[ProtoContract]
public class SingleGame : Game, IConsoleable, IComputerable
{
    private static string platform = "Console and Computer";
    private static string gameMode = "Single Game";
    [JsonPropertyOrder(1)]
    public string Platform
    {
        get { return platform; }
        set { platform = value ?? string.Empty; }
    }
    private double rating;
    [JsonPropertyOrder(2)]
    [ProtoMember(13)]
    public double Rating
    {
        get { return rating; }
        set { rating = value; }
    }
    [ProtoMember(16)]
    public string GameMode
    {
        get { return gameMode; }
        set { gameMode = value ?? string.Empty; }
    }
    public SingleGame() : base() { }
    public SingleGame(string Title, string Genre, int ReleaseYear, double Rating) : base(Title, Genre, ReleaseYear)
    {
        this.Rating = Rating;
    }
    public override string ToString()
    {
        return $"{base.ToString()}, Platform: {platform}, Game Rating: {rating}";
    }

    public void PlayOnConsole()
    {
        Console.WriteLine($"Playing {title} on Console...");
    }

    public void PlayOnComputer()
    {
        Console.WriteLine($"Playing {title} on Computer...");
    }
}
[ProtoContract]
public class MultiplayerGame : Game, IConsoleable, IComputerable, IMobile
{
    private static string platform = "Console, Computer and Mobile";
    private static string gameMode = "Multiplayer Game";
    [JsonPropertyOrder(1)]
    public string Platform
    {
        get { return platform; }
        set { platform = value ?? string.Empty; }
    }
    private int maxPlayers;
    [JsonPropertyOrder(2)]
    [ProtoMember(14)]
    public int MaxPlayers
    {
        get { return maxPlayers; }
        set { maxPlayers = value; }
    }
    [ProtoMember(17)]
    public string GameMode
    {
        get { return gameMode; }
        set { gameMode = value ?? string.Empty; }
    }
    public MultiplayerGame() : base() { }
    public MultiplayerGame(string Title, string Genre, int ReleaseYear, int maxPlayers) : base(Title, Genre, ReleaseYear)
    {
        this.maxPlayers = maxPlayers;
    }

    public void PlayOnConsole()
    {
        Console.WriteLine($"Playing {title} on Console...");
    }

    public void PlayOnComputer()
    {
        Console.WriteLine($"Playing {title} on Computer...");
    }

    public void PlayOnMobile()
    {
        Console.WriteLine($"Playing {title} on Mobile...");
    }
    public override string ToString()
    {
        return $"{base.ToString()}, Platform: {platform}, Max Players: {MaxPlayers}";
    }
}
[ProtoContract]
public class OnlineGame : Game, IComputerable, IMobile
{
    private static string platform = "Computer and Mobile";
    private static string gameMode = "Online Game";
    [JsonPropertyOrder(1)]
    public string Platform
    {
        get { return platform; }
        set { platform = value ?? string.Empty; }
    }
    private bool seasonPass;
    [JsonPropertyOrder(2)]
    [ProtoMember(15)]
    public bool SeasonPass
    {
        get { return seasonPass; }
        set { seasonPass = value; }
    }
    [ProtoMember(18)]
    public string GameMode
    {
        get { return gameMode; }
        set { gameMode = value ?? string.Empty; }
    }
    public OnlineGame() : base() { }
    public OnlineGame(string Title, string Genre, int ReleaseYear, bool SeasonPass) : base(Title, Genre, ReleaseYear)
    {
        this.SeasonPass = SeasonPass;
    }

    public void PlayOnComputer()
    {
        Console.WriteLine($"Playing {title} on Computer...");
    }

    public void PlayOnMobile()
    {
        Console.WriteLine($"Playing {title} on Mobile...");
    }
    public override string ToString()
    {
        return $"{base.ToString()}, Platform: {platform}, Season Pass: {SeasonPass}";
    }
}
[ProtoContract]
[ProtoInclude(3, typeof(GameCatalog))]
interface IGameCatalog
{
    void AddGame(Game game);
    void RemoveGame();
    void AddGame(Game[] games);
    void RemoveGame(int iGame);
    void DisplayCatalog();
}
