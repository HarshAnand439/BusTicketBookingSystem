using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Bus
    {
        [Key]
        public int BusId { get; set; }

        [Required]
        public string BusNumber { get; set; }

        [Range(1, int.MaxValue)]
        public int Capacity { get; set; }
    }
}
