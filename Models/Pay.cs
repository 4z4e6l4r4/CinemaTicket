using CinemaTicket.Models.Abstract;
namespace CinemaTicket.Models
{
    public class Pay : CommonProperty
    {
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; } 
        public decimal PaymentAmount { get; set; } 
        public string PaymentMethod { get; set; } 
        public bool PaymentStatus { get; set; }
    }
}
