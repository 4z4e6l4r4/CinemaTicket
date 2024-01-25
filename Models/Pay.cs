using CinemaTicket.Models.Abstract;
using System.ComponentModel.DataAnnotations.Schema;
namespace CinemaTicket.Models
{
    public class Pay : CommonProperty
    {
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
        [Column(TypeName = "decimal(15, 1)")]
        public decimal PaymentAmount { get; set; } 
        public string PaymentMethod { get; set; } 
        public bool PaymentStatus { get; set; }
    }
}
