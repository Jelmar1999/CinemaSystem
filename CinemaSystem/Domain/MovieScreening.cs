using System;
using System.Collections.Generic;

namespace CinemaSystem.Domain
{
    public class MovieScreening
    {
        public DateTime dateAndTime;
        private double pricePerSeat;
        private Movie movie;
        private ICollection<MovieTicket> movieTickets;

        public MovieScreening(Movie movie, DateTime dateAndTime, double pricePerSeat)
        {
            this.dateAndTime = dateAndTime;
            this.pricePerSeat = pricePerSeat;
        }

        public double GetPricePerSeat()
        {
            return 0;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}