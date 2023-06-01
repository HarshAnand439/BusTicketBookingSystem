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

        /*public IEnumerable<Booking> GetAllBookings()
        {
            return _context.Bookings.Include(b => b.Schedule).Include(b => b.Customer);
        }

        public Booking GetBookingById(int id)
        {
            return _context.Bookings.Include(b => b.Schedule).Include(b => b.Customer).FirstOrDefault(b => b.BookingId == id);
        }

        public void CreateBooking(Booking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();
        }

        public void UpdateBooking(Booking booking)
        {
            _context.Entry(booking).State = EntityState.Modified;
            _context.SaveChanges();
        }

        *//*public void DeleteBooking(int id)
        {
            Booking booking = _context.Bookings.Find(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                _context.SaveChanges();
            }
        }*//*

        public void DeleteBooking(Booking booking)
        {
            _context.Bookings.Remove(booking);
            _context.SaveChanges();
        }*/

        public ICollection<Booking> GetAllBookings()
        {
            return _context.Bookings.OrderBy(x => x.BookingId).ToList();
        }

        public Booking GetBookingById(int id)
        {
            return _context.Bookings.Where(x => x.BookingId == id).FirstOrDefault();
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
