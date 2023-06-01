using BLL.Services;
using DAL.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ServiceLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ICustomerService customerService, ILogger<CustomerController> logger)
        {
            _customerService = customerService;
            _logger = logger;
        }

        [HttpGet("GetCustomers")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Customer>))]
        public IActionResult GetAllCustomers()
        {
            try
            {
                var Customers = _customerService.GetAllCustomers();
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _logger.LogInformation("Customers Fetched.");
                return Ok(Customers);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while retrieving Customers.");
                return StatusCode(500);
            }
        }

        [HttpGet("GetCustomerById")]
        public IActionResult GetCustomerById(int id)
        {
            try
            {
                var customer = _customerService.GetCustomerById(id);
                if (customer == null)
                {
                    return NotFound();
                }
                _logger.LogInformation("Customer are fetched by ID");
                return Ok(customer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving a Customer by ID.");
                return StatusCode(500);
            }
        }

        [HttpPost("CreateCustomer")]
        public IActionResult CreateCustomer(Customer customer)
        {
            try
            {
                if (customer == null)
                {
                    return BadRequest(ModelState);
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (!_customerService.CreateCustomer(customer))
                {
                    ModelState.AddModelError("", "Customer is not Created [CONTOLLER]");
                    return StatusCode(500, ModelState);
                }
                _logger.LogInformation("Customer is Created");
                return Ok("Customer Successfully Created");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a Customer.");
                return StatusCode(500);
            }
        }

        [HttpPut("UpdateCustomer")]
        public IActionResult UpdateCustomer(int id, Customer customer)
        {
            try
            {
                if (id != customer.CustomerId)
                {
                    return BadRequest();
                }

                _customerService.UpdateCustomer(customer);
                _logger.LogInformation("Customer is Created");

                return Ok("Customer Successfully Updated");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating a Customer.");
                return StatusCode(500);
            }
        }

        [HttpDelete("DeleteCustomer")]
        public IActionResult DeleteCustomer(int id)
        {
            try
            {
                var customer = _customerService.GetCustomerById(id);

                if (customer == null)
                {
                    return NotFound();
                }
                _customerService.DeleteCustomer(customer);
                _logger.LogInformation("Customer is Deleted");

                return Ok("Customer Successfully Deleted");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting a Customer.");
                return StatusCode(500);
            }
        }

        /*[HttpGet]
        public ActionResult<IEnumerable<Customer>> GetAllCustomers()
        {
            var customers = _customerService.GetAllCustomers();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomerById(int id)
        {
            var customer = _customerService.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        public ActionResult<Customer> CreateCustomer(Customer customer)
        {
            _customerService.CreateCustomer(customer);
            return CreatedAtAction(nameof(GetCustomerById), new { id = customer.CustomerId }, customer);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCustomer(int id, Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return BadRequest();
            }

            _customerService.UpdateCustomer(customer);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var existingCustomer = _customerService.GetCustomerById(id);

            if (existingCustomer == null)
            {
                return NotFound();
            }

            _customerService.DeleteCustomer(existingCustomer);

            return NoContent();
        }*/
    }
}
