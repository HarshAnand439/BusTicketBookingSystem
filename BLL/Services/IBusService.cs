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
        /*public List<BusDTO> GetBuses();
        public BusDTO GetBusById(int id);*/

        public Task<IEnumerable<Bus>> GetAllBusesAsync();
        public Task<Bus> GetBusByIdAsync(int id);
        public Task<bool> UpdateBusAsync(Bus bus);
        public Task AddBusAsync(Bus bus);
        public Task DeleteBusAsync(Bus bus);
    }
}
