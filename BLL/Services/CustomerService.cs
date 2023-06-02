using BLL.DTOs;
using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public ICollection<Customer> GetAllCustomers()
        {
            return _customerRepository.GetAllCustomers();
        }
        public Customer GetCustomerById(int id)
        {
            return _customerRepository.GetCustomerById(id);
        }
        public bool CreateCustomer(CustomerDTO customer)
        {
            var temp = new Customer
            {
                Name = customer.Name,
                Age = customer.Age
            };
            /*if (IsValidCustomer(temp))
            {*/
                var s = _customerRepository.CreateCustomer(temp);
                if (s)
                {
                    return true;
                }
            /*}*/
            return false;
            /*return _customerRepository.CreateCustomer(temp);*/
        }
        public void UpdateCustomer(Customer customer)
        {
            if (IsValidCustomer(customer))
            {
                _customerRepository.UpdateCustomer(customer);
            }
        }
        public void DeleteCustomer(Customer customer)
        {
            if (HasNoAssociatedBookings(customer.CustomerId))
            {
                _customerRepository.DeleteCustomer(customer);
            }
        }

        private bool IsValidCustomer(Customer customer)
        {
            if (customer.Age >= 10 && customer.Age <= 100)
            {
                return true;
            }
            return false;
        }

        private bool HasNoAssociatedBookings(int customerId)
        {
            // Check if the customer has any associated bookings
            return _customerRepository.GetCustomerBookingsCount(customerId) == 0;
        }
    }
}
