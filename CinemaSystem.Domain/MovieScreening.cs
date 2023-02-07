using Newtonsoft.Json;

namespace CinemaSystem.Domain
{
    public class MovieScreening
    {
        [JsonProperty]
        private DateTime dateAndTime;
        [JsonProperty]
        private double pricePerSeat;
        [JsonProperty]
        private Movie movie;

        public MovieScreening(Movie movie, DateTime dateAndTime, double pricePerSeat)
        {
            this.movie = movie;
            this.dateAndTime = dateAndTime;
            this.pricePerSeat = pricePerSeat;
        }

        public double GetPricePerSeat()
        {
            return pricePerSeat;
        }

        public bool inWeekend()
        {
            switch (dateAndTime.DayOfWeek)
            {
                case DayOfWeek.Friday:
                case DayOfWeek.Saturday:
                case DayOfWeek.Sunday:
                    return true;
                case DayOfWeek.Monday:
                case DayOfWeek.Tuesday:
                case DayOfWeek.Wednesday:
                case DayOfWeek.Thursday:
                default:
                    return false;
            }
        }

        public override string ToString()
        {
            return $"dateTime = {dateAndTime}, priceperseat = {pricePerSeat}, movie = {movie}";
        }
    }
}