using DAL.Data;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly AppDbContext _dbContext;

        public ScheduleRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Schedule>> GetAllSchedules()
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
        }

        public async Task<int> GetAvailableSeatsAsync(int scheduleId)
        {
            var schedule = await _dbContext.Schedules.FindAsync(scheduleId);
            if (schedule == null)
            {
                throw new ArgumentException("Invalid schedule ID");
            }

            var bookedSeats = await _dbContext.Bookings
                .Where(b => b.ScheduleId == scheduleId)
                .Select(b => b.SeatNo)
                .DefaultIfEmpty(0)
                .SumAsync();

            return schedule.AvailSeats - bookedSeats;
        }
    }
}
