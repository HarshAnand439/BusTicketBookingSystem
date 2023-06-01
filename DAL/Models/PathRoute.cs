using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class PathRoute
    {
        /*[Key]
        [Required]
        public int RouteId { get; set; }

        [StringLength(255)]
        [Required]
        public string Source { get; set; }

        [StringLength(255)]
        [Required]
        public string Destination { get; set; }

        [Required]
        public int Distance { get; set; }

        [Required]
        public int Price { get; set; }*/

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
