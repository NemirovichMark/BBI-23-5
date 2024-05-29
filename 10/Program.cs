using System.Reflection.Metadata;
using System.Text.Json;
using System.Xml.Serialization;

class Program
{
    static void Main()
    {
        GameCatalog catalog = new GameCatalog();
        Game[] games =
        {
            new OnlineGame("Counter-Strike 2", "Shooter", 2012, false),
            new OnlineGame("Dota 2", "MOBA", 2013, true),
            new OnlineGame("PUBG: BATTLEGROUNDS", "Battle Royale", 2017, true),
            new OnlineGame("Apex Legends", "Battle Royale", 2020, true),
            new SingleGame("Grand Theft Auto V", "Action-adventure", 2013, 97.01),
            new OnlineGame("Lost Ark", "MMORPG", 2019, true),
            new MultiplayerGame("Stardew Valley", "Life sim", 2016, 4),
            new OnlineGame("Rust", "Survival sim", 2018, true),
            new OnlineGame("Team Fortress 2", "Shooter", 2007, false),
            new SingleGame("Fallout 4", "Action-RPG", 2015, 85.67),
            new OnlineGame("War Thunder", "War sim", 2013, true),
            new OnlineGame("Destiny 2", "Shooter", 2019, true),
            new SingleGame("Hades II", "Rogue-like", 2024, 81),
            new OnlineGame("Warframe", "Action-RPG", 2013, true),
            new MultiplayerGame("HELLDIVERS 2", "Shooter", 2024, 4),
            new MultiplayerGame("Monster Hunter: World", "Action-RPG", 2017, 4),
            new OnlineGame("Tom Clansy's Rainbow Six Siege", "Shooter", 2015, true),
            new MultiplayerGame("Sid Meier's Civilization VI", "Turn-based strategy", 2016, 12),
            new MultiplayerGame("Baldur's Gate 3", "RPG", 2023, 4),
            new MultiplayerGame("Hearts of Iron IV", "Global strategy", 2016, 8),
            new SingleGame("ELDEN RING", "Action-RPG", 2022, 94),
            new SingleGame("Hades", "Rogue-like", 2020, 92),
            new MultiplayerGame("Don't Starve Together", "Survival sim", 2016, 4),
            new MultiplayerGame("Total War: WARHAMMER III", "Global strategy", 2022, 8),
            new MultiplayerGame("PAYDAY 2", "Shooter", 2013, 4),
            new OnlineGame("Dead by Daylight", "Survival horror", 2016, false),
            new MultiplayerGame("Dying Light", "Action-adventure", 2015, 4),
            new SingleGame("RimWorld", "Construction and management sim", 2018, 87),
            new OnlineGame("Overwatch 2", "Shooter", 2023, true),
            new SingleGame("The Sims 4", "Life sim", 2014, 69.64)
        };
        Game[] gamesToAdd =
        {
            new OnlineGame("VALORANT", "Shooter", 2020, true),
            new MultiplayerGame("Terraria", "Action-adventure", 2011, 4),
            new SingleGame("Manor Lords", "City-building sim", 2024, 75),
            new OnlineGame("ARK: SUrvival Evolved", "Survival sim", 2017, false),
            new MultiplayerGame("Europa Universalis IV", "Global strategy", 2013, 12),
            new SingleGame("Red Dead Redemption 2", "Action-adventure", 2018, 96.45),
            new SingleGame("Fallout: New Vegas", "RPG", 2010, 85),
            new SingleGame("The Elder Scrolls V: Skyrim", "Action-RPG", 2011, 94.8),
            new SingleGame("Crusader Kings III", "Global strategy", 2020, 91),
            new OnlineGame("Sea of Thieves", "Action-adventure", 2018, false)
        };
        catalog.AddGame(gamesToAdd);
        
        MySerializer[] serializers =
        {
            new MyJsonSerializer(),
            new MyXmlSerializer(),
            new MyBinarySerializer()
        };

        string[] FileNames = { "raw_data.json", "raw_data.xml", "raw_data.bin", "data.json", "data.xml", "sorted_data.bin"};  // сделать один такой массив и при первом проигрыше добавлять raw
        string CurrentDirectory = Environment.CurrentDirectory;
        string path = Path.Combine(CurrentDirectory, "Файлы к работе");
        if (!Directory.Exists(path)) Directory.CreateDirectory(path);
        for (int i = 0; i < 2; i++) serializers[i].Write(catalog, Path.Combine(path, FileNames[i]));
        for (int i = 0; i < 10; i++) catalog.AddGame(games[i]); 
        catalog.AddGame(games[16]);
        serializers[0].Write(catalog, Path.Combine(path, FileNames[3]));
        for (int i = 0; i < 5; i++) catalog.RemoveGame(i);
        catalog.RemoveGame(7);
        serializers[1].Write(catalog, Path.Combine(path, FileNames[4]));

        for (int i = 17; i < 27; i++) catalog.AddGame(games[i]);
        serializers[2].Write(catalog, Path.Combine(path, FileNames[2]));
        catalog.SortCatalog();
        serializers[2].Write(catalog, Path.Combine(path, FileNames[5]));
        

        Console.WriteLine("From array");
        catalog.DisplayCatalog();
        Console.WriteLine();

        for (int i = 0; i < FileNames.Length; i++)
        {
            Console.WriteLine($"From {FileNames[i]}");
            GameCatalog catalogtemp = serializers[i % 3].Read<GameCatalog>(Path.Combine(path, FileNames[i]));
            catalogtemp.DisplayCatalog();
            Console.WriteLine();
        }

        Console.WriteLine("Platforms and game modes");
        catalog.DisplayPreference();
        Console.WriteLine();
        
        int k = catalog.Size;
        for (int i = 0; i < k; i++)
        {
            catalog.RemoveGame();
        }
        Console.WriteLine("Cleared");
        catalog.DisplayCatalog();
    }
}

