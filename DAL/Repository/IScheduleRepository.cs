using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public interface IScheduleRepository
    {
        /*public Task<IEnumerable<Schedule>> GetAllSchedules();
        public Task<Schedule> GetScheduleById(int id);
        public Task<IEnumerable<Schedule>> GetSchedulesByRouteIdAsync(int routeId);
        public Task<IEnumerable<Schedule>> GetSchedulesByBusIdAsync(int busId);
        public Task CreateSchedule(Schedule schedule);
        public Task UpdateSchedule(Schedule schedule);
        public Task DeleteSchedule(int id);
        public Task<int> GetAvailableSeatsAsync(int scheduleId);*/

        public ICollection<Schedule> GetAllSchedules();
        public Schedule GetScheduleById(int id);
        public bool CreateSchedule(Schedule schedule);
        public void UpdateSchedule(Schedule schedule);
        public void DeleteSchedule(Schedule schedule);
    }
}
