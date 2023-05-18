using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public interface IBusRepository
    {
        public Task<IEnumerable<Bus>> GetAllBusesAsync();
        public Task<Bus> GetBusByIdAsync(int id);
        public Task<bool> UpdateBusAsync(Bus bus);
        public Task AddBusAsync(Bus bus);
        public Task DeleteBusAsync(Bus bus);
    }
}
