public partial class GameCatalog
{
    public void SortCatalog()
    {
        for (int i = 0; i < games.Count; i++)
        {
            var val = games[i];
            for (int j = i - 1; j >= 0;)
            {
                if (val < games[j])
                {
                    games[j + 1] = games[j];
                    j--;
                    games[j + 1] = val;
                }
                else break;
            }
        }
    }
}