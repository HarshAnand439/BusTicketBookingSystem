using DAL.Data;
using DAL.Models;
using DAL.Repository;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace DAL.Repository
{
    public class BusRepository : IBusRepository
    {
        private readonly AppDbContext _context;

        public BusRepository(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        public ICollection<Bus> GetAllBuses()
        {
            return _context.Buses.OrderBy(x => x.BusId).ToList();
        }

        public Bus GetBusById(int id)
        {
            return _context.Buses.Where(x => x.BusId == id).FirstOrDefault();
        }

        public bool CreateBus(Bus bus)
        {
            if ((_context.Buses.Add(bus)) != null)
            {
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public void UpdateBus(Bus bus)
        {
            _context.Buses.Update(bus);
            _context.SaveChanges();
        }

        public void DeleteBus(Bus bus)
        {
            _context.Buses.Remove(bus);
            _context.SaveChanges();
        }
    }
}
