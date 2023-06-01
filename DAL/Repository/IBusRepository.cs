using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public interface IBusRepository
    {
        public ICollection<Bus> GetAllBuses();
        public Bus GetBusById(int id);
        public bool CreateBus(Bus bus);
        public void UpdateBus(Bus bus);
        public void DeleteBus(Bus bus);
    }
}
