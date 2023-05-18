using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Customer
    {
        [Key]
        [Required]
        public int CustomerId { get; set; }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        [StringLength(255)]
        [Required]
        public string Email { get; set; }

        [Required]
        public int PhoneNo { get; set; }
    }
}
