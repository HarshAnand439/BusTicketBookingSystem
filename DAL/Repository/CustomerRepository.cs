﻿using DAL.Data;
using DAL.Models;

namespace DAL.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;
        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }
        /*public IEnumerable<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }
        public Customer GetCustomerById(int id)
        {
            return _context.Customers.Find(id);
        }
        public void CreateCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }
        public void UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
        }
        public void DeleteCustomer(Customer customer)
        {
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }*/

        public ICollection<Customer> GetAllCustomers()
        {
            return _context.Customers.OrderBy(x => x.CustomerId).ToList();
        }

        public Customer GetCustomerById(int id)
        {
            return _context.Customers.Where(x => x.CustomerId == id).FirstOrDefault();
        }

        public bool CreateCustomer(Customer customer)
        {
            if ((_context.Customers.Add(customer)) != null)
            {
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public void UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
        }

        public void DeleteCustomer(Customer customer)
        {
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }
    }
}