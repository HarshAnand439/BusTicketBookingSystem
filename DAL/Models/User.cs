using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class User
    {
        [Key]
        [Required]
        public int UserId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        [StringLength(255)]
        [Required]
        public string UserName { get; set; }

        [StringLength(255)]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string? Token { get; set; }

        /*[Key]
        [Required]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }*/


        /*public bool IsAdmin { get; set; }*/

        /*public string UserName { get; set; }
        public string Password { get; set; }*/
    }
}
