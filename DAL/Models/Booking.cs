﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Booking
    {
        /*[Key]
        [Required]
        public int BookingId { get; set; }

        [ForeignKey("Schedule")]
        public int ScheduleId { get; set; }
        [Required]
        public Schedule Schedule { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        [Required]
        public Customer Customer { get; set; }

        [Required]
        public int SeatNo { get; set; }*/

        [Key]
        public int BookingId { get; set; }

        [ForeignKey("Schedule")]
        public int ScheduleId { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        [Range(1, int.MaxValue)]
        public int SeatNo { get; set; }

        // Navigation properties
        public Schedule? Schedule { get; set; }
        public Customer? Customer { get; set; }
    }
}