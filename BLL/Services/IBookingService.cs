using BLL.DTOs;
using DAL.Models;
using DAL.Repository;

namespace BLL.Services
{
    public interface IBookingService
    {
        public IEnumerable<Booking> GetAllBookings();
        public Booking GetBookingById(int id);
        public void CreateBooking(Booking booking);
        public void UpdateBooking(Booking booking);
        public void DeleteBooking(Booking booking);
    }
}
