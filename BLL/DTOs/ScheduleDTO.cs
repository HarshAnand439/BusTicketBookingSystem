using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ScheduleDTO
    {
        public int RouteId { get; set; }
        public PathRoute PathRoute { get; set; }
        public int BusId { get; set; }
        public Bus Bus { get; set; }
        public DateTime DepTime { get; set; }
        public DateTime ArrTime { get; set; }
        public int AvailSeats { get; set; }

        public static explicit operator Schedule(ScheduleDTO dto)
        {
            if (dto == null)
                return null;

            return new Schedule
            {
                RouteId = dto.RouteId,
                BusId = dto.BusId,
                DepTime = dto.DepTime,
                ArrTime = dto.ArrTime,
                AvailSeats = dto.AvailSeats
            };
        }

        public static implicit operator ScheduleDTO(Schedule schedule)
        {
            if (schedule == null)
                return null;

            return new ScheduleDTO
            {
                RouteId = schedule.RouteId,
                BusId = schedule.BusId,
                DepTime = schedule.DepTime,
                ArrTime = schedule.ArrTime,
                AvailSeats = schedule.AvailSeats
            };
        }
    }
}
