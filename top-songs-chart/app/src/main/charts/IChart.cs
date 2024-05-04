using app.main.songs;

namespace app.main.charts;

public interface IChart
{
    public void AddSong(Song song);
    public void RemoveSong(Song song);
    public void AddSong(Song[] songs);

    public void RemoveSong(int id);
    public void DisplayChart();

}