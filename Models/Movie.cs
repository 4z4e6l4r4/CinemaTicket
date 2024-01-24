using CinemaTicket.Models.Abstract;

namespace CinemaTicket.Models
{
    public class Movie : CommonProperty
    {
        public string PosterImageUrl { get; set; }
        public string Director { get; set; }
        public int Duration { get; set; } 
        public string Genre { get; set; } 
        public DateTime ReleaseDate { get; set; } 
        public double? IMDBScore { get; set; }
        public virtual ICollection<Screening> Screenings { get; set; }

    }
}
