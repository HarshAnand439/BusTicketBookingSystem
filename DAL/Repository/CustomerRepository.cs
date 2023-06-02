using DAL.Data;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;
        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public ICollection<Customer> GetAllCustomers()
        {
            return _context.Customers.OrderBy(x => x.CustomerId).ToList();
        }

        public Customer GetCustomerById(int id)
        {
            return _context.Customers.Where(x => x.CustomerId == id).FirstOrDefault();
        }

        public int GetCustomerBookingsCount(int customerId)
        {
            return _context.Bookings.Count(b => b.CustomerId == customerId);
        }

        public bool CreateCustomer(Customer customer)
        {
            if (_context.Customers.Add(customer) != null)
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
