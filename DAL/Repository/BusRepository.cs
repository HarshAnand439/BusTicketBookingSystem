using DAL.Data;
using DAL.Models;
using DAL.Repository;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace DAL.Repository
{
    public class BusRepository : IBusRepository
    {
        private readonly AppDbContext _dbContext;

        public BusRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Bus>> GetAllBusesAsync()
        {
            return await _dbContext.Buses.ToListAsync();
        }

        public async Task<Bus> GetBusByIdAsync(int id)
        {
            return await _dbContext.Buses.FindAsync(id);
        }

        public async Task<bool> UpdateBusAsync(Bus bus)
        {
            _dbContext.Entry(bus).State = EntityState.Modified;
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task AddBusAsync(Bus bus)
        {
            await _dbContext.Buses.AddAsync(bus);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteBusAsync(Bus bus)
        {
            _dbContext.Buses.Remove(bus);
            await _dbContext.SaveChangesAsync();
        }
    }
}
