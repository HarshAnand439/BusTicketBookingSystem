using DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class BookingDTO
    {
        [Key]
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
        public int SeatNo { get; set; }


        public static explicit operator Booking(BookingDTO dto)
        {
            if (dto == null)
                return null;

            return new Booking
            {
                BookingId = dto.BookingId,
                ScheduleId = dto.ScheduleId,
                CustomerId = dto.CustomerId,
                SeatNo = dto.SeatNo
            };
        }

        public static implicit operator BookingDTO(Booking booking)
        {
            if (booking == null)
                return null;

            return new BookingDTO
            {
                BookingId = booking.BookingId,
                ScheduleId = booking.ScheduleId,
                CustomerId = booking.CustomerId,
                SeatNo = booking.SeatNo
            };
        }
    }
}
