using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public interface IBusRepository
    {
        public ICollection<Bus> GetAllBuses();
        public Bus GetBusById(int id);
        public Bus GetBusByNumber(string BusNumber);
        public bool HasAssociatedSchedules(int busId);
        public bool HasAssociatedBookings(int BusId);
        public bool CreateBus(Bus bus);
        public void UpdateBus(Bus bus);
        public void DeleteBus(Bus bus);
    }
}
