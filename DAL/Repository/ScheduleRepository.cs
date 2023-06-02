using DAL.Data;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly AppDbContext _context;

        public ScheduleRepository(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        public ICollection<Schedule> GetAllSchedules()
        {
            return _context.Schedules.OrderBy(x => x.ScheduleId).ToList();
        }

        public Schedule GetScheduleById(int id)
        {
            return _context.Schedules.Where(x => x.ScheduleId == id).FirstOrDefault();
        }

        public bool CreateSchedule(Schedule schedule)
        {
            if (_context.Schedules.Add(schedule) != null)
            {
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public void UpdateSchedule(Schedule schedule)
        {
            _context.Schedules.Update(schedule);
            _context.SaveChanges();
        }

        public void DeleteSchedule(Schedule schedule)
        {
            _context.Schedules.Remove(schedule);
            _context.SaveChanges();
        }

        public bool HasAssociatedBookings(int scheduleId)
        {
            // Check if the schedule has any associated bookings
            return _context.Bookings.Any(b => b.ScheduleId == scheduleId);
        }

        public async Task<int> GetAvailableSeatsAsync(int scheduleId)
        {
            var schedule = await _context.Schedules.FindAsync(scheduleId);
            if (schedule == null)
            {
                throw new ArgumentException("Invalid schedule ID");
            }

            var bookedSeats = await _context.Bookings
                .Where(b => b.ScheduleId == scheduleId)
                .Select(b => b.SeatNo)
                .DefaultIfEmpty(0)
                .SumAsync();

            return schedule.AvailSeats - bookedSeats;
        }
    }
}
