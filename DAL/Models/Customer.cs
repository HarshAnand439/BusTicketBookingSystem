using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Customer
    {

        [Key]
        public int CustomerId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(1, 99)]
        public int Age { get; set; }
    }
}
