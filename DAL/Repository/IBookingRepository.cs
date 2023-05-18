using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public interface IBookingRepository
    {
        public IEnumerable<Booking> GetAllBookings();
        public Booking GetBookingById(int id);
        public void CreateBooking(Booking booking);
        public void UpdateBooking(Booking booking);
        public void DeleteBooking(Booking booking);
    }
}
