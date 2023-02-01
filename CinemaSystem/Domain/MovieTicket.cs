namespace CinemaSystem.Domain
{
    public class MovieTicket
    {
        private int rowNr;
        private int seatNr;
        private bool isPremium;
        public MovieScreening movieScreening;

        public MovieTicket(MovieScreening movieScreening, bool isPremiumReservation, int rowNr, int seatNr)
        {
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
            return base.ToString();
        }
    }
}