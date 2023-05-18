using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IScheduleService
    {
        public Task<IEnumerable<Schedule>> GetAllSchedules();
        public Task<Schedule> GetScheduleById(int id);
        public Task CreateSchedule(Schedule schedule);
        public Task UpdateSchedule(Schedule schedule);
        public Task DeleteSchedule(int id);
    }
}
