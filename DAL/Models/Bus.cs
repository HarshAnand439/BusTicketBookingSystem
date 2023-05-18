using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Bus
    {
        [Key]
        [Required]
        public int BusId { get; set; }

        [StringLength(255)]
        [Required]
        public string? BusNumber { get; set; }

        [Required]
        public int Capacity { get; set; }
    }
}
