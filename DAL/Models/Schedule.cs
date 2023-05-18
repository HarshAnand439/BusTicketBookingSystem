using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Schedule
    {
        [Key]
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
    }
}
