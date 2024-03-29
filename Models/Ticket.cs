﻿using CinemaTicket.Models.Abstract;
using System.ComponentModel.DataAnnotations.Schema;
namespace CinemaTicket.Models
{
    public class Ticket : CommonProperty
    {
        public int ScreeningId { get; set; }
        public Screening Screening { get; set; } 
        public string SeatNumber { get; set; }
        [Column(TypeName = "decimal(15, 1)")]
        public decimal Price { get; set; }
        public DateTime SaleDate { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual Pay Pay { get; set; }


    }
} 
