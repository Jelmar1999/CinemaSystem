namespace CinemaSystem.Domain;

using Newtonsoft.Json;

public class MovieTicket
{
    [JsonProperty] private int rowNr;
    [JsonProperty] private int seatNr;
    [JsonProperty] private bool isPremium;
    public MovieScreening movieScreening;

    public MovieTicket(MovieScreening movieScreening, bool isPremiumReservation, int rowNr, int seatNr)
    {
        this.movieScreening = movieScreening;
        this.rowNr = rowNr;
        this.seatNr = seatNr;
        this.isPremium = isPremiumReservation;
    }

    public bool IsPremiumTicket()
    {
        return isPremium;
    }

    public double GetPrice()
    {
        return movieScreening.GetPricePerSeat();
    }

    public override string ToString()
    {
        return
            $"rowNr = {this.rowNr}, seatNr = {this.seatNr}, isPremium = {this.isPremium}, screening = {movieScreening.ToString()}";
    }
}