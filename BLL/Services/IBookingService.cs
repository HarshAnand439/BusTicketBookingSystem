using BLL.DTOs;
using DAL.Models;
using DAL.Repository;

namespace BLL.Services
{
    public interface IBookingService
    {
        public ICollection<Booking> GetAllBookings();
        Booking GetBookingById(int id);
        bool CreateBooking(BookingDTO booking);
        void UpdateBooking(Booking booking);
        void DeleteBooking(Booking booking);
    }
}
