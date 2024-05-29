using ProtoBuf;
[ProtoContract]
public partial class GameCatalog : IGameCatalog
{
    private List<Game> games = new List<Game>();
    [ProtoMember(1)]
    public List<Game> Games
    {
        get { return games; }
        set { games = value; }
    }
    [ProtoMember(2)]
    public int Size
    {
        get { return games.Count; }
        set { }
    }
    public GameCatalog() { }
    public GameCatalog(List<Game> games)
    {
        this.games = games;
    }

    public void AddGame(Game game)
    {
        games.Add(game);
    }

    public void RemoveGame()
    {
        if (games.Count > 0)
        {
            games.RemoveAt(games.Count - 1);
        }
    }

    public void AddGame(Game[] games)
    {
        this.games.AddRange(games);
    }

    public void RemoveGame(int iGame)
    {
        if (iGame >= 0 && iGame < games.Count)
        {
            games.RemoveAt(iGame);
        }
    }

    public void DisplayCatalog()
    {
        Console.WriteLine("Catalog:");
        foreach (var game in games)
        {
            Console.WriteLine(game);
        }
    }
}


