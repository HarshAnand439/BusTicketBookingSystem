using BLL.DTOs;
using BLL.Services;
using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class BusService : IBusService
    {
        private readonly IBusRepository _busRepository;

        public BusService(IBusRepository busRepository)
        {
            _busRepository = busRepository;
        }

        public ICollection<Bus> GetAllBuses()
        {
            return _busRepository.GetAllBuses();
        }
        public Bus GetBusById(int id)
        {
            return _busRepository.GetBusById(id);
        }
        public bool CreateBus(BusDTO bus)
        {
            var temp = new Bus
            {
                BusNumber = bus.BusNumber,
                Capacity = bus.Capacity
            };

            if (_busRepository.CreateBus(temp))
            {
                return true;
            }
            return false;
        }
        public void UpdateBus(Bus bus)
        {
            _busRepository.UpdateBus(bus);
        }
        public void DeleteBus(Bus bus)
        {
            _busRepository.DeleteBus(bus);
        }
    }
}

