using DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class BookingDTO
    {
        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int SeatNo { get; set; }


        public static explicit operator Booking(BookingDTO dto)
        {
            if (dto == null)
                return null;

            return new Booking
            {
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
                ScheduleId = booking.ScheduleId,
                CustomerId = booking.CustomerId,
                SeatNo = booking.SeatNo
            };
        }
    }
}
