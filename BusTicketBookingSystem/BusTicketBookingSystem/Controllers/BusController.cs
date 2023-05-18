using BLL.DTOs;
using BLL.Services;
using DAL.Models;
using DAL.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ServiceLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusController : ControllerBase
    {
        private readonly BLL.Services.IBusService _busService;

        public BusController(IBusService busService)
        {
            _busService = busService;
        }

        // GET: api/Bus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bus>>> GetBuses()
        {
            var buses = await _busService.GetAllBusesAsync();

            return Ok(buses);
        }

        // GET: api/Bus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bus>> GetBus(int id)
        {
            var bus = await _busService.GetBusByIdAsync(id);

            if (bus == null)
            {
                return NotFound("Invalid ID");
            }

            return Ok(bus);
        }

        // PUT: api/Bus/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBus(int id, Bus bus)
        {
            if (id != bus.BusId)
            {
                return BadRequest();
            }

            var result = await _busService.UpdateBusAsync(bus);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Bus
        [HttpPost]
        public async Task<ActionResult<Bus>> PostBus(Bus bus)
        {
            await _busService.AddBusAsync(bus);

            return CreatedAtAction("GetBus", new { id = bus.BusId }, bus);
        }

        // DELETE: api/Bus/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Bus>> DeleteBus(int id)
        {
            var bus = await _busService.GetBusByIdAsync(id);

            if (bus == null)
            {
                return NotFound();
            }

            await _busService.DeleteBusAsync(bus);

            return Ok(bus);
        }
    }
}
