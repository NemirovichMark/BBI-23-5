public partial class GameCatalog
{
    public void DisplayPreference()
    {
        foreach (var game in games) 
        {
            if (game.GetType() == typeof(SingleGame)) 
            {
                Console.WriteLine($"Title: {game.Title}, Platform: {((SingleGame)game).Platform}, Game Mode: {((SingleGame)game).GameMode}");
            }
            else if (game.GetType() == typeof(MultiplayerGame)) 
            {
                Console.WriteLine($"Title: {game.Title}, Platform: {((MultiplayerGame)game).Platform}, Game Mode: {((MultiplayerGame)game).GameMode}");
            }
            else
            {
                Console.WriteLine($"Title: {game.Title}, Platform: {((OnlineGame)game).Platform}, Game Mode: {((OnlineGame)game).GameMode}");
            }
        }
    }
}