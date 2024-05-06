using app.main.songs;

namespace app.main.charts;

public partial class Chart
{
    public List<ChartSong> SelectByYear(int year)
    {
        List<ChartSong> selected = new List<ChartSong>();
        foreach (ChartSong song in songs)
        {
            if (song.Year == year)
            {
                selected.Add(song);
            }
        }

        return selected;
    }

    public List<ChartSong> SelectedByYear(int yearMin, int yearMax)
    {
        List<ChartSong> selected = new List<ChartSong>();
        foreach (ChartSong song in songs)
        {
            if (song.Year >= yearMin && song.Year <= yearMax)
            {
                selected.Add(song);
            }
        }

        return selected;
    }
}