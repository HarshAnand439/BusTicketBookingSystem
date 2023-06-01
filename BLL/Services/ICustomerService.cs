using BLL.DTOs;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface ICustomerService
    {
        public ICollection<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        bool CreateCustomer(CustomerDTO customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
    }
}
