using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Booking
    {
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
