using BLL.Services;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ServiceLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly ILogger<BookingController> _logger;

        public BookingController(IBookingService bookingService, ILogger<BookingController> logger)
        {
            _bookingService = bookingService;
            _logger = logger;
        }

        [HttpGet("GetBookings")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Booking>))]
        public IActionResult GetAllBookings()
        {
            try
            {
                var Bookinges = _bookingService.GetAllBookings();
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _logger.LogInformation("Bookinges Fetched.");
                return Ok(Bookinges);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while retrieving Bookinges.");
                return StatusCode(500);
            }
        }

        [HttpGet("GetBookingById")]
        public IActionResult GetBookingById(int id)
        {
            try
            {
                var booking = _bookingService.GetBookingById(id);
                if (booking == null)
                {
                    return NotFound();
                }
                _logger.LogInformation("Booking are fetched by ID");
                return Ok(booking);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving a Booking by ID.");
                return StatusCode(500);
            }
        }

        [HttpPost("Create Booking")]
        public IActionResult CreateBooking(Booking booking)
        {
            try
            {
                if (booking == null)
                {
                    return BadRequest(ModelState);
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (!_bookingService.CreateBooking(booking))
                {
                    ModelState.AddModelError("", "Booking is not Created [CONTOLLER]");
                    return StatusCode(500, ModelState);
                }
                _logger.LogInformation("Booking is Created");
                return Ok("Booking Successfully Created");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a Booking.");
                return StatusCode(500);
            }
        }

        [HttpPut("UpdateBooking")]
        public IActionResult UpdateBooking(int id, Booking booking)
        {
            try
            {
                if (id != booking.BookingId)
                {
                    return BadRequest();
                }

                _bookingService.UpdateBooking(booking);
                _logger.LogInformation("Booking is Created");

                return Ok("Booking Successfully Updated");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating a Booking.");
                return StatusCode(500);
            }
        }

        [HttpDelete("DeleteBooking")]
        public IActionResult DeleteBooking(int id)
        {
            try
            {
                var booking = _bookingService.GetBookingById(id);

                if (booking == null)
                {
                    return NotFound();
                }
                _bookingService.DeleteBooking(booking);
                _logger.LogInformation("Booking is Deleted");

                return Ok("Booking Successfully Deleted");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting a Booking.");
                return StatusCode(500);
            }
        }

        /*[HttpGet]
        public ActionResult<IEnumerable<Booking>> GetAllBookings()
        {
            var bookings = _bookingService.GetAllBookings();
            return Ok(bookings);
        }

        [HttpGet("{id}")]
        public ActionResult<Booking> GetBookingById(int id)
        {
            var booking = _bookingService.GetBookingById(id);
            if (booking == null)
            {
                return NotFound();
            }
            return Ok(booking);
        }

        [HttpPost]
        public ActionResult<Booking> CreateBooking(Booking booking)
        {
            _bookingService.CreateBooking(booking);
            return Ok(booking);
        }

        [HttpPut("{id}")]
        public ActionResult<Booking> UpdateBooking(int id, Booking booking)
        {
            if (id != booking.BookingId)
            {
                return BadRequest();
            }
            _bookingService.UpdateBooking(booking);
            return Ok(booking);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteBooking(int id)
        {
            var booking = _bookingService.GetBookingById(id);
            if (booking == null)
            {
                return NotFound();
            }
            _bookingService.DeleteBooking(booking);
            return NoContent();
        }*/
    }
}
