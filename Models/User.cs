using CinemaTicket.Models.Abstract;

namespace CinemaTicket.Models
{
    public class User : CommonProperty
    {
        public string Email { get; set; }
        public string Password { get; set; } 
        public string Role { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }


    }
}
