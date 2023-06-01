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
        private readonly IBusService _busService;
        private readonly ILogger<BusController> _logger;

        public BusController(IBusService busService, ILogger<BusController> logger)
        {
            _busService = busService;
            _logger = logger;
        }

        [HttpGet("GetBuses")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Bus>))]
        public IActionResult GetAllBuses()
        {
            try
            {
                var Buses = _busService.GetAllBuses();
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _logger.LogInformation("Buses Fetched.");
                return Ok(Buses);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while retrieving Buses.");
                return StatusCode(500);
            }
        }

        [HttpGet("GetBusById")]
        public IActionResult GetBusById(int id)
        {
            try
            {
                var bus = _busService.GetBusById(id);
                if (bus == null)
                {
                    return NotFound();
                }
                _logger.LogInformation("Bus are fetched by ID");
                return Ok(bus);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving a Bus by ID.");
                return StatusCode(500);
            }
        }

        [HttpPost("CreateBus")]
        public IActionResult CreateBus(BusDTO bus)
        {
            try
            {
                if (bus == null)
                {
                    return BadRequest(ModelState);
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (!_busService.CreateBus(bus))
                {
                    ModelState.AddModelError("", "Bus is not Created [CONTOLLER]");
                    return StatusCode(500, ModelState);
                }
                _logger.LogInformation("Bus is Created");
                return Ok("Bus Successfully Created");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a Bus.");
                return StatusCode(500);
            }
        }

        [HttpPut("UpdateBus")]
        public IActionResult Updatebus(int id, Bus bus)
        {
            try
            {
                if (id != bus.BusId)
                {
                    return BadRequest();
                }

                _busService.UpdateBus(bus);
                _logger.LogInformation("Bus is Created");

                return Ok("Bus Successfully Updated");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating a Bus.");
                return StatusCode(500);
            }
        }

        [HttpDelete("DeleteBus")]
        public IActionResult DeleteBus(int id)
        {
            try
            {
                var bus = _busService.GetBusById(id);

                if (bus == null)
                {
                    return NotFound();
                }
                _busService.DeleteBus(bus);
                _logger.LogInformation("Bus is Deleted");

                return Ok("Bus Successfully Deleted");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting a Bus.");
                return StatusCode(500);
            }
        }
    }
}
