using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;

        public ScheduleService(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public async Task<IEnumerable<Schedule>> GetAllSchedules()
        {
            return await _scheduleRepository.GetAllSchedules();
        }

        public async Task<Schedule> GetScheduleById(int id)
        {
            return await _scheduleRepository.GetScheduleById(id);
        }

        public async Task CreateSchedule(Schedule schedule)
        {
            await _scheduleRepository.CreateSchedule(schedule);
        }

        public async Task UpdateSchedule(Schedule schedule)
        {
            await _scheduleRepository.UpdateSchedule(schedule);
        }

        public async Task DeleteSchedule(int id)
        {
            await _scheduleRepository.DeleteSchedule(id);
        }
    }
}
