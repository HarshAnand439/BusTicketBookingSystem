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
            // Check if the BusNumber already exists
            if (_busRepository.GetBusByNumber(bus.BusNumber) != null)
            {
                // BusNumber already exists, return false or throw an exception
                return false;
            }
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
            // Check if the BusNumber already exists for a different bus
            /*var existingBus = _busRepository.GetBusByNumber(bus.BusNumber);
            if (existingBus != null && existingBus.BusId != bus.BusId)
            {
                return;
            }*/
            _busRepository.UpdateBus(bus);
        }
        public void DeleteBus(Bus bus)
        {
            // Check if the bus has associated schedules or bookings
            var hasAssociatedSchedules = _busRepository.HasAssociatedSchedules(bus.BusId);
            var hasAssociatedBookings = _busRepository.HasAssociatedBookings(bus.BusId);

            if (hasAssociatedSchedules || hasAssociatedBookings)
            {
                return;
            }
            _busRepository.DeleteBus(bus);
        }
    }
}

