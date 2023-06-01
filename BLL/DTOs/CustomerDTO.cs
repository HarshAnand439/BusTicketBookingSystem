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
        public string Name { get; set; }
        public int Age { get; set; }

        public static explicit operator Customer(CustomerDTO dto)
        {
            if (dto == null)
                return null;

            return new Customer
            {
                Name = dto.Name,
                Age = dto.Age
            };
        }

        public static implicit operator CustomerDTO(Customer customer)
        {
            if (customer == null)
                return null;

            return new CustomerDTO
            {
                Name = customer.Name,
                Age = customer.Age
            };
        }
    }
}
