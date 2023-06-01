using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class PathRoute
    {
        [Key]
        public int RouteId { get; set; }

        [Required]
        public string Source { get; set; }

        [Required]
        public string Destination { get; set; }

        [Range(1, int.MaxValue)]
        public int Distance { get; set; }

        [Range(1, int.MaxValue)]
        public int Price { get; set; }
    }
}
