using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CustomerDTO
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

        public static explicit operator Customer(CustomerDTO dto)
        {
            if (dto == null)
                return null;

            return new Customer
            {
                CustomerId = dto.CustomerId,
                Name = dto.Name,
                Email = dto.Email,
                PhoneNo = dto.PhoneNo
            };
        }

        public static implicit operator CustomerDTO(Customer customer)
        {
            if (customer == null)
                return null;

            return new CustomerDTO
            {
                CustomerId = customer.CustomerId,
                Name = customer.Name,
                Email = customer.Email,
                PhoneNo = customer.PhoneNo
            };
        }
    }
}
