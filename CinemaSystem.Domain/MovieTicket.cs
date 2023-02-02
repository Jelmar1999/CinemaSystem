using Newtonsoft.Json;

namespace CinemaSystem.Domain
{
    public class MovieTicket
    {
        [JsonProperty]
        private int rowNr;
        [JsonProperty]
        private int seatNr;
        [JsonProperty]
        private bool isPremium;
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
            return true;
        }

        public double GetPrice()
        {
            return 0;
        }

        public override string ToString()
        {
            return $"rowNr = {this.rowNr}, seatNr = {this.seatNr}, isPremium = {this.isPremium}, screening = {movieScreening.ToString()}";
        }
    }
}