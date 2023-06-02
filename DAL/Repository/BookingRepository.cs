using DAL.Models;
using DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly AppDbContext _context;

        public BookingRepository(AppDbContext context)
        {
            _context = context;
        }

        public ICollection<Booking> GetAllBookings()
        {
            return _context.Bookings.OrderBy(x => x.BookingId).ToList();
        }

        public Booking GetBookingById(int id)
        {
            return _context.Bookings.Where(x => x.BookingId == id).FirstOrDefault();
        }

        public bool IsSeatAvailable(int scheduleId, int seatNo)
        {
            var schedule = _context.Schedules.FirstOrDefault(s => s.ScheduleId == scheduleId);
            if (schedule == null)
            {
                return false;
            }

            int bookedSeats = _context.Bookings.Count(b => b.ScheduleId == scheduleId && b.SeatNo == seatNo);

            return bookedSeats < schedule.AvailSeats;
        }

        public bool CreateBooking(Booking booking)
        {
            if ((_context.Bookings.Add(booking)) != null)
            {
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public void UpdateBooking(Booking booking)
        {
            _context.Bookings.Update(booking);
            _context.SaveChanges();
        }

        public void DeleteBooking(Booking booking)
        {
            _context.Bookings.Remove(booking);
            _context.SaveChanges();
        }
    }
}
