using BLL.DTOs;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IBusService
    {
        public ICollection<Bus> GetAllBuses();
        Bus GetBusById(int id);
        bool CreateBus(BusDTO bus);
        void UpdateBus(Bus bus);
        void DeleteBus(Bus bus);
    }
}
