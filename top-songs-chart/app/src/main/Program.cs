using app.main.charts;
using app.main.serialize;
using app.main.songs;

namespace app.main;

static class Program
{
    private static void PrintCharts(MyJsonSerializer<Chart[]> myJsonSerializer, string path, string file)
    {
        Chart[] charts = myJsonSerializer.Read(path + file);
        Console.WriteLine(file);
        foreach (Chart chart in charts)
        {
            chart.DisplayChart();
            Console.WriteLine();
        }
    }

    private static void PrintCharts(MyXmlSerializer<Chart[]> myXmlSerializer, string path, string file)
    {
        Chart[] charts = myXmlSerializer.Read(path + file);
        Console.WriteLine(file);
        foreach (Chart chart in charts)
        {
            chart.DisplayChart();
            Console.WriteLine();
        }
    }

    private static void DeleteFile(string path, string file)
    {
        if (File.Exists(path + file))
        {
            File.Delete(path + file);
        }
    }

    public static void Main(string[] args)
    {
        Chart[] charts =
        {
            new Chart("RussiaChart"),
            new Chart("BelarusChart"),
            new Chart("WorldChart")
        };

        ChartSong[] songs = new ChartSong[25];
        for (int i = 0; i < 25; i++)
        {
            songs[i] = new ChartSong(
                Faker.Lorem.Words(100).ToList()[Faker.RandomNumber.Next(1, 99)],
                Faker.Name.FullName(),
                Faker.RandomNumber.Next(1950, 2024),
                Faker.RandomNumber.Next(100, 1000000),
                Faker.Enum.Random<Genre>()
            );
        }

        for (int i = 0; i < 3; i++)
        {
            HashSet<int> set = new HashSet<int>();
            for (int j = 0; j < 10; j++)
            {
                int num = Faker.RandomNumber.Next(0, 24);
                while (set.Contains(num))
                {
                    num = Faker.RandomNumber.Next(0, 24);
                }

                charts[i].AddSong(songs[num]);
                set.Add(num);
            }
        }

        string path = "/Users/laviprog/Projects/top-songs-chart/app/src/resources/JSON/";
        string file1 = "raw_data.json";
        string file2 = "data.json";
        string file3 = "sort_data.json";
        DeleteFile(path, file1);
        DeleteFile(path, file2);
        DeleteFile(path, file3);
        MyJsonSerializer<Chart[]> myJsonSerializer = new MyJsonSerializer<Chart[]>();
        myJsonSerializer.Write(charts, path + file1);
        for (int i = 0; i < 3; i++)
        {
            charts[i].SortByYearAsc();
        }

        myJsonSerializer.Write(charts, path + file2);

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                charts[i].AddSong(
                    new ChartSong(
                        Faker.Lorem.Words(100).ToList()[Faker.RandomNumber.Next(1, 99)],
                        Faker.Name.FullName(),
                        Faker.RandomNumber.Next(1950, 2024),
                        Faker.RandomNumber.Next(100, 1000000),
                        Faker.Enum.Random<Genre>()
                    )
                );
            }

            charts[i].SortByTitleAsc();
        }

        myJsonSerializer.Write(charts, path + file3);

        PrintCharts(myJsonSerializer, path, file1);
        PrintCharts(myJsonSerializer, path, file2);
        PrintCharts(myJsonSerializer, path, file3);


        string file4 = "raw_data.xml";
        string file5 = "data.xml";
        string path2 = "/Users/laviprog/Projects/top-songs-chart/app/src/resources/XML/";
        DeleteFile(path2, file4);
        DeleteFile(path2, file5);
        MyXmlSerializer<Chart[]> myXmlSerializer = new MyXmlSerializer<Chart[]>();
        for (int i = 0; i < 3; i++)
        {
            foreach (ChartSong song in charts[i].SelectedByYear(0, 2019))
            {
                charts[i].RemoveSong(song);
            }
        }

        myXmlSerializer.Write(charts, path2 + file4);
        LiveSingle[] liveSingles = new LiveSingle[10];
        for (int i = 0; i < 10; i++)
        {
            liveSingles[i] = new LiveSingle(
                Faker.Lorem.Words(100).ToList()[Faker.RandomNumber.Next(1, 99)],
                Faker.Name.FullName(),
                Faker.RandomNumber.Next(1950, 2024),
                Faker.RandomNumber.Next(1000, 100000),
                Faker.RandomNumber.Next(100, 1000)
            );
        }

        int max = 0;
        for (int i = 0; i < liveSingles.Length; i++)
        {
            max = i;
            for (int j = i + 1; j < liveSingles.Length; j++)
            {
                if (liveSingles[j].GetRevenue() > liveSingles[max].GetRevenue())
                {
                    max = j;
                }
            }

            LiveSingle temp = liveSingles[i];
            liveSingles[i] = liveSingles[max];
            liveSingles[max] = temp;
        }

        Console.WriteLine("LiveSingles");
        for (int i = 0; i < liveSingles.Length; i++)
        {
            Console.WriteLine(i + 1 + " " + liveSingles[i]);
        }

        Console.WriteLine();

        ChartSong[] chartSongs = new ChartSong[3];
        for (int i = 0; i < 3; i++)
        {
            chartSongs[i] = new ChartSong(
                Faker.Lorem.Words(100).ToList()[Faker.RandomNumber.Next(1, 99)],
                Faker.Name.FullName(),
                Faker.RandomNumber.Next(1950, 2024),
                Faker.RandomNumber.Next(100, 1000000),
                Faker.Enum.Random<Genre>()
            );
        }

        for (int i = 0; i < 3; i++)
        {
            charts[i].AddSong(
                new ChartSong(
                    Faker.Lorem.Words(100).ToList()[Faker.RandomNumber.Next(1, 99)],
                    Faker.Name.FullName(),
                    Faker.RandomNumber.Next(1950, 2024),
                    Faker.RandomNumber.Next(100, 1000000),
                    Faker.Enum.Random<Genre>()
                )
            );
            charts[i].AddSong(chartSongs);
            charts[i].SortByTitleAsc();
        }

        myXmlSerializer.Write(charts, path2 + file5);

        PrintCharts(myXmlSerializer, path2, file4);
        PrintCharts(myXmlSerializer, path2, file5);
    }
}