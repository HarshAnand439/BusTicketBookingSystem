using BLL.DTOs;
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

        /*public async Task<IEnumerable<Schedule>> GetAllSchedules()
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
        }*/

        public ICollection<Schedule> GetAllSchedules()
        {
            return _scheduleRepository.GetAllSchedules();
        }
        public Schedule GetScheduleById(int id)
        {
            return _scheduleRepository.GetScheduleById(id);
        }
        public bool CreateSchedule(Schedule schedule)
        {
            /*var temp = new Schedule
            {
                ScheduleId = schedule.ScheduleId,
                RouteId = schedule.RouteId,
                BusId = schedule.BusId,
                DepTime = schedule.DepTime,
                ArrTime = schedule.ArrTime,
                AvailSeats = schedule.AvailSeats
            };*/
            if (_scheduleRepository.CreateSchedule(schedule))
            {
                return true;
            }
            return false;
        }
        public void UpdateSchedule(Schedule schedule)
        {
            _scheduleRepository.UpdateSchedule(schedule);
        }
        public void DeleteSchedule(Schedule schedule)
        {
            _scheduleRepository.DeleteSchedule(schedule);
        }
    }
}
