using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public interface IScheduleRepository
    {
        public ICollection<Schedule> GetAllSchedules();
        public Schedule GetScheduleById(int id);
        public bool CreateSchedule(Schedule schedule);
        public void UpdateSchedule(Schedule schedule);
        public bool HasAssociatedBookings(int scheduleId);
        public void DeleteSchedule(Schedule schedule);
    }
}
