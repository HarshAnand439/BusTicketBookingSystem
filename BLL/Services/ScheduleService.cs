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
            // Business validations before creating the schedule
            if (schedule.DepTime >= schedule.ArrTime)
            {
                throw new InvalidDataException("Departure time must be before the arrival time.");
            }

            if (_scheduleRepository.CreateSchedule(schedule))
            {
                return true;
            }
            return false;
        }

        /*public bool CreateSchedule(ScheduleDTO schedule)
        {
            // Business validations before creating the schedule
            if (schedule.DepTime >= schedule.ArrTime)
            {
                throw new InvalidDataException("Departure time must be before the arrival time.");
            }
            var temp = new Schedule
            {
                RouteId = schedule.RouteId,
                PathRoute = schedule.PathRoute,
                BusId = schedule.BusId,
                Bus = schedule.Bus,
                DepTime = schedule.DepTime,
                ArrTime = schedule.ArrTime,
                AvailSeats = schedule.AvailSeats
            };
            if (_scheduleRepository.CreateSchedule(temp))
            {
                return true;
            }
            return false;
        }*/
        public void UpdateSchedule(Schedule schedule)
        {
            // Business validations before updating the schedule
            if (schedule.DepTime >= schedule.ArrTime)
            {
                throw new InvalidDataException("Departure time must be before the arrival time.");
            }

            _scheduleRepository.UpdateSchedule(schedule);
        }
        public void DeleteSchedule(Schedule schedule)
        {
            // Check if the schedule has associated bookings before deleting
            if (_scheduleRepository.HasAssociatedBookings(schedule.ScheduleId))
            {
                throw new InvalidOperationException("Cannot delete the schedule as it has associated bookings.");
            }

            _scheduleRepository.DeleteSchedule(schedule);
        }
    }
}
