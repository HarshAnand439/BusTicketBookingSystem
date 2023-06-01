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
        /*[Key]
        [Required]
        public int ScheduleId { get; set; }

        [ForeignKey("PathRoute")]
        public int RouteId { get; set; }
        [Required]
        public PathRoute PathRoute { get; set; }

        [ForeignKey("Bus")]
        public int BusId { get; set; }
        [Required]
        public Bus Bus { get; set; }

        [Required]
        public DateTime DepTime { get; set; }

        [Required]
        public DateTime ArrTime { get; set; }

        [Required]
        public int AvailSeats { get; set; }

        public static explicit operator Schedule(ScheduleDTO dto)
        {
            if (dto == null)
                return null;

            return new Schedule
            {
                ScheduleId = dto.ScheduleId,
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
                ScheduleId = schedule.ScheduleId,
                RouteId = schedule.RouteId,
                BusId = schedule.BusId,
                DepTime = schedule.DepTime,
                ArrTime = schedule.ArrTime,
                AvailSeats = schedule.AvailSeats
            };
        }*/

        public int ScheduleId { get; set; }
        public int RouteId { get; set; }
        public int BusId { get; set; }
        public DateTime DepTime { get; set; }
        public DateTime ArrTime { get; set; }
        public int AvailSeats { get; set; }

        public static explicit operator Schedule(ScheduleDTO dto)
        {
            if (dto == null)
                return null;

            return new Schedule
            {
                ScheduleId = dto.ScheduleId,
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
                ScheduleId = schedule.ScheduleId,
                RouteId = schedule.RouteId,
                BusId = schedule.BusId,
                DepTime = schedule.DepTime,
                ArrTime = schedule.ArrTime,
                AvailSeats = schedule.AvailSeats
            };
        }
    }
}
