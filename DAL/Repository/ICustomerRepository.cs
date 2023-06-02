using DAL.Data;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface ICustomerRepository
    {
        public ICollection<Customer> GetAllCustomers();
        public Customer GetCustomerById(int id);
        public int GetCustomerBookingsCount(int customerId);
        public bool CreateCustomer(Customer customer);
        public void UpdateCustomer(Customer customer);
        public void DeleteCustomer(Customer customer);
    }
}
