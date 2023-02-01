using System.Collections.Generic;

namespace CinemaSystem.Domain
{
    public class Movie
    {
        private string title;
        private ICollection<MovieScreening> movieScreenings;

        public Movie(string title)
        {
            this.title = title;
        }

        public void AddScreening(MovieScreening screening)
        {
            this.movieScreenings.Add(screening);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}