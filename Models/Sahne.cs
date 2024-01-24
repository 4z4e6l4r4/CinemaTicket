using CinemaTicket.Models.Abstract;

namespace CinemaTicket.Models
{
    public class Sahne : CommonProperty
    {
        public int SeatCapacity { get; set; } 
        public string SceneType { get; set; }
        public virtual ICollection<Screening> Screenings { get; set; }

    }
}
