namespace app.main.songs;

public class LiveSingle : Song
{
    private int ticketAmount;
    private int ticketPrice;
    
    public LiveSingle(string title, string artist, int year, int ticketAmount, int ticketPrice) : base(title, artist, year)
    {
        this.ticketAmount = ticketAmount;
        this.ticketPrice = ticketPrice;
    }

    public int GetRevenue()
    {
        return ticketPrice * ticketAmount;
    }


    public override string ToString()
    {
        return base.ToString() + $" {ticketPrice}, {ticketAmount}";
    }
}