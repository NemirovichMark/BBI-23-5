using app.main.songs;

namespace app.main.charts;

public partial class Chart
{
    public void SortByTitleAsc()
    {
        int min = 0;
        for (int i = 0; i < songs.Count; i++)
        {
            min = i;
            for (int j = i + 1; j < songs.Count; j++)
            {
                if (songs[j].Title.CompareTo(songs[min].Title) < 0)
                {
                    min = j;
                }
            }
            ChartSong temp = songs[i];
            songs[i] = songs[min];
            songs[min] = temp;

        }
    }

    public void SortByTitleDesc()
    {
        SortByTitleAsc();
        songs.Reverse();
    }

    public void SortByYearAsc()
    {
        int min = 0;
        for (int i = 0; i < songs.Count; i++)
        {
            min = i;
            for (int j = i + 1; j < songs.Count; j++)
            {
                if (songs[j].Year < songs[min].Year)
                {
                    min = j;
                }
            }

            ChartSong temp = songs[i];
            songs[i] = songs[min];
            songs[min] = temp;
            
        }
    }
    
    public void SortByYearDesc()
    {
        SortByYearAsc();
        songs.Reverse();
    }
}