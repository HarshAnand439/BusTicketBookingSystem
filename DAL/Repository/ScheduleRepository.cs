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

        /*public async Task<IEnumerable<Schedule>> GetAllSchedules()
        {
            return await _dbContext.Schedules.ToListAsync();
        }

        public async Task<Schedule> GetScheduleById(int id)
        {
            return await _dbContext.Schedules.FindAsync(id);
        }

        public async Task<IEnumerable<Schedule>> GetSchedulesByRouteIdAsync(int routeId)
        {
            return await _dbContext.Schedules
                .Where(s => s.RouteId == routeId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Schedule>> GetSchedulesByBusIdAsync(int busId)
        {
            return await _dbContext.Schedules
                .Where(s => s.BusId == busId)
                .ToListAsync();
        }

        public async Task CreateSchedule(Schedule schedule)
        {
            await _dbContext.Schedules.AddAsync(schedule);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateSchedule(Schedule schedule)
        {
            _dbContext.Schedules.Update(schedule);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteSchedule(int id)
        {
            var schedule = await _dbContext.Schedules.FindAsync(id);
            _dbContext.Schedules.Remove(schedule);
            await _dbContext.SaveChangesAsync();
        }*/

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
