using System.Text.Json.Serialization;
using app.main.songs;

namespace app.main.charts;

[Serializable]
public partial class Chart : IChart
{
    private string name;
    private List<ChartSong> songs;

    public Chart()
    {
    }

    public Chart(string name)
    {
        this.name = name;
        songs = new List<ChartSong>();
    }

    [JsonConstructor]
    public Chart(string name, List<ChartSong> songs)
    {
        this.name = name;
        this.songs = songs;
    }

    public List<ChartSong> Songs
    {
        get => songs;
        set => songs = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Name
    {
        get => name;
        set => name = value ?? throw new ArgumentNullException(nameof(value));
    }

    public void AddSong(Song song)
    {
        songs.Add((ChartSong)song);
    }

    public void RemoveSong(Song song)
    {
        songs.Remove((ChartSong)song);
    }

    public void AddSong(Song[] arraySong)
    {
        foreach (Song song in arraySong)
        {
            songs.Add((ChartSong)song);
        }
    }

    public void RemoveSong(int id)
    {
        songs.RemoveAt(id);
    }

    public void DisplayChart()
    {
        Console.WriteLine("Chart: " + name);
        for (int i = 0; i < songs.Count; i++)
        {
            Console.WriteLine(i + 1 + " " + songs[i]);
        }
    }
}
