using AutoMapper;
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

        public async Task<IEnumerable<Bus>> GetAllBusesAsync()
        {
            return await _busRepository.GetAllBusesAsync();
        }

        public async Task<Bus> GetBusByIdAsync(int id)
        {
            return await _busRepository.GetBusByIdAsync(id);
        }

        public async Task<bool> UpdateBusAsync(Bus bus)
        {
            var existingBus = await _busRepository.GetBusByIdAsync(bus.BusId);

            if (existingBus == null)
            {
                return false;
            }

            existingBus.BusNumber = bus.BusNumber;
            existingBus.Capacity = bus.Capacity;

            return await _busRepository.UpdateBusAsync(existingBus);
        }

        public async Task AddBusAsync(Bus bus)
        {
            await _busRepository.AddBusAsync(bus);
        }

        public async Task DeleteBusAsync(Bus bus)
        {
            await _busRepository.DeleteBusAsync(bus);
        }
    }
}

