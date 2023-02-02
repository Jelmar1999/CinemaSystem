using System.Collections.Generic;
using Newtonsoft.Json;

namespace CinemaSystem.Domain
{
    public class Movie
    {
        [JsonProperty]
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
            return $"title = {title}";
        }
    }
}