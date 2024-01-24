using CinemaTicket.Models.Abstract;

namespace CinemaTicket.Models
{
    public class Screening : CommonProperty
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int SahneId { get; set; }
        public Sahne Sahne { get; set; } 
        public DateTime ScreeningTime { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }

    }
}
