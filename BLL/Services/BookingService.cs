using BLL.DTOs;
using DAL.Models;
using DAL.Repository;

namespace BLL.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public ICollection<Booking> GetAllBookings()
        {
            return _bookingRepository.GetAllBookings();
        }
        public Booking GetBookingById(int id)
        {
            return _bookingRepository.GetBookingById(id);
        }
        public bool CreateBooking(BookingDTO booking)
        {
            /*// Check if the seat is available in the schedule
            if (!_bookingRepository.IsSeatAvailable(booking.ScheduleId, booking.SeatNo))
            {
                // Seat is already booked
                return false;
            }*/

            var temp = new Booking
            {
                ScheduleId = booking.ScheduleId,
                Schedule = booking.Schedule,
                CustomerId = booking.CustomerId,
                Customer = booking.Customer,
                SeatNo = booking.SeatNo
            };
            if (_bookingRepository.CreateBooking(temp))
            {
                return true;
            }
            return false;
        }
        public void UpdateBooking(Booking booking)
        {
            _bookingRepository.UpdateBooking(booking);
        }
        public void DeleteBooking(Booking booking)
        {
            var temp = _bookingRepository.GetBookingById(booking.BookingId);
            if (temp != null)
            {
                _bookingRepository.DeleteBooking(temp);
            }
            else
            {
                return;
            }
        }
    }
}
