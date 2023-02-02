using System;
using System.Collections.Generic;

namespace CinemaSystem.Domain
{
    public class MovieScreening
    {
        private DateTime dateAndTime;
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
            return base.ToString();
        }
    }
}